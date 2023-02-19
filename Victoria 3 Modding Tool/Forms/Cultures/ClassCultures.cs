using System;
using System.Collections.Generic;

namespace Victoria_3_Modding_Tool
{
    public class ClassCultures : IType
    {
        public string Name { get; set; }

        public string TrueName { get; set; }

        public string Code { get; set; }

        public ClassCultures()
        { }

        public ClassCultures(ClassCultures Culture)
        {
            this.Name = Culture.Name;
            this.TrueName = Culture.TrueName;
            this.Code = Culture.Code;
        }

        public ClassCultures(string name, string trueName, string code)
        {
            this.Name = name;
            this.TrueName = trueName;
            this.Code = code;
        }

        public ClassCultures(KeyValuePair<string, object> ParserData, string trueName)
        {
            this.Name = ParserData.Key;
            this.TrueName = trueName;
            this.Code = (string)ParserData.Value;
        }
    }
}