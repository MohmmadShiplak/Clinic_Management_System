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
    public  class clsMajor
    {

        public enum enMode { AddNew=0, UpdateNew=1}
        public enMode _Mode;


        public int ?MajorID { get; set; }
        public string MajorName { get; set; }   


        public clsMajor(int ?MajorID,string MajorName)
        {

            this.MajorID = MajorID;
            this.MajorName = MajorName;

           _Mode = enMode.UpdateNew;   
        }






     public static DataTable AllOnlyNames()=>clsMajorData.AllOnlyNames();


        public static   clsMajor Find(int MajorID)
        {

            string MajorName = "";


            if (clsMajorData.GetMajorsInfoByID(MajorID, ref MajorName))
                return new clsMajor(MajorID, MajorName);
            else
                return null;

        }
        public static clsMajor Find(string MajorName)
        {

            int ?MajorID = null;


            if (clsMajorData.GetMajorsInfoByName(MajorName,ref MajorID))
                return new clsMajor(MajorID, MajorName);
            else
                return null;

        }
        public static byte ?GetMajorID(string MajorName)=>clsMajorData.GetMajorID(MajorName);





    }
}
