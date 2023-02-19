using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Victoria_3_Modding_Tool
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
            this.Padding = new Padding(1);//Border size
            this.SetStyle(
                        ControlStyles.AllPaintingInWmPaint |
                        ControlStyles.UserPaint |
                        ControlStyles.DoubleBuffer, true);
            if (Properties.Settings.Default.Victoria3Path == "Not Set") { LoadEditorButton.Enabled = false; }
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
        // Button Click
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void NewProjectBT_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (PathForm form = new PathForm())
            {
                form.newProj = true;
                form.ShowDialog();
            }
            this.Show();
        }

        private void LoadEditorButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (PathForm form = new PathForm())
            {
                form.newProj = false;
                form.ShowDialog();
            }
            this.Show();
        }

        private void AboutBT_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (CodeEditorPathForm form = new CodeEditorPathForm())
            {
                form.ShowDialog();
            }
            this.Show();
        }

        private void CreditBT_Click(object sender, EventArgs e)
        {
            using (Credits form = new Credits())
            {
                form.ShowDialog();
            }
            this.Show();
        }
    }
}