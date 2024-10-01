using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace Clinic_DataAccess
{
    public  class clsPaymentsData
    {

        public static bool GetPaymentsInfoByID(int ?PaymentID, ref int?  PersonID, ref DateTime PaymentDate
          , ref int ? PaymentMethod,ref decimal? AmountPaid,   ref string AdditionalNotes)
        {

            bool IsFound = false;

            try
            {




                using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
                {

                    Connection.Open();
                    //name of Store Procedure 
                    using (SqlCommand Command = new SqlCommand("SP_GetPaymentsInfobyID", Connection))
                    {


                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@ID", (object)PaymentID??DBNull.Value);


                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {

                            if (Reader.Read())
                            {
                                IsFound = true;


                                PersonID = (int)Reader["PersonID"];
                                PaymentDate = (DateTime)Reader["PaymentDate"];
                                PaymentMethod = (int)Reader["PaymentMethod"];
                                AmountPaid = (decimal)Reader["AmountPaid"];
                                AdditionalNotes = (string)Reader["AdditionalNotes"]; 

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

        public static int AddNewPayments(  int ?PersonID,DateTime ?PaymentDate
          ,  int  ?PaymentMethod,  decimal ?AmountPaid,  string AdditionalNotes)
        {

            int PaymentID = -1;


            try
            {
                using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
                {

                    Connection.Open();

                    using (SqlCommand Command = new SqlCommand("SP_AddPayments", Connection))
                    {
                        //Command from Type Stored Procedure 
                        Command.CommandType = CommandType.StoredProcedure;

                        Command.Parameters.AddWithValue("@PersonID",(object) PersonID??DBNull.Value);
                        Command.Parameters.AddWithValue("@PaymentDate",(object) PaymentDate??DBNull.Value);
                        Command.Parameters.AddWithValue("@PaymentMethod",(object) PaymentMethod??DBNull.Value);
                        Command.Parameters.AddWithValue("@AmountPaid",(object)AmountPaid ?? DBNull.Value );
                        Command.Parameters.AddWithValue("@AdditionalNotes",(object)AdditionalNotes ?? DBNull.Value);
                 
                        //represent a Parameter 
                        SqlParameter OutPutPersonID = new SqlParameter("@PaymentID", SqlDbType.Int)//Type of output parameter 
                        {

                            Direction = ParameterDirection.Output
                        };
                        Command.Parameters.Add(OutPutPersonID);
                        Command.ExecuteScalar();
                        PaymentID = (int)Command.Parameters["@PaymentID"].Value;

                    }

                }
            }
            catch (Exception ex)
            {
                clsDataAccessHelper.HandleException(ex);
            }
            return PaymentID;
        }



        public static bool UpdatePayments(int? PaymentID,int ?PersonID,DateTime? PaymentDate
          , int  ?PaymentMethod, decimal ?AmountPaid, string AdditionalNotes)
        {


            int RowAffected =0;

            try
            {

                using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
                {

                    Connection.Open();

                    using (SqlCommand Command = new SqlCommand("SP_UpdatePayments", Connection))
                    {

                        Command.CommandType = CommandType.StoredProcedure;

                        Command.Parameters.AddWithValue("@PaymentID",(object)PaymentID ?? DBNull.Value);
                        Command.Parameters.AddWithValue("@PersonID", (object)PersonID ?? DBNull.Value );
                        Command.Parameters.AddWithValue("@PaymentDate", (object)PaymentDate ?? DBNull.Value);
                        Command.Parameters.AddWithValue("@PaymentMethod", (object)PaymentMethod ?? DBNull.Value);
                        Command.Parameters.AddWithValue("@AmountPaid", (object)AmountPaid ?? DBNull.Value);
                        Command.Parameters.AddWithValue("@AdditionalNotes", (object)AdditionalNotes ?? DBNull.Value);

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

        public static bool DeletePayment(int PaymentID)
        {


            int RowAffected = 0;


            try
            {
                using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
                {

                    Connection.Open();


                    using (SqlCommand Command = new SqlCommand("SP_DeletePayment", Connection))
                    {


                        Command.Parameters.AddWithValue("@PaymentID", (object)PaymentID ?? DBNull.Value);


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

        public static DataTable GetAllPayments()
        {

            DataTable dt = new DataTable();

            using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
            {

                Connection.Open();

              

                using (SqlCommand Command = new SqlCommand("SP_GetAllPayments", Connection))
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
        public static int Count() => clsDataAccessHelper.Count("SP_GetAllPaymentsCount");


    }
}
