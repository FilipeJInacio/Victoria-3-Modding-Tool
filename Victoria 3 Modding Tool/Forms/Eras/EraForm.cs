﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Formats.Tar;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Victoria_3_Modding_Tool
{
    public partial class EraForm : Form
    {
        public ClassEras local;

        public int SaveStatus; // 0 -> Just openned  / 1 -> Saved / 2 -> Not saved

        public EraForm()
        {
            InitializeComponent();
            this.Padding = new Padding(1);//Border size
            this.SetStyle(
                        ControlStyles.AllPaintingInWmPaint |
                        ControlStyles.UserPaint |
                        ControlStyles.DoubleBuffer, true);
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width / 2, Screen.PrimaryScreen.WorkingArea.Height * 1 / 4);
        }

        public ClassEras ReturnValue()
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
            using (EraHelp form = new EraHelp())
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
                form.currentMode = "Eras";
                form.text = "era_" + local.Era + " = {\n" +
                    "\ttechnology_cost = " + local.Cost + "\n" +
                    "}";
                form.DebugOptionsMono = true;
                form.GoodCode = true;
                form.ShowDialog();
                s = form.ReturnValue();
            }
            if (s != string.Empty)
            {
                local = new ClassEras(((List<KeyValuePair<string, object>>)(new Parser().ParseText(s)))[0]);
                EraTB.Texts = local.Era.ToString();
                EraCostTB.Texts = local.Cost.ToString();
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

        private bool SaveVerification()
        {
            int number;
            Match m = Regex.Match(EraTB.Texts, "^[0-9]+$");
            Match n = Regex.Match(EraCostTB.Texts, "^[0-9]+$");

            // Is int? Era
            if (!m.Success || string.IsNullOrEmpty(EraTB.Texts))
            {
                EraTB.BorderColor = Color.FromArgb(255, 39, 58);
                EraTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
                return false;
            }
            else
            {
                if (int.TryParse(EraTB.Texts, out number) && number > 0 && number < 2147483647)
                {
                    EraTB.BorderColor = Color.FromArgb(66, 66, 66);
                    EraTB.BorderFocusColor = Color.FromArgb(153, 153, 153);
                }
                else
                {
                    EraTB.BorderColor = Color.FromArgb(255, 39, 58);
                    EraTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
                    return false;
                }
            }

            // Is int? Era Cost
            if (!n.Success || string.IsNullOrEmpty(EraCostTB.Texts))
            {
                EraCostTB.BorderColor = Color.FromArgb(255, 39, 58);
                EraCostTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
                return false;
            }
            else
            {
                if (int.TryParse(EraCostTB.Texts, out number) && number > 0 && number < 2147483647)
                {
                    EraCostTB.BorderColor = Color.FromArgb(66, 66, 66);
                    EraCostTB.BorderFocusColor = Color.FromArgb(153, 153, 153);
                }
                else
                {
                    EraCostTB.BorderColor = Color.FromArgb(255, 39, 58);
                    EraCostTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
                    return false;
                }
            }

            SaveStatus = 1;
            SaveEra();
            return true;
        }

        private void SaveEra()
        {
            local = new ClassEras(Int32.Parse(EraTB.Texts), Int32.Parse(EraCostTB.Texts));
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
                    if (!SaveVerification())
                    {
                        e.Cancel = true;
                    }
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void EraTB_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            SaveStatus = 2;
        }

        private void EraCostTB_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            SaveStatus = 2;
        }

        private void EraForm_Load(object sender, EventArgs e)
        {
            if (local != null)
            {
                EraTB.Texts = local.Era.ToString();
                EraCostTB.Texts = local.Cost.ToString();
            }
            SaveStatus = 0;
        }


    }
}