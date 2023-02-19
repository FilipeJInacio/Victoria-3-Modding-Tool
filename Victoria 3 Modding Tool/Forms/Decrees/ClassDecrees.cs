using System.Collections.Generic;
using System.Drawing;

namespace Victoria_3_Modding_Tool
{
    public class ClassDecrees : IType
    {
        public string Name { get; set; }

        public string TrueName { get; set; }

        public string Description { get; set; }

        public string Code { get; set; }

        public ClassDecrees()
        { }

        public ClassDecrees(ClassDecrees Decree)
        {
            this.Name= Decree.Name;
            this.TrueName= Decree.TrueName;
            this.Description= Decree.Description;
            this.Code= Decree.Code;
        }

        public ClassDecrees(string name, string trueName,string desc, string code)
        {
            this.Name = name;
            this.TrueName = trueName;
            this.Description = desc;
            this.Code = code;
        }

        public ClassDecrees(KeyValuePair<string, object> ParserData, string trueName,string desc)
        {
            this.Name = ParserData.Key;
            this.Description = desc;
            this.TrueName = trueName;
            this.Code = (string)ParserData.Value;
        }
    }

}