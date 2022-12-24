using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web;

namespace Victoria_3_Modding_Tool.Forms.Tech
{
    public class ClassModifiers
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

        public ClassModifiers() { }

        public ClassModifiers(KeyValuePair<string, object> ParserData)
        {
            this.name = ParserData.Key;
            this.good = -1;
            this.percent = -1;
            this.num_decimals = -1;
            this.invert = -1;
            this.neutral = -1;
            this.boolean = -1;
            this.ai_value = -1;


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
                        if (entry.Value.ToString() == "yes") { this.num_decimals = 1; } else { this.num_decimals = 0; }
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
                    case "ai_value":
                        this.ai_value = Int32.Parse(entry.Value.ToString());
                        continue;

                    default:
                        continue;
                }
            }
        }

        public ClassModifiers(ClassModifiers modifierstypes)
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

        public ClassModifiers(string name, int good, int percent, int num_decimals, int invert, int neutral, int boolean, string postfix, string translate, int ai_value)
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

        public bool hasModifier(List<ClassModifiers> modifierType, string name)
        {
            foreach (ClassModifiers entry in modifierType)
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
        public bool hasName(List<ClassPopNeeds> popNeeds, string name)
        {
            foreach (ClassPopNeeds entry in popNeeds)
            {
                if (entry.name == name)
                {
                    return true;
                }
            }

            return false;
        }

        public int hasNameIndex(List<ClassPopNeeds> popNeeds, string name)
        {
            int i = 0;
            foreach (ClassPopNeeds entry in popNeeds)
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

        public List<ClassPopNeeds> Merge(List<ClassPopNeeds> Pri, List<ClassPopNeeds> Sec)
        {
            List<ClassPopNeeds> result = new List<ClassPopNeeds>();

            foreach (ClassPopNeeds Entry in Pri)
            {
                result.Add(Entry);
            }

            foreach (ClassPopNeeds Entry in Sec)
            {
                if (!new ClassPopNeeds().hasName(result, Entry.name))
                {
                    result.Add(Entry);
                }
            }

            return result;
        }


    }

}