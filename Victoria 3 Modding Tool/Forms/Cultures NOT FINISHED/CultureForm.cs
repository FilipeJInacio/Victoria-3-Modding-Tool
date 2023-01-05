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
    public partial class CultureForm : Form
    {
        public List<ClassTech> TechList; // Needed   (Victoria 3 + Project)
        public List<ClassModifiersType> ModifiersTypes; // Needed

        public List<ClassEra> EraList; // Needed   (Victoria 3 + Project)

        public ClassTech local;  // null if new   information if to change

        public bool[] canSave = { false, false, false, false, false, false }; // Name - Era - Category - Texture - Desc - True Name  false -> cant save
        public int SaveStatus = 0;    // 0 -> opened just now   1 -> is saved   2 -> is not

        public int sizeOfVicky; // Needed

        public CultureForm()
        {
            InitializeComponent();
            this.Padding = new Padding(1);//Border size
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width / 4, 0);
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
        private static extern void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

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
            if (NeededTechLB.SelectedIndex != 0 && NeededTechLB.SelectedIndex != -1)
            {
                NeededTechLB.Items.RemoveAt(NeededTechLB.SelectedIndex);
                SaveStatus = 2;
            }
        }

        private void ModifiersLB_DoubleClick(object sender, EventArgs e)
        {
            if (ModifiersLB.SelectedIndex != -1)
            {
                ModifiersLB.Items.RemoveAt(ModifiersLB.SelectedIndex);
                SaveStatus = 2;
            }
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
                    TextureTB.Texts = openFileDialog.FileName;
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

            SaveStatus = 2;
        }

        private bool containsModifier(string name)
        {
            foreach (string entry in ModifiersLB.Items)
            {
                if (entry.Split(' ')[0] == name) { return false; }
            }
            return true;
        }

        private void ModifiersAddBT_Click(object sender, EventArgs e)
        {
            float i = 0;
            bool verif;

            if (!Regex.Match(NumberTB.Texts, "^([-])?([0-9])+([.][0-9]{1,3})?$").Success || string.IsNullOrEmpty(NumberTB.Texts))
            {
                NumberTB.BorderColor = Color.FromArgb(255, 39, 58);
                NumberTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
                verif = false;
            }
            else
            {
                if (float.TryParse(NumberTB.Texts.Replace(".", ","), out i) && i > -2147483647 && i < 2147483647)
                {
                    NumberTB.BorderColor = Color.FromArgb(66, 66, 66);
                    NumberTB.BorderFocusColor = Color.FromArgb(153, 153, 153);
                    verif = true;
                }
                else
                {
                    NumberTB.BorderColor = Color.FromArgb(255, 39, 58);
                    NumberTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
                    verif = false;
                }
            }

            if (ModifiersCB.SelectedIndex == -1)
            {
                verif = false;
                ModifiersCB.BorderColor = Color.FromArgb(255, 39, 58);
            }
            else
            {
                ModifiersCB.BorderColor = Color.FromArgb(66, 66, 66);
            }

            if (verif)
            {
                if (containsModifier(ModifiersCB.SelectedItem.ToString()))
                {
                    ModifiersLB.Items.Add(ModifiersCB.SelectedItem.ToString() + " = " + i.ToString().Replace(',', '.'));
                }
            }
            SaveStatus = 2;
        }

        private void SaveBT_Click(object sender, EventArgs e)
        {
            SaveVerification();
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Load/Save Information
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        private bool SaveVerification()
        {
            if (!string.IsNullOrEmpty(NameTB.Texts) && !new Functions().hasName(TechList.GetRange(sizeOfVicky, TechList.Count - sizeOfVicky), NameTB.Texts) && Regex.Match(NameTB.Texts, "^([a-z]||_)+$").Success)
            {
                canSave[0] = true;
            }
            else { canSave[0] = false; }

            if (Regex.Match(DescriptionTB.Texts, "^[\\u0000-\\u007E]+$").Success || string.IsNullOrEmpty(DescriptionTB.Texts))
            {
                canSave[4] = true;
            }
            else { canSave[4] = false; }

            if (Regex.Match(NameGameTB.Texts, "^[\\u0000-\\u007E]+$").Success || string.IsNullOrEmpty(NameGameTB.Texts))
            {
                canSave[5] = true;
            }
            else { canSave[5] = false; }

            if (!string.IsNullOrEmpty(TextureTB.Texts) && TextureTB.Texts.EndsWith(".dds"))
            {
                canSave[3] = true;
            }
            else { canSave[3] = false; }

            if (canSave[0] == false)
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

            if (canSave[5] == false)
            {
                NameGameTB.BorderColor = Color.FromArgb(255, 39, 58);
                NameGameTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                NameGameTB.BorderColor = Color.FromArgb(66, 66, 66);
                NameGameTB.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[0] == true && canSave[1] == true && canSave[2] == true && canSave[3] == true && canSave[4] == true && canSave[5] == true)
            {
                Save_Technology();

                SaveStatus = 1;
                return true;
            }
            return false;
        }

        private void LoadInfoToControls()
        {
            NameTB.Texts = local.Name;

            NameGameTB.Texts = local.TrueName;

            EraCB.SelectedIndex = local.Era - 1;

            TextureTB.Texts = local.Texture;

            DescriptionTB.Texts = local.Desc;

            switch (local.Category)
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

            if (local.CanResearch == false)
            {
                CanResearchCB.Checked = false;
            }

            int i = 0;

            NeededCB.Items.Clear();
            NeededCB.Items.Add(string.Format("{0,-65}{1,-5 }{2,-10 }", "Tech", "Era", "Category"));
            foreach (ClassTech TechEntry in TechList)
            {
                if (TechEntry.Category == CategoryCB.SelectedItem.ToString().ToLower())
                {
                    NeededCB.Items.Add(string.Format("{0,-65}{1,-5 }{2,-10 }", TechEntry.Name, TechEntry.Era, TechEntry.Category.ToUpper()[0] + TechEntry.Category.Substring(1)));
                }
            }

            foreach (string needTech in local.Restrictions)
            {
                foreach (ClassTech techsingular in TechList)
                {
                    if (techsingular.Name == needTech)
                    {
                        break;
                    }
                    i++;
                }

                NeededTechLB.Items.Add(string.Format("{0,-65}{1,-5 }{2,-10 }", TechList[i].Name, TechList[i].Era.ToString(), TechList[i].Category.ToUpper()[0] + TechList[i].Category.Substring(1)));
                i = 0;
            }

            foreach (string entry in local.Modifiers)
            {
                ModifiersLB.Items.Add(entry);
            }

            SaveStatus = 0;
        }

        private void Save_Technology()
        {
            local = new ClassTech(NameTB.Texts, NameGameTB.Texts, (int)EraCB.SelectedItem, TextureTB.Texts, DescriptionTB.Texts, CategoryCB.SelectedItem.ToString().ToLower(), CanResearchCB.Checked ? true : false);

            List<string> words = NeededTechLB.Items.Cast<string>().ToList();

            words.RemoveAt(0);

            for (int i = 0; i < words.Count; i++)
            {
                words[i] = words[i].ToString().Substring(0, 65).Trim(' ');
            }

            local.Restrictions = words.Cast<string>().ToList();

            local.Modifiers = ModifiersLB.Items.Cast<string>().ToList();
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
                    if (!SaveVerification()) { e.Cancel = true; }
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

            NeededTechLB.Items.Add(string.Format("{0,-65}{1,-5 }{2,-10 }", "Tech", "Era", "Category"));
            NeededCB.Items.Add("Choose a category.");

            foreach (ClassModifiersType entry in ModifiersTypes)
            {
                ModifiersCB.Items.Add(entry.Name);
            }

            if (local != null)
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
                NeededCB.Items.Add(string.Format("{0,-65}{1,-5 }{2,-10 }", "Tech", "Era", "Category"));
                foreach (ClassTech TechEntry in TechList)
                {
                    if (TechEntry.Category == CategoryCB.SelectedItem.ToString().ToLower())
                    {
                        NeededCB.Items.Add(string.Format("{0,-65}{1,-5 }{2,-10 }", TechEntry.Name, TechEntry.Era, TechEntry.Category.ToUpper()[0] + TechEntry.Category.Substring(1)));
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