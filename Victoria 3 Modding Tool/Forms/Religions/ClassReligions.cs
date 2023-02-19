using System;
using System.Collections.Generic;

namespace Victoria_3_Modding_Tool
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

        public ClassReligions()
        { }

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
                    case "color":
                        foreach (KeyValuePair<string, object> entry2 in (List<KeyValuePair<string, object>>)entry.Value)
                        {
                            switch (entry2.Key)
                            {
                                case "0":
                                    this.Red = (int)Math.Round(float.Parse(entry2.Value.ToString().Replace(".", ",")) * 255);
                                    continue;
                                case "1":
                                    this.Green = (int)Math.Round(float.Parse(entry2.Value.ToString().Replace(".", ",")) * 255);
                                    continue;
                                case "2":
                                    this.Blue = (int)Math.Round(float.Parse(entry2.Value.ToString().Replace(".", ",")) * 255);
                                    continue;
                            }
                        }
                        continue;
                    case "traits":
                        foreach (KeyValuePair<string, object> traits in (List<KeyValuePair<string, object>>)entry.Value)
                        {
                            this.Traits.Add(traits.Value.ToString());
                        }
                        continue;
                    case "taboos":
                        foreach (KeyValuePair<string, object> entry2 in (List<KeyValuePair<string, object>>)entry.Value)
                        {
                            this.Taboos.Add(entry2.Value.ToString());
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
            this.Red = religion.Red;
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

        public ClassReligions(string name, string truename, string texture, int red, int green, int blue)
        {
            this.Name = name;
            this.Truename = truename;
            this.Traits = new List<string>();
            this.Texture = texture;
            this.Red = red;
            this.Green = green;
            this.Blue = blue;
            this.Taboos = new List<string>();
        }
    }
}