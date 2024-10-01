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
    public partial class frmListPayments : Form
    {


        private DataTable dtPayment;
        public frmListPayments()
        {
            InitializeComponent();
        }

        private void frmListPayments_Load(object sender, EventArgs e)
        {
            dtPayment = clsPayments.GetAllPayments();
            dgvPayments.DataSource = dtPayment;

            if (dgvPayments.Rows.Count > 0)
            {



                dgvPayments.Columns[0].HeaderText = "Patient ID";
                dgvPayments.Columns[0].Width = 120;

                dgvPayments.Columns[1].HeaderText = "Full Name";
                dgvPayments.Columns[1].Width = 150;

                dgvPayments.Columns[2].HeaderText = "DateOfBirth";
                dgvPayments.Columns[2].Width = 100;

                dgvPayments.Columns[3].HeaderText = "Amount Paid";
                dgvPayments.Columns[3].Width = 100;

                dgvPayments.Columns[4].HeaderText = "PaymentMethod";
                dgvPayments.Columns[4].Width = 100;
            }
        }

        private void updatePaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdatePayments frm1 = new frmAddUpdatePayments();
            frm1.ShowDialog();
            frmListPayments_Load(null, null);
        }

        private void updatePaymentToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            int PaymentID = (int)dgvPayments.CurrentRow.Cells[0].Value;

            frmAddUpdatePayments frm1 = new frmAddUpdatePayments(PaymentID);
            frm1.ShowDialog();
            frmListPayments_Load(null, null);
        }

        private void deletePaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int PaymentID = (int)dgvPayments.CurrentRow.Cells[0].Value;

            if(clsPayments.DeletePayment(PaymentID))
            {

                MessageBox.Show("Payment Deleted Successfully :-)", "Success"
                    , MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmListPayments_Load(null, null);
            }
            else
            {


                MessageBox.Show("Payment is not Deleted  ):-", "Failed"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
    }
}
