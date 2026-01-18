using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Forms;

namespace ClinicManager_PresentationLayer
{
    public partial class ucFilterBar : UserControl
    {
        public ucFilterBar()
        {
            InitializeComponent();
        }

        public void ConfigureCMBFilter(List<string> Items)
        {
            cmbFilter.Items.Clear();
            if(Items.Count > 0)
            {
                foreach (string item in Items)
                {
                    cmbFilter.Items.Add(item);
                }
                if(cmbFilter.Items.Contains("All Fields"))
                {
                    cmbFilter.SelectedItem = "All Fields";
                }
            }
            _MakeInputEnabled();
        }

        private void _MakeInputEnabled()
        {
            if (cmbFilter.SelectedItem.ToString() != "All Fields")
            {
                tbInput.Enabled = true;
            }
            else
            {
                tbInput.Enabled = false;
                tbInput.Text = "";
            }
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _MakeInputEnabled();
        }

        public void GeneralConfiguring()
        {
            Control OldControl = tlpFilterBar.GetControlFromPosition(2, 0);
            OldControl.Visible = true;
            tlpFilterBar.ColumnStyles[2] = new ColumnStyle(SizeType.Percent, 0f);
        }

        public void FillCMBChooseDoctor(List<string> DoctorsList)
        {
            cbChooseDoctor.Items.Clear();
            if(DoctorsList.Count > 0)
            {
                foreach (string Doctor in DoctorsList)
                {
                    cbChooseDoctor.Items.Add(Doctor);
                }
                if(cbChooseDoctor.Items.Contains("All Doctors"))
                {
                    cbChooseDoctor.SelectedItem = "All Doctors";
                }
            }
        }

        private void btnApply_MouseHover(object sender, EventArgs e)
        {
            btnApply.BackColor = Color.FromArgb(8, 58, 141, 255);
        }

        public event Action<string, string, string> OnApplyFiltering;
        protected virtual void ApplyFiltering(string Input, string FilteringMethod,
            string ChoosedDoctor = "All Doctors")
        {
            Action<string, string, string> Handler = OnApplyFiltering;
            if (Handler != null)
            {
                Handler(Input, FilteringMethod, ChoosedDoctor);
            }
        }
        private void btnApply_Click(object sender, EventArgs e)
        {
            if (OnApplyFiltering != null)
            {
                if (cbChooseDoctor.Items.Count > 0)
                {
                    ApplyFiltering(tbInput.Text.Trim(), 
                        cmbFilter.SelectedItem.ToString(),
                        cbChooseDoctor.SelectedItem.ToString());
                }
                else
                {
                    ApplyFiltering(tbInput.Text.Trim(), 
                        cmbFilter.SelectedItem.ToString(), string.Empty);
                }
            }
        }

        private void btnApply_MouseLeave(object sender, EventArgs e)
        {
            btnApply.BackColor = Color.FromArgb(58, 141, 255);
        }

        private void btnClear_MouseHover(object sender, EventArgs e)
        {
            btnClear.BackColor = Color.FromArgb(8, 90, 107, 125);
        }

        public event Action<string, string> OnClearFilteringResult;
        protected virtual void ClearFilteringResult(string AllFields,
            string AllDoctors = "All Doctors")
        {
            Action<string, string> Handler = OnClearFilteringResult;
            if(Handler != null)
            {
                Handler(AllFields, AllDoctors);
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            if (cbChooseDoctor.Items.Count > 0)
            {
                cbChooseDoctor.SelectedItem = "All Doctors";
            }
            cmbFilter.SelectedItem = "All Fields";
            _MakeInputEnabled();
            if (OnClearFilteringResult != null)
            {
                if (cbChooseDoctor.Items.Count > 0)
                {
                    ApplyFiltering(tbInput.Text.Trim(),
                        cmbFilter.SelectedItem.ToString(),
                        cbChooseDoctor.SelectedItem.ToString());
                }
                else
                {
                    ApplyFiltering(tbInput.Text.Trim(),
                        cmbFilter.SelectedItem.ToString(), string.Empty);
                }
            }
        }

        private void btnClear_MouseLeave(object sender, EventArgs e)
        {
            btnClear.BackColor = Color.FromArgb(90, 107, 125);
        }
    }
}
