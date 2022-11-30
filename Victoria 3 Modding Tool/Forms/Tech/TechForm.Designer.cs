using System.Windows.Forms;

namespace Victoria_3_Modding_Tool
{
    partial class TechForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TechForm));
            this.SaveBT = new System.Windows.Forms.Button();
            this.ModifiersAddBT = new System.Windows.Forms.Button();
            this.HotBarP = new System.Windows.Forms.Panel();
            this.HelpBT = new System.Windows.Forms.Button();
            this.TitleL = new System.Windows.Forms.Label();
            this.MinimiseBT = new System.Windows.Forms.Button();
            this.ChangeSizeBT = new System.Windows.Forms.Button();
            this.CloseBT = new System.Windows.Forms.Button();
            this.ModifiersL = new System.Windows.Forms.Label();
            this.TextureL = new System.Windows.Forms.Label();
            this.TexturePathBT = new System.Windows.Forms.Button();
            this.NameL = new System.Windows.Forms.Label();
            this.EraCostL = new System.Windows.Forms.Label();
            this.EraL = new System.Windows.Forms.Label();
            this.CategoryL = new System.Windows.Forms.Label();
            this.CanResearchL = new System.Windows.Forms.Label();
            this.DescriptionL = new System.Windows.Forms.Label();
            this.NeededTechAddBT = new System.Windows.Forms.Button();
            this.NeededTechL = new System.Windows.Forms.Label();
            this.NeededTechLB = new System.Windows.Forms.ListBox();
            this.ModifiersLB = new System.Windows.Forms.ListBox();
            this.ModifiersCB = new Victoria_3_Modding_Tool.CustomComboBox();
            this.NeededCB = new Victoria_3_Modding_Tool.CustomComboBox();
            this.DescriptionTB = new Victoria_3_Modding_Tool.CustomTextBox();
            this.CanResearchCB = new Victoria_3_Modding_Tool.Custom_Controls.CustomCheckBox();
            this.CategoryCB = new Victoria_3_Modding_Tool.CustomComboBox();
            this.EraCB = new Victoria_3_Modding_Tool.CustomComboBox();
            this.EraCostTB = new Victoria_3_Modding_Tool.CustomTextBox();
            this.NameTB = new Victoria_3_Modding_Tool.CustomTextBox();
            this.TextureTB = new Victoria_3_Modding_Tool.CustomTextBox();
            this.NameGameTB = new Victoria_3_Modding_Tool.CustomTextBox();
            this.NameGameL = new System.Windows.Forms.Label();
            this.HotBarP.SuspendLayout();
            this.SuspendLayout();
            // 
            // SaveBT
            // 
            this.SaveBT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(53)))), ((int)(((byte)(130)))));
            this.SaveBT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SaveBT.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.SaveBT.FlatAppearance.BorderSize = 0;
            this.SaveBT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.SaveBT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.SaveBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveBT.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.SaveBT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.SaveBT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SaveBT.Location = new System.Drawing.Point(928, 676);
            this.SaveBT.Name = "SaveBT";
            this.SaveBT.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.SaveBT.Size = new System.Drawing.Size(60, 32);
            this.SaveBT.TabIndex = 28;
            this.SaveBT.Text = "Save";
            this.SaveBT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SaveBT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SaveBT.UseVisualStyleBackColor = false;
            this.SaveBT.Click += new System.EventHandler(this.SaveBT_Click);
            // 
            // ModifiersAddBT
            // 
            this.ModifiersAddBT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.ModifiersAddBT.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.ModifiersAddBT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(29)))), ((int)(((byte)(70)))));
            this.ModifiersAddBT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(34)))), ((int)(((byte)(75)))));
            this.ModifiersAddBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ModifiersAddBT.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.ModifiersAddBT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.ModifiersAddBT.Location = new System.Drawing.Point(928, 545);
            this.ModifiersAddBT.Name = "ModifiersAddBT";
            this.ModifiersAddBT.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.ModifiersAddBT.Size = new System.Drawing.Size(51, 32);
            this.ModifiersAddBT.TabIndex = 31;
            this.ModifiersAddBT.Text = "Add";
            this.ModifiersAddBT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ModifiersAddBT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ModifiersAddBT.UseVisualStyleBackColor = false;
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
            this.HotBarP.Size = new System.Drawing.Size(995, 32);
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
            this.HelpBT.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.HelpBT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.HelpBT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.HelpBT.Location = new System.Drawing.Point(851, 0);
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
            this.TitleL.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.TitleL.Location = new System.Drawing.Point(12, 6);
            this.TitleL.Name = "TitleL";
            this.TitleL.Size = new System.Drawing.Size(109, 21);
            this.TitleL.TabIndex = 35;
            this.TitleL.Text = "Tech Editor";
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
            this.MinimiseBT.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.MinimiseBT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.MinimiseBT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MinimiseBT.Location = new System.Drawing.Point(887, 0);
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
            this.ChangeSizeBT.Enabled = false;
            this.ChangeSizeBT.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.ChangeSizeBT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(155)))), ((int)(((byte)(255)))));
            this.ChangeSizeBT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.ChangeSizeBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChangeSizeBT.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.ChangeSizeBT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.ChangeSizeBT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ChangeSizeBT.Location = new System.Drawing.Point(923, 0);
            this.ChangeSizeBT.Name = "ChangeSizeBT";
            this.ChangeSizeBT.Padding = new System.Windows.Forms.Padding(5, 3, 0, 0);
            this.ChangeSizeBT.Size = new System.Drawing.Size(36, 32);
            this.ChangeSizeBT.TabIndex = 34;
            this.ChangeSizeBT.Text = "□";
            this.ChangeSizeBT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ChangeSizeBT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ChangeSizeBT.UseVisualStyleBackColor = false;
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
            this.CloseBT.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.CloseBT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.CloseBT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CloseBT.Location = new System.Drawing.Point(959, 0);
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
            // ModifiersL
            // 
            this.ModifiersL.AutoSize = true;
            this.ModifiersL.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.ModifiersL.Location = new System.Drawing.Point(13, 521);
            this.ModifiersL.Name = "ModifiersL";
            this.ModifiersL.Size = new System.Drawing.Size(91, 21);
            this.ModifiersL.TabIndex = 36;
            this.ModifiersL.Text = "Modifiers";
            // 
            // TextureL
            // 
            this.TextureL.AutoSize = true;
            this.TextureL.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.TextureL.Location = new System.Drawing.Point(12, 164);
            this.TextureL.Name = "TextureL";
            this.TextureL.Size = new System.Drawing.Size(82, 21);
            this.TextureL.TabIndex = 39;
            this.TextureL.Text = "Texture:";
            // 
            // TexturePathBT
            // 
            this.TexturePathBT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.TexturePathBT.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.TexturePathBT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(29)))), ((int)(((byte)(70)))));
            this.TexturePathBT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(34)))), ((int)(((byte)(75)))));
            this.TexturePathBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TexturePathBT.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.TexturePathBT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.TexturePathBT.Location = new System.Drawing.Point(928, 188);
            this.TexturePathBT.Name = "TexturePathBT";
            this.TexturePathBT.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TexturePathBT.Size = new System.Drawing.Size(51, 32);
            this.TexturePathBT.TabIndex = 37;
            this.TexturePathBT.Text = "...";
            this.TexturePathBT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TexturePathBT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.TexturePathBT.UseVisualStyleBackColor = false;
            this.TexturePathBT.Click += new System.EventHandler(this.TexturePathBT_Click);
            // 
            // NameL
            // 
            this.NameL.AutoSize = true;
            this.NameL.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.NameL.Location = new System.Drawing.Point(12, 43);
            this.NameL.Name = "NameL";
            this.NameL.Size = new System.Drawing.Size(55, 21);
            this.NameL.TabIndex = 41;
            this.NameL.Text = "Name:";
            // 
            // EraCostL
            // 
            this.EraCostL.AutoSize = true;
            this.EraCostL.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.EraCostL.Location = new System.Drawing.Point(327, 43);
            this.EraCostL.Name = "EraCostL";
            this.EraCostL.Size = new System.Drawing.Size(55, 21);
            this.EraCostL.TabIndex = 46;
            this.EraCostL.Text = "Cost:";
            // 
            // EraL
            // 
            this.EraL.AutoSize = true;
            this.EraL.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.EraL.Location = new System.Drawing.Point(453, 43);
            this.EraL.Name = "EraL";
            this.EraL.Size = new System.Drawing.Size(46, 21);
            this.EraL.TabIndex = 47;
            this.EraL.Text = "Era:";
            // 
            // CategoryL
            // 
            this.CategoryL.AutoSize = true;
            this.CategoryL.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.CategoryL.Location = new System.Drawing.Point(650, 43);
            this.CategoryL.Name = "CategoryL";
            this.CategoryL.Size = new System.Drawing.Size(91, 21);
            this.CategoryL.TabIndex = 48;
            this.CategoryL.Text = "Category:";
            // 
            // CanResearchL
            // 
            this.CanResearchL.AutoSize = true;
            this.CanResearchL.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.CanResearchL.Location = new System.Drawing.Point(851, 134);
            this.CanResearchL.Name = "CanResearchL";
            this.CanResearchL.Size = new System.Drawing.Size(118, 21);
            this.CanResearchL.TabIndex = 49;
            this.CanResearchL.Text = "Researchable";
            // 
            // DescriptionL
            // 
            this.DescriptionL.AutoSize = true;
            this.DescriptionL.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.DescriptionL.Location = new System.Drawing.Point(12, 223);
            this.DescriptionL.Name = "DescriptionL";
            this.DescriptionL.Size = new System.Drawing.Size(118, 21);
            this.DescriptionL.TabIndex = 51;
            this.DescriptionL.Text = "Description:";
            // 
            // NeededTechAddBT
            // 
            this.NeededTechAddBT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.NeededTechAddBT.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.NeededTechAddBT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(29)))), ((int)(((byte)(70)))));
            this.NeededTechAddBT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(34)))), ((int)(((byte)(75)))));
            this.NeededTechAddBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NeededTechAddBT.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.NeededTechAddBT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.NeededTechAddBT.Location = new System.Drawing.Point(928, 360);
            this.NeededTechAddBT.Name = "NeededTechAddBT";
            this.NeededTechAddBT.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.NeededTechAddBT.Size = new System.Drawing.Size(51, 32);
            this.NeededTechAddBT.TabIndex = 53;
            this.NeededTechAddBT.Text = "Add";
            this.NeededTechAddBT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.NeededTechAddBT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.NeededTechAddBT.UseVisualStyleBackColor = false;
            this.NeededTechAddBT.Click += new System.EventHandler(this.AddTechBT_Click);
            // 
            // NeededTechL
            // 
            this.NeededTechL.AutoSize = true;
            this.NeededTechL.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.NeededTechL.Location = new System.Drawing.Point(13, 336);
            this.NeededTechL.Name = "NeededTechL";
            this.NeededTechL.Size = new System.Drawing.Size(118, 21);
            this.NeededTechL.TabIndex = 54;
            this.NeededTechL.Text = "Needed Tech:";
            // 
            // NeededTechLB
            // 
            this.NeededTechLB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.NeededTechLB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NeededTechLB.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.NeededTechLB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.NeededTechLB.FormattingEnabled = true;
            this.NeededTechLB.ItemHeight = 24;
            this.NeededTechLB.Location = new System.Drawing.Point(16, 398);
            this.NeededTechLB.Name = "NeededTechLB";
            this.NeededTechLB.Size = new System.Drawing.Size(963, 120);
            this.NeededTechLB.TabIndex = 59;
            this.NeededTechLB.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.NeededTechLB_DrawItem_1);
            this.NeededTechLB.DoubleClick += new System.EventHandler(this.NeededTechLB_DoubleClick);
            // 
            // ModifiersLB
            // 
            this.ModifiersLB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ModifiersLB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ModifiersLB.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ModifiersLB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.ModifiersLB.FormattingEnabled = true;
            this.ModifiersLB.ItemHeight = 24;
            this.ModifiersLB.Location = new System.Drawing.Point(17, 588);
            this.ModifiersLB.Name = "ModifiersLB";
            this.ModifiersLB.Size = new System.Drawing.Size(897, 120);
            this.ModifiersLB.TabIndex = 60;
            this.ModifiersLB.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ModifiersLB_DrawItem);
            this.ModifiersLB.DoubleClick += new System.EventHandler(this.ModifiersLB_DoubleClick);
            // 
            // ModifiersCB
            // 
            this.ModifiersCB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.ModifiersCB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.ModifiersCB.BorderSize = 1;
            this.ModifiersCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ModifiersCB.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModifiersCB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.ModifiersCB.FormattingEnabled = false;
            this.ModifiersCB.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(73)))), ((int)(((byte)(150)))));
            this.ModifiersCB.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ModifiersCB.ListTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.ModifiersCB.Location = new System.Drawing.Point(16, 545);
            this.ModifiersCB.MinimumSize = new System.Drawing.Size(200, 30);
            this.ModifiersCB.Name = "ModifiersCB";
            this.ModifiersCB.Padding = new System.Windows.Forms.Padding(1);
            this.ModifiersCB.Size = new System.Drawing.Size(906, 32);
            this.ModifiersCB.TabIndex = 56;
            this.ModifiersCB.Texts = "";
            // 
            // NeededCB
            // 
            this.NeededCB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.NeededCB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.NeededCB.BorderSize = 1;
            this.NeededCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.NeededCB.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NeededCB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.NeededCB.FormattingEnabled = false;
            this.NeededCB.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(73)))), ((int)(((byte)(150)))));
            this.NeededCB.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.NeededCB.ListTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.NeededCB.Location = new System.Drawing.Point(16, 360);
            this.NeededCB.MinimumSize = new System.Drawing.Size(200, 30);
            this.NeededCB.Name = "NeededCB";
            this.NeededCB.Padding = new System.Windows.Forms.Padding(1);
            this.NeededCB.Size = new System.Drawing.Size(906, 32);
            this.NeededCB.TabIndex = 52;
            this.NeededCB.Texts = "";
            // 
            // DescriptionTB
            // 
            this.DescriptionTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.DescriptionTB.BackgroundColorFocus = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.DescriptionTB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.DescriptionTB.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.DescriptionTB.BorderSize = 1;
            this.DescriptionTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.DescriptionTB.Location = new System.Drawing.Point(16, 247);
            this.DescriptionTB.Multiline = true;
            this.DescriptionTB.Name = "DescriptionTB";
            this.DescriptionTB.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.DescriptionTB.ReadOnly = false;
            this.DescriptionTB.Size = new System.Drawing.Size(963, 86);
            this.DescriptionTB.TabIndex = 50;
            this.DescriptionTB.Texts = "";
            this.DescriptionTB.UnderlinedStyle = false;
            this.DescriptionTB.CustomTextBox_TextChanged += new System.EventHandler(this.DescriptionTB_CustomTextBox_TextChanged);
            // 
            // CanResearchCB
            // 
            this.CanResearchCB.AutoSize = true;
            this.CanResearchCB.Checked = true;
            this.CanResearchCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CanResearchCB.Location = new System.Drawing.Point(783, 129);
            this.CanResearchCB.MinimumSize = new System.Drawing.Size(62, 32);
            this.CanResearchCB.Name = "CanResearchCB";
            this.CanResearchCB.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.CanResearchCB.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.CanResearchCB.OnBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(53)))), ((int)(((byte)(130)))));
            this.CanResearchCB.OnToggleColor = System.Drawing.Color.Gainsboro;
            this.CanResearchCB.Size = new System.Drawing.Size(62, 32);
            this.CanResearchCB.TabIndex = 45;
            this.CanResearchCB.UseVisualStyleBackColor = true;
            this.CanResearchCB.CheckedChanged += new System.EventHandler(this.CanResearchCB_CheckedChanged);
            // 
            // CategoryCB
            // 
            this.CategoryCB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.CategoryCB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.CategoryCB.BorderSize = 1;
            this.CategoryCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.CategoryCB.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CategoryCB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.CategoryCB.FormattingEnabled = false;
            this.CategoryCB.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(73)))), ((int)(((byte)(150)))));
            this.CategoryCB.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.CategoryCB.ListTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.CategoryCB.Location = new System.Drawing.Point(654, 67);
            this.CategoryCB.MinimumSize = new System.Drawing.Size(120, 30);
            this.CategoryCB.Name = "CategoryCB";
            this.CategoryCB.Padding = new System.Windows.Forms.Padding(1);
            this.CategoryCB.Size = new System.Drawing.Size(305, 32);
            this.CategoryCB.TabIndex = 44;
            this.CategoryCB.Texts = "";
            this.CategoryCB.OnSelectedIndexChanged += new System.EventHandler(this.CategoryCB_OnSelectedIndexChanged);
            // 
            // EraCB
            // 
            this.EraCB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.EraCB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.EraCB.BorderSize = 1;
            this.EraCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.EraCB.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EraCB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.EraCB.FormattingEnabled = false;
            this.EraCB.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(73)))), ((int)(((byte)(150)))));
            this.EraCB.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.EraCB.ListTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.EraCB.Location = new System.Drawing.Point(457, 67);
            this.EraCB.MinimumSize = new System.Drawing.Size(120, 32);
            this.EraCB.Name = "EraCB";
            this.EraCB.Padding = new System.Windows.Forms.Padding(1);
            this.EraCB.Size = new System.Drawing.Size(138, 32);
            this.EraCB.TabIndex = 43;
            this.EraCB.Texts = "";
            this.EraCB.OnSelectedIndexChanged += new System.EventHandler(this.EraCB_OnSelectedIndexChanged);
            // 
            // EraCostTB
            // 
            this.EraCostTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.EraCostTB.BackgroundColorFocus = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.EraCostTB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.EraCostTB.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.EraCostTB.BorderSize = 1;
            this.EraCostTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.EraCostTB.Location = new System.Drawing.Point(331, 67);
            this.EraCostTB.Multiline = false;
            this.EraCostTB.Name = "EraCostTB";
            this.EraCostTB.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.EraCostTB.ReadOnly = true;
            this.EraCostTB.Size = new System.Drawing.Size(120, 24);
            this.EraCostTB.TabIndex = 42;
            this.EraCostTB.Texts = "";
            this.EraCostTB.UnderlinedStyle = false;
            // 
            // NameTB
            // 
            this.NameTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.NameTB.BackgroundColorFocus = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.NameTB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.NameTB.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.NameTB.BorderSize = 1;
            this.NameTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.NameTB.Location = new System.Drawing.Point(16, 67);
            this.NameTB.Multiline = false;
            this.NameTB.Name = "NameTB";
            this.NameTB.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.NameTB.ReadOnly = false;
            this.NameTB.Size = new System.Drawing.Size(255, 24);
            this.NameTB.TabIndex = 40;
            this.NameTB.Texts = "";
            this.NameTB.UnderlinedStyle = false;
            this.NameTB.CustomTextBox_TextChanged += new System.EventHandler(this.NameTB_CustomTextBox_TextChanged);
            // 
            // TextureTB
            // 
            this.TextureTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.TextureTB.BackgroundColorFocus = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.TextureTB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.TextureTB.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.TextureTB.BorderSize = 1;
            this.TextureTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.TextureTB.Location = new System.Drawing.Point(16, 188);
            this.TextureTB.Multiline = false;
            this.TextureTB.Name = "TextureTB";
            this.TextureTB.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.TextureTB.ReadOnly = false;
            this.TextureTB.Size = new System.Drawing.Size(906, 24);
            this.TextureTB.TabIndex = 38;
            this.TextureTB.Texts = "";
            this.TextureTB.UnderlinedStyle = false;
            this.TextureTB.CustomTextBox_TextChanged += new System.EventHandler(this.TextureTB_CustomTextBox_TextChanged);
            // 
            // NameGameTB
            // 
            this.NameGameTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.NameGameTB.BackgroundColorFocus = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.NameGameTB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.NameGameTB.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.NameGameTB.BorderSize = 1;
            this.NameGameTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.NameGameTB.Location = new System.Drawing.Point(16, 129);
            this.NameGameTB.Multiline = false;
            this.NameGameTB.Name = "NameGameTB";
            this.NameGameTB.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.NameGameTB.ReadOnly = false;
            this.NameGameTB.Size = new System.Drawing.Size(742, 24);
            this.NameGameTB.TabIndex = 61;
            this.NameGameTB.Texts = "";
            this.NameGameTB.UnderlinedStyle = false;
            this.NameGameTB.CustomTextBox_TextChanged += new System.EventHandler(this.NameGameTB_CustomTextBox_TextChanged);
            // 
            // NameGameL
            // 
            this.NameGameL.AutoSize = true;
            this.NameGameL.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.NameGameL.Location = new System.Drawing.Point(12, 105);
            this.NameGameL.Name = "NameGameL";
            this.NameGameL.Size = new System.Drawing.Size(127, 21);
            this.NameGameL.TabIndex = 62;
            this.NameGameL.Text = "Name in game:";
            // 
            // TechForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(995, 718);
            this.Controls.Add(this.NameGameL);
            this.Controls.Add(this.NameGameTB);
            this.Controls.Add(this.ModifiersLB);
            this.Controls.Add(this.NeededTechLB);
            this.Controls.Add(this.ModifiersCB);
            this.Controls.Add(this.NeededTechL);
            this.Controls.Add(this.NeededTechAddBT);
            this.Controls.Add(this.NeededCB);
            this.Controls.Add(this.DescriptionL);
            this.Controls.Add(this.DescriptionTB);
            this.Controls.Add(this.CanResearchL);
            this.Controls.Add(this.CategoryL);
            this.Controls.Add(this.EraL);
            this.Controls.Add(this.EraCostL);
            this.Controls.Add(this.CanResearchCB);
            this.Controls.Add(this.CategoryCB);
            this.Controls.Add(this.EraCB);
            this.Controls.Add(this.EraCostTB);
            this.Controls.Add(this.NameL);
            this.Controls.Add(this.NameTB);
            this.Controls.Add(this.TextureL);
            this.Controls.Add(this.TextureTB);
            this.Controls.Add(this.TexturePathBT);
            this.Controls.Add(this.ModifiersL);
            this.Controls.Add(this.HotBarP);
            this.Controls.Add(this.ModifiersAddBT);
            this.Controls.Add(this.SaveBT);
            this.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(995, 718);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(995, 718);
            this.Name = "TechForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Victoria 3 Modding Tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TechForm_FormClosing);
            this.Load += new System.EventHandler(this.TechForm_Load);
            this.HotBarP.ResumeLayout(false);
            this.HotBarP.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button SaveBT;
        private Button ModifiersAddBT;
        private Panel HotBarP;
        private Button MinimiseBT;
        private Button ChangeSizeBT;
        private Button CloseBT;
        private Label TitleL;
        private Label ModifiersL;
        private Label TextureL;
        private CustomTextBox TextureTB;
        private Button TexturePathBT;
        private CustomTextBox NameTB;
        private Label NameL;
        private CustomTextBox EraCostTB;
        private CustomComboBox EraCB;
        private CustomComboBox CategoryCB;
        private Custom_Controls.CustomCheckBox CanResearchCB;
        private Label EraCostL;
        private Label EraL;
        private Label CategoryL;
        private Label CanResearchL;
        private CustomTextBox DescriptionTB;
        private Label DescriptionL;
        private CustomComboBox NeededCB;
        private Button NeededTechAddBT;
        private Label NeededTechL;
        private CustomComboBox ModifiersCB;
        private ListBox NeededTechLB;
        private ListBox ModifiersLB;
        private CustomTextBox NameGameTB;
        private Label NameGameL;
        private Button HelpBT;
    }
}

