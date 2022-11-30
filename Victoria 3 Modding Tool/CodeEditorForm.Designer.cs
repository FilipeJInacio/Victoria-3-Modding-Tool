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
            this.HotBarP = new System.Windows.Forms.Panel();
            this.TitleL = new System.Windows.Forms.Label();
            this.MinimiseBT = new System.Windows.Forms.Button();
            this.ChangeSizeBT = new System.Windows.Forms.Button();
            this.CloseBT = new System.Windows.Forms.Button();
            this.MainRTB = new System.Windows.Forms.RichTextBox();
            this.DebugRTB = new System.Windows.Forms.RichTextBox();
            this.LabelTemp = new System.Windows.Forms.Label();
            this.HelpBT = new System.Windows.Forms.Button();
            this.HotBarP.SuspendLayout();
            this.SuspendLayout();
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
            this.HotBarP.Size = new System.Drawing.Size(960, 32);
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
            this.MinimiseBT.Location = new System.Drawing.Point(852, 0);
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
            this.ChangeSizeBT.Location = new System.Drawing.Point(888, 0);
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
            this.CloseBT.Location = new System.Drawing.Point(924, 0);
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
            // MainRTB
            // 
            this.MainRTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.MainRTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MainRTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.MainRTB.Location = new System.Drawing.Point(130, 55);
            this.MainRTB.Name = "MainRTB";
            this.MainRTB.Size = new System.Drawing.Size(800, 867);
            this.MainRTB.TabIndex = 35;
            this.MainRTB.Text = "";
            this.MainRTB.TextChanged += new System.EventHandler(this.MainRTB_TextChanged);
            // 
            // DebugRTB
            // 
            this.DebugRTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.DebugRTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DebugRTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.DebugRTB.Location = new System.Drawing.Point(130, 928);
            this.DebugRTB.Name = "DebugRTB";
            this.DebugRTB.Size = new System.Drawing.Size(800, 88);
            this.DebugRTB.TabIndex = 36;
            this.DebugRTB.Text = "";
            // 
            // LabelTemp
            // 
            this.LabelTemp.AutoSize = true;
            this.LabelTemp.Location = new System.Drawing.Point(32, 131);
            this.LabelTemp.Name = "LabelTemp";
            this.LabelTemp.Size = new System.Drawing.Size(0, 21);
            this.LabelTemp.TabIndex = 37;
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
            this.HelpBT.Location = new System.Drawing.Point(816, 0);
            this.HelpBT.Name = "HelpBT";
            this.HelpBT.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.HelpBT.Size = new System.Drawing.Size(36, 32);
            this.HelpBT.TabIndex = 37;
            this.HelpBT.Text = "?";
            this.HelpBT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.HelpBT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.HelpBT.UseVisualStyleBackColor = false;
            // 
            // CodeEditorForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(960, 1038);
            this.Controls.Add(this.LabelTemp);
            this.Controls.Add(this.DebugRTB);
            this.Controls.Add(this.MainRTB);
            this.Controls.Add(this.HotBarP);
            this.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(960, 1038);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(960, 1038);
            this.Name = "CodeEditorForm";
            this.Text = "Victoria 3 Modding Tool";
            this.Load += new System.EventHandler(this.CodeEditorForm_Load);
            this.HotBarP.ResumeLayout(false);
            this.HotBarP.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Panel HotBarP;
        private Button MinimiseBT;
        private Button ChangeSizeBT;
        private Button CloseBT;
        private Label TitleL;
        private RichTextBox MainRTB;
        private RichTextBox DebugRTB;
        private Label LabelTemp;
        private Button HelpBT;
    }
}

