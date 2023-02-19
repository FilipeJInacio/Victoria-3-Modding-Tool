using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AutocompleteMenuNS
{
    [Serializable]
    public class Colors
    {
        public Color ForeColor { get; set; }
        public Color BackColor { get; set; }
        public Color SelectedForeColor { get; set; }
        public Color SelectedBackColor { get; set; }
        public Color SelectedBackColor2 { get; set; }
        public Color HighlightingColor { get; set; }

        public Colors()
        {
            ForeColor = Color.White;
            BackColor = Color.FromArgb(30, 30, 30);
            SelectedForeColor = Color.FromArgb(230, 230, 230);
            SelectedBackColor = Color.FromArgb(31, 98, 169);
            SelectedBackColor2 = Color.FromArgb(31, 98, 169);
            HighlightingColor = Color.FromArgb(90, 90, 90);
        }
    }
}
