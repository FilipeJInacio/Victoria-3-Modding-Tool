using System;
using System.Collections.Generic;

namespace Victoria_3_Modding_Tool.Forms.Era
{
    public class ClassEra : IType
    {
        string IType.Name
        {
            get { return Era.ToString(); }
        }

        public int Era { get; set; }
        public int Cost { get; set; }

        public ClassEra() { }
        public ClassEra(int era, int cost)
        {
            this.Era = era;
            this.Cost = cost;
        }

        public ClassEra(KeyValuePair<string, object> ParserData)
        {
            foreach (KeyValuePair<string, object> element in (List<KeyValuePair<string, object>>)ParserData.Value)
            {
                this.Era = Int32.Parse(ParserData.Key.ToString().Substring(4));
                this.Cost = Convert.ToInt32(element.Value);
            }
        }



    }
}
