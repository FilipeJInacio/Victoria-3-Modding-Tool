using System.Windows.Forms;

namespace Victoria_3_Modding_Tool
{
    partial class PathForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PathForm));
            this.CreateBT = new System.Windows.Forms.Button();
            this.VicPathBT = new System.Windows.Forms.Button();
            this.HotBarP = new System.Windows.Forms.Panel();
            this.TitleL = new System.Windows.Forms.Label();
            this.MinimiseBT = new System.Windows.Forms.Button();
            this.ChangeSizeBT = new System.Windows.Forms.Button();
            this.CloseBT = new System.Windows.Forms.Button();
            this.BackBT = new System.Windows.Forms.Button();
            this.VickyPathL = new System.Windows.Forms.Label();
            this.ProjPathL = new System.Windows.Forms.Label();
            this.ProjPathBT = new System.Windows.Forms.Button();
            this.ProjNameL = new System.Windows.Forms.Label();
            this.LanguageL = new System.Windows.Forms.Label();
            this.ModL = new System.Windows.Forms.Label();
            this.ModPathBT = new System.Windows.Forms.Button();
            this.AdviceL = new System.Windows.Forms.Label();
            this.ModPathTB = new Victoria_3_Modding_Tool.CustomTextBox();
            this.LanguageCB = new Victoria_3_Modding_Tool.CustomComboBox();
            this.PNameTB = new Victoria_3_Modding_Tool.CustomTextBox();
            this.ProjPathTB = new Victoria_3_Modding_Tool.CustomTextBox();
            this.VickyPathTB = new Victoria_3_Modding_Tool.CustomTextBox();
            this.HelpBT = new System.Windows.Forms.Button();
            this.HotBarP.SuspendLayout();
            this.SuspendLayout();
            // 
            // CreateBT
            // 
            this.CreateBT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(53)))), ((int)(((byte)(130)))));
            this.CreateBT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CreateBT.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.CreateBT.FlatAppearance.BorderSize = 0;
            this.CreateBT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.CreateBT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.CreateBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateBT.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.CreateBT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.CreateBT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CreateBT.Location = new System.Drawing.Point(699, 356);
            this.CreateBT.Name = "CreateBT";
            this.CreateBT.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.CreateBT.Size = new System.Drawing.Size(80, 32);
            this.CreateBT.TabIndex = 28;
            this.CreateBT.Text = "Load";
            this.CreateBT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CreateBT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CreateBT.UseVisualStyleBackColor = false;
            this.CreateBT.Click += new System.EventHandler(this.CreateBT_Click);
            // 
            // VicPathBT
            // 
            this.VicPathBT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.VicPathBT.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.VicPathBT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(29)))), ((int)(((byte)(70)))));
            this.VicPathBT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(34)))), ((int)(((byte)(75)))));
            this.VicPathBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VicPathBT.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.VicPathBT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.VicPathBT.Location = new System.Drawing.Point(728, 247);
            this.VicPathBT.Name = "VicPathBT";
            this.VicPathBT.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.VicPathBT.Size = new System.Drawing.Size(51, 32);
            this.VicPathBT.TabIndex = 31;
            this.VicPathBT.Text = "...";
            this.VicPathBT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.VicPathBT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.VicPathBT.UseVisualStyleBackColor = false;
            this.VicPathBT.Click += new System.EventHandler(this.VicPathBT_Click);
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
            this.HotBarP.Size = new System.Drawing.Size(800, 32);
            this.HotBarP.TabIndex = 32;
            this.HotBarP.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HotBarP_MouseDown);
            // 
            // TitleL
            // 
            this.TitleL.AutoSize = true;
            this.TitleL.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.TitleL.Location = new System.Drawing.Point(12, 6);
            this.TitleL.Name = "TitleL";
            this.TitleL.Size = new System.Drawing.Size(181, 21);
            this.TitleL.TabIndex = 35;
            this.TitleL.Text = "Project Information";
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
            this.MinimiseBT.Location = new System.Drawing.Point(692, 0);
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
            this.ChangeSizeBT.Location = new System.Drawing.Point(728, 0);
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
            this.CloseBT.Location = new System.Drawing.Point(764, 0);
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
            // BackBT
            // 
            this.BackBT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.BackBT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BackBT.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.BackBT.FlatAppearance.BorderSize = 0;
            this.BackBT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.BackBT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.BackBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackBT.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.BackBT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.BackBT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BackBT.Location = new System.Drawing.Point(613, 356);
            this.BackBT.Name = "BackBT";
            this.BackBT.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.BackBT.Size = new System.Drawing.Size(80, 32);
            this.BackBT.TabIndex = 34;
            this.BackBT.Text = "Back";
            this.BackBT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BackBT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BackBT.UseVisualStyleBackColor = false;
            this.BackBT.Click += new System.EventHandler(this.BackBT_Click);
            // 
            // VickyPathL
            // 
            this.VickyPathL.AutoSize = true;
            this.VickyPathL.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.VickyPathL.Location = new System.Drawing.Point(12, 223);
            this.VickyPathL.Name = "VickyPathL";
            this.VickyPathL.Size = new System.Drawing.Size(145, 21);
            this.VickyPathL.TabIndex = 36;
            this.VickyPathL.Text = "Victoria 3 Path";
            // 
            // ProjPathL
            // 
            this.ProjPathL.AutoSize = true;
            this.ProjPathL.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.ProjPathL.Location = new System.Drawing.Point(12, 102);
            this.ProjPathL.Name = "ProjPathL";
            this.ProjPathL.Size = new System.Drawing.Size(118, 21);
            this.ProjPathL.TabIndex = 39;
            this.ProjPathL.Text = "Project Path";
            // 
            // ProjPathBT
            // 
            this.ProjPathBT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.ProjPathBT.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.ProjPathBT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(29)))), ((int)(((byte)(70)))));
            this.ProjPathBT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(34)))), ((int)(((byte)(75)))));
            this.ProjPathBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProjPathBT.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.ProjPathBT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.ProjPathBT.Location = new System.Drawing.Point(728, 126);
            this.ProjPathBT.Name = "ProjPathBT";
            this.ProjPathBT.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.ProjPathBT.Size = new System.Drawing.Size(51, 32);
            this.ProjPathBT.TabIndex = 37;
            this.ProjPathBT.Text = "...";
            this.ProjPathBT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ProjPathBT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ProjPathBT.UseVisualStyleBackColor = false;
            this.ProjPathBT.Click += new System.EventHandler(this.ProjPathBT_Click);
            // 
            // ProjNameL
            // 
            this.ProjNameL.AutoSize = true;
            this.ProjNameL.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.ProjNameL.Location = new System.Drawing.Point(12, 43);
            this.ProjNameL.Name = "ProjNameL";
            this.ProjNameL.Size = new System.Drawing.Size(118, 21);
            this.ProjNameL.TabIndex = 41;
            this.ProjNameL.Text = "Project Name";
            // 
            // LanguageL
            // 
            this.LanguageL.AutoSize = true;
            this.LanguageL.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.LanguageL.Location = new System.Drawing.Point(483, 43);
            this.LanguageL.Name = "LanguageL";
            this.LanguageL.Size = new System.Drawing.Size(82, 21);
            this.LanguageL.TabIndex = 69;
            this.LanguageL.Text = "Language";
            // 
            // ModL
            // 
            this.ModL.AutoSize = true;
            this.ModL.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.ModL.Location = new System.Drawing.Point(12, 282);
            this.ModL.Name = "ModL";
            this.ModL.Size = new System.Drawing.Size(82, 21);
            this.ModL.TabIndex = 72;
            this.ModL.Text = "Mod Path";
            // 
            // ModPathBT
            // 
            this.ModPathBT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.ModPathBT.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.ModPathBT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(29)))), ((int)(((byte)(70)))));
            this.ModPathBT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(34)))), ((int)(((byte)(75)))));
            this.ModPathBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ModPathBT.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.ModPathBT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.ModPathBT.Location = new System.Drawing.Point(728, 306);
            this.ModPathBT.Name = "ModPathBT";
            this.ModPathBT.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.ModPathBT.Size = new System.Drawing.Size(51, 32);
            this.ModPathBT.TabIndex = 70;
            this.ModPathBT.Text = "...";
            this.ModPathBT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ModPathBT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ModPathBT.UseVisualStyleBackColor = false;
            this.ModPathBT.Click += new System.EventHandler(this.ModPathBT_Click);
            // 
            // AdviceL
            // 
            this.AdviceL.AutoSize = true;
            this.AdviceL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(44)))), ((int)(((byte)(63)))));
            this.AdviceL.Location = new System.Drawing.Point(12, 172);
            this.AdviceL.Name = "AdviceL";
            this.AdviceL.Size = new System.Drawing.Size(622, 42);
            this.AdviceL.TabIndex = 73;
            this.AdviceL.Text = "The moment you Save, the Files will be changed in the Project Path. \r\nBe careful " +
    "to not lose anything important.";
            // 
            // ModPathTB
            // 
            this.ModPathTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.ModPathTB.BackgroundColorFocus = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.ModPathTB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.ModPathTB.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.ModPathTB.BorderSize = 1;
            this.ModPathTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.ModPathTB.Location = new System.Drawing.Point(16, 306);
            this.ModPathTB.Multiline = false;
            this.ModPathTB.Name = "ModPathTB";
            this.ModPathTB.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.ModPathTB.ReadOnly = false;
            this.ModPathTB.Size = new System.Drawing.Size(706, 24);
            this.ModPathTB.TabIndex = 71;
            this.ModPathTB.Texts = "";
            this.ModPathTB.UnderlinedStyle = false;
            this.ModPathTB.CustomTextBox_TextChanged += new System.EventHandler(this.ModPathTB_CustomTextBox_TextChanged);
            // 
            // LanguageCB
            // 
            this.LanguageCB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.LanguageCB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.LanguageCB.BorderSize = 1;
            this.LanguageCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.LanguageCB.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LanguageCB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.LanguageCB.FormattingEnabled = false;
            this.LanguageCB.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(73)))), ((int)(((byte)(150)))));
            this.LanguageCB.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.LanguageCB.ListTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.LanguageCB.Location = new System.Drawing.Point(487, 67);
            this.LanguageCB.MinimumSize = new System.Drawing.Size(200, 30);
            this.LanguageCB.Name = "LanguageCB";
            this.LanguageCB.Padding = new System.Windows.Forms.Padding(1);
            this.LanguageCB.Size = new System.Drawing.Size(292, 32);
            this.LanguageCB.TabIndex = 66;
            this.LanguageCB.Texts = "";
            this.LanguageCB.OnSelectedIndexChanged += new System.EventHandler(this.LanguageCB_OnSelectedIndexChanged);
            // 
            // PNameTB
            // 
            this.PNameTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.PNameTB.BackgroundColorFocus = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.PNameTB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.PNameTB.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.PNameTB.BorderSize = 1;
            this.PNameTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.PNameTB.Location = new System.Drawing.Point(16, 67);
            this.PNameTB.Multiline = false;
            this.PNameTB.Name = "PNameTB";
            this.PNameTB.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.PNameTB.ReadOnly = false;
            this.PNameTB.Size = new System.Drawing.Size(465, 24);
            this.PNameTB.TabIndex = 40;
            this.PNameTB.Texts = "";
            this.PNameTB.UnderlinedStyle = false;
            this.PNameTB.CustomTextBox_TextChanged += new System.EventHandler(this.PNameTB_CustomTextBox_TextChanged);
            // 
            // ProjPathTB
            // 
            this.ProjPathTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.ProjPathTB.BackgroundColorFocus = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.ProjPathTB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.ProjPathTB.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.ProjPathTB.BorderSize = 1;
            this.ProjPathTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.ProjPathTB.Location = new System.Drawing.Point(16, 126);
            this.ProjPathTB.Multiline = false;
            this.ProjPathTB.Name = "ProjPathTB";
            this.ProjPathTB.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.ProjPathTB.ReadOnly = false;
            this.ProjPathTB.Size = new System.Drawing.Size(706, 24);
            this.ProjPathTB.TabIndex = 38;
            this.ProjPathTB.Texts = "";
            this.ProjPathTB.UnderlinedStyle = false;
            this.ProjPathTB.CustomTextBox_TextChanged += new System.EventHandler(this.ProjPathTB_CustomTextBox_TextChanged);
            // 
            // VickyPathTB
            // 
            this.VickyPathTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.VickyPathTB.BackgroundColorFocus = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.VickyPathTB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.VickyPathTB.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.VickyPathTB.BorderSize = 1;
            this.VickyPathTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.VickyPathTB.Location = new System.Drawing.Point(16, 247);
            this.VickyPathTB.Multiline = false;
            this.VickyPathTB.Name = "VickyPathTB";
            this.VickyPathTB.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.VickyPathTB.ReadOnly = false;
            this.VickyPathTB.Size = new System.Drawing.Size(706, 24);
            this.VickyPathTB.TabIndex = 33;
            this.VickyPathTB.Texts = "";
            this.VickyPathTB.UnderlinedStyle = false;
            this.VickyPathTB.CustomTextBox_TextChanged += new System.EventHandler(this.VickyPathTB_CustomTextBox_TextChanged);
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
            this.HelpBT.Location = new System.Drawing.Point(656, 0);
            this.HelpBT.Name = "HelpBT";
            this.HelpBT.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.HelpBT.Size = new System.Drawing.Size(36, 32);
            this.HelpBT.TabIndex = 38;
            this.HelpBT.Text = "?";
            this.HelpBT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.HelpBT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.HelpBT.UseVisualStyleBackColor = false;
            this.HelpBT.Click += new System.EventHandler(this.HelpBT_Click);
            // 
            // PathForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(800, 400);
            this.Controls.Add(this.AdviceL);
            this.Controls.Add(this.ModL);
            this.Controls.Add(this.ModPathTB);
            this.Controls.Add(this.ModPathBT);
            this.Controls.Add(this.LanguageL);
            this.Controls.Add(this.LanguageCB);
            this.Controls.Add(this.ProjNameL);
            this.Controls.Add(this.PNameTB);
            this.Controls.Add(this.ProjPathL);
            this.Controls.Add(this.ProjPathTB);
            this.Controls.Add(this.ProjPathBT);
            this.Controls.Add(this.VickyPathL);
            this.Controls.Add(this.BackBT);
            this.Controls.Add(this.VickyPathTB);
            this.Controls.Add(this.HotBarP);
            this.Controls.Add(this.VicPathBT);
            this.Controls.Add(this.CreateBT);
            this.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 400);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 400);
            this.Name = "PathForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Victoria 3 Modding Tool";
            this.Load += new System.EventHandler(this.PathForm_Load);
            this.HotBarP.ResumeLayout(false);
            this.HotBarP.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button CreateBT;
        private Button VicPathBT;
        private Panel HotBarP;
        private Button MinimiseBT;
        private Button ChangeSizeBT;
        private Button CloseBT;
        private CustomTextBox VickyPathTB;
        private Label TitleL;
        private Button BackBT;
        private Label VickyPathL;
        private Label ProjPathL;
        private CustomTextBox ProjPathTB;
        private Button ProjPathBT;
        private CustomTextBox PNameTB;
        private Label ProjNameL;
        private CustomComboBox LanguageCB;
        private Label LanguageL;
        private Label ModL;
        private CustomTextBox ModPathTB;
        private Button ModPathBT;
        private Label AdviceL;
        private Button HelpBT;
    }
}

