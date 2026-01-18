using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ClinicManager_PresentationLayer
{
    public partial class ucBaseScreen : UserControl
    {
        public ucBaseScreen()
        {
            InitializeComponent();
        }

        public void CustomConfiguring(bool DeleteCMS = true,
            bool HideButtonAddNew = true)
        {
            if (DeleteCMS)
            {
                cmsData.Items.Clear();
            }
            if (HideButtonAddNew)
            {
                btnAddNew.Visible = false;
            }
        }

        public void ConfigureHeaderBar(string ScreenName)
        {
            HeaderBar.ConfigureScreenName(ScreenName);
        }

        public void ConfigureFilterBar(List<string> FeltringMethod)
        {
            FilterBar.ConfigureCMBFilter(FeltringMethod);
        }

        public void GeneralConfiguringFilterBar()
        {
            FilterBar.GeneralConfiguring();
        }

        public void ConfigureFilteringDoctors(List<string> Doctors)
        {
            FilterBar.FillCMBChooseDoctor(Doctors);
        }

        private void ucBaseScreen_Load(object sender, EventArgs e)
        {
            _ConfigureDGVData();
        }

        private void _ConfigureDGVData()
        {
            dgvMain.EnableHeadersVisualStyles = false;
            dgvMain.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(46, 58, 74);
            dgvMain.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvMain.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            dgvMain.DefaultCellStyle.SelectionBackColor = Color.FromArgb(60, 90, 120);
            dgvMain.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvMain.DefaultCellStyle.NullValue = "Unknown";
            dgvMain.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 242, 245);

            dgvMain.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMain.RowHeadersVisible = false;
            dgvMain.AllowUserToResizeRows = false;

            dgvMain.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMain.MultiSelect = false;
            dgvMain.ReadOnly = true;
            dgvMain.AllowUserToAddRows = false;
            dgvMain.AllowUserToDeleteRows = false;
            dgvMain.AllowUserToResizeColumns = true;
            dgvMain.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvMain.GridColor = Color.FromArgb(220, 220, 220);
        }

        public void ViewData(DataTable Data)
        {
            dgvMain.DataSource = Data.DefaultView;
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
        private void FilterBar_OnApplyFiltering(string arg1, string arg2, 
            string arg3)
        {
            string Input = arg1, FilteringMethod = arg2, ChoosedDoctor = arg3;
            if (OnApplyFiltering != null)
            {
                ApplyFiltering(Input, FilteringMethod, ChoosedDoctor);
            }
        }

        public event Action<string, string> OnClearFilteringResult;
        protected virtual void ClearFilteringResult(string AllFields,
            string AllDoctors = "All Doctors")
        {
            Action<string, string> Handler = OnClearFilteringResult;
            if (Handler != null)
            {
                Handler(AllFields, AllDoctors);
            }
        }
        private void FilterBar_OnClearFilteringResult(string arg1, string arg2)
        {
            string AllFields = arg1, AllDoctors = arg2;
            if (OnClearFilteringResult != null)
            {
                ClearFilteringResult(AllFields, AllDoctors);
            }
        }

        private void btnAddNew_MouseHover(object sender, EventArgs e)
        {
            btnAddNew.BackColor = Color.FromArgb(95, 162, 255);
        }

        public event Action OnAddNewButton;
        protected virtual void AddNewButton()
        {
            Action Handler = OnAddNewButton;
            if (Handler != null)
            {
                Handler();
            }
        }
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            if (OnAddNewButton != null)
            {
                AddNewButton();
            }
        }

        private void btnAddNew_MouseLeave(object sender, EventArgs e)
        {
            btnAddNew.BackColor = Color.FromArgb(58, 141, 255);
        }

        public event Action<int> OnEditRowSelected;
        protected virtual void EditRowSelected(int ID)
        {
            Action<int> Handler = OnEditRowSelected;
            if (Handler != null)
            {
                Handler(ID);
            }
        }
        public int GetID()
        {
            if(dgvMain.CurrentRow == null)
            {
                return -1;
            }
            return int.TryParse(dgvMain.CurrentRow.Cells[0].Value.ToString(),
                out int id) ? id : -1;
        }
        private void _editRowSelected()
        {
            if (OnEditRowSelected != null)
            {
                EditRowSelected(GetID());
            }
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _editRowSelected();
        }

        public event Action<int, string> OnRowSelected;
        protected virtual void RowSelected(int ID, string Name)
        {
            Action<int, string> Handler = OnRowSelected;
            if (Handler != null)
            {
                Handler(ID, Name);
            }
        }
        public string GetPersonName()
        {
            if (dgvMain.CurrentRow == null)
            {
                return string.Empty;
            }
            return dgvMain.CurrentRow.Cells[1].Value.ToString();
        }
        private void dgvMain_CellDoubleClick(object sender, 
            DataGridViewCellEventArgs e)
        {
            _editRowSelected();
            RowSelected(GetID(), GetPersonName());
        }

        public event Action<int> OnDeleteRowSelected;
        protected virtual void DeleteRowSelected(int ID)
        {
            Action<int> Handler = OnDeleteRowSelected;
            if (Handler != null)
            {
                Handler(ID);
            }
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(OnDeleteRowSelected != null)
            {
                DeleteRowSelected(GetID());
            }
        }
    }
}
