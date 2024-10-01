using Clinic_Business;
using Clinic_Project.Properties;
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
    public partial class frmAddUpdatePersons : Form
    {
        //this 
        //public delegate void DataBackEventHandler(object sender, int? PersonID);

        //public event DataBackEventHandler DataBack;


        //Or  this 

        public Action<int?> PersonIDDataBack;





        public enum enMode { AddNew=0,UpdateNew=1};

        public enMode _Mode = enMode.UpdateNew;

        public enum enGendor { Male = 0, Female =1};

        public clsPerson _Person;

        public int ?_PersonID = null;

        public frmAddUpdatePersons(int PersonID )
        {
            InitializeComponent();

            _PersonID = PersonID;

            _Mode = enMode.UpdateNew;
        }
        public frmAddUpdatePersons()
        {
            InitializeComponent();

            _Mode = enMode.AddNew;

        }

        private void ResetDefualtValues()
        {



            if(_Mode==enMode.AddNew)
            {

                _Person = new clsPerson();

                lblTitle.Text = "Add New People ";

                return;

            }
            else
            {

                lblTitle.Text = "Update People ";
                  
            }


            if (rbMale.Checked)
                pbPersonImage.Image = Resources.Male_512;
            else
                pbPersonImage.Image = Resources.Female_512;



            txtFirstName.Text = "";
            txtSecondName.Text = "";
            txtThirdName.Text = "";
            txtLastName.Text = "";
            //txtEmail.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            rbMale.Checked = true;
        }

        public void LoadData()
        {



            _Person = clsPerson.Find(_PersonID);


            if (_Person==null)
            {

                MessageBox.Show("No Persons with PersonID " + _PersonID.ToString(), "Error"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);

                return ;

            }


      

            lblPersonID.Text = _PersonID.ToString();
            txtFirstName.Text = _Person.FirstName;
            txtSecondName.Text = _Person.SecondName;
            txtThirdName.Text = _Person.ThirdName;
            txtLastName.Text = _Person.LastName;
            txtEmail.Text = _Person.Email;
            txtPhone.Text = _Person.Phone;
            txtAddress.Text = _Person.Address;

            if (_Person.Gendor == 0)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;

            dtpDateOfBirth.Value = _Person.DateOfBirth;


            if(_Person.ImagePath!="")
            {
                pbPersonImage.ImageLocation = _Person.ImagePath;
            }



         
        }















        private void frmAddUpdatePersons_Load(object sender, EventArgs e)
        {

            ResetDefualtValues();


            if(_Mode==enMode.UpdateNew)
            LoadData();


        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            _Person.FirstName = txtFirstName.Text;
            _Person.SecondName = txtSecondName.Text;
            _Person.ThirdName = txtThirdName.Text;
            _Person.LastName = txtLastName.Text;
            _Person.Email = txtEmail.Text;
            _Person.Address = txtAddress.Text;
            _Person.DateOfBirth = dtpDateOfBirth.Value;
            _Person.Phone = txtPhone.Text;

            if (rbMale.Checked)
                _Person.Gendor = (short)enGendor.Male;
            else
                _Person.Gendor = (short)enGendor.Female;


            if (pbPersonImage.ImageLocation != null)
                _Person.ImagePath = pbPersonImage.ImageLocation;
            else
                _Person.ImagePath = "";

            if(_Person.Save())
            {

                lblPersonID.Text = _Person.PersonID.ToString();

                MessageBox.Show("Data Saved Successfully :-)", "Saved"
                    , MessageBoxButtons.OK, MessageBoxIcon.Information);

                PersonIDDataBack?.Invoke( _Person.PersonID);


                _Mode = enMode.UpdateNew;

            }
            else
            {

                MessageBox.Show("Data is not Saved  (:-", "Error"
                               , MessageBoxButtons.OK, MessageBoxIcon.Error);



            }




        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbPersonImage.ImageLocation == null)
                pbPersonImage.Image = Resources.Male_512;
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {

            if (pbPersonImage.ImageLocation == null)
                pbPersonImage.Image = Resources.Female_512;


        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {

            //if(string.IsNullOrEmpty(txtFirstName.Text))
            //{

            //    e.Cancel = false;


            //    errorProvider1.SetError(txtFirstName, "this Field is Required ");

            //    return;
            //}
            //else
            //{
            //    errorProvider1.SetError(txtFirstName, null);
            //}
            //if(txtFirstName.Text!=_Person.FullName() && clsPerson.IsPersonExist(txtFirstName.Text.Trim()))
            //{

            //    e.Cancel = false;
            //    errorProvider1.SetError(txtFirstName, "Name is Used for Onther Person ");

            //}
            //else
            //{
            //    errorProvider1.SetError(txtFirstName, null);
            //}



        }

        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            openFileDialog1.Filter = "Image Files |*.jpg;*.jpeg;*.png*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {

                string SelectedFilePath = openFileDialog1.FileName;
                pbPersonImage.Load(SelectedFilePath);

                llRemoveImage.Visible = true;

            }








        }

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            pbPersonImage.ImageLocation = null;

            if (rbMale.Checked)
                pbPersonImage.Image = Resources.Male_512;
            else
                pbPersonImage.Image = Resources.Female_512;



            llRemoveImage.Visible = true;
                  







        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {

    




        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
