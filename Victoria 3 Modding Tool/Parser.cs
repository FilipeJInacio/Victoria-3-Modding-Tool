using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Victoria_3_Modding_Tool
{
    public interface IParser
    {
         List<object> ParseFiles(string directoryPath);
    }

    public class Parser : IParser
    {
        public List<object> ParseFiles(string directoryPath)
        {
            string[] paths = Directory.GetFiles(directoryPath, "*.txt");

            List<object> rawResults = new List<object>();

            foreach (string filePath in paths)
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    rawResults.Add(ParseObject(sr));
                }
            }
            return rawResults;
        }

        public object ParseObject(StreamReader sr)
        {
            string ln;
            List<KeyValuePair<string, object>> parsedObject = new List<KeyValuePair<string, object>> ();
            int j = 0;
            void NextLine() { ln = sr.ReadLine();}
            NextLine();

            while (ln != null)
            {
                ln = StripComments(ln.Replace("\t",""));

                ln = ln.Replace(" ","");
                

                if (ln.Length == 0)
                {
                    NextLine();
                    continue;
                }

                if (ln.Contains("{") && ln.Contains("}"))
                {
                    NextLine();
                    continue;
                }
                else if (ln.Contains("{"))
                {
                    parsedObject.Add(new KeyValuePair<string, object>(ln.Split('=')[0], ParseObject(sr)));
                    NextLine();
                    continue;
                }
                else if (ln.Contains("}"))
                {
                    return parsedObject;
                }
                else if (ln.Contains("="))
                {
                    parsedObject.Add(new KeyValuePair<string, object>(ln.Split('=')[0], ln.Split('=')[1]));
                    NextLine();
                    continue;
                }
                else 
                {
                    j++;
                    parsedObject.Add(new KeyValuePair<string, object>(j.ToString(), ln));
                    NextLine();
                    continue;
                }

            }

            return parsedObject;
        }

        public string StripComments(string line)
        {
            int i;
            if ((i = line.IndexOf("#")) == -1)
            {
                return line;
            }
            else if (i == 0)
            {
                return "";
            }
            else { return line.Substring(0, i); }
        }



    }

    public class Parser2 : IParser
    {
        public List<object> ParseFiles(string directoryPath)
        {
            string[] paths = Directory.GetFiles(directoryPath, "*.txt");

            List<object> rawResults = new List<object>();

            foreach (string filePath in paths)
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    rawResults.Add(ParseObject(sr));
                }
            }
            return rawResults;
        }

        public object ParseObject(StreamReader sr)
        {
            string ln;
            string[] words;
            List<KeyValuePair<string, object>> parsedObject = new List<KeyValuePair<string, object>>();
            int j = 0;
            void NextLine() { ln = sr.ReadLine();}
            NextLine();

            while (ln != null)
            {
                ln = StripComments(ln.Replace("\t",""));

                words = ln.Split(' ');
                if (ln.Contains('{') && ln.Contains('}')) // only for color
                {
                    parsedObject.Add(new KeyValuePair<string, object>("red", words[3]));
                    parsedObject.Add(new KeyValuePair<string, object>("green", words[4]));
                    parsedObject.Add(new KeyValuePair<string, object>("blue", words[5]));
                    NextLine();
                    continue;
                } else if (words[0]== "taboos")
                {
                    NextLine();
                    ln = StripComments(ln.Trim('\t'));
                    words = ln.Split(' ');
                    parsedObject.Add(new KeyValuePair<string, object>("taboos", words));
                    NextLine();
                    NextLine();
                    continue;
                }
                else
                {
                    ln = ln.Replace(" ", "");
                }

                if (ln.Length == 0)
                {
                    NextLine();
                    continue;
                }



                if (ln.Contains("{"))
                {
                    parsedObject.Add(new KeyValuePair<string, object>(ln.Split('=')[0], ParseObject(sr)));
                    NextLine();
                    continue;
                }
                else if (ln.Contains("}"))
                {
                    return parsedObject;
                }
                else if (ln.Contains("="))
                {
                    parsedObject.Add(new KeyValuePair<string, object>(ln.Split('=')[0], ln.Split('=')[1]));
                    NextLine();
                    continue;
                }
                else
                {
                    j++;
                    parsedObject.Add(new KeyValuePair<string, object>(j.ToString(), ln));
                    NextLine();
                    continue;
                }

            }

            return parsedObject;
        }

        public string StripComments(string line)
        {
            int i;
            if ((i = line.IndexOf("#")) == -1)
            {
                return line;
            }
            else if (i == 0)
            {
                return "";
            }
            else { return line.Substring(0, i); }
        }



    }

    public class LocalizationParser
    {
        public Dictionary<string,string> Dic;


        public Dictionary<string, string> ParseFiles(string directoryPath)
        {
            Dic = new Dictionary<string, string>();

            List<string> paths = GetTextFiles(directoryPath);

            foreach (string filePath in paths)
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    ParseObject(sr);
                }
            }
            return Dic;
        }

        public void ParseObject(StreamReader sr)
        {
            string ln;
            string[] words;
            Match m;
            void NextLine() { ln = sr.ReadLine();}
            NextLine();
            NextLine();


            while (ln != null)
            {
                if ((m=Regex.Match(ln, "[\\u0000-\\u007E]+:\\d\\s\"[\u0000-\u0021\u0023-\u007E]*\"(?:[\u0000-\u0021\u0023-\u007E]*\"[\u0000-\u0021\u0023-\u007E]*\")*")).Success)
                {
                    ln = m.Value;
                    words = ln.Split(':');
                    if (!words[0].Contains("#")) {
                        Dic.Add(words[0].Trim(' '), words[1].Substring(3, words[1].Length-4));
                    }
                    NextLine();
                    continue;
                }
                else
                {
                    NextLine();
                    continue;
                }
            }

            return;
        }

        public List<string> GetTextFiles(string startingPath)
        {
            List<string> files = new List<string>();
            foreach(string entry in Directory.GetFiles(startingPath, "*.yml"))
            {
                files.Add(entry);
            }
            foreach (string entry in Directory.GetDirectories(startingPath, "*", SearchOption.TopDirectoryOnly))
            {
                files.AddRange(GetTextFiles(entry));
            }
            return files;

        }

    }
}
