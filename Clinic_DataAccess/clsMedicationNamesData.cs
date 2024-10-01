using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_DataAccess
{
    public  class clsMedicationNamesData
    {

        public static bool GetMedicationNamesInfoByID(int? MedicationID, ref string MedicationName)

        {

            bool IsFound = false;

            using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
            {

                Connection.Open();
                //name of Store Procedure 
                using (SqlCommand Command = new SqlCommand("SP_GetMedicationNamesInfobyID", Connection))
                {


                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@MedicationID", (object)MedicationID ?? DBNull.Value);


                    using (SqlDataReader Reader = Command.ExecuteReader())
                    {

                        if (Reader.Read())
                        {

                            IsFound = true;

                            MedicationName = (Reader["MedicationName"] != DBNull.Value) ? (string)Reader["MedicationName"] : null;


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
        public static bool GetAllMedicationNamesInfoByName(string MedicatioinName, ref int? MedicationID)

        {

            bool IsFound = false;

            using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
            {

                Connection.Open();
                //name of Store Procedure 
                using (SqlCommand Command = new SqlCommand("SP_GetMedicationNamesInfobyName", Connection))
                {


                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@MedicationName", (object)MedicatioinName ?? DBNull.Value);


                    using (SqlDataReader Reader = Command.ExecuteReader())
                    {

                        if (Reader.Read())
                        {

                            IsFound = true;

                            MedicationID = (int)Reader["MedicationID"];


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
        public static DataTable GetAllMedicationNames()
        {

            DataTable dt = new DataTable();

            using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
            {

                Connection.Open();



                using (SqlCommand Command = new SqlCommand("SP_GetAllMedicationNames", Connection))
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
