using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_DataAccess
{
    public class clsMedicalRecordData
    {

        public static int AddNewMedicalRecord(int ?PatienID,string Description, string Diagonsis,
            string Notes)
        {

            int ID = -1;

            using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
            {

                Connection.Open();

                try
                {
                    using (SqlCommand Command = new SqlCommand("SP_AddMedicalRecords", Connection))
                    {

                        Command.CommandType = CommandType.StoredProcedure;


                        Command.Parameters.AddWithValue("@PatientID",(object)PatienID??DBNull.Value);
                        Command.Parameters.AddWithValue("@VisitDescription",(object) Description??DBNull.Value);
                        Command.Parameters.AddWithValue("@Diagonsis",(object) Diagonsis??DBNull.Value);
                        Command.Parameters.AddWithValue("@AdditionalNotes",(object)Notes ?? DBNull.Value);



                        SqlParameter OutPutAppointmentID = new SqlParameter("@ID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        Command.Parameters.Add(OutPutAppointmentID);
                        Command.ExecuteScalar();
                        ID = (int)Command.Parameters["@ID"].Value;
                    }

                }
                catch (Exception ex)
                {
                    clsDataAccessHelper.HandleException(ex);
                }

            }
            return ID;
        }
        public static bool UpdateMedicalRecords(int ?ID,int ?PatientID, string Description, string Diagonsis,
            string Notes)

        {

            int RowAffected = 0;

            try
            {



                using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
                {

                    Connection.Open();

                    using (SqlCommand Command = new SqlCommand("SP_UpdateMedicalRecords", Connection))
                    {

                        Command.CommandType = CommandType.StoredProcedure;
                        //you should put here names of paramaters in Stored Procedure 

                        Command.Parameters.AddWithValue("@PatientID", (object)PatientID ?? DBNull.Value);
                        Command.Parameters.AddWithValue("@VisitDescription", (object)Description ?? DBNull.Value);
                        Command.Parameters.AddWithValue("@Diagonsis", (object)Diagonsis ?? DBNull.Value);
                        Command.Parameters.AddWithValue("@AdditionalNotes", (object)Notes ?? DBNull.Value);
                        Command.Parameters.AddWithValue("@ID", (object)ID ?? DBNull.Value);

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
        public static bool GetMedicalRecordInfobyID(int ?ID,ref int? PatientID, ref string Description, ref string Diagonsis, ref string Notes)

        {

            bool IsFound = false;



            try
            {

                using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
                {

                    Connection.Open();

                    using (SqlCommand Command = new SqlCommand("SP_GetMedicalRecordsInfoByID", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;

                        Command.Parameters.AddWithValue("@ID", ID);

                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {

                            if (Reader.Read())
                            {

                                IsFound = true;

                                PatientID = (int)Reader["PatientID"];
                                Description = (string)Reader["VisitDescription"];
                                Diagonsis = (string)Reader["Diagnosis"];
                                Notes = (string)Reader["AdditionalNotes"];

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
        public static DataTable GetAllMedicalRecords()
        {

            DataTable dt = new DataTable();

            using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
            {

                Connection.Open();

                using (SqlCommand Command = new SqlCommand("SP_GetAllMedicalRecords", Connection))
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
            return dt;
        }

        public static bool DeleteMedicalRecord(int ID)
        {


            int RowAffected = 0;


            using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
            {

                Connection.Open();

                string Query = @"delete MedicalRecords where MedicalRecordID=@MedicalRecordID";



                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {

                    Command.Parameters.AddWithValue("@MedicalRecordID", ID);


                    RowAffected = Command.ExecuteNonQuery();
                }

            }
            return RowAffected > 0;
        }


        public static int Count() => clsDataAccessHelper.Count("SP_GetAllMedicalRecordsCount");


    }
   
















}

