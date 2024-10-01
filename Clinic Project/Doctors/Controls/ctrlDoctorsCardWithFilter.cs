using Clinic_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinic_Project
{
    public partial class ctrlDoctorsCardWithFilter : UserControl
    {

       public class clsDoctorsSelectedEventArgs:EventArgs
        {

public int ?DoctorID { get; set; }

            public clsDoctorsSelectedEventArgs(int ?DoctorID)
            {
                this.DoctorID = DoctorID;
            }
        }
        public    EventHandler<clsDoctorsSelectedEventArgs> OneDoctorSelected;

        public void RaiseOneDoctorSelected(int ?DoctorID)
        {
            RaiseOneDoctorSelected(new clsDoctorsSelectedEventArgs(DoctorID));
        }
        protected void RaiseOneDoctorSelected (clsDoctorsSelectedEventArgs e)
        {
            OneDoctorSelected?.Invoke(this, e);
        }



        public clsDoctor _Doctor;

        public int ?DoctorID
        {
            get { return ctrlDoctorsCard2.DoctorID; }
        }

        private bool  _FilterEnabeld = true;

        //          public bool FilterEnabeld
        //        {

        //get
        //            {
        //               return _FilterEnabeld;
        //            }
        //            set
        //            {

        //    _FilterEnabeld=value;
        //                gbFilter.Enabled = _FilterEnabeld;
        //            }


        //        }

        public bool FilterEnabled
        {
            get => ctrlFilter1.FilterEnabled;
            set => ctrlFilter1.FilterEnabled = value;
        }





        public void LoadDoctorsInfoByDoctorID(int ?DoctorID)
        {

        ctrlFilter1.TextSearch = DoctorID.ToString();
           ctrlDoctorsCard2.LoadDoctorsInfoByDoctorID(DoctorID);




            if (OneDoctorSelected != null )
                RaiseOneDoctorSelected(ctrlDoctorsCard2?.DoctorID);


        }
        public void LoadDoctorsInfoByPersonID(int PersonID)
        {

            ctrlFilter1.TextSearch = PersonID.ToString();
            ctrlDoctorsCard2.LoadDoctorsInfoByPersonID(PersonID);

            if (OneDoctorSelected != null )
                RaiseOneDoctorSelected(ctrlDoctorsCard2.DoctorID);


        }

        public ctrlDoctorsCardWithFilter()
        {
            InitializeComponent();
            ctrlFilter1.ItemsInComboBox(new[] { ("DoctorID", true) });



        }

        //public void FindNow()
        //{

        //    switch (cbFindBy.Text)
        //    {



        //        case "DoctorID":
        //            ctrlDoctorsCard2.LoadDoctorsInfoByDoctorID(int.Parse(txtSearch.Text));
        //            break;


        //            case "PersonID":
        //            ctrlDoctorsCard2.LoadDoctorsInfoByPersonID(int.Parse(txtSearch.Text));
        //            break;



        //        default:
        //            break;

        //    }

        //    if (OneDoctorSelected != null && FilterEnabeld)
        //        RaiseOneDoctorSelected(ctrlDoctorsCard2.DoctorID);

        //}




        private void btnFind_Click(object sender, EventArgs e)
        {
           
        }

        private void ctrlDoctorsCardWithFilter_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
           
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            this.ctrlFilter1 = new Clinic_Project.ctrlFilter();
            this.ctrlDoctorsCard2 = new Clinic_Project.ctrlDoctorsCard();
            this.SuspendLayout();
            // 
            // ctrlFilter1
            // 
            this.ctrlFilter1.FilterEnabled = true;
            this.ctrlFilter1.Location = new System.Drawing.Point(0, 0);
            this.ctrlFilter1.Name = "ctrlFilter1";
            this.ctrlFilter1.ShowAddPersonButton = true;
            this.ctrlFilter1.Size = new System.Drawing.Size(1285, 109);
            this.ctrlFilter1.TabIndex = 148;
            this.ctrlFilter1.TextSearch = "";
            this.ctrlFilter1.OnFindNumericClick += new System.EventHandler<Clinic_Project.ctrlFilter.FindNumericClickEventArgs>(this.ctrlFilter1_OnFindNumericClick);
            // 
            // ctrlDoctorsCard2
            // 
            this.ctrlDoctorsCard2.BackColor = System.Drawing.Color.White;
            this.ctrlDoctorsCard2.Location = new System.Drawing.Point(0, 106);
            this.ctrlDoctorsCard2.Name = "ctrlDoctorsCard2";
            this.ctrlDoctorsCard2.Size = new System.Drawing.Size(1282, 542);
            this.ctrlDoctorsCard2.TabIndex = 8;
            // 
            // ctrlDoctorsCardWithFilter
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ctrlFilter1);
            this.Controls.Add(this.ctrlDoctorsCard2);
            this.Name = "ctrlDoctorsCardWithFilter";
            this.Size = new System.Drawing.Size(1285, 648);
            this.ResumeLayout(false);

        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
           
        }

        private void btnSearch_Click_2(object sender, EventArgs e)
        {
           
        }

        private void ctrlFilter1_OnFindNumericClick(object sender, ctrlFilter.FindNumericClickEventArgs e)
        {
            switch (e?.FieldName)
            {

                case "DoctorID":
                    LoadDoctorsInfoByDoctorID(e?.Value);
                    break;
            }


        }
    }
}
