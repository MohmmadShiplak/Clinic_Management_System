using Clinic_Business;
using Clinic_Project.Properties;
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
    public partial class ctrlDoctorsCard : UserControl
    {

        private  int? _DoctorID = null;

        clsDoctor _Doctor;


        public int ?DoctorID
        {
            get { return _DoctorID; }
        }

       private void _FillDoctorsInfo()
        {

            _DoctorID = _Doctor.DoctorID.Value;

            ctrlPersonCard1.LoadPersonInfo(_Doctor.PersonID);

            lblDoctorID.Text=_Doctor.DoctorID.ToString();

            lblExperience.Text=_Doctor.Experience.ToString();

            lblSpecification.Text = _Doctor.MajorInfo.MajorName;

           // lblCreatedByUserID.Text = _Doctor.CreatedUserInfo.Username;

        }
        public void LoadDoctorsInfoByDoctorID(int ?DoctorID)
        {

            _DoctorID = DoctorID;

            if (!_DoctorID.HasValue)
            {
                MessageBox.Show("No Patinets With PatientID " + _Doctor.ToString(), "Error"
                   , MessageBoxButtons.OK, MessageBoxIcon.Error);

                _ResetDefualtValues();

                return;

            }

            _Doctor = clsDoctor.FindByDoctorID(_DoctorID);

            if(_Doctor==null)
            {

                _ResetDefualtValues();

                MessageBox.Show("No Doctors With DoctorID "+_DoctorID.ToString(),"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);

                

                return;
            }
            _FillDoctorsInfo();
        }
        public void LoadDoctorsInfoByPersonID(int PersonID)
        {

            _Doctor = clsDoctor.FindByPersonID(PersonID);

            if (_Doctor == null)
            {

                MessageBox.Show("No Doctors With DoctorID " + _DoctorID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                _ResetDefualtValues();

                return;
            }
            _FillDoctorsInfo();
        }










        private void _ResetDefualtValues()
        {

            _DoctorID = null;

            _Doctor = null;
            lblDoctorID.Text = "[????]";
            lblExperience.Text = "[????]";
            lblSpecification.Text = "[????]";
            lblCreatedByUserID.Text = "[????]";

        }

        public ctrlDoctorsCard()
        {
            InitializeComponent();
        }

        private void ctrlDoctorsCard_Load(object sender, EventArgs e)
        {

        }
    }
}
