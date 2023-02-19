using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Xml.Linq;

namespace Victoria_3_Modding_Tool
{
    public class ClassCanals : IType
    {
        public string Name { get; set; }

        public string TrueName { get; set; }

        public string Code { get; set; }

        public ClassCanals()
        { }

        public ClassCanals(ClassCanals Canal)
        {
            this.Name = Canal.Name;
            this.TrueName = Canal.TrueName;
            this.Code = Canal.Code;
        }

        public ClassCanals(string name, string trueName, string code)
        {
            this.Name = name;
            this.TrueName = trueName;
            this.Code = code;
        }

        public ClassCanals(KeyValuePair<string, object> ParserData, string trueName)
        {
            this.Name = ParserData.Key;
            this.TrueName = trueName;
            this.Code = (string)ParserData.Value;
        }
    }
}