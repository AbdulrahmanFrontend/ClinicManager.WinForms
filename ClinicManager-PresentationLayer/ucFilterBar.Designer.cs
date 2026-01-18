namespace ClinicManager_PresentationLayer
{
    partial class ucFilterBar
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
            this.lblFilterBy = new System.Windows.Forms.Label();
            this.tlpFilterBar = new System.Windows.Forms.TableLayoutPanel();
            this.cbChooseDoctor = new System.Windows.Forms.ComboBox();
            this.cmbFilter = new System.Windows.Forms.ComboBox();
            this.tbInput = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.tlpFilterBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFilterBy
            // 
            this.lblFilterBy.AutoSize = true;
            this.lblFilterBy.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFilterBy.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilterBy.ForeColor = System.Drawing.Color.White;
            this.lblFilterBy.Location = new System.Drawing.Point(11, 10);
            this.lblFilterBy.Name = "lblFilterBy";
            this.lblFilterBy.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblFilterBy.Size = new System.Drawing.Size(78, 23);
            this.lblFilterBy.TabIndex = 0;
            this.lblFilterBy.Text = "Filter by:";
            // 
            // tlpFilterBar
            // 
            this.tlpFilterBar.AutoSize = true;
            this.tlpFilterBar.ColumnCount = 5;
            this.tlpFilterBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpFilterBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpFilterBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpFilterBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpFilterBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpFilterBar.Controls.Add(this.cbChooseDoctor, 2, 0);
            this.tlpFilterBar.Controls.Add(this.cmbFilter, 0, 0);
            this.tlpFilterBar.Controls.Add(this.tbInput, 1, 0);
            this.tlpFilterBar.Controls.Add(this.btnClear, 4, 0);
            this.tlpFilterBar.Controls.Add(this.btnApply, 3, 0);
            this.tlpFilterBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlpFilterBar.Location = new System.Drawing.Point(11, 37);
            this.tlpFilterBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tlpFilterBar.Name = "tlpFilterBar";
            this.tlpFilterBar.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.tlpFilterBar.RowCount = 1;
            this.tlpFilterBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFilterBar.Size = new System.Drawing.Size(1204, 39);
            this.tlpFilterBar.TabIndex = 1;
            // 
            // cbChooseDoctor
            // 
            this.cbChooseDoctor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbChooseDoctor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbChooseDoctor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbChooseDoctor.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbChooseDoctor.FormattingEnabled = true;
            this.cbChooseDoctor.Location = new System.Drawing.Point(723, 3);
            this.cbChooseDoctor.MaxDropDownItems = 4;
            this.cbChooseDoctor.Name = "cbChooseDoctor";
            this.cbChooseDoctor.Size = new System.Drawing.Size(232, 33);
            this.cbChooseDoctor.TabIndex = 2;
            // 
            // cmbFilter
            // 
            this.cmbFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilter.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFilter.FormattingEnabled = true;
            this.cmbFilter.Location = new System.Drawing.Point(8, 2);
            this.cmbFilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbFilter.MaxDropDownItems = 4;
            this.cmbFilter.Name = "cmbFilter";
            this.cmbFilter.Size = new System.Drawing.Size(232, 33);
            this.cmbFilter.TabIndex = 0;
            this.cmbFilter.SelectedIndexChanged += new System.EventHandler(this.cmbFilter_SelectedIndexChanged);
            // 
            // tbInput
            // 
            this.tbInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbInput.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInput.Location = new System.Drawing.Point(246, 2);
            this.tbInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbInput.Name = "tbInput";
            this.tbInput.Size = new System.Drawing.Size(471, 31);
            this.tbInput.TabIndex = 1;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(107)))), ((int)(((byte)(125)))));
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(1080, 2);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(116, 35);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            this.btnClear.MouseLeave += new System.EventHandler(this.btnClear_MouseLeave);
            this.btnClear.MouseHover += new System.EventHandler(this.btnClear_MouseHover);
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(141)))), ((int)(((byte)(255)))));
            this.btnApply.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnApply.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnApply.FlatAppearance.BorderSize = 0;
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApply.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApply.ForeColor = System.Drawing.Color.White;
            this.btnApply.Location = new System.Drawing.Point(961, 2);
            this.btnApply.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(113, 35);
            this.btnApply.TabIndex = 2;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            this.btnApply.MouseLeave += new System.EventHandler(this.btnApply_MouseLeave);
            this.btnApply.MouseHover += new System.EventHandler(this.btnApply_MouseHover);
            // 
            // ucFilterBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(58)))), ((int)(((byte)(74)))));
            this.Controls.Add(this.tlpFilterBar);
            this.Controls.Add(this.lblFilterBy);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ucFilterBar";
            this.Padding = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.Size = new System.Drawing.Size(1226, 86);
            this.tlpFilterBar.ResumeLayout(false);
            this.tlpFilterBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFilterBy;
        private System.Windows.Forms.TableLayoutPanel tlpFilterBar;
        private System.Windows.Forms.ComboBox cmbFilter;
        private System.Windows.Forms.TextBox tbInput;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ComboBox cbChooseDoctor;
    }
}
