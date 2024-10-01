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
    public partial class frmListAppointments : Form
    {

        private DataTable _dtAppointments;

        public frmListAppointments()
        {
            InitializeComponent();
        }

        private void frmListAppointments_Load(object sender, EventArgs e)
        {

            _dtAppointments = clsAppointments.GetAllApoointments();
            dgvAppointments.DataSource = _dtAppointments;


            if(dgvAppointments.Rows.Count>0)
            {
                dgvAppointments.Columns[1].HeaderText = "Full Name";
                dgvAppointments.Columns[1].Width = 140;

                dgvAppointments.Columns[2].HeaderText = "Sick Name";
                dgvAppointments.Columns[2].Width = 129;

                dgvAppointments.Columns[3].HeaderText = "Time";
                dgvAppointments.Columns[3].Width = 129;

            }




        }

        private void updateAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int AppointmentID = (int)dgvAppointments.CurrentRow.Cells[0].Value;


            frmAddUpdateAppointment frm1 = new frmAddUpdateAppointment(AppointmentID);
            frmListAppointments_Load(null,null);
            frm1.ShowDialog();

        }

        private void deleteAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int AppointmentID = (int)dgvAppointments.CurrentRow.Cells[0].Value;


            if(clsAppointments.DeleteAppointment(AppointmentID))
            {

                MessageBox.Show("Appointment Deleted Sucessfully :-)", "Sucess"
                    , MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmListAppointments_Load(null, null);
            }
            else
            {

                MessageBox.Show("Appointment is not Deleted )-:", "Failed "
                 , MessageBoxButtons.OK, MessageBoxIcon.Error);


            }





        }

        private void btnAddAppointments_Click(object sender, EventArgs e)
        {

            frmAddUpdateAppointment frm1 = new frmAddUpdateAppointment();
            frm1.ShowDialog();
            frmListAppointments_Load(null, null);




        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmSendEmails frm1 = new frmSendEmails();
            frm1.ShowDialog();

          




        }
    }
}
