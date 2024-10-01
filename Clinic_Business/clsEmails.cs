using Clinic_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using static Clinic_Business.clsPerson;

namespace Clinic_Business
{
    public   class clsEmails
    {

        public enum enMode { AddNew = 0, UpdateNew = 1 };
        public enMode _Mode;


        public clsEmails _Email;

        public int ID { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }


        public clsEmails()
        {

            this.ID = -1;
            this.Name = "";
            this.Text = "";



            _Mode = enMode.AddNew;

        }
        public clsEmails(int ID,string Name,string Text)
        {

            this.ID = ID;
            this.Name = Name;
            this.Text = Text;
            _Mode = enMode.UpdateNew;

        }

        private bool AddNewEmails()
        {

            this.ID = clsEmailsData.AddNewEmails(this.Name, this.Text);
                

            return (ID != -1);

        }
        private bool UpdateEmails()
        {
            return clsEmailsData.UpdateEmail(this.ID, this.Name, this.Text);
        }
       
        public bool Save()
        {


switch(_Mode)
            {

                case enMode.AddNew:
                    if(AddNewEmails())
                    {

                        _Mode = enMode.UpdateNew;
                        return true;



                    }
                    else
                    {
                        return false;
                    }
                case enMode.UpdateNew:
                    return UpdateEmails();

            }
            return true ;
        }







        public static clsEmails Find(int ID)
        {

            string Name = "", Text = "";


            if (clsEmailsData.GetEmailsInfobyID(ID, ref Name, ref Text))
                return new clsEmails(ID, Name, Text);
            else
                return null;

        }




    }
}
