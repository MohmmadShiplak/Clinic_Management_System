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
    public partial class frmFindDoctors : Form
    {

        public Action<int?> DataBack;


        public frmFindDoctors()
        {
            InitializeComponent();
              
        }

        private void frmFindDoctors_Load(object sender, EventArgs e)
        {
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DataBack.Invoke(ctrlDoctorsCardWithFilter1?.DoctorID);
        }

        private void ctrlDoctorsCardWithFilter1_Load(object sender, EventArgs e)
        {

        }

        private void ctrlDoctorsCardWithFilter1_OneDoctorSelected(object sender, ctrlDoctorsCardWithFilter.clsDoctorsSelectedEventArgs e)
        {

        }
    }
}
