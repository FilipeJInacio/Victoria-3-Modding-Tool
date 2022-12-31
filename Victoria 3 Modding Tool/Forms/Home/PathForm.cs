using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Victoria_3_Modding_Tool
{
    public partial class PathForm : Form
    {
        public bool newProj; // True -> its a new project
        public bool[] canMake = { false , false , false , false, false }; // -> name / projpath / language / Vickypath / Mod (Not needed)


        public PathForm()
        {
            InitializeComponent();
            this.Padding = new Padding(1);//Border size
            LoadLanguages();
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
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void HotBarP_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void LoadProject()
        {
            PNameTB.Texts = Properties.Settings.Default.ProjName;

            ProjPathTB.Texts = Properties.Settings.Default.ProjPath;

            for (int i = 0; i < LanguageCB.Items.Count; ++i)
            { 
                if (LanguageCB.Items[i].ToString() == Properties.Settings.Default.Language) { LanguageCB.SelectedIndex = i; }
            }

            VickyPathTB.Texts = Properties.Settings.Default.Victoria3Path;

            if (Properties.Settings.Default.ModPath != "Not Set")
            {
                ModPathTB.Texts = Properties.Settings.Default.ModPath;
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Buttons
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void CreateBT_Click(object sender, EventArgs e)
        {

            if (Regex.Match(PNameTB.Texts, "^([a-z]||_)+$").Success)
            {
                canMake[0]=true;
                PNameTB.BorderColor = Color.FromArgb(66, 66, 66);
                PNameTB.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }
            else
            {
                PNameTB.BorderColor = Color.FromArgb(255, 39, 58);
                PNameTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
                canMake[0]=false;
            }

            if (canMake[0] == true && canMake[1] == true && canMake[2] == true && canMake[3] == true)
            {

                Properties.Settings.Default.ProjName = PNameTB.Texts;
                Properties.Settings.Default.ProjPath = ProjPathTB.Texts;
                Properties.Settings.Default.Language = LanguageCB.SelectedItem.ToString();
                Properties.Settings.Default.Victoria3Path = VickyPathTB.Texts;
                if(canMake[4] == true) { Properties.Settings.Default.ModPath = ModPathTB.Texts; }
                Properties.Settings.Default.Save();

                this.Hide();
                using (Main form = new Main())
                {
                    form.language = LanguageCB.Items[LanguageCB.SelectedIndex].ToString();
                    form.VickyPath = VickyPathTB.Texts;
                    form.ProjPath = ProjPathTB.Texts;
                    form.ProjName = PNameTB.Texts;
                    if (canMake[4] == true){ form.ModPath = ModPathTB.Texts; } else { form.ModPath = null; }
                        form.ShowDialog();
                }
                this.Close();
            }


            if(canMake[0] == false)
            {
                PNameTB.BorderColor = Color.FromArgb(255, 39, 58);
                PNameTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                PNameTB.BorderColor = Color.FromArgb(66, 66, 66);
                PNameTB.BorderFocusColor = Color.FromArgb(153, 153, 153);
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

            if (canMake[2] == false)
            {
                LanguageCB.BorderColor = Color.FromArgb(255, 39, 58);
            }
            else
            {
                LanguageCB.BorderColor = Color.FromArgb(66, 66, 66);
            }

            if (canMake[3] == false)
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

        private void ModPathBT_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog FBD = new FolderBrowserDialog())
            {

                if (FBD.ShowDialog() == DialogResult.OK)
                {
                    ModPathTB.Texts = FBD.SelectedPath;  //selected folder path
                }
                else
                {
                    ModPathTB.Texts = "";
                }
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Combo Box Languages
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void LoadLanguages()
        {
            LanguageCB.Items.Add("braz_por");
            LanguageCB.Items.Add("english");
            LanguageCB.Items.Add("french");
            LanguageCB.Items.Add("german");
            LanguageCB.Items.Add("japanese");
            LanguageCB.Items.Add("korean");
            LanguageCB.Items.Add("polish");
            LanguageCB.Items.Add("russian");
            LanguageCB.Items.Add("simp_chinise");
            LanguageCB.Items.Add("spanish");
            LanguageCB.Items.Add("turkish");

        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Can Proceed Verifications
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void PNameTB_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(PNameTB.Texts)) { canMake[0] = true; } else { canMake[0] = false; }
        }

        private void ProjPathTB_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            if (Directory.Exists(ProjPathTB.Texts)){ canMake[1] = true; } else { canMake[1] = false; }
        }

        private void LanguageCB_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            canMake[2] = true;
        }

        private void VickyPathTB_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            if (Directory.Exists(VickyPathTB.Texts) && Directory.Exists(VickyPathTB.Texts+"\\binaries")) { canMake[3] = true; } else { canMake[3] = false; }
        }

        private void ModPathTB_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            if (Directory.Exists(ModPathTB.Texts)) { canMake[4] = true; } else { canMake[4] = false; }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Form
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void PathForm_Load(object sender, EventArgs e)
        {
            if (newProj == false) { LoadProject(); }
        }

        
    }
}
