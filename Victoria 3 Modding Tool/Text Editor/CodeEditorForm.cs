using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using ScintillaNET;
using AutocompleteMenuNS;
using System.Collections.Generic;
using System.Text;

namespace Victoria_3_Modding_Tool
{
    /*

    https://www.youtube.com/watch?v=v3UyE0x1Sbc


    add red color
    more than one txt
    left menu
    code folder not working
    keywords
    indentation algorithm
    autocomplete  - time - add - separation
    fix order of controls   (press (space) closes window error)
    */



    public partial class CodeEditorForm : Form
    {
        private Size formSize; //Keep form size when it is minimized and restored.Since the form is resized because it takes into account the size of the title bar and borders.

        public string text; // if null -> no text / text -> to put on screen
        public string save;
        public string currentMode;

        public bool projIsNULL = false;
        public string VickyPath = Properties.Settings.Default.Victoria3Path;
        public string ProjPath = Properties.Settings.Default.ProjPath;

        public bool stopIndenting = false;
        public bool GoodCode;

        public int SaveStatus; // 0 -> Just openned  / 1 -> Saved / 2 -> Not saved

        public Color[] ScintillaColor = {
            Color.FromArgb(31, 98, 169),    // Caret
            Color.FromArgb(31, 98, 169),    // Selection
            Color.FromArgb(40, 40, 40),     // Scintilla Backcolor
            Color.FromArgb(160, 160, 160),  // Default -> not ended word
            Color.White,                    // Base Font
            Color.FromArgb(194, 136, 248),  // Number
            Color.FromArgb(255, 128, 64),   // "String"
            Color.FromArgb(64, 161, 64),    // #Comment
            Color.FromArgb(235, 33, 91),    // = : < >
            Color.FromArgb(57, 104, 255),   // { }
            Color.Red,                      // { ... not closed
            Color.White,                    // { ... } highlight other fore
            Color.FromArgb(17, 61, 111),    // { ... } highlight other backcolor
            Color.FromArgb(220, 187, 75),   // yes no
            Color.FromArgb(33, 168, 148),   // AND ...
            Color.OrangeRed,                // set_variable...
            Color.White,                    // Commands
            Color.White                     // Custom Keywords
        };

        public Font ScintillaFont = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

        ToolStripMenuItem ResetFile = new System.Windows.Forms.ToolStripMenuItem();
        ToolStripMenuItem MonoElementDebug = new System.Windows.Forms.ToolStripMenuItem();
        ToolStripMenuItem WordWrapView = new System.Windows.Forms.ToolStripMenuItem();
        ToolStripMenuItem ShowIndentView = new System.Windows.Forms.ToolStripMenuItem();
        ToolStripMenuItem ShowWhiteSpaceView = new System.Windows.Forms.ToolStripMenuItem();

        public bool DebugOptionsMono; // true -> lock on mono
        public bool noErrors;

        public CodeEditorForm()
        {
            InitializeComponent();
            this.Padding = new Padding(2);//Border size
            this.SetStyle(
                        ControlStyles.AllPaintingInWmPaint |
                        ControlStyles.UserPaint |
                        ControlStyles.DoubleBuffer, true);

            this.MenuStrip.Renderer = new MenuStripRender();

            MenuSetup();

            InitColorsAndFont();

            InitSyntaxColoring();

            InitNumberMargin();

            InitBookmarkMargin();

            InitCodeFolding();

            InitDragDropFile();

            LoadDataFromFile("../");

            InitHotkeys();

            SetUpMenuComboBox();

        }

        public string ReturnValue()
        {
            if (SaveStatus == 1 || SaveStatus == 0) // saved
            {
                return save;
            }
            else { return string.Empty; }  // No save
        }

        #region Form Stuff
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Hot Bar Buttons
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void CloseBT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MinimiseBT_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ChangeSizeBT_Click(object sender, EventArgs e)
        {

            if (WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }

        }

        private void HelpBT_Click(object sender, EventArgs e)
        {

        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Hot Bar Drag Motion
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void HotBarP_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // No Windows Border and Resize
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        protected override void WndProc(ref Message m)
        {
            const int WM_NCCALCSIZE = 0x0083;//Standar Title Bar - Snap Window
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MINIMIZE = 0xF020; //Minimize form (Before)
            const int SC_RESTORE = 0xF120; //Restore form (Before)
            const int WM_NCHITTEST = 0x0084;//Win32, Mouse Input Notification: Determine what part of the window corresponds to a point, allows to resize the form.
            const int resizeAreaSize = 10;
            #region Form Resize
            // Resize/WM_NCHITTEST values
            const int HTCLIENT = 1; //Represents the client area of the window
            const int HTLEFT = 10;  //Left border of a window, allows resize horizontally to the left
            const int HTRIGHT = 11; //Right border of a window, allows resize horizontally to the right
            const int HTTOP = 12;   //Upper-horizontal border of a window, allows resize vertically up
            const int HTTOPLEFT = 13;//Upper-left corner of a window border, allows resize diagonally to the left
            const int HTTOPRIGHT = 14;//Upper-right corner of a window border, allows resize diagonally to the right
            const int HTBOTTOM = 15; //Lower-horizontal border of a window, allows resize vertically down
            const int HTBOTTOMLEFT = 16;//Lower-left corner of a window border, allows resize diagonally to the left
            const int HTBOTTOMRIGHT = 17;//Lower-right corner of a window border, allows resize diagonally to the right
            ///<Doc> More Information: https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-nchittest </Doc>
            if (m.Msg == WM_NCHITTEST)
            { //If the windows m is WM_NCHITTEST
                base.WndProc(ref m);
                if (this.WindowState == FormWindowState.Normal)//Resize the form if it is in normal state
                {
                    if ((int)m.Result == HTCLIENT)//If the result of the m (mouse pointer) is in the client area of the window
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32()); //Gets screen point coordinates(X and Y coordinate of the pointer)                           
                        Point clientPoint = this.PointToClient(screenPoint); //Computes the location of the screen point into client coordinates                          
                        if (clientPoint.Y <= resizeAreaSize)//If the pointer is at the top of the form (within the resize area- X coordinate)
                        {
                            if (clientPoint.X <= resizeAreaSize) //If the pointer is at the coordinate X=0 or less than the resizing area(X=10) in 
                                m.Result = (IntPtr)HTTOPLEFT; //Resize diagonally to the left
                            else if (clientPoint.X < (this.Size.Width - resizeAreaSize))//If the pointer is at the coordinate X=11 or less than the width of the form(X=Form.Width-resizeArea)
                                m.Result = (IntPtr)HTTOP; //Resize vertically up
                            else //Resize diagonally to the right
                                m.Result = (IntPtr)HTTOPRIGHT;
                        }
                        else if (clientPoint.Y <= (this.Size.Height - resizeAreaSize)) //If the pointer is inside the form at the Y coordinate(discounting the resize area size)
                        {
                            if (clientPoint.X <= resizeAreaSize)//Resize horizontally to the left
                                m.Result = (IntPtr)HTLEFT;
                            else if (clientPoint.X > (this.Width - resizeAreaSize))//Resize horizontally to the right
                                m.Result = (IntPtr)HTRIGHT;
                        }
                        else
                        {
                            if (clientPoint.X <= resizeAreaSize)//Resize diagonally to the left
                                m.Result = (IntPtr)HTBOTTOMLEFT;
                            else if (clientPoint.X < (this.Size.Width - resizeAreaSize)) //Resize vertically down
                                m.Result = (IntPtr)HTBOTTOM;
                            else //Resize diagonally to the right
                                m.Result = (IntPtr)HTBOTTOMRIGHT;
                        }
                    }
                }
                return;
            }
            #endregion
            //Remove border and keep snap window
            if (m.Msg == WM_NCCALCSIZE && m.WParam.ToInt32() == 1)
            {
                return;
            }
            //Keep form size when it is minimized and restored. Since the form is resized because it takes into account the size of the title bar and borders.
            if (m.Msg == WM_SYSCOMMAND)
            {
                /// <see cref="https://docs.microsoft.com/en-us/windows/win32/menurc/wm-syscommand"/>
                /// Quote:
                /// In WM_SYSCOMMAND messages, the four low - order bits of the wParam parameter 
                /// are used internally by the system.To obtain the correct result when testing 
                /// the value of wParam, an application must combine the value 0xFFF0 with the 
                /// wParam value by using the bitwise AND operator.
                int wParam = (m.WParam.ToInt32() & 0xFFF0);
                if (wParam == SC_MINIMIZE)  //Before
                    formSize = this.ClientSize;
                if (wParam == SC_RESTORE)// Restored form(Before)
                    this.Size = formSize;
            }
            base.WndProc(ref m);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Form
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void AdjustForm()
        {
            switch (this.WindowState)
            {
                case FormWindowState.Maximized: //Maximized form (After)
                    this.Padding = new Padding(8, 8, 8, 0);
                    break;
                case FormWindowState.Normal: //Restored form (After)
                    if (this.Padding.Top != 2)
                        this.Padding = new Padding(2);
                    break;
            }
        }

        private void CodeEditorForm_Resize(object sender, EventArgs e)
        {
            AdjustForm();
        }

        private void CodeEditorForm_Load(object sender, EventArgs e)
        {
            if (ProjPath == "") { projIsNULL = true; }
            formSize = this.ClientSize;
            AutoComplete.TargetControlWrapper = new ScintillaWrapper(scintilla);
            scintilla.Text = text;
            if (text == null) { ResetFile.Enabled = false; }
            if (GoodCode) { save = text; SaveStatus = 0; }else{SaveStatus = 2;}
            SetUpMode();
            if (DebugOptionsMono == true) { MonoElementDebug.Enabled = false; ChangeBT.Enabled = true; MenuCB.Enabled = false; }
        }

        private void CodeEditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SaveStatus == 2)
            {
                DialogResult result = MessageBox.ClassMessageBox.Show();
                if (result == DialogResult.OK)
                {
                    save = scintilla.Text;
                    if (noErrors)
                    {
                        SaveStatus = 1;
                    }
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }
        #endregion Form Stuff

        #region Scintilla Stuff
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Text Editor Events
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        private CSharpLexer cSharpLexer = new CSharpLexer("no yes",
            "OR NOT AND NAND NOR ADD if limit else",
            "set_variable remove_variable add_modifier remove_modifier set_global_variable remove_global_variable",
            "annex",
            "temporaryholder");

        private void scintilla_StyleNeeded(object sender, StyleNeededEventArgs e)
        {
            var startPos = scintilla.GetEndStyled();
            var endPos = e.Position;

            cSharpLexer.Style(scintilla, startPos, endPos);
        }

        int lastCaretPos = 0;

        private void scintilla_UpdateUI(object sender, UpdateUIEventArgs e)
        {
            // Has the caret changed position?
            var caretPos = scintilla.CurrentPosition;
            if (lastCaretPos != caretPos)
            {
                lastCaretPos = caretPos;
                var bracePos1 = -1;
                var bracePos2 = -1;

                // Is there a brace to the left or right?
                if (caretPos > 0 && CSharpLexer.IsBrace(scintilla.GetCharAt(caretPos - 1)))
                    bracePos1 = (caretPos - 1);
                else if (CSharpLexer.IsBrace(scintilla.GetCharAt(caretPos)))
                    bracePos1 = caretPos;

                if (bracePos1 >= 0)
                {
                    // Find the matching brace
                    bracePos2 = scintilla.BraceMatch(bracePos1);
                    if (bracePos2 == Scintilla.InvalidPosition)
                        scintilla.BraceBadLight(bracePos1);
                    else
                        scintilla.BraceHighlight(bracePos1, bracePos2);
                }
                else
                {
                    // Turn off brace matching
                    scintilla.BraceHighlight(Scintilla.InvalidPosition, Scintilla.InvalidPosition);
                }
            }
        }

        private void scintilla_TextChanged(object sender, EventArgs e)
        {
            SaveStatus = 2;
            noErrors = false;
        }

        private void scintilla_InsertCheck(object sender, InsertCheckEventArgs e)
        {

            if (((e.Text.EndsWith("" + Constants.vbCr) || e.Text.EndsWith("" + Constants.vbLf))) && !stopIndenting)
            {
                int startPos = scintilla.Lines[scintilla.LineFromPosition(scintilla.CurrentPosition)].Position;
                int endPos = e.Position;
                string curLineText = scintilla.GetTextRange(startPos, (endPos - startPos)); //Text until the caret so that the whitespace is always equal in every line.

                Match indent = Regex.Match(curLineText, "^[ \\t]*");
                e.Text = (e.Text + indent.Value);
                if (Regex.IsMatch(curLineText, "{\\s*$"))
                {
                    e.Text = (e.Text + Constants.vbTab);
                }

            }
            stopIndenting = false;
        }

        private void scintilla_CharAdded(object sender, CharAddedEventArgs e)
        {

            switch (e.Char)
            {
                //The '{' char.
                case 123:
                    int startPos = scintilla.Lines[scintilla.LineFromPosition(scintilla.CurrentPosition)].Position;
                    int endPos = Math.Max(scintilla.CurrentPosition, scintilla.AnchorPosition);
                    string curLineText = scintilla.GetTextRange(startPos, (endPos - startPos)); //Text until the caret so that the whitespace is always equal in every line.
                    Match indent = Regex.Match(curLineText, "^[\\t]*");

                    scintilla.TargetStart = Math.Min(scintilla.CurrentPosition, scintilla.AnchorPosition) - 1;
                    scintilla.TargetEnd = Math.Max(scintilla.CurrentPosition, scintilla.AnchorPosition) + 1;
                    stopIndenting = true;
                    scintilla.ReplaceTarget("{\n" + indent.Value + "\t\n" + indent.Value + "}\n");
                    scintilla.GotoPosition(scintilla.CurrentPosition + 3 + indent.Value.Length);
                    break;

                //The '}' char.
                case 125:
                    int curLine = scintilla.LineFromPosition(scintilla.CurrentPosition);

                    if (scintilla.Lines[curLine].Text.Trim() == "}")
                    { //Check whether the bracket is the only thing on the line.. For cases like "if() { }".
                        SetIndent(scintilla, curLine, GetIndent(scintilla, curLine) - 4);
                    }
                    break;

                //The '"' char.
                case 34:
                    scintilla.TargetStart = Math.Min(scintilla.CurrentPosition, scintilla.AnchorPosition) - 1;
                    scintilla.TargetEnd = Math.Max(scintilla.CurrentPosition, scintilla.AnchorPosition);
                    scintilla.ReplaceTarget("\"\"");
                    scintilla.GotoPosition(scintilla.CurrentPosition + 1);
                    break;

                // =
                case 61:
                    scintilla.TargetStart = Math.Min(scintilla.CurrentPosition, scintilla.AnchorPosition) - 1;
                    scintilla.TargetEnd = Math.Max(scintilla.CurrentPosition, scintilla.AnchorPosition);
                    if (scintilla.CurrentPosition > 1)
                    {
                        if (scintilla.Text[scintilla.CurrentPosition - 2] == ' ')
                        {
                            scintilla.ReplaceTarget("= ");
                            scintilla.GotoPosition(scintilla.CurrentPosition + 2);
                        }
                        else
                        {
                            scintilla.ReplaceTarget(" = ");
                            scintilla.GotoPosition(scintilla.CurrentPosition + 3);
                        }
                    }


                    break;

                // (space)
                case 32:
                    scintilla.TargetStart = Math.Min(scintilla.CurrentPosition, scintilla.AnchorPosition) - 1;
                    scintilla.TargetEnd = Math.Max(scintilla.CurrentPosition, scintilla.AnchorPosition);
                    if (scintilla.CurrentPosition > 2)
                    {
                        if (scintilla.Text[scintilla.CurrentPosition - 2] == ' ' && scintilla.Text[scintilla.CurrentPosition - 3] == '=')
                        {
                            scintilla.ReplaceTarget("");
                        }
                    }

                    break;
            }




            /*
            // Find the word start
            var currentPos = scintilla.CurrentPosition;
            var wordStartPos = scintilla.WordStartPosition(currentPos, true);

            // Display the autocompletion list
            var lenEntered = currentPos - wordStartPos;
            if (lenEntered > 0)
            {
                if (!scintilla.AutoCActive)
                    scintilla.AutoCShow(lenEntered, "AND OR if set_variable set_variables set_variabless set_variablesss set_variablessss set_variablesssss set_variablesssssss");
            }
            */
        }

        const int SCI_SETLINEINDENTATION = 2126;
        const int SCI_GETLINEINDENTATION = 2127;
        private void SetIndent(ScintillaNET.Scintilla scin, int line, int indent)
        {
            scin.DirectMessage(SCI_SETLINEINDENTATION, new IntPtr(line), new IntPtr(indent));
        }
        private int GetIndent(ScintillaNET.Scintilla scin, int line)
        {
            return scin.DirectMessage(SCI_GETLINEINDENTATION, new IntPtr(line), (nint)null).ToInt32();
        }

        private void InitHotkeys()
        {

            // register the hotkeys with the form
            HotKeyManager.AddHotKey(this, OpenSearch, Keys.F, true);
            HotKeyManager.AddHotKey(this, OpenSearch, Keys.R, true);
            HotKeyManager.AddHotKey(this, OpenSearch, Keys.H, true);
            HotKeyManager.AddHotKey(this, Uppercase, Keys.U, true);
            HotKeyManager.AddHotKey(this, Lowercase, Keys.L, true);
            HotKeyManager.AddHotKey(this, ZoomIn, Keys.Oemplus, true);
            HotKeyManager.AddHotKey(this, ZoomOut, Keys.OemMinus, true);
            HotKeyManager.AddHotKey(this, ZoomDefault, Keys.D0, true);
            HotKeyManager.AddHotKey(this, CloseSearch, Keys.Escape);

            // remove conflicting hotkeys from scintilla
            scintilla.ClearCmdKey(Keys.Control | Keys.F);
            scintilla.ClearCmdKey(Keys.Control | Keys.R);
            scintilla.ClearCmdKey(Keys.Control | Keys.H);
            scintilla.ClearCmdKey(Keys.Control | Keys.L);
            scintilla.ClearCmdKey(Keys.Control | Keys.U);

        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Text Editor Styling
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void InitSyntaxColoring()
        {


            // Configure the default style
            scintilla.StyleResetDefault();
            scintilla.CaretForeColor = ScintillaColor[0];
            scintilla.SetSelectionBackColor(true, ScintillaColor[1]);
            scintilla.Styles[Style.Default].BackColor = ScintillaColor[2];
            scintilla.Styles[Style.Default].ForeColor = Color.FromArgb(255, 255, 255);
            scintilla.Styles[Style.Default].Font = ScintillaFont.Name;
            scintilla.Styles[Style.Default].Size = (int)Math.Round(ScintillaFont.Size);
            scintilla.StyleClearAll();

            // Configure the lexer styles
            scintilla.Styles[CSharpLexer.StyleDefault].ForeColor = ScintillaColor[3];
            scintilla.Styles[CSharpLexer.StyleIdentifier].ForeColor = ScintillaColor[4];
            scintilla.Styles[CSharpLexer.StyleNumber].ForeColor = ScintillaColor[5];
            scintilla.Styles[CSharpLexer.StyleString].ForeColor = ScintillaColor[6];
            scintilla.Styles[CSharpLexer.StyleComment].ForeColor = ScintillaColor[7];
            scintilla.Styles[CSharpLexer.StyleEqual].ForeColor = ScintillaColor[8];
            scintilla.Styles[CSharpLexer.StyleBrace].ForeColor = ScintillaColor[9];
            scintilla.Styles[CSharpLexer.StyleAffirmativeKeyword].ForeColor = ScintillaColor[13];
            scintilla.Styles[CSharpLexer.StyleLogicKeyword].ForeColor = ScintillaColor[14];
            scintilla.Styles[CSharpLexer.StyleSetDelete].ForeColor = ScintillaColor[15];
            scintilla.Styles[CSharpLexer.StyleCommands].ForeColor = ScintillaColor[16];
            scintilla.Styles[CSharpLexer.StyleKeywords].ForeColor = ScintillaColor[17];

            scintilla.Styles[Style.BraceLight].BackColor = ScintillaColor[12];
            scintilla.Styles[Style.BraceLight].ForeColor = ScintillaColor[11];
            scintilla.Styles[Style.BraceBad].ForeColor = ScintillaColor[10];

            scintilla.Styles[Style.LineNumber].BackColor = Color.FromArgb(40, 40, 40);
            scintilla.Styles[Style.LineNumber].ForeColor = Color.FromArgb(140, 140, 140);
            scintilla.Styles[Style.IndentGuide].ForeColor = Color.Gray;
            scintilla.Styles[Style.IndentGuide].FillLine = false;
        }


        /// <summary>
        /// change this to whatever margin you want the line numbers to show in
        /// </summary>
        private const int NUMBER_MARGIN = 1;

        /// <summary>
        /// change this to whatever margin you want the bookmarks/breakpoints to show in
        /// </summary>
        private const int BOOKMARK_MARGIN = 2;
        private const int BOOKMARK_MARKER = 2;

        /// <summary>
        /// change this to whatever margin you want the code folding tree (+/-) to show in
        /// </summary>
        private const int FOLDING_MARGIN = 3;

        /// <summary>
        /// set this true to show circular buttons for code folding (the [+] and [-] buttons on the margin)
        /// </summary>
        private const bool CODEFOLDING_CIRCULAR = true;

        private void scintilla_MarginClick(object sender, MarginClickEventArgs e)
        {
            if (e.Margin == BOOKMARK_MARGIN)
            {
                // Do we have a marker for this line?
                const uint mask = (1 << BOOKMARK_MARKER);
                var line = scintilla.Lines[scintilla.LineFromPosition(e.Position)];
                if ((line.MarkerGet() & mask) > 0)
                {
                    // Remove existing bookmark
                    line.MarkerDelete(BOOKMARK_MARKER);
                }
                else
                {
                    // Add bookmark
                    line.MarkerAdd(BOOKMARK_MARKER);
                }
            }
        }

        private void InitNumberMargin()
        {

            scintilla.Styles[Style.LineNumber].BackColor = Color.FromArgb(40, 40, 40);
            scintilla.Styles[Style.LineNumber].ForeColor = Color.FromArgb(140, 140, 140);
            scintilla.Styles[Style.IndentGuide].ForeColor = Color.Gray;
            scintilla.Styles[Style.IndentGuide].FillLine = false;

            var nums = scintilla.Margins[NUMBER_MARGIN];
            nums.Width = 30;
            nums.Type = MarginType.Number;
            nums.Sensitive = true;
            nums.Mask = 0;

            scintilla.MarginClick += scintilla_MarginClick;
        }

        private void InitBookmarkMargin()
        {

            var margin = scintilla.Margins[BOOKMARK_MARGIN];
            margin.Width = 20;
            margin.Sensitive = true;
            margin.Type = MarginType.Symbol;
            margin.Mask = (1 << BOOKMARK_MARKER);
            //margin.Cursor = MarginCursor.Arrow;

            var marker = scintilla.Markers[BOOKMARK_MARKER];
            marker.Symbol = MarkerSymbol.Circle;
            marker.SetBackColor(Color.FromArgb(197, 81, 89));
            marker.SetForeColor(Color.FromArgb(197, 81, 89));
            marker.SetAlpha(100);

        }

        private void InitCodeFolding()
        {
            scintilla.SetFoldMarginColor(true, Color.FromArgb(40, 40, 40));
            scintilla.SetFoldMarginHighlightColor(true, Color.FromArgb(45, 45, 45));



            // Instruct the lexer to calculate folding
            scintilla.SetProperty("fold", "1");
            scintilla.SetProperty("fold.compact", "1");

            // Configure a margin to display folding symbols
            scintilla.Margins[FOLDING_MARGIN].Type = MarginType.Symbol;
            scintilla.Margins[FOLDING_MARGIN].Mask = Marker.MaskFolders;
            scintilla.Margins[FOLDING_MARGIN].Sensitive = true;
            scintilla.Margins[FOLDING_MARGIN].Width = 20;

            // Set colors for all folding markers
            for (int i = 25; i <= 31; i++)
            {
                scintilla.Markers[i].SetForeColor(Color.FromArgb(50, 50, 50));
                scintilla.Markers[i].SetBackColor(Color.White);
            }

            // Configure folding markers with respective symbols
            scintilla.Markers[Marker.Folder].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CirclePlus : MarkerSymbol.BoxPlus;
            scintilla.Markers[Marker.FolderOpen].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CircleMinus : MarkerSymbol.BoxMinus;
            scintilla.Markers[Marker.FolderEnd].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CirclePlusConnected : MarkerSymbol.BoxPlusConnected;
            scintilla.Markers[Marker.FolderMidTail].Symbol = MarkerSymbol.TCorner;
            scintilla.Markers[Marker.FolderOpenMid].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CircleMinusConnected : MarkerSymbol.BoxMinusConnected;
            scintilla.Markers[Marker.FolderSub].Symbol = MarkerSymbol.VLine;
            scintilla.Markers[Marker.FolderTail].Symbol = MarkerSymbol.LCorner;

            // Enable automatic folding
            scintilla.AutomaticFold = (AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change);


        }

        public void InitDragDropFile()
        {

            scintilla.AllowDrop = true;
            scintilla.DragEnter += delegate (object sender, DragEventArgs e) {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                    e.Effect = DragDropEffects.Copy;
                else
                    e.Effect = DragDropEffects.None;
            };
            scintilla.DragDrop += delegate (object sender, DragEventArgs e) {

                // get file drop
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {

                    Array a = (Array)e.Data.GetData(DataFormats.FileDrop);
                    if (a != null)
                    {

                        string path = a.GetValue(0).ToString();

                        LoadDataFromFile(path);

                    }
                }
            };

        }

        private void LoadDataFromFile(string path)
        {
            if (File.Exists(path))
            {
                //FileName.Text = Path.GetFileName(path);
                scintilla.Text = File.ReadAllText(path);
            }
        }


        /*
                private void AddFoldRegion(int StartLine, int EndLine, int CurrentLevel)
                {
                    int Start = StartLine, End = EndLine;

                    if (StartLine > EndLine)
                    {
                        Start = EndLine;
                        End = StartLine;
                    }
                    scintilla.Lines[Start].FoldLevelFlags = FoldLevelFlags.Header;
                    scintilla.Lines[Start].FoldLevel = CurrentLevel;
                    for (int i = Start + 1; i < End; ++i)
                    {
                        scintilla.Lines[i].FoldLevel = scintilla.Lines[Start].FoldLevel + 1;
                        scintilla.Lines[i].FoldLevelFlags = FoldLevelFlags.White;
                    }
                    scintilla.Lines[End].FoldLevel = scintilla.Lines[Start].FoldLevel + 1;
                }
                private void RemoveFoldRegion(int StartLine, int EndLine, int CurrentLevel)
                {
                    int Start = StartLine, End = EndLine;

                    if (StartLine > EndLine)
                    {
                        Start = EndLine;
                        End = StartLine;
                    }
                    scintilla.Lines[Start].FoldLevelFlags = 0;
                    scintilla.Lines[Start].FoldLevel = CurrentLevel;
                    for (int i = Start + 1; i < End; ++i)
                    {
                        scintilla.Lines[i].FoldLevel = scintilla.Lines[Start].FoldLevel;
                        scintilla.Lines[i].FoldLevelFlags = 0;
                    }
                    scintilla.Lines[End].FoldLevel = scintilla.Lines[Start].FoldLevel;
                }

        */
        #endregion Scintilla Stuff

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Menu
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region Menu
        private void MenuSetup()
        {

            ToolStripMenuItem FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();

            ToolStripMenuItem NewFile = new System.Windows.Forms.ToolStripMenuItem();
            ToolStripMenuItem OpenFile = new System.Windows.Forms.ToolStripMenuItem();
            ExtendedToolStripSeparator FileExtendedToolStripSeparator1 = new ExtendedToolStripSeparator();
            ToolStripMenuItem SaveFile = new System.Windows.Forms.ToolStripMenuItem();
            ToolStripMenuItem SaveAsFIle = new System.Windows.Forms.ToolStripMenuItem();
            ExtendedToolStripSeparator FileExtendedToolStripSeparator2 = new ExtendedToolStripSeparator();
            ToolStripMenuItem ExitFile = new System.Windows.Forms.ToolStripMenuItem();

            // 
            // NewFile
            // 
            NewFile.ForeColor = System.Drawing.Color.White;
            NewFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            NewFile.Name = "NewFile";
            NewFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            NewFile.Size = new System.Drawing.Size(180, 26);
            NewFile.Text = "New";
            NewFile.Click += new System.EventHandler(FileNew_Click);
            // 
            // ResetFile
            // 
            ResetFile.ForeColor = System.Drawing.Color.White;
            ResetFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            ResetFile.Name = "ResetFile";
            ResetFile.Size = new System.Drawing.Size(180, 26);
            ResetFile.Text = "Reset";
            ResetFile.Click += new System.EventHandler(ResetFile_Click);
            // 
            // OpenFile
            // 
            OpenFile.ForeColor = System.Drawing.Color.White;
            OpenFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            OpenFile.Name = "OpenFile";
            OpenFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            OpenFile.Size = new System.Drawing.Size(180, 26);
            OpenFile.Text = "Open";
            OpenFile.Click += new System.EventHandler(OpenFile_Click);
            // 
            // FileExtendedToolStripSeparator1
            // 
            FileExtendedToolStripSeparator1.Name = "FileExtendedToolStripSeparator1";
            FileExtendedToolStripSeparator1.Size = new System.Drawing.Size(249, 6);
            // 
            // SaveFile
            // 
            SaveFile.ForeColor = System.Drawing.Color.White;
            SaveFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            SaveFile.Name = "SaveFile";
            SaveFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            SaveFile.Size = new System.Drawing.Size(180, 26);
            SaveFile.Text = "Save";
            SaveFile.Click += new System.EventHandler(SaveFile_Click);
            // 
            // SaveAsFIle
            // 
            SaveAsFIle.ForeColor = System.Drawing.Color.White;
            SaveAsFIle.Name = "SaveAsFIle";
            SaveAsFIle.Size = new System.Drawing.Size(180, 26);
            SaveAsFIle.Text = "Save As";
            SaveAsFIle.Click += new System.EventHandler(SaveAsFIle_Click);
            // 
            // FileExtendedToolStripSeparator2
            // 
            FileExtendedToolStripSeparator2.Name = "FileExtendedToolStripSeparator2";
            FileExtendedToolStripSeparator2.Size = new System.Drawing.Size(249, 6);
            // 
            // ExitFile
            // 
            ExitFile.ForeColor = System.Drawing.Color.White;
            ExitFile.Name = "ExitFile";
            ExitFile.Size = new System.Drawing.Size(180, 26);
            ExitFile.Text = "Exit";
            ExitFile.Click += new System.EventHandler(ExitFile_Click);


            ToolStripMenuItem EditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();

            ToolStripMenuItem FindReplaceEdit = new System.Windows.Forms.ToolStripMenuItem();
            ExtendedToolStripSeparator EditExtendedToolStripSeparator1 = new ExtendedToolStripSeparator();
            ToolStripMenuItem UndoEdit = new System.Windows.Forms.ToolStripMenuItem();
            ToolStripMenuItem RedoEdit = new System.Windows.Forms.ToolStripMenuItem();
            ExtendedToolStripSeparator EditExtendedToolStripSeparator2 = new ExtendedToolStripSeparator();
            ToolStripMenuItem CutEdit = new System.Windows.Forms.ToolStripMenuItem();
            ToolStripMenuItem CopyEdit = new System.Windows.Forms.ToolStripMenuItem();
            ToolStripMenuItem PasteEdit = new System.Windows.Forms.ToolStripMenuItem();
            ExtendedToolStripSeparator EditExtendedToolStripSeparator3 = new ExtendedToolStripSeparator();
            ToolStripMenuItem SelectLineEdit = new System.Windows.Forms.ToolStripMenuItem();
            ToolStripMenuItem SelectAllEdit = new System.Windows.Forms.ToolStripMenuItem();
            ToolStripMenuItem ClearEdit = new System.Windows.Forms.ToolStripMenuItem();
            ExtendedToolStripSeparator EditExtendedToolStripSeparator4 = new ExtendedToolStripSeparator();
            ToolStripMenuItem IndentEdit = new System.Windows.Forms.ToolStripMenuItem();
            ToolStripMenuItem OutdentEdit = new System.Windows.Forms.ToolStripMenuItem();
            ExtendedToolStripSeparator EditExtendedToolStripSeparator5 = new ExtendedToolStripSeparator();
            ToolStripMenuItem UpperCaseEdit = new System.Windows.Forms.ToolStripMenuItem();
            ToolStripMenuItem LowerCaseEdit = new System.Windows.Forms.ToolStripMenuItem();

            // 
            // FindReplaceEdit
            // 
            FindReplaceEdit.ForeColor = System.Drawing.Color.White;
            FindReplaceEdit.Name = "FindReplaceEdit";
            FindReplaceEdit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            FindReplaceEdit.Size = new System.Drawing.Size(234, 26);
            FindReplaceEdit.Text = "Find and Replace";
            FindReplaceEdit.Click += new System.EventHandler(FindReplaceEdit_Click);
            // 
            // EditExtendedToolStripSeparator1
            // 
            EditExtendedToolStripSeparator1.Name = "EditExtendedToolStripSeparator1";
            EditExtendedToolStripSeparator1.Size = new System.Drawing.Size(249, 6);
            // 
            // UndoEdit
            // 
            UndoEdit.ForeColor = System.Drawing.Color.White;
            UndoEdit.Name = "UndoEdit";
            UndoEdit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            UndoEdit.Size = new System.Drawing.Size(234, 26);
            UndoEdit.Text = "Undo";
            UndoEdit.Click += new System.EventHandler(UndoEdit_Click);
            // 
            // RedoEdit
            // 
            RedoEdit.ForeColor = System.Drawing.Color.White;
            RedoEdit.Name = "RedoEdit";
            RedoEdit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            RedoEdit.Size = new System.Drawing.Size(234, 26);
            RedoEdit.Text = "Redo";
            RedoEdit.Click += new System.EventHandler(RedoEdit_Click);
            // 
            // EditExtendedToolStripSeparator2
            // 
            EditExtendedToolStripSeparator2.Name = "EditExtendedToolStripSeparator2";
            EditExtendedToolStripSeparator2.Size = new System.Drawing.Size(249, 6);
            // 
            // CutEdit
            // 
            CutEdit.ForeColor = System.Drawing.Color.White;
            CutEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            CutEdit.Name = "CutEdit";
            CutEdit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            CutEdit.Size = new System.Drawing.Size(234, 26);
            CutEdit.Text = "Cut";
            CutEdit.Click += new System.EventHandler(CutEdit_Click);
            // 
            // CopyEdit
            // 
            CopyEdit.ForeColor = System.Drawing.Color.White;
            CopyEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            CopyEdit.Name = "CopyEdit";
            CopyEdit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            CopyEdit.Size = new System.Drawing.Size(234, 26);
            CopyEdit.Text = "Copy";
            CopyEdit.Click += new System.EventHandler(CopyEdit_Click);
            // 
            // PasteEdit
            // 
            PasteEdit.ForeColor = System.Drawing.Color.White;
            PasteEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            PasteEdit.Name = "PasteEdit";
            PasteEdit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            PasteEdit.Size = new System.Drawing.Size(234, 26);
            PasteEdit.Text = "Paste";
            PasteEdit.Click += new System.EventHandler(PasteEdit_Click);
            // 
            // EditExtendedToolStripSeparator3
            // 
            EditExtendedToolStripSeparator3.Name = "EditExtendedToolStripSeparator3";
            EditExtendedToolStripSeparator3.Size = new System.Drawing.Size(249, 6);
            // 
            // SelectLineEdit
            // 
            SelectLineEdit.ForeColor = System.Drawing.Color.White;
            SelectLineEdit.Name = "SelectLineEdit";
            SelectLineEdit.Size = new System.Drawing.Size(234, 26);
            SelectLineEdit.Text = "Select Line";
            SelectLineEdit.Click += new System.EventHandler(SelectLineEdit_Click);
            // 
            // SelectAllEdit
            // 
            SelectAllEdit.ForeColor = System.Drawing.Color.White;
            SelectAllEdit.Name = "SelectAllEdit";
            SelectAllEdit.ShortcutKeyDisplayString = "Ctrl+A";
            SelectAllEdit.Size = new System.Drawing.Size(234, 26);
            SelectAllEdit.Text = "Select All";
            SelectAllEdit.Click += new System.EventHandler(SelectAllEdit_Click);
            // 
            // ClearEdit
            // 
            ClearEdit.ForeColor = System.Drawing.Color.White;
            ClearEdit.Name = "ClearEdit";
            ClearEdit.Size = new System.Drawing.Size(234, 26);
            ClearEdit.Text = "Clear Selection";
            ClearEdit.Click += new System.EventHandler(ClearEdit_Click);
            // 
            // EditExtendedToolStripSeparator4
            // 
            EditExtendedToolStripSeparator4.Name = "EditExtendedToolStripSeparator4";
            EditExtendedToolStripSeparator4.Size = new System.Drawing.Size(249, 6);
            // 
            // IndentEdit
            // 
            IndentEdit.ForeColor = System.Drawing.Color.White;
            IndentEdit.Name = "IndentEdit";
            IndentEdit.ShortcutKeyDisplayString = "Tab";
            IndentEdit.Size = new System.Drawing.Size(234, 26);
            IndentEdit.Text = "Indent";
            IndentEdit.Click += new System.EventHandler(IndentEdit_Click);
            // 
            // OutdentEdit
            // 
            OutdentEdit.ForeColor = System.Drawing.Color.White;
            OutdentEdit.Name = "OutdentEdit";
            OutdentEdit.ShortcutKeyDisplayString = "Shift+Tab";
            OutdentEdit.Size = new System.Drawing.Size(234, 26);
            OutdentEdit.Text = "Outdent";
            OutdentEdit.Click += new System.EventHandler(OutdentEdit_Click);
            // 
            // EditExtendedToolStripSeparator5
            // 
            EditExtendedToolStripSeparator5.Name = "EditExtendedToolStripSeparator5";
            EditExtendedToolStripSeparator5.Size = new System.Drawing.Size(249, 6);
            // 
            // UpperCaseEdit
            // 
            UpperCaseEdit.ForeColor = System.Drawing.Color.White;
            UpperCaseEdit.Name = "UpperCaseEdit";
            UpperCaseEdit.ShortcutKeyDisplayString = "Ctrl+U";
            UpperCaseEdit.Size = new System.Drawing.Size(234, 26);
            UpperCaseEdit.Text = "Uppercase";
            UpperCaseEdit.Click += new System.EventHandler(UpperCaseEdit_Click);
            // 
            // LowerCaseEdit
            // 
            LowerCaseEdit.ForeColor = System.Drawing.Color.White;
            LowerCaseEdit.Name = "LowerCaseEdit";
            LowerCaseEdit.ShortcutKeyDisplayString = "Ctrl+L";
            LowerCaseEdit.Size = new System.Drawing.Size(234, 26);
            LowerCaseEdit.Text = "Lowercase";
            LowerCaseEdit.Click += new System.EventHandler(LowerCaseEdit_Click);




            ToolStripMenuItem SearchToolStripMenuItem = new ToolStripMenuItem();

            ToolStripMenuItem KeyWordSearch = new System.Windows.Forms.ToolStripMenuItem();
            ExtendedToolStripSeparator SearchExtendedToolStripSeparator1 = new ExtendedToolStripSeparator();

            // 
            // KeyWordSearch
            // 
            KeyWordSearch.ForeColor = System.Drawing.Color.White;
            KeyWordSearch.Name = "KeyWordSearch";
            KeyWordSearch.Size = new System.Drawing.Size(234, 26);
            KeyWordSearch.Text = "Search KeyWord";
            KeyWordSearch.Click += new System.EventHandler(LowerCaseEdit_Click);
            // 
            // SearchExtendedToolStripSeparator1
            // 
            SearchExtendedToolStripSeparator1.Name = "SearchExtendedToolStripSeparator1";
            SearchExtendedToolStripSeparator1.Size = new System.Drawing.Size(249, 6);


            ToolStripMenuItem ViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();


            ExtendedToolStripSeparator ViewExtendedToolStripSeparator1 = new ExtendedToolStripSeparator();
            ToolStripMenuItem ZoomInView = new System.Windows.Forms.ToolStripMenuItem();
            ToolStripMenuItem ZoomOutView = new System.Windows.Forms.ToolStripMenuItem();
            ToolStripMenuItem Zoom100View = new System.Windows.Forms.ToolStripMenuItem();
            ExtendedToolStripSeparator ViewExtendedToolStripSeparator2 = new ExtendedToolStripSeparator();
            ToolStripMenuItem CollapseAllView = new System.Windows.Forms.ToolStripMenuItem();
            ToolStripMenuItem ExpandAllView = new System.Windows.Forms.ToolStripMenuItem();

            // 
            // WordWrapView
            // 
            WordWrapView.CheckOnClick = true;
            WordWrapView.ForeColor = System.Drawing.Color.White;
            WordWrapView.Name = "WordWrapView";
            WordWrapView.Size = new System.Drawing.Size(252, 26);
            WordWrapView.Text = "Word Wrap";
            WordWrapView.Click += new System.EventHandler(WordWrapView_Click);
            // 
            // ShowIndentView
            // 
            ShowIndentView.Checked = true;
            ShowIndentView.CheckOnClick = true;
            ShowIndentView.CheckState = System.Windows.Forms.CheckState.Checked;
            ShowIndentView.ForeColor = System.Drawing.Color.White;
            ShowIndentView.Name = "ShowIndentView";
            ShowIndentView.Size = new System.Drawing.Size(252, 26);
            ShowIndentView.Text = "Show Indent Guides";
            ShowIndentView.Click += new System.EventHandler(ShowIndentView_Click);
            // 
            // ShowWhiteSpaceView
            // 
            ShowWhiteSpaceView.CheckOnClick = true;
            ShowWhiteSpaceView.ForeColor = System.Drawing.Color.White;
            ShowWhiteSpaceView.Name = "ShowWhiteSpaceView";
            ShowWhiteSpaceView.Size = new System.Drawing.Size(252, 26);
            ShowWhiteSpaceView.Text = "Show Whitespace";
            ShowWhiteSpaceView.Click += new System.EventHandler(ShowWhiteSpaceView_Click);
            // 
            // ViewExtendedToolStripSeparator1
            // 
            ViewExtendedToolStripSeparator1.Name = "ViewExtendedToolStripSeparator1";
            ViewExtendedToolStripSeparator1.Size = new System.Drawing.Size(249, 6);
            // 
            // ZoomInView
            // 
            ZoomInView.ForeColor = System.Drawing.Color.White;
            ZoomInView.Name = "ZoomInView";
            ZoomInView.ShortcutKeyDisplayString = "Ctrl+Plus";
            ZoomInView.Size = new System.Drawing.Size(252, 26);
            ZoomInView.Text = "Zoom In";
            ZoomInView.Click += new System.EventHandler(ZoomInView_Click);
            // 
            // ZoomOutView
            // 
            ZoomOutView.ForeColor = System.Drawing.Color.White;
            ZoomOutView.Name = "ZoomOutView";
            ZoomOutView.ShortcutKeyDisplayString = "Ctrl+Minus";
            ZoomOutView.Size = new System.Drawing.Size(252, 26);
            ZoomOutView.Text = "Zoom Out";
            ZoomOutView.Click += new System.EventHandler(ZoomOutView_Click);
            // 
            // Zoom100View
            // 
            Zoom100View.ForeColor = System.Drawing.Color.White;
            Zoom100View.Name = "Zoom100View";
            Zoom100View.ShortcutKeyDisplayString = "Ctrl+0";
            Zoom100View.Size = new System.Drawing.Size(252, 26);
            Zoom100View.Text = "Zoom 100%";
            Zoom100View.Click += new System.EventHandler(Zoom100View_Click);
            // 
            // ViewExtendedToolStripSeparator2
            // 
            ViewExtendedToolStripSeparator2.Name = "ViewExtendedToolStripSeparator2";
            ViewExtendedToolStripSeparator2.Size = new System.Drawing.Size(249, 6);
            // 
            // CollapseAllView
            // 
            CollapseAllView.ForeColor = System.Drawing.Color.White;
            CollapseAllView.Name = "CollapseAllView";
            CollapseAllView.Size = new System.Drawing.Size(252, 26);
            CollapseAllView.Text = "Collapse All";
            CollapseAllView.Click += new System.EventHandler(CollapseAllView_Click);
            // 
            // ExpandAllView
            // 
            ExpandAllView.ForeColor = System.Drawing.Color.White;
            ExpandAllView.Name = "ExpandAllView";
            ExpandAllView.Size = new System.Drawing.Size(252, 26);
            ExpandAllView.Text = "Expand All";
            ExpandAllView.Click += new System.EventHandler(ExpandAllView_Click);



            ToolStripMenuItem CustomizeToolStripMenuItem = new ToolStripMenuItem();

            ToolStripMenuItem ColorsCustomize = new System.Windows.Forms.ToolStripMenuItem();
            ToolStripMenuItem FontCustomize = new System.Windows.Forms.ToolStripMenuItem();

            // 
            // ColorsCustomize
            // 
            ColorsCustomize.ForeColor = System.Drawing.Color.White;
            ColorsCustomize.Name = "ColorsCustomize";
            ColorsCustomize.Size = new System.Drawing.Size(234, 26);
            ColorsCustomize.Text = "Colors";
            ColorsCustomize.Click += new System.EventHandler(ColorsCustomize_Click);

            // 
            // FontCustomize
            // 
            FontCustomize.ForeColor = System.Drawing.Color.White;
            FontCustomize.Name = "FontCustomize";
            FontCustomize.Size = new System.Drawing.Size(234, 26);
            FontCustomize.Text = "Font and Size";
            FontCustomize.Click += new System.EventHandler(FontCustomize_Click);



            ToolStripMenuItem DebugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();




            // 
            // MonoElementDebug
            // 
            MonoElementDebug.Checked = true;
            MonoElementDebug.CheckOnClick = true;
            MonoElementDebug.CheckState = System.Windows.Forms.CheckState.Checked;
            MonoElementDebug.ForeColor = System.Drawing.Color.White;
            MonoElementDebug.Name = "MonoElementDebug";
            MonoElementDebug.Size = new System.Drawing.Size(252, 26);
            MonoElementDebug.Text = "Mono Element";
            MonoElementDebug.Click += new System.EventHandler(MonoElementDebug_Click);




            // 
            // FileToolStripMenuItem
            // 
            FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            NewFile,
            ResetFile,
            OpenFile,
            FileExtendedToolStripSeparator1,
            SaveFile,
            SaveAsFIle,
            FileExtendedToolStripSeparator2,
            ExitFile});
            FileToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            FileToolStripMenuItem.Size = new System.Drawing.Size(58, 28);
            FileToolStripMenuItem.Text = "File";


            // 
            // EditToolStripMenuItem
            // 
            EditToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            FindReplaceEdit,
            EditExtendedToolStripSeparator1,
            UndoEdit,
            RedoEdit,
            EditExtendedToolStripSeparator2,
            CutEdit,
            CopyEdit,
            PasteEdit,
            EditExtendedToolStripSeparator3,
            SelectLineEdit,
            SelectAllEdit,
            ClearEdit,
            EditExtendedToolStripSeparator4,
            IndentEdit,
            OutdentEdit,
            EditExtendedToolStripSeparator5,
            UpperCaseEdit,
            LowerCaseEdit});
            EditToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            EditToolStripMenuItem.Name = "EditToolStripMenuItem";
            EditToolStripMenuItem.Size = new System.Drawing.Size(58, 28);
            EditToolStripMenuItem.Text = "Edit";


            // 
            // SearchToolStripMenuItem
            // 
            SearchToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            KeyWordSearch,
            SearchExtendedToolStripSeparator1});
            SearchToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            SearchToolStripMenuItem.Name = "SearchToolStripMenuItem";
            SearchToolStripMenuItem.Size = new System.Drawing.Size(58, 28);
            SearchToolStripMenuItem.Text = "Search";




            // 
            // ViewToolStripMenuItem
            // 
            ViewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            WordWrapView,
            ShowIndentView,
            ShowWhiteSpaceView,
            ViewExtendedToolStripSeparator1,
            ZoomInView,
            ZoomOutView,
            Zoom100View,
            ViewExtendedToolStripSeparator2,
            CollapseAllView,
            ExpandAllView});
            ViewToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            ViewToolStripMenuItem.Name = "ViewToolStripMenuItem";
            ViewToolStripMenuItem.Size = new System.Drawing.Size(58, 28);
            ViewToolStripMenuItem.Text = "View";

            // 
            // CustomizeToolStripMenuItem
            // 
            CustomizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            ColorsCustomize,
            FontCustomize});
            CustomizeToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            CustomizeToolStripMenuItem.Name = "CustomizeToolStripMenuItem";
            CustomizeToolStripMenuItem.Size = new System.Drawing.Size(58, 28);
            CustomizeToolStripMenuItem.Text = "Customize";



            // 
            // DebugToolStripMenuItem
            // 
            DebugToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            MonoElementDebug});
            DebugToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            DebugToolStripMenuItem.Name = "DebugToolStripMenuItem";
            DebugToolStripMenuItem.Size = new System.Drawing.Size(58, 28);
            DebugToolStripMenuItem.Text = "Debug";



            MenuStrip.Items.Add(FileToolStripMenuItem);
            MenuStrip.Items.Add(EditToolStripMenuItem);
            //MenuStrip.Items.Add(SearchToolStripMenuItem);
            MenuStrip.Items.Add(ViewToolStripMenuItem);
            MenuStrip.Items.Add(CustomizeToolStripMenuItem);
            MenuStrip.Items.Add(DebugToolStripMenuItem);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // File Menu
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region File
        private void FileNew_Click(object sender, EventArgs e)
        {
            if (SaveStatus == 2)
            {
                DialogResult result = MessageBox.ClassMessageBox.Show();
                if (result == DialogResult.OK)
                {
                    save = scintilla.Text;
                    if (noErrors)
                    {
                        SaveStatus = 1;
                    }
                    scintilla.Text = "";
                }
                else if (result == DialogResult.Cancel)
                {

                }
                else
                {
                    scintilla.Text = "";
                }
            }
            else
            {
                scintilla.Text = "";
            }


        }

        private void ResetFile_Click(object sender, EventArgs e)
        {
            if (SaveStatus == 2)
            {
                DialogResult result = MessageBox.ClassMessageBox.Show();
                if (result == DialogResult.OK)
                {
                    save = scintilla.Text;
                    if (noErrors)
                    {
                        SaveStatus = 1;
                    }
                    scintilla.Text = text;
                }
                else if (result == DialogResult.Cancel)
                {
                }
                else
                {
                    scintilla.Text = text;
                }
            }
            else
            {
                scintilla.Text = text;
            }
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {

            if (SaveStatus == 2)
            {
                DialogResult result = MessageBox.ClassMessageBox.Show();
                if (result == DialogResult.OK)
                {
                    save = scintilla.Text;
                    if (noErrors)
                    {
                        SaveStatus = 1;
                    }
                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                        openFileDialog.InitialDirectory = "c:\\";
                        openFileDialog.Filter = "txt files (*.txt)|*.txt";
                        openFileDialog.FilterIndex = 2;
                        openFileDialog.RestoreDirectory = true;

                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            //Get the path of specified file
                            LoadDataFromFile(openFileDialog.FileName);
                        }
                    }
                }
                else if (result == DialogResult.Cancel)
                {
                }
                else
                {
                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                        openFileDialog.InitialDirectory = "c:\\";
                        openFileDialog.Filter = "txt files (*.txt)|*.txt";
                        openFileDialog.FilterIndex = 2;
                        openFileDialog.RestoreDirectory = true;

                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            //Get the path of specified file
                            LoadDataFromFile(openFileDialog.FileName);
                        }
                    }
                }
            }
            else
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = "c:\\";
                    openFileDialog.Filter = "txt files (*.txt)|*.txt";
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        //Get the path of specified file
                        LoadDataFromFile(openFileDialog.FileName);
                    }
                }
            }
        }

        private void SaveFile_Click(object sender, EventArgs e)
        {
            save = scintilla.Text;
            if (noErrors)
            {
                SaveStatus = 1;
            }
        }

        private void SaveAsFIle_Click(object sender, EventArgs e)
        {
            if (noErrors)
            {
                SaveStatus = 1;
            }
            save = scintilla.Text;
            SaveFileDialog SFD = new SaveFileDialog();
            SFD.Filter = "Text Files (.txt)|*.txt";
            SFD.Title = "Save file...";
            if (SFD.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamWriter sw = new StreamWriter(File.Open(SFD.FileName, FileMode.Create), new UTF8Encoding(true));
                sw.Write(save);
                sw.Close();
            }
        }

        private void ExitFile_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion File
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Edit Menu
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region Edit
        private void FindReplaceEdit_Click(object sender, EventArgs e)
        {
            OpenSearch();
        }

        private void UndoEdit_Click(object sender, EventArgs e)
        {
            scintilla.Undo();
        }

        private void RedoEdit_Click(object sender, EventArgs e)
        {
            scintilla.Redo();
        }

        private void CutEdit_Click(object sender, EventArgs e)
        {
            scintilla.Cut();
        }

        private void CopyEdit_Click(object sender, EventArgs e)
        {
            scintilla.Copy();
        }

        private void PasteEdit_Click(object sender, EventArgs e)
        {
            scintilla.Paste();
        }

        private void SelectLineEdit_Click(object sender, EventArgs e)
        {
            Line line = scintilla.Lines[scintilla.CurrentLine];
            scintilla.SetSelection(line.Position + line.Length, line.Position);
        }

        private void SelectAllEdit_Click(object sender, EventArgs e)
        {
            scintilla.SelectAll();
        }

        private void ClearEdit_Click(object sender, EventArgs e)
        {
            scintilla.SetEmptySelection(0);
        }

        private void Indent()
        {
            // we use this hack to send "Shift+Tab" to scintilla, since there is no known API to indent,
            // although the indentation function exists. Pressing TAB with the editor focused confirms this.
            GenerateKeystrokes("{TAB}");
        }
        private void IndentEdit_Click(object sender, EventArgs e)
        {
            Indent();
        }

        private void GenerateKeystrokes(string keys)
        {
            HotKeyManager.Enable = false;
            scintilla.Focus();
            SendKeys.Send(keys);
            HotKeyManager.Enable = true;
        }

        private void Outdent()
        {
            // we use this hack to send "Shift+Tab" to scintilla, since there is no known API to outdent,
            // although the indentation function exists. Pressing Shift+Tab with the editor focused confirms this.
            GenerateKeystrokes("+{TAB}");
        }
        private void OutdentEdit_Click(object sender, EventArgs e)
        {
            Outdent();
        }

        private void Uppercase()
        {

            // save the selection
            int start = scintilla.SelectionStart;
            int end = scintilla.SelectionEnd;

            // modify the selected text
            scintilla.ReplaceSelection(scintilla.GetTextRange(start, end - start).ToUpper());

            // preserve the original selection
            scintilla.SetSelection(start, end);
        }
        private void UpperCaseEdit_Click(object sender, EventArgs e)
        {
            Uppercase();
        }

        private void Lowercase()
        {

            // save the selection
            int start = scintilla.SelectionStart;
            int end = scintilla.SelectionEnd;

            // modify the selected text
            scintilla.ReplaceSelection(scintilla.GetTextRange(start, end - start).ToLower());

            // preserve the original selection
            scintilla.SetSelection(start, end);
        }
        private void LowerCaseEdit_Click(object sender, EventArgs e)
        {
            Lowercase();
        }
        #endregion Edit
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Search Menu
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // View Menu
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region View
        private void WordWrapView_Click(object sender, EventArgs e)
        {
            // toggle word wrap
            WordWrapView.Checked = !WordWrapView.Checked;
            scintilla.WrapMode = WordWrapView.Checked ? WrapMode.Word : WrapMode.None;
        }

        private void ShowIndentView_Click(object sender, EventArgs e)
        {
            // toggle indent guides
            ShowIndentView.Checked = !ShowIndentView.Checked;
            scintilla.IndentationGuides = ShowIndentView.Checked ? IndentView.LookBoth : IndentView.None;
        }

        private void ShowWhiteSpaceView_Click(object sender, EventArgs e)
        {
            // toggle view whitespace
            ShowWhiteSpaceView.Checked = !ShowWhiteSpaceView.Checked;
            scintilla.ViewWhitespace = ShowWhiteSpaceView.Checked ? WhitespaceMode.VisibleAlways : WhitespaceMode.Invisible;
        }

        private void ZoomIn()
        {
            scintilla.ZoomIn();
        }
        private void ZoomInView_Click(object sender, EventArgs e)
        {
            ZoomIn();
        }

        private void ZoomOut()
        {
            scintilla.ZoomOut();
        }
        private void ZoomOutView_Click(object sender, EventArgs e)
        {
            ZoomOut();
        }

        private void ZoomDefault()
        {
            scintilla.Zoom = 0;
        }
        private void Zoom100View_Click(object sender, EventArgs e)
        {
            ZoomDefault();
        }

        private void CollapseAllView_Click(object sender, EventArgs e)
        {
            scintilla.FoldAll(FoldAction.Contract);
        }

        private void ExpandAllView_Click(object sender, EventArgs e)
        {
            scintilla.FoldAll(FoldAction.Expand);
        }
        #endregion View
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Customize Menu
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void InitColorsAndFont()
        {
            if (Properties.Settings.Default.Font != ScintillaFont)
            {
                ScintillaFont = Properties.Settings.Default.Font;
            }

            if (Properties.Settings.Default.flag)
            {
                ScintillaColor = new Color[]{
                    Properties.Settings.Default.Caret,                          // Caret
                    Properties.Settings.Default.Selection,                      // Selection
                    Properties.Settings.Default.Backcolor,                      // Scintilla Backcolor
                    Properties.Settings.Default.notfinished,                    // Default -> not ended word
                    Properties.Settings.Default.Base,                           // Base Font
                    Properties.Settings.Default.Number,                         // Number
                    Properties.Settings.Default.text,                           // "String"
                    Properties.Settings.Default.comment,                        // #Comment
                    Properties.Settings.Default.equal,                          // = : < >
                    Properties.Settings.Default.braces,                         // { }
                    Properties.Settings.Default.not_closed,                     // { ... not closed
                    Properties.Settings.Default.highlight_fore,                 // { ... } highlight other fore
                    Properties.Settings.Default.highlight_backcolor,            // { ... } highlight other backcolor
                    Properties.Settings.Default.affirmative,                    // yes no
                    Properties.Settings.Default.logic,                          // AND ...
                    Properties.Settings.Default.setdelete,                      // set_variable...
                    Properties.Settings.Default.commands,                       // Commands
                    Properties.Settings.Default.keywords                        // Custom Keywords
                    };
            }
            else
            {
                Properties.Settings.Default.Caret = ScintillaColor[0];                             // Caret
                Properties.Settings.Default.Selection = ScintillaColor[1];                         // Selection
                Properties.Settings.Default.Backcolor = ScintillaColor[2];                         // Scintilla Backcolor
                Properties.Settings.Default.notfinished = ScintillaColor[3];                       // Default -> not ended word
                Properties.Settings.Default.Base = ScintillaColor[4];                              // Base Font
                Properties.Settings.Default.Number = ScintillaColor[5];                            // Number
                Properties.Settings.Default.text = ScintillaColor[6];                              // "String"
                Properties.Settings.Default.comment = ScintillaColor[7];                           // #Comment
                Properties.Settings.Default.equal = ScintillaColor[8];                             // = : < >
                Properties.Settings.Default.braces = ScintillaColor[9];                            // { }
                Properties.Settings.Default.not_closed = ScintillaColor[10];                       // { ... not closed
                Properties.Settings.Default.highlight_fore = ScintillaColor[11];                   // { ... } highlight other fore
                Properties.Settings.Default.highlight_backcolor = ScintillaColor[12];              // { ... } highlight other backcolor
                Properties.Settings.Default.affirmative = ScintillaColor[13];                      // yes no
                Properties.Settings.Default.logic = ScintillaColor[14];                            // AND ...
                Properties.Settings.Default.setdelete = ScintillaColor[15];                        // set_variable...
                Properties.Settings.Default.commands = ScintillaColor[16];                         // Commands
                Properties.Settings.Default.keywords = ScintillaColor[17];                         // Custom Keywords
                Properties.Settings.Default.flag = true;
                Properties.Settings.Default.Save();
            }

        }

        private void FontCustomize_Click(object sender, EventArgs e)
        {
            FontDialog dlg = new FontDialog();
            dlg.Font = ScintillaFont;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ScintillaFont = dlg.Font;
                Properties.Settings.Default.Font = dlg.Font;
                Properties.Settings.Default.Save();
                InitSyntaxColoring();
            }
        }

        private void ColorsCustomize_Click(object sender, EventArgs e)
        {
            using (FontColorForm form = new FontColorForm())
            {
                form.ColorData = ScintillaColor;
                form.ShowDialog();
                Color[] j = form.ReturnValue();
                if (j != null)
                {
                    ScintillaColor = j;
                    Properties.Settings.Default.Caret = ScintillaColor[0];                             // Caret
                    Properties.Settings.Default.Selection = ScintillaColor[1];                         // Selection
                    Properties.Settings.Default.Backcolor = ScintillaColor[2];                         // Scintilla Backcolor
                    Properties.Settings.Default.notfinished = ScintillaColor[3];                       // Default -> not ended word
                    Properties.Settings.Default.Base = ScintillaColor[4];                              // Base Font
                    Properties.Settings.Default.Number = ScintillaColor[5];                            // Number
                    Properties.Settings.Default.text = ScintillaColor[6];                              // "String"
                    Properties.Settings.Default.comment = ScintillaColor[7];                           // #Comment
                    Properties.Settings.Default.equal = ScintillaColor[8];                             // = : < >
                    Properties.Settings.Default.braces = ScintillaColor[9];                            // { }
                    Properties.Settings.Default.not_closed = ScintillaColor[10];                       // { ... not closed
                    Properties.Settings.Default.highlight_fore = ScintillaColor[11];                   // { ... } highlight other fore
                    Properties.Settings.Default.highlight_backcolor = ScintillaColor[12];              // { ... } highlight other backcolor
                    Properties.Settings.Default.affirmative = ScintillaColor[13];                      // yes no
                    Properties.Settings.Default.logic = ScintillaColor[14];                            // AND ...
                    Properties.Settings.Default.setdelete = ScintillaColor[15];                        // set_variable...
                    Properties.Settings.Default.commands = ScintillaColor[16];                         // Commands
                    Properties.Settings.Default.keywords = ScintillaColor[17];                         // Custom Keywords
                    Properties.Settings.Default.Save();
                    InitSyntaxColoring();
                }
            }
        }


        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Find Replace
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        bool SearchIsOpen = false;

        public void InvokeIfNeeded(Action action)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(action);
            }
            else
            {
                action.Invoke();
            }
        }

        private void OpenSearch()
        {

            SearchManager.FindBox = FindTB;
            SearchManager.TextArea = scintilla;
            SearchManager.ReplaceBox = ReplaceTB;

            if (!SearchIsOpen)
            {
                SearchIsOpen = true;
                InvokeIfNeeded(delegate () {
                    FindReplaceP.Visible = true;
                    FindTB.Text = SearchManager.LastSearch;
                    FindTB.Focus();
                    FindTB.Texts = scintilla.SelectedText;
                    FindTB.SelectAll();
                });
            }
            else
            {
                InvokeIfNeeded(delegate () {
                    FindTB.Focus();
                    FindTB.SelectAll();
                });
            }

        }

        private void CloseSearch()
        {
            if (SearchIsOpen)
            {
                SearchIsOpen = false;
                InvokeIfNeeded(delegate () {
                    FindReplaceP.Visible = false;
                    //CurBrowser.GetBrowser().StopFinding(true);
                });
            }
        }

        private void FindXBT_Click(object sender, EventArgs e)
        {
            FindTB.Texts = string.Empty;
        }

        private void ReplaceXBT_Click(object sender, EventArgs e)
        {
            ReplaceTB.Texts = string.Empty;
        }

        private void ExitFindReplaceBT_Click(object sender, EventArgs e)
        {
            CloseSearch();
        }

        private void NextBT_Click(object sender, EventArgs e)
        {
            SearchManager.Find(true, false);
        }

        private void BackBT_Click(object sender, EventArgs e)
        {
            SearchManager.Find(false, false);
        }

        private void FindTB_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            SearchManager.Find(true, true);
        }

        private void ReplaceTB_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            SearchManager.Replace(false);
        }

        private void FindTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (HotKeyManager.IsHotkey(e, Keys.Enter))
            {
                SearchManager.Find(true, false);
            }
            if (HotKeyManager.IsHotkey(e, Keys.Enter, true) || HotKeyManager.IsHotkey(e, Keys.Enter, false, true))
            {
                SearchManager.Find(false, false);
            }
        }

        private void ReplaceBT_Click(object sender, EventArgs e)
        {
            SearchManager.Replace(true);
        }

        private void ReplaceAllBT_Click(object sender, EventArgs e)
        {
            SearchManager.ReplaceAll(true);
        }

        #endregion Menu

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Indent Algorithm
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void IndentBT_Click(object sender, EventArgs e)
        {

        }


        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Auto Complete on Runtime
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        // *
        private void SetUpMenuComboBox()
        {
            MenuCB.Items.Add("Building Groups");
            MenuCB.Items.Add("Buildings");
            MenuCB.Items.Add("Canals");
            MenuCB.Items.Add("Cultures");
            MenuCB.Items.Add("Decisions");
            MenuCB.Items.Add("Decrees");
            MenuCB.Items.Add("Eras");
            MenuCB.Items.Add("Goods");
            MenuCB.Items.Add("Institutions");
            MenuCB.Items.Add("Law Groups");
            MenuCB.Items.Add("Laws");
            MenuCB.Items.Add("Modifiers");
            MenuCB.Items.Add("Modifier Types");
            MenuCB.Items.Add("Pop Needs");
            MenuCB.Items.Add("Pop Types");
            MenuCB.Items.Add("Production Method Groups");
            MenuCB.Items.Add("Production Methods");
            MenuCB.Items.Add("Religions");
            MenuCB.Items.Add("State Traits");
            MenuCB.Items.Add("Technologies");
        }

        // *
        private void SetUpMode()
        {
            string[] snippets;
            var items = new List<AutocompleteItem>();
            switch (currentMode)
            {
                case "Null":

                    break;
                case "Building Groups":
                    {
                        snippets = new string[23] { "parent_group = ","category = " ,"always_possible = ", "economy_of_scale = ", "is_subsistence = ", "default_building = ", "lens = ", "auto_place_buildings = ", "capped_by_resources = ", "discoverable_resource = ", "depletable_resource = ", "can_use_slaves = ", "land_usage = ", "cash_reserves_max = ", "inheritable_construction = ", "stateregion_max_level = ", "urbanization = ", "should_auto_expand = ", "hiring_rate = ", "proportionality_limit = ", "hires_unemployed_only = ", "infrastructure_usage_per_level = ", "fired_pops_become_radical = "};

                        foreach (var item in snippets)
                            items.Add(new UnknownAutocompleteItem(item) { ImageIndex = 1 });

                        //set as autocomplete source
                        AutoComplete.SetAutocompleteItems(items);


                        break;
                    }
                case "Buildings":
                    {
                        snippets = new string[41] { "building_group = ", "texture = ", "required_construction = ", "buildable = ", "expandable = ", "downsizeable = ", "unique = ", "has_max_level = ", "ignore_stateregion_max_level = ", "enable_air_connection = ", "port = ", "unlocking_technologies = ", "can_build = ", "construction_points = ", "construction_modifier = ", "owners = ", "economic_contribution = ", "min_raise_to_hire = ", "naval = ", "canal = ", "ai_value = ", "ai_subsidies_weight = ", "slaves_role = ", "production_method_groups = ", "should_auto_expand = ", "city_type = ", "generates_residences = ", "terrain_manipulator = ", "levels_per_mesh = ", "residence_points_per_level = ", "override_centerpiece_mesh = ", "centerpiece_mesh_weight = ", "meshes = ", "entity_not_constructed = ", "entity_under_construction = ", "entity_constructed = ", "locator = ", "lens = ", "city_gfx_interactions = ","possible = ", "recruits_combat_unit = " };

                        foreach (var item in snippets)
                            items.Add(new UnknownAutocompleteItem(item) { ImageIndex = 1 });

                        //set as autocomplete source
                        AutoComplete.SetAutocompleteItems(items);


                        break;
                    }
                case "Canals":
                    {
                        snippets = new string[5] { "texture = ", "possible = ", "has_technology_researched = ", "owns_treaty_port_in = ","state_region = " };

                        foreach (var item in snippets)
                            items.Add(new UnknownAutocompleteItem(item) { ImageIndex = 1 });

                        //set as autocomplete source
                        AutoComplete.SetAutocompleteItems(items);


                        break;
                    }
                case "Cultures":
                    {
                        snippets = new string[12] { "color = ","religion = ","traits = ", "male_common_first_names = ", "female_common_first_names = ", "noble_last_names = ", "common_last_names = ", "male_regal_first_names = ", "female_regal_first_names = ", "regal_last_names = ", "graphics = ", "ethnicities = " };

                        foreach (var item in snippets)
                            items.Add(new UnknownAutocompleteItem(item) { ImageIndex = 1 });

                        //set as autocomplete source
                        AutoComplete.SetAutocompleteItems(items);


                        break;
                    }
                case "Decisions":
                    {
                        snippets = new string[4] { "is_shown = ", "possible = ", "when_taken = ", "ai_chance = " };

                        foreach (var item in snippets)
                            items.Add(new UnknownAutocompleteItem(item) { ImageIndex = 1 });

                        //set as autocomplete source
                        AutoComplete.SetAutocompleteItems(items);


                        break;
                    }
                case "Decrees":
                    {
                        snippets = new string[6] { "texture = ", "modifier = ", "unlocking_technologies = ","valid = ", "cost = ", "ai_weight = "};

                        foreach (var item in snippets)
                            items.Add(new UnknownAutocompleteItem(item) { ImageIndex = 1 });

                        //set as autocomplete source
                        AutoComplete.SetAutocompleteItems(items);


                        break;
                    }
                case "Eras": // Era
                    { 
                    snippets = new string[2]{ "technology_cost = ", "era_" };

                    foreach (var item in snippets)
                        items.Add(new UnknownAutocompleteItem(item) { ImageIndex = 1 });

                    //set as autocomplete source
                    AutoComplete.SetAutocompleteItems(items);

            
                    break;
                    }
                case "Goods": // Goods
                    {
                        snippets = new string[10] { "texture = ", "cost = ", "category = ", "prestige_factor = ", "traded_quantity = ", "convoy_cost_multiplier = ", "consumption_tax_cost = ", "tradeable = ", "fixed_price = ", "obsession_chance = " };

                        foreach (var item in snippets)
                            items.Add(new UnknownAutocompleteItem(item) { ImageIndex = 1 });

                        //set as autocomplete source
                        AutoComplete.SetAutocompleteItems(items);

                        break;
                    }
                case "Institutions": // Institutions
                    {
                        snippets = new string[3] { "icon = ", "background_texture = ", "modifier = " };

                        foreach (var item in snippets)
                            items.Add(new UnknownAutocompleteItem(item) { ImageIndex = 1 });

                        //set as autocomplete source
                        AutoComplete.SetAutocompleteItems(items);

                        break;
                    }
                case "Law Groups": 
                    {
                        snippets = new string[6] { "law_group_category = ", "base_enactment_days = ", "enactment_approval_mult = ", "progressive_movement_chance = ", "regressive_movement_chance = ", "change_allowed_trigger = "};

                        foreach (var item in snippets)
                            items.Add(new UnknownAutocompleteItem(item) { ImageIndex = 1 });

                        //set as autocomplete source
                        AutoComplete.SetAutocompleteItems(items);

                        break;
                    }
                case "Laws":
                    {
                        snippets = new string[29] { "group = ", "icon = " , "progressiveness = ", "unlocking_laws = ", "is_visible = ", "on_activate = ", "on_deactivate = ", "unlocking_technologies = ", "modifier = ", "build_from_investment_pool = ", "institution = ", "institution_modifier = ", "disallowing_laws = ", "on_enact = ", "cultural_acceptance_rule = " ,"religious_acceptance_rule = ", "possible_political_movements = ", "pop_support = ", "ai_will_do = ", "revolution_state_weight = ", "tax_modifier_very_low = ", "tax_modifier_low = ", "tax_modifier_medium = ", "tax_modifier_high = ", "tax_modifier_very_high = ", "tariff_modifier_no_priority = ", "tariff_modifier_export_priority = ", "tariff_modifier_import_priority = ","can_enact = " };

                        foreach (var item in snippets)
                            items.Add(new UnknownAutocompleteItem(item) { ImageIndex = 1 });

                        //set as autocomplete source
                        AutoComplete.SetAutocompleteItems(items);

                        break;
                    }
                case "Modifiers": // Modifiers
                    {
                        snippets = new string[1] { "icon = " };

                        foreach (var item in snippets)
                            items.Add(new UnknownAutocompleteItem(item) { ImageIndex = 1 });

                        //set as autocomplete source
                        AutoComplete.SetAutocompleteItems(items);

                        break;
                    }
                case "Modifier Types": // ModifierTypes
                    {
                        snippets = new string[9] { "good = ", "percent = ", "num_decimals = ", "invert = ", "neutral = ", "boolean = ", "postfix = ", "translate = ", "ai_value = " };

                        foreach (var item in snippets)
                            items.Add(new UnknownAutocompleteItem(item) { ImageIndex = 1 });

                        //set as autocomplete source
                        AutoComplete.SetAutocompleteItems(items);

                        break;
                    }
                case "Pop Needs": // PopNeeds
                    {
                        snippets = new string[6] { "goods = ", "weight = ", "max_weight = ", "min_weight = ", "default = ", "entry = " };

                        foreach (var item in snippets)
                            items.Add(new UnknownAutocompleteItem(item) { ImageIndex = 1 });

                        //set as autocomplete source
                        AutoComplete.SetAutocompleteItems(items);

                        break;
                    }
                case "Pop Types": // PopTypes
                    {
                        snippets = new string[24] { "texture = ", "color = ", "strata = ", "subsistence_income = ", "is_slave = ", "start_quality_of_life = ", "can_always_hire = ", "ignores_employment_proportionality = ", "working_adult_ratio = ", "wage_weight = ", "consumption_mult = ", "literacy_target = ", "education_access = ", "dependent_wage = ", "unemployment = ", "political_engagement_base = ", "political_engagement_literacy_factor = ", "political_engagement_mult = ", "qualifications_growth_desc = ", "qualifications = ", "portrait_age_min = ", "portrait_age_max = ", "portrait_pose = ", "portrait_is_female = " };

                        foreach (var item in snippets)
                            items.Add(new UnknownAutocompleteItem(item) { ImageIndex = 1 });

                        //set as autocomplete source
                        AutoComplete.SetAutocompleteItems(items);

                        break;
                    }
                case "Production Method Groups":
                    {
                        snippets = new string[4] {"texture = ", "ai_selection = ", "is_hidden_when_unavailable = ", "production_methods = " };

                        foreach (var item in snippets)
                            items.Add(new UnknownAutocompleteItem(item) { ImageIndex = 1 });

                        //set as autocomplete source
                        AutoComplete.SetAutocompleteItems(items);

                        break;
                    }
                case "Production Methods":
                    {
                        snippets = new string[18] {"texture = ", "is_default = ", "low_pop_method = ", "ai_value = ", "pollution_generation = ","unlocking_technologies = ", "unlocking_glogal_technologies = ", "building_modifiers = ", "state_modifiers = ", "country_modifiers = ", "workforce_scaled = ", "level_scaled = ", "unscaled = ", "timed_modifiers = ", "unlocking_laws = ", "disallowing_laws = " , "unlocking_religions = ", "unlocking_production_methods = " };

                        foreach (var item in snippets)
                            items.Add(new UnknownAutocompleteItem(item) { ImageIndex = 1 });

                        //set as autocomplete source
                        AutoComplete.SetAutocompleteItems(items);

                        break;
                    }
                case "Religions": // Religions
                    {
                        snippets = new string[4] { "texture = ", "color = ", "traits = ", "taboos = " };

                        foreach (var item in snippets)
                            items.Add(new UnknownAutocompleteItem(item) { ImageIndex = 1 });

                        //set as autocomplete source
                        AutoComplete.SetAutocompleteItems(items);

                        break;
                    }
                case "State Traits": // StateTraits
                    {
                        snippets = new string[4] { "icon = ", "disabling_technologies = ", "required_techs_for_colonization = ", "modifier = " };

                        foreach (var item in snippets)
                            items.Add(new UnknownAutocompleteItem(item) { ImageIndex = 1 });

                        //set as autocomplete source
                        AutoComplete.SetAutocompleteItems(items);

                        break;
                    }
                case "Technologies": // Technology
                    {
                        snippets = new string[6] { "era = ", "texture = ", "category = ", "can_research = ", "modifier = ", "unlocking_technologies = " };

                        foreach (var item in snippets)
                            items.Add(new UnknownAutocompleteItem(item) { ImageIndex = 1 });

                        //set as autocomplete source
                        AutoComplete.SetAutocompleteItems(items);

                        break;
                    }
            }

        }

        private void MenuCB_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            currentMode = MenuCB.SelectedItem.ToString();
            SetUpMode();
        }


        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // AutoComplete Tooltip
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        // *
        private void AutoCompleteMenu_Hovered(object sender, HoveredEventArgs e)
        {
            if (e.Item != null)
            {
                switch (currentMode)
                {
                    case "Null":

                        break;
                    case "Building Groups":

                        switch (e.Item.ToString())
                        {
                            case "parent_group = ":

                                e.Item.ToolTipTitle = "Building Groups:";
                                e.Item.ToolTipText = "";
                                break;
                            case "category = ":

                                e.Item.ToolTipTitle = "Building Groups:";
                                e.Item.ToolTipText = "";
                                break;
                            case "always_possible = ":

                                e.Item.ToolTipTitle = "Building Groups:";
                                e.Item.ToolTipText = "";
                                break;
                            case "economy_of_scale = ":

                                e.Item.ToolTipTitle = "Building Groups:";
                                e.Item.ToolTipText = "";
                                break;
                            case "is_subsistence = ":

                                e.Item.ToolTipTitle = "Building Groups:";
                                e.Item.ToolTipText = "";
                                break;
                            case "default_building = ":

                                e.Item.ToolTipTitle = "Building Groups:";
                                e.Item.ToolTipText = "";
                                break;
                            case "lens = ":

                                e.Item.ToolTipTitle = "Building Groups:";
                                e.Item.ToolTipText = "";
                                break;
                            case "auto_place_buildings = ":

                                e.Item.ToolTipTitle = "Building Groups:";
                                e.Item.ToolTipText = "";
                                break;
                            case "capped_by_resources = ":

                                e.Item.ToolTipTitle = "Building Groups:";
                                e.Item.ToolTipText = "";
                                break;
                            case "discoverable_resource = ":

                                e.Item.ToolTipTitle = "Building Groups:";
                                e.Item.ToolTipText = "";
                                break;
                            case "depletable_resource = ":

                                e.Item.ToolTipTitle = "Building Groups:";
                                e.Item.ToolTipText = "";
                                break;
                            case "can_use_slaves = ":

                                e.Item.ToolTipTitle = "Building Groups:";
                                e.Item.ToolTipText = "";
                                break;
                            case "land_usage = ":

                                e.Item.ToolTipTitle = "Building Groups:";
                                e.Item.ToolTipText = "";
                                break;
                            case "cash_reserves_max = ":

                                e.Item.ToolTipTitle = "Building Groups:";
                                e.Item.ToolTipText = "";
                                break;
                            case "inheritable_construction = ":

                                e.Item.ToolTipTitle = "Building Groups:";
                                e.Item.ToolTipText = "";
                                break;
                            case "stateregion_max_level = ":

                                e.Item.ToolTipTitle = "Building Groups:";
                                e.Item.ToolTipText = "";
                                break;

                            case "urbanization = ":

                                e.Item.ToolTipTitle = "Building Groups:";
                                e.Item.ToolTipText = "";
                                break;
                            case "should_auto_expand = ":

                                e.Item.ToolTipTitle = "Building Groups:";
                                e.Item.ToolTipText = "";
                                break;
                            case "hiring_rate = ":

                                e.Item.ToolTipTitle = "Building Groups:";
                                e.Item.ToolTipText = "";
                                break;
                            case "proportionality_limit = ":

                                e.Item.ToolTipTitle = "Building Groups:";
                                e.Item.ToolTipText = "";
                                break;
                            case "hires_unemployed_only = ":

                                e.Item.ToolTipTitle = "Building Groups:";
                                e.Item.ToolTipText = "";
                                break;
                            case "infrastructure_usage_per_level = ":

                                e.Item.ToolTipTitle = "Building Groups:";
                                e.Item.ToolTipText = "";
                                break;
                            case "fired_pops_become_radical = ":

                                e.Item.ToolTipTitle = "Building Groups:";
                                e.Item.ToolTipText = "";
                                break;
                        }

                        break;
                    case "Buildings":

                        switch (e.Item.ToString())
                        {
                            case "building_group = ":

                                e.Item.ToolTipTitle = "Buildings:";
                                e.Item.ToolTipText = "";
                                break;
                            case "texture = ":

                                e.Item.ToolTipTitle = "Buildings:";
                                e.Item.ToolTipText = "";
                                break;
                            case "required_construction = ":

                                e.Item.ToolTipTitle = "Buildings:";
                                e.Item.ToolTipText = "";
                                break;
                            case "buildable = ":

                                e.Item.ToolTipTitle = "Buildings:";
                                e.Item.ToolTipText = "";
                                break;
                            case "expandable = ":

                                e.Item.ToolTipTitle = "Buildings:";
                                e.Item.ToolTipText = "";
                                break;
                            case "downsizeable = ":

                                e.Item.ToolTipTitle = "Buildings:";
                                e.Item.ToolTipText = "";
                                break;
                            case "unique = ":

                                e.Item.ToolTipTitle = "Buildings:";
                                e.Item.ToolTipText = "";
                                break;
                            case "has_max_level = ":

                                e.Item.ToolTipTitle = "Buildings:";
                                e.Item.ToolTipText = "";
                                break;
                            case "ignore_stateregion_max_level = ":

                                e.Item.ToolTipTitle = "Buildings:";
                                e.Item.ToolTipText = "";
                                break;
                            case "enable_air_connection = ":

                                e.Item.ToolTipTitle = "Buildings:";
                                e.Item.ToolTipText = "";
                                break;
                            case "port = ":

                                e.Item.ToolTipTitle = "Buildings:";
                                e.Item.ToolTipText = "";
                                break;
                            case "unlocking_technologies = ":

                                e.Item.ToolTipTitle = "Buildings:";
                                e.Item.ToolTipText = "";
                                break;
                            case "can_build = ":

                                e.Item.ToolTipTitle = "Buildings:";
                                e.Item.ToolTipText = "";
                                break;
                            case "construction_points = ":

                                e.Item.ToolTipTitle = "Buildings:";
                                e.Item.ToolTipText = "";
                                break;
                            case "construction_modifier = ":

                                e.Item.ToolTipTitle = "Buildings:";
                                e.Item.ToolTipText = "";
                                break;
                            case "owners = ":

                                e.Item.ToolTipTitle = "Buildings:";
                                e.Item.ToolTipText = "";
                                break;
                            case "economic_contribution = ":

                                e.Item.ToolTipTitle = "Buildings:";
                                e.Item.ToolTipText = "";
                                break;
                            case "min_raise_to_hire = ":

                                e.Item.ToolTipTitle = "Buildings:";
                                e.Item.ToolTipText = "";
                                break;
                            case "naval = ":

                                e.Item.ToolTipTitle = "Buildings:";
                                e.Item.ToolTipText = "";
                                break;
                            case "canal = ":

                                e.Item.ToolTipTitle = "Buildings:";
                                e.Item.ToolTipText = "";
                                break;
                            case "ai_value = ":

                                e.Item.ToolTipTitle = "Buildings:";
                                e.Item.ToolTipText = "";
                                break;
                            case "ai_subsidies_weight = ":

                                e.Item.ToolTipTitle = "Buildings:";
                                e.Item.ToolTipText = "";
                                break;
                            case "slaves_role = ":

                                e.Item.ToolTipTitle = "Buildings:";
                                e.Item.ToolTipText = "";
                                break;
                            case "production_method_groups = ":

                                e.Item.ToolTipTitle = "Buildings:";
                                e.Item.ToolTipText = "";
                                break;
                            case "should_auto_expand = ":

                                e.Item.ToolTipTitle = "Buildings:";
                                e.Item.ToolTipText = "";
                                break;
                            case "city_type = ":

                                e.Item.ToolTipTitle = "Buildings:";
                                e.Item.ToolTipText = "";
                                break;
                            case "generates_residences = ":

                                e.Item.ToolTipTitle = "Buildings:";
                                e.Item.ToolTipText = "";
                                break;
                            case "terrain_manipulator = ":

                                e.Item.ToolTipTitle = "Buildings:";
                                e.Item.ToolTipText = "";
                                break;
                            case "levels_per_mesh = ":

                                e.Item.ToolTipTitle = "Buildings:";
                                e.Item.ToolTipText = "";
                                break;
                            case "residence_points_per_level = ":

                                e.Item.ToolTipTitle = "Buildings:";
                                e.Item.ToolTipText = "";
                                break;
                            case "override_centerpiece_mesh = ":

                                e.Item.ToolTipTitle = "Buildings:";
                                e.Item.ToolTipText = "";
                                break;
                            case "centerpiece_mesh_weight = ":

                                e.Item.ToolTipTitle = "Buildings:";
                                e.Item.ToolTipText = "";
                                break;
                            case "meshes = ":

                                e.Item.ToolTipTitle = "Buildings:";
                                e.Item.ToolTipText = "";
                                break;
                            case "entity_not_constructed = ":

                                e.Item.ToolTipTitle = "Buildings:";
                                e.Item.ToolTipText = "";
                                break;
                            case "entity_under_construction = ":

                                e.Item.ToolTipTitle = "Buildings:";
                                e.Item.ToolTipText = "";
                                break;
                            case "entity_constructed = ":

                                e.Item.ToolTipTitle = "Buildings:";
                                e.Item.ToolTipText = "";
                                break;
                            case "locator = ":

                                e.Item.ToolTipTitle = "Buildings:";
                                e.Item.ToolTipText = "";
                                break;
                            case "lens = ":

                                e.Item.ToolTipTitle = "Buildings:";
                                e.Item.ToolTipText = "";
                                break;
                            case "city_gfx_interactions = ":

                                e.Item.ToolTipTitle = "Buildings:";
                                e.Item.ToolTipText = "";
                                break;
                            case "possible = ":

                                e.Item.ToolTipTitle = "Buildings:";
                                e.Item.ToolTipText = "";
                                break;
                            case "recruits_combat_unit = ":

                                e.Item.ToolTipTitle = "Buildings:";
                                e.Item.ToolTipText = "";
                                break;
                        }

                       break;
                    case "Canals":

                        switch (e.Item.ToString())
                        {
                            case "texture = ":

                                e.Item.ToolTipTitle = "Building Groups:";
                                e.Item.ToolTipText = "";
                                break;
                            case "possible = ":

                                e.Item.ToolTipTitle = "Building Groups:";
                                e.Item.ToolTipText = "";
                                break;
                            case "has_technology_researched = ":

                                e.Item.ToolTipTitle = "Building Groups:";
                                e.Item.ToolTipText = "";
                                break;
                            case "owns_treaty_port_in = ":

                                e.Item.ToolTipTitle = "Building Groups:";
                                e.Item.ToolTipText = "";
                                break;
                            case "state_region = ":

                                e.Item.ToolTipTitle = "Building Groups:";
                                e.Item.ToolTipText = "";
                                break;

                        }

                        break;
                    case "Cultures":

                        switch (e.Item.ToString())
                        {
                            case "color = ":

                                e.Item.ToolTipTitle = "Cultures:";
                                e.Item.ToolTipText = "";
                                break;
                            case "religion = ":

                                e.Item.ToolTipTitle = "Cultures:";
                                e.Item.ToolTipText = "";
                                break;
                            case "traits = ":

                                e.Item.ToolTipTitle = "Cultures:";
                                e.Item.ToolTipText = "";
                                break;
                            case "male_common_first_names = ":

                                e.Item.ToolTipTitle = "Cultures:";
                                e.Item.ToolTipText = "";
                                break;
                            case "female_common_first_names = ":

                                e.Item.ToolTipTitle = "Cultures:";
                                e.Item.ToolTipText = "";
                                break;
                            case "noble_last_names = ":

                                e.Item.ToolTipTitle = "Cultures:";
                                e.Item.ToolTipText = "";
                                break;
                            case "common_last_names = ":

                                e.Item.ToolTipTitle = "Cultures:";
                                e.Item.ToolTipText = "";
                                break;
                            case "male_regal_first_names = ":

                                e.Item.ToolTipTitle = "Cultures:";
                                e.Item.ToolTipText = "";
                                break;
                            case "female_regal_first_names = ":

                                e.Item.ToolTipTitle = "Cultures:";
                                e.Item.ToolTipText = "";
                                break;
                            case "regal_last_names = ":

                                e.Item.ToolTipTitle = "Cultures:";
                                e.Item.ToolTipText = "";
                                break;
                            case "graphics = ":

                                e.Item.ToolTipTitle = "Cultures:";
                                e.Item.ToolTipText = "";
                                break;
                            case "ethnicities = ":

                                e.Item.ToolTipTitle = "Cultures:";
                                e.Item.ToolTipText = "";
                                break;
                            
                        }

                        break;


                    case "Decisions":

                        switch (e.Item.ToString())
                        {
                            case "is_shown = ":

                                e.Item.ToolTipTitle = "Decisions:";
                                e.Item.ToolTipText = "";
                                break;

                            case "possible = ":

                                e.Item.ToolTipTitle = "Decisions:";
                                e.Item.ToolTipText = "";
                                break;
                            case "when_taken = ":

                                e.Item.ToolTipTitle = "Decisions:";
                                e.Item.ToolTipText = "";
                                break;
                            case "ai_chance = ":

                                e.Item.ToolTipTitle = "Decisions:";
                                e.Item.ToolTipText = "";
                                break;
                        }

                        break;

                    case "Decrees":

                        switch (e.Item.ToString())
                        {
                            case "texture = ":

                                e.Item.ToolTipTitle = "Decrees:";
                                e.Item.ToolTipText = "";
                                break;

                            case "modifier = ":

                                e.Item.ToolTipTitle = "Decrees:";
                                e.Item.ToolTipText = "";
                                break;
                            case "unlocking_technologies = ":

                                e.Item.ToolTipTitle = "Decrees:";
                                e.Item.ToolTipText = "";
                                break;
                            case "valid = ":

                                e.Item.ToolTipTitle = "Decrees:";
                                e.Item.ToolTipText = "";
                                break;
                            case "cost = ":

                                e.Item.ToolTipTitle = "Decrees:";
                                e.Item.ToolTipText = "";
                                break;
                            case "ai_weight = ":

                                e.Item.ToolTipTitle = "Decrees:";
                                e.Item.ToolTipText = "";
                                break;
                        }

                        break;

                    case "Eras": // Era

                        switch (e.Item.ToString())
                        {
                            case "technology_cost = ":

                                e.Item.ToolTipTitle = "Eras:";
                                e.Item.ToolTipText = "The cost of the tecnology in this era: e.g. Era 1 -> 5000 / Era 2 -> 7500.";
                                break;

                            case "era_":

                                e.Item.ToolTipTitle = "Eras:";
                                e.Item.ToolTipText = "era_X being X the era number.";
                                break;
                        }

                        break;

                    case "Goods": // Goods

                        switch (e.Item.ToString())
                        {
                            case "texture = ":

                                e.Item.ToolTipTitle = "Goods:";
                                e.Item.ToolTipText = "";
                                break;

                            case "cost = ":

                                e.Item.ToolTipTitle = "Goods:";
                                e.Item.ToolTipText = "";
                                break;
                            case "category = ":

                                e.Item.ToolTipTitle = "Goods:";
                                e.Item.ToolTipText = "";
                                break;
                            case "prestige_factor = ":

                                e.Item.ToolTipTitle = "Goods:";
                                e.Item.ToolTipText = "";
                                break;
                            case "traded_quantity = ":

                                e.Item.ToolTipTitle = "Goods:";
                                e.Item.ToolTipText = "";
                                break;
                            case "convoy_cost_multiplier = ":

                                e.Item.ToolTipTitle = "Goods:";
                                e.Item.ToolTipText = "";
                                break;
                            case "consumption_tax_cost = ":

                                e.Item.ToolTipTitle = "Goods:";
                                e.Item.ToolTipText = "";
                                break;
                            case "tradeable = ":

                                e.Item.ToolTipTitle = "Goods:";
                                e.Item.ToolTipText = "";
                                break;
                            case "fixed_price = ":

                                e.Item.ToolTipTitle = "Goods:";
                                e.Item.ToolTipText = "";
                                break;
                            case "obsession_chance = ":

                                e.Item.ToolTipTitle = "Goods:";
                                e.Item.ToolTipText = "";
                                break;
                        }

                        break;

                    case "Institutions": // Institutions

                        switch (e.Item.ToString())
                        {
                            case "icon = ":

                                e.Item.ToolTipTitle = "Institutions:";
                                e.Item.ToolTipText = "";
                                break;

                            case "background_texture = ":

                                e.Item.ToolTipTitle = "Institutions:";
                                e.Item.ToolTipText = "";
                                break;

                            case "modifier = ":

                                e.Item.ToolTipTitle = "Institutions:";
                                e.Item.ToolTipText = "";
                                break;
                        }

                        break;

                    case "Law Groups": 

                        switch (e.Item.ToString())
                        {
                            case "law_group_category = ":

                                e.Item.ToolTipTitle = "Law Groups:";
                                e.Item.ToolTipText = "";
                                break;

                            case "base_enactment_days = ":

                                e.Item.ToolTipTitle = "Law Groups:";
                                e.Item.ToolTipText = "";
                                break;

                            case "enactment_approval_mult = ":

                                e.Item.ToolTipTitle = "Law Groups:";
                                e.Item.ToolTipText = "";
                                break;

                            case "progressive_movement_chance = ":

                                e.Item.ToolTipTitle = "Law Groups:";
                                e.Item.ToolTipText = "";
                                break;

                            case "regressive_movement_chance = ":

                                e.Item.ToolTipTitle = "Law Groups:";
                                e.Item.ToolTipText = "";
                                break;

                            case "change_allowed_trigger = ":

                                e.Item.ToolTipTitle = "Law Groups:";
                                e.Item.ToolTipText = "";
                                break;
                        }

                        break;

                    case "Laws":

                        switch (e.Item.ToString())
                        {
                            case "group = ":

                                e.Item.ToolTipTitle = "Laws:";
                                e.Item.ToolTipText = "";
                                break;

                            case "icon = ":

                                e.Item.ToolTipTitle = "Laws:";
                                e.Item.ToolTipText = "";
                                break;

                            case "progressiveness = ":

                                e.Item.ToolTipTitle = "Laws:";
                                e.Item.ToolTipText = "";
                                break;

                            case "unlocking_laws = ":

                                e.Item.ToolTipTitle = "Laws:";
                                e.Item.ToolTipText = "";
                                break;
                            case "is_visible = ":

                                e.Item.ToolTipTitle = "Laws:";
                                e.Item.ToolTipText = "";
                                break;

                            case "on_activate = ":

                                e.Item.ToolTipTitle = "Laws:";
                                e.Item.ToolTipText = "";
                                break;

                            case "on_deactivate = ":

                                e.Item.ToolTipTitle = "Laws:";
                                e.Item.ToolTipText = "";
                                break;

                            case "unlocking_technologies = ":

                                e.Item.ToolTipTitle = "Laws:";
                                e.Item.ToolTipText = "";
                                break;

                            case "modifier = ":

                                e.Item.ToolTipTitle = "Laws:";
                                e.Item.ToolTipText = "";
                                break;

                            case "build_from_investment_pool = ":

                                e.Item.ToolTipTitle = "Laws:";
                                e.Item.ToolTipText = "";
                                break;
                            case "institution = ":

                                e.Item.ToolTipTitle = "Laws:";
                                e.Item.ToolTipText = "";
                                break;

                            case "institution_modifier = ":

                                e.Item.ToolTipTitle = "Laws:";
                                e.Item.ToolTipText = "";
                                break;

                            case "disallowing_laws = ":

                                e.Item.ToolTipTitle = "Laws:";
                                e.Item.ToolTipText = "";
                                break;

                            case "on_enact = ":

                                e.Item.ToolTipTitle = "Laws:";
                                e.Item.ToolTipText = "";
                                break;

                            case "cultural_acceptance_rule = ":

                                e.Item.ToolTipTitle = "Laws:";
                                e.Item.ToolTipText = "";
                                break;

                            case "religious_acceptance_rule = ":

                                e.Item.ToolTipTitle = "Laws:";
                                e.Item.ToolTipText = "";
                                break;
                            case "possible_political_movements = ":

                                e.Item.ToolTipTitle = "Laws:";
                                e.Item.ToolTipText = "";
                                break;

                            case "pop_support = ":

                                e.Item.ToolTipTitle = "Laws:";
                                e.Item.ToolTipText = "";
                                break;

                            case "ai_will_do = ":

                                e.Item.ToolTipTitle = "Laws:";
                                e.Item.ToolTipText = "";
                                break;

                            case "revolution_state_weight = ":

                                e.Item.ToolTipTitle = "Laws:";
                                e.Item.ToolTipText = "";
                                break;

                            case "tax_modifier_very_low = ":

                                e.Item.ToolTipTitle = "Laws:";
                                e.Item.ToolTipText = "";
                                break;

                            case "tax_modifier_low = ":

                                e.Item.ToolTipTitle = "Laws:";
                                e.Item.ToolTipText = "";
                                break;
                            case "tax_modifier_medium = ":

                                e.Item.ToolTipTitle = "Laws:";
                                e.Item.ToolTipText = "";
                                break;

                            case "tax_modifier_high = ":

                                e.Item.ToolTipTitle = "Laws:";
                                e.Item.ToolTipText = "";
                                break;

                            case "tax_modifier_very_high = ":

                                e.Item.ToolTipTitle = "Laws:";
                                e.Item.ToolTipText = "";
                                break;

                            case "tariff_modifier_no_priority = ":

                                e.Item.ToolTipTitle = "Laws:";
                                e.Item.ToolTipText = "";
                                break;

                            case "tariff_modifier_export_priority = ":

                                e.Item.ToolTipTitle = "Laws:";
                                e.Item.ToolTipText = "";
                                break;

                            case "tariff_modifier_import_priority = ":

                                e.Item.ToolTipTitle = "Laws:";
                                e.Item.ToolTipText = "";
                                break;
                            case "can_enact = ":

                                e.Item.ToolTipTitle = "Laws:";
                                e.Item.ToolTipText = "";
                                break;
                        }

                        break;

                    case "Modifiers": // Modifiers

                        switch (e.Item.ToString())
                        {
                            case "icon = ":

                                e.Item.ToolTipTitle = "Modifier:";
                                e.Item.ToolTipText = "";
                                break;
                        }

                        break;

                    case "Modifier Types": // ModifierTypes

                        switch (e.Item.ToString())
                        {
                            case "good = ":

                                e.Item.ToolTipTitle = "Modifier Types:";
                                e.Item.ToolTipText = "";
                                break;

                            case "percent = ":

                                e.Item.ToolTipTitle = "Modifier Types:";
                                e.Item.ToolTipText = "";
                                break;
                            case "num_decimals = ":

                                e.Item.ToolTipTitle = "Modifier Types:";
                                e.Item.ToolTipText = "";
                                break;
                            case "invert = ":

                                e.Item.ToolTipTitle = "Modifier Types:";
                                e.Item.ToolTipText = "";
                                break;
                            case "neutral = ":

                                e.Item.ToolTipTitle = "Modifier Types:";
                                e.Item.ToolTipText = "";
                                break;
                            case "boolean = ":

                                e.Item.ToolTipTitle = "Modifier Types:";
                                e.Item.ToolTipText = "";
                                break;
                            case "postfix = ":

                                e.Item.ToolTipTitle = "Modifier Types:";
                                e.Item.ToolTipText = "";
                                break;
                            case "translate = ":

                                e.Item.ToolTipTitle = "Modifier Types:";
                                e.Item.ToolTipText = "";
                                break;
                            case "ai_value = ":

                                e.Item.ToolTipTitle = "Modifier Types:";
                                e.Item.ToolTipText = "";
                                break;
                        }

                        break;

                    case "Pop Needs": // PopNeeds

                        switch (e.Item.ToString())
                        {
                            case "goods = ":

                                e.Item.ToolTipTitle = "Pop Needs:";
                                e.Item.ToolTipText = "";
                                break;

                            case "weight = ":

                                e.Item.ToolTipTitle = "Pop Needs:";
                                e.Item.ToolTipText = "";
                                break;
                            case "max_weight = ":

                                e.Item.ToolTipTitle = "Pop Needs:";
                                e.Item.ToolTipText = "";
                                break;
                            case "min_weight = ":

                                e.Item.ToolTipTitle = "Pop Needs:";
                                e.Item.ToolTipText = "";
                                break;
                            case "default = ":

                                e.Item.ToolTipTitle = "Pop Needs:";
                                e.Item.ToolTipText = "";
                                break;
                            case "entry = ":

                                e.Item.ToolTipTitle = "Pop Needs:";
                                e.Item.ToolTipText = "";
                                break;
                        }

                        break;

                    case "Pop Types": // PopNeeds

                        switch (e.Item.ToString())
                        {
                            case "texture = ":

                                e.Item.ToolTipTitle = "Pop Types:";
                                e.Item.ToolTipText = "";
                                break;

                            case "color = ":

                                e.Item.ToolTipTitle = "Pop Types:";
                                e.Item.ToolTipText = "";
                                break;
                            case "strata = ":

                                e.Item.ToolTipTitle = "Pop Types:";
                                e.Item.ToolTipText = "";
                                break;
                            case "subsistence_income = ":

                                e.Item.ToolTipTitle = "Pop Types:";
                                e.Item.ToolTipText = "";
                                break;
                            case "is_slave = ":

                                e.Item.ToolTipTitle = "Pop Types:";
                                e.Item.ToolTipText = "";
                                break;
                            case "start_quality_of_life = ":

                                e.Item.ToolTipTitle = "Pop Types:";
                                e.Item.ToolTipText = "";
                                break;
                            case "can_always_hire = ":

                                e.Item.ToolTipTitle = "Pop Types:";
                                e.Item.ToolTipText = "";
                                break;

                            case "ignores_employment_proportionality = ":

                                e.Item.ToolTipTitle = "Pop Types:";
                                e.Item.ToolTipText = "";
                                break;
                            case "working_adult_ratio = ":

                                e.Item.ToolTipTitle = "Pop Types:";
                                e.Item.ToolTipText = "";
                                break;
                            case "wage_weight = ":

                                e.Item.ToolTipTitle = "Pop Types:";
                                e.Item.ToolTipText = "";
                                break;
                            case "consumption_mult = ":

                                e.Item.ToolTipTitle = "Pop Types:";
                                e.Item.ToolTipText = "";
                                break;
                            case "literacy_target = ":

                                e.Item.ToolTipTitle = "Pop Types:";
                                e.Item.ToolTipText = "";
                                break;
                            case "education_access = ":

                                e.Item.ToolTipTitle = "Pop Types:";
                                e.Item.ToolTipText = "";
                                break;

                            case "dependent_wage = ":

                                e.Item.ToolTipTitle = "Pop Types:";
                                e.Item.ToolTipText = "";
                                break;
                            case "unemployment = ":

                                e.Item.ToolTipTitle = "Pop Types:";
                                e.Item.ToolTipText = "";
                                break;
                            case "unemployment_wealth = ":

                                e.Item.ToolTipTitle = "Pop Types:";
                                e.Item.ToolTipText = "";
                                break;
                            case "political_engagement_base = ":

                                e.Item.ToolTipTitle = "Pop Types:";
                                e.Item.ToolTipText = "";
                                break;
                            case "political_engagement_literacy_factor = ":

                                e.Item.ToolTipTitle = "Pop Types:";
                                e.Item.ToolTipText = "";
                                break;
                            case "political_engagement_mult = ":

                                e.Item.ToolTipTitle = "Pop Types:";
                                e.Item.ToolTipText = "";
                                break;
                            case "qualifications_growth_desc = ":

                                e.Item.ToolTipTitle = "Pop Types:";
                                e.Item.ToolTipText = "";
                                break;

                            case "qualifications = ":

                                e.Item.ToolTipTitle = "Pop Types:";
                                e.Item.ToolTipText = "";
                                break;
                            case "portrait_age = ":

                                e.Item.ToolTipTitle = "Pop Types:";
                                e.Item.ToolTipText = "";
                                break;
                            case "portrait_pose = ":

                                e.Item.ToolTipTitle = "Pop Types:";
                                e.Item.ToolTipText = "";
                                break;
                            case "portrait_is_female = ":

                                e.Item.ToolTipTitle = "Pop Types:";
                                e.Item.ToolTipText = "";
                                break;
                        }

                        break;

                    case "Religions": // Religions

                        switch (e.Item.ToString())
                        {
                            case "texture = ":

                                e.Item.ToolTipTitle = "Religion:";
                                e.Item.ToolTipText = "";
                                break;

                            case "color = ":

                                e.Item.ToolTipTitle = "Religion:";
                                e.Item.ToolTipText = "";
                                break;
                            case "traits = ":

                                e.Item.ToolTipTitle = "Religion:";
                                e.Item.ToolTipText = "";
                                break;

                            case "taboos = ":

                                e.Item.ToolTipTitle = "Religion:";
                                e.Item.ToolTipText = "";
                                break;
                        }

                        break;

                    case "State Traits": // StateTraits

                        switch (e.Item.ToString())
                        {
                            case "icon = ":

                                e.Item.ToolTipTitle = "State Traits:";
                                e.Item.ToolTipText = "";
                                break;

                            case "disabling_technologies = ":

                                e.Item.ToolTipTitle = "State Traits:";
                                e.Item.ToolTipText = "";
                                break;
                            case "required_techs_for_colonization = ":

                                e.Item.ToolTipTitle = "State Traits:";
                                e.Item.ToolTipText = "";
                                break;

                            case "modifier = ":

                                e.Item.ToolTipTitle = "State Traits:";
                                e.Item.ToolTipText = "";
                                break;
                        }

                        break;

                    case "Technologies": // Technology

                        switch (e.Item.ToString())
                        {
                            case "era = ":

                                e.Item.ToolTipTitle = "Technology:";
                                e.Item.ToolTipText = "";
                                break;

                            case "texture = ":

                                e.Item.ToolTipTitle = "Technology:";
                                e.Item.ToolTipText = "";
                                break;
                            case "category = ":

                                e.Item.ToolTipTitle = "Technology:";
                                e.Item.ToolTipText = "";
                                break;
                            case "can_research = ":

                                e.Item.ToolTipTitle = "Technology:";
                                e.Item.ToolTipText = "";
                                break;
                            case "modifier = ":

                                e.Item.ToolTipTitle = "Technology:";
                                e.Item.ToolTipText = "";
                                break;
                            case "unlocking_technologies = ":

                                e.Item.ToolTipTitle = "Technology:";
                                e.Item.ToolTipText = "";
                                break;
                        }

                        break;

                }
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Debug and error detection
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void MonoElementDebug_Click(object sender, EventArgs e)
        {

        }

        // *
        private void DebugBT_Click(object sender, EventArgs e)
        {
            DebugTB.Text = "";
            Debugger.DebugTB = DebugTB;
            Debugger.scintilla = scintilla;
            Debugger.MonoElementDebug = MonoElementDebug;
            intString[] info;

            List<ClassModifiersType>  ModifierTypeDataP = new List<ClassModifiersType>();
            List<ClassModifiersType>  ModifierTypeDataV = new List<ClassModifiersType>();

            Functions.ReadFilesCommon(VickyPath + "\\game\\common\\modifier_types", ModifierTypeDataV, new Parser(), s => new ClassModifiersType(s), t => t.Name);
            if (!projIsNULL)
            {
                Functions.ReadFilesCommon(ProjPath + "\\common\\modifier_types", ModifierTypeDataP, new Parser(), s => new ClassModifiersType(s), t => t.Name);
            }


            switch (currentMode)
            {
                case "Null":
                    DebugTB.Text = "Select a mode";
                    break;

                case "Building Groups":
                    info = new intString[23];
                    info[0] = new intString(1101, "parent_group");
                    info[1] = new intString(1101, "category");
                    info[2] = new intString(1110, "always_possible");
                    info[3] = new intString(1110, "economy_of_scale");
                    info[4] = new intString(1110, "is_subsistence");
                    info[5] = new intString(1101, "default_building");
                    info[6] = new intString(1101, "lens");
                    info[7] = new intString(1110, "auto_place_buildings");
                    info[8] = new intString(1110, "capped_by_resources");
                    info[9] = new intString(1110, "discoverable_resource");
                    info[10] = new intString(1110, "depletable_resource");
                    info[11] = new intString(1110, "can_use_slaves");
                    info[12] = new intString(1101, "land_usage");
                    info[13] = new intString(1111, "cash_reserves_max");
                    info[14] = new intString(1110, "inheritable_construction");
                    info[15] = new intString(1110, "stateregion_max_level");
                    info[16] = new intString(1111, "urbanization");
                    info[17] = new intString(1105, "should_auto_expand");
                    info[18] = new intString(1111, "hiring_rate");
                    info[19] = new intString(1111, "proportionality_limit");
                    info[20] = new intString(1110, "hires_unemployed_only");
                    info[21] = new intString(1111, "infrastructure_usage_per_level");
                    info[22] = new intString(1110, "fired_pops_become_radical ");

                    if (!projIsNULL)
                    { Debugger.DebugTreatment(info, Functions.MergeClasses(ModifierTypeDataP, ModifierTypeDataV)); }
                    else { Debugger.DebugTreatment(info, ModifierTypeDataV); }
                    break;

                case "Buildings":
                    info = new intString[41];
                    info[0] = new intString(0101, "building_group");
                    info[1] = new intString(1104, "texture");
                    info[2] = new intString(1101, "required_construction");
                    info[3] = new intString(1110, "buildable");
                    info[4] = new intString(1110, "expandable");
                    info[5] = new intString(1110, "downsizeable");
                    info[6] = new intString(1110, "unique");
                    info[7] = new intString(1110, "has_max_level");
                    info[8] = new intString(1110, "ignore_stateregion_max_level");
                    info[9] = new intString(1110, "enable_air_connection");
                    info[10] = new intString(1110, "port");
                    info[11] = new intString(1119, "unlocking_technologies");
                    info[12] = new intString(1105, "can_build");
                    info[13] = new intString(1111, "construction_points");
                    info[14] = new intString(1105, "construction_modifier");
                    info[15] = new intString(1101, "owners");
                    info[16] = new intString(1111, "economic_contribution");
                    info[17] = new intString(1111, "min_raise_to_hire");
                    info[18] = new intString(1110, "naval");
                    info[19] = new intString(1101, "canal");
                    info[20] = new intString(1111, "ai_value");
                    info[21] = new intString(1111, "ai_subsidies_weight");
                    info[22] = new intString(1101, "slaves_role");
                    info[23] = new intString(0105, "production_method_groups");
                    info[24] = new intString(1105, "should_auto_expand");
                    info[25] = new intString(1101, "city_type");
                    info[26] = new intString(1110, "generates_residences");
                    info[27] = new intString(1101, "terrain_manipulator");
                    info[28] = new intString(1111, "levels_per_mesh");
                    info[29] = new intString(1110, "residence_points_per_level");
                    info[30] = new intString(1110, "override_centerpiece_mesh");
                    info[31] = new intString(1111, "centerpiece_mesh_weight");
                    info[32] = new intString(1105, "meshes");
                    info[33] = new intString(1120, "entity_not_constructed");
                    info[34] = new intString(1120, "entity_under_construction");
                    info[35] = new intString(1120, "entity_constructed");
                    info[36] = new intString(1104, "locator");
                    info[37] = new intString(1101, "lens");
                    info[38] = new intString(1105, "city_gfx_interactions");
                    info[39] = new intString(1105, "possible");
                    info[40] = new intString(1101, "recruits_combat_unit");

                    if (!projIsNULL)
                    { Debugger.DebugTreatment(info, Functions.MergeClasses(ModifierTypeDataP, ModifierTypeDataV)); }
                    else { Debugger.DebugTreatment(info, ModifierTypeDataV); }
                    break;

                case "Canals":
                    info = new intString[4];
                    info[0] = new intString(0104, "texture");
                    info[1] = new intString(0105, "possible");
                    info[2] = new intString(1119, "has_technology_researched");
                    info[3] = new intString(0101, "state_region");

                    if (!projIsNULL)
                    { Debugger.DebugTreatment(info, Functions.MergeClasses(ModifierTypeDataP, ModifierTypeDataV)); }
                    else { Debugger.DebugTreatment(info, ModifierTypeDataV); }
                    break;

                case "Cultures":
                    info = new intString[12];
                    info[0] = new intString(0118, "color");
                    info[1] = new intString(0101, "religion");
                    info[2] = new intString(0119, "traits");
                    info[3] = new intString(0105, "male_common_first_names");
                    info[4] = new intString(0105, "female_common_first_names");
                    info[5] = new intString(0105, "noble_last_names");
                    info[6] = new intString(0105, "common_last_names");
                    info[7] = new intString(1105, "male_regal_first_names");
                    info[8] = new intString(1105, "female_regal_first_names");
                    info[9] = new intString(1105, "regal_last_names");
                    info[10] = new intString(0101, "graphics");
                    info[11] = new intString(0105, "ethnicities");

                    if (!projIsNULL)
                    { Debugger.DebugTreatment(info, Functions.MergeClasses(ModifierTypeDataP, ModifierTypeDataV)); }
                    else { Debugger.DebugTreatment(info, ModifierTypeDataV); }
                    break;

                case "Decisions":
                    info = new intString[4];
                    info[0] = new intString(0105, "is_shown");
                    info[1] = new intString(0105, "possible");
                    info[2] = new intString(0105, "when_taken");
                    info[3] = new intString(0105, "ai_chance");

                    if (!projIsNULL)
                    { Debugger.DebugTreatment(info, Functions.MergeClasses(ModifierTypeDataP, ModifierTypeDataV));}
                    else { Debugger.DebugTreatment(info, ModifierTypeDataV); }
                    break;

                case "Decrees":
                    info = new intString[6];
                    info[0] = new intString(0104, "texture");
                    info[1] = new intString(1105, "modifier");
                    info[2] = new intString(1105, "unlocking_technologies");
                    info[3] = new intString(1105, "valid");
                    info[4] = new intString(0111, "cost");
                    info[5] = new intString(0105, "ai_weight");

                    if (!projIsNULL)
                    { Debugger.DebugTreatment(info, Functions.MergeClasses(ModifierTypeDataP, ModifierTypeDataV)); }
                    else { Debugger.DebugTreatment(info, ModifierTypeDataV); }
                    break;

                case "Eras": // Era
                    info = new intString[2];
                    info[0] = new intString(0111, "technology_cost");
                    info[1] = new intString(0009, "era_");

                    if (!projIsNULL)
                    { Debugger.DebugTreatment(info, Functions.MergeClasses(ModifierTypeDataP, ModifierTypeDataV)); }
                    else { Debugger.DebugTreatment(info, ModifierTypeDataV); }
                    break;

                case "Goods": // Goods
                    info = new intString[10];
                    info[0] = new intString(0104, "texture");
                    info[1] = new intString(0111, "cost");
                    info[2] = new intString(0101, "category");
                    info[3] = new intString(0111, "prestige_factor");
                    info[4] = new intString(1110, "tradeable");
                    info[5] = new intString(1110, "fixed_price");
                    info[6] = new intString(1111, "obsession_chance");
                    info[7] = new intString(1111, "traded_quantity");
                    info[8] = new intString(1111, "convoy_cost_multiplier");
                    info[9] = new intString(1111, "consumption_tax_cost");

                    if (!projIsNULL)
                    { Debugger.DebugTreatment(info, Functions.MergeClasses(ModifierTypeDataP, ModifierTypeDataV)); }
                    else { Debugger.DebugTreatment(info, ModifierTypeDataV); }
                    break;

                case "Institutions": // Institutions
                    info = new intString[3];
                    info[0] = new intString(0104, "icon");
                    info[1] = new intString(0104, "background_texture");
                    info[2] = new intString(1105, "modifier");

                    if (!projIsNULL)
                    { Debugger.DebugTreatment(info, Functions.MergeClasses(ModifierTypeDataP, ModifierTypeDataV)); }
                    else { Debugger.DebugTreatment(info, ModifierTypeDataV); }
                    break;

                case "Law Groups":
                    info = new intString[6];
                    info[0] = new intString(0101, "law_group_category");
                    info[1] = new intString(1111, "base_enactment_days");
                    info[2] = new intString(1111, "enactment_approval_mult");
                    info[3] = new intString(0111, "progressive_movement_chance");
                    info[4] = new intString(0111, "regressive_movement_chance");
                    info[5] = new intString(1105, "change_allowed_trigger");

                    if (!projIsNULL)
                    { Debugger.DebugTreatment(info, Functions.MergeClasses(ModifierTypeDataP, ModifierTypeDataV)); }
                    else { Debugger.DebugTreatment(info, ModifierTypeDataV); }
                    break;

                case "Laws":
                    info = new intString[29];
                    info[0] = new intString(0101, "group");
                    info[1] = new intString(0104, "icon");
                    info[2] = new intString(0111, "progressiveness");
                    info[3] = new intString(1105, "unlocking_laws");
                    info[4] = new intString(1105, "is_visible"); 
                    info[5] = new intString(1105, "on_activate");
                    info[6] = new intString(1105, "on_deactivate");
                    info[7] = new intString(1105, "unlocking_technologies");
                    info[8] = new intString(1105, "modifier");
                    info[9] = new intString(1105, "build_from_investment_pool");
                    info[10] = new intString(1101, "institution");
                    info[11] = new intString(1105, "institution_modifier");
                    info[12] = new intString(1105, "disallowing_laws");
                    info[13] = new intString(1105, "on_enact");
                    info[14] = new intString(1105, "cultural_acceptance_rule");
                    info[15] = new intString(1105, "religious_acceptance_rule");
                    info[16] = new intString(1105, "possible_political_movements");
                    info[17] = new intString(1105, "pop_support"); 
                    info[18] = new intString(1105, "ai_will_do");
                    info[19] = new intString(1105, "revolution_state_weight"); 
                    info[20] = new intString(1105, "tax_modifier_very_low");
                    info[21] = new intString(1105, "tax_modifier_low");
                    info[22] = new intString(1105, "tax_modifier_medium ");
                    info[23] = new intString(1105, "tax_modifier_high ");
                    info[24] = new intString(1105, "tax_modifier_very_high");
                    info[25] = new intString(1105, "tariff_modifier_no_priority ");
                    info[26] = new intString(1105, "tariff_modifier_export_priority ");
                    info[27] = new intString(1105, "tariff_modifier_import_priority");
                    info[28] = new intString(1105, "can_enact");

                    if (!projIsNULL)
                    { Debugger.DebugTreatment(info, Functions.MergeClasses(ModifierTypeDataP, ModifierTypeDataV)); }
                    else { Debugger.DebugTreatment(info, ModifierTypeDataV); }
                    break;

                case "Modifiers": // Modifiers
                    info = new intString[2];
                    info[0] = new intString(1104, "icon");
                    info[1] = new intString(1115, "modifier");

                    if (!projIsNULL)
                    { Debugger.DebugTreatment(info, Functions.MergeClasses(ModifierTypeDataP, ModifierTypeDataV)); }
                    else { Debugger.DebugTreatment(info, ModifierTypeDataV); }
                    break;

                case "Modifier Types": // ModifierTypes
                    info = new intString[9];
                    info[0] = new intString(1110, "good");
                    info[1] = new intString(1110, "percent");
                    info[2] = new intString(1111, "num_decimals");
                    info[3] = new intString(1110, "invert");
                    info[4] = new intString(1110, "neutral");
                    info[5] = new intString(1110, "boolean");
                    info[6] = new intString(1104, "postfix");
                    info[7] = new intString(1101, "translate");
                    info[8] = new intString(1111, "ai_value");

                    if (!projIsNULL)
                    { Debugger.DebugTreatment(info, Functions.MergeClasses(ModifierTypeDataP, ModifierTypeDataV)); }
                    else { Debugger.DebugTreatment(info, ModifierTypeDataV); }
                    break;

                case "Pop Needs": // PopNeeds
                    info = new intString[2];
                    info[0] = new intString(0101, "default");
                    info[1] = new intString(0113, "entry");

                    if (!projIsNULL)
                    { Debugger.DebugTreatment(info, Functions.MergeClasses(ModifierTypeDataP, ModifierTypeDataV)); }
                    else { Debugger.DebugTreatment(info, ModifierTypeDataV); }
                    break;

                case "Pop Types": // PopNeeds
                    info = new intString[24];
                    info[0] = new intString(0104, "texture");
                    info[1] = new intString(0118, "color");
                    info[2] = new intString(0101, "strata");
                    info[3] = new intString(1110, "subsistence_income");
                    info[4] = new intString(1110, "is_slave");
                    info[5] = new intString(0111, "start_quality_of_life");
                    info[6] = new intString(1110, "can_always_hire");
                    info[7] = new intString(1110, "ignores_employment_proportionality"); 
                    info[8] = new intString(1111, "working_adult_ratio");
                    info[9] = new intString(0111, "wage_weight");
                    info[10] = new intString(1111, "consumption_mult"); 
                    info[11] = new intString(1111, "literacy_target");
                    info[12] = new intString(1111, "education_access");
                    info[13] = new intString(0111, "dependent_wage");
                    info[14] = new intString(0110, "unemployment");
                    info[15] = new intString(1111, "unemployment_wealth");
                    info[16] = new intString(0111, "political_engagement_base");
                    info[17] = new intString(0111, "political_engagement_literacy_factor");
                    info[18] = new intString(0105, "political_engagement_mult");
                    info[19] = new intString(1104, "qualifications_growth_desc");
                    info[20] = new intString(1105, "qualifications");
                    info[21] = new intString(0105, "portrait_age");
                    info[22] = new intString(0117, "portrait_pose"); 
                    info[23] = new intString(0117, "portrait_is_female");


                    if (!projIsNULL)
                    { Debugger.DebugTreatment(info, Functions.MergeClasses(ModifierTypeDataP, ModifierTypeDataV)); }
                    else { Debugger.DebugTreatment(info, ModifierTypeDataV); }
                    break;

                case "Production Method Groups":
                    info = new intString[4];
                    info[0] = new intString(0104, "texture");
                    info[1] = new intString(1101, "ai_selection");
                    info[2] = new intString(1110, "is_hidden_when_unavailable");
                    info[3] = new intString(0105, "production_methods");

                    if (!projIsNULL)
                    { Debugger.DebugTreatment(info, Functions.MergeClasses(ModifierTypeDataP, ModifierTypeDataV)); }
                    else { Debugger.DebugTreatment(info, ModifierTypeDataV); }
                    break;

                case "Production Methods":
                    info = new intString[18];
                    info[0] = new intString(0104, "texture");
                    info[1] = new intString(1110, "is_default");
                    info[2] = new intString(1110, "low_pop_method");
                    info[3] = new intString(1111, "ai_value");
                    info[4] = new intString(1111, "pollution_generation");
                    info[5] = new intString(1119, "unlocking_technologies");
                    info[6] = new intString(1119, "unlocking_glogal_technologies");
                    info[7] = new intString(1105, "building_modifiers");
                    info[8] = new intString(1105, "state_modifiers");
                    info[9] = new intString(1105, "country_modifiers");
                    info[10] = new intString(1205, "workforce_scaled");
                    info[11] = new intString(1205, "level_scaled");
                    info[12] = new intString(1205, "unscaled");
                    info[13] = new intString(1105, "timed_modifiers");
                    info[14] = new intString(1119, "unlocking_laws");
                    info[15] = new intString(1119, "disallowing_laws");
                    info[16] = new intString(1119, "unlocking_religions");
                    info[17] = new intString(1105, "unlocking_production_methods");


                    if (!projIsNULL)
                    { Debugger.DebugTreatment(info, Functions.MergeClasses(ModifierTypeDataP, ModifierTypeDataV)); }
                    else { Debugger.DebugTreatment(info, ModifierTypeDataV); }
                    break;

                case "Religions": // Religions
                    info = new intString[4];
                    info[0] = new intString(0104, "texture");
                    info[1] = new intString(0105, "traits");
                    info[2] = new intString(0102, "color");
                    info[3] = new intString(1105, "taboos");

                    if (!projIsNULL)
                    { Debugger.DebugTreatment(info, Functions.MergeClasses(ModifierTypeDataP, ModifierTypeDataV)); }
                    else { Debugger.DebugTreatment(info, ModifierTypeDataV); }
                    break;

                case "State Traits": // StateTraits
                    info = new intString[5];
                    info[0] = new intString(0104, "icon");
                    info[1] = new intString(0105, "modifier");
                    info[2] = new intString(1215, "modifier");
                    info[3] = new intString(1112, "disabling_technologies");
                    info[4] = new intString(1112, "required_techs_for_colonization");

                    if (!projIsNULL)
                    { Debugger.DebugTreatment(info, Functions.MergeClasses(ModifierTypeDataP, ModifierTypeDataV)); }
                    else { Debugger.DebugTreatment(info, ModifierTypeDataV); }
                    break;

                case "Technologies": // Technology
                    info = new intString[7];
                    info[0] = new intString(0114, "era");
                    info[1] = new intString(0104, "texture");
                    info[2] = new intString(0101, "category");
                    info[3] = new intString(1110, "can_research");
                    info[4] = new intString(1105, "modifier");
                    info[5] = new intString(1215, "modifier");
                    info[6] = new intString(1105, "unlocking_technologies");

                    if (!projIsNULL)
                    { Debugger.DebugTreatment(info, Functions.MergeClasses(ModifierTypeDataP, ModifierTypeDataV)); }
                    else { Debugger.DebugTreatment(info, ModifierTypeDataV); }
                    break;

            }

            if (DebugTB.Text == "")
            {
                noErrors = true;
            }
            else
            {
                noErrors = false;
            }


            
        }


        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Return to form
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void ChangeBT_Click(object sender, EventArgs e)
        {
            if (noErrors == true || SaveStatus == 0)
            {
                this.Close();
            }
            else
            {
                DebugTB.Text = "There are currently errors or the most recent code hasn't been checked. \r\n";
            }
        }



    }
}