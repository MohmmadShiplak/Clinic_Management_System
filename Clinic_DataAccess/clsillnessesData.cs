using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_DataAccess
{
    public  class clsillnessesData
    {

        public static bool GetIllnessesInfoByID(int? illnessID, ref string illnessName)

        {

            bool IsFound = false;

            using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
            {

                Connection.Open();
                //name of Store Procedure 
                using (SqlCommand Command = new SqlCommand("SP_GetIllnessesInfobyID", Connection))
                {


                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@illnessID", (object)illnessID ?? DBNull.Value);


                    using (SqlDataReader Reader = Command.ExecuteReader())
                    {

                        if (Reader.Read())
                        {

                            IsFound = true;

                            illnessName = (Reader["illnessName"] != DBNull.Value) ? (string)Reader["illnessName"] : null;


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
        public static bool GetAllillnessesInfoByName(string illnessName, ref int? illnessID)

        {

            bool IsFound = false;

            using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
            {

                Connection.Open();
                //name of Store Procedure 
                using (SqlCommand Command = new SqlCommand("SP_GetIllnessesInfobyName", Connection))
                {


                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@illnessName", (object)illnessName ?? DBNull.Value);


                    using (SqlDataReader Reader = Command.ExecuteReader())
                    {

                        if (Reader.Read())
                        {

                            IsFound = true;

                            illnessID = (int)Reader["illnessID"];


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



                using (SqlCommand Command = new SqlCommand("SP_GetAllillnessesName", Connection))
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
