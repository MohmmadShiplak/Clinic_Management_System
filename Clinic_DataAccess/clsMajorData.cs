using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_DataAccess
{
    public  class clsMajorData
    {


        public static bool GetMajorsInfoByID(int? MajorID, ref string MajorName )
   
        {

            bool IsFound = false;

            using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
            {

                Connection.Open();
                //name of Store Procedure 
                using (SqlCommand Command = new SqlCommand("SP_GetMajorsInfobyID", Connection))
                {


                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@MajorID", (object)MajorID ?? DBNull.Value);


                    using (SqlDataReader Reader = Command.ExecuteReader())
                    {

                        if (Reader.Read())
                        {

                            IsFound = true;

                            MajorName = (Reader["MajorName"] != DBNull.Value) ? (string)Reader["MajorName"] : null;
                         

                        }
                        else
                        {
                            IsFound = false;
                        }

                    }
                    return IsFound;

                }

            }
        }
        public static bool GetMajorsInfoByName(string MajorName, ref int? MajorID  )

        {

            bool IsFound = false;

            using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
            {

                Connection.Open();
                //name of Store Procedure 
                using (SqlCommand Command = new SqlCommand("SP_GetMajorsInfobyName", Connection))
                {


                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@MajorName", (object)MajorName ?? DBNull.Value);


                    using (SqlDataReader Reader = Command.ExecuteReader())
                    {

                        if (Reader.Read())
                        {

                            IsFound = true;

                            MajorID = (int)Reader["MajorID"];


                        }
                        else
                        {
                            IsFound = false;
                        }

                    }
                    return IsFound;

                }

            }
        }
        public static byte? GetMajorID(string MajorName)
        {
            // This function will return the new person id if succeeded and null if not
            byte? MajorID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetMajorID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@MajorName", MajorName);

                        SqlParameter outputIdParam = new SqlParameter("MajorID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);

                        command.ExecuteNonQuery();

                        MajorID = (byte?)(int)outputIdParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error :" + ex.Message);
            }

            return MajorID;
        }










        public static DataTable AllOnlyNames()
        {

            DataTable dt = new DataTable();

            using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
            {

                Connection.Open();

            

                using (SqlCommand Command = new SqlCommand("SP_GetAllMajorNames", Connection))
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




    }
}
