using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace Clinic_DataAccess
{
    public  class clsPatientData
    {

        public static bool GetPatientInfoByID(int? PatientID, ref int ?PersonID, ref int  ? illnessID, ref DateTime ?CreationDate, ref string Notes )
        {

            bool IsFound = false;

            try
            {

                using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
                {

                    Connection.Open();
                    //name of Store Procedure 
                    using (SqlCommand Command = new SqlCommand("SP_GetPatientsInfobyID", Connection))
                    {


                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@PatientID", (object)PatientID ?? DBNull.Value);


                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {

                            if (Reader.Read())
                            {

                                IsFound = true;

                                PersonID = (int)Reader["PersonID"];
                                illnessID = (int)Reader["illnessID"];
                                CreationDate = ((DateTime)Reader["CreationDate"]);
                                Notes = (string)Reader["Notes"];


                            }
                            else
                            {
                                IsFound = false;
                            }

                        }
                   

                    }

                }
            }
            catch (Exception ex)
            {
                clsDataAccessHelper.HandleException(ex);
            }
            return IsFound; 
        }
        public static bool GetPatientInfoByPersonID(ref int? PatientID, int? PersonID, ref int? illnessID, ref DateTime CreationDate, ref string Notes)
        {

            bool IsFound = false;


            try
            {



                using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
                {

                    Connection.Open();
                    //name of Store Procedure 
                    using (SqlCommand Command = new SqlCommand("SP_GetPatientsInfoByPersonID", Connection))
                    {


                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@PersonID", (object)PersonID ?? DBNull.Value);


                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {

                            if (Reader.Read())
                            {

                                IsFound = true;

                                PatientID = (int)Reader["PatientID"];
                                illnessID = (int)Reader["illnessID"];
                                CreationDate = ((DateTime)Reader["CreationDate"]);
                                Notes = (string)Reader["Notes"];


                            }
                            else
                            {
                                IsFound = false;
                            }

                        }
                     

                    }

                }
            }
            catch (Exception ex)
            {
                clsDataAccessHelper.HandleException(ex);
            }
            return IsFound;
        }










        public static int? AddNewPatients(int? PersonID, int   ?illnessID, DateTime? CreationDate,string Notes )
        {

            int? NewPersonID = null;


            try
            {
                using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
                {

                    Connection.Open();

                    using (SqlCommand Command = new SqlCommand("SP_AddPatients", Connection))
                    {
                        //Command from Type Stored Procedure 
                        Command.CommandType = CommandType.StoredProcedure;


                        Command.Parameters.AddWithValue("@PersonID", (object)PersonID ?? DBNull.Value);
                        Command.Parameters.AddWithValue("@illnessID", (object)illnessID ?? DBNull.Value);
                        Command.Parameters.AddWithValue("@CreationDate", (object)CreationDate ?? DBNull.Value);
                        Command.Parameters.AddWithValue("@Notes", (object)Notes ?? DBNull.Value);



                        //  Command.Parameters.AddWithValue("@CreatedByUserID", (object)CreatedByUserID ?? DBNull.Value);


                        //represent a Parameter 
                        SqlParameter OutPutPersonID = new SqlParameter("@PatientID", SqlDbType.Int)//Type of output parameter 
                        {

                            Direction = ParameterDirection.Output
                        };
                        Command.Parameters.Add(OutPutPersonID);
                        Command.ExecuteScalar();
                        NewPersonID = (int)OutPutPersonID.Value;

                    }

                }
            }
            catch (Exception ex)
            {
                clsDataAccessHelper.HandleException(ex);
            }
            return NewPersonID;
        }



        public static bool UpdatePatients(int ?PatientID,int? DoctorID, int ? illnessID, DateTime? CreationDate, string Notes)
        {


            int RowAffected = 0;

            try
            {

                using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
                {

                    Connection.Open();

                    using (SqlCommand Command = new SqlCommand("SP_UpdatePatients", Connection))
                    {

                        Command.CommandType = CommandType.StoredProcedure;

                        Command.Parameters.AddWithValue("@PatientID", (object)PatientID ?? DBNull.Value);
                        Command.Parameters.AddWithValue("@PersonID", (object)DoctorID ?? DBNull.Value);
                        Command.Parameters.AddWithValue("@illnessID", (object)illnessID ?? DBNull.Value);
                        Command.Parameters.AddWithValue("@CreationDate", (object)CreationDate ?? DBNull.Value);
                        Command.Parameters.AddWithValue("@Notes", (object)Notes ?? DBNull.Value);


                        RowAffected = Command.ExecuteNonQuery();

                    }


                }
            }
            catch (Exception ex)
            {
                clsDataAccessHelper.HandleException(ex);
            }
            return RowAffected > 0;
        }
        public static bool IsPatient(int? PersonID) => clsDataAccessHelper.IsExists("SP_IsDoctor", "PersonID", PersonID);

        public static DataTable GetAllPatinets()
        {

            DataTable dt = new DataTable();


            try
            {
                using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
                {

                    Connection.Open();

                    using (SqlCommand Command = new SqlCommand("SP_GetAllPatients", Connection))
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
            catch(Exception ex)
            {
                clsDataAccessHelper.HandleException(ex);
            }
            return dt;
        }

        public static bool DeletePatient(int PatientID)
        {


            int RowAffected = 0;

            try
            {




                using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
                {

                    Connection.Open();


                    using (SqlCommand Command = new SqlCommand("SP_DeletePatient", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;

                        Command.Parameters.AddWithValue("@PatientID", PatientID);


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

        public static int Count() => clsDataAccessHelper.Count("SP_GetAllPatientsCount");

















    }









}

