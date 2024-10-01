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
    public partial class frmAddUpdateAppointment : Form
    {

        public enum enMode { AddNew=0,UpdateNew=1 }

        public enMode _Mode = enMode.AddNew;


        private int _AppointmentID = -1;

        private clsAppointments _Appointment;

        private int ?_SelectedApponitment=null;

        private TimeSpan GetTimeFromDateTimePicker()
        {

            int Hours = dtpTime.Value.Hour;

            int Minutes = dtpTime.Value.Minute;

            return new TimeSpan(Hours, Minutes, 0);
        }

        public frmAddUpdateAppointment(int AppointmentID)
        {
            InitializeComponent();

            _AppointmentID = AppointmentID;

            _Mode = enMode.UpdateNew;
        }
        public frmAddUpdateAppointment()
        {
            InitializeComponent();

            _Mode = enMode.AddNew;
        }
        private void _ResetDefualtValues()
        {
            FillComboBoxWithStatusName();

            if (_Mode == enMode.AddNew)
            {

                _Appointment = new clsAppointments();


                tpDoctors.Enabled=false;

                return;
            }
            else
            {
                tpDoctors.Enabled = true;
                btnSave.Enabled = true;
            }

        }
        private void FillComboBoxWithStatusName()
        {

            DataTable dtStatusName = clsStatus.AllOnlyNames();


            foreach(DataRow Row in dtStatusName.Rows)
            {
                cbStatus.Items.Add(Row["StatusName"]);
            }

        }







        private void FillAppointmentsInfo()
        {
         
            lblAppointment.Text = _Appointment.AppointmentID.ToString();
            dtpTime.Value = (DateTime.Now - _Appointment.Time);
            ctrlDoctorsCardWithFilter1.LoadDoctorsInfoByDoctorID(_Appointment.DoctorID);
            ctrlPatientCardWithFilter1.LoadPatientInfoByPatinetID(_Appointment.PatientID);
            cbStatus.SelectedIndex = cbStatus.FindString(_Appointment.StatusInfo.StatusName);
        }


        private void LoadData()
        {



            _Appointment = clsAppointments.Find(_AppointmentID);

            if(_Appointment==null)
            {

                MessageBox.Show("No Appointments with AppointmentID" + _AppointmentID.ToString(), "Error"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

        FillAppointmentsInfo(); 
        }


        private void frmAddUpdateAppointment_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();


if(_Mode==enMode.UpdateNew)
            LoadData();
        }



        private void btnSave_Click_3(object sender, EventArgs e)
        {

            int ?StatusID = clsStatus.Find(cbStatus.Text).StatusID;

            _Appointment.StatusID = StatusID;
            _Appointment.DoctorID = ctrlDoctorsCardWithFilter1.DoctorID;
            _Appointment.PatientID = ctrlPatientCardWithFilter1.PatientID;
            _Appointment.Time = GetTimeFromDateTimePicker();



            if (_Appointment.Save())
            {

                lblAppointment.Text = _Appointment.AppointmentID.ToString();


                _Mode = enMode.UpdateNew;

                MessageBox.Show("Appointment Saved Successfully :-)", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Appointment Failed to Save   ):-", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void ctrlPatientCardWithFilter1_OnePatientSelected_3(object sender, ctrlPatientCardWithFilter.clsPatientSelectedEventArgs e)
        {

            if(!e.PatientID.HasValue)
            {
                btnSave.Enabled = false;

                return;

            }


            if (_Mode == enMode.AddNew && ctrlPatientCardWithFilter1.SelectedPatinetInfo.IsAppointment())
            {

                MessageBox.Show(" this Patient Already has an Appointment Please Choose Onther One "
                    , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                btnSave.Enabled = false;

                tpDoctors.Enabled = false;

                tpAppointments.Enabled = false;



                return;
            }


            _SelectedApponitment = e.PatientID;

            tpDoctors.Enabled = true;



            tpAppointments.Enabled = true;

            btnSave.Enabled = true;



        }

        private void btnNext_Click(object sender, EventArgs e)
        {

            if(_Mode==enMode.UpdateNew)
            {
                btnSave.Enabled = true;
                tpDoctors.Enabled = true;

               

                return;
            }
            else
            {
                btnSave.Enabled = true;
                tpPatient.Enabled = true;
                tcPatientInfo.SelectedTab = tcPatientInfo.TabPages[1];


            }







        }

        private void btnNext2_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.UpdateNew)
            {
                btnSave.Enabled = true;
                tpDoctors.Enabled = true;


                return;
            }
            else
            {
                btnSave.Enabled = true;
                tpPatient.Enabled = true;
                tcPatientInfo.SelectedTab = tcPatientInfo.TabPages[2];

            }





        }
    }
}
