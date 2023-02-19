using System.Collections.Generic;

namespace Victoria_3_Modding_Tool
{
    public class ClassLawGroups : IType
    {
        public string Name { get; set; }

        public string TrueName { get; set; }

        public string Description { get; set; }

        public string Code { get; set; }

        public ClassLawGroups()
        { }

        public ClassLawGroups(ClassLawGroups LawGroups)
        {
            this.Name = LawGroups.Name;
            this.TrueName = LawGroups.TrueName;
            this.Description = LawGroups.Description;
            this.Code = LawGroups.Code;
        }

        public ClassLawGroups(string name, string trueName, string desc, string code)
        {
            this.Name = name;
            this.TrueName = trueName;
            this.Description = desc;
            this.Code = code;
        }

        public ClassLawGroups(KeyValuePair<string, object> ParserData, string trueName, string desc)
        {
            this.Name = ParserData.Key;
            this.Description = desc;
            this.TrueName = trueName;
            this.Code = (string)ParserData.Value;
        }
    }



    public class ClassLaws : IType
    {
        public string Name { get; set; }

        public string TrueName { get; set; }

        public string Description { get; set; }

        public string Code { get; set; }

        public ClassLaws()
        { }

        public ClassLaws(ClassLaws Laws)
        {
            this.Name= Laws.Name;
            this.TrueName= Laws.TrueName;
            this.Description= Laws.Description;
            this.Code= Laws.Code;
        }

        public ClassLaws(string name, string trueName,string desc, string code)
        {
            this.Name = name;
            this.TrueName = trueName;
            this.Description = desc;
            this.Code = code;
        }

        public ClassLaws(KeyValuePair<string, object> ParserData, string trueName,string desc)
        {
            this.Name = ParserData.Key;
            this.Description = desc;
            this.TrueName = trueName;
            this.Code = (string)ParserData.Value;
        }
    }



}