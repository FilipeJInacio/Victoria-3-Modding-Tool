using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

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
        static string language;

        static public void IniciateLanguage(string a)
        {
            language = a;
        }

        static public bool hasName<T>(List<T> Data, string name) where T : IType
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

        static public int hasNameIndex<T>(List<T> Data, string name) where T : IType
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

        static public List<T> MergeClasses<T>(List<T> Pri, List<T> Sec) where T : IType
        {
            List<T> result = new List<T>();

            result.AddRange(Pri);

            foreach (T entry in Sec)
            {
                if (!Functions.hasName(result, entry.Name))
                {
                    result.Add(entry);
                }
            }

            return result;
        }

        static public void TextureMerger<T>(string path, List<T> Data) where T : ITexture
        {
            for (int i = 0; i < Data.Count; i++)
            {
                if (Data[i].Texture != string.Empty)
                {
                    Data[i].Texture = path + Data[i].Texture.ToString().Replace("/", "\\");
                }

            }
        }

        static public void BackTextureMerger<T>(string path, List<T> Data) where T : IBackTexture
        {
            for (int i = 0; i < Data.Count; i++)
            {
                Data[i].BackTexture = path + Data[i].BackTexture.ToString().Replace("/", "\\");
            }
        }

        static public Dictionary<string, string> LocalizationSetup(string path)
        {
            if (Directory.Exists(path + "\\localization\\" + language))
            {
                return new LocalizationParser().ParseFiles(path + "\\localization\\" + language);
            }
            return null;
        }

        static public void ReadFilesCommon<T>(string path, List<T> Data, IParser Iparser, Func<KeyValuePair<string, object>, T> ClassCreator, Func<T, string> sortBy)
        {
            if (Directory.Exists(path))
            {
                foreach (List<KeyValuePair<string, object>> entry in Iparser.ParseFiles(path).Cast<List<KeyValuePair<string, object>>>()) // Files
                {
                    foreach (KeyValuePair<string, object> entry2 in entry)
                    {
                        Data.Add(ClassCreator(entry2));
                    }
                }

                Data.Sort(delegate (T t1, T t2)
                {   // 0.5 s Make more efi
                    return sortBy(t1).CompareTo(sortBy(t2));
                });
            }
            return;
        }

        static public void SearchBarSimpleConfig<T>(List<T> Data, CustomTextBox TB, CustomListBox LB) where T : IType
        {
            if (string.IsNullOrEmpty(TB.Texts) == false)
            {
                LB.Clear();
                foreach (T str in Data)
                {
                    if (str.Name.StartsWith(TB.Texts))
                    {
                        LB.Add(str.Name);
                    }
                }
            }
            else if (TB.Texts == "")
            {
                LB.Clear();
                foreach (T str in Data)
                {
                    LB.Add(str.Name);
                }
            }

        }

        static public int SizeOfName(string text)
        {
            char c;
            for (int i=0;i<text.Length;i++)
            {
                c = text[i];
                if (c=='='||c==' ')
                {
                    return i;
                }
            }
            return -1;
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
                if (!Functions.hasName(Data, entry))
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