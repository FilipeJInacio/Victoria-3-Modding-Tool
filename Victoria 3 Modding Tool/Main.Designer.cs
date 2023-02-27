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
            HotBarP = new Panel();
            HelpBT = new Button();
            MinimiseBT = new Button();
            ChangeSizeBT = new Button();
            CloseBT = new Button();
            VickyL = new Label();
            ModL = new Label();
            ProjectL = new Label();
            MainP = new Panel();
            MainSpaceP = new Panel();
            MainSearchBarTB = new CustomTextBox();
            MainLB = new CustomListBox();
            MainLabelP = new Panel();
            MainL = new Label();
            VickyP = new Panel();
            Vicky3SpaceL = new Panel();
            VickySearchBarTB = new CustomTextBox();
            VickyLB = new CustomListBox();
            VickyLabelP = new Panel();
            ModP = new Panel();
            NewModP = new Panel();
            AddModBT = new Button();
            XL = new Label();
            ModLB = new CustomListBox();
            ModSearchBarTB = new CustomTextBox();
            ModLabelP = new Panel();
            ProjectP = new Panel();
            ButtonsP = new Panel();
            DeleteBT = new Button();
            SaveBT = new Button();
            AddBT = new Button();
            ProjSearchBarTB = new CustomTextBox();
            ProjLB = new CustomListBox();
            ProjectLabelP = new Panel();
            HotBarP.SuspendLayout();
            MainP.SuspendLayout();
            MainLabelP.SuspendLayout();
            VickyP.SuspendLayout();
            VickyLabelP.SuspendLayout();
            ModP.SuspendLayout();
            NewModP.SuspendLayout();
            ModLabelP.SuspendLayout();
            ProjectP.SuspendLayout();
            ButtonsP.SuspendLayout();
            ProjectLabelP.SuspendLayout();
            SuspendLayout();
            // 
            // HotBarP
            // 
            HotBarP.BackColor = Color.FromArgb(30, 30, 30);
            HotBarP.Controls.Add(HelpBT);
            HotBarP.Controls.Add(MinimiseBT);
            HotBarP.Controls.Add(ChangeSizeBT);
            HotBarP.Controls.Add(CloseBT);
            HotBarP.Dock = DockStyle.Top;
            HotBarP.Location = new Point(0, 0);
            HotBarP.Name = "HotBarP";
            HotBarP.Size = new Size(1183, 32);
            HotBarP.TabIndex = 32;
            HotBarP.MouseDown += HotBarP_MouseDown;
            // 
            // HelpBT
            // 
            HelpBT.BackColor = Color.FromArgb(56, 56, 56);
            HelpBT.BackgroundImageLayout = ImageLayout.Zoom;
            HelpBT.Dock = DockStyle.Right;
            HelpBT.FlatAppearance.BorderColor = Color.FromArgb(66, 66, 66);
            HelpBT.FlatAppearance.MouseDownBackColor = Color.FromArgb(35, 126, 255);
            HelpBT.FlatAppearance.MouseOverBackColor = Color.FromArgb(40, 131, 255);
            HelpBT.FlatStyle = FlatStyle.Flat;
            HelpBT.Font = new Font("Cascadia Mono", 12F, FontStyle.Regular, GraphicsUnit.Point);
            HelpBT.ForeColor = Color.FromArgb(250, 250, 250);
            HelpBT.ImageAlign = ContentAlignment.MiddleLeft;
            HelpBT.Location = new Point(1039, 0);
            HelpBT.Name = "HelpBT";
            HelpBT.Padding = new Padding(5, 0, 0, 0);
            HelpBT.Size = new Size(36, 32);
            HelpBT.TabIndex = 73;
            HelpBT.Text = "?";
            HelpBT.TextAlign = ContentAlignment.MiddleLeft;
            HelpBT.TextImageRelation = TextImageRelation.ImageBeforeText;
            HelpBT.UseVisualStyleBackColor = false;
            HelpBT.Click += HelpBT_Click;
            // 
            // MinimiseBT
            // 
            MinimiseBT.BackColor = Color.FromArgb(56, 56, 56);
            MinimiseBT.BackgroundImageLayout = ImageLayout.Zoom;
            MinimiseBT.Dock = DockStyle.Right;
            MinimiseBT.FlatAppearance.BorderColor = Color.FromArgb(66, 66, 66);
            MinimiseBT.FlatAppearance.MouseDownBackColor = Color.FromArgb(25, 202, 211);
            MinimiseBT.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 207, 216);
            MinimiseBT.FlatStyle = FlatStyle.Flat;
            MinimiseBT.Font = new Font("Cascadia Mono", 12F, FontStyle.Regular, GraphicsUnit.Point);
            MinimiseBT.ForeColor = Color.FromArgb(250, 250, 250);
            MinimiseBT.ImageAlign = ContentAlignment.MiddleLeft;
            MinimiseBT.Location = new Point(1075, 0);
            MinimiseBT.Name = "MinimiseBT";
            MinimiseBT.Padding = new Padding(5, 0, 0, 0);
            MinimiseBT.Size = new Size(36, 32);
            MinimiseBT.TabIndex = 74;
            MinimiseBT.Text = "_";
            MinimiseBT.TextAlign = ContentAlignment.MiddleLeft;
            MinimiseBT.TextImageRelation = TextImageRelation.ImageBeforeText;
            MinimiseBT.UseVisualStyleBackColor = false;
            MinimiseBT.Click += MinimiseBT_Click;
            // 
            // ChangeSizeBT
            // 
            ChangeSizeBT.BackColor = Color.FromArgb(56, 56, 56);
            ChangeSizeBT.BackgroundImageLayout = ImageLayout.Zoom;
            ChangeSizeBT.Dock = DockStyle.Right;
            ChangeSizeBT.Enabled = false;
            ChangeSizeBT.FlatAppearance.BorderColor = Color.FromArgb(66, 66, 66);
            ChangeSizeBT.FlatAppearance.MouseDownBackColor = Color.FromArgb(61, 155, 255);
            ChangeSizeBT.FlatAppearance.MouseOverBackColor = Color.FromArgb(66, 160, 255);
            ChangeSizeBT.FlatStyle = FlatStyle.Flat;
            ChangeSizeBT.Font = new Font("Cascadia Mono", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ChangeSizeBT.ForeColor = Color.FromArgb(250, 250, 250);
            ChangeSizeBT.ImageAlign = ContentAlignment.MiddleLeft;
            ChangeSizeBT.Location = new Point(1111, 0);
            ChangeSizeBT.Name = "ChangeSizeBT";
            ChangeSizeBT.Padding = new Padding(5, 3, 0, 0);
            ChangeSizeBT.Size = new Size(36, 32);
            ChangeSizeBT.TabIndex = 75;
            ChangeSizeBT.Text = "□";
            ChangeSizeBT.TextAlign = ContentAlignment.MiddleLeft;
            ChangeSizeBT.TextImageRelation = TextImageRelation.ImageBeforeText;
            ChangeSizeBT.UseVisualStyleBackColor = false;
            // 
            // CloseBT
            // 
            CloseBT.BackColor = Color.FromArgb(56, 56, 56);
            CloseBT.BackgroundImageLayout = ImageLayout.Zoom;
            CloseBT.Dock = DockStyle.Right;
            CloseBT.FlatAppearance.BorderColor = Color.FromArgb(66, 66, 66);
            CloseBT.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 39, 58);
            CloseBT.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 44, 63);
            CloseBT.FlatStyle = FlatStyle.Flat;
            CloseBT.Font = new Font("Cascadia Mono", 12F, FontStyle.Regular, GraphicsUnit.Point);
            CloseBT.ForeColor = Color.FromArgb(250, 250, 250);
            CloseBT.ImageAlign = ContentAlignment.MiddleLeft;
            CloseBT.Location = new Point(1147, 0);
            CloseBT.Name = "CloseBT";
            CloseBT.Padding = new Padding(5, 1, 0, 0);
            CloseBT.Size = new Size(36, 32);
            CloseBT.TabIndex = 76;
            CloseBT.Text = "x";
            CloseBT.TextAlign = ContentAlignment.MiddleLeft;
            CloseBT.TextImageRelation = TextImageRelation.ImageBeforeText;
            CloseBT.UseVisualStyleBackColor = false;
            CloseBT.Click += CloseBT_Click;
            // 
            // VickyL
            // 
            VickyL.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            VickyL.AutoSize = true;
            VickyL.BackColor = Color.Transparent;
            VickyL.Font = new Font("Cascadia Mono", 15F, FontStyle.Regular, GraphicsUnit.Point);
            VickyL.Location = new Point(36, 4);
            VickyL.Name = "VickyL";
            VickyL.Size = new Size(132, 27);
            VickyL.TabIndex = 71;
            VickyL.Text = "Victoria 3";
            // 
            // ModL
            // 
            ModL.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            ModL.AutoSize = true;
            ModL.BackColor = Color.Transparent;
            ModL.Font = new Font("Cascadia Mono", 15F, FontStyle.Regular, GraphicsUnit.Point);
            ModL.Location = new Point(126, 4);
            ModL.Name = "ModL";
            ModL.Size = new Size(48, 27);
            ModL.TabIndex = 72;
            ModL.Text = "Mod";
            // 
            // ProjectL
            // 
            ProjectL.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            ProjectL.AutoSize = true;
            ProjectL.BackColor = Color.Transparent;
            ProjectL.Font = new Font("Cascadia Mono", 15F, FontStyle.Regular, GraphicsUnit.Point);
            ProjectL.Location = new Point(124, 0);
            ProjectL.Name = "ProjectL";
            ProjectL.Size = new Size(96, 27);
            ProjectL.TabIndex = 73;
            ProjectL.Text = "Project";
            // 
            // MainP
            // 
            MainP.Controls.Add(MainSpaceP);
            MainP.Controls.Add(MainSearchBarTB);
            MainP.Controls.Add(MainLB);
            MainP.Controls.Add(MainLabelP);
            MainP.Location = new Point(30, 55);
            MainP.Name = "MainP";
            MainP.Size = new Size(231, 560);
            MainP.TabIndex = 87;
            // 
            // MainSpaceP
            // 
            MainSpaceP.Dock = DockStyle.Top;
            MainSpaceP.Location = new Point(0, 61);
            MainSpaceP.Name = "MainSpaceP";
            MainSpaceP.Size = new Size(231, 31);
            MainSpaceP.TabIndex = 83;
            // 
            // MainSearchBarTB
            // 
            MainSearchBarTB.BackColor = Color.FromArgb(56, 56, 56);
            MainSearchBarTB.BackgroundColorFocus = Color.FromArgb(31, 31, 31);
            MainSearchBarTB.BorderColor = Color.FromArgb(66, 66, 66);
            MainSearchBarTB.BorderFocusColor = Color.FromArgb(153, 153, 153);
            MainSearchBarTB.BorderSize = 1;
            MainSearchBarTB.Dock = DockStyle.Top;
            MainSearchBarTB.ForeColor = Color.FromArgb(249, 249, 249);
            MainSearchBarTB.Location = new Point(0, 31);
            MainSearchBarTB.Multiline = false;
            MainSearchBarTB.Name = "MainSearchBarTB";
            MainSearchBarTB.Padding = new Padding(7, 5, 7, 5);
            MainSearchBarTB.ReadOnly = false;
            MainSearchBarTB.Size = new Size(231, 30);
            MainSearchBarTB.TabIndex = 65;
            MainSearchBarTB.Texts = "";
            MainSearchBarTB.UnderlinedStyle = false;
            MainSearchBarTB.CustomTextBox_TextChanged += MainSearchBarTB_CustomTextBox_TextChanged;
            // 
            // MainLB
            // 
            MainLB.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            MainLB.BackColor = Color.FromArgb(40, 40, 40);
            MainLB.BorderColor = Color.FromArgb(66, 66, 66);
            MainLB.BorderSize = 2;
            MainLB.ForeColor = Color.FromArgb(250, 250, 250);
            MainLB.HighlightColor = Color.FromArgb(80, 80, 80);
            MainLB.LineColor = Color.FromArgb(66, 66, 66);
            MainLB.LineSize = 2;
            MainLB.Location = new Point(3, 85);
            MainLB.Name = "MainLB";
            MainLB.Padding = new Padding(2);
            MainLB.SelectedIndex = -1;
            MainLB.Size = new Size(225, 472);
            MainLB.TabIndex = 56;
            MainLB.ItemDoubleClicked += MainLB_Click;
            // 
            // MainLabelP
            // 
            MainLabelP.Controls.Add(MainL);
            MainLabelP.Dock = DockStyle.Top;
            MainLabelP.Location = new Point(0, 0);
            MainLabelP.Name = "MainLabelP";
            MainLabelP.Size = new Size(231, 31);
            MainLabelP.TabIndex = 81;
            // 
            // MainL
            // 
            MainL.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            MainL.AutoSize = true;
            MainL.BackColor = Color.Transparent;
            MainL.Font = new Font("Cascadia Mono", 15F, FontStyle.Regular, GraphicsUnit.Point);
            MainL.Location = new Point(86, 4);
            MainL.Name = "MainL";
            MainL.Size = new Size(60, 27);
            MainL.TabIndex = 88;
            MainL.Text = "Main";
            // 
            // VickyP
            // 
            VickyP.Controls.Add(Vicky3SpaceL);
            VickyP.Controls.Add(VickySearchBarTB);
            VickyP.Controls.Add(VickyLB);
            VickyP.Controls.Add(VickyLabelP);
            VickyP.Location = new Point(288, 59);
            VickyP.Name = "VickyP";
            VickyP.Size = new Size(201, 560);
            VickyP.TabIndex = 88;
            // 
            // Vicky3SpaceL
            // 
            Vicky3SpaceL.Dock = DockStyle.Top;
            Vicky3SpaceL.Location = new Point(0, 61);
            Vicky3SpaceL.Name = "Vicky3SpaceL";
            Vicky3SpaceL.Size = new Size(201, 31);
            Vicky3SpaceL.TabIndex = 84;
            // 
            // VickySearchBarTB
            // 
            VickySearchBarTB.BackColor = Color.FromArgb(56, 56, 56);
            VickySearchBarTB.BackgroundColorFocus = Color.FromArgb(31, 31, 31);
            VickySearchBarTB.BorderColor = Color.FromArgb(66, 66, 66);
            VickySearchBarTB.BorderFocusColor = Color.FromArgb(153, 153, 153);
            VickySearchBarTB.BorderSize = 1;
            VickySearchBarTB.Dock = DockStyle.Top;
            VickySearchBarTB.ForeColor = Color.FromArgb(249, 249, 249);
            VickySearchBarTB.Location = new Point(0, 31);
            VickySearchBarTB.Multiline = false;
            VickySearchBarTB.Name = "VickySearchBarTB";
            VickySearchBarTB.Padding = new Padding(7, 5, 7, 5);
            VickySearchBarTB.ReadOnly = false;
            VickySearchBarTB.Size = new Size(201, 30);
            VickySearchBarTB.TabIndex = 66;
            VickySearchBarTB.Texts = "";
            VickySearchBarTB.UnderlinedStyle = false;
            VickySearchBarTB.CustomTextBox_TextChanged += VickySearchBarTB_CustomTextBox_TextChanged;
            // 
            // VickyLB
            // 
            VickyLB.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            VickyLB.BackColor = Color.FromArgb(40, 40, 40);
            VickyLB.BorderColor = Color.FromArgb(66, 66, 66);
            VickyLB.BorderSize = 2;
            VickyLB.ForeColor = Color.FromArgb(250, 250, 250);
            VickyLB.HighlightColor = Color.FromArgb(80, 80, 80);
            VickyLB.LineColor = Color.FromArgb(66, 66, 66);
            VickyLB.LineSize = 2;
            VickyLB.Location = new Point(3, 85);
            VickyLB.Name = "VickyLB";
            VickyLB.Padding = new Padding(2);
            VickyLB.SelectedIndex = -1;
            VickyLB.Size = new Size(195, 472);
            VickyLB.TabIndex = 83;
            VickyLB.ItemDoubleClicked += VickyLB_Click;
            // 
            // VickyLabelP
            // 
            VickyLabelP.Controls.Add(VickyL);
            VickyLabelP.Dock = DockStyle.Top;
            VickyLabelP.Location = new Point(0, 0);
            VickyLabelP.Name = "VickyLabelP";
            VickyLabelP.Size = new Size(201, 31);
            VickyLabelP.TabIndex = 82;
            // 
            // ModP
            // 
            ModP.Controls.Add(NewModP);
            ModP.Controls.Add(ModLB);
            ModP.Controls.Add(ModSearchBarTB);
            ModP.Controls.Add(ModLabelP);
            ModP.Location = new Point(516, 59);
            ModP.Name = "ModP";
            ModP.Size = new Size(290, 560);
            ModP.TabIndex = 89;
            // 
            // NewModP
            // 
            NewModP.Controls.Add(AddModBT);
            NewModP.Controls.Add(XL);
            NewModP.Dock = DockStyle.Top;
            NewModP.Location = new Point(0, 61);
            NewModP.Name = "NewModP";
            NewModP.Size = new Size(290, 32);
            NewModP.TabIndex = 87;
            // 
            // AddModBT
            // 
            AddModBT.BackColor = Color.FromArgb(56, 56, 56);
            AddModBT.BackgroundImageLayout = ImageLayout.Zoom;
            AddModBT.Dock = DockStyle.Right;
            AddModBT.FlatAppearance.BorderColor = Color.FromArgb(66, 66, 66);
            AddModBT.FlatAppearance.BorderSize = 0;
            AddModBT.FlatAppearance.MouseDownBackColor = Color.FromArgb(51, 51, 51);
            AddModBT.FlatAppearance.MouseOverBackColor = Color.FromArgb(77, 77, 77);
            AddModBT.FlatStyle = FlatStyle.Flat;
            AddModBT.Font = new Font("Cascadia Mono", 12F, FontStyle.Regular, GraphicsUnit.Point);
            AddModBT.ForeColor = Color.FromArgb(250, 250, 250);
            AddModBT.Image = (Image)resources.GetObject("AddModBT.Image");
            AddModBT.Location = new Point(141, 0);
            AddModBT.Name = "AddModBT";
            AddModBT.Padding = new Padding(5, 0, 0, 0);
            AddModBT.Size = new Size(130, 32);
            AddModBT.TabIndex = 86;
            AddModBT.Text = " New Mod";
            AddModBT.TextAlign = ContentAlignment.MiddleLeft;
            AddModBT.TextImageRelation = TextImageRelation.ImageBeforeText;
            AddModBT.UseVisualStyleBackColor = false;
            // 
            // XL
            // 
            XL.AutoSize = true;
            XL.BackColor = Color.Transparent;
            XL.Dock = DockStyle.Right;
            XL.ForeColor = Color.FromArgb(255, 44, 63);
            XL.Location = new Point(271, 0);
            XL.Name = "XL";
            XL.Size = new Size(19, 21);
            XL.TabIndex = 85;
            XL.Text = "X";
            XL.Visible = false;
            // 
            // ModLB
            // 
            ModLB.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ModLB.BackColor = Color.FromArgb(40, 40, 40);
            ModLB.BorderColor = Color.FromArgb(66, 66, 66);
            ModLB.BorderSize = 2;
            ModLB.ForeColor = Color.FromArgb(250, 250, 250);
            ModLB.HighlightColor = Color.FromArgb(80, 80, 80);
            ModLB.LineColor = Color.FromArgb(66, 66, 66);
            ModLB.LineSize = 2;
            ModLB.Location = new Point(3, 85);
            ModLB.Name = "ModLB";
            ModLB.Padding = new Padding(2);
            ModLB.SelectedIndex = -1;
            ModLB.Size = new Size(284, 472);
            ModLB.TabIndex = 83;
            ModLB.ItemDoubleClicked += ModLB_DoubleClick;
            // 
            // ModSearchBarTB
            // 
            ModSearchBarTB.BackColor = Color.FromArgb(56, 56, 56);
            ModSearchBarTB.BackgroundColorFocus = Color.FromArgb(31, 31, 31);
            ModSearchBarTB.BorderColor = Color.FromArgb(66, 66, 66);
            ModSearchBarTB.BorderFocusColor = Color.FromArgb(153, 153, 153);
            ModSearchBarTB.BorderSize = 1;
            ModSearchBarTB.Dock = DockStyle.Top;
            ModSearchBarTB.ForeColor = Color.FromArgb(249, 249, 249);
            ModSearchBarTB.Location = new Point(0, 31);
            ModSearchBarTB.Multiline = false;
            ModSearchBarTB.Name = "ModSearchBarTB";
            ModSearchBarTB.Padding = new Padding(7, 5, 7, 5);
            ModSearchBarTB.ReadOnly = false;
            ModSearchBarTB.Size = new Size(290, 30);
            ModSearchBarTB.TabIndex = 67;
            ModSearchBarTB.Texts = "";
            ModSearchBarTB.UnderlinedStyle = false;
            ModSearchBarTB.CustomTextBox_TextChanged += ModSearchBarTB_CustomTextBox_TextChanged;
            // 
            // ModLabelP
            // 
            ModLabelP.Controls.Add(ModL);
            ModLabelP.Dock = DockStyle.Top;
            ModLabelP.Location = new Point(0, 0);
            ModLabelP.Name = "ModLabelP";
            ModLabelP.Size = new Size(290, 31);
            ModLabelP.TabIndex = 82;
            // 
            // ProjectP
            // 
            ProjectP.Controls.Add(ButtonsP);
            ProjectP.Controls.Add(ProjSearchBarTB);
            ProjectP.Controls.Add(ProjLB);
            ProjectP.Controls.Add(ProjectLabelP);
            ProjectP.Location = new Point(849, 59);
            ProjectP.Name = "ProjectP";
            ProjectP.Size = new Size(322, 557);
            ProjectP.TabIndex = 90;
            // 
            // ButtonsP
            // 
            ButtonsP.Controls.Add(DeleteBT);
            ButtonsP.Controls.Add(SaveBT);
            ButtonsP.Controls.Add(AddBT);
            ButtonsP.Dock = DockStyle.Top;
            ButtonsP.Location = new Point(0, 61);
            ButtonsP.Name = "ButtonsP";
            ButtonsP.Size = new Size(322, 32);
            ButtonsP.TabIndex = 86;
            // 
            // DeleteBT
            // 
            DeleteBT.BackColor = Color.FromArgb(56, 56, 56);
            DeleteBT.BackgroundImageLayout = ImageLayout.Zoom;
            DeleteBT.Dock = DockStyle.Left;
            DeleteBT.Enabled = false;
            DeleteBT.FlatAppearance.BorderColor = Color.FromArgb(66, 66, 66);
            DeleteBT.FlatAppearance.BorderSize = 0;
            DeleteBT.FlatAppearance.MouseDownBackColor = Color.FromArgb(51, 51, 51);
            DeleteBT.FlatAppearance.MouseOverBackColor = Color.FromArgb(77, 77, 77);
            DeleteBT.FlatStyle = FlatStyle.Flat;
            DeleteBT.Font = new Font("Cascadia Mono", 12F, FontStyle.Regular, GraphicsUnit.Point);
            DeleteBT.ForeColor = Color.FromArgb(250, 250, 250);
            DeleteBT.Image = (Image)resources.GetObject("DeleteBT.Image");
            DeleteBT.Location = new Point(183, 0);
            DeleteBT.Name = "DeleteBT";
            DeleteBT.Padding = new Padding(5, 0, 0, 0);
            DeleteBT.Size = new Size(118, 32);
            DeleteBT.TabIndex = 74;
            DeleteBT.Text = " Delete";
            DeleteBT.TextAlign = ContentAlignment.MiddleLeft;
            DeleteBT.TextImageRelation = TextImageRelation.ImageBeforeText;
            DeleteBT.UseVisualStyleBackColor = false;
            // 
            // SaveBT
            // 
            SaveBT.BackColor = Color.FromArgb(56, 56, 56);
            SaveBT.BackgroundImageLayout = ImageLayout.Zoom;
            SaveBT.Dock = DockStyle.Left;
            SaveBT.Enabled = false;
            SaveBT.FlatAppearance.BorderColor = Color.FromArgb(66, 66, 66);
            SaveBT.FlatAppearance.BorderSize = 0;
            SaveBT.FlatAppearance.MouseDownBackColor = Color.FromArgb(51, 51, 51);
            SaveBT.FlatAppearance.MouseOverBackColor = Color.FromArgb(77, 77, 77);
            SaveBT.FlatStyle = FlatStyle.Flat;
            SaveBT.Font = new Font("Cascadia Mono", 12F, FontStyle.Regular, GraphicsUnit.Point);
            SaveBT.ForeColor = Color.FromArgb(250, 250, 250);
            SaveBT.Image = (Image)resources.GetObject("SaveBT.Image");
            SaveBT.Location = new Point(90, 0);
            SaveBT.Name = "SaveBT";
            SaveBT.Padding = new Padding(5, 0, 0, 0);
            SaveBT.Size = new Size(93, 32);
            SaveBT.TabIndex = 73;
            SaveBT.Text = " Save";
            SaveBT.TextAlign = ContentAlignment.MiddleLeft;
            SaveBT.TextImageRelation = TextImageRelation.ImageBeforeText;
            SaveBT.UseVisualStyleBackColor = false;
            // 
            // AddBT
            // 
            AddBT.BackColor = Color.FromArgb(56, 56, 56);
            AddBT.BackgroundImageLayout = ImageLayout.Zoom;
            AddBT.Dock = DockStyle.Left;
            AddBT.Enabled = false;
            AddBT.FlatAppearance.BorderColor = Color.FromArgb(66, 66, 66);
            AddBT.FlatAppearance.BorderSize = 0;
            AddBT.FlatAppearance.MouseDownBackColor = Color.FromArgb(51, 51, 51);
            AddBT.FlatAppearance.MouseOverBackColor = Color.FromArgb(77, 77, 77);
            AddBT.FlatStyle = FlatStyle.Flat;
            AddBT.Font = new Font("Cascadia Mono", 12F, FontStyle.Regular, GraphicsUnit.Point);
            AddBT.ForeColor = Color.FromArgb(250, 250, 250);
            AddBT.Image = (Image)resources.GetObject("AddBT.Image");
            AddBT.Location = new Point(0, 0);
            AddBT.Name = "AddBT";
            AddBT.Padding = new Padding(5, 0, 0, 0);
            AddBT.Size = new Size(90, 32);
            AddBT.TabIndex = 71;
            AddBT.Text = " New";
            AddBT.TextAlign = ContentAlignment.MiddleLeft;
            AddBT.TextImageRelation = TextImageRelation.ImageBeforeText;
            AddBT.UseVisualStyleBackColor = false;
            // 
            // ProjSearchBarTB
            // 
            ProjSearchBarTB.BackColor = Color.FromArgb(56, 56, 56);
            ProjSearchBarTB.BackgroundColorFocus = Color.FromArgb(31, 31, 31);
            ProjSearchBarTB.BorderColor = Color.FromArgb(66, 66, 66);
            ProjSearchBarTB.BorderFocusColor = Color.FromArgb(153, 153, 153);
            ProjSearchBarTB.BorderSize = 1;
            ProjSearchBarTB.Dock = DockStyle.Top;
            ProjSearchBarTB.ForeColor = Color.FromArgb(249, 249, 249);
            ProjSearchBarTB.Location = new Point(0, 31);
            ProjSearchBarTB.Multiline = false;
            ProjSearchBarTB.Name = "ProjSearchBarTB";
            ProjSearchBarTB.Padding = new Padding(7, 5, 7, 5);
            ProjSearchBarTB.ReadOnly = false;
            ProjSearchBarTB.Size = new Size(322, 30);
            ProjSearchBarTB.TabIndex = 68;
            ProjSearchBarTB.Texts = "";
            ProjSearchBarTB.UnderlinedStyle = false;
            ProjSearchBarTB.CustomTextBox_TextChanged += ProjSearchBarTB_CustomTextBox_TextChanged;
            // 
            // ProjLB
            // 
            ProjLB.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ProjLB.BackColor = Color.FromArgb(40, 40, 40);
            ProjLB.BorderColor = Color.FromArgb(66, 66, 66);
            ProjLB.BorderSize = 2;
            ProjLB.ForeColor = Color.FromArgb(250, 250, 250);
            ProjLB.HighlightColor = Color.FromArgb(80, 80, 80);
            ProjLB.LineColor = Color.FromArgb(66, 66, 66);
            ProjLB.LineSize = 2;
            ProjLB.Location = new Point(5, 82);
            ProjLB.Name = "ProjLB";
            ProjLB.Padding = new Padding(2);
            ProjLB.SelectedIndex = -1;
            ProjLB.Size = new Size(314, 472);
            ProjLB.TabIndex = 83;
            ProjLB.ItemDoubleClicked += ProjectLB_Click;
            // 
            // ProjectLabelP
            // 
            ProjectLabelP.Controls.Add(ProjectL);
            ProjectLabelP.Dock = DockStyle.Top;
            ProjectLabelP.Location = new Point(0, 0);
            ProjectLabelP.Name = "ProjectLabelP";
            ProjectLabelP.Size = new Size(322, 31);
            ProjectLabelP.TabIndex = 82;
            // 
            // Main
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(36, 36, 36);
            ClientSize = new Size(1183, 648);
            Controls.Add(ProjectP);
            Controls.Add(ModP);
            Controls.Add(VickyP);
            Controls.Add(MainP);
            Controls.Add(HotBarP);
            Font = new Font("Cascadia Mono", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = Color.FromArgb(250, 250, 250);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Main";
            StartPosition = FormStartPosition.Manual;
            Text = " ";
            WindowState = FormWindowState.Maximized;
            FormClosing += Main_FormClosing;
            Load += Main_Load;
            HotBarP.ResumeLayout(false);
            MainP.ResumeLayout(false);
            MainLabelP.ResumeLayout(false);
            MainLabelP.PerformLayout();
            VickyP.ResumeLayout(false);
            VickyLabelP.ResumeLayout(false);
            VickyLabelP.PerformLayout();
            ModP.ResumeLayout(false);
            NewModP.ResumeLayout(false);
            NewModP.PerformLayout();
            ModLabelP.ResumeLayout(false);
            ModLabelP.PerformLayout();
            ProjectP.ResumeLayout(false);
            ButtonsP.ResumeLayout(false);
            ProjectLabelP.ResumeLayout(false);
            ProjectLabelP.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel HotBarP;
        private Button MinimiseBT;
        private Button ChangeSizeBT;
        private Button CloseBT;
        private Button HelpBT;
        private Label VickyL;
        private Label ModL;
        private Label ProjectL;
        private Panel MainP;
        private Panel MainLabelP;
        private Label MainL;
        private Panel VickyP;
        private Panel VickyLabelP;
        private Panel ModP;
        private Panel ModLabelP;
        private Panel ProjectP;
        private Panel ProjectLabelP;
        private CustomListBox MainLB;
        private CustomListBox ProjectLB;
        private CustomTextBox MainSearchBarTB;
        private CustomTextBox VickySearchBarTB;
        private CustomTextBox ModSearchBarTB;
        private CustomTextBox ProjSearchBarTB;
        private CustomListBox VickyLB;
        private CustomListBox ModLB;
        private CustomListBox ProjLB;
        private Panel MainSpaceP;
        private Panel Vicky3SpaceL;
        private Panel NewModP;
        private Button AddModBT;
        private Label XL;
        private Panel ButtonsP;
        private Button DeleteBT;
        private Button SaveBT;
        private Button AddBT;
    }
}

