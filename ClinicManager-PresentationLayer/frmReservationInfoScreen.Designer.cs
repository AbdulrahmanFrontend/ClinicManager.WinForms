namespace ClinicManager_PresentationLayer
{
    partial class frmReservationInfoScreen
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
            this.ReservationCard = new ClinicManager_PresentationLayer.ucReservationCard();
            ((System.ComponentModel.ISupportInitialize)(this.errorpInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // errorpInfo
            // 
            this.errorpInfo.ContainerControl = this;
            // 
            // FormActionButtons
            // 
            this.FormActionButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.FormActionButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FormActionButtons.Location = new System.Drawing.Point(0, 357);
            this.FormActionButtons.Name = "FormActionButtons";
            this.FormActionButtons.Padding = new System.Windows.Forms.Padding(10);
            this.FormActionButtons.Size = new System.Drawing.Size(1425, 77);
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
            this.HeaderBar.Size = new System.Drawing.Size(1425, 67);
            this.HeaderBar.TabIndex = 0;
            // 
            // ReservationCard
            // 
            this.ReservationCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(58)))), ((int)(((byte)(74)))));
            this.ReservationCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReservationCard.Location = new System.Drawing.Point(0, 67);
            this.ReservationCard.Name = "ReservationCard";
            this.ReservationCard.Padding = new System.Windows.Forms.Padding(10);
            this.ReservationCard.Size = new System.Drawing.Size(1425, 290);
            this.ReservationCard.TabIndex = 2;
            this.ReservationCard.OnSearchPatient += new System.Action(this.ReservationCard_OnSearchPatient);
            this.ReservationCard.OnSearchDoctor += new System.Action(this.ReservationCard_OnSearchDoctor);
            // 
            // frmReservationInfoScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1425, 434);
            this.Controls.Add(this.ReservationCard);
            this.Controls.Add(this.FormActionButtons);
            this.Controls.Add(this.HeaderBar);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1443, 481);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1443, 481);
            this.Name = "frmReservationInfoScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmReservationInfoScreen";
            ((System.ComponentModel.ISupportInitialize)(this.errorpInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ucHeaderBar HeaderBar;
        private ucFormActionButtons FormActionButtons;
        private System.Windows.Forms.ErrorProvider errorpInfo;
        private ucReservationCard ReservationCard;
    }
}
