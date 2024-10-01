using Clinic_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinic_Project
{
    public partial class frmListDoctors : Form
    {

        private DataTable _dtDoctors;



        public frmListDoctors()
        {
            InitializeComponent();
        }

        private void frmListDoctors_Load(object sender, EventArgs e)
        {

            _dtDoctors = clsDoctor.GetAllDoctors();
           dgvDoctors.DataSource = _dtDoctors;  




        }

        private void showDoctorsInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {

         int DoctorID = (int)dgvDoctors.CurrentRow.Cells[0].Value;  

            frmShowDoctorsInfo frm1=new frmShowDoctorsInfo(DoctorID);
            frm1.ShowDialog();







        }

        private void updateDoctorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int DoctorID = (int)dgvDoctors.CurrentRow.Cells[0].Value;


            frmAddUpdateDoctors frm1=new frmAddUpdateDoctors(DoctorID);
            frm1.ShowDialog();
            frmListDoctors_Load(null, null);





        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            frmAddUpdateDoctors frm1 = new frmAddUpdateDoctors();
            frm1.ShowDialog();
            frmListDoctors_Load(null, null);



        }

        private void deleteDoctorsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int DoctorID =(int)dgvDoctors.CurrentRow.Cells [0].Value;

            if (clsDoctor.DeleteDoctor(DoctorID))
            {

                MessageBox.Show("Doctor Deleted Successfully :-)", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmListDoctors_Load(null, null);

                return;

            }
            else
            {

                MessageBox.Show("Doctor Failed to delete ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }



        }
    }
}
