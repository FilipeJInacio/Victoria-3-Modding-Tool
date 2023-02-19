using System.Collections.Generic;

namespace Victoria_3_Modding_Tool
{
    public class ClassInstitutions : IType, ITexture, IBackTexture
    {
        public string Name { get; set; }
        public string TrueName { get; set; }
        public string Texture { get; set; }
        public string BackTexture { get; set; }
        public List<string> Modifiers { get; set; } // Depends on the party -> empty

        public ClassInstitutions()
        { }

        public ClassInstitutions(KeyValuePair<string, object> ParserData, string TrueName)
        {
            this.Name = ParserData.Key;
            this.TrueName = TrueName;
            this.Modifiers = new List<string>();

            foreach (KeyValuePair<string, object> entry in (List<KeyValuePair<string, object>>)ParserData.Value)
            {
                switch (entry.Key)
                {
                    case "icon":
                        this.Texture = entry.Value.ToString().Trim('"'); continue;
                    case "background_texture":
                        this.BackTexture = entry.Value.ToString().Trim('"'); continue;
                    case "modifier":
                        foreach (KeyValuePair<string, object> modifiersEntry in (List<KeyValuePair<string, object>>)entry.Value)
                        {
                            this.Modifiers.Add(modifiersEntry.Key + " = " + modifiersEntry.Value);
                        }
                        continue;
                    default:
                        continue;
                }
            }
        }

        public ClassInstitutions(ClassInstitutions n)
        {
            this.Name = n.Name;
            this.TrueName = n.TrueName;
            this.BackTexture = n.BackTexture;
            this.Texture = n.Texture;
            this.Modifiers = new List<string>();
            foreach (string entry in n.Modifiers)
            {
                Modifiers.Add(entry);
            }
        }

        public ClassInstitutions(string name, string trueName, string back_ground, string icon)
        {
            this.Name = name;
            this.TrueName = trueName;
            this.BackTexture = back_ground;
            this.Texture = icon;
            this.Modifiers = new List<string>();
        }
    }
}