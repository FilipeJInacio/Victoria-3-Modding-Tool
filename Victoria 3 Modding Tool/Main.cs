using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;


namespace Victoria_3_Modding_Tool
{
    /*

    To do:



    wait to finish to open

    dic same error

    form position

    Help

    Add focus when leaving page

    open form




    To improve:

    -Debugger


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


    /*
    Code Types:
    - Building Groups
    - Buildings
    - Canals
    - Cultures
    - Decisions
    - Decrees
    - Law Groups
    - Laws
    - Pop Types
    - Production Methods
    */

    public partial class Main : Form
    {
        // *
        #region Variables
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

        public List<ClassBuildingGroups> BuildingGroupsDataP;
        public List<ClassBuildingGroups> BuildingGroupsDataV;
        public List<ClassBuildingGroups> BuildingGroupsDataM;

        public List<ClassBuildings> BuildingsDataP;
        public List<ClassBuildings> BuildingsDataV;
        public List<ClassBuildings> BuildingsDataM;

        public List<ClassCanals> CanalsDataP;
        public List<ClassCanals> CanalsDataV;
        public List<ClassCanals> CanalsDataM;

        public List<ClassCultures> CulturesDataP;
        public List<ClassCultures> CulturesDataV;
        public List<ClassCultures> CulturesDataM;

        public List<ClassDecisions> DecisionsDataP;
        public List<ClassDecisions> DecisionsDataV;
        public List<ClassDecisions> DecisionsDataM;

        public List<ClassDecrees> DecreesDataP;
        public List<ClassDecrees> DecreesDataV;
        public List<ClassDecrees> DecreesDataM;

        public List<ClassEras> ErasDataP;
        public List<ClassEras> ErasDataV;
        public List<ClassEras> ErasDataM;

        public List<ClassGoods> GoodsDataP;
        public List<ClassGoods> GoodsDataV;
        public List<ClassGoods> GoodsDataM;

        public List<ClassInstitutions> InstitutionsDataP;
        public List<ClassInstitutions> InstitutionsDataV;
        public List<ClassInstitutions> InstitutionsDataM;

        public List<ClassLawGroups> LawGroupsDataP;
        public List<ClassLawGroups> LawGroupsDataV;
        public List<ClassLawGroups> LawGroupsDataM;

        public List<ClassLaws> LawsDataP;
        public List<ClassLaws> LawsDataV;
        public List<ClassLaws> LawsDataM;

        public List<ClassModifiers> ModifierDataP;
        public List<ClassModifiers> ModifierDataV;
        public List<ClassModifiers> ModifierDataM;

        public List<ClassModifiersType> ModifierTypeDataP;
        public List<ClassModifiersType> ModifierTypeDataV;
        public List<ClassModifiersType> ModifierTypeDataM;

        public List<ClassPopNeeds> PopNeedsDataP;
        public List<ClassPopNeeds> PopNeedsDataV;
        public List<ClassPopNeeds> PopNeedsDataM;

        public List<ClassPopTypes> PopTypesDataP;
        public List<ClassPopTypes> PopTypesDataV;
        public List<ClassPopTypes> PopTypesDataM;

        public List<ClassProductionMethodGroups> ProductionMethodGroupsDataP;
        public List<ClassProductionMethodGroups> ProductionMethodGroupsDataV;
        public List<ClassProductionMethodGroups> ProductionMethodGroupsDataM;

        public List<ClassProductionMethods> ProductionMethodsDataP;
        public List<ClassProductionMethods> ProductionMethodsDataV;
        public List<ClassProductionMethods> ProductionMethodsDataM;

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

        #endregion Variables

        public Main()
        {
            InitializeComponent();
            this.Padding = new Padding(1);//Border size
            this.SetStyle(
                        ControlStyles.AllPaintingInWmPaint |
                        ControlStyles.UserPaint |
                        ControlStyles.DoubleBuffer, true);
            LoadMainLB();
        }

        #region Form Stuff
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Form
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

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
            LocalizationDataV = Functions.LocalizationSetup(VickyPath + "\\game");
            LocalizationDataP = Functions.LocalizationSetup(ProjPath);
            LocalizationDataM = Functions.LocalizationSetup(ModPath);
        }


        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Border
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        protected override void OnPaint(PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.FromArgb(61, 61, 61), ButtonBorderStyle.Solid);

            base.OnPaint(e);
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


        #endregion Form Stuff

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // LB Search Bar *
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        //*
        private void LoadMainLB()
        {
            MainData.Add("Building Groups");
            MainData.Add("Buildings");
            MainData.Add("Canals");
            MainData.Add("Cultures");
            MainData.Add("Decisions");
            MainData.Add("Decrees");
            MainData.Add("Eras");
            MainData.Add("Goods");
            MainData.Add("Institutions");
            MainData.Add("Law Groups");
            MainData.Add("Laws");
            MainData.Add("Modifiers");
            MainData.Add("Modifier Types");
            MainData.Add("Pop Needs");
            MainData.Add("Pop Types");
            MainData.Add("Production Method Groups");
            MainData.Add("Production Methods");
            MainData.Add("Religions");
            MainData.Add("State Traits");
            MainData.Add("Technologies");

            MainLB.Add("Building Groups");
            MainLB.Add("Buildings");
            MainLB.Add("Canals");
            MainLB.Add("Cultures");
            MainLB.Add("Decisions");
            MainLB.Add("Decrees");
            MainLB.Add("Eras");
            MainLB.Add("Goods");
            MainLB.Add("Institutions");
            MainLB.Add("Law Groups");
            MainLB.Add("Laws");
            MainLB.Add("Modifiers");
            MainLB.Add("Modifier Types");
            MainLB.Add("Pop Needs");
            MainLB.Add("Pop Types");
            MainLB.Add("Production Method Groups");
            MainLB.Add("Production Methods");
            MainLB.Add("Religions");
            MainLB.Add("State Traits");
            MainLB.Add("Technologies");
        }

        private void MainSearchBarTB_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            if (mainSelectedIndex == -1) { return; }

            if (string.IsNullOrEmpty(MainSearchBarTB.Texts) == false)
            {
                MainLB.Clear();
                foreach (string entry in MainData)
                {
                    if (entry.StartsWith(MainSearchBarTB.Texts))
                    {
                        MainLB.Add(entry);
                    }
                }
            }
            else if (MainSearchBarTB.Texts == "")
            {
                MainLB.Clear();
                foreach (string entry in MainData)
                {
                    MainLB.Add(entry);
                }
            }
        }

        //*
        private void VickySearchBarTB_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            SearchBarConfigs(VickySearchBarTB, VickyLB, BuildingGroupsDataV, BuildingsDataV, CanalsDataV, CulturesDataV, DecisionsDataV, DecreesDataV, ErasDataV, GoodsDataV, InstitutionsDataV, LawGroupsDataV, LawsDataV, ModifierDataV, ModifierTypeDataV, PopNeedsDataV, PopTypesDataV, ProductionMethodGroupsDataV, ProductionMethodsDataV, ReligionsDataV, StateTraitsDataV, TechDataV);
        }

        //*
        private void ProjSearchBarTB_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            SearchBarConfigs(ProjSearchBarTB, ProjectLB, BuildingGroupsDataP, BuildingsDataP, CanalsDataP, CulturesDataP, DecisionsDataP, DecreesDataP, ErasDataP, GoodsDataP, InstitutionsDataP, LawGroupsDataP, LawsDataP, ModifierDataP, ModifierTypeDataP, PopNeedsDataP, PopTypesDataP, ProductionMethodGroupsDataP, ProductionMethodsDataP, ReligionsDataP, StateTraitsDataP, TechDataP);
        }

        //*
        private void ModSearchBarTB_CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            SearchBarConfigs(ModSearchBarTB, ModLB, BuildingGroupsDataM, BuildingsDataM, CanalsDataM, CulturesDataM, DecisionsDataM, DecreesDataM, ErasDataM, GoodsDataM, InstitutionsDataM, LawGroupsDataM, LawsDataM, ModifierDataM, ModifierTypeDataM, PopNeedsDataM, PopTypesDataM, ProductionMethodGroupsDataM, ProductionMethodsDataM, ReligionsDataM, StateTraitsDataM, TechDataM);
        }

        // *
        private void SearchBarConfigs(CustomTextBox TB, CustomListBox LB, List<ClassBuildingGroups> BuildingGroupsData, List<ClassBuildings> BuildingsData, List<ClassCanals> CanalsData, List<ClassCultures> CulturesData, List<ClassDecisions> DecisionsData, List<ClassDecrees> DecreesData, List<ClassEras> ErasData, List<ClassGoods> GoodsData, List<ClassInstitutions> InstitutionData, List<ClassLawGroups> LawGroupsData, List<ClassLaws> LawsData, List<ClassModifiers> ModifierData, List<ClassModifiersType> ModifierTypeData, List<ClassPopNeeds> PopNeedsData, List<ClassPopTypes> PopTypesData, List<ClassProductionMethodGroups> ProductionMethodGroupsData, List<ClassProductionMethods> ProductionMethodsData, List<ClassReligions> ReligionsData, List<ClassStateTraits> StateTraitsData, List<ClassTech> TechData)
        {
            if (mainSelectedIndex == -1) { return; }

            switch (MainData[mainSelectedIndex].ToString())
            {
                case "Building Groups":
                    Functions.SearchBarSimpleConfig(BuildingGroupsData, TB, LB);
                    break;
                case "Buildings":
                    Functions.SearchBarSimpleConfig(BuildingsData, TB, LB);
                    break;
                case "Canals":
                    Functions.SearchBarSimpleConfig(CanalsData, TB, LB);
                    break;
                case "Cultures":
                    Functions.SearchBarSimpleConfig(CulturesData, TB, LB);
                    break;
                case "Decisions":
                    Functions.SearchBarSimpleConfig(DecisionsData, TB, LB);
                    break;
                case "Decrees":
                    Functions.SearchBarSimpleConfig(DecreesData, TB, LB);
                    break;
                case "Eras":
                    {
                        if (string.IsNullOrEmpty(TB.Texts) == false)
                        {
                            LB.Clear();
                            LB.Add(string.Format("{0,-20}{1,-20 }", "Era", "Cost"));

                            foreach (ClassEras entry in ErasData)
                            {
                                if (entry.Era.ToString().StartsWith(TB.Texts))
                                { LB.Add(string.Format("{0,-20}{1,-20 }", entry.Era, entry.Cost)); }
                            }
                        }
                        else if (TB.Texts == "")
                        {
                            LB.Clear();
                            LB.Add(string.Format("{0,-20}{1,-20 }", "Era", "Cost"));

                            foreach (ClassEras entry in ErasData)
                            {
                                if (entry.Era.ToString().StartsWith(TB.Texts))
                                { LB.Add(string.Format("{0,-20}{1,-20 }", entry.Era, entry.Cost)); }
                            }
                        }

                        break;
                    }
                case "Goods":
                    Functions.SearchBarSimpleConfig(GoodsData, TB, LB);
                    break;
                case "Institutions":
                    Functions.SearchBarSimpleConfig(InstitutionData, TB, LB);
                    break;
                case "Law Groups":
                    Functions.SearchBarSimpleConfig(LawGroupsData, TB, LB);
                    break;
                case "Laws":
                    Functions.SearchBarSimpleConfig(LawsData, TB, LB);
                    break;
                case "Modifiers":
                    Functions.SearchBarSimpleConfig(ModifierData, TB, LB);
                    break;
                case "Modifier Types":
                    Functions.SearchBarSimpleConfig(ModifierTypeData, TB, LB);
                    break;
                case "Pop Needs":
                    Functions.SearchBarSimpleConfig(PopNeedsData, TB, LB);
                    break;
                case "Pop Types":
                    Functions.SearchBarSimpleConfig(PopTypesData, TB, LB);
                    break;
                case "Production Method Groups":
                    Functions.SearchBarSimpleConfig(ProductionMethodGroupsData, TB, LB);
                    break;
                case "Production Methods":
                    Functions.SearchBarSimpleConfig(ProductionMethodsData, TB, LB);
                    break;
                case "Religions":
                    Functions.SearchBarSimpleConfig(ReligionsData, TB, LB);
                    break;
                case "State Traits":
                    Functions.SearchBarSimpleConfig(StateTraitsData, TB, LB);
                    break;
                case "Technologies":
                    Functions.SearchBarSimpleConfig(TechData, TB, LB);
                    break;
                default:
                    MainLB.Add("Error");
                    break;
            }
        }



        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // LB data *
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        // *
        private void Mod()
        {
            ModLB.Clear();
            if (ModPath != null)
            {
                switch (MainData[mainSelectedIndex].ToString())
                {
                    case "Building Groups":
                        {
                            BuildingGroupsDataM = new List<ClassBuildingGroups>();
                            Functions.ReadFilesCommon(ModPath + "\\common\\building_groups", BuildingGroupsDataM, new NoParse(), s => new ClassBuildingGroups(s,
                                LocalizationDataM != null ? (LocalizationDataM.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty
                                ), t => t.Name);
                            foreach (ClassBuildingGroups entry in BuildingGroupsDataM) { ModLB.Add(entry.Name); }

                            break;
                        }
                    case "Buildings":
                        {
                            BuildingsDataM = new List<ClassBuildings>();
                            Functions.ReadFilesCommon(ModPath + "\\common\\buildings", BuildingsDataM, new NoParse(), s => new ClassBuildings(s,
                                LocalizationDataM != null ? (LocalizationDataM.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty,
                                LocalizationDataM != null ? (LocalizationDataM.TryGetValue(s.Key + "_lens_option", out x) ? x : string.Empty) : string.Empty
                                ), t => t.Name);
                            foreach (ClassBuildings entry in BuildingsDataM) { ModLB.Add(entry.Name); }

                            break;
                        }
                    case "Canals":
                        {
                            CanalsDataM = new List<ClassCanals>();
                            Functions.ReadFilesCommon(ModPath + "\\common\\canals", CanalsDataM, new NoParse(), s => new ClassCanals(s,
                                LocalizationDataM != null ? (LocalizationDataM.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty
                                ), t => t.Name);
                            foreach (ClassCanals entry in CanalsDataM) { ModLB.Add(entry.Name); }

                            break;
                        }
                    case "Cultures":
                        {
                            CulturesDataM = new List<ClassCultures>();
                            Functions.ReadFilesCommon(ModPath + "\\common\\cultures", CulturesDataM, new NoParse(), s => new ClassCultures(s,
                                LocalizationDataM != null ? (LocalizationDataM.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty
                                ), t => t.Name);
                            foreach (ClassCultures entry in CulturesDataM) { ModLB.Add(entry.Name); }

                            break;
                        }
                    case "Decisions":
                        {
                            DecisionsDataM = new List<ClassDecisions>();
                            Functions.ReadFilesCommon(ModPath + "\\common\\decisions", DecisionsDataM, new NoParse(), s => new ClassDecisions(s,
                                LocalizationDataM != null ? (LocalizationDataM.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty,
                                LocalizationDataM != null ? (LocalizationDataM.TryGetValue(s.Key + "_desc", out x) ? x : string.Empty) : string.Empty,
                                LocalizationDataM != null ? (LocalizationDataM.TryGetValue(s.Key + "_tooltip", out x) ? x : string.Empty) : string.Empty
                                ), t => t.Name);
                            foreach (ClassDecisions entry in DecisionsDataM) { ModLB.Add(entry.Name); }

                            break;
                        }
                    case "Decrees":
                        {
                            DecreesDataM = new List<ClassDecrees>();
                            Functions.ReadFilesCommon(ModPath + "\\common\\decrees", DecreesDataM, new NoParse(), s => new ClassDecrees(s,
                                LocalizationDataM != null ? (LocalizationDataM.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty,
                                LocalizationDataM != null ? (LocalizationDataM.TryGetValue(s.Key + "_desc", out x) ? x : string.Empty) : string.Empty
                                ), t => t.Name);
                            foreach (ClassDecrees entry in DecreesDataM) { ModLB.Add(entry.Name); }

                            break;
                        }
                    case "Eras":
                        {
                            ErasDataM = new List<ClassEras>();
                            Functions.ReadFilesCommon(ModPath + "\\common\\technology\\eras", ErasDataM, new Parser(), s => new ClassEras(s), t => t.Era.ToString());
                            ModLB.Add(string.Format("{0,-20}{1,-20 }", "Era", "Cost"));
                            foreach (ClassEras eraEntry in ErasDataM) { ModLB.Add(string.Format("{0,-20}{1,-20 }", eraEntry.Era, eraEntry.Cost)); }

                            break;
                        }
                    case "Goods":
                        {
                            GoodsDataM = new List<ClassGoods>();
                            Functions.ReadFilesCommon(ModPath + "\\common\\goods", GoodsDataM, new Parser(), s => new ClassGoods(s,
                                LocalizationDataM != null ? (LocalizationDataM.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty), t => t.Name);
                            foreach (ClassGoods entry in GoodsDataM) { ModLB.Add(entry.Name); }

                            break;
                        }
                    case "Institutions":
                        {
                            InstitutionsDataM = new List<ClassInstitutions>();
                            Functions.ReadFilesCommon(ModPath + "\\common\\institutions", InstitutionsDataM, new Parser(), s => new ClassInstitutions(s,
                                LocalizationDataM != null ? (LocalizationDataM.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty), t => t.Name);
                            foreach (ClassInstitutions entry in InstitutionsDataM) { ModLB.Add(entry.Name); }

                            break;
                        }
                    case "Law Groups":
                        {
                            LawGroupsDataM = new List<ClassLawGroups>();
                            Functions.ReadFilesCommon(ModPath + "\\common\\law_groups", LawGroupsDataM, new NoParse(), s => new ClassLawGroups(s,
                                LocalizationDataM != null ? (LocalizationDataM.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty,
                                LocalizationDataM != null ? (LocalizationDataM.TryGetValue(s.Key + "_desc", out x) ? x : string.Empty) : string.Empty
                                ), t => t.Name);
                            foreach (ClassLawGroups entry in LawGroupsDataM) { ModLB.Add(entry.Name); }

                            break;
                        }
                    case "Law":
                        {
                            LawsDataM = new List<ClassLaws>();
                            Functions.ReadFilesCommon(ModPath + "\\common\\laws", LawsDataM, new NoParse(), s => new ClassLaws(s,
                                LocalizationDataM != null ? (LocalizationDataM.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty,
                                LocalizationDataM != null ? (LocalizationDataM.TryGetValue(s.Key + "_desc", out x) ? x : string.Empty) : string.Empty
                                ), t => t.Name);
                            foreach (ClassLaws entry in LawsDataM) { ModLB.Add(entry.Name); }

                            break;
                        }
                    case "Modifiers":
                        {
                            ModifierDataM = new List<ClassModifiers>();
                            Functions.ReadFilesCommon(ModPath + "\\common\\modifiers", ModifierDataM, new Parser(), s => new ClassModifiers(s,
                                LocalizationDataM != null ? (LocalizationDataM.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty,
                                LocalizationDataM != null ? (LocalizationDataM.TryGetValue(s.Key + "_desc", out x) ? x : string.Empty) : string.Empty), t => t.Name);
                            foreach (ClassModifiers entry in ModifierDataM) { ModLB.Add(entry.Name); }

                            break;
                        }
                    case "Modifier Types":
                        {
                            ModifierTypeDataM = new List<ClassModifiersType>();
                            Functions.ReadFilesCommon(ModPath + "\\common\\modifier_types", ModifierTypeDataM, new Parser(), s => new ClassModifiersType(s), t => t.Name);
                            foreach (ClassModifiersType entry in ModifierTypeDataM) { ModLB.Add(entry.Name); }

                            break;
                        }
                    case "Pop Needs":
                        {
                            PopNeedsDataM = new List<ClassPopNeeds>();
                            Functions.ReadFilesCommon(ModPath + "\\common\\pop_needs", PopNeedsDataM, new Parser(), s => new ClassPopNeeds(s,
                                LocalizationDataM != null ? (LocalizationDataM.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty), t => t.Name);
                            foreach (ClassPopNeeds entry in PopNeedsDataM) { ModLB.Add(entry.Name); }

                            break;
                        }
                    case "Pop Types":
                        {
                            PopTypesDataM = new List<ClassPopTypes>();
                            Functions.ReadFilesCommon(ModPath + "\\common\\pop_types", PopTypesDataM, new NoParse(), s => new ClassPopTypes(s,
                                LocalizationDataM != null ? (LocalizationDataM.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty,
                                LocalizationDataM != null ? (LocalizationDataM.TryGetValue(s.Key + "_desc", out x) ? x : string.Empty) : string.Empty,
                                LocalizationDataM != null ? (LocalizationDataM.TryGetValue(s.Key + "_only_icon", out x) ? x : string.Empty) : string.Empty,
                                LocalizationDataM != null ? (LocalizationDataM.TryGetValue(s.Key + "_no_icon", out x) ? x : string.Empty) : string.Empty,
                                LocalizationDataM != null ? (LocalizationDataM.TryGetValue(s.Key.ToUpper() + "_QUALIFICATIONS_DESC", out x) ? x : string.Empty) : string.Empty
                                ), t => t.Name);
                            foreach (ClassPopTypes entry in PopTypesDataM) { ModLB.Add(entry.Name); }

                            break;
                        }
                    case "Production Method Groups":
                        {
                            ProductionMethodGroupsDataM = new List<ClassProductionMethodGroups>();
                            Functions.ReadFilesCommon(ModPath + "\\common\\production_method_groups", ProductionMethodGroupsDataM, new Parser(), s => new ClassProductionMethodGroups(s,
                                LocalizationDataM != null ? (LocalizationDataM.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty
                                ), t => t.Name);
                            foreach (ClassProductionMethodGroups entry in ProductionMethodGroupsDataM) { ModLB.Add(entry.Name); }

                            break;
                        }
                    case "Production Methods":
                        {
                            ProductionMethodsDataM = new List<ClassProductionMethods>();
                            Functions.ReadFilesCommon(ModPath + "\\common\\production_methods", ProductionMethodsDataM, new NoParse(), s => new ClassProductionMethods(s,
                                LocalizationDataM != null ? (LocalizationDataM.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty
                                ), t => t.Name);
                            foreach (ClassProductionMethods entry in ProductionMethodsDataM) { ModLB.Add(entry.Name); }

                            break;
                        }
                    case "Religions":
                        {
                            ReligionsDataM = new List<ClassReligions>();
                            Functions.ReadFilesCommon(ModPath + "\\common\\religions", ReligionsDataM, new Parser(), s => new ClassReligions(s,
                                LocalizationDataM != null ? (LocalizationDataM.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty), t => t.Name);
                            foreach (ClassReligions entry in ReligionsDataM) { ModLB.Add(entry.Name); }

                            break;
                        }
                    case "State Traits":
                        {
                            StateTraitsDataM = new List<ClassStateTraits>();
                            Functions.ReadFilesCommon(ModPath + "\\common\\state_traits", StateTraitsDataM, new Parser(), s => new ClassStateTraits(s,
                                LocalizationDataM != null ? (LocalizationDataM.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty), t => t.Name);
                            foreach (ClassStateTraits entry in StateTraitsDataM) { ModLB.Add(entry.Name); }

                            break;
                        }
                    case "Technologies":
                        {
                            TechDataM = new List<ClassTech>();
                            Functions.ReadFilesCommon(ModPath + "\\common\\technology\\technologies", TechDataM, new Parser(), s => new ClassTech(s,
                                LocalizationDataM != null ? (LocalizationDataM.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty,
                                LocalizationDataM != null ? (LocalizationDataM.TryGetValue(s.Key + "_desc", out x) ? x : string.Empty) : string.Empty), t => t.Name);
                            foreach (ClassTech entry in TechDataM) { ModLB.Add(entry.Name); }

                            break;
                        }
                    default:
                        break;
                }
            }
        }

        // *
        private void MainLB_Click(object sender, string e)
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

            VickyLB.Clear();
            ProjectLB.Clear();
            ModLB.Clear();

            mainSelectedIndex = MainLB.SelectedIndex;

            switch (MainData[mainSelectedIndex].ToString())
            {
                case "Building Groups":
                    {
                        BuildingGroupsDataP = new List<ClassBuildingGroups>();
                        BuildingGroupsDataV = new List<ClassBuildingGroups>();

                        Functions.ReadFilesCommon(VickyPath + "\\game\\common\\building_groups", BuildingGroupsDataV, new NoParse(), s => new ClassBuildingGroups(s,
                            LocalizationDataV != null ? (LocalizationDataV.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty
                            ), t => t.Name);
                        Functions.ReadFilesCommon(ProjPath + "\\common\\building_groups", BuildingGroupsDataP, new NoParse(), s => new ClassBuildingGroups(s,
                            LocalizationDataP != null ? (LocalizationDataP.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty
                            ), t => t.Name);

                        foreach (ClassBuildingGroups Entry in BuildingGroupsDataV) { VickyLB.Add(Entry.Name); }
                        foreach (ClassBuildingGroups Entry in BuildingGroupsDataP) { ProjectLB.Add(Entry.Name); }

                        if (BuildingGroupsDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }
                        Mod();

                        break;
                    }
                case "Buildings":
                    {
                        BuildingsDataP = new List<ClassBuildings>();
                        BuildingsDataV = new List<ClassBuildings>();

                        Functions.ReadFilesCommon(VickyPath + "\\game\\common\\buildings", BuildingsDataV, new NoParse(), s => new ClassBuildings(s,
                            LocalizationDataV != null ? (LocalizationDataV.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty,
                            LocalizationDataV != null ? (LocalizationDataV.TryGetValue(s.Key + "_lens_option", out x) ? x : string.Empty) : string.Empty
                            ), t => t.Name);
                        Functions.ReadFilesCommon(ProjPath + "\\common\\buildings", BuildingsDataP, new NoParse(), s => new ClassBuildings(s,
                            LocalizationDataP != null ? (LocalizationDataP.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty,
                            LocalizationDataP != null ? (LocalizationDataP.TryGetValue(s.Key + "_lens_option", out x) ? x : string.Empty) : string.Empty
                            ), t => t.Name);

                        foreach (ClassBuildings Entry in BuildingsDataV) { VickyLB.Add(Entry.Name); }
                        foreach (ClassBuildings Entry in BuildingsDataP) { ProjectLB.Add(Entry.Name); }

                        if (BuildingsDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }
                        Mod();

                        break;
                    }
                case "Canals":
                    {
                        CanalsDataP = new List<ClassCanals>();
                        CanalsDataV = new List<ClassCanals>();

                        Functions.ReadFilesCommon(VickyPath + "\\game\\common\\canals", CanalsDataV, new NoParse(), s => new ClassCanals(s,
                            LocalizationDataV != null ? (LocalizationDataV.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty
                            ), t => t.Name);
                        Functions.ReadFilesCommon(ProjPath + "\\common\\canals", CanalsDataP, new NoParse(), s => new ClassCanals(s,
                            LocalizationDataP != null ? (LocalizationDataP.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty
                            ), t => t.Name);

                        foreach (ClassCanals Entry in CanalsDataV) { VickyLB.Add(Entry.Name); }
                        foreach (ClassCanals Entry in CanalsDataP) { ProjectLB.Add(Entry.Name); }

                        if (CanalsDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }
                        Mod();

                        break;
                    }
                case "Cultures":
                    {
                        CulturesDataP = new List<ClassCultures>();
                        CulturesDataV = new List<ClassCultures>();

                        Functions.ReadFilesCommon(VickyPath + "\\game\\common\\cultures", CulturesDataV, new NoParse(), s => new ClassCultures(s,
                            LocalizationDataV != null ? (LocalizationDataV.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty
                            ), t => t.Name);
                        Functions.ReadFilesCommon(ProjPath + "\\common\\Cultures", CulturesDataP, new NoParse(), s => new ClassCultures(s,
                            LocalizationDataP != null ? (LocalizationDataP.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty
                            ), t => t.Name);

                        foreach (ClassCultures Entry in CulturesDataV) { VickyLB.Add(Entry.Name); }
                        foreach (ClassCultures Entry in CulturesDataP) { ProjectLB.Add(Entry.Name); }

                        if (CulturesDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }
                        Mod();

                        break;
                    }
                case "Decisions":
                    {
                        DecisionsDataP = new List<ClassDecisions>();
                        DecisionsDataV = new List<ClassDecisions>();

                        Functions.ReadFilesCommon(VickyPath + "\\game\\common\\decisions", DecisionsDataV, new NoParse(), s => new ClassDecisions(s,
                            LocalizationDataV != null ? (LocalizationDataV.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty,
                            LocalizationDataV != null ? (LocalizationDataV.TryGetValue(s.Key + "_desc", out x) ? x : string.Empty) : string.Empty,
                            LocalizationDataV != null ? (LocalizationDataV.TryGetValue(s.Key + "_tooltip", out x) ? x : string.Empty) : string.Empty
                            ), t => t.Name);
                        Functions.ReadFilesCommon(ProjPath + "\\common\\decisions", DecisionsDataP, new NoParse(), s => new ClassDecisions(s,
                            LocalizationDataP != null ? (LocalizationDataP.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty,
                            LocalizationDataP != null ? (LocalizationDataP.TryGetValue(s.Key + "_desc", out x) ? x : string.Empty) : string.Empty,
                            LocalizationDataP != null ? (LocalizationDataP.TryGetValue(s.Key + "_tooltip", out x) ? x : string.Empty) : string.Empty
                            ), t => t.Name);

                        foreach (ClassDecisions Entry in DecisionsDataV) { VickyLB.Add(Entry.Name); }
                        foreach (ClassDecisions Entry in DecisionsDataP) { ProjectLB.Add(Entry.Name); }

                        if (DecisionsDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }
                        Mod();

                        break;
                    }
                case "Decrees":
                    {
                        DecreesDataP = new List<ClassDecrees>();
                        DecreesDataV = new List<ClassDecrees>();

                        Functions.ReadFilesCommon(VickyPath + "\\game\\common\\decrees", DecreesDataV, new NoParse(), s => new ClassDecrees(s,
                            LocalizationDataV != null ? (LocalizationDataV.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty,
                            LocalizationDataV != null ? (LocalizationDataV.TryGetValue(s.Key + "_desc", out x) ? x : string.Empty) : string.Empty
                            ), t => t.Name);
                        Functions.ReadFilesCommon(ProjPath + "\\common\\decrees", DecreesDataP, new NoParse(), s => new ClassDecrees(s,
                            LocalizationDataP != null ? (LocalizationDataP.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty,
                            LocalizationDataP != null ? (LocalizationDataP.TryGetValue(s.Key + "_desc", out x) ? x : string.Empty) : string.Empty
                            ), t => t.Name);

                        foreach (ClassDecrees Entry in DecreesDataV) { VickyLB.Add(Entry.Name); }
                        foreach (ClassDecrees Entry in DecreesDataP) { ProjectLB.Add(Entry.Name); }

                        if (DecreesDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }
                        Mod();

                        break;
                    }
                case "Eras":
                    {
                        ErasDataP = new List<ClassEras>();
                        ErasDataV = new List<ClassEras>();

                        Functions.ReadFilesCommon(VickyPath + "\\game\\common\\technology\\eras", ErasDataV, new Parser(), s => new ClassEras(s), t => t.Era.ToString());
                        Functions.ReadFilesCommon(ProjPath + "\\common\\technology\\eras", ErasDataP, new Parser(), s => new ClassEras(s), t => t.Era.ToString());

                        VickyLB.Add(string.Format("{0,-20}{1,-20 }", "Era", "Cost"));
                        foreach (ClassEras eraEntry in ErasDataV) { VickyLB.Add(string.Format("{0,-20}{1,-20 }", eraEntry.Era, eraEntry.Cost)); }
                        ProjectLB.Add(string.Format("{0,-20}{1,-20 }", "Era", "Cost"));
                        foreach (ClassEras eraEntry in ErasDataP) { ProjectLB.Add(string.Format("{0,-20}{1,-20 }", eraEntry.Era, eraEntry.Cost)); }

                        if (ErasDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }
                        Mod();

                        break;
                    }
                case "Goods":
                    {
                        GoodsDataP = new List<ClassGoods>();
                        GoodsDataV = new List<ClassGoods>();

                        Functions.ReadFilesCommon(VickyPath + "\\game\\common\\goods", GoodsDataV, new Parser(), s => new ClassGoods(s,
                            LocalizationDataV != null ? (LocalizationDataV.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty), t => t.Name);
                        Functions.ReadFilesCommon(ProjPath + "\\common\\goods", GoodsDataP, new Parser(), s => new ClassGoods(s,
                            LocalizationDataP != null ? (LocalizationDataP.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty), t => t.Name);

                        Functions.TextureMerger(VickyPath + "\\game\\", GoodsDataV);
                        Functions.TextureMerger(ProjPath + "\\", GoodsDataP);

                        foreach (ClassGoods entry in GoodsDataV) { VickyLB.Add(entry.Name); }
                        foreach (ClassGoods entry in GoodsDataP) { ProjectLB.Add(entry.Name); }

                        if (GoodsDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }
                        Mod();

                        break;
                    }
                case "Institutions":
                    {
                        ModifierTypeDataP = new List<ClassModifiersType>();
                        ModifierTypeDataV = new List<ClassModifiersType>();

                        Functions.ReadFilesCommon(VickyPath + "\\game\\common\\modifier_types", ModifierTypeDataV, new Parser(), s => new ClassModifiersType(s), t => t.Name);
                        Functions.ReadFilesCommon(ProjPath + "\\common\\modifier_types", ModifierTypeDataP, new Parser(), s => new ClassModifiersType(s), t => t.Name);

                        InstitutionsDataP = new List<ClassInstitutions>();
                        InstitutionsDataV = new List<ClassInstitutions>();

                        Functions.ReadFilesCommon(VickyPath + "\\game\\common\\institutions", InstitutionsDataV, new Parser(), s => new ClassInstitutions(s,
                            LocalizationDataV != null ? (LocalizationDataV.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty), t => t.Name);
                        Functions.ReadFilesCommon(ProjPath + "\\common\\institutions", InstitutionsDataP, new Parser(), s => new ClassInstitutions(s,
                            LocalizationDataP != null ? (LocalizationDataP.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty), t => t.Name);

                        Functions.TextureMerger(VickyPath + "\\game\\", InstitutionsDataV);
                        Functions.TextureMerger(ProjPath + "\\", InstitutionsDataP);
                        Functions.BackTextureMerger(VickyPath + "\\game\\", InstitutionsDataV);
                        Functions.BackTextureMerger(ProjPath + "\\", InstitutionsDataP);

                        foreach (ClassInstitutions entry in InstitutionsDataV) { VickyLB.Add(entry.Name); }
                        foreach (ClassInstitutions entry in InstitutionsDataP) { ProjectLB.Add(entry.Name); }

                        if (InstitutionsDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }
                        Mod();

                        break;
                    }
                case "Law Groups":
                    {
                        LawGroupsDataP = new List<ClassLawGroups>();
                        LawGroupsDataV = new List<ClassLawGroups>();

                        Functions.ReadFilesCommon(VickyPath + "\\game\\common\\law_groups", LawGroupsDataV, new NoParse(), s => new ClassLawGroups(s,
                            LocalizationDataV != null ? (LocalizationDataV.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty,
                            LocalizationDataV != null ? (LocalizationDataV.TryGetValue(s.Key + "_desc", out x) ? x : string.Empty) : string.Empty
                            ), t => t.Name);
                        Functions.ReadFilesCommon(ProjPath + "\\common\\law_groups", LawGroupsDataP, new NoParse(), s => new ClassLawGroups(s,
                            LocalizationDataP != null ? (LocalizationDataP.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty,
                            LocalizationDataP != null ? (LocalizationDataP.TryGetValue(s.Key + "_desc", out x) ? x : string.Empty) : string.Empty
                            ), t => t.Name);

                        foreach (ClassLawGroups Entry in LawGroupsDataV) { VickyLB.Add(Entry.Name); }
                        foreach (ClassLawGroups Entry in LawGroupsDataP) { ProjectLB.Add(Entry.Name); }

                        if (LawGroupsDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }
                        Mod();

                        break;
                    }
                case "Laws":
                    {
                        LawsDataP = new List<ClassLaws>();
                        LawsDataV = new List<ClassLaws>();

                        Functions.ReadFilesCommon(VickyPath + "\\game\\common\\laws", LawsDataV, new NoParse(), s => new ClassLaws(s,
                            LocalizationDataV != null ? (LocalizationDataV.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty,
                            LocalizationDataV != null ? (LocalizationDataV.TryGetValue(s.Key + "_desc", out x) ? x : string.Empty) : string.Empty
                            ), t => t.Name);
                        Functions.ReadFilesCommon(ProjPath + "\\common\\laws", LawsDataP, new NoParse(), s => new ClassLaws(s,
                            LocalizationDataP != null ? (LocalizationDataP.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty,
                            LocalizationDataP != null ? (LocalizationDataP.TryGetValue(s.Key + "_desc", out x) ? x : string.Empty) : string.Empty
                            ), t => t.Name);

                        foreach (ClassLaws Entry in LawsDataV) { VickyLB.Add(Entry.Name); }
                        foreach (ClassLaws Entry in LawsDataP) { ProjectLB.Add(Entry.Name); }

                        if (LawsDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }
                        Mod();

                        break;
                    }
                case "Modifiers":
                    {
                        ModifierTypeDataP = new List<ClassModifiersType>();
                        ModifierTypeDataV = new List<ClassModifiersType>();

                        Functions.ReadFilesCommon(VickyPath + "\\game\\common\\modifier_types", ModifierTypeDataV, new Parser(), s => new ClassModifiersType(s), t => t.Name);
                        Functions.ReadFilesCommon(ProjPath + "\\common\\modifier_types", ModifierTypeDataP, new Parser(), s => new ClassModifiersType(s), t => t.Name);

                        ModifierDataP = new List<ClassModifiers>();
                        ModifierDataV = new List<ClassModifiers>();

                        Functions.ReadFilesCommon(VickyPath + "\\game\\common\\modifiers", ModifierDataV, new Parser(), s => new ClassModifiers(s,
                            LocalizationDataV != null ? (LocalizationDataV.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty,
                            LocalizationDataV != null ? (LocalizationDataV.TryGetValue(s.Key + "_desc", out x) ? x : string.Empty) : string.Empty), t => t.Name);
                        Functions.ReadFilesCommon(ProjPath + "\\common\\modifiers", ModifierDataP, new Parser(), s => new ClassModifiers(s,
                            LocalizationDataP != null ? (LocalizationDataP.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty,
                            LocalizationDataP != null ? (LocalizationDataP.TryGetValue(s.Key + "_desc", out x) ? x : string.Empty) : string.Empty), t => t.Name);

                        Functions.TextureMerger(VickyPath + "\\game\\", ModifierDataV);
                        Functions.TextureMerger(ProjPath + "\\", ModifierDataP);

                        foreach (ClassModifiers entry in ModifierDataV) { VickyLB.Add(entry.Name); }
                        foreach (ClassModifiers entry in ModifierDataP) { ProjectLB.Add(entry.Name); }

                        if (ModifierDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }
                        Mod();

                        break;
                    }
                case "Modifier Types":
                    {
                        ModifierTypeDataP = new List<ClassModifiersType>();
                        ModifierTypeDataV = new List<ClassModifiersType>();

                        Functions.ReadFilesCommon(VickyPath + "\\game\\common\\modifier_types", ModifierTypeDataV, new Parser(), s => new ClassModifiersType(s), t => t.Name);
                        Functions.ReadFilesCommon(ProjPath + "\\common\\modifier_types", ModifierTypeDataP, new Parser(), s => new ClassModifiersType(s), t => t.Name);

                        //new ExtraFunctions().Modifi(ModifierTypeDataV);

                        foreach (ClassModifiersType entry in ModifierTypeDataV) { VickyLB.Add(entry.Name); }
                        foreach (ClassModifiersType entry in ModifierTypeDataP) { ProjectLB.Add(entry.Name); }

                        if (ModifierTypeDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }
                        Mod();

                        break;
                    }
                case "Pop Needs":
                    {
                        GoodsDataP = new List<ClassGoods>();
                        GoodsDataV = new List<ClassGoods>();

                        Functions.ReadFilesCommon(VickyPath + "\\game\\common\\goods", GoodsDataV, new Parser(), s => new ClassGoods(s,
                            LocalizationDataV != null ? (LocalizationDataV.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty), t => t.Name);
                        Functions.ReadFilesCommon(ProjPath + "\\common\\goods", GoodsDataP, new Parser(), s => new ClassGoods(s,
                            LocalizationDataP != null ? (LocalizationDataP.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty), t => t.Name);

                        PopNeedsDataP = new List<ClassPopNeeds>();
                        PopNeedsDataV = new List<ClassPopNeeds>();

                        Functions.ReadFilesCommon(VickyPath + "\\game\\common\\pop_needs", PopNeedsDataV, new Parser(), s => new ClassPopNeeds(s,
                            LocalizationDataV != null ? (LocalizationDataV.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty), t => t.Name);
                        Functions.ReadFilesCommon(ProjPath + "\\common\\pop_needs", PopNeedsDataP, new Parser(), s => new ClassPopNeeds(s,
                            LocalizationDataP != null ? (LocalizationDataP.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty), t => t.Name);

                        foreach (ClassPopNeeds Entry in PopNeedsDataV) { VickyLB.Add(Entry.Name); }
                        foreach (ClassPopNeeds Entry in PopNeedsDataP) { ProjectLB.Add(Entry.Name); }

                        if (PopNeedsDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }
                        Mod();

                        break;
                    }
                case "Pop Types":
                    {
                        PopTypesDataP = new List<ClassPopTypes>();
                        PopTypesDataV = new List<ClassPopTypes>();

                        Functions.ReadFilesCommon(VickyPath + "\\game\\common\\pop_types", PopTypesDataV, new NoParse(), s => new ClassPopTypes(s,
                            LocalizationDataV != null ? (LocalizationDataV.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty,
                            LocalizationDataV != null ? (LocalizationDataV.TryGetValue(s.Key + "_desc", out x) ? x : string.Empty) : string.Empty,
                            LocalizationDataV != null ? (LocalizationDataV.TryGetValue(s.Key + "_only_icon", out x) ? x : string.Empty) : string.Empty,
                            LocalizationDataV != null ? (LocalizationDataV.TryGetValue(s.Key + "_no_icon", out x) ? x : string.Empty) : string.Empty,
                            LocalizationDataV != null ? (LocalizationDataV.TryGetValue(s.Key.ToUpper() + "_QUALIFICATIONS_DESC", out x) ? x : string.Empty) : string.Empty
                            ), t => t.Name);
                        Functions.ReadFilesCommon(ProjPath + "\\common\\pop_types", PopTypesDataP, new NoParse(), s => new ClassPopTypes(s,
                            LocalizationDataP != null ? (LocalizationDataP.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty,
                            LocalizationDataP != null ? (LocalizationDataP.TryGetValue(s.Key + "_desc", out x) ? x : string.Empty) : string.Empty,
                            LocalizationDataP != null ? (LocalizationDataP.TryGetValue(s.Key + "_only_icon", out x) ? x : string.Empty) : string.Empty,
                            LocalizationDataP != null ? (LocalizationDataP.TryGetValue(s.Key + "_no_icon", out x) ? x : string.Empty) : string.Empty,
                            LocalizationDataP != null ? (LocalizationDataP.TryGetValue(s.Key.ToUpper() + "_QUALIFICATIONS_DESC", out x) ? x : string.Empty) : string.Empty
                            ), t => t.Name);

                        foreach (ClassPopTypes Entry in PopTypesDataV) { VickyLB.Add(Entry.Name); }
                        foreach (ClassPopTypes Entry in PopTypesDataP) { ProjectLB.Add(Entry.Name); }

                        if (PopTypesDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }
                        Mod();

                        break;
                    }
                case "Production Method Groups":
                    {
                        ProductionMethodsDataP = new List<ClassProductionMethods>();
                        ProductionMethodsDataV = new List<ClassProductionMethods>();

                        Functions.ReadFilesCommon(VickyPath + "\\game\\common\\production_methods", ProductionMethodsDataV, new NoParse(), s => new ClassProductionMethods(s,
                            LocalizationDataV != null ? (LocalizationDataV.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty
                            ), t => t.Name);
                        Functions.ReadFilesCommon(ProjPath + "\\common\\production_methods", ProductionMethodsDataP, new NoParse(), s => new ClassProductionMethods(s,
                            LocalizationDataP != null ? (LocalizationDataP.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty
                            ), t => t.Name);

                        ProductionMethodGroupsDataP = new List<ClassProductionMethodGroups>();
                        ProductionMethodGroupsDataV = new List<ClassProductionMethodGroups>();

                        Functions.ReadFilesCommon(VickyPath + "\\game\\common\\production_method_groups", ProductionMethodGroupsDataV, new Parser(), s => new ClassProductionMethodGroups(s,
                            LocalizationDataV != null ? (LocalizationDataV.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty
                            ), t => t.Name);
                        Functions.ReadFilesCommon(ProjPath + "\\common\\production_method_groups", ProductionMethodGroupsDataP, new Parser(), s => new ClassProductionMethodGroups(s,
                            LocalizationDataP != null ? (LocalizationDataP.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty
                            ), t => t.Name);

                        foreach (ClassProductionMethodGroups Entry in ProductionMethodGroupsDataV) { VickyLB.Add(Entry.Name); }
                        foreach (ClassProductionMethodGroups Entry in ProductionMethodGroupsDataP) { ProjectLB.Add(Entry.Name); }

                        if (ProductionMethodGroupsDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }
                        Mod();

                        break;
                    }
                case "Production Methods":
                    {
                        ProductionMethodsDataP = new List<ClassProductionMethods>();
                        ProductionMethodsDataV = new List<ClassProductionMethods>();

                        Functions.ReadFilesCommon(VickyPath + "\\game\\common\\production_methods", ProductionMethodsDataV, new NoParse(), s => new ClassProductionMethods(s,
                            LocalizationDataV != null ? (LocalizationDataV.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty
                            ), t => t.Name);
                        Functions.ReadFilesCommon(ProjPath + "\\common\\production_methods", ProductionMethodsDataP, new NoParse(), s => new ClassProductionMethods(s,
                            LocalizationDataP != null ? (LocalizationDataP.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty
                            ), t => t.Name);

                        foreach (ClassProductionMethods Entry in ProductionMethodsDataV) { VickyLB.Add(Entry.Name); }
                        foreach (ClassProductionMethods Entry in ProductionMethodsDataP) { ProjectLB.Add(Entry.Name); }

                        if (ProductionMethodsDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }
                        Mod();

                        break;
                    }
                case "Religions":
                    {
                        GoodsDataP = new List<ClassGoods>();
                        GoodsDataV = new List<ClassGoods>();

                        Functions.ReadFilesCommon(VickyPath + "\\game\\common\\goods", GoodsDataV, new Parser(), s => new ClassGoods(s,
                            LocalizationDataV != null ? (LocalizationDataV.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty), t => t.Name);
                        Functions.ReadFilesCommon(ProjPath + "\\common\\goods", GoodsDataP, new Parser(), s => new ClassGoods(s,
                            LocalizationDataP != null ? (LocalizationDataP.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty), t => t.Name);

                        ReligionsDataP = new List<ClassReligions>();
                        ReligionsDataV = new List<ClassReligions>();

                        Functions.ReadFilesCommon(VickyPath + "\\game\\common\\religions", ReligionsDataV, new Parser(), s => new ClassReligions(s,
                            LocalizationDataV != null ? (LocalizationDataV.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty), t => t.Name);
                        Functions.ReadFilesCommon(ProjPath + "\\common\\religions", ReligionsDataP, new Parser(), s => new ClassReligions(s,
                            LocalizationDataP != null ? (LocalizationDataP.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty), t => t.Name);

                        Functions.TextureMerger(VickyPath + "\\game\\", ReligionsDataV);
                        Functions.TextureMerger(ProjPath + "\\", ReligionsDataP);

                        TraitsAdder(); // temp

                        foreach (ClassReligions Entry in ReligionsDataV) { VickyLB.Add(Entry.Name); }
                        foreach (ClassReligions Entry in ReligionsDataP) { ProjectLB.Add(Entry.Name); }

                        if (ReligionsDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }
                        Mod();

                        break;
                    }
                case "State Traits":
                    {
                        TechDataP = new List<ClassTech>();
                        TechDataV = new List<ClassTech>();
                        ModifierTypeDataP = new List<ClassModifiersType>();
                        ModifierTypeDataV = new List<ClassModifiersType>();
                        StateTraitsDataP = new List<ClassStateTraits>();
                        StateTraitsDataV = new List<ClassStateTraits>();

                        Functions.ReadFilesCommon(VickyPath + "\\game\\common\\modifier_types", ModifierTypeDataV, new Parser(), s => new ClassModifiersType(s), t => t.Name);
                        Functions.ReadFilesCommon(ProjPath + "\\common\\modifier_types", ModifierTypeDataP, new Parser(), s => new ClassModifiersType(s), t => t.Name);

                        Functions.ReadFilesCommon(VickyPath + "\\game\\common\\technology\\technologies", TechDataV, new Parser(), s => new ClassTech(s,
                            LocalizationDataV != null ? (LocalizationDataV.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty,
                            LocalizationDataV != null ? (LocalizationDataV.TryGetValue(s.Key + "_desc", out x) ? x : string.Empty) : string.Empty), t => t.Name);
                        Functions.ReadFilesCommon(ProjPath + "\\common\\technology\\technologies", TechDataP, new Parser(), s => new ClassTech(s,
                            LocalizationDataP != null ? (LocalizationDataP.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty,
                            LocalizationDataP != null ? (LocalizationDataP.TryGetValue(s.Key + "_desc", out x) ? x : string.Empty) : string.Empty), t => t.Name);

                        Functions.ReadFilesCommon(VickyPath + "\\game\\common\\state_traits", StateTraitsDataV, new Parser(), s => new ClassStateTraits(s,
                            LocalizationDataV != null ? (LocalizationDataV.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty), t => t.Name);
                        Functions.ReadFilesCommon(ProjPath + "\\common\\state_traits", StateTraitsDataP, new Parser(), s => new ClassStateTraits(s,
                            LocalizationDataP != null ? (LocalizationDataP.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty), t => t.Name);

                        Functions.TextureMerger(VickyPath + "\\game\\", StateTraitsDataV);
                        Functions.TextureMerger(ProjPath + "\\", StateTraitsDataP);

                        foreach (ClassStateTraits entry in StateTraitsDataV) { VickyLB.Add(entry.Name); }
                        foreach (ClassStateTraits entry in StateTraitsDataP) { ProjectLB.Add(entry.Name); }

                        if (StateTraitsDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }
                        Mod();

                        break;
                    }
                case "Technologies":
                    {
                        TechDataP = new List<ClassTech>();
                        TechDataV = new List<ClassTech>();
                        ErasDataP = new List<ClassEras>();
                        ErasDataV = new List<ClassEras>();
                        ModifierTypeDataP = new List<ClassModifiersType>();
                        ModifierTypeDataV = new List<ClassModifiersType>();

                        Functions.ReadFilesCommon(VickyPath + "\\game\\common\\modifier_types", ModifierTypeDataV, new Parser(), s => new ClassModifiersType(s), t => t.Name);
                        Functions.ReadFilesCommon(ProjPath + "\\common\\modifier_types", ModifierTypeDataP, new Parser(), s => new ClassModifiersType(s), t => t.Name);

                        Functions.ReadFilesCommon(VickyPath + "\\game\\common\\technology\\eras", ErasDataV, new Parser(), s => new ClassEras(s), t => t.Era.ToString());
                        Functions.ReadFilesCommon(ProjPath + "\\common\\technology\\eras", ErasDataP, new Parser(), s => new ClassEras(s), t => t.Era.ToString());

                        Functions.ReadFilesCommon(VickyPath + "\\game\\common\\technology\\technologies", TechDataV, new Parser(), s => new ClassTech(s,
                            LocalizationDataV != null ? (LocalizationDataV.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty,
                            LocalizationDataV != null ? (LocalizationDataV.TryGetValue(s.Key + "_desc", out x) ? x : string.Empty) : string.Empty), t => t.Name);
                        Functions.ReadFilesCommon(ProjPath + "\\common\\technology\\technologies", TechDataP, new Parser(), s => new ClassTech(s,
                            LocalizationDataP != null ? (LocalizationDataP.TryGetValue(s.Key, out string x) ? x : string.Empty) : string.Empty,
                            LocalizationDataP != null ? (LocalizationDataP.TryGetValue(s.Key + "_desc", out x) ? x : string.Empty) : string.Empty), t => t.Name);

                        Functions.TextureMerger(VickyPath + "\\game\\", TechDataV);
                        Functions.TextureMerger(ProjPath + "\\", TechDataP);

                        foreach (ClassTech entry in TechDataV) { VickyLB.Add(entry.Name); }
                        foreach (ClassTech entry in TechDataP) { ProjectLB.Add(entry.Name); }

                        if (TechDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }
                        Mod();

                        break;
                    }
                default:
                    MainLB.Add("Error");
                    break;
            }
        }

        //*
        private void VickyLB_Click(object sender, string e)
        {
            DoubleClickList(VickyLB, VickyPath, vickySelectedIndex, BuildingGroupsDataV, BuildingsDataV, CanalsDataV, CulturesDataV, DecisionsDataV, DecreesDataV, ErasDataV, GoodsDataV, InstitutionsDataV, LawGroupsDataV, LawsDataV, ModifierDataV, ModifierTypeDataV, PopNeedsDataV, PopTypesDataV, ProductionMethodGroupsDataV, ProductionMethodsDataV, ReligionsDataV, StateTraitsDataV, TechDataV);
        }

        //*
        private void ProjectLB_Click(object sender, string e)
        {
            DoubleClickList(ProjectLB, ProjPath, projSelectedIndex, BuildingGroupsDataP, BuildingsDataP, CanalsDataP, CulturesDataP, DecisionsDataP, DecreesDataP, ErasDataP, GoodsDataP, InstitutionsDataP, LawGroupsDataP, LawsDataP, ModifierDataP, ModifierTypeDataP, PopNeedsDataP, PopTypesDataP, ProductionMethodGroupsDataP, ProductionMethodsDataP, ReligionsDataP, StateTraitsDataP, TechDataP);
        }

        //*
        private void ModLB_DoubleClick(object sender, string e)
        {
            DoubleClickList(ModLB, ModPath, modSelectedIndex, BuildingGroupsDataM, BuildingsDataM, CanalsDataM, CulturesDataM, DecisionsDataM, DecreesDataM, ErasDataM, GoodsDataM, InstitutionsDataP, LawGroupsDataP, LawsDataP, ModifierDataM, ModifierTypeDataM, PopNeedsDataM, PopTypesDataM, ProductionMethodGroupsDataM, ProductionMethodsDataM, ReligionsDataM, StateTraitsDataM, TechDataM);
        }

        //*
        private void DoubleClickList(CustomListBox ListBox, string path, int selectedIndex, List<ClassBuildingGroups> BuildingGroupsData, List<ClassBuildings> BuildingsData, List<ClassCanals> CanalsData, List<ClassCultures> CulturesData, List<ClassDecisions> DecisionsData, List<ClassDecrees> DecreesData, List<ClassEras> ErasData, List<ClassGoods> GoodsData, List<ClassInstitutions> InstitutionsData, List<ClassLawGroups> LawGroupsData, List<ClassLaws> LawsData, List<ClassModifiers> ModifierData, List<ClassModifiersType> ModifierTypeData, List<ClassPopNeeds> PopNeedsData, List<ClassPopTypes> PopTypesData, List<ClassProductionMethodGroups> ProductionMethodGroupsData, List<ClassProductionMethods> ProductionMethodsData, List<ClassReligions> ReligionsData, List<ClassStateTraits> StateTraitsData, List<ClassTech> TechData)
        {
            if (mainSelectedIndex == -1) { return; }
            SaveStatus = 2;

            if (path != null)
            {
                switch (MainData[mainSelectedIndex].ToString())
                {
                    case "Building Groups":
                        {
                            if (ListBox.Count == 0) { return; }

                            if (ListBox.SelectedIndex == -1) { selectedIndex = 0; ListBox.SelectedIndex = 0; } else { selectedIndex = ListBox.SelectedIndex; }

                            using (BuildingGroupsForm form = new BuildingGroupsForm())
                            {
                                int i;
                                i = Functions.hasNameIndex(BuildingGroupsData, ListBox[selectedIndex].ToString());
                                form.BuildingGroupsListP = BuildingGroupsDataP;
                                form.local = new ClassBuildingGroups(BuildingGroupsData[i]);
                                form.ShowDialog();
                                ClassBuildingGroups j = form.ReturnValue();
                                if (j != null)
                                {
                                    i = Functions.hasNameIndex(BuildingGroupsDataP, j.Name); // Index to change
                                    if (i == -1)
                                    {
                                        BuildingGroupsDataP.Add(new ClassBuildingGroups(j));
                                        BuildingGroupsDataP.Sort(delegate (ClassBuildingGroups t1, ClassBuildingGroups t2)
                                        {
                                            return (t1.Name.CompareTo(t2.Name));
                                        });
                                        ProjectLB.Clear();
                                        foreach (ClassBuildingGroups entry in BuildingGroupsDataP) { ProjectLB.Add(entry.Name); }
                                    }
                                    else
                                    {
                                        BuildingGroupsDataP[i] = j;
                                        ProjectLB.Clear();
                                        foreach (ClassBuildingGroups entry in BuildingGroupsDataP) { ProjectLB.Add(entry.Name); }
                                    }
                                }
                            }

                            if (BuildingGroupsDataP.Count == 0) { DeleteBT.Enabled = false; }
                            else { DeleteBT.Enabled = true; }

                            break;
                        }
                    case "Buildings":
                        {
                            if (ListBox.Count == 0) { return; }

                            if (ListBox.SelectedIndex == -1) { selectedIndex = 0; ListBox.SelectedIndex = 0; } else { selectedIndex = ListBox.SelectedIndex; }

                            using (BuildingsForm form = new BuildingsForm())
                            {
                                int i;
                                i = Functions.hasNameIndex(BuildingsData, ListBox[selectedIndex].ToString());
                                form.BuildingsListP = BuildingsDataP;
                                form.local = new ClassBuildings(BuildingsData[i]);
                                form.ShowDialog();
                                ClassBuildings j = form.ReturnValue();
                                if (j != null)
                                {
                                    i = Functions.hasNameIndex(BuildingsDataP, j.Name); // Index to change
                                    if (i == -1)
                                    {
                                        BuildingsDataP.Add(new ClassBuildings(j));
                                        BuildingsDataP.Sort(delegate (ClassBuildings t1, ClassBuildings t2)
                                        {
                                            return (t1.Name.CompareTo(t2.Name));
                                        });
                                        ProjectLB.Clear();
                                        foreach (ClassBuildings entry in BuildingsDataP) { ProjectLB.Add(entry.Name); }
                                    }
                                    else
                                    {
                                        BuildingsDataP[i] = j;
                                        ProjectLB.Clear();
                                        foreach (ClassBuildings entry in BuildingsDataP) { ProjectLB.Add(entry.Name); }
                                    }
                                }
                            }

                            if (BuildingsDataP.Count == 0) { DeleteBT.Enabled = false; }
                            else { DeleteBT.Enabled = true; }

                            break;
                        }
                    case "Canals":
                        {
                            if (ListBox.Count == 0) { return; }

                            if (ListBox.SelectedIndex == -1) { selectedIndex = 0; ListBox.SelectedIndex = 0; } else { selectedIndex = ListBox.SelectedIndex; }

                            using (CanalsForm form = new CanalsForm())
                            {
                                int i;
                                i = Functions.hasNameIndex(CanalsData, ListBox[selectedIndex].ToString());
                                form.CanalsListP = CanalsDataP;
                                form.local = new ClassCanals(CanalsData[i]);
                                form.ShowDialog();
                                ClassCanals j = form.ReturnValue();
                                if (j != null)
                                {
                                    i = Functions.hasNameIndex(CanalsDataP, j.Name); // Index to change
                                    if (i == -1)
                                    {
                                        CanalsDataP.Add(new ClassCanals(j));
                                        CanalsDataP.Sort(delegate (ClassCanals t1, ClassCanals t2)
                                        {
                                            return (t1.Name.CompareTo(t2.Name));
                                        });
                                        ProjectLB.Clear();
                                        foreach (ClassCanals entry in CanalsDataP) { ProjectLB.Add(entry.Name); }
                                    }
                                    else
                                    {
                                        CanalsDataP[i] = j;
                                        ProjectLB.Clear();
                                        foreach (ClassCanals entry in CanalsDataP) { ProjectLB.Add(entry.Name); }
                                    }
                                }
                            }

                            if (CanalsDataP.Count == 0) { DeleteBT.Enabled = false; }
                            else { DeleteBT.Enabled = true; }

                            break;
                        }
                    case "Cultures":
                        {
                            if (ListBox.Count == 0) { return; }

                            if (ListBox.SelectedIndex == -1) { selectedIndex = 0; ListBox.SelectedIndex = 0; } else { selectedIndex = ListBox.SelectedIndex; }

                            using (CulturesForm form = new CulturesForm())
                            {
                                int i;
                                i = Functions.hasNameIndex(CulturesData, ListBox[selectedIndex].ToString());
                                form.CulturesListP = CulturesDataP;
                                form.local = new ClassCultures(CulturesData[i]);
                                form.ShowDialog();
                                ClassCultures j = form.ReturnValue();
                                if (j != null)
                                {
                                    i = Functions.hasNameIndex(CulturesDataP, j.Name); // Index to change
                                    if (i == -1)
                                    {
                                        CulturesDataP.Add(new ClassCultures(j));
                                        CulturesDataP.Sort(delegate (ClassCultures t1, ClassCultures t2)
                                        {
                                            return (t1.Name.CompareTo(t2.Name));
                                        });
                                        ProjectLB.Clear();
                                        foreach (ClassCultures entry in CulturesDataP) { ProjectLB.Add(entry.Name); }
                                    }
                                    else
                                    {
                                        CulturesDataP[i] = j;
                                        ProjectLB.Clear();
                                        foreach (ClassCultures entry in CulturesDataP) { ProjectLB.Add(entry.Name); }
                                    }
                                }
                            }

                            if (CulturesDataP.Count == 0) { DeleteBT.Enabled = false; }
                            else { DeleteBT.Enabled = true; }

                            break;
                        }
                    case "Decisions":
                        {
                            if (ListBox.Count == 0) { return; }

                            if (ListBox.SelectedIndex == -1) { selectedIndex = 0; ListBox.SelectedIndex = 0; } else { selectedIndex = ListBox.SelectedIndex; }

                            using (DecisionsForm form = new DecisionsForm())
                            {
                                int i;
                                i = Functions.hasNameIndex(DecisionsData, ListBox[selectedIndex].ToString());
                                form.DecisionsListP = DecisionsDataP;
                                form.local = new ClassDecisions(DecisionsData[i]);
                                form.ShowDialog();
                                ClassDecisions j = form.ReturnValue();
                                if (j != null)
                                {
                                    i = Functions.hasNameIndex(DecisionsDataP, j.Name); // Index to change
                                    if (i == -1)
                                    {
                                        DecisionsDataP.Add(new ClassDecisions(j));
                                        DecisionsDataP.Sort(delegate (ClassDecisions t1, ClassDecisions t2)
                                        {
                                            return (t1.Name.CompareTo(t2.Name));
                                        });
                                        ProjectLB.Clear();
                                        foreach (ClassDecisions entry in DecisionsDataP) { ProjectLB.Add(entry.Name); }
                                    }
                                    else
                                    {
                                        DecisionsDataP[i] = j;
                                        ProjectLB.Clear();
                                        foreach (ClassDecisions entry in DecisionsDataP) { ProjectLB.Add(entry.Name); }
                                    }
                                }
                            }

                            if (DecisionsDataP.Count == 0) { DeleteBT.Enabled = false; }
                            else { DeleteBT.Enabled = true; }

                            break;
                        }
                    case "Decrees":
                        {
                            if (ListBox.Count == 0) { return; }

                            if (ListBox.SelectedIndex == -1) { selectedIndex = 0; ListBox.SelectedIndex = 0; } else { selectedIndex = ListBox.SelectedIndex; }

                            using (DecreesForm form = new DecreesForm())
                            {
                                int i;
                                i = Functions.hasNameIndex(DecreesData, ListBox[selectedIndex].ToString());
                                form.DecreesListP = DecreesDataP;
                                form.local = new ClassDecrees(DecreesData[i]);
                                form.ShowDialog();
                                ClassDecrees j = form.ReturnValue();
                                if (j != null)
                                {
                                    i = Functions.hasNameIndex(DecreesDataP, j.Name); // Index to change
                                    if (i == -1)
                                    {
                                        DecreesDataP.Add(new ClassDecrees(j));
                                        DecreesDataP.Sort(delegate (ClassDecrees t1, ClassDecrees t2)
                                        {
                                            return (t1.Name.CompareTo(t2.Name));
                                        });
                                        ProjectLB.Clear();
                                        foreach (ClassDecrees entry in DecreesDataP) { ProjectLB.Add(entry.Name); }
                                    }
                                    else
                                    {
                                        DecreesDataP[i] = j;
                                        ProjectLB.Clear();
                                        foreach (ClassDecrees entry in DecreesDataP) { ProjectLB.Add(entry.Name); }
                                    }
                                }
                            }

                            if (DecreesDataP.Count == 0) { DeleteBT.Enabled = false; }
                            else { DeleteBT.Enabled = true; }

                            break;
                        }
                    case "Eras":
                        {
                            if (ListBox.SelectedIndex == 0) { return; }

                            if (ListBox.Count == 1) { return; }

                            if (ListBox.SelectedIndex == -1) { selectedIndex = 1; ListBox.SelectedIndex = 1; } else { selectedIndex = ListBox.SelectedIndex; }

                            using (EraForm form = new EraForm())
                            {
                                int i;
                                i = Functions.hasNameIndex(ErasData, int.Parse(ListBox[selectedIndex].ToString().Substring(0, 20)).ToString());
                                form.local = new ClassEras(ErasData[i].Era, ErasData[i].Cost);
                                form.ShowDialog();
                                ClassEras j = form.ReturnValue();
                                if (j != null)
                                {
                                    i = Functions.hasNameIndex(ErasDataP, j.Era.ToString()); // Index to change
                                    if (i == -1)
                                    {
                                        ErasDataP.Add(new ClassEras(j.Era, j.Cost));
                                        ErasDataP.Sort(delegate (ClassEras t1, ClassEras t2)
                                        {
                                            return (t1.Era.CompareTo(t2.Era));
                                        });
                                        ProjectLB.Clear();
                                        ProjectLB.Add(string.Format("{0,-20}{1,-20 }", "Era", "Cost"));
                                        foreach (ClassEras eraEntry in ErasDataP) { ProjectLB.Add(string.Format("{0,-20}{1,-20 }", eraEntry.Era, eraEntry.Cost)); }
                                    }
                                    else
                                    {
                                        ErasDataP[i].Cost = j.Cost;
                                        ProjectLB.Clear();
                                        ProjectLB.Add(string.Format("{0,-20}{1,-20 }", "Era", "Cost"));
                                        foreach (ClassEras eraEntry in ErasDataP) { ProjectLB.Add(string.Format("{0,-20}{1,-20 }", eraEntry.Era, eraEntry.Cost)); }
                                    }
                                }
                            }

                            if (ErasDataP.Count == 0) { DeleteBT.Enabled = false; }
                            else { DeleteBT.Enabled = true; }

                            break;
                        }
                    case "Goods":
                        {
                            if (ListBox.Count == 0) { return; }

                            if (ListBox.SelectedIndex == -1) { selectedIndex = 0; ListBox.SelectedIndex = 0; } else { selectedIndex = ListBox.SelectedIndex; }

                            using (GoodsForm form = new GoodsForm())
                            {
                                int i;
                                i = Functions.hasNameIndex(GoodsData, ListBox[selectedIndex].ToString());

                                form.GoodsDataP = GoodsDataP;
                                form.local = new ClassGoods(GoodsData[i]);
                                form.ShowDialog();

                                ClassGoods j = form.ReturnValue();
                                if (j != null)
                                {
                                    i = Functions.hasNameIndex(GoodsDataP, j.Name); // Index to change
                                    if (i == -1)
                                    {
                                        GoodsDataP.Add(new ClassGoods(j));
                                        GoodsDataP.Sort(delegate (ClassGoods t1, ClassGoods t2)
                                        {
                                            return (t1.Name.CompareTo(t2.Name));
                                        });
                                        ProjectLB.Clear();
                                        foreach (ClassGoods entry in GoodsDataP) { ProjectLB.Add(entry.Name); }
                                    }
                                    else
                                    {
                                        GoodsDataP[i] = j;
                                        ProjectLB.Clear();
                                        foreach (ClassGoods entry in GoodsDataP) { ProjectLB.Add(entry.Name); }
                                    }
                                }
                            }

                            if (GoodsDataP.Count == 0) { DeleteBT.Enabled = false; }
                            else { DeleteBT.Enabled = true; }

                            break;
                        }
                    case "Institutions":
                        {
                            if (ListBox.Count == 0) { return; }

                            if (ListBox.SelectedIndex == -1) { selectedIndex = 0; ListBox.SelectedIndex = 0; } else { selectedIndex = ListBox.SelectedIndex; }

                            using (InstitutionsForm form = new InstitutionsForm())
                            {
                                int i;
                                i = Functions.hasNameIndex(InstitutionsData, ListBox[selectedIndex].ToString());

                                form.InstitutionsDataP = InstitutionsDataP;
                                form.ModifiersTypes = Functions.MergeClasses(ModifierTypeDataP, ModifierTypeDataV);
                                form.local = new ClassInstitutions(InstitutionsData[i]);
                                form.ShowDialog();

                                ClassInstitutions j = form.ReturnValue();
                                if (j != null)
                                {
                                    i = Functions.hasNameIndex(InstitutionsDataP, j.Name); // Index to change
                                    if (i == -1)
                                    {
                                        InstitutionsDataP.Add(new ClassInstitutions(j));
                                        InstitutionsDataP.Sort(delegate (ClassInstitutions t1, ClassInstitutions t2)
                                        {
                                            return (t1.Name.CompareTo(t2.Name));
                                        });
                                        ProjectLB.Clear();
                                        foreach (ClassInstitutions entry in InstitutionsDataP) { ProjectLB.Add(entry.Name); }
                                    }
                                    else
                                    {
                                        InstitutionsDataP[i] = j;
                                        ProjectLB.Clear();
                                        foreach (ClassInstitutions entry in InstitutionsDataP) { ProjectLB.Add(entry.Name); }
                                    }
                                }
                            }

                            if (InstitutionsDataP.Count == 0) { DeleteBT.Enabled = false; }
                            else { DeleteBT.Enabled = true; }

                            break;
                        }
                    case "Law Groups":
                        {
                            if (ListBox.Count == 0) { return; }

                            if (ListBox.SelectedIndex == -1) { selectedIndex = 0; ListBox.SelectedIndex = 0; } else { selectedIndex = ListBox.SelectedIndex; }

                            using (LawGroupsForm form = new LawGroupsForm())
                            {
                                int i;
                                i = Functions.hasNameIndex(LawGroupsData, ListBox[selectedIndex].ToString());
                                form.LawGroupsListP = LawGroupsDataP;
                                form.local = new ClassLawGroups(LawGroupsData[i]);
                                form.ShowDialog();
                                ClassLawGroups j = form.ReturnValue();
                                if (j != null)
                                {
                                    i = Functions.hasNameIndex(LawGroupsDataP, j.Name); // Index to change
                                    if (i == -1)
                                    {
                                        LawGroupsDataP.Add(new ClassLawGroups(j));
                                        LawGroupsDataP.Sort(delegate (ClassLawGroups t1, ClassLawGroups t2)
                                        {
                                            return (t1.Name.CompareTo(t2.Name));
                                        });
                                        ProjectLB.Clear();
                                        foreach (ClassLawGroups entry in LawGroupsDataP) { ProjectLB.Add(entry.Name); }
                                    }
                                    else
                                    {
                                        LawGroupsDataP[i] = j;
                                        ProjectLB.Clear();
                                        foreach (ClassLawGroups entry in LawGroupsDataP) { ProjectLB.Add(entry.Name); }
                                    }
                                }
                            }

                            if (LawGroupsDataP.Count == 0) { DeleteBT.Enabled = false; }
                            else { DeleteBT.Enabled = true; }

                            break;
                        }
                    case "Laws":
                        {
                            if (ListBox.Count == 0) { return; }

                            if (ListBox.SelectedIndex == -1) { selectedIndex = 0; ListBox.SelectedIndex = 0; } else { selectedIndex = ListBox.SelectedIndex; }

                            using (LawsForm form = new LawsForm())
                            {
                                int i;
                                i = Functions.hasNameIndex(LawsData, ListBox[selectedIndex].ToString());
                                form.LawsListP = LawsDataP;
                                form.local = new ClassLaws(LawsData[i]);
                                form.ShowDialog();
                                ClassLaws j = form.ReturnValue();
                                if (j != null)
                                {
                                    i = Functions.hasNameIndex(LawsDataP, j.Name); // Index to change
                                    if (i == -1)
                                    {
                                        LawsDataP.Add(new ClassLaws(j));
                                        LawsDataP.Sort(delegate (ClassLaws t1, ClassLaws t2)
                                        {
                                            return (t1.Name.CompareTo(t2.Name));
                                        });
                                        ProjectLB.Clear();
                                        foreach (ClassLaws entry in LawsDataP) { ProjectLB.Add(entry.Name); }
                                    }
                                    else
                                    {
                                        LawsDataP[i] = j;
                                        ProjectLB.Clear();
                                        foreach (ClassLaws entry in LawsDataP) { ProjectLB.Add(entry.Name); }
                                    }
                                }
                            }

                            if (LawsDataP.Count == 0) { DeleteBT.Enabled = false; }
                            else { DeleteBT.Enabled = true; }

                            break;
                        }
                    case "Modifiers":
                        {
                            if (ListBox.Count == 0) { return; }

                            if (ListBox.SelectedIndex == -1) { selectedIndex = 0; ListBox.SelectedIndex = 0; } else { selectedIndex = ListBox.SelectedIndex; }

                            using (ModifiersForm form = new ModifiersForm())
                            {
                                int i;
                                i = Functions.hasNameIndex(ModifierData, ListBox[selectedIndex].ToString());

                                form.ModifiersDataP = ModifierDataP;
                                form.ModifiersTypes = Functions.MergeClasses(ModifierTypeDataP, ModifierTypeDataV);
                                form.local = new ClassModifiers(ModifierData[i]);
                                form.ShowDialog();

                                ClassModifiers j = form.ReturnValue();
                                if (j != null)
                                {
                                    i = Functions.hasNameIndex(ModifierDataP, j.Name); // Index to change
                                    if (i == -1)
                                    {
                                        ModifierDataP.Add(new ClassModifiers(j));
                                        ModifierDataP.Sort(delegate (ClassModifiers t1, ClassModifiers t2)
                                        {
                                            return (t1.Name.CompareTo(t2.Name));
                                        });
                                        ProjectLB.Clear();
                                        foreach (ClassModifiers entry in ModifierDataP) { ProjectLB.Add(entry.Name); }
                                    }
                                    else
                                    {
                                        ModifierDataP[i] = j;
                                        ProjectLB.Clear();
                                        foreach (ClassModifiers entry in ModifierDataP) { ProjectLB.Add(entry.Name); }
                                    }
                                }
                            }

                            if (ModifierDataP.Count == 0) { DeleteBT.Enabled = false; }
                            else { DeleteBT.Enabled = true; }

                            break;
                        }
                    case "Modifier Types":
                        {
                            if (ListBox.Count == 0) { return; }

                            if (ListBox.SelectedIndex == -1) { selectedIndex = 0; ListBox.SelectedIndex = 0; } else { selectedIndex = ListBox.SelectedIndex; }

                            using (ModifiersTypesForm form = new ModifiersTypesForm())
                            {
                                int i;
                                i = Functions.hasNameIndex(ModifierTypeData, ListBox[selectedIndex].ToString());

                                form.ModifiersDataP = ModifierTypeDataP;
                                form.local = new ClassModifiersType(ModifierTypeData[i]);
                                form.ShowDialog();

                                ClassModifiersType j = form.ReturnValue();
                                if (j != null)
                                {
                                    i = Functions.hasNameIndex(ModifierTypeDataP, j.Name); // Index to change
                                    if (i == -1)
                                    {
                                        ModifierTypeDataP.Add(new ClassModifiersType(j));
                                        ModifierTypeDataP.Sort(delegate (ClassModifiersType t1, ClassModifiersType t2)
                                        {
                                            return (t1.Name.CompareTo(t2.Name));
                                        });
                                        ProjectLB.Clear();
                                        foreach (ClassModifiersType entry in ModifierTypeDataP) { ProjectLB.Add(entry.Name); }
                                    }
                                    else
                                    {
                                        ModifierTypeDataP[i] = j;
                                        ProjectLB.Clear();
                                        foreach (ClassModifiersType entry in ModifierTypeDataP) { ProjectLB.Add(entry.Name); }
                                    }
                                }
                            }

                            if (ModifierTypeDataP.Count == 0) { DeleteBT.Enabled = false; }
                            else { DeleteBT.Enabled = true; }

                            break;
                        }
                    case "Pop Needs":
                        {
                            if (ListBox.Count == 0) { return; }

                            if (ListBox.SelectedIndex == -1) { selectedIndex = 0; ListBox.SelectedIndex = 0; } else { selectedIndex = ListBox.SelectedIndex; }

                            using (PopNeedsForm form = new PopNeedsForm())
                            {
                                int i;
                                i = Functions.hasNameIndex(PopNeedsData, ListBox[selectedIndex].ToString());
                                form.PopNeedsListP = PopNeedsDataP;
                                form.GoodsList = Functions.MergeClasses(GoodsDataP, GoodsDataV);
                                form.local = new ClassPopNeeds(PopNeedsData[i]);
                                form.ShowDialog();
                                ClassPopNeeds j = form.ReturnValue();
                                if (j != null)
                                {
                                    i = Functions.hasNameIndex(PopNeedsDataP, j.Name); // Index to change
                                    if (i == -1)
                                    {
                                        PopNeedsDataP.Add(new ClassPopNeeds(j));
                                        PopNeedsDataP.Sort(delegate (ClassPopNeeds t1, ClassPopNeeds t2)
                                        {
                                            return (t1.Name.CompareTo(t2.Name));
                                        });
                                        ProjectLB.Clear();
                                        foreach (ClassPopNeeds entry in PopNeedsDataP) { ProjectLB.Add(entry.Name); }
                                    }
                                    else
                                    {
                                        PopNeedsDataP[i] = j;
                                        ProjectLB.Clear();
                                        foreach (ClassPopNeeds entry in PopNeedsDataP) { ProjectLB.Add(entry.Name); }
                                    }
                                }
                            }

                            if (PopNeedsDataP.Count == 0) { DeleteBT.Enabled = false; }
                            else { DeleteBT.Enabled = true; }

                            break;
                        }
                    case "Pop Types":
                        {
                            if (ListBox.Count == 0) { return; }

                            if (ListBox.SelectedIndex == -1) { selectedIndex = 0; ListBox.SelectedIndex = 0; } else { selectedIndex = ListBox.SelectedIndex; }

                            using (PopTypesForm form = new PopTypesForm())
                            {
                                int i;
                                i = Functions.hasNameIndex(PopTypesData, ListBox[selectedIndex].ToString());
                                form.PopTypesListP = PopTypesDataP;
                                form.local = new ClassPopTypes(PopTypesData[i]);
                                form.ShowDialog();
                                ClassPopTypes j = form.ReturnValue();
                                if (j != null)
                                {
                                    i = Functions.hasNameIndex(PopTypesDataP, j.Name); // Index to change
                                    if (i == -1)
                                    {
                                        PopTypesDataP.Add(new ClassPopTypes(j));
                                        PopTypesDataP.Sort(delegate (ClassPopTypes t1, ClassPopTypes t2)
                                        {
                                            return (t1.Name.CompareTo(t2.Name));
                                        });
                                        ProjectLB.Clear();
                                        foreach (ClassPopTypes entry in PopTypesDataP) { ProjectLB.Add(entry.Name); }
                                    }
                                    else
                                    {
                                        PopTypesDataP[i] = j;
                                        ProjectLB.Clear();
                                        foreach (ClassPopTypes entry in PopTypesDataP) { ProjectLB.Add(entry.Name); }
                                    }
                                }
                            }

                            if (PopTypesDataP.Count == 0) { DeleteBT.Enabled = false; }
                            else { DeleteBT.Enabled = true; }

                            break;
                        }
                    case "Production Method Groups":
                        {
                            if (ListBox.Count == 0) { return; }

                            if (ListBox.SelectedIndex == -1) { selectedIndex = 0; ListBox.SelectedIndex = 0; } else { selectedIndex = ListBox.SelectedIndex; }

                            using (ProductionMethodGroupsForm form = new ProductionMethodGroupsForm())
                            {
                                int i;
                                i = Functions.hasNameIndex(ProductionMethodGroupsData, ListBox[selectedIndex].ToString());
                                form.ProductionMethodGroupsListP = ProductionMethodGroupsDataP;
                                form.ProductionMethodsList = Functions.MergeClasses(ProductionMethodsDataP, ProductionMethodsDataV);
                                form.local = new ClassProductionMethodGroups(ProductionMethodGroupsData[i]);
                                form.ShowDialog();
                                ClassProductionMethodGroups j = form.ReturnValue();
                                if (j != null)
                                {
                                    i = Functions.hasNameIndex(ProductionMethodGroupsDataP, j.Name); // Index to change
                                    if (i == -1)
                                    {
                                        ProductionMethodGroupsDataP.Add(new ClassProductionMethodGroups(j));
                                        ProductionMethodGroupsDataP.Sort(delegate (ClassProductionMethodGroups t1, ClassProductionMethodGroups t2)
                                        {
                                            return (t1.Name.CompareTo(t2.Name));
                                        });
                                        ProjectLB.Clear();
                                        foreach (ClassProductionMethodGroups entry in ProductionMethodGroupsDataP) { ProjectLB.Add(entry.Name); }
                                    }
                                    else
                                    {
                                        ProductionMethodGroupsDataP[i] = j;
                                        ProjectLB.Clear();
                                        foreach (ClassProductionMethodGroups entry in ProductionMethodGroupsDataP) { ProjectLB.Add(entry.Name); }
                                    }
                                }
                            }

                            if (ProductionMethodGroupsDataP.Count == 0) { DeleteBT.Enabled = false; }
                            else { DeleteBT.Enabled = true; }

                            break;
                        }
                    case "Production Methods":
                        {
                            if (ListBox.Count == 0) { return; }

                            if (ListBox.SelectedIndex == -1) { selectedIndex = 0; ListBox.SelectedIndex = 0; } else { selectedIndex = ListBox.SelectedIndex; }

                            using (ProductionMethodsForm form = new ProductionMethodsForm())
                            {
                                int i;
                                i = Functions.hasNameIndex(ProductionMethodsData, ListBox[selectedIndex].ToString());
                                form.ProductionMethodsListP = ProductionMethodsDataP;
                                form.local = new ClassProductionMethods(ProductionMethodsData[i]);
                                form.ShowDialog();
                                ClassProductionMethods j = form.ReturnValue();
                                if (j != null)
                                {
                                    i = Functions.hasNameIndex(ProductionMethodsDataP, j.Name); // Index to change
                                    if (i == -1)
                                    {
                                        ProductionMethodsDataP.Add(new ClassProductionMethods(j));
                                        ProductionMethodsDataP.Sort(delegate (ClassProductionMethods t1, ClassProductionMethods t2)
                                        {
                                            return (t1.Name.CompareTo(t2.Name));
                                        });
                                        ProjectLB.Clear();
                                        foreach (ClassProductionMethods entry in ProductionMethodsDataP) { ProjectLB.Add(entry.Name); }
                                    }
                                    else
                                    {
                                        ProductionMethodsDataP[i] = j;
                                        ProjectLB.Clear();
                                        foreach (ClassProductionMethods entry in ProductionMethodsDataP) { ProjectLB.Add(entry.Name); }
                                    }
                                }
                            }

                            if (ProductionMethodsDataP.Count == 0) { DeleteBT.Enabled = false; }
                            else { DeleteBT.Enabled = true; }

                            break;
                        }
                    case "Religions":
                        {
                            if (ListBox.Count == 0) { return; }

                            if (ListBox.SelectedIndex == -1) { selectedIndex = 0; ListBox.SelectedIndex = 0; } else { selectedIndex = ListBox.SelectedIndex; }

                            using (ReligionForm form = new ReligionForm())
                            {
                                int i;
                                i = Functions.hasNameIndex(ReligionsData, ListBox[selectedIndex].ToString());
                                form.ReligionDataP = ReligionsDataP;
                                form.GoodsData = Functions.MergeClasses(GoodsDataP, GoodsDataV);
                                form.local = new ClassReligions(ReligionsData[i]);
                                form.Traits = TraitsData;
                                form.ShowDialog();
                                ClassReligions j = form.ReturnValue();
                                if (j != null)
                                {
                                    i = Functions.hasNameIndex(ReligionsDataP, j.Name); // Index to change
                                    if (i == -1)
                                    {
                                        ReligionsDataP.Add(new ClassReligions(j));
                                        ReligionsDataP.Sort(delegate (ClassReligions t1, ClassReligions t2)
                                        {
                                            return (t1.Name.CompareTo(t2.Name));
                                        });
                                        ProjectLB.Clear();
                                        foreach (ClassReligions entry in ReligionsDataP) { ProjectLB.Add(entry.Name); }
                                    }
                                    else
                                    {
                                        ReligionsDataP[i] = j;
                                        ProjectLB.Clear();
                                        foreach (ClassReligions entry in ReligionsDataP) { ProjectLB.Add(entry.Name); }
                                    }
                                }
                            }

                            if (ReligionsDataP.Count == 0) { DeleteBT.Enabled = false; }
                            else { DeleteBT.Enabled = true; }

                            break;
                        }
                    case "State Traits":
                        {
                            if (ListBox.Count == 0) { return; }

                            if (ListBox.SelectedIndex == -1) { selectedIndex = 0; ListBox.SelectedIndex = 0; } else { selectedIndex = ListBox.SelectedIndex; }

                            using (StateTraitsForm form = new StateTraitsForm())
                            {
                                int i;
                                i = Functions.hasNameIndex(StateTraitsData, ListBox[selectedIndex].ToString());
                                form.StateTraitsDataP = StateTraitsDataP;
                                form.ModifiersTypes = Functions.MergeClasses(ModifierTypeDataP, ModifierTypeDataV);
                                form.TechData = Functions.MergeClasses(TechDataP, TechDataV);
                                form.local = new ClassStateTraits(StateTraitsData[i]);
                                form.ShowDialog();
                                ClassStateTraits j = form.ReturnValue();
                                if (j != null)
                                {
                                    i = Functions.hasNameIndex(StateTraitsDataP, j.Name); // Index to change
                                    if (i == -1)
                                    {
                                        StateTraitsDataP.Add(new ClassStateTraits(j));
                                        StateTraitsDataP.Sort(delegate (ClassStateTraits t1, ClassStateTraits t2)
                                        {
                                            return (t1.Name.CompareTo(t2.Name));
                                        });
                                        ProjectLB.Clear();
                                        foreach (ClassStateTraits entry in StateTraitsDataP) { ProjectLB.Add(entry.Name); }
                                    }
                                    else
                                    {
                                        StateTraitsDataP[i] = j;
                                        ProjectLB.Clear();
                                        foreach (ClassStateTraits entry in StateTraitsDataP) { ProjectLB.Add(entry.Name); }
                                    }
                                }
                            }

                            if (StateTraitsDataP.Count == 0) { DeleteBT.Enabled = false; }
                            else { DeleteBT.Enabled = true; }

                            break;
                        }
                    case "Technologies":
                        {
                            if (ListBox.Count == 0) { return; }

                            if (ListBox.SelectedIndex == -1) { selectedIndex = 0; ListBox.SelectedIndex = 0; } else { selectedIndex = ListBox.SelectedIndex; }

                            using (TechForm form = new TechForm())
                            {
                                int i;
                                i = Functions.hasNameIndex(TechData, ListBox[selectedIndex].ToString());
                                form.TechListP = TechDataP;
                                form.ModifiersTypes = Functions.MergeClasses(ModifierTypeDataP, ModifierTypeDataV);
                                form.TechList = Functions.MergeClasses(TechDataP, TechDataV);
                                form.EraList = Functions.MergeClasses(ErasDataP, ErasDataV);
                                form.local = new ClassTech(TechData[i]);
                                form.ShowDialog();
                                ClassTech j = form.ReturnValue();
                                if (j != null)
                                {
                                    i = Functions.hasNameIndex(TechDataP, j.Name); // Index to change
                                    if (i == -1)
                                    {
                                        TechDataP.Add(new ClassTech(j));
                                        TechDataP.Sort(delegate (ClassTech t1, ClassTech t2)
                                        {
                                            return (t1.Name.CompareTo(t2.Name));
                                        });
                                        ProjectLB.Clear();
                                        foreach (ClassTech entry in TechDataP) { ProjectLB.Add(entry.Name); }
                                    }
                                    else
                                    {
                                        TechDataP[i] = j;
                                        ProjectLB.Clear();
                                        foreach (ClassTech entry in TechDataP) { ProjectLB.Add(entry.Name); }
                                    }
                                }
                            }

                            if (TechDataP.Count == 0) { DeleteBT.Enabled = false; }
                            else { DeleteBT.Enabled = true; }

                            break;
                        }
                    default:
                        MainLB.Add("Error");
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
                case "Building Groups":
                    {
                        using (BuildingGroupsForm form = new BuildingGroupsForm())
                        {
                            int i;
                            form.BuildingGroupsListP = BuildingGroupsDataP;
                            form.local = null;
                            form.ShowDialog();
                            ClassBuildingGroups j = form.ReturnValue();
                            if (j != null)
                            {
                                i = Functions.hasNameIndex(BuildingGroupsDataP, j.Name); // Index to change
                                if (i == -1)
                                {
                                    BuildingGroupsDataP.Add(new ClassBuildingGroups(j));
                                    BuildingGroupsDataP.Sort(delegate (ClassBuildingGroups t1, ClassBuildingGroups t2)
                                    {
                                        return (t1.Name.CompareTo(t2.Name));
                                    });
                                    ProjectLB.Clear();
                                    foreach (ClassBuildingGroups entry in BuildingGroupsDataP) { ProjectLB.Add(entry.Name); }
                                }
                                else
                                {
                                    BuildingGroupsDataP[i] = j;
                                    ProjectLB.Clear();
                                    foreach (ClassBuildingGroups entry in BuildingGroupsDataP) { ProjectLB.Add(entry.Name); }
                                }
                            }
                        }

                        if (BuildingGroupsDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }

                        break;
                    }
                case "Buildings":
                    {
                        using (BuildingsForm form = new BuildingsForm())
                        {
                            int i;
                            form.BuildingsListP = BuildingsDataP;
                            form.local = null;
                            form.ShowDialog();
                            ClassBuildings j = form.ReturnValue();
                            if (j != null)
                            {
                                i = Functions.hasNameIndex(BuildingsDataP, j.Name); // Index to change
                                if (i == -1)
                                {
                                    BuildingsDataP.Add(new ClassBuildings(j));
                                    BuildingsDataP.Sort(delegate (ClassBuildings t1, ClassBuildings t2)
                                    {
                                        return (t1.Name.CompareTo(t2.Name));
                                    });
                                    ProjectLB.Clear();
                                    foreach (ClassBuildings entry in BuildingsDataP) { ProjectLB.Add(entry.Name); }
                                }
                                else
                                {
                                    BuildingsDataP[i] = j;
                                    ProjectLB.Clear();
                                    foreach (ClassBuildings entry in BuildingsDataP) { ProjectLB.Add(entry.Name); }
                                }
                            }
                        }

                        if (BuildingsDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }

                        break;
                    }
                case "Canals":
                    {
                        using (CanalsForm form = new CanalsForm())
                        {
                            int i;
                            form.CanalsListP = CanalsDataP;
                            form.local = null;
                            form.ShowDialog();
                            ClassCanals j = form.ReturnValue();
                            if (j != null)
                            {
                                i = Functions.hasNameIndex(CanalsDataP, j.Name); // Index to change
                                if (i == -1)
                                {
                                    CanalsDataP.Add(new ClassCanals(j));
                                    CanalsDataP.Sort(delegate (ClassCanals t1, ClassCanals t2)
                                    {
                                        return (t1.Name.CompareTo(t2.Name));
                                    });
                                    ProjectLB.Clear();
                                    foreach (ClassCanals entry in CanalsDataP) { ProjectLB.Add(entry.Name); }
                                }
                                else
                                {
                                    CanalsDataP[i] = j;
                                    ProjectLB.Clear();
                                    foreach (ClassCanals entry in CanalsDataP) { ProjectLB.Add(entry.Name); }
                                }
                            }
                        }

                        if (CanalsDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }

                        break;
                    }
                case "Cultures":
                    {
                        using (CulturesForm form = new CulturesForm())
                        {
                            int i;
                            form.CulturesListP = CulturesDataP;
                            form.local = null;
                            form.ShowDialog();
                            ClassCultures j = form.ReturnValue();
                            if (j != null)
                            {
                                i = Functions.hasNameIndex(CulturesDataP, j.Name); // Index to change
                                if (i == -1)
                                {
                                    CulturesDataP.Add(new ClassCultures(j));
                                    CulturesDataP.Sort(delegate (ClassCultures t1, ClassCultures t2)
                                    {
                                        return (t1.Name.CompareTo(t2.Name));
                                    });
                                    ProjectLB.Clear();
                                    foreach (ClassCultures entry in CulturesDataP) { ProjectLB.Add(entry.Name); }
                                }
                                else
                                {
                                    CulturesDataP[i] = j;
                                    ProjectLB.Clear();
                                    foreach (ClassCultures entry in CulturesDataP) { ProjectLB.Add(entry.Name); }
                                }
                            }
                        }

                        if (CulturesDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }

                        break;
                    }
                case "Decisions":
                    {
                        using (DecisionsForm form = new DecisionsForm())
                        {
                            int i;
                            form.DecisionsListP = DecisionsDataP;
                            form.local = null;
                            form.ShowDialog();
                            ClassDecisions j = form.ReturnValue();
                            if (j != null)
                            {
                                i = Functions.hasNameIndex(DecisionsDataP, j.Name); // Index to change
                                if (i == -1)
                                {
                                    DecisionsDataP.Add(new ClassDecisions(j));
                                    DecisionsDataP.Sort(delegate (ClassDecisions t1, ClassDecisions t2)
                                    {
                                        return (t1.Name.CompareTo(t2.Name));
                                    });
                                    ProjectLB.Clear();
                                    foreach (ClassDecisions entry in DecisionsDataP) { ProjectLB.Add(entry.Name); }
                                }
                                else
                                {
                                    DecisionsDataP[i] = j;
                                    ProjectLB.Clear();
                                    foreach (ClassDecisions entry in DecisionsDataP) { ProjectLB.Add(entry.Name); }
                                }
                            }
                        }

                        if (DecisionsDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }

                        break;
                    }
                case "Decrees":
                    {
                        using (DecreesForm form = new DecreesForm())
                        {
                            int i;
                            form.DecreesListP = DecreesDataP;
                            form.local = null;
                            form.ShowDialog();
                            ClassDecrees j = form.ReturnValue();
                            if (j != null)
                            {
                                i = Functions.hasNameIndex(DecreesDataP, j.Name); // Index to change
                                if (i == -1)
                                {
                                    DecreesDataP.Add(new ClassDecrees(j));
                                    DecreesDataP.Sort(delegate (ClassDecrees t1, ClassDecrees t2)
                                    {
                                        return (t1.Name.CompareTo(t2.Name));
                                    });
                                    ProjectLB.Clear();
                                    foreach (ClassDecrees entry in DecreesDataP) { ProjectLB.Add(entry.Name); }
                                }
                                else
                                {
                                    DecreesDataP[i] = j;
                                    ProjectLB.Clear();
                                    foreach (ClassDecrees entry in DecreesDataP) { ProjectLB.Add(entry.Name); }
                                }
                            }
                        }

                        if (DecreesDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }

                        break;
                    }
                case "Eras":
                    {
                        using (EraForm form = new EraForm())
                        {
                            int i;
                            form.local = null;
                            form.ShowDialog();
                            ClassEras j = form.ReturnValue();
                            if (j != null)
                            {
                                i = Functions.hasNameIndex(ErasDataP, j.Era.ToString()); // Index to change
                                if (i == -1)
                                {
                                    ErasDataP.Add(new ClassEras(j.Era, j.Cost));
                                    ErasDataP.Sort(delegate (ClassEras t1, ClassEras t2)
                                    {
                                        return (t1.Era.CompareTo(t2.Era));
                                    });
                                    ProjectLB.Clear();
                                    ProjectLB.Add(string.Format("{0,-20}{1,-20 }", "Era", "Cost"));
                                    foreach (ClassEras eraEntry in ErasDataP) { ProjectLB.Add(string.Format("{0,-20}{1,-20 }", eraEntry.Era, eraEntry.Cost)); }
                                }
                                else
                                {
                                    ErasDataP[i].Cost = j.Cost;
                                    ProjectLB.Clear();
                                    ProjectLB.Add(string.Format("{0,-20}{1,-20 }", "Era", "Cost"));
                                    foreach (ClassEras eraEntry in ErasDataP) { ProjectLB.Add(string.Format("{0,-20}{1,-20 }", eraEntry.Era, eraEntry.Cost)); }
                                }
                            }
                        }

                        if (ErasDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }

                        break;
                    }
                case "Goods":
                    {
                        using (GoodsForm form = new GoodsForm())
                        {
                            int i;

                            form.GoodsDataP = GoodsDataP;
                            form.local = null;
                            form.ShowDialog();

                            ClassGoods j = form.ReturnValue();
                            if (j != null)
                            {
                                i = Functions.hasNameIndex(GoodsDataP, j.Name); // Index to change
                                if (i == -1)
                                {
                                    GoodsDataP.Add(new ClassGoods(j));
                                    GoodsDataP.Sort(delegate (ClassGoods t1, ClassGoods t2)
                                    {
                                        return (t1.Name.CompareTo(t2.Name));
                                    });
                                    ProjectLB.Clear();
                                    foreach (ClassGoods entry in GoodsDataP) { ProjectLB.Add(entry.Name); }
                                }
                                else
                                {
                                    GoodsDataP[i] = j;
                                    ProjectLB.Clear();
                                    foreach (ClassGoods entry in GoodsDataP) { ProjectLB.Add(entry.Name); }
                                }
                            }
                        }

                        if (GoodsDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }

                        break;
                    }
                case "Institutions":
                    {
                        using (InstitutionsForm form = new InstitutionsForm())
                        {
                            int i;

                            form.InstitutionsDataP = InstitutionsDataP;
                            form.ModifiersTypes = Functions.MergeClasses(ModifierTypeDataP, ModifierTypeDataV);
                            form.local = null;
                            form.ShowDialog();

                            ClassInstitutions j = form.ReturnValue();
                            if (j != null)
                            {
                                i = Functions.hasNameIndex(InstitutionsDataP, j.Name); // Index to change
                                if (i == -1)
                                {
                                    InstitutionsDataP.Add(new ClassInstitutions(j));
                                    InstitutionsDataP.Sort(delegate (ClassInstitutions t1, ClassInstitutions t2)
                                    {
                                        return (t1.Name.CompareTo(t2.Name));
                                    });
                                    ProjectLB.Clear();
                                    foreach (ClassInstitutions entry in InstitutionsDataP) { ProjectLB.Add(entry.Name); }
                                }
                                else
                                {
                                    InstitutionsDataP[i] = j;
                                    ProjectLB.Clear();
                                    foreach (ClassInstitutions entry in InstitutionsDataP) { ProjectLB.Add(entry.Name); }
                                }
                            }
                        }

                        if (InstitutionsDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }

                        break;
                    }
                case "Law Groups":
                    {
                        using (LawGroupsForm form = new LawGroupsForm())
                        {
                            int i;
                            form.LawGroupsListP = LawGroupsDataP;
                            form.local = null;
                            form.ShowDialog();
                            ClassLawGroups j = form.ReturnValue();
                            if (j != null)
                            {
                                i = Functions.hasNameIndex(LawGroupsDataP, j.Name); // Index to change
                                if (i == -1)
                                {
                                    LawGroupsDataP.Add(new ClassLawGroups(j));
                                    LawGroupsDataP.Sort(delegate (ClassLawGroups t1, ClassLawGroups t2)
                                    {
                                        return (t1.Name.CompareTo(t2.Name));
                                    });
                                    ProjectLB.Clear();
                                    foreach (ClassLawGroups entry in LawGroupsDataP) { ProjectLB.Add(entry.Name); }
                                }
                                else
                                {
                                    LawGroupsDataP[i] = j;
                                    ProjectLB.Clear();
                                    foreach (ClassLawGroups entry in LawGroupsDataP) { ProjectLB.Add(entry.Name); }
                                }
                            }
                        }

                        if (LawGroupsDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }

                        break;
                    }
                case "Laws":
                    {
                        using (LawsForm form = new LawsForm())
                        {
                            int i;
                            form.LawsListP = LawsDataP;
                            form.local = null;
                            form.ShowDialog();
                            ClassLaws j = form.ReturnValue();
                            if (j != null)
                            {
                                i = Functions.hasNameIndex(LawsDataP, j.Name); // Index to change
                                if (i == -1)
                                {
                                    LawsDataP.Add(new ClassLaws(j));
                                    LawsDataP.Sort(delegate (ClassLaws t1, ClassLaws t2)
                                    {
                                        return (t1.Name.CompareTo(t2.Name));
                                    });
                                    ProjectLB.Clear();
                                    foreach (ClassLaws entry in LawsDataP) { ProjectLB.Add(entry.Name); }
                                }
                                else
                                {
                                    LawsDataP[i] = j;
                                    ProjectLB.Clear();
                                    foreach (ClassLaws entry in LawsDataP) { ProjectLB.Add(entry.Name); }
                                }
                            }
                        }

                        if (LawsDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }

                        break;
                    }
                case "Modifiers":
                    {
                        using (ModifiersForm form = new ModifiersForm())
                        {
                            int i;

                            form.ModifiersDataP = ModifierDataP;
                            form.ModifiersTypes = Functions.MergeClasses(ModifierTypeDataP, ModifierTypeDataV);
                            form.local = null;
                            form.ShowDialog();

                            ClassModifiers j = form.ReturnValue();
                            if (j != null)
                            {
                                i = Functions.hasNameIndex(ModifierDataP, j.Name); // Index to change
                                if (i == -1)
                                {
                                    ModifierDataP.Add(new ClassModifiers(j));
                                    ModifierDataP.Sort(delegate (ClassModifiers t1, ClassModifiers t2)
                                    {
                                        return (t1.Name.CompareTo(t2.Name));
                                    });
                                    ProjectLB.Clear();
                                    foreach (ClassModifiers entry in ModifierDataP) { ProjectLB.Add(entry.Name); }
                                }
                                else
                                {
                                    ModifierDataP[i] = j;
                                    ProjectLB.Clear();
                                    foreach (ClassModifiers entry in ModifierDataP) { ProjectLB.Add(entry.Name); }
                                }
                            }
                        }

                        if (ModifierDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }

                        break;
                    }
                case "Modifier Types":
                    {
                        using (ModifiersTypesForm form = new ModifiersTypesForm())
                        {
                            int i;

                            form.ModifiersDataP = ModifierTypeDataP;
                            form.local = null;
                            form.ShowDialog();

                            ClassModifiersType j = form.ReturnValue();
                            if (j != null)
                            {
                                i = Functions.hasNameIndex(ModifierTypeDataP, j.Name); // Index to change
                                if (i == -1)
                                {
                                    ModifierTypeDataP.Add(new ClassModifiersType(j));
                                    ModifierTypeDataP.Sort(delegate (ClassModifiersType t1, ClassModifiersType t2)
                                    {
                                        return (t1.Name.CompareTo(t2.Name));
                                    });
                                    ProjectLB.Clear();
                                    foreach (ClassModifiersType entry in ModifierTypeDataP) { ProjectLB.Add(entry.Name); }
                                }
                                else
                                {
                                    ModifierTypeDataP[i] = j;
                                    ProjectLB.Clear();
                                    foreach (ClassModifiersType entry in ModifierTypeDataP) { ProjectLB.Add(entry.Name); }
                                }
                            }
                        }

                        if (ModifierTypeDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }

                        break;
                    }
                case "Pop Needs":
                    {
                        using (PopNeedsForm form = new PopNeedsForm())
                        {
                            int i;
                            form.PopNeedsListP = PopNeedsDataP;
                            form.GoodsList = Functions.MergeClasses(GoodsDataP, GoodsDataV);
                            form.local = null;
                            form.ShowDialog();
                            ClassPopNeeds j = form.ReturnValue();
                            if (j != null)
                            {
                                i = Functions.hasNameIndex(PopNeedsDataP, j.Name); // Index to change
                                if (i == -1)
                                {
                                    PopNeedsDataP.Add(new ClassPopNeeds(j));
                                    PopNeedsDataP.Sort(delegate (ClassPopNeeds t1, ClassPopNeeds t2)
                                    {
                                        return (t1.Name.CompareTo(t2.Name));
                                    });
                                    ProjectLB.Clear();
                                    foreach (ClassPopNeeds entry in PopNeedsDataP) { ProjectLB.Add(entry.Name); }
                                }
                                else
                                {
                                    PopNeedsDataP[i] = j;
                                    ProjectLB.Clear();
                                    foreach (ClassPopNeeds entry in PopNeedsDataP) { ProjectLB.Add(entry.Name); }
                                }
                            }
                        }

                        if (PopNeedsDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }

                        break;
                    }
                case "Pop Types":
                    {
                        using (PopTypesForm form = new PopTypesForm())
                        {
                            int i;
                            form.PopTypesListP = PopTypesDataP;
                            form.local = null;
                            form.ShowDialog();
                            ClassPopTypes j = form.ReturnValue();
                            if (j != null)
                            {
                                i = Functions.hasNameIndex(PopTypesDataP, j.Name); // Index to change
                                if (i == -1)
                                {
                                    PopTypesDataP.Add(new ClassPopTypes(j));
                                    PopTypesDataP.Sort(delegate (ClassPopTypes t1, ClassPopTypes t2)
                                    {
                                        return (t1.Name.CompareTo(t2.Name));
                                    });
                                    ProjectLB.Clear();
                                    foreach (ClassPopTypes entry in PopTypesDataP) { ProjectLB.Add(entry.Name); }
                                }
                                else
                                {
                                    PopTypesDataP[i] = j;
                                    ProjectLB.Clear();
                                    foreach (ClassPopTypes entry in PopTypesDataP) { ProjectLB.Add(entry.Name); }
                                }
                            }
                        }

                        if (PopTypesDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }

                        break;
                    }
                case "Production Method Groups":
                    {
                        using (ProductionMethodGroupsForm form = new ProductionMethodGroupsForm())
                        {
                            int i;
                            form.ProductionMethodGroupsListP = ProductionMethodGroupsDataP;
                            form.ProductionMethodsList = Functions.MergeClasses(ProductionMethodsDataP, ProductionMethodsDataV);
                            form.local = null;
                            form.ShowDialog();
                            ClassProductionMethodGroups j = form.ReturnValue();
                            if (j != null)
                            {
                                i = Functions.hasNameIndex(ProductionMethodGroupsDataP, j.Name); // Index to change
                                if (i == -1)
                                {
                                    ProductionMethodGroupsDataP.Add(new ClassProductionMethodGroups(j));
                                    ProductionMethodGroupsDataP.Sort(delegate (ClassProductionMethodGroups t1, ClassProductionMethodGroups t2)
                                    {
                                        return (t1.Name.CompareTo(t2.Name));
                                    });
                                    ProjectLB.Clear();
                                    foreach (ClassProductionMethodGroups entry in ProductionMethodGroupsDataP) { ProjectLB.Add(entry.Name); }
                                }
                                else
                                {
                                    ProductionMethodGroupsDataP[i] = j;
                                    ProjectLB.Clear();
                                    foreach (ClassProductionMethodGroups entry in ProductionMethodGroupsDataP) { ProjectLB.Add(entry.Name); }
                                }
                            }
                        }

                        if (ProductionMethodGroupsDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }

                        break;
                    }
                case "Production Methods":
                    {
                        using (ProductionMethodsForm form = new ProductionMethodsForm())
                        {
                            int i;
                            form.ProductionMethodsListP = ProductionMethodsDataP;
                            form.local = null;
                            form.ShowDialog();
                            ClassProductionMethods j = form.ReturnValue();
                            if (j != null)
                            {
                                i = Functions.hasNameIndex(ProductionMethodsDataP, j.Name); // Index to change
                                if (i == -1)
                                {
                                    ProductionMethodsDataP.Add(new ClassProductionMethods(j));
                                    ProductionMethodsDataP.Sort(delegate (ClassProductionMethods t1, ClassProductionMethods t2)
                                    {
                                        return (t1.Name.CompareTo(t2.Name));
                                    });
                                    ProjectLB.Clear();
                                    foreach (ClassProductionMethods entry in ProductionMethodsDataP) { ProjectLB.Add(entry.Name); }
                                }
                                else
                                {
                                    ProductionMethodsDataP[i] = j;
                                    ProjectLB.Clear();
                                    foreach (ClassProductionMethods entry in ProductionMethodsDataP) { ProjectLB.Add(entry.Name); }
                                }
                            }
                        }

                        if (ProductionMethodsDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }

                        break;
                    }
                case "Religions":
                    {
                        using (ReligionForm form = new ReligionForm())
                        {
                            int i;
                            form.ReligionDataP = ReligionsDataP;
                            form.GoodsData = Functions.MergeClasses(GoodsDataP, GoodsDataV);
                            form.Traits = TraitsData;
                            form.local = null;
                            form.ShowDialog();
                            ClassReligions j = form.ReturnValue();
                            if (j != null)
                            {
                                i = Functions.hasNameIndex(ReligionsDataP, j.Name); // Index to change
                                if (i == -1)
                                {
                                    ReligionsDataP.Add(new ClassReligions(j));
                                    ReligionsDataP.Sort(delegate (ClassReligions t1, ClassReligions t2)
                                    {
                                        return (t1.Name.CompareTo(t2.Name));
                                    });
                                    ProjectLB.Clear();
                                    foreach (ClassReligions entry in ReligionsDataP) { ProjectLB.Add(entry.Name); }
                                }
                                else
                                {
                                    ReligionsDataP[i] = j;
                                    ProjectLB.Clear();
                                    foreach (ClassReligions entry in ReligionsDataP) { ProjectLB.Add(entry.Name); }
                                }
                            }
                        }

                        if (ReligionsDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }

                        break;
                    }
                case "State Traits":
                    {
                        using (StateTraitsForm form = new StateTraitsForm())
                        {
                            int i;
                            form.StateTraitsDataP = StateTraitsDataP;
                            form.ModifiersTypes = Functions.MergeClasses(ModifierTypeDataP, ModifierTypeDataV);
                            form.TechData = Functions.MergeClasses(TechDataP, TechDataV);
                            form.local = null;
                            form.ShowDialog();
                            ClassStateTraits j = form.ReturnValue();
                            if (j != null)
                            {
                                i = Functions.hasNameIndex(StateTraitsDataP, j.Name); // Index to change
                                if (i == -1)
                                {
                                    StateTraitsDataP.Add(new ClassStateTraits(j));
                                    StateTraitsDataP.Sort(delegate (ClassStateTraits t1, ClassStateTraits t2)
                                    {
                                        return (t1.Name.CompareTo(t2.Name));
                                    });
                                    ProjectLB.Clear();
                                    foreach (ClassStateTraits entry in StateTraitsDataP) { ProjectLB.Add(entry.Name); }
                                }
                                else
                                {
                                    StateTraitsDataP[i] = j;
                                    ProjectLB.Clear();
                                    foreach (ClassStateTraits entry in StateTraitsDataP) { ProjectLB.Add(entry.Name); }
                                }
                            }
                        }

                        if (StateTraitsDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }

                        break;
                    }
                case "Technologies":
                    {
                        using (TechForm form = new TechForm())
                        {
                            int i;
                            form.TechListP = TechDataP;
                            form.ModifiersTypes = Functions.MergeClasses(ModifierTypeDataP, ModifierTypeDataV);
                            form.TechList = Functions.MergeClasses(TechDataP, TechDataV);
                            form.EraList = Functions.MergeClasses(ErasDataP, ErasDataV);
                            form.local = null;
                            form.ShowDialog();
                            ClassTech j = form.ReturnValue();
                            if (j != null)
                            {
                                i = Functions.hasNameIndex(TechDataP, j.Name); // Index to change
                                if (i == -1)
                                {
                                    TechDataP.Add(new ClassTech(j));
                                    TechDataP.Sort(delegate (ClassTech t1, ClassTech t2)
                                    {
                                        return (t1.Name.CompareTo(t2.Name));
                                    });
                                    ProjectLB.Clear();
                                    foreach (ClassTech entry in TechDataP) { ProjectLB.Add(entry.Name); }
                                }
                                else
                                {
                                    TechDataP[i] = j;
                                    ProjectLB.Clear();
                                    foreach (ClassTech entry in TechDataP) { ProjectLB.Add(entry.Name); }
                                }
                            }
                        }

                        if (TechDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }

                        break;
                    }
                default:
                    MainLB.Add("Error");
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

            LocalizationDataV = Functions.LocalizationSetup(VickyPath + "\\game");
            LocalizationDataP = Functions.LocalizationSetup(ProjPath);
            LocalizationDataM = Functions.LocalizationSetup(ModPath);
        }

        // *
        private void DeleteBT_Click(object sender, EventArgs e)
        {
            int i;
            SaveStatus = 2;

            switch (MainData[mainSelectedIndex].ToString())
            {
                case "Building Groups":
                    {
                        if (ProjectLB.SelectedIndex == -1) { projSelectedIndex = 0; ProjectLB.SelectedIndex = 0; } else { projSelectedIndex = ProjectLB.SelectedIndex; }

                        i = Functions.hasNameIndex(BuildingGroupsDataP, ProjectLB[projSelectedIndex].ToString());
                        BuildingGroupsDataP.RemoveAt(i);
                        ProjectLB.Clear();
                        foreach (ClassBuildingGroups entry in BuildingGroupsDataP) { ProjectLB.Add(entry.Name); }

                        if (BuildingGroupsDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }

                        break;
                    }
                case "Buildings":
                    {
                        if (ProjectLB.SelectedIndex == -1) { projSelectedIndex = 0; ProjectLB.SelectedIndex = 0; } else { projSelectedIndex = ProjectLB.SelectedIndex; }

                        i = Functions.hasNameIndex(BuildingsDataP, ProjectLB[projSelectedIndex].ToString());
                        BuildingsDataP.RemoveAt(i);
                        ProjectLB.Clear();
                        foreach (ClassBuildings entry in BuildingsDataP) { ProjectLB.Add(entry.Name); }

                        if (BuildingsDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }

                        break;
                    }
                case "Canals":
                    {
                        if (ProjectLB.SelectedIndex == -1) { projSelectedIndex = 0; ProjectLB.SelectedIndex = 0; } else { projSelectedIndex = ProjectLB.SelectedIndex; }

                        i = Functions.hasNameIndex(CanalsDataP, ProjectLB[projSelectedIndex].ToString());
                        CanalsDataP.RemoveAt(i);
                        ProjectLB.Clear();
                        foreach (ClassCanals entry in CanalsDataP) { ProjectLB.Add(entry.Name); }

                        if (CanalsDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }

                        break;
                    }
                case "Cultures":
                    {
                        if (ProjectLB.SelectedIndex == -1) { projSelectedIndex = 0; ProjectLB.SelectedIndex = 0; } else { projSelectedIndex = ProjectLB.SelectedIndex; }

                        i = Functions.hasNameIndex(CulturesDataP, ProjectLB[projSelectedIndex].ToString());
                        CulturesDataP.RemoveAt(i);
                        ProjectLB.Clear();
                        foreach (ClassCultures entry in CulturesDataP) { ProjectLB.Add(entry.Name); }

                        if (CulturesDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }

                        break;
                    }
                case "Decisions":
                    {
                        if (ProjectLB.SelectedIndex == -1) { projSelectedIndex = 0; ProjectLB.SelectedIndex = 0; } else { projSelectedIndex = ProjectLB.SelectedIndex; }

                        i = Functions.hasNameIndex(DecisionsDataP, ProjectLB[projSelectedIndex].ToString());
                        DecisionsDataP.RemoveAt(i);
                        ProjectLB.Clear();
                        foreach (ClassDecisions entry in DecisionsDataP) { ProjectLB.Add(entry.Name); }

                        if (DecisionsDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }

                        break;
                    }
                case "Decrees":
                    {
                        if (ProjectLB.SelectedIndex == -1) { projSelectedIndex = 0; ProjectLB.SelectedIndex = 0; } else { projSelectedIndex = ProjectLB.SelectedIndex; }

                        i = Functions.hasNameIndex(DecreesDataP, ProjectLB[projSelectedIndex].ToString());
                        DecreesDataP.RemoveAt(i);
                        ProjectLB.Clear();
                        foreach (ClassDecrees entry in DecreesDataP) { ProjectLB.Add(entry.Name); }

                        if (DecreesDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }

                        break;
                    }
                case "Eras":
                    {
                        if (ProjectLB.SelectedIndex == 0) { return; }

                        if (ProjectLB.SelectedIndex == -1) { projSelectedIndex = 1; ProjectLB.SelectedIndex = 1; } else { projSelectedIndex = ProjectLB.SelectedIndex; }

                        i = Functions.hasNameIndex(ErasDataP, ProjectLB[projSelectedIndex].ToString().Substring(0, 20));
                        ErasDataP.RemoveAt(i);
                        ProjectLB.Clear();
                        ProjectLB.Add(string.Format("{0,-20}{1,-20 }", "Era", "Cost"));
                        foreach (ClassEras eraEntry in ErasDataP) { ProjectLB.Add(string.Format("{0,-20}{1,-20 }", eraEntry.Era, eraEntry.Cost)); }

                        if (ErasDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }

                        break;
                    }
                case "Goods":
                    {
                        if (ProjectLB.SelectedIndex == -1) { projSelectedIndex = 0; ProjectLB.SelectedIndex = 0; } else { projSelectedIndex = ProjectLB.SelectedIndex; }

                        i = Functions.hasNameIndex(GoodsDataP, ProjectLB[projSelectedIndex].ToString());
                        GoodsDataP.RemoveAt(i);
                        ProjectLB.Clear();
                        foreach (ClassGoods entry in GoodsDataP) { ProjectLB.Add(entry.Name); }

                        if (GoodsDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }

                        break;
                    }
                case "Institutions":
                    {
                        if (ProjectLB.SelectedIndex == -1) { projSelectedIndex = 0; ProjectLB.SelectedIndex = 0; } else { projSelectedIndex = ProjectLB.SelectedIndex; }

                        i = Functions.hasNameIndex(InstitutionsDataP, ProjectLB[projSelectedIndex].ToString());
                        InstitutionsDataP.RemoveAt(i);
                        ProjectLB.Clear();
                        foreach (ClassInstitutions entry in InstitutionsDataP) { ProjectLB.Add(entry.Name); }

                        if (InstitutionsDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }

                        break;
                    }
                case "Law Groups":
                    {
                        if (ProjectLB.SelectedIndex == -1) { projSelectedIndex = 0; ProjectLB.SelectedIndex = 0; } else { projSelectedIndex = ProjectLB.SelectedIndex; }

                        i = Functions.hasNameIndex(LawGroupsDataP, ProjectLB[projSelectedIndex].ToString());
                        LawGroupsDataP.RemoveAt(i);
                        ProjectLB.Clear();
                        foreach (ClassLawGroups entry in LawGroupsDataP) { ProjectLB.Add(entry.Name); }

                        if (LawGroupsDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }

                        break;
                    }
                case "Laws":
                    {
                        if (ProjectLB.SelectedIndex == -1) { projSelectedIndex = 0; ProjectLB.SelectedIndex = 0; } else { projSelectedIndex = ProjectLB.SelectedIndex; }

                        i = Functions.hasNameIndex(LawsDataP, ProjectLB[projSelectedIndex].ToString());
                        LawsDataP.RemoveAt(i);
                        ProjectLB.Clear();
                        foreach (ClassLaws entry in LawsDataP) { ProjectLB.Add(entry.Name); }

                        if (LawsDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }

                        break;
                    }
                case "Modifiers":
                    {
                        if (ProjectLB.SelectedIndex == -1) { projSelectedIndex = 0; ProjectLB.SelectedIndex = 0; } else { projSelectedIndex = ProjectLB.SelectedIndex; }

                        i = Functions.hasNameIndex(ModifierDataP, ProjectLB[projSelectedIndex].ToString());
                        ModifierDataP.RemoveAt(i);
                        ProjectLB.Clear();
                        foreach (ClassModifiers entry in ModifierDataP) { ProjectLB.Add(entry.Name); }

                        if (ModifierDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }

                        break;
                    }
                case "Modifier Types":
                    {
                        if (ProjectLB.SelectedIndex == -1) { projSelectedIndex = 0; ProjectLB.SelectedIndex = 0; } else { projSelectedIndex = ProjectLB.SelectedIndex; }

                        i = Functions.hasNameIndex(ModifierTypeDataP, ProjectLB[projSelectedIndex].ToString());
                        ModifierTypeDataP.RemoveAt(i);
                        ProjectLB.Clear();
                        foreach (ClassModifiersType entry in ModifierTypeDataP) { ProjectLB.Add(entry.Name); }

                        if (ModifierTypeDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }

                        break;
                    }
                case "Pop Needs":
                    {
                        if (ProjectLB.SelectedIndex == -1) { projSelectedIndex = 0; ProjectLB.SelectedIndex = 0; } else { projSelectedIndex = ProjectLB.SelectedIndex; }

                        i = Functions.hasNameIndex(PopNeedsDataP, ProjectLB[projSelectedIndex].ToString());
                        PopNeedsDataP.RemoveAt(i);
                        ProjectLB.Clear();
                        foreach (ClassPopNeeds entry in PopNeedsDataP) { ProjectLB.Add(entry.Name); }

                        if (PopNeedsDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }

                        break;
                    }
                case "Pop Types":
                    {
                        if (ProjectLB.SelectedIndex == -1) { projSelectedIndex = 0; ProjectLB.SelectedIndex = 0; } else { projSelectedIndex = ProjectLB.SelectedIndex; }

                        i = Functions.hasNameIndex(PopTypesDataP, ProjectLB[projSelectedIndex].ToString());
                        PopTypesDataP.RemoveAt(i);
                        ProjectLB.Clear();
                        foreach (ClassPopTypes entry in PopTypesDataP) { ProjectLB.Add(entry.Name); }

                        if (PopTypesDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }

                        break;
                    }
                case "Production Method Groups":
                    {
                        if (ProjectLB.SelectedIndex == -1) { projSelectedIndex = 0; ProjectLB.SelectedIndex = 0; } else { projSelectedIndex = ProjectLB.SelectedIndex; }

                        i = Functions.hasNameIndex(ProductionMethodGroupsDataP, ProjectLB[projSelectedIndex].ToString());
                        ProductionMethodGroupsDataP.RemoveAt(i);
                        ProjectLB.Clear();
                        foreach (ClassProductionMethodGroups entry in ProductionMethodGroupsDataP) { ProjectLB.Add(entry.Name); }

                        if (ProductionMethodGroupsDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }

                        break;
                    }
                case "Production Methods":
                    {
                        if (ProjectLB.SelectedIndex == -1) { projSelectedIndex = 0; ProjectLB.SelectedIndex = 0; } else { projSelectedIndex = ProjectLB.SelectedIndex; }

                        i = Functions.hasNameIndex(ProductionMethodsDataP, ProjectLB[projSelectedIndex].ToString());
                        ProductionMethodsDataP.RemoveAt(i);
                        ProjectLB.Clear();
                        foreach (ClassProductionMethods entry in ProductionMethodsDataP) { ProjectLB.Add(entry.Name); }

                        if (ProductionMethodsDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }

                        break;
                    }
                case "Religions":
                    {
                        if (ProjectLB.SelectedIndex == -1) { projSelectedIndex = 0; ProjectLB.SelectedIndex = 0; } else { projSelectedIndex = ProjectLB.SelectedIndex; }

                        i = Functions.hasNameIndex(ReligionsDataP, ProjectLB[projSelectedIndex].ToString());
                        ReligionsDataP.RemoveAt(i);
                        ProjectLB.Clear();
                        foreach (ClassReligions entry in ReligionsDataP) { ProjectLB.Add(entry.Name); }

                        if (ReligionsDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }

                        break;
                    }
                case "State Traits":
                    {
                        if (ProjectLB.SelectedIndex == -1) { projSelectedIndex = 0; ProjectLB.SelectedIndex = 0; } else { projSelectedIndex = ProjectLB.SelectedIndex; }

                        i = Functions.hasNameIndex(StateTraitsDataP, ProjectLB[projSelectedIndex].ToString());
                        StateTraitsDataP.RemoveAt(i);
                        ProjectLB.Clear();
                        foreach (ClassStateTraits entry in StateTraitsDataP) { ProjectLB.Add(entry.Name); }

                        if (StateTraitsDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }

                        break;
                    }
                case "Technologies":
                    {
                        if (ProjectLB.SelectedIndex == -1) { projSelectedIndex = 0; ProjectLB.SelectedIndex = 0; } else { projSelectedIndex = ProjectLB.SelectedIndex; }

                        i = Functions.hasNameIndex(TechDataP, ProjectLB[projSelectedIndex].ToString());
                        TechDataP.RemoveAt(i);
                        ProjectLB.Clear();
                        foreach (ClassTech entry in TechDataP) { ProjectLB.Add(entry.Name); }

                        if (TechDataP.Count == 0) { DeleteBT.Enabled = false; }
                        else { DeleteBT.Enabled = true; }

                        break;
                    }
                default:
                    MainLB.Add("Error");
                    break;
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Extra Local Functions
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        // *
        private void ClearClassData()
        {
            BuildingGroupsDataP?.Clear();
            BuildingGroupsDataV?.Clear();
            BuildingGroupsDataM?.Clear();

            BuildingsDataP?.Clear();
            BuildingsDataV?.Clear();
            BuildingsDataM?.Clear();

            CanalsDataP?.Clear();
            CanalsDataV?.Clear();
            CanalsDataM?.Clear();

            CulturesDataP?.Clear();
            CulturesDataV?.Clear();
            CulturesDataM?.Clear();

            DecisionsDataP?.Clear();
            DecisionsDataV?.Clear();
            DecisionsDataM?.Clear();

            DecreesDataP?.Clear();
            DecreesDataV?.Clear();
            DecreesDataM?.Clear();

            ErasDataP?.Clear();
            ErasDataV?.Clear();
            ErasDataM?.Clear();

            GoodsDataP?.Clear();
            GoodsDataV?.Clear();
            GoodsDataM?.Clear();

            InstitutionsDataP?.Clear();
            InstitutionsDataV?.Clear();
            InstitutionsDataM?.Clear();

            LawGroupsDataP?.Clear();
            LawGroupsDataV?.Clear();
            LawGroupsDataM?.Clear();

            LawsDataP?.Clear();
            LawsDataV?.Clear();
            LawsDataM?.Clear();

            ModifierDataP?.Clear();
            ModifierDataV?.Clear();
            ModifierDataM?.Clear();

            ModifierTypeDataP?.Clear();
            ModifierTypeDataV?.Clear();
            ModifierTypeDataM?.Clear();

            PopNeedsDataP?.Clear();
            PopNeedsDataV?.Clear();
            PopNeedsDataM?.Clear();

            PopTypesDataP?.Clear();
            PopTypesDataV?.Clear();
            PopTypesDataM?.Clear();

            ProductionMethodGroupsDataP?.Clear();
            ProductionMethodGroupsDataV?.Clear();
            ProductionMethodGroupsDataM?.Clear();

            ProductionMethodsDataP?.Clear();
            ProductionMethodsDataV?.Clear();
            ProductionMethodsDataM?.Clear();

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
                case "Building Groups":

                    if (BuildingGroupsDataP.Count != 0)
                    {
                        if (!Directory.Exists(ProjPath + "\\common\\building_groups"))
                        {
                            Directory.CreateDirectory(ProjPath + "\\common\\building_groups");
                        }

                        using (StreamWriter sw = new StreamWriter(File.Open(ProjPath + "\\common\\building_groups\\" + ProjName.ToLower().Replace(" ", "_") + ".txt", FileMode.Create), new UTF8Encoding(true)))
                        {
                            sw.NewLine = "\n";
                            foreach (ClassBuildingGroups Entry in BuildingGroupsDataP)
                            {
                                if (Entry.Code != string.Empty)
                                {
                                    sw.WriteLine(Entry.Code);
                                }
                            }
                        }

                        // Localization
                        if (!Directory.Exists(ProjPath + "\\localization\\" + language))
                        {
                            Directory.CreateDirectory(ProjPath + "\\localization\\" + language);
                        }

                        using (StreamWriter sw = new StreamWriter(File.Open(ProjPath + "\\localization\\" + language + "\\" + ProjName.ToLower().Replace(" ", "_") + "_building_groups_l_english.yml", FileMode.Create), new UTF8Encoding(true)))
                        {
                            sw.NewLine = "\n";
                            sw.WriteLine("l_" + language + ":");

                            foreach (ClassBuildingGroups Entry in BuildingGroupsDataP)
                            {
                                sw.WriteLine(" " + Entry.Name + ":0 \"" + Entry.TrueName + "\"");
                            }
                        }
                    }

                    break;
                case "Buildings":

                    if (BuildingsDataP.Count != 0)
                    {
                        if (!Directory.Exists(ProjPath + "\\common\\buildings"))
                        {
                            Directory.CreateDirectory(ProjPath + "\\common\\buildings");
                        }

                        using (StreamWriter sw = new StreamWriter(File.Open(ProjPath + "\\common\\buildings\\" + ProjName.ToLower().Replace(" ", "_") + ".txt", FileMode.Create), new UTF8Encoding(true)))
                        {
                            sw.NewLine = "\n";
                            foreach (ClassBuildings Entry in BuildingsDataP)
                            {
                                if (Entry.Code != string.Empty)
                                {
                                    sw.WriteLine(Entry.Code);
                                }
                            }
                        }

                        // Localization
                        if (!Directory.Exists(ProjPath + "\\localization\\" + language))
                        {
                            Directory.CreateDirectory(ProjPath + "\\localization\\" + language);
                        }

                        using (StreamWriter sw = new StreamWriter(File.Open(ProjPath + "\\localization\\" + language + "\\" + ProjName.ToLower().Replace(" ", "_") + "_buildings_l_english.yml", FileMode.Create), new UTF8Encoding(true)))
                        {
                            sw.NewLine = "\n";
                            sw.WriteLine("l_" + language + ":");

                            foreach (ClassBuildings Entry in BuildingsDataP)
                            {
                                sw.WriteLine(" " + Entry.Name + ":0 \"" + Entry.TrueName + "\"");
                                sw.WriteLine(" " + Entry.Name + "_lens_option:0 \"" + Entry.LensOption + "\"");

                            }
                        }
                    }

                    break;
                case "Canals":

                    if (CanalsDataP.Count != 0)
                    {
                        if (!Directory.Exists(ProjPath + "\\common\\canals"))
                        {
                            Directory.CreateDirectory(ProjPath + "\\common\\canals");
                        }

                        using (StreamWriter sw = new StreamWriter(File.Open(ProjPath + "\\common\\canals\\" + ProjName.ToLower().Replace(" ", "_") + ".txt", FileMode.Create), new UTF8Encoding(true)))
                        {
                            sw.NewLine = "\n";
                            foreach (ClassCanals Entry in CanalsDataP)
                            {
                                if (Entry.Code != string.Empty)
                                {
                                    sw.WriteLine(Entry.Code);
                                }
                            }
                        }

                        // Localization
                        if (!Directory.Exists(ProjPath + "\\localization\\" + language))
                        {
                            Directory.CreateDirectory(ProjPath + "\\localization\\" + language);
                        }

                        using (StreamWriter sw = new StreamWriter(File.Open(ProjPath + "\\localization\\" + language + "\\" + ProjName.ToLower().Replace(" ", "_") + "_canals_l_english.yml", FileMode.Create), new UTF8Encoding(true)))
                        {
                            sw.NewLine = "\n";
                            sw.WriteLine("l_" + language + ":");

                            foreach (ClassCanals Entry in CanalsDataP)
                            {
                                sw.WriteLine(" " + Entry.Name + ":0 \"" + Entry.TrueName + "\"");
                            }
                        }
                    }

                    break;
                case "Cultures":

                    if (CulturesDataP.Count != 0)
                    {
                        if (!Directory.Exists(ProjPath + "\\common\\cultures"))
                        {
                            Directory.CreateDirectory(ProjPath + "\\common\\cultures");
                        }

                        using (StreamWriter sw = new StreamWriter(File.Open(ProjPath + "\\common\\cultures\\" + ProjName.ToLower().Replace(" ", "_") + ".txt", FileMode.Create), new UTF8Encoding(true)))
                        {
                            sw.NewLine = "\n";
                            foreach (ClassCultures Entry in CulturesDataP)
                            {
                                if (Entry.Code != string.Empty)
                                {
                                    sw.WriteLine(Entry.Code);
                                }
                            }
                        }

                        // Localization
                        if (!Directory.Exists(ProjPath + "\\localization\\" + language))
                        {
                            Directory.CreateDirectory(ProjPath + "\\localization\\" + language);
                        }

                        using (StreamWriter sw = new StreamWriter(File.Open(ProjPath + "\\localization\\" + language + "\\" + ProjName.ToLower().Replace(" ", "_") + "_cultures_l_english.yml", FileMode.Create), new UTF8Encoding(true)))
                        {
                            sw.NewLine = "\n";
                            sw.WriteLine("l_" + language + ":");

                            foreach (ClassCultures Entry in CulturesDataP)
                            {
                                sw.WriteLine(" " + Entry.Name + ":0 \"" + Entry.TrueName + "\"");
                            }
                        }
                    }

                    break;

                case "Decisions":

                    if (DecisionsDataP.Count != 0)
                    {
                        if (!Directory.Exists(ProjPath + "\\common\\decisions"))
                        {
                            Directory.CreateDirectory(ProjPath + "\\common\\decisions");
                        }

                        using (StreamWriter sw = new StreamWriter(File.Open(ProjPath + "\\common\\decisions\\" + ProjName.ToLower().Replace(" ", "_") + ".txt", FileMode.Create), new UTF8Encoding(true)))
                        {
                            sw.NewLine = "\n";
                            foreach (ClassDecisions Entry in DecisionsDataP)
                            {
                                if (Entry.Code != string.Empty)
                                {
                                    sw.WriteLine(Entry.Code);
                                }
                            }
                        }

                        // Localization
                        if (!Directory.Exists(ProjPath + "\\localization\\" + language))
                        {
                            Directory.CreateDirectory(ProjPath + "\\localization\\" + language);
                        }

                        using (StreamWriter sw = new StreamWriter(File.Open(ProjPath + "\\localization\\" + language + "\\" + ProjName.ToLower().Replace(" ", "_") + "_decisions_l_english.yml", FileMode.Create), new UTF8Encoding(true)))
                        {
                            sw.NewLine = "\n";
                            sw.WriteLine("l_" + language + ":");

                            foreach (ClassDecisions Entry in DecisionsDataP)
                            {
                                sw.WriteLine(" " + Entry.Name + ":0 \"" + Entry.TrueName + "\"");
                                sw.WriteLine(" " + Entry.Name + "_desc:0 \"" + Entry.Description + "\"");
                                if (Entry.ToolTip != string.Empty)
                                {
                                    sw.WriteLine(" " + Entry.Name + "_tooltip:0 \"" + Entry.ToolTip + "\"");
                                }
                            }
                        }
                    }

                    break;

                case "Decrees":

                    if (DecreesDataP.Count != 0)
                    {
                        if (!Directory.Exists(ProjPath + "\\common\\decrees"))
                        {
                            Directory.CreateDirectory(ProjPath + "\\common\\decrees");
                        }

                        using (StreamWriter sw = new StreamWriter(File.Open(ProjPath + "\\common\\decrees\\" + ProjName.ToLower().Replace(" ", "_") + ".txt", FileMode.Create), new UTF8Encoding(true)))
                        {
                            sw.NewLine = "\n";
                            foreach (ClassDecrees Entry in DecreesDataP)
                            {
                                if (Entry.Code != string.Empty)
                                {
                                    sw.WriteLine(Entry.Code);
                                }
                            }
                        }

                        // Localization
                        if (!Directory.Exists(ProjPath + "\\localization\\" + language))
                        {
                            Directory.CreateDirectory(ProjPath + "\\localization\\" + language);
                        }

                        using (StreamWriter sw = new StreamWriter(File.Open(ProjPath + "\\localization\\" + language + "\\" + ProjName.ToLower().Replace(" ", "_") + "_decrees_l_english.yml", FileMode.Create), new UTF8Encoding(true)))
                        {
                            sw.NewLine = "\n";
                            sw.WriteLine("l_" + language + ":");

                            foreach (ClassDecrees Entry in DecreesDataP)
                            {
                                sw.WriteLine(" " + Entry.Name + ":0 \"" + Entry.TrueName + "\"");
                                sw.WriteLine(" " + Entry.Name + "_desc:0 \"" + Entry.Description + "\"");
                            }
                        }
                    }

                    break;

                case "Eras":

                    if (ErasDataP.Count != 0)
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
                            foreach (ClassEras eraEntry in ErasDataP)
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
                            sw.WriteLine("l_" + language + ":");

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

                        using (StreamWriter sw = new StreamWriter(File.Open(ProjPath + "\\localization\\" + language + "\\" + ProjName.ToLower().Replace(" ", "_") + "_institutions_l_english.yml", FileMode.Create), new UTF8Encoding(true)))
                        {
                            sw.NewLine = "\n";
                            sw.WriteLine("l_" + language + ":");

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

                case "Law Groups":

                    if (LawGroupsDataP.Count != 0)
                    {
                        if (!Directory.Exists(ProjPath + "\\common\\law_groups"))
                        {
                            Directory.CreateDirectory(ProjPath + "\\common\\law_groups");
                        }

                        using (StreamWriter sw = new StreamWriter(File.Open(ProjPath + "\\common\\law_groups\\" + ProjName.ToLower().Replace(" ", "_") + ".txt", FileMode.Create), new UTF8Encoding(true)))
                        {
                            sw.NewLine = "\n";
                            foreach (ClassLawGroups Entry in LawGroupsDataP)
                            {
                                if (Entry.Code != string.Empty)
                                {
                                    sw.WriteLine(Entry.Code);
                                }
                            }
                        }

                        // Localization
                        if (!Directory.Exists(ProjPath + "\\localization\\" + language))
                        {
                            Directory.CreateDirectory(ProjPath + "\\localization\\" + language);
                        }

                        using (StreamWriter sw = new StreamWriter(File.Open(ProjPath + "\\localization\\" + language + "\\" + ProjName.ToLower().Replace(" ", "_") + "_law_groups_l_english.yml", FileMode.Create), new UTF8Encoding(true)))
                        {
                            sw.NewLine = "\n";
                            sw.WriteLine("l_" + language + ":");

                            foreach (ClassLawGroups Entry in LawGroupsDataP)
                            {
                                sw.WriteLine(" " + Entry.Name + ":0 \"" + Entry.TrueName + "\"");
                                sw.WriteLine(" " + Entry.Name + "_desc:0 \"" + Entry.Description + "\"");
                            }
                        }
                    }

                    break;

                case "Laws":

                    if (LawsDataP.Count != 0)
                    {
                        if (!Directory.Exists(ProjPath + "\\common\\laws"))
                        {
                            Directory.CreateDirectory(ProjPath + "\\common\\laws");
                        }

                        using (StreamWriter sw = new StreamWriter(File.Open(ProjPath + "\\common\\laws\\" + ProjName.ToLower().Replace(" ", "_") + ".txt", FileMode.Create), new UTF8Encoding(true)))
                        {
                            sw.NewLine = "\n";
                            foreach (ClassLaws Entry in LawsDataP)
                            {
                                if (Entry.Code != string.Empty)
                                {
                                    sw.WriteLine(Entry.Code);
                                }
                            }
                        }

                        // Localization
                        if (!Directory.Exists(ProjPath + "\\localization\\" + language))
                        {
                            Directory.CreateDirectory(ProjPath + "\\localization\\" + language);
                        }

                        using (StreamWriter sw = new StreamWriter(File.Open(ProjPath + "\\localization\\" + language + "\\" + ProjName.ToLower().Replace(" ", "_") + "_laws_l_english.yml", FileMode.Create), new UTF8Encoding(true)))
                        {
                            sw.NewLine = "\n";
                            sw.WriteLine("l_" + language + ":");

                            foreach (ClassLaws Entry in LawsDataP)
                            {
                                sw.WriteLine(" " + Entry.Name + ":0 \"" + Entry.TrueName + "\"");
                                sw.WriteLine(" " + Entry.Name + "_desc:0 \"" + Entry.Description + "\"");
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
                            sw.WriteLine("l_" + language + ":");

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

                                if (!string.IsNullOrEmpty(Entry.Translate))
                                {
                                    sw.WriteLine("\ttranslate = " + Entry.Translate);
                                }

                                if (!string.IsNullOrEmpty(Entry.Postfix))
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

                        using (StreamWriter sw = new StreamWriter(File.Open(ProjPath + "\\localization\\" + language + "\\" + ProjName.ToLower().Replace(" ", "_") + "_pop_needs_l_english.yml", FileMode.Create), new UTF8Encoding(true)))
                        {
                            sw.NewLine = "\n";
                            sw.WriteLine("l_" + language + ":");

                            foreach (ClassPopNeeds Entry in PopNeedsDataP)
                            {
                                sw.WriteLine(" " + Entry.Name + ":0 \"" + Entry.TrueName + "\"");
                            }
                        }
                    }

                    break;

                case "Pop Types":

                    if (PopTypesDataP.Count != 0)
                    {
                        if (!Directory.Exists(ProjPath + "\\common\\pop_types"))
                        {
                            Directory.CreateDirectory(ProjPath + "\\common\\pop_types");
                        }

                        using (StreamWriter sw = new StreamWriter(File.Open(ProjPath + "\\common\\pop_types\\" + ProjName.ToLower().Replace(" ", "_") + ".txt", FileMode.Create), new UTF8Encoding(true)))
                        {
                            sw.NewLine = "\n";
                            foreach (ClassPopTypes Entry in PopTypesDataP)
                            {
                                if (Entry.Code != string.Empty)
                                {
                                    sw.WriteLine(Entry.Code);
                                }
                            }
                        }

                        // Localization
                        if (!Directory.Exists(ProjPath + "\\localization\\" + language))
                        {
                            Directory.CreateDirectory(ProjPath + "\\localization\\" + language);
                        }

                        using (StreamWriter sw = new StreamWriter(File.Open(ProjPath + "\\localization\\" + language + "\\" + ProjName.ToLower().Replace(" ", "_") + "_pop_types_l_english.yml", FileMode.Create), new UTF8Encoding(true)))
                        {
                            sw.NewLine = "\n";
                            sw.WriteLine("l_" + language + ":");

                            foreach (ClassPopTypes Entry in PopTypesDataP)
                            {
                                sw.WriteLine(" " + Entry.Name + ":0 \"" + Entry.TrueName + "\"");
                                sw.WriteLine(" " + Entry.Name + "_only_icon:0 \"" + Entry.OnlyIcon + "\"");
                                sw.WriteLine(" " + Entry.Name + "_no_icon:0 \"" + Entry.NoIcon + "\"");
                                sw.WriteLine(" " + Entry.Name + "_desc:0 \"" + Entry.Description + "\"");
                                if (Entry.QualificationsDesc != string.Empty)
                                {
                                    sw.WriteLine(" " + Entry.Name.ToUpper() + "_QUALIFICATIONS_DESC:0 \"" + Entry.QualificationsDesc + "\"");
                                }
                            }
                        }
                    }

                    break;

                case "Production Method Groups":

                    if (ProductionMethodGroupsDataP.Count != 0)
                    {
                        if (!Directory.Exists(ProjPath + "\\common\\production_method_groups"))
                        {
                            Directory.CreateDirectory(ProjPath + "\\common\\production_method_groups");
                        }

                        using (StreamWriter sw = new StreamWriter(File.Open(ProjPath + "\\common\\production_method_groups\\" + ProjName.ToLower().Replace(" ", "_") + ".txt", FileMode.Create), new UTF8Encoding(true)))
                        {
                            sw.NewLine = "\n";
                            foreach (ClassProductionMethodGroups Entry in ProductionMethodGroupsDataP)
                            {
                                sw.WriteLine(Entry.Name + " = {");
                                sw.WriteLine("\ttexture = \"" + Entry.Texture + "\"");
                                if (Entry.Ai_selection) { sw.WriteLine("\tai_selection = most_productive"); }
                                if (Entry.Is_hidden_when_unavailable) { sw.WriteLine("\tis_hidden_when_unavailable = yes"); }
                                if (Entry.Production_methods.Count != 0)
                                {
                                    sw.WriteLine("\n\tproduction_methods = {");
                                    foreach (string entry in Entry.Production_methods)
                                    {
                                        sw.WriteLine("\t\t" + entry);
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

                        using (StreamWriter sw = new StreamWriter(File.Open(ProjPath + "\\localization\\" + language + "\\" + ProjName.ToLower().Replace(" ", "_") + "_production_method_groups_l_english.yml", FileMode.Create), new UTF8Encoding(true)))
                        {
                            sw.NewLine = "\n";
                            sw.WriteLine("l_" + language + ":");

                            foreach (ClassProductionMethodGroups Entry in ProductionMethodGroupsDataP)
                            {
                                sw.WriteLine(" " + Entry.Name + ":0 \"" + Entry.TrueName + "\"");
                            }
                        }
                    }

                    break;

                case "Production Methods":

                    if (ProductionMethodsDataP.Count != 0)
                    {
                        if (!Directory.Exists(ProjPath + "\\common\\production_methods"))
                        {
                            Directory.CreateDirectory(ProjPath + "\\common\\production_methods");
                        }

                        using (StreamWriter sw = new StreamWriter(File.Open(ProjPath + "\\common\\production_methods\\" + ProjName.ToLower().Replace(" ", "_") + ".txt", FileMode.Create), new UTF8Encoding(true)))
                        {
                            sw.NewLine = "\n";
                            foreach (ClassProductionMethods Entry in ProductionMethodsDataP)
                            {
                                if (Entry.Code != string.Empty)
                                {
                                    sw.WriteLine(Entry.Code);
                                }
                            }
                        }

                        // Localization
                        if (!Directory.Exists(ProjPath + "\\localization\\" + language))
                        {
                            Directory.CreateDirectory(ProjPath + "\\localization\\" + language);
                        }

                        using (StreamWriter sw = new StreamWriter(File.Open(ProjPath + "\\localization\\" + language + "\\" + ProjName.ToLower().Replace(" ", "_") + "_production_methods_l_english.yml", FileMode.Create), new UTF8Encoding(true)))
                        {
                            sw.NewLine = "\n";
                            sw.WriteLine("l_" + language + ":");

                            foreach (ClassProductionMethods Entry in ProductionMethodsDataP)
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
                            sw.WriteLine("l_" + language + ":");

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
                            sw.WriteLine("l_" + language + ":");

                            foreach (ClassStateTraits entry in StateTraitsDataP)
                            {
                                sw.WriteLine(" " + entry.Name + ":0 \"" + entry.TrueName + "\"");
                            }
                        }


                    }

                    break;

                case "Technologies":

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
                            sw.WriteLine("l_" + language + ":");

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