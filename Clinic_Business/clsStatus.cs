using Clinic_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Business
{
    public  class clsStatus
    {

        public enum enMode { AddNew = 0, UpdateNew = 1 }
        public enMode _Mode;


        public int? StatusID { get; set; }
        public string StatusName { get; set; }






        public clsStatus(int? ID, string StatusName)
        {

            this.StatusID = ID;
            this.StatusName = StatusName;

            _Mode = enMode.UpdateNew;
        }






        public static DataTable AllOnlyNames() => clsStatusData.AllOnlyNames();


        public static clsStatus Find(int? StatusID)
        {

            string StatusName = "";


            if (clsStatusData.GetStatusesInfoByID(StatusID, ref StatusName))
                return new clsStatus(StatusID, StatusName);
            else
                return null;

        }
        public static clsStatus Find(string StatusName)
        {

            int? StatusID = null;


            if (clsStatusData.GetAllStatusesInfoByName(StatusName, ref StatusID))
                return new clsStatus(StatusID, StatusName);
            else
                return null;

        }







    }
}
