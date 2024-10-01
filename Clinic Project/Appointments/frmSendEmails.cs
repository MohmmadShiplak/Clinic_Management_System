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
    public partial class frmSendEmails : Form
    {

        public int ID=-1;

        public enum enMode { AddNew=0,Update=1 };

        public enMode _Mode;


        public clsEmails _Email;


        public frmSendEmails()
        {
            InitializeComponent();
        }

        private void LoadData()
        {


if(_Mode==enMode.AddNew)
            {
                _Email= new clsEmails();

                return;
            }
else
            {
//
            }

            _Email = clsEmails.Find(ID);

            if(_Email==null)
            {

                MessageBox.Show("No Emails with Email " + _Email.Name, "Error"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);



            }




            lblID.Text = _Email.ID.ToString();
            txtName.Text = _Email.Name;
            txtText.Text = _Email.Text;


        }

        private void frmSendEmails_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {

            _Email.Name = txtName.Text;
            _Email.Text = txtText.Text;


            if (_Email.Save())
            {


                lblID.Text = _Email.ID.ToString();

                MessageBox.Show("Email Send Successfully for a Patient ", "Sucess"
                    , MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            else
            {
                MessageBox.Show("Email does not Send ", "Failed"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);

            }






        }
    }
}
