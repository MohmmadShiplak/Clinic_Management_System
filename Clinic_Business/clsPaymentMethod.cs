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

    public class clsPaymentMethod
    {

        public enum enMode { AddNew=0,UpdateNew };
        public enMode _Mode=enMode.AddNew;


        public int ?ID { get; set; }
        public string PaymentName { get; set; }


        public clsPaymentMethod()
        {

            this.ID = null;
            this.PaymentName = "";

            _Mode=enMode.AddNew;
        }
        public clsPaymentMethod(int ?ID, string PaymentName)
        {

            this.ID = ID;
            this.PaymentName = PaymentName;

            _Mode=enMode.UpdateNew;
        }





        public static DataTable GetAllPaymentsMethod() => clsPaymentMethodData.GetAllPaymentsMethod();
       
        public static clsPaymentMethod Find(int ?ID)
        {

            string PaymentName = "";

            if (clsPaymentMethodData.GetPaymentMethodInfobyID(ID, ref PaymentName))
                return new clsPaymentMethod(ID, PaymentName);
            else
                return null;

        }
        public static clsPaymentMethod Find(string PaymentName)
        {

            int? ID = null;

            if (clsPaymentMethodData.GetPaymentMethodsInfobyName(PaymentName, ref ID))
                return new clsPaymentMethod(ID, PaymentName);
            else
                return null;

        }






    }
}
