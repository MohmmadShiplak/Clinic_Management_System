using Clinic_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinic_Project
{
    public partial class frmAddUpdatePayments : Form
    {

        private  enum enMode { AddNew=0,UpdateNew=1 };

        private  enMode _Mode;


        private int ?_PaymentID = null;


        private clsPayments _Payment;

        private int ?_SelectedPaymentID;


        public frmAddUpdatePayments(int PaymentID)
        {
            InitializeComponent();

            _PaymentID = PaymentID;


            _Mode = enMode.UpdateNew;
        }

        private void FillComboBoxWithPaymentNames()
        {

            DataTable dtPaymentNames = clsPaymentMethod.GetAllPaymentsMethod();


            foreach (DataRow Row in dtPaymentNames.Rows)
            {
                cbPaymentMethod.Items.Add(Row["PaymentName"]);
            }


        }

       private void ResetDefaultValues()
        {

            FillComboBoxWithPaymentNames();


            if (_Mode == enMode.AddNew)
            {


                _Payment = new clsPayments();

                return;
            }
         

            lblPaymentID.Text =null;
            dtpPaymentDate.Value = DateTime.Now;
            cbPaymentMethod.SelectedIndex = 0;
            txtAmountPaid.Text = null;
            txtAdditionalNotes.Text = null ;

        }

        public frmAddUpdatePayments()
        {
            InitializeComponent();


            _Mode = enMode.AddNew ;
        }


       private void _FillPaymentsInfoWithData()
        {

            lblPaymentID.Text = _Payment.PaymentID.ToString();
            dtpPaymentDate.Value = _Payment.PaymentDate.Value;
            cbPaymentMethod.SelectedIndex = cbPaymentMethod.FindString(_Payment.PaymentInfo.PaymentName);
            txtAmountPaid.Text = _Payment.AmountPaid.ToString();
            txtAdditionalNotes.Text = _Payment.AdditionalNotes;
            ctrlPersonCardWithFilter1.LoadPersonInfo(_Payment.PersonID);
        }




        private void LoadData()
        {

            _Payment = clsPayments.Find(_PaymentID);

            if(_Payment==null)
            {

                MessageBox.Show("No Payments with PaymentID " + _PaymentID.ToString(), "Error"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Close();

                return;
            }

     _FillPaymentsInfoWithData();

        }

        private void frmAddUpdatePayments_Load(object sender, EventArgs e)
        {

            ResetDefaultValues();
           

        if(_Mode==enMode.UpdateNew)
            LoadData();


          
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {

            int ?PaymenMethod = clsPaymentMethod.Find(cbPaymentMethod.Text).ID;

            _Payment.PersonID = ctrlPersonCardWithFilter1.PersonID;
            _Payment.PaymentMethod = PaymenMethod;
            _Payment.PaymentDate = dtpPaymentDate.Value;
            _Payment.AmountPaid = Convert.ToDecimal(txtAmountPaid.Text);
            _Payment.AdditionalNotes = txtAdditionalNotes.Text;



            if (_Payment.Save())
            {


                lblPaymentID.Text = _Payment.PaymentID.ToString();

                _Mode = enMode.UpdateNew;   

                MessageBox.Show("Money Paid Successfully ", "Sucess"
                    , MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            else
            {

                MessageBox.Show("Error :Money does not Paid ", "Error"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);



            }

        }

     
    }
}
