using ClinicManager_PresentationLayer.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClinicManager_PresentationLayer
{
    public partial class ucSideBar : UserControl
    {
        public ucSideBar()
        {
            InitializeComponent();
        }
        private void ucSideBar_Load(object sender, EventArgs e)
        {
            _SetActiveButton(uCtrlDashBtnMain);
            uCtrlDashBtnMain.Configure(Resources.download__6_, "Dashboard");
            uCtrlDashBtnPatients.Configure(Resources.download__2_, "Patients");
            uCtrlDashBtnDoctors.Configure(Resources.download1, "Doctors");
            uCtrlDashBtnAppointments.Configure(Resources.download__1_, "Reservations");
            uCtrlDashBtnPayments.Configure(Resources.download__7_,
                "Today's Appointments");
            uCtrlDashBtnMedicalRecords.Configure(Resources.download__8_,
                "Medical Records");
        }

        private ucDashboardButton _ActiveDashboardButton;
        private void _SetActiveButton(ucDashboardButton dashbButton)
        {
            if (_ActiveDashboardButton != null)
            {
                _ActiveDashboardButton.BackColor = Color.FromArgb(40, 50, 65);
            }
            _ActiveDashboardButton = dashbButton;
            _ActiveDashboardButton.BackColor = Color.FromArgb(60, 90, 120);
        }
        private void DashboardButton_MouseHover(object obj)
        {
            if ((ucDashboardButton)obj == _ActiveDashboardButton)
            {
                return;
            }
            ((ucDashboardButton)obj).BackColor = Color.FromArgb(50, 60, 75);
        }

        public event Action<string> OnOpenScreen;
        protected virtual void OpenScreen(string ScreenName)
        {
            Action<string> Handler = OnOpenScreen;
            if (OnOpenScreen != null)
            {
                Handler(ScreenName);
            }
        }
        private void DashboardButton_Click(object obj)
        {
            if ((ucDashboardButton)obj == _ActiveDashboardButton)
            {
                return;
            }
            _SetActiveButton((ucDashboardButton)obj);
            if (OnOpenScreen != null)
            {
                OpenScreen(((ucDashboardButton)obj).Tag.ToString());
            }
        }

        private void DashboardButton_MouseLeave(object obj)
        {
            if ((ucDashboardButton)obj == _ActiveDashboardButton)
            {
                return;
            }
            ((ucDashboardButton)obj).BackColor = Color.FromArgb(40, 50, 65);
        }
    }
}
