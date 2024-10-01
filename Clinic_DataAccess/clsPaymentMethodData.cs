using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_DataAccess
{
    public class clsPaymentMethodData
    {


        public static DataTable GetAllPaymentsMethod()
        {

            DataTable dt = new DataTable();

            using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
            {

                Connection.Open();



                using (SqlCommand Command = new SqlCommand("SP_GetAllPaymentNames", Connection))
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


        public static bool GetPaymentMethodInfobyID(int? ID, ref string PaymentName)
        {
            bool IsFound = false;

            using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
            {

                Connection.Open();
                //name of Store Procedure 
                using (SqlCommand Command = new SqlCommand("SP_GetPaymentMethodInfobyID", Connection))
                {


                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@ID", (object)ID ?? DBNull.Value);


                    using (SqlDataReader Reader = Command.ExecuteReader())
                    {

                        if (Reader.Read())
                        {

                            IsFound = true;

                            PaymentName = (Reader["PaymentName"] != DBNull.Value) ? (string)Reader["PaymentName"] : null;


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
        public static bool GetPaymentMethodsInfobyName(string PaymentName, ref int? ID)
        {

            bool IsFound = false;



            try
            {


                using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
                {

                    Connection.Open();
                    //name of Store Procedure 
                    using (SqlCommand Command = new SqlCommand("SP_GetPaymentsInfoByName", Connection))
                    {


                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@PaymentName", (object)PaymentName ?? DBNull.Value);


                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {

                            if (Reader.Read())
                            {

                                IsFound = true;

                                ID = (Reader["PaymentID"] != DBNull.Value) ? (int?)Reader["PaymentID"] : null;


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
            catch (Exception ex)
            {
                Console.WriteLine("Error :" + ex.ToString());
            }
            return IsFound;
        }

    }
}





    

