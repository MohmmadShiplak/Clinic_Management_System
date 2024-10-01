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
    public partial class ctrlUserCard : UserControl
    {

        private int? _UserID = null;

        private clsUsers _User = null;
       
        public ctrlUserCard()
        {
            InitializeComponent();
        }

        public  void _ResetDefualtValues()
        {
            _UserID = null;

            ctrlPersonCard1.ResetDefualtValues();

            lblUserID.Text = "[???]";
            lblIsActive.Text = "[???]";
            lblUserName.Text = "[???]";
               
        }
        public void LoadUsersInfo(int ?UserID)
        {

            _UserID=UserID;

            if(!_UserID.HasValue)
            {


               MessageBox.Show("No Users With UserID "+_UserID.ToString(),"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);


                _ResetDefualtValues();

                return;


            }

            _User=clsUsers.FindByUserID(_UserID);


            if(_User == null)
            {

                MessageBox.Show("No Users With UserID " + _UserID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


                _ResetDefualtValues();

                return;

            }

            FillUsersInfo();
        }

        public void FillUsersInfo()
        {


            ctrlPersonCard1.LoadPersonInfo(_User.PersonID);
            lblUserID.Text = _User.UserID.ToString();
            lblIsActive.Text=_User.IsActive.ToString();
            lblUserName.Text = _User.Username;

        }











    }
}
