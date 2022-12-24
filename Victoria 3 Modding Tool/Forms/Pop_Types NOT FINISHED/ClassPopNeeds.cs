using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Web;

namespace Victoria_3_Modding_Tool.Forms.Tech
{
    public class ClassPopTypesPolitical
    {
        public string goods { get; set; }
        public float weight { get; set; }
        public float minWeight { get; set; }
        public float maxWeight { get; set; }


 

    }

    public class ClassPopTypesQualifications
    {
        public string goods { get; set; }
        public float weight { get; set; }
        public float minWeight { get; set; }
        public float maxWeight { get; set; }


    }

    public class ClassPopTypes
    {
        public string name { get; set; } // NEEDED
        public string texture { get; set; } // NEEDED
        public Color color { get; set; } // NEEDED
        public string strata { get; set; } // NEEDED
        public bool subsistence_income { get; set; } // DEFAULT -> false
        public bool is_slave { get; set; }  // DEFAULT -> false
        public float start_quality_of_life { get; set; } // NEEDED
        public bool can_always_hire { get; set; } // DEFAULT -> false
        public bool ignores_employment_proportionality { get; set; } // DEFAULT -> false
        public float working_adult_ratio { get; set; } // DEFAULT -> 1
        public float wage_weight { get; set; } // NEEDED
        public float consumption_mult { get; set; } // DEFAULT -> 1
        public float literacy_target { get; set; } // DEFAULT -> 0
        public float education_access { get; set; } // DEFAULT -> 0
        public float dependent_wage { get; set; } // NEEDED
        public bool unemployment { get; set; } // NEEDED
        public float political_engagement_base { get; set; } // NEEDED
        public float political_engagement_literacy_factor { get; set; } // NEEDED
        public ClassPopTypesPolitical political_engagement_mult { get; set; } // NEEDED
        public string qualifications_growth_desc { get; set; } // NEEDED
        public ClassPopTypesQualifications qualifications { get; set; } // NEEDED
        public int portrait_age_min { get; set; } // NEEDED
        public int portrait_age_max { get; set; } // NEEDED
        public int portrait_pose { get; set; } // NEEDED
        public bool portrait_is_female { get; set; } // NEEDED


        public ClassPopTypes() { }

        public ClassPopTypes(ClassPopTypes PopTypes)
        {
            name = PopTypes.name;
            texture = PopTypes.texture;
            color = PopTypes.color;
            strata = PopTypes.strata;
            subsistence_income = PopTypes.subsistence_income;
            is_slave = PopTypes.is_slave;
            start_quality_of_life = PopTypes.start_quality_of_life;
            can_always_hire = PopTypes.can_always_hire;
            ignores_employment_proportionality = PopTypes.ignores_employment_proportionality;
            working_adult_ratio = PopTypes.working_adult_ratio;
            wage_weight = PopTypes.wage_weight;
            consumption_mult = PopTypes.consumption_mult;
            literacy_target = PopTypes.literacy_target;
            education_access = PopTypes.education_access;
            dependent_wage = PopTypes.dependent_wage;
            unemployment = PopTypes.unemployment;
            political_engagement_base = PopTypes.political_engagement_base;
            political_engagement_literacy_factor = PopTypes.political_engagement_literacy_factor;
            political_engagement_mult = PopTypes.political_engagement_mult;
            qualifications_growth_desc = PopTypes.qualifications_growth_desc;
            qualifications = PopTypes.qualifications;
            portrait_age_min = PopTypes.portrait_age_min;
            portrait_age_max = PopTypes.portrait_age_max;
            portrait_pose = PopTypes.portrait_pose;
            portrait_is_female = PopTypes.portrait_is_female;

        }

        public ClassPopTypes(string name, string texture, Color color, string strata, bool subsistence_income, bool is_slave, float start_quality_of_life, bool can_always_hire, bool ignores_employment_proportionality, float working_adult_ratio, float wage_weight, float consumption_mult ,float literacy_target,float education_access,float dependent_wage,bool unemployment, float political_engagement_base , float political_engagement_literacy_factor , ClassPopTypesPolitical political_engagement_mult,string qualifications_growth_desc, ClassPopTypesQualifications qualifications,int portrait_age_min,int portrait_age_max,int portrait_pose,bool portrait_is_female)
        {
            this.name = name;
            this.texture = texture;
            this.color = color;
            this.strata = strata;
            this.subsistence_income = subsistence_income;
            this.is_slave = is_slave;
            this.start_quality_of_life = start_quality_of_life;
            this.can_always_hire = can_always_hire;
            this.ignores_employment_proportionality = ignores_employment_proportionality;
            this.working_adult_ratio = working_adult_ratio;
            this.wage_weight = wage_weight;
            this.consumption_mult = consumption_mult;
            this.literacy_target = literacy_target;
            this.education_access = education_access;
            this.dependent_wage = dependent_wage;
            this.unemployment = unemployment;
            this.political_engagement_base = political_engagement_base;
            this.political_engagement_literacy_factor = political_engagement_literacy_factor;
            this.political_engagement_mult = political_engagement_mult;
            this.qualifications_growth_desc = qualifications_growth_desc;
            this.qualifications = qualifications;
            this.portrait_age_min = portrait_age_min;
            this.portrait_age_max = portrait_age_max;
            this.portrait_pose = portrait_pose;
            this.portrait_is_female = portrait_is_female;
        }

     






        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Has name in list
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        public bool hasName(List<ClassPopNeeds> popNeeds, string name)
        {
            foreach (ClassPopNeeds entry in popNeeds)
            {
                if (entry.name == name)
                {
                    return true;
                }
            }

            return false;
        }

        public int hasNameIndex(List<ClassPopNeeds> popNeeds, string name)
        {
            int i = 0;
            foreach (ClassPopNeeds entry in popNeeds)
            {
                if (entry.name == name)
                {
                    return i;
                }
                i++;
            }

            return -1;
        }


        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Merge TechClass list
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        public List<ClassPopNeeds> Merge(List<ClassPopNeeds> Pri, List<ClassPopNeeds> Sec)
        {
            List<ClassPopNeeds> result = new List<ClassPopNeeds>();

            foreach (ClassPopNeeds Entry in Pri)
            {
                result.Add(Entry);
            }

            foreach (ClassPopNeeds Entry in Sec)
            {
                if (!new ClassPopNeeds().hasName(result, Entry.name))
                {
                    result.Add(Entry);
                }
            }

            return result;
        }


    }

}