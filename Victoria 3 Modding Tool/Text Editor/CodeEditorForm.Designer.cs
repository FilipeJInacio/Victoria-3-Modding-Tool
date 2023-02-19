using AutocompleteMenuNS;
using System.Windows.Forms;

namespace Victoria_3_Modding_Tool
{
    partial class CodeEditorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CodeEditorForm));
            this.AutoComplete = new AutocompleteMenuNS.AutocompleteMenu();
            this.DebugTB = new System.Windows.Forms.TextBox();
            this.HotBarP = new System.Windows.Forms.Panel();
            this.HelpBT = new System.Windows.Forms.Button();
            this.TitleL = new System.Windows.Forms.Label();
            this.MinimiseBT = new System.Windows.Forms.Button();
            this.ChangeSizeBT = new System.Windows.Forms.Button();
            this.CloseBT = new System.Windows.Forms.Button();
            this.UnderMenuP = new System.Windows.Forms.Panel();
            this.LeftBigP = new System.Windows.Forms.Panel();
            this.TreeView = new System.Windows.Forms.TreeView();
            this.LeftMenuP = new System.Windows.Forms.Panel();
            this.RightMenuP = new System.Windows.Forms.Panel();
            this.ChangeBT = new System.Windows.Forms.Button();
            this.IndentBT = new System.Windows.Forms.Button();
            this.DebugBT = new System.Windows.Forms.Button();
            this.MenuCB = new Victoria_3_Modding_Tool.CustomComboBox();
            this.MenuPanel = new System.Windows.Forms.Panel();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.MenuIcon = new System.Windows.Forms.ToolStripMenuItem();
            this.CodeDebugP = new System.Windows.Forms.Panel();
            this.CodeP = new System.Windows.Forms.Panel();
            this.scintilla = new ScintillaNET.Scintilla();
            this.FindReplaceP = new System.Windows.Forms.Panel();
            this.BlackP = new System.Windows.Forms.Panel();
            this.ReplaceAllBT = new System.Windows.Forms.Button();
            this.ExitFindReplaceBT = new System.Windows.Forms.Button();
            this.ReplaceXBT = new System.Windows.Forms.Button();
            this.FindXBT = new System.Windows.Forms.Button();
            this.NextBT = new System.Windows.Forms.Button();
            this.BackBT = new System.Windows.Forms.Button();
            this.ReplaceTB = new Victoria_3_Modding_Tool.CustomTextBox();
            this.ReplaceBT = new System.Windows.Forms.Button();
            this.FindTB = new Victoria_3_Modding_Tool.CustomTextBox();
            this.HotBarP.SuspendLayout();
            this.LeftBigP.SuspendLayout();
            this.RightMenuP.SuspendLayout();
            this.MenuPanel.SuspendLayout();
            this.MenuStrip.SuspendLayout();
            this.CodeDebugP.SuspendLayout();
            this.CodeP.SuspendLayout();
            this.FindReplaceP.SuspendLayout();
            this.BlackP.SuspendLayout();
            this.SuspendLayout();
            // 
            // AutoComplete
            // 
            this.AutoComplete.AllowsTabKey = true;
            this.AutoComplete.AppearInterval = 10;
            this.AutoComplete.Colors = ((AutocompleteMenuNS.Colors)(resources.GetObject("AutoComplete.Colors")));
            this.AutoComplete.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AutoComplete.ImageList = null;
            this.AutoComplete.Items = new string[0];
            this.AutoComplete.MaximumSize = new System.Drawing.Size(400, 200);
            this.AutoComplete.MinFragmentLength = 1;
            this.AutoComplete.TargetControlWrapper = null;
            this.AutoComplete.ToolTipDuration = 1000000;
            this.AutoComplete.Hovered += new System.EventHandler<AutocompleteMenuNS.HoveredEventArgs>(this.AutoCompleteMenu_Hovered);
            // 
            // DebugTB
            // 
            this.AutoComplete.SetAutocompleteMenu(this.DebugTB, null);
            this.DebugTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.DebugTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DebugTB.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DebugTB.ForeColor = System.Drawing.Color.White;
            this.DebugTB.Location = new System.Drawing.Point(0, 706);
            this.DebugTB.Multiline = true;
            this.DebugTB.Name = "DebugTB";
            this.DebugTB.ReadOnly = true;
            this.DebugTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DebugTB.Size = new System.Drawing.Size(1540, 110);
            this.DebugTB.TabIndex = 59;
            // 
            // HotBarP
            // 
            this.HotBarP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.HotBarP.Controls.Add(this.HelpBT);
            this.HotBarP.Controls.Add(this.TitleL);
            this.HotBarP.Controls.Add(this.MinimiseBT);
            this.HotBarP.Controls.Add(this.ChangeSizeBT);
            this.HotBarP.Controls.Add(this.CloseBT);
            this.HotBarP.Dock = System.Windows.Forms.DockStyle.Top;
            this.HotBarP.Location = new System.Drawing.Point(0, 0);
            this.HotBarP.Name = "HotBarP";
            this.HotBarP.Size = new System.Drawing.Size(1784, 32);
            this.HotBarP.TabIndex = 32;
            this.HotBarP.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HotBarP_MouseDown);
            // 
            // HelpBT
            // 
            this.HelpBT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.HelpBT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.HelpBT.Dock = System.Windows.Forms.DockStyle.Right;
            this.HelpBT.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.HelpBT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(126)))), ((int)(((byte)(255)))));
            this.HelpBT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(131)))), ((int)(((byte)(255)))));
            this.HelpBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HelpBT.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.HelpBT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.HelpBT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.HelpBT.Location = new System.Drawing.Point(1640, 0);
            this.HelpBT.Name = "HelpBT";
            this.HelpBT.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.HelpBT.Size = new System.Drawing.Size(36, 32);
            this.HelpBT.TabIndex = 37;
            this.HelpBT.Text = "?";
            this.HelpBT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.HelpBT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.HelpBT.UseVisualStyleBackColor = false;
            this.HelpBT.Click += new System.EventHandler(this.HelpBT_Click);
            // 
            // TitleL
            // 
            this.TitleL.AutoSize = true;
            this.TitleL.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TitleL.Location = new System.Drawing.Point(12, 6);
            this.TitleL.Name = "TitleL";
            this.TitleL.Size = new System.Drawing.Size(109, 21);
            this.TitleL.TabIndex = 35;
            this.TitleL.Text = "Coding Tool";
            // 
            // MinimiseBT
            // 
            this.MinimiseBT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.MinimiseBT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.MinimiseBT.Dock = System.Windows.Forms.DockStyle.Right;
            this.MinimiseBT.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.MinimiseBT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(202)))), ((int)(((byte)(211)))));
            this.MinimiseBT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(207)))), ((int)(((byte)(216)))));
            this.MinimiseBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinimiseBT.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MinimiseBT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.MinimiseBT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MinimiseBT.Location = new System.Drawing.Point(1676, 0);
            this.MinimiseBT.Name = "MinimiseBT";
            this.MinimiseBT.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.MinimiseBT.Size = new System.Drawing.Size(36, 32);
            this.MinimiseBT.TabIndex = 35;
            this.MinimiseBT.Text = "_";
            this.MinimiseBT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MinimiseBT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.MinimiseBT.UseVisualStyleBackColor = false;
            this.MinimiseBT.Click += new System.EventHandler(this.MinimiseBT_Click);
            // 
            // ChangeSizeBT
            // 
            this.ChangeSizeBT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.ChangeSizeBT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ChangeSizeBT.Dock = System.Windows.Forms.DockStyle.Right;
            this.ChangeSizeBT.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.ChangeSizeBT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(155)))), ((int)(((byte)(255)))));
            this.ChangeSizeBT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.ChangeSizeBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChangeSizeBT.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ChangeSizeBT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.ChangeSizeBT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ChangeSizeBT.Location = new System.Drawing.Point(1712, 0);
            this.ChangeSizeBT.Name = "ChangeSizeBT";
            this.ChangeSizeBT.Padding = new System.Windows.Forms.Padding(5, 3, 0, 0);
            this.ChangeSizeBT.Size = new System.Drawing.Size(36, 32);
            this.ChangeSizeBT.TabIndex = 34;
            this.ChangeSizeBT.Text = "□";
            this.ChangeSizeBT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ChangeSizeBT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ChangeSizeBT.UseVisualStyleBackColor = false;
            this.ChangeSizeBT.Click += new System.EventHandler(this.ChangeSizeBT_Click);
            // 
            // CloseBT
            // 
            this.CloseBT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.CloseBT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CloseBT.Dock = System.Windows.Forms.DockStyle.Right;
            this.CloseBT.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.CloseBT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.CloseBT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(44)))), ((int)(((byte)(63)))));
            this.CloseBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseBT.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CloseBT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.CloseBT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CloseBT.Location = new System.Drawing.Point(1748, 0);
            this.CloseBT.Name = "CloseBT";
            this.CloseBT.Padding = new System.Windows.Forms.Padding(5, 1, 0, 0);
            this.CloseBT.Size = new System.Drawing.Size(36, 32);
            this.CloseBT.TabIndex = 33;
            this.CloseBT.Text = "x";
            this.CloseBT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CloseBT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CloseBT.UseVisualStyleBackColor = false;
            this.CloseBT.Click += new System.EventHandler(this.CloseBT_Click);
            // 
            // UnderMenuP
            // 
            this.UnderMenuP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.UnderMenuP.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.UnderMenuP.Location = new System.Drawing.Point(0, 929);
            this.UnderMenuP.Name = "UnderMenuP";
            this.UnderMenuP.Size = new System.Drawing.Size(1784, 32);
            this.UnderMenuP.TabIndex = 38;
            // 
            // LeftBigP
            // 
            this.LeftBigP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LeftBigP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.LeftBigP.Controls.Add(this.TreeView);
            this.LeftBigP.Controls.Add(this.LeftMenuP);
            this.LeftBigP.Location = new System.Drawing.Point(5, 70);
            this.LeftBigP.Name = "LeftBigP";
            this.LeftBigP.Size = new System.Drawing.Size(231, 854);
            this.LeftBigP.TabIndex = 41;
            // 
            // TreeView
            // 
            this.TreeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.TreeView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.TreeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TreeView.Location = new System.Drawing.Point(0, 38);
            this.TreeView.Name = "TreeView";
            this.TreeView.Size = new System.Drawing.Size(231, 816);
            this.TreeView.TabIndex = 46;
            // 
            // LeftMenuP
            // 
            this.LeftMenuP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.LeftMenuP.Dock = System.Windows.Forms.DockStyle.Top;
            this.LeftMenuP.Location = new System.Drawing.Point(0, 0);
            this.LeftMenuP.Name = "LeftMenuP";
            this.LeftMenuP.Size = new System.Drawing.Size(231, 32);
            this.LeftMenuP.TabIndex = 43;
            // 
            // RightMenuP
            // 
            this.RightMenuP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RightMenuP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.RightMenuP.Controls.Add(this.ChangeBT);
            this.RightMenuP.Controls.Add(this.IndentBT);
            this.RightMenuP.Controls.Add(this.DebugBT);
            this.RightMenuP.Controls.Add(this.MenuCB);
            this.RightMenuP.Location = new System.Drawing.Point(242, 70);
            this.RightMenuP.Name = "RightMenuP";
            this.RightMenuP.Size = new System.Drawing.Size(1540, 32);
            this.RightMenuP.TabIndex = 42;
            // 
            // ChangeBT
            // 
            this.ChangeBT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.ChangeBT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ChangeBT.Dock = System.Windows.Forms.DockStyle.Right;
            this.ChangeBT.Enabled = false;
            this.ChangeBT.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.ChangeBT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(126)))), ((int)(((byte)(255)))));
            this.ChangeBT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(131)))), ((int)(((byte)(255)))));
            this.ChangeBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChangeBT.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ChangeBT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.ChangeBT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ChangeBT.Location = new System.Drawing.Point(1504, 0);
            this.ChangeBT.Name = "ChangeBT";
            this.ChangeBT.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.ChangeBT.Size = new System.Drawing.Size(36, 32);
            this.ChangeBT.TabIndex = 57;
            this.ChangeBT.Text = "⇌";
            this.ChangeBT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ChangeBT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ChangeBT.UseVisualStyleBackColor = false;
            this.ChangeBT.Click += new System.EventHandler(this.ChangeBT_Click);
            // 
            // IndentBT
            // 
            this.IndentBT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.IndentBT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.IndentBT.Enabled = false;
            this.IndentBT.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.IndentBT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.IndentBT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.IndentBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IndentBT.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.IndentBT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.IndentBT.Image = global::Victoria_3_Modding_Tool.Properties.Resources.braces;
            this.IndentBT.Location = new System.Drawing.Point(353, 0);
            this.IndentBT.Name = "IndentBT";
            this.IndentBT.Size = new System.Drawing.Size(143, 32);
            this.IndentBT.TabIndex = 56;
            this.IndentBT.Text = "Indent Code";
            this.IndentBT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.IndentBT.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.IndentBT.UseVisualStyleBackColor = false;
            this.IndentBT.Click += new System.EventHandler(this.IndentBT_Click);
            // 
            // DebugBT
            // 
            this.DebugBT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.DebugBT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DebugBT.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.DebugBT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.DebugBT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.DebugBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DebugBT.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DebugBT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.DebugBT.Image = global::Victoria_3_Modding_Tool.Properties.Resources.error;
            this.DebugBT.Location = new System.Drawing.Point(496, 0);
            this.DebugBT.Name = "DebugBT";
            this.DebugBT.Size = new System.Drawing.Size(158, 32);
            this.DebugBT.TabIndex = 55;
            this.DebugBT.Text = "Run Debugger";
            this.DebugBT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DebugBT.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.DebugBT.UseVisualStyleBackColor = false;
            this.DebugBT.Click += new System.EventHandler(this.DebugBT_Click);
            // 
            // MenuCB
            // 
            this.MenuCB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.MenuCB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.MenuCB.BorderSize = 1;
            this.MenuCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MenuCB.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MenuCB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.MenuCB.FormattingEnabled = false;
            this.MenuCB.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(73)))), ((int)(((byte)(150)))));
            this.MenuCB.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.MenuCB.ListTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.MenuCB.Location = new System.Drawing.Point(0, 0);
            this.MenuCB.MinimumSize = new System.Drawing.Size(200, 30);
            this.MenuCB.Name = "MenuCB";
            this.MenuCB.Padding = new System.Windows.Forms.Padding(1);
            this.MenuCB.Size = new System.Drawing.Size(353, 32);
            this.MenuCB.TabIndex = 54;
            this.MenuCB.Texts = "";
            this.MenuCB.OnSelectedIndexChanged += new System.EventHandler(this.MenuCB_OnSelectedIndexChanged);
            // 
            // MenuPanel
            // 
            this.MenuPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MenuPanel.Controls.Add(this.MenuStrip);
            this.MenuPanel.Location = new System.Drawing.Point(0, 32);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(1782, 34);
            this.MenuPanel.TabIndex = 44;
            // 
            // MenuStrip
            // 
            this.MenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.MenuStrip.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuIcon});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(1782, 32);
            this.MenuStrip.TabIndex = 0;
            this.MenuStrip.Text = "Search";
            // 
            // MenuIcon
            // 
            this.MenuIcon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuIcon.Image = global::Victoria_3_Modding_Tool.Properties.Resources.V3small;
            this.MenuIcon.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuIcon.Name = "MenuIcon";
            this.MenuIcon.Size = new System.Drawing.Size(36, 28);
            // 
            // CodeDebugP
            // 
            this.CodeDebugP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CodeDebugP.Controls.Add(this.DebugTB);
            this.CodeDebugP.Controls.Add(this.CodeP);
            this.CodeDebugP.Location = new System.Drawing.Point(242, 108);
            this.CodeDebugP.Name = "CodeDebugP";
            this.CodeDebugP.Size = new System.Drawing.Size(1540, 816);
            this.CodeDebugP.TabIndex = 53;
            // 
            // CodeP
            // 
            this.CodeP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CodeP.Controls.Add(this.scintilla);
            this.CodeP.Location = new System.Drawing.Point(0, 0);
            this.CodeP.Name = "CodeP";
            this.CodeP.Size = new System.Drawing.Size(1542, 702);
            this.CodeP.TabIndex = 56;
            // 
            // scintilla
            // 
            this.scintilla.AdditionalCaretForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.scintilla.AllowDrop = true;
            this.scintilla.AutoCMaxHeight = 9;
            this.scintilla.AutomaticFold = ((ScintillaNET.AutomaticFold)(((ScintillaNET.AutomaticFold.Show | ScintillaNET.AutomaticFold.Click) 
            | ScintillaNET.AutomaticFold.Change)));
            this.scintilla.BiDirectionality = ScintillaNET.BiDirectionalDisplayType.Disabled;
            this.scintilla.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.scintilla.CaretForeColor = System.Drawing.Color.White;
            this.scintilla.CaretLineBackColor = System.Drawing.Color.DarkGray;
            this.scintilla.CaretLineBackColorAlpha = 10;
            this.scintilla.CaretLineLayer = ScintillaNET.Layer.OverText;
            this.scintilla.CaretLineVisible = true;
            this.scintilla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scintilla.EdgeColor = System.Drawing.Color.DimGray;
            this.scintilla.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.scintilla.IndentationGuides = ScintillaNET.IndentView.LookBoth;
            this.scintilla.LexerName = null;
            this.scintilla.Location = new System.Drawing.Point(0, 0);
            this.scintilla.Name = "scintilla";
            this.scintilla.ScrollWidth = 90;
            this.scintilla.Size = new System.Drawing.Size(1542, 702);
            this.scintilla.TabIndents = true;
            this.scintilla.TabIndex = 1;
            this.scintilla.UseRightToLeftReadingLayout = false;
            this.scintilla.WrapMode = ScintillaNET.WrapMode.None;
            this.scintilla.CharAdded += new System.EventHandler<ScintillaNET.CharAddedEventArgs>(this.scintilla_CharAdded);
            this.scintilla.InsertCheck += new System.EventHandler<ScintillaNET.InsertCheckEventArgs>(this.scintilla_InsertCheck);
            this.scintilla.MarginClick += new System.EventHandler<ScintillaNET.MarginClickEventArgs>(this.scintilla_MarginClick);
            this.scintilla.StyleNeeded += new System.EventHandler<ScintillaNET.StyleNeededEventArgs>(this.scintilla_StyleNeeded);
            this.scintilla.UpdateUI += new System.EventHandler<ScintillaNET.UpdateUIEventArgs>(this.scintilla_UpdateUI);
            this.scintilla.TextChanged += new System.EventHandler(this.scintilla_TextChanged);
            // 
            // FindReplaceP
            // 
            this.FindReplaceP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FindReplaceP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(53)))), ((int)(((byte)(130)))));
            this.FindReplaceP.Controls.Add(this.BlackP);
            this.FindReplaceP.Location = new System.Drawing.Point(1443, 108);
            this.FindReplaceP.Name = "FindReplaceP";
            this.FindReplaceP.Size = new System.Drawing.Size(336, 137);
            this.FindReplaceP.TabIndex = 55;
            this.FindReplaceP.Visible = false;
            // 
            // BlackP
            // 
            this.BlackP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.BlackP.Controls.Add(this.ReplaceAllBT);
            this.BlackP.Controls.Add(this.ExitFindReplaceBT);
            this.BlackP.Controls.Add(this.ReplaceXBT);
            this.BlackP.Controls.Add(this.FindXBT);
            this.BlackP.Controls.Add(this.NextBT);
            this.BlackP.Controls.Add(this.BackBT);
            this.BlackP.Controls.Add(this.ReplaceTB);
            this.BlackP.Controls.Add(this.ReplaceBT);
            this.BlackP.Controls.Add(this.FindTB);
            this.BlackP.Location = new System.Drawing.Point(3, 0);
            this.BlackP.Name = "BlackP";
            this.BlackP.Size = new System.Drawing.Size(330, 134);
            this.BlackP.TabIndex = 1;
            // 
            // ReplaceAllBT
            // 
            this.ReplaceAllBT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.ReplaceAllBT.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.ReplaceAllBT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(29)))), ((int)(((byte)(70)))));
            this.ReplaceAllBT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(34)))), ((int)(((byte)(75)))));
            this.ReplaceAllBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReplaceAllBT.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ReplaceAllBT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.ReplaceAllBT.Location = new System.Drawing.Point(10, 93);
            this.ReplaceAllBT.Name = "ReplaceAllBT";
            this.ReplaceAllBT.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.ReplaceAllBT.Size = new System.Drawing.Size(127, 32);
            this.ReplaceAllBT.TabIndex = 87;
            this.ReplaceAllBT.Text = "Replace All";
            this.ReplaceAllBT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ReplaceAllBT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ReplaceAllBT.UseVisualStyleBackColor = false;
            // 
            // ExitFindReplaceBT
            // 
            this.ExitFindReplaceBT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.ExitFindReplaceBT.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.ExitFindReplaceBT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(29)))), ((int)(((byte)(70)))));
            this.ExitFindReplaceBT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(34)))), ((int)(((byte)(75)))));
            this.ExitFindReplaceBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitFindReplaceBT.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ExitFindReplaceBT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.ExitFindReplaceBT.Location = new System.Drawing.Point(294, 3);
            this.ExitFindReplaceBT.Name = "ExitFindReplaceBT";
            this.ExitFindReplaceBT.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.ExitFindReplaceBT.Size = new System.Drawing.Size(32, 32);
            this.ExitFindReplaceBT.TabIndex = 86;
            this.ExitFindReplaceBT.Text = "X";
            this.ExitFindReplaceBT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ExitFindReplaceBT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ExitFindReplaceBT.UseVisualStyleBackColor = false;
            // 
            // ReplaceXBT
            // 
            this.ReplaceXBT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.ReplaceXBT.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.ReplaceXBT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(29)))), ((int)(((byte)(70)))));
            this.ReplaceXBT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(34)))), ((int)(((byte)(75)))));
            this.ReplaceXBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReplaceXBT.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ReplaceXBT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.ReplaceXBT.Location = new System.Drawing.Point(252, 55);
            this.ReplaceXBT.Name = "ReplaceXBT";
            this.ReplaceXBT.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.ReplaceXBT.Size = new System.Drawing.Size(32, 32);
            this.ReplaceXBT.TabIndex = 85;
            this.ReplaceXBT.Text = "X";
            this.ReplaceXBT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ReplaceXBT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ReplaceXBT.UseVisualStyleBackColor = false;
            // 
            // FindXBT
            // 
            this.FindXBT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.FindXBT.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.FindXBT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(29)))), ((int)(((byte)(70)))));
            this.FindXBT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(34)))), ((int)(((byte)(75)))));
            this.FindXBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FindXBT.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FindXBT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.FindXBT.Location = new System.Drawing.Point(252, 17);
            this.FindXBT.Name = "FindXBT";
            this.FindXBT.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.FindXBT.Size = new System.Drawing.Size(32, 32);
            this.FindXBT.TabIndex = 84;
            this.FindXBT.Text = "X";
            this.FindXBT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FindXBT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.FindXBT.UseVisualStyleBackColor = false;
            // 
            // NextBT
            // 
            this.NextBT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(53)))), ((int)(((byte)(130)))));
            this.NextBT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.NextBT.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.NextBT.FlatAppearance.BorderSize = 0;
            this.NextBT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.NextBT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.NextBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NextBT.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NextBT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.NextBT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.NextBT.Location = new System.Drawing.Point(290, 55);
            this.NextBT.Name = "NextBT";
            this.NextBT.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.NextBT.Size = new System.Drawing.Size(36, 32);
            this.NextBT.TabIndex = 83;
            this.NextBT.Text = "⌃";
            this.NextBT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.NextBT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.NextBT.UseVisualStyleBackColor = false;
            // 
            // BackBT
            // 
            this.BackBT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(53)))), ((int)(((byte)(130)))));
            this.BackBT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BackBT.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.BackBT.FlatAppearance.BorderSize = 0;
            this.BackBT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.BackBT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.BackBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackBT.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BackBT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.BackBT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BackBT.Location = new System.Drawing.Point(290, 93);
            this.BackBT.Name = "BackBT";
            this.BackBT.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.BackBT.Size = new System.Drawing.Size(36, 32);
            this.BackBT.TabIndex = 82;
            this.BackBT.Text = "⌄";
            this.BackBT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BackBT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BackBT.UseVisualStyleBackColor = false;
            // 
            // ReplaceTB
            // 
            this.ReplaceTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.ReplaceTB.BackgroundColorFocus = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.ReplaceTB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.ReplaceTB.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.ReplaceTB.BorderSize = 1;
            this.ReplaceTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.ReplaceTB.Location = new System.Drawing.Point(10, 55);
            this.ReplaceTB.Multiline = false;
            this.ReplaceTB.Name = "ReplaceTB";
            this.ReplaceTB.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.ReplaceTB.ReadOnly = false;
            this.ReplaceTB.Size = new System.Drawing.Size(252, 30);
            this.ReplaceTB.TabIndex = 81;
            this.ReplaceTB.Texts = "";
            this.ReplaceTB.UnderlinedStyle = false;
            // 
            // ReplaceBT
            // 
            this.ReplaceBT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.ReplaceBT.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.ReplaceBT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(29)))), ((int)(((byte)(70)))));
            this.ReplaceBT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(34)))), ((int)(((byte)(75)))));
            this.ReplaceBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReplaceBT.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ReplaceBT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.ReplaceBT.Location = new System.Drawing.Point(196, 93);
            this.ReplaceBT.Name = "ReplaceBT";
            this.ReplaceBT.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.ReplaceBT.Size = new System.Drawing.Size(88, 32);
            this.ReplaceBT.TabIndex = 78;
            this.ReplaceBT.Text = "Replace";
            this.ReplaceBT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ReplaceBT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ReplaceBT.UseVisualStyleBackColor = false;
            // 
            // FindTB
            // 
            this.FindTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.FindTB.BackgroundColorFocus = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.FindTB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.FindTB.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.FindTB.BorderSize = 1;
            this.FindTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.FindTB.Location = new System.Drawing.Point(10, 17);
            this.FindTB.Multiline = false;
            this.FindTB.Name = "FindTB";
            this.FindTB.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.FindTB.ReadOnly = false;
            this.FindTB.Size = new System.Drawing.Size(252, 30);
            this.FindTB.TabIndex = 77;
            this.FindTB.Texts = "";
            this.FindTB.UnderlinedStyle = false;
            // 
            // CodeEditorForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(1784, 961);
            this.Controls.Add(this.FindReplaceP);
            this.Controls.Add(this.CodeDebugP);
            this.Controls.Add(this.MenuPanel);
            this.Controls.Add(this.RightMenuP);
            this.Controls.Add(this.LeftBigP);
            this.Controls.Add(this.UnderMenuP);
            this.Controls.Add(this.HotBarP);
            this.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(1000, 700);
            this.Name = "CodeEditorForm";
            this.Text = "Victoria 3 Modding Tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CodeEditorForm_FormClosing);
            this.Load += new System.EventHandler(this.CodeEditorForm_Load);
            this.Resize += new System.EventHandler(this.CodeEditorForm_Resize);
            this.HotBarP.ResumeLayout(false);
            this.HotBarP.PerformLayout();
            this.LeftBigP.ResumeLayout(false);
            this.RightMenuP.ResumeLayout(false);
            this.MenuPanel.ResumeLayout(false);
            this.MenuPanel.PerformLayout();
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.CodeDebugP.ResumeLayout(false);
            this.CodeDebugP.PerformLayout();
            this.CodeP.ResumeLayout(false);
            this.FindReplaceP.ResumeLayout(false);
            this.BlackP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private AutocompleteMenuNS.AutocompleteMenu AutoComplete;
        private Panel HotBarP;
        private Button MinimiseBT;
        private Button ChangeSizeBT;
        private Button CloseBT;
        private Button HelpBT;
        private Panel UnderMenuP;
        private Label TitleL;
        private Panel LeftBigP;
        private Panel RightMenuP;
        private TreeView TreeView;
        private Panel LeftMenuP;
        private Panel MenuPanel;
        private MenuStrip MenuStrip;
        private ToolStripMenuItem MenuIcon;
        private CustomComboBox MenuCB;
        private Panel CodeDebugP;
        private Panel FindReplaceP;
        private Panel BlackP;
        private Button ReplaceAllBT;
        private Button ExitFindReplaceBT;
        private Button ReplaceXBT;
        private Button FindXBT;
        private Button NextBT;
        private Button BackBT;
        private CustomTextBox ReplaceTB;
        private Button ReplaceBT;
        private CustomTextBox FindTB;
        private Panel CodeP;
        private ScintillaNET.Scintilla scintilla;
        private TextBox DebugTB;
        private Button DebugBT;
        private Button IndentBT;
        private Button ChangeBT;
    }
}

