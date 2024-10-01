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
using System.IO;

namespace Clinic_Project
{
    public partial class ctrlPersonCard : UserControl
    {

        int _PersonID = -1;

        private  clsPerson _Person;

        public int PersonID
        {
            get { return _PersonID; }
        }



        public ctrlPersonCard()
        {
            InitializeComponent();
        }

        public void FillPersonsInfo()
        {

            lblPersonID.Text = _Person.PersonID.ToString();
            lblName.Text = _Person.Name.ToString  ();
            lblAddress.Text = _Person.Address.ToString();
            lblEmail.Text = _Person.Email.ToString();
            lblDateOfBirth.Text = _Person.DateOfBirth.ToString();
            lblGendor.Text = (_Person.Gendor == 0) ? "Male" : "Female";
            lblPhone.Text = _Person.Phone.ToString();
            LoadPersonImage();

        }
        public  void LoadPersonInfo(int PersonID)
        {


            _Person = clsPerson.Find(PersonID);


            if(_Person==null)
            {

                MessageBox.Show("There is No Persons with PersonID " + _PersonID.ToString(), "Error"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            FillPersonsInfo();
        }
        private void LoadPersonImage()
        {

            if (_Person.Gendor == 0)
                pbPersonImage.Image = Resources.Male_512;
            else
                pbPersonImage.Image = Resources.Female_512; ;


            string ImagePath = _Person.ImagePath;

            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    pbPersonImage.ImageLocation = ImagePath;
                else
                    MessageBox.Show("Could not Find this Image =" + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);










        }




    }
}
