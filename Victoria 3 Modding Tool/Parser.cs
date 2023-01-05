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

    public class LocalizationParser
    {
        public Dictionary<string, string> Dic;

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
            void NextLine() { ln = sr.ReadLine(); }
            NextLine();
            NextLine();

            while (ln != null)
            {
                if ((m = Regex.Match(ln, "[\\u0000-\\u007E]+:\\d\\s\"[\u0000-\u0021\u0023-\u007E]*\"(?:[\u0000-\u0021\u0023-\u007E]*\"[\u0000-\u0021\u0023-\u007E]*\")*")).Success)
                {
                    ln = m.Value;
                    words = ln.Split(':');
                    if (!words[0].Contains("#"))
                    {
                        Dic.Add(words[0].Trim(' '), words[1].Substring(3, words[1].Length - 4));
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
            foreach (string entry in Directory.GetFiles(startingPath, "*.yml"))
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

    public class Parser : IParser
    {
        public List<string> Tokens { get; set; }
        public int Index { get; set; }
        public int Status { get; set; }


        /*
        0 -> procura key
        1 -> procura operador (=)
        2 -> procure value
        */

        public List<object> ParseFiles(string directoryPath)
        {
            Tokens = new List<string>();

            string[] paths = Directory.GetFiles(directoryPath, "*.txt");

            List<object> rawResults = new List<object>();

            foreach (string filePath in paths)
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    rawResults.Add(ParseObject(sr));
                    Tokens.Clear();
                }
            }

            return rawResults;
        }

        public object ParseObject(StreamReader sr)
        {
            string ln;
            string[] words;
            void NextLine() { ln = sr.ReadLine(); }
            NextLine();

            while (ln != null)
            {
                ln = StripComments(ln.Replace("\t", ""));

                words = ln.Split(' ', (char)System.StringSplitOptions.RemoveEmptyEntries);

                foreach (string entry in words)
                {
                    if (!string.IsNullOrEmpty(entry.Trim(' ')))
                    {
                        Tokens.Add(entry);
                    }
                }

                NextLine();

            }

            Index = 0;
            return ParseTokens();
        }

        public object ParseTokens()
        {
            List<KeyValuePair<string, object>> parsedObject = new List<KeyValuePair<string, object>>();
            string temp = string.Empty;
            string token;
            int counter = 0;
            void NextToken() { token = Tokens[Index]; Index++; }

            while (Index < Tokens.Count)
            {
                NextToken();
                switch (token)
                {
                    case "{":
                        Status = 0;
                        parsedObject.Add(new KeyValuePair<string, object>(temp, ParseTokens()));

                        continue;
                    case "}":
                        if (Status == 1)
                        {
                            parsedObject.Add(new KeyValuePair<string, object>(counter.ToString(), temp));
                        }
                        Status = 0;
                        return parsedObject;
                    case "{}":
                        Status = 0;
                        return parsedObject;
                    case "=":
                        Status = 2;
                        continue;
                    default:

                        if (Status == 0)
                        {
                            temp = token;
                            Status = 1;
                            continue;
                        }

                        if (Status == 1)
                        {
                            parsedObject.Add(new KeyValuePair<string, object>(counter.ToString(), temp));
                            counter++;
                            temp = token;
                            continue;
                        }

                        if (Status == 2)
                        {
                            parsedObject.Add(new KeyValuePair<string, object>(temp,token));
                            Status = 0;
                            continue;
                        }

                        break;
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
}