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
    public partial class frmListPrescription : Form
    {

        private DataTable _dtAllPrescription;

        public frmListPrescription()
        {
            InitializeComponent();
        }

        private void frmListPrescription_Load(object sender, EventArgs e)
        {
            _dtAllPrescription = clsPrescription.GetAllPrescriptions();
            dgvPatients.DataSource = _dtAllPrescription;



            dgvPatients.Columns[0].HeaderText = "PrescriptionID";
            dgvPatients.Columns[0].Width = 140;

            dgvPatients .Columns[1].HeaderText = "Patient Name";
             dgvPatients.Columns[1].Width = 150;

            dgvPatients.Columns[2].HeaderText = "Medication Name";
            dgvPatients.Columns[2].Width = 130;

         
        }

        private void addNewPrescriptionToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form frm1 = new frmAddUpdatePrescription();
            frm1.ShowDialog();
            frmListPrescription_Load(null, null);

        }

        private void updatePrescriptionToolStripMenuItem_Click(object sender, EventArgs e)
        {


            int PrescriptionID=(int)dgvPatients.CurrentRow.Cells[0].Value;

            Form frm1 = new frmAddUpdatePrescription(PrescriptionID);
            frm1.ShowDialog();
            frmListPrescription_Load(null, null);


        }

        private void deletePrescriptionToolStripMenuItem_Click(object sender, EventArgs e)
        {


            int PrescriptionID = (int)dgvPatients.CurrentRow.Cells[0].Value;


            if (clsPrescription.DeletePrescription(PrescriptionID))
            {

                MessageBox.Show("Prescription Deleted Successfully :-)", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmListPrescription_Load(null, null);
                return;

            }
            else
            {
                MessageBox.Show("Prescription is not Deleted due data to Connect it ", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
