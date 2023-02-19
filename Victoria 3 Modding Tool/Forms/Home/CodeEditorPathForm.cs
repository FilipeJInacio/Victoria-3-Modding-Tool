using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Victoria_3_Modding_Tool
{
    public partial class CodeEditorPathForm : Form
    {
        public bool[] canMake = { false, false }; // -> Vickypath / projpath 
        public bool ProjIsNull = false;

        public CodeEditorPathForm()
        {
            InitializeComponent();
            this.Padding = new Padding(1);//Border size
            this.SetStyle(
                        ControlStyles.AllPaintingInWmPaint |
                        ControlStyles.UserPaint |
                        ControlStyles.DoubleBuffer, true);

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
        // Buttons
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void CreateBT_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(ProjPathTB.Texts)) { canMake[1] = true; } 
            else if (string.IsNullOrEmpty(ProjPathTB.Texts)) { canMake[1] = true; ProjIsNull = true; }
            else { canMake[1] = false; }

            if (Directory.Exists(VickyPathTB.Texts) && Directory.Exists(VickyPathTB.Texts + "\\binaries")) { canMake[0] = true; } else { canMake[0] = false; }

            if (canMake[0] == true && canMake[1] == true)
            {
                Properties.Settings.Default.ProjPath = ProjPathTB.Texts;
                Properties.Settings.Default.Victoria3Path = VickyPathTB.Texts;
                Properties.Settings.Default.Save();

                this.Hide();
                using (CodeEditorForm form = new CodeEditorForm())
                {
                    form.currentMode = "Null";
                    form.VickyPath = VickyPathTB.Texts;
                    form.GoodCode = false;
                    if (ProjIsNull) {form.ProjPath = "";}else{form.ProjPath = ProjPathTB.Texts;}
                    form.text = null;
                    form.ShowDialog();
                }
                this.Close();
            }


            if (canMake[1] == false)
            {
                ProjPathTB.BorderColor = Color.FromArgb(255, 39, 58);
                ProjPathTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                ProjPathTB.BorderColor = Color.FromArgb(66, 66, 66);
                ProjPathTB.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canMake[0] == false)
            {
                VickyPathTB.BorderColor = Color.FromArgb(255, 39, 58);
                VickyPathTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                VickyPathTB.BorderColor = Color.FromArgb(66, 66, 66);
                VickyPathTB.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }
        }

        private void BackBT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ProjPathBT_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog FBD = new FolderBrowserDialog())
            {
                if (FBD.ShowDialog() == DialogResult.OK)
                {
                    ProjPathTB.Texts = FBD.SelectedPath;  //selected folder path
                }
                else
                {
                    ProjPathTB.Texts = "";
                }
            }
        }

        private void VicPathBT_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog FBD = new FolderBrowserDialog())
            {
                if (FBD.ShowDialog() == DialogResult.OK)
                {
                    VickyPathTB.Texts = FBD.SelectedPath;  //selected folder path
                }
                else
                {
                    VickyPathTB.Texts = "";
                }
            }
        }


        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Can Proceed Verifications
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void ProjPathTB_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void VickyPathTB_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Form
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void CodeEditorPathForm_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.ProjPath != "Not Set") { ProjPathTB.Texts = Properties.Settings.Default.ProjPath; }
            if (Properties.Settings.Default.Victoria3Path != "Not Set") { VickyPathTB.Texts = Properties.Settings.Default.Victoria3Path; }
        }
    }
}