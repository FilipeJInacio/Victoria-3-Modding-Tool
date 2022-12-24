using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Victoria_3_Modding_Tool.Forms.Tech;

namespace Victoria_3_Modding_Tool
{
    public partial class PopTypesForm : Form
    {
        public List<ClassGoods> GoodsList; // Needed   (Victoria 3 + Project)
        public List<ClassPopNeeds> PopNeedsList; // Needed   (Victoria 3 + Project)

        public ClassPopNeeds local;  // null if new   information if to change
        public List<ClassPopNeedsEntry> localEntry;  // local mem

        public bool[] canSave = { false, false, false }; // Name - Default Good - at least 1 weight   false -> cant save
        public int SaveStatus = 0;    // 0 -> opened just now   1 -> is saved   2 -> is not

        public int sizeOfVicky; // Needed


        public PopTypesForm()
        {
            InitializeComponent();
            this.Padding = new Padding(1);//Border size
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width/4, 0);

        }

        public ClassPopNeeds ReturnValue()
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
                graph.DrawRectangle(penBorder, EntryLB.Location.X - 2, EntryLB.Location.Y - 2, EntryLB.Width + 4F, EntryLB.Height + 4F);
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

        private void EntryLB_DrawItem(object sender, DrawItemEventArgs e)
        {
            LB_DrawItem(sender, e, EntryLB);
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
            using (PopNeedsHelp form = new PopNeedsHelp())
            {
                form.ShowDialog();
            }
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
        // Button Events
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        private bool verification()
        {
            bool[] verif = {false,false,false, false};
            float weight=0, min=0, max=0;

            if (!Regex.Match(WeigthTB.Texts, "^([0-9])+([.][0-9]{1,3})?$").Success || String.IsNullOrEmpty(WeigthTB.Texts))
            {
                WeigthTB.BorderColor = Color.FromArgb(255, 39, 58);
                WeigthTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                if (float.TryParse(WeigthTB.Texts.Replace(".", ","), out weight) && (weight >= 0 && weight < 2147483647))
                {
                    verif[0] = true;
                    WeigthTB.BorderColor = Color.FromArgb(66, 66, 66);
                    WeigthTB.BorderFocusColor = Color.FromArgb(153, 153, 153);
                }
                else
                {
                    WeigthTB.BorderColor = Color.FromArgb(255, 39, 58);
                    WeigthTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
                }
            }

            if (!Regex.Match(MinTB.Texts, "^([0-9])+([.][0-9]{1,3})?$").Success || String.IsNullOrEmpty(MinTB.Texts))
            {
                MinTB.BorderColor = Color.FromArgb(255, 39, 58);
                MinTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                if (float.TryParse(MinTB.Texts.Replace(".", ","), out min) && (min >= 0 && min < 2147483647))
                {
                    verif[1] = true;
                    MinTB.BorderColor = Color.FromArgb(66, 66, 66);
                    MinTB.BorderFocusColor = Color.FromArgb(153, 153, 153);
                }
                else
                {
                    MinTB.BorderColor = Color.FromArgb(255, 39, 58);
                    MinTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
                }
            }

            if (!Regex.Match(MaxTB.Texts, "^([0-9])+([.][0-9]{1,3})?$").Success || String.IsNullOrEmpty(MaxTB.Texts))
            {
                MaxTB.BorderColor = Color.FromArgb(255, 39, 58);
                MaxTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                if (float.TryParse(MaxTB.Texts.Replace(".", ","), out max) && (max >= 0 && max < 2147483647))
                {
                    verif[2] = true;
                    MaxTB.BorderColor = Color.FromArgb(66, 66, 66);
                    MaxTB.BorderFocusColor = Color.FromArgb(153, 153, 153);
                }
                else
                {
                    MaxTB.BorderColor = Color.FromArgb(255, 39, 58);
                    MaxTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
                }
            }

            if (EntryCB.SelectedIndex != -1 && !new ClassPopNeedsEntry().hasGood(localEntry,EntryCB.SelectedItem.ToString()))
            {
                EntryCB.BorderColor = Color.FromArgb(66, 66, 66);
                verif[3] = true;
            }
            else
            {
                EntryCB.BorderColor = Color.FromArgb(255, 39, 58);
            }


            if (verif[0]==true && verif[1]==true&& verif[2] == true && verif[3] == true)
            {


                if (min < weight && weight < max)
                {
                    WeigthTB.BorderColor = Color.FromArgb(66, 66, 66);
                    WeigthTB.BorderFocusColor = Color.FromArgb(153, 153, 153);
                    MaxTB.BorderColor = Color.FromArgb(66, 66, 66);
                    MaxTB.BorderFocusColor = Color.FromArgb(153, 153, 153);
                    MinTB.BorderColor = Color.FromArgb(66, 66, 66);
                    MinTB.BorderFocusColor = Color.FromArgb(153, 153, 153);
                    return true;
                }
                else
                {
                    WeigthTB.BorderColor = Color.FromArgb(255, 39, 58);
                    WeigthTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
                    MaxTB.BorderColor = Color.FromArgb(255, 39, 58);
                    MaxTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
                    MinTB.BorderColor = Color.FromArgb(255, 39, 58);
                    MinTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
                    return false;
                }
            }
            else
            {
                return false;
            }


        }

        private void AddBT_Click(object sender, EventArgs e)
        {
            SaveStatus = 2;
            if (verification())
            {
                localEntry.Add(new ClassPopNeedsEntry(EntryCB.SelectedItem.ToString(), float.Parse(WeigthTB.Texts.ToString(), CultureInfo.InvariantCulture.NumberFormat), float.Parse(MaxTB.Texts.ToString(), CultureInfo.InvariantCulture.NumberFormat), float.Parse(MinTB.Texts.ToString(), CultureInfo.InvariantCulture.NumberFormat)));
                EntryLB.Items.Add(String.Format("{0,-55}{1,-8 }{2,-8 }{3,-8 }", localEntry[localEntry.Count-1].goods, localEntry[localEntry.Count - 1].weight.ToString().Replace(",", "."), localEntry[localEntry.Count - 1].minWeight.ToString().Replace(",", "."), localEntry[localEntry.Count - 1].maxWeight.ToString().Replace(",", ".")));
            }

            if (localEntry.Count != 0) { DeleteBT.Enabled = true; }
        }

        private void DeleteBT_Click(object sender, EventArgs e)
        {
            if (EntryLB.SelectedIndex != -1)
            {
                if (EntryLB.SelectedIndex != 0)
                {
                    localEntry.RemoveAt(EntryLB.SelectedIndex - 1);
                    EntryLB.Items.RemoveAt(EntryLB.SelectedIndex);
                    SaveStatus = 2;
                }
            }

            if (localEntry.Count == 0) { DeleteBT.Enabled= false; }
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
            if (!string.IsNullOrEmpty(NameTB.Texts) && !new ClassPopNeeds().hasName(PopNeedsList.GetRange(sizeOfVicky, PopNeedsList.Count - sizeOfVicky), NameTB.Texts) && Regex.Match(NameTB.Texts, "^([a-z]||_)+$").Success)
            {
                canSave[0] = true;
            }
            else { canSave[0] = false; }

            if (localEntry.Count == 0) { canSave[2] = false; }
            else
            {
                if (new ClassPopNeedsEntry().hasGood(localEntry, DefaultCB.SelectedItem.ToString())) { canSave[2] = true; }
                else { canSave[2] = false; }
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
                DefaultCB.BorderColor = Color.FromArgb(255, 39, 58);
            }
            else
            {
                DefaultCB.BorderColor = Color.FromArgb(66, 66, 66);
            }

            if (canSave[2] == false)
            {
                EntryCB.BorderColor = Color.FromArgb(255, 39, 58);
            }
            else
            {
                EntryCB.BorderColor = Color.FromArgb(66, 66, 66);
            }

            if (canSave[0] == true && canSave[1] == true && canSave[2] == true)
            {
                SaveForm();
                SaveStatus = 1;
                return true;
            }
            return false;

        }

        private void LoadInfoToControls()
        {
            localEntry = new List<ClassPopNeedsEntry>();

            NameTB.Texts = local.name;

            DefaultCB.SelectedIndex= new ClassGoods().hasNameIndex(GoodsList, local.defaultgood);

            foreach (ClassPopNeedsEntry entry in local.entries)
            {
                EntryLB.Items.Add(String.Format("{0,-55}{1,-8 }{2,-8 }{3,-8 }", entry.goods, entry.weight.ToString().Replace(",", "."), entry.minWeight.ToString().Replace(",", "."), entry.maxWeight.ToString().Replace(",", ".")));
                localEntry.Add(new ClassPopNeedsEntry(entry));
            }
            if (localEntry.Count != 0) { DeleteBT.Enabled = true; }

            SaveStatus = 0;

        }

        private void SaveForm()
        {
            local = new ClassPopNeeds(NameTB.Texts, DefaultCB.SelectedItem.ToString());

            foreach(ClassPopNeedsEntry entry in localEntry)
            {
                local.entries.Add(entry);
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Form Events
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void PopNeedsForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (SaveStatus == 2)
            {
                DialogResult result = MessageBox.ClassMessageBox.Show();
                if (result == DialogResult.OK)
                {
                    if (!SaveVerification()){e.Cancel = true;}
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
               
            }
        }

        private void PopNeedsForm_Load(object sender, EventArgs e)
        {

            foreach (ClassGoods entry in GoodsList)
            {
                DefaultCB.Items.Add(entry.name);
                EntryCB.Items.Add(entry.name);
            }

            EntryLB.Items.Add(String.Format("{0,-55}{1,-8 }{2,-8 }{3,-8 }", "Good", "Weight", "Min", "Max"));

            if (local != null )
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

        private void DefaultCB_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            SaveStatus = 2;

            if (DefaultCB.SelectedIndex != -1)
            {
                canSave[1] = true;
            }
            else { canSave[1] = false; }
        }
        
    }
}
