using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Victoria_3_Modding_Tool.Forms.Tech;

namespace Victoria_3_Modding_Tool
{
    public partial class ReligionForm : Form
    {
        public List<ClassGoods> GoodsData; // Needed
        public List<ClassReligions> ReligionData; // Needed
        public List<string> Traits; // Not Needed

        public ClassReligions local;  // null if new   information if to change

        public bool[] canSave = { false, false, false, false, false, false }; // Name - TrueName - Texture - Red - Green - Blue    false -> cant save
        public int SaveStatus = 0;    // 0 -> opened just now   1 -> is saved   2 -> is not
        public int sizeOfVicky;

        public ReligionForm()
        {
            InitializeComponent();
            this.Padding = new Padding(1);//Border size
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width/4, 0);
        }

        public ClassReligions ReturnValue()
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
                graph.DrawRectangle(penBorder, TraitsLB.Location.X - 2, TraitsLB.Location.Y - 2, TraitsLB.Width + 4F, TraitsLB.Height + 4F);
                graph.DrawRectangle(penBorder, TaboosLB.Location.X - 2, TaboosLB.Location.Y - 2, TaboosLB.Width + 4F, TaboosLB.Height + 4F);
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
            LB_DrawItem(sender, e, TraitsLB);
        }

        private void ModifiersLB_DrawItem(object sender, DrawItemEventArgs e)
        {
            LB_DrawItem(sender, e, TaboosLB);
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

        private void TraitsLB_DoubleClick(object sender, EventArgs e)
        {
            if (TraitsLB.SelectedIndex != -1)
            {
                Traits.Remove(TraitsLB.SelectedItem.ToString());
                TraitsLB.Items.RemoveAt(TraitsLB.SelectedIndex);
                SaveStatus = 2;
            }
        }

        private void TaboosLB_DoubleClick(object sender, EventArgs e)
        {
            if (TaboosLB.SelectedIndex != -1)
            {
                TaboosLB.Items.RemoveAt(TaboosLB.SelectedIndex);
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
                    TextureTB.Texts = openFileDialog.FileName.Substring(openFileDialog.FileName.IndexOf("gfx"));

                }

            }
        }

        private void TraitAddBT_Click(object sender, EventArgs e)
        {
            if (TraitsCB.SelectedIndex != -1)
            {
                if (!TraitsLB.Items.Contains(TraitsCB.SelectedItem))
                {
                    TraitsLB.Items.Add(TraitsCB.SelectedItem);
                }
            }
        }

        private void TabooAddBT_Click(object sender, EventArgs e)
        {
            if (TaboosCB.SelectedIndex != -1)
            {
                if (!TaboosLB.Items.Contains(TaboosCB.SelectedItem))
                {
                    TaboosLB.Items.Add(TaboosCB.SelectedItem);
                }
            }
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
            if (!string.IsNullOrEmpty(NameTB.Texts) && !new Functions().hasName(ReligionData.GetRange(sizeOfVicky, ReligionData.Count - sizeOfVicky), NameTB.Texts) && Regex.Match(NameTB.Texts, "^([a-z]||_)+$").Success)
            {
                canSave[0] = true;
            }
            else { canSave[0] = false; }

            if (Regex.Match(NameGameTB.Texts, "^[\\u0000-\\u007E]+$").Success || string.IsNullOrEmpty(NameGameTB.Texts))
            {
                canSave[1] = true;
            }
            else { canSave[1] = false; }

            if (!string.IsNullOrEmpty(TextureTB.Texts) && TextureTB.Texts.EndsWith(".dds"))
            {
                canSave[2] = true;
            }
            else { canSave[2] = false; }


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
                NameGameTB.BorderColor = Color.FromArgb(255, 39, 58);
                NameGameTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                NameGameTB.BorderColor = Color.FromArgb(66, 66, 66);
                NameGameTB.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[2] == false)
            {
                TextureTB.BorderColor = Color.FromArgb(255, 39, 58);
                TextureTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                TextureTB.BorderColor = Color.FromArgb(66, 66, 66);
                TextureTB.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[3] == false)
            {
                RedTB.BorderColor = Color.FromArgb(255, 39, 58);
                RedTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                RedTB.BorderColor = Color.FromArgb(66, 66, 66);
                RedTB.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[4] == false)
            {
                GreenTB.BorderColor = Color.FromArgb(255, 39, 58);
                GreenTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                GreenTB.BorderColor = Color.FromArgb(66, 66, 66);
                GreenTB.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[5] == false)
            {
                BlueTB.BorderColor = Color.FromArgb(255, 39, 58);
                BlueTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                BlueTB.BorderColor = Color.FromArgb(66, 66, 66);
                BlueTB.BorderFocusColor = Color.FromArgb(153, 153, 153);
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

            NameGameTB.Texts = local.Truename;

            TextureTB.Texts = local.Texture;

            RedTB.Texts = local.Red.ToString();
            GreenTB.Texts = local.Green.ToString();
            BlueTB.Texts = local.Blue.ToString();

            foreach(string entry in local.Traits)
            {
                TraitsLB.Items.Add(entry);
            }

            foreach (string entry in local.Taboos)
            {
                TaboosLB.Items.Add(entry);
            }

            SaveStatus = 0;

        }

        private void Save_Technology()
        {
            local = new ClassReligions(NameTB.Texts,NameGameTB.Texts, TextureTB.Texts,Int32.Parse(RedTB.Texts), Int32.Parse(GreenTB.Texts), Int32.Parse(BlueTB.Texts));
            local.Traits = TraitsLB.Items.Cast<string>().ToList();
            local.Taboos = TaboosLB.Items.Cast<string>().ToList();

        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Form Events
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void ReligionForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void ReligionForm_Load(object sender, EventArgs e)
        {

            foreach (string entry in Traits)
            {
                TraitsCB.Items.Add(entry);
            }

            foreach (ClassGoods entry in GoodsData)
            {
                if(entry.Category== "luxury")
                TaboosCB.Items.Add(entry.Name);
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

        private void NameGameTB_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            SaveStatus = 2;
        }

        private void TextureTB_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            SaveStatus = 2;
        }

        private void RedTB_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            SaveStatus = 2;
            int i;
            if (!Regex.Match(RedTB.Texts, "^([0-9])+$").Success || string.IsNullOrEmpty(RedTB.Texts))
            {
                canSave[3] = false;
            }
            else
            {

                if (int.TryParse(RedTB.Texts, out i) && i >= 0 && i <= 255)
                {
                    canSave[3] = true;
                }
                else
                {
                    canSave[3] = false;
                }

            }

            if (canSave[3]==true && canSave[4] == true && canSave[5] == true)
            {
                ColorP.BackColor= Color.FromArgb(Int32.Parse(RedTB.Texts), Int32.Parse(GreenTB.Texts), Int32.Parse(BlueTB.Texts));
            }

        }

        private void GreenTB_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            SaveStatus = 2;
            int i;
            if (!Regex.Match(GreenTB.Texts, "^([0-9])+$").Success || string.IsNullOrEmpty(GreenTB.Texts))
            {
                canSave[4] = false;
            }
            else
            {

                if (int.TryParse(GreenTB.Texts, out i) && i >= 0 && i <= 255)
                {
                    canSave[4] = true;
                }
                else
                {
                    canSave[4] = false;
                }

            }

            if (canSave[3] == true && canSave[4] == true && canSave[5] == true)
            {
                ColorP.BackColor = Color.FromArgb(Int32.Parse(RedTB.Texts), Int32.Parse(GreenTB.Texts), Int32.Parse(BlueTB.Texts));
            }
        }

        private void BlueTB_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            SaveStatus = 2;
            int i;
            if (!Regex.Match(BlueTB.Texts, "^([0-9])+$").Success || string.IsNullOrEmpty(BlueTB.Texts))
            {
                canSave[5] = false;
            }
            else
            {

                if (int.TryParse(RedTB.Texts, out i) && i >= 0 && i <= 255)
                {
                    canSave[5] = true;
                }
                else
                {
                    canSave[5] = false;
                }

            }

            if (canSave[3] == true && canSave[4] == true && canSave[5] == true)
            {
                ColorP.BackColor = Color.FromArgb(Int32.Parse(RedTB.Texts), Int32.Parse(GreenTB.Texts), Int32.Parse(BlueTB.Texts));
            }
        }

       
    }
}
