using ScintillaNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace Victoria_3_Modding_Tool
{
    public class CSharpLexer
    {
        public const int StyleDefault = 0;
        public const int StyleIdentifier = 1;
        public const int StyleNumber = 2;
        public const int StyleString = 3;
        public const int StyleComment = 4;
        public const int StyleEqual = 5;
        public const int StyleBrace = 6;
        public const int StyleAffirmativeKeyword = 7;
        public const int StyleLogicKeyword = 8;
        public const int StyleSetDelete = 9;
        public const int StyleCommands = 10;
        public const int StyleKeywords = 11;

        private const int STATE_UNKNOWN = 0;
        private const int STATE_IDENTIFIER = 1;
        private const int STATE_NUMBER = 2;
        private const int STATE_STRING = 3;
        private const int STATE_COMMENT = 4;

        private HashSet<string> affirmativeKeyword;
        private HashSet<string> logicKeywords;
        private HashSet<string> setdeleteKeywords;
        private HashSet<string> commandsKeywords;
        private HashSet<string> keywords;

        public void Style(Scintilla scintilla, int startPos, int endPos)
        {
            // Back up to the line start
            var line = scintilla.LineFromPosition(startPos);
            startPos = scintilla.Lines[line].Position;

            var length = 0;
            var state = STATE_UNKNOWN;

            // Start styling
            scintilla.StartStyling(startPos);
            while (startPos < endPos)
            {
                var c = (char)scintilla.GetCharAt(startPos);

            REPROCESS:
                switch (state)
                {
                    case STATE_UNKNOWN:
                        if (c == '"')
                        {
                            // Start of "string"
                            scintilla.SetStyling(1, StyleString);
                            state = STATE_STRING;
                        }
                        else if (c == '#')
                        {
                            // Start of # comment
                            state = STATE_COMMENT;
                            goto REPROCESS;

                        }
                        else if (c == '=' || c == ':' || c == '<' || c == '>') 
                        {
                            scintilla.SetStyling(1, StyleEqual);
                        }
                        else if (c == '{' || c == '}')
                        {
                            scintilla.SetStyling(1, StyleBrace);
                        }
                        else if (Char.IsDigit(c))
                        {
                            state = STATE_NUMBER;
                            goto REPROCESS;
                        }
                        else if (Char.IsLetter(c))
                        {
                            state = STATE_IDENTIFIER;
                            goto REPROCESS;
                        }
                        else
                        {
                            // Everything else
                            scintilla.SetStyling(1, StyleDefault);
                        }
                        break;

                    case STATE_STRING:
                        if (c == '"')
                        {
                            length++;
                            scintilla.SetStyling(length, StyleString);
                            length = 0;
                            state = STATE_UNKNOWN;
                        }
                        else
                        {
                            length++;
                        }
                        break;

                    case STATE_NUMBER:
                        if (Char.IsDigit(c) || (c >= 'a' && c <= 'f') || (c >= 'A' && c <= 'F') || c == 'x')
                        {
                            length++;
                        }
                        else
                        {
                            scintilla.SetStyling(length, StyleNumber);
                            length = 0;
                            state = STATE_UNKNOWN;
                            goto REPROCESS;
                        }
                        break;

                    case STATE_IDENTIFIER:
                        if (Char.IsLetterOrDigit(c) || c == '_')
                        {
                            length++;
                        }
                        else
                        {
                            var style = StyleIdentifier;
                            var identifier = scintilla.GetTextRange(startPos - length, length);
                            if (affirmativeKeyword.Contains(identifier))
                                style = StyleAffirmativeKeyword;
                            if (logicKeywords.Contains(identifier))
                                style = StyleLogicKeyword;
                            if (setdeleteKeywords.Contains(identifier))
                                style = StyleSetDelete;
                            if (commandsKeywords.Contains(identifier))
                                style = StyleCommands;
                            if (keywords.Contains(identifier))
                                style = StyleKeywords;
                            scintilla.SetStyling(length, style);
                            length = 0;
                            state = STATE_UNKNOWN;
                            goto REPROCESS;
                        }
                        break;

                    case STATE_COMMENT:
                        if (c != '\n' && c != '\r')
                        {
                            length++;
                        }
                        else
                        {
                            scintilla.SetStyling(length, StyleComment);
                            length = 0;
                            state = STATE_UNKNOWN;
                            goto REPROCESS;
                        }
                        break;
                }

                startPos++;
            }
        }

        public CSharpLexer(string affirmativeKeyword, string logicKeywords, string setdeleteKeywords, string commandsKeywords, string keywords)
        {
            // Put keywords in a HashSet
            var list = Regex.Split(affirmativeKeyword ?? string.Empty, @"\s+").Where(l => !string.IsNullOrEmpty(l));
            this.affirmativeKeyword = new HashSet<string>(list);

            list = Regex.Split(logicKeywords ?? string.Empty, @"\s+").Where(l => !string.IsNullOrEmpty(l));
            this.logicKeywords = new HashSet<string>(list);

            list = Regex.Split(setdeleteKeywords ?? string.Empty, @"\s+").Where(l => !string.IsNullOrEmpty(l));
            this.setdeleteKeywords = new HashSet<string>(list);

            list = Regex.Split(commandsKeywords ?? string.Empty, @"\s+").Where(l => !string.IsNullOrEmpty(l));
            this.commandsKeywords = new HashSet<string>(list);

            list = Regex.Split(keywords ?? string.Empty, @"\s+").Where(l => !string.IsNullOrEmpty(l));
            this.keywords = new HashSet<string>(list);
        }

        public static bool IsBrace(int c)
        {
            switch (c)
            {
                case '(':
                case ')':
                case '[':
                case ']':
                case '{':
                case '}':
                    return true;
            }

            return false;
        }




    }

    internal class HotKeyManager
    {

        public static bool Enable = true;

        public static void AddHotKey(Form form, Action function, Keys key, bool ctrl = false, bool shift = false, bool alt = false)
        {
            form.KeyPreview = true;

            form.KeyDown += delegate (object sender, KeyEventArgs e) {
                if (IsHotkey(e, key, ctrl, shift, alt))
                {
                    function();
                }
            };
        }

        public static bool IsHotkey(KeyEventArgs eventData, Keys key, bool ctrl = false, bool shift = false, bool alt = false)
        {
            return eventData.KeyCode == key && eventData.Control == ctrl && eventData.Shift == shift && eventData.Alt == alt;
        }


    }

    internal class SearchManager
    {

        public static ScintillaNET.Scintilla TextArea;
        public static CustomTextBox FindBox;
        public static CustomTextBox ReplaceBox;

        public static string LastSearch = "";
        public static string LastReplace = "";

        public static int LastSearchIndex;

        public static void Find(bool next, bool incremental)
        {
            int pos;

            LastSearch = FindBox.Texts;
            if (LastSearch.Length > 0)
            {

                if (next)
                {

                    // SEARCH FOR THE NEXT OCCURANCE

                    // Search the document at the last search index
                    TextArea.TargetStart = LastSearchIndex - 1;
                    TextArea.TargetEnd = LastSearchIndex + (LastSearch.Length + 1);
                    TextArea.SearchFlags = SearchFlags.None;

                    // Search, and if not found..
                    if (!incremental || TextArea.SearchInTarget(LastSearch) == -1)
                    {

                        // Search the document from the caret onwards
                        TextArea.TargetStart = TextArea.CurrentPosition;
                        TextArea.TargetEnd = TextArea.TextLength;
                        TextArea.SearchFlags = SearchFlags.None;

                        // Search, and if not found..
                        if (TextArea.SearchInTarget(LastSearch) == -1)
                        {

                            // Search again from top
                            TextArea.TargetStart = 0;
                            TextArea.TargetEnd = TextArea.TextLength;

                            // Search, and if not found..
                            if (TextArea.SearchInTarget(LastSearch) == -1)
                            {

                                // clear selection and exit
                                TextArea.ClearSelections();
                                return;
                            }
                        }

                    }

                }
                else
                {
                    TextArea.SearchFlags = SearchFlags.None;
                    TextArea.TargetStart = Math.Min(TextArea.CurrentPosition, TextArea.AnchorPosition);
                    TextArea.TargetEnd = 0;

                    pos = TextArea.SearchInTarget(LastSearch);
                    if (pos >= 0)
                        TextArea.SetSel(TextArea.TargetStart, TextArea.TargetEnd);

                    // Search, and if not found..
                    if (TextArea.SearchInTarget(LastSearch) == -1)
                    {

                        // Search again from the caret onwards
                        TextArea.SearchFlags = SearchFlags.None;
                        TextArea.TargetStart = TextArea.TextLength;
                        TextArea.TargetEnd = Math.Min(TextArea.CurrentPosition, TextArea.AnchorPosition);

                        pos = TextArea.SearchInTarget(LastSearch);
                        if (pos >= 0)
                            TextArea.SetSel(TextArea.TargetStart, TextArea.TargetEnd);

                        // Search, and if not found..
                        if (TextArea.SearchInTarget(LastSearch) == -1)
                        {

                            // clear selection and exit
                            TextArea.ClearSelections();
                            return;
                        }
                    }
                }

                // Select the occurance
                LastSearchIndex = TextArea.TargetStart;
                TextArea.SetSelection(TextArea.TargetEnd, TextArea.TargetStart);
                TextArea.ScrollCaret();

            }

            FindBox.Focus();
        }

        public static void ReplaceAll(bool replace)
        {
            LastReplace = ReplaceBox.Texts;
            if (replace)
            {
                if (TextArea.SearchFlags == SearchFlags.None)
                {
                    TextArea.Text = TextArea.Text.Replace(FindBox.Texts, ReplaceBox.Texts);
                }
                else
                {
                    TextArea.TargetStart = 0;
                    TextArea.TargetEnd = TextArea.TextLength;
                    do
                    {
                        TextArea.ReplaceTarget(ReplaceBox.Texts);
                        TextArea.TargetStart = TextArea.TargetEnd;
                        TextArea.TargetEnd = TextArea.TextLength;

                    } while (TextArea.SearchInTarget(FindBox.Texts) == -1);

                }
            }
            

        }

        public static void Replace(bool replace)
        {
            LastReplace = ReplaceBox.Texts;
            if (replace)
            {
                if (TextArea.SearchInTarget(FindBox.Texts) != -1)
                {
                    TextArea.TargetStart = Math.Min(TextArea.CurrentPosition, TextArea.AnchorPosition);
                    TextArea.TargetEnd = Math.Max(TextArea.CurrentPosition, TextArea.AnchorPosition) + LastSearch.Length;
                    if (TextArea.SearchInTarget(FindBox.Texts) != -1)
                    {
                        TextArea.ReplaceTarget(ReplaceBox.Texts);
                    }
                }
            }
            
            
        }

    }


}