using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;

namespace Clinic_DataAccess
{
    public  class clsEmailsData
    {

        public static int AddNewEmails(string Name,string Text)
           
        {

            int EmailID = -1;

            using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
            {

                Connection.Open();

                try
                {
                    using (SqlCommand Command = new SqlCommand("SP_AddNewEmails", Connection))
                    {

                        Command.CommandType = CommandType.StoredProcedure;

                        Command.Parameters.AddWithValue("@Name", Name);
                        Command.Parameters.AddWithValue("@Text",Text);
                  

                        SqlParameter OutPutAppointmentID = new SqlParameter("@NewEmailID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        Command.Parameters.Add(OutPutAppointmentID);
                        Command.ExecuteScalar();
                        EmailID = (int)Command.Parameters["@NewEmailID"].Value;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error :" + ex.Message);
                }

            }
            return EmailID;
        }
        public static bool UpdateEmail(int ID, string Name, string Text)
  
        {

            int RowAffected = 0;

            using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
            {

                Connection.Open();

                using (SqlCommand Command = new SqlCommand("SP_UpdateEmails", Connection))
                {

                    Command.CommandType = CommandType.StoredProcedure;

                    Command.Parameters.AddWithValue("@ID",ID);
                    Command.Parameters.AddWithValue("@Name", Name);
                    Command.Parameters.AddWithValue("@Text", Text);
                
                    RowAffected = Command.ExecuteNonQuery();

                }
                return RowAffected > 0;
            }

        }
        public static bool GetEmailsInfobyID(int ID, ref string Name, ref string Text)

        {

            bool IsFound = false;

            using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
            {

                Connection.Open();

                using (SqlCommand Command = new SqlCommand("sp_GetEmailsInfobyID", Connection))
                {
                    Command.CommandType = CommandType.StoredProcedure;

                    Command.Parameters.AddWithValue("@ID", ID);

                    using (SqlDataReader Reader = Command.ExecuteReader())
                    {

                        if (Reader.Read())
                        {

                            IsFound = true;
                        
                            Name = (string)Reader["Name"];
                            Text = (string)Reader["Text"];

                        }
                        else
                        {
                            IsFound = false;
                        }
                        return IsFound;

                    }

                }


            }

        }

















    }
}
