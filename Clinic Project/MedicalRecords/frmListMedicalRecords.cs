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
    public partial class frmListMedicalRecords : Form
    {

        private DataTable _dtMedicalRecords;


        public frmListMedicalRecords()
        {
            InitializeComponent();
        }

        private void frmListMedicalRecords_Load(object sender, EventArgs e)
        {

            _dtMedicalRecords = clsMedicalRecord.GetAllMedicalRecords();
            dgvMedicalRecords.DataSource = _dtMedicalRecords;


            if(dgvMedicalRecords.Rows.Count>0)
            {

               dgvMedicalRecords.Columns[1].HeaderText = "Full Name";
                dgvMedicalRecords.Columns[1].Width = 140;

                dgvMedicalRecords.Columns[2].HeaderText = "Diagnosis";
               dgvMedicalRecords.Columns[2].Width = 129;

               dgvMedicalRecords.Columns[3].HeaderText = "Description";
                dgvMedicalRecords.Columns[3].Width = 129;

            }

        }

  


        private void btnAdd_Click(object sender, EventArgs e)
        {

            Form frm1 = new frmAddUpdateMedicalRecord();
            frm1.ShowDialog();
            frmListMedicalRecords_Load(null, null);

        }

        private void updateMedicalToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            int MedicalID = (int)dgvMedicalRecords.CurrentRow.Cells[0].Value;


            frmAddUpdateMedicalRecord frm1 = new frmAddUpdateMedicalRecord(MedicalID);
            frmListMedicalRecords_Load(null, null);
            frm1.ShowDialog();



        }

        private void deleteMedicalToolStripMenuItem_Click_1(object sender, EventArgs e)
        {


            int MedicalID = (int)dgvMedicalRecords.CurrentRow.Cells[0].Value;

            if (MessageBox.Show("are you sure you want to delete this medicalRecord ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;


            if (clsMedicalRecord.Delete(MedicalID))
            {
                MessageBox.Show("Medical Record Deleted Successfully :-)", "Success"
                    , MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmListMedicalRecords_Load(null, null);
            }
            else
            {
                MessageBox.Show("Medical Record did not Deleted  :-)", "Failed"
                                   , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}
