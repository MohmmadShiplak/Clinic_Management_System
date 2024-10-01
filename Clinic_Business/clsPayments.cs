using Clinic_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Business
{
    public class clsPayments
    {

        public enum enMode { AddNew = 0, UpdateNew = 1 };

        public enMode _Mode;

        public int ?PaymentID { set; get; }

        public  int ?PersonID { get; set; }
        public DateTime ?PaymentDate { get; set; }
        public int? PaymentMethod { set; get; }

        public decimal ?AmountPaid { set; get; }

        public string AdditionalNotes { get; set; }

        public clsPaymentMethod PaymentInfo;

        public clsPayments(int ?PaymentID,int? PersonID, DateTime PaymentDate, int? PaymentMethod, decimal? AmountPaid, string AdditionalNotes)
        {

            this.PaymentID = PaymentID;
            this.PersonID = PersonID;
            this.PaymentDate = PaymentDate;
            this.PaymentMethod = PaymentMethod;
            this.AmountPaid = AmountPaid;
            this.AdditionalNotes = AdditionalNotes;
          this.PaymentInfo = clsPaymentMethod.Find(PaymentID);
            _Mode = enMode.UpdateNew;
        }
        public clsPayments()
        {

            this.PaymentID = null;
            this.PaymentDate = DateTime.MinValue;
            this.PaymentMethod = null;
            this.AmountPaid = 0;
            this.AdditionalNotes = null;

            _Mode = enMode.AddNew;
        }

        private bool _AddNewPayments()
        {

            this.PaymentID = clsPaymentsData.AddNewPayments(this.PersonID,this.PaymentDate, this.PaymentMethod, this.AmountPaid, this.AdditionalNotes);

            return (PaymentID.HasValue);
        }
        private bool _UpdatePayments()
        {
            return clsPaymentsData.UpdatePayments(this.PaymentID,this.PersonID, this.PaymentDate, this.PaymentMethod, this.AmountPaid, this.AdditionalNotes);
        }
        public bool Save()
        {

            switch (_Mode)
            {

                case enMode.AddNew:
                    if (_AddNewPayments())
                    {

                        _Mode = enMode.UpdateNew;

                        return true;

                    }
                    else
                    {
                        return false;

                    }
                case enMode.UpdateNew:
                    return _UpdatePayments();

            }
            return false;
        }
        public static clsPayments Find(int? ID)
        {

          string  AdditionalNotes = null;

            int ?PaymentMethod = null,PersonID=null;

            decimal? AmountPaid = null;

            DateTime PaymentDate = DateTime.MinValue;


            if (clsPaymentsData.GetPaymentsInfoByID(ID, ref PersonID ,ref PaymentDate, ref PaymentMethod, ref AmountPaid, ref AdditionalNotes))
                return new clsPayments(ID,PersonID, PaymentDate, PaymentMethod, AmountPaid, AdditionalNotes);
            else
                return null;

        }
     
        public static bool DeletePayment(int PaymentID)
        {
            return clsPaymentsData.DeletePayment(PaymentID);
        }
        public static DataTable GetAllPayments()
        {
            return clsPaymentsData.GetAllPayments();
        }
        public static int Count()=>clsPaymentsData.Count();





    }
}
