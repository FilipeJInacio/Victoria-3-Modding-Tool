using System.Collections.Generic;

namespace Victoria_3_Modding_Tool.Forms.Era
{
    public class ClassEra
    {
        public int Era { get; set; }
        public int Cost { get; set; }

        public ClassEra() { }
        public ClassEra(int era, int cost)
        {
            this.Era = era;
            this.Cost = cost;
        }

        public bool FindEra(List<ClassEra> EraData, int Era)
        {
            foreach (ClassEra EraEntry in EraData)
            {
                if (EraEntry.Era == Era)
                {

                    return true;
                }
            }
            return false;
        }

        public bool FindEraValue(List<ClassEra> EraData, int Era , int Value)
        {
            foreach (ClassEra EraEntry in EraData)
            {
                if (EraEntry.Era == Era && EraEntry.Cost == Value)
                {

                    return true;
                }
            }
            return false;
        }

        public int FindEraValue(List<ClassEra> EraData, int Era)
        {
            int i = 0;
            foreach (ClassEra EraEntry in EraData)
            {
                if (EraEntry.Era == Era) { return i; }
                i++;
            }
            return -1;
        }

        public List<ClassEra> MergeEra(List<ClassEra> Pri, List<ClassEra> Sec)
        {

            List<ClassEra> ListE = new List<ClassEra>();

            foreach(ClassEra eraEntry in Pri)
            {
                ListE.Add(new ClassEra(eraEntry.Era, eraEntry.Cost));
            }

            foreach (ClassEra SecEntry in Sec)
            {
                if (!FindEra(ListE, SecEntry.Era))
                {
                    ListE.Add(new ClassEra(SecEntry.Era, SecEntry.Cost));
                }
            }

            ListE.Sort(delegate (ClassEra t1, ClassEra t2)
            {   // 0.5 s Make more efi
                return (t1.Era.CompareTo(t2.Era));
            });

            return ListE;
        }

    }
}
