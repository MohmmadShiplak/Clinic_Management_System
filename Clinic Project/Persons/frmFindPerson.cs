﻿using System;
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
    public partial class frmFindPerson : Form
    {

        public delegate void DataBackEventHandler(object sender, int ?PersonID);

        public DataBackEventHandler Databack;



        public frmFindPerson()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Databack?.Invoke(this,ctrlPersonCardWithFilter1.PersonID);
        }

        private void ctrlPersonCardWithFilter1_Load(object sender, EventArgs e)
        {

        }
    }
}
