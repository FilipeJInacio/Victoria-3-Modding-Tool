using System.Windows.Forms;

namespace Victoria_3_Modding_Tool
{
    partial class StateTraitsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StateTraitsForm));
            this.SaveBT = new System.Windows.Forms.Button();
            this.HotBarP = new System.Windows.Forms.Panel();
            this.HelpBT = new System.Windows.Forms.Button();
            this.TitleL = new System.Windows.Forms.Label();
            this.MinimiseBT = new System.Windows.Forms.Button();
            this.ChangeSizeBT = new System.Windows.Forms.Button();
            this.CloseBT = new System.Windows.Forms.Button();
            this.NameL = new System.Windows.Forms.Label();
            this.NameTB = new Victoria_3_Modding_Tool.CustomTextBox();
            this.NumberTB = new Victoria_3_Modding_Tool.CustomTextBox();
            this.ModifiersLB = new System.Windows.Forms.ListBox();
            this.ModifiersCB = new Victoria_3_Modding_Tool.CustomComboBox();
            this.ModifiersL = new System.Windows.Forms.Label();
            this.ModifiersAddBT = new System.Windows.Forms.Button();
            this.NameGameL = new System.Windows.Forms.Label();
            this.NameGameTB = new Victoria_3_Modding_Tool.CustomTextBox();
            this.IconL = new System.Windows.Forms.Label();
            this.IconTB = new Victoria_3_Modding_Tool.CustomTextBox();
            this.IconPathBT = new System.Windows.Forms.Button();
            this.DisableCB = new Victoria_3_Modding_Tool.CustomComboBox();
            this.RequiredCB = new Victoria_3_Modding_Tool.CustomComboBox();
            this.DisablesCB = new Victoria_3_Modding_Tool.CustomCheckBox();
            this.DisableL = new System.Windows.Forms.Label();
            this.DisableCBL = new System.Windows.Forms.Label();
            this.RequiredL = new System.Windows.Forms.Label();
            this.RequiredCBL = new System.Windows.Forms.Label();
            this.RequiresCB = new Victoria_3_Modding_Tool.CustomCheckBox();
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
            this.SaveBT.Location = new System.Drawing.Point(828, 520);
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
            this.HotBarP.Size = new System.Drawing.Size(900, 32);
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
            this.HelpBT.Location = new System.Drawing.Point(756, 0);
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
            this.TitleL.Size = new System.Drawing.Size(172, 21);
            this.TitleL.TabIndex = 35;
            this.TitleL.Text = "State Trait Editor";
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
            this.MinimiseBT.Location = new System.Drawing.Point(792, 0);
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
            this.ChangeSizeBT.Location = new System.Drawing.Point(828, 0);
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
            this.CloseBT.Location = new System.Drawing.Point(864, 0);
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
            this.NameTB.Size = new System.Drawing.Size(394, 30);
            this.NameTB.TabIndex = 40;
            this.NameTB.Texts = "";
            this.NameTB.UnderlinedStyle = false;
            this.NameTB.CustomTextBox_TextChanged += new System.EventHandler(this.NameTB_CustomTextBox_TextChanged);
            // 
            // NumberTB
            // 
            this.NumberTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.NumberTB.BackgroundColorFocus = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.NumberTB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.NumberTB.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.NumberTB.BorderSize = 1;
            this.NumberTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.NumberTB.Location = new System.Drawing.Point(724, 300);
            this.NumberTB.Multiline = false;
            this.NumberTB.Name = "NumberTB";
            this.NumberTB.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.NumberTB.ReadOnly = false;
            this.NumberTB.Size = new System.Drawing.Size(96, 30);
            this.NumberTB.TabIndex = 69;
            this.NumberTB.Texts = "";
            this.NumberTB.UnderlinedStyle = false;
            // 
            // ModifiersLB
            // 
            this.ModifiersLB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ModifiersLB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ModifiersLB.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ModifiersLB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.ModifiersLB.FormattingEnabled = true;
            this.ModifiersLB.ItemHeight = 24;
            this.ModifiersLB.Location = new System.Drawing.Point(16, 336);
            this.ModifiersLB.Name = "ModifiersLB";
            this.ModifiersLB.Size = new System.Drawing.Size(806, 216);
            this.ModifiersLB.TabIndex = 68;
            this.ModifiersLB.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ModifiersLB_DrawItem);
            this.ModifiersLB.DoubleClick += new System.EventHandler(this.ModifiersLB_DoubleClick);
            // 
            // ModifiersCB
            // 
            this.ModifiersCB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.ModifiersCB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.ModifiersCB.BorderSize = 1;
            this.ModifiersCB.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ModifiersCB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.ModifiersCB.FormattingEnabled = false;
            this.ModifiersCB.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(73)))), ((int)(((byte)(150)))));
            this.ModifiersCB.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ModifiersCB.ListTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.ModifiersCB.Location = new System.Drawing.Point(16, 300);
            this.ModifiersCB.MinimumSize = new System.Drawing.Size(200, 30);
            this.ModifiersCB.Name = "ModifiersCB";
            this.ModifiersCB.Padding = new System.Windows.Forms.Padding(1);
            this.ModifiersCB.Size = new System.Drawing.Size(702, 32);
            this.ModifiersCB.TabIndex = 67;
            this.ModifiersCB.Texts = "";
            // 
            // ModifiersL
            // 
            this.ModifiersL.AutoSize = true;
            this.ModifiersL.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ModifiersL.Location = new System.Drawing.Point(12, 276);
            this.ModifiersL.Name = "ModifiersL";
            this.ModifiersL.Size = new System.Drawing.Size(100, 21);
            this.ModifiersL.TabIndex = 66;
            this.ModifiersL.Text = "Modifiers:";
            // 
            // ModifiersAddBT
            // 
            this.ModifiersAddBT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.ModifiersAddBT.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.ModifiersAddBT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(29)))), ((int)(((byte)(70)))));
            this.ModifiersAddBT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(34)))), ((int)(((byte)(75)))));
            this.ModifiersAddBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ModifiersAddBT.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ModifiersAddBT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.ModifiersAddBT.Location = new System.Drawing.Point(826, 300);
            this.ModifiersAddBT.Name = "ModifiersAddBT";
            this.ModifiersAddBT.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.ModifiersAddBT.Size = new System.Drawing.Size(51, 32);
            this.ModifiersAddBT.TabIndex = 65;
            this.ModifiersAddBT.Text = "Add";
            this.ModifiersAddBT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ModifiersAddBT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ModifiersAddBT.UseVisualStyleBackColor = false;
            this.ModifiersAddBT.Click += new System.EventHandler(this.ModifiersAddBT_Click);
            // 
            // NameGameL
            // 
            this.NameGameL.AutoSize = true;
            this.NameGameL.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NameGameL.Location = new System.Drawing.Point(422, 43);
            this.NameGameL.Name = "NameGameL";
            this.NameGameL.Size = new System.Drawing.Size(127, 21);
            this.NameGameL.TabIndex = 71;
            this.NameGameL.Text = "Name in game:";
            // 
            // NameGameTB
            // 
            this.NameGameTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.NameGameTB.BackgroundColorFocus = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.NameGameTB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.NameGameTB.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.NameGameTB.BorderSize = 1;
            this.NameGameTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.NameGameTB.Location = new System.Drawing.Point(426, 67);
            this.NameGameTB.Multiline = false;
            this.NameGameTB.Name = "NameGameTB";
            this.NameGameTB.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.NameGameTB.ReadOnly = false;
            this.NameGameTB.Size = new System.Drawing.Size(449, 30);
            this.NameGameTB.TabIndex = 70;
            this.NameGameTB.Texts = "";
            this.NameGameTB.UnderlinedStyle = false;
            this.NameGameTB.CustomTextBox_TextChanged += new System.EventHandler(this.NameGameTB_CustomTextBox_TextChanged);
            // 
            // IconL
            // 
            this.IconL.AutoSize = true;
            this.IconL.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.IconL.Location = new System.Drawing.Point(12, 101);
            this.IconL.Name = "IconL";
            this.IconL.Size = new System.Drawing.Size(55, 21);
            this.IconL.TabIndex = 74;
            this.IconL.Text = "Icon:";
            // 
            // IconTB
            // 
            this.IconTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.IconTB.BackgroundColorFocus = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.IconTB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.IconTB.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.IconTB.BorderSize = 1;
            this.IconTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.IconTB.Location = new System.Drawing.Point(16, 125);
            this.IconTB.Multiline = false;
            this.IconTB.Name = "IconTB";
            this.IconTB.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.IconTB.ReadOnly = false;
            this.IconTB.Size = new System.Drawing.Size(804, 30);
            this.IconTB.TabIndex = 73;
            this.IconTB.Texts = "";
            this.IconTB.UnderlinedStyle = false;
            this.IconTB.CustomTextBox_TextChanged += new System.EventHandler(this.IconTB_CustomTextBox_TextChanged);
            // 
            // IconPathBT
            // 
            this.IconPathBT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.IconPathBT.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.IconPathBT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(29)))), ((int)(((byte)(70)))));
            this.IconPathBT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(34)))), ((int)(((byte)(75)))));
            this.IconPathBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IconPathBT.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.IconPathBT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.IconPathBT.Location = new System.Drawing.Point(826, 125);
            this.IconPathBT.Name = "IconPathBT";
            this.IconPathBT.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.IconPathBT.Size = new System.Drawing.Size(51, 32);
            this.IconPathBT.TabIndex = 72;
            this.IconPathBT.Text = "...";
            this.IconPathBT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.IconPathBT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.IconPathBT.UseVisualStyleBackColor = false;
            this.IconPathBT.Click += new System.EventHandler(this.IconPathBT_Click);
            // 
            // DisableCB
            // 
            this.DisableCB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.DisableCB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.DisableCB.BorderSize = 1;
            this.DisableCB.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DisableCB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.DisableCB.FormattingEnabled = false;
            this.DisableCB.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(73)))), ((int)(((byte)(150)))));
            this.DisableCB.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.DisableCB.ListTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.DisableCB.Location = new System.Drawing.Point(16, 182);
            this.DisableCB.MinimumSize = new System.Drawing.Size(200, 30);
            this.DisableCB.Name = "DisableCB";
            this.DisableCB.Padding = new System.Windows.Forms.Padding(1);
            this.DisableCB.Size = new System.Drawing.Size(601, 32);
            this.DisableCB.TabIndex = 75;
            this.DisableCB.Texts = "";
            this.DisableCB.OnSelectedIndexChanged += new System.EventHandler(this.DisableCB_OnSelectedIndexChanged);
            // 
            // RequiredCB
            // 
            this.RequiredCB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.RequiredCB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.RequiredCB.BorderSize = 1;
            this.RequiredCB.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RequiredCB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.RequiredCB.FormattingEnabled = false;
            this.RequiredCB.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(73)))), ((int)(((byte)(150)))));
            this.RequiredCB.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.RequiredCB.ListTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.RequiredCB.Location = new System.Drawing.Point(16, 241);
            this.RequiredCB.MinimumSize = new System.Drawing.Size(200, 30);
            this.RequiredCB.Name = "RequiredCB";
            this.RequiredCB.Padding = new System.Windows.Forms.Padding(1);
            this.RequiredCB.Size = new System.Drawing.Size(601, 32);
            this.RequiredCB.TabIndex = 76;
            this.RequiredCB.Texts = "";
            this.RequiredCB.OnSelectedIndexChanged += new System.EventHandler(this.RequiredCB_OnSelectedIndexChanged);
            // 
            // DisablesCB
            // 
            this.DisablesCB.AutoSize = true;
            this.DisablesCB.Checked = true;
            this.DisablesCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DisablesCB.Location = new System.Drawing.Point(687, 182);
            this.DisablesCB.MinimumSize = new System.Drawing.Size(62, 32);
            this.DisablesCB.Name = "DisablesCB";
            this.DisablesCB.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.DisablesCB.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.DisablesCB.OnBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(53)))), ((int)(((byte)(130)))));
            this.DisablesCB.OnToggleColor = System.Drawing.Color.Gainsboro;
            this.DisablesCB.Size = new System.Drawing.Size(62, 32);
            this.DisablesCB.TabIndex = 77;
            this.DisablesCB.UseVisualStyleBackColor = true;
            // 
            // DisableL
            // 
            this.DisableL.AutoSize = true;
            this.DisableL.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DisableL.Location = new System.Drawing.Point(12, 158);
            this.DisableL.Name = "DisableL";
            this.DisableL.Size = new System.Drawing.Size(298, 21);
            this.DisableL.TabIndex = 78;
            this.DisableL.Text = "Tech that disables the modifier:";
            // 
            // DisableCBL
            // 
            this.DisableCBL.AutoSize = true;
            this.DisableCBL.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DisableCBL.Location = new System.Drawing.Point(756, 187);
            this.DisableCBL.Name = "DisableCBL";
            this.DisableCBL.Size = new System.Drawing.Size(109, 21);
            this.DisableCBL.TabIndex = 79;
            this.DisableCBL.Text = "Is disabled";
            // 
            // RequiredL
            // 
            this.RequiredL.AutoSize = true;
            this.RequiredL.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RequiredL.Location = new System.Drawing.Point(16, 217);
            this.RequiredL.Name = "RequiredL";
            this.RequiredL.Size = new System.Drawing.Size(334, 21);
            this.RequiredL.TabIndex = 80;
            this.RequiredL.Text = "Requires this tech for colonization:";
            // 
            // RequiredCBL
            // 
            this.RequiredCBL.AutoSize = true;
            this.RequiredCBL.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RequiredCBL.Location = new System.Drawing.Point(756, 246);
            this.RequiredCBL.Name = "RequiredCBL";
            this.RequiredCBL.Size = new System.Drawing.Size(109, 21);
            this.RequiredCBL.TabIndex = 82;
            this.RequiredCBL.Text = "Is required";
            // 
            // RequiresCB
            // 
            this.RequiresCB.AutoSize = true;
            this.RequiresCB.Checked = true;
            this.RequiresCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RequiresCB.Location = new System.Drawing.Point(687, 241);
            this.RequiresCB.MinimumSize = new System.Drawing.Size(62, 32);
            this.RequiresCB.Name = "RequiresCB";
            this.RequiresCB.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.RequiresCB.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.RequiresCB.OnBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(53)))), ((int)(((byte)(130)))));
            this.RequiresCB.OnToggleColor = System.Drawing.Color.Gainsboro;
            this.RequiresCB.Size = new System.Drawing.Size(62, 32);
            this.RequiresCB.TabIndex = 81;
            this.RequiresCB.UseVisualStyleBackColor = true;
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
            this.ChangeBT.Location = new System.Drawing.Point(720, 0);
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
            // StateTraitsForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(900, 565);
            this.Controls.Add(this.RequiredCBL);
            this.Controls.Add(this.RequiresCB);
            this.Controls.Add(this.RequiredL);
            this.Controls.Add(this.DisableCBL);
            this.Controls.Add(this.DisableL);
            this.Controls.Add(this.DisablesCB);
            this.Controls.Add(this.RequiredCB);
            this.Controls.Add(this.DisableCB);
            this.Controls.Add(this.IconL);
            this.Controls.Add(this.IconTB);
            this.Controls.Add(this.IconPathBT);
            this.Controls.Add(this.NameGameL);
            this.Controls.Add(this.NameGameTB);
            this.Controls.Add(this.NumberTB);
            this.Controls.Add(this.ModifiersLB);
            this.Controls.Add(this.ModifiersCB);
            this.Controls.Add(this.ModifiersL);
            this.Controls.Add(this.ModifiersAddBT);
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
            this.MaximumSize = new System.Drawing.Size(900, 565);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(900, 565);
            this.Name = "StateTraitsForm";
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
        private Button HelpBT;
        private CustomTextBox NumberTB;
        private ListBox ModifiersLB;
        private CustomComboBox ModifiersCB;
        private Label ModifiersL;
        private Button ModifiersAddBT;
        private Label NameGameL;
        private CustomTextBox NameGameTB;
        private Label IconL;
        private CustomTextBox IconTB;
        private Button IconPathBT;
        private CustomComboBox DisableCB;
        private CustomComboBox RequiredCB;
        private CustomCheckBox DisablesCB;
        private Label DisableL;
        private Label DisableCBL;
        private Label RequiredL;
        private Label RequiredCBL;
        private CustomCheckBox RequiresCB;
        private Button ChangeBT;
    }
}

