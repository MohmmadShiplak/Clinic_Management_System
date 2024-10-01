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
using System.Xml.Serialization;

namespace Clinic_Project
{
    public partial class frmAddUpdateMedicalRecord : Form
    {

        private  enum enMode { AddNew = 0, UpdateNew = 1 };

        private  enMode _Mode;


        private  int ?_MedicalID = null;


        private  clsMedicalRecord _MedicalRecord;

        


        public frmAddUpdateMedicalRecord(int ID)
        {
            InitializeComponent();

            _MedicalID = ID;


            _Mode = enMode.UpdateNew;
        }
        public frmAddUpdateMedicalRecord()
        {
            InitializeComponent();

            _Mode = enMode.AddNew;
        }

        private void ResetDefualtValues()
        {

            if (_Mode == enMode.AddNew)
            {


                _MedicalRecord = new clsMedicalRecord();

                return;
            }


            txtDescription.Text = null;
            txtDiagonsis.Text = null;
            txtNotes.Text = null;

        }

        private void _FillMedicalRecordsInfoWithData()
        {

            lblMedicalRecord.Text = _MedicalRecord.ID.ToString();
            ctrlPatientCardWithFilter1.LoadPatinetsInfo(_MedicalRecord.PatientID);
            txtDescription.Text = _MedicalRecord.Description;
            txtDiagonsis.Text = _MedicalRecord.Diagonsis;
            txtNotes.Text = _MedicalRecord.Notes;


        }
        private void LoadData()
        {

         
            _MedicalRecord = clsMedicalRecord.Find(_MedicalID);

            if (_MedicalRecord == null)
            {

                MessageBox.Show("No Medical Records  with MedicalRecordID " + _MedicalID.ToString(), "Error"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Close();

                return;
            }

            _FillMedicalRecordsInfoWithData();

        }

        private void btnSave_Click_2(object sender, EventArgs e)
        {

            _MedicalRecord.PatientID = ctrlPatientCardWithFilter1.PatientID;
            _MedicalRecord.Description = txtDescription.Text;
            _MedicalRecord.Diagonsis = txtDiagonsis.Text;
            _MedicalRecord.Notes = txtNotes.Text;


            if (_MedicalRecord.Save())
            {


                lblMedicalRecord.Text = _MedicalRecord.ID.ToString();

                _Mode = enMode.UpdateNew;

                MessageBox.Show("Data Saved Successfully :-) ", "Sucess"
                    , MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            else
            {

                MessageBox.Show("Error :Data does Saved (:- ", "Error"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);



            }


        }

        private void frmAddUpdateMedicalRecord_Load(object sender, EventArgs e)
        {


            if(_Mode==enMode.UpdateNew)
            LoadData();
        }

     
    }

    }

