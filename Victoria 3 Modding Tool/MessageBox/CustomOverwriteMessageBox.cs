using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Victoria_3_Modding_Tool
{
    public partial class CustomOverwriteMessageBox : Form
    {
        public CustomOverwriteMessageBox()
        {
            InitializeComponent();
            this.Padding = new Padding(1);//Border size
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
            DialogResult = DialogResult.Cancel;
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

        private void YesBT_Click(object sender, EventArgs e)
        {
            // save Leave
            DialogResult = DialogResult.OK;
        }

        private void CancelBT_Click(object sender, EventArgs e)
        {
            // No leave
            DialogResult = DialogResult.Cancel;
        }
    }
}