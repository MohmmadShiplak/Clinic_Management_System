using Clinic_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Business
{
    public  class clsDoctor
    {

        public enum enMode { AddNew = 0, UpdateNew = 1 };
        public enMode _Mode;


        clsDoctor _Doctor;

        public int  ?DoctorID { get; set; }

        public int ?PersonID { get; set; }

        public int ?MajorID { get; set; }

        public byte ? Experience  { get; set; }

        public int  ?CreatedByUserID { get; set; }

        public clsUsers CreatedUserInfo { get; }



        public clsMajor MajorInfo;

      //  public bool IsAppointment() => clsAppointments.IsAppointment(PersonID);






        //public string FullName()
        //{

        //}


        public clsDoctor()
        {
            this.DoctorID = null;
            this.PersonID = null;
        
            this.MajorID = null;
            this.Experience = null;
            this.CreatedByUserID =null;
           

            _Mode = enMode.AddNew;




        }
       public clsDoctor(int ?DoctorID,int PersonID,int MajorID,byte Experience,int CreatedByUserID )
        {

            this.PersonID = PersonID;
            this.DoctorID = DoctorID;
            this.MajorID = MajorID;
            this.Experience = Experience;
            this.CreatedByUserID = CreatedByUserID;
            this.MajorInfo = clsMajor.Find(MajorID);
            this.CreatedUserInfo = clsUsers.FindByUserID(CreatedByUserID);
            _Mode = enMode.UpdateNew;

        }
        private bool AddNewDoctors()
        {

            this.DoctorID = clsDoctorData.AddNewDoctors(this.PersonID, this.MajorID, this.Experience);
             

            return (DoctorID.HasValue);

        }
        private bool  UpdateDcotors()
        {
            return clsDoctorData.UpdateDcotors(this.DoctorID, this.PersonID, this.MajorID, this.Experience);
        }
        public bool Save()
        {

            switch (_Mode)
            {
                case enMode.AddNew:
                    if (AddNewDoctors())
                    {

                        _Mode = enMode.UpdateNew;

                        return true;

                    }
                    else
                    {
                        return false;
                    }
                case enMode.UpdateNew:
                    return UpdateDcotors();

            }
            return true;
        }
        public static clsDoctor FindByDoctorID(int  ?DoctorID)
        {


             int MajorID =-1,PersonID=-1,CreatedByUserID=-1 ;

            byte Experience = 0;

            if (clsDoctorData.GetDoctorsInfoByID(DoctorID,ref PersonID, ref MajorID, ref Experience,ref CreatedByUserID))
                return new clsDoctor(DoctorID,PersonID, MajorID, Experience,CreatedByUserID);
            else
                return null;


        }
        public static clsDoctor FindByPersonID(int PersonID)
        {


            int DoctorID = -1, MajorID = -1, CreatedByUserID = -1;

             byte Experience = 0;

            if (clsDoctorData.GetDoctorsInfoByPersonID(ref DoctorID, PersonID,ref MajorID,ref Experience,ref CreatedByUserID))
                return new clsDoctor(DoctorID, PersonID, MajorID, Experience,CreatedByUserID);
            else
                return null;


        }
        public static DataTable GetAllDoctors() => clsDoctorData.GetAllDoctors();


        public static bool IsDoctor(int ?PersonID) => clsDoctorData.IsDoctor(PersonID);

        public static bool DeleteDoctor(int DoctorID) => clsDoctorData.DeleteDoctor(DoctorID);

        public static int Count() => clsDoctorData.Count();





    }
}
