using System.Windows.Forms;

namespace Victoria_3_Modding_Tool
{
    partial class ModifiersTypesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModifiersTypesForm));
            this.SaveBT = new System.Windows.Forms.Button();
            this.HotBarP = new System.Windows.Forms.Panel();
            this.HelpBT = new System.Windows.Forms.Button();
            this.TitleL = new System.Windows.Forms.Label();
            this.MinimiseBT = new System.Windows.Forms.Button();
            this.ChangeSizeBT = new System.Windows.Forms.Button();
            this.CloseBT = new System.Windows.Forms.Button();
            this.NameL = new System.Windows.Forms.Label();
            this.NumDeciL = new System.Windows.Forms.Label();
            this.GoodL = new System.Windows.Forms.Label();
            this.PercentageL = new System.Windows.Forms.Label();
            this.NameTB = new Victoria_3_Modding_Tool.CustomTextBox();
            this.NeutralL = new System.Windows.Forms.Label();
            this.InvertL = new System.Windows.Forms.Label();
            this.BooleanL = new System.Windows.Forms.Label();
            this.PostfixL = new System.Windows.Forms.Label();
            this.PostfixTB = new Victoria_3_Modding_Tool.CustomTextBox();
            this.TranslateL = new System.Windows.Forms.Label();
            this.TranslateTB = new Victoria_3_Modding_Tool.CustomTextBox();
            this.AIValueL = new System.Windows.Forms.Label();
            this.AIValueTB = new Victoria_3_Modding_Tool.CustomTextBox();
            this.GoodTB = new Victoria_3_Modding_Tool.CustomTextBox();
            this.PercentageTB = new Victoria_3_Modding_Tool.CustomTextBox();
            this.NeutralTB = new Victoria_3_Modding_Tool.CustomTextBox();
            this.InvertTB = new Victoria_3_Modding_Tool.CustomTextBox();
            this.BooleanTB = new Victoria_3_Modding_Tool.CustomTextBox();
            this.NumDeciTB = new Victoria_3_Modding_Tool.CustomTextBox();
            this.ChangeBT = new System.Windows.Forms.Button();
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
            this.SaveBT.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SaveBT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.SaveBT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SaveBT.Location = new System.Drawing.Point(547, 216);
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
            this.HotBarP.Controls.Add(this.ChangeBT);
            this.HotBarP.Controls.Add(this.HelpBT);
            this.HotBarP.Controls.Add(this.TitleL);
            this.HotBarP.Controls.Add(this.MinimiseBT);
            this.HotBarP.Controls.Add(this.ChangeSizeBT);
            this.HotBarP.Controls.Add(this.CloseBT);
            this.HotBarP.Dock = System.Windows.Forms.DockStyle.Top;
            this.HotBarP.Location = new System.Drawing.Point(0, 0);
            this.HotBarP.Name = "HotBarP";
            this.HotBarP.Size = new System.Drawing.Size(620, 32);
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
            this.HelpBT.Location = new System.Drawing.Point(476, 0);
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
            this.TitleL.Size = new System.Drawing.Size(199, 21);
            this.TitleL.TabIndex = 35;
            this.TitleL.Text = "Modifier Types Editor";
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
            this.MinimiseBT.Location = new System.Drawing.Point(512, 0);
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
            this.ChangeSizeBT.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ChangeSizeBT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.ChangeSizeBT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ChangeSizeBT.Location = new System.Drawing.Point(548, 0);
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
            this.CloseBT.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CloseBT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.CloseBT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CloseBT.Location = new System.Drawing.Point(584, 0);
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
            // NameL
            // 
            this.NameL.AutoSize = true;
            this.NameL.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NameL.Location = new System.Drawing.Point(12, 43);
            this.NameL.Name = "NameL";
            this.NameL.Size = new System.Drawing.Size(55, 21);
            this.NameL.TabIndex = 41;
            this.NameL.Text = "Name:";
            // 
            // NumDeciL
            // 
            this.NumDeciL.AutoSize = true;
            this.NumDeciL.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NumDeciL.Location = new System.Drawing.Point(431, 43);
            this.NumDeciL.Name = "NumDeciL";
            this.NumDeciL.Size = new System.Drawing.Size(181, 21);
            this.NumDeciL.TabIndex = 48;
            this.NumDeciL.Text = "Number of decimals:";
            // 
            // GoodL
            // 
            this.GoodL.AutoSize = true;
            this.GoodL.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GoodL.Location = new System.Drawing.Point(85, 181);
            this.GoodL.Name = "GoodL";
            this.GoodL.Size = new System.Drawing.Size(46, 21);
            this.GoodL.TabIndex = 49;
            this.GoodL.Text = "Good";
            // 
            // PercentageL
            // 
            this.PercentageL.AutoSize = true;
            this.PercentageL.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PercentageL.Location = new System.Drawing.Point(85, 221);
            this.PercentageL.Name = "PercentageL";
            this.PercentageL.Size = new System.Drawing.Size(100, 21);
            this.PercentageL.TabIndex = 64;
            this.PercentageL.Text = "Percentage";
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
            this.NameTB.Size = new System.Drawing.Size(413, 30);
            this.NameTB.TabIndex = 40;
            this.NameTB.Texts = "";
            this.NameTB.UnderlinedStyle = false;
            this.NameTB.CustomTextBox_TextChanged += new System.EventHandler(this.NameTB_CustomTextBox_TextChanged);
            // 
            // NeutralL
            // 
            this.NeutralL.AutoSize = true;
            this.NeutralL.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NeutralL.Location = new System.Drawing.Point(315, 221);
            this.NeutralL.Name = "NeutralL";
            this.NeutralL.Size = new System.Drawing.Size(73, 21);
            this.NeutralL.TabIndex = 68;
            this.NeutralL.Text = "Neutral";
            // 
            // InvertL
            // 
            this.InvertL.AutoSize = true;
            this.InvertL.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.InvertL.Location = new System.Drawing.Point(315, 181);
            this.InvertL.Name = "InvertL";
            this.InvertL.Size = new System.Drawing.Size(64, 21);
            this.InvertL.TabIndex = 66;
            this.InvertL.Text = "Invert";
            // 
            // BooleanL
            // 
            this.BooleanL.AutoSize = true;
            this.BooleanL.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BooleanL.Location = new System.Drawing.Point(518, 181);
            this.BooleanL.Name = "BooleanL";
            this.BooleanL.Size = new System.Drawing.Size(73, 21);
            this.BooleanL.TabIndex = 70;
            this.BooleanL.Text = "Boolean";
            // 
            // PostfixL
            // 
            this.PostfixL.AutoSize = true;
            this.PostfixL.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PostfixL.Location = new System.Drawing.Point(357, 102);
            this.PostfixL.Name = "PostfixL";
            this.PostfixL.Size = new System.Drawing.Size(82, 21);
            this.PostfixL.TabIndex = 72;
            this.PostfixL.Text = "Postfix:";
            // 
            // PostfixTB
            // 
            this.PostfixTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.PostfixTB.BackgroundColorFocus = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.PostfixTB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.PostfixTB.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.PostfixTB.BorderSize = 1;
            this.PostfixTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.PostfixTB.Location = new System.Drawing.Point(361, 129);
            this.PostfixTB.Multiline = false;
            this.PostfixTB.Name = "PostfixTB";
            this.PostfixTB.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.PostfixTB.ReadOnly = false;
            this.PostfixTB.Size = new System.Drawing.Size(246, 30);
            this.PostfixTB.TabIndex = 71;
            this.PostfixTB.Texts = "";
            this.PostfixTB.UnderlinedStyle = false;
            this.PostfixTB.CustomTextBox_TextChanged += new System.EventHandler(this.PostfixTB_CustomTextBox_TextChanged);
            // 
            // TranslateL
            // 
            this.TranslateL.AutoSize = true;
            this.TranslateL.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TranslateL.Location = new System.Drawing.Point(106, 105);
            this.TranslateL.Name = "TranslateL";
            this.TranslateL.Size = new System.Drawing.Size(100, 21);
            this.TranslateL.TabIndex = 74;
            this.TranslateL.Text = "Translate:";
            // 
            // TranslateTB
            // 
            this.TranslateTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.TranslateTB.BackgroundColorFocus = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.TranslateTB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.TranslateTB.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.TranslateTB.BorderSize = 1;
            this.TranslateTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.TranslateTB.Location = new System.Drawing.Point(110, 129);
            this.TranslateTB.Multiline = false;
            this.TranslateTB.Name = "TranslateTB";
            this.TranslateTB.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.TranslateTB.ReadOnly = false;
            this.TranslateTB.Size = new System.Drawing.Size(245, 30);
            this.TranslateTB.TabIndex = 73;
            this.TranslateTB.Texts = "";
            this.TranslateTB.UnderlinedStyle = false;
            this.TranslateTB.CustomTextBox_TextChanged += new System.EventHandler(this.TranslateTB_CustomTextBox_TextChanged);
            // 
            // AIValueL
            // 
            this.AIValueL.AutoSize = true;
            this.AIValueL.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AIValueL.Location = new System.Drawing.Point(12, 105);
            this.AIValueL.Name = "AIValueL";
            this.AIValueL.Size = new System.Drawing.Size(91, 21);
            this.AIValueL.TabIndex = 76;
            this.AIValueL.Text = "AI Value:";
            // 
            // AIValueTB
            // 
            this.AIValueTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.AIValueTB.BackgroundColorFocus = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.AIValueTB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.AIValueTB.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.AIValueTB.BorderSize = 1;
            this.AIValueTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.AIValueTB.Location = new System.Drawing.Point(16, 129);
            this.AIValueTB.Multiline = false;
            this.AIValueTB.Name = "AIValueTB";
            this.AIValueTB.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.AIValueTB.ReadOnly = false;
            this.AIValueTB.Size = new System.Drawing.Size(88, 30);
            this.AIValueTB.TabIndex = 75;
            this.AIValueTB.Texts = "";
            this.AIValueTB.UnderlinedStyle = false;
            this.AIValueTB.CustomTextBox_TextChanged += new System.EventHandler(this.AIValueTB_CustomTextBox_TextChanged);
            // 
            // GoodTB
            // 
            this.GoodTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.GoodTB.BackgroundColorFocus = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.GoodTB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.GoodTB.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.GoodTB.BorderSize = 1;
            this.GoodTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.GoodTB.Location = new System.Drawing.Point(16, 178);
            this.GoodTB.Multiline = false;
            this.GoodTB.Name = "GoodTB";
            this.GoodTB.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.GoodTB.ReadOnly = false;
            this.GoodTB.Size = new System.Drawing.Size(57, 30);
            this.GoodTB.TabIndex = 77;
            this.GoodTB.Texts = "";
            this.GoodTB.UnderlinedStyle = false;
            this.GoodTB.CustomTextBox_TextChanged += new System.EventHandler(this.GoodTB_CustomTextBox_TextChanged);
            // 
            // PercentageTB
            // 
            this.PercentageTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.PercentageTB.BackgroundColorFocus = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.PercentageTB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.PercentageTB.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.PercentageTB.BorderSize = 1;
            this.PercentageTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.PercentageTB.Location = new System.Drawing.Point(16, 216);
            this.PercentageTB.Multiline = false;
            this.PercentageTB.Name = "PercentageTB";
            this.PercentageTB.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.PercentageTB.ReadOnly = false;
            this.PercentageTB.Size = new System.Drawing.Size(57, 30);
            this.PercentageTB.TabIndex = 78;
            this.PercentageTB.Texts = "";
            this.PercentageTB.UnderlinedStyle = false;
            this.PercentageTB.CustomTextBox_TextChanged += new System.EventHandler(this.PercentageTB_CustomTextBox_TextChanged);
            // 
            // NeutralTB
            // 
            this.NeutralTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.NeutralTB.BackgroundColorFocus = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.NeutralTB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.NeutralTB.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.NeutralTB.BorderSize = 1;
            this.NeutralTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.NeutralTB.Location = new System.Drawing.Point(252, 216);
            this.NeutralTB.Multiline = false;
            this.NeutralTB.Name = "NeutralTB";
            this.NeutralTB.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.NeutralTB.ReadOnly = false;
            this.NeutralTB.Size = new System.Drawing.Size(57, 30);
            this.NeutralTB.TabIndex = 80;
            this.NeutralTB.Texts = "";
            this.NeutralTB.UnderlinedStyle = false;
            this.NeutralTB.CustomTextBox_TextChanged += new System.EventHandler(this.NeutralTB_CustomTextBox_TextChanged);
            // 
            // InvertTB
            // 
            this.InvertTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.InvertTB.BackgroundColorFocus = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.InvertTB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.InvertTB.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.InvertTB.BorderSize = 1;
            this.InvertTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.InvertTB.Location = new System.Drawing.Point(252, 178);
            this.InvertTB.Multiline = false;
            this.InvertTB.Name = "InvertTB";
            this.InvertTB.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.InvertTB.ReadOnly = false;
            this.InvertTB.Size = new System.Drawing.Size(57, 30);
            this.InvertTB.TabIndex = 79;
            this.InvertTB.Texts = "";
            this.InvertTB.UnderlinedStyle = false;
            this.InvertTB.CustomTextBox_TextChanged += new System.EventHandler(this.InvertTB_CustomTextBox_TextChanged);
            // 
            // BooleanTB
            // 
            this.BooleanTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.BooleanTB.BackgroundColorFocus = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.BooleanTB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.BooleanTB.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.BooleanTB.BorderSize = 1;
            this.BooleanTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.BooleanTB.Location = new System.Drawing.Point(455, 178);
            this.BooleanTB.Multiline = false;
            this.BooleanTB.Name = "BooleanTB";
            this.BooleanTB.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.BooleanTB.ReadOnly = false;
            this.BooleanTB.Size = new System.Drawing.Size(57, 30);
            this.BooleanTB.TabIndex = 81;
            this.BooleanTB.Texts = "";
            this.BooleanTB.UnderlinedStyle = false;
            this.BooleanTB.CustomTextBox_TextChanged += new System.EventHandler(this.BooleanTB_CustomTextBox_TextChanged);
            // 
            // NumDeciTB
            // 
            this.NumDeciTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.NumDeciTB.BackgroundColorFocus = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.NumDeciTB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.NumDeciTB.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.NumDeciTB.BorderSize = 1;
            this.NumDeciTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.NumDeciTB.Location = new System.Drawing.Point(435, 67);
            this.NumDeciTB.Multiline = false;
            this.NumDeciTB.Name = "NumDeciTB";
            this.NumDeciTB.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.NumDeciTB.ReadOnly = false;
            this.NumDeciTB.Size = new System.Drawing.Size(172, 30);
            this.NumDeciTB.TabIndex = 82;
            this.NumDeciTB.Texts = "";
            this.NumDeciTB.UnderlinedStyle = false;
            this.NumDeciTB.CustomTextBox_TextChanged += new System.EventHandler(this.NumDeciTB_CustomTextBox_TextChanged);
            // 
            // ChangeBT
            // 
            this.ChangeBT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.ChangeBT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ChangeBT.Dock = System.Windows.Forms.DockStyle.Right;
            this.ChangeBT.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.ChangeBT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(126)))), ((int)(((byte)(255)))));
            this.ChangeBT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(131)))), ((int)(((byte)(255)))));
            this.ChangeBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChangeBT.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ChangeBT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.ChangeBT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ChangeBT.Location = new System.Drawing.Point(440, 0);
            this.ChangeBT.Name = "ChangeBT";
            this.ChangeBT.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.ChangeBT.Size = new System.Drawing.Size(36, 32);
            this.ChangeBT.TabIndex = 40;
            this.ChangeBT.Text = "⇌";
            this.ChangeBT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ChangeBT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ChangeBT.UseVisualStyleBackColor = false;
            this.ChangeBT.Click += new System.EventHandler(this.ChangeBT_Click);
            // 
            // ModifiersTypesForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(620, 260);
            this.Controls.Add(this.NumDeciTB);
            this.Controls.Add(this.BooleanTB);
            this.Controls.Add(this.NeutralTB);
            this.Controls.Add(this.InvertTB);
            this.Controls.Add(this.PercentageTB);
            this.Controls.Add(this.GoodTB);
            this.Controls.Add(this.AIValueL);
            this.Controls.Add(this.AIValueTB);
            this.Controls.Add(this.TranslateL);
            this.Controls.Add(this.TranslateTB);
            this.Controls.Add(this.PostfixL);
            this.Controls.Add(this.PostfixTB);
            this.Controls.Add(this.BooleanL);
            this.Controls.Add(this.NeutralL);
            this.Controls.Add(this.InvertL);
            this.Controls.Add(this.PercentageL);
            this.Controls.Add(this.GoodL);
            this.Controls.Add(this.NumDeciL);
            this.Controls.Add(this.NameL);
            this.Controls.Add(this.NameTB);
            this.Controls.Add(this.HotBarP);
            this.Controls.Add(this.SaveBT);
            this.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(620, 260);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(620, 260);
            this.Name = "ModifiersTypesForm";
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
        private CustomTextBox NameTB;
        private Label NameL;
        private Label NumDeciL;
        private Label GoodL;
        private Button HelpBT;
        private Label PercentageL;
        private Label NeutralL;
        private Label InvertL;
        private Label BooleanL;
        private Label PostfixL;
        private CustomTextBox PostfixTB;
        private Label TranslateL;
        private CustomTextBox TranslateTB;
        private Label AIValueL;
        private CustomTextBox AIValueTB;
        private CustomTextBox GoodTB;
        private CustomTextBox PercentageTB;
        private CustomTextBox NeutralTB;
        private CustomTextBox InvertTB;
        private CustomTextBox BooleanTB;
        private CustomTextBox NumDeciTB;
        private Button ChangeBT;
    }
}

