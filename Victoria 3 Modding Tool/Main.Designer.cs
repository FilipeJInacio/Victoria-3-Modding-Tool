using System.Drawing;
using System.Windows.Forms;

namespace Victoria_3_Modding_Tool
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.HotBarP = new System.Windows.Forms.Panel();
            this.HelpBT = new System.Windows.Forms.Button();
            this.MinimiseBT = new System.Windows.Forms.Button();
            this.ChangeSizeBT = new System.Windows.Forms.Button();
            this.CloseBT = new System.Windows.Forms.Button();
            this.MainLB = new System.Windows.Forms.ListBox();
            this.VickyLB = new System.Windows.Forms.ListBox();
            this.ProjectLB = new System.Windows.Forms.ListBox();
            this.ModLB = new System.Windows.Forms.ListBox();
            this.MainL = new System.Windows.Forms.Label();
            this.VickyL = new System.Windows.Forms.Label();
            this.ModL = new System.Windows.Forms.Label();
            this.ProjectL = new System.Windows.Forms.Label();
            this.NewL = new System.Windows.Forms.Label();
            this.SaveL = new System.Windows.Forms.Label();
            this.DeleteL = new System.Windows.Forms.Label();
            this.AddModL = new System.Windows.Forms.Label();
            this.AddModBT = new System.Windows.Forms.Button();
            this.DeleteBT = new System.Windows.Forms.Button();
            this.SaveBT = new System.Windows.Forms.Button();
            this.AddBT = new System.Windows.Forms.Button();
            this.XL = new System.Windows.Forms.Label();
            this.ModSearchBarTB = new Victoria_3_Modding_Tool.CustomTextBox();
            this.ProjSearchBarTB = new Victoria_3_Modding_Tool.CustomTextBox();
            this.VickySearchBarTB = new Victoria_3_Modding_Tool.CustomTextBox();
            this.MainSearchBarTB = new Victoria_3_Modding_Tool.CustomTextBox();
            this.HotBarP.SuspendLayout();
            this.SuspendLayout();
            // 
            // HotBarP
            // 
            this.HotBarP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.HotBarP.Controls.Add(this.HelpBT);
            this.HotBarP.Controls.Add(this.MinimiseBT);
            this.HotBarP.Controls.Add(this.ChangeSizeBT);
            this.HotBarP.Controls.Add(this.CloseBT);
            this.HotBarP.Dock = System.Windows.Forms.DockStyle.Top;
            this.HotBarP.Location = new System.Drawing.Point(0, 0);
            this.HotBarP.Name = "HotBarP";
            this.HotBarP.Size = new System.Drawing.Size(1920, 32);
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
            this.HelpBT.Location = new System.Drawing.Point(1776, 0);
            this.HelpBT.Name = "HelpBT";
            this.HelpBT.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.HelpBT.Size = new System.Drawing.Size(36, 32);
            this.HelpBT.TabIndex = 73;
            this.HelpBT.Text = "?";
            this.HelpBT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.HelpBT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.HelpBT.UseVisualStyleBackColor = false;
            this.HelpBT.Click += new System.EventHandler(this.HelpBT_Click);
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
            this.MinimiseBT.Location = new System.Drawing.Point(1812, 0);
            this.MinimiseBT.Name = "MinimiseBT";
            this.MinimiseBT.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.MinimiseBT.Size = new System.Drawing.Size(36, 32);
            this.MinimiseBT.TabIndex = 74;
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
            this.ChangeSizeBT.Location = new System.Drawing.Point(1848, 0);
            this.ChangeSizeBT.Name = "ChangeSizeBT";
            this.ChangeSizeBT.Padding = new System.Windows.Forms.Padding(5, 3, 0, 0);
            this.ChangeSizeBT.Size = new System.Drawing.Size(36, 32);
            this.ChangeSizeBT.TabIndex = 75;
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
            this.CloseBT.Location = new System.Drawing.Point(1884, 0);
            this.CloseBT.Name = "CloseBT";
            this.CloseBT.Padding = new System.Windows.Forms.Padding(5, 1, 0, 0);
            this.CloseBT.Size = new System.Drawing.Size(36, 32);
            this.CloseBT.TabIndex = 76;
            this.CloseBT.Text = "x";
            this.CloseBT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CloseBT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CloseBT.UseVisualStyleBackColor = false;
            this.CloseBT.Click += new System.EventHandler(this.CloseBT_Click);
            // 
            // MainLB
            // 
            this.MainLB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.MainLB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MainLB.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.MainLB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.MainLB.FormattingEnabled = true;
            this.MainLB.ItemHeight = 24;
            this.MainLB.Location = new System.Drawing.Point(32, 112);
            this.MainLB.Name = "MainLB";
            this.MainLB.Size = new System.Drawing.Size(240, 888);
            this.MainLB.TabIndex = 56;
            this.MainLB.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.MainLB_DrawItem);
            this.MainLB.DoubleClick += new System.EventHandler(this.MainLB_Click);
            // 
            // VickyLB
            // 
            this.VickyLB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.VickyLB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.VickyLB.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.VickyLB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.VickyLB.FormattingEnabled = true;
            this.VickyLB.ItemHeight = 24;
            this.VickyLB.Location = new System.Drawing.Point(304, 112);
            this.VickyLB.Name = "VickyLB";
            this.VickyLB.Size = new System.Drawing.Size(240, 888);
            this.VickyLB.TabIndex = 57;
            this.VickyLB.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.VickyLB_DrawItem);
            this.VickyLB.DoubleClick += new System.EventHandler(this.VickyLB_Click);
            // 
            // ProjectLB
            // 
            this.ProjectLB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ProjectLB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ProjectLB.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ProjectLB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.ProjectLB.FormattingEnabled = true;
            this.ProjectLB.ItemHeight = 24;
            this.ProjectLB.Location = new System.Drawing.Point(1417, 101);
            this.ProjectLB.Name = "ProjectLB";
            this.ProjectLB.Size = new System.Drawing.Size(240, 888);
            this.ProjectLB.TabIndex = 58;
            this.ProjectLB.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ProjectLB_DrawItem);
            this.ProjectLB.DoubleClick += new System.EventHandler(this.ProjectLB_Click);
            // 
            // ModLB
            // 
            this.ModLB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ModLB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ModLB.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ModLB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.ModLB.FormattingEnabled = true;
            this.ModLB.ItemHeight = 24;
            this.ModLB.Location = new System.Drawing.Point(832, 84);
            this.ModLB.Name = "ModLB";
            this.ModLB.Size = new System.Drawing.Size(390, 912);
            this.ModLB.TabIndex = 68;
            this.ModLB.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ModLB_DrawItem);
            this.ModLB.DoubleClick += new System.EventHandler(this.ModLB_DoubleClick);
            // 
            // MainL
            // 
            this.MainL.AutoSize = true;
            this.MainL.Font = new System.Drawing.Font("Cascadia Mono", 15F);
            this.MainL.Location = new System.Drawing.Point(109, 55);
            this.MainL.Name = "MainL";
            this.MainL.Size = new System.Drawing.Size(60, 27);
            this.MainL.TabIndex = 70;
            this.MainL.Text = "Main";
            // 
            // VickyL
            // 
            this.VickyL.AutoSize = true;
            this.VickyL.Font = new System.Drawing.Font("Cascadia Mono", 15F);
            this.VickyL.Location = new System.Drawing.Point(300, 53);
            this.VickyL.Name = "VickyL";
            this.VickyL.Size = new System.Drawing.Size(132, 27);
            this.VickyL.TabIndex = 71;
            this.VickyL.Text = "Victoria 3";
            // 
            // ModL
            // 
            this.ModL.AutoSize = true;
            this.ModL.Font = new System.Drawing.Font("Cascadia Mono", 15F);
            this.ModL.Location = new System.Drawing.Point(828, 50);
            this.ModL.Name = "ModL";
            this.ModL.Size = new System.Drawing.Size(48, 27);
            this.ModL.TabIndex = 72;
            this.ModL.Text = "Mod";
            // 
            // ProjectL
            // 
            this.ProjectL.AutoSize = true;
            this.ProjectL.Font = new System.Drawing.Font("Cascadia Mono", 15F);
            this.ProjectL.Location = new System.Drawing.Point(1413, 46);
            this.ProjectL.Name = "ProjectL";
            this.ProjectL.Size = new System.Drawing.Size(96, 27);
            this.ProjectL.TabIndex = 73;
            this.ProjectL.Text = "Project";
            // 
            // NewL
            // 
            this.NewL.AutoSize = true;
            this.NewL.Location = new System.Drawing.Point(1343, 466);
            this.NewL.Name = "NewL";
            this.NewL.Size = new System.Drawing.Size(37, 21);
            this.NewL.TabIndex = 74;
            this.NewL.Text = "New";
            // 
            // SaveL
            // 
            this.SaveL.AutoSize = true;
            this.SaveL.Location = new System.Drawing.Point(1343, 541);
            this.SaveL.Name = "SaveL";
            this.SaveL.Size = new System.Drawing.Size(46, 21);
            this.SaveL.TabIndex = 75;
            this.SaveL.Text = "Save";
            // 
            // DeleteL
            // 
            this.DeleteL.AutoSize = true;
            this.DeleteL.Location = new System.Drawing.Point(1343, 617);
            this.DeleteL.Name = "DeleteL";
            this.DeleteL.Size = new System.Drawing.Size(64, 21);
            this.DeleteL.TabIndex = 76;
            this.DeleteL.Text = "Delete";
            // 
            // AddModL
            // 
            this.AddModL.AutoSize = true;
            this.AddModL.Location = new System.Drawing.Point(1343, 199);
            this.AddModL.Name = "AddModL";
            this.AddModL.Size = new System.Drawing.Size(73, 21);
            this.AddModL.TabIndex = 78;
            this.AddModL.Text = "New Mod";
            // 
            // AddModBT
            // 
            this.AddModBT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.AddModBT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.AddModBT.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.AddModBT.FlatAppearance.BorderSize = 0;
            this.AddModBT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.AddModBT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.AddModBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddModBT.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.AddModBT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.AddModBT.Image = global::Victoria_3_Modding_Tool.Properties.Resources.addmod;
            this.AddModBT.Location = new System.Drawing.Point(1257, 175);
            this.AddModBT.Name = "AddModBT";
            this.AddModBT.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.AddModBT.Size = new System.Drawing.Size(80, 68);
            this.AddModBT.TabIndex = 69;
            this.AddModBT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AddModBT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.AddModBT.UseVisualStyleBackColor = false;
            this.AddModBT.Click += new System.EventHandler(this.AddModBT_Click);
            // 
            // DeleteBT
            // 
            this.DeleteBT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.DeleteBT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DeleteBT.Enabled = false;
            this.DeleteBT.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.DeleteBT.FlatAppearance.BorderSize = 0;
            this.DeleteBT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.DeleteBT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.DeleteBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteBT.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.DeleteBT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.DeleteBT.Image = global::Victoria_3_Modding_Tool.Properties.Resources.delete;
            this.DeleteBT.Location = new System.Drawing.Point(1257, 593);
            this.DeleteBT.Name = "DeleteBT";
            this.DeleteBT.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.DeleteBT.Size = new System.Drawing.Size(80, 68);
            this.DeleteBT.TabIndex = 72;
            this.DeleteBT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DeleteBT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.DeleteBT.UseVisualStyleBackColor = false;
            this.DeleteBT.Click += new System.EventHandler(this.DeleteBT_Click);
            // 
            // SaveBT
            // 
            this.SaveBT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.SaveBT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SaveBT.Enabled = false;
            this.SaveBT.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.SaveBT.FlatAppearance.BorderSize = 0;
            this.SaveBT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.SaveBT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.SaveBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveBT.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.SaveBT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.SaveBT.Image = global::Victoria_3_Modding_Tool.Properties.Resources.save;
            this.SaveBT.Location = new System.Drawing.Point(1257, 516);
            this.SaveBT.Name = "SaveBT";
            this.SaveBT.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.SaveBT.Size = new System.Drawing.Size(80, 71);
            this.SaveBT.TabIndex = 71;
            this.SaveBT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SaveBT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SaveBT.UseVisualStyleBackColor = false;
            this.SaveBT.Click += new System.EventHandler(this.SaveBT_Click);
            // 
            // AddBT
            // 
            this.AddBT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.AddBT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.AddBT.Enabled = false;
            this.AddBT.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.AddBT.FlatAppearance.BorderSize = 0;
            this.AddBT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.AddBT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.AddBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddBT.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.AddBT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.AddBT.Image = global::Victoria_3_Modding_Tool.Properties.Resources.add;
            this.AddBT.Location = new System.Drawing.Point(1257, 442);
            this.AddBT.Name = "AddBT";
            this.AddBT.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.AddBT.Size = new System.Drawing.Size(80, 68);
            this.AddBT.TabIndex = 70;
            this.AddBT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AddBT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.AddBT.UseVisualStyleBackColor = false;
            this.AddBT.Click += new System.EventHandler(this.AddBT_Click);
            // 
            // XL
            // 
            this.XL.AutoSize = true;
            this.XL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(44)))), ((int)(((byte)(63)))));
            this.XL.Location = new System.Drawing.Point(1318, 175);
            this.XL.Name = "XL";
            this.XL.Size = new System.Drawing.Size(19, 21);
            this.XL.TabIndex = 79;
            this.XL.Text = "X";
            this.XL.Visible = false;
            // 
            // ModSearchBarTB
            // 
            this.ModSearchBarTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.ModSearchBarTB.BackgroundColorFocus = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.ModSearchBarTB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.ModSearchBarTB.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.ModSearchBarTB.BorderSize = 1;
            this.ModSearchBarTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.ModSearchBarTB.Location = new System.Drawing.Point(832, 46);
            this.ModSearchBarTB.Multiline = false;
            this.ModSearchBarTB.Name = "ModSearchBarTB";
            this.ModSearchBarTB.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.ModSearchBarTB.ReadOnly = false;
            this.ModSearchBarTB.Size = new System.Drawing.Size(390, 24);
            this.ModSearchBarTB.TabIndex = 67;
            this.ModSearchBarTB.Texts = "";
            this.ModSearchBarTB.UnderlinedStyle = false;
            this.ModSearchBarTB.CustomTextBox_TextChanged += new System.EventHandler(this.ModSearchBarTB_CustomTextBox_TextChanged);
            // 
            // ProjSearchBarTB
            // 
            this.ProjSearchBarTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.ProjSearchBarTB.BackgroundColorFocus = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.ProjSearchBarTB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.ProjSearchBarTB.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.ProjSearchBarTB.BorderSize = 1;
            this.ProjSearchBarTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.ProjSearchBarTB.Location = new System.Drawing.Point(1417, 39);
            this.ProjSearchBarTB.Multiline = false;
            this.ProjSearchBarTB.Name = "ProjSearchBarTB";
            this.ProjSearchBarTB.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.ProjSearchBarTB.ReadOnly = false;
            this.ProjSearchBarTB.Size = new System.Drawing.Size(240, 24);
            this.ProjSearchBarTB.TabIndex = 68;
            this.ProjSearchBarTB.Texts = "";
            this.ProjSearchBarTB.UnderlinedStyle = false;
            this.ProjSearchBarTB.CustomTextBox_TextChanged += new System.EventHandler(this.ProjSearchBarTB_CustomTextBox_TextChanged);
            // 
            // VickySearchBarTB
            // 
            this.VickySearchBarTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.VickySearchBarTB.BackgroundColorFocus = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.VickySearchBarTB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.VickySearchBarTB.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.VickySearchBarTB.BorderSize = 1;
            this.VickySearchBarTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.VickySearchBarTB.Location = new System.Drawing.Point(304, 50);
            this.VickySearchBarTB.Multiline = false;
            this.VickySearchBarTB.Name = "VickySearchBarTB";
            this.VickySearchBarTB.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.VickySearchBarTB.ReadOnly = false;
            this.VickySearchBarTB.Size = new System.Drawing.Size(240, 24);
            this.VickySearchBarTB.TabIndex = 66;
            this.VickySearchBarTB.Texts = "";
            this.VickySearchBarTB.UnderlinedStyle = false;
            this.VickySearchBarTB.CustomTextBox_TextChanged += new System.EventHandler(this.VickySearchBarTB_CustomTextBox_TextChanged);
            // 
            // MainSearchBarTB
            // 
            this.MainSearchBarTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.MainSearchBarTB.BackgroundColorFocus = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.MainSearchBarTB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.MainSearchBarTB.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.MainSearchBarTB.BorderSize = 1;
            this.MainSearchBarTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.MainSearchBarTB.Location = new System.Drawing.Point(32, 50);
            this.MainSearchBarTB.Multiline = false;
            this.MainSearchBarTB.Name = "MainSearchBarTB";
            this.MainSearchBarTB.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.MainSearchBarTB.ReadOnly = false;
            this.MainSearchBarTB.Size = new System.Drawing.Size(240, 24);
            this.MainSearchBarTB.TabIndex = 65;
            this.MainSearchBarTB.Texts = "";
            this.MainSearchBarTB.UnderlinedStyle = false;
            this.MainSearchBarTB.CustomTextBox_TextChanged += new System.EventHandler(this.MainSearchBarTB_CustomTextBox_TextChanged);
            // 
            // Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(1920, 1040);
            this.Controls.Add(this.XL);
            this.Controls.Add(this.AddModL);
            this.Controls.Add(this.AddModBT);
            this.Controls.Add(this.DeleteL);
            this.Controls.Add(this.SaveL);
            this.Controls.Add(this.NewL);
            this.Controls.Add(this.ProjectL);
            this.Controls.Add(this.ModL);
            this.Controls.Add(this.VickyL);
            this.Controls.Add(this.MainL);
            this.Controls.Add(this.ModSearchBarTB);
            this.Controls.Add(this.ModLB);
            this.Controls.Add(this.ProjSearchBarTB);
            this.Controls.Add(this.VickySearchBarTB);
            this.Controls.Add(this.MainSearchBarTB);
            this.Controls.Add(this.DeleteBT);
            this.Controls.Add(this.SaveBT);
            this.Controls.Add(this.AddBT);
            this.Controls.Add(this.ProjectLB);
            this.Controls.Add(this.VickyLB);
            this.Controls.Add(this.MainLB);
            this.Controls.Add(this.HotBarP);
            this.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = " ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.HotBarP.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Panel HotBarP;
        private Button MinimiseBT;
        private Button ChangeSizeBT;
        private Button CloseBT;
        private ListBox MainLB;
        private ListBox VickyLB;
        private ListBox ProjectLB;
        private Button AddBT;
        private Button SaveBT;
        private Button DeleteBT;
        private Button HelpBT;
        private CustomTextBox MainSearchBarTB;
        private CustomTextBox VickySearchBarTB;
        private CustomTextBox ProjSearchBarTB;
        private CustomTextBox ModSearchBarTB;
        private ListBox ModLB;
        private Label MainL;
        private Label VickyL;
        private Label ModL;
        private Label ProjectL;
        private Label NewL;
        private Label SaveL;
        private Label DeleteL;
        private Button AddModBT;
        private Label AddModL;
        private Label XL;
    }
}

