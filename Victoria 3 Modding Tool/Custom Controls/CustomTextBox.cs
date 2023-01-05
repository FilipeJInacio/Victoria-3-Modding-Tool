using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Victoria_3_Modding_Tool
{
    public partial class CustomTextBox : UserControl
    {
        //Fields
        private Color borderColor = Color.MediumSlateBlue;

        private Color backgroundFocusColor = Color.DarkSlateGray;
        private int borderSize = 2;
        private bool underlinedStyle = false;
        private Color borderFocusColor = Color.HotPink;
        private bool isFocused = false;
        private Color backup;

        public CustomTextBox()
        {
            InitializeComponent();
        }

        //Properties
        [Category("Custom")]
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                this.Invalidate();
            }
        }

        [Category("Custom")]
        public int BorderSize
        {
            get { return borderSize; }
            set
            {
                borderSize = value;
                this.Invalidate();
            }
        }

        [Category("Custom")]
        public bool UnderlinedStyle
        {
            get { return underlinedStyle; }
            set
            {
                underlinedStyle = value;
                this.Invalidate();
            }
        }

        [Category("Custom")]
        public bool Multiline
        {
            get { return textBox1.Multiline; }
            set { textBox1.Multiline = value; }
        }

        [Category("Custom")]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                backup = value;
                base.BackColor = value;
                textBox1.BackColor = value;
            }
        }

        [Category("Custom")]
        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set
            {
                base.ForeColor = value;
                textBox1.ForeColor = value;
            }
        }

        [Category("Custom")]
        public override Font Font
        {
            get { return base.Font; }
            set
            {
                base.Font = value;
                textBox1.Font = value;
                if (this.DesignMode)
                    UpdateControlHeight();
            }
        }

        [Category("Custom")]
        public string Texts
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        [Category("Custom")]
        public Color BorderFocusColor
        {
            get { return borderFocusColor; }
            set { borderFocusColor = value; }
        }

        [Category("Custom")]
        public Color BackgroundColorFocus
        {
            get { return backgroundFocusColor; }
            set
            {
                backgroundFocusColor = value;
                this.Invalidate();
            }
        }

        [Category("Custom")]
        public bool ReadOnly
        {
            get { return textBox1.ReadOnly; }
            set { textBox1.ReadOnly = value; }
        }

        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user changes text")]
        public event EventHandler CustomTextBox_TextChanged;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (CustomTextBox_TextChanged != null)
                CustomTextBox_TextChanged(this, e);
        }

        //Private methods
        private void UpdateControlHeight()
        {
            if (textBox1.Multiline == false)
            {
                int txtHeight = TextRenderer.MeasureText("Text", this.Font).Height + 1;
                textBox1.Multiline = true;
                textBox1.MinimumSize = new Size(0, txtHeight);
                textBox1.Multiline = false;
                this.Height = textBox1.Height + this.Padding.Top + this.Padding.Bottom;
            }
        }

        //Overridden methods
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graph = e.Graphics;
            //Draw border
            using (Pen penBorder = new Pen(borderColor, borderSize))
            {
                penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                if (isFocused) penBorder.Color = borderFocusColor;
                if (underlinedStyle) //Line Style
                    graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                else //Normal Style
                    graph.DrawRectangle(penBorder, 0, 0, this.Width - 0.5F, this.Height - 0.5F);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (this.DesignMode)
                UpdateControlHeight();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UpdateControlHeight();
        }

        //Change border color in focus mode
        private void textBox1_Enter(object sender, EventArgs e)
        {
            isFocused = true;
            textBox1.BackColor = backgroundFocusColor;
            base.BackColor = backgroundFocusColor;
            this.Invalidate();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            isFocused = false;
            textBox1.BackColor = backup;
            base.BackColor = backup;
            this.Invalidate();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(e);
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            this.OnMouseLeave(e);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.OnKeyPress(e);
        }
    }
}