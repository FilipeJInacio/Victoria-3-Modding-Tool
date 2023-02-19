using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Victoria_3_Modding_Tool
{
    public partial class ModifiersTypesForm : Form
    {
        public List<ClassModifiersType> ModifiersDataP;
        public ClassModifiersType local;

        public bool[] canSave = { false, false, false, false, false, false, false, false, false, false }; // name - nOfDecimals - Ai - Translate - Postfix - Good - Percentage - Invert - Neutral - Boolean    false -> cant save
        public int SaveStatus = 0;    // 0 -> opened just now   1 -> is saved 2 -> is not


        public ModifiersTypesForm()
        {
            InitializeComponent();
            this.Padding = new Padding(1);//Border size
            this.SetStyle(
                        ControlStyles.AllPaintingInWmPaint |
                        ControlStyles.UserPaint |
                        ControlStyles.DoubleBuffer, true);

            Rectangle rect = Screen.PrimaryScreen.WorkingArea;
            rect.Width = rect.Width / 2;
            this.Location = new Point(rect.Width / 2, 0);
        }

        public ClassModifiersType ReturnValue()
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

        private void GoToCodeEditor()
        {
            string s;
            this.Hide();
            using (CodeEditorForm form = new CodeEditorForm())
            {
                form.currentMode = "Modifier Types";
                s = local.Name + " = {\n";

                if (local.Neutral != -1)
                {
                    if (local.Neutral == 1)
                    {
                        s += "\tneutral = yes\n";
                    }
                    else
                    {
                        s += "\tneutral = no\n";
                    }
                }

                if (local.Good != -1)
                {
                    if (local.Good == 1)
                    {
                        s += "\tgood = yes\n";
                    }
                    else
                    {
                        s += "\tgood = no\n";
                    }
                }

                if (local.Boolean != -1)
                {
                    if (local.Boolean == 1)
                    {
                        s += "\tboolean = yes\n";
                    }
                    else
                    {
                        s += "\tboolean = no\n";
                    }
                }

                if (local.Percent != -1)
                {
                    if (local.Percent == 1)
                    {
                        s += "\tpercent = yes\n";
                    }
                    else
                    {
                        s += "\tpercent = no\n";
                    }
                }

                if (local.Invert != -1)
                {
                    if (local.Invert == 1)
                    {
                        s += "\tinvert = yes\n";
                    }
                    else
                    {
                        s += "\tinvert = no\n";
                    }
                }

                if (local.Num_decimals != -1)
                {
                    s += "\tnum_decimals = " + local.Num_decimals + "\n";
                }

                if (!string.IsNullOrEmpty(local.Translate))
                {
                    s += "\ttranslate = " + local.Translate + "\n";
                }

                if (!string.IsNullOrEmpty(local.Postfix))
                {
                    s += "\tpostfix = \"" + local.Postfix + "\"\n";
                }

                if (local.Ai_value != -1)
                {
                    s += "\tai_value = " + local.Ai_value + "\n";
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
                local = new ClassModifiersType(((List<KeyValuePair<string, object>>)(new Parser().ParseText(s)))[0]);
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
        // Button Events
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void SaveBT_Click(object sender, EventArgs e)
        {
            SaveVerification();
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Load/Save Information
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void LoadInfoToControls()
        {
            NameTB.Texts = local.Name;

            NumDeciTB.Texts = local.Num_decimals.ToString();

            AIValueTB.Texts = local.Ai_value.ToString();

            if (!string.IsNullOrEmpty(local.Translate))
            {
                TranslateTB.Texts = local.Translate.ToString();
            }

            if (!string.IsNullOrEmpty(local.Postfix))
            {
                PostfixTB.Texts = local.Postfix.ToString();
            }

            GoodTB.Texts = local.Good.ToString();
            NeutralTB.Texts = local.Neutral.ToString();
            PercentageTB.Texts = local.Percent.ToString();
            InvertTB.Texts = local.Invert.ToString();
            BooleanTB.Texts = local.Boolean.ToString();

            SaveStatus = 0;
        }

        private bool SaveVerification()
        {
            int j;

            if (!string.IsNullOrEmpty(NameTB.Texts) && !Functions.hasName(ModifiersDataP, NameTB.Texts) && Regex.Match(NameTB.Texts, "^([a-z]||_)+$").Success)
            {
                canSave[0] = true;
            }
            else { canSave[0] = false; }

            if (Regex.Match(TranslateTB.Texts, "^[\\u0000-\\u007E]+$").Success || string.IsNullOrEmpty(TranslateTB.Texts))
            {
                canSave[3] = true;
            }
            else { canSave[3] = false; }

            if (Regex.Match(PostfixTB.Texts, "^[\\u0000-\\u007E]+$").Success || string.IsNullOrEmpty(PostfixTB.Texts))
            {
                canSave[4] = true;
            }
            else { canSave[4] = false; }

            if (string.IsNullOrEmpty(NumDeciTB.Texts))
            {
                NumDeciTB.BorderColor = Color.FromArgb(255, 39, 58);
                NumDeciTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
                canSave[1] = false;
            }
            else
            {
                if (int.TryParse(NumDeciTB.Texts, out j) && (j == -1 || j == 0 || j == 1 || j == 2))
                {
                    NumDeciTB.BorderColor = Color.FromArgb(66, 66, 66);
                    NumDeciTB.BorderFocusColor = Color.FromArgb(153, 153, 153);
                    canSave[1] = true;
                }
                else
                {
                    NumDeciTB.BorderColor = Color.FromArgb(255, 39, 58);
                    NumDeciTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
                    canSave[1] = false;
                }
            }

            if (!Regex.Match(AIValueTB.Texts, "^([-])?([0-9])+$").Success || string.IsNullOrEmpty(AIValueTB.Texts))
            {
                AIValueTB.BorderColor = Color.FromArgb(255, 39, 58);
                AIValueTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
                canSave[2] = false;
            }
            else
            {
                if (int.TryParse(AIValueTB.Texts, out j) && ((j >= 0 && j < 2147483647) || j == -1))
                {
                    AIValueTB.BorderColor = Color.FromArgb(66, 66, 66);
                    AIValueTB.BorderFocusColor = Color.FromArgb(153, 153, 153);
                    canSave[2] = true;
                }
                else
                {
                    AIValueTB.BorderColor = Color.FromArgb(255, 39, 58);
                    AIValueTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
                    canSave[2] = false;
                }
            }

            if (string.IsNullOrEmpty(GoodTB.Texts))
            {
                GoodTB.BorderColor = Color.FromArgb(255, 39, 58);
                GoodTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
                canSave[5] = false;
            }
            else
            {
                if (int.TryParse(GoodTB.Texts, out j) && (j == -1 || j == 0 || j == 1))
                {
                    GoodTB.BorderColor = Color.FromArgb(66, 66, 66);
                    GoodTB.BorderFocusColor = Color.FromArgb(153, 153, 153);
                    canSave[5] = true;
                }
                else
                {
                    GoodTB.BorderColor = Color.FromArgb(255, 39, 58);
                    GoodTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
                    canSave[5] = false;
                }
            }

            if (string.IsNullOrEmpty(PercentageTB.Texts))
            {
                PercentageTB.BorderColor = Color.FromArgb(255, 39, 58);
                PercentageTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
                canSave[6] = false;
            }
            else
            {
                if (int.TryParse(PercentageTB.Texts, out j) && (j == -1 || j == 0 || j == 1))
                {
                    PercentageTB.BorderColor = Color.FromArgb(66, 66, 66);
                    PercentageTB.BorderFocusColor = Color.FromArgb(153, 153, 153);
                    canSave[6] = true;
                }
                else
                {
                    PercentageTB.BorderColor = Color.FromArgb(255, 39, 58);
                    PercentageTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
                    canSave[6] = false;
                }
            }

            if (string.IsNullOrEmpty(InvertTB.Texts))
            {
                InvertTB.BorderColor = Color.FromArgb(255, 39, 58);
                InvertTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
                canSave[7] = false;
            }
            else
            {
                if (int.TryParse(InvertTB.Texts, out j) && (j == -1 || j == 0 || j == 1))
                {
                    InvertTB.BorderColor = Color.FromArgb(66, 66, 66);
                    InvertTB.BorderFocusColor = Color.FromArgb(153, 153, 153);
                    canSave[7] = true;
                }
                else
                {
                    InvertTB.BorderColor = Color.FromArgb(255, 39, 58);
                    InvertTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
                    canSave[7] = false;
                }
            }

            if (string.IsNullOrEmpty(NeutralTB.Texts))
            {
                NeutralTB.BorderColor = Color.FromArgb(255, 39, 58);
                NeutralTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
                canSave[8] = false;
            }
            else
            {
                if (int.TryParse(NeutralTB.Texts, out j) && (j == -1 || j == 0 || j == 1))
                {
                    NeutralTB.BorderColor = Color.FromArgb(66, 66, 66);
                    NeutralTB.BorderFocusColor = Color.FromArgb(153, 153, 153);
                    canSave[8] = true;
                }
                else
                {
                    NeutralTB.BorderColor = Color.FromArgb(255, 39, 58);
                    NeutralTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
                    canSave[8] = false;
                }
            }

            if (string.IsNullOrEmpty(BooleanTB.Texts))
            {
                BooleanTB.BorderColor = Color.FromArgb(255, 39, 58);
                BooleanTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
                canSave[9] = false;
            }
            else
            {
                if (int.TryParse(BooleanTB.Texts, out j) && (j == -1 || j == 0 || j == 1))
                {
                    BooleanTB.BorderColor = Color.FromArgb(66, 66, 66);
                    BooleanTB.BorderFocusColor = Color.FromArgb(153, 153, 153);
                    canSave[9] = true;
                }
                else
                {
                    BooleanTB.BorderColor = Color.FromArgb(255, 39, 58);
                    BooleanTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
                    canSave[9] = false;
                }
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

            if (canSave[3] == false)
            {
                TranslateTB.BorderColor = Color.FromArgb(255, 39, 58);
                TranslateTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                TranslateTB.BorderColor = Color.FromArgb(66, 66, 66);
                TranslateTB.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[4] == false)
            {
                PostfixTB.BorderColor = Color.FromArgb(255, 39, 58);
                PostfixTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                PostfixTB.BorderColor = Color.FromArgb(66, 66, 66);
                PostfixTB.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[0] == true && canSave[1] == true && canSave[2] == true && canSave[3] == true && canSave[4] == true && canSave[5] == true && canSave[6] == true && canSave[7] == true && canSave[8] == true && canSave[9] == true)
            {
                Save_Goods();
                SaveStatus = 1;
                return true;
            }

            return false;
        }

        private void Save_Goods()
        {
            local = new ClassModifiersType(NameTB.Texts, Int32.Parse(GoodTB.Texts), Int32.Parse(PercentageTB.Texts), Int32.Parse(NumDeciTB.Texts), Int32.Parse(InvertTB.Texts), Int32.Parse(NeutralTB.Texts), Int32.Parse(BooleanTB.Texts), PostfixTB.Texts, TranslateTB.Texts, Int32.Parse(AIValueTB.Texts));
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

        private void NumDeciTB_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            SaveStatus = 2;
        }

        private void AIValueTB_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            SaveStatus = 2;
        }

        private void TranslateTB_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            SaveStatus = 2;
        }

        private void PostfixTB_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            SaveStatus = 2;
        }

        private void GoodTB_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            SaveStatus = 2;
        }

        private void InvertTB_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            SaveStatus = 2;
        }

        private void BooleanTB_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            SaveStatus = 2;
        }

        private void PercentageTB_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            SaveStatus = 2;
        }

        private void NeutralTB_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            SaveStatus = 2;
        }


    }
}