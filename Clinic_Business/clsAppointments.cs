using Clinic_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Business
{
    public  class clsAppointments
    {

private enum enMode { AddNew=0,UpdateNew=1 };

        private enMode _Mode = enMode.AddNew;

        public int ?AppointmentID { get; set; }
        public int  ?PatientID { get; set; }
        public int  ?DoctorID { get; set; }

 
        public  TimeSpan Time { get; set; }

        public int ? StatusID { get; set; }

        public  bool  IsAppointment() => clsAppointments.IsAppointment(PatientID);


        public clsPerson _PersonInfo;

        public clsStatus StatusInfo;




        public clsAppointments()
        {

            this.AppointmentID = null;
            this.PatientID = null;
            this.DoctorID = null;
            
            this.Time =DateTime.Now.TimeOfDay;
            this.StatusID = null;

            _Mode = enMode.AddNew;

        }
        public clsAppointments(int ?AppointmentID,int  PatientID,int  DoctorID,TimeSpan DateTime
            ,int StatusID)
        { 
            this.AppointmentID = AppointmentID;
            this.PatientID = PatientID;
            this.DoctorID = DoctorID;
            this.Time = DateTime;
            this.StatusID = StatusID;
            this._PersonInfo = clsPerson.Find(AppointmentID);
            this.StatusInfo = clsStatus.Find(StatusID);

            _Mode = enMode.UpdateNew;
        }
        private bool AddNewAppointment()
        {

            this.AppointmentID = clsAppointmentsData.AddNewAppointment(this.PatientID, this.DoctorID
                ,this.Time, this.StatusID);

            return (this.AppointmentID != -1);

        }
        private bool UpdateAppointment()
        {
            return clsAppointmentsData.UpdateAppointment(this.AppointmentID, this.PatientID, this.DoctorID
                , this.Time, this.StatusID);
        }
        public bool  Save()
        {

switch(_Mode)
            {

                case enMode.AddNew:
                    if(AddNewAppointment())
                    {

                        _Mode = enMode.UpdateNew;

                        return true;


                    }
                    else
                    {
                        return false;
                    }
                case enMode.UpdateNew:
                    return UpdateAppointment();

            }
            return false;
        }
        public static clsAppointments Find(int ?AppointmentID)
        {

            int  DoctorID = -1, PatientID =-1;


            TimeSpan Time = DateTime.Now.TimeOfDay;

            int Status = -1;
           
            if (clsAppointmentsData.GetAppointmentsInfobyID(AppointmentID, ref PatientID
                , ref DoctorID, ref Time, ref Status))
                return new clsAppointments(AppointmentID, PatientID, DoctorID, Time, Status);
            else
                return null;


        }
       public static DataTable GetAllApoointments()
        {
            return clsAppointmentsData.GetAllAppointments();
        }
        public static bool DeleteAppointment(int AppointmentID)
        {
            return clsAppointmentsData.DeleteAppointment(AppointmentID);
        }
        public static bool IsAppointment(int ?PatientID )=>clsAppointmentsData.IsAppointment(PatientID);

        public static int count() => clsAppointmentsData.Count();




    }
}
