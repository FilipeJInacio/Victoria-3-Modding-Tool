using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Victoria_3_Modding_Tool.Forms.Era;
using Victoria_3_Modding_Tool.Forms.Tech;

namespace Victoria_3_Modding_Tool
{
    public partial class TechForm : Form
    {
        public List<ClassTech> TechList; // Needed   (Victoria 3 + Project)

        public List<ClassEra> EraList; // Needed   (Victoria 3 + Project)

        public ClassTech local;  // null if new   information if to change

        public bool[] canSave = { false, false, false, false, false }; // Name - Era - Category - Texture - Desc  false -> cant save
        public int SaveStatus = 0;    // 0 -> opened just now   1 -> is saved   2 -> is not

        public int sizeOfVicky; // Needed


        public TechForm()
        {
            InitializeComponent();
            this.Padding = new Padding(1);//Border size
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width/4, 0);

        }

        public ClassTech ReturnValue()
        {
            if (SaveStatus == 1) // saved
            {
                return local;
            }
            else { return null; }  // No save
            
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Border
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        protected override void OnPaint(PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.FromArgb(61, 61, 61), ButtonBorderStyle.Solid);

            base.OnPaint(e);
            Graphics graph = e.Graphics;
            //Draw border

            using (Pen penBorder = new Pen(Color.FromArgb(66, 66, 66), 2))
            {
                penBorder.Alignment = PenAlignment.Inset;
                graph.DrawRectangle(penBorder, NeededTechLB.Location.X - 2, NeededTechLB.Location.Y - 2, NeededTechLB.Width + 4F, NeededTechLB.Height + 4F);
                graph.DrawRectangle(penBorder, ModifiersLB.Location.X - 2, ModifiersLB.Location.Y - 2, ModifiersLB.Width + 4F, ModifiersLB.Height + 4F);
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // LB Styling
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void LB_DrawItem(object sender, DrawItemEventArgs e, ListBox LB)
        {
            Color backgroundColor = Color.FromArgb(50, 50, 50);
            Color horizontalColor = Color.FromArgb(100, 100, 100);


            if (e.Index >= 0)
            {
                SolidBrush sb = new SolidBrush(((e.State & DrawItemState.Selected) == DrawItemState.Selected) ? horizontalColor : backgroundColor);
                e.Graphics.FillRectangle(sb, e.Bounds);
                string text = LB.Items[e.Index].ToString();
                SolidBrush tb = new SolidBrush(e.ForeColor);
                e.Graphics.DrawString(text, e.Font, tb, LB.GetItemRectangle(e.Index).Location);
            }
        }

        private void NeededTechLB_DrawItem_1(object sender, DrawItemEventArgs e)
        {
            LB_DrawItem(sender, e, NeededTechLB);
        }

        private void ModifiersLB_DrawItem(object sender, DrawItemEventArgs e)
        {
            LB_DrawItem(sender, e, ModifiersLB);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Hot Bar Buttons
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void CloseBT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MinimiseBT_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void HelpBT_Click(object sender, EventArgs e)
        {
            using (TechHelp form = new TechHelp())
            {
                form.ShowDialog();
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Hot Bar Drag Motion
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void HotBarP_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // ListBox Events
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void NeededTechLB_DoubleClick(object sender, EventArgs e)
        {
            if (NeededTechLB.SelectedIndex != 0)
            {
                NeededTechLB.Items.RemoveAt(NeededTechLB.SelectedIndex);
                SaveStatus = 2;
            }

        }

        private void ModifiersLB_DoubleClick(object sender, EventArgs e)
        {
            // To do
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Button Events
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void TexturePathBT_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "dds files (*.dds)|*.dds";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;



                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {

                    //Get the path of specified file
                    TextureTB.Texts = openFileDialog.FileName.Substring(openFileDialog.FileName.IndexOf("gfx"));

                }

            }
        }

        private void AddTechBT_Click(object sender, EventArgs e)
        {
            if (NeededCB.SelectedIndex != -1)
            {
                if (!NeededTechLB.Items.Contains(NeededCB.SelectedItem))
                {
                    NeededTechLB.Items.Add(NeededCB.SelectedItem);
                }
            }

        }

        private void ModifiersBT_Click(object sender, EventArgs e)
        {

        } // To Do

        private void SaveBT_Click(object sender, EventArgs e)
        {
            SaveVerification();
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Load/Save Information
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        private bool SaveVerification()
        {
            if (!string.IsNullOrEmpty(NameTB.Texts) && !new ClassTech().hasName(TechList.GetRange(sizeOfVicky, TechList.Count - sizeOfVicky), NameTB.Texts) && Regex.Match(NameTB.Texts, "^([a-z]||_)+$").Success)
            {
                canSave[0] = true;
            }
            else { canSave[0] = false; }

            bool verifName = new ClassTech().hasName(TechList.GetRange(sizeOfVicky, TechList.Count - sizeOfVicky), NameTB.Texts);

            if (Regex.Match(DescriptionTB.Texts, "^[\\u0000-\\u007E]+$").Success)
            {
                canSave[4] = true;
            }
            else { canSave[4] = false; }

            if (canSave[0] == false || verifName)
            {
                NameTB.BorderColor = Color.FromArgb(255, 39, 58);
                NameTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                NameTB.BorderColor = Color.FromArgb(66, 66, 66);
                NameTB.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }



            if (canSave[1] == false)
            {
                EraCB.BorderColor = Color.FromArgb(255, 39, 58);
            }
            else
            {
                EraCB.BorderColor = Color.FromArgb(66, 66, 66);
            }

            if (canSave[2] == false)
            {
                CategoryCB.BorderColor = Color.FromArgb(255, 39, 58);
            }
            else
            {
                CategoryCB.BorderColor = Color.FromArgb(66, 66, 66);
            }

            if (canSave[3] == false)
            {
                TextureTB.BorderColor = Color.FromArgb(255, 39, 58);
                TextureTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                TextureTB.BorderColor = Color.FromArgb(66, 66, 66);
                TextureTB.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[4] == false)
            {
                DescriptionTB.BorderColor = Color.FromArgb(255, 39, 58);
                DescriptionTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                DescriptionTB.BorderColor = Color.FromArgb(66, 66, 66);
                DescriptionTB.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[0] == true && canSave[1] == true && canSave[2] == true && canSave[3] == true && !verifName && canSave[4] == true)
            {
                Save_Technology();

                SaveStatus = 1;
                return true;
            }
            return false;
        }

        private void LoadInfoToControls()
        {

            NameTB.Texts = local.name;

            NameGameTB.Texts = local.TrueName;

            EraCB.SelectedIndex = local.era - 1;

            TextureTB.Texts = local.texture;
            DescriptionTB.Texts = local.Desc;

            switch (local.category)
            {
                case "production":
                    CategoryCB.SelectedIndex = 0;
                    break;
                case "military":
                    CategoryCB.SelectedIndex = 1;
                    break;
                case "society":
                    CategoryCB.SelectedIndex = 2;
                    break;
            }

            if (local.canResearch == false)
            {
                CanResearchCB.Checked = false;
            }

            int i = 0;

            NeededCB.Items.Clear();
            NeededCB.Items.Add(String.Format("{0,-65}{1,-5 }{2,-10 }", "Tech", "Era", "Category"));
            foreach (ClassTech TechEntry in TechList)
            {
                if (TechEntry.category == CategoryCB.SelectedItem.ToString().ToLower())
                {
                    NeededCB.Items.Add(String.Format("{0,-65}{1,-5 }{2,-10 }", TechEntry.name, TechEntry.era, TechEntry.category.ToUpper()[0] + TechEntry.category.Substring(1)));
                }
            }


            foreach (string needTech in local.restrictions)
            {
                foreach (ClassTech techsingular in TechList)
                {
                    if (techsingular.name == needTech)
                    {
                        break;
                    }
                    i++;
                }

                NeededTechLB.Items.Add(String.Format("{0,-65}{1,-5 }{2,-10 }", TechList[i].name, TechList[i].era.ToString(), TechList[i].category.ToUpper()[0] + TechList[i].category.Substring(1)));
                i = 0;
            }


            ////
            ////
            //// Modifiers
            ////
            ////
           
            SaveStatus = 0;

        }

        private void Save_Technology()
        {

            local = new ClassTech(NameTB.Texts, NameGameTB.Texts, (int)EraCB.SelectedItem, TextureTB.Texts, DescriptionTB.Texts, CategoryCB.SelectedItem.ToString().ToLower(), CanResearchCB.Checked? true:false);

            List<string> words = NeededTechLB.Items.Cast<String>().ToList();

            words.RemoveAt(0);

            for (int i = 0; i < words.Count; i++)
            {
                words[i] = words[i].ToString().Substring(0, 65).Trim(' ');
            }

            local.restrictions = words.Cast<string>().ToList();


            // Modifiers to add
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Form Events
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void TechForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (SaveStatus == 2)
            {
                DialogResult result = MessageBox.ClassMessageBox.Show();
                if (result == DialogResult.OK)
                {
                    if (!SaveVerification()){e.Cancel = true;}
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
               
            }
        }

        private void TechForm_Load(object sender, EventArgs e)
        {


            foreach (ClassEra Era in EraList)
            {
                EraCB.Items.Add(Era.Era);
            }

            CategoryCB.Items.Add("Production");
            CategoryCB.Items.Add("Military");
            CategoryCB.Items.Add("Society");


            NeededTechLB.Items.Add(String.Format("{0,-65}{1,-5 }{2,-10 }", "Tech", "Era", "Category"));
            NeededCB.Items.Add("Choose a category.");
            


            ModifiersLB.Items.Add("Work In Progress");
            // TO DO




            if (local != null )
            {
                LoadInfoToControls();
            }
            else
            {
                SaveStatus = 2;
            }

        }


        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // If Text Changed Ask To Save
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void NameTB_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            SaveStatus = 2;
        }

        private void EraCB_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            SaveStatus = 2;
            if (EraCB.SelectedIndex != -1)
            {
                canSave[1] = true;
            }
            else { canSave[1] = false; }
            EraCostTB.Texts = EraList[Int32.Parse(EraCB.SelectedItem.ToString()) - 1].Cost.ToString();
        }

        private void CategoryCB_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            SaveStatus = 2;
            if (CategoryCB.SelectedIndex != -1)
            {
                canSave[2] = true;
                NeededCB.Items.Clear();
                NeededCB.Items.Add(String.Format("{0,-65}{1,-5 }{2,-10 }", "Tech", "Era", "Category"));
                foreach (ClassTech TechEntry in TechList)
                {
                    if (TechEntry.category == CategoryCB.SelectedItem.ToString().ToLower())
                    {
                        NeededCB.Items.Add(String.Format("{0,-65}{1,-5 }{2,-10 }", TechEntry.name, TechEntry.era, TechEntry.category.ToUpper()[0] + TechEntry.category.Substring(1)));
                    }
                }



            }
            else { canSave[2] = false; }
        }

        private void CanResearchCB_CheckedChanged(object sender, EventArgs e)
        {
            SaveStatus = 2;
        }

        private void TextureTB_CustomTextBox_TextChanged(object sender, EventArgs e)
        {

            SaveStatus = 2;
            if (!string.IsNullOrEmpty(TextureTB.Texts) && TextureTB.Texts.EndsWith(".dds"))
            {
                canSave[3] = true;
            }
            else { canSave[3] = false; }
        }

        private void DescriptionTB_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            SaveStatus = 2;
        }

        private void NameGameTB_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            SaveStatus = 2;
        }

        
    }
}
