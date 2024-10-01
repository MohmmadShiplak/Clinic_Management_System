using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_DataAccess
{
    public  class clsDoctorData
    {

        public static bool GetDoctorsInfoByID(int? DoctorID, ref int PersonID, ref int MajorID, ref byte Experience, ref int CreatedByUserID)
        {

            bool IsFound = false;

            try
            {


                using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
                {

                    Connection.Open();
                    //name of Store Procedure 
                    using (SqlCommand Command = new SqlCommand("SP_GetDoctorsInfobyID", Connection))
                    {


                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@DoctorID", (object)DoctorID ?? DBNull.Value);


                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {

                            if (Reader.Read())
                            {

                                IsFound = true;

                                PersonID = (int)Reader["PersonID"];
                                MajorID = (int)Reader["MajorID"];
                                Experience = ((byte)Reader["Experience"]);
                                //CreatedByUserID = (int)Reader["CreatedByUserID"];


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
        public static bool GetDoctorsInfoByPersonID(ref int DoctorID, int? PersonID, ref int MajorID, ref byte Experience, ref int CreatedByUserID)
        {

            bool IsFound = false;


            try
            {


                using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
                {

                    Connection.Open();
                    //name of Store Procedure 
                    using (SqlCommand Command = new SqlCommand("SP_GetDoctorsInfobyPersonID", Connection))
                    {


                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@PersonID", (object)PersonID ?? DBNull.Value);


                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {

                            if (Reader.Read())
                            {

                                IsFound = true;

                                PersonID = (int)Reader["DoctorID"];
                                MajorID = (int)Reader["MajorID"];
                                Experience = ((byte)Reader["Experience"]);
                                CreatedByUserID = (int)Reader["CreatedByUserID"];


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

        public static int? AddNewDoctors(  int ?PersonID,  int ?MajorID,  short ?Experience)
        {

            int? NewPersonID = null;


            try
            {
                using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
                {

                    Connection.Open();

                    using (SqlCommand Command = new SqlCommand("SP_AddNewDoctors", Connection))
                    {
                        //Command from Type Stored Procedure 
                        Command.CommandType = CommandType.StoredProcedure;


                        Command.Parameters.AddWithValue("@PersonID", (object)PersonID ?? DBNull.Value);
                        Command.Parameters.AddWithValue("@MajorID", (object)MajorID ?? DBNull.Value);
                        Command.Parameters.AddWithValue("@Experience", (object)Experience ?? DBNull.Value);
                      //  Command.Parameters.AddWithValue("@CreatedByUserID", (object)CreatedByUserID ?? DBNull.Value);
                       

                        //represent a Parameter 
                        SqlParameter OutPutPersonID = new SqlParameter("@DoctorID", SqlDbType.Int)//Type of output parameter 
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



        public static bool  UpdateDcotors(int ?DoctorID,  int ? PersonID,  int ?MajorID,  short? Experience)
        {


            int RowAffected = 0;

            try
            {

                using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
                {

                    Connection.Open();

                    using (SqlCommand Command = new SqlCommand("SP_UpdateDoctor", Connection))
                    {

                        Command.CommandType = CommandType.StoredProcedure;

                        Command.Parameters.AddWithValue("@DoctorID", (object)DoctorID ?? DBNull.Value);
                        Command.Parameters.AddWithValue("@PersonID", (object)PersonID ?? DBNull.Value);
                        Command.Parameters.AddWithValue("@MajorID", (object)MajorID ?? DBNull.Value);
                        Command.Parameters.AddWithValue("@Experience", (object)Experience ?? DBNull.Value);
                     //   Command.Parameters.AddWithValue("@CreatedByUserID", (object)CreatedByUserID ?? DBNull.Value);
                      
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
        public static bool IsDoctor(int ?PersonID)=>clsDataAccessHelper.IsExists("SP_IsDoctor","PersonID",PersonID);

        public static DataTable GetAllDoctors()
        {

            DataTable dt = new DataTable();

            using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
            {

                Connection.Open();

                using (SqlCommand Command = new SqlCommand("SP_GetAllDoctors", Connection))
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
        public static bool DeleteDoctor(int DoctorID)
        {


            int RowAffected = 0;

            try
            { 
                using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
                {

                    Connection.Open();


                    using (SqlCommand Command = new SqlCommand("SP_DeleteDoctor", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;

                        Command.Parameters.AddWithValue("@DoctorID", DoctorID);


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
        public static int Count() => clsDataAccessHelper.Count("SP_GetAllDoctorsCount");



















    }
}
