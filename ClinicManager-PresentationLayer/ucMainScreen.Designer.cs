namespace ClinicManager_PresentationLayer
{
    partial class ucMainScreen
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
            this.flpCards = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblLatestAddedPatients = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvLatestAddedPatients = new System.Windows.Forms.DataGridView();
            this.dgvUpcomingAppointments = new System.Windows.Forms.DataGridView();
            this.ucHeaderBar1 = new ClinicManager_PresentationLayer.ucHeaderBar();
            this.HeaderBar = new ClinicManager_PresentationLayer.ucHeaderBar();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.uCtrlSCDoctors = new ClinicManager_PresentationLayer.ucStatsCard();
            this.uCtrlSCAppointments = new ClinicManager_PresentationLayer.ucStatsCard();
            this.uCtrlSCPatients = new ClinicManager_PresentationLayer.ucStatsCard();
            this.uCtrlSCRevenue = new ClinicManager_PresentationLayer.ucStatsCard();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLatestAddedPatients)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpcomingAppointments)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpCards
            // 
            this.flpCards.AutoSize = true;
            this.flpCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpCards.Location = new System.Drawing.Point(10, 0);
            this.flpCards.Name = "flpCards";
            this.flpCards.Size = new System.Drawing.Size(866, 0);
            this.flpCards.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(442, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(411, 42);
            this.label1.TabIndex = 3;
            this.label1.Text = "Upcoming Appointments:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLatestAddedPatients
            // 
            this.lblLatestAddedPatients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLatestAddedPatients.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLatestAddedPatients.ForeColor = System.Drawing.Color.White;
            this.lblLatestAddedPatients.Location = new System.Drawing.Point(13, 0);
            this.lblLatestAddedPatients.Margin = new System.Windows.Forms.Padding(3, 0, 10, 0);
            this.lblLatestAddedPatients.Name = "lblLatestAddedPatients";
            this.lblLatestAddedPatients.Size = new System.Drawing.Size(409, 42);
            this.lblLatestAddedPatients.TabIndex = 4;
            this.lblLatestAddedPatients.Text = "Latest Added Patients:";
            this.lblLatestAddedPatients.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.95224F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.04776F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblLatestAddedPatients, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvLatestAddedPatients, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dgvUpcomingAppointments, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 357);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(866, 385);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // dgvLatestAddedPatients
            // 
            this.dgvLatestAddedPatients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLatestAddedPatients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLatestAddedPatients.Location = new System.Drawing.Point(13, 45);
            this.dgvLatestAddedPatients.Name = "dgvLatestAddedPatients";
            this.dgvLatestAddedPatients.RowHeadersWidth = 51;
            this.dgvLatestAddedPatients.RowTemplate.Height = 24;
            this.dgvLatestAddedPatients.Size = new System.Drawing.Size(416, 327);
            this.dgvLatestAddedPatients.TabIndex = 5;
            // 
            // dgvUpcomingAppointments
            // 
            this.dgvUpcomingAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUpcomingAppointments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUpcomingAppointments.Location = new System.Drawing.Point(435, 45);
            this.dgvUpcomingAppointments.Name = "dgvUpcomingAppointments";
            this.dgvUpcomingAppointments.RowHeadersWidth = 51;
            this.dgvUpcomingAppointments.RowTemplate.Height = 24;
            this.dgvUpcomingAppointments.Size = new System.Drawing.Size(418, 327);
            this.dgvUpcomingAppointments.TabIndex = 6;
            // 
            // ucHeaderBar1
            // 
            this.ucHeaderBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(48)))), ((int)(((byte)(63)))));
            this.ucHeaderBar1.Location = new System.Drawing.Point(395, 235);
            this.ucHeaderBar1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucHeaderBar1.Name = "ucHeaderBar1";
            this.ucHeaderBar1.Padding = new System.Windows.Forms.Padding(5);
            this.ucHeaderBar1.Size = new System.Drawing.Size(8, 8);
            this.ucHeaderBar1.TabIndex = 9;
            // 
            // HeaderBar
            // 
            this.HeaderBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(48)))), ((int)(((byte)(63)))));
            this.HeaderBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderBar.Location = new System.Drawing.Point(10, 0);
            this.HeaderBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.HeaderBar.Name = "HeaderBar";
            this.HeaderBar.Padding = new System.Windows.Forms.Padding(5);
            this.HeaderBar.Size = new System.Drawing.Size(866, 67);
            this.HeaderBar.TabIndex = 10;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.uCtrlSCDoctors, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.uCtrlSCAppointments, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.uCtrlSCPatients, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.uCtrlSCRevenue, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(10, 67);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.Padding = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(866, 244);
            this.tableLayoutPanel2.TabIndex = 11;
            // 
            // uCtrlSCDoctors
            // 
            this.uCtrlSCDoctors.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(70)))));
            this.uCtrlSCDoctors.Dock = System.Windows.Forms.DockStyle.Right;
            this.uCtrlSCDoctors.Location = new System.Drawing.Point(506, 13);
            this.uCtrlSCDoctors.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            this.uCtrlSCDoctors.Name = "uCtrlSCDoctors";
            this.uCtrlSCDoctors.Padding = new System.Windows.Forms.Padding(10);
            this.uCtrlSCDoctors.Size = new System.Drawing.Size(347, 89);
            this.uCtrlSCDoctors.TabIndex = 3;
            // 
            // uCtrlSCAppointments
            // 
            this.uCtrlSCAppointments.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(70)))));
            this.uCtrlSCAppointments.Dock = System.Windows.Forms.DockStyle.Left;
            this.uCtrlSCAppointments.Location = new System.Drawing.Point(13, 142);
            this.uCtrlSCAppointments.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.uCtrlSCAppointments.Name = "uCtrlSCAppointments";
            this.uCtrlSCAppointments.Padding = new System.Windows.Forms.Padding(10);
            this.uCtrlSCAppointments.Size = new System.Drawing.Size(347, 89);
            this.uCtrlSCAppointments.TabIndex = 1;
            // 
            // uCtrlSCPatients
            // 
            this.uCtrlSCPatients.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(70)))));
            this.uCtrlSCPatients.Dock = System.Windows.Forms.DockStyle.Left;
            this.uCtrlSCPatients.Location = new System.Drawing.Point(13, 13);
            this.uCtrlSCPatients.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            this.uCtrlSCPatients.Name = "uCtrlSCPatients";
            this.uCtrlSCPatients.Padding = new System.Windows.Forms.Padding(10);
            this.uCtrlSCPatients.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.uCtrlSCPatients.Size = new System.Drawing.Size(347, 89);
            this.uCtrlSCPatients.TabIndex = 0;
            // 
            // uCtrlSCRevenue
            // 
            this.uCtrlSCRevenue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(70)))));
            this.uCtrlSCRevenue.Dock = System.Windows.Forms.DockStyle.Right;
            this.uCtrlSCRevenue.Location = new System.Drawing.Point(506, 142);
            this.uCtrlSCRevenue.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.uCtrlSCRevenue.Name = "uCtrlSCRevenue";
            this.uCtrlSCRevenue.Padding = new System.Windows.Forms.Padding(10);
            this.uCtrlSCRevenue.Size = new System.Drawing.Size(347, 89);
            this.uCtrlSCRevenue.TabIndex = 2;
            // 
            // ucMainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.HeaderBar);
            this.Controls.Add(this.ucHeaderBar1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.flpCards);
            this.Name = "ucMainScreen";
            this.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.Size = new System.Drawing.Size(886, 742);
            this.Load += new System.EventHandler(this.ucMainScreen_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLatestAddedPatients)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpcomingAppointments)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flpCards;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLatestAddedPatients;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ucHeaderBar ucHeaderBar1;
        private ucHeaderBar HeaderBar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private ucStatsCard uCtrlSCPatients;
        private ucStatsCard uCtrlSCAppointments;
        private ucStatsCard uCtrlSCRevenue;
        private ucStatsCard uCtrlSCDoctors;
        private System.Windows.Forms.DataGridView dgvLatestAddedPatients;
        private System.Windows.Forms.DataGridView dgvUpcomingAppointments;
    }
}
