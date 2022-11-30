using System.Windows.Forms;

namespace Victoria_3_Modding_Tool
{
    partial class GoodsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GoodsForm));
            this.SaveBT = new System.Windows.Forms.Button();
            this.HotBarP = new System.Windows.Forms.Panel();
            this.HelpBT = new System.Windows.Forms.Button();
            this.TitleL = new System.Windows.Forms.Label();
            this.MinimiseBT = new System.Windows.Forms.Button();
            this.ChangeSizeBT = new System.Windows.Forms.Button();
            this.CloseBT = new System.Windows.Forms.Button();
            this.TextureL = new System.Windows.Forms.Label();
            this.TexturePathBT = new System.Windows.Forms.Button();
            this.NameL = new System.Windows.Forms.Label();
            this.CostL = new System.Windows.Forms.Label();
            this.CategoryL = new System.Windows.Forms.Label();
            this.FixedL = new System.Windows.Forms.Label();
            this.NameGameL = new System.Windows.Forms.Label();
            this.TradableL = new System.Windows.Forms.Label();
            this.ObsessionL = new System.Windows.Forms.Label();
            this.ConvoyL = new System.Windows.Forms.Label();
            this.TradedL = new System.Windows.Forms.Label();
            this.PrestigeL = new System.Windows.Forms.Label();
            this.ObsessionPL = new System.Windows.Forms.Label();
            this.PrestigePL = new System.Windows.Forms.Label();
            this.ConvoyPL = new System.Windows.Forms.Label();
            this.ConsumptionL = new System.Windows.Forms.Label();
            this.ConsumptionTB = new Victoria_3_Modding_Tool.CustomTextBox();
            this.ConvoyTB = new Victoria_3_Modding_Tool.CustomTextBox();
            this.TradedTB = new Victoria_3_Modding_Tool.CustomTextBox();
            this.PrestigeTB = new Victoria_3_Modding_Tool.CustomTextBox();
            this.ObsessionTB = new Victoria_3_Modding_Tool.CustomTextBox();
            this.TradeableCB = new Victoria_3_Modding_Tool.Custom_Controls.CustomCheckBox();
            this.NameGameTB = new Victoria_3_Modding_Tool.CustomTextBox();
            this.FixedCB = new Victoria_3_Modding_Tool.Custom_Controls.CustomCheckBox();
            this.CategoryCB = new Victoria_3_Modding_Tool.CustomComboBox();
            this.CostTB = new Victoria_3_Modding_Tool.CustomTextBox();
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
            this.SaveBT.Location = new System.Drawing.Point(919, 309);
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
            this.TitleL.Size = new System.Drawing.Size(118, 21);
            this.TitleL.TabIndex = 35;
            this.TitleL.Text = "Goods Editor";
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
            // TextureL
            // 
            this.TextureL.AutoSize = true;
            this.TextureL.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.TextureL.Location = new System.Drawing.Point(12, 161);
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
            this.TexturePathBT.Location = new System.Drawing.Point(928, 185);
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
            // CostL
            // 
            this.CostL.AutoSize = true;
            this.CostL.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.CostL.Location = new System.Drawing.Point(508, 102);
            this.CostL.Name = "CostL";
            this.CostL.Size = new System.Drawing.Size(55, 21);
            this.CostL.TabIndex = 46;
            this.CostL.Text = "Cost:";
            // 
            // CategoryL
            // 
            this.CategoryL.AutoSize = true;
            this.CategoryL.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.CategoryL.Location = new System.Drawing.Point(508, 43);
            this.CategoryL.Name = "CategoryL";
            this.CategoryL.Size = new System.Drawing.Size(91, 21);
            this.CategoryL.TabIndex = 48;
            this.CategoryL.Text = "Category:";
            // 
            // FixedL
            // 
            this.FixedL.AutoSize = true;
            this.FixedL.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.FixedL.Location = new System.Drawing.Point(861, 131);
            this.FixedL.Name = "FixedL";
            this.FixedL.Size = new System.Drawing.Size(109, 21);
            this.FixedL.TabIndex = 49;
            this.FixedL.Text = "Fixed Price";
            // 
            // NameGameL
            // 
            this.NameGameL.AutoSize = true;
            this.NameGameL.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.NameGameL.Location = new System.Drawing.Point(12, 102);
            this.NameGameL.Name = "NameGameL";
            this.NameGameL.Size = new System.Drawing.Size(127, 21);
            this.NameGameL.TabIndex = 62;
            this.NameGameL.Text = "Name in game:";
            // 
            // TradableL
            // 
            this.TradableL.AutoSize = true;
            this.TradableL.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.TradableL.Location = new System.Drawing.Point(861, 72);
            this.TradableL.Name = "TradableL";
            this.TradableL.Size = new System.Drawing.Size(91, 21);
            this.TradableL.TabIndex = 64;
            this.TradableL.Text = "Tradeable";
            // 
            // ObsessionL
            // 
            this.ObsessionL.AutoSize = true;
            this.ObsessionL.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.ObsessionL.Location = new System.Drawing.Point(13, 220);
            this.ObsessionL.Name = "ObsessionL";
            this.ObsessionL.Size = new System.Drawing.Size(163, 21);
            this.ObsessionL.TabIndex = 66;
            this.ObsessionL.Text = "Obsession Chance:";
            // 
            // ConvoyL
            // 
            this.ConvoyL.AutoSize = true;
            this.ConvoyL.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.ConvoyL.Location = new System.Drawing.Point(398, 220);
            this.ConvoyL.Name = "ConvoyL";
            this.ConvoyL.Size = new System.Drawing.Size(172, 21);
            this.ConvoyL.TabIndex = 67;
            this.ConvoyL.Text = "Convoy Multiplier:";
            // 
            // TradedL
            // 
            this.TradedL.AutoSize = true;
            this.TradedL.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.TradedL.Location = new System.Drawing.Point(398, 279);
            this.TradedL.Name = "TradedL";
            this.TradedL.Size = new System.Drawing.Size(154, 21);
            this.TradedL.TabIndex = 71;
            this.TradedL.Text = "Traded Quantity:";
            // 
            // PrestigeL
            // 
            this.PrestigeL.AutoSize = true;
            this.PrestigeL.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.PrestigeL.Location = new System.Drawing.Point(13, 279);
            this.PrestigeL.Name = "PrestigeL";
            this.PrestigeL.Size = new System.Drawing.Size(154, 21);
            this.PrestigeL.TabIndex = 70;
            this.PrestigeL.Text = "Prestige Factor:";
            // 
            // ObsessionPL
            // 
            this.ObsessionPL.AutoSize = true;
            this.ObsessionPL.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.ObsessionPL.Location = new System.Drawing.Point(241, 250);
            this.ObsessionPL.Name = "ObsessionPL";
            this.ObsessionPL.Size = new System.Drawing.Size(19, 21);
            this.ObsessionPL.TabIndex = 78;
            this.ObsessionPL.Text = "%";
            // 
            // PrestigePL
            // 
            this.PrestigePL.AutoSize = true;
            this.PrestigePL.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.PrestigePL.Location = new System.Drawing.Point(627, 250);
            this.PrestigePL.Name = "PrestigePL";
            this.PrestigePL.Size = new System.Drawing.Size(19, 21);
            this.PrestigePL.TabIndex = 79;
            this.PrestigePL.Text = "%";
            // 
            // ConvoyPL
            // 
            this.ConvoyPL.AutoSize = true;
            this.ConvoyPL.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.ConvoyPL.Location = new System.Drawing.Point(241, 306);
            this.ConvoyPL.Name = "ConvoyPL";
            this.ConvoyPL.Size = new System.Drawing.Size(19, 21);
            this.ConvoyPL.TabIndex = 80;
            this.ConvoyPL.Text = "%";
            // 
            // ConsumptionL
            // 
            this.ConsumptionL.AutoSize = true;
            this.ConsumptionL.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.ConsumptionL.Location = new System.Drawing.Point(729, 219);
            this.ConsumptionL.Name = "ConsumptionL";
            this.ConsumptionL.Size = new System.Drawing.Size(199, 21);
            this.ConsumptionL.TabIndex = 81;
            this.ConsumptionL.Text = "Consumption Tax Cost:";
            // 
            // ConsumptionTB
            // 
            this.ConsumptionTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.ConsumptionTB.BackgroundColorFocus = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.ConsumptionTB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.ConsumptionTB.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.ConsumptionTB.BorderSize = 1;
            this.ConsumptionTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.ConsumptionTB.Location = new System.Drawing.Point(733, 243);
            this.ConsumptionTB.Multiline = false;
            this.ConsumptionTB.Name = "ConsumptionTB";
            this.ConsumptionTB.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.ConsumptionTB.ReadOnly = false;
            this.ConsumptionTB.Size = new System.Drawing.Size(219, 24);
            this.ConsumptionTB.TabIndex = 82;
            this.ConsumptionTB.Texts = "";
            this.ConsumptionTB.UnderlinedStyle = false;
            this.ConsumptionTB.CustomTextBox_TextChanged += new System.EventHandler(this.ConsumptionTB_CustomTextBox_TextChanged);
            // 
            // ConvoyTB
            // 
            this.ConvoyTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.ConvoyTB.BackgroundColorFocus = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.ConvoyTB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.ConvoyTB.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.ConvoyTB.BorderSize = 1;
            this.ConvoyTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.ConvoyTB.Location = new System.Drawing.Point(402, 243);
            this.ConvoyTB.Multiline = false;
            this.ConvoyTB.Name = "ConvoyTB";
            this.ConvoyTB.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.ConvoyTB.ReadOnly = false;
            this.ConvoyTB.Size = new System.Drawing.Size(219, 24);
            this.ConvoyTB.TabIndex = 77;
            this.ConvoyTB.Texts = "";
            this.ConvoyTB.UnderlinedStyle = false;
            this.ConvoyTB.CustomTextBox_TextChanged += new System.EventHandler(this.ConvoyTB_CustomTextBox_TextChanged);
            // 
            // TradedTB
            // 
            this.TradedTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.TradedTB.BackgroundColorFocus = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.TradedTB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.TradedTB.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.TradedTB.BorderSize = 1;
            this.TradedTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.TradedTB.Location = new System.Drawing.Point(402, 303);
            this.TradedTB.Multiline = false;
            this.TradedTB.Name = "TradedTB";
            this.TradedTB.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.TradedTB.ReadOnly = false;
            this.TradedTB.Size = new System.Drawing.Size(219, 24);
            this.TradedTB.TabIndex = 76;
            this.TradedTB.Texts = "";
            this.TradedTB.UnderlinedStyle = false;
            this.TradedTB.CustomTextBox_TextChanged += new System.EventHandler(this.TradedTB_CustomTextBox_TextChanged);
            // 
            // PrestigeTB
            // 
            this.PrestigeTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.PrestigeTB.BackgroundColorFocus = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.PrestigeTB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.PrestigeTB.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.PrestigeTB.BorderSize = 1;
            this.PrestigeTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.PrestigeTB.Location = new System.Drawing.Point(17, 303);
            this.PrestigeTB.Multiline = false;
            this.PrestigeTB.Name = "PrestigeTB";
            this.PrestigeTB.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.PrestigeTB.ReadOnly = false;
            this.PrestigeTB.Size = new System.Drawing.Size(219, 24);
            this.PrestigeTB.TabIndex = 75;
            this.PrestigeTB.Texts = "";
            this.PrestigeTB.UnderlinedStyle = false;
            this.PrestigeTB.CustomTextBox_TextChanged += new System.EventHandler(this.PrestigeTB_CustomTextBox_TextChanged);
            // 
            // ObsessionTB
            // 
            this.ObsessionTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.ObsessionTB.BackgroundColorFocus = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.ObsessionTB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.ObsessionTB.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.ObsessionTB.BorderSize = 1;
            this.ObsessionTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.ObsessionTB.Location = new System.Drawing.Point(16, 243);
            this.ObsessionTB.Multiline = false;
            this.ObsessionTB.Name = "ObsessionTB";
            this.ObsessionTB.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.ObsessionTB.ReadOnly = false;
            this.ObsessionTB.Size = new System.Drawing.Size(219, 24);
            this.ObsessionTB.TabIndex = 74;
            this.ObsessionTB.Texts = "";
            this.ObsessionTB.UnderlinedStyle = false;
            this.ObsessionTB.CustomTextBox_TextChanged += new System.EventHandler(this.ObsessionTB_CustomTextBox_TextChanged);
            // 
            // TradeableCB
            // 
            this.TradeableCB.AutoSize = true;
            this.TradeableCB.Checked = true;
            this.TradeableCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TradeableCB.Location = new System.Drawing.Point(793, 67);
            this.TradeableCB.MinimumSize = new System.Drawing.Size(62, 32);
            this.TradeableCB.Name = "TradeableCB";
            this.TradeableCB.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.TradeableCB.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.TradeableCB.OnBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(53)))), ((int)(((byte)(130)))));
            this.TradeableCB.OnToggleColor = System.Drawing.Color.Gainsboro;
            this.TradeableCB.Size = new System.Drawing.Size(62, 32);
            this.TradeableCB.TabIndex = 63;
            this.TradeableCB.UseVisualStyleBackColor = true;
            this.TradeableCB.CheckedChanged += new System.EventHandler(this.CB_CheckedChanged);
            // 
            // NameGameTB
            // 
            this.NameGameTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.NameGameTB.BackgroundColorFocus = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.NameGameTB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.NameGameTB.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.NameGameTB.BorderSize = 1;
            this.NameGameTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.NameGameTB.Location = new System.Drawing.Point(16, 126);
            this.NameGameTB.Multiline = false;
            this.NameGameTB.Name = "NameGameTB";
            this.NameGameTB.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.NameGameTB.ReadOnly = false;
            this.NameGameTB.Size = new System.Drawing.Size(469, 24);
            this.NameGameTB.TabIndex = 61;
            this.NameGameTB.Texts = "";
            this.NameGameTB.UnderlinedStyle = false;
            // 
            // FixedCB
            // 
            this.FixedCB.AutoSize = true;
            this.FixedCB.Location = new System.Drawing.Point(793, 126);
            this.FixedCB.MinimumSize = new System.Drawing.Size(62, 32);
            this.FixedCB.Name = "FixedCB";
            this.FixedCB.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.FixedCB.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.FixedCB.OnBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(53)))), ((int)(((byte)(130)))));
            this.FixedCB.OnToggleColor = System.Drawing.Color.Gainsboro;
            this.FixedCB.Size = new System.Drawing.Size(62, 32);
            this.FixedCB.TabIndex = 45;
            this.FixedCB.UseVisualStyleBackColor = true;
            this.FixedCB.CheckedChanged += new System.EventHandler(this.CB_CheckedChanged);
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
            this.CategoryCB.Location = new System.Drawing.Point(512, 67);
            this.CategoryCB.MinimumSize = new System.Drawing.Size(120, 30);
            this.CategoryCB.Name = "CategoryCB";
            this.CategoryCB.Padding = new System.Windows.Forms.Padding(1);
            this.CategoryCB.Size = new System.Drawing.Size(267, 32);
            this.CategoryCB.TabIndex = 44;
            this.CategoryCB.Texts = "";
            this.CategoryCB.OnSelectedIndexChanged += new System.EventHandler(this.CategoryCB_OnSelectedIndexChanged);
            // 
            // CostTB
            // 
            this.CostTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.CostTB.BackgroundColorFocus = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.CostTB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.CostTB.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.CostTB.BorderSize = 1;
            this.CostTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.CostTB.Location = new System.Drawing.Point(512, 126);
            this.CostTB.Multiline = false;
            this.CostTB.Name = "CostTB";
            this.CostTB.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.CostTB.ReadOnly = false;
            this.CostTB.Size = new System.Drawing.Size(267, 24);
            this.CostTB.TabIndex = 42;
            this.CostTB.Texts = "";
            this.CostTB.UnderlinedStyle = false;
            this.CostTB.CustomTextBox_TextChanged += new System.EventHandler(this.CostTB_CustomTextBox_TextChanged);
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
            this.NameTB.Size = new System.Drawing.Size(469, 24);
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
            this.TextureTB.Location = new System.Drawing.Point(17, 185);
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
            // GoodsForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(995, 350);
            this.Controls.Add(this.ConsumptionTB);
            this.Controls.Add(this.ConsumptionL);
            this.Controls.Add(this.ConvoyPL);
            this.Controls.Add(this.PrestigePL);
            this.Controls.Add(this.ObsessionPL);
            this.Controls.Add(this.ConvoyTB);
            this.Controls.Add(this.TradedTB);
            this.Controls.Add(this.PrestigeTB);
            this.Controls.Add(this.ObsessionTB);
            this.Controls.Add(this.TradedL);
            this.Controls.Add(this.PrestigeL);
            this.Controls.Add(this.ConvoyL);
            this.Controls.Add(this.ObsessionL);
            this.Controls.Add(this.TradableL);
            this.Controls.Add(this.TradeableCB);
            this.Controls.Add(this.NameGameL);
            this.Controls.Add(this.NameGameTB);
            this.Controls.Add(this.FixedL);
            this.Controls.Add(this.CategoryL);
            this.Controls.Add(this.CostL);
            this.Controls.Add(this.FixedCB);
            this.Controls.Add(this.CategoryCB);
            this.Controls.Add(this.CostTB);
            this.Controls.Add(this.NameL);
            this.Controls.Add(this.NameTB);
            this.Controls.Add(this.TextureL);
            this.Controls.Add(this.TextureTB);
            this.Controls.Add(this.TexturePathBT);
            this.Controls.Add(this.HotBarP);
            this.Controls.Add(this.SaveBT);
            this.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(995, 350);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(995, 350);
            this.Name = "GoodsForm";
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
        private Panel HotBarP;
        private Button MinimiseBT;
        private Button ChangeSizeBT;
        private Button CloseBT;
        private Label TitleL;
        private Label TextureL;
        private CustomTextBox TextureTB;
        private Button TexturePathBT;
        private CustomTextBox NameTB;
        private Label NameL;
        private CustomTextBox CostTB;
        private CustomComboBox CategoryCB;
        private Custom_Controls.CustomCheckBox FixedCB;
        private Label CostL;
        private Label CategoryL;
        private Label FixedL;
        private CustomTextBox NameGameTB;
        private Label NameGameL;
        private Button HelpBT;
        private Label TradableL;
        private Custom_Controls.CustomCheckBox TradeableCB;
        private Label ObsessionL;
        private Label ConvoyL;
        private Label TradedL;
        private Label PrestigeL;
        private CustomTextBox ObsessionTB;
        private CustomTextBox PrestigeTB;
        private CustomTextBox TradedTB;
        private CustomTextBox ConvoyTB;
        private Label ObsessionPL;
        private Label PrestigePL;
        private Label ConvoyPL;
        private CustomTextBox ConsumptionTB;
        private Label ConsumptionL;
    }
}

