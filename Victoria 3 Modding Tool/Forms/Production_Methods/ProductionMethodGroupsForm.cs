using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Victoria_3_Modding_Tool
{
    public partial class ProductionMethodGroupsForm : Form
    {
        public List<ClassProductionMethodGroups> ProductionMethodGroupsListP;
        public List<ClassProductionMethods> ProductionMethodsList; // Needed   (Victoria 3 + Project)

        public ClassProductionMethodGroups local;  // null if new   information if to change

        public bool[] canSave = { false, false, false, false, false, false }; // Name - True Name - Texture - List   false -> cant save
        public int SaveStatus = 0;    // 0 -> opened just now   1 -> is saved   2 -> is not

        public ProductionMethodGroupsForm()
        {
            InitializeComponent();
            this.Padding = new Padding(1);//Border size
            this.SetStyle(
                        ControlStyles.AllPaintingInWmPaint |
                        ControlStyles.UserPaint |
                        ControlStyles.DoubleBuffer, true);
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width / 4, 0);
        }

        public ClassProductionMethodGroups ReturnValue()
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
                graph.DrawRectangle(penBorder, ProductionLB.Location.X - 2, ProductionLB.Location.Y - 2, ProductionLB.Width + 4F, ProductionLB.Height + 4F);
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
            LB_DrawItem(sender, e, ProductionLB);
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

        private void GoToCodeEditor()
        {
            string s;
            this.Hide();
            using (CodeEditorForm form = new CodeEditorForm())
            {
                form.currentMode = "Production Method Groups";
                s = local.Name + " = {\n" +
                    "\ttexture = \"" + local.Texture + "\"\n";
                if (local.Ai_selection) { s += "\tai_selection = most_productive\n"; }
                if (local.Is_hidden_when_unavailable) { s += "\tis_hidden_when_unavailable = yes\n"; }
                if (local.Production_methods.Count != 0)
                {
                    s += "\n\tproduction_methods = {\n";
                    foreach (string entry in local.Production_methods)
                    {
                        s += "\t\t" + entry + "\n";
                    }
                    s += "\t}\n";
                }
                s += "}";
                form.text = s;
                form.DebugOptionsMono = true;
                form.GoodCode = true;
                form.ShowDialog();
                s = form.ReturnValue();
            }
            if (s != string.Empty)
            {
                local = new ClassProductionMethodGroups(((List<KeyValuePair<string, object>>)(new Parser().ParseText(s)))[0], local.TrueName);
                LoadInfoToControls();
            }
            SaveStatus = 2;
            this.Show();


        }

        private void ChangeBT_Click(object sender, EventArgs e)
        {

            if (SaveStatus == 2)
            {
                DialogResult result = MessageBox.ClassMessageBox.Show();
                if (result == DialogResult.OK)
                {
                    if (SaveVerification())
                    {
                        GoToCodeEditor();
                    }
                }
                else if (result == DialogResult.Cancel)
                {

                }
            }
            else
            {
                GoToCodeEditor();
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
            if (ProductionLB.SelectedIndex != 0 && ProductionLB.SelectedIndex != -1)
            {
                ProductionLB.Items.RemoveAt(ProductionLB.SelectedIndex);
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
            if (ProductionCB.SelectedIndex != -1)
            {
                if (!ProductionLB.Items.Contains(ProductionCB.SelectedItem))
                {
                    ProductionLB.Items.Add(ProductionCB.SelectedItem);
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
            if (!string.IsNullOrEmpty(NameTB.Texts) && !Functions.hasName(ProductionMethodGroupsListP, NameTB.Texts) && Regex.Match(NameTB.Texts, "^([a-z]||_)+$").Success)
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

            if (ProductionLB.Items.Count>0) { canSave[3] = true; } else { canSave[3] = false; }

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


            if (canSave[0] == true && canSave[1] == true && canSave[2] == true && canSave[3] == true)
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

            TextureTB.Texts = local.Texture;


            if (local.Ai_selection == false)
            {
                AICB.Checked = false;
            }
            else { { AICB.Checked = true; } }

            if (local.Is_hidden_when_unavailable == false)
            {
                UnavailableCB.Checked = false;
            }
            else { { UnavailableCB.Checked = true; } }

            ProductionLB.Items.Clear();
            foreach (string entry in local.Production_methods)
            {
                ProductionLB.Items.Add(entry);
            }

            SaveStatus = 0;
        }

        private void Save_Technology()
        {
            local = new ClassProductionMethodGroups(NameTB.Texts, NameGameTB.Texts, TextureTB.Texts, UnavailableCB.Checked ? true : false, AICB.Checked ? true : false);

            local.Production_methods = ProductionLB.Items.Cast<string>().ToList();
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

            foreach (ClassProductionMethods entry in ProductionMethodsList)
            {
                ProductionCB.Items.Add(entry.Name);
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

        private void CanResearchCB_CheckedChanged(object sender, EventArgs e)
        {
            SaveStatus = 2;
        }

        private void TextureTB_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            SaveStatus = 2;
        }

        private void NameGameTB_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            SaveStatus = 2;
        }

        private void UnavailableCB_CheckedChanged(object sender, EventArgs e)
        {
            SaveStatus = 2;
        }
    }
}