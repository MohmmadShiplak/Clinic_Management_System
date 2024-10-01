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
    public partial class frmListPersons : Form
    {

        private DataTable _dtPersons;

        public frmListPersons()
        {
            InitializeComponent();
        }

        private void frmListPersons_Load(object sender, EventArgs e)
        {
            _dtPersons = clsPerson.GetAllPeople();
            dgvPersons.DataSource = _dtPersons;

            if(dgvPersons.Rows.Count>0)
            {

                dgvPersons.Columns[5].HeaderText = "Email";
                dgvPersons.Columns[5].Width = 170;

                dgvPersons.Columns[7].HeaderText = "Image Path";
                dgvPersons.Columns[7].Width = 170;

                dgvPersons.Columns[2].HeaderText = "DateOfBirth";
                dgvPersons.Columns[2].Width = 70;




            }







        }

        private void deletePersonToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int PersonID = (int)dgvPersons.CurrentRow.Cells[0].Value;

            if(clsPerson.DeletePerson(PersonID))
            {

                MessageBox.Show("Person Deleted Successfully :-)", "Success"
                    , MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmListPersons_Load(null, null);
            }
            else
            {
                MessageBox.Show("Person is not Deleted  (:-", "Failed "
                                , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }

        private void personsInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int PersonID = (int)dgvPersons.CurrentRow.Cells[0].Value;

            frmShowPersonInfo frm1 = new frmShowPersonInfo(PersonID);
            frm1.ShowDialog();


        }

        private void addNewPersonsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmAddUpdatePersons frm1 = new frmAddUpdatePersons();
            frm1.ShowDialog();






        }

        private void updatePersToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int PersonID = (int)dgvPersons.CurrentRow.Cells[0].Value;

            frmAddUpdatePersons frm1 = new frmAddUpdatePersons(PersonID);
            frm1.ShowDialog();










        }
    }
}
