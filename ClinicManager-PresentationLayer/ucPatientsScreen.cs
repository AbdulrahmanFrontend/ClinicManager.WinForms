using BusinessLayer;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ClinicManager_PresentationLayer
{
    public partial class ucPatientsScreen : UserControl
    {
        private string _Input, _FilteringMethod = "All Fields";

        public ucPatientsScreen()
        {
            InitializeComponent();
        }

        private void ucPatientsScreen_Load(object sender, EventArgs e)
        {
            BaseScreen.ConfigureHeaderBar("Patients Screen");
            BaseScreen.ConfigureFilterBar(_FiltringMethodsList());
            BaseScreen.GeneralConfiguringFilterBar();
            BaseScreen_OnApplyFiltering(_Input, _FilteringMethod, "");
        }

        private enum _EnFilteringMethods
        {
            enAllFields, enName, enPhone, enGender, enBirthDateFromYear,
            enBirthDateYear, enAddress, enEmail
        }

        private Dictionary<_EnFilteringMethods, string> _FilteringMethodsDictionary
            = new Dictionary<_EnFilteringMethods, string>()
            {
                { _EnFilteringMethods.enAllFields, "All Fields" },
                { _EnFilteringMethods.enName, "Name" },
                { _EnFilteringMethods.enPhone, "Phone" },
                { _EnFilteringMethods.enGender, "Gender" },
                { _EnFilteringMethods.enBirthDateFromYear, "Birth Date From Year" },
                { _EnFilteringMethods.enBirthDateYear, "Birth Date Year" },
                { _EnFilteringMethods.enAddress, "Address" },
                { _EnFilteringMethods.enEmail, "Email" }
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
                    BaseScreen.ViewData(clsPatient.GetAllPatients());
                    break;
                case _EnFilteringMethods.enName:
                    BaseScreen.ViewData(clsPatient.FilterByName(_Input));
                    break;
                case _EnFilteringMethods.enPhone:
                    BaseScreen.ViewData(clsPatient.FilterByPhone(_Input));
                    break;
                case _EnFilteringMethods.enGender:
                    _Input = _Input?.ToUpper();
                    if (_Input != "F" && _Input != "M")
                    {
                        _Input = null;
                    }
                    BaseScreen.ViewData(clsPatient.FilterByGender(_Input));
                    break;
                case _EnFilteringMethods.enBirthDateFromYear:
                    if (!int.TryParse(_Input, out int FromYear))
                    {
                        MessageBox.Show("Error: Enter valid year.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    DateTime? BirthDateFromYear = new DateTime(FromYear, 1, 1);
                    BaseScreen.ViewData(
                        clsPatient.FilterByBirthDateFrom(BirthDateFromYear)
                        );
                    break;
                case _EnFilteringMethods.enBirthDateYear:
                    if (!int.TryParse(_Input, out int Year))
                    {
                        MessageBox.Show("Error: Enter valid year.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    DateTime? BirthDateFrom = new DateTime(Year, 1, 1);
                    DateTime? BirthDateTo = new DateTime(Year, 12, 31);
                    BaseScreen.ViewData(
                        clsPatient.FilterByBirthDateYear(BirthDateFrom, BirthDateTo)
                        );
                    break;
                case _EnFilteringMethods.enAddress:
                    BaseScreen.ViewData(clsPatient.FilterByAddress(_Input));
                    break;
                case _EnFilteringMethods.enEmail:
                    BaseScreen.ViewData(clsPatient.FilterByEmail(_Input));
                    break;
                default:
                    BaseScreen.ViewData(clsPatient.GetAllPatients());
                    break;
            }
        }

        private void BaseScreen_AddButtonClicked()
        {
            frmPatientInfoScreen frm = new frmPatientInfoScreen();
            if(frm.ShowDialog() == DialogResult.OK)
            {
                BaseScreen_OnApplyFiltering(_Input, _FilteringMethod, "");
            }
        }

        private void BaseScreen_OnEditRowSelected(int obj)
        {
            int PatientID = obj;
            if (clsPatient.IsPatientExist(PatientID))
            {
                frmPatientInfoScreen frm = new frmPatientInfoScreen(PatientID);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("The selected patient does not exist.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            BaseScreen_OnApplyFiltering(_Input, _FilteringMethod, "");
        }

        private void BaseScreen_OnDeleteRowSelected(int obj)
        {
            int PatientID = obj;
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this patient?", "Confirm Deletion", 
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
            {
                bool isDeleted = clsPatientServices.DeletePatient(PatientID);
                if (isDeleted)
                {
                    MessageBox.Show("Patient deleted successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to delete the patient.", "Error",
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
