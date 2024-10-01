using Clinic_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Management;
using System.Windows.Forms;

namespace Clinic_Project
{
    public partial class ctrlPatientCardWithFilter : UserControl
    {


        public clsPatient SelectedPatinetInfo
        {
            get { return ctrlPatientCard1.SelectedPatientInfo; }
        }
        public class clsPatientSelectedEventArgs : EventArgs
        {

            public int? PatientID { get; set; }

            public clsPatientSelectedEventArgs(int? PatientID)
            {
                this.PatientID = PatientID;
            }
        }
        public event EventHandler<clsPatientSelectedEventArgs> OnePatientSelected;

        public void RaiseOnePatientSelected(int? PatientID)
        {
            RaiseOnePatientSelected(new clsPatientSelectedEventArgs(PatientID));
        }
        protected  void RaiseOnePatientSelected(clsPatientSelectedEventArgs e)
        {
            OnePatientSelected?.Invoke(this, e);
        }
        public int? PatientID
        {
            get { return ctrlPatientCard1.PatientID; }
        }

  
        public void LoadPatientInfoByPatinetID(int ?PatientID)
        {

            ctrlFilter1.TextSearch = PatientID.ToString();

            ctrlPatientCard1.LoadPatientInfoByPatientID(PatientID);

            if (OnePatientSelected != null)
                RaiseOnePatientSelected(ctrlPatientCard1?.PatientID);

        }
        public bool FilterEnabled
        {
            get => ctrlFilter1.FilterEnabled;
            set => ctrlFilter1.FilterEnabled = value;
        }






        public void Find()
        {

        //switch(cbFindBy.Text)
        //    {

        //        case "PersonID":
        //            ctrlPatientCard1.LoadPatientInfoByPersonID(int.Parse(txtSearch.Text));
        //            break;


        //        default:
        //            break;

        //    }

        //    if (OnePatientSelected != null&&FilterEnabeld)
        //        RaiseOnePatientSelected(ctrlPatientCard1.PersonID);


        }


        public void LoadPatinetsInfo(int? PatientID)
        {
            ctrlFilter1.TextSearch = PatientID.ToString();
            ctrlPatientCard1.LoadPatientInfoByPatientID(PatientID);

            if (OnePatientSelected != null)
                RaiseOnePatientSelected(ctrlPatientCard1?.PatientID);
        }






        public ctrlPatientCardWithFilter()
        {
            InitializeComponent();

            ctrlFilter1.ItemsInComboBox(new[] { ("Patient ID", true) });

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
        }

        private void InitializeComponent()
        {
            this.ctrlPatientCard1 = new Clinic_Project.ctrlPatientCard();
            this.ctrlFilter1 = new Clinic_Project.ctrlFilter();
            this.SuspendLayout();
            // 
            // ctrlPatientCard1
            // 
            this.ctrlPatientCard1.BackColor = System.Drawing.Color.White;
            this.ctrlPatientCard1.Location = new System.Drawing.Point(3, 117);
            this.ctrlPatientCard1.Name = "ctrlPatientCard1";
            this.ctrlPatientCard1.Size = new System.Drawing.Size(1434, 602);
            this.ctrlPatientCard1.TabIndex = 7;
            // 
            // ctrlFilter1
            // 
            this.ctrlFilter1.FilterEnabled = true;
            this.ctrlFilter1.Location = new System.Drawing.Point(0, 3);
            this.ctrlFilter1.Name = "ctrlFilter1";
            this.ctrlFilter1.ShowAddPersonButton = true;
            this.ctrlFilter1.Size = new System.Drawing.Size(1425, 120);
            this.ctrlFilter1.TabIndex = 8;
            this.ctrlFilter1.TextSearch = "";
            this.ctrlFilter1.OnFindNumericClick += new System.EventHandler<Clinic_Project.ctrlFilter.FindNumericClickEventArgs>(this.ctrlFilter1_OnFindNumericClick);
            // 
            // ctrlPatientCardWithFilter
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ctrlFilter1);
            this.Controls.Add(this.ctrlPatientCard1);
            this.Name = "ctrlPatientCardWithFilter";
            this.Size = new System.Drawing.Size(1440, 850);
            this.ResumeLayout(false);

        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {


            Find();








        }

        private void cbFindBy_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ctrlFilter1_OnFindNumericClick(object sender, ctrlFilter.FindNumericClickEventArgs e)
        {


           switch(e?.FieldName)
            {

                case "Patient ID":
                    LoadPatinetsInfo(e?.Value);
                    break;
            }






        }
    }
}
