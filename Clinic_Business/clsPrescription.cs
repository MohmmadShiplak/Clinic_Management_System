using Clinic_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Business
{
    public  class clsPrescription
    {

        public enum enMode { AddNew = 0, UpdateNew = 1 };
        public enMode _Mode;



        public int? PrescriptionID { get; set; }

        public int? PatientID { get; set; }


        public int  ?MedicationID { get; set; }

        public string Dosage { get; set; }

        public string Frequency { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

      
        public string SpecialInstructions { get; set; }

        public clsMedicationNames MedicationNamesInfo;

     




        public clsPrescription()
        {

            this.PrescriptionID = null;
            this.PatientID = null;
            this.MedicationID = 0;
            this.Dosage = null;
            this.Frequency = null;
            this.StartDate = DateTime.Now;
            this.EndDate = DateTime.Now;
            this.SpecialInstructions = null;
         


            _Mode = enMode.AddNew;




        }
        public clsPrescription(int ?PrescriptionID, int ?PatientID, int  ?MedicationID,  string Dosage,  string Frequency,
  DateTime StartDate, DateTime EndDate, string SpeciallInstruction)
        {

            this.PrescriptionID = PrescriptionID;
            this.PatientID = PatientID;
            this.MedicationID = MedicationID;
            this.Dosage= Dosage;
            this.Frequency = Frequency;
            this.StartDate = StartDate;
            this.EndDate =EndDate;
            this.SpecialInstructions = SpeciallInstruction;
            this.MedicationNamesInfo = clsMedicationNames.Find(MedicationID);
            //   this.AppointmentsInfo = clsAppointments.Find(PersonID);
            _Mode = enMode.UpdateNew;

        }
        private bool AddNewPrescription()
        {

            this.PrescriptionID = clsPrescriptionData.AddNewPrescription(this.PatientID, this.MedicationID, this.Dosage, this.Frequency, this.StartDate, this.EndDate, this.SpecialInstructions);
                

            return (PrescriptionID.HasValue);

        }
        private bool UpdatePrescription()
        {
            return clsPrescriptionData.UpdatePrescription(this.PrescriptionID, this.PatientID, this.MedicationID, this.Dosage, this.Frequency, this.StartDate, this.EndDate, this.SpecialInstructions);
        }
        public bool Save()
        {

            switch (_Mode)
            {
                case enMode.AddNew:
                    if (AddNewPrescription())
                    {

                        _Mode = enMode.UpdateNew;

                        return true;

                    }
                    else
                    {
                        return false;
                    }
                case enMode.UpdateNew:
                    return UpdatePrescription();

            }
            return true;
        }
        public static clsPrescription Find(int? PrescriptionID)
        {

            string Dosage = null, Frequency = null, SpeciallInstructions=null;

            int ?PatientID = null,MedicationID=null;

            DateTime StartDate = DateTime.Now;
            DateTime EndDate = DateTime.Now;



            if (clsPrescriptionData.GetPrescriptionInfoByID(PrescriptionID, ref PatientID, ref MedicationID, ref Dosage, ref Frequency, ref StartDate, ref EndDate, ref SpeciallInstructions))
                return new clsPrescription(PrescriptionID,PatientID,MedicationID,Dosage,Frequency,StartDate,EndDate,SpeciallInstructions);
            else
                return null;
        }
        public static DataTable GetAllPrescriptions() => clsPrescriptionData.GetAllPrescription();


        public static int Count() => clsPrescriptionData.Count();

        public static bool DeletePrescription(int PrescriptionID)=>clsPrescriptionData.DeletePrescription(PrescriptionID);












    }
}
