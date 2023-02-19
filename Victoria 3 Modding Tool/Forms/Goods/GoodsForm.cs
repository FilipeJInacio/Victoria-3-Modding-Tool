using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Victoria_3_Modding_Tool
{
    public partial class GoodsForm : Form
    {
        public List<ClassGoods> GoodsDataP;

        public ClassGoods local;

        public bool[] canSave = { false, false, false, false, false, false, false, false, false, false }; // Name - Cost - Category - Texture - Obsession - Prestige - Convoy - Quantity - Tax - True Name    false -> cant save
        public int SaveStatus = 0;    // 0 -> opened just now   1 -> is saved 2 -> is not

        public GoodsForm()
        {
            InitializeComponent();
            this.Padding = new Padding(1);//Border size
            this.SetStyle(
                        ControlStyles.AllPaintingInWmPaint |
                        ControlStyles.UserPaint |
                        ControlStyles.DoubleBuffer, true);
            Rectangle rect = Screen.PrimaryScreen.WorkingArea;
            this.Location = new Point(rect.Width / 3, 0);
        }

        public ClassGoods ReturnValue()
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
            using (GoodsHelp form = new GoodsHelp())
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
                form.currentMode = "Goods";
                s = local.Name + " = {\n" +
                    "\ttexture = \"" + local.Texture + "\"\n" +
                    "\tcost = " + local.Cost + "\n" +
                    "\tcategory = " + local.Category + "\n\n" +
                    "\tprestige_factor = " + local.Prestige.ToString().Replace(",", ".") + "\n";
                if (local.TradedQuantity != -1) { s += "\ttraded_quantity = " + local.TradedQuantity + "\n"; }
                if (local.Convoy_cost != -1) { s += "\tconvoy_cost_multiplier = " + local.Convoy_cost.ToString().Replace(",", ".") + "\n"; }
                if (local.Consumption != -1) { s += "\tconsumption_tax_cost = " + local.Consumption + "\n"; }
                if (local.Obsession != -1) { s += "\tobsession_chance = " + local.Obsession.ToString().Replace(",", ".") + "\n\n"; }
                if (local.Tradeable == false) { s += "\ttradeable = no\n"; }
                if (local.Fixed_price == true) { s += "\tfixed_price = yes\n"; }
                s += "}";
                form.text = s;
                form.DebugOptionsMono = true;
                form.GoodCode = true;
                form.ShowDialog();
                s = form.ReturnValue();
            }
            if (s != string.Empty)
            {
                local = new ClassGoods(((List<KeyValuePair<string, object>>)(new Parser().ParseText(s)))[0],local.TrueName);
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

        private void TexturePathBT_Click(object sender, EventArgs e)
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
                    TextureTB.Texts = openFileDialog.FileName;
                }
            }
        }

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

            NameGameTB.Texts = local.TrueName;

            TextureTB.Texts = local.Texture;

            CostTB.Texts = local.Cost.ToString();

            if (local.Tradeable == false)
            {
                TradeableCB.Checked = false;
            }
            else
            {
                TradeableCB.Checked = true;
            }

            if (local.Fixed_price == true)
            {
                FixedCB.Checked = true;
            }
            else
            {
                FixedCB.Checked = false;
            }

            switch (local.Category)
            {
                case "staple":
                    CategoryCB.SelectedIndex = 0;
                    break;

                case "industrial":
                    CategoryCB.SelectedIndex = 1;
                    break;

                case "luxury":
                    CategoryCB.SelectedIndex = 2;
                    break;

                case "military":
                    CategoryCB.SelectedIndex = 3;
                    break;
            }

            ObsessionTB.Texts = local.Obsession.ToString().Replace(",", ".");
            PrestigeTB.Texts = local.Prestige.ToString().Replace(",", ".");
            ConvoyTB.Texts = local.Convoy_cost.ToString().Replace(",", ".");
            TradedTB.Texts = local.TradedQuantity.ToString();
            ConsumptionTB.Texts = local.Consumption.ToString();

            SaveStatus = 0;
        }

        private bool SaveVerification()
        {
            float i;
            int j;

            // Name
            if (!string.IsNullOrEmpty(NameTB.Texts) && !Functions.hasName(GoodsDataP, NameTB.Texts) && Regex.Match(NameTB.Texts, "^([a-z]||_)+$").Success)
            {
                canSave[0] = true;
            }
            else { canSave[0] = false; }

            // True Name
            if (Regex.Match(NameGameTB.Texts, "^[\\u0000-\\u007E]+$").Success || string.IsNullOrEmpty(NameGameTB.Texts))
            {
                canSave[9] = true;
            }
            else { canSave[9] = false; }

            // Texture
            if (!string.IsNullOrEmpty(TextureTB.Texts) && TextureTB.Texts.EndsWith(".dds"))
            {
                canSave[3] = true;
            }
            else { canSave[3] = false; }

            // Cost
            if (!Regex.Match(CostTB.Texts, "^([0-9])+$").Success || string.IsNullOrEmpty(CostTB.Texts))
            {
                CostTB.BorderColor = Color.FromArgb(255, 39, 58);
                CostTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
                canSave[1] = false;
            }
            else
            {
                if (int.TryParse(CostTB.Texts, out j) && j > 0 && j < 2147483647)
                {
                    canSave[1] = true;
                    CostTB.BorderColor = Color.FromArgb(66, 66, 66);
                    CostTB.BorderFocusColor = Color.FromArgb(153, 153, 153);
                }
                else
                {
                    CostTB.BorderColor = Color.FromArgb(255, 39, 58);
                    CostTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
                    canSave[1] = false;
                }
            }

            // Obsession
            if (!Regex.Match(ObsessionTB.Texts, "^([-])?([0-9])+([.][0-9]{1,3})?$").Success || string.IsNullOrEmpty(ObsessionTB.Texts))
            {
                ObsessionTB.BorderColor = Color.FromArgb(255, 39, 58);
                ObsessionTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
                canSave[4] = false;
            }
            else
            {
                if (float.TryParse(ObsessionTB.Texts.Replace(".", ","), out i) && ((i > 0 && i < 2147483647) || i == -1))
                {
                    canSave[4] = true;
                    ObsessionTB.BorderColor = Color.FromArgb(66, 66, 66);
                    ObsessionTB.BorderFocusColor = Color.FromArgb(153, 153, 153);
                }
                else
                {
                    ObsessionTB.BorderColor = Color.FromArgb(255, 39, 58);
                    ObsessionTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
                    canSave[4] = false;
                }
            }

            // Traded Quantity
            if (!Regex.Match(TradedTB.Texts, "^([-])?([0-9])+$").Success || string.IsNullOrEmpty(TradedTB.Texts))
            {
                TradedTB.BorderColor = Color.FromArgb(255, 39, 58);
                TradedTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
                canSave[7] = false;
            }
            else
            {
                if (int.TryParse(TradedTB.Texts, out j) && ((j > 0 && j < 2147483647) || j == -1))
                {
                    if (TradeableCB.Checked == false && j != -1)
                    {
                        TradedTB.BorderColor = Color.FromArgb(255, 39, 58);
                        TradedTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
                        canSave[7] = false;
                    }
                    else
                    {
                        TradedTB.BorderColor = Color.FromArgb(66, 66, 66);
                        TradedTB.BorderFocusColor = Color.FromArgb(153, 153, 153);
                        canSave[7] = true;
                    }
                }
                else
                {
                    TradedTB.BorderColor = Color.FromArgb(255, 39, 58);
                    TradedTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
                    canSave[7] = false;
                }
            }

            // Convoy
            if (!Regex.Match(ConvoyTB.Texts, "^([-])?([0-9])+([.][0-9]{1,3})?$").Success || string.IsNullOrEmpty(ConvoyTB.Texts))
            {
                ConvoyTB.BorderColor = Color.FromArgb(255, 39, 58);
                ConvoyTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
                canSave[6] = false;
            }
            else
            {
                if (float.TryParse(ConvoyTB.Texts.Replace(".", ","), out i) && ((i > 0 && i < 2147483647) || i == -1))
                {
                    if (TradeableCB.Checked == false && i != -1)
                    {
                        ConvoyTB.BorderColor = Color.FromArgb(255, 39, 58);
                        ConvoyTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
                        canSave[6] = false;
                    }
                    else
                    {
                        ConvoyTB.BorderColor = Color.FromArgb(66, 66, 66);
                        ConvoyTB.BorderFocusColor = Color.FromArgb(153, 153, 153);
                        canSave[6] = true;
                    }
                }
                else
                {
                    ConvoyTB.BorderColor = Color.FromArgb(255, 39, 58);
                    ConvoyTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
                    canSave[6] = false;
                }
            }

            // Prestige
            if (!Regex.Match(PrestigeTB.Texts, "^([-])?([0-9])+([.][0-9]{1,3})?$").Success || string.IsNullOrEmpty(PrestigeTB.Texts))
            {
                PrestigeTB.BorderColor = Color.FromArgb(255, 39, 58);
                PrestigeTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
                canSave[5] = false;
            }
            else
            {
                if (float.TryParse(PrestigeTB.Texts.Replace(".", ","), out i) && ((i > 0 && i < 2147483647) || i == -1))
                {
                    canSave[5] = true;
                    PrestigeTB.BorderColor = Color.FromArgb(66, 66, 66);
                    PrestigeTB.BorderFocusColor = Color.FromArgb(153, 153, 153);
                }
                else
                {
                    PrestigeTB.BorderColor = Color.FromArgb(255, 39, 58);
                    PrestigeTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
                    canSave[5] = false;
                }
            }

            if (!Regex.Match(ConsumptionTB.Texts, "^([-])?([0-9])+$").Success || string.IsNullOrEmpty(ConsumptionTB.Texts))
            {
                ConsumptionTB.BorderColor = Color.FromArgb(255, 39, 58);
                ConsumptionTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
                canSave[8] = false;
            }
            else
            {
                if (int.TryParse(ConsumptionTB.Texts, out j) && ((j > 0 && j < 2147483647) || (j == -1)))
                {
                    canSave[8] = true;
                    ConsumptionTB.BorderColor = Color.FromArgb(66, 66, 66);
                    ConsumptionTB.BorderFocusColor = Color.FromArgb(153, 153, 153);
                }
                else
                {
                    ConsumptionTB.BorderColor = Color.FromArgb(255, 39, 58);
                    ConsumptionTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
                    canSave[8] = false;
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

            if (canSave[2] == false)
            {
                CategoryCB.BorderColor = Color.FromArgb(255, 39, 58);
            }
            else
            {
                CategoryCB.BorderColor = Color.FromArgb(66, 66, 66);
            }

            if (canSave[3] == false)
            {
                TextureTB.BorderColor = Color.FromArgb(255, 39, 58);
                TextureTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                TextureTB.BorderColor = Color.FromArgb(66, 66, 66);
                TextureTB.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[9] == false)
            {
                NameGameTB.BorderColor = Color.FromArgb(255, 39, 58);
                NameGameTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                NameGameTB.BorderColor = Color.FromArgb(66, 66, 66);
                NameGameTB.BorderFocusColor = Color.FromArgb(153, 153, 153);
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
            local = new ClassGoods(NameTB.Texts, NameGameTB.Texts, TextureTB.Texts, Int32.Parse(CostTB.Texts), CategoryCB.SelectedItem.ToString().ToLower(), TradeableCB.Checked, FixedCB.Checked, Int32.Parse(ConsumptionTB.Texts), float.Parse(ObsessionTB.Texts, CultureInfo.InvariantCulture.NumberFormat), float.Parse(PrestigeTB.Texts, CultureInfo.InvariantCulture.NumberFormat), Int32.Parse(TradedTB.Texts), float.Parse(ConvoyTB.Texts, CultureInfo.InvariantCulture.NumberFormat));
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
            CategoryCB.Items.Add("Staple");
            CategoryCB.Items.Add("Industrial");
            CategoryCB.Items.Add("Luxury");
            CategoryCB.Items.Add("Military");

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

        private void CategoryCB_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            SaveStatus = 2;
            if (CategoryCB.SelectedIndex != -1)
            {
                canSave[2] = true;
            }
            else { canSave[2] = false; }
        }

        private void TextureTB_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            SaveStatus = 2;
        }

        private void CB_CheckedChanged(object sender, EventArgs e)
        {
            SaveStatus = 2;
        }

        private void CostTB_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            SaveStatus = 2;
        }

        private void ObsessionTB_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            SaveStatus = 2;
        }

        private void PrestigeTB_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            SaveStatus = 2;
        }

        private void ConvoyTB_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            SaveStatus = 2;
        }

        private void TradedTB_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            SaveStatus = 2;
        }

        private void ConsumptionTB_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            SaveStatus = 2;
        }

    }
}