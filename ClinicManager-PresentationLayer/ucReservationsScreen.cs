using BusinessLayer;
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
    public partial class ucReservationsScreen : UserControl
    {
        private string _Input, _FilteringMethod = "All Fields";

        public ucReservationsScreen()
        {
            InitializeComponent();
        }

        private void ucAppointmentsScreen_Load(object sender, EventArgs e)
        {
            BaseScreen.ConfigureHeaderBar("Reservations Screen");
            BaseScreen.ConfigureFilterBar(_FiltringMethodsList());
            BaseScreen.GeneralConfiguringFilterBar();
            BaseScreen_OnApplyFiltering(_Input, _FilteringMethod, "");
        }

        private enum _EnFilteringMethods
        {
            enAllFields, enPatientName, enDoctorName, enDate, enStatus
        }

        private Dictionary<_EnFilteringMethods, string> _FilteringMethodsDictionary
            = new Dictionary<_EnFilteringMethods, string>()
            {
                { _EnFilteringMethods.enAllFields, "All Fields" },
                { _EnFilteringMethods.enPatientName, "Patient Name" },
                { _EnFilteringMethods.enDoctorName, "Doctor Name" },
                { _EnFilteringMethods.enDate, "Date (__/__/____)" },
                { _EnFilteringMethods.enStatus, "Status" },
            };

        private _EnFilteringMethods _FilteringMethodName(string FilteringMethod)
        {
            foreach (KeyValuePair<_EnFilteringMethods, string> Pair in
                _FilteringMethodsDictionary)
            {
                if (Pair.Value == FilteringMethod)
                {
                    return Pair.Key;
                }
            }
            return _EnFilteringMethods.enAllFields;
        }

        private List<string> _FiltringMethodsList()
        {
            List<string> FMList = new List<string>();
            foreach (KeyValuePair<_EnFilteringMethods, string> Pair in
                _FilteringMethodsDictionary)
            {
                FMList.Add(Pair.Value);
            }
            return FMList;
        }

        private void BaseScreen_OnApplyFiltering(string arg1, string arg2, 
            string arg3)
        {
            _Input = arg1;
            _FilteringMethod = arg2;
            switch (_FilteringMethodName(_FilteringMethod))
            {
                case _EnFilteringMethods.enAllFields:
                    BaseScreen.ViewData(clsAppointment.GetAllReservations());
                    break;
                case _EnFilteringMethods.enPatientName:
                    BaseScreen.ViewData(
                        clsAppointment.FilterReservationsByPatientName(_Input)
                        );
                    break;
                case _EnFilteringMethods.enDoctorName:
                    BaseScreen.ViewData(
                        clsAppointment.FilterReservationsByDoctorName(_Input)
                        );
                    break;
                case _EnFilteringMethods.enDate:
                    if (!DateTime.TryParse(_Input, out DateTime DateTo))
                    {
                        MessageBox.Show("Error: Enter valid Date.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    DateTime? DateFrom = DateTo.Date.AddDays(-1);
                    BaseScreen.ViewData(
                        clsAppointment.FilterReservationsByDate(DateFrom, DateTo)
                        );
                    break;
                case _EnFilteringMethods.enStatus:
                    BaseScreen.ViewData(
                        clsAppointment.FilterReservationsByStatus(_Input)
                        );
                    break;
                default:
                    BaseScreen.ViewData(clsAppointment.GetAllReservations());
                    break;
            }
        }

        private void BaseScreen_AddButtonClicked()
        {
            frmReservationInfoScreen frm = new frmReservationInfoScreen();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                BaseScreen_OnApplyFiltering(_Input, _FilteringMethod, "");
            }
        }

        private void BaseScreen_OnEditRowSelected(int obj)
        {
            int AppointmentID = obj;
            if (clsAppointment.IsAppointmentExist(AppointmentID))
            {
                frmReservationInfoScreen frm = 
                    new frmReservationInfoScreen(AppointmentID);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("The selected appointment does not exist.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            BaseScreen_OnApplyFiltering(_Input, _FilteringMethod, "");
        }

        private void BaseScreen_OnDeleteRowSelected(int obj)
        {
            int AppointmentID = obj;
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this reservation?",
                "Confirm Deletion", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
            {
                bool isDeleted = 
                    clsAppointmentServices.DeleteAppointment(AppointmentID);
                if (isDeleted)
                {
                    MessageBox.Show("Appointment deleted successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to delete the appointment.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                BaseScreen_OnApplyFiltering(_Input, _FilteringMethod, "");
            }
        }

        private void BaseScreen_OnClearFilteringResult(string arg1, string arg2)
        {
            _FilteringMethod = arg1;
            BaseScreen_OnApplyFiltering(_Input, _FilteringMethod, "");
        }
    }
}
