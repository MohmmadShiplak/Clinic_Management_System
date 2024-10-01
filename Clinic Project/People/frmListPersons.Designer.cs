namespace Clinic_Project
{
    partial class frmListPersons
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
            this.components = new System.ComponentModel.Container();
            this.dgvPersons = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.personsInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewPersonsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updatePersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deletePersonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersons)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPersons
            // 
            this.dgvPersons.AllowUserToAddRows = false;
            this.dgvPersons.AllowUserToDeleteRows = false;
            this.dgvPersons.AllowUserToOrderColumns = true;
            this.dgvPersons.BackgroundColor = System.Drawing.Color.White;
            this.dgvPersons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersons.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvPersons.GridColor = System.Drawing.Color.White;
            this.dgvPersons.Location = new System.Drawing.Point(-1, 242);
            this.dgvPersons.Name = "dgvPersons";
            this.dgvPersons.ReadOnly = true;
            this.dgvPersons.RowHeadersWidth = 51;
            this.dgvPersons.RowTemplate.Height = 24;
            this.dgvPersons.Size = new System.Drawing.Size(1471, 498);
            this.dgvPersons.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.personsInfoToolStripMenuItem,
            this.addNewPersonsToolStripMenuItem,
            this.updatePersToolStripMenuItem,
            this.deletePersonToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(211, 128);
            // 
            // personsInfoToolStripMenuItem
            // 
            this.personsInfoToolStripMenuItem.Name = "personsInfoToolStripMenuItem";
            this.personsInfoToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.personsInfoToolStripMenuItem.Text = "Persons Info";
            this.personsInfoToolStripMenuItem.Click += new System.EventHandler(this.personsInfoToolStripMenuItem_Click);
            // 
            // addNewPersonsToolStripMenuItem
            // 
            this.addNewPersonsToolStripMenuItem.Name = "addNewPersonsToolStripMenuItem";
            this.addNewPersonsToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.addNewPersonsToolStripMenuItem.Text = "Add New Person";
            this.addNewPersonsToolStripMenuItem.Click += new System.EventHandler(this.addNewPersonsToolStripMenuItem_Click);
            // 
            // updatePersToolStripMenuItem
            // 
            this.updatePersToolStripMenuItem.Name = "updatePersToolStripMenuItem";
            this.updatePersToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.updatePersToolStripMenuItem.Text = "Update Person";
            this.updatePersToolStripMenuItem.Click += new System.EventHandler(this.updatePersToolStripMenuItem_Click);
            // 
            // deletePersonToolStripMenuItem
            // 
            this.deletePersonToolStripMenuItem.Name = "deletePersonToolStripMenuItem";
            this.deletePersonToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.deletePersonToolStripMenuItem.Text = "Delete Person";
            this.deletePersonToolStripMenuItem.Click += new System.EventHandler(this.deletePersonToolStripMenuItem_Click);
            // 
            // frmListPersons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1472, 741);
            this.Controls.Add(this.dgvPersons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmListPersons";
            this.Text = "List Persons";
            this.Load += new System.EventHandler(this.frmListPersons_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersons)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPersons;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem personsInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewPersonsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updatePersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deletePersonToolStripMenuItem;
    }
}