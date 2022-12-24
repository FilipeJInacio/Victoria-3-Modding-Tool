using System.Windows.Forms;

namespace Victoria_3_Modding_Tool
{
    partial class ReligionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReligionForm));
            this.SaveBT = new System.Windows.Forms.Button();
            this.TabooAddBT = new System.Windows.Forms.Button();
            this.HotBarP = new System.Windows.Forms.Panel();
            this.HelpBT = new System.Windows.Forms.Button();
            this.TitleL = new System.Windows.Forms.Label();
            this.MinimiseBT = new System.Windows.Forms.Button();
            this.ChangeSizeBT = new System.Windows.Forms.Button();
            this.CloseBT = new System.Windows.Forms.Button();
            this.TabooL = new System.Windows.Forms.Label();
            this.TextureL = new System.Windows.Forms.Label();
            this.TexturePathBT = new System.Windows.Forms.Button();
            this.NameL = new System.Windows.Forms.Label();
            this.TraitAddBT = new System.Windows.Forms.Button();
            this.TraitL = new System.Windows.Forms.Label();
            this.TraitsLB = new System.Windows.Forms.ListBox();
            this.TaboosLB = new System.Windows.Forms.ListBox();
            this.NameGameL = new System.Windows.Forms.Label();
            this.ColorL = new System.Windows.Forms.Label();
            this.ColorP = new System.Windows.Forms.Panel();
            this.RedL = new System.Windows.Forms.Label();
            this.GreenL = new System.Windows.Forms.Label();
            this.BlueL = new System.Windows.Forms.Label();
            this.BlueTB = new Victoria_3_Modding_Tool.CustomTextBox();
            this.GreenTB = new Victoria_3_Modding_Tool.CustomTextBox();
            this.RedTB = new Victoria_3_Modding_Tool.CustomTextBox();
            this.NameGameTB = new Victoria_3_Modding_Tool.CustomTextBox();
            this.TaboosCB = new Victoria_3_Modding_Tool.CustomComboBox();
            this.TraitsCB = new Victoria_3_Modding_Tool.CustomComboBox();
            this.NameTB = new Victoria_3_Modding_Tool.CustomTextBox();
            this.TextureTB = new Victoria_3_Modding_Tool.CustomTextBox();
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
            this.SaveBT.Location = new System.Drawing.Point(848, 67);
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
            // TabooAddBT
            // 
            this.TabooAddBT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.TabooAddBT.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.TabooAddBT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(29)))), ((int)(((byte)(70)))));
            this.TabooAddBT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(34)))), ((int)(((byte)(75)))));
            this.TabooAddBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TabooAddBT.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.TabooAddBT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.TabooAddBT.Location = new System.Drawing.Point(857, 185);
            this.TabooAddBT.Name = "TabooAddBT";
            this.TabooAddBT.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TabooAddBT.Size = new System.Drawing.Size(51, 32);
            this.TabooAddBT.TabIndex = 31;
            this.TabooAddBT.Text = "Add";
            this.TabooAddBT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TabooAddBT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.TabooAddBT.UseVisualStyleBackColor = false;
            this.TabooAddBT.Click += new System.EventHandler(this.TabooAddBT_Click);
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
            this.HotBarP.Size = new System.Drawing.Size(920, 32);
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
            this.HelpBT.Location = new System.Drawing.Point(776, 0);
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
            this.TitleL.Size = new System.Drawing.Size(145, 21);
            this.TitleL.TabIndex = 35;
            this.TitleL.Text = "Religion Editor";
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
            this.MinimiseBT.Location = new System.Drawing.Point(812, 0);
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
            this.ChangeSizeBT.Location = new System.Drawing.Point(848, 0);
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
            this.CloseBT.Location = new System.Drawing.Point(884, 0);
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
            // TabooL
            // 
            this.TabooL.AutoSize = true;
            this.TabooL.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.TabooL.Location = new System.Drawing.Point(464, 161);
            this.TabooL.Name = "TabooL";
            this.TabooL.Size = new System.Drawing.Size(64, 21);
            this.TabooL.TabIndex = 36;
            this.TabooL.Text = "Taboos";
            // 
            // TextureL
            // 
            this.TextureL.AutoSize = true;
            this.TextureL.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.TextureL.Location = new System.Drawing.Point(13, 102);
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
            this.TexturePathBT.Location = new System.Drawing.Point(857, 126);
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
            // TraitAddBT
            // 
            this.TraitAddBT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.TraitAddBT.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.TraitAddBT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(29)))), ((int)(((byte)(70)))));
            this.TraitAddBT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(34)))), ((int)(((byte)(75)))));
            this.TraitAddBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TraitAddBT.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.TraitAddBT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.TraitAddBT.Location = new System.Drawing.Point(405, 185);
            this.TraitAddBT.Name = "TraitAddBT";
            this.TraitAddBT.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TraitAddBT.Size = new System.Drawing.Size(51, 32);
            this.TraitAddBT.TabIndex = 53;
            this.TraitAddBT.Text = "Add";
            this.TraitAddBT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TraitAddBT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.TraitAddBT.UseVisualStyleBackColor = false;
            this.TraitAddBT.Click += new System.EventHandler(this.TraitAddBT_Click);
            // 
            // TraitL
            // 
            this.TraitL.AutoSize = true;
            this.TraitL.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.TraitL.Location = new System.Drawing.Point(13, 161);
            this.TraitL.Name = "TraitL";
            this.TraitL.Size = new System.Drawing.Size(64, 21);
            this.TraitL.TabIndex = 54;
            this.TraitL.Text = "Traits";
            // 
            // TraitsLB
            // 
            this.TraitsLB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.TraitsLB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TraitsLB.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.TraitsLB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.TraitsLB.FormattingEnabled = true;
            this.TraitsLB.ItemHeight = 24;
            this.TraitsLB.Location = new System.Drawing.Point(16, 223);
            this.TraitsLB.Name = "TraitsLB";
            this.TraitsLB.Size = new System.Drawing.Size(440, 120);
            this.TraitsLB.TabIndex = 59;
            this.TraitsLB.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.NeededTechLB_DrawItem_1);
            this.TraitsLB.DoubleClick += new System.EventHandler(this.TraitsLB_DoubleClick);
            // 
            // TaboosLB
            // 
            this.TaboosLB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.TaboosLB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TaboosLB.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.TaboosLB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.TaboosLB.FormattingEnabled = true;
            this.TaboosLB.ItemHeight = 24;
            this.TaboosLB.Location = new System.Drawing.Point(468, 223);
            this.TaboosLB.Name = "TaboosLB";
            this.TaboosLB.Size = new System.Drawing.Size(440, 120);
            this.TaboosLB.TabIndex = 60;
            this.TaboosLB.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ModifiersLB_DrawItem);
            this.TaboosLB.DoubleClick += new System.EventHandler(this.TaboosLB_DoubleClick);
            // 
            // NameGameL
            // 
            this.NameGameL.AutoSize = true;
            this.NameGameL.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.NameGameL.Location = new System.Drawing.Point(308, 43);
            this.NameGameL.Name = "NameGameL";
            this.NameGameL.Size = new System.Drawing.Size(127, 21);
            this.NameGameL.TabIndex = 62;
            this.NameGameL.Text = "Name in game:";
            // 
            // ColorL
            // 
            this.ColorL.AutoSize = true;
            this.ColorL.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.ColorL.Location = new System.Drawing.Point(567, 43);
            this.ColorL.Name = "ColorL";
            this.ColorL.Size = new System.Drawing.Size(64, 21);
            this.ColorL.TabIndex = 66;
            this.ColorL.Text = "Color:";
            // 
            // ColorP
            // 
            this.ColorP.Location = new System.Drawing.Point(583, 67);
            this.ColorP.Name = "ColorP";
            this.ColorP.Size = new System.Drawing.Size(34, 32);
            this.ColorP.TabIndex = 67;
            // 
            // RedL
            // 
            this.RedL.AutoSize = true;
            this.RedL.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.RedL.ForeColor = System.Drawing.Color.Red;
            this.RedL.Location = new System.Drawing.Point(637, 43);
            this.RedL.Name = "RedL";
            this.RedL.Size = new System.Drawing.Size(37, 21);
            this.RedL.TabIndex = 68;
            this.RedL.Text = "Red";
            // 
            // GreenL
            // 
            this.GreenL.AutoSize = true;
            this.GreenL.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.GreenL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(250)))), ((int)(((byte)(0)))));
            this.GreenL.Location = new System.Drawing.Point(699, 43);
            this.GreenL.Name = "GreenL";
            this.GreenL.Size = new System.Drawing.Size(55, 21);
            this.GreenL.TabIndex = 69;
            this.GreenL.Text = "Green";
            // 
            // BlueL
            // 
            this.BlueL.AutoSize = true;
            this.BlueL.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.BlueL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(255)))));
            this.BlueL.Location = new System.Drawing.Point(765, 43);
            this.BlueL.Name = "BlueL";
            this.BlueL.Size = new System.Drawing.Size(46, 21);
            this.BlueL.TabIndex = 70;
            this.BlueL.Text = "Blue";
            // 
            // BlueTB
            // 
            this.BlueTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.BlueTB.BackgroundColorFocus = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.BlueTB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.BlueTB.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.BlueTB.BorderSize = 1;
            this.BlueTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.BlueTB.Location = new System.Drawing.Point(769, 67);
            this.BlueTB.Multiline = false;
            this.BlueTB.Name = "BlueTB";
            this.BlueTB.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.BlueTB.ReadOnly = false;
            this.BlueTB.Size = new System.Drawing.Size(60, 32);
            this.BlueTB.TabIndex = 65;
            this.BlueTB.Texts = "";
            this.BlueTB.UnderlinedStyle = false;
            this.BlueTB.CustomTextBox_TextChanged += new System.EventHandler(this.BlueTB_CustomTextBox_TextChanged);
            // 
            // GreenTB
            // 
            this.GreenTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.GreenTB.BackgroundColorFocus = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.GreenTB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.GreenTB.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.GreenTB.BorderSize = 1;
            this.GreenTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.GreenTB.Location = new System.Drawing.Point(703, 67);
            this.GreenTB.Multiline = false;
            this.GreenTB.Name = "GreenTB";
            this.GreenTB.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.GreenTB.ReadOnly = false;
            this.GreenTB.Size = new System.Drawing.Size(60, 32);
            this.GreenTB.TabIndex = 64;
            this.GreenTB.Texts = "";
            this.GreenTB.UnderlinedStyle = false;
            this.GreenTB.CustomTextBox_TextChanged += new System.EventHandler(this.GreenTB_CustomTextBox_TextChanged);
            // 
            // RedTB
            // 
            this.RedTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.RedTB.BackgroundColorFocus = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.RedTB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.RedTB.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.RedTB.BorderSize = 1;
            this.RedTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.RedTB.Location = new System.Drawing.Point(637, 67);
            this.RedTB.Multiline = false;
            this.RedTB.Name = "RedTB";
            this.RedTB.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.RedTB.ReadOnly = false;
            this.RedTB.Size = new System.Drawing.Size(60, 32);
            this.RedTB.TabIndex = 63;
            this.RedTB.Texts = "";
            this.RedTB.UnderlinedStyle = false;
            this.RedTB.CustomTextBox_TextChanged += new System.EventHandler(this.RedTB_CustomTextBox_TextChanged);
            // 
            // NameGameTB
            // 
            this.NameGameTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.NameGameTB.BackgroundColorFocus = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.NameGameTB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.NameGameTB.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.NameGameTB.BorderSize = 1;
            this.NameGameTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.NameGameTB.Location = new System.Drawing.Point(312, 67);
            this.NameGameTB.Multiline = false;
            this.NameGameTB.Name = "NameGameTB";
            this.NameGameTB.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.NameGameTB.ReadOnly = false;
            this.NameGameTB.Size = new System.Drawing.Size(250, 32);
            this.NameGameTB.TabIndex = 61;
            this.NameGameTB.Texts = "";
            this.NameGameTB.UnderlinedStyle = false;
            this.NameGameTB.CustomTextBox_TextChanged += new System.EventHandler(this.NameGameTB_CustomTextBox_TextChanged);
            // 
            // TaboosCB
            // 
            this.TaboosCB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.TaboosCB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.TaboosCB.BorderSize = 1;
            this.TaboosCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.TaboosCB.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaboosCB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.TaboosCB.FormattingEnabled = false;
            this.TaboosCB.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(73)))), ((int)(((byte)(150)))));
            this.TaboosCB.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.TaboosCB.ListTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.TaboosCB.Location = new System.Drawing.Point(468, 185);
            this.TaboosCB.MinimumSize = new System.Drawing.Size(200, 30);
            this.TaboosCB.Name = "TaboosCB";
            this.TaboosCB.Padding = new System.Windows.Forms.Padding(1);
            this.TaboosCB.Size = new System.Drawing.Size(383, 32);
            this.TaboosCB.TabIndex = 56;
            this.TaboosCB.Texts = "";
            // 
            // TraitsCB
            // 
            this.TraitsCB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.TraitsCB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.TraitsCB.BorderSize = 1;
            this.TraitsCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.TraitsCB.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TraitsCB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.TraitsCB.FormattingEnabled = false;
            this.TraitsCB.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(73)))), ((int)(((byte)(150)))));
            this.TraitsCB.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.TraitsCB.ListTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.TraitsCB.Location = new System.Drawing.Point(16, 185);
            this.TraitsCB.MinimumSize = new System.Drawing.Size(200, 30);
            this.TraitsCB.Name = "TraitsCB";
            this.TraitsCB.Padding = new System.Windows.Forms.Padding(1);
            this.TraitsCB.Size = new System.Drawing.Size(383, 32);
            this.TraitsCB.TabIndex = 52;
            this.TraitsCB.Texts = "";
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
            this.NameTB.Size = new System.Drawing.Size(250, 32);
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
            this.TextureTB.Location = new System.Drawing.Point(17, 126);
            this.TextureTB.Multiline = false;
            this.TextureTB.Name = "TextureTB";
            this.TextureTB.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.TextureTB.ReadOnly = false;
            this.TextureTB.Size = new System.Drawing.Size(834, 32);
            this.TextureTB.TabIndex = 38;
            this.TextureTB.Texts = "";
            this.TextureTB.UnderlinedStyle = false;
            this.TextureTB.CustomTextBox_TextChanged += new System.EventHandler(this.TextureTB_CustomTextBox_TextChanged);
            // 
            // ReligionForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(920, 355);
            this.Controls.Add(this.BlueL);
            this.Controls.Add(this.GreenL);
            this.Controls.Add(this.RedL);
            this.Controls.Add(this.ColorP);
            this.Controls.Add(this.ColorL);
            this.Controls.Add(this.BlueTB);
            this.Controls.Add(this.GreenTB);
            this.Controls.Add(this.RedTB);
            this.Controls.Add(this.NameGameL);
            this.Controls.Add(this.NameGameTB);
            this.Controls.Add(this.TaboosLB);
            this.Controls.Add(this.TraitsLB);
            this.Controls.Add(this.TaboosCB);
            this.Controls.Add(this.TraitL);
            this.Controls.Add(this.TraitAddBT);
            this.Controls.Add(this.TraitsCB);
            this.Controls.Add(this.NameL);
            this.Controls.Add(this.NameTB);
            this.Controls.Add(this.TextureL);
            this.Controls.Add(this.TextureTB);
            this.Controls.Add(this.TexturePathBT);
            this.Controls.Add(this.TabooL);
            this.Controls.Add(this.HotBarP);
            this.Controls.Add(this.TabooAddBT);
            this.Controls.Add(this.SaveBT);
            this.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(920, 355);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(920, 355);
            this.Name = "ReligionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Victoria 3 Modding Tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReligionForm_FormClosing);
            this.Load += new System.EventHandler(this.ReligionForm_Load);
            this.HotBarP.ResumeLayout(false);
            this.HotBarP.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button SaveBT;
        private Button TabooAddBT;
        private Panel HotBarP;
        private Button MinimiseBT;
        private Button ChangeSizeBT;
        private Button CloseBT;
        private Label TitleL;
        private Label TabooL;
        private Label TextureL;
        private CustomTextBox TextureTB;
        private Button TexturePathBT;
        private CustomTextBox NameTB;
        private Label NameL;
        private CustomComboBox TraitsCB;
        private Button TraitAddBT;
        private Label TraitL;
        private CustomComboBox TaboosCB;
        private ListBox TraitsLB;
        private ListBox TaboosLB;
        private CustomTextBox NameGameTB;
        private Label NameGameL;
        private Button HelpBT;
        private CustomTextBox RedTB;
        private CustomTextBox GreenTB;
        private CustomTextBox BlueTB;
        private Label ColorL;
        private Panel ColorP;
        private Label RedL;
        private Label GreenL;
        private Label BlueL;
    }
}

