using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Clinic_DataAccess
{
    public class clsPersonData
    {

        public static bool GetPersonsInfoByID(int? PersonID, ref string FirstName,ref string SecondName,ref string ThirdName,ref string LastName,
         ref DateTime DateOfBirth
            , ref short Gendor, ref string Phone, ref string Email, ref string Address,ref string ImagePath)
        {

            bool IsFound = false;

            using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
            {

                Connection.Open();
                //name of Store Procedure 
                using (SqlCommand Command = new SqlCommand("SP_GetPersonsByID", Connection))
                {


                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@PersonID",(object) PersonID??DBNull.Value);


                    using (SqlDataReader Reader = Command.ExecuteReader())
                    {

                        if (Reader.Read())
                        {

                            IsFound = true;

                            FirstName = (Reader["FirstName"]!=DBNull.Value)?(string)Reader["FirstName"]:null;
                            SecondName = (Reader["SecondName"]!=DBNull.Value)? (string)Reader["SecondName"]:null;
                            ThirdName = (Reader["ThirdName"] != DBNull.Value) ? (string)Reader["ThirdName"] : null;
                            LastName = (Reader["LastName"] != DBNull.Value) ? (string)Reader["LastName"] : null;
                            DateOfBirth = (DateTime)Reader["DateOfBirth"];
                            Gendor = (byte)Reader["Gendor"];
                            Phone = (string)Reader["Phone"]; 
                            Email = (string)Reader["Email"];
                            Address = (Reader["Address"]!=DBNull.Value)?(string)Reader["Address"]:null;
                            ImagePath = (Reader["ImagePath"] != DBNull.Value) ? (string)Reader["ImagePath"] : null;
                         
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

        public static int? AddNewPersons(string FirstName,string SecondName,string ThirdName,string LastName, DateTime DateOfBirth, short Gendor,
            string Phone, string Email, string Address,string ImagePath)
        {

            int ?NewPersonID =null;


            try
            {
                using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
                {

                    Connection.Open();

                    using (SqlCommand Command = new SqlCommand("SP_AddNewPerson", Connection))
                    {
                        //Command from Type Stored Procedure 
                        Command.CommandType = CommandType.StoredProcedure;


                        Command.Parameters.AddWithValue("@FirstName",(object) FirstName??DBNull.Value);
                        Command.Parameters.AddWithValue("@SecondName", (object)SecondName??DBNull.Value);
                        Command.Parameters.AddWithValue("@ThirdName", (object)ThirdName ?? DBNull.Value);
                        Command.Parameters.AddWithValue("@LastName", (object)LastName ?? DBNull.Value);
                        Command.Parameters.AddWithValue("@DateOfBirth", (object)DateOfBirth ?? DBNull.Value);
                        Command.Parameters.AddWithValue("@Gendor", (object)Gendor ?? DBNull.Value);
                        Command.Parameters.AddWithValue("@Phone", (object)Phone ?? DBNull.Value);
                        Command.Parameters.AddWithValue("@Email", (object)Email ?? DBNull.Value);
                        Command.Parameters.AddWithValue("@Address", (object)Address??DBNull.Value);
                        Command.Parameters.AddWithValue("@ImagePath", (object)ImagePath ?? DBNull.Value);




                        //represent a Parameter 
                        SqlParameter OutPutPersonID = new SqlParameter("@PersonID", SqlDbType.Int)//Type of output parameter 
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



        public static bool UpdatePerson(int? PersonID, string FirstName,string SecondName,string ThirdName,string LastName, DateTime DateOfBirth
            , short Gendor, string Phone, string Email, string Address,string ImagePath)
        {


            int RowAffected = 0;

            try
            {

                using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
                {

                    Connection.Open();

                    using (SqlCommand Command = new SqlCommand("SP_UpdatePerson", Connection))
                    {

                        Command.CommandType = CommandType.StoredProcedure;


                        Command.Parameters.AddWithValue("@PersonID", PersonID);
                        Command.Parameters.AddWithValue("@FirstName", (object)FirstName ?? DBNull.Value);
                        Command.Parameters.AddWithValue("@SecondName", (object)SecondName ?? DBNull.Value);
                        Command.Parameters.AddWithValue("@ThirdName", (object)ThirdName ?? DBNull.Value);
                        Command.Parameters.AddWithValue("@LastName", (object)LastName ?? DBNull.Value);
                        Command.Parameters.AddWithValue("@DateOfBirth", (object)DateOfBirth ?? DBNull.Value);
                        Command.Parameters.AddWithValue("@Gendor", (object)Gendor ?? DBNull.Value);
                        Command.Parameters.AddWithValue("@Phone", (object)Phone ?? DBNull.Value);
                        Command.Parameters.AddWithValue("@Email", (object)Email ?? DBNull.Value);
                        Command.Parameters.AddWithValue("@Address", (object)Address ?? DBNull.Value);
                        Command.Parameters.AddWithValue("@ImagePath", (object)ImagePath ?? DBNull.Value);














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

        public static bool DeletePerson(int PersonID)
        {


            int RowAffected = 0;


            using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
            {

                Connection.Open();

                using (SqlCommand Command = new SqlCommand("SP_DeletePerson", Connection))
                {

                    Command.CommandType = CommandType.StoredProcedure;

                    Command.Parameters.AddWithValue("@PersonID", PersonID);


                    RowAffected = Command.ExecuteNonQuery();
                }

            }
            return RowAffected > 0;
        }
        public static bool IsPersonExist(string Name)
        {
            bool IsFound = true;



            try
            {



                using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
                {


                    Connection.Open();

                    string Query = @"SELECT  found =1 from People where Name =@Name";

                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {

                        Command.Parameters.AddWithValue("@Name", Name);

                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {

                            IsFound = Reader.HasRows;

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
        public static DataTable GetAllPeople()
        {

            DataTable dt = new DataTable();

            using (SqlConnection Connection = new SqlConnection(clsSettings.ConnectionString))
            {

                Connection.Open();

                using (SqlCommand Command = new SqlCommand("SP_GetAllPersons", Connection))
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
       
