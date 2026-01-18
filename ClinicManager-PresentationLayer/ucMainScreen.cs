using BusinessLayer;
using ClinicManager_PresentationLayer.Properties;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ClinicManager_PresentationLayer
{
    public partial class ucMainScreen : UserControl
    {
        private int _TotalPatients;
        private int _TotalDoctors;
        private int _TodayAppointments;
        private int _TodayRevenue;
        private DataView _UpcomingAppointments;
        private DataView _LatestAddedPatients;

        public ucMainScreen()
        {
            InitializeComponent();
            _TotalPatients = clsPatient.GetTotalPatients();
            _TotalDoctors = clsDoctor.GetTotalDoctors();
            _TodayAppointments = clsAppointment.GetTodayAppointmentsCount();
            _TodayRevenue = clsPayments.GetTotalTodayRevenue();
            _UpcomingAppointments = 
                clsAppointment.GetTopFiveTodayAppointments().DefaultView;
            _LatestAddedPatients = clsPatient.GetFromPatientsDetails().DefaultView;
        }

        private void ucMainScreen_Load(object sender, EventArgs e)
        {
            uCtrlSCPatients.Configure(Resources.download__2_, "Total Patients:", 
                _TotalPatients.ToString());
            uCtrlSCDoctors.Configure(Resources.download1, "Total Doctors:",
                _TotalDoctors.ToString());
            uCtrlSCAppointments.Configure(Resources.download__1_,
                "Today's Appointments:", _TodayAppointments.ToString());
            uCtrlSCRevenue.Configure(Resources.download__7_, "Today's Revenue:", 
                _TodayRevenue.ToString());
            HeaderBar.ConfigureScreenName("Dashboard");
            dgvUpcomingAppointments.DataSource = _UpcomingAppointments;
            dgvLatestAddedPatients.DataSource = _LatestAddedPatients;

            dgvLatestAddedPatients.EnableHeadersVisualStyles = false;
            dgvLatestAddedPatients.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(46, 58, 74);
            dgvLatestAddedPatients.ColumnHeadersDefaultCellStyle.ForeColor = 
                Color.White;
            dgvLatestAddedPatients.ColumnHeadersDefaultCellStyle.Font = 
                new Font("Segoe UI", 10, FontStyle.Bold);
            dgvLatestAddedPatients.DefaultCellStyle.SelectionBackColor = 
                Color.FromArgb(60, 90, 120);
            dgvLatestAddedPatients.DefaultCellStyle.SelectionForeColor = 
                Color.White;
            dgvLatestAddedPatients.DefaultCellStyle.NullValue = "Unknown";
            dgvLatestAddedPatients.AlternatingRowsDefaultCellStyle.BackColor = 
                Color.FromArgb(240, 242, 245);
            dgvLatestAddedPatients.AutoSizeColumnsMode = 
                DataGridViewAutoSizeColumnsMode.Fill;
            dgvLatestAddedPatients.RowHeadersVisible = false;
            dgvLatestAddedPatients.AllowUserToResizeRows = false;
            dgvLatestAddedPatients.SelectionMode = 
                DataGridViewSelectionMode.FullRowSelect;
            dgvLatestAddedPatients.MultiSelect = false;
            dgvLatestAddedPatients.ReadOnly = true;
            dgvLatestAddedPatients.AllowUserToAddRows = false;
            dgvLatestAddedPatients.AllowUserToDeleteRows = false;
            dgvLatestAddedPatients.AllowUserToResizeColumns = true;
            dgvLatestAddedPatients.CellBorderStyle = 
                DataGridViewCellBorderStyle.SingleHorizontal;
            dgvLatestAddedPatients.GridColor = Color.FromArgb(220, 220, 220);

            dgvUpcomingAppointments.EnableHeadersVisualStyles = false;
            dgvUpcomingAppointments.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(46, 58, 74);
            dgvUpcomingAppointments.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;
            dgvUpcomingAppointments.ColumnHeadersDefaultCellStyle.Font = 
                new Font("Segoe UI", 10, FontStyle.Bold);
            dgvUpcomingAppointments.DefaultCellStyle.SelectionBackColor = 
                Color.FromArgb(60, 90, 120);
            dgvUpcomingAppointments.DefaultCellStyle.SelectionForeColor = 
                Color.White;
            dgvUpcomingAppointments.DefaultCellStyle.NullValue = "Unknown";
            dgvUpcomingAppointments.AlternatingRowsDefaultCellStyle.BackColor = 
                Color.FromArgb(240, 242, 245);
            dgvUpcomingAppointments.AutoSizeColumnsMode = 
                DataGridViewAutoSizeColumnsMode.Fill;
            dgvUpcomingAppointments.RowHeadersVisible = false;
            dgvUpcomingAppointments.AllowUserToResizeRows = false;
            dgvUpcomingAppointments.SelectionMode = 
                DataGridViewSelectionMode.FullRowSelect;
            dgvUpcomingAppointments.MultiSelect = false;
            dgvUpcomingAppointments.ReadOnly = true;
            dgvUpcomingAppointments.AllowUserToAddRows = false;
            dgvUpcomingAppointments.AllowUserToDeleteRows = false;
            dgvUpcomingAppointments.AllowUserToResizeColumns = true;
            dgvUpcomingAppointments.CellBorderStyle = 
                DataGridViewCellBorderStyle.SingleHorizontal;
            dgvUpcomingAppointments.GridColor = Color.FromArgb(220, 220, 220);
        }
    }
}
