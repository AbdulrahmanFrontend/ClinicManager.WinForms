namespace ClinicManager_PresentationLayer
{
    partial class frmEditTodayAppointmentScreen
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
            this.FormActionButtons = new ClinicManager_PresentationLayer.ucFormActionButtons();
            this.HeaderBar = new ClinicManager_PresentationLayer.ucHeaderBar();
            this.TodayAppointmentCard = new ClinicManager_PresentationLayer.ucTodayAppointmentCard();
            this.SuspendLayout();
            // 
            // FormActionButtons
            // 
            this.FormActionButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.FormActionButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FormActionButtons.Location = new System.Drawing.Point(0, 546);
            this.FormActionButtons.Name = "FormActionButtons";
            this.FormActionButtons.Padding = new System.Windows.Forms.Padding(10);
            this.FormActionButtons.Size = new System.Drawing.Size(1303, 77);
            this.FormActionButtons.TabIndex = 1;
            this.FormActionButtons.OnCancelButton += new System.Action(this.FormActionButtons_OnCancelButton);
            this.FormActionButtons.OnSaveButton += new System.Action(this.FormActionButtons_OnSaveButton);
            // 
            // HeaderBar
            // 
            this.HeaderBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(48)))), ((int)(((byte)(63)))));
            this.HeaderBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderBar.Location = new System.Drawing.Point(0, 0);
            this.HeaderBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.HeaderBar.Name = "HeaderBar";
            this.HeaderBar.Padding = new System.Windows.Forms.Padding(5);
            this.HeaderBar.Size = new System.Drawing.Size(1303, 67);
            this.HeaderBar.TabIndex = 0;
            // 
            // TodayAppointmentCard
            // 
            this.TodayAppointmentCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.TodayAppointmentCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TodayAppointmentCard.Location = new System.Drawing.Point(0, 67);
            this.TodayAppointmentCard.Name = "TodayAppointmentCard";
            this.TodayAppointmentCard.Padding = new System.Windows.Forms.Padding(10);
            this.TodayAppointmentCard.Size = new System.Drawing.Size(1303, 479);
            this.TodayAppointmentCard.TabIndex = 2;
            this.TodayAppointmentCard.OnSelectedNewStatus += new System.Action<string>(this.TodayAppointmentCard_OnSelectedNewStatus);
            // 
            // frmEditTodayAppointmentScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1303, 623);
            this.Controls.Add(this.TodayAppointmentCard);
            this.Controls.Add(this.FormActionButtons);
            this.Controls.Add(this.HeaderBar);
            this.Name = "frmEditTodayAppointmentScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmEditTodayAppointmentScreen";
            this.Load += new System.EventHandler(this.frmEditTodayAppointmentScreen_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ucHeaderBar HeaderBar;
        private ucFormActionButtons FormActionButtons;
        private ucTodayAppointmentCard TodayAppointmentCard;
    }
}
