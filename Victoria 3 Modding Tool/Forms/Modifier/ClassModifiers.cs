using System;
using System.Collections.Generic;

namespace Victoria_3_Modding_Tool.Forms.Tech
{
    public class ClassModifiers : IType, ITexture
    {
        public string Name { get; set; }
        public string TrueName { get; set; }
        public string Description { get; set; }
        public string Texture { get; set; }
        public List<string> Modifiers { get; set; }

        public ClassModifiers()
        { }

        public ClassModifiers(KeyValuePair<string, object> ParserData, string TrueName, string Desc)
        {
            this.Name = ParserData.Key;
            this.TrueName = TrueName;
            this.Description = Desc;
            this.Texture = string.Empty;
            this.Modifiers = new List<string>();

            foreach (KeyValuePair<string, object> entry in (List<KeyValuePair<string, object>>)ParserData.Value)
            {
                if (entry.Key == "icon")
                {
                    this.Texture = entry.Value.ToString();
                }
                else
                {
                    Modifiers.Add(entry.Key + " = " + entry.Value);
                }
            }
        }

        public ClassModifiers(ClassModifiers n)
        {
            this.Name = n.Name;
            this.TrueName = n.TrueName;
            this.Description = n.Description;
            this.Texture = n.Texture;
            this.Modifiers = new List<string>();
            foreach (string entry in n.Modifiers)
            {
                Modifiers.Add(entry);
            }
        }

        public ClassModifiers(string name, string trueName, string description, string icon)
        {
            this.Name = name;
            this.TrueName = trueName;
            this.Description = description;
            this.Texture = icon;
            this.Modifiers = new List<string>();
        }
    }

    public class ClassModifiersType : IType
    {
        public string Name { get; set; }
        public int Good { get; set; }
        public int Percent { get; set; }
        public int Num_decimals { get; set; }
        public int Invert { get; set; }
        public int Neutral { get; set; }
        public int Boolean { get; set; }
        public string Postfix { get; set; }
        public string Translate { get; set; }
        public int Ai_value { get; set; }

        public ClassModifiersType()
        { }

        public ClassModifiersType(KeyValuePair<string, object> ParserData)
        {
            this.Name = ParserData.Key;
            this.Good = -1;
            this.Percent = -1;
            this.Num_decimals = -1;
            this.Invert = -1;
            this.Neutral = -1;
            this.Boolean = -1;
            this.Ai_value = -1;
            this.Translate = null;
            this.Postfix = null;

            foreach (KeyValuePair<string, object> entry in (List<KeyValuePair<string, object>>)ParserData.Value)
            {
                switch (entry.Key)
                {
                    case "good":
                        if (entry.Value.ToString() == "yes") { this.Good = 1; } else { this.Good = 0; }
                        continue;
                    case "percent":
                        if (entry.Value.ToString() == "yes") { this.Percent = 1; } else { this.Percent = 0; }
                        continue;
                    case "num_decimals":
                        this.Num_decimals = Int32.Parse(entry.Value.ToString());
                        continue;
                    case "invert":
                        if (entry.Value.ToString() == "yes") { this.Invert = 1; } else { this.Invert = 0; }
                        continue;
                    case "neutral":
                        if (entry.Value.ToString() == "yes") { this.Neutral = 1; } else { this.Neutral = 0; }
                        continue;
                    case "boolean":
                        if (entry.Value.ToString() == "yes") { this.Boolean = 1; } else { this.Boolean = 0; }
                        continue;
                    case "postfix":
                        this.Postfix = entry.Value.ToString().Trim('"'); continue;
                    case "translate":
                        this.Translate = entry.Value.ToString(); continue;
                    case "ai_value":
                        this.Ai_value = Int32.Parse(entry.Value.ToString());
                        continue;

                    default:
                        continue;
                }
            }
        }

        public ClassModifiersType(ClassModifiersType modifierstypes)
        {
            this.Name = modifierstypes.Name;
            this.Good = modifierstypes.Good;
            this.Percent = modifierstypes.Percent;
            this.Num_decimals = modifierstypes.Num_decimals;
            this.Invert = modifierstypes.Invert;
            this.Neutral = modifierstypes.Neutral;
            this.Boolean = modifierstypes.Boolean;
            this.Postfix = modifierstypes.Postfix;
            this.Translate = modifierstypes.Translate;
            this.Ai_value = modifierstypes.Ai_value;
        }

        public ClassModifiersType(string name, int good, int percent, int num_decimals, int invert, int neutral, int boolean, string postfix, string translate, int ai_value)
        {
            this.Name = name;
            this.Good = good;
            this.Percent = percent;
            this.Num_decimals = num_decimals;
            this.Invert = invert;
            this.Neutral = neutral;
            this.Boolean = boolean;
            this.Postfix = postfix;
            this.Translate = translate;
            this.Ai_value = ai_value;
        }
    }
}