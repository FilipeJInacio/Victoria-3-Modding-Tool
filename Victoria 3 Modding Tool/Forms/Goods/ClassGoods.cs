using System;
using System.Collections.Generic;
using System.Globalization;

namespace Victoria_3_Modding_Tool.Forms.Tech
{
    public class ClassGoods
    {
        public string name { get; set; }
        public string TrueName { get; set; }
        public string texture { get; set; }
        public int cost { get; set; }
        public string category { get; set; }
        public bool tradeable { get; set; }
        public bool fixed_price { get; set; }
        public int consumption { get; set; }
        public float obsession { get; set; }
        public float prestige { get; set; }
        public int tradedQuantity { get; set; }
        public float convoy_cost { get; set; }

        public ClassGoods() { }

        public ClassGoods(ClassGoods good)
        {
            this.name= good.name;
            this.TrueName= good.TrueName;
            this.texture = good.texture;
            this.cost = good.cost;
            this.category = good.category;
            this.tradeable = good.tradeable;
            this.fixed_price= good.fixed_price;
            this.consumption = good.consumption;
            this.obsession = good.obsession;
            this.prestige= good.prestige;
            this.tradedQuantity= good.tradedQuantity;
            this.convoy_cost = good.convoy_cost;
        }

        public ClassGoods(string name, string TrueName, string texture, int cost, string category, bool tradeablee, bool fixed_price, int consumption, float obsession, float prestige, int tradedQuantity, float convoy_cost)
        {
            this.name = name;
            this.TrueName = TrueName;
            this.texture = texture;
            this.cost= cost;
            this.category = category;
            this.tradeable = tradeablee;
            this.fixed_price = fixed_price;
            this.consumption = consumption;
            this.obsession = obsession;
            this.prestige = prestige;
            this.tradedQuantity = tradedQuantity;
            this.convoy_cost = convoy_cost;

        }

        public ClassGoods(KeyValuePair<string, object> ParserData)
        {

            this.tradeable = true;
            this.fixed_price = false;
            this.name = ParserData.Key;
            this.TrueName = "None";
            this.obsession = -1;
            this.prestige = -1;
            this.tradedQuantity = 1;
            this.convoy_cost = 1;
            this.consumption = -1;

            foreach (KeyValuePair<string, object> element in (List<KeyValuePair<string, object>>)ParserData.Value)
            {

                switch (element.Key)
                {
                    case "texture":
                        this.texture = element.Value.ToString().Trim('"'); continue;
                    case "cost":
                        this.cost = Int32.Parse(element.Value.ToString()); continue;
                    case "category":
                        this.category = element.Value.ToString(); continue;
                    case "tradeable":
                        if (element.Value.ToString() == "no") { this.tradeable = false; continue; } else { this.tradeable = true; }
                        continue;
                    case "fixed_price":
                        if (element.Value.ToString() == "yes") { this.fixed_price = true; continue; } else { this.fixed_price = false; }
                        continue;
                    case "obsession_chance":
                        this.obsession = float.Parse(element.Value.ToString(), CultureInfo.InvariantCulture.NumberFormat); continue;
                    case "prestige_factor":
                        this.prestige = float.Parse(element.Value.ToString(), CultureInfo.InvariantCulture.NumberFormat); continue;
                    case "traded_quantity":
                        this.tradedQuantity = Int32.Parse(element.Value.ToString()); continue;
                    case "convoy_cost_multiplier":
                        this.convoy_cost = float.Parse(element.Value.ToString(), CultureInfo.InvariantCulture.NumberFormat); continue;
                    case "consumption_tax_cost":
                        this.consumption = Int32.Parse(element.Value.ToString()); continue;
                    default:
                        continue;

                }

            }

            if (this.tradeable==false) { this.tradedQuantity = -1; this.convoy_cost = -1; }


        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Has name in TechClass list
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        public bool hasName(List<ClassGoods> techl, string name)
        {
            foreach (ClassGoods goodsEntry in techl)
            {
                if (goodsEntry.name == name)
                {
                    return true;
                }
            }

            return false;
        }

        public int hasNameIndex(List<ClassGoods> techl, string name)
        {
            int i=0;
            foreach (ClassGoods goodsEntry in techl)
            {
                if (goodsEntry.name == name)
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

        public List<ClassGoods> MergeGoods(List<ClassGoods> Pri, List<ClassGoods> Sec)
        {
            List<ClassGoods> result = new List<ClassGoods>();

            foreach (ClassGoods goodsEntry in Pri)
            {
                result.Add(goodsEntry);
            }

            foreach (ClassGoods goodsEntry in Sec)
            {
                if (!new ClassGoods().hasName(result, goodsEntry.name))
                {
                    result.Add(goodsEntry);
                }
            }

            return result;
        }


    }

}