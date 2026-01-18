namespace ClinicManager_PresentationLayer
{
    partial class frmSelectDoctorScreen
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
            this.BaseScreen = new ClinicManager_PresentationLayer.ucBaseScreen();
            this.SuspendLayout();
            // 
            // BaseScreen
            // 
            this.BaseScreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.BaseScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BaseScreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BaseScreen.Location = new System.Drawing.Point(0, 0);
            this.BaseScreen.Name = "BaseScreen";
            this.BaseScreen.Padding = new System.Windows.Forms.Padding(11, 0, 11, 0);
            this.BaseScreen.Size = new System.Drawing.Size(882, 643);
            this.BaseScreen.TabIndex = 0;
            this.BaseScreen.OnRowSelected += new System.Action<int, string>(this.BaseScreen_OnRowSelected);
            // 
            // frmSelectDoctorScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(882, 653);
            this.Controls.Add(this.BaseScreen);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(900, 700);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(900, 700);
            this.Name = "frmSelectDoctorScreen";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmSelectDoctorScreen";
            this.Load += new System.EventHandler(this.frmSelectDoctorScreen_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ucBaseScreen BaseScreen;
    }
}
