using System;
using System.Collections.Generic;

namespace Victoria_3_Modding_Tool.Forms.Tech
{
    public class ClassModifiersType
    {
        public string name { get; set; }
        public int good { get; set; }
        public int percent { get; set; }
        public int num_decimals { get; set; }
        public int invert { get; set; }
        public int neutral { get; set; }
        public int boolean { get; set; }
        public string postfix { get; set; }
        public string translate { get; set; }
        public int ai_value { get; set; }

        public ClassModifiersType() { }

        public ClassModifiersType(KeyValuePair<string, object> ParserData)
        {
            this.name = ParserData.Key;
            this.good = -1;
            this.percent = -1;
            this.num_decimals = -1;
            this.invert = -1;
            this.neutral = -1;
            this.boolean = -1;
            this.ai_value = -1;
            this.translate = null;
            this.postfix = null;

            foreach (KeyValuePair<string, object> entry in (List<KeyValuePair<string, object>>)ParserData.Value)
            {
                switch (entry.Key)
                {
                    case "good":
                        if (entry.Value.ToString() == "yes") { this.good = 1; } else { this.good = 0; }
                        continue;
                    case "percent":
                        if (entry.Value.ToString() == "yes") { this.percent = 1; } else { this.percent = 0; }
                        continue;
                    case "num_decimals":
                        this.num_decimals = Int32.Parse(entry.Value.ToString());
                        continue;
                    case "invert":
                        if (entry.Value.ToString() == "yes") { this.invert = 1; } else { this.invert = 0; }
                        continue;
                    case "neutral":
                        if (entry.Value.ToString() == "yes") { this.neutral = 1; } else { this.neutral = 0; }
                        continue;
                    case "boolean":
                        if (entry.Value.ToString() == "yes") { this.boolean = 1; } else { this.boolean = 0; }
                        continue;
                    case "postfix":
                        this.postfix = entry.Value.ToString().Trim('"'); continue;
                    case "translate":
                        this.translate = entry.Value.ToString(); continue;
                    case "ai_value":
                        this.ai_value = Int32.Parse(entry.Value.ToString());
                        continue;

                    default:
                        continue;
                }
            }
        }

        public ClassModifiersType(ClassModifiersType modifierstypes)
        {
            this.name = modifierstypes.name;
            this.good = modifierstypes.good;
            this.percent = modifierstypes.percent;
            this.num_decimals = modifierstypes.num_decimals;
            this.invert = modifierstypes.invert;
            this.neutral = modifierstypes.neutral;
            this.boolean = modifierstypes.boolean;
            this.postfix = modifierstypes.postfix;
            this.translate = modifierstypes.translate;
            this.ai_value = modifierstypes.ai_value;
        }

        public ClassModifiersType(string name, int good, int percent, int num_decimals, int invert, int neutral, int boolean, string postfix, string translate, int ai_value)
        {
            this.name = name;
            this.good = good;
            this.percent = percent;
            this.num_decimals = num_decimals;
            this.invert = invert;
            this.neutral = neutral;
            this.boolean = boolean;
            this.postfix = postfix;
            this.translate = translate;
            this.ai_value = ai_value;
        }

        public bool hasModifier(List<ClassModifiersType> modifierType, string name)
        {
            foreach (ClassModifiersType entry in modifierType)
            {
                if (entry.name == name)
                {
                    return true;
                }
            }

            return false;
        }

       

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Has name in list
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        public bool hasName(List<ClassModifiersType> modifier, string name)
        {
            foreach (ClassModifiersType entry in modifier)
            {
                if (entry.name == name)
                {
                    return true;
                }
            }

            return false;
        }

        public int hasNameIndex(List<ClassModifiersType> modifier, string name)
        {
            int i = 0;
            foreach (ClassModifiersType entry in modifier)
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

        public List<ClassModifiersType> Merge(List<ClassModifiersType> Pri, List<ClassModifiersType> Sec)
        {
            List<ClassModifiersType> result = new List<ClassModifiersType>();

            foreach (ClassModifiersType Entry in Pri)
            {
                result.Add(Entry);
            }

            foreach (ClassModifiersType Entry in Sec)
            {
                if (!new ClassModifiersType().hasName(result, Entry.name))
                {
                    result.Add(Entry);
                }
            }

            return result;
        }


    }

}