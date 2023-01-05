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
    public partial class StateTraitsForm : Form
    {
        public List<ClassTech> TechData;
        public List<ClassModifiersType> ModifiersTypes;
        public List<ClassStateTraits> StateTraitsData;
        public ClassStateTraits local;

        public bool[] canSave = { false, false, false, false, false }; // name - truename - icon - disable - equired    false -> cant save
        public int SaveStatus = 0;    // 0 -> opened just now   1 -> is saved 2 -> is not
        public int sizeOfVicky; // Needed

        public StateTraitsForm()
        {
            InitializeComponent();
            this.Padding = new Padding(1);//Border size

            Rectangle rect = Screen.PrimaryScreen.WorkingArea;
            this.Location = new Point(rect.Width / 2, 0);
        }

        public ClassStateTraits ReturnValue()
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
                graph.DrawRectangle(penBorder, ModifiersLB.Location.X - 2, ModifiersLB.Location.Y - 2, ModifiersLB.Width + 4F, ModifiersLB.Height + 4F);
            }
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
        // LB Styling
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void LB_DrawItem(DrawItemEventArgs e, ListBox LB)
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

        private void ModifiersLB_DrawItem(object sender, DrawItemEventArgs e)
        {
            LB_DrawItem(e, ModifiersLB);
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

        private void SaveBT_Click(object sender, EventArgs e)
        {
            SaveVerification();
        }

        private void IconPathBT_Click(object sender, EventArgs e)
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
                    IconTB.Texts = openFileDialog.FileName.Substring(openFileDialog.FileName.IndexOf("gfx"));
                }
            }
        }

        private bool ContainsModifier(string name)
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
                if (ContainsModifier(ModifiersCB.SelectedItem.ToString()))
                {
                    ModifiersLB.Items.Add(ModifiersCB.SelectedItem.ToString() + " = " + i.ToString().Replace(',', '.'));
                }
            }
            SaveStatus = 2;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Load/Save Information
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void LoadInfoToControls()
        {
            int i;

            NameTB.Texts = local.Name;

            NameGameTB.Texts = local.TrueName;

            IconTB.Texts = local.Texture;

            if(local.DisablingTechnologies == string.Empty)
            {
                DisablesCB.Checked= false;
            }
            else
            {
                i = new Functions().hasNameIndex(TechData, local.DisablingTechnologies);
                if (i != -1)
                {
                    DisableCB.SelectedIndex = i;
                }
            }


            if (local.RequiredTechsForColonization == string.Empty)
            {
                RequiresCB.Checked = false;
            }
            else
            {
                i = new Functions().hasNameIndex(TechData, local.RequiredTechsForColonization);
                if (i != -1)
                {
                    RequiredCB.SelectedIndex = i;
                }
            }


            foreach (string entry in local.Modifiers)
            {
                ModifiersLB.Items.Add(entry);
            }

            SaveStatus = 0;
        }

        private bool SaveVerification()
        {
            if (!string.IsNullOrEmpty(NameTB.Texts) && !new Functions().hasName(StateTraitsData.GetRange(sizeOfVicky, StateTraitsData.Count - sizeOfVicky), NameTB.Texts) && Regex.Match(NameTB.Texts, "^([a-z]||_)+$").Success)
            {
                canSave[0] = true;
            }
            else { canSave[0] = false; }

            if (Regex.Match(NameGameTB.Texts, "^[\\u0000-\\u007E]+$").Success || string.IsNullOrEmpty(NameGameTB.Texts))
            {
                canSave[1] = true;
            }
            else { canSave[1] = false; }

            if ((Regex.Match(IconTB.Texts, "^[\\u0000-\\u007E]+$").Success && IconTB.Texts.EndsWith(".dds")) || string.IsNullOrEmpty(IconTB.Texts))
            {
                canSave[2] = true;
            }
            else { canSave[2] = false; }

            if (DisablesCB.Checked == true && DisableCB.SelectedIndex == -1)
            {
                canSave[3] = false;
            }
            else
            {
                canSave[3] = true;
            }

            if (RequiresCB.Checked == true && RequiredCB.SelectedIndex == -1)
            {
                canSave[4] = false;
            }
            else
            {
                canSave[4] = true;
            }


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
                IconTB.BorderColor = Color.FromArgb(255, 39, 58);
                IconTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                IconTB.BorderColor = Color.FromArgb(66, 66, 66);
                IconTB.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[3] == false)
            {
                DisableCB.BorderColor = Color.FromArgb(255, 39, 58);
            }
            else
            {
                DisableCB.BorderColor = Color.FromArgb(66, 66, 66);
            }

            if (canSave[4] == false)
            {
                RequiredCB.BorderColor = Color.FromArgb(255, 39, 58);
            }
            else
            {
                RequiredCB.BorderColor = Color.FromArgb(66, 66, 66);
            }

            if (canSave[0] == true && canSave[1] == true && canSave[2] == true && canSave[3] == true && canSave[4] == true)
            {
                Save_Goods();
                SaveStatus = 1;
                return true;
            }

            return false;
        }

        private void Save_Goods()
        {
            string i, j;
            if (DisablesCB.Checked == false)
            {
                i = string.Empty;
            }
            else
            {
                i = DisableCB.SelectedItem.ToString();
            }
            if (RequiresCB.Checked == false)
            {
                j = string.Empty;
            }
            else
            {
                j = RequiredCB.SelectedItem.ToString();
            }

            local = new ClassStateTraits(NameTB.Texts, NameGameTB.Texts, IconTB.Texts, i, j)
            {
                Modifiers = ModifiersLB.Items.Cast<string>().ToList()
            };
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
            foreach (ClassTech entry in TechData)
            {
                DisableCB.Items.Add(entry.Name);
                RequiredCB.Items.Add(entry.Name);
            }

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

        private void NameGameTB_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            SaveStatus = 2;
        }

        private void IconTB_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            SaveStatus = 2;
        }

        private void DisableCB_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            SaveStatus = 2;
        }

        private void RequiredCB_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            SaveStatus = 2;
        }
    }
}