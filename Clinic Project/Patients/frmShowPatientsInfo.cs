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
    public partial class frmShowPatientsInfo : Form
    {
        private int ?_PatientID = null;

        public frmShowPatientsInfo(int? PatientID)
        {
            InitializeComponent();
            _PatientID = PatientID; 
        }

        private void frmShowPatientsInfo_Load(object sender, EventArgs e)
        {
            ctrlPatientCard1.LoadPatientInfoByPatientID(_PatientID);
        }
    }
}
