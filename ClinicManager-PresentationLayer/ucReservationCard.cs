using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ClinicManager_PresentationLayer
{
    public partial class ucReservationCard : UserControl
    {
        public ucReservationCard()
        {
            InitializeComponent();
        }

        public DateTimePicker DateTimePackerDateTime
        {
            get
            {
                return dtpAppointmentDateTime;
            }
        }
        public ComboBox ComboBoxStatus
        {
            get
            {
                return cbNewStatus;
            }
        }
        public TextBox TextBoxSearchPatient
        {
            get
            {
                return tbSearchPatient;
            }
        }
        public TextBox TextBoxSearchDoctor
        {
            get
            {
                return tbSearchDoctor;
            }
        }

        public void GetStatusList(List<string> StatusList)
        {
            cbNewStatus.Items.Clear();
            if (StatusList.Count > 0)
            {
                foreach (string Status in StatusList)
                {
                    cbNewStatus.Items.Add(Status);
                }
                cbNewStatus.SelectedIndex = 0;
            }
        }

        public void GetAppointmentTypesList(List<string> AppointmentTypeList)
        {
            cbAppointmentType.Items.Clear();
            if (AppointmentTypeList.Count > 0)
            {
                foreach (string AppointmentType in AppointmentTypeList)
                {
                    cbAppointmentType.Items.Add(AppointmentType);
                }
                cbAppointmentType.SelectedIndex = 0;
            }
        }

        public struct stAppointmentInput
        {
            public DateTime? AppointmentDateTime { get; set; }
            public string Status { get; set; }
            public string AppointmentType { get; set; }
            public int PatientID { get; set; }
            public int DoctorID { get; set; }
        }

        public stAppointmentInput GetInput()
        {
            return new stAppointmentInput()
            {
                AppointmentDateTime = dtpAppointmentDateTime.Value,
                Status = cbNewStatus.Text.Trim(),
                AppointmentType = cbAppointmentType.Text.Trim(),
                PatientID =
                int.TryParse(tbSearchPatient.Text.Split('.')[0], out int ID) ? ID : -1,
                DoctorID =
                int.TryParse(tbSearchDoctor.Text.Split('.')[0], out int id) ? id : -1,
            };
        }

        public void SetInputPatient(string PatientName, int PatientID)
        {
            tbSearchPatient.Text = PatientID + ". " + PatientName;
        }

        public void SetInputDoctor(string DoctorName, int DoctorID)
        {
            tbSearchDoctor.Text = DoctorID + ". " + DoctorName;
        }

        public void GetOutput(DateTime? AppointmentDateTime, string StatusName, 
            string AppointmentTypeStr)
        {
            dtpAppointmentDateTime.Value = AppointmentDateTime.Value;
            cbAppointmentType.Text = AppointmentTypeStr;
            pnlOldStatus.Visible = true;
            tbOldStatus.Text = StatusName;
        }

        private void btnSearch_MouseHover(object sender, EventArgs e)
        {
            btnSearchPatient.BackColor = Color.FromArgb(95, 162, 255);
        }

        public event Action OnSearchPatient;
        protected virtual void SearchPatient()
        {
            Action Handler = OnSearchPatient;
            if (Handler != null)
            {
                Handler();
            }
        }
        private void btnSearchPatient_Click(object sender, EventArgs e)
        {
            if (OnSearchPatient != null)
            {
                SearchPatient();
            }
        }

        public event Action OnSearchDoctor;
        protected virtual void SearchDoctor()
        {
            Action Handler = OnSearchDoctor;
            if (Handler != null)
            {
                Handler();
            }
        }
        private void btnSearchDoctor_Click(object sender, EventArgs e)
        {
            if (OnSearchDoctor != null)
            {
                SearchDoctor();
            }
        }

        private void btnSearch_MouseLeave(object sender, EventArgs e)
        {
            btnSearchPatient.BackColor = Color.FromArgb(58, 141, 255);
        }
    }
}
