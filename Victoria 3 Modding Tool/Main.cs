using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Victoria_3_Modding_Tool.Forms.Tech;
using Victoria_3_Modding_Tool.Forms.Era;
using System.Drawing.Drawing2D;
using System.Text;

namespace Victoria_3_Modding_Tool
{

    /*
    To do:

    exit save bug

    Help  (Main-PopNeeds-PathForm Needs)

    CodeEditor ->make spellcheck, end custom colors, make autocomplete

    */


    public partial class Main : Form
    {

        public int SaveStatus = 0;  // 0 -> just entered // 1 -> saved // 2 -> unsaved

        public string language;
        public string ProjName;
        public string VickyPath;
        public string ProjPath;
        public string ModPath;  // null -> no mod
        public string ModName;

        public int mainSelectedIndex = -1;
        public int vickySelectedIndex = -1;
        public int modSelectedIndex = -1;
        public int projSelectedIndex = -1;

        public List<string> MainData = new List<string>();

        public List<ClassEra> EraDataP;
        public List<ClassEra> EraDataV;
        public List<ClassEra> EraDataM;

        public List<ClassGoods> GoodsDataP;
        public List<ClassGoods> GoodsDataV;
        public List<ClassGoods> GoodsDataM;

        public List<ClassPopNeeds> PopNeedsDataP;
        public List<ClassPopNeeds> PopNeedsDataV;
        public List<ClassPopNeeds> PopNeedsDataM;

        public List<ClassTech> TechDataP;
        public List<ClassTech> TechDataV;
        public List<ClassTech> TechDataM;


        public Main()
        {
            InitializeComponent();
            this.Padding = new Padding(1);//Border size
            SizeObjects();
            LoadMainLB();
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Form
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void SizeObjects()
        {
            Rectangle rect = Screen.PrimaryScreen.WorkingArea;

            this.Size = new Size(rect.Width, rect.Height);
            this.MaximumSize = new Size(rect.Width, rect.Height);
            this.MinimumSize = new Size(rect.Width, rect.Height);

            MainLB.Size = new Size(rect.Width / 8, rect.Height - 160);
            VickyLB.Size = new Size(rect.Width / 5, rect.Height - 160);
            ModLB.Size = new Size(rect.Width / 5, rect.Height - 160);
            ProjectLB.Size = new Size(rect.Width / 5, rect.Height - 160);

            MainLB.Location = new Point(32, 128);
            VickyLB.Location = new Point(124 + rect.Width / 8, 128);
            ModLB.Location = new Point(156 + rect.Width * 13 / 40, 128);
            ProjectLB.Location = new Point(rect.Width * 4 / 5 - 32, 128);

            MainSearchBarTB.Size = new Size(rect.Width / 8 + 4, 32);
            VickySearchBarTB.Size = new Size(rect.Width / 5 + 4, 32);
            ModSearchBarTB.Size = new Size(rect.Width / 5 + 4, 32);
            ProjSearchBarTB.Size = new Size(rect.Width / 5 + 4, 32);

            MainSearchBarTB.Location = new Point(30, 86);
            VickySearchBarTB.Location = new Point(122 + rect.Width / 8, 86);
            ModSearchBarTB.Location = new Point(154 + rect.Width * 13 / 40, 86);
            ProjSearchBarTB.Location = new Point(rect.Width * 4 / 5 - 34, 86);

            MainL.Location = new Point(32 + rect.Width / 16 - MainL.Width / 2, 44);
            VickyL.Location = new Point(124 + rect.Width * 9 / 40 - VickyL.Width / 2, 44);
            ModL.Location = new Point(154 + rect.Width * 17 / 40 - ModL.Width / 2, 44);
            ProjectL.Location = new Point(rect.Width * 9 / 10 - 16 - ProjectL.Width / 2, 44);

            AddModBT.Size = new Size(100, 100);
            AddBT.Size = new Size(100, 100);
            SaveBT.Size = new Size(100, 100);
            DeleteBT.Size = new Size(100, 100);

            AddModBT.Location = new Point(rect.Width * 53 / 80 + 62 - AddModBT.Width / 2, 230);
            AddBT.Location = new Point(rect.Width * 53 / 80 + 62 - AddBT.Width / 2, 380);
            SaveBT.Location = new Point(rect.Width * 53 / 80 + 62 - SaveBT.Size.Width / 2, 390 + SaveBT.Size.Height);
            DeleteBT.Location = new Point(rect.Width * 53 / 80 + 62 - DeleteBT.Size.Width / 2, 400 + SaveBT.Size.Height + DeleteBT.Size.Height);

            AddModL.Location = new Point(rect.Width * 53 / 80 + 62 - AddBT.Width / 2, 230);
            NewL.Location = new Point(rect.Width * 53 / 80 + 62 - AddBT.Width / 2, 380);
            SaveL.Location = new Point(rect.Width * 53 / 80 + 62 - SaveBT.Size.Width / 2, 390 + SaveBT.Size.Height);
            DeleteL.Location = new Point(rect.Width * 53 / 80 + 62 - DeleteBT.Size.Width / 2, 400 + SaveBT.Size.Height + DeleteBT.Size.Height);

            XL.Location = new Point(rect.Width * 53 / 80 + 62 + AddModBT.Width/2 - XL.Width , 230);
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SaveStatus == 2)
            {
                DialogResult result = MessageBox.ClassMessageBox.Show();
                if (result == DialogResult.OK)
                {
                    DialogResult resul = MessageBox.ClassMessageBox.ShowOverwrite();
                    if (resul == DialogResult.OK)
                    {
                        MakeProjFiles();
                    }
                    else if (resul == DialogResult.Cancel)
                    {

                    }
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }

            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Border
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        protected override void OnPaint(PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.FromArgb(61, 61, 61), ButtonBorderStyle.Solid);

            base.OnPaint(e);
            Graphics graph = e.Graphics;
            //Draw border

            using (Pen penBorder = new Pen(Color.FromArgb(66, 66, 66), 2))
            {
                penBorder.Alignment = PenAlignment.Inset;
                graph.DrawLine(penBorder, MainLB.Width + 78, 54, MainLB.Width + 78, MainLB.Height + 130);
                graph.DrawLine(penBorder, MainLB.Width + VickyLB.Width + ModLB.Width + 188, 350, Screen.PrimaryScreen.WorkingArea.Width - 64 - ProjectLB.Width, 350);
                graph.DrawLine(penBorder, MainLB.Width + VickyLB.Width + ModLB.Width + 188, 360, Screen.PrimaryScreen.WorkingArea.Width - 64 - ProjectLB.Width, 360);
                graph.DrawRectangle(penBorder, MainLB.Location.X - 2, MainLB.Location.Y - 2, MainLB.Width + 4F, MainLB.Height + 4F);
                graph.DrawRectangle(penBorder, VickyLB.Location.X - 2, VickyLB.Location.Y - 2, VickyLB.Width + 4F, VickyLB.Height + 4F);
                graph.DrawRectangle(penBorder, ProjectLB.Location.X - 2, ProjectLB.Location.Y - 2, ProjectLB.Width + 4F, ProjectLB.Height + 4F);
                graph.DrawRectangle(penBorder, ModLB.Location.X - 2, ModLB.Location.Y - 2, ModLB.Width + 4F, ModLB.Height + 4F);
            }

        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Hot Bar Buttons
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void CloseBT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MinimiseBT_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void HelpBT_Click(object sender, EventArgs e)
        {

        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Hot Bar Drag Motion
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void HotBarP_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);

        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // LB Styling
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void LB_DrawItem(object sender, DrawItemEventArgs e, ListBox LB)
        {
            Color backgroundColor = Color.FromArgb(50, 50, 50);
            Color horizontalColor = Color.FromArgb(100, 100, 100);


            if (e.Index >= 0)
            {
                SolidBrush sb = new SolidBrush(((e.State & DrawItemState.Selected) == DrawItemState.Selected) ? horizontalColor : backgroundColor);
                e.Graphics.FillRectangle(sb, e.Bounds);
                string text = LB.Items[e.Index].ToString();
                SolidBrush tb = new SolidBrush(e.ForeColor);
                e.Graphics.DrawString(text, e.Font, tb, LB.GetItemRectangle(e.Index).Location);
            }
        }

        private void MainLB_DrawItem(object sender, DrawItemEventArgs e)
        {
            LB_DrawItem(sender, e, MainLB);
        }

        private void VickyLB_DrawItem(object sender, DrawItemEventArgs e)
        {
            LB_DrawItem(sender, e, VickyLB);
        }

        private void ProjectLB_DrawItem(object sender, DrawItemEventArgs e)
        {
            LB_DrawItem(sender, e, ProjectLB);
        }

        private void ModLB_DrawItem(object sender, DrawItemEventArgs e)
        {
            LB_DrawItem(sender, e, ModLB);
        }


        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // LB data *
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        // *
        private void Mod()
        {
          
            ModLB.Items.Clear();
            if (ModPath != null)
            {
                switch (MainData[mainSelectedIndex].ToString())
                {

                    case "Era":

                        EraDataM = new List<ClassEra>();
                        LoadEraData(ModPath + "\\common\\technology\\eras", EraDataM);
                        ModLB.Items.Add(String.Format("{0,-20}{1,-20 }", "Era", "Cost"));
                        foreach (ClassEra eraEntry in EraDataM) { ModLB.Items.Add(String.Format("{0,-20}{1,-20 }", eraEntry.Era, eraEntry.Cost)); }

                        break;
                    case "Goods":

                        GoodsDataM = new List<ClassGoods>();
                        goods(ProjPath, GoodsDataM, "\\" + ProjName.ToLower().Replace(" ", "_") + "_goods_l_" + language + ".yml");
                        foreach (ClassGoods entry in GoodsDataM) { ModLB.Items.Add(entry.name); }

                        break;
                    case "Pop Needs":

                        PopNeedsDataM = new List<ClassPopNeeds>();
                        popneeds(ProjPath, PopNeedsDataM);
                        foreach (ClassPopNeeds entry in PopNeedsDataM) { ModLB.Items.Add(entry.name); }

                        break;
                    case "Technology":

                        TechDataM = new List<ClassTech>();
                        EraDataM = new List<ClassEra>();
                        EraTech(ModPath, EraDataM, TechDataM, "\\" + ProjName.ToLower().Replace(" ", "_") + "_tech_l_" + language + ".yml");
                        foreach (ClassTech techEntry in TechDataM) { ModLB.Items.Add(techEntry.name); }

                        break;

                    default:
                        break;
                }
            }

        }

        // *
        private void MainLB_Click(object sender, EventArgs e)
        {
            if (MainLB.SelectedIndex == -1) { return; }

            if (SaveStatus == 2)
            {
                DialogResult result = MessageBox.ClassMessageBox.Show();
                if (result == DialogResult.OK)
                {
                    DialogResult resul = MessageBox.ClassMessageBox.ShowOverwrite();
                    if (resul == DialogResult.OK)
                    {
                        MakeProjFiles();
                    }
                    else if (resul == DialogResult.Cancel)
                    {
                        return;
                    }
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
                else
                {
                    SaveStatus = 0;
                }

            }

            AddBT.Enabled = true;

            VickyLB.Items.Clear();
            ProjectLB.Items.Clear();
            ModLB.Items.Clear();

            mainSelectedIndex = MainLB.SelectedIndex;

            switch (MainData[mainSelectedIndex].ToString())
            {

                case "Era":

                    EraDataP = new List<ClassEra>();
                    EraDataV = new List<ClassEra>();

                    LoadEraData(VickyPath + "\\game\\common\\technology\\eras", EraDataV);
                    LoadEraData(ProjPath + "\\common\\technology\\eras", EraDataP);

                    VickyLB.Items.Add(String.Format("{0,-20}{1,-20 }", "Era", "Cost"));
                    foreach (ClassEra eraEntry in EraDataV) { VickyLB.Items.Add(String.Format("{0,-20}{1,-20 }", eraEntry.Era, eraEntry.Cost)); }
                    ProjectLB.Items.Add(String.Format("{0,-20}{1,-20 }", "Era", "Cost"));
                    foreach (ClassEra eraEntry in EraDataP) { ProjectLB.Items.Add(String.Format("{0,-20}{1,-20 }", eraEntry.Era, eraEntry.Cost)); }

                    if (EraDataP.Count == 0) { DeleteBT.Enabled = false; }
                    else { DeleteBT.Enabled = true; }
                    Mod();

                    break;

                case "Goods":
                    GoodsDataP = new List<ClassGoods>();
                    GoodsDataV = new List<ClassGoods>();

                    goods(VickyPath + "\\game", GoodsDataV, "\\goods_l_" + language + ".yml");
                    goods(ProjPath, GoodsDataP, "\\" + ProjName.ToLower().Replace(" ", "_") + "_goods_l_" + language + ".yml");

                    foreach (ClassGoods goodsEntry in GoodsDataV) { VickyLB.Items.Add(goodsEntry.name); }
                    foreach (ClassGoods goodsEntry in GoodsDataP) { ProjectLB.Items.Add(goodsEntry.name); }

                    if (GoodsDataP.Count == 0) { DeleteBT.Enabled = false; }
                    else { DeleteBT.Enabled = true; }
                    Mod();

                    break;


                case "Pop Needs":

                    GoodsDataP = new List<ClassGoods>();
                    GoodsDataV = new List<ClassGoods>();

                    goods(VickyPath + "\\game", GoodsDataV, "\\goods_l_" + language + ".yml");
                    goods(ProjPath, GoodsDataP, "\\" + ProjName.ToLower().Replace(" ", "_") + "_goods_l_" + language + ".yml");

                    PopNeedsDataP = new List<ClassPopNeeds>();
                    PopNeedsDataV = new List<ClassPopNeeds>();

                    popneeds(VickyPath + "\\game", PopNeedsDataV);
                    popneeds(ProjPath, PopNeedsDataP);

                    foreach (ClassPopNeeds Entry in PopNeedsDataV) { VickyLB.Items.Add(Entry.name); }
                    foreach (ClassPopNeeds Entry in PopNeedsDataP) { ProjectLB.Items.Add(Entry.name); }

                    if (PopNeedsDataP.Count == 0) { DeleteBT.Enabled = false; }
                    else { DeleteBT.Enabled = true; }
                    Mod();

                    break;



                case "Technology":

                    TechDataP = new List<ClassTech>();
                    TechDataV = new List<ClassTech>();
                    EraDataP = new List<ClassEra>();
                    EraDataV = new List<ClassEra>();

                    EraTech(VickyPath + "\\game", EraDataV, TechDataV, "\\inventions_l_" + language + ".yml");
                    EraTech(ProjPath, EraDataP, TechDataP, "\\" + ProjName.ToLower().Replace(" ", "_") + "_tech_l_" + language + ".yml");
                    foreach (ClassTech techEntry in TechDataV) { VickyLB.Items.Add(techEntry.name); }
                    foreach (ClassTech techEntry in TechDataP) { ProjectLB.Items.Add(techEntry.name); }

                    if (TechDataP.Count == 0) { DeleteBT.Enabled = false; }
                    else { DeleteBT.Enabled = true; }
                    Mod();

                    break;


                default:
                    MainLB.Items.Add("Error");
                    break;
            }
        }

        // *
        private void VickyLB_Click(object sender, EventArgs e)
        {
            if (mainSelectedIndex == -1) { return; }
            SaveStatus = 2;

            switch (MainData[mainSelectedIndex].ToString())
            {

                case "Era":

                    if (VickyLB.SelectedIndex == 0) { return; }

                    if (VickyLB.Items.Count == 1) { return; }

                    if (VickyLB.SelectedIndex == -1) { vickySelectedIndex = 1; VickyLB.SelectedIndex = 1; } else { vickySelectedIndex = VickyLB.SelectedIndex; }

                    using (EraForm form = new EraForm())
                    {
                        int i;
                        i = new ClassEra().FindEraValue(EraDataV, Int32.Parse(VickyLB.Items[vickySelectedIndex].ToString().Substring(0, 20)));
                        form.local = new ClassEra(EraDataV[i].Era, EraDataV[i].Cost);
                        form.ShowDialog();
                        ClassEra j = form.ReturnValue();
                        if (j != null)
                        {
                            i = new ClassEra().FindEraValue(EraDataP, j.Era); // Index to change
                            if (i == -1)
                            {
                                EraDataP.Add(new ClassEra(j.Era, j.Cost));
                                EraDataP.Sort(delegate (ClassEra t1, ClassEra t2)
                                {
                                    return (t1.Era.CompareTo(t2.Era));
                                });
                                ProjectLB.Items.Clear();
                                ProjectLB.Items.Add(String.Format("{0,-20}{1,-20 }", "Era", "Cost"));
                                foreach (ClassEra eraEntry in EraDataP) { ProjectLB.Items.Add(String.Format("{0,-20}{1,-20 }", eraEntry.Era, eraEntry.Cost)); }
                            }
                            else
                            {
                                EraDataP[i].Cost = j.Cost;
                                ProjectLB.Items.Clear();
                                ProjectLB.Items.Add(String.Format("{0,-20}{1,-20 }", "Era", "Cost"));
                                foreach (ClassEra eraEntry in EraDataP) { ProjectLB.Items.Add(String.Format("{0,-20}{1,-20 }", eraEntry.Era, eraEntry.Cost)); }
                            }
                        }
                    }

                    if (EraDataP.Count == 0) { DeleteBT.Enabled = false; }
                    else { DeleteBT.Enabled = true; }

                    break;

                case "Goods":

                    if (VickyLB.Items.Count == 0) { return; }

                    if (VickyLB.SelectedIndex == -1) { vickySelectedIndex = 0; VickyLB.SelectedIndex = 0; } else { vickySelectedIndex = VickyLB.SelectedIndex; }

                    using (GoodsForm form = new GoodsForm())
                    {
                        int i;
                        i = new ClassGoods().hasNameIndex(GoodsDataV, VickyLB.Items[vickySelectedIndex].ToString());


                        form.sizeOfVicky = GoodsDataV.Count;
                        form.GoodsData = new ClassGoods().MergeGoods(GoodsDataP, GoodsDataV);
                        form.local = new ClassGoods(GoodsDataV[i]);
                        form.ShowDialog();

                        ClassGoods j = form.ReturnValue();
                        if (j != null)
                        {
                            i = new ClassGoods().hasNameIndex(GoodsDataP, j.name); // Index to change
                            if (i == -1)
                            {
                                GoodsDataP.Add(new ClassGoods(j));
                                GoodsDataP.Sort(delegate (ClassGoods t1, ClassGoods t2)
                                {
                                    return (t1.name.CompareTo(t2.name));
                                });
                                ProjectLB.Items.Clear();
                                foreach (ClassGoods entry in GoodsDataP) { ProjectLB.Items.Add(entry.name); }
                            }
                            else
                            {
                                GoodsDataP[i] = j;
                                ProjectLB.Items.Clear();
                                foreach (ClassGoods entry in GoodsDataP) { ProjectLB.Items.Add(entry.name); }
                            }

                        }

                    }

                    if (GoodsDataP.Count == 0) { DeleteBT.Enabled = false; }
                    else { DeleteBT.Enabled = true; }

                    break;

                case "Pop Needs":

                    if (VickyLB.Items.Count == 0) { return; }

                    if (VickyLB.SelectedIndex == -1) { vickySelectedIndex = 0; VickyLB.SelectedIndex = 0; } else { vickySelectedIndex = VickyLB.SelectedIndex; }


                    using (PopNeedsForm form = new PopNeedsForm())
                    {
                        int i;
                        i = new ClassPopNeeds().hasNameIndex(PopNeedsDataV, VickyLB.Items[vickySelectedIndex].ToString());
                        form.sizeOfVicky = PopNeedsDataV.Count;
                        form.GoodsList = new ClassGoods().MergeGoods(GoodsDataP, GoodsDataV);
                        form.PopNeedsList = new ClassPopNeeds().Merge(PopNeedsDataP, PopNeedsDataV);
                        form.local = new ClassPopNeeds(PopNeedsDataV[i]);
                        form.ShowDialog();
                        ClassPopNeeds j = form.ReturnValue();
                        if (j != null)
                        {
                            i = new ClassPopNeeds().hasNameIndex(PopNeedsDataP, j.name); // Index to change
                            if (i == -1)
                            {
                                PopNeedsDataP.Add(new ClassPopNeeds(j));
                                PopNeedsDataP.Sort(delegate (ClassPopNeeds t1, ClassPopNeeds t2)
                                {
                                    return (t1.name.CompareTo(t2.name));
                                });
                                ProjectLB.Items.Clear();
                                foreach (ClassPopNeeds entry in PopNeedsDataP) { ProjectLB.Items.Add(entry.name); }
                            }
                            else
                            {
                                PopNeedsDataP[i] = j;
                                ProjectLB.Items.Clear();
                                foreach (ClassPopNeeds entry in PopNeedsDataP) { ProjectLB.Items.Add(entry.name); }
                            }

                        }

                    }

                    if (PopNeedsDataP.Count == 0) { DeleteBT.Enabled = false; }
                    else { DeleteBT.Enabled = true; }

                    break;


                case "Technology":

                    if (VickyLB.Items.Count == 0) { return; }

                    if (VickyLB.SelectedIndex == -1) { vickySelectedIndex = 0; VickyLB.SelectedIndex = 0; } else { vickySelectedIndex = VickyLB.SelectedIndex; }


                    using (TechForm form = new TechForm())
                    {
                        int i;
                        i = new ClassTech().hasNameIndex(TechDataV, VickyLB.Items[vickySelectedIndex].ToString());
                        form.sizeOfVicky = TechDataV.Count;
                        form.TechList = new ClassTech().MergeTech(TechDataP, TechDataV);
                        form.EraList = new ClassEra().MergeEra(EraDataP, EraDataV);
                        form.local = new ClassTech(TechDataV[i]);
                        form.ShowDialog();
                        ClassTech j = form.ReturnValue();
                        if (j != null)
                        {
                            i = new ClassTech().hasNameIndex(TechDataP, j.name); // Index to change
                            if (i == -1)
                            {
                                TechDataP.Add(new ClassTech(j));
                                TechDataP.Sort(delegate (ClassTech t1, ClassTech t2)
                                {
                                    return (t1.name.CompareTo(t2.name));
                                });
                                ProjectLB.Items.Clear();
                                foreach (ClassTech entry in TechDataP) { ProjectLB.Items.Add(entry.name); }
                            }
                            else
                            {
                                TechDataP[i] = j;
                                ProjectLB.Items.Clear();
                                foreach (ClassTech entry in TechDataP) { ProjectLB.Items.Add(entry.name); }
                            }

                        }

                    }

                    if (TechDataP.Count == 0) { DeleteBT.Enabled = false; }
                    else { DeleteBT.Enabled = true; }

                    break;




                default:
                    MainLB.Items.Add("Error");
                    break;
            }



        }

        // *
        private void ProjectLB_Click(object sender, EventArgs e)
        {
            if (mainSelectedIndex == -1) { return; }
            SaveStatus = 2;

            switch (MainData[mainSelectedIndex].ToString())
            {

                case "Era":

                    if (ProjectLB.SelectedIndex == 0) { return; }

                    if (ProjectLB.Items.Count == 1) { return; }

                    if (ProjectLB.SelectedIndex == -1) { projSelectedIndex = 1; ProjectLB.SelectedIndex = 1; } else { projSelectedIndex = ProjectLB.SelectedIndex; }

                    using (EraForm form = new EraForm())
                    {
                        int i;
                        i = new ClassEra().FindEraValue(EraDataP, Int32.Parse(ProjectLB.Items[projSelectedIndex].ToString().Substring(0, 20)));
                        form.local = new ClassEra(EraDataP[i].Era, EraDataP[i].Cost);
                        form.ShowDialog();
                        ClassEra j = form.ReturnValue();
                        if (j != null)
                        {
                            i = new ClassEra().FindEraValue(EraDataP, j.Era); // Index to change
                            if (i == -1)
                            {
                                EraDataP.Add(new ClassEra(j.Era, j.Cost));
                                EraDataP.Sort(delegate (ClassEra t1, ClassEra t2)
                                {
                                    return (t1.Era.CompareTo(t2.Era));
                                });
                                ProjectLB.Items.Clear();
                                ProjectLB.Items.Add(String.Format("{0,-20}{1,-20 }", "Era", "Cost"));
                                foreach (ClassEra eraEntry in EraDataP) { ProjectLB.Items.Add(String.Format("{0,-20}{1,-20 }", eraEntry.Era, eraEntry.Cost)); }
                            }
                            else
                            {
                                EraDataP[i].Cost = j.Cost;
                                ProjectLB.Items.Clear();
                                ProjectLB.Items.Add(String.Format("{0,-20}{1,-20 }", "Era", "Cost"));
                                foreach (ClassEra eraEntry in EraDataP) { ProjectLB.Items.Add(String.Format("{0,-20}{1,-20 }", eraEntry.Era, eraEntry.Cost)); }
                            }
                        }
                    }

                    if (EraDataP.Count == 0) { DeleteBT.Enabled = false; }
                    else { DeleteBT.Enabled = true; }

                    break;

                case "Goods":

                    if (ProjectLB.Items.Count == 0) { return; }

                    if (ProjectLB.SelectedIndex == -1) { projSelectedIndex = 0; ProjectLB.SelectedIndex = 0; } else { projSelectedIndex = ProjectLB.SelectedIndex; }

                    using (GoodsForm form = new GoodsForm())
                    {
                        int i;
                        i = new ClassGoods().hasNameIndex(GoodsDataP, ProjectLB.Items[projSelectedIndex].ToString());


                        form.sizeOfVicky = GoodsDataV.Count;
                        form.GoodsData = new ClassGoods().MergeGoods(GoodsDataP, GoodsDataV);
                        form.local = new ClassGoods(GoodsDataP[i]);
                        form.ShowDialog();

                        ClassGoods j = form.ReturnValue();
                        if (j != null)
                        {
                            i = new ClassGoods().hasNameIndex(GoodsDataP, j.name); // Index to change
                            if (i == -1)
                            {
                                GoodsDataP.Add(new ClassGoods(j));
                                GoodsDataP.Sort(delegate (ClassGoods t1, ClassGoods t2)
                                {
                                    return (t1.name.CompareTo(t2.name));
                                });
                                ProjectLB.Items.Clear();
                                foreach (ClassGoods entry in GoodsDataP) { ProjectLB.Items.Add(entry.name); }
                            }
                            else
                            {
                                GoodsDataP[i] = j;
                                ProjectLB.Items.Clear();
                                foreach (ClassGoods entry in GoodsDataP) { ProjectLB.Items.Add(entry.name); }
                            }

                        }

                    }

                    if (GoodsDataP.Count == 0) { DeleteBT.Enabled = false; }
                    else { DeleteBT.Enabled = true; }

                    break;

                case "Pop Needs":

                    if (ProjectLB.Items.Count == 0) { return; }

                    if (ProjectLB.SelectedIndex == -1) { projSelectedIndex = 0; ProjectLB.SelectedIndex = 0; } else { projSelectedIndex = ProjectLB.SelectedIndex; }


                    using (PopNeedsForm form = new PopNeedsForm())
                    {
                        int i;
                        i = new ClassPopNeeds().hasNameIndex(PopNeedsDataP, ProjectLB.Items[projSelectedIndex].ToString());
                        form.sizeOfVicky = PopNeedsDataP.Count;
                        form.GoodsList = new ClassGoods().MergeGoods(GoodsDataP, GoodsDataV);
                        form.PopNeedsList = new ClassPopNeeds().Merge(PopNeedsDataP, PopNeedsDataV);
                        form.local = new ClassPopNeeds(PopNeedsDataP[i]);
                        form.ShowDialog();
                        ClassPopNeeds j = form.ReturnValue();
                        if (j != null)
                        {
                            i = new ClassPopNeeds().hasNameIndex(PopNeedsDataP, j.name); // Index to change
                            if (i == -1)
                            {
                                PopNeedsDataP.Add(new ClassPopNeeds(j));
                                PopNeedsDataP.Sort(delegate (ClassPopNeeds t1, ClassPopNeeds t2)
                                {
                                    return (t1.name.CompareTo(t2.name));
                                });
                                ProjectLB.Items.Clear();
                                foreach (ClassPopNeeds entry in PopNeedsDataP) { ProjectLB.Items.Add(entry.name); }
                            }
                            else
                            {
                                PopNeedsDataP[i] = j;
                                ProjectLB.Items.Clear();
                                foreach (ClassPopNeeds entry in PopNeedsDataP) { ProjectLB.Items.Add(entry.name); }
                            }

                        }

                    }

                    if (PopNeedsDataP.Count == 0) { DeleteBT.Enabled = false; }
                    else { DeleteBT.Enabled = true; }


                    break;

                case "Technology":

                    if (ProjectLB.Items.Count == 0) { return; }

                    if (ProjectLB.SelectedIndex == -1) { projSelectedIndex = 0; ProjectLB.SelectedIndex = 0; } else { projSelectedIndex = ProjectLB.SelectedIndex; }


                    using (TechForm form = new TechForm())
                    {
                        int i;
                        i = new ClassTech().hasNameIndex(TechDataP, ProjectLB.Items[projSelectedIndex].ToString());
                        form.sizeOfVicky = TechDataV.Count;
                        form.TechList = new ClassTech().MergeTech(TechDataP, TechDataV);
                        form.EraList = new ClassEra().MergeEra(EraDataP, EraDataV);
                        form.local = new ClassTech(TechDataP[i]);
                        form.ShowDialog();
                        ClassTech j = form.ReturnValue();
                        if (j != null)
                        {
                            i = new ClassTech().hasNameIndex(TechDataP, j.name); // Index to change
                            if (i == -1)
                            {
                                TechDataP.Add(new ClassTech(j));
                                TechDataP.Sort(delegate (ClassTech t1, ClassTech t2)
                                {
                                    return (t1.name.CompareTo(t2.name));
                                });
                                ProjectLB.Items.Clear();
                                foreach (ClassTech entry in TechDataP) { ProjectLB.Items.Add(entry.name); }
                            }
                            else
                            {
                                TechDataP[i] = j;
                                ProjectLB.Items.Clear();
                                foreach (ClassTech entry in TechDataP) { ProjectLB.Items.Add(entry.name); }
                            }

                        }

                    }

                    if (TechDataP.Count == 0) { DeleteBT.Enabled = false; }
                    else { DeleteBT.Enabled = true; }


                    break;

                case "Decisions":


                    break;




                default:
                    MainLB.Items.Add("Error");
                    break;
            }


        }

        // *
        private void ModLB_DoubleClick(object sender, EventArgs e)
        {
            if (mainSelectedIndex == -1) { return; }
            SaveStatus = 2;

            if (ModPath != null)
            {
                switch (MainData[mainSelectedIndex].ToString())
                {

                    case "Era":

                        if (ModLB.SelectedIndex == 0) { return; }

                        if (ModLB.Items.Count == 1) { return; }

                        if (ModLB.SelectedIndex == -1) { modSelectedIndex = 1; ModLB.SelectedIndex = 1; } else { modSelectedIndex = ModLB.SelectedIndex; }

                        using (EraForm form = new EraForm())
                        {
                            int i;
                            i = new ClassEra().FindEraValue(EraDataM, Int32.Parse(ModLB.Items[modSelectedIndex].ToString().Substring(0, 20)));
                            form.local = new ClassEra(EraDataM[i].Era, EraDataM[i].Cost);
                            form.ShowDialog();
                            ClassEra j = form.ReturnValue();
                            if (j != null)
                            {
                                i = new ClassEra().FindEraValue(EraDataP, j.Era); // Index to change
                                if (i == -1)
                                {
                                    EraDataP.Add(new ClassEra(j.Era, j.Cost));
                                    EraDataP.Sort(delegate (ClassEra t1, ClassEra t2)
                                    {
                                        return (t1.Era.CompareTo(t2.Era));
                                    });
                                    ProjectLB.Items.Clear();
                                    ProjectLB.Items.Add(String.Format("{0,-20}{1,-20 }", "Era", "Cost"));
                                    foreach (ClassEra eraEntry in EraDataP) { ProjectLB.Items.Add(String.Format("{0,-20}{1,-20 }", eraEntry.Era, eraEntry.Cost)); }
                                }
                                else
                                {
                                    EraDataP[i].Cost = j.Cost;
                                    ProjectLB.Items.Clear();
                                    ProjectLB.Items.Add(String.Format("{0,-20}{1,-20 }", "Era", "Cost"));
                                    foreach (ClassEra eraEntry in EraDataP) { ProjectLB.Items.Add(String.Format("{0,-20}{1,-20 }", eraEntry.Era, eraEntry.Cost)); }
                                }
                            }
                        }

                        if (EraDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }

                        break;

                    case "Goods":

                        if (ModLB.Items.Count == 0) { return; }

                        if (ModLB.SelectedIndex == -1) { modSelectedIndex = 0; ModLB.SelectedIndex = 0; } else { modSelectedIndex = ModLB.SelectedIndex; }

                        using (GoodsForm form = new GoodsForm())
                        {
                            int i;
                            i = new ClassGoods().hasNameIndex(GoodsDataM, ModLB.Items[modSelectedIndex].ToString());


                            form.sizeOfVicky = GoodsDataV.Count;
                            form.GoodsData = new ClassGoods().MergeGoods(GoodsDataP, GoodsDataV);
                            form.local = new ClassGoods(GoodsDataM[i]);
                            form.ShowDialog();

                            ClassGoods j = form.ReturnValue();
                            if (j != null)
                            {
                                i = new ClassGoods().hasNameIndex(GoodsDataP, j.name); // Index to change
                                if (i == -1)
                                {
                                    GoodsDataP.Add(new ClassGoods(j));
                                    GoodsDataP.Sort(delegate (ClassGoods t1, ClassGoods t2)
                                    {
                                        return (t1.name.CompareTo(t2.name));
                                    });
                                    ProjectLB.Items.Clear();
                                    foreach (ClassGoods entry in GoodsDataP) { ProjectLB.Items.Add(entry.name); }
                                }
                                else
                                {
                                    GoodsDataP[i] = j;
                                    ProjectLB.Items.Clear();
                                    foreach (ClassGoods entry in GoodsDataP) { ProjectLB.Items.Add(entry.name); }
                                }

                            }

                        }

                        if (GoodsDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }

                        break;

                    case "Pop Needs":

                        if (ModLB.Items.Count == 0) { return; }

                        if (ModLB.SelectedIndex == -1) { modSelectedIndex = 0; ModLB.SelectedIndex = 0; } else { modSelectedIndex = ModLB.SelectedIndex; }


                        using (PopNeedsForm form = new PopNeedsForm())
                        {
                            int i;
                            i = new ClassPopNeeds().hasNameIndex(PopNeedsDataM, ModLB.Items[modSelectedIndex].ToString());
                            form.sizeOfVicky = PopNeedsDataV.Count;
                            form.GoodsList = new ClassGoods().MergeGoods(GoodsDataP, GoodsDataV);
                            form.PopNeedsList = new ClassPopNeeds().Merge(PopNeedsDataP, PopNeedsDataV);
                            form.local = new ClassPopNeeds(PopNeedsDataM[i]);
                            form.ShowDialog();
                            ClassPopNeeds j = form.ReturnValue();
                            if (j != null)
                            {
                                i = new ClassPopNeeds().hasNameIndex(PopNeedsDataP, j.name); // Index to change
                                if (i == -1)
                                {
                                    PopNeedsDataP.Add(new ClassPopNeeds(j));
                                    PopNeedsDataP.Sort(delegate (ClassPopNeeds t1, ClassPopNeeds t2)
                                    {
                                        return (t1.name.CompareTo(t2.name));
                                    });
                                    ProjectLB.Items.Clear();
                                    foreach (ClassPopNeeds entry in PopNeedsDataP) { ProjectLB.Items.Add(entry.name); }
                                }
                                else
                                {
                                    PopNeedsDataP[i] = j;
                                    ProjectLB.Items.Clear();
                                    foreach (ClassPopNeeds entry in PopNeedsDataP) { ProjectLB.Items.Add(entry.name); }
                                }

                            }

                        }

                        if (PopNeedsDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }


                        break;

                    case "Technology":

                        if (ModLB.Items.Count == 0) { return; }

                        if (ModLB.SelectedIndex == -1) { modSelectedIndex = 0; ModLB.SelectedIndex = 0; } else { modSelectedIndex = ModLB.SelectedIndex; }


                        using (TechForm form = new TechForm())
                        {
                            int i;
                            i = new ClassTech().hasNameIndex(TechDataM, ModLB.Items[modSelectedIndex].ToString());
                            form.sizeOfVicky = TechDataV.Count;
                            form.TechList = new ClassTech().MergeTech(TechDataP, TechDataV);
                            form.EraList = new ClassEra().MergeEra(EraDataP, EraDataV);
                            form.local = new ClassTech(TechDataM[i]);
                            form.ShowDialog();
                            ClassTech j = form.ReturnValue();
                            if (j != null)
                            {
                                i = new ClassTech().hasNameIndex(TechDataP, j.name); // Index to change
                                if (i == -1)
                                {
                                    TechDataP.Add(new ClassTech(j));
                                    TechDataP.Sort(delegate (ClassTech t1, ClassTech t2)
                                    {
                                        return (t1.name.CompareTo(t2.name));
                                    });
                                    ProjectLB.Items.Clear();
                                    foreach (ClassTech entry in TechDataP) { ProjectLB.Items.Add(entry.name); }
                                }
                                else
                                {
                                    TechDataP[i] = j;
                                    ProjectLB.Items.Clear();
                                    foreach (ClassTech entry in TechDataP) { ProjectLB.Items.Add(entry.name); }
                                }

                            }

                        }

                        if (TechDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }


                        break;

                    case "Decisions":


                        break;




                    default:
                        MainLB.Items.Add("Error");
                        break;
                }
            }
        }


        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Button Click *
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void AddModBT_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog FBD = new FolderBrowserDialog())
            {

                if (FBD.ShowDialog() == DialogResult.OK)
                {
                    ModPath = FBD.SelectedPath;  //selected folder path
                    if (mainSelectedIndex!=-1){Mod();}
                    XL.Visible = false;
                }
                else
                {
                    XL.Visible = true;
                }
            }
        }

        // *
        private void AddBT_Click(object sender, EventArgs e)
        {
            SaveStatus = 2;
            switch (MainData[mainSelectedIndex].ToString())
            {

                case "Era":

                    using (EraForm form = new EraForm())
                    {
                        int i;
                        form.local = null;
                        form.ShowDialog();
                        ClassEra j = form.ReturnValue();
                        if (j != null)
                        {

                            i = new ClassEra().FindEraValue(EraDataP, j.Era); // Index to change
                            if (i == -1)
                            {
                                EraDataP.Add(new ClassEra(j.Era, j.Cost));
                                EraDataP.Sort(delegate (ClassEra t1, ClassEra t2)
                                {
                                    return (t1.Era.CompareTo(t2.Era));
                                });
                                ProjectLB.Items.Clear();
                                ProjectLB.Items.Add(String.Format("{0,-20}{1,-20 }", "Era", "Cost"));
                                foreach (ClassEra eraEntry in EraDataP) { ProjectLB.Items.Add(String.Format("{0,-20}{1,-20 }", eraEntry.Era, eraEntry.Cost)); }
                            }
                            else
                            {
                                EraDataP[i].Cost = j.Cost;
                                ProjectLB.Items.Clear();
                                ProjectLB.Items.Add(String.Format("{0,-20}{1,-20 }", "Era", "Cost"));
                                foreach (ClassEra eraEntry in EraDataP) { ProjectLB.Items.Add(String.Format("{0,-20}{1,-20 }", eraEntry.Era, eraEntry.Cost)); }
                            }
                        }
                    }

                    if (EraDataP.Count == 0) { DeleteBT.Enabled = false; }
                    else { DeleteBT.Enabled = true; }


                    break;

                case "Goods":

                    using (GoodsForm form = new GoodsForm())
                    {
                        int i;

                        form.sizeOfVicky = GoodsDataV.Count;
                        form.GoodsData = new ClassGoods().MergeGoods(GoodsDataP, GoodsDataV);
                        form.local = null;
                        form.ShowDialog();

                        ClassGoods j = form.ReturnValue();
                        if (j != null)
                        {
                            i = new ClassGoods().hasNameIndex(GoodsDataP, j.name); // Index to change
                            if (i == -1)
                            {
                                GoodsDataP.Add(new ClassGoods(j));
                                GoodsDataP.Sort(delegate (ClassGoods t1, ClassGoods t2)
                                {
                                    return (t1.name.CompareTo(t2.name));
                                });
                                ProjectLB.Items.Clear();
                                foreach (ClassGoods entry in GoodsDataP) { ProjectLB.Items.Add(entry.name); }
                            }
                            else
                            {
                                GoodsDataP[i] = j;
                                ProjectLB.Items.Clear();
                                foreach (ClassGoods entry in GoodsDataP) { ProjectLB.Items.Add(entry.name); }
                            }

                        }




                    }

                    if (GoodsDataP.Count == 0) { DeleteBT.Enabled = false; }
                    else { DeleteBT.Enabled = true; }


                    break;

                case "Pop Needs":

                    using (PopNeedsForm form = new PopNeedsForm())
                    {
                        int i;
                        form.sizeOfVicky = PopNeedsDataV.Count;
                        form.GoodsList = new ClassGoods().MergeGoods(GoodsDataP, GoodsDataV);
                        form.PopNeedsList = new ClassPopNeeds().Merge(PopNeedsDataP, PopNeedsDataV);
                        form.local = null;
                        form.ShowDialog();
                        ClassPopNeeds j = form.ReturnValue();
                        if (j != null)
                        {
                            i = new ClassPopNeeds().hasNameIndex(PopNeedsDataP, j.name); // Index to change
                            if (i == -1)
                            {
                                PopNeedsDataP.Add(new ClassPopNeeds(j));
                                PopNeedsDataP.Sort(delegate (ClassPopNeeds t1, ClassPopNeeds t2)
                                {
                                    return (t1.name.CompareTo(t2.name));
                                });
                                ProjectLB.Items.Clear();
                                foreach (ClassPopNeeds entry in PopNeedsDataP) { ProjectLB.Items.Add(entry.name); }
                            }
                            else
                            {
                                PopNeedsDataP[i] = j;
                                ProjectLB.Items.Clear();
                                foreach (ClassPopNeeds entry in PopNeedsDataP) { ProjectLB.Items.Add(entry.name); }
                            }

                        }

                    }

                    if (PopNeedsDataP.Count == 0) { DeleteBT.Enabled = false; }
                    else { DeleteBT.Enabled = true; }

                    break;


                case "Technology":

                    using (TechForm form = new TechForm())
                    {
                        int i;
                        form.sizeOfVicky = TechDataV.Count;
                        form.TechList = new ClassTech().MergeTech(TechDataP, TechDataV);
                        form.EraList = new ClassEra().MergeEra(EraDataP, EraDataV);
                        form.local = null;
                        form.ShowDialog();
                        ClassTech j = form.ReturnValue();
                        if (j != null)
                        {
                            i = new ClassTech().hasNameIndex(TechDataP, j.name); // Index to change
                            if (i == -1)
                            {
                                TechDataP.Add(new ClassTech(j));
                                TechDataP.Sort(delegate (ClassTech t1, ClassTech t2)
                                {
                                    return (t1.name.CompareTo(t2.name));
                                });
                                ProjectLB.Items.Clear();
                                foreach (ClassTech entry in TechDataP) { ProjectLB.Items.Add(entry.name); }
                            }
                            else
                            {
                                TechDataP[i] = j;
                                ProjectLB.Items.Clear();
                                foreach (ClassTech entry in TechDataP) { ProjectLB.Items.Add(entry.name); }
                            }

                        }

                    }

                    if (TechDataP.Count == 0) { DeleteBT.Enabled = false; }
                    else { DeleteBT.Enabled = true; }

                    break;




                default:
                    MainLB.Items.Add("Error");
                    break;
            }
        }

        private void SaveBT_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.ClassMessageBox.ShowOverwrite();
            if (result == DialogResult.OK)
            {
                MakeProjFiles();
                SaveStatus = 1;
            }
            else if (result == DialogResult.Cancel)
            {

            }

        }

        // *
        private void DeleteBT_Click(object sender, EventArgs e)
        {

            int i;
            SaveStatus = 2;

            switch (MainData[mainSelectedIndex].ToString())
            {

                case "Era":

                    if (ProjectLB.SelectedIndex == 0) { return; }

                    if (ProjectLB.SelectedIndex == -1) { projSelectedIndex = 1; ProjectLB.SelectedIndex = 1; } else { projSelectedIndex = ProjectLB.SelectedIndex; }

                    i = new ClassEra().FindEraValue(EraDataP, Int32.Parse(ProjectLB.Items[projSelectedIndex].ToString().Substring(0, 20)));
                    EraDataP.RemoveAt(i);
                    ProjectLB.Items.Clear();
                    ProjectLB.Items.Add(String.Format("{0,-20}{1,-20 }", "Era", "Cost"));
                    foreach (ClassEra eraEntry in EraDataP) { ProjectLB.Items.Add(String.Format("{0,-20}{1,-20 }", eraEntry.Era, eraEntry.Cost)); }

                    if (EraDataP.Count == 0) { DeleteBT.Enabled = false; }
                    else { DeleteBT.Enabled = true; }

                    break;

                case "Goods":

                    if (ProjectLB.SelectedIndex == -1) { projSelectedIndex = 0; ProjectLB.SelectedIndex = 0; } else { projSelectedIndex = ProjectLB.SelectedIndex; }

                    i = new ClassGoods().hasNameIndex(GoodsDataP, ProjectLB.Items[projSelectedIndex].ToString());
                    GoodsDataP.RemoveAt(i);
                    ProjectLB.Items.Clear();
                    foreach (ClassGoods entry in GoodsDataP) { ProjectLB.Items.Add(entry.name); }

                    if (GoodsDataP.Count == 0) { DeleteBT.Enabled = false; }
                    else { DeleteBT.Enabled = true; }


                    break;

                case "Pop Needs":

                    if (ProjectLB.SelectedIndex == -1) { projSelectedIndex = 0; ProjectLB.SelectedIndex = 0; } else { projSelectedIndex = ProjectLB.SelectedIndex; }

                    i = new ClassPopNeeds().hasNameIndex(PopNeedsDataP, ProjectLB.Items[projSelectedIndex].ToString());
                    PopNeedsDataP.RemoveAt(i);
                    ProjectLB.Items.Clear();
                    foreach (ClassPopNeeds entry in PopNeedsDataP) { ProjectLB.Items.Add(entry.name); }

                    if (PopNeedsDataP.Count == 0) { DeleteBT.Enabled = false; }
                    else { DeleteBT.Enabled = true; }


                    break;

                case "Technology":

                    if (ProjectLB.SelectedIndex == -1) { projSelectedIndex = 0; ProjectLB.SelectedIndex = 0; } else { projSelectedIndex = ProjectLB.SelectedIndex; }

                    i = new ClassTech().hasNameIndex(TechDataP, ProjectLB.Items[projSelectedIndex].ToString());
                    TechDataP.RemoveAt(i);
                    ProjectLB.Items.Clear();
                    foreach (ClassTech entry in TechDataP) { ProjectLB.Items.Add(entry.name); }

                    if (TechDataP.Count == 0) { DeleteBT.Enabled = false; }
                    else { DeleteBT.Enabled = true; }


                    break;

                case "Decisions":



                default:
                    MainLB.Items.Add("Error");
                    break;
            }

        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // LB Search Bar *
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        //*
        private void LoadMainLB()
        {
            MainData.Add("Era");
            MainData.Add("Goods");
            MainData.Add("Pop Needs");
            MainData.Add("Technology");


            MainLB.Items.Add("Era");
            MainLB.Items.Add("Goods");
            MainLB.Items.Add("Pop Needs");
            MainLB.Items.Add("Technology");

        }

        private void MainSearchBarTB_CustomTextBox_TextChanged(object sender, EventArgs e)
        {

            if (mainSelectedIndex == -1) { return; }

            if (string.IsNullOrEmpty(MainSearchBarTB.Texts) == false)
            {
                MainLB.Items.Clear();
                foreach (string entry in MainData)
                {
                    if (entry.StartsWith(MainSearchBarTB.Texts))
                    {
                        MainLB.Items.Add(entry);
                    }

                }

            }
            else if (MainSearchBarTB.Texts == "")
            {
                MainLB.Items.Clear();
                foreach (string entry in MainData)
                {
                    MainLB.Items.Add(entry);
                }
            }
        }

        // *
        private void VickySearchBarTB_CustomTextBox_TextChanged(object sender, EventArgs e)
        {

            if (mainSelectedIndex == -1) { return; }

            switch (MainData[mainSelectedIndex].ToString())
            {

                case "Era":

                    if (string.IsNullOrEmpty(VickySearchBarTB.Texts) == false)
                    {
                        VickyLB.Items.Clear();
                        VickyLB.Items.Add(String.Format("{0,-20}{1,-20 }", "Era", "Cost"));

                        foreach (ClassEra entry in EraDataV)
                        {
                            if (entry.Era.ToString().StartsWith(VickySearchBarTB.Texts))
                            { VickyLB.Items.Add(String.Format("{0,-20}{1,-20 }", entry.Era, entry.Cost)); }

                        }

                    }
                    else if (VickySearchBarTB.Texts == "")
                    {
                        VickyLB.Items.Clear();
                        VickyLB.Items.Add(String.Format("{0,-20}{1,-20 }", "Era", "Cost"));

                        foreach (ClassEra entry in EraDataV)
                        {
                            if (entry.Era.ToString().StartsWith(VickySearchBarTB.Texts))
                            { VickyLB.Items.Add(String.Format("{0,-20}{1,-20 }", entry.Era, entry.Cost)); }
                        }
                    }


                    break;

                case "Goods":

                    if (string.IsNullOrEmpty(VickySearchBarTB.Texts) == false)
                    {
                        VickyLB.Items.Clear();
                        foreach (ClassGoods str in GoodsDataV)
                        {
                            if (str.name.StartsWith(VickySearchBarTB.Texts))
                            {
                                VickyLB.Items.Add(str.name);
                            }

                        }

                    }
                    else if (VickySearchBarTB.Texts == "")
                    {
                        VickyLB.Items.Clear();
                        foreach (ClassGoods str in GoodsDataV)
                        {
                            VickyLB.Items.Add(str.name);
                        }
                    }

                    break;

                case "Pop Needs":

                    if (string.IsNullOrEmpty(VickySearchBarTB.Texts) == false)
                    {
                        VickyLB.Items.Clear();
                        foreach (ClassPopNeeds str in PopNeedsDataV)
                        {
                            if (str.name.StartsWith(VickySearchBarTB.Texts))
                            {
                                VickyLB.Items.Add(str.name);
                            }

                        }

                    }
                    else if (VickySearchBarTB.Texts == "")
                    {
                        VickyLB.Items.Clear();
                        foreach (ClassPopNeeds str in PopNeedsDataV)
                        {
                            VickyLB.Items.Add(str.name);
                        }
                    }

                    break;


                case "Technology":

                    if (string.IsNullOrEmpty(VickySearchBarTB.Texts) == false)
                    {
                        VickyLB.Items.Clear();
                        foreach (ClassTech str in TechDataV)
                        {
                            if (str.name.StartsWith(VickySearchBarTB.Texts))
                            {
                                VickyLB.Items.Add(str.name);
                            }

                        }

                    }
                    else if (VickySearchBarTB.Texts == "")
                    {
                        VickyLB.Items.Clear();
                        foreach (ClassTech str in TechDataV)
                        {
                            VickyLB.Items.Add(str.name);
                        }
                    }

                    break;

                case "Decisions":


                    break;



                default:
                    MainLB.Items.Add("Error");
                    break;
            }


        }

        // *
        private void ProjSearchBarTB_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            if (mainSelectedIndex == -1) { return; }

            switch (MainData[mainSelectedIndex].ToString())
            {

                case "Era":

                    if (string.IsNullOrEmpty(ProjSearchBarTB.Texts) == false)
                    {
                        ProjectLB.Items.Clear();
                        ProjectLB.Items.Add(String.Format("{0,-20}{1,-20 }", "Era", "Cost"));

                        foreach (ClassEra entry in EraDataP)
                        {
                            if (entry.Era.ToString().StartsWith(ProjSearchBarTB.Texts))
                            { ProjectLB.Items.Add(String.Format("{0,-20}{1,-20 }", entry.Era, entry.Cost)); }

                        }

                    }
                    else if (ProjSearchBarTB.Texts == "")
                    {
                        ProjectLB.Items.Clear();
                        ProjectLB.Items.Add(String.Format("{0,-20}{1,-20 }", "Era", "Cost"));

                        foreach (ClassEra entry in EraDataP)
                        {
                            if (entry.Era.ToString().StartsWith(ProjSearchBarTB.Texts))
                            { ProjectLB.Items.Add(String.Format("{0,-20}{1,-20 }", entry.Era, entry.Cost)); }
                        }
                    }


                    break;

                case "Goods":

                    if (string.IsNullOrEmpty(ProjSearchBarTB.Texts) == false)
                    {
                        ProjectLB.Items.Clear();
                        foreach (ClassGoods str in GoodsDataP)
                        {
                            if (str.name.StartsWith(ProjSearchBarTB.Texts))
                            {
                                ProjectLB.Items.Add(str.name);
                            }

                        }

                    }
                    else if (ProjSearchBarTB.Texts == "")
                    {
                        ProjectLB.Items.Clear();
                        foreach (ClassGoods str in GoodsDataP)
                        {
                            ProjectLB.Items.Add(str.name);
                        }
                    }

                    break;

                case "Pop Needs":

                    if (string.IsNullOrEmpty(ProjSearchBarTB.Texts) == false)
                    {
                        ProjectLB.Items.Clear();
                        foreach (ClassPopNeeds str in PopNeedsDataP)
                        {
                            if (str.name.StartsWith(ProjSearchBarTB.Texts))
                            {
                                ProjectLB.Items.Add(str.name);
                            }

                        }

                    }
                    else if (ProjSearchBarTB.Texts == "")
                    {
                        ProjectLB.Items.Clear();
                        foreach (ClassPopNeeds str in PopNeedsDataP)
                        {
                            ProjectLB.Items.Add(str.name);
                        }
                    }

                    break;


                case "Technology":

                    if (string.IsNullOrEmpty(ProjSearchBarTB.Texts) == false)
                    {
                        ProjectLB.Items.Clear();
                        foreach (ClassTech str in TechDataP)
                        {
                            if (str.name.StartsWith(ProjSearchBarTB.Texts))
                            {
                                ProjectLB.Items.Add(str.name);
                            }

                        }

                    }
                    else if (ProjSearchBarTB.Texts == "")
                    {
                        ProjectLB.Items.Clear();
                        foreach (ClassTech str in TechDataP)
                        {
                            ProjectLB.Items.Add(str.name);
                        }
                    }

                    break;

                case "Decisions":


                    break;



                default:
                    MainLB.Items.Add("Error");
                    break;
            }
        }

        // *
        private void ModSearchBarTB_CustomTextBox_TextChanged(object sender, EventArgs e)
        {

            if (mainSelectedIndex == -1) { return; }

            switch (MainData[mainSelectedIndex].ToString())
            {

                case "Era":

                    if (string.IsNullOrEmpty(ModSearchBarTB.Texts) == false)
                    {
                        ModLB.Items.Clear();
                        ModLB.Items.Add(String.Format("{0,-20}{1,-20 }", "Era", "Cost"));

                        foreach (ClassEra entry in EraDataM)
                        {
                            if (entry.Era.ToString().StartsWith(ModSearchBarTB.Texts))
                            { ModLB.Items.Add(String.Format("{0,-20}{1,-20 }", entry.Era, entry.Cost)); }

                        }

                    }
                    else if (ModSearchBarTB.Texts == "")
                    {
                        ModLB.Items.Clear();
                        ModLB.Items.Add(String.Format("{0,-20}{1,-20 }", "Era", "Cost"));

                        foreach (ClassEra entry in EraDataM)
                        {
                            if (entry.Era.ToString().StartsWith(ModSearchBarTB.Texts))
                            { ModLB.Items.Add(String.Format("{0,-20}{1,-20 }", entry.Era, entry.Cost)); }
                        }
                    }


                    break;

                case "Goods":

                    if (string.IsNullOrEmpty(ModSearchBarTB.Texts) == false)
                    {
                        ModLB.Items.Clear();
                        foreach (ClassGoods str in GoodsDataM)
                        {
                            if (str.name.StartsWith(ModSearchBarTB.Texts))
                            {
                                ModLB.Items.Add(str.name);
                            }

                        }

                    }
                    else if (ModSearchBarTB.Texts == "")
                    {
                        ModLB.Items.Clear();
                        foreach (ClassGoods str in GoodsDataM)
                        {
                            ModLB.Items.Add(str.name);
                        }
                    }

                    break;

                case "PopNeeds":

                    if (string.IsNullOrEmpty(ModSearchBarTB.Texts) == false)
                    {
                        ModLB.Items.Clear();
                        foreach (ClassPopNeeds str in PopNeedsDataM)
                        {
                            if (str.name.StartsWith(ModSearchBarTB.Texts))
                            {
                                ModLB.Items.Add(str.name);
                            }

                        }

                    }
                    else if (ModSearchBarTB.Texts == "")
                    {
                        ModLB.Items.Clear();
                        foreach (ClassPopNeeds str in PopNeedsDataM)
                        {
                            ModLB.Items.Add(str.name);
                        }
                    }

                    break;


                case "Technology":

                    if (string.IsNullOrEmpty(ModSearchBarTB.Texts) == false)
                    {
                        ModLB.Items.Clear();
                        foreach (ClassTech str in TechDataM)
                        {
                            if (str.name.StartsWith(ModSearchBarTB.Texts))
                            {
                                ModLB.Items.Add(str.name);
                            }

                        }

                    }
                    else if (ModSearchBarTB.Texts == "")
                    {
                        ModLB.Items.Clear();
                        foreach (ClassTech str in TechDataM)
                        {
                            ModLB.Items.Add(str.name);
                        }
                    }

                    break;

                case "Decisions":


                    break;



                default:
                    MainLB.Items.Add("Error");
                    break;
            }
        }


        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Tech / Era
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void LoadEraData(string path, List<ClassEra> EraData)
        {

            if (Directory.Exists(path))
            {

                foreach (List<KeyValuePair<string, object>> Techs in new Parser().ParseFiles(path)) // Files
                {
                    foreach (KeyValuePair<string, object> techEntry in Techs) // Individual Tech  Pair (Name,Dic)
                    {
                        foreach (KeyValuePair<string, object> element in (List<KeyValuePair<string, object>>)techEntry.Value)
                        {
                            EraData.Add(new ClassEra(Int32.Parse(techEntry.Key.ToString().Substring(4)), Convert.ToInt32(element.Value)));
                        }
                    }
                }

            }

        }

        private void LoadTechData(string path, List<ClassTech> TechData)
        {

            if (Directory.Exists(path))
            {

                foreach (List<KeyValuePair<string, object>> Techs in new Parser().ParseFiles(path)) // Files
                {
                    foreach (KeyValuePair<string, object> techEntry in Techs) // Individual Tech  Pair (Name,Dic)
                    {
                        TechData.Add(new ClassTech(techEntry));
                    }
                }
            }

        }

        private void OpenPathDescripTech(string path, List<ClassTech> TechData)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            int i = 0;

            foreach (ClassTech techEntry in TechData)
            {
                dic.Add(techEntry.name, i);
                i++;
            }

            if (File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    bool b = false;

                    string ln;
                    string[] words;
                    void NextLine() { ln = sr.ReadLine(); }
                    NextLine();
                    NextLine();

                    while (ln != null)
                    {
                        b = false;

                        if ((i = ln.IndexOf("#")) == -1)
                        {
                        }
                        else if (i < 7)
                        {
                            NextLine();
                            continue;
                        }
                        else { ln = ln.Substring(0, i); }


                        if (ln.Contains(":"))
                        {
                            words = ln.Split(':');
                            words[0] = words[0].Trim(' ');

                            if (dic.ContainsKey(words[0]))
                            {
                                i = dic[words[0]];
                                b = true;
                                TechData[i].TrueName = words[1].Substring(3, words[1].Length - 4);
                                NextLine();
                                words = ln.Split(':');
                                words[0] = words[0].Trim(' ');
                                if (words[0] == TechData[i].name + "_desc" && !words[0].Contains("#"))
                                {
                                    TechData[i].Desc = words[1].Substring(3, words[1].Length - 4);
                                    NextLine();
                                }
                            }
                            else if (dic.ContainsKey(words[0].Substring(0, words[0].Length - 6)))
                            {
                                b = true;
                                TechData[dic[words[0].Substring(0, words[0].Length - 6)]].Desc = words[1].Substring(3, words[1].Length - 4);
                                NextLine();
                            }

                            if (b == false)
                            {
                                NextLine();
                            }


                        }
                        else { NextLine(); }

                    }
                }
            }
        }

        private void EraTech(string path, List<ClassEra> EraData, List<ClassTech> TechData, string localization_name)
        {
            LoadEraData(path + "\\common\\technology\\eras", EraData);

            LoadTechData(path + "\\common\\technology\\technologies", TechData);

            TechData.Sort(delegate (ClassTech t1, ClassTech t2)
            {   // 0.5 s Make more efi
                return (t1.name.CompareTo(t2.name));
            });

            OpenPathDescripTech(path + "\\localization\\" + language + localization_name, TechData);


            return;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Goods / Pop Needs
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void OpenPathDescripGoods(string path, List<ClassGoods> GoodsData)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            int i = 0;

            foreach (ClassGoods goodsEntry in GoodsData)
            {
                dic.Add(goodsEntry.name, i);
                i++;
            }

            if (File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {

                    string ln;
                    string[] words;
                    void NextLine() { ln = sr.ReadLine(); }
                    NextLine();
                    NextLine();

                    while (ln != null)
                    {

                        if ((i = ln.IndexOf("#")) == -1)
                        {
                        }
                        else if (i < 7)
                        {
                            NextLine();
                            continue;
                        }
                        else { ln = ln.Substring(0, i); }


                        if (ln.Contains(":"))
                        {
                            words = ln.Split(':');
                            words[0] = words[0].Trim(' ');

                            if (dic.ContainsKey(words[0]))
                            {
                                i = dic[words[0]];
                                GoodsData[i].TrueName = words[1].Substring(3, words[1].Length - 4);
                                NextLine();
                            }
                            else
                            {
                                NextLine();
                            }

                        }
                        else { NextLine(); }

                    }
                }
            }
        }

        private void goods(string path, List<ClassGoods> GoodsData, string localization_name)
        {

            if (Directory.Exists(path + "\\common\\goods"))
            {
                foreach (List<KeyValuePair<string, object>> Goods in new Parser().ParseFiles(path + "\\common\\goods")) // Files
                {
                    foreach (KeyValuePair<string, object> Entry in Goods) // Individual Tech  Pair (Name,Dic)
                    {
                        GoodsData.Add(new ClassGoods(Entry));
                    }
                }
            }

            GoodsData.Sort(delegate (ClassGoods t1, ClassGoods t2)
            {   // 0.5 s Make more efi
                return (t1.name.CompareTo(t2.name));
            });

            OpenPathDescripGoods(path + "\\localization\\" + language + localization_name, GoodsData);

            return;
        }

        private void popneeds(string path, List<ClassPopNeeds> PopNeedsData)
        {

            if (Directory.Exists(path + "\\common\\pop_needs"))
            {
                foreach (List<KeyValuePair<string, object>> PopNeeds in new Parser().ParseFiles(path + "\\common\\pop_needs")) // Files
                {
                    foreach (KeyValuePair<string, object> Entry in PopNeeds)
                    {
                        PopNeedsData.Add(new ClassPopNeeds(Entry));
                    }
                }
            }

            PopNeedsData.Sort(delegate (ClassPopNeeds t1, ClassPopNeeds t2)
            {   // 0.5 s Make more efi
                return (t1.name.CompareTo(t2.name));
            });

            return;
        }


        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Make Project *
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        // *
        private void MakeProjFiles()
        {
            // 1st
            // Common
            if (!Directory.Exists(ProjPath + "\\common"))
            {
                Directory.CreateDirectory(ProjPath + "\\common");
            }


            // 2nd
            // Makes technology
            if (TechDataP != null)
            {
                if (TechDataP.Count != 0)
                {
                    if (!Directory.Exists(ProjPath + "\\common\\technology"))
                    {
                        Directory.CreateDirectory(ProjPath + "\\common\\technology");
                    }

                    if (!Directory.Exists(ProjPath + "\\common\\technology\\technologies"))
                    {
                        Directory.CreateDirectory(ProjPath + "\\common\\technology\\technologies");
                    }

                    using (StreamWriter sw = new StreamWriter(File.Open(ProjPath + "\\common\\technology\\technologies\\" + ProjName.ToLower().Replace(" ", "_") + ".txt", FileMode.Create)))
                    {
                        foreach (ClassTech techEntry in TechDataP)
                        {
                            sw.WriteLine();
                            sw.WriteLine(techEntry.name + " = {");
                            sw.WriteLine("\tera = era_" + techEntry.era);
                            sw.WriteLine("\ttexture = \"" + techEntry.texture + "\"");
                            sw.WriteLine("\tcategory = " + techEntry.category);
                            if (techEntry.canResearch == false) { sw.WriteLine("\tcan_research = no"); }
                            if (techEntry.modifiers.Count != 0)
                            {
                                sw.WriteLine();
                                sw.WriteLine("\tmodifier = {");
                                foreach (string modifier in techEntry.modifiers)
                                {
                                    sw.WriteLine("\t\t" + modifier);
                                }
                                sw.WriteLine("\t}");
                            }
                            if (techEntry.restrictions.Count != 0)
                            {
                                sw.WriteLine();
                                sw.WriteLine("\tunlocking_technologies = {");
                                foreach (string restr in techEntry.restrictions)
                                {
                                    sw.WriteLine("\t\t" + restr);
                                }
                                sw.WriteLine("\t}");
                            }
                            sw.WriteLine("}");
                        }


                    }
                }
            }

            // 2nd
            // Makes era
            if (EraDataP != null)
            {

                if (EraDataP.Count != 0)
                {
                    if (!Directory.Exists(ProjPath + "\\common\\technology"))
                    {
                        Directory.CreateDirectory(ProjPath + "\\common\\technology");
                    }
                    if (!Directory.Exists(ProjPath + "\\common\\technology\\eras"))
                    {
                        Directory.CreateDirectory(ProjPath + "\\common\\technology\\eras");
                    }

                    using (StreamWriter sw = new StreamWriter(File.Open(ProjPath + "\\common\\technology\\eras\\" + ProjName.ToLower().Replace(" ", "_") + ".txt", FileMode.Create)))
                    {
                        foreach (ClassEra eraEntry in EraDataP)
                        {
                            sw.WriteLine();
                            sw.WriteLine("era_" + eraEntry.Era + " = {");
                            sw.WriteLine("\ttechnology_cost = " + eraEntry.Cost);
                            sw.WriteLine("}");
                        }


                    }

                }
            }

            // 2nd
            // Makes goods
            if (GoodsDataP != null)
            {
                if (GoodsDataP.Count != 0)
                {

                    if (!Directory.Exists(ProjPath + "\\common\\goods"))
                    {
                        Directory.CreateDirectory(ProjPath + "\\common\\goods");
                    }

                    using (StreamWriter sw = new StreamWriter(File.Open(ProjPath + "\\common\\goods\\" + ProjName.ToLower().Replace(" ", "_") + ".txt", FileMode.Create)))
                    {
                        foreach (ClassGoods Entry in GoodsDataP)
                        {
                            sw.WriteLine();
                            sw.WriteLine(Entry.name + " = {");
                            sw.WriteLine("\ttexture = \"" + Entry.texture + "\"");
                            sw.WriteLine("\tcost = " + Entry.cost);
                            sw.WriteLine("\tcategory = " + Entry.category);

                            if (Entry.tradeable == false) { sw.WriteLine("\ttradeable = no"); }

                            if (Entry.fixed_price == true) { sw.WriteLine("\tfixed_price = yes"); }

                            sw.WriteLine();

                            if (Entry.obsession != -1) { sw.WriteLine("\tobsession_chance = " + Entry.obsession.ToString().Replace(",", ".")); }

                            sw.WriteLine("\tprestige_factor = " + Entry.prestige.ToString().Replace(",", "."));

                            if (Entry.tradedQuantity != -1) { sw.WriteLine("\ttraded_quantity = " + Entry.tradedQuantity); }

                            if (Entry.convoy_cost != -1) { sw.WriteLine("\tconvoy_cost_multiplier = " +  Entry.convoy_cost.ToString().Replace(",",".")); }

                            if (Entry.consumption != -1) { sw.WriteLine("\tconsumption_tax_cost = " + Entry.consumption); }

                            sw.WriteLine("}");
                            sw.WriteLine();

                        }
                    }


                }
            }

            // 2nd
            // Makes pop needs
            if (PopNeedsDataP != null)
            {
                if (PopNeedsDataP.Count != 0)
                {

                    if (!Directory.Exists(ProjPath + "\\common\\pop_needs"))
                    {
                        Directory.CreateDirectory(ProjPath + "\\common\\pop_needs");
                    }

                    using (StreamWriter sw = new StreamWriter(File.Open(ProjPath + "\\common\\pop_needs\\" + ProjName.ToLower().Replace(" ", "_") + ".txt", FileMode.Create)))
                    {
                        foreach (ClassPopNeeds Entry in PopNeedsDataP)
                        {
                            sw.WriteLine();
                            sw.WriteLine(Entry.name + " = {");
                            sw.WriteLine("\tdefault = " + Entry.defaultgood);

                            foreach (ClassPopNeedsEntry entry in Entry.entries)
                            {
                                sw.WriteLine();
                                sw.WriteLine("\tentry = {");
                                sw.WriteLine("\t\tgoods = " + entry.goods);
                                sw.WriteLine();
                                sw.WriteLine("\t\tweight = " + entry.weight.ToString().Replace(",", "."));
                                sw.WriteLine("\t\tmax_weight = " + entry.maxWeight.ToString().Replace(",", "."));
                                sw.WriteLine("\t\tmin_weight = " + entry.minWeight.ToString().Replace(",", "."));
                                sw.WriteLine("\t}");
                                sw.WriteLine();
                            }

                            sw.WriteLine("}");
                            sw.WriteLine();

                        }
                    }


                }
            }
            

            //////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////

            // 1st
            // Makes Localization
            if (!Directory.Exists(ProjPath + "\\localization"))
            {
                Directory.CreateDirectory(ProjPath + "\\localization");
            }


            // 2nd
            // Makes Languages Tech
            if (TechDataP != null)
            {
                if (TechDataP.Count != 0)
                {

                    if (!Directory.Exists(ProjPath + "\\localization\\" + language))
                    {
                        Directory.CreateDirectory(ProjPath + "\\localization\\" + language);
                    }


                    using (StreamWriter sw = new StreamWriter(File.Open(ProjPath + "\\localization\\" + language + "\\" + ProjName.ToLower().Replace(" ", "_") + "_tech_l_english.yml", FileMode.Create), new UTF8Encoding(true)))
                    {
                        sw.WriteLine("l_english:");

                        foreach (ClassTech techEntry in TechDataP)
                        {

                            sw.WriteLine(" " + techEntry.name + ":0 \"" + techEntry.TrueName + "\"");
                            sw.WriteLine(" " + techEntry.name + "_desc:0 \"" + techEntry.Desc + "\"");

                        }
                    }
                }
            }

            if (GoodsDataP != null)
            {
                if (GoodsDataP.Count != 0)
                {
                    if (!Directory.Exists(ProjPath + "\\localization\\" + language))
                    {
                        Directory.CreateDirectory(ProjPath + "\\localization\\" + language);
                    }

                    using (StreamWriter sw = new StreamWriter(File.Open(ProjPath + "\\localization\\" + language + "\\" + ProjName.ToLower().Replace(" ", "_") + "_goods_l_english.yml", FileMode.Create), new UTF8Encoding(true)))
                    {
                        sw.WriteLine("l_english:");

                        foreach (ClassGoods Entry in GoodsDataP)
                        {

                            sw.WriteLine(" " + Entry.name + ":0 \"" + Entry.TrueName + "\"");

                        }
                    }
                }
            }



        }

        private void DeleteDirectory(string target_dir)
        {
            string[] files = Directory.GetFiles(target_dir);
            string[] dirs = Directory.GetDirectories(target_dir);

            foreach (string file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }

            foreach (string dir in dirs)
            {
                DeleteDirectory(dir);
            }

            Directory.Delete(target_dir, false);
        }

        
    }
}
