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
    public partial class ctrlPersonCardWithFilter : UserControl
    {

        public class clsPersonEventArg : EventArgs
        {

            public int PersonID { get; }


            public clsPersonEventArg(int PersonID)
            {
                this.PersonID = PersonID;
            }

        }
        public event EventHandler<clsPersonEventArg> OnePersonComplete;

        public void RaiseOnePersonsCompleted(int PersonID)
        {
            RaiseOnePersonsCompleted(new clsPersonEventArg(PersonID));
        }
        protected virtual void RaiseOnePersonsCompleted(clsPersonEventArg e)
        {
            OnePersonComplete?.Invoke(this, e);
        }




        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
        }

        private bool _FilterEnabled = true;

        public bool FilterEnabled
        {

            get
            {
                return _FilterEnabled;
            }
            set
            {

                _FilterEnabled = value;
                gpFilter.Enabled = _FilterEnabled;

            }
        }
        
           private int _PersonID = -1;

        public int  PersonID
            {

            get { return ctrlPersonCard1.PersonID; }
            }
        private void Find()
        {

            switch(cbFilterBy.Text)
            {

                case "Person ID":
  ctrlPersonCard1.LoadPersonInfo(int.Parse(txtFilterValue.Text));
                    break;

                default:
                    break;
            }

            if (OnePersonComplete != null && FilterEnabled)
                RaiseOnePersonsCompleted(ctrlPersonCard1.PersonID);





        }

        private void btnFind_Click(object sender, EventArgs e)
        {

            if(!this.ValidateChildren())
            {

                MessageBox.Show("Some Fileds are not valide put the mouse over the red Icon(s) to see the Error "
                    , "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Find();
        }

        private void ctrlPersonCardWithFilter_Load(object sender, EventArgs e)
        {
            txtFilterValue.Focus();
            cbFilterBy.SelectedIndex = 0;
        }
        private void DataBackEvent(object sender,int PersonID)
        {

            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Text = PersonID.ToString();
            ctrlPersonCard1.LoadPersonInfo(PersonID);



        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {

            frmAddUpdatePersons frm1 = new frmAddUpdatePersons();
            frm1.DataBack += DataBackEvent;
            frm1.ShowDialog();




        }
    }
}
