using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Victoria_3_Modding_Tool.Forms.Tech
{
    public class ClassStateTraits : IType, ITexture
    {
        public string Name { get; set; }
        public string TrueName { get; set; }
        public string Texture { get; set; }
        public string DisablingTechnologies { get; set; }
        public string RequiredTechsForColonization { get; set; }
        public List<string> Modifiers { get; set; }

        public ClassStateTraits()
        { }

        public ClassStateTraits(KeyValuePair<string, object> ParserData, string TrueName)
        {
            this.Name = ParserData.Key;
            this.TrueName = TrueName;
            this.DisablingTechnologies = string.Empty;
            this.RequiredTechsForColonization= string.Empty;
            this.Modifiers = new List<string>();

            foreach (KeyValuePair<string, object> entry in (List<KeyValuePair<string, object>>)ParserData.Value)
            {
                switch (entry.Key)
                {
                    case "icon":
                        this.Texture = entry.Value.ToString().Trim('"'); continue;
                    case "disabling_technologies":
                        foreach (KeyValuePair<string, object> entry2 in (List<KeyValuePair<string, object>>)entry.Value)
                        {
                            this.DisablingTechnologies = entry2.Value.ToString().Trim('"');
                        }
                        continue;
                    case "required_techs_for_colonization":
                        foreach (KeyValuePair<string, object> entry2 in (List<KeyValuePair<string, object>>)entry.Value)
                        {
                            this.DisablingTechnologies = entry2.Value.ToString().Trim('"');
                        }
                        continue;
                    case "modifier":
                        foreach (KeyValuePair<string, object> modifiersEntry in (List<KeyValuePair<string, object>>)entry.Value)
                        {
                            this.Modifiers.Add(modifiersEntry.Key + " = " + modifiersEntry.Value);
                        }
                        continue;
                    default:
                        continue;
                }
            }
        }

        public ClassStateTraits(ClassStateTraits n)
        {
            this.Name = n.Name;
            this.TrueName = n.TrueName;
            this.Texture = n.Texture;
            this.DisablingTechnologies = n.DisablingTechnologies;
            this.RequiredTechsForColonization = n.RequiredTechsForColonization;
            this.Modifiers = new List<string>();
            foreach (string entry in n.Modifiers)
            {
                Modifiers.Add(entry);
            }
        }

        public ClassStateTraits(string name, string trueName, string icon, string DisablingTechnologies, string RequiredTechsForColonization)
        {
            this.Name = name;
            this.TrueName = trueName;
            this.Texture = icon;
            this.DisablingTechnologies = DisablingTechnologies;
            this.RequiredTechsForColonization= RequiredTechsForColonization;
            this.Modifiers = new List<string>();
        }
    }

}