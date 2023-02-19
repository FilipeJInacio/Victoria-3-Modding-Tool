using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Victoria_3_Modding_Tool
{
    internal class VerticalToolStripSeparator : ToolStripSeparator
    {
        public VerticalToolStripSeparator()
        {
            this.Paint += ExtendedToolStripSeparator_Paint;
        }

        private void ExtendedToolStripSeparator_Paint(object sender, PaintEventArgs e)
        {
            // Get the separator's width and height.
            ToolStripSeparator toolStripSeparator = (ToolStripSeparator)sender;
            int width = toolStripSeparator.Width;
            int height = toolStripSeparator.Height;

            // Choose the colors for drawing.
            Color foreColor = Color.FromArgb(160, 160, 160);
            Color backColor = Color.FromArgb(41, 41, 41);

            // Fill the background.
            e.Graphics.FillRectangle(new SolidBrush(backColor), 0, 0, width, height);

            // Draw the line.
            e.Graphics.DrawLine(new Pen(foreColor), width / 2, 6, width / 2, height - 6);
        }
    }
}
