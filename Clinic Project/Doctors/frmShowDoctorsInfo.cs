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
    public partial class frmShowDoctorsInfo : Form
    {

        int ?_DoctorID=null;
        public frmShowDoctorsInfo(int? DoctorID)
        {
            InitializeComponent();
            _DoctorID = DoctorID;   
        }

        private void frmShowDoctorsInfo_Load(object sender, EventArgs e)
        {
            ctrlDoctorsCard1.LoadDoctorsInfoByDoctorID(_DoctorID);
        }
    }
}
