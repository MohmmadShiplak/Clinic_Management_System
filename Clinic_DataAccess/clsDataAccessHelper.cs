using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_DataAccess
{
    public  class clsDataAccessHelper
    {

        public static void HandleException(Exception ex)
        {

            if(ex is SqlException sqlEX)
            {

                clsErrorLog loggerToEventViewer = new clsErrorLog(clsLogHandler.LogToEventViewer);
                loggerToEventViewer.LogError("Database Exception", sqlEX);

            }
            else
            {

                clsErrorLog loggerToEventViewer = new clsErrorLog(clsLogHandler.LogToEventViewer);
                loggerToEventViewer.LogError("General Exception", ex);
            }

        }















        public static bool IsExists<T>(string storedProcedureName, string parameterName, T value)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue($"@{parameterName}", (object)value ?? DBNull.Value);

                        // @ReturnVal could be any name, and we don't need to add it to the SP, just use it here in the code.
                        SqlParameter returnParameter = new SqlParameter("@ReturnVal", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.ReturnValue
                        };
                        command.Parameters.Add(returnParameter);

                        command.ExecuteNonQuery();

                        isFound = (int)returnParameter.Value == 1;
                    }
                }
            }
            catch (Exception ex)
            {
                isFound = false;
                Console.WriteLine("Error :" + ex.Message);
            }

            return isFound;
        }
        public static int Count(string storedProcedureName)
        {
            int Count = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int Value))
                        {
                            Count = Value;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
               Console.WriteLine("Error :"+ex.Message); 
            }

            return Count;
        }






    }
}
