using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Victoria_3_Modding_Tool.Forms.Tech;

namespace Victoria_3_Modding_Tool
{
    public partial class GoodsForm : Form
    {
        public List<ClassGoods> GoodsData;  // Needed

        public ClassGoods local;

        public bool[] canSave = { false, false, false, false, false, false, false, false, false }; // Name - Cost - Category - Texture - Obsession - Prestige - Convoy - Quantity - Tax    false -> cant save
        public int SaveStatus = 0;    // 0 -> opened just now   1 -> is saved 2 -> is not
        public int sizeOfVicky; // Needed




        public GoodsForm()
        {
            InitializeComponent();
            this.Padding = new Padding(1);//Border size

            Rectangle rect = Screen.PrimaryScreen.WorkingArea;
            rect.Width = rect.Width / 2;
            this.Location = new Point(rect.Width/2, 0);

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
                    TextureTB.Texts = openFileDialog.FileName.Substring(openFileDialog.FileName.IndexOf("gfx"));

                }

            }
        }

        private void SaveBT_Click(object sender, EventArgs e)
        {
            float i;
            int j;

            if (!string.IsNullOrEmpty(NameTB.Texts) && !new ClassGoods().hasName(GoodsData.GetRange(sizeOfVicky, GoodsData.Count - sizeOfVicky), NameTB.Texts) && Regex.Match(NameTB.Texts, "^([a-z]||_)+$").Success)
            {
                canSave[0] = true;
            }
            else { canSave[0] = false; }


            if (!Regex.Match(CostTB.Texts, "^([0-9])+$").Success || String.IsNullOrEmpty(CostTB.Texts))
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

            if (!Regex.Match(ObsessionTB.Texts, "^([-])?([0-9])+([.][0-9]{1,3})?$").Success || String.IsNullOrEmpty(ObsessionTB.Texts))
            {
                ObsessionTB.BorderColor = Color.FromArgb(255, 39, 58);
                ObsessionTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
                canSave[4] = false;
            }
            else
            {

                if (float.TryParse(ObsessionTB.Texts.Replace(".", ","), out i) && ((i > 0 && i < 2147483647)|| i==-1 ))
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

            if (!Regex.Match(TradedTB.Texts, "^([-])?([0-9])+$").Success || String.IsNullOrEmpty(TradedTB.Texts))
            {
                TradedTB.BorderColor = Color.FromArgb(255, 39, 58);
                TradedTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
                canSave[7] = false;
            }
            else
            {

                if (int.TryParse(TradedTB.Texts, out j) && ((j > 0 && j < 2147483647) || j==-1))
                {

                    if (TradeableCB.Checked == false && j != -1)
                    {
                        TradedTB.BorderColor = Color.FromArgb(255, 39, 58);
                        TradedTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
                        canSave[7] = false;
                    }
                    else if (TradeableCB.Checked == true && j == -1)
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

            if (!Regex.Match(ConvoyTB.Texts, "^([-])?([0-9])+([.][0-9]{1,3})?$").Success || String.IsNullOrEmpty(ConvoyTB.Texts))
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
                    else if(TradeableCB.Checked == true && i == -1)
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

            if (!Regex.Match(PrestigeTB.Texts, "^([-])?([0-9])+([.][0-9]{1,3})?$").Success || String.IsNullOrEmpty(PrestigeTB.Texts))
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

            if (!Regex.Match(ConsumptionTB.Texts, "^([-])?([0-9])+$").Success || String.IsNullOrEmpty(ConsumptionTB.Texts))
            {
                ConsumptionTB.BorderColor = Color.FromArgb(255, 39, 58);
                ConsumptionTB.BorderFocusColor = Color.FromArgb(255, 94, 108);
                canSave[8] = false;
            }
            else
            {

                if (int.TryParse(ConsumptionTB.Texts, out j) && ((j > 0 && j < 2147483647)||(j==-1)))
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



            if (canSave[0] == true && canSave[1] == true && canSave[2] == true && canSave[3] == true && canSave[4]==true && canSave[5] == true && canSave[6] == true && canSave[7] == true && canSave[8] == true)
            {
                Save_Goods();
                
                SaveStatus = 1;
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

        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Load/Save Information
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void LoadInfoToControls()
        {

            NameTB.Texts = local.name;

            NameGameTB.Texts = local.TrueName;

            TextureTB.Texts = local.texture;

            CostTB.Texts = local.cost.ToString();

            if (local.tradeable == false)
            {
                TradeableCB.Checked = false;
            }
            else
            {
                TradeableCB.Checked = true;
            }

            if (local.fixed_price == true)
            {
                FixedCB.Checked = true;
            }
            else
            {
                FixedCB.Checked = false;
            }

            switch (local.category)
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

            ObsessionTB.Texts = local.obsession.ToString().Replace(",",".");
            PrestigeTB.Texts = local.prestige.ToString().Replace(",", ".");
            ConvoyTB.Texts = local.convoy_cost.ToString().Replace(",", ".");
            TradedTB.Texts = local.tradedQuantity.ToString();
            ConsumptionTB.Texts = local.consumption.ToString();

            SaveStatus = 0;

        }

        private void Save_Goods()
        {
            local = new ClassGoods(NameTB.Texts, NameGameTB.Texts, TextureTB.Texts, Int32.Parse(CostTB.Texts), CategoryCB.SelectedItem.ToString().ToLower(), TradeableCB.Checked ? true : false, FixedCB.Checked ? true : false, Int32.Parse(ConsumptionTB.Texts), float.Parse(ObsessionTB.Texts, CultureInfo.InvariantCulture.NumberFormat), float.Parse(PrestigeTB.Texts, CultureInfo.InvariantCulture.NumberFormat), Int32.Parse(TradedTB.Texts), float.Parse(ConvoyTB.Texts, CultureInfo.InvariantCulture.NumberFormat));
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
                    Save_Goods();
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
            if (!string.IsNullOrEmpty(TextureTB.Texts) && TextureTB.Texts.EndsWith(".dds"))
            {
                canSave[3] = true;
            }
            else { canSave[3] = false; }
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
