using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Victoria_3_Modding_Tool
{
    public partial class FontColorForm : Form
    {
        public Color[] ColorData;
        public Color[] NewColorData = null;

        public bool[] canSave = { 
            false, false, false,
            false, false, false,
            false, false, false,
            false, false, false,
            false, false, false,
            false, false, false,
            false, false, false,
            false, false, false,
            false, false, false,
            false, false, false,
            false, false, false,
            false, false, false,
            false, false, false,
            false, false, false,
            false, false, false,
            false, false, false,
            false, false, false,
            false, false, false 
        }; 

        public int SaveStatus = 0;    // 0 -> opened just now   1 -> is saved   2 -> is not

        public FontColorForm()
        {
            InitializeComponent();
            this.Padding = new Padding(1);//Border size
            this.SetStyle(
                        ControlStyles.AllPaintingInWmPaint |
                        ControlStyles.UserPaint |
                        ControlStyles.DoubleBuffer, true);
        }

        public Color[] ReturnValue()
        {
            if (SaveStatus == 1) // saved
            {
                return NewColorData;
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
        // Click
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void SaveBT_Click(object sender, EventArgs e)
        {
            SaveVerification();
        }

        private void CancelBT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Saving
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FontColorForm_Load(object sender, EventArgs e)
        {
            Red1.Texts = ColorData[0].R.ToString();
            Green1.Texts = ColorData[0].G.ToString();
            Blue1.Texts = ColorData[0].B.ToString();

            Red2.Texts = ColorData[1].R.ToString();
            Green2.Texts = ColorData[1].G.ToString();
            Blue2.Texts = ColorData[1].B.ToString();

            Red3.Texts = ColorData[2].R.ToString();
            Green3.Texts = ColorData[2].G.ToString();
            Blue3.Texts = ColorData[2].B.ToString();

            Red4.Texts = ColorData[3].R.ToString();
            Green4.Texts = ColorData[3].G.ToString();
            Blue4.Texts = ColorData[3].B.ToString();

            Red5.Texts = ColorData[4].R.ToString();
            Green5.Texts = ColorData[4].G.ToString();
            Blue5.Texts = ColorData[4].B.ToString();

            Red6.Texts = ColorData[5].R.ToString();
            Green6.Texts = ColorData[5].G.ToString();
            Blue6.Texts = ColorData[5].B.ToString();

            Red7.Texts = ColorData[6].R.ToString();
            Green7.Texts = ColorData[6].G.ToString();
            Blue7.Texts = ColorData[6].B.ToString();

            Red8.Texts = ColorData[7].R.ToString();
            Green8.Texts = ColorData[7].G.ToString();
            Blue8.Texts = ColorData[7].B.ToString();

            Red9.Texts = ColorData[8].R.ToString();
            Green9.Texts = ColorData[8].G.ToString();
            Blue9.Texts = ColorData[8].B.ToString();

            Red10.Texts = ColorData[9].R.ToString();
            Green10.Texts = ColorData[9].G.ToString();
            Blue10.Texts = ColorData[9].B.ToString();

            Red11.Texts = ColorData[10].R.ToString();
            Green11.Texts = ColorData[10].G.ToString();
            Blue11.Texts = ColorData[10].B.ToString();

            Red12.Texts = ColorData[11].R.ToString();
            Green12.Texts = ColorData[11].G.ToString();
            Blue12.Texts = ColorData[11].B.ToString();

            Red13.Texts = ColorData[12].R.ToString();
            Green13.Texts = ColorData[12].G.ToString();
            Blue13.Texts = ColorData[12].B.ToString();

            Red14.Texts = ColorData[13].R.ToString();
            Green14.Texts = ColorData[13].G.ToString();
            Blue14.Texts = ColorData[13].B.ToString();

            Red15.Texts = ColorData[14].R.ToString();
            Green15.Texts = ColorData[14].G.ToString();
            Blue15.Texts = ColorData[14].B.ToString();

            Red16.Texts = ColorData[15].R.ToString();
            Green16.Texts = ColorData[15].G.ToString();
            Blue16.Texts = ColorData[15].B.ToString();

            Red17.Texts = ColorData[16].R.ToString();
            Green17.Texts = ColorData[16].G.ToString();
            Blue17.Texts = ColorData[16].B.ToString();

            Red18.Texts = ColorData[17].R.ToString();
            Green18.Texts = ColorData[17].G.ToString();
            Blue18.Texts = ColorData[17].B.ToString();

        }

        private bool SaveVerification()
        {

            if (canSave[0] == false)
            {
                Red1.BorderColor = Color.FromArgb(255, 39, 58);
                Red1.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                Red1.BorderColor = Color.FromArgb(66, 66, 66);
                Red1.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[1] == false)
            {
                Green1.BorderColor = Color.FromArgb(255, 39, 58);
                Green1.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                Green1.BorderColor = Color.FromArgb(66, 66, 66);
                Green1.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[2] == false)
            {
                Blue1.BorderColor = Color.FromArgb(255, 39, 58);
                Blue1.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                Blue1.BorderColor = Color.FromArgb(66, 66, 66);
                Blue1.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[3] == false)
            {
                Red2.BorderColor = Color.FromArgb(255, 39, 58);
                Red2.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                Red2.BorderColor = Color.FromArgb(66, 66, 66);
                Red2.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[4] == false)
            {
                Green2.BorderColor = Color.FromArgb(255, 39, 58);
                Green2.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                Green2.BorderColor = Color.FromArgb(66, 66, 66);
                Green2.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[5] == false)
            {
                Blue2.BorderColor = Color.FromArgb(255, 39, 58);
                Blue2.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                Blue2.BorderColor = Color.FromArgb(66, 66, 66);
                Blue2.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[6] == false)
            {
                Red3.BorderColor = Color.FromArgb(255, 39, 58);
                Red3.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                Red3.BorderColor = Color.FromArgb(66, 66, 66);
                Red3.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[7] == false)
            {
                Green3.BorderColor = Color.FromArgb(255, 39, 58);
                Green3.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                Green3.BorderColor = Color.FromArgb(66, 66, 66);
                Green3.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[8] == false)
            {
                Blue3.BorderColor = Color.FromArgb(255, 39, 58);
                Blue3.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                Blue3.BorderColor = Color.FromArgb(66, 66, 66);
                Blue3.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[9] == false)
            {
                Red4.BorderColor = Color.FromArgb(255, 39, 58);
                Red4.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                Red4.BorderColor = Color.FromArgb(66, 66, 66);
                Red4.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[10] == false)
            {
                Green4.BorderColor = Color.FromArgb(255, 39, 58);
                Green4.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                Green4.BorderColor = Color.FromArgb(66, 66, 66);
                Green4.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[11] == false)
            {
                Blue4.BorderColor = Color.FromArgb(255, 39, 58);
                Blue4.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                Blue4.BorderColor = Color.FromArgb(66, 66, 66);
                Blue4.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[12] == false)
            {
                Red5.BorderColor = Color.FromArgb(255, 39, 58);
                Red5.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                Red5.BorderColor = Color.FromArgb(66, 66, 66);
                Red5.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[13] == false)
            {
                Green5.BorderColor = Color.FromArgb(255, 39, 58);
                Green5.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                Green5.BorderColor = Color.FromArgb(66, 66, 66);
                Green5.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[14] == false)
            {
                Blue5.BorderColor = Color.FromArgb(255, 39, 58);
                Blue5.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                Blue5.BorderColor = Color.FromArgb(66, 66, 66);
                Blue5.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[15] == false)
            {
                Red6.BorderColor = Color.FromArgb(255, 39, 58);
                Red6.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                Red6.BorderColor = Color.FromArgb(66, 66, 66);
                Red6.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[16] == false)
            {
                Green6.BorderColor = Color.FromArgb(255, 39, 58);
                Green6.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                Green6.BorderColor = Color.FromArgb(66, 66, 66);
                Green6.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[17] == false)
            {
                Blue6.BorderColor = Color.FromArgb(255, 39, 58);
                Blue6.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                Blue6.BorderColor = Color.FromArgb(66, 66, 66);
                Blue6.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[18] == false)
            {
                Red7.BorderColor = Color.FromArgb(255, 39, 58);
                Red7.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                Red7.BorderColor = Color.FromArgb(66, 66, 66);
                Red7.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[19] == false)
            {
                Green7.BorderColor = Color.FromArgb(255, 39, 58);
                Green7.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                Green7.BorderColor = Color.FromArgb(66, 66, 66);
                Green7.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[20] == false)
            {
                Blue7.BorderColor = Color.FromArgb(255, 39, 58);
                Blue7.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                Blue7.BorderColor = Color.FromArgb(66, 66, 66);
                Blue7.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[21] == false)
            {
                Red8.BorderColor = Color.FromArgb(255, 39, 58);
                Red8.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                Red8.BorderColor = Color.FromArgb(66, 66, 66);
                Red8.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[22] == false)
            {
                Green8.BorderColor = Color.FromArgb(255, 39, 58);
                Green8.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                Green8.BorderColor = Color.FromArgb(66, 66, 66);
                Green8.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[23] == false)
            {
                Blue8.BorderColor = Color.FromArgb(255, 39, 58);
                Blue8.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                Blue8.BorderColor = Color.FromArgb(66, 66, 66);
                Blue8.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[24] == false)
            {
                Red9.BorderColor = Color.FromArgb(255, 39, 58);
                Red9.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                Red9.BorderColor = Color.FromArgb(66, 66, 66);
                Red9.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[25] == false)
            {
                Green9.BorderColor = Color.FromArgb(255, 39, 58);
                Green9.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                Green9.BorderColor = Color.FromArgb(66, 66, 66);
                Green9.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[26] == false)
            {
                Blue9.BorderColor = Color.FromArgb(255, 39, 58);
                Blue9.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                Blue9.BorderColor = Color.FromArgb(66, 66, 66);
                Blue9.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[27] == false)
            {
                Red10.BorderColor = Color.FromArgb(255, 39, 58);
                Red10.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                Red10.BorderColor = Color.FromArgb(66, 66, 66);
                Red10.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[28] == false)
            {
                Green10.BorderColor = Color.FromArgb(255, 39, 58);
                Green10.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                Green10.BorderColor = Color.FromArgb(66, 66, 66);
                Green10.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[29] == false)
            {
                Blue10.BorderColor = Color.FromArgb(255, 39, 58);
                Blue10.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                Blue10.BorderColor = Color.FromArgb(66, 66, 66);
                Blue10.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[30] == false)
            {
                Red11.BorderColor = Color.FromArgb(255, 39, 58);
                Red11.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                Red11.BorderColor = Color.FromArgb(66, 66, 66);
                Red11.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[31] == false)
            {
                Green11.BorderColor = Color.FromArgb(255, 39, 58);
                Green11.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                Green11.BorderColor = Color.FromArgb(66, 66, 66);
                Green11.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[32] == false)
            {
                Blue11.BorderColor = Color.FromArgb(255, 39, 58);
                Blue11.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                Blue11.BorderColor = Color.FromArgb(66, 66, 66);
                Blue11.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[33] == false)
            {
                Red12.BorderColor = Color.FromArgb(255, 39, 58);
                Red12.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                Red12.BorderColor = Color.FromArgb(66, 66, 66);
                Red12.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[34] == false)
            {
                Green12.BorderColor = Color.FromArgb(255, 39, 58);
                Green12.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                Green12.BorderColor = Color.FromArgb(66, 66, 66);
                Green12.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[35] == false)
            {
                Blue12.BorderColor = Color.FromArgb(255, 39, 58);
                Blue12.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                Blue12.BorderColor = Color.FromArgb(66, 66, 66);
                Blue12.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[36] == false)
            {
                Red13.BorderColor = Color.FromArgb(255, 39, 58);
                Red13.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                Red13.BorderColor = Color.FromArgb(66, 66, 66);
                Red13.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[37] == false)
            {
                Green13.BorderColor = Color.FromArgb(255, 39, 58);
                Green13.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                Green13.BorderColor = Color.FromArgb(66, 66, 66);
                Green13.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[38] == false)
            {
                Blue13.BorderColor = Color.FromArgb(255, 39, 58);
                Blue13.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                Blue13.BorderColor = Color.FromArgb(66, 66, 66);
                Blue13.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[39] == false)
            {
                Red14.BorderColor = Color.FromArgb(255, 39, 58);
                Red14.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                Red14.BorderColor = Color.FromArgb(66, 66, 66);
                Red14.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[40] == false)
            {
                Green14.BorderColor = Color.FromArgb(255, 39, 58);
                Green14.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                Green14.BorderColor = Color.FromArgb(66, 66, 66);
                Green14.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[41] == false)
            {
                Blue14.BorderColor = Color.FromArgb(255, 39, 58);
                Blue14.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                Blue14.BorderColor = Color.FromArgb(66, 66, 66);
                Blue14.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[42] == false)
            {
                Red15.BorderColor = Color.FromArgb(255, 39, 58);
                Red15.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                Red15.BorderColor = Color.FromArgb(66, 66, 66);
                Red15.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[43] == false)
            {
                Green15.BorderColor = Color.FromArgb(255, 39, 58);
                Green15.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                Green15.BorderColor = Color.FromArgb(66, 66, 66);
                Green15.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[44] == false)
            {
                Blue15.BorderColor = Color.FromArgb(255, 39, 58);
                Blue15.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                Blue15.BorderColor = Color.FromArgb(66, 66, 66);
                Blue15.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[45] == false)
            {
                Red16.BorderColor = Color.FromArgb(255, 39, 58);
                Red16.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                Red16.BorderColor = Color.FromArgb(66, 66, 66);
                Red16.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[46] == false)
            {
                Green16.BorderColor = Color.FromArgb(255, 39, 58);
                Green16.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                Green16.BorderColor = Color.FromArgb(66, 66, 66);
                Green16.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[47] == false)
            {
                Blue16.BorderColor = Color.FromArgb(255, 39, 58);
                Blue16.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                Blue16.BorderColor = Color.FromArgb(66, 66, 66);
                Blue16.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[48] == false)
            {
                Red17.BorderColor = Color.FromArgb(255, 39, 58);
                Red17.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                Red17.BorderColor = Color.FromArgb(66, 66, 66);
                Red17.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[49] == false)
            {
                Green17.BorderColor = Color.FromArgb(255, 39, 58);
                Green17.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                Green17.BorderColor = Color.FromArgb(66, 66, 66);
                Green17.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[50] == false)
            {
                Blue17.BorderColor = Color.FromArgb(255, 39, 58);
                Blue17.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                Blue17.BorderColor = Color.FromArgb(66, 66, 66);
                Blue17.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[51] == false)
            {
                Red18.BorderColor = Color.FromArgb(255, 39, 58);
                Red18.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                Red18.BorderColor = Color.FromArgb(66, 66, 66);
                Red18.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[52] == false)
            {
                Green18.BorderColor = Color.FromArgb(255, 39, 58);
                Green18.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                Green18.BorderColor = Color.FromArgb(66, 66, 66);
                Green18.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            if (canSave[53] == false)
            {
                Blue18.BorderColor = Color.FromArgb(255, 39, 58);
                Blue18.BorderFocusColor = Color.FromArgb(255, 94, 108);
            }
            else
            {
                Blue18.BorderColor = Color.FromArgb(66, 66, 66);
                Blue18.BorderFocusColor = Color.FromArgb(153, 153, 153);
            }

            

            if (canSave[0] == true && canSave[1] == true && canSave[2] == true && canSave[3] == true && canSave[4] == true && canSave[5] == true && canSave[6] == true && canSave[7] == true && canSave[8] == true && canSave[9] == true && canSave[10] == true && canSave[11] == true && canSave[12] == true && canSave[13] == true && canSave[14] == true && canSave[15] == true && canSave[16] == true && canSave[17] == true && canSave[18] == true && canSave[19] == true && canSave[20] == true && canSave[21] == true && canSave[22] == true && canSave[5] == true && canSave[23] == true && canSave[24] == true && canSave[25] == true && canSave[26] == true && canSave[27] == true && canSave[28] == true && canSave[29] == true && canSave[30] == true && canSave[31] == true && canSave[32] == true && canSave[33] == true && canSave[34] == true && canSave[35] == true && canSave[36] == true && canSave[37] == true && canSave[38] == true && canSave[39] == true && canSave[40] == true && canSave[41] == true && canSave[42] == true && canSave[43] == true && canSave[44] == true && canSave[45] == true && canSave[46] == true && canSave[47] == true && canSave[48] == true && canSave[49] == true && canSave[50] == true && canSave[51] == true && canSave[52] == true && canSave[53] == true)
            {
                Save_Form();

                SaveStatus = 1;
                return true;
            }
            return false;
        }

        private void Save_Form()
        {
            NewColorData = new Color[]{ 
                Color.FromArgb(Int32.Parse(Red1.Texts), Int32.Parse(Green1.Texts), Int32.Parse(Blue1.Texts)),
                Color.FromArgb(Int32.Parse(Red2.Texts), Int32.Parse(Green2.Texts), Int32.Parse(Blue2.Texts)),
                Color.FromArgb(Int32.Parse(Red3.Texts), Int32.Parse(Green3.Texts), Int32.Parse(Blue3.Texts)),
                Color.FromArgb(Int32.Parse(Red4.Texts), Int32.Parse(Green4.Texts), Int32.Parse(Blue4.Texts)),
                Color.FromArgb(Int32.Parse(Red5.Texts), Int32.Parse(Green5.Texts), Int32.Parse(Blue5.Texts)),
                Color.FromArgb(Int32.Parse(Red6.Texts), Int32.Parse(Green6.Texts), Int32.Parse(Blue6.Texts)),    
                Color.FromArgb(Int32.Parse(Red7.Texts), Int32.Parse(Green7.Texts), Int32.Parse(Blue7.Texts)),    
                Color.FromArgb(Int32.Parse(Red8.Texts), Int32.Parse(Green8.Texts), Int32.Parse(Blue8.Texts)),
                Color.FromArgb(Int32.Parse(Red9.Texts), Int32.Parse(Green9.Texts), Int32.Parse(Blue9.Texts)),    
                Color.FromArgb(Int32.Parse(Red10.Texts), Int32.Parse(Green10.Texts), Int32.Parse(Blue10.Texts)),    
                Color.FromArgb(Int32.Parse(Red11.Texts), Int32.Parse(Green11.Texts), Int32.Parse(Blue11.Texts)),    
                Color.FromArgb(Int32.Parse(Red12.Texts), Int32.Parse(Green12.Texts), Int32.Parse(Blue12.Texts)),    
                Color.FromArgb(Int32.Parse(Red13.Texts), Int32.Parse(Green13.Texts), Int32.Parse(Blue13.Texts)), 
                Color.FromArgb(Int32.Parse(Red14.Texts), Int32.Parse(Green14.Texts), Int32.Parse(Blue14.Texts)),    
                Color.FromArgb(Int32.Parse(Red15.Texts), Int32.Parse(Green15.Texts), Int32.Parse(Blue15.Texts)),    
                Color.FromArgb(Int32.Parse(Red16.Texts), Int32.Parse(Green16.Texts), Int32.Parse(Blue16.Texts)),    
                Color.FromArgb(Int32.Parse(Red17.Texts), Int32.Parse(Green17.Texts), Int32.Parse(Blue17.Texts)),    
                Color.FromArgb(Int32.Parse(Red18.Texts), Int32.Parse(Green18.Texts), Int32.Parse(Blue18.Texts))
                    };
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Color
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void TB_TextChanged(CustomTextBox TB, CustomTextBox TB1, CustomTextBox TB2, CustomTextBox TB3, Panel P, int a, int b, int c, int d)
        {
            SaveStatus = 2;
            int i;
            if (!Regex.Match(TB.Texts, "^([0-9])+$").Success || string.IsNullOrEmpty(TB.Texts))
            {
                canSave[d] = false;
            }
            else
            {
                if (int.TryParse(TB.Texts, out i) && i >= 0 && i <= 255)
                {
                    canSave[d] = true;
                }
                else
                {
                    canSave[d] = false;
                }
            }

            if (canSave[a] == true && canSave[b] == true && canSave[c] == true)
            {
                P.BackColor = Color.FromArgb(Int32.Parse(TB1.Texts), Int32.Parse(TB2.Texts), Int32.Parse(TB3.Texts));
            }
        }

        private void Red1_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            TB_TextChanged(Red1, Red1, Green1, Blue1, Color1, 0, 1, 2, 0);
        }

        private void Green1_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            TB_TextChanged(Green1, Red1, Green1, Blue1, Color1, 0, 1, 2, 1);
        }

        private void Blue1_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            TB_TextChanged(Blue1, Red1, Green1, Blue1, Color1, 0, 1, 2, 2);
        }

        private void Red2_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            TB_TextChanged(Red2, Red2, Green2, Blue2, Color2, 3, 4, 5, 3);
        }

        private void Green2_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            TB_TextChanged(Green2, Red2, Green2, Blue2, Color2, 3, 4, 5, 4);
        }

        private void Blue2_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            TB_TextChanged(Blue2, Red2, Green2, Blue2, Color2, 3, 4, 5, 5);
        }

        private void Red3_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            TB_TextChanged(Red3, Red3, Green3, Blue3, Color3, 6, 7, 8, 6);
        }

        private void Green3_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            TB_TextChanged(Green3, Red3, Green3, Blue3, Color3, 6, 7, 8, 7);
        }

        private void Blue3_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            TB_TextChanged(Blue3, Red3, Green3, Blue3, Color3, 6, 7, 8, 8);
        }

        private void Red4_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            TB_TextChanged(Red4, Red4, Green4, Blue4, Color4, 9, 10, 11, 9);
        }

        private void Green4_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            TB_TextChanged(Green4, Red4, Green4, Blue4, Color4, 9, 10, 11, 10);
        }

        private void Blue4_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            TB_TextChanged(Blue4, Red4, Green4, Blue4, Color4, 9, 10, 11, 11);
        }

        private void Red5_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            TB_TextChanged(Red5, Red5, Green5, Blue5, Color5, 12, 13, 14, 12);
        }

        private void Green5_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            TB_TextChanged(Green5, Red5, Green5, Blue5, Color5, 12, 13, 14, 13);
        }

        private void Blue5_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            TB_TextChanged(Blue5, Red5, Green5, Blue5, Color5, 12, 13, 14, 14);
        }

        private void Red6_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            TB_TextChanged(Red6, Red6, Green6, Blue6, Color6, 15, 16, 17, 15);
        }

        private void Green6_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            TB_TextChanged(Green6, Red6, Green6, Blue6, Color6, 15, 16, 17, 16);
        }

        private void Blue6_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            TB_TextChanged(Blue6, Red6, Green6, Blue6, Color6, 15, 16, 17, 17);
        }

        private void Red7_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            TB_TextChanged(Red7, Red7, Green7, Blue7, Color7, 18, 19, 20, 18);
        }

        private void Green7_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            TB_TextChanged(Green7, Red7, Green7, Blue7, Color7, 18, 19, 20, 19);
        }

        private void Blue7_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            TB_TextChanged(Blue7, Red7, Green7, Blue7, Color7, 18, 19, 20, 20);
        }

        private void Red8_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            TB_TextChanged(Red8, Red8, Green8, Blue8, Color8, 21, 22, 23, 21);
        }

        private void Green8_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            TB_TextChanged(Green8, Red8, Green8, Blue8, Color8, 21, 22, 23, 22);
        }

        private void Blue8_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            TB_TextChanged(Blue8, Red8, Green8, Blue8, Color8, 21, 22, 23, 23);
        }

        private void Red9_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            TB_TextChanged(Red9, Red9, Green9, Blue9, Color9, 24, 25, 26, 24);
        }

        private void Green9_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            TB_TextChanged(Green9, Red9, Green9, Blue9, Color9, 24, 25, 26, 25);
        }

        private void Blue9_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            TB_TextChanged(Blue9, Red9, Green9, Blue9, Color9, 24, 25, 26, 26);
        }

        private void Red10_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            TB_TextChanged(Red10, Red10, Green10, Blue10, Color10, 27, 28, 29, 27);
        }

        private void Green10_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            TB_TextChanged(Green10, Red10, Green10, Blue10, Color10, 27, 28, 29, 28);
        }

        private void Blue10_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            TB_TextChanged(Blue10, Red10, Green10, Blue10, Color10, 27, 28, 29, 29);
        }

        private void Red11_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            TB_TextChanged(Red11, Red11, Green11, Blue11, Color11, 30, 31, 32, 30);
        }

        private void Green11_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            TB_TextChanged(Green11, Red11, Green11, Blue11, Color11, 30, 31, 32, 31);
        }

        private void Blue11_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            TB_TextChanged(Blue11, Red11, Green11, Blue11, Color11, 30, 31, 32, 32);
        }

        private void Red12_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            TB_TextChanged(Red12, Red12, Green12, Blue12, Color12, 33, 34, 35, 33);
        }

        private void Green12_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            TB_TextChanged(Green12, Red12, Green12, Blue12, Color12, 33, 34, 35, 34);
        }

        private void Blue12_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            TB_TextChanged(Blue12, Red12, Green12, Blue12, Color12, 33, 34, 35, 35);
        }

        private void Red13_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            TB_TextChanged(Red13, Red13, Green13, Blue13, Color13, 36, 37, 38, 36);
        }

        private void Green13_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            TB_TextChanged(Green13, Red13, Green13, Blue13, Color13, 36, 37, 38, 37);
        }

        private void Blue13_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            TB_TextChanged(Blue13, Red13, Green13, Blue13, Color13, 36, 37, 38, 38);
        }

        private void Red14_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            TB_TextChanged(Red14, Red14, Green14, Blue14, Color14, 39, 40, 41, 39);
        }

        private void Green14_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            TB_TextChanged(Green14, Red14, Green14, Blue14, Color14, 39, 40, 41, 40);
        }

        private void Blue14_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            TB_TextChanged(Blue14, Red14, Green14, Blue14, Color14, 39, 40, 41, 41);
        }

        private void Red15_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            TB_TextChanged(Red15, Red15, Green15, Blue15, Color15, 42, 43, 44, 42);
        }

        private void Green15_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            TB_TextChanged(Green15, Red15, Green15, Blue15, Color15, 42, 43, 44, 43);
        }

        private void Blue15_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            TB_TextChanged(Blue15, Red15, Green15, Blue15, Color15, 42, 43, 44, 44);
        }

        private void Red16_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            TB_TextChanged(Red16, Red16, Green16, Blue16, Color16, 45, 46, 47, 45);
        }

        private void Green16_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            TB_TextChanged(Green16, Red16, Green16, Blue16, Color16, 45, 46, 47, 46);
        }

        private void Blue16_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            TB_TextChanged(Blue16, Red16, Green16, Blue16, Color16, 45, 46, 47, 47);
        }

        private void Red17_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            TB_TextChanged(Red17, Red17, Green17, Blue17, Color17, 48, 49, 50, 48);
        }

        private void Green17_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            TB_TextChanged(Green17, Red17, Green17, Blue17, Color17, 48, 49, 50, 49);
        }

        private void Blue17_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            TB_TextChanged(Blue17, Red17, Green17, Blue17, Color17, 48, 49, 50, 50);
        }

        private void Red18_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            TB_TextChanged(Red18, Red18, Green18, Blue18, Color18, 51, 52, 53, 51);
        }

        private void Green18_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            TB_TextChanged(Green18, Red18, Green18, Blue18, Color18, 51, 52, 53, 52);
        }

        private void Blue18_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            TB_TextChanged(Blue18, Red18, Green18, Blue18, Color18, 51, 52, 53, 53);
        }


    }
}