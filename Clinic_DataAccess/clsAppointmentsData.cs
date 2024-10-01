using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_DataAccess
{
    public static   class clsAppointmentsData
    {

public static int? AddNewAppointment(int  ?PatientID,int  ?DoctorID,TimeSpan ?  Time
   ,int ? StatusID)
        {

            int ?AppointmentID = null;

            using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
            {

                Connection.Open();

                try
                {
                    using (SqlCommand Command = new SqlCommand("SP_AddNewAppointment", Connection))
                    {

                        Command.CommandType = CommandType.StoredProcedure;

                        Command.Parameters.AddWithValue("@PatientID",(object) PatientID??DBNull.Value);
                        Command.Parameters.AddWithValue("@DoctorID",(object) DoctorID??DBNull.Value);
                        Command.Parameters.AddWithValue("@time", (object)Time ?? DBNull.Value );
                        Command.Parameters.AddWithValue("@StatusID",  (object)StatusID ?? DBNull.Value);
                  

                        SqlParameter OutPutAppointmentID = new SqlParameter("@NewAppointmentID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        Command.Parameters.Add(OutPutAppointmentID);
                        Command.ExecuteScalar();
                        AppointmentID = (int?)Command.Parameters["@NewAppointmentID"].Value;
                    }
                   
                }
                catch(Exception ex)
                {
                    clsDataAccessHelper.HandleException(ex);
                }
               
                }
            return AppointmentID;
        }
        public static bool UpdateAppointment(int? AppointmentID, int? PatientID, int? DoctorID, TimeSpan? Time
    , int? StatusID)
        {

            int ?RowAffected = null;


            try
            {

                using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
                {

                    Connection.Open();

                    using (SqlCommand Command = new SqlCommand("SP_UpdateAppointment", Connection))
                    {

                        Command.CommandType = CommandType.StoredProcedure;

                        Command.Parameters.AddWithValue("@AppointmentID", AppointmentID);
                        Command.Parameters.AddWithValue("@PatientID", PatientID);
                        Command.Parameters.AddWithValue("@DoctorID", DoctorID);
                        Command.Parameters.AddWithValue("@Time", Time);
                        Command.Parameters.AddWithValue("@StatusID", StatusID);


                        RowAffected = Command.ExecuteNonQuery();

                    }
                   
                }

            }
            catch(Exception ex)
            {
                clsDataAccessHelper.HandleException(ex);
            }
            return RowAffected > 0;
        }
        public static bool GetAppointmentsInfobyID(int? AppointmentID, ref int DoctorID, ref int PatientID, ref TimeSpan Time
     , ref int StatusID)
        {

            bool IsFound = false;

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
                {

                    Connection.Open();

                    using (SqlCommand Command = new SqlCommand("SP_GetAppointmentInfobyID", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;

                        Command.Parameters.AddWithValue("@AppointmentID", AppointmentID);

                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {

                            if (Reader.Read())
                            {

                                IsFound = true;
                                DoctorID = (int)Reader["DoctorID"];
                                PatientID = (int)Reader["PatientID"];

                                Time = (TimeSpan)Reader["Time"];
                                StatusID = (int)Reader["StatusID"];

                            }
                            else
                            {
                                IsFound = false;
                            }
                           

                        }

                    }


                }

            }
            catch(Exception ex)
            {
                clsDataAccessHelper.HandleException(ex);
            }
            return IsFound;
        }
        public static DataTable GetAllAppointments()
        {

            DataTable dt = new DataTable();

            try
            {

                using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
                {

                    Connection.Open();


                    using (SqlCommand Command = new SqlCommand("Sp_GetAllAppointments", Connection))
                    {

                        Command.CommandType = CommandType.StoredProcedure;


                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {

                            if (Reader.HasRows)
                            {
                                dt.Load(Reader);
                            }


                        }

                    }

                }
          
            }
            catch (Exception ex)
            {
                clsDataAccessHelper.HandleException(ex);
            }
            return dt;  
            }
        public static bool DeleteAppointment(int AppointmentID)
        {


            int RowAffected = 0;


            using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
            {

                Connection.Open();

        
                using (SqlCommand Command = new SqlCommand("SP_DeleteAppointment", Connection))
                {

                   Command.CommandType=CommandType.StoredProcedure;

                   Command.Parameters.AddWithValue("@AppointmentID", AppointmentID);


                    RowAffected = Command.ExecuteNonQuery();
                }

            }
            return RowAffected > 0;
        }
        public static bool IsAppointment(int? PatientID) => clsDataAccessHelper.IsExists("SP_IsAppointment", "PatientID", PatientID);

        public static int Count() => clsDataAccessHelper.Count("SP_GetAllAppointmentsCount");








    }
}
