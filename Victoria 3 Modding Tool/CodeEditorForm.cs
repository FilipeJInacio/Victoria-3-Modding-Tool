using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Victoria_3_Modding_Tool
{
    public partial class CodeEditorForm : Form
    {
        public string text; // if null -> no text / text -> to put on screen

        public CodeEditorForm()
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
        // Form
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void SizeObjects()
        {
            Rectangle rect = Screen.PrimaryScreen.WorkingArea;
            rect.Width = rect.Width / 2;

            this.Size = new Size(rect.Width, rect.Height);
            this.MaximumSize = new Size(rect.Width, rect.Height);
            this.MinimumSize = new Size(rect.Width, rect.Height);
            this.Location = new Point(rect.Width, 0);

            MainRTB.Size = new Size(rect.Width * 5 / 6, rect.Height * 5 / 6);
            MainRTB.Location = new Point(rect.Width / 6, 50);

            DebugRTB.Size = new Size(rect.Width * 5 / 6, rect.Height / 12);
            DebugRTB.Location = new Point(rect.Width / 6, 55 + rect.Height * 5 / 6);
        }

        private void CodeEditorForm_Load(object sender, EventArgs e)
        {
            SizeObjects();
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Text Editor Styling
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void MainRTB_TextChanged(object sender, EventArgs e)
        {
            // Matcher
            MatchCollection variablesMatches = Regex.Matches(MainRTB.Text, @"\b(set_variable|remove_variable|add_modifier|remove_modifier|set_global_variable|remove_global_variable)\b");   // NEED DELETE GLOBAL VARIABLE

            MatchCollection conditionsMatches = Regex.Matches(MainRTB.Text, @"\b(OR|AND|NAND|NOR|NOT)\b");

            MatchCollection braquetsMatches = Regex.Matches(MainRTB.Text, @"\b{\b");   // Doesn't work

            MatchCollection commentMatches = Regex.Matches(MainRTB.Text, @"#.+$", RegexOptions.Multiline);

            MatchCollection stringMatches = Regex.Matches(MainRTB.Text, "\".+?\"");

            // Saving the original position + color
            int originalIndex = MainRTB.SelectionStart;
            int originalLength = MainRTB.SelectionLength;
            Color originalColor = Color.White;

            LabelTemp.Focus();

            //Remove any previous highlights
            MainRTB.SelectionStart = 0;
            MainRTB.SelectionLength = MainRTB.Text.Length;
            MainRTB.SelectionColor = originalColor;

            // Put the color
            foreach (Match m in variablesMatches)
            {
                MainRTB.SelectionStart = m.Index;
                MainRTB.SelectionLength = m.Length;
                MainRTB.SelectionColor = Color.FromArgb(255, 118, 118);
            }

            foreach (Match m in conditionsMatches)
            {
                MainRTB.SelectionStart = m.Index;
                MainRTB.SelectionLength = m.Length;
                MainRTB.SelectionColor = Color.FromArgb(173, 255, 255);
            }

            foreach (Match m in braquetsMatches)
            {
                MainRTB.SelectionStart = m.Index;
                MainRTB.SelectionLength = m.Length;
                MainRTB.SelectionColor = Color.FromArgb(140, 0, 175);
            }

            foreach (Match m in commentMatches)
            {
                MainRTB.SelectionStart = m.Index;
                MainRTB.SelectionLength = m.Length;
                MainRTB.SelectionColor = Color.Green;
            }

            foreach (Match m in stringMatches)
            {
                MainRTB.SelectionStart = m.Index;
                MainRTB.SelectionLength = m.Length;
                MainRTB.SelectionColor = Color.Orange;
            }

            // Return Normal
            MainRTB.SelectionStart = originalIndex;
            MainRTB.SelectionLength = originalLength;
            MainRTB.SelectionColor = originalColor;

            MainRTB.Focus();
        }
    }
}