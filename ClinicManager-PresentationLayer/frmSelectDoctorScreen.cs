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
    public partial class frmSelectDoctorScreen : Form
    {
        private string _Input, _FilteringMethod = "All Fields";

        public frmSelectDoctorScreen()
        {
            InitializeComponent();
        }

        private void frmSelectDoctorScreen_Load(object sender, EventArgs e)
        {
            BaseScreen.ConfigureHeaderBar("Select Doctor Screen");
            BaseScreen.CustomConfiguring();
            BaseScreen.ConfigureFilterBar(_FiltringMethodsList());
            BaseScreen_OnApplyFiltering(_Input, _FilteringMethod);
        }

        private enum _EnFilteringMethods { enAllFields, enDoctorName }

        private Dictionary<_EnFilteringMethods, string> _FilteringMethodsDictionary
            = new Dictionary<_EnFilteringMethods, string>()
            {
                { _EnFilteringMethods.enAllFields, "All Fields" },
                { _EnFilteringMethods.enDoctorName, "Doctor Name" },
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
                    BaseScreen.ViewData(clsDoctor.GetAllDoctors());
                    break;
                case _EnFilteringMethods.enDoctorName:
                    BaseScreen.ViewData(clsDoctor.FilterByName(_Input));
                    break;
                default:
                    BaseScreen.ViewData(clsDoctor.GetAllDoctors());
                    break;
            }
        }

        private void BaseScreen_OnClearFilteringResult(string obj)
        {
            BaseScreen_OnApplyFiltering(_Input, _FilteringMethod);
        }

        public delegate void DataBackEventHandler(int DoctorID, string DoctorName);
        public event DataBackEventHandler BackDoctorInfoSelected;
        private void BaseScreen_OnRowSelected(int arg1, string arg2)
        {
            int DoctorID = arg1;
            string DoctorName = arg2;
            if (DoctorID != -1)
            {
                this.BackDoctorInfoSelected?.Invoke(DoctorID, DoctorName);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("This Doctor is not found!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                BaseScreen_OnApplyFiltering(_Input, _FilteringMethod);
            }
        }
    }
}
