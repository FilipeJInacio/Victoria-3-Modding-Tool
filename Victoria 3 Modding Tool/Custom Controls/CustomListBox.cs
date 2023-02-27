using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Victoria_3_Modding_Tool
{
    public partial class CustomListBox : UserControl
    {


        //Fields
        private Color borderColor = Color.FromArgb(66, 66, 66);

        private Color highlightColor = Color.FromArgb(80, 80, 80);

        private Color lineColor = Color.FromArgb(66, 66, 66);

        private int borderSize = 2;
        
        private int lineSize = 2;


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
        public Color HighlightColor
        {
            get { return highlightColor; }
            set
            {
                highlightColor = value;
            }
        }

        [Category("Custom")]
        public Color LineColor
        {
            get { return lineColor; }
            set
            {
                lineColor = value;
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
        public int LineSize
        {
            get { return lineSize; }
            set
            {
                lineSize = value;
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

        [Category("Custom")]
        public new Size Size
        {
            get { return base.Size; }
            set { base.Size = value; }
        }

        [Category("Custom")]
        public new Point Location
        {
            get { return base.Location; }
            set { base.Location = value; }
        }

        [Category("Custom")]
        public int Count
        {
            get { return Listb.Items.Count; }
        }

        // Methods
        public void Add(string item)
        {
            Listb.BeginUpdate();
            Listb.Items.Add(item);
            Listb.EndUpdate();
        }

        public void Clear()
        {
            this.Listb.BeginUpdate();
            this.Listb.Items.Clear();
            this.Listb.EndUpdate();
        }

        public int SelectedIndex
        {
            get { return Listb.SelectedIndex; }
            set { Listb.SelectedIndex = value; }
        }

        public object Items(int index)
        {
            return this.Listb.Items[index];
        }

        public object this[int index]
        {
            get { return Listb.Items[index]; }
            set { Listb.Items[index] = value; }
        }


        // Event
        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when double click")]
        public event EventHandler<string> ItemDoubleClicked;

        private void Listb_DoubleClick(object sender, EventArgs e)
        {
            if (Listb.SelectedItem != null)
            {
                OnItemDoubleClicked(Listb.SelectedItem.ToString());
            }
        }

        protected virtual void OnItemDoubleClicked(string item)
        {
            ItemDoubleClicked?.Invoke(this, item);
        }




        // List Properties
        public CustomListBox()
        {
            DoubleBuffered = true;
            Listb = new ListBox();
            this.SuspendLayout();
            // ListBox
            Listb.BorderStyle = BorderStyle.None;
            Listb.DrawMode = DrawMode.OwnerDrawFixed;
            Listb.Font = new Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Listb.ForeColor = Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            Listb.FormattingEnabled = true;
            Listb.ItemHeight = 24;
            Listb.Location = new Point(0, 0);
            Listb.Name = "ListBox";
            Listb.Size = new Size(235, 936);
            Listb.DrawItem += new DrawItemEventHandler(Listb_DrawItem);
            Listb.DoubleClick += new System.EventHandler(Listb_DoubleClick);
            Listb.Dock = DockStyle.Fill;
            Listb.BackColor = BackColor;
            // Forward the DoubleClick event of the custom control to the ListBox


            Controls.Add(Listb);
            ResumeLayout();
            AdjustListBoxDimensions();
        }


        // Highlight event
        private void Listb_DrawItem(object sender, DrawItemEventArgs e)
        {

            if (e.Index >= 0)
            {
                // Makes background
                SolidBrush sb = new SolidBrush(((e.State & DrawItemState.Selected) == DrawItemState.Selected) ? HighlightColor : BackColor);
                e.Graphics.FillRectangle(sb, e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);

                // Makes Lines
                using (Pen penBorder = new Pen(lineColor, lineSize))
                {
                    penBorder.Alignment = PenAlignment.Inset;
                    e.Graphics.DrawRectangle(penBorder, e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
                }

                // Makes text
                string text = Listb.Items[e.Index].ToString();
                SolidBrush tb = new SolidBrush(e.ForeColor);
                e.Graphics.DrawString(text, e.Font, tb, Listb.GetItemRectangle(e.Index).Location.X + 3F, Listb.GetItemRectangle(e.Index).Location.Y + 3F);
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
