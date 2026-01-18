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
    public partial class frmSelectPatientScreen : Form
    {
        private string _Input, _FilteringMethod = "All Fields";

        public frmSelectPatientScreen()
        {
            InitializeComponent();
        }

        private void frmSelectPatient_Load(object sender, EventArgs e)
        {
            BaseScreen.ConfigureHeaderBar("Select Patient Screen");
            BaseScreen.CustomConfiguring();
            BaseScreen.ConfigureFilterBar(_FiltringMethodsList());
            BaseScreen_OnApplyFiltering(_Input, _FilteringMethod);
        }

        private enum _EnFilteringMethods { enAllFields, enPatientName }

        private Dictionary<_EnFilteringMethods, string> _FilteringMethodsDictionary
            = new Dictionary<_EnFilteringMethods, string>()
            {
                { _EnFilteringMethods.enAllFields, "All Fields" },
                { _EnFilteringMethods.enPatientName, "Patient Name" },
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

        private void BaseScreen_OnApplyFiltering(string arg1, string arg2)
        {
            _Input = arg1;
            _FilteringMethod = arg2;
            switch (_FilteringMethodName(_FilteringMethod))
            {
                case _EnFilteringMethods.enAllFields:
                    BaseScreen.ViewData(clsPatient.GetAllPatients());
                    break;
                case _EnFilteringMethods.enPatientName:
                    BaseScreen.ViewData(clsPatient.FilterByName(_Input));
                    break;
                default:
                    BaseScreen.ViewData(clsPatient.GetAllPatients());
                    break;
            }
        }

        private void BaseScreen_OnClearFilteringResult(string obj)
        {
            BaseScreen_OnApplyFiltering(_Input, _FilteringMethod);
        }

        public delegate void DataBackEventHandler(int PatientID, string PatientName);
        public event DataBackEventHandler BackPatientInfoSelected;
        private void BaseScreen_OnRowSelected(int arg1, string arg2)
        {
            int PatientID = arg1;
            string PatientName = arg2;
            if (PatientID != -1)
            {
                this.BackPatientInfoSelected?.Invoke(PatientID, PatientName);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("This Patient is not found!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                BaseScreen_OnApplyFiltering(_Input, _FilteringMethod);
            }
        }
    }
}
