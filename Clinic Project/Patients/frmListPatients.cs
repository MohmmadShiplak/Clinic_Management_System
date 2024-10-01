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

namespace Clinic_Project.Patients
{
    public partial class frmListPatients : Form
    {


        DataTable _dtPatients;






        public frmListPatients()
        {
            InitializeComponent();
        }

        private void frmListPatients_Load(object sender, EventArgs e)
        {

            _dtPatients = clsPatient.GetAllPatients();
            dgvPatients.DataSource = _dtPatients;

            dgvPatients.Columns[0].HeaderText = "Patient ID";
            dgvPatients.Columns[0].Width = 120;

            dgvPatients.Columns[1].HeaderText = "Full Name";
            dgvPatients.Columns[1].Width = 150;

            dgvPatients.Columns[2].HeaderText = "DateOfBirth";
            dgvPatients.Columns[2].Width = 150;

            dgvPatients.Columns[3].HeaderText = "Gender Name";
            dgvPatients.Columns[3].Width = 100;

            dgvPatients.Columns[4].HeaderText = "Sick Name ";
            dgvPatients.Columns[4].Width = 100;

            lblRecord.Text = _dtPatients.Rows.Count.ToString();
        }

        private void showPatientsInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {

int PatientID = (int)dgvPatients.CurrentRow.Cells[0].Value;

            frmShowPatientsInfo frm1 = new frmShowPatientsInfo(PatientID);
            frm1.ShowDialog();
        }

        private void updatePatientsInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int PatientID = (int)dgvPatients.CurrentRow.Cells[0].Value;

            frmAddUpdatePatients frm1=new frmAddUpdatePatients(PatientID);
            frm1.ShowDialog();
            frmListPatients_Load(null, null);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            frmAddUpdatePatients frm1 = new frmAddUpdatePatients();
            frm1.ShowDialog();
            frmListPatients_Load(null, null);



        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

            frmAddUpdateAppointment frm1 = new frmAddUpdateAppointment();
            frm1.ShowDialog();


        }

        private void deletePatinetsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int PatientID =(int)dgvPatients.CurrentRow.Cells [0].Value;


            if(clsPatient.DeletePatient(PatientID))
            {

                MessageBox.Show("Patient Deleted Successfully :-)", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmListPatients_Load(null, null);

                return;

            }
            else
            {
                MessageBox.Show("Patient is not Deleted due to Connect data ","error",MessageBoxButtons.OK, MessageBoxIcon.Error);  
            }

        }
    }
}
