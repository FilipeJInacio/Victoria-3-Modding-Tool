using System;
using System.Collections.Generic;

namespace Victoria_3_Modding_Tool.Forms.Tech
{
    public class ClassReligions : IType, ITexture
    {
        public string Name { get; set; }
        public string Truename { get; set; }
        public string Texture { get; set; }
        public List<string> Traits { get; set; }
        public int Red { get; set; }
        public int Green { get; set; }
        public int Blue { get; set; }
        public List<string> Taboos { get; set; }

        public ClassReligions() { }

        public ClassReligions(KeyValuePair<string, object> ParserData, string TrueName)
        {
            this.Name = ParserData.Key;
            this.Truename = TrueName;
            Traits = new List<string>();
            Taboos = new List<string>();


            foreach (KeyValuePair<string, object> entry in (List<KeyValuePair<string, object>>)ParserData.Value)
            {
                switch (entry.Key)
                {
                    case "texture":
                        this.Texture = entry.Value.ToString().Trim('"'); continue;
                    case "red":
                        this.Red = (int)Math.Round(float.Parse(entry.Value.ToString().Replace(".",",")) * 255);
                        continue;
                    case "green":
                        this.Green = (int)Math.Round(float.Parse(entry.Value.ToString().Replace(".", ",")) * 255);
                        continue;
                    case "blue":
                        this.Blue = (int)Math.Round(float.Parse(entry.Value.ToString().Replace(".", ",")) * 255);
                        continue;
                    case "traits":
                        foreach (KeyValuePair<string, object> traits in (List<KeyValuePair<string, object>>)entry.Value)
                        {
                            this.Traits.Add(traits.Value.ToString());
                        }
                        continue;
                    case "taboos":
                        foreach (string s in (string[])entry.Value)
                        {
                            this.Taboos.Add(s);
                        }     
                        continue;
                    

                    default:
                        continue;
                }
            }
        }

        public ClassReligions(ClassReligions religion)
        {
            this.Name = religion.Name;
            this.Texture = religion.Texture;
            this.Red= religion.Red;
            this.Green = religion.Green;
            this.Blue = religion.Blue;
            this.Truename = religion.Truename;
            Traits = new List<string>();
            foreach (string entry in religion.Traits)
            {
                Traits.Add(entry);
            }
            Taboos = new List<string>();
            foreach (string entry in religion.Taboos)
            {
                Taboos.Add(entry);
            }
        }

        public ClassReligions(string name,string truename, string texture, int red, int green , int blue)
        {
            this.Name = name;
            this.Truename = truename;
            this.Traits = new List<string>();
            this.Texture = texture;
            this.Red = red;
            this.Green = green;
            this.Blue = blue;
            this.Taboos= new List<string>();

        }
       

    }

}