namespace ClinicManager_PresentationLayer
{
    partial class frmPatientInfoScreen
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
            this.errorpInfo = new System.Windows.Forms.ErrorProvider(this.components);
            this.FormActionButtons = new ClinicManager_PresentationLayer.ucFormActionButtons();
            this.HeaderBar = new ClinicManager_PresentationLayer.ucHeaderBar();
            this.PatientCard = new ClinicManager_PresentationLayer.ucPatientCard();
            ((System.ComponentModel.ISupportInitialize)(this.errorpInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // errorpInfo
            // 
            this.errorpInfo.ContainerControl = this;
            // 
            // FormActionButtons
            // 
            this.FormActionButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(65)))));
            this.FormActionButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FormActionButtons.Location = new System.Drawing.Point(0, 401);
            this.FormActionButtons.Name = "FormActionButtons";
            this.FormActionButtons.Padding = new System.Windows.Forms.Padding(10);
            this.FormActionButtons.Size = new System.Drawing.Size(1209, 71);
            this.FormActionButtons.TabIndex = 1;
            this.FormActionButtons.OnCancelButton += new System.Action(this.FormActionButtons_OnCancelButton);
            this.FormActionButtons.OnSaveButton += new System.Action(this.FormActionButtons_OnSaveButton);
            this.FormActionButtons.OnDeleteButton += new System.Action(this.FormActionButtons_OnDeleteButton);
            // 
            // HeaderBar
            // 
            this.HeaderBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.HeaderBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderBar.Location = new System.Drawing.Point(0, 0);
            this.HeaderBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.HeaderBar.Name = "HeaderBar";
            this.HeaderBar.Padding = new System.Windows.Forms.Padding(5);
            this.HeaderBar.Size = new System.Drawing.Size(1209, 62);
            this.HeaderBar.TabIndex = 0;
            // 
            // PatientCard
            // 
            this.PatientCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(58)))), ((int)(((byte)(74)))));
            this.PatientCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PatientCard.Location = new System.Drawing.Point(0, 62);
            this.PatientCard.Name = "PatientCard";
            this.PatientCard.Padding = new System.Windows.Forms.Padding(10);
            this.PatientCard.Size = new System.Drawing.Size(1209, 339);
            this.PatientCard.TabIndex = 2;
            // 
            // frmPatientInfoScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(1209, 472);
            this.Controls.Add(this.PatientCard);
            this.Controls.Add(this.FormActionButtons);
            this.Controls.Add(this.HeaderBar);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1227, 519);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1227, 519);
            this.Name = "frmPatientInfoScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmPatientInfoScreen";
            ((System.ComponentModel.ISupportInitialize)(this.errorpInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ucHeaderBar HeaderBar;
        private ucFormActionButtons FormActionButtons;
        private System.Windows.Forms.ErrorProvider errorpInfo;
        private ucPatientCard PatientCard;
    }
}
