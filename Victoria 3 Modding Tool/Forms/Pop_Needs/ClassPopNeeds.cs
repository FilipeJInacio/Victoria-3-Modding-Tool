using System.Collections.Generic;
using System.Globalization;
using System.Web;

namespace Victoria_3_Modding_Tool.Forms.Tech
{
    public class ClassPopNeedsEntry : IType
    {
        public string Name { get; set; }
        public float Weight { get; set; }
        public float MinWeight { get; set; }
        public float MaxWeight { get; set; }

        public ClassPopNeedsEntry(){ }

        public ClassPopNeedsEntry(List<KeyValuePair<string, object>> element)
        {

            foreach (KeyValuePair<string, object> entry in element)
            {
                switch (entry.Key)
                {
                    case "goods":
                        this.Name = entry.Value.ToString().Trim('"'); continue;
                    case "weight":
                        this.Weight = float.Parse(entry.Value.ToString(), CultureInfo.InvariantCulture.NumberFormat); continue;
                    case "max_weight":
                        this.MaxWeight = float.Parse(entry.Value.ToString(), CultureInfo.InvariantCulture.NumberFormat); continue;
                    case "min_weight":
                        this.MinWeight = float.Parse(entry.Value.ToString(), CultureInfo.InvariantCulture.NumberFormat); continue;
                    default:
                        continue;
                }
            }
        }

        public ClassPopNeedsEntry(ClassPopNeedsEntry popneedentry)
        {
            this.Name = popneedentry.Name;
            this.Weight = popneedentry.Weight;
            this.MinWeight = popneedentry.MinWeight;
            this.MaxWeight = popneedentry.MaxWeight;
        }

        public ClassPopNeedsEntry(string goods,float weight, float maxWeight, float minWeight)
        {
            this.Name = goods;
            this.Weight = weight;
            this.MinWeight = minWeight;
            this.MaxWeight = maxWeight;
        }


    }

    public class ClassPopNeeds : IType
    {
        public string Name { get; set; }

        public string TrueName { get; set; }
        public string Defaultgood { get; set; }
        public List<ClassPopNeedsEntry> Entries { get; set; }


        public ClassPopNeeds() { }

        public ClassPopNeeds(ClassPopNeeds Popneed)
        {
            this.Name= Popneed.Name;
            this.TrueName = Popneed.TrueName;
            this.Defaultgood= Popneed.Defaultgood;
            this.Entries = new List<ClassPopNeedsEntry>();
            foreach (ClassPopNeedsEntry entry in Popneed.Entries)
            {
                Entries.Add(entry);
            }

        }

        public ClassPopNeeds(string name, string Truename, string defaultgood)
        {
            this.Name = name;
            this.TrueName = Truename;
            this.Defaultgood = defaultgood;
            this.Entries = new List<ClassPopNeedsEntry>();
        }

        public ClassPopNeeds(KeyValuePair<string, object> ParserData, string Truename)
        {

            this.Name = ParserData.Key;
            this.TrueName = Truename;
            this.Entries = new List<ClassPopNeedsEntry>();

            foreach (KeyValuePair<string, object> element in (List<KeyValuePair<string, object>>)ParserData.Value)
            {

                switch (element.Key)
                {
                    case "default":
                        this.Defaultgood = element.Value.ToString().Trim('"'); continue;
                    case "entry":
                        Entries.Add(new ClassPopNeedsEntry((List<KeyValuePair<string, object>>)element.Value)); continue;
                    default:
                        continue;
                }
            }
        }


    }

}