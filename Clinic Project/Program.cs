﻿using Clinic_Project.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Clinic_Project
{
    internal class Program
    {
        [STAThread]

        static void Main(string[] args)
       
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new frmMain());
            // Application.Run(new frmTest2());
            Application.Run(new  frmLogin());

        }
    }
}
