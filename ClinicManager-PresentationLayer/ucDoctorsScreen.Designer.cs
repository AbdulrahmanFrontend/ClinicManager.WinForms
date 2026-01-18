namespace ClinicManager_PresentationLayer
{
    partial class ucDoctorsScreen
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
            this.BaseScreen = new ClinicManager_PresentationLayer.ucBaseScreen();
            this.SuspendLayout();
            // 
            // BaseScreen
            // 
            this.BaseScreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.BaseScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BaseScreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BaseScreen.Location = new System.Drawing.Point(10, 0);
            this.BaseScreen.Name = "BaseScreen";
            this.BaseScreen.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.BaseScreen.Size = new System.Drawing.Size(959, 743);
            this.BaseScreen.TabIndex = 0;
            this.BaseScreen.OnApplyFiltering += new System.Action<string, string, string>(this.BaseScreen_OnApplyFiltering);
            this.BaseScreen.OnClearFilteringResult += new System.Action<string, string>(this.BaseScreen_OnClearFilteringResult);
            this.BaseScreen.OnAddNewButton += new System.Action(this.BaseScreen_AddButtonClicked);
            this.BaseScreen.OnEditRowSelected += new System.Action<int>(this.BaseScreen_OnEditRowSelected);
            this.BaseScreen.OnDeleteRowSelected += new System.Action<int>(this.BaseScreen_OnDeleteRowSelected);
            // 
            // ucDoctorsScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.Controls.Add(this.BaseScreen);
            this.Name = "ucDoctorsScreen";
            this.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.Size = new System.Drawing.Size(979, 743);
            this.Load += new System.EventHandler(this.ucDoctorsScreen_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ucBaseScreen BaseScreen;
    }
}
