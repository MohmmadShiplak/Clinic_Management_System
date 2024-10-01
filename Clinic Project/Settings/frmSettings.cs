using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace Clinic_Project
{
    public partial class frmSettings : Form
    {
        frmLogin  _frmLogin;

        public frmSettings()
        {
            InitializeComponent();
             
        }


       private void ShowClinicInfoFromConfig()
        {

            lblOpeningTime.Text = ConfigurationManager.AppSettings["ClinicOpeningTime"] ?? "N/A";
            lblClosingTime.Text = ConfigurationManager.AppSettings["ClinicClosingTime"] ?? "N/A";
            lblWorkingDays.Text = ConfigurationManager.AppSettings["Working Days"] ?? "N/A";
            lblholidays.Text = ConfigurationManager.AppSettings["holidays"] ?? "N/A";
               
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            ShowClinicInfoFromConfig();


        }

        private void guna2ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmShowUsersInfo frm1 = new frmShowUsersInfo(clsGlobal.CurrentUser.UserID);
            frm1.ShowDialog();

        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmChangePassword frm1=new frmChangePassword(clsGlobal.CurrentUser.UserID);
            frm1.ShowDialog();  

        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {

            clsGlobal.CurrentUser = null;
            _frmLogin.Show();
            this.Close();
        }
    }
}
