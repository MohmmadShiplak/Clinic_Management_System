using Clinic_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Business
{
    public    class clsPerson
    {

        public enum enMode { AddNew=0,UpdateNew=1 };
        public enMode _Mode;

    
        clsPerson _Person;

        public int ?PersonID { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public  string ThirdName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public short Gendor { get; set; }

        public string Phone { get; set; }

      public   string Email { get; set; }

      public   string Address { get; set; }

        public string ImagePath { get; set; }


     

        public bool IsDoctor() => clsDoctor.IsDoctor(PersonID);

    


        public string FullName() => string.Concat(FirstName + " ", SecondName + " " + ThirdName + " " + LastName);
      
        //public string FullName()
        //{
           
        //}


        public clsPerson()
        {

            this.PersonID =null;
            this.FirstName = null;
            this.SecondName = null;
            this.ThirdName = null;
            this.LastName = null;
            this.DateOfBirth = DateTime.Now;
            this.Gendor = 0;
            this.Phone = null;
            this.Email = null;
            this.Address = null;
            this.ImagePath = null;


            _Mode = enMode.AddNew;




        }
        public clsPerson(int? PersonID,string FirstName,string SecondName,string ThirdName,string LastName ,DateTime DateOfBirth,short Gendor
            ,string Phone,string Email,string Address,string ImagePath)
        {

            this.PersonID =PersonID;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gendor =Gendor;
            this.Phone = Phone;
            this.Email = Email;
            this.Address = Address;
            this.ImagePath = ImagePath;
         //   this.AppointmentsInfo = clsAppointments.Find(PersonID);
            _Mode = enMode.UpdateNew;

        }
        private bool AddNewPersons()
        {

            this.PersonID = clsPersonData.AddNewPersons(this.FirstName,this.SecondName,this.ThirdName,this.LastName, this.DateOfBirth, this.Gendor, this.Phone
                , this.Email, this.Address,this.ImagePath);

            return (PersonID.HasValue);

        }
        private bool  UpdatePersons()
        {
            return clsPersonData.UpdatePerson(this.PersonID,this.FirstName ,this.SecondName,this.ThirdName,LastName, this.DateOfBirth, this.Gendor, this.Phone, this.Email, this.Address,this.ImagePath);
        }
        public bool Save()
        {

switch(_Mode)
            {
                case enMode.AddNew:
                    if(AddNewPersons())
                    {

                        _Mode = enMode.UpdateNew;

                        return true;

                    }
                    else
                    {
                        return false;
                    }
                case enMode.UpdateNew:
                    return UpdatePersons();

            }
            return true; 
        }
        public static  clsPerson Find(int ?PersonID)
        {

            string FirstName = null,SecondName=null,ThirdName=null,LastName=null, Address = null, Email = null, Phone = null,ImagePath=null;

               short  Gendor=-1;

            DateTime DateOfBirth=DateTime.Now;


            if (clsPersonData.GetPersonsInfoByID(PersonID, ref FirstName,ref SecondName,ref ThirdName,ref LastName, ref DateOfBirth, ref Gendor, ref Phone, ref Email, ref Address,ref ImagePath))
                return new clsPerson(PersonID,FirstName,SecondName,ThirdName,LastName, DateOfBirth, Gendor, Phone, Email, Address,ImagePath);
            else
            return null;


        }
        public static bool IsPersonExist(string Name)
        {
            return clsPersonData.IsPersonExist(Name);
        }
        public static DataTable GetAllPeople()=>clsPersonData.GetAllPeople();
       
        public static bool DeletePerson(int PersonID)=>clsPersonData.DeletePerson(PersonID);
        


    }
}
