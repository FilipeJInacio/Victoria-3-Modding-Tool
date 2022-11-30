using System.Windows.Forms;

namespace Victoria_3_Modding_Tool
{
    partial class PathFormHelp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EraHelp));
            this.HotBarP = new System.Windows.Forms.Panel();
            this.CloseBT = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.CancelBT = new System.Windows.Forms.Button();
            this.HotBarP.SuspendLayout();
            this.SuspendLayout();
            // 
            // HotBarP
            // 
            this.HotBarP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.HotBarP.Controls.Add(this.CloseBT);
            this.HotBarP.Dock = System.Windows.Forms.DockStyle.Top;
            this.HotBarP.Location = new System.Drawing.Point(0, 0);
            this.HotBarP.Name = "HotBarP";
            this.HotBarP.Size = new System.Drawing.Size(700, 32);
            this.HotBarP.TabIndex = 32;
            this.HotBarP.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HotBarP_MouseDown);
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
            this.CloseBT.Location = new System.Drawing.Point(664, 0);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.label2.Location = new System.Drawing.Point(29, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 21);
            this.label2.TabIndex = 39;
            this.label2.Text = "Do you want to save";
            // 
            // CancelBT
            // 
            this.CancelBT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.CancelBT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CancelBT.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.CancelBT.FlatAppearance.BorderSize = 0;
            this.CancelBT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.CancelBT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.CancelBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelBT.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.CancelBT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.CancelBT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CancelBT.Location = new System.Drawing.Point(565, 384);
            this.CancelBT.Name = "CancelBT";
            this.CancelBT.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.CancelBT.Size = new System.Drawing.Size(87, 32);
            this.CancelBT.TabIndex = 40;
            this.CancelBT.Text = "Ok";
            this.CancelBT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CancelBT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CancelBT.UseVisualStyleBackColor = false;
            this.CancelBT.Click += new System.EventHandler(this.CancelBT_Click);
            // 
            // EraHelp
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(700, 700);
            this.Controls.Add(this.CancelBT);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.HotBarP);
            this.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(700, 700);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(700, 700);
            this.Name = "EraHelp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Victoria 3 Modding Tool Popup";
            this.HotBarP.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Panel HotBarP;
        private Button CloseBT;
        private Label label2;
        private Button CancelBT;
    }
}

