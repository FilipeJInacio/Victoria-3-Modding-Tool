using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System;

namespace Victoria_3_Modding_Tool.Custom_Controls
{
    class CustomListBox : UserControl
    {
        //Fields
        private Color borderColor = Color.MediumSlateBlue;
        private int borderSize = 1;


        //Items
        private ListBox Listb;

        //Properties
        [Category("Custom")]
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
            }
        }

        [Category("Custom")]
        public int BorderSize
        {
            get { return borderSize; }
            set
            {
                borderSize = value;
                this.Padding = new Padding(borderSize);//Border Size
                AdjustListBoxDimensions();
            }
        }


        [Category("Custom")]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                this.Listb.BackColor = value;
                base.BackColor = value;
            }
        }


        public void Add(object item)
        {
            this.Listb.BeginUpdate();
            this.Listb.Items.Add(item);
            this.Listb.EndUpdate();
        }

        public void Clear()
        {
            this.Listb.BeginUpdate();
            this.Listb.Items.Clear();
            this.Listb.EndUpdate();
        }

        public int SelectedIndex()
        {
            return this.Listb.SelectedIndex;
        }


        public object Item(int index)
        {
            return this.Listb.Items[index];
        }


       


        // List Properties
        public CustomListBox()
        {
            Listb = new ListBox();
            this.SuspendLayout();
            // ListBox
            Listb.BorderStyle = BorderStyle.None;
            Listb.DrawMode = DrawMode.OwnerDrawFixed;
            Listb.Font = new Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Listb.ForeColor = Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            Listb.FormattingEnabled = true;
            Listb.ItemHeight = 24;
            Listb.Location = new Point(0,0);
            Listb.Name = "CustomListBox";
            Listb.Size = new Size(235, 936);
            Listb.DrawItem += new DrawItemEventHandler(Listb_DrawItem);
            Listb.Dock = DockStyle.Fill;
            Listb.BackColor = BackColor;
            
            Controls.Add(Listb);
            ResumeLayout();
            AdjustListBoxDimensions();

        }



        // Highlight event
        private void Listb_DrawItem(object sender, DrawItemEventArgs e)
        {
            Color backgroundColor = Color.FromArgb(50, 50, 50);
            Color horizontalColor = Color.FromArgb(100, 100, 100);


            if (e.Index >= 0)
            {
                SolidBrush sb = new SolidBrush(((e.State & DrawItemState.Selected) == DrawItemState.Selected) ? horizontalColor : backgroundColor);
                e.Graphics.FillRectangle(sb, e.Bounds);
                string text = Listb.Items[e.Index].ToString();
                SolidBrush tb = new SolidBrush(e.ForeColor);
                e.Graphics.DrawString(text, e.Font, tb, Listb.GetItemRectangle(e.Index).Location);
            }
        }





        //Adjust Dimension (Still in test)
        private void AdjustListBoxDimensions()
        {
            Listb.Location = new Point()
            {
                X = this.Width - this.Padding.Right - Listb.Width,
                Y = Listb.Height
            };
        }


        // Draws the border
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graph = e.Graphics;
            //Draw border
            using (Pen penBorder = new Pen(borderColor, borderSize))
            {
                penBorder.Alignment = PenAlignment.Inset;
                graph.DrawRectangle(penBorder, 0, 0, this.Width - 0.5F, this.Height - 0.5F);
            }
        }




    }
}
