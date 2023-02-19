using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Victoria_3_Modding_Tool
{
    public partial class PopTypesForm : Form
    {
        public List<ClassPopTypes> PopTypesListP;
        public ClassPopTypes local;  // null if new   information if to change

        public bool[] canSave = { false, false, false, false, false ,false}; // Name - TrueName - Desc - OnlyIcon - NoIcon - Qualifications  false -> cant save
        public int SaveStatus = 0;    // 0 -> opened just now   1 -> is saved   2 -> is not

        public PopTypesForm()
        {
            InitializeComponent();
            this.Padding = new Padding(1);//Border size
            this.SetStyle(
                        ControlStyles.AllPaintingInWmPaint |
                        ControlStyles.UserPaint |
                        ControlStyles.DoubleBuffer, true);
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width / 4, 0);
        }

        public ClassPopTypes ReturnValue()
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
                form.currentMode = "Pop Types";
                if (local.Code == string.Empty)
                {
                    form.text = local.Name + " = {\n\t\n}";
                    form.GoodCode = false;
                }
                else
                {
                    int i = Functions.SizeOfName(local.Code);
                    form.text = local.Name + local.Code.Substring(i, local.Code.Length - i);
                    form.GoodCode = true;
                }
                form.DebugOptionsMono = true;
                form.ShowDialog();
                s = form.ReturnValue();
            }
            if (s == string.Empty)
            {
                local.Code = string.Empty;
            }
            else
            {
                local = new ClassPopTypes(((List<KeyValuePair<string, object>>)(new NoParse().ParseText(s)))[0], local.TrueName, local.Description, local.OnlyIcon, local.NoIcon, local.QualificationsDesc);
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

        private bool SaveVerification()
        {
            if (!string.IsNullOrEmpty(NameTB.Texts) && !Functions.hasName(PopTypesListP, NameTB.Texts) && Regex.Match(NameTB.Texts, "^([a-z]||_)+$").Success)
            {
                canSave[0] = true;
            }
            else { canSave[0] = false; }

            if (Regex.Match(NameGameTB.Texts, "^[\\u0000-\\u007E]+$").Success || string.IsNullOrEmpty(NameGameTB.Texts))
            {
                canSave[1] = true;
            }
            else { canSave[1] = false; }

            if (Regex.Match(DescriptionTB.Texts, "^[\\u0000-\\u007E]+$").Success || string.IsNullOrEmpty(DescriptionTB.Texts))
            {
                canSave[2] = true;
            }
            else { canSave[2] = false; }

            if (Regex.Match(OnlyIconTB.Texts, "^[\\u0000-\\u007E]+$").Success || string.IsNullOrEmpty(OnlyIconTB.Texts))
            {
                canSave[3] = true;
            }
            else { canSave[3] = false; }

            if (Regex.Match(NoIconTB.Texts, "^[\\u0000-\\u007E]+$").Success || string.IsNullOrEmpty(NoIconTB.Texts))
            {
                canSave[4] = true;
            }
            else { canSave[4] = false; }

            if (Regex.Match(QualificationsTB.Texts, "^[\\u0000-\\u007E]+$").Success || string.IsNullOrEmpty(QualificationsTB.Texts))
            {
                canSave[5] = true;
            }
            else { canSave[5] = false; }

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
                DescriptionTB.BorderColor = Color.FromArgb(255, 39, 58);
                DescriptionTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                DescriptionTB.BorderColor = Color.FromArgb(66, 66, 66);
                DescriptionTB.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[3] == false)
            {
                OnlyIconTB.BorderColor = Color.FromArgb(255, 39, 58);
                OnlyIconTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                OnlyIconTB.BorderColor = Color.FromArgb(66, 66, 66);
                OnlyIconTB.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[4] == false)
            {
                NoIconTB.BorderColor = Color.FromArgb(255, 39, 58);
                NoIconTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                NoIconTB.BorderColor = Color.FromArgb(66, 66, 66);
                NoIconTB.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[5] == false)
            {
                QualificationsTB.BorderColor = Color.FromArgb(255, 39, 58);
                QualificationsTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                QualificationsTB.BorderColor = Color.FromArgb(66, 66, 66);
                QualificationsTB.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[0] == true && canSave[1] == true && canSave[2] == true && canSave[3] == true && canSave[4] == true && canSave[5] == true)
            {
                Save_Form();

                SaveStatus = 1;
                return true;
            }
            return false;
        }

        private void LoadInfoToControls()
        {
            NameTB.Texts = local.Name;

            NameGameTB.Texts = local.TrueName;

            DescriptionTB.Texts = local.Description;

            OnlyIconTB.Texts = local.OnlyIcon;

            NoIconTB.Texts = local.NoIcon;

            QualificationsTB.Texts = local.QualificationsDesc;
       
            SaveStatus = 0;
        }

        private void Save_Form()
        {
            local = new ClassPopTypes(NameTB.Texts, NameGameTB.Texts, DescriptionTB.Texts, OnlyIconTB.Texts, NoIconTB.Texts, QualificationsTB.Texts,(local.Code==null)? string.Empty:local.Code);
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
                local = new ClassPopTypes();
                SaveStatus = 2;
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // If Text Changed Ask To Save
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
   
        private void DescriptionTB_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            SaveStatus = 2;
        }

        private void NameGameTB_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            SaveStatus = 2;
        }

        private void NameTB_CustomTextBox_TextChanged_1(object sender, EventArgs e)
        {
            SaveStatus = 2;
        }

        private void OnlyIconTB_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            SaveStatus = 2;
        }

        private void NoIconTB_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            SaveStatus = 2;
        }

        private void QualificationsTB_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            SaveStatus = 2;
        }
    }
}