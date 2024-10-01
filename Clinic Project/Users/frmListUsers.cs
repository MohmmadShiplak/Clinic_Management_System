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
    public partial class frmListUsers : Form
    {

        private DataTable _dtAllUsers;

        public frmListUsers()
        {
            InitializeComponent();
        }

        private void frmListUsers_Load(object sender, EventArgs e)
        {

            _dtAllUsers = clsUsers.GetAllUsers();
            dgvUsers.DataSource = _dtAllUsers;



            dgvUsers.Columns[0].HeaderText = "User ID";
            dgvUsers.Columns[0].Width = 150;
             

            dgvUsers.Columns[1].HeaderText = "Full Name";
            dgvUsers.Columns[1].Width = 150;

            dgvUsers.Columns[2].HeaderText = "User Name";
            dgvUsers.Columns[2].Width = 150;

            dgvUsers.Columns[3].HeaderText = "Gender";
            dgvUsers.Columns[3].Width = 120;

            dgvUsers.Columns[4].HeaderText = "Is Active";
            dgvUsers.Columns[4].Width = 70;


        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form frm1 = new frmAddUpdateUsers();
            frmListUsers_Load(null, null);
            frm1.ShowDialog();
           

        }

        private void updateUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID=(int)dgvUsers.CurrentRow.Cells[0].Value;

            Form frm1 = new frmAddUpdateUsers(UserID);
            frmListUsers_Load(null, null);
            frm1.ShowDialog();

        }

        private void showUsersInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvUsers.CurrentRow.Cells[0].Value;

            frmShowUsersInfo frm1=new frmShowUsersInfo(UserID);

           frm1.ShowDialog();

        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int  UserID = (int)dgvUsers.CurrentRow.Cells[0].Value;

            frmChangePassword frm1=new frmChangePassword(UserID);
            frm1.ShowDialog();

        }

        private void deleteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int UserID = (int)dgvUsers.CurrentRow.Cells[0].Value;


            if(clsUsers.DeleteUser(UserID))
            {

                MessageBox.Show("Users Deleted Successfully :-)","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                frmListUsers_Load(null, null);
                return; 

            }
            else
            {
                MessageBox.Show("User is not Deleted due data to Connect it ","Failed",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }










        }

        private void guna2ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
