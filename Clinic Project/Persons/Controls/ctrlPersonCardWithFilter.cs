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
    public partial class ctrlPersonCardWithFilter : UserControl
    {

        public class clsPersonEventArg : EventArgs
        {

            public int ?PersonID { get; }


            public clsPersonEventArg(int ?PersonID)
            {
                this.PersonID = PersonID;
            }

        }
        public event EventHandler<clsPersonEventArg> OnePersonComplete;

        public void RaiseOnePersonsCompleted(int ?PersonID)
        {
            RaiseOnePersonsCompleted(new clsPersonEventArg(PersonID));
        }
        protected virtual void RaiseOnePersonsCompleted(clsPersonEventArg e)
        {
            OnePersonComplete?.Invoke(this, e);
        }

        public clsPerson SelectedPersonInfo => ctrlPersonCard1.SelectedPersonInfo;








        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();

            ctrlFilter1.ItemsInComboBox(new[] { ("Person ID", true) });

        }

        public bool FilterEnabled
        {
            get => ctrlFilter1.FilterEnabled;
            set => ctrlFilter1.FilterEnabled = value;
        }







        private int _PersonID = -1;

        public int  ?PersonID
            {

            get { return ctrlPersonCard1._PersonID; }
            }
        private void Find()
        {

  //          switch(cbFilterBy.Text)
  //          {

  //              case "Person ID":
  //ctrlPersonCard1.LoadPersonInfo(int.Parse(txtFilterValue.Text));
  //                  break;

  //              default:
  //                  break;
  //          }

            //if (OnePersonComplete != null && FilterEnabled)
            //    RaiseOnePersonsCompleted(ctrlPersonCard1?.PersonID);


        }
       public void LoadDataByPersonID(int ?PersonID)
        {


            //cbFilterBy.SelectedIndex = 0;
            //txtFilterValue.Text = PersonID.ToString();
            //Find();

        }






        private void btnFind_Click(object sender, EventArgs e)
        {

            if(!this.ValidateChildren())
            {

                MessageBox.Show("Some Fileds are not valide put the mouse over the red Icon(s) to see the Error "
                    , "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //switch (txtFilterValue.Text)
            //{
            //    case "Person ID":
            //        LoadPersonInfo();
            //        break;
            //}





            // Find();
        }

        private void ctrlPersonCardWithFilter_Load(object sender, EventArgs e)
        {
        //    txtFilterValue.Focus();
        //    cbFilterBy.SelectedIndex = 0;
        }
        //Subscribe With The Event 
        private void DataBackEvent(object sender,int ?PersonID)
        {

     

        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {

            frmAddUpdatePersons frm1 = new frmAddUpdatePersons();
            frm1.PersonIDDataBack += LoadPersonInfo;
            frm1.ShowDialog();




        }
        public void LoadPersonInfo(int? personID)
        {
         ctrlFilter1.TextSearch= personID.ToString();
            ctrlPersonCard1.LoadPersonInfo(personID);

            if (OnePersonComplete != null)
                RaiseOnePersonsCompleted(ctrlPersonCard1?.PersonID);
        }

        private void ctrlFilter1_OnFindNumericClick(object sender, ctrlFilter.FindNumericClickEventArgs e)
        {

            switch(e?.FieldName)
            {


                case "Person ID":
                    LoadPersonInfo(e?.Value);
                    break;

            }

        }

        private void ctrlFilter1_OnAddClick(object sender, EventArgs e)
        {


            frmAddUpdatePersons frm1 = new frmAddUpdatePersons();
            frm1.PersonIDDataBack += LoadPersonInfo;
            frm1.ShowDialog();  


        }
    }
}
