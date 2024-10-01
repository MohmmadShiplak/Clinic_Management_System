using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_DataAccess
{
    public  class clsStatusData
    {

        public static bool GetStatusesInfoByID(int? StatusID, ref string StatusName)

        {

            bool IsFound = false;

            using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
            {

                Connection.Open();
                //name of Store Procedure 
                using (SqlCommand Command = new SqlCommand("SP_GetStatusInfoByID", Connection))
                {


                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@StatusID", (object)StatusID ?? DBNull.Value);


                    using (SqlDataReader Reader = Command.ExecuteReader())
                    {

                        if (Reader.Read())
                        {

                            IsFound = true;

                            StatusName = (Reader["StatusName"] != DBNull.Value) ? (string)Reader["StatusName"] : null;


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
        public static bool GetAllStatusesInfoByName(string StatusName, ref int? StatusID)

        {

            bool IsFound = false;

            using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
            {

                Connection.Open();
                //name of Store Procedure 
                using (SqlCommand Command = new SqlCommand("SP_GetStatusesInfobyName", Connection))
                {


                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@StatusName", (object)StatusName ?? DBNull.Value);


                    using (SqlDataReader Reader = Command.ExecuteReader())
                    {

                        if (Reader.Read())
                        {

                            IsFound = true;

                            StatusID = (int)Reader["StatusID"];


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
        public static DataTable AllOnlyNames()
        {

            DataTable dt = new DataTable();

            using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
            {

                Connection.Open();

                using (SqlCommand Command = new SqlCommand("SP_GetAllStatusNames", Connection))
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
