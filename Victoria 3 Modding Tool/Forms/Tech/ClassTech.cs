using System;
using System.Collections.Generic;

namespace Victoria_3_Modding_Tool.Forms.Tech
{
    public class ClassTech
    {
        public string name { get; set; }
        public string TrueName { get; set; }
        public int era { get; set; }
        public string texture { get; set; }
        public string Desc { get; set; }
        public string category { get; set; }
        public bool canResearch { get; set; }
        public List<string> modifiers { get; set; }
        public List<string> restrictions { get; set; }

        public ClassTech() { }

        public ClassTech(ClassTech tech) {
            this.name = tech.name;
            this.TrueName = tech.TrueName;
            this.era = tech.era;
            this.texture = tech.texture;
            this.Desc = tech.Desc;
            this.category = tech.category;
            this.canResearch = tech.canResearch;
            modifiers = new List<string>();
            foreach(string modifier in tech.modifiers)
            {
                modifiers.Add(modifier);
            }

            restrictions = new List<string>();
            foreach (string restriction in tech.restrictions)
            {
                restrictions.Add(restriction);
            }
        }

        public ClassTech(string name, string TrueName, int era, string texture, string desc, string category, bool canResearch)
        {
            this.name = name;
            this.TrueName = TrueName;
            this.era = era;
            this.texture = texture;
            this.Desc = desc;
            this.category = category;
            this.canResearch = canResearch;
            modifiers = new List<string>();
            restrictions = new List<string>();
        }
        public ClassTech(KeyValuePair<string, object> ParserData)
        {
            modifiers = new List<string>();
            restrictions = new List<string>();

            this.canResearch = true;
            this.name = ParserData.Key;
            this.Desc = "None";
            this.TrueName = "None";

            foreach (KeyValuePair<string, object> element in (List<KeyValuePair<string, object>>)ParserData.Value)
            {

                switch (element.Key)
                {
                    case "era":
                        this.era = Int32.Parse(element.Value.ToString().Substring(4)); continue;
                    case "texture":
                        this.texture = element.Value.ToString().Trim('"'); continue;
                    case "category":
                        this.category = element.Value.ToString(); continue;
                    case "can_research":
                        if (element.Value.ToString() == "no") { this.canResearch = false; } else { this.canResearch = true; }continue;
                    case "modifier":
                        foreach (KeyValuePair<string, object> modifiersEntry in (List<KeyValuePair<string, object>>)element.Value)
                        {
                            this.modifiers.Add(modifiersEntry.Key + " = " + modifiersEntry.Value);
                        }
                        continue;
                    case "unlocking_technologies":
                        foreach (KeyValuePair<string, object> neededTech in (List<KeyValuePair<string, object>>)element.Value)
                        {
                            this.restrictions.Add(neededTech.Value.ToString());
                        }
                        continue;
                    default:
                        continue;

                }

            }

        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Has name in TechClass list
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        public bool hasName(List<ClassTech> techl, string name)
        {
            foreach (ClassTech techEntry in techl)
            {
                if (techEntry.name == name)
                {
                    return true;
                }
            }

            return false;
        }

        public int hasNameIndex(List<ClassTech> techl, string name)
        {
            int i = 0;
            foreach (ClassTech techEntry in techl)
            {
                if (techEntry.name == name){ return i; }
                i++;
            }

            return -1;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Merge TechClass list
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        public List<ClassTech> MergeTech(List<ClassTech> Pri, List<ClassTech> Sec)
        {
            List<ClassTech> result = new List<ClassTech>();

            foreach (ClassTech techEntry in Pri)
            {
                result.Add(new ClassTech(techEntry));
            }

            foreach (ClassTech techEntry in Sec)
            {
                if (!new ClassTech().hasName(result, techEntry.name))
                {
                    result.Add(new ClassTech(techEntry));
                }
            }

            return result;
        }
    }

}