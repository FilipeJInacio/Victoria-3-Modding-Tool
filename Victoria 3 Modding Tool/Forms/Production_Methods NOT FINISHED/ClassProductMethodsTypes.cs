using System.Collections.Generic;

namespace Victoria_3_Modding_Tool.Forms.Tech
{
    public class ClassProductMethods
    {
        public string name { get; set; }
        public string texture { get; set; }
        public List<KeyValuePair<string, int>> building_input_add { get; set; }
        public List<KeyValuePair<string, int>> building_output_add { get; set; }
        public List<KeyValuePair<string, int>> building_employment_add { get; set; }

        public ClassProductMethods()
        { }

        public ClassProductMethods(ClassProductMethodsTypes ProductMethodsTypes)
        {
        }

        public ClassProductMethods(string name, string texture, bool ai_selection)
        {
        }

        public ClassProductMethods(KeyValuePair<string, object> ParserData)
        {
        }
    }

    public class ClassProductMethodsTypes
    {
        public string name { get; set; }
        public string texture { get; set; }
        public bool ai_selection { get; set; } // DEFAULT -> not most productive -> false
        public List<string> production_methods { get; set; }

        public ClassProductMethodsTypes()
        { }

        public ClassProductMethodsTypes(ClassProductMethodsTypes ProductMethodsTypes)
        {
            this.name = ProductMethodsTypes.name;
            this.texture = ProductMethodsTypes.texture;
            this.ai_selection = ProductMethodsTypes.ai_selection;
            production_methods = new List<string>();
            foreach (string entry in ProductMethodsTypes.production_methods)
            {
                production_methods.Add(entry);
            }
        }

        public ClassProductMethodsTypes(string name, string texture, bool ai_selection)
        {
            this.name = name;
            this.texture = texture;
            this.ai_selection = ai_selection;
            production_methods = new List<string>();
        }

        public ClassProductMethodsTypes(KeyValuePair<string, object> ParserData)
        {
            this.ai_selection = false;
            production_methods = new List<string>();

            foreach (KeyValuePair<string, object> element in (List<KeyValuePair<string, object>>)ParserData.Value)
            {
                switch (element.Key)
                {
                    case "texture":
                        this.texture = element.Value.ToString().Trim('"'); continue;
                    case "ai_selection":
                        if (element.Value.ToString() == "most_productive") { this.ai_selection = true; continue; }
                        continue;
                    case "production_methods":
                        foreach (KeyValuePair<string, object> entry in (List<KeyValuePair<string, object>>)element.Value)
                        {
                            this.production_methods.Add(entry.Value.ToString());
                        }
                        continue;
                    default:
                        continue;
                }
            }
        }

        // Not DONE

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Has name in TechClass list
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        public bool hasName(List<ClassGoods> techl, string name)
        {
            foreach (ClassGoods goodsEntry in techl)
            {
                if (goodsEntry.Name == name)
                {
                    return true;
                }
            }

            return false;
        }

        public int hasNameIndex(List<ClassGoods> techl, string name)
        {
            int i = 0;
            foreach (ClassGoods goodsEntry in techl)
            {
                if (goodsEntry.Name == name)
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
                if (!new Functions().hasName(result, goodsEntry.Name))
                {
                    result.Add(goodsEntry);
                }
            }

            return result;
        }
    }
}