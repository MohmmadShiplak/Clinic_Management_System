using Clinic_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Business
{
    public  class clsMedicationNames
    {

        public enum enMode { AddNew = 0, UpdateNew = 1 }
        public enMode _Mode;


        public int? MedicationID { get; set; }
        public string MedicationName { get; set; }






        public clsMedicationNames(int? ID, string MedicationName)
        {

            this.MedicationID = ID;
            this.MedicationName = MedicationName;

            _Mode = enMode.UpdateNew;
        }






        public static DataTable AllOnlyNames() => clsMedicationNamesData.GetAllMedicationNames();


        public static clsMedicationNames Find(int? MedicationID)
        {

            string MedicationName = "";


            if (clsMedicationNamesData.GetMedicationNamesInfoByID(MedicationID, ref MedicationName))
                return new clsMedicationNames(MedicationID, MedicationName);
            else
                return null;

        }
        public static clsMedicationNames Find(string MedicationName)
        {

            int? MedicationID = null;


            if (clsMedicationNamesData.GetAllMedicationNamesInfoByName(MedicationName, ref MedicationID))
                return new clsMedicationNames(MedicationID, MedicationName);
            else
                return null;

        }


















    }
}
