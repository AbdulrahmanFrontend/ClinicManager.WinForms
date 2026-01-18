namespace ClinicManager_PresentationLayer
{
    partial class ucReservationCard
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
            this.tlpInfo = new System.Windows.Forms.TableLayoutPanel();
            this.pnlOldStatus = new System.Windows.Forms.Panel();
            this.tbOldStatus = new System.Windows.Forms.TextBox();
            this.lblOldStatus = new System.Windows.Forms.Label();
            this.pnlSearchDoctor = new System.Windows.Forms.Panel();
            this.tbSearchDoctor = new System.Windows.Forms.TextBox();
            this.btnSearchDoctor = new System.Windows.Forms.Button();
            this.pnlDateTime = new System.Windows.Forms.Panel();
            this.dtpAppointmentDateTime = new System.Windows.Forms.DateTimePicker();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.pnlSearchPatient = new System.Windows.Forms.Panel();
            this.tbSearchPatient = new System.Windows.Forms.TextBox();
            this.btnSearchPatient = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbAppointmentType = new System.Windows.Forms.ComboBox();
            this.lblAppointmentType = new System.Windows.Forms.Label();
            this.pnlNewStatus = new System.Windows.Forms.Panel();
            this.cbNewStatus = new System.Windows.Forms.ComboBox();
            this.lblNewStatus = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tlpInfo.SuspendLayout();
            this.pnlOldStatus.SuspendLayout();
            this.pnlSearchDoctor.SuspendLayout();
            this.pnlDateTime.SuspendLayout();
            this.pnlSearchPatient.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlNewStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpInfo
            // 
            this.tlpInfo.ColumnCount = 2;
            this.tlpInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpInfo.Controls.Add(this.pnlOldStatus, 1, 2);
            this.tlpInfo.Controls.Add(this.pnlSearchDoctor, 1, 1);
            this.tlpInfo.Controls.Add(this.pnlDateTime, 0, 0);
            this.tlpInfo.Controls.Add(this.pnlSearchPatient, 0, 1);
            this.tlpInfo.Controls.Add(this.panel1, 1, 0);
            this.tlpInfo.Controls.Add(this.pnlNewStatus, 0, 2);
            this.tlpInfo.Dock = System.Windows.Forms.DockStyle.Left;
            this.tlpInfo.Location = new System.Drawing.Point(10, 10);
            this.tlpInfo.Name = "tlpInfo";
            this.tlpInfo.Padding = new System.Windows.Forms.Padding(10);
            this.tlpInfo.RowCount = 3;
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpInfo.Size = new System.Drawing.Size(1058, 292);
            this.tlpInfo.TabIndex = 11;
            // 
            // pnlOldStatus
            // 
            this.pnlOldStatus.Controls.Add(this.tbOldStatus);
            this.pnlOldStatus.Controls.Add(this.lblOldStatus);
            this.pnlOldStatus.Location = new System.Drawing.Point(532, 176);
            this.pnlOldStatus.Name = "pnlOldStatus";
            this.pnlOldStatus.Padding = new System.Windows.Forms.Padding(10, 10, 20, 10);
            this.pnlOldStatus.Size = new System.Drawing.Size(513, 82);
            this.pnlOldStatus.TabIndex = 14;
            this.pnlOldStatus.Visible = false;
            // 
            // tbOldStatus
            // 
            this.tbOldStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(247)))));
            this.tbOldStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbOldStatus.Enabled = false;
            this.tbOldStatus.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbOldStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.tbOldStatus.Location = new System.Drawing.Point(10, 42);
            this.tbOldStatus.MaxLength = 100;
            this.tbOldStatus.Name = "tbOldStatus";
            this.tbOldStatus.Size = new System.Drawing.Size(483, 30);
            this.tbOldStatus.TabIndex = 1;
            // 
            // lblOldStatus
            // 
            this.lblOldStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblOldStatus.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOldStatus.ForeColor = System.Drawing.Color.White;
            this.lblOldStatus.Location = new System.Drawing.Point(10, 10);
            this.lblOldStatus.Name = "lblOldStatus";
            this.lblOldStatus.Size = new System.Drawing.Size(483, 27);
            this.lblOldStatus.TabIndex = 0;
            this.lblOldStatus.Text = "Old Status:";
            this.lblOldStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlSearchDoctor
            // 
            this.pnlSearchDoctor.Controls.Add(this.tbSearchDoctor);
            this.pnlSearchDoctor.Controls.Add(this.btnSearchDoctor);
            this.pnlSearchDoctor.Location = new System.Drawing.Point(532, 108);
            this.pnlSearchDoctor.Name = "pnlSearchDoctor";
            this.pnlSearchDoctor.Padding = new System.Windows.Forms.Padding(10, 10, 20, 10);
            this.pnlSearchDoctor.Size = new System.Drawing.Size(513, 50);
            this.pnlSearchDoctor.TabIndex = 5;
            // 
            // tbSearchDoctor
            // 
            this.tbSearchDoctor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSearchDoctor.Enabled = false;
            this.tbSearchDoctor.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearchDoctor.Location = new System.Drawing.Point(160, 10);
            this.tbSearchDoctor.Name = "tbSearchDoctor";
            this.tbSearchDoctor.Size = new System.Drawing.Size(333, 30);
            this.tbSearchDoctor.TabIndex = 4;
            // 
            // btnSearchDoctor
            // 
            this.btnSearchDoctor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(141)))), ((int)(((byte)(255)))));
            this.btnSearchDoctor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchDoctor.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSearchDoctor.FlatAppearance.BorderSize = 0;
            this.btnSearchDoctor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchDoctor.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchDoctor.ForeColor = System.Drawing.Color.White;
            this.btnSearchDoctor.Location = new System.Drawing.Point(10, 10);
            this.btnSearchDoctor.Name = "btnSearchDoctor";
            this.btnSearchDoctor.Size = new System.Drawing.Size(150, 30);
            this.btnSearchDoctor.TabIndex = 3;
            this.btnSearchDoctor.Text = "Search Doctor";
            this.btnSearchDoctor.UseVisualStyleBackColor = false;
            this.btnSearchDoctor.Click += new System.EventHandler(this.btnSearchDoctor_Click);
            this.btnSearchDoctor.MouseLeave += new System.EventHandler(this.btnSearch_MouseLeave);
            this.btnSearchDoctor.MouseHover += new System.EventHandler(this.btnSearch_MouseHover);
            // 
            // pnlDateTime
            // 
            this.pnlDateTime.Controls.Add(this.dtpAppointmentDateTime);
            this.pnlDateTime.Controls.Add(this.lblDateTime);
            this.pnlDateTime.Location = new System.Drawing.Point(13, 13);
            this.pnlDateTime.Name = "pnlDateTime";
            this.pnlDateTime.Padding = new System.Windows.Forms.Padding(10, 10, 20, 10);
            this.pnlDateTime.Size = new System.Drawing.Size(513, 82);
            this.pnlDateTime.TabIndex = 9;
            // 
            // dtpAppointmentDateTime
            // 
            this.dtpAppointmentDateTime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtpAppointmentDateTime.CustomFormat = "dd/MM/yyyy  hh:mm tt";
            this.dtpAppointmentDateTime.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dtpAppointmentDateTime.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpAppointmentDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAppointmentDateTime.Location = new System.Drawing.Point(10, 42);
            this.dtpAppointmentDateTime.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dtpAppointmentDateTime.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpAppointmentDateTime.Name = "dtpAppointmentDateTime";
            this.dtpAppointmentDateTime.Size = new System.Drawing.Size(483, 30);
            this.dtpAppointmentDateTime.TabIndex = 1;
            // 
            // lblDateTime
            // 
            this.lblDateTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(58)))), ((int)(((byte)(74)))));
            this.lblDateTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDateTime.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTime.ForeColor = System.Drawing.Color.White;
            this.lblDateTime.Location = new System.Drawing.Point(10, 10);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(483, 27);
            this.lblDateTime.TabIndex = 0;
            this.lblDateTime.Text = "Date && Time:";
            this.lblDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlSearchPatient
            // 
            this.pnlSearchPatient.Controls.Add(this.tbSearchPatient);
            this.pnlSearchPatient.Controls.Add(this.btnSearchPatient);
            this.pnlSearchPatient.Location = new System.Drawing.Point(13, 108);
            this.pnlSearchPatient.Name = "pnlSearchPatient";
            this.pnlSearchPatient.Padding = new System.Windows.Forms.Padding(10, 10, 20, 10);
            this.pnlSearchPatient.Size = new System.Drawing.Size(513, 50);
            this.pnlSearchPatient.TabIndex = 4;
            // 
            // tbSearchPatient
            // 
            this.tbSearchPatient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSearchPatient.Enabled = false;
            this.tbSearchPatient.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearchPatient.Location = new System.Drawing.Point(160, 10);
            this.tbSearchPatient.Name = "tbSearchPatient";
            this.tbSearchPatient.Size = new System.Drawing.Size(333, 30);
            this.tbSearchPatient.TabIndex = 3;
            // 
            // btnSearchPatient
            // 
            this.btnSearchPatient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(141)))), ((int)(((byte)(255)))));
            this.btnSearchPatient.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchPatient.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSearchPatient.FlatAppearance.BorderSize = 0;
            this.btnSearchPatient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchPatient.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchPatient.ForeColor = System.Drawing.Color.White;
            this.btnSearchPatient.Location = new System.Drawing.Point(10, 10);
            this.btnSearchPatient.Name = "btnSearchPatient";
            this.btnSearchPatient.Size = new System.Drawing.Size(150, 30);
            this.btnSearchPatient.TabIndex = 2;
            this.btnSearchPatient.Text = "Search Patient";
            this.btnSearchPatient.UseVisualStyleBackColor = false;
            this.btnSearchPatient.Click += new System.EventHandler(this.btnSearchPatient_Click);
            this.btnSearchPatient.MouseLeave += new System.EventHandler(this.btnSearch_MouseLeave);
            this.btnSearchPatient.MouseHover += new System.EventHandler(this.btnSearch_MouseHover);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbAppointmentType);
            this.panel1.Controls.Add(this.lblAppointmentType);
            this.panel1.Location = new System.Drawing.Point(532, 13);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10, 10, 20, 10);
            this.panel1.Size = new System.Drawing.Size(513, 82);
            this.panel1.TabIndex = 13;
            // 
            // cbAppointmentType
            // 
            this.cbAppointmentType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(247)))));
            this.cbAppointmentType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbAppointmentType.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cbAppointmentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAppointmentType.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAppointmentType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.cbAppointmentType.Location = new System.Drawing.Point(10, 41);
            this.cbAppointmentType.MaxLength = 1;
            this.cbAppointmentType.Name = "cbAppointmentType";
            this.cbAppointmentType.Size = new System.Drawing.Size(483, 31);
            this.cbAppointmentType.TabIndex = 1;
            // 
            // lblAppointmentType
            // 
            this.lblAppointmentType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(58)))), ((int)(((byte)(74)))));
            this.lblAppointmentType.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAppointmentType.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppointmentType.ForeColor = System.Drawing.Color.White;
            this.lblAppointmentType.Location = new System.Drawing.Point(10, 10);
            this.lblAppointmentType.Name = "lblAppointmentType";
            this.lblAppointmentType.Size = new System.Drawing.Size(483, 27);
            this.lblAppointmentType.TabIndex = 0;
            this.lblAppointmentType.Text = "Appointment Type:";
            this.lblAppointmentType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlNewStatus
            // 
            this.pnlNewStatus.Controls.Add(this.cbNewStatus);
            this.pnlNewStatus.Controls.Add(this.lblNewStatus);
            this.pnlNewStatus.Location = new System.Drawing.Point(13, 176);
            this.pnlNewStatus.Name = "pnlNewStatus";
            this.pnlNewStatus.Padding = new System.Windows.Forms.Padding(10, 10, 20, 10);
            this.pnlNewStatus.Size = new System.Drawing.Size(513, 82);
            this.pnlNewStatus.TabIndex = 8;
            // 
            // cbNewStatus
            // 
            this.cbNewStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(247)))));
            this.cbNewStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbNewStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cbNewStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNewStatus.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNewStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.cbNewStatus.Location = new System.Drawing.Point(10, 41);
            this.cbNewStatus.MaxLength = 1;
            this.cbNewStatus.Name = "cbNewStatus";
            this.cbNewStatus.Size = new System.Drawing.Size(483, 31);
            this.cbNewStatus.Sorted = true;
            this.cbNewStatus.TabIndex = 1;
            // 
            // lblNewStatus
            // 
            this.lblNewStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(58)))), ((int)(((byte)(74)))));
            this.lblNewStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNewStatus.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewStatus.ForeColor = System.Drawing.Color.White;
            this.lblNewStatus.Location = new System.Drawing.Point(10, 10);
            this.lblNewStatus.Name = "lblNewStatus";
            this.lblNewStatus.Size = new System.Drawing.Size(483, 27);
            this.lblNewStatus.TabIndex = 0;
            this.lblNewStatus.Text = "New Status:";
            this.lblNewStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::ClinicManager_PresentationLayer.Properties.Resources.download__1_;
            this.pictureBox1.Location = new System.Drawing.Point(1068, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(302, 292);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // ucReservationCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(58)))), ((int)(((byte)(74)))));
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tlpInfo);
            this.Name = "ucReservationCard";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(1380, 312);
            this.tlpInfo.ResumeLayout(false);
            this.pnlOldStatus.ResumeLayout(false);
            this.pnlOldStatus.PerformLayout();
            this.pnlSearchDoctor.ResumeLayout(false);
            this.pnlSearchDoctor.PerformLayout();
            this.pnlDateTime.ResumeLayout(false);
            this.pnlSearchPatient.ResumeLayout(false);
            this.pnlSearchPatient.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.pnlNewStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpInfo;
        private System.Windows.Forms.Panel pnlSearchPatient;
        private System.Windows.Forms.Panel pnlDateTime;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Panel pnlNewStatus;
        private System.Windows.Forms.ComboBox cbNewStatus;
        private System.Windows.Forms.Label lblNewStatus;
        private System.Windows.Forms.Panel pnlSearchDoctor;
        private System.Windows.Forms.TextBox tbSearchPatient;
        private System.Windows.Forms.Button btnSearchPatient;
        private System.Windows.Forms.TextBox tbSearchDoctor;
        private System.Windows.Forms.Button btnSearchDoctor;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbAppointmentType;
        private System.Windows.Forms.Label lblAppointmentType;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DateTimePicker dtpAppointmentDateTime;
        private System.Windows.Forms.Panel pnlOldStatus;
        private System.Windows.Forms.TextBox tbOldStatus;
        private System.Windows.Forms.Label lblOldStatus;
    }
}
