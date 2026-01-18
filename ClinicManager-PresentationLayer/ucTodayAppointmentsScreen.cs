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
    public partial class ucTodayAppointmentsScreen : UserControl
    {
        private string _Input, _FilterByDoctors = "All Doctors",
            _FilteringMethod = "All Fields";

        public ucTodayAppointmentsScreen()
        {
            InitializeComponent();
        }

        private void ucTodayAppointmentsScreen_Load(object sender, EventArgs e)
        {
            BaseScreen.ConfigureHeaderBar("Today's Appointments Screen");
            BaseScreen.ConfigureFilterBar(_FiltringMethodsList());
            List<string> list = clsDoctor.GetDoctorsList();
            list.Add("All Doctors");
            BaseScreen.ConfigureFilteringDoctors(list);
            BaseScreen.CustomConfiguring();
            BaseScreen_OnApplyFiltering(_Input, _FilteringMethod, _FilterByDoctors);
        }

        private enum _EnFilteringMethods
        {
            enAllFields, enPatientName, enDoctorName, enStatus
        }

        private Dictionary<_EnFilteringMethods, string> _FilteringMethodsDictionary
            = new Dictionary<_EnFilteringMethods, string>()
            {
                { _EnFilteringMethods.enAllFields, "All Fields" },
                { _EnFilteringMethods.enPatientName, "Patient Name" },
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
            if (arg3 != "All Doctors")
            {
                List<string> ArgsList = arg3.Split(' ').ToList();
                ArgsList.RemoveAt(0);
                _FilterByDoctors = ArgsList[0];
            }
            else
            {
                _FilterByDoctors = "All Doctors";
            }
            DataTable dtTodayAppointments = new DataTable();
            if (_FilterByDoctors == "All Doctors")
            {
                dtTodayAppointments = clsAppointment.GetAllTodayAppointments();
            }
            else
            {
                if (!string.IsNullOrEmpty(_FilterByDoctors))
                {
                    dtTodayAppointments = clsAppointment.
                        FilterTodayAppointmentsByDoctorName(_FilterByDoctors);
                }
            }
            DataView dvTodayAppointments = dtTodayAppointments.DefaultView;
            if (!string.IsNullOrEmpty(_Input))
            {
                switch (_FilteringMethodName(_FilteringMethod))
                {
                    case _EnFilteringMethods.enAllFields:
                        break;
                    case _EnFilteringMethods.enPatientName:
                        if(dtTodayAppointments.Columns.Contains("PatientName"))
                        {
                            dvTodayAppointments.RowFilter =
                                string.Format("[PatientName] Like '{0}%'", _Input);
                        }
                        break;
                    case _EnFilteringMethods.enStatus:
                        if (dtTodayAppointments.Columns.Contains("Status"))
                        {
                            dvTodayAppointments.RowFilter =
                                string.Format("[Status] Like '{0}%'", _Input);
                        }
                        break;
                    default:
                        break;
                }
            }
            else
            {
                dvTodayAppointments.RowFilter = string.Format("");
            }
            BaseScreen.ViewData(dvTodayAppointments.ToTable());
        }

        private void BaseScreen_OnEditRowSelected(int obj)
        {
            int AppointmentID = obj;
            if (clsAppointment.IsAppointmentExist(AppointmentID))
            {
                frmEditTodayAppointmentScreen frm =
                    new frmEditTodayAppointmentScreen(AppointmentID);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("The selected reservation does not exist.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            BaseScreen_OnApplyFiltering(_Input, _FilteringMethod, _FilterByDoctors);
        }

        private void BaseScreen_OnClearFilteringResult(string arg1, string arg2)
        {
            _FilteringMethod = arg1;
            _FilterByDoctors = arg2;
            BaseScreen_OnApplyFiltering(_Input, _FilteringMethod, _FilterByDoctors);
        }
    }
}
