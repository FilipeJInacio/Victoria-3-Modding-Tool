using System;
using System.Collections.Generic;

namespace Victoria_3_Modding_Tool
{
    public class ClassProductionMethods : IType
    {
        public string Name { get; set; }
        public string TrueName { get; set; }

        public string Code { get; set; }

        public ClassProductionMethods()
        { }

        public ClassProductionMethods(ClassProductionMethods ProductMethods)
        {
            this.Name = ProductMethods.Name;
            this.TrueName = ProductMethods.TrueName;
            this.Code = ProductMethods.Code;
        }

        public ClassProductionMethods(string name, string trueName, string code)
        {
            this.Name = name;
            this.TrueName = trueName;
            this.Code = code;
        }

        public ClassProductionMethods(KeyValuePair<string, object> ParserData, string TrueName)
        {
            this.Name = ParserData.Key;
            this.TrueName = TrueName;
            this.Code = (string)ParserData.Value;
        }
    }

    public class ClassProductionMethodGroups : IType
    {
        public string Name { get; set; }
        public string TrueName { get; set; }
        public string Texture { get; set; }
        public bool Is_hidden_when_unavailable { get; set; }
        public bool Ai_selection { get; set; } // DEFAULT -> not most productive -> false
        public List<string> Production_methods { get; set; }

        public ClassProductionMethodGroups()
        { }

        public ClassProductionMethodGroups(ClassProductionMethodGroups ProductMethodsTypes)
        {
            this.Name = ProductMethodsTypes.Name;
            this.TrueName = ProductMethodsTypes.TrueName;
            this.Texture = ProductMethodsTypes.Texture;
            this.Is_hidden_when_unavailable = ProductMethodsTypes.Is_hidden_when_unavailable;
            this.Ai_selection = ProductMethodsTypes.Ai_selection;
            Production_methods = new List<string>();
            foreach (string entry in ProductMethodsTypes.Production_methods)
            {
                Production_methods.Add(entry);
            }
        }

        public ClassProductionMethodGroups(string name,string TrueName, string texture,bool isHidden, bool ai_selection)
        {
            this.Name = name;
            this.TrueName=TrueName;
            this.Texture = texture;
            this.Is_hidden_when_unavailable = isHidden;
            this.Ai_selection = ai_selection;
            Production_methods = new List<string>();
        }

        public ClassProductionMethodGroups(KeyValuePair<string, object> ParserData,string TrueName)
        {
            this.Name = ParserData.Key;
            this.Is_hidden_when_unavailable = false;
            this.Ai_selection = false;
            this.TrueName = TrueName;
            Production_methods = new List<string>();

            foreach (KeyValuePair<string, object> element in (List<KeyValuePair<string, object>>)ParserData.Value)
            {
                switch (element.Key)
                {
                    case "texture":
                        this.Texture = element.Value.ToString().Trim('"'); continue;
                    case "is_hidden_when_unavailable":
                        if (element.Value.ToString() == "yes") { this.Is_hidden_when_unavailable = true; continue; }
                        continue;
                    case "ai_selection":
                        if (element.Value.ToString() == "most_productive") { this.Ai_selection = true; continue; }
                        continue;
                    case "production_methods":
                        foreach (KeyValuePair<string, object> entry in (List<KeyValuePair<string, object>>)element.Value)
                        {
                            this.Production_methods.Add(entry.Value.ToString());
                        }
                        continue;
                    default:
                        continue;
                }
            }
        }

        


    }
}