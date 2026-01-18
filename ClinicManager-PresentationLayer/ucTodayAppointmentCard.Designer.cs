namespace ClinicManager_PresentationLayer
{
    partial class ucTodayAppointmentCard
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
            this.pnlPatient = new System.Windows.Forms.Panel();
            this.tbPatient = new System.Windows.Forms.TextBox();
            this.lblPatient = new System.Windows.Forms.Label();
            this.pnlDoctor = new System.Windows.Forms.Panel();
            this.tbDoctor = new System.Windows.Forms.TextBox();
            this.lblDoctor = new System.Windows.Forms.Label();
            this.pnlDateTime = new System.Windows.Forms.Panel();
            this.dtpAppointmentDateTime = new System.Windows.Forms.DateTimePicker();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.pnlOldStatus = new System.Windows.Forms.Panel();
            this.tbOldStatus = new System.Windows.Forms.TextBox();
            this.lblOldStatus = new System.Windows.Forms.Label();
            this.pnlNewStatus = new System.Windows.Forms.Panel();
            this.cbNewStatus = new System.Windows.Forms.ComboBox();
            this.lblNewStatus = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbAppointmentType = new System.Windows.Forms.TextBox();
            this.lblAppointmentType = new System.Windows.Forms.Label();
            this.pnlPaymentDate = new System.Windows.Forms.Panel();
            this.dtpPaymentDate = new System.Windows.Forms.DateTimePicker();
            this.lblPaymentDate = new System.Windows.Forms.Label();
            this.pnlAmountPaid = new System.Windows.Forms.Panel();
            this.tbAmountPaid = new System.Windows.Forms.TextBox();
            this.lblAmountPaid = new System.Windows.Forms.Label();
            this.pnlPaymentMethod = new System.Windows.Forms.Panel();
            this.cbPaymentMethod = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlAdditionalNotes = new System.Windows.Forms.Panel();
            this.tbAdditionalNotes = new System.Windows.Forms.TextBox();
            this.lblAdditionalNotes = new System.Windows.Forms.Label();
            this.tlpInfo.SuspendLayout();
            this.pnlPatient.SuspendLayout();
            this.pnlDoctor.SuspendLayout();
            this.pnlDateTime.SuspendLayout();
            this.pnlOldStatus.SuspendLayout();
            this.pnlNewStatus.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlPaymentDate.SuspendLayout();
            this.pnlAmountPaid.SuspendLayout();
            this.pnlPaymentMethod.SuspendLayout();
            this.pnlAdditionalNotes.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpInfo
            // 
            this.tlpInfo.ColumnCount = 2;
            this.tlpInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpInfo.Controls.Add(this.pnlPatient, 1, 0);
            this.tlpInfo.Controls.Add(this.pnlDoctor, 0, 0);
            this.tlpInfo.Controls.Add(this.pnlDateTime, 0, 1);
            this.tlpInfo.Controls.Add(this.pnlOldStatus, 1, 1);
            this.tlpInfo.Controls.Add(this.pnlNewStatus, 0, 2);
            this.tlpInfo.Controls.Add(this.panel1, 1, 2);
            this.tlpInfo.Controls.Add(this.pnlPaymentDate, 0, 3);
            this.tlpInfo.Controls.Add(this.pnlAmountPaid, 1, 3);
            this.tlpInfo.Controls.Add(this.pnlPaymentMethod, 0, 4);
            this.tlpInfo.Dock = System.Windows.Forms.DockStyle.Left;
            this.tlpInfo.Location = new System.Drawing.Point(10, 10);
            this.tlpInfo.Name = "tlpInfo";
            this.tlpInfo.Padding = new System.Windows.Forms.Padding(10);
            this.tlpInfo.RowCount = 5;
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpInfo.Size = new System.Drawing.Size(949, 526);
            this.tlpInfo.TabIndex = 12;
            // 
            // pnlPatient
            // 
            this.pnlPatient.Controls.Add(this.tbPatient);
            this.pnlPatient.Controls.Add(this.lblPatient);
            this.pnlPatient.Location = new System.Drawing.Point(477, 13);
            this.pnlPatient.Name = "pnlPatient";
            this.pnlPatient.Padding = new System.Windows.Forms.Padding(10, 10, 20, 10);
            this.pnlPatient.Size = new System.Drawing.Size(459, 82);
            this.pnlPatient.TabIndex = 19;
            // 
            // tbPatient
            // 
            this.tbPatient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(247)))));
            this.tbPatient.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbPatient.Enabled = false;
            this.tbPatient.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPatient.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.tbPatient.Location = new System.Drawing.Point(10, 42);
            this.tbPatient.MaxLength = 100;
            this.tbPatient.Name = "tbPatient";
            this.tbPatient.Size = new System.Drawing.Size(429, 30);
            this.tbPatient.TabIndex = 1;
            // 
            // lblPatient
            // 
            this.lblPatient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(58)))), ((int)(((byte)(74)))));
            this.lblPatient.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPatient.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatient.ForeColor = System.Drawing.Color.White;
            this.lblPatient.Location = new System.Drawing.Point(10, 10);
            this.lblPatient.Name = "lblPatient";
            this.lblPatient.Size = new System.Drawing.Size(429, 27);
            this.lblPatient.TabIndex = 0;
            this.lblPatient.Text = "Patient";
            this.lblPatient.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlDoctor
            // 
            this.pnlDoctor.Controls.Add(this.tbDoctor);
            this.pnlDoctor.Controls.Add(this.lblDoctor);
            this.pnlDoctor.Location = new System.Drawing.Point(13, 13);
            this.pnlDoctor.Name = "pnlDoctor";
            this.pnlDoctor.Padding = new System.Windows.Forms.Padding(10, 10, 20, 10);
            this.pnlDoctor.Size = new System.Drawing.Size(458, 82);
            this.pnlDoctor.TabIndex = 18;
            // 
            // tbDoctor
            // 
            this.tbDoctor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(247)))));
            this.tbDoctor.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbDoctor.Enabled = false;
            this.tbDoctor.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDoctor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.tbDoctor.Location = new System.Drawing.Point(10, 42);
            this.tbDoctor.MaxLength = 100;
            this.tbDoctor.Name = "tbDoctor";
            this.tbDoctor.Size = new System.Drawing.Size(428, 30);
            this.tbDoctor.TabIndex = 1;
            // 
            // lblDoctor
            // 
            this.lblDoctor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(58)))), ((int)(((byte)(74)))));
            this.lblDoctor.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDoctor.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoctor.ForeColor = System.Drawing.Color.White;
            this.lblDoctor.Location = new System.Drawing.Point(10, 10);
            this.lblDoctor.Name = "lblDoctor";
            this.lblDoctor.Size = new System.Drawing.Size(428, 27);
            this.lblDoctor.TabIndex = 0;
            this.lblDoctor.Text = "Doctor:";
            this.lblDoctor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlDateTime
            // 
            this.pnlDateTime.Controls.Add(this.dtpAppointmentDateTime);
            this.pnlDateTime.Controls.Add(this.lblDateTime);
            this.pnlDateTime.Location = new System.Drawing.Point(13, 114);
            this.pnlDateTime.Name = "pnlDateTime";
            this.pnlDateTime.Padding = new System.Windows.Forms.Padding(10, 10, 20, 10);
            this.pnlDateTime.Size = new System.Drawing.Size(458, 82);
            this.pnlDateTime.TabIndex = 9;
            // 
            // dtpAppointmentDateTime
            // 
            this.dtpAppointmentDateTime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtpAppointmentDateTime.CustomFormat = "dd/MM/yyyy  hh:mm tt";
            this.dtpAppointmentDateTime.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dtpAppointmentDateTime.Enabled = false;
            this.dtpAppointmentDateTime.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpAppointmentDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAppointmentDateTime.Location = new System.Drawing.Point(10, 42);
            this.dtpAppointmentDateTime.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dtpAppointmentDateTime.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpAppointmentDateTime.Name = "dtpAppointmentDateTime";
            this.dtpAppointmentDateTime.Size = new System.Drawing.Size(428, 30);
            this.dtpAppointmentDateTime.TabIndex = 2;
            // 
            // lblDateTime
            // 
            this.lblDateTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(58)))), ((int)(((byte)(74)))));
            this.lblDateTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDateTime.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTime.ForeColor = System.Drawing.Color.White;
            this.lblDateTime.Location = new System.Drawing.Point(10, 10);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(428, 27);
            this.lblDateTime.TabIndex = 0;
            this.lblDateTime.Text = "Date && Time:";
            this.lblDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlOldStatus
            // 
            this.pnlOldStatus.Controls.Add(this.tbOldStatus);
            this.pnlOldStatus.Controls.Add(this.lblOldStatus);
            this.pnlOldStatus.Location = new System.Drawing.Point(477, 114);
            this.pnlOldStatus.Name = "pnlOldStatus";
            this.pnlOldStatus.Padding = new System.Windows.Forms.Padding(10, 10, 20, 10);
            this.pnlOldStatus.Size = new System.Drawing.Size(459, 82);
            this.pnlOldStatus.TabIndex = 20;
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
            this.tbOldStatus.Size = new System.Drawing.Size(429, 30);
            this.tbOldStatus.TabIndex = 1;
            // 
            // lblOldStatus
            // 
            this.lblOldStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(58)))), ((int)(((byte)(74)))));
            this.lblOldStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblOldStatus.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOldStatus.ForeColor = System.Drawing.Color.White;
            this.lblOldStatus.Location = new System.Drawing.Point(10, 10);
            this.lblOldStatus.Name = "lblOldStatus";
            this.lblOldStatus.Size = new System.Drawing.Size(429, 27);
            this.lblOldStatus.TabIndex = 0;
            this.lblOldStatus.Text = "Old Status:";
            this.lblOldStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlNewStatus
            // 
            this.pnlNewStatus.Controls.Add(this.cbNewStatus);
            this.pnlNewStatus.Controls.Add(this.lblNewStatus);
            this.pnlNewStatus.Location = new System.Drawing.Point(13, 215);
            this.pnlNewStatus.Name = "pnlNewStatus";
            this.pnlNewStatus.Padding = new System.Windows.Forms.Padding(10, 10, 20, 10);
            this.pnlNewStatus.Size = new System.Drawing.Size(458, 82);
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
            this.cbNewStatus.Size = new System.Drawing.Size(428, 31);
            this.cbNewStatus.Sorted = true;
            this.cbNewStatus.TabIndex = 1;
            this.cbNewStatus.SelectedIndexChanged += new System.EventHandler(this.cbNewStatus_SelectedIndexChanged);
            // 
            // lblNewStatus
            // 
            this.lblNewStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(58)))), ((int)(((byte)(74)))));
            this.lblNewStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNewStatus.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewStatus.ForeColor = System.Drawing.Color.White;
            this.lblNewStatus.Location = new System.Drawing.Point(10, 10);
            this.lblNewStatus.Name = "lblNewStatus";
            this.lblNewStatus.Size = new System.Drawing.Size(428, 27);
            this.lblNewStatus.TabIndex = 0;
            this.lblNewStatus.Text = "New Status:";
            this.lblNewStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbAppointmentType);
            this.panel1.Controls.Add(this.lblAppointmentType);
            this.panel1.Location = new System.Drawing.Point(477, 215);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10, 10, 20, 10);
            this.panel1.Size = new System.Drawing.Size(459, 82);
            this.panel1.TabIndex = 13;
            // 
            // tbAppointmentType
            // 
            this.tbAppointmentType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(247)))));
            this.tbAppointmentType.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbAppointmentType.Enabled = false;
            this.tbAppointmentType.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAppointmentType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.tbAppointmentType.Location = new System.Drawing.Point(10, 42);
            this.tbAppointmentType.MaxLength = 100;
            this.tbAppointmentType.Name = "tbAppointmentType";
            this.tbAppointmentType.Size = new System.Drawing.Size(429, 30);
            this.tbAppointmentType.TabIndex = 2;
            // 
            // lblAppointmentType
            // 
            this.lblAppointmentType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(58)))), ((int)(((byte)(74)))));
            this.lblAppointmentType.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAppointmentType.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppointmentType.ForeColor = System.Drawing.Color.White;
            this.lblAppointmentType.Location = new System.Drawing.Point(10, 10);
            this.lblAppointmentType.Name = "lblAppointmentType";
            this.lblAppointmentType.Size = new System.Drawing.Size(429, 27);
            this.lblAppointmentType.TabIndex = 0;
            this.lblAppointmentType.Text = "Appointment Type:";
            this.lblAppointmentType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlPaymentDate
            // 
            this.pnlPaymentDate.Controls.Add(this.dtpPaymentDate);
            this.pnlPaymentDate.Controls.Add(this.lblPaymentDate);
            this.pnlPaymentDate.Location = new System.Drawing.Point(13, 316);
            this.pnlPaymentDate.Name = "pnlPaymentDate";
            this.pnlPaymentDate.Padding = new System.Windows.Forms.Padding(10, 10, 20, 10);
            this.pnlPaymentDate.Size = new System.Drawing.Size(458, 82);
            this.pnlPaymentDate.TabIndex = 14;
            // 
            // dtpPaymentDate
            // 
            this.dtpPaymentDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtpPaymentDate.CustomFormat = "dd/MM/yyyy hh:mm tt";
            this.dtpPaymentDate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dtpPaymentDate.Enabled = false;
            this.dtpPaymentDate.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPaymentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPaymentDate.Location = new System.Drawing.Point(10, 42);
            this.dtpPaymentDate.MaxDate = new System.DateTime(2026, 1, 9, 0, 0, 0, 0);
            this.dtpPaymentDate.MinDate = new System.DateTime(1901, 1, 1, 0, 0, 0, 0);
            this.dtpPaymentDate.Name = "dtpPaymentDate";
            this.dtpPaymentDate.Size = new System.Drawing.Size(428, 30);
            this.dtpPaymentDate.TabIndex = 1;
            this.dtpPaymentDate.Value = new System.DateTime(2026, 1, 9, 0, 0, 0, 0);
            // 
            // lblPaymentDate
            // 
            this.lblPaymentDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(58)))), ((int)(((byte)(74)))));
            this.lblPaymentDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPaymentDate.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentDate.ForeColor = System.Drawing.Color.White;
            this.lblPaymentDate.Location = new System.Drawing.Point(10, 10);
            this.lblPaymentDate.Name = "lblPaymentDate";
            this.lblPaymentDate.Size = new System.Drawing.Size(428, 27);
            this.lblPaymentDate.TabIndex = 0;
            this.lblPaymentDate.Text = "Payment Date:";
            this.lblPaymentDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlAmountPaid
            // 
            this.pnlAmountPaid.Controls.Add(this.tbAmountPaid);
            this.pnlAmountPaid.Controls.Add(this.lblAmountPaid);
            this.pnlAmountPaid.Location = new System.Drawing.Point(477, 316);
            this.pnlAmountPaid.Name = "pnlAmountPaid";
            this.pnlAmountPaid.Padding = new System.Windows.Forms.Padding(10, 10, 20, 10);
            this.pnlAmountPaid.Size = new System.Drawing.Size(459, 82);
            this.pnlAmountPaid.TabIndex = 16;
            // 
            // tbAmountPaid
            // 
            this.tbAmountPaid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(247)))));
            this.tbAmountPaid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbAmountPaid.Enabled = false;
            this.tbAmountPaid.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAmountPaid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.tbAmountPaid.Location = new System.Drawing.Point(10, 42);
            this.tbAmountPaid.MaxLength = 100;
            this.tbAmountPaid.Name = "tbAmountPaid";
            this.tbAmountPaid.Size = new System.Drawing.Size(429, 30);
            this.tbAmountPaid.TabIndex = 1;
            this.tbAmountPaid.Text = "0";
            // 
            // lblAmountPaid
            // 
            this.lblAmountPaid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(58)))), ((int)(((byte)(74)))));
            this.lblAmountPaid.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAmountPaid.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountPaid.ForeColor = System.Drawing.Color.White;
            this.lblAmountPaid.Location = new System.Drawing.Point(10, 10);
            this.lblAmountPaid.Name = "lblAmountPaid";
            this.lblAmountPaid.Size = new System.Drawing.Size(429, 27);
            this.lblAmountPaid.TabIndex = 0;
            this.lblAmountPaid.Text = "Amount Paid:";
            this.lblAmountPaid.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlPaymentMethod
            // 
            this.pnlPaymentMethod.Controls.Add(this.cbPaymentMethod);
            this.pnlPaymentMethod.Controls.Add(this.label2);
            this.pnlPaymentMethod.Location = new System.Drawing.Point(13, 417);
            this.pnlPaymentMethod.Name = "pnlPaymentMethod";
            this.pnlPaymentMethod.Padding = new System.Windows.Forms.Padding(10, 10, 20, 10);
            this.pnlPaymentMethod.Size = new System.Drawing.Size(458, 82);
            this.pnlPaymentMethod.TabIndex = 17;
            // 
            // cbPaymentMethod
            // 
            this.cbPaymentMethod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(247)))));
            this.cbPaymentMethod.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbPaymentMethod.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cbPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPaymentMethod.Enabled = false;
            this.cbPaymentMethod.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPaymentMethod.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.cbPaymentMethod.Location = new System.Drawing.Point(10, 41);
            this.cbPaymentMethod.MaxLength = 1;
            this.cbPaymentMethod.Name = "cbPaymentMethod";
            this.cbPaymentMethod.Size = new System.Drawing.Size(428, 31);
            this.cbPaymentMethod.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(58)))), ((int)(((byte)(74)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(10, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(428, 27);
            this.label2.TabIndex = 0;
            this.label2.Text = "Payment Method:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlAdditionalNotes
            // 
            this.pnlAdditionalNotes.Controls.Add(this.tbAdditionalNotes);
            this.pnlAdditionalNotes.Controls.Add(this.lblAdditionalNotes);
            this.pnlAdditionalNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAdditionalNotes.Location = new System.Drawing.Point(959, 10);
            this.pnlAdditionalNotes.Name = "pnlAdditionalNotes";
            this.pnlAdditionalNotes.Padding = new System.Windows.Forms.Padding(10, 10, 20, 10);
            this.pnlAdditionalNotes.Size = new System.Drawing.Size(433, 526);
            this.pnlAdditionalNotes.TabIndex = 17;
            // 
            // tbAdditionalNotes
            // 
            this.tbAdditionalNotes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(247)))));
            this.tbAdditionalNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbAdditionalNotes.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAdditionalNotes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.tbAdditionalNotes.Location = new System.Drawing.Point(10, 53);
            this.tbAdditionalNotes.MaxLength = 100;
            this.tbAdditionalNotes.Multiline = true;
            this.tbAdditionalNotes.Name = "tbAdditionalNotes";
            this.tbAdditionalNotes.Size = new System.Drawing.Size(403, 463);
            this.tbAdditionalNotes.TabIndex = 1;
            // 
            // lblAdditionalNotes
            // 
            this.lblAdditionalNotes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(58)))), ((int)(((byte)(74)))));
            this.lblAdditionalNotes.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAdditionalNotes.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdditionalNotes.ForeColor = System.Drawing.Color.White;
            this.lblAdditionalNotes.Location = new System.Drawing.Point(10, 10);
            this.lblAdditionalNotes.Name = "lblAdditionalNotes";
            this.lblAdditionalNotes.Size = new System.Drawing.Size(403, 43);
            this.lblAdditionalNotes.TabIndex = 0;
            this.lblAdditionalNotes.Text = "Additional Notes:";
            this.lblAdditionalNotes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ucTodayAppointmentsCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.Controls.Add(this.pnlAdditionalNotes);
            this.Controls.Add(this.tlpInfo);
            this.Name = "ucTodayAppointmentsCard";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(1402, 546);
            this.tlpInfo.ResumeLayout(false);
            this.pnlPatient.ResumeLayout(false);
            this.pnlPatient.PerformLayout();
            this.pnlDoctor.ResumeLayout(false);
            this.pnlDoctor.PerformLayout();
            this.pnlDateTime.ResumeLayout(false);
            this.pnlOldStatus.ResumeLayout(false);
            this.pnlOldStatus.PerformLayout();
            this.pnlNewStatus.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlPaymentDate.ResumeLayout(false);
            this.pnlAmountPaid.ResumeLayout(false);
            this.pnlAmountPaid.PerformLayout();
            this.pnlPaymentMethod.ResumeLayout(false);
            this.pnlAdditionalNotes.ResumeLayout(false);
            this.pnlAdditionalNotes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpInfo;
        private System.Windows.Forms.Panel pnlNewStatus;
        private System.Windows.Forms.ComboBox cbNewStatus;
        private System.Windows.Forms.Label lblNewStatus;
        private System.Windows.Forms.Panel pnlDateTime;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblAppointmentType;
        private System.Windows.Forms.Panel pnlPaymentDate;
        private System.Windows.Forms.DateTimePicker dtpPaymentDate;
        private System.Windows.Forms.Label lblPaymentDate;
        private System.Windows.Forms.Panel pnlPaymentMethod;
        private System.Windows.Forms.ComboBox cbPaymentMethod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlAmountPaid;
        private System.Windows.Forms.TextBox tbAmountPaid;
        private System.Windows.Forms.Label lblAmountPaid;
        private System.Windows.Forms.Panel pnlAdditionalNotes;
        private System.Windows.Forms.TextBox tbAdditionalNotes;
        private System.Windows.Forms.Label lblAdditionalNotes;
        private System.Windows.Forms.Panel pnlPatient;
        private System.Windows.Forms.TextBox tbPatient;
        private System.Windows.Forms.Label lblPatient;
        private System.Windows.Forms.Panel pnlDoctor;
        private System.Windows.Forms.TextBox tbDoctor;
        private System.Windows.Forms.Label lblDoctor;
        private System.Windows.Forms.DateTimePicker dtpAppointmentDateTime;
        private System.Windows.Forms.Panel pnlOldStatus;
        private System.Windows.Forms.TextBox tbOldStatus;
        private System.Windows.Forms.Label lblOldStatus;
        private System.Windows.Forms.TextBox tbAppointmentType;
    }
}
