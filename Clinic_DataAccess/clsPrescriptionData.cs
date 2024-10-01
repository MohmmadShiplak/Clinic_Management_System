using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_DataAccess
{
    public  class clsPrescriptionData
    {

        public static bool GetPrescriptionInfoByID(int? PrescriptionID, ref int? PatientID, ref int? MedicationName, ref string Dosage, ref string Frequency,
 ref DateTime StartDate, ref DateTime EndDate, ref string SpeciallInstruction
    )
        {

            bool IsFound = false;

            try
            {


                using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
                {

                    Connection.Open();
                    //name of Store Procedure 
                    using (SqlCommand Command = new SqlCommand("SP_GetPrescriptionsInfobyID", Connection))
                    {


                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@Prescription", (object)PrescriptionID ?? DBNull.Value);


                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {

                            if (Reader.Read())
                            {

                                IsFound = true;

                                PatientID = Reader["PatientID"] != DBNull.Value ? (int?)Reader["PatientID"] : null;
                                MedicationName = Reader["MedicationID"] != DBNull.Value ? (int?)Reader["MedicationID"] : null;
                                Dosage = (Reader["Dosage"] != DBNull.Value) ? (string)Reader["Dosage"] : null;
                                Frequency = (Reader["Frequency"] != DBNull.Value) ? (string)Reader["Frequency"] : null;
                                StartDate = (DateTime)Reader["StartDate"];
                                EndDate = (DateTime)Reader["EndDate"];
                                SpeciallInstruction = (Reader["SpecialInstructions"] != DBNull.Value) ? (string)Reader["SpecialInstructions"] : null;


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

        public static int? AddNewPrescription( int? PatientID, int ?MedicationName,  string Dosage,  string Frequency,
  DateTime StartDate, DateTime EndDate, string SpeciallInstruction)
        {

            int? NewPersonID = null;


            try
            {
                using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
                {

                    Connection.Open();

                    using (SqlCommand Command = new SqlCommand("SP_AddNewPrescription", Connection))
                    {
                        //Command from Type Stored Procedure 
                        Command.CommandType = CommandType.StoredProcedure;

                        Command.Parameters.AddWithValue("@PatientID", (object)PatientID ?? DBNull.Value);
                        Command.Parameters.AddWithValue("@MedicationName", (object)MedicationName ?? DBNull.Value);
                        Command.Parameters.AddWithValue("@Dosage", (object)Dosage ?? DBNull.Value);
                        Command.Parameters.AddWithValue("@Frequency", (object)Frequency ?? DBNull.Value);
                        Command.Parameters.AddWithValue("@StartDate", (object)StartDate ?? DBNull.Value);
                        Command.Parameters.AddWithValue("@EndDate", (object)EndDate ?? DBNull.Value);
                        Command.Parameters.AddWithValue("@SpeciallInstructions", (object)SpeciallInstruction ?? DBNull.Value);
                     
                        //represent a Parameter 
                        SqlParameter OutPutPersonID = new SqlParameter("@PrescriptionID", SqlDbType.Int)//Type of output parameter 
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



        public static bool UpdatePrescription(int ?PrescriptionID, int ?PatientID,int ? MedicationName,  string Dosage, string Frequency,
 DateTime StartDate, DateTime EndDate, string SpeciallInstruction)
        {


            int RowAffected = 0;

            try
            {

                using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
                {

                    Connection.Open();

                    using (SqlCommand Command = new SqlCommand("SP_UpdatePrescription", Connection))
                    {

                        Command.CommandType = CommandType.StoredProcedure;

                        Command.Parameters.AddWithValue("@PrescriptionID", (object)PrescriptionID ?? DBNull.Value);
                        Command.Parameters.AddWithValue("@PatientID", (object)PatientID ?? DBNull.Value);
                        Command.Parameters.AddWithValue("@MedicationName", (object)MedicationName ?? DBNull.Value);
                        Command.Parameters.AddWithValue("@Dosage", (object)Dosage ?? DBNull.Value);
                        Command.Parameters.AddWithValue("@Frequency", (object)Frequency ?? DBNull.Value);
                        Command.Parameters.AddWithValue("@StartDate", (object)StartDate ?? DBNull.Value);
                        Command.Parameters.AddWithValue("@EndDate", (object)EndDate ?? DBNull.Value);
                        Command.Parameters.AddWithValue("@SpeciallInstructions", (object)SpeciallInstruction ?? DBNull.Value);




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
        public static DataTable GetAllPrescription()
        {

            DataTable dt = new DataTable();

            try
            {


                using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
                {

                    Connection.Open();

                    using (SqlCommand Command = new SqlCommand("sp_GetAllPrescription", Connection))
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
            catch(Exception ex)
            {
                clsDataAccessHelper.HandleException(ex);
            }
            return dt;  
            }
        public static int Count() => clsDataAccessHelper.Count("SP_GetAllPrescriptionsCount");

        public static bool DeletePrescription(int PrescriptionID)
        {


            int RowAffected = 0;


            try
            {
                using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
                {

                    Connection.Open();


                    using (SqlCommand Command = new SqlCommand("SP_DeletePrescription", Connection))
                    {

                        Command.CommandType = CommandType.StoredProcedure;


                        Command.Parameters.AddWithValue("@PrescriptionID", (object)PrescriptionID ?? DBNull.Value);


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

    }
}
