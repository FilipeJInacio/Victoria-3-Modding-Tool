using System;
using System.Collections.Generic;
using System.Globalization;

namespace Victoria_3_Modding_Tool.Forms.Tech
{
    public class ClassGoods : IType, ITexture
    {
        public string Name { get; set; }
        public string TrueName { get; set; }
        public string Texture { get; set; }
        public int Cost { get; set; }
        public string Category { get; set; }
        public bool Tradeable { get; set; }
        public bool Fixed_price { get; set; }
        public int Consumption { get; set; }
        public float Obsession { get; set; }
        public float Prestige { get; set; }
        public int TradedQuantity { get; set; }
        public float Convoy_cost { get; set; }

        public ClassGoods() { }

        public ClassGoods(ClassGoods good)
        {
            this.Name= good.Name;
            this.TrueName= good.TrueName;
            this.Texture = good.Texture;
            this.Cost = good.Cost;
            this.Category = good.Category;
            this.Tradeable = good.Tradeable;
            this.Fixed_price= good.Fixed_price;
            this.Consumption = good.Consumption;
            this.Obsession = good.Obsession;
            this.Prestige= good.Prestige;
            this.TradedQuantity= good.TradedQuantity;
            this.Convoy_cost = good.Convoy_cost;
        }

        public ClassGoods(string name, string TrueName, string texture, int cost, string category, bool tradeablee, bool fixed_price, int consumption, float obsession, float prestige, int tradedQuantity, float convoy_cost)
        {
            this.Name = name;
            this.TrueName = TrueName;
            this.Texture = texture;
            this.Cost= cost;
            this.Category = category;
            this.Tradeable = tradeablee;
            this.Fixed_price = fixed_price;
            this.Consumption = consumption;
            this.Obsession = obsession;
            this.Prestige = prestige;
            this.TradedQuantity = tradedQuantity;
            this.Convoy_cost = convoy_cost;

        }

        public ClassGoods(KeyValuePair<string, object> ParserData, string TrueName)
        {

            this.Tradeable = true;
            this.Fixed_price = false;
            this.Name = ParserData.Key;
            this.TrueName = TrueName;
            this.Obsession = -1;
            this.Prestige = -1;
            this.TradedQuantity = 1;
            this.Convoy_cost = 1;
            this.Consumption = -1;

            foreach (KeyValuePair<string, object> element in (List<KeyValuePair<string, object>>)ParserData.Value)
            {

                switch (element.Key)
                {
                    case "texture":
                        this.Texture = element.Value.ToString().Trim('"'); continue;
                    case "cost":
                        this.Cost = Int32.Parse(element.Value.ToString()); continue;
                    case "category":
                        this.Category = element.Value.ToString(); continue;
                    case "tradeable":
                        if (element.Value.ToString() == "no") { this.Tradeable = false; continue; } else { this.Tradeable = true; }
                        continue;
                    case "fixed_price":
                        if (element.Value.ToString() == "yes") { this.Fixed_price = true; continue; } else { this.Fixed_price = false; }
                        continue;
                    case "obsession_chance":
                        this.Obsession = float.Parse(element.Value.ToString(), CultureInfo.InvariantCulture.NumberFormat); continue;
                    case "prestige_factor":
                        this.Prestige = float.Parse(element.Value.ToString(), CultureInfo.InvariantCulture.NumberFormat); continue;
                    case "traded_quantity":
                        this.TradedQuantity = Int32.Parse(element.Value.ToString()); continue;
                    case "convoy_cost_multiplier":
                        this.Convoy_cost = float.Parse(element.Value.ToString(), CultureInfo.InvariantCulture.NumberFormat); continue;
                    case "consumption_tax_cost":
                        this.Consumption = Int32.Parse(element.Value.ToString()); continue;
                    default:
                        continue;

                }

            }

            if (this.Tradeable==false) { this.TradedQuantity = -1; this.Convoy_cost = -1; }


        }

    }

}