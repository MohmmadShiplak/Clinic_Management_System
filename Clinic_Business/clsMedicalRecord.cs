using Clinic_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Business
{
    public  class clsMedicalRecord
    {

        private enum enMode { AddNew = 0, UpdateNew = 1 };

        private enMode _Mode = enMode.AddNew;

        public int ?ID { get; set; }

        public int? PatientID { get; set; }
        public string Description { get; set; }
        public string Diagonsis { get; set; }

        public string Notes { get; set; }


        public clsMedicalRecord()
        {

            this.ID = null;
            this.PatientID = null;
            this.Description = null;
            this.Diagonsis = null;
            this.Notes =null;
          

            _Mode = enMode.AddNew;

        }
        public clsMedicalRecord(int ?ID,int ?PatientID ,string Description, string Diagonsis, string Notes )
            
        {
            this.ID = ID;
            this.PatientID =PatientID; 
            this.Description = Description;
            this.Diagonsis = Diagonsis;
            this.Notes = Notes;
         

            _Mode = enMode.UpdateNew;
        }
        private bool AddNewMedicalRecord()
        {

            this.ID = clsMedicalRecordData.AddNewMedicalRecord(this.PatientID,this.Description, this.Diagonsis
                , this.Notes);

            return (this.ID != -1);

        }
        private bool UpdateMedicalRecord()
        {
            return clsMedicalRecordData.UpdateMedicalRecords(this.ID,this.PatientID, this.Description, this.Diagonsis
                , this.Notes);
        }
        public bool Save()
        {

            switch (_Mode)
            {

                case enMode.AddNew:
                    if (AddNewMedicalRecord())
                    {

                        _Mode = enMode.UpdateNew;

                        return true;


                    }
                    else
                    {
                        return false;
                    }
                case enMode.UpdateNew:
                    return UpdateMedicalRecord();

            }
            return false;
        }
        public static clsMedicalRecord Find(int? ID)
        {

            string Description = "", Diagonsis = "";

            string Notes = "";

            int? PatientID = null;

            if (clsMedicalRecordData.GetMedicalRecordInfobyID(ID,ref PatientID, ref Description
                , ref Diagonsis, ref Notes  ))
                return new clsMedicalRecord(ID, PatientID, Description, Diagonsis, Notes );
            else
                return null;


        }
        public static bool Delete(int ID) => clsMedicalRecordData.DeleteMedicalRecord(ID);

        public static DataTable GetAllMedicalRecords() => clsMedicalRecordData.GetAllMedicalRecords();

        public static int Count()=>clsMedicalRecordData.Count();












    }
}
