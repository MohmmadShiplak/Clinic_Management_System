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
    public partial class frmAddUpdatePatients : Form
    {



        public enum enMode { AddNew=0, UpdateNew=1}
        public enMode _Mode=enMode.AddNew;


        public int ?_PatientID = null;

        public clsPatient _Patinet;

        public frmAddUpdatePatients(int PatinetID)
        {
            InitializeComponent();

            _PatientID = PatinetID;

            _Mode = enMode.UpdateNew;
        }
        public frmAddUpdatePatients()
        {
            InitializeComponent();

           _Mode = enMode.AddNew;
        }

        private void _FillComboBoxWithillnessesName()
        {

            DataTable dtillnessName = clsillnesses.AllOnlyNames();
           

            foreach(DataRow Row in dtillnessName.Rows)
            {
                cbillnessName.Items.Add(Row["illnessName"]);
            }

        }

        private void _ResetDefualtValues()
        {
            _FillComboBoxWithillnessesName();

            if(_Mode == enMode.AddNew )
            {
                _Patinet = new clsPatient();
            }
            else
            {




            }

            lblPatinetID.Text = "[???]";
            txtNotes.Text = "[???]";
           // lblCreationDate.Text = "[???]";
            cbillnessName.SelectedIndex = 0;
                
        }
        private void _FillPatientsInfo()
        {

            ctrlPersonCardWithFilter1.LoadPersonInfo(_Patinet.PersonID);
            lblPatinetID.Text = _PatientID.ToString();
            txtNotes.Text = _Patinet.Notes;
            cbillnessName.SelectedIndex = cbillnessName.FindString(_Patinet.illnessesInfo.illnessName);
            //  lblCreationDate.Text=clsFormat.DateToShort()
            dtpCreationDate.Value = _Patinet.CreationDate.Value;


        }


        public void LoadData()
        {

           _Patinet = clsPatient.FindbyPatientID(_PatientID);

            if(_Patinet==null)
            {

MessageBox.Show("There is No Patients With PatinetID "+_PatientID.ToString(),"Error"
    ,MessageBoxButtons.OK,MessageBoxIcon.Error);


                return;

            }
            _FillPatientsInfo();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {


            int ?IllnessID = clsillnesses.Find(cbillnessName.Text).illnessID;

            _Patinet.illnessID = IllnessID; 
            _Patinet.Notes=txtNotes.Text;
            _Patinet.PersonID = ctrlPersonCardWithFilter1.PersonID;
            _Patinet.CreationDate=dtpCreationDate.Value;
            if(_Patinet.Save())
            {

                lblPatinetID.Text = _Patinet.PatientID.ToString();

                _Mode = enMode.UpdateNew;


                MessageBox.Show("Data Saved Successfully :-)", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data Failed To Save  (:-", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmAddUpdatePatients_Load(object sender, EventArgs e)
        {

            _ResetDefualtValues();

            if (_Mode == enMode.UpdateNew)
                LoadData();



        }
    }
}
