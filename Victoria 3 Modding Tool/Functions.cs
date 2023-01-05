using System;
using System.Collections.Generic;
using System.IO;
using Victoria_3_Modding_Tool.Forms.Tech;

namespace Victoria_3_Modding_Tool
{
    internal interface IType
    {
        string Name { get; }
    }

    internal interface ITexture
    {
        string Texture { get; set; }
    }

    internal interface IBackTexture
    {
        string BackTexture { get; set; }
    }

    internal class Functions
    {
        public bool hasName<T>(List<T> Data, string name) where T : IType
        {
            foreach (T entry in Data)
            {
                if (entry.Name == name)
                {
                    return true;
                }
            }

            return false;
        }

        public int hasNameIndex<T>(List<T> Data, string name) where T : IType
        {
            int i = 0;
            foreach (T entry in Data)
            {
                if (entry.Name == name)
                {
                    return i;
                }
                i++;
            }

            return -1;
        }

        public List<T> MergeClasses<T>(List<T> Pri, List<T> Sec) where T : IType
        {
            List<T> result = new List<T>();

            result.AddRange(Pri);

            foreach (T entry in Sec)
            {
                if (!new Functions().hasName(result, entry.Name))
                {
                    result.Add(entry);
                }
            }

            return result;
        }

        public void TextureMerger<T>(string path, List<T> Data) where T : ITexture
        {
            for (int i = 0; i < Data.Count; i++)
            {
                Data[i].Texture = path + Data[i].Texture.ToString().Replace("/", "\\");
            }
        }

        public void BackTextureMerger<T>(string path, List<T> Data) where T : IBackTexture
        {
            for (int i = 0; i < Data.Count; i++)
            {
                Data[i].BackTexture = path + Data[i].BackTexture.ToString().Replace("/", "\\");
            }
        }

        
    }

    internal class ExtraFunctions
    {
        public List<string> Temp;
        public List<string> Out;

        // Compare Modifier Types 
        public void Modifi(List<ClassModifiersType> Data)
        {
            string ln;
            Temp = new List<string>();
            Out = new List<string>();
            using (StreamReader sr = new StreamReader("C:\\Users\\fjina\\OneDrive\\Ambiente de Trabalho\\temp.txt"))
            {
                void NextLine() { ln = sr.ReadLine(); }
                NextLine();
                while (ln != null)
                {
                    Temp.Add(ln);
                    NextLine();
                }
            }

            foreach (string entry in Temp)
            {
                if (!new Functions().hasName(Data, entry))
                {
                    Out.Add(entry);
                }
            }

            using (StreamWriter sw = new StreamWriter(File.Open("C:\\Users\\fjina\\OneDrive\\Ambiente de Trabalho\\temp2.txt", FileMode.Create)))
            {
                foreach (string entry in Out)
                {
                    sw.WriteLine(entry);
                }

            }

            Out.Clear();
            Temp.Clear();

        }

    }
}