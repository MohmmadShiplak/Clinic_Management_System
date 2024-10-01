namespace Clinic_Project
{
    partial class frmAddUpdateAppointment
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
            this.tcPatientInfo = new Guna.UI2.WinForms.Guna2TabControl();
            this.tpPatient = new System.Windows.Forms.TabPage();
            this.btnNext = new Guna.UI2.WinForms.Guna2Button();
            this.ctrlPatientCardWithFilter1 = new Clinic_Project.ctrlPatientCardWithFilter();
            this.tpDoctors = new System.Windows.Forms.TabPage();
            this.btnNext2 = new Guna.UI2.WinForms.Guna2Button();
            this.ctrlDoctorsCardWithFilter1 = new Clinic_Project.ctrlDoctorsCardWithFilter();
            this.tpAppointments = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.lblAppointment = new System.Windows.Forms.Label();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.tcPatientInfo.SuspendLayout();
            this.tpPatient.SuspendLayout();
            this.tpDoctors.SuspendLayout();
            this.tpAppointments.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcPatientInfo
            // 
            this.tcPatientInfo.Controls.Add(this.tpPatient);
            this.tcPatientInfo.Controls.Add(this.tpDoctors);
            this.tcPatientInfo.Controls.Add(this.tpAppointments);
            this.tcPatientInfo.ItemSize = new System.Drawing.Size(180, 40);
            this.tcPatientInfo.Location = new System.Drawing.Point(-1, 2);
            this.tcPatientInfo.Name = "tcPatientInfo";
            this.tcPatientInfo.SelectedIndex = 0;
            this.tcPatientInfo.Size = new System.Drawing.Size(1314, 784);
            this.tcPatientInfo.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.tcPatientInfo.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.tcPatientInfo.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tcPatientInfo.TabButtonHoverState.ForeColor = System.Drawing.Color.White;
            this.tcPatientInfo.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.tcPatientInfo.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this.tcPatientInfo.TabButtonIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.tcPatientInfo.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tcPatientInfo.TabButtonIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(160)))), ((int)(((byte)(167)))));
            this.tcPatientInfo.TabButtonIdleState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.tcPatientInfo.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
            this.tcPatientInfo.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.tcPatientInfo.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tcPatientInfo.TabButtonSelectedState.ForeColor = System.Drawing.Color.White;
            this.tcPatientInfo.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(132)))), ((int)(((byte)(255)))));
            this.tcPatientInfo.TabButtonSize = new System.Drawing.Size(180, 40);
            this.tcPatientInfo.TabIndex = 0;
            this.tcPatientInfo.TabMenuBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.tcPatientInfo.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop;
            // 
            // tpPatient
            // 
            this.tpPatient.Controls.Add(this.btnNext);
            this.tpPatient.Controls.Add(this.ctrlPatientCardWithFilter1);
            this.tpPatient.Location = new System.Drawing.Point(4, 44);
            this.tpPatient.Name = "tpPatient";
            this.tpPatient.Padding = new System.Windows.Forms.Padding(3);
            this.tpPatient.Size = new System.Drawing.Size(1306, 736);
            this.tpPatient.TabIndex = 1;
            this.tpPatient.Text = "Patients Info";
            this.tpPatient.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.BorderThickness = 1;
            this.btnNext.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNext.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNext.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNext.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnNext.FillColor = System.Drawing.Color.White;
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnNext.ForeColor = System.Drawing.Color.Black;
            this.btnNext.Location = new System.Drawing.Point(1126, 692);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(180, 44);
            this.btnNext.TabIndex = 21;
            this.btnNext.Text = "Next";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // ctrlPatientCardWithFilter1
            // 
            this.ctrlPatientCardWithFilter1.BackColor = System.Drawing.Color.White;
            this.ctrlPatientCardWithFilter1.FilterEnabled = true;
            this.ctrlPatientCardWithFilter1.Location = new System.Drawing.Point(-4, -11);
            this.ctrlPatientCardWithFilter1.Name = "ctrlPatientCardWithFilter1";
            this.ctrlPatientCardWithFilter1.Size = new System.Drawing.Size(1310, 822);
            this.ctrlPatientCardWithFilter1.TabIndex = 0;
            this.ctrlPatientCardWithFilter1.OnePatientSelected += new System.EventHandler<Clinic_Project.ctrlPatientCardWithFilter.clsPatientSelectedEventArgs>(this.ctrlPatientCardWithFilter1_OnePatientSelected_3);
            // 
            // tpDoctors
            // 
            this.tpDoctors.Controls.Add(this.btnNext2);
            this.tpDoctors.Controls.Add(this.ctrlDoctorsCardWithFilter1);
            this.tpDoctors.Location = new System.Drawing.Point(4, 44);
            this.tpDoctors.Name = "tpDoctors";
            this.tpDoctors.Padding = new System.Windows.Forms.Padding(3);
            this.tpDoctors.Size = new System.Drawing.Size(1306, 680);
            this.tpDoctors.TabIndex = 0;
            this.tpDoctors.Text = "Doctors Info ";
            this.tpDoctors.UseVisualStyleBackColor = true;
            // 
            // btnNext2
            // 
            this.btnNext2.BorderThickness = 1;
            this.btnNext2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNext2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNext2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNext2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnNext2.FillColor = System.Drawing.Color.White;
            this.btnNext2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnNext2.ForeColor = System.Drawing.Color.Black;
            this.btnNext2.Location = new System.Drawing.Point(1120, 660);
            this.btnNext2.Name = "btnNext2";
            this.btnNext2.Size = new System.Drawing.Size(180, 40);
            this.btnNext2.TabIndex = 21;
            this.btnNext2.Text = "Next";
            this.btnNext2.Click += new System.EventHandler(this.btnNext2_Click);
            // 
            // ctrlDoctorsCardWithFilter1
            // 
            this.ctrlDoctorsCardWithFilter1.BackColor = System.Drawing.Color.White;
          
            this.ctrlDoctorsCardWithFilter1.Location = new System.Drawing.Point(-8, 6);
            this.ctrlDoctorsCardWithFilter1.Name = "ctrlDoctorsCardWithFilter1";
            this.ctrlDoctorsCardWithFilter1.Size = new System.Drawing.Size(1314, 705);
            this.ctrlDoctorsCardWithFilter1.TabIndex = 0;
            // 
            // tpAppointments
            // 
            this.tpAppointments.Controls.Add(this.label1);
            this.tpAppointments.Controls.Add(this.label3);
            this.tpAppointments.Controls.Add(this.label2);
            this.tpAppointments.Controls.Add(this.cbStatus);
            this.tpAppointments.Controls.Add(this.dtpTime);
            this.tpAppointments.Controls.Add(this.lblAppointment);
            this.tpAppointments.Location = new System.Drawing.Point(4, 44);
            this.tpAppointments.Name = "tpAppointments";
            this.tpAppointments.Size = new System.Drawing.Size(1306, 680);
            this.tpAppointments.TabIndex = 2;
            this.tpAppointments.Text = "Appointments Info ";
            this.tpAppointments.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(59, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 25);
            this.label1.TabIndex = 38;
            this.label1.Text = "Appointment ID :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(134, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 25);
            this.label3.TabIndex = 37;
            this.label3.Text = "Status :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(37, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 25);
            this.label2.TabIndex = 36;
            this.label2.Text = "Appointment Time  :";
            // 
            // cbStatus
            // 
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Location = new System.Drawing.Point(240, 199);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(156, 24);
            this.cbStatus.TabIndex = 35;
            // 
            // dtpTime
            // 
            this.dtpTime.CustomFormat = "hh:mm:tt";
            this.dtpTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTime.Location = new System.Drawing.Point(240, 139);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.Size = new System.Drawing.Size(156, 28);
            this.dtpTime.TabIndex = 34;
            // 
            // lblAppointment
            // 
            this.lblAppointment.AutoSize = true;
            this.lblAppointment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppointment.Location = new System.Drawing.Point(235, 76);
            this.lblAppointment.Name = "lblAppointment";
            this.lblAppointment.Size = new System.Drawing.Size(45, 25);
            this.lblAppointment.TabIndex = 33;
            this.lblAppointment.Text = "???";
            // 
            // btnSave
            // 
            this.btnSave.BorderThickness = 1;
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSave.FillColor = System.Drawing.Color.White;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(1129, 792);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(180, 38);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_3);
            // 
            // frmAddUpdateAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1306, 833);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tcPatientInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddUpdateAppointment";
            this.Text = "frmAddUpdateAppointment";
            this.Load += new System.EventHandler(this.frmAddUpdateAppointment_Load);
            this.tcPatientInfo.ResumeLayout(false);
            this.tpPatient.ResumeLayout(false);
            this.tpDoctors.ResumeLayout(false);
            this.tpAppointments.ResumeLayout(false);
            this.tpAppointments.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TabControl tcPatientInfo;
        private System.Windows.Forms.TabPage tpPatient;
        private System.Windows.Forms.TabPage tpDoctors;
        private System.Windows.Forms.TabPage tpAppointments;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.DateTimePicker dtpTime;
        private System.Windows.Forms.Label lblAppointment;
        private ctrlDoctorsCardWithFilter ctrlDoctorsCardWithFilter1;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private ctrlPatientCardWithFilter ctrlPatientCardWithFilter1;
        private Guna.UI2.WinForms.Guna2Button btnNext;
        private Guna.UI2.WinForms.Guna2Button btnNext2;
    }
}