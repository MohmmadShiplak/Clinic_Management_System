using Clinic_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Business
{
    public class clsUsers
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;



        public enum enPermissions
        {
            All = -1,
            AddUser = 1,
            UpdateUser = 2,
            DeleteUser = 4,
            ListUsers = 8
        }


        public int? UserID { get; set; }
        public int? PersonID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Permissions { get; set; }
        public bool IsActive { get; set; }

        public clsPerson PersonInfo { get; private set; }

        public clsUsers()
        {
            UserID = null;
            PersonID = null;
            Username = string.Empty;
            Password = string.Empty;
            Permissions = -1;
            IsActive = true;

            Mode = enMode.AddNew;
        }

        private clsUsers(int? userID, int? personID, string username, string password,
            int permissions, bool isActive)
        {
            UserID = userID;
            PersonID = personID;
            Username = username;
            Password = password;
            Permissions = permissions;
            IsActive = isActive;
            PersonInfo = clsPerson.Find(personID);

            Mode = enMode.Update;
        }

        private bool _Add()
        {
            UserID = clsUsersData.Add(PersonID, Username, Password, Permissions, IsActive);

            return (UserID.HasValue);
        }

        private bool _Update()
        {
            return clsUsersData.Update(UserID, PersonID, Username, Password, Permissions, IsActive);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_Add())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _Update();
            }

            return false;
        }

        public static clsUsers FindByUserID(int? UserID)
        {
            int? PersonID = null;
            string Username = string.Empty;
            string Password = string.Empty;
            int permissions = -1;
            bool IsActive = false;

            bool IsFound = clsUsersData.GetUserInfoByUserID(UserID, ref PersonID,
             ref Username, ref Password, ref permissions, ref IsActive);

            return (IsFound) ? (new clsUsers(UserID, PersonID, Username, Password, permissions, IsActive)) : null;


        }
        public static clsUsers Find(int? PersonID)
        {
            int? UserID = null;
            string Username = string.Empty;
            string Password = string.Empty;
            int permissions = -1;
            bool IsActive = false;

            bool IsFound = clsUsersData.GetUsersInfoByPersonID(PersonID, ref UserID,
                ref Username, ref Password, ref permissions, ref IsActive);

            return (IsFound) ? (new clsUsers(UserID, PersonID, Username, Password, permissions, IsActive)) : null;
        }
        public static clsUsers Find(string UserName, string Password)
        {
            int? UserID = null;


            int? personID = null;



            int permissions = -1;
            bool IsActive = false;

            bool IsFound = clsUsersData.GetUserInfoByUsernameAndPassword(ref UserID, ref personID, UserName, Password, ref permissions, ref IsActive);



            return (IsFound) ? (new clsUsers(UserID, personID, UserName, Password, permissions, IsActive)) : null;
        }
      public  bool ChangePassword(int ?UserID,string NewPasssowrd)=>clsUsersData.ChangePassword(UserID, NewPasssowrd);

        public bool ChangePassword(string NewPassowrd) => ChangePassword(UserID, NewPassowrd);


        public static DataTable GetAllUsers()=>clsUsersData.GetAllUsers();

        public static bool DeleteUser(int UserID) => clsUsersData.DeleteUser(UserID);


    }
}
