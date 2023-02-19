using System.Collections.Generic;
using System.Drawing;

namespace Victoria_3_Modding_Tool
{
    public class ClassDecisions : IType
    {
        public string Name { get; set; }

        public string TrueName { get; set; }

        public string Description { get; set; }

        public string ToolTip { get; set; }

        public string Code { get; set; }

        public ClassDecisions()
        { }

        public ClassDecisions(ClassDecisions Decision)
        {
            this.Name= Decision.Name;
            this.TrueName= Decision.TrueName;
            this.Description= Decision.Description;
            this.ToolTip= Decision.ToolTip;
            this.Code= Decision.Code;
        }

        public ClassDecisions(string name, string trueName,string desc, string tooltip, string code)
        {
            this.Name = name;
            this.TrueName = trueName;
            this.Description = desc;
            this.ToolTip = tooltip;
            this.Code = code;
        }

        public ClassDecisions(KeyValuePair<string, object> ParserData, string trueName,string desc, string tooltip)
        {
            this.Name = ParserData.Key;
            this.Description = desc;
            this.TrueName = trueName;
            this.ToolTip = tooltip;
            this.Code = (string)ParserData.Value;
        }
    }


    
}