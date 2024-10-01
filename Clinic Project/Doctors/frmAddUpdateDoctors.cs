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
    public partial class frmAddUpdateDoctors : Form
    {

        public enum enMode { AddNew=0,Updare =1 };

        public enMode _Mode;


       private   int ?_DoctorID = null;

        public clsDoctor _Doctor = null;

        private int? _SelectedDoctorID = null;


        public frmAddUpdateDoctors(int DoctorID)
        {
            InitializeComponent();

           _DoctorID= DoctorID;

          _Mode = enMode.Updare;
        }

        public frmAddUpdateDoctors()
        {
            InitializeComponent();

            _Mode = enMode.AddNew;
        }

       private void _FillComboBoxWithMajorNames ()
        {

            DataTable _dtMajorNames = clsMajor.AllOnlyNames();

            foreach(DataRow Row in _dtMajorNames.Rows)
            {
                cbMajors.Items.Add(Row["MajorName"]);
            }

            if (cbMajors.Items.Count > 0)
                cbMajors.SelectedIndex = 0;
        }

        private void ResetDefualtValues()
        {

            _FillComboBoxWithMajorNames();

          if(_Mode==enMode.AddNew)
            {

                _Doctor = new clsDoctor();

                lblTitle.Text = "Add New Doctors ";

                return;

            }
    

        }
        public void LoadData()
        {

            _Doctor = clsDoctor.FindByDoctorID(_DoctorID);

            if(_Doctor==null)
            {

MessageBox.Show("No Doctors With DoctorID "+_DoctorID.ToString(),"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);

                return;
            }

            ctrlPersonCardWithFilter1.LoadPersonInfo(_Doctor.PersonID);
            lblDoctorID.Text = _Doctor.DoctorID.ToString();
            cbMajors.SelectedIndex = cbMajors.FindString(_Doctor.MajorInfo.MajorName);
            NumericUpDown.Value = (int)_Doctor.Experience;
            //this will Implement Later 
         //   lblCreatedByUserID.Text = clsGlobal.CurrentUser.Username;
        }


        private void frmAddUpdateDoctors_Load(object sender, EventArgs e)
        {

            ResetDefualtValues();

            if (_Mode == enMode.Updare)
                LoadData();


        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {


            // int? MajorID = clsMajor.Find(cbMajors.Text).MajorID;


            _Doctor.DoctorID = _SelectedDoctorID;
            _Doctor.Experience = (byte)NumericUpDown.Value;
            _Doctor.MajorID = clsMajor.GetMajorID(cbMajors.Text);
            _Doctor.PersonID = ctrlPersonCardWithFilter1.PersonID;
          //  _Doctor.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if (_Doctor.Save())
            {

                lblDoctorID.Text = _Doctor.DoctorID.ToString();


                MessageBox.Show("Data Saved Successfully :-)", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _Mode = enMode.Updare;



            }
            else
            {

                MessageBox.Show("Data Failed to Save (:-", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void ctrlPersonCardWithFilter1_OnePersonComplete_1(object sender, ctrlPersonCardWithFilter.clsPersonEventArg e)
        {
            //check if PersonID does not Exist 
            if (!e.PersonID.HasValue)
            {

                btnSave.Enabled = false;

                return;

            }


            if (_Mode == enMode.AddNew && ctrlPersonCardWithFilter1.SelectedPersonInfo.IsDoctor())
            {

                MessageBox.Show("This Person Already Selected as a Doctor Please Choose Onther One", "Error"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);

                btnSave.Enabled = false;


                return;
            }


            btnSave.Enabled = true;

            _SelectedDoctorID = e?.PersonID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
