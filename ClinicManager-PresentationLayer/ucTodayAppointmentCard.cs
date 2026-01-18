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
    public partial class ucTodayAppointmentCard : UserControl
    {
        public ucTodayAppointmentCard()
        {
            InitializeComponent();
        }

        public DateTimePicker DateTimePickerDateTime
        {
            get
            {
                return dtpAppointmentDateTime;
            }
        }
        public TextBox TextBoxAmountPaid
        {
            get
            {
                return tbAmountPaid;
            }
        }
        public ComboBox CombBoxPaymentMethod
        {
            get
            {
                return cbPaymentMethod;
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

        public void GetPaymentMethodsList(List<string> PaymentMethodsList)
        {
            cbPaymentMethod.Items.Clear();
            if (PaymentMethodsList.Count > 0)
            {
                foreach (string PaymentMethod in PaymentMethodsList)
                {
                    cbPaymentMethod.Items.Add(PaymentMethod);
                }
                cbPaymentMethod.SelectedItem = "Cash";
            }
        }

        public struct stAppointmentInput
        {
            public DateTime? AppointmentDateTime { get; set; }
            public string Status { get; set; }
        }

        public struct stPaymentsInput
        {
            public string PaymentMethod { get; set; }
            public string AdditionalNotes { get; set; }
        }

        public stAppointmentInput GetAppointmentInput()
        {
            return new stAppointmentInput()
            {
                AppointmentDateTime = dtpAppointmentDateTime.Value,
                Status = cbNewStatus.Text.Trim(),
            };
        }

        public stPaymentsInput GetPaymentsInput()
        {
            return new stPaymentsInput()
            {
                PaymentMethod = cbPaymentMethod.SelectedItem.ToString(),
                AdditionalNotes = tbAdditionalNotes.Text.Trim(),
            };
        }

        public void SetInputPatient(string PatientName, int PatientID)
        {
            tbPatient.Text = PatientID + ". " + PatientName;
        }

        public void SetInputDoctor(string DoctorName, int DoctorID)
        {
            tbDoctor.Text = DoctorID + ". " + DoctorName;
        }

        public void GetOutput(DateTime? AppointmentDateTime, string StatusName,
            string AppointmentTypeStr)
        {
            dtpAppointmentDateTime.Value = AppointmentDateTime.Value;
            tbAppointmentType.Text = AppointmentTypeStr;
            tbOldStatus.Text = StatusName;
        }


        public event Action<string> OnSelectedNewStatus;
        protected virtual void SelectNewStatus(string NewStatus)
        {
            Action<string> Handler = OnSelectedNewStatus;
            if (Handler != null)
            {
                Handler(NewStatus);
            }
        }
        private void cbNewStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtpAppointmentDateTime.Enabled = false;
            tbAmountPaid.Text = "0";
            cbPaymentMethod.Enabled = false;
            if (OnSelectedNewStatus != null)
            {
                SelectNewStatus(cbNewStatus.Text);
            }
        }
    }
}
