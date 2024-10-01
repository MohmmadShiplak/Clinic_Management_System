using Clinic_Business;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinic_Project
{
    public partial class frmChangePassword : Form
    {

        private int ?_UserID = null;


        private clsUsers _User;

        public frmChangePassword(int? UserID)
        {
            InitializeComponent();
            _UserID = UserID;   
        }

        private void _ResetDefualtValues()
        {

            _UserID = null;

            ctrlUserCard1._ResetDefualtValues();
            txtConfirmPassword.Text = "[???]";
            txtNewPassword.Text = "[???]";
            txtCurrentPassword.Text = "[???]";
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {

            if(!_UserID.HasValue)
            {

                MessageBox.Show("No Users With UserID ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                _ResetDefualtValues();

                return;

            }

            _User = clsUsers.FindByUserID(_UserID);

            if(_User==null)
            {

                MessageBox.Show("No Users With UserID ","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);

                _ResetDefualtValues();
                this.Close();

                return;

            }
            ctrlUserCard1.LoadUsersInfo(_UserID);
        }
        private void _ChangePassword()
        {

if(_User.ChangePassword(clsGlobal.ComputeHash(txtNewPassword.Text)))
            {
                MessageBox.Show("Password Changed Successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                _ResetDefualtValues();
            }
else
            {
                MessageBox.Show("An Error Occurred, Password did not change.",
                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void _TextBox_TextChanged(object sender,EventArgs e)
        {
            ((Guna2TextBox)sender).UseSystemPasswordChar = true;
        }






        private void btnSave_Click(object sender, EventArgs e)
        {


            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _ChangePassword();
     

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {

            if(txtConfirmPassword.Text.Trim()!=txtNewPassword.Text.Trim())
            {

                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Password Confirmation does not Match New Password");


            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword,null);
            }


        }





        private void gbFilter_Click(object sender, EventArgs e)
        {

        }

        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {


            //check password in database  that matched Currrent password
            if (_User.Password != clsGlobal.ComputeHash(txtCurrentPassword.Text))
            {

                e.Cancel = true;

                errorProvider1.SetError(txtCurrentPassword, "Current Password Wrong ");
                return;
            }
            else
            {
                errorProvider1.SetError(txtCurrentPassword, null);
            }



        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            string newPassword = txtNewPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(newPassword))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNewPassword, "The password field cannot be empty. Please enter a new password.");
                return;
            }
            else
            {
                errorProvider1.SetError(txtNewPassword, null);
            }

            //if (clsGlobal.ComputeHash(newPassword) == _User.Password)
            //{
            //    e.Cancel = true;
            //    errorProvider1.SetError(txtNewPassword, "This password is the same as your current one. Please choose a different password.");
            //}
            //else
            //{
            //    errorProvider1.SetError(txtNewPassword, null);
            //}
        }
    }
}
