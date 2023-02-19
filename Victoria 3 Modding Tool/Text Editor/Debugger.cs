using ScintillaNET;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Victoria_3_Modding_Tool
{
    
    public class intString
    {
        public int intValue { get; set; }

        // x = 1234:
        // 1 -> can be 0 or 1 meaning necessary (0) and 1 extra but expected 
        // 2 -> state
        // 3/4 -> type

        // 1 -> 0101
        // 2 -> 0102
        // 3 -> 0103
        // 4 -> 0104
        // 5 -> 0105
        // 7 -> 0107


        // 0 -> done -> value confirmed
        // 1 -> type: [a-zA-Z_0-9] = [a-zA-Z_]
        // 2 -> type: [a-zA-Z_] = { \d \d \d } (Color decimal)
        // 3 -> (Color rgb)
        // 4 -> ("...")
        // 5 -> type: [a-zA-Z_] = {
        // 6 -> type: }
        // 7 -> type: { [a-zA-Z_] }
        // 8 -> type: [a-zA-Z_]
        // 9 -> type 5 but specific name [a-zA-Z_0-9] = x ---- e.g. era_X
        // 10 -> type: [a-zA-Z_] = [yes|no]
        // 11 -> type: [a-zA-Z_] = [number]
        // 12 -> type: [a-zA-Z_] = { "[a-zA-Z_]" }
        // 13 -> type 7 and repets at least once
        // 14 -> type: [a-zA-Z_] = [a-zA-Z_0-9]
        // 15 -> type: modifier = [number] more than 1
        // 16 -> type: modifier = [number] 1   (not implemented)
        // 17 -> type: { [a-zA-Z_] } but { [a-zA-Z_] = [a-zA-Z_0-9] }
        // 18 -> type: [a-zA-Z_] = hsv{ \d \d \d } (Color decimal)
        // 19 -> type: { [a-zA-Z_] } or { or { }
        // 20 -> type: { "[a-zA-Z_]"... } or { or { }

        public string stringValue { get; set; }

        public intString()
        {
        }
        public intString(int i, string s)
        {
            intValue = i;
            stringValue = s;
        }
        public intString(intString i)
        {
            intValue = i.intValue;
            stringValue = i.stringValue;
        }
        static public bool cont9(intString[] a)
        {
            foreach(intString entry in a)
            {
                if (entry.intValue == 9)
                {
                    return true;
                }
            }
            return false;
        }
    }

    internal class Debugger
    {
        static public Scintilla scintilla;
        static public TextBox DebugTB;
        static public ToolStripMenuItem MonoElementDebug;
        static public void DebugTreatment(intString[] expected, List<ClassModifiersType> ModifierTypeData)
        {
            string line;
            int i = 0, j = 0;
            int state = 0;
            // 0 -> out of element
            // 1 -> in element
            // 2 -> inside parameter
            // ...

            bool significant;
            bool completed = false;
            bool contains9 = intString.cont9(expected);

            int[] braces = { 0, 0 };

            Match m;
            string match;

            intString[] mem = new intString[expected.Count()];
            foreach (intString entry in expected)
            {
                mem[j] = new intString(expected[j].intValue, expected[j].stringValue);
                j++;
            }

            while (i < scintilla.Text.Length)
            {
                line = Parser.StripComments(scintilla.Lines[scintilla.LineFromPosition(i)].Text.ToString().Replace("\t", "")).Replace("\r\n", "").Replace("\n", "").Trim(' ');
                if (!string.IsNullOrEmpty(line))
                {
                    switch (state)
                    {
                        case 0:
                            {

                                if (!completed)
                                {
                                    // Type 9
                                    if (!(m=Regex.Match(line, "^([a-zA-Z_0-9]+) = {$")).Success)
                                    {
                                        DebugTB.Text += "Expected '[a-zA-Z_0-9] = {' syntax: Line " + (scintilla.LineFromPosition(i) + 1) + "\r\n";
                                    }
                                    else
                                    {
                                        if (contains9)
                                        {
                                            significant = false;
                                            match = m.Groups[1].Value;
                                            foreach (intString entry in mem)
                                            {
                                                if (entry.intValue == 9)
                                                {
                                                    if (match.Length > entry.stringValue.Length)
                                                    {
                                                        if (match.Substring(0, entry.stringValue.Length) == entry.stringValue)
                                                        {
                                                            entry.intValue = 0;
                                                            significant = true;
                                                        }
                                                    }

                                                }
                                            }

                                            if (significant == false)
                                            {
                                                DebugTB.Text += "Invalid element name: Line " + (scintilla.LineFromPosition(i) + 1) + "\r\n";
                                            }
                                        }

                                        state++;
                                        braces[0]++;
                                    }
                                }
                                else
                                {
                                    DebugTB.Text += "Expected only one element: Line " + (scintilla.LineFromPosition(i) + 1) + "\r\n";
                                }


                                break;
                            }

                        case 1:
                            {
                                // Type 10  [a-z_A-Z] = [yes|no]
                                if ((m=Regex.Match(line, "^([a-zA-Z_0-9]+) = (yes|no)$")).Success)
                                {
                                    significant = false;
                                    match = m.Groups[1].Value;
                                    foreach (intString entry in mem)
                                    {
                                        if (entry.intValue == 0110 || entry.intValue == 1110)
                                        {
                                            if (match == entry.stringValue)
                                            {
                                                entry.intValue = 0;
                                                significant = true;
                                            }
                                        }
                                    }

                                    if (significant == false)
                                    {
                                        DebugTB.Text += "Unexpected Information: Line " + (scintilla.LineFromPosition(i) + 1) + "\r\n";
                                    }

                                }
                                // Type 11  [a-z_A-Z] = [number] and type 15
                                else if ((m = Regex.Match(line, "^([a-zA-Z_0-9]+) = ([-])?([0-9])+([.][0-9]{1,3})?$")).Success)
                                {
                                    significant = false;
                                    match = m.Groups[1].Value;
                                    foreach (intString entry in mem)
                                    {
                                        if (entry.intValue == 0111 || entry.intValue == 1111)
                                        {
                                            if (match == entry.stringValue)
                                            {
                                                entry.intValue = 0;
                                                significant = true;
                                            }
                                        }
                                        if (entry.intValue == 0115 || entry.intValue == 1115)
                                        {
                                            foreach (ClassModifiersType entry2 in ModifierTypeData)
                                            {
                                                if (match == entry2.Name)
                                                {
                                                    entry.intValue = 1115;
                                                    significant = true;
                                                }
                                            }
                                        }
                                    }

                                    if (significant == false)
                                    {
                                        DebugTB.Text += "Unexpected Information: Line " + (scintilla.LineFromPosition(i) + 1) + "\r\n";
                                    }

                                }
                                // Type 1
                                else if ((m = Regex.Match(line, "^([a-zA-Z_0-9]+) = [a-zA-Z_]+$")).Success)
                                {
                                    significant = false;
                                    match = m.Groups[1].Value;
                                    foreach (intString entry in mem)
                                    {
                                        if (entry.intValue == 0101 || entry.intValue == 1101)
                                        {
                                            if (match == entry.stringValue)
                                            {
                                                entry.intValue = 0;
                                                significant = true;
                                            }
                                        }
                                    }

                                    if (significant == false)
                                    {
                                        DebugTB.Text += "Unexpected Information: Line " + (scintilla.LineFromPosition(i) + 1) + "\r\n";
                                    }
                                }

                                // Type 2 (Color decimal)
                                else if ((m = Regex.Match(line, "^([a-zA-Z_0-9]+) = { [0-1]\\.?[0-9]{0,3} [0-1]\\.?[0-9]{0,3} [0-1]\\.?[0-9]{0,3} }$")).Success)
                                {
                                    significant = false;
                                    match = m.Groups[1].Value;
                                    foreach (intString entry in mem)
                                    {
                                        if (entry.intValue == 0102 || entry.intValue == 1102)
                                        {
                                            if (match == entry.stringValue)
                                            {
                                                entry.intValue = 0;
                                                significant = true;
                                            }
                                        }
                                    }

                                    if (significant == false)
                                    {
                                        DebugTB.Text += "Unexpected Information: Line " + (scintilla.LineFromPosition(i) + 1) + "\r\n";
                                    }
                                }
                                // Type 18
                                else if ((m = Regex.Match(line, "^([a-zA-Z_0-9]+) = hsv{ [0-1]\\.?[0-9]{0,3} [0-1]\\.?[0-9]{0,3} [0-1]\\.?[0-9]{0,3} }$")).Success)
                                {
                                    significant = false;
                                    match = m.Groups[1].Value;
                                    foreach (intString entry in mem)
                                    {
                                        if (entry.intValue == 0118 || entry.intValue == 1118)
                                        {
                                            if (match == entry.stringValue)
                                            {
                                                entry.intValue = 0;
                                                significant = true;
                                            }
                                        }
                                    }

                                    if (significant == false)
                                    {
                                        DebugTB.Text += "Unexpected Information: Line " + (scintilla.LineFromPosition(i) + 1) + "\r\n";
                                    }
                                }

                                // Type 3 (Color rgb)
                                else if ((m = Regex.Match(line, "^([a-zA-Z_0-9]+) = { [0-9]{0,3} [0-9]{0,3} [0-9]{0,3} }$")).Success)
                                {
                                    significant = false;
                                    match = m.Groups[1].Value;
                                    foreach (intString entry in mem)
                                    {
                                        if (entry.intValue == 0103 || entry.intValue == 1103)
                                        {
                                            if (match == entry.stringValue)
                                            {
                                                entry.intValue = 0;
                                                significant = true;
                                            }
                                        }
                                    }

                                    if (significant == false)
                                    {
                                        DebugTB.Text += "Unexpected Information: Line " + (scintilla.LineFromPosition(i) + 1) + "\r\n";
                                    }
                                }

                                // Type 4 ("...")
                                else if ((m = Regex.Match(line, "^([a-zA-Z_0-9]+) = \"(.*)\"$")).Success)
                                {
                                    significant = false;
                                    match = m.Groups[1].Value;
                                    foreach (intString entry in mem)
                                    {
                                        if (entry.intValue == 0104 || entry.intValue == 1104)
                                        {
                                            if (match == entry.stringValue)
                                            {
                                                entry.intValue = 0;
                                                significant = true;
                                            }
                                        }
                                    }

                                    if (significant == false)
                                    {
                                        DebugTB.Text += "Unexpected Information: Line " + (scintilla.LineFromPosition(i) + 1) + "\r\n";
                                    }
                                }

                                // Type 5 { and type 13
                                else if ((m = Regex.Match(line, "^([a-zA-Z_0-9:]+) = {$")).Success)
                                {
                                    significant = false;
                                    match = m.Groups[1].Value;
                                    foreach (intString entry in mem)
                                    {
                                        if (entry.intValue == 0105 || entry.intValue == 1105)
                                        {
                                            if (match == entry.stringValue)
                                            {
                                                entry.intValue = 0;
                                                significant = true;
                                            }
                                        }
                                        else if (entry.intValue == 0113 || entry.intValue == 1113)
                                        {
                                            if (match == entry.stringValue)
                                            {
                                                entry.intValue = 1113;
                                                significant = true;
                                            }
                                        }
                                        else if (entry.intValue == 0119 || entry.intValue == 1119)
                                        {
                                            if (match == entry.stringValue)
                                            {
                                                entry.intValue = 0;
                                                significant = true;
                                            }
                                        }
                                        else if (entry.intValue == 0120 || entry.intValue == 1120)
                                        {
                                            if (match == entry.stringValue)
                                            {
                                                entry.intValue = 0;
                                                significant = true;
                                            }
                                        }
                                    }
                                    state++;

                                    if (significant == false)
                                    {
                                        DebugTB.Text += "Unexpected Information: Line " + (scintilla.LineFromPosition(i) + 1) + "\r\n";
                                    }

                                    braces[0]++;
                                }

                                // Type 6 }
                                else if (Regex.Match(line, "^}$").Success)
                                {
                                    braces[1]++;
                                    state--;
                                }

                                // Type 12 { "[a-z_A-Z]" }
                                else if ((m = Regex.Match(line, "^([a-zA-Z_0-9]+) = { (\"[a-zA-Z_0-9]+\" )*}$")).Success)
                                {
                                    significant = false;
                                    match = m.Groups[1].Value;
                                    foreach (intString entry in mem)
                                    {
                                        if (entry.intValue == 0112 || entry.intValue == 1112)
                                        {
                                            if (match == entry.stringValue)
                                            {
                                                entry.intValue = 0;
                                                significant = true;
                                            }
                                        }
                                        if (entry.intValue == 0120 || entry.intValue == 1120)
                                        {
                                            if (match == entry.stringValue)
                                            {
                                                entry.intValue = 0;
                                                significant = true;
                                            }
                                        }
                                    }

                                    if (significant == false)
                                    {
                                        DebugTB.Text += "Unexpected Information: Line " + (scintilla.LineFromPosition(i) + 1) + "\r\n";
                                    }

                                    braces[0]++;
                                    braces[1]++;
                                }
                                // Type 7 { [a-z_A-Z] ...}
                                else if ((m = Regex.Match(line, "^([a-zA-Z_0-9]+) = { ([a-zA-Z_0-9]+ )*}$")).Success)
                                {
                                    significant = false;
                                    match = m.Groups[1].Value;
                                    foreach (intString entry in mem)
                                    {
                                        if (entry.intValue == 0107 || entry.intValue == 1107)
                                        {
                                            if (match == entry.stringValue)
                                            {
                                                entry.intValue = 0;
                                                significant = true;
                                            }
                                        }
                                        else if (entry.intValue == 0119 || entry.intValue == 1119)
                                        {
                                            if (match == entry.stringValue)
                                            {
                                                entry.intValue = 0;
                                                significant = true;
                                            }
                                        }
                                    }

                                    if (significant == false)
                                    {
                                        DebugTB.Text += "Unexpected Information: Line " + (scintilla.LineFromPosition(i) + 1) + "\r\n";
                                    }

                                    braces[0]++;
                                    braces[1]++;
                                }
                                // Type 17
                                else if ((m = Regex.Match(line, "^([a-zA-Z_]+) = { [a-zA-Z_]+ = [a-zA-Z_0-9]+ }$")).Success)
                                {
                                    significant = false;
                                    match = m.Groups[1].Value;
                                    foreach (intString entry in mem)
                                    {
                                        if (entry.intValue == 0117 || entry.intValue == 1117)
                                        {
                                            if (match == entry.stringValue)
                                            {
                                                entry.intValue = 0;
                                                significant = true;
                                            }
                                        }
                                    }

                                    if (significant == false)
                                    {
                                        DebugTB.Text += "Unexpected Information: Line " + (scintilla.LineFromPosition(i) + 1) + "\r\n";
                                    }

                                    braces[0]++;
                                    braces[1]++;
                                }
                                // Type 14
                                else if ((m = Regex.Match(line, "^([a-zA-Z_0-9]+) = [a-zA-Z_0-9]+$")).Success)
                                {
                                    significant = false;
                                    match = m.Groups[1].Value;
                                    foreach (intString entry in mem)
                                    {
                                        if (entry.intValue == 0114 || entry.intValue == 1114)
                                        {
                                            if (match == entry.stringValue)
                                            {
                                                entry.intValue = 0;
                                                significant = true;
                                            }
                                        }
                                    }

                                    if (significant == false)
                                    {
                                        DebugTB.Text += "Unexpected Information: Line " + (scintilla.LineFromPosition(i) + 1) + "\r\n";
                                    }
                                }


                                else
                                {
                                    DebugTB.Text += "Unknown line: Line " + (scintilla.LineFromPosition(i) + 1) + "\r\n";
                                }

                                break;
                            }

                        case 2:
                            {
                                // Type 11  [a-z_A-Z] = [number] and type 15
                                if ((m = Regex.Match(line, "^([a-zA-Z_0-9]+) = ([-])?([0-9])+([.][0-9]{1,3})?$")).Success)
                                {
                                }
                                // Type 1
                                else if (Regex.Match(line, "^[a-zA-Z_0-9]+ = [a-zA-Z_]+$").Success)
                                {

                                }
                                // Type 8
                                else if (Regex.Match(line, "^[a-zA-Z_]+$").Success)
                                {

                                }
                                // Type 6 }
                                else if (Regex.Match(line, "^}$").Success)
                                {
                                    braces[1]++;
                                    state--;
                                }
                                // type 5: [a-zA-Z_] = { 
                                else if (Regex.Match(line, "^[a-zA-Z_:]+ = {$").Success)
                                {
                                    state++;
                                    braces[0]++;
                                }

                                break;
                            }

                        case 3:
                            {
                                // Type 11  [a-z_A-Z] = [number] and type 15
                                if ((m = Regex.Match(line, "^([a-zA-Z_0-9]+) = ([-])?([0-9])+([.][0-9]{1,3})?$")).Success)
                                {
                                }
                                // Type 1
                                else if (Regex.Match(line, "^[a-zA-Z_0-9]+ = [a-zA-Z_]+$").Success)
                                {

                                }
                                // Type 8
                                else if (Regex.Match(line, "^[a-zA-Z_]+$").Success)
                                {

                                }
                                // Type 6 }
                                else if (Regex.Match(line, "^}$").Success)
                                {
                                    braces[1]++;
                                    state--;
                                }
                                // type 5: [a-zA-Z_] = { 
                                else if (Regex.Match(line, "^[a-zA-Z_:]+ = {$").Success)
                                {
                                    state++;
                                    braces[0]++;
                                }

                                break;
                            }

                        case 4:
                            {
                                // Type 11  [a-z_A-Z] = [number] and type 15
                                if ((m = Regex.Match(line, "^([a-zA-Z_0-9]+) = ([-])?([0-9])+([.][0-9]{1,3})?$")).Success)
                                {
                                }
                                // Type 1
                                else if (Regex.Match(line, "^[a-zA-Z_0-9]+ = [a-zA-Z_]+$").Success)
                                {

                                }
                                // Type 8
                                else if (Regex.Match(line, "^[a-zA-Z_]+$").Success)
                                {

                                }
                                // Type 6 }
                                else if (Regex.Match(line, "^}$").Success)
                                {
                                    braces[1]++;
                                    state--;
                                }
                                // type 5: [a-zA-Z_] = { 
                                else if (Regex.Match(line, "^[a-zA-Z_:]+ = {$").Success)
                                {
                                    state++;
                                    braces[0]++;
                                }

                                break;
                            }

                        case 5:
                            {
                                // Type 11  [a-z_A-Z] = [number] and type 15
                                if ((m = Regex.Match(line, "^([a-zA-Z_0-9]+) = ([-])?([0-9])+([.][0-9]{1,3})?$")).Success)
                                {
                                }
                                // Type 1
                                else if (Regex.Match(line, "^[a-zA-Z_0-9]+ = [a-zA-Z_]+$").Success)
                                {

                                }
                                // Type 8
                                else if (Regex.Match(line, "^[a-zA-Z_]+$").Success)
                                {

                                }
                                // Type 6 }
                                else if (Regex.Match(line, "^}$").Success)
                                {
                                    braces[1]++;
                                    state--;
                                }
                                // type 5: [a-zA-Z_] = { 
                                else if (Regex.Match(line, "^[a-zA-Z_:]+ = {$").Success)
                                {
                                    state++;
                                    braces[0]++;
                                }

                                break;
                            }

                        case 6:
                            {
                                // Type 11  [a-z_A-Z] = [number] and type 15
                                if ((m = Regex.Match(line, "^([a-zA-Z_0-9]+) = ([-])?([0-9])+([.][0-9]{1,3})?$")).Success)
                                {
                                }
                                // Type 1
                                else if (Regex.Match(line, "^[a-zA-Z_0-9]+ = [a-zA-Z_]+$").Success)
                                {

                                }
                                // Type 8
                                else if (Regex.Match(line, "^[a-zA-Z_]+$").Success)
                                {

                                }
                                // Type 6 }
                                else if (Regex.Match(line, "^}$").Success)
                                {
                                    braces[1]++;
                                    state--;
                                }
                                // type 5: [a-zA-Z_] = { 
                                else if (Regex.Match(line, "^[a-zA-Z_:]+ = {$").Success)
                                {
                                    state++;
                                    braces[0]++;
                                }

                                break;
                            }


                    }

                    if (state == 0 && !completed)
                    {
                        // Completed an element?
                        significant = false;
                        foreach (intString entry in mem)
                        {
                            if (entry.intValue != 0 && entry.intValue < 1000)
                            {
                                significant = true;
                            }
                        }

                        // if no then
                        if (significant == true)
                        {
                            int a = scintilla.LineFromPosition(i) + 1;
                            DebugTB.Text += "The primary parameters of an element ended with errors: Line " + a + "\r\n";
                        }
                        else // if yes then
                        {
                            j = 0;
                            foreach (intString entry in expected)
                            {
                                mem[j] = new intString(expected[j].intValue, expected[j].stringValue);
                                j++;
                            }
                        }

                        if (MonoElementDebug.Checked)
                        {
                            completed = true;
                        }


                    }
                }


                i += scintilla.Lines[scintilla.LineFromPosition(i)].Length;
            }

            if (DebugTB.Text.Length > 2)
            {
                if (DebugTB.Text[DebugTB.Text.Length - 1] == '\n')
                {
                    DebugTB.Text = DebugTB.Text.Remove(DebugTB.Text.Length - 1).Remove(DebugTB.Text.Length - 2);
                }
            }
            

        }




    }
}
