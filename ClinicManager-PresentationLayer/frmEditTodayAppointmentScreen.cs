using BusinessLayer;
using Sunny.UI;
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
    public partial class frmEditTodayAppointmentScreen : Form
    {
        private clsAppointment _Appointment;
        private bool IsCompleted = false;

        public frmEditTodayAppointmentScreen(int AppointmentID)
        {
            InitializeComponent();
            _Appointment = clsAppointment.FindByAppointmentID(AppointmentID);
            if (_Appointment == null)
            {
                MessageBox.Show("This Reservation is not found!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void frmEditTodayAppointmentScreen_Load(object sender,
            EventArgs e)
        {
            HeaderBar.ConfigureScreenName("Edit Today's Appointment Info");
            FormActionButtons.ConfigureForAdd();
            clsAppointmentStatus.Context =
                clsAppointmentStatus.enContext.UpdateTodayAppointment;
            TodayAppointmentCard.GetStatusList(
                clsAppointmentStatus.GetAppointmentStatusListByContext()
                );
            TodayAppointmentCard.GetPaymentMethodsList(
                clsPaymentMethod.GetMethodsList()
                );
            TodayAppointmentCard.GetOutput(_Appointment.AppointmentDateTime,
                _Appointment.GetStatus(),
                _Appointment.AppointmentTypeDictionary[_Appointment.AppointmentType]);
            TodayAppointmentCard.SetInputPatient(_Appointment.GetPatientName(),
                _Appointment.PatientID);
            TodayAppointmentCard.SetInputDoctor(_Appointment.GetDoctorName(),
                _Appointment.DoctorID);
        }

        private void TodayAppointmentCard_OnSelectedNewStatus(string obj)
        {
            string NewStatus = obj;
            foreach (var Status in _Appointment.StatusDictionary)
            {
                if (Status.Value == NewStatus)
                {
                    switch (Status.Key)
                    {
                        case clsAppointment.enStatus.enRescheduled:
                            TodayAppointmentCard.DateTimePickerDateTime.Enabled = true;
                            break;
                        case clsAppointment.enStatus.enCompleted:
                            IsCompleted = true;
                            TodayAppointmentCard.CombBoxPaymentMethod.Enabled = true;
                            if (_Appointment.AppointmentType == 
                                clsAppointment.enAppointmentType.enExamination)
                            {
                                TodayAppointmentCard.TextBoxAmountPaid.Text =
                                    _Appointment.GetPayments().ToString();
                            }
                            break;
                    }
                }
            }
        }

        private void FormActionButtons_OnCancelButton()
        {
            this.Close();
        }

        private void FormActionButtons_OnSaveButton()
        {
            var AppointmentInput = TodayAppointmentCard.GetAppointmentInput();
            _Appointment.AppointmentDateTime = AppointmentInput.AppointmentDateTime;
            clsAppointmentStatus Status = 
                clsAppointmentStatus.FindByStatusName(AppointmentInput.Status);
            if (Status == null)
            {
                MessageBox.Show("Selected Status is not found!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _Appointment.AppointmentStatusID = Status.StatusID;
            DialogResult ConfirmRequest = MessageBox.Show(
                "Do you sure to save this reservation?", "Confirm Request",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1);
            if (IsCompleted)
            {
                clsPayments Payments = new clsPayments();
                var PaymentsInput = TodayAppointmentCard.GetPaymentsInput();
                clsPaymentMethod Method = 
                    clsPaymentMethod.FindByMethodName(PaymentsInput.PaymentMethod);
                if (Method == null)
                {
                    MessageBox.Show("Selected Method is not found!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Payments.MethodID = Method.MethodID;
                Payments.AdditionalNotes = PaymentsInput.AdditionalNotes;
                Payments.AmountPaid = _Appointment.GetPayments();
                Payments.PaymentDate = DateTime.Today.Date;
                if (ConfirmRequest == DialogResult.OK)
                {
                    if (clsAppointmentServices
                        .UpdateAppointmentWithPayments(_Appointment, Payments))
                    {
                        MessageBox.Show("Appointment Completed Successfully.",
                                "Success", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to Save this Reservation.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                if (ConfirmRequest == DialogResult.OK)
                {
                    if (_Appointment.Save())
                    {
                        MessageBox.Show("Reservation Saved Successfully.", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to Save this Reservation.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}
