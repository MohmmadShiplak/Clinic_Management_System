using Clinic_Project.Patients;
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
    public partial class frmMain : Form
    {
        frmLogin _frmLogin;

        public frmMain(frmLogin frmLogin)
        {
            InitializeComponent();
            _frmLogin = frmLogin;   
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {

            Form frm1 = new frmDashboard();
            frm1.ShowDialog();

        }

        private void btnAppointments_Click(object sender, EventArgs e)
        {

            Form frm1 = new frmListAppointments();
            frm1.ShowDialog();


        }

        private void btnPatients_Click(object sender, EventArgs e)
        {

            Form frm1 =new  frmListPatients();
            frm1.ShowDialog();

        }

        private void btnDoctors_Click(object sender, EventArgs e)
        {

            Form frm1 = new frmListDoctors();
            frm1.ShowDialog();

        }

        private void btnPrescription_Click(object sender, EventArgs e)
        {

            Form frm1 = new frmListPrescription();
            frm1.ShowDialog();  

        }

        private void btnPayments_Click(object sender, EventArgs e)
        {

            Form frm1 = new frmListPayments();
            frm1.ShowDialog();

        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            frmSettings frm1=new frmSettings();
            frm1.ShowDialog();
        }
    }
}
