using System;
using System.Collections.Generic;

namespace Victoria_3_Modding_Tool.Forms.Tech
{
    public class ClassReligions
    {
        public string name { get; set; }
        public string Truename { get; set; }
        public string texture { get; set; }
        public List<string> traits { get; set; }
        public int red { get; set; }
        public int green { get; set; }
        public int blue { get; set; }
        public List<string> taboos { get; set; }

        public ClassReligions() { }

        public ClassReligions(KeyValuePair<string, object> ParserData)
        {
            this.name = ParserData.Key;
            this.Truename = "None";
            traits = new List<string>();
            taboos = new List<string>();


            foreach (KeyValuePair<string, object> entry in (List<KeyValuePair<string, object>>)ParserData.Value)
            {
                switch (entry.Key)
                {
                    case "texture":
                        this.texture = entry.Value.ToString().Trim('"'); continue;
                    case "red":
                        this.red = (int)Math.Round(float.Parse(entry.Value.ToString().Replace(".",",")) * 255);
                        continue;
                    case "green":
                        this.green = (int)Math.Round(float.Parse(entry.Value.ToString().Replace(".", ",")) * 255);
                        continue;
                    case "blue":
                        this.blue = (int)Math.Round(float.Parse(entry.Value.ToString().Replace(".", ",")) * 255);
                        continue;
                    case "traits":
                        foreach (KeyValuePair<string, object> traits in (List<KeyValuePair<string, object>>)entry.Value)
                        {
                            this.traits.Add(traits.Value.ToString());
                        }
                        continue;
                    case "taboos":
                        foreach (string s in (string[])entry.Value)
                        {
                            this.taboos.Add(s);
                        }     
                        continue;
                    

                    default:
                        continue;
                }
            }
        }

        public ClassReligions(ClassReligions religion)
        {
            this.name = religion.name;
            this.texture = religion.texture;
            this.red= religion.red;
            this.green = religion.green;
            this.blue = religion.blue;
            this.Truename = religion.Truename;
            traits = new List<string>();
            foreach (string entry in religion.traits)
            {
                traits.Add(entry);
            }
            taboos = new List<string>();
            foreach (string entry in religion.taboos)
            {
                taboos.Add(entry);
            }
        }

        public ClassReligions(string name,string truename, string texture, int red, int green , int blue)
        {
            this.name = name;
            this.Truename = truename;
            this.traits = new List<string>();
            this.texture = texture;
            this.red = red;
            this.green = green;
            this.blue = blue;
            this.taboos= new List<string>();

        }
       

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Has name in list
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        public bool hasName(List<ClassReligions> religion, string name)
        {
            foreach (ClassReligions entry in religion)
            {
                if (entry.name == name)
                {
                    return true;
                }
            }

            return false;
        }

        public int hasNameIndex(List<ClassReligions> religion, string name)
        {
            int i = 0;
            foreach (ClassReligions entry in religion)
            {
                if (entry.name == name)
                {
                    return i;
                }
                i++;
            }

            return -1;
        }


        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Merge TechClass list
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        public List<ClassReligions> Merge(List<ClassReligions> Pri, List<ClassReligions> Sec)
        {
            List<ClassReligions> result = new List<ClassReligions>();

            foreach (ClassReligions Entry in Pri)
            {
                result.Add(Entry);
            }

            foreach (ClassReligions Entry in Sec)
            {
                if (!new ClassReligions().hasName(result, Entry.name))
                {
                    result.Add(Entry);
                }
            }

            return result;
        }


    }

}