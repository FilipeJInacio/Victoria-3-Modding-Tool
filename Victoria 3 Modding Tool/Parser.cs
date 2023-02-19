using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

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

        // Method 1 - File
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



        // Method 2 - Text
        public object ParseText(string text)
        {
            Tokens = new List<string>();
            return ParseObject(text);
        }

        public object ParseObject(string text)
        {
            string ln;
            string[] words;
            int i = 0;
            string[] textSplit = text.Split('\n');
            Match m;

            void NextLine()
            {
                if (i < textSplit.Count())
                { ln = textSplit[i]; i++; }
                else { ln = null; }
            }

            NextLine();

            while (ln != null)
            {
                ln = StripComments(ln.Replace("\t", ""));

                if ((m = Regex.Match(ln, "^([a-zA-Z_]+) = \"(.*)\"$")).Success)
                {
                    Tokens.Add(m.Groups[1].Value);
                    Tokens.Add("=");
                    Tokens.Add("\"" + m.Groups[2].Value + "\"");
                }
                else
                {
                    words = ln.Split(' ', (char)System.StringSplitOptions.RemoveEmptyEntries);

                    foreach (string entry in words)
                    {
                        if (!string.IsNullOrEmpty(entry.Trim(' ')))
                        {
                            Tokens.Add(entry);
                        }
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


        static public string StripComments(string line)
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

    public class NoParse : IParser
    {
        public int Status { get; set; }

        // Method 1 - File
        public List<object> ParseFiles(string directoryPath)
        {
            string[] paths = Directory.GetFiles(directoryPath, "*.txt");

            List<object> rawResults = new List<object>();

            foreach (string filePath in paths)
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    Status = 0;
                    rawResults.Add(ParseObject(sr));
                }
            }

            return rawResults;
        }

        public object ParseObject(StreamReader sr)
        {
            List<KeyValuePair<string, object>> parsedObject = new List<KeyValuePair<string, object>>();

            string ln;
            string temp = "";
            string name = "";
            int a, b;

            void NextLine() { ln = sr.ReadLine(); }
            NextLine();

            while (ln != null)
            {

                if (Status != 0)
                {
                    temp += ln + "\n";
                }

                ln = Parser.StripComments(ln.Replace("\t", ""));

                if (ln.Contains("{")) { a = ln.Count(c => c == '{'); } else { a = 0; }
                if (ln.Contains("}")) { b = ln.Count(c => c == '}'); } else { b = 0; }


                if (a == b)
                {

                }
                else if (a > b)
                {
                    if (Status == 0)
                    {
                        temp += ln + "\n";
                        name = ln.Split('=')[0].Trim('\t').Trim(' ');
                    }
                    Status += a - b;
                }
                else if (a < b)
                {
                    Status += a - b;
                    if (Status == 0)
                    {
                        parsedObject.Add(new KeyValuePair<string, object>(name, temp));
                        temp = "";
                    }
                }

                NextLine();

            }


            return parsedObject;
        }



        // Method 2 - Text
        public object ParseText(string text)
        {
            return ParseObject(text);
        }

        public object ParseObject(string text)
        {
            List<KeyValuePair<string, object>> parsedObject = new List<KeyValuePair<string, object>>();

            string ln;
            string temp = "";
            string name = "";
            int a, b;
            int i = 0;
            List<string> textSplit = new List<string>();

            if (text.Contains("\n")) {
                textSplit.AddRange(text.Split('\n'));
            }
            else
            {
                textSplit.Add(text);
            }


            void NextLine()
            {
                if (i < textSplit.Count())
                { ln = textSplit[i]; i++; }
                else { ln = null; }
            }

            NextLine();

            while (ln != null)
            {

                if (Status != 0)
                {
                    temp += ln + "\n";
                }

                ln = Parser.StripComments(ln.Replace("\t", ""));

                if (ln.Contains("{")) { a = ln.Count(c => c == '{'); } else { a = 0; }
                if (ln.Contains("}")) { b = ln.Count(c => c == '}'); } else { b = 0; }
               

                if (a == b)
                {

                }
                else if (a > b)
                {
                    if (Status == 0)
                    {
                        temp += ln + "\n";
                        name = ln.Split('=')[0].Trim('\t').Trim(' ');
                    }
                    Status += a - b;
                }
                else if (a < b)
                {
                    Status += a - b;
                    if (Status == 0)
                    {
                        parsedObject.Add(new KeyValuePair<string, object>(name, temp));
                        temp = "";
                    }
                }

                NextLine();

            }


            return parsedObject;
        }

    }

}