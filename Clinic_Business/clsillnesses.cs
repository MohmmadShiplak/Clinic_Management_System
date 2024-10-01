using Clinic_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Business
{
    public  class clsillnesses
    {

        public enum enMode { AddNew = 0, UpdateNew = 1 }
        public enMode _Mode;


        public int? illnessID { get; set; }
        public string illnessName { get; set; }

       




        public clsillnesses(int? ID, string illnessName)
        {

            this.illnessID = ID;
            this.illnessName = illnessName;

            _Mode = enMode.UpdateNew;
        }






        public static DataTable AllOnlyNames() => clsillnessesData.AllOnlyNames();


        public static  clsillnesses Find(int ?IllnessID)
        {

            string illnessName = "";


            if (clsillnessesData.GetIllnessesInfoByID(IllnessID, ref illnessName))
                return new clsillnesses(IllnessID, illnessName);
            else
                return null;

        }
        public static clsillnesses Find(string illnessName)
        {

            int? illnessID = null;


            if (clsillnessesData.GetAllillnessesInfoByName(illnessName, ref illnessID))
                return new clsillnesses(illnessID, illnessName);
            else
                return null;

        }












    }
}
