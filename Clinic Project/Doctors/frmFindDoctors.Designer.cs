namespace Clinic_Project
{
    partial class frmFindDoctors
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
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.ctrlDoctorsCardWithFilter1 = new Clinic_Project.ctrlDoctorsCardWithFilter();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.BorderThickness = 2;
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose.FillColor = System.Drawing.Color.White;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(1330, 765);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(180, 45);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ctrlDoctorsCardWithFilter1
            // 
            this.ctrlDoctorsCardWithFilter1.BackColor = System.Drawing.Color.White;
            this.ctrlDoctorsCardWithFilter1.FilterEnabled = true;
            this.ctrlDoctorsCardWithFilter1.Location = new System.Drawing.Point(-2, -4);
            this.ctrlDoctorsCardWithFilter1.Name = "ctrlDoctorsCardWithFilter1";
            this.ctrlDoctorsCardWithFilter1.Size = new System.Drawing.Size(1522, 763);
            this.ctrlDoctorsCardWithFilter1.TabIndex = 2;
            // 
            // frmFindDoctors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1543, 822);
            this.Controls.Add(this.ctrlDoctorsCardWithFilter1);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmFindDoctors";
            this.Text = "frmFindDoctors";
            this.Load += new System.EventHandler(this.frmFindDoctors_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private ctrlDoctorsCardWithFilter ctrlDoctorsCardWithFilter1;
    }
}