namespace ClinicManager_PresentationLayer
{
    partial class frmDoctorInfoScreen
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
            this.FormActionButtons = new ClinicManager_PresentationLayer.ucFormActionButtons();
            this.HeaderBar = new ClinicManager_PresentationLayer.ucHeaderBar();
            this.DoctorCard = new ClinicManager_PresentationLayer.ucDoctorCard();
            this.errorpInfo = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorpInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // FormActionButtons
            // 
            this.FormActionButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.FormActionButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FormActionButtons.Location = new System.Drawing.Point(0, 484);
            this.FormActionButtons.Name = "FormActionButtons";
            this.FormActionButtons.Padding = new System.Windows.Forms.Padding(10);
            this.FormActionButtons.Size = new System.Drawing.Size(1223, 77);
            this.FormActionButtons.TabIndex = 1;
            this.FormActionButtons.OnCancelButton += new System.Action(this.FormActionButtons_OnCancelButton);
            this.FormActionButtons.OnSaveButton += new System.Action(this.FormActionButtons_OnSaveButton);
            this.FormActionButtons.OnDeleteButton += new System.Action(this.FormActionButtons_OnDeleteButton);
            // 
            // HeaderBar
            // 
            this.HeaderBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(48)))), ((int)(((byte)(63)))));
            this.HeaderBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderBar.Location = new System.Drawing.Point(0, 0);
            this.HeaderBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.HeaderBar.Name = "HeaderBar";
            this.HeaderBar.Padding = new System.Windows.Forms.Padding(5);
            this.HeaderBar.Size = new System.Drawing.Size(1223, 67);
            this.HeaderBar.TabIndex = 0;
            // 
            // DoctorCard
            // 
            this.DoctorCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(58)))), ((int)(((byte)(74)))));
            this.DoctorCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DoctorCard.Location = new System.Drawing.Point(0, 67);
            this.DoctorCard.Name = "DoctorCard";
            this.DoctorCard.Padding = new System.Windows.Forms.Padding(10);
            this.DoctorCard.Size = new System.Drawing.Size(1223, 417);
            this.DoctorCard.TabIndex = 2;
            // 
            // errorpInfo
            // 
            this.errorpInfo.ContainerControl = this;
            // 
            // frmDoctorInfoScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1223, 561);
            this.Controls.Add(this.DoctorCard);
            this.Controls.Add(this.FormActionButtons);
            this.Controls.Add(this.HeaderBar);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1241, 608);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1241, 608);
            this.Name = "frmDoctorInfoScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmDoctorInfoScreen";
            ((System.ComponentModel.ISupportInitialize)(this.errorpInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ucHeaderBar HeaderBar;
        private ucFormActionButtons FormActionButtons;
        private ucDoctorCard DoctorCard;
        private System.Windows.Forms.ErrorProvider errorpInfo;
    }
}
