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
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {

            lblDoctors.Text = clsDoctor.Count().ToString();

            lblAppointments.Text=clsAppointments.count().ToString();

            lblPatients.Text = clsPatient.Count().ToString();

            lblMedicalRecords.Text=clsMedicalRecord.Count().ToString();  

            lblPayments.Text=clsPayments.Count().ToString();

            lblPrescription.Text = clsPrescription.Count().ToString();

        }
    }
}
