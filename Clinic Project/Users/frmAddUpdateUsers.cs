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
using System.Xml.Serialization;

namespace Clinic_Project
{
    public partial class frmAddUpdateUsers : Form
    {

        public enum enMode { AddNew=0, UpdateNew=1 }
        public enMode _Mode;

        public clsUsers _User;

        public int ?_UserID=null;

        private int ?_SelectedPersonID = null;


        public frmAddUpdateUsers(int? UserID)
        {
            InitializeComponent();
            _UserID = UserID;

           
            
            _Mode = enMode.UpdateNew;
        }

        public frmAddUpdateUsers()
        {
            InitializeComponent();
           // _UserID = UserID;

            _Mode = enMode.AddNew;
        }
        private void FillCheckBoxPermissions()
        {

if(_User.Permissions==-1)
            {
                chkAdmin.Checked = true;

                return;
            }

foreach(var Item in gbPermissions.Controls)
            {

if(Item is CheckBox chk)
                {

                    if(chk.Tag.ToString()!="-1")
                    {

                        int TagValue =Convert.ToInt32(chk.Tag.ToString());

if((TagValue&_User.Permissions)==TagValue)
                        {
                            chkActiveUser.Checked = true;
                        }


                    }

                }


            }

        }
        private int CountPermissions()
        {

            int Permissions = 0;

            if (chkAdmin.Checked)
                return -1;

            if (chkAddUser.Checked)
                Permissions += (int)clsUsers.enPermissions.AddUser;

            if (chkUpdateUser.Checked)
                Permissions += (int)clsUsers.enPermissions.UpdateUser;

            if (chkDeleteUser.Checked)
                Permissions += (int)clsUsers.enPermissions.DeleteUser;

            if (chkListUsers.Checked)
                Permissions += (int)clsUsers.enPermissions.ListUsers;

            return Permissions;
        }

        private void _ResetDefualtValues ()
        {

if(_Mode == enMode.AddNew)
            { 
            
            _User = new clsUsers();

                return;
            }


            lblUserID.Text = "[???]";
            txtUsername.Text = "[???]";
            txtPassword.Text = "[???]";
            txtConfirmPassword.Text = "[???]";
            chkActiveUser.Checked = false ;

        }
        public void LoadData()
        {
            _ResetDefualtValues();

            ctrlPersonCardWithFilter1.FilterEnabled = false;

            _User = clsUsers.FindByUserID(_UserID);

            if(_User == null)
            {
            MessageBox.Show("No Users With UserID "+_UserID.ToString(),"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);  

                this.Close();

                return;
            
            }
            
            ctrlPersonCardWithFilter1.LoadPersonInfo(_User.PersonID);
            lblUserID.Text= _UserID.ToString();
            txtUsername.Text = _User.Username;
            txtPassword.Text = _User.Password;
            txtConfirmPassword.Text = _User.Password;
            chkActiveUser.Checked=_User.IsActive;
            FillCheckBoxPermissions();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            _User.PersonID = ctrlPersonCardWithFilter1.PersonID;
            _User.Username=txtUsername.Text;
            _User.Password = txtPassword.Text;
           _User.IsActive = chkActiveUser.Checked;
            _User.Permissions = CountPermissions();

            if (_Mode == enMode.AddNew)
            {
                _User.Password = clsGlobal.ComputeHash(txtPassword.Text);
            }

        
            if (_User.Save())
            {

                lblUserID.Text = _User.UserID.ToString();

                _Mode = enMode.UpdateNew;



                MessageBox.Show("Data Saved Successfully :-)", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {

                MessageBox.Show("Data Failed To Save (-:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }






        }

        private void frmAddUpdateUsers_Load(object sender, EventArgs e)
        {

            _ResetDefualtValues();


            if (_Mode == enMode.UpdateNew)
                LoadData();





        }

        private void ctrlPersonCardWithFilter1_OnePersonComplete(object sender, ctrlPersonCardWithFilter.clsPersonEventArg e)
        {

            if (!e.PersonID.HasValue)
            {


              //  tp.Enabled = false;
                //btnSave.Enabled = false;

                //return;

            }




            _SelectedPersonID = e.PersonID; 
            btnSave.Enabled = true;


        }
    }
}
