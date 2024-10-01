using Clinic_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Business
{
    public  class clsPatient
    {


        public enum enMode { AddNew = 0, UpdateNew = 1 };
        public enMode _Mode;


        clsDoctor _Doctor;

        public int? PatientID { get; set; }

        public int? PersonID { get; set; }

        public int? illnessID { get; set; }

        public DateTime? CreationDate { get; set; }

        public string Notes  { get; set; }

        public bool IsAppointment() => clsAppointments.IsAppointment(PatientID);




        public clsillnesses illnessesInfo;

 

        //public string FullName()
        //{

        //}


        public clsPatient()
        {
            this.PersonID = null;
            this.PatientID = null;
            this.illnessID = null;
            this.CreationDate = null;
            this.Notes = null;
          
            _Mode = enMode.AddNew;




        }
        public clsPatient(int? PatientID, int ?PersonID, int ?illnessID, DateTime ?CreationDate, string Notes )
        {

            this.PatientID = PatientID;
            this.PersonID = PersonID;
            this.illnessID = illnessID;
            this.CreationDate = CreationDate;
            this.Notes = Notes;
            this.illnessesInfo = clsillnesses.Find(illnessID);
            //this.CreatedByUserID = CreatedByUserID;
            //this.MajorInfo = clsMajor.Find(MajorID);
            //this.CreatedUserInfo = clsUsers.FindByUserID(CreatedByUserID);
            _Mode = enMode.UpdateNew;

        }
        private bool AddNewPatinets()
        {

            this.PatientID = clsPatientData.AddNewPatients( this.PersonID, this.illnessID,this.CreationDate,this.Notes);


            return (PatientID.HasValue);

        }
        private bool UpdatePatients()
        {
            return clsPatientData.UpdatePatients(this.PatientID,this.PersonID, this.illnessID, this.CreationDate, this.Notes);
        }
        public bool Save()
        {

            switch (_Mode)
            {
                case enMode.AddNew:
                    if (AddNewPatinets())
                    {

                        _Mode = enMode.UpdateNew;

                        return true;

                    }
                    else
                    {
                        return false;
                    }
                case enMode.UpdateNew:
                    return UpdatePatients();

            }
            return true;
        }
        public static clsPatient FindbyPersonID(int ?PersonID)
        {


            int? PatientID = null, illnessID = null; ;

            DateTime CreationDate=DateTime.MinValue;

            string Notes=" ";

            if (clsPatientData.GetPatientInfoByPersonID(ref PatientID,PersonID,ref illnessID,ref CreationDate,ref Notes))
                return new clsPatient(PatientID,PersonID,illnessID,CreationDate,Notes);
            else
                return null;


        }
        public static clsPatient FindbyPatientID(int? PatientID)
        {


            int? PersonID = null, illnessID = null; ;

            DateTime? CreationDate = DateTime.MinValue;

            string Notes = " ";

            if (clsPatientData.GetPatientInfoByID(PatientID,ref PersonID,ref illnessID,ref CreationDate,ref Notes))
                return new clsPatient(PatientID, PersonID, illnessID, CreationDate, Notes);
            else
                return null;


        }
        public static DataTable GetAllPatients() => clsPatientData.GetAllPatinets();

        public static bool DeletePatient(int Patient)=>clsPatientData.DeletePatient(Patient);


        public static int Count() => clsPatientData.Count();










    }
}
