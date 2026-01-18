namespace ClinicManager_PresentationLayer
{
    partial class ucDashboardButton
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
            this.btnDashboard = new System.Windows.Forms.Button();
            this.pbIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDashboard
            // 
            this.btnDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Location = new System.Drawing.Point(55, 5);
            this.btnDashboard.Margin = new System.Windows.Forms.Padding(4);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnDashboard.Size = new System.Drawing.Size(183, 50);
            this.btnDashboard.TabIndex = 1;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.ctrlDashboardButton_Click);
            this.btnDashboard.MouseLeave += new System.EventHandler(this.ctrlDashboardButton_MouseLeave);
            this.btnDashboard.MouseHover += new System.EventHandler(this.ctrlDashboardButton_MouseHover);
            // 
            // pbIcon
            // 
            this.pbIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbIcon.Image = global::ClinicManager_PresentationLayer.Properties.Resources.download1;
            this.pbIcon.Location = new System.Drawing.Point(5, 5);
            this.pbIcon.Margin = new System.Windows.Forms.Padding(4);
            this.pbIcon.Name = "pbIcon";
            this.pbIcon.Size = new System.Drawing.Size(50, 50);
            this.pbIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbIcon.TabIndex = 0;
            this.pbIcon.TabStop = false;
            this.pbIcon.Click += new System.EventHandler(this.ctrlDashboardButton_Click);
            this.pbIcon.MouseLeave += new System.EventHandler(this.ctrlDashboardButton_MouseLeave);
            this.pbIcon.MouseHover += new System.EventHandler(this.ctrlDashboardButton_MouseHover);
            // 
            // ucDashboardButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(65)))));
            this.Controls.Add(this.btnDashboard);
            this.Controls.Add(this.pbIcon);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucDashboardButton";
            this.Padding = new System.Windows.Forms.Padding(5, 5, 0, 5);
            this.Size = new System.Drawing.Size(238, 60);
            this.Click += new System.EventHandler(this.ctrlDashboardButton_Click);
            this.MouseLeave += new System.EventHandler(this.ctrlDashboardButton_MouseLeave);
            this.MouseHover += new System.EventHandler(this.ctrlDashboardButton_MouseHover);
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbIcon;
        private System.Windows.Forms.Button btnDashboard;
    }
}
