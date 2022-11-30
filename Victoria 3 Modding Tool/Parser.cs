﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Victoria_3_Modding_Tool
{
    public class Parser
    {
        public int count = 0;

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
                count = 0;
            }
            return rawResults;
        }

        public object ParseObject(StreamReader sr)
        {
            string ln;
            List<KeyValuePair<string, object>> parsedObject = new List<KeyValuePair<string, object>> ();
            int j = 0;
            void NextLine() { ln = sr.ReadLine(); count++; }
            NextLine();

            while (ln != null)
            {
                ln = StripComments(ln.Trim('\t').Replace(" ", ""));

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
}