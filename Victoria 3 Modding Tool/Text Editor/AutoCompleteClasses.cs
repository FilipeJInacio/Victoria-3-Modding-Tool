using System;
using System.Drawing;

namespace AutocompleteMenuNS
{
    public class UnknownAutocompleteItem : AutocompleteItem
    {
        public UnknownAutocompleteItem(string snippet) : base(snippet)
        {
            Text = snippet.Replace("\r", "");
            ToolTipTitle = "Unknown:";
            ToolTipText = Text;
            ToolTipBackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            ToolTipForeColor = System.Drawing.Color.White;
        }
    }

}
