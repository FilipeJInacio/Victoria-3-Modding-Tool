using System;
using System.Collections.Generic;

namespace Victoria_3_Modding_Tool.Forms.Tech
{
    public class ClassCultures : IType, ITexture
    {
        public string Name { get; set; }
        public string TrueName { get; set; }
        public int Era { get; set; }
        public string Texture { get; set; }
        public string Desc { get; set; }
        public string Category { get; set; }
        public bool CanResearch { get; set; }
        public List<string> Modifiers { get; set; }
        public List<string> Restrictions { get; set; }

        public ClassCultures()
        { }

        public ClassCultures(ClassTech tech)
        {
            this.Name = tech.Name;
            this.TrueName = tech.TrueName;
            this.Era = tech.Era;
            this.Texture = tech.Texture;
            this.Desc = tech.Desc;
            this.Category = tech.Category;
            this.CanResearch = tech.CanResearch;
            Modifiers = new List<string>();
            foreach (string modifier in tech.Modifiers)
            {
                Modifiers.Add(modifier);
            }

            Restrictions = new List<string>();
            foreach (string restriction in tech.Restrictions)
            {
                Restrictions.Add(restriction);
            }
        }

        public ClassCultures(string name, string TrueName, int era, string texture, string desc, string category, bool canResearch)
        {
            this.Name = name;
            this.TrueName = TrueName;
            this.Era = era;
            this.Texture = texture;
            this.Desc = desc;
            this.Category = category;
            this.CanResearch = canResearch;
            Modifiers = new List<string>();
            Restrictions = new List<string>();
        }

        public ClassCultures(KeyValuePair<string, object> ParserData, string TrueName, string Desc)
        {
            Modifiers = new List<string>();
            Restrictions = new List<string>();

            this.CanResearch = true;
            this.Name = ParserData.Key;
            this.Desc = Desc;
            this.TrueName = TrueName;

            foreach (KeyValuePair<string, object> element in (List<KeyValuePair<string, object>>)ParserData.Value)
            {
                switch (element.Key)
                {
                    case "era":
                        this.Era = Int32.Parse(element.Value.ToString().Substring(4)); continue;
                    case "texture":
                        this.Texture = element.Value.ToString().Trim('"'); continue;
                    case "category":
                        this.Category = element.Value.ToString(); continue;
                    case "can_research":
                        if (element.Value.ToString() == "no") { this.CanResearch = false; } else { this.CanResearch = true; }
                        continue;
                    case "modifier":
                        foreach (KeyValuePair<string, object> modifiersEntry in (List<KeyValuePair<string, object>>)element.Value)
                        {
                            this.Modifiers.Add(modifiersEntry.Key + " = " + modifiersEntry.Value);
                        }
                        continue;
                    case "unlocking_technologies":
                        foreach (KeyValuePair<string, object> neededTech in (List<KeyValuePair<string, object>>)element.Value)
                        {
                            this.Restrictions.Add(neededTech.Value.ToString());
                        }
                        continue;
                    default:
                        continue;
                }
            }
        }
    }
}