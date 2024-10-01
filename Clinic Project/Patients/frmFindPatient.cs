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
    public partial class frmFindPatient : Form
    {

        public Action<int?> PatientDataBack;








        public frmFindPatient()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            PatientDataBack.Invoke(ctrlPatientCardWithFilter1.PatientID);
        }
    }
}
