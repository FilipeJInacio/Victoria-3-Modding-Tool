using System.Collections.Generic;
using System.Globalization;
using System.Web;

namespace Victoria_3_Modding_Tool.Forms.Tech
{
    public class ClassPopNeedsEntry
    {
        public string goods { get; set; }
        public float weight { get; set; }
        public float minWeight { get; set; }
        public float maxWeight { get; set; }

        public ClassPopNeedsEntry()
        { }

        public ClassPopNeedsEntry(List<KeyValuePair<string, object>> element)
        {

            foreach (KeyValuePair<string, object> entry in element)
            {
                switch (entry.Key)
                {
                    case "goods":
                        this.goods = entry.Value.ToString().Trim('"'); continue;
                    case "weight":
                        this.weight = float.Parse(entry.Value.ToString(), CultureInfo.InvariantCulture.NumberFormat); continue;
                    case "max_weight":
                        this.maxWeight = float.Parse(entry.Value.ToString(), CultureInfo.InvariantCulture.NumberFormat); continue;
                    case "min_weight":
                        this.minWeight = float.Parse(entry.Value.ToString(), CultureInfo.InvariantCulture.NumberFormat); continue;
                    default:
                        continue;
                }
            }
        }

        public ClassPopNeedsEntry(ClassPopNeedsEntry popneedentry)
        {
            this.goods = popneedentry.goods;
            this.weight = popneedentry.weight;
            this.minWeight = popneedentry.minWeight;
            this.maxWeight = popneedentry.maxWeight;
        }

        public ClassPopNeedsEntry(string goods,float weight, float maxWeight, float minWeight)
        {
            this.goods = goods;
            this.weight = weight;
            this.minWeight = minWeight;
            this.maxWeight = maxWeight;
        }

        public bool hasGood(List<ClassPopNeedsEntry> popNeeds, string name)
        {
            foreach (ClassPopNeedsEntry entry in popNeeds)
            {
                if (entry.goods == name)
                {
                    return true;
                }
            }

            return false;
        }

 

    }

    public class ClassPopNeeds
    {
        public string name { get; set; }
        public string defaultgood { get; set; }
        public List<ClassPopNeedsEntry> entries { get; set; }


        public ClassPopNeeds() { }

        public ClassPopNeeds(ClassPopNeeds Popneed)
        {
            this.name= Popneed.name;
            this.defaultgood= Popneed.defaultgood;
            this.entries = new List<ClassPopNeedsEntry>();
            foreach (ClassPopNeedsEntry entry in Popneed.entries)
            {
                entries.Add(entry);
            }

        }

        public ClassPopNeeds(string name, string defaultgood)
        {
            this.name = name;
            this.defaultgood = defaultgood;
            this.entries = new List<ClassPopNeedsEntry>();
        }

        public ClassPopNeeds(KeyValuePair<string, object> ParserData)
        {

            this.name = ParserData.Key;
            this.entries = new List<ClassPopNeedsEntry>();

            foreach (KeyValuePair<string, object> element in (List<KeyValuePair<string, object>>)ParserData.Value)
            {

                switch (element.Key)
                {
                    case "default":
                        this.defaultgood = element.Value.ToString().Trim('"'); continue;
                    case "entry":
                        entries.Add(new ClassPopNeedsEntry((List<KeyValuePair<string, object>>)element.Value)); continue;
                    default:
                        continue;
                }
            }
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