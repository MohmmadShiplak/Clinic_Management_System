namespace Clinic_Project
{
    partial class frmShowDoctorsInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ctrlDoctorsCard1 = new Clinic_Project.ctrlDoctorsCard();
            this.SuspendLayout();
            // 
            // ctrlDoctorsCard1
            // 
            this.ctrlDoctorsCard1.BackColor = System.Drawing.Color.White;
            this.ctrlDoctorsCard1.Location = new System.Drawing.Point(1, 0);
            this.ctrlDoctorsCard1.Name = "ctrlDoctorsCard1";
            this.ctrlDoctorsCard1.Size = new System.Drawing.Size(1759, 766);
            this.ctrlDoctorsCard1.TabIndex = 0;
            // 
            // frmShowDoctorsInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1772, 547);
            this.Controls.Add(this.ctrlDoctorsCard1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmShowDoctorsInfo";
            this.Text = "frmShowDoctorsInfo";
            this.Load += new System.EventHandler(this.frmShowDoctorsInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlDoctorsCard ctrlDoctorsCard1;
    }
}