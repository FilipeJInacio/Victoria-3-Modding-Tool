using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Victoria_3_Modding_Tool.Forms.Era;
using Victoria_3_Modding_Tool.Forms.Tech;

namespace Victoria_3_Modding_Tool
{
    /*

    To do:

    dic same error

    form position

    Help

    CodeEditor ->make spellcheck, end custom colors, make autocomplete

    */

    // Questions
    // - What are the traits  religion/culture?
    // - Modifier -> color made?       modifiers_haitian
    // - Worth of items   (Pop Needs)
    // - Duplicate error
    // - Diference? color= rgb{ 62 77 100 }
    // - Culture German? in localization

    // Not working
    // - Modifiers/ ModifierTypes
    // - Pop_Needs -> localization
    // - Religion -> not working

    public partial class Main : Form
    {
        public int SaveStatus = 0;  // 0 -> just entered // 1 -> saved // 2 -> unsaved

        public string language;
        public string ProjName;
        public string VickyPath;
        public string ProjPath;
        public string ModPath;  // null -> no mod
        public string ModName;

        public Dictionary<string, string> LocalizationDataP;
        public Dictionary<string, string> LocalizationDataV;
        public Dictionary<string, string> LocalizationDataM;

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

        public List<ClassInstitutions> InstitutionsDataP;
        public List<ClassInstitutions> InstitutionsDataV;
        public List<ClassInstitutions> InstitutionsDataM;

        public List<ClassModifiers> ModifierDataP;
        public List<ClassModifiers> ModifierDataV;
        public List<ClassModifiers> ModifierDataM;

        public List<ClassModifiersType> ModifierTypeDataP;
        public List<ClassModifiersType> ModifierTypeDataV;
        public List<ClassModifiersType> ModifierTypeDataM;

        public List<ClassPopNeeds> PopNeedsDataP;
        public List<ClassPopNeeds> PopNeedsDataV;
        public List<ClassPopNeeds> PopNeedsDataM;

        public List<ClassReligions> ReligionsDataP;
        public List<ClassReligions> ReligionsDataV;
        public List<ClassReligions> ReligionsDataM;
        public List<string> TraitsData;

        public List<ClassStateTraits> StateTraitsDataP;
        public List<ClassStateTraits> StateTraitsDataV;
        public List<ClassStateTraits> StateTraitsDataM;

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

            XL.Location = new Point(rect.Width * 53 / 80 + 62 + AddModBT.Width / 2 - XL.Width, 230);
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

        private void Main_Load(object sender, EventArgs e)
        {
            LocalizationDataV = LocalizationSetup(VickyPath + "\\game");
            LocalizationDataP = LocalizationSetup(ProjPath);
            LocalizationDataM = LocalizationSetup(ModPath);
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
        private static extern void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

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
        // LB Search Bar *
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        //*
        private void LoadMainLB()
        {
            MainData.Add("Era");
            MainData.Add("Goods");
            MainData.Add("Institutions");
            MainData.Add("Modifiers");
            MainData.Add("Modifier Types");
            MainData.Add("Pop Needs");
            MainData.Add("Religions");
            MainData.Add("State Traits");
            MainData.Add("Technology");

            MainLB.Items.Add("Era");
            MainLB.Items.Add("Goods");
            MainLB.Items.Add("Institutions");
            MainLB.Items.Add("Modifiers");
            MainLB.Items.Add("Modifier Types");
            MainLB.Items.Add("Pop Needs");
            MainLB.Items.Add("Religions");
            MainLB.Items.Add("State Traits");
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

        //*
        private void VickySearchBarTB_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            SearchBarConfigs(VickySearchBarTB, VickyLB, EraDataV, GoodsDataV, InstitutionsDataV, ModifierDataV, ModifierTypeDataV, PopNeedsDataV, ReligionsDataV,  StateTraitsDataV, TechDataV);
        }

        //*
        private void ProjSearchBarTB_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            SearchBarConfigs(ProjSearchBarTB, ProjectLB, EraDataP, GoodsDataP, InstitutionsDataP, ModifierDataP, ModifierTypeDataP, PopNeedsDataP, ReligionsDataP, StateTraitsDataP, TechDataP);
        }

        //*
        private void ModSearchBarTB_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            SearchBarConfigs(ModSearchBarTB, ModLB, EraDataM, GoodsDataM, InstitutionsDataM, ModifierDataM, ModifierTypeDataM, PopNeedsDataM, ReligionsDataM, StateTraitsDataM, TechDataM);
        }

        // *
        private void SearchBarConfigs(CustomTextBox TB, ListBox LB, List<ClassEra> EraData, List<ClassGoods> GoodsData, List<ClassInstitutions> InstitutionData, List<ClassModifiers> ModifierData, List<ClassModifiersType> ModifierTypeData, List<ClassPopNeeds> PopNeedsData, List<ClassReligions> ReligionsData,List<ClassStateTraits> StateTraitsData, List<ClassTech> TechData)
        {
            if (mainSelectedIndex == -1) { return; }

            switch (MainData[mainSelectedIndex].ToString())
            {
                case "Era":

                    if (string.IsNullOrEmpty(TB.Texts) == false)
                    {
                        LB.Items.Clear();
                        LB.Items.Add(string.Format("{0,-20}{1,-20 }", "Era", "Cost"));

                        foreach (ClassEra entry in EraData)
                        {
                            if (entry.Era.ToString().StartsWith(TB.Texts))
                            { LB.Items.Add(string.Format("{0,-20}{1,-20 }", entry.Era, entry.Cost)); }
                        }
                    }
                    else if (TB.Texts == "")
                    {
                        LB.Items.Clear();
                        LB.Items.Add(string.Format("{0,-20}{1,-20 }", "Era", "Cost"));

                        foreach (ClassEra entry in EraData)
                        {
                            if (entry.Era.ToString().StartsWith(TB.Texts))
                            { LB.Items.Add(string.Format("{0,-20}{1,-20 }", entry.Era, entry.Cost)); }
                        }
                    }

                    break;

                case "Goods":

                    if (string.IsNullOrEmpty(TB.Texts) == false)
                    {
                        LB.Items.Clear();
                        foreach (ClassGoods str in GoodsData)
                        {
                            if (str.Name.StartsWith(TB.Texts))
                            {
                                LB.Items.Add(str.Name);
                            }
                        }
                    }
                    else if (TB.Texts == "")
                    {
                        LB.Items.Clear();
                        foreach (ClassGoods str in GoodsData)
                        {
                            LB.Items.Add(str.Name);
                        }
                    }

                    break;

                case "Institutions":

                    if (string.IsNullOrEmpty(TB.Texts) == false)
                    {
                        LB.Items.Clear();
                        foreach (ClassInstitutions str in InstitutionData)
                        {
                            if (str.Name.StartsWith(TB.Texts))
                            {
                                LB.Items.Add(str.Name);
                            }
                        }
                    }
                    else if (TB.Texts == "")
                    {
                        LB.Items.Clear();
                        foreach (ClassInstitutions str in InstitutionData)
                        {
                            LB.Items.Add(str.Name);
                        }
                    }

                    break;

                case "Modifiers":

                    if (string.IsNullOrEmpty(TB.Texts) == false)
                    {
                        LB.Items.Clear();
                        foreach (ClassModifiers str in ModifierData)
                        {
                            if (str.Name.StartsWith(TB.Texts))
                            {
                                LB.Items.Add(str.Name);
                            }
                        }
                    }
                    else if (TB.Texts == "")
                    {
                        LB.Items.Clear();
                        foreach (ClassModifiers str in ModifierData)
                        {
                            LB.Items.Add(str.Name);
                        }
                    }

                    break;

                case "Modifier Types":

                    if (string.IsNullOrEmpty(TB.Texts) == false)
                    {
                        LB.Items.Clear();
                        foreach (ClassModifiersType str in ModifierTypeData)
                        {
                            if (str.Name.StartsWith(TB.Texts))
                            {
                                LB.Items.Add(str.Name);
                            }
                        }
                    }
                    else if (TB.Texts == "")
                    {
                        LB.Items.Clear();
                        foreach (ClassModifiersType str in ModifierTypeData)
                        {
                            LB.Items.Add(str.Name);
                        }
                    }

                    break;

                case "Pop Needs":

                    if (string.IsNullOrEmpty(TB.Texts) == false)
                    {
                        LB.Items.Clear();
                        foreach (ClassPopNeeds str in PopNeedsData)
                        {
                            if (str.Name.StartsWith(TB.Texts))
                            {
                                LB.Items.Add(str.Name);
                            }
                        }
                    }
                    else if (TB.Texts == "")
                    {
                        LB.Items.Clear();
                        foreach (ClassPopNeeds str in PopNeedsData)
                        {
                            LB.Items.Add(str.Name);
                        }
                    }

                    break;

                case "Religions":

                    if (string.IsNullOrEmpty(TB.Texts) == false)
                    {
                        LB.Items.Clear();
                        foreach (ClassReligions str in ReligionsData)
                        {
                            if (str.Name.StartsWith(TB.Texts))
                            {
                                LB.Items.Add(str.Name);
                            }
                        }
                    }
                    else if (TB.Texts == "")
                    {
                        LB.Items.Clear();
                        foreach (ClassReligions str in ReligionsData)
                        {
                            LB.Items.Add(str.Name);
                        }
                    }

                    break;

                case "State Traits":

                    if (string.IsNullOrEmpty(TB.Texts) == false)
                    {
                        LB.Items.Clear();
                        foreach (ClassStateTraits str in StateTraitsData)
                        {
                            if (str.Name.StartsWith(TB.Texts))
                            {
                                LB.Items.Add(str.Name);
                            }
                        }
                    }
                    else if (TB.Texts == "")
                    {
                        LB.Items.Clear();
                        foreach (ClassStateTraits str in StateTraitsData)
                        {
                            LB.Items.Add(str.Name);
                        }
                    }

                    break;

                case "Technology":

                    if (string.IsNullOrEmpty(TB.Texts) == false)
                    {
                        LB.Items.Clear();
                        foreach (ClassTech str in TechData)
                        {
                            if (str.Name.StartsWith(TB.Texts))
                            {
                                LB.Items.Add(str.Name);
                            }
                        }
                    }
                    else if (TB.Texts == "")
                    {
                        LB.Items.Clear();
                        foreach (ClassTech str in TechData)
                        {
                            LB.Items.Add(str.Name);
                        }
                    }

                    break;

                default:
                    MainLB.Items.Add("Error");
                    break;
            }
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
                        ReadFilesCommon(ModPath + "\\common\\technology\\eras", EraDataM, new Parser(), s => new ClassEra(s), t => t.Era.ToString());
                        ModLB.Items.Add(string.Format("{0,-20}{1,-20 }", "Era", "Cost"));
                        foreach (ClassEra eraEntry in EraDataM) { ModLB.Items.Add(string.Format("{0,-20}{1,-20 }", eraEntry.Era, eraEntry.Cost)); }

                        break;

                    case "Goods":

                        GoodsDataM = new List<ClassGoods>();
                        ReadFilesCommon(ModPath + "\\common\\goods", GoodsDataM, new Parser(), s => new ClassGoods(s,
                            LocalizationDataM != null ? (LocalizationDataM.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty), t => t.Name);
                        foreach (ClassGoods entry in GoodsDataM) { ModLB.Items.Add(entry.Name); }

                        break;

                    case "Institutions":

                        InstitutionsDataM = new List<ClassInstitutions>();
                        ReadFilesCommon(ModPath + "\\common\\institutions", InstitutionsDataM, new Parser(), s => new ClassInstitutions(s,
                            LocalizationDataM != null ? (LocalizationDataM.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty), t => t.Name);
                        foreach (ClassInstitutions entry in InstitutionsDataM) { ModLB.Items.Add(entry.Name); }

                        break;

                    case "Modifiers":

                        ModifierDataM = new List<ClassModifiers>();
                        ReadFilesCommon(ModPath + "\\common\\modifiers", ModifierDataM, new Parser(), s => new ClassModifiers(s,
                            LocalizationDataM != null ? (LocalizationDataM.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty,
                            LocalizationDataM != null ? (LocalizationDataM.TryGetValue(s.Key + "_desc", out x) ? x : string.Empty) : string.Empty), t => t.Name);
                        foreach (ClassModifiers entry in ModifierDataM) { ModLB.Items.Add(entry.Name); }

                        break;

                    case "Modifier Types":

                        ModifierTypeDataM = new List<ClassModifiersType>();
                        ReadFilesCommon(ModPath + "\\common\\modifier_types", ModifierTypeDataM, new Parser(), s => new ClassModifiersType(s), t => t.Name);
                        foreach (ClassModifiersType entry in ModifierTypeDataM) { ModLB.Items.Add(entry.Name); }

                        break;

                    case "Pop Needs":

                        PopNeedsDataM = new List<ClassPopNeeds>();
                        ReadFilesCommon(ModPath + "\\common\\pop_needs", PopNeedsDataM, new Parser(), s => new ClassPopNeeds(s,
                            LocalizationDataM != null ? (LocalizationDataM.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty), t => t.Name);
                        foreach (ClassPopNeeds entry in PopNeedsDataM) { ModLB.Items.Add(entry.Name); }

                        break;

                    case "Religions":

                        ReligionsDataM = new List<ClassReligions>();
                        ReadFilesCommon(ModPath + "\\common\\religions", ReligionsDataM, new Parser(), s => new ClassReligions(s,
                            LocalizationDataM != null ? (LocalizationDataM.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty), t => t.Name);
                        foreach (ClassReligions entry in ReligionsDataM) { ModLB.Items.Add(entry.Name); }

                        break;

                    case "State Traits":

                        StateTraitsDataM = new List<ClassStateTraits>();
                        ReadFilesCommon(ModPath + "\\common\\state_traits", StateTraitsDataM, new Parser(), s => new ClassStateTraits(s,
                            LocalizationDataM != null ? (LocalizationDataM.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty), t => t.Name);
                        foreach (ClassStateTraits entry in StateTraitsDataM) { ModLB.Items.Add(entry.Name); }

                        break;

                    case "Technology":

                        TechDataM = new List<ClassTech>();
                        ReadFilesCommon(ModPath + "\\common\\technology\\technologies", TechDataM, new Parser(), s => new ClassTech(s,
                            LocalizationDataM != null ? (LocalizationDataM.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty,
                            LocalizationDataM != null ? (LocalizationDataM.TryGetValue(s.Key + "_desc", out x) ? x : string.Empty) : string.Empty), t => t.Name);
                        foreach (ClassTech entry in TechDataM) { ModLB.Items.Add(entry.Name); }

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
            SaveBT.Enabled = true;

            ClearClassData();

            VickyLB.Items.Clear();
            ProjectLB.Items.Clear();
            ModLB.Items.Clear();

            mainSelectedIndex = MainLB.SelectedIndex;

            switch (MainData[mainSelectedIndex].ToString())
            {
                case "Era":

                    EraDataP = new List<ClassEra>();
                    EraDataV = new List<ClassEra>();

                    ReadFilesCommon(VickyPath + "\\game\\common\\technology\\eras", EraDataV, new Parser(), s => new ClassEra(s), t => t.Era.ToString());
                    ReadFilesCommon(ProjPath + "\\common\\technology\\eras", EraDataP, new Parser(), s => new ClassEra(s), t => t.Era.ToString());

                    VickyLB.Items.Add(string.Format("{0,-20}{1,-20 }", "Era", "Cost"));
                    foreach (ClassEra eraEntry in EraDataV) { VickyLB.Items.Add(string.Format("{0,-20}{1,-20 }", eraEntry.Era, eraEntry.Cost)); }
                    ProjectLB.Items.Add(string.Format("{0,-20}{1,-20 }", "Era", "Cost"));
                    foreach (ClassEra eraEntry in EraDataP) { ProjectLB.Items.Add(string.Format("{0,-20}{1,-20 }", eraEntry.Era, eraEntry.Cost)); }

                    if (EraDataP.Count == 0) { DeleteBT.Enabled = false; }
                    else { DeleteBT.Enabled = true; }
                    Mod();

                    break;

                case "Institutions":
                    ModifierTypeDataP = new List<ClassModifiersType>();
                    ModifierTypeDataV = new List<ClassModifiersType>();

                    ReadFilesCommon(VickyPath + "\\game\\common\\modifier_types", ModifierTypeDataV, new Parser(), s => new ClassModifiersType(s), t => t.Name);
                    ReadFilesCommon(ProjPath + "\\common\\modifier_types", ModifierTypeDataP, new Parser(), s => new ClassModifiersType(s), t => t.Name);

                    InstitutionsDataP = new List<ClassInstitutions>();
                    InstitutionsDataV = new List<ClassInstitutions>();

                    ReadFilesCommon(VickyPath + "\\game\\common\\institutions", InstitutionsDataV, new Parser(), s => new ClassInstitutions(s,
                        LocalizationDataV != null ? (LocalizationDataV.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty), t => t.Name);
                    ReadFilesCommon(ProjPath + "\\common\\institutions", InstitutionsDataP, new Parser(), s => new ClassInstitutions(s,
                        LocalizationDataP != null ? (LocalizationDataP.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty), t => t.Name);

                    new Functions().TextureMerger(VickyPath + "\\game\\", InstitutionsDataV);
                    new Functions().TextureMerger(ProjPath + "\\", InstitutionsDataP);
                    new Functions().BackTextureMerger(VickyPath + "\\game\\", InstitutionsDataV);
                    new Functions().BackTextureMerger(ProjPath + "\\", InstitutionsDataP);

                    foreach (ClassInstitutions entry in InstitutionsDataV) { VickyLB.Items.Add(entry.Name); }
                    foreach (ClassInstitutions entry in InstitutionsDataP) { ProjectLB.Items.Add(entry.Name); }

                    if (InstitutionsDataP.Count == 0) { DeleteBT.Enabled = false; }
                    else { DeleteBT.Enabled = true; }
                    Mod();

                    break;

                case "Goods":
                    GoodsDataP = new List<ClassGoods>();
                    GoodsDataV = new List<ClassGoods>();

                    ReadFilesCommon(VickyPath + "\\game\\common\\goods", GoodsDataV, new Parser(), s => new ClassGoods(s,
                        LocalizationDataV != null ? (LocalizationDataV.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty), t => t.Name);
                    ReadFilesCommon(ProjPath + "\\common\\goods", GoodsDataP, new Parser(), s => new ClassGoods(s,
                        LocalizationDataP != null ? (LocalizationDataP.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty), t => t.Name);

                    new Functions().TextureMerger(VickyPath + "\\game\\", GoodsDataV);
                    new Functions().TextureMerger(ProjPath + "\\", GoodsDataP);

                    foreach (ClassGoods entry in GoodsDataV) { VickyLB.Items.Add(entry.Name); }
                    foreach (ClassGoods entry in GoodsDataP) { ProjectLB.Items.Add(entry.Name); }

                    if (GoodsDataP.Count == 0) { DeleteBT.Enabled = false; }
                    else { DeleteBT.Enabled = true; }
                    Mod();

                    break;

                case "Modifiers":
                    ModifierTypeDataP = new List<ClassModifiersType>();
                    ModifierTypeDataV = new List<ClassModifiersType>();

                    ReadFilesCommon(VickyPath + "\\game\\common\\modifier_types", ModifierTypeDataV, new Parser(), s => new ClassModifiersType(s), t => t.Name);
                    ReadFilesCommon(ProjPath + "\\common\\modifier_types", ModifierTypeDataP, new Parser(), s => new ClassModifiersType(s), t => t.Name);

                    ModifierDataP = new List<ClassModifiers>();
                    ModifierDataV = new List<ClassModifiers>();

                    ReadFilesCommon(VickyPath + "\\game\\common\\modifiers", ModifierDataV, new Parser(), s => new ClassModifiers(s,
                        LocalizationDataV != null ? (LocalizationDataV.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty,
                        LocalizationDataV != null ? (LocalizationDataV.TryGetValue(s.Key + "_desc", out x) ? x : string.Empty) : string.Empty), t => t.Name);
                    ReadFilesCommon(ProjPath + "\\common\\modifiers", ModifierDataP, new Parser(), s => new ClassModifiers(s,
                        LocalizationDataP != null ? (LocalizationDataP.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty,
                        LocalizationDataP != null ? (LocalizationDataP.TryGetValue(s.Key + "_desc", out x) ? x : string.Empty) : string.Empty), t => t.Name);

                    new Functions().TextureMerger(VickyPath + "\\game\\", ModifierDataV);
                    new Functions().TextureMerger(ProjPath + "\\", ModifierDataP);

                    foreach (ClassModifiers entry in ModifierDataV) { VickyLB.Items.Add(entry.Name); }
                    foreach (ClassModifiers entry in ModifierDataP) { ProjectLB.Items.Add(entry.Name); }

                    if (ModifierDataP.Count == 0) { DeleteBT.Enabled = false; }
                    else { DeleteBT.Enabled = true; }
                    Mod();

                    break;

                case "Modifier Types":
                    ModifierTypeDataP = new List<ClassModifiersType>();
                    ModifierTypeDataV = new List<ClassModifiersType>();

                    ReadFilesCommon(VickyPath + "\\game\\common\\modifier_types", ModifierTypeDataV, new Parser(), s => new ClassModifiersType(s), t => t.Name);
                    ReadFilesCommon(ProjPath + "\\common\\modifier_types", ModifierTypeDataP, new Parser(), s => new ClassModifiersType(s), t => t.Name);

                    //new ExtraFunctions().Modifi(ModifierTypeDataV);

                    foreach (ClassModifiersType entry in ModifierTypeDataV) { VickyLB.Items.Add(entry.Name); }
                    foreach (ClassModifiersType entry in ModifierTypeDataP) { ProjectLB.Items.Add(entry.Name); }

                    if (ModifierTypeDataP.Count == 0) { DeleteBT.Enabled = false; }
                    else { DeleteBT.Enabled = true; }
                    Mod();

                    break;

                case "Pop Needs":

                    GoodsDataP = new List<ClassGoods>();
                    GoodsDataV = new List<ClassGoods>();

                    ReadFilesCommon(VickyPath + "\\game\\common\\goods", GoodsDataV, new Parser(), s => new ClassGoods(s,
                        LocalizationDataV != null ? (LocalizationDataV.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty), t => t.Name);
                    ReadFilesCommon(ProjPath + "\\common\\goods", GoodsDataP, new Parser(), s => new ClassGoods(s,
                        LocalizationDataP != null ? (LocalizationDataP.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty), t => t.Name);

                    PopNeedsDataP = new List<ClassPopNeeds>();
                    PopNeedsDataV = new List<ClassPopNeeds>();

                    ReadFilesCommon(VickyPath + "\\game\\common\\pop_needs", PopNeedsDataV, new Parser(), s => new ClassPopNeeds(s,
                        LocalizationDataV != null ? (LocalizationDataV.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty), t => t.Name);
                    ReadFilesCommon(ProjPath + "\\common\\pop_needs", PopNeedsDataP, new Parser(), s => new ClassPopNeeds(s,
                        LocalizationDataP != null ? (LocalizationDataP.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty), t => t.Name);

                    foreach (ClassPopNeeds Entry in PopNeedsDataV) { VickyLB.Items.Add(Entry.Name); }
                    foreach (ClassPopNeeds Entry in PopNeedsDataP) { ProjectLB.Items.Add(Entry.Name); }

                    if (PopNeedsDataP.Count == 0) { DeleteBT.Enabled = false; }
                    else { DeleteBT.Enabled = true; }
                    Mod();

                    break;

                case "Religions":

                    GoodsDataP = new List<ClassGoods>();
                    GoodsDataV = new List<ClassGoods>();

                    ReadFilesCommon(VickyPath + "\\game\\common\\goods", GoodsDataV, new Parser(), s => new ClassGoods(s,
                        LocalizationDataV != null ? (LocalizationDataV.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty), t => t.Name);
                    ReadFilesCommon(ProjPath + "\\common\\goods", GoodsDataP, new Parser(), s => new ClassGoods(s,
                        LocalizationDataP != null ? (LocalizationDataP.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty), t => t.Name);

                    ReligionsDataP = new List<ClassReligions>();
                    ReligionsDataV = new List<ClassReligions>();

                    ReadFilesCommon(VickyPath + "\\game\\common\\religions", ReligionsDataV, new Parser(), s => new ClassReligions(s,
                        LocalizationDataV != null ? (LocalizationDataV.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty), t => t.Name);
                    ReadFilesCommon(ProjPath + "\\common\\religions", ReligionsDataP, new Parser(), s => new ClassReligions(s,
                        LocalizationDataP != null ? (LocalizationDataP.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty), t => t.Name);

                    new Functions().TextureMerger(VickyPath + "\\game\\", ReligionsDataV);
                    new Functions().TextureMerger(ProjPath + "\\", ReligionsDataP);

                    TraitsAdder(); // temp

                    foreach (ClassReligions Entry in ReligionsDataV) { VickyLB.Items.Add(Entry.Name); }
                    foreach (ClassReligions Entry in ReligionsDataP) { ProjectLB.Items.Add(Entry.Name); }

                    if (ReligionsDataP.Count == 0) { DeleteBT.Enabled = false; }
                    else { DeleteBT.Enabled = true; }
                    Mod();

                    break;

                case "State Traits":

                    TechDataP = new List<ClassTech>();
                    TechDataV = new List<ClassTech>();
                    ModifierTypeDataP = new List<ClassModifiersType>();
                    ModifierTypeDataV = new List<ClassModifiersType>();
                    StateTraitsDataP = new List<ClassStateTraits>();
                    StateTraitsDataV = new List<ClassStateTraits>();

                    ReadFilesCommon(VickyPath + "\\game\\common\\modifier_types", ModifierTypeDataV, new Parser(), s => new ClassModifiersType(s), t => t.Name);
                    ReadFilesCommon(ProjPath + "\\common\\modifier_types", ModifierTypeDataP, new Parser(), s => new ClassModifiersType(s), t => t.Name);

                    ReadFilesCommon(VickyPath + "\\game\\common\\technology\\technologies", TechDataV, new Parser(), s => new ClassTech(s,
                        LocalizationDataV != null ? (LocalizationDataV.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty,
                        LocalizationDataV != null ? (LocalizationDataV.TryGetValue(s.Key + "_desc", out x) ? x : string.Empty) : string.Empty), t => t.Name);
                    ReadFilesCommon(ProjPath + "\\common\\technology\\technologies", TechDataP, new Parser(), s => new ClassTech(s,
                        LocalizationDataP != null ? (LocalizationDataP.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty,
                        LocalizationDataP != null ? (LocalizationDataP.TryGetValue(s.Key + "_desc", out x) ? x : string.Empty) : string.Empty), t => t.Name);

                    ReadFilesCommon(VickyPath + "\\game\\common\\state_traits", StateTraitsDataV, new Parser(), s => new ClassStateTraits(s,
                        LocalizationDataV != null ? (LocalizationDataV.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty), t => t.Name);
                    ReadFilesCommon(ProjPath + "\\common\\state_traits", StateTraitsDataP, new Parser(), s => new ClassStateTraits(s,
                        LocalizationDataP != null ? (LocalizationDataP.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty), t => t.Name);

                    new Functions().TextureMerger(VickyPath + "\\game\\", StateTraitsDataV);
                    new Functions().TextureMerger(ProjPath + "\\", StateTraitsDataP);

                    foreach (ClassStateTraits entry in StateTraitsDataV) { VickyLB.Items.Add(entry.Name); }
                    foreach (ClassStateTraits entry in StateTraitsDataP) { ProjectLB.Items.Add(entry.Name); }

                    if (StateTraitsDataP.Count == 0) { DeleteBT.Enabled = false; }
                    else { DeleteBT.Enabled = true; }
                    Mod();

                    break;

                case "Technology":

                    TechDataP = new List<ClassTech>();
                    TechDataV = new List<ClassTech>();
                    EraDataP = new List<ClassEra>();
                    EraDataV = new List<ClassEra>();
                    ModifierTypeDataP = new List<ClassModifiersType>();
                    ModifierTypeDataV = new List<ClassModifiersType>();

                    ReadFilesCommon(VickyPath + "\\game\\common\\modifier_types", ModifierTypeDataV, new Parser(), s => new ClassModifiersType(s), t => t.Name);
                    ReadFilesCommon(ProjPath + "\\common\\modifier_types", ModifierTypeDataP, new Parser(), s => new ClassModifiersType(s), t => t.Name);

                    ReadFilesCommon(VickyPath + "\\game\\common\\technology\\eras", EraDataV, new Parser(), s => new ClassEra(s), t => t.Era.ToString());
                    ReadFilesCommon(ProjPath + "\\common\\technology\\eras", EraDataP, new Parser(), s => new ClassEra(s), t => t.Era.ToString());

                    ReadFilesCommon(VickyPath + "\\game\\common\\technology\\technologies", TechDataV, new Parser(), s => new ClassTech(s,
                        LocalizationDataV != null ? (LocalizationDataV.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty,
                        LocalizationDataV != null ? (LocalizationDataV.TryGetValue(s.Key + "_desc", out x) ? x : string.Empty) : string.Empty), t => t.Name);
                    ReadFilesCommon(ProjPath + "\\common\\technology\\technologies", TechDataP, new Parser(), s => new ClassTech(s,
                        LocalizationDataP != null ? (LocalizationDataP.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty,
                        LocalizationDataP != null ? (LocalizationDataP.TryGetValue(s.Key + "_desc", out x) ? x : string.Empty) : string.Empty), t => t.Name);

                    new Functions().TextureMerger(VickyPath + "\\game\\", TechDataV);
                    new Functions().TextureMerger(ProjPath + "\\", TechDataP);

                    foreach (ClassTech entry in TechDataV) { VickyLB.Items.Add(entry.Name); }
                    foreach (ClassTech entry in TechDataP) { ProjectLB.Items.Add(entry.Name); }

                    if (TechDataP.Count == 0) { DeleteBT.Enabled = false; }
                    else { DeleteBT.Enabled = true; }
                    Mod();

                    break;

                default:
                    MainLB.Items.Add("Error");
                    break;
            }
        }

        //*
        private void VickyLB_Click(object sender, EventArgs e)
        {
            DoubleClickList(VickyLB, VickyPath, vickySelectedIndex, EraDataV, GoodsDataV, InstitutionsDataV, ModifierDataV, ModifierTypeDataV, PopNeedsDataV, ReligionsDataV, StateTraitsDataV, TechDataV);
        }

        //*
        private void ProjectLB_Click(object sender, EventArgs e)
        {
            DoubleClickList(ProjectLB, ProjPath, projSelectedIndex, EraDataP, GoodsDataP, InstitutionsDataP, ModifierDataP, ModifierTypeDataP, PopNeedsDataP, ReligionsDataP, StateTraitsDataP, TechDataP);
        }

        //*
        private void ModLB_DoubleClick(object sender, EventArgs e)
        {
            DoubleClickList(ModLB, ModPath, modSelectedIndex, EraDataM, GoodsDataM, InstitutionsDataP, ModifierDataM, ModifierTypeDataM, PopNeedsDataM, ReligionsDataM, StateTraitsDataM, TechDataM);
        }

        //*
        private void DoubleClickList(ListBox ListBox, string path, int selectedIndex, List<ClassEra> EraData, List<ClassGoods> GoodsData, List<ClassInstitutions> InstitutionsData, List<ClassModifiers> ModifierData, List<ClassModifiersType> ModifierTypeData, List<ClassPopNeeds> PopNeedsData, List<ClassReligions> ReligionsData, List<ClassStateTraits> StateTraitsData, List<ClassTech> TechData)
        {
            if (mainSelectedIndex == -1) { return; }
            SaveStatus = 2;

            if (path != null)
            {
                switch (MainData[mainSelectedIndex].ToString())
                {
                    case "Era":

                        if (ListBox.SelectedIndex == 0) { return; }

                        if (ListBox.Items.Count == 1) { return; }

                        if (ListBox.SelectedIndex == -1) { selectedIndex = 1; ListBox.SelectedIndex = 1; } else { selectedIndex = ListBox.SelectedIndex; }

                        using (EraForm form = new EraForm())
                        {
                            int i;
                            i = new Functions().hasNameIndex(EraData,int.Parse( ListBox.Items[selectedIndex].ToString().Substring(0, 20)).ToString());
                            form.local = new ClassEra(EraData[i].Era, EraData[i].Cost);
                            form.ShowDialog();
                            ClassEra j = form.ReturnValue();
                            if (j != null)
                            {
                                i = new Functions().hasNameIndex(EraDataP, j.Era.ToString()); // Index to change
                                if (i == -1)
                                {
                                    EraDataP.Add(new ClassEra(j.Era, j.Cost));
                                    EraDataP.Sort(delegate (ClassEra t1, ClassEra t2)
                                    {
                                        return (t1.Era.CompareTo(t2.Era));
                                    });
                                    ProjectLB.Items.Clear();
                                    ProjectLB.Items.Add(string.Format("{0,-20}{1,-20 }", "Era", "Cost"));
                                    foreach (ClassEra eraEntry in EraDataP) { ProjectLB.Items.Add(string.Format("{0,-20}{1,-20 }", eraEntry.Era, eraEntry.Cost)); }
                                }
                                else
                                {
                                    EraDataP[i].Cost = j.Cost;
                                    ProjectLB.Items.Clear();
                                    ProjectLB.Items.Add(string.Format("{0,-20}{1,-20 }", "Era", "Cost"));
                                    foreach (ClassEra eraEntry in EraDataP) { ProjectLB.Items.Add(string.Format("{0,-20}{1,-20 }", eraEntry.Era, eraEntry.Cost)); }
                                }
                            }
                        }

                        if (EraDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }

                        break;

                    case "Goods":

                        if (ListBox.Items.Count == 0) { return; }

                        if (ListBox.SelectedIndex == -1) { selectedIndex = 0; ListBox.SelectedIndex = 0; } else { selectedIndex = ListBox.SelectedIndex; }

                        using (GoodsForm form = new GoodsForm())
                        {
                            int i;
                            i = new Functions().hasNameIndex(GoodsData, ListBox.Items[selectedIndex].ToString());

                            form.sizeOfVicky = GoodsDataV.Count;
                            form.GoodsData = new Functions().MergeClasses(GoodsDataP, GoodsDataV);
                            form.local = new ClassGoods(GoodsData[i]);
                            form.ShowDialog();

                            ClassGoods j = form.ReturnValue();
                            if (j != null)
                            {
                                i = new Functions().hasNameIndex(GoodsDataP, j.Name); // Index to change
                                if (i == -1)
                                {
                                    GoodsDataP.Add(new ClassGoods(j));
                                    GoodsDataP.Sort(delegate (ClassGoods t1, ClassGoods t2)
                                    {
                                        return (t1.Name.CompareTo(t2.Name));
                                    });
                                    ProjectLB.Items.Clear();
                                    foreach (ClassGoods entry in GoodsDataP) { ProjectLB.Items.Add(entry.Name); }
                                }
                                else
                                {
                                    GoodsDataP[i] = j;
                                    ProjectLB.Items.Clear();
                                    foreach (ClassGoods entry in GoodsDataP) { ProjectLB.Items.Add(entry.Name); }
                                }
                            }
                        }

                        if (GoodsDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }

                        break;

                    case "Institutions":

                        if (ListBox.Items.Count == 0) { return; }

                        if (ListBox.SelectedIndex == -1) { selectedIndex = 0; ListBox.SelectedIndex = 0; } else { selectedIndex = ListBox.SelectedIndex; }

                        using (InstitutionsForm form = new InstitutionsForm())
                        {
                            int i;
                            i = new Functions().hasNameIndex(InstitutionsData, ListBox.Items[selectedIndex].ToString());

                            form.sizeOfVicky = InstitutionsDataV.Count;
                            form.ModifiersTypes = new Functions().MergeClasses(ModifierTypeDataP, ModifierTypeDataV);
                            form.InstitutionsData = new Functions().MergeClasses(InstitutionsDataP, InstitutionsDataV);
                            form.local = new ClassInstitutions(InstitutionsData[i]);
                            form.ShowDialog();

                            ClassInstitutions j = form.ReturnValue();
                            if (j != null)
                            {
                                i = new Functions().hasNameIndex(InstitutionsDataP, j.Name); // Index to change
                                if (i == -1)
                                {
                                    InstitutionsDataP.Add(new ClassInstitutions(j));
                                    InstitutionsDataP.Sort(delegate (ClassInstitutions t1, ClassInstitutions t2)
                                    {
                                        return (t1.Name.CompareTo(t2.Name));
                                    });
                                    ProjectLB.Items.Clear();
                                    foreach (ClassInstitutions entry in InstitutionsDataP) { ProjectLB.Items.Add(entry.Name); }
                                }
                                else
                                {
                                    InstitutionsDataP[i] = j;
                                    ProjectLB.Items.Clear();
                                    foreach (ClassInstitutions entry in InstitutionsDataP) { ProjectLB.Items.Add(entry.Name); }
                                }
                            }
                        }

                        if (InstitutionsDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }

                        break;

                    case "Modifiers":

                        if (ListBox.Items.Count == 0) { return; }

                        if (ListBox.SelectedIndex == -1) { selectedIndex = 0; ListBox.SelectedIndex = 0; } else { selectedIndex = ListBox.SelectedIndex; }

                        using (ModifiersForm form = new ModifiersForm())
                        {
                            int i;
                            i = new Functions().hasNameIndex(ModifierData, ListBox.Items[selectedIndex].ToString());

                            form.sizeOfVicky = ModifierDataV.Count;
                            form.ModifiersTypes = new Functions().MergeClasses(ModifierTypeDataP, ModifierTypeDataV);
                            form.ModifiersData = new Functions().MergeClasses(ModifierDataP, ModifierDataV);
                            form.local = new ClassModifiers(ModifierData[i]);
                            form.ShowDialog();

                            ClassModifiers j = form.ReturnValue();
                            if (j != null)
                            {
                                i = new Functions().hasNameIndex(ModifierDataP, j.Name); // Index to change
                                if (i == -1)
                                {
                                    ModifierDataP.Add(new ClassModifiers(j));
                                    ModifierDataP.Sort(delegate (ClassModifiers t1, ClassModifiers t2)
                                    {
                                        return (t1.Name.CompareTo(t2.Name));
                                    });
                                    ProjectLB.Items.Clear();
                                    foreach (ClassModifiers entry in ModifierDataP) { ProjectLB.Items.Add(entry.Name); }
                                }
                                else
                                {
                                    ModifierDataP[i] = j;
                                    ProjectLB.Items.Clear();
                                    foreach (ClassModifiers entry in ModifierDataP) { ProjectLB.Items.Add(entry.Name); }
                                }
                            }
                        }

                        if (ModifierDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }

                        break;

                    case "Modifier Types":

                        if (ListBox.Items.Count == 0) { return; }

                        if (ListBox.SelectedIndex == -1) { selectedIndex = 0; ListBox.SelectedIndex = 0; } else { selectedIndex = ListBox.SelectedIndex; }

                        using (ModifiersTypesForm form = new ModifiersTypesForm())
                        {
                            int i;
                            i = new Functions().hasNameIndex(ModifierTypeData, ListBox.Items[selectedIndex].ToString());

                            form.sizeOfVicky = ModifierTypeDataV.Count;
                            form.ModifiersData = new Functions().MergeClasses(ModifierTypeDataP, ModifierTypeDataV);
                            form.local = new ClassModifiersType(ModifierTypeData[i]);
                            form.ShowDialog();

                            ClassModifiersType j = form.ReturnValue();
                            if (j != null)
                            {
                                i = new Functions().hasNameIndex(ModifierTypeDataP, j.Name); // Index to change
                                if (i == -1)
                                {
                                    ModifierTypeDataP.Add(new ClassModifiersType(j));
                                    ModifierTypeDataP.Sort(delegate (ClassModifiersType t1, ClassModifiersType t2)
                                    {
                                        return (t1.Name.CompareTo(t2.Name));
                                    });
                                    ProjectLB.Items.Clear();
                                    foreach (ClassModifiersType entry in ModifierTypeDataP) { ProjectLB.Items.Add(entry.Name); }
                                }
                                else
                                {
                                    ModifierTypeDataP[i] = j;
                                    ProjectLB.Items.Clear();
                                    foreach (ClassModifiersType entry in ModifierTypeDataP) { ProjectLB.Items.Add(entry.Name); }
                                }
                            }
                        }

                        if (ModifierTypeDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }

                        break;

                    case "Pop Needs":

                        if (ListBox.Items.Count == 0) { return; }

                        if (ListBox.SelectedIndex == -1) { selectedIndex = 0; ListBox.SelectedIndex = 0; } else { selectedIndex = ListBox.SelectedIndex; }

                        using (PopNeedsForm form = new PopNeedsForm())
                        {
                            int i;
                            i = new Functions().hasNameIndex(PopNeedsData, ListBox.Items[selectedIndex].ToString());
                            form.sizeOfVicky = PopNeedsDataV.Count;
                            form.GoodsList = new Functions().MergeClasses(GoodsDataP, GoodsDataV);
                            form.PopNeedsList = new Functions().MergeClasses(PopNeedsDataP, PopNeedsDataV);
                            form.local = new ClassPopNeeds(PopNeedsData[i]);
                            form.ShowDialog();
                            ClassPopNeeds j = form.ReturnValue();
                            if (j != null)
                            {
                                i = new Functions().hasNameIndex(PopNeedsDataP, j.Name); // Index to change
                                if (i == -1)
                                {
                                    PopNeedsDataP.Add(new ClassPopNeeds(j));
                                    PopNeedsDataP.Sort(delegate (ClassPopNeeds t1, ClassPopNeeds t2)
                                    {
                                        return (t1.Name.CompareTo(t2.Name));
                                    });
                                    ProjectLB.Items.Clear();
                                    foreach (ClassPopNeeds entry in PopNeedsDataP) { ProjectLB.Items.Add(entry.Name); }
                                }
                                else
                                {
                                    PopNeedsDataP[i] = j;
                                    ProjectLB.Items.Clear();
                                    foreach (ClassPopNeeds entry in PopNeedsDataP) { ProjectLB.Items.Add(entry.Name); }
                                }
                            }
                        }

                        if (PopNeedsDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }

                        break;

                    case "Religions":

                        if (ListBox.Items.Count == 0) { return; }

                        if (ListBox.SelectedIndex == -1) { selectedIndex = 0; ListBox.SelectedIndex = 0; } else { selectedIndex = ListBox.SelectedIndex; }

                        using (ReligionForm form = new ReligionForm())
                        {
                            int i;
                            i = new Functions().hasNameIndex(ReligionsData, ListBox.Items[selectedIndex].ToString());
                            form.sizeOfVicky = ReligionsDataV.Count;
                            form.GoodsData = new Functions().MergeClasses(GoodsDataP, GoodsDataV);
                            form.ReligionData = new Functions().MergeClasses(ReligionsDataP, ReligionsDataV);
                            form.local = new ClassReligions(ReligionsData[i]);
                            form.Traits = TraitsData;
                            form.ShowDialog();
                            ClassReligions j = form.ReturnValue();
                            if (j != null)
                            {
                                i = new Functions().hasNameIndex(ReligionsDataP, j.Name); // Index to change
                                if (i == -1)
                                {
                                    ReligionsDataP.Add(new ClassReligions(j));
                                    ReligionsDataP.Sort(delegate (ClassReligions t1, ClassReligions t2)
                                    {
                                        return (t1.Name.CompareTo(t2.Name));
                                    });
                                    ProjectLB.Items.Clear();
                                    foreach (ClassReligions entry in ReligionsDataP) { ProjectLB.Items.Add(entry.Name); }
                                }
                                else
                                {
                                    ReligionsDataP[i] = j;
                                    ProjectLB.Items.Clear();
                                    foreach (ClassReligions entry in ReligionsDataP) { ProjectLB.Items.Add(entry.Name); }
                                }
                            }
                        }

                        if (ReligionsDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }

                        break;

                    case "State Traits":

                        if (ListBox.Items.Count == 0) { return; }

                        if (ListBox.SelectedIndex == -1) { selectedIndex = 0; ListBox.SelectedIndex = 0; } else { selectedIndex = ListBox.SelectedIndex; }

                        using (StateTraitsForm form = new StateTraitsForm())
                        {
                            int i;
                            i = new Functions().hasNameIndex(StateTraitsData, ListBox.Items[selectedIndex].ToString());
                            form.sizeOfVicky = StateTraitsDataV.Count;
                            form.ModifiersTypes = new Functions().MergeClasses(ModifierTypeDataP, ModifierTypeDataV);
                            form.TechData = new Functions().MergeClasses(TechDataP, TechDataV);
                            form.StateTraitsData = new Functions().MergeClasses(StateTraitsDataP, StateTraitsDataV);
                            form.local = new ClassStateTraits(StateTraitsData[i]);
                            form.ShowDialog();
                            ClassStateTraits j = form.ReturnValue();
                            if (j != null)
                            {
                                i = new Functions().hasNameIndex(StateTraitsDataP, j.Name); // Index to change
                                if (i == -1)
                                {
                                    StateTraitsDataP.Add(new ClassStateTraits(j));
                                    StateTraitsDataP.Sort(delegate (ClassStateTraits t1, ClassStateTraits t2)
                                    {
                                        return (t1.Name.CompareTo(t2.Name));
                                    });
                                    ProjectLB.Items.Clear();
                                    foreach (ClassStateTraits entry in StateTraitsDataP) { ProjectLB.Items.Add(entry.Name); }
                                }
                                else
                                {
                                    StateTraitsDataP[i] = j;
                                    ProjectLB.Items.Clear();
                                    foreach (ClassStateTraits entry in StateTraitsDataP) { ProjectLB.Items.Add(entry.Name); }
                                }
                            }
                        }

                        if (StateTraitsDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }

                        break;

                    case "Technology":

                        if (ListBox.Items.Count == 0) { return; }

                        if (ListBox.SelectedIndex == -1) { selectedIndex = 0; ListBox.SelectedIndex = 0; } else { selectedIndex = ListBox.SelectedIndex; }

                        using (TechForm form = new TechForm())
                        {
                            int i;
                            i = new Functions().hasNameIndex(TechData, ListBox.Items[selectedIndex].ToString());
                            form.sizeOfVicky = TechDataV.Count;
                            form.ModifiersTypes = new Functions().MergeClasses(ModifierTypeDataP, ModifierTypeDataV);
                            form.TechList = new Functions().MergeClasses(TechDataP, TechDataV);
                            form.EraList = new Functions().MergeClasses(EraDataP, EraDataV);
                            form.local = new ClassTech(TechData[i]);
                            form.ShowDialog();
                            ClassTech j = form.ReturnValue();
                            if (j != null)
                            {
                                i = new Functions().hasNameIndex(TechDataP, j.Name); // Index to change
                                if (i == -1)
                                {
                                    TechDataP.Add(new ClassTech(j));
                                    TechDataP.Sort(delegate (ClassTech t1, ClassTech t2)
                                    {
                                        return (t1.Name.CompareTo(t2.Name));
                                    });
                                    ProjectLB.Items.Clear();
                                    foreach (ClassTech entry in TechDataP) { ProjectLB.Items.Add(entry.Name); }
                                }
                                else
                                {
                                    TechDataP[i] = j;
                                    ProjectLB.Items.Clear();
                                    foreach (ClassTech entry in TechDataP) { ProjectLB.Items.Add(entry.Name); }
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
                    if (mainSelectedIndex != -1) { Mod(); }
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
                            i = new Functions().hasNameIndex(EraDataP, j.Era.ToString()); // Index to change
                            if (i == -1)
                            {
                                EraDataP.Add(new ClassEra(j.Era, j.Cost));
                                EraDataP.Sort(delegate (ClassEra t1, ClassEra t2)
                                {
                                    return (t1.Era.CompareTo(t2.Era));
                                });
                                ProjectLB.Items.Clear();
                                ProjectLB.Items.Add(string.Format("{0,-20}{1,-20 }", "Era", "Cost"));
                                foreach (ClassEra eraEntry in EraDataP) { ProjectLB.Items.Add(string.Format("{0,-20}{1,-20 }", eraEntry.Era, eraEntry.Cost)); }
                            }
                            else
                            {
                                EraDataP[i].Cost = j.Cost;
                                ProjectLB.Items.Clear();
                                ProjectLB.Items.Add(string.Format("{0,-20}{1,-20 }", "Era", "Cost"));
                                foreach (ClassEra eraEntry in EraDataP) { ProjectLB.Items.Add(string.Format("{0,-20}{1,-20 }", eraEntry.Era, eraEntry.Cost)); }
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
                        form.GoodsData = new Functions().MergeClasses(GoodsDataP, GoodsDataV);
                        form.local = null;
                        form.ShowDialog();

                        ClassGoods j = form.ReturnValue();
                        if (j != null)
                        {
                            i = new Functions().hasNameIndex(GoodsDataP, j.Name); // Index to change
                            if (i == -1)
                            {
                                GoodsDataP.Add(new ClassGoods(j));
                                GoodsDataP.Sort(delegate (ClassGoods t1, ClassGoods t2)
                                {
                                    return (t1.Name.CompareTo(t2.Name));
                                });
                                ProjectLB.Items.Clear();
                                foreach (ClassGoods entry in GoodsDataP) { ProjectLB.Items.Add(entry.Name); }
                            }
                            else
                            {
                                GoodsDataP[i] = j;
                                ProjectLB.Items.Clear();
                                foreach (ClassGoods entry in GoodsDataP) { ProjectLB.Items.Add(entry.Name); }
                            }
                        }
                    }

                    if (GoodsDataP.Count == 0) { DeleteBT.Enabled = false; }
                    else { DeleteBT.Enabled = true; }

                    break;

                case "Institutions":

                    using (InstitutionsForm form = new InstitutionsForm())
                    {
                        int i;

                        form.sizeOfVicky = InstitutionsDataV.Count;
                        form.ModifiersTypes = new Functions().MergeClasses(ModifierTypeDataP, ModifierTypeDataV);
                        form.InstitutionsData = new Functions().MergeClasses(InstitutionsDataP, InstitutionsDataV);
                        form.local = null;
                        form.ShowDialog();

                        ClassInstitutions j = form.ReturnValue();
                        if (j != null)
                        {
                            i = new Functions().hasNameIndex(InstitutionsDataP, j.Name); // Index to change
                            if (i == -1)
                            {
                                InstitutionsDataP.Add(new ClassInstitutions(j));
                                InstitutionsDataP.Sort(delegate (ClassInstitutions t1, ClassInstitutions t2)
                                {
                                    return (t1.Name.CompareTo(t2.Name));
                                });
                                ProjectLB.Items.Clear();
                                foreach (ClassInstitutions entry in InstitutionsDataP) { ProjectLB.Items.Add(entry.Name); }
                            }
                            else
                            {
                                InstitutionsDataP[i] = j;
                                ProjectLB.Items.Clear();
                                foreach (ClassInstitutions entry in InstitutionsDataP) { ProjectLB.Items.Add(entry.Name); }
                            }
                        }
                    }

                    if (InstitutionsDataP.Count == 0) { DeleteBT.Enabled = false; }
                    else { DeleteBT.Enabled = true; }

                    break;

                case "Modifiers":

                    using (ModifiersForm form = new ModifiersForm())
                    {
                        int i;

                        form.sizeOfVicky = ModifierDataV.Count;
                        form.ModifiersTypes = new Functions().MergeClasses(ModifierTypeDataP, ModifierTypeDataV);
                        form.ModifiersData = new Functions().MergeClasses(ModifierDataP, ModifierDataV);
                        form.local = null;
                        form.ShowDialog();

                        ClassModifiers j = form.ReturnValue();
                        if (j != null)
                        {
                            i = new Functions().hasNameIndex(ModifierDataP, j.Name); // Index to change
                            if (i == -1)
                            {
                                ModifierDataP.Add(new ClassModifiers(j));
                                ModifierDataP.Sort(delegate (ClassModifiers t1, ClassModifiers t2)
                                {
                                    return (t1.Name.CompareTo(t2.Name));
                                });
                                ProjectLB.Items.Clear();
                                foreach (ClassModifiers entry in ModifierDataP) { ProjectLB.Items.Add(entry.Name); }
                            }
                            else
                            {
                                ModifierDataP[i] = j;
                                ProjectLB.Items.Clear();
                                foreach (ClassModifiers entry in ModifierDataP) { ProjectLB.Items.Add(entry.Name); }
                            }
                        }
                    }

                    if (ModifierDataP.Count == 0) { DeleteBT.Enabled = false; }
                    else { DeleteBT.Enabled = true; }

                    break;

                case "Modifier Types":

                    using (ModifiersTypesForm form = new ModifiersTypesForm())
                    {
                        int i;

                        form.sizeOfVicky = ModifierTypeDataV.Count;
                        form.ModifiersData = new Functions().MergeClasses(ModifierTypeDataP, ModifierTypeDataV);
                        form.local = null;
                        form.ShowDialog();

                        ClassModifiersType j = form.ReturnValue();
                        if (j != null)
                        {
                            i = new Functions().hasNameIndex(ModifierTypeDataP, j.Name); // Index to change
                            if (i == -1)
                            {
                                ModifierTypeDataP.Add(new ClassModifiersType(j));
                                ModifierTypeDataP.Sort(delegate (ClassModifiersType t1, ClassModifiersType t2)
                                {
                                    return (t1.Name.CompareTo(t2.Name));
                                });
                                ProjectLB.Items.Clear();
                                foreach (ClassModifiersType entry in ModifierTypeDataP) { ProjectLB.Items.Add(entry.Name); }
                            }
                            else
                            {
                                ModifierTypeDataP[i] = j;
                                ProjectLB.Items.Clear();
                                foreach (ClassModifiersType entry in ModifierTypeDataP) { ProjectLB.Items.Add(entry.Name); }
                            }
                        }
                    }

                    if (ModifierTypeDataP.Count == 0) { DeleteBT.Enabled = false; }
                    else { DeleteBT.Enabled = true; }

                    break;

                case "Pop Needs":

                    using (PopNeedsForm form = new PopNeedsForm())
                    {
                        int i;
                        form.sizeOfVicky = PopNeedsDataV.Count;
                        form.GoodsList = new Functions().MergeClasses(GoodsDataP, GoodsDataV);
                        form.PopNeedsList = new Functions().MergeClasses(PopNeedsDataP, PopNeedsDataV);
                        form.local = null;
                        form.ShowDialog();
                        ClassPopNeeds j = form.ReturnValue();
                        if (j != null)
                        {
                            i = new Functions().hasNameIndex(PopNeedsDataP, j.Name); // Index to change
                            if (i == -1)
                            {
                                PopNeedsDataP.Add(new ClassPopNeeds(j));
                                PopNeedsDataP.Sort(delegate (ClassPopNeeds t1, ClassPopNeeds t2)
                                {
                                    return (t1.Name.CompareTo(t2.Name));
                                });
                                ProjectLB.Items.Clear();
                                foreach (ClassPopNeeds entry in PopNeedsDataP) { ProjectLB.Items.Add(entry.Name); }
                            }
                            else
                            {
                                PopNeedsDataP[i] = j;
                                ProjectLB.Items.Clear();
                                foreach (ClassPopNeeds entry in PopNeedsDataP) { ProjectLB.Items.Add(entry.Name); }
                            }
                        }
                    }

                    if (PopNeedsDataP.Count == 0) { DeleteBT.Enabled = false; }
                    else { DeleteBT.Enabled = true; }

                    break;

                case "Religions":

                    using (ReligionForm form = new ReligionForm())
                    {
                        int i;
                        form.sizeOfVicky = ReligionsDataV.Count;
                        form.GoodsData = new Functions().MergeClasses(GoodsDataP, GoodsDataV);
                        form.ReligionData = new Functions().MergeClasses(ReligionsDataP, ReligionsDataV);
                        form.Traits = TraitsData;
                        form.local = null;
                        form.ShowDialog();
                        ClassReligions j = form.ReturnValue();
                        if (j != null)
                        {
                            i = new Functions().hasNameIndex(ReligionsDataP, j.Name); // Index to change
                            if (i == -1)
                            {
                                ReligionsDataP.Add(new ClassReligions(j));
                                ReligionsDataP.Sort(delegate (ClassReligions t1, ClassReligions t2)
                                {
                                    return (t1.Name.CompareTo(t2.Name));
                                });
                                ProjectLB.Items.Clear();
                                foreach (ClassReligions entry in ReligionsDataP) { ProjectLB.Items.Add(entry.Name); }
                            }
                            else
                            {
                                ReligionsDataP[i] = j;
                                ProjectLB.Items.Clear();
                                foreach (ClassReligions entry in ReligionsDataP) { ProjectLB.Items.Add(entry.Name); }
                            }
                        }
                    }

                    if (ReligionsDataP.Count == 0) { DeleteBT.Enabled = false; }
                    else { DeleteBT.Enabled = true; }

                    break;

                case "State Traits":

                    using (StateTraitsForm form = new StateTraitsForm())
                    {
                        int i;
                        form.sizeOfVicky = StateTraitsDataV.Count;
                        form.ModifiersTypes = new Functions().MergeClasses(ModifierTypeDataP, ModifierTypeDataV);
                        form.TechData = new Functions().MergeClasses(TechDataP, TechDataV);
                        form.StateTraitsData = new Functions().MergeClasses(StateTraitsDataP, StateTraitsDataV);
                        form.local = null;
                        form.ShowDialog();
                        ClassStateTraits j = form.ReturnValue();
                        if (j != null)
                        {
                            i = new Functions().hasNameIndex(StateTraitsDataP, j.Name); // Index to change
                            if (i == -1)
                            {
                                StateTraitsDataP.Add(new ClassStateTraits(j));
                                StateTraitsDataP.Sort(delegate (ClassStateTraits t1, ClassStateTraits t2)
                                {
                                    return (t1.Name.CompareTo(t2.Name));
                                });
                                ProjectLB.Items.Clear();
                                foreach (ClassStateTraits entry in StateTraitsDataP) { ProjectLB.Items.Add(entry.Name); }
                            }
                            else
                            {
                                StateTraitsDataP[i] = j;
                                ProjectLB.Items.Clear();
                                foreach (ClassStateTraits entry in StateTraitsDataP) { ProjectLB.Items.Add(entry.Name); }
                            }
                        }
                    }

                    if (StateTraitsDataP.Count == 0) { DeleteBT.Enabled = false; }
                    else { DeleteBT.Enabled = true; }

                    break;

                case "Technology":

                    using (TechForm form = new TechForm())
                    {
                        int i;
                        form.sizeOfVicky = TechDataV.Count;
                        form.ModifiersTypes = new Functions().MergeClasses(ModifierTypeDataP, ModifierTypeDataV);
                        form.TechList = new Functions().MergeClasses(TechDataP, TechDataV);
                        form.EraList = new Functions().MergeClasses(EraDataP, EraDataV);
                        form.local = null;
                        form.ShowDialog();
                        ClassTech j = form.ReturnValue();
                        if (j != null)
                        {
                            i = new Functions().hasNameIndex(TechDataP, j.Name); // Index to change
                            if (i == -1)
                            {
                                TechDataP.Add(new ClassTech(j));
                                TechDataP.Sort(delegate (ClassTech t1, ClassTech t2)
                                {
                                    return (t1.Name.CompareTo(t2.Name));
                                });
                                ProjectLB.Items.Clear();
                                foreach (ClassTech entry in TechDataP) { ProjectLB.Items.Add(entry.Name); }
                            }
                            else
                            {
                                TechDataP[i] = j;
                                ProjectLB.Items.Clear();
                                foreach (ClassTech entry in TechDataP) { ProjectLB.Items.Add(entry.Name); }
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

            LocalizationDataV = LocalizationSetup(VickyPath + "\\game");
            LocalizationDataP = LocalizationSetup(ProjPath);
            LocalizationDataM = LocalizationSetup(ModPath);
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

                    i = new Functions().hasNameIndex(EraDataP, ProjectLB.Items[projSelectedIndex].ToString().Substring(0, 20));
                    EraDataP.RemoveAt(i);
                    ProjectLB.Items.Clear();
                    ProjectLB.Items.Add(string.Format("{0,-20}{1,-20 }", "Era", "Cost"));
                    foreach (ClassEra eraEntry in EraDataP) { ProjectLB.Items.Add(string.Format("{0,-20}{1,-20 }", eraEntry.Era, eraEntry.Cost)); }

                    if (EraDataP.Count == 0) { DeleteBT.Enabled = false; }
                    else { DeleteBT.Enabled = true; }

                    break;

                case "Goods":

                    if (ProjectLB.SelectedIndex == -1) { projSelectedIndex = 0; ProjectLB.SelectedIndex = 0; } else { projSelectedIndex = ProjectLB.SelectedIndex; }

                    i = new Functions().hasNameIndex(GoodsDataP, ProjectLB.Items[projSelectedIndex].ToString());
                    GoodsDataP.RemoveAt(i);
                    ProjectLB.Items.Clear();
                    foreach (ClassGoods entry in GoodsDataP) { ProjectLB.Items.Add(entry.Name); }

                    if (GoodsDataP.Count == 0) { DeleteBT.Enabled = false; }
                    else { DeleteBT.Enabled = true; }

                    break;

                case "Institutions":

                    if (ProjectLB.SelectedIndex == -1) { projSelectedIndex = 0; ProjectLB.SelectedIndex = 0; } else { projSelectedIndex = ProjectLB.SelectedIndex; }

                    i = new Functions().hasNameIndex(InstitutionsDataP, ProjectLB.Items[projSelectedIndex].ToString());
                    InstitutionsDataP.RemoveAt(i);
                    ProjectLB.Items.Clear();
                    foreach (ClassInstitutions entry in InstitutionsDataP) { ProjectLB.Items.Add(entry.Name); }

                    if (InstitutionsDataP.Count == 0) { DeleteBT.Enabled = false; }
                    else { DeleteBT.Enabled = true; }

                    break;

                case "Modifiers":

                    if (ProjectLB.SelectedIndex == -1) { projSelectedIndex = 0; ProjectLB.SelectedIndex = 0; } else { projSelectedIndex = ProjectLB.SelectedIndex; }

                    i = new Functions().hasNameIndex(ModifierDataP, ProjectLB.Items[projSelectedIndex].ToString());
                    ModifierDataP.RemoveAt(i);
                    ProjectLB.Items.Clear();
                    foreach (ClassModifiers entry in ModifierDataP) { ProjectLB.Items.Add(entry.Name); }

                    if (ModifierDataP.Count == 0) { DeleteBT.Enabled = false; }
                    else { DeleteBT.Enabled = true; }

                    break;

                case "Modifier Types":

                    if (ProjectLB.SelectedIndex == -1) { projSelectedIndex = 0; ProjectLB.SelectedIndex = 0; } else { projSelectedIndex = ProjectLB.SelectedIndex; }

                    i = new Functions().hasNameIndex(ModifierTypeDataP, ProjectLB.Items[projSelectedIndex].ToString());
                    ModifierTypeDataP.RemoveAt(i);
                    ProjectLB.Items.Clear();
                    foreach (ClassModifiersType entry in ModifierTypeDataP) { ProjectLB.Items.Add(entry.Name); }

                    if (ModifierTypeDataP.Count == 0) { DeleteBT.Enabled = false; }
                    else { DeleteBT.Enabled = true; }

                    break;

                case "Pop Needs":

                    if (ProjectLB.SelectedIndex == -1) { projSelectedIndex = 0; ProjectLB.SelectedIndex = 0; } else { projSelectedIndex = ProjectLB.SelectedIndex; }

                    i = new Functions().hasNameIndex(PopNeedsDataP, ProjectLB.Items[projSelectedIndex].ToString());
                    PopNeedsDataP.RemoveAt(i);
                    ProjectLB.Items.Clear();
                    foreach (ClassPopNeeds entry in PopNeedsDataP) { ProjectLB.Items.Add(entry.Name); }

                    if (PopNeedsDataP.Count == 0) { DeleteBT.Enabled = false; }
                    else { DeleteBT.Enabled = true; }

                    break;

                case "Religions":

                    if (ProjectLB.SelectedIndex == -1) { projSelectedIndex = 0; ProjectLB.SelectedIndex = 0; } else { projSelectedIndex = ProjectLB.SelectedIndex; }

                    i = new Functions().hasNameIndex(ReligionsDataP, ProjectLB.Items[projSelectedIndex].ToString());
                    ReligionsDataP.RemoveAt(i);
                    ProjectLB.Items.Clear();
                    foreach (ClassReligions entry in ReligionsDataP) { ProjectLB.Items.Add(entry.Name); }

                    if (ReligionsDataP.Count == 0) { DeleteBT.Enabled = false; }
                    else { DeleteBT.Enabled = true; }

                    break;

                case "State Traits":

                    if (ProjectLB.SelectedIndex == -1) { projSelectedIndex = 0; ProjectLB.SelectedIndex = 0; } else { projSelectedIndex = ProjectLB.SelectedIndex; }

                    i = new Functions().hasNameIndex(StateTraitsDataP, ProjectLB.Items[projSelectedIndex].ToString());
                    StateTraitsDataP.RemoveAt(i);
                    ProjectLB.Items.Clear();
                    foreach (ClassStateTraits entry in StateTraitsDataP) { ProjectLB.Items.Add(entry.Name); }

                    if (StateTraitsDataP.Count == 0) { DeleteBT.Enabled = false; }
                    else { DeleteBT.Enabled = true; }

                    break;

                case "Technology":

                    if (ProjectLB.SelectedIndex == -1) { projSelectedIndex = 0; ProjectLB.SelectedIndex = 0; } else { projSelectedIndex = ProjectLB.SelectedIndex; }

                    i = new Functions().hasNameIndex(TechDataP, ProjectLB.Items[projSelectedIndex].ToString());
                    TechDataP.RemoveAt(i);
                    ProjectLB.Items.Clear();
                    foreach (ClassTech entry in TechDataP) { ProjectLB.Items.Add(entry.Name); }

                    if (TechDataP.Count == 0) { DeleteBT.Enabled = false; }
                    else { DeleteBT.Enabled = true; }

                    break;

                default:
                    MainLB.Items.Add("Error");
                    break;
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Important
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        private Dictionary<string, string> LocalizationSetup(string path)
        {
            if (Directory.Exists(path + "\\localization\\" + language))
            {
                return new LocalizationParser().ParseFiles(path + "\\localization\\" + language);
            }
            return null;
        }

        private void ReadFilesCommon<T>(string path, List<T> Data, IParser Iparser, Func<KeyValuePair<string, object>, T> ClassCreator, Func<T, string> sortBy)
        {
            if (Directory.Exists(path))
            {
                foreach (List<KeyValuePair<string, object>> entry in Iparser.ParseFiles(path).Cast<List<KeyValuePair<string, object>>>()) // Files
                {
                    foreach (KeyValuePair<string, object> entry2 in entry)
                    {
                        Data.Add(ClassCreator(entry2));
                    }
                }

                Data.Sort(delegate (T t1, T t2)
                {   // 0.5 s Make more efi
                    return sortBy(t1).CompareTo(sortBy(t2));
                });
            }
            return;
        }

        // *
        private void ClearClassData()
        {
            EraDataP?.Clear();
            EraDataV?.Clear();
            EraDataM?.Clear();

            GoodsDataP?.Clear();
            GoodsDataV?.Clear();
            GoodsDataM?.Clear();

            InstitutionsDataP?.Clear();
            InstitutionsDataV?.Clear();
            InstitutionsDataM?.Clear();

            ModifierDataP?.Clear();
            ModifierDataV?.Clear();
            ModifierDataM?.Clear();

            ModifierTypeDataP?.Clear();
            ModifierTypeDataV?.Clear();
            ModifierTypeDataM?.Clear();

            PopNeedsDataP?.Clear();
            PopNeedsDataV?.Clear();
            PopNeedsDataM?.Clear();

            ReligionsDataP?.Clear();
            ReligionsDataV?.Clear();
            ReligionsDataM?.Clear();

            StateTraitsDataP?.Clear();
            StateTraitsDataV?.Clear();
            StateTraitsDataM?.Clear();

            TechDataP?.Clear();
            TechDataV?.Clear();
            TechDataM?.Clear();
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Traits
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void TraitsAdder()
        {
            TraitsData = new List<string>();

            foreach (ClassReligions entry in ReligionsDataV)
            {
                foreach (string trait in entry.Traits)
                {
                    if (!TraitsData.Contains(trait))
                    {
                        TraitsData.Add(trait);
                    }
                }
            }

            foreach (ClassReligions entry in ReligionsDataP)
            {
                foreach (string trait in entry.Traits)
                {
                    if (!TraitsData.Contains(trait))
                    {
                        TraitsData.Add(trait);
                    }
                }
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Make Project *
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        // *
        private void MakeProjFiles()
        {
            // Makes Common
            if (!Directory.Exists(ProjPath + "\\common"))
            {
                Directory.CreateDirectory(ProjPath + "\\common");
            }

            // Makes Localization
            if (!Directory.Exists(ProjPath + "\\localization"))
            {
                Directory.CreateDirectory(ProjPath + "\\localization");
            }

            // Makes GFX
            if (!Directory.Exists(ProjPath + "\\gfx"))
            {
                Directory.CreateDirectory(ProjPath + "\\gfx");
            }

            switch (MainData[mainSelectedIndex].ToString())
            {
                case "Era":

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

                        using (StreamWriter sw = new StreamWriter(File.Open(ProjPath + "\\common\\technology\\eras\\" + ProjName.ToLower().Replace(" ", "_") + ".txt", FileMode.Create), new UTF8Encoding(true)))
                        {
                            sw.NewLine = "\n";
                            foreach (ClassEra eraEntry in EraDataP)
                            {
                                sw.WriteLine();
                                sw.WriteLine("era_" + eraEntry.Era + " = {");
                                sw.WriteLine("\ttechnology_cost = " + eraEntry.Cost);
                                sw.WriteLine("}");
                            }
                        }
                    }

                    break;

                case "Goods":

                    if (GoodsDataP.Count != 0)
                    {
                        // Common
                        if (!Directory.Exists(ProjPath + "\\common\\goods"))
                        {
                            Directory.CreateDirectory(ProjPath + "\\common\\goods");
                        }

                        using (StreamWriter sw = new StreamWriter(File.Open(ProjPath + "\\common\\goods\\" + ProjName.ToLower().Replace(" ", "_") + ".txt", FileMode.Create), new UTF8Encoding(true)))
                        {
                            sw.NewLine = "\n";
                            foreach (ClassGoods Entry in GoodsDataP)
                            {
                                sw.WriteLine();
                                sw.WriteLine(Entry.Name + " = {");
                                sw.WriteLine("\ttexture = \"" + "gfx/interface/icons/goods_icons/" + Entry.Name + ".dds" + "\"");
                                sw.WriteLine("\tcost = " + Entry.Cost);
                                sw.WriteLine("\tcategory = " + Entry.Category);

                                if (Entry.Tradeable == false) { sw.WriteLine("\ttradeable = no"); }

                                if (Entry.Fixed_price == true) { sw.WriteLine("\tfixed_price = yes"); }

                                sw.WriteLine();

                                if (Entry.Obsession != -1) { sw.WriteLine("\tobsession_chance = " + Entry.Obsession.ToString().Replace(",", ".")); }

                                sw.WriteLine("\tprestige_factor = " + Entry.Prestige.ToString().Replace(",", "."));

                                if (Entry.TradedQuantity != -1) { sw.WriteLine("\ttraded_quantity = " + Entry.TradedQuantity); }

                                if (Entry.Convoy_cost != -1) { sw.WriteLine("\tconvoy_cost_multiplier = " + Entry.Convoy_cost.ToString().Replace(",", ".")); }

                                if (Entry.Consumption != -1) { sw.WriteLine("\tconsumption_tax_cost = " + Entry.Consumption); }

                                sw.WriteLine("}");
                                sw.WriteLine();
                            }
                        }

                        // Localization
                        if (!Directory.Exists(ProjPath + "\\localization\\" + language))
                        {
                            Directory.CreateDirectory(ProjPath + "\\localization\\" + language);
                        }

                        using (StreamWriter sw = new StreamWriter(File.Open(ProjPath + "\\localization\\" + language + "\\" + ProjName.ToLower().Replace(" ", "_") + "_goods_l_english.yml", FileMode.Create), new UTF8Encoding(true)))
                        {
                            sw.NewLine = "\n";
                            sw.WriteLine("l_english:");

                            foreach (ClassGoods Entry in GoodsDataP)
                            {
                                sw.WriteLine(" " + Entry.Name + ":0 \"" + Entry.TrueName + "\"");
                            }
                        }

                        // gfx
                        if (!Directory.Exists(ProjPath + "\\gfx\\interface"))
                        {
                            Directory.CreateDirectory(ProjPath + "\\gfx\\interface");
                        }

                        if (!Directory.Exists(ProjPath + "\\gfx\\interface\\icons"))
                        {
                            Directory.CreateDirectory(ProjPath + "\\gfx\\interface\\icons");
                        }

                        if (!Directory.Exists(ProjPath + "\\gfx\\interface\\icons\\goods_icons"))
                        {
                            Directory.CreateDirectory(ProjPath + "\\gfx\\interface\\icons\\goods_icons");
                        }

                        foreach (ClassGoods entry in GoodsDataP)
                        {
                            File.Copy(VickyPath + "\\game\\" + entry.Texture, ProjPath + "\\gfx\\interface\\icons\\goods_icons\\" + entry.Name + ".dds", true);
                        }
                    }

                    break;

                case "Institutions":

                    if (InstitutionsDataP.Count != 0)
                    {
                        // Common
                        if (!Directory.Exists(ProjPath + "\\common\\institutions"))
                        {
                            Directory.CreateDirectory(ProjPath + "\\common\\institutions");
                        }

                        using (StreamWriter sw = new StreamWriter(File.Open(ProjPath + "\\common\\institutions\\" + ProjName.ToLower().Replace(" ", "_") + ".txt", FileMode.Create), new UTF8Encoding(true)))
                        {
                            sw.NewLine = "\n";
                            foreach (ClassInstitutions entry in InstitutionsDataP)
                            {
                                sw.WriteLine();
                                sw.WriteLine(entry.Name + " = {");

                                sw.WriteLine("\ticon = " + "gfx/interface/icons/institution_icons/" + entry.Name + ".dds");
                                sw.WriteLine("\tbackground_texture = " + "gfx/interface/illustrations/institutions/" + entry.Name + ".dds");

                                if (entry.Modifiers.Count != 0)
                                {
                                    foreach (string modifier in entry.Modifiers)
                                    {
                                        sw.WriteLine("\t" + modifier);
                                    }
                                }

                                sw.WriteLine("}");
                            }
                        }

                        // Localization
                        if (!Directory.Exists(ProjPath + "\\localization\\" + language))
                        {
                            Directory.CreateDirectory(ProjPath + "\\localization\\" + language);
                        }

                        using (StreamWriter sw = new StreamWriter(File.Open(ProjPath + "\\localization\\" + language + "\\" + ProjName.ToLower().Replace(" ", "_") + "_institutions_l_english.yml", FileMode.Create), new UTF8Encoding(true)))
                        {
                            sw.NewLine = "\n";
                            sw.WriteLine("l_english:");

                            foreach (ClassInstitutions entry in InstitutionsDataP)
                            {
                                sw.WriteLine(" " + entry.Name + ":0 \"" + entry.TrueName + "\"");
                            }
                        }

                        // gfx
                        if (!Directory.Exists(ProjPath + "\\gfx\\interface"))
                        {
                            Directory.CreateDirectory(ProjPath + "\\gfx\\interface");
                        }

                        if (!Directory.Exists(ProjPath + "\\gfx\\interface\\icons"))
                        {
                            Directory.CreateDirectory(ProjPath + "\\gfx\\interface\\icons");
                        }

                        if (!Directory.Exists(ProjPath + "\\gfx\\interface\\icons\\institution_icons"))
                        {
                            Directory.CreateDirectory(ProjPath + "\\gfx\\interface\\icons\\institution_icons");
                        }

                        if (!Directory.Exists(ProjPath + "\\gfx\\interface\\illustrations"))
                        {
                            Directory.CreateDirectory(ProjPath + "\\gfx\\interface\\illustrations");
                        }

                        if (!Directory.Exists(ProjPath + "\\gfx\\interface\\illustrations\\institutions"))
                        {
                            Directory.CreateDirectory(ProjPath + "\\gfx\\interface\\illustrations\\institutions");
                        }

                        foreach (ClassInstitutions entry in InstitutionsDataP)
                        {
                            if (entry.Texture != ProjPath + "\\gfx\\interface\\icons\\institution_icons\\" + entry.Name + ".dds")
                            {
                                File.Copy(entry.Texture, ProjPath + "\\gfx\\interface\\icons\\institution_icons\\" + entry.Name + ".dds", true);
                            }

                            if (entry.BackTexture != ProjPath + "\\gfx\\interface\\illustrations\\institutions\\" + entry.Name + ".dds")
                            {
                                File.Copy(entry.BackTexture, ProjPath + "\\gfx\\interface\\illustrations\\institutions\\" + entry.Name + ".dds", true);
                            }
                        }
                    }

                    break;

                case "Modifiers":

                    if (ModifierDataP.Count != 0)
                    {
                        // Common
                        if (!Directory.Exists(ProjPath + "\\common\\modifiers"))
                        {
                            Directory.CreateDirectory(ProjPath + "\\common\\modifiers");
                        }

                        using (StreamWriter sw = new StreamWriter(File.Open(ProjPath + "\\common\\modifiers" + ProjName.ToLower().Replace(" ", "_") + ".txt", FileMode.Create), new UTF8Encoding(true)))
                        {
                            sw.NewLine = "\n";
                            foreach (ClassModifiers entry in ModifierDataP)
                            {
                                sw.WriteLine();
                                sw.WriteLine(entry.Name + " = {");

                                if (entry.Texture != string.Empty)
                                {
                                    sw.WriteLine("\ticon = " + "gfx/interface/icons/timed_modifier_icons/" + entry.Name + ".dds");
                                }

                                if (entry.Modifiers.Count != 0)
                                {
                                    foreach (string modifier in entry.Modifiers)
                                    {
                                        sw.WriteLine("\t" + modifier);
                                    }
                                }

                                sw.WriteLine("}");
                            }
                        }

                        // Localization
                        if (!Directory.Exists(ProjPath + "\\localization\\" + language))
                        {
                            Directory.CreateDirectory(ProjPath + "\\localization\\" + language);
                        }

                        using (StreamWriter sw = new StreamWriter(File.Open(ProjPath + "\\localization\\" + language + "\\" + ProjName.ToLower().Replace(" ", "_") + "_modifiers_l_english.yml", FileMode.Create), new UTF8Encoding(true)))
                        {
                            sw.NewLine = "\n";
                            sw.WriteLine("l_english:");

                            foreach (ClassModifiers entry in ModifierDataP)
                            {
                                sw.WriteLine(" " + entry.Name + ":0 \"" + entry.TrueName + "\"");
                                sw.WriteLine(" " + entry.Name + "_desc:0 \"" + entry.Description + "\"");
                            }
                        }

                        // gfx
                        if (!Directory.Exists(ProjPath + "\\gfx\\interface"))
                        {
                            Directory.CreateDirectory(ProjPath + "\\gfx\\interface");
                        }

                        if (!Directory.Exists(ProjPath + "\\gfx\\interface\\icons"))
                        {
                            Directory.CreateDirectory(ProjPath + "\\gfx\\interface\\icons");
                        }

                        if (!Directory.Exists(ProjPath + "\\gfx\\interface\\icons\\timed_modifier_icons"))
                        {
                            Directory.CreateDirectory(ProjPath + "\\gfx\\interface\\icons\\timed_modifier_icons");
                        }

                        foreach (ClassModifiers entry in ModifierDataP)
                        {
                            if (entry.Texture != ProjPath + "\\gfx\\interface\\icons\\timed_modifier_icons\\" + entry.Name + ".dds")
                            {
                                File.Copy(entry.Texture, ProjPath + "\\gfx\\interface\\icons\\timed_modifier_icons\\" + entry.Name + ".dds", true);
                            }
                        }
                    }

                    break;

                case "Modifier Types":

                    if (ModifierTypeDataP.Count != 0)
                    {
                        if (!Directory.Exists(ProjPath + "\\common\\modifier_types"))
                        {
                            Directory.CreateDirectory(ProjPath + "\\common\\modifier_types");
                        }

                        using (StreamWriter sw = new StreamWriter(File.Open(ProjPath + "\\common\\modifier_types\\" + ProjName.ToLower().Replace(" ", "_") + ".txt", FileMode.Create), new UTF8Encoding(true)))
                        {
                            sw.NewLine = "\n";
                            foreach (ClassModifiersType Entry in ModifierTypeDataP)
                            {
                                sw.WriteLine();
                                sw.WriteLine(Entry.Name + " = {");

                                if (Entry.Neutral != -1)
                                {
                                    if (Entry.Neutral == 1)
                                    {
                                        sw.WriteLine("\tneutral = yes");
                                    }
                                    else
                                    {
                                        sw.WriteLine("\tneutral = no");
                                    }
                                }

                                if (Entry.Good != -1)
                                {
                                    if (Entry.Good == 1)
                                    {
                                        sw.WriteLine("\tgood = yes");
                                    }
                                    else
                                    {
                                        sw.WriteLine("\tgood = no");
                                    }
                                }

                                if (Entry.Boolean != -1)
                                {
                                    if (Entry.Boolean == 1)
                                    {
                                        sw.WriteLine("\tboolean = yes");
                                    }
                                    else
                                    {
                                        sw.WriteLine("\tboolean = no");
                                    }
                                }

                                if (Entry.Percent != -1)
                                {
                                    if (Entry.Percent == 1)
                                    {
                                        sw.WriteLine("\tpercent = yes");
                                    }
                                    else
                                    {
                                        sw.WriteLine("\tpercent = no");
                                    }
                                }

                                if (Entry.Invert != -1)
                                {
                                    if (Entry.Invert == 1)
                                    {
                                        sw.WriteLine("\tinvert = yes");
                                    }
                                    else
                                    {
                                        sw.WriteLine("\tinvert = no");
                                    }
                                }

                                if (Entry.Num_decimals != -1)
                                {
                                    sw.WriteLine("\tnum_decimals = " + Entry.Num_decimals);
                                }

                                if (Entry.Translate != null)
                                {
                                    sw.WriteLine("\ttranslate = " + Entry.Translate);
                                }

                                if (Entry.Postfix != null)
                                {
                                    sw.WriteLine("\tpostfix = \"" + Entry.Postfix + "\"");
                                }

                                if (Entry.Ai_value != -1)
                                {
                                    sw.WriteLine("\tai_value = " + Entry.Ai_value);
                                }

                                sw.WriteLine("}");
                                sw.WriteLine();
                            }
                        }
                    }

                    break;

                case "Pop Needs":

                    if (PopNeedsDataP.Count != 0)
                    {
                        if (!Directory.Exists(ProjPath + "\\common\\pop_needs"))
                        {
                            Directory.CreateDirectory(ProjPath + "\\common\\pop_needs");
                        }

                        using (StreamWriter sw = new StreamWriter(File.Open(ProjPath + "\\common\\pop_needs\\" + ProjName.ToLower().Replace(" ", "_") + ".txt", FileMode.Create), new UTF8Encoding(true)))
                        {
                            sw.NewLine = "\n";
                            foreach (ClassPopNeeds Entry in PopNeedsDataP)
                            {
                                sw.WriteLine();
                                sw.WriteLine(Entry.Name + " = {");
                                sw.WriteLine("\tdefault = " + Entry.Defaultgood);

                                foreach (ClassPopNeedsEntry entry in Entry.Entries)
                                {
                                    sw.WriteLine();
                                    sw.WriteLine("\tentry = {");
                                    sw.WriteLine("\t\tgoods = " + entry.Name);
                                    sw.WriteLine();
                                    sw.WriteLine("\t\tweight = " + entry.Weight.ToString().Replace(",", "."));
                                    sw.WriteLine("\t\tmax_weight = " + entry.MaxWeight.ToString().Replace(",", "."));
                                    sw.WriteLine("\t\tmin_weight = " + entry.MinWeight.ToString().Replace(",", "."));
                                    sw.WriteLine("\t}");
                                    sw.WriteLine();
                                }

                                sw.WriteLine("}");
                                sw.WriteLine();
                            }
                        }

                        // Localization
                        if (!Directory.Exists(ProjPath + "\\localization\\" + language))
                        {
                            Directory.CreateDirectory(ProjPath + "\\localization\\" + language);
                        }

                        using (StreamWriter sw = new StreamWriter(File.Open(ProjPath + "\\localization\\" + language + "\\" + ProjName.ToLower().Replace(" ", "_") + "_popneeds_l_english.yml", FileMode.Create), new UTF8Encoding(true)))
                        {
                            sw.NewLine = "\n";
                            sw.WriteLine("l_english:");

                            foreach (ClassPopNeeds Entry in PopNeedsDataP)
                            {
                                sw.WriteLine(" " + Entry.Name + ":0 \"" + Entry.TrueName + "\"");
                            }
                        }
                    }

                    break;

                case "Religions":

                    if (ReligionsDataP.Count != 0)
                    {
                        // Common
                        if (!Directory.Exists(ProjPath + "\\common\\religions"))
                        {
                            Directory.CreateDirectory(ProjPath + "\\common\\religions");
                        }

                        using (StreamWriter sw = new StreamWriter(File.Open(ProjPath + "\\common\\religions\\" + ProjName.ToLower().Replace(" ", "_") + ".txt", FileMode.Create), new UTF8Encoding(true)))
                        {
                            sw.NewLine = "\n";
                            foreach (ClassReligions Entry in ReligionsDataP)
                            {
                                sw.WriteLine();
                                sw.WriteLine(Entry.Name + " = {");
                                sw.WriteLine("\ttexture = \"" + "gfx/interface/icons/religion_icons/" + Entry.Name + ".dds" + "\"");

                                if (Entry.Traits.Count != 0)
                                {
                                    sw.WriteLine("\ttraits = {");
                                    foreach (string traits in Entry.Traits)
                                    {
                                        sw.WriteLine("\t\t" + traits);
                                    }
                                    sw.WriteLine("\t}");
                                }
                                sw.WriteLine("\tcolor = { " + Math.Round((double)Entry.Red / 255, 2).ToString().Replace(",", ".") + " " + Math.Round((double)Entry.Green / 255, 2).ToString().Replace(",", ".") + " " + Math.Round((double)Entry.Blue / 255, 2).ToString().Replace(",", ".") + " }");
                                if (Entry.Taboos.Count != 0)
                                {
                                    sw.WriteLine("\ttaboos = {");
                                    foreach (string taboos in Entry.Taboos)
                                    {
                                        sw.WriteLine("\t\t" + taboos);
                                    }
                                    sw.WriteLine("\t}");
                                }
                                sw.WriteLine("}");
                                sw.WriteLine();
                            }
                        }

                        // Localization
                        if (!Directory.Exists(ProjPath + "\\localization\\" + language))
                        {
                            Directory.CreateDirectory(ProjPath + "\\localization\\" + language);
                        }

                        using (StreamWriter sw = new StreamWriter(File.Open(ProjPath + "\\localization\\" + language + "\\" + ProjName.ToLower().Replace(" ", "_") + "_religions_l_english.yml", FileMode.Create), new UTF8Encoding(true)))
                        {
                            sw.NewLine = "\n";
                            sw.WriteLine("l_english:");

                            foreach (ClassReligions Entry in ReligionsDataP)
                            {
                                sw.WriteLine(" " + Entry.Name + ":0 \"" + Entry.Truename + "\"");
                            }
                        }

                        // gfx
                        if (!Directory.Exists(ProjPath + "\\gfx\\interface"))
                        {
                            Directory.CreateDirectory(ProjPath + "\\gfx\\interface");
                        }

                        if (!Directory.Exists(ProjPath + "\\gfx\\interface\\icons"))
                        {
                            Directory.CreateDirectory(ProjPath + "\\gfx\\interface\\icons");
                        }

                        if (!Directory.Exists(ProjPath + "\\gfx\\interface\\icons\\religion_icons"))
                        {
                            Directory.CreateDirectory(ProjPath + "\\gfx\\interface\\icons\\religion_icons");
                        }

                        foreach (ClassReligions entry in ReligionsDataP)
                        {
                            if (entry.Texture != ProjPath + "\\gfx\\interface\\icons\\religion_icons\\" + entry.Name + ".dds")
                            {
                                File.Copy(entry.Texture, ProjPath + "\\gfx\\interface\\icons\\religion_icons\\" + entry.Name + ".dds", true);
                            }
                        }
                    }

                    break;

                case "State Traits":

                    if (StateTraitsDataP.Count != 0)
                    {
                        // Common
                        if (!Directory.Exists(ProjPath + "\\common\\state_traits"))
                        {
                            Directory.CreateDirectory(ProjPath + "\\common\\state_traits");
                        }

                        using (StreamWriter sw = new StreamWriter(File.Open(ProjPath + "\\common\\state_traits\\" + ProjName.ToLower().Replace(" ", "_") + ".txt", FileMode.Create), new UTF8Encoding(true)))
                        {
                            sw.NewLine = "\n";
                            foreach (ClassStateTraits entry in StateTraitsDataP)
                            {
                                sw.WriteLine();
                                sw.WriteLine(entry.Name + " = {");
                                sw.WriteLine("\ticon = \"" + "gfx/interface/icons/state_trait_icons/" + entry.Name + ".dds" + "\"");
                                sw.WriteLine();
                                if (entry.RequiredTechsForColonization != string.Empty)
                                {
                                    sw.WriteLine("\trequired_techs_for_colonization = { \"" + entry.RequiredTechsForColonization + "\" }");
                                }
                                if (entry.DisablingTechnologies != string.Empty)
                                {
                                    sw.WriteLine("\tdisabling_technologies = { \"" + entry.DisablingTechnologies + "\" }");
                                }
                                if (entry.Modifiers.Count != 0)
                                {
                                    sw.WriteLine();
                                    sw.WriteLine("\tmodifier = {");
                                    foreach (string modifier in entry.Modifiers)
                                    {
                                        sw.WriteLine("\t\t" + modifier);
                                    }
                                    sw.WriteLine("\t}");
                                }
                                
                                sw.WriteLine("}");
                            }
                        }

                        // Localization
                        if (!Directory.Exists(ProjPath + "\\localization\\" + language))
                        {
                            Directory.CreateDirectory(ProjPath + "\\localization\\" + language);
                        }

                        using (StreamWriter sw = new StreamWriter(File.Open(ProjPath + "\\localization\\" + language + "\\" + ProjName.ToLower().Replace(" ", "_") + "_state_traits_l_english.yml", FileMode.Create), new UTF8Encoding(true)))
                        {
                            sw.NewLine = "\n";
                            sw.WriteLine("l_english:");

                            foreach (ClassStateTraits entry in StateTraitsDataP)
                            {
                                sw.WriteLine(" " + entry.Name + ":0 \"" + entry.TrueName + "\"");
                            }
                        }

                       
                    }

                    break;

                case "Technology":

                    if (TechDataP.Count != 0)
                    {
                        // Common
                        if (!Directory.Exists(ProjPath + "\\common\\technology"))
                        {
                            Directory.CreateDirectory(ProjPath + "\\common\\technology");
                        }

                        if (!Directory.Exists(ProjPath + "\\common\\technology\\technologies"))
                        {
                            Directory.CreateDirectory(ProjPath + "\\common\\technology\\technologies");
                        }

                        using (StreamWriter sw = new StreamWriter(File.Open(ProjPath + "\\common\\technology\\technologies\\" + ProjName.ToLower().Replace(" ", "_") + ".txt", FileMode.Create), new UTF8Encoding(true)))
                        {
                            sw.NewLine = "\n";
                            foreach (ClassTech techEntry in TechDataP)
                            {
                                sw.WriteLine();
                                sw.WriteLine(techEntry.Name + " = {");
                                sw.WriteLine("\tera = era_" + techEntry.Era);
                                sw.WriteLine("\ttexture = \"" + "gfx/interface/icons/invention_icons/" + techEntry.Name + ".dds" + "\"");
                                sw.WriteLine("\tcategory = " + techEntry.Category);
                                if (techEntry.CanResearch == false) { sw.WriteLine("\tcan_research = no"); }
                                if (techEntry.Modifiers.Count != 0)
                                {
                                    sw.WriteLine();
                                    sw.WriteLine("\tmodifier = {");
                                    foreach (string modifier in techEntry.Modifiers)
                                    {
                                        sw.WriteLine("\t\t" + modifier);
                                    }
                                    sw.WriteLine("\t}");
                                }
                                if (techEntry.Restrictions.Count != 0)
                                {
                                    sw.WriteLine();
                                    sw.WriteLine("\tunlocking_technologies = {");
                                    foreach (string restr in techEntry.Restrictions)
                                    {
                                        sw.WriteLine("\t\t" + restr);
                                    }
                                    sw.WriteLine("\t}");
                                }
                                sw.WriteLine("}");
                            }
                        }

                        // Localization
                        if (!Directory.Exists(ProjPath + "\\localization\\" + language))
                        {
                            Directory.CreateDirectory(ProjPath + "\\localization\\" + language);
                        }

                        using (StreamWriter sw = new StreamWriter(File.Open(ProjPath + "\\localization\\" + language + "\\" + ProjName.ToLower().Replace(" ", "_") + "_tech_l_english.yml", FileMode.Create), new UTF8Encoding(true)))
                        {
                            sw.NewLine = "\n";
                            sw.WriteLine("l_english:");

                            foreach (ClassTech techEntry in TechDataP)
                            {
                                sw.WriteLine(" " + techEntry.Name + ":0 \"" + techEntry.TrueName + "\"");
                                sw.WriteLine(" " + techEntry.Name + "_desc:0 \"" + techEntry.Desc + "\"");
                            }
                        }

                        // gfx
                        if (!Directory.Exists(ProjPath + "\\gfx\\interface"))
                        {
                            Directory.CreateDirectory(ProjPath + "\\gfx\\interface");
                        }

                        if (!Directory.Exists(ProjPath + "\\gfx\\interface\\icons"))
                        {
                            Directory.CreateDirectory(ProjPath + "\\gfx\\interface\\icons");
                        }

                        if (!Directory.Exists(ProjPath + "\\gfx\\interface\\icons\\invention_icons"))
                        {
                            Directory.CreateDirectory(ProjPath + "\\gfx\\interface\\icons\\invention_icons");
                        }

                        foreach (ClassTech techEntry in TechDataP)
                        {
                            if (techEntry.Texture != ProjPath + "\\gfx\\interface\\icons\\invention_icons\\" + techEntry.Name + ".dds")
                            {
                                File.Copy(techEntry.Texture, ProjPath + "\\gfx\\interface\\icons\\invention_icons\\" + techEntry.Name + ".dds", true);
                            }
                        }
                    }

                    break;

                default:
                    break;
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