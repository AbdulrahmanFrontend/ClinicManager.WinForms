using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicManager_PresentationLayer
{
    public partial class frmDashboard : Form
    {
        private UserControl _NewScreen;

        public frmDashboard()
        {
            InitializeComponent();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            _NewScreen = new ucMainScreen();
            ConfigureScreen();
        }

        private void SideBar_OnOpenScreen(string obj)
        {
            string ScreenName = obj;
            foreach (Control ctrl in pnlScreen.Controls)
            {
                ctrl.Dispose();
            }
            pnlScreen.Controls.Clear();
            switch (ScreenName)
            {
                case "Main Screen":
                    _NewScreen = new ucMainScreen();
                    break;
                case "Patients Screen":
                    _NewScreen = new ucPatientsScreen();
                    break;
                case "Doctors Screen":
                    _NewScreen = new ucDoctorsScreen();
                    break;
                case "Reservations Screen":
                    _NewScreen = new ucReservationsScreen();
                    break;
                case "Today's Appointments Screen":
                    _NewScreen = new ucTodayAppointmentsScreen();
                    break;
            }
            if (_NewScreen != null)
            {
                ConfigureScreen();
            }
        }

        private void ConfigureScreen()
        {
            _NewScreen.Dock = DockStyle.Fill;
            pnlScreen.Controls.Add(_NewScreen);
        }
    }
}
