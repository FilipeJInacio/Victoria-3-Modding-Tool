using System.Collections.Generic;

namespace Victoria_3_Modding_Tool
{

    public class ClassBuildingGroups : IType
    {
        /*
        # parent_group = parent_group_key		    If set, this group is considered a child of the specified group. Default no parent.
        # always_possible = yes/no				    If yes, building types in this group are always permitted regardless of resources in state. Default no.
        # economy_of_scale = yes/no				    If yes, any non-subsistence buildings in or underneath this group will get an economy of scale throughput modifier for each level > 1. Default no.
        # is_subsistence = yes/no				    If yes, buildings of types in this group are considered subsistence buildings that follow special rules. Default no.
        # default_building = building_type_key	    Specifies the default building type that will be built unless the state specifies a different one. No default.
        # lens = lens_key						    If specified, determines the lens buildings in this group will be sorted under. No default.
        # auto_place_buildings = yes/no
        # capped_by_resources = yes/no
        # discoverable_resource = yes/no
        # depletable_resource = yes/no
        # can_use_slaves = yes/no				    Default no, setting yes enables slavery for all contained buildings and groups
        # land_usage = urban/rural				    Which type of state resource the building uses. urban = Urbanization, rural = Arable Land. Default no state resource usage.
        #										    If unspecified, will return first non-default land usage type found in parent building group tree.
        # cash_reserves_max = number			    Maximum amount of £ (per level) that buildings in this group can store into their cash reserves. If unspecified or set to 0, it will use the value from the parent group. Default 0
        # inheritable_construction =  yes/no	    If yes, a construction of this building group will survive a state changing hands or a split state merging
        # stateregion_max_level = yes/no		    If yes, any building types in this group with the has_max_level property will consider its level restrictions on state-region rather than state level	
        # urbanization = number					    The amount of urbanization buildings in this group provides per level
        # should_auto_expand = trigger			    Under which condition buildings in this group should auto-expand if auto-expand is toggled on (trigger on more specific group or building type overrides)
        # 										    If this trigger has any contents at all, the game will think the building is potentially auto-expandable, so do not write triggers that can never evaluate to true here
        # hiring_rate = X						    How much of the building's max staffing level can be hired in a single week (default NDefines::NEconomy::HIRING_RATE)
        # proportionality_limit = X				    How high is the building's tolerance for pop types being out of proportion? default NDefines::NEconomy::EMPLOYMENT_PROPORTIONALITY_LIMIT)
        # hires_unemployed_only = yes			    If yes, buildings in this group may only hire from the unemployment pool. Default no.
        # infrastructure_usage_per_level = number	How much of the state's infrastructure is used per level of this building. Default 0.
        # fired_pops_become_radical = yes/no		If yes, pops fired from this building will become radicalized. Default no.
        */

        public string Name { get; set; }

        public string TrueName { get; set; }

        public string LensOption { get; set; }

        public string Code { get; set; }

        public ClassBuildingGroups()
        { }

        public ClassBuildingGroups(ClassBuildingGroups Decision)
        {
            this.Name = Decision.Name;
            this.TrueName = Decision.TrueName;
            this.Code = Decision.Code;
        }

        public ClassBuildingGroups(string name, string trueName, string code)
        {
            this.Name = name;
            this.TrueName = trueName;
            this.Code = code;
        }

        public ClassBuildingGroups(KeyValuePair<string, object> ParserData, string trueName)
        {
            this.Name = ParserData.Key;
            this.TrueName = trueName;
            this.Code = (string)ParserData.Value;
        }

    }

    /*
    public class ClassBuildingGroups : IType
    {
        

        public string Name { get; set; }
        public string TrueName { get; set; }
        public string ParentGroup { get; set; }
        public bool AlwaysPossible { get; set; }
        public bool EconomyOfScale { get; set; }
        public bool IsSubsistence { get; set; }
        public string DefaultBuilding { get; set; }
        public string Lens { get; set; }
        public bool AutoPlaceBuilding { get; set; }
        public bool CappedByResources { get; set; }
        public bool DiscoverableResource { get; set; }
        public bool DepletableResource { get; set; }
        public bool CanUseSlaves { get; set; }
        public string LandUsage { get; set; }
        public int CashReserves { get; set; }
        public bool InheritableConstraction { get; set; }
        public bool StateRegionMaxLevel { get; set; }
        public int Urbanization { get; set; }
        public string ShouldAutoExpand { get; set; } // Default - No - Custom -> in code
        public float HiringRate { get; set; }
        public float ProportionalityLimit { get; set; }
        public bool HiresUnemployedOnly { get; set; }
        public int InfrastructureUsagePerLevel { get; set; }
        public bool FiredPopsBecomeRadical { get; set; }


        // 6 strings, 12 bools , 3 ints, 2 floats

        public ClassBuildingGroups() { }

        public ClassBuildingGroups(string name, string trueName,string parentGroup,bool alwaysPossible,bool economyOfScale, bool isSubsistence, string defaultBuilding, string lens, bool autoPlaceBuilding, bool cappedByResources, bool discoverableResource, bool depletableResource, bool canUseSlaves, string landUsage, int cashReserves, bool inheritableConstraction, bool stateRegionMaxLevel, int urbanization,string shouldAutoExpand, float hiringRate, float proportionalityLimit, bool hiresUnemployedOnly, int infrastructureUsagePerLevel, bool firedPopsBecomeRadical)
        {
            this.Name = name;
            this.TrueName = trueName;
            this.ParentGroup = parentGroup;
            this.AlwaysPossible= alwaysPossible;
            this.EconomyOfScale= economyOfScale;
            this.IsSubsistence= isSubsistence;
            this.DefaultBuilding= defaultBuilding;
            this.Lens= lens;
            this.AutoPlaceBuilding= autoPlaceBuilding;
            this.CappedByResources= cappedByResources;
            this.DiscoverableResource= discoverableResource;
            this.DepletableResource= depletableResource;
            this.CanUseSlaves= canUseSlaves;
            this.LandUsage= landUsage;
            this.CashReserves= cashReserves;
            this.InheritableConstraction= inheritableConstraction;
            this.StateRegionMaxLevel= stateRegionMaxLevel;
            this.Urbanization= urbanization;
            this.ShouldAutoExpand= shouldAutoExpand;
            this.HiringRate= hiringRate;
            this.ProportionalityLimit= proportionalityLimit;
            this.HiresUnemployedOnly= hiresUnemployedOnly;
            this.InfrastructureUsagePerLevel= infrastructureUsagePerLevel;
            this.FiredPopsBecomeRadical = firedPopsBecomeRadical;
        }


        public ClassBuildingGroups(ClassBuildingGroups BG)
        {
            this.Name = BG.Name;
            this.TrueName = BG.TrueName;
            this.ParentGroup = BG.ParentGroup;
            this.AlwaysPossible = BG.AlwaysPossible;
            this.EconomyOfScale = BG.EconomyOfScale;
            this.IsSubsistence = BG.IsSubsistence;
            this.DefaultBuilding = BG.DefaultBuilding;
            this.Lens = BG.Lens;
            this.AutoPlaceBuilding = BG.AutoPlaceBuilding;
            this.CappedByResources = BG.CappedByResources;
            this.DiscoverableResource = BG.DiscoverableResource;
            this.DepletableResource = BG.DepletableResource;
            this.CanUseSlaves = BG.CanUseSlaves;
            this.LandUsage = BG.LandUsage;
            this.CashReserves = BG.CashReserves;
            this.InheritableConstraction = BG.InheritableConstraction;
            this.StateRegionMaxLevel = BG.StateRegionMaxLevel;
            this.Urbanization = BG.Urbanization;
            this.ShouldAutoExpand = BG.ShouldAutoExpand;
            this.HiringRate = BG.HiringRate;
            this.ProportionalityLimit = BG.ProportionalityLimit;
            this.HiresUnemployedOnly = BG.HiresUnemployedOnly;
            this.InfrastructureUsagePerLevel = BG.InfrastructureUsagePerLevel;
            this.FiredPopsBecomeRadical = BG.FiredPopsBecomeRadical;
        }

        public ClassBuildingGroups(KeyValuePair<string, object> ParserData,string TrueName)
        {
            this.Name = ParserData.Key;
            this.TrueName = TrueName;
            this.AlwaysPossible = false;
            this.EconomyOfScale = false;
            this.IsSubsistence= false;
            this.AutoPlaceBuilding = false;
            this.CappedByResources= false;
            this.DiscoverableResource = false;
            this.DepletableResource = false;
            this.CanUseSlaves= false;
            this.InheritableConstraction= false;
            this.StateRegionMaxLevel = false;
            this.HiresUnemployedOnly = false;
            this.FiredPopsBecomeRadical = false;

            foreach (KeyValuePair<string, object> element in (List<KeyValuePair<string, object>>)ParserData.Value)
            {
                switch (element.Key)
                {
                    case "parent_group":
                        this.ParentGroup = element.Value.ToString(); 
                        continue;
                    case "always_possible":
                        if (element.Value.ToString() == "yes") { this.AlwaysPossible = true; } else { this.AlwaysPossible = false; } 
                        continue;
                    case "economy_of_scale":
                        if (element.Value.ToString() == "yes") { this.EconomyOfScale = true; } else { this.EconomyOfScale = false; } 
                        continue;
                    case "is_subsistence":
                        if (element.Value.ToString() == "yes") { this.IsSubsistence = true; } else { this.IsSubsistence = false; }
                        continue;
                    case "default_building":
                        this.DefaultBuilding = element.Value.ToString();
                        continue;
                    case "lens":
                        this.Lens = element.Value.ToString();
                        continue;
                    case "auto_place_buildings":
                        if (element.Value.ToString() == "yes") { this.AutoPlaceBuilding = true; } else { this.AutoPlaceBuilding = false; }
                        continue;
                    case "capped_by_resources":
                        if (element.Value.ToString() == "yes") { this.CappedByResources = true; } else { this.CappedByResources = false; }
                        continue;
                    case "discoverable_resource":
                        if (element.Value.ToString() == "yes") { this.DiscoverableResource = true; } else { this.DiscoverableResource = false; }
                        continue;
                    case "depletable_resource":
                        if (element.Value.ToString() == "yes") { this.DepletableResource = true; } else { this.DepletableResource = false; }
                        continue;
                    case "can_use_slaves":
                        if (element.Value.ToString() == "yes") { this.CanUseSlaves = true; } else { this.CanUseSlaves = false; }
                        continue;
                    case "land_usage":
                        this.LandUsage = element.Value.ToString();
                        continue;
                    case "cash_reserves_max":
                        this.CashReserves = Int32.Parse(element.Value.ToString());
                        continue;
                    case "inheritable_construction":
                        if (element.Value.ToString() == "yes") { this.InheritableConstraction = true; } else { this.InheritableConstraction = false; }
                        continue;
                    case "stateregion_max_level":
                        if (element.Value.ToString() == "yes") { this.StateRegionMaxLevel = true; } else { this.StateRegionMaxLevel = false; }
                        continue;
                    case "urbanization":
                        this.Urbanization = Int32.Parse(element.Value.ToString());
                        continue;
                    case "should_auto_expand":
                        this.ShouldAutoExpand = element.Value.ToString(); // TO DO
                        continue;
                    case "hiring_rate":
                        this.HiringRate = float.Parse(element.Value.ToString(), CultureInfo.InvariantCulture.NumberFormat); continue;
                    case "proportionality_limit":
                        this.ProportionalityLimit = float.Parse(element.Value.ToString(), CultureInfo.InvariantCulture.NumberFormat); continue;
                    case "hires_unemployed_only":
                        if (element.Value.ToString() == "yes") { this.HiresUnemployedOnly = true; } else { this.HiresUnemployedOnly = false; }
                        continue;
                    case "infrastructure_usage_per_level":
                        this.InfrastructureUsagePerLevel = Int32.Parse(element.Value.ToString());
                        continue;
                    case "fired_pops_become_radical":
                        if (element.Value.ToString() == "yes") { this.FiredPopsBecomeRadical = true; } else { this.FiredPopsBecomeRadical = false; }
                        continue;

                    default:
                        continue;
                }
            }

        }


    }
    */

    public class ClassBuildings : IType
    {
        public string Name { get; set; }

        public string TrueName { get; set; }

        public string LensOption  { get; set; } 

        public string Code { get; set; }

        public ClassBuildings()
        { }

        public ClassBuildings(ClassBuildings Decision)
        {
            this.Name = Decision.Name;
            this.TrueName = Decision.TrueName;
            this.LensOption= Decision.LensOption;
            this.Code = Decision.Code;
        }

        public ClassBuildings(string name, string trueName, string lensOption, string code)
        {
            this.Name = name;
            this.TrueName = trueName;
            this.LensOption= lensOption;
            this.Code = code;
        }

        public ClassBuildings(KeyValuePair<string, object> ParserData, string trueName, string lensOption)
        {
            this.Name = ParserData.Key;
            this.TrueName = trueName;
            this.LensOption= lensOption;
            this.Code = (string)ParserData.Value;
        }

    }
}