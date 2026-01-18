namespace ClinicManager_PresentationLayer
{
    partial class ucSideBar
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.uCtrlDashBtnMedicalRecords = new ClinicManager_PresentationLayer.ucDashboardButton();
            this.uCtrlDashBtnPayments = new ClinicManager_PresentationLayer.ucDashboardButton();
            this.uCtrlDashBtnAppointments = new ClinicManager_PresentationLayer.ucDashboardButton();
            this.uCtrlDashBtnDoctors = new ClinicManager_PresentationLayer.ucDashboardButton();
            this.uCtrlDashBtnPatients = new ClinicManager_PresentationLayer.ucDashboardButton();
            this.uCtrlDashBtnMain = new ClinicManager_PresentationLayer.ucDashboardButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pbLogo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5, 5, 0, 5);
            this.panel1.Size = new System.Drawing.Size(277, 177);
            this.panel1.TabIndex = 15;
            // 
            // pbLogo
            // 
            this.pbLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbLogo.Image = global::ClinicManager_PresentationLayer.Properties.Resources.download__5_;
            this.pbLogo.Location = new System.Drawing.Point(5, 5);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(272, 167);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // uCtrlDashBtnMedicalRecords
            // 
            this.uCtrlDashBtnMedicalRecords.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(65)))));
            this.uCtrlDashBtnMedicalRecords.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uCtrlDashBtnMedicalRecords.Dock = System.Windows.Forms.DockStyle.Top;
            this.uCtrlDashBtnMedicalRecords.Location = new System.Drawing.Point(0, 447);
            this.uCtrlDashBtnMedicalRecords.Margin = new System.Windows.Forms.Padding(4);
            this.uCtrlDashBtnMedicalRecords.Name = "uCtrlDashBtnMedicalRecords";
            this.uCtrlDashBtnMedicalRecords.Padding = new System.Windows.Forms.Padding(5, 5, 0, 5);
            this.uCtrlDashBtnMedicalRecords.Size = new System.Drawing.Size(277, 54);
            this.uCtrlDashBtnMedicalRecords.TabIndex = 21;
            this.uCtrlDashBtnMedicalRecords.Tag = "Medical Records Screen";
            this.uCtrlDashBtnMedicalRecords.DashboardButtonHovered += new System.Action<object>(this.DashboardButton_MouseHover);
            this.uCtrlDashBtnMedicalRecords.DashboardButtonClicked += new System.Action<object>(this.DashboardButton_Click);
            this.uCtrlDashBtnMedicalRecords.DashboardButtonLeft += new System.Action<object>(this.DashboardButton_MouseLeave);
            // 
            // uCtrlDashBtnPayments
            // 
            this.uCtrlDashBtnPayments.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(65)))));
            this.uCtrlDashBtnPayments.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uCtrlDashBtnPayments.Dock = System.Windows.Forms.DockStyle.Top;
            this.uCtrlDashBtnPayments.Location = new System.Drawing.Point(0, 393);
            this.uCtrlDashBtnPayments.Margin = new System.Windows.Forms.Padding(4);
            this.uCtrlDashBtnPayments.Name = "uCtrlDashBtnPayments";
            this.uCtrlDashBtnPayments.Padding = new System.Windows.Forms.Padding(5, 5, 0, 5);
            this.uCtrlDashBtnPayments.Size = new System.Drawing.Size(277, 54);
            this.uCtrlDashBtnPayments.TabIndex = 20;
            this.uCtrlDashBtnPayments.Tag = "Today\'s Appointments Screen";
            this.uCtrlDashBtnPayments.DashboardButtonHovered += new System.Action<object>(this.DashboardButton_MouseHover);
            this.uCtrlDashBtnPayments.DashboardButtonClicked += new System.Action<object>(this.DashboardButton_Click);
            this.uCtrlDashBtnPayments.DashboardButtonLeft += new System.Action<object>(this.DashboardButton_MouseLeave);
            // 
            // uCtrlDashBtnAppointments
            // 
            this.uCtrlDashBtnAppointments.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(65)))));
            this.uCtrlDashBtnAppointments.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uCtrlDashBtnAppointments.Dock = System.Windows.Forms.DockStyle.Top;
            this.uCtrlDashBtnAppointments.Location = new System.Drawing.Point(0, 339);
            this.uCtrlDashBtnAppointments.Margin = new System.Windows.Forms.Padding(4);
            this.uCtrlDashBtnAppointments.Name = "uCtrlDashBtnAppointments";
            this.uCtrlDashBtnAppointments.Padding = new System.Windows.Forms.Padding(5, 5, 0, 5);
            this.uCtrlDashBtnAppointments.Size = new System.Drawing.Size(277, 54);
            this.uCtrlDashBtnAppointments.TabIndex = 19;
            this.uCtrlDashBtnAppointments.Tag = "Reservations Screen";
            this.uCtrlDashBtnAppointments.DashboardButtonHovered += new System.Action<object>(this.DashboardButton_MouseHover);
            this.uCtrlDashBtnAppointments.DashboardButtonClicked += new System.Action<object>(this.DashboardButton_Click);
            this.uCtrlDashBtnAppointments.DashboardButtonLeft += new System.Action<object>(this.DashboardButton_MouseLeave);
            // 
            // uCtrlDashBtnDoctors
            // 
            this.uCtrlDashBtnDoctors.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(65)))));
            this.uCtrlDashBtnDoctors.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uCtrlDashBtnDoctors.Dock = System.Windows.Forms.DockStyle.Top;
            this.uCtrlDashBtnDoctors.Location = new System.Drawing.Point(0, 285);
            this.uCtrlDashBtnDoctors.Margin = new System.Windows.Forms.Padding(4);
            this.uCtrlDashBtnDoctors.Name = "uCtrlDashBtnDoctors";
            this.uCtrlDashBtnDoctors.Padding = new System.Windows.Forms.Padding(5, 5, 0, 5);
            this.uCtrlDashBtnDoctors.Size = new System.Drawing.Size(277, 54);
            this.uCtrlDashBtnDoctors.TabIndex = 18;
            this.uCtrlDashBtnDoctors.Tag = "Doctors Screen";
            this.uCtrlDashBtnDoctors.DashboardButtonHovered += new System.Action<object>(this.DashboardButton_MouseHover);
            this.uCtrlDashBtnDoctors.DashboardButtonClicked += new System.Action<object>(this.DashboardButton_Click);
            this.uCtrlDashBtnDoctors.DashboardButtonLeft += new System.Action<object>(this.DashboardButton_MouseLeave);
            // 
            // uCtrlDashBtnPatients
            // 
            this.uCtrlDashBtnPatients.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(65)))));
            this.uCtrlDashBtnPatients.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uCtrlDashBtnPatients.Dock = System.Windows.Forms.DockStyle.Top;
            this.uCtrlDashBtnPatients.Location = new System.Drawing.Point(0, 231);
            this.uCtrlDashBtnPatients.Margin = new System.Windows.Forms.Padding(4);
            this.uCtrlDashBtnPatients.Name = "uCtrlDashBtnPatients";
            this.uCtrlDashBtnPatients.Padding = new System.Windows.Forms.Padding(5, 5, 0, 5);
            this.uCtrlDashBtnPatients.Size = new System.Drawing.Size(277, 54);
            this.uCtrlDashBtnPatients.TabIndex = 17;
            this.uCtrlDashBtnPatients.Tag = "Patients Screen";
            this.uCtrlDashBtnPatients.DashboardButtonHovered += new System.Action<object>(this.DashboardButton_MouseHover);
            this.uCtrlDashBtnPatients.DashboardButtonClicked += new System.Action<object>(this.DashboardButton_Click);
            this.uCtrlDashBtnPatients.DashboardButtonLeft += new System.Action<object>(this.DashboardButton_MouseLeave);
            // 
            // uCtrlDashBtnMain
            // 
            this.uCtrlDashBtnMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(65)))));
            this.uCtrlDashBtnMain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uCtrlDashBtnMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.uCtrlDashBtnMain.Location = new System.Drawing.Point(0, 177);
            this.uCtrlDashBtnMain.Margin = new System.Windows.Forms.Padding(4);
            this.uCtrlDashBtnMain.Name = "uCtrlDashBtnMain";
            this.uCtrlDashBtnMain.Padding = new System.Windows.Forms.Padding(5, 5, 0, 5);
            this.uCtrlDashBtnMain.Size = new System.Drawing.Size(277, 54);
            this.uCtrlDashBtnMain.TabIndex = 16;
            this.uCtrlDashBtnMain.Tag = "Main Screen";
            this.uCtrlDashBtnMain.DashboardButtonHovered += new System.Action<object>(this.DashboardButton_MouseHover);
            this.uCtrlDashBtnMain.DashboardButtonClicked += new System.Action<object>(this.DashboardButton_Click);
            this.uCtrlDashBtnMain.DashboardButtonLeft += new System.Action<object>(this.DashboardButton_MouseLeave);
            // 
            // ucSideBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(65)))));
            this.Controls.Add(this.uCtrlDashBtnMedicalRecords);
            this.Controls.Add(this.uCtrlDashBtnPayments);
            this.Controls.Add(this.uCtrlDashBtnAppointments);
            this.Controls.Add(this.uCtrlDashBtnDoctors);
            this.Controls.Add(this.uCtrlDashBtnPatients);
            this.Controls.Add(this.uCtrlDashBtnMain);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucSideBar";
            this.Size = new System.Drawing.Size(277, 614);
            this.Load += new System.EventHandler(this.ucSideBar_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbLogo;
        private ucDashboardButton uCtrlDashBtnMain;
        private ucDashboardButton uCtrlDashBtnPatients;
        private ucDashboardButton uCtrlDashBtnDoctors;
        private ucDashboardButton uCtrlDashBtnAppointments;
        private ucDashboardButton uCtrlDashBtnPayments;
        private ucDashboardButton uCtrlDashBtnMedicalRecords;
    }
}
