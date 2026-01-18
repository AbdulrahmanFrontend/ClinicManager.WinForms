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
    public partial class frmReservationInfoScreen : Form
    {
        private clsAppointment _Appointment;

        private enum _enFormBehavior { enAdd, enEdit }
        private _enFormBehavior _FormBehavior { get; set; }

        public frmReservationInfoScreen()
        {
            InitializeComponent();
            _FormBehavior = _enFormBehavior.enAdd;
            _Appointment = new clsAppointment();
            HeaderBar.ConfigureScreenName("Add New Reservation");
            FormActionButtons.ConfigureForAdd();
            ReservationCard.GetAppointmentTypesList(_GetAppointmentTypesList());
            clsAppointmentStatus.Context =
                clsAppointmentStatus.enContext.NewReservation;
            ReservationCard.GetStatusList(
                clsAppointmentStatus.GetAppointmentStatusListByContext()
                );
        }

        public frmReservationInfoScreen(int AppointmentID)
        {
            InitializeComponent();
            _FormBehavior = _enFormBehavior.enEdit;
            _Appointment = clsAppointment.FindByAppointmentID(AppointmentID);
            if(_Appointment == null)
            {
                MessageBox.Show("This reservation is not found!", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            HeaderBar.ConfigureScreenName("Edit Reservation Info");
            FormActionButtons.ConfigureForEdit();
            ReservationCard.GetAppointmentTypesList(_GetAppointmentTypesList());
            clsAppointmentStatus.Context =
                clsAppointmentStatus.enContext.UpdateReservation;
            ReservationCard.GetStatusList(
                clsAppointmentStatus.GetAppointmentStatusListByContext()
                );
            ReservationCard.GetOutput(_Appointment.AppointmentDateTime,
                _Appointment.GetStatus(),
                _Appointment.AppointmentTypeDictionary[_Appointment.AppointmentType]);
            ReservationCard. SetInputPatient(_Appointment.GetPatientName(), 
                _Appointment.PatientID);
            ReservationCard.SetInputDoctor(_Appointment.GetDoctorName(), 
                _Appointment.DoctorID);
        }

        private List<string> _GetAppointmentTypesList()
        {
            List<string> AppointmentTypesList = new List<string>();
            foreach (KeyValuePair<clsAppointment.enAppointmentType, string> Pair in
                _Appointment.AppointmentTypeDictionary)
            {
                if (!Pair.Key.Equals(clsAppointment.enAppointmentType.enUndefined))
                {
                    AppointmentTypesList.Add(Pair.Value);
                }
            }
            return AppointmentTypesList;
        }

        private void ReservationCard_OnSearchPatient()
        {
            frmSelectPatientScreen frm = new frmSelectPatientScreen();
            frm.BackPatientInfoSelected += frmPatientSelection_DoubleClickRow;
            frm.ShowDialog();
        }

        private void frmPatientSelection_DoubleClickRow(int PatientID, 
            string PatientName)
        {
            ReservationCard.SetInputPatient(PatientName, PatientID);
        }

        private void ReservationCard_OnSearchDoctor()
        {
            frmSelectDoctorScreen frm = new frmSelectDoctorScreen();
            frm.BackDoctorInfoSelected += frmDoctorSelection_DoubleClickRow;
            frm.ShowDialog();
        }

        private void frmDoctorSelection_DoubleClickRow(int DoctorID, 
            string DoctorName)
        {
            ReservationCard.SetInputDoctor(DoctorName, DoctorID);
        }

        private void FormActionButtons_OnCancelButton()
        {
            this.Close();
        }

        private void _SetError(object sender1, string ErrorMessage, 
            object sender2 = null)
        {
            errorpInfo.Clear();
            MessageBox.Show("Failed to Save this Reservation.\n" + ErrorMessage,
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (sender1 is TextBox)
            {
                errorpInfo.SetError((TextBox)sender1, ErrorMessage);
            }
            else if (sender1 is ComboBox && sender2 is DateTimePicker)
            {
                errorpInfo.SetError((ComboBox)sender1, ErrorMessage);
                errorpInfo.SetError((DateTimePicker)sender2, ErrorMessage);
            }
            else if (sender1 is DateTimePicker)
            {
                errorpInfo.SetError((DateTimePicker)sender1, ErrorMessage);
            }
        }
        private bool _ValidateAppointment()
        {
            errorpInfo.Clear();
            if (!_Appointment.ValidateStatus())
            {
                _SetError(ReservationCard.ComboBoxStatus, 
                    _Appointment.ValidationStatusMSG(),
                    ReservationCard.DateTimePackerDateTime);
                return false;
            }
            if (!_Appointment.IsDoctorIDValid())
            {
                _SetError(ReservationCard.TextBoxSearchDoctor, 
                    _Appointment.ValidationDoctorMSG());
                return false;
            }
            if (!_Appointment.IsPatientIDValid())
            {
                _SetError(ReservationCard.TextBoxSearchPatient,
                    _Appointment.ValidationPatientMSG());
                return false;
            }
            switch (_FormBehavior)
            {
                case _enFormBehavior.enAdd:
                    if (clsAppointment.ReservedAppointment(-1, _Appointment.DoctorID,
                        _Appointment.PatientID, _Appointment.AppointmentDateTime))
                    {
                        _SetError(ReservationCard.DateTimePackerDateTime, 
                            _Appointment.ValidationReserveAppointmentMSG());
                        return false;
                    }
                    break;
                case _enFormBehavior.enEdit:
                    if (clsAppointment.ReservedAppointment(
                        _Appointment.AppointmentID, _Appointment.DoctorID,
                        _Appointment.PatientID, _Appointment.AppointmentDateTime))
                    {
                        _SetError(ReservationCard.DateTimePackerDateTime,
                            _Appointment.ValidationReserveAppointmentMSG());
                        return false;
                    }
                    break;
            }
            return true;
        }
        private void FormActionButtons_OnSaveButton()
        {
            var InputAppointment = ReservationCard.GetInput();
            clsAppointmentStatus Status =
                clsAppointmentStatus.FindByStatusName(InputAppointment.Status);
            if(Status == null)
            {
                MessageBox.Show("Selected Status is not found!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _Appointment.AppointmentDateTime = InputAppointment.AppointmentDateTime;
            _Appointment.PatientID = InputAppointment.PatientID;
            _Appointment.DoctorID = InputAppointment.DoctorID;
            _Appointment.AppointmentStatusID = Status.StatusID;
            foreach (KeyValuePair<clsAppointment.enAppointmentType, string> Pair in
                _Appointment.AppointmentTypeDictionary)
            {
                if (Pair.Value == InputAppointment.AppointmentType)
                {
                    _Appointment.AppointmentType = Pair.Key;
                    break;
                }
            }
            if (_ValidateAppointment())
            {
                DialogResult ConfirmRequest = MessageBox.Show(
                    "Do you sure to save this reservation?", "Confirm Request",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1);
                if (ConfirmRequest == DialogResult.OK)
                {
                    if (_Appointment.Save())
                    {
                        MessageBox.Show("Reservation Saved Successfully.", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (_FormBehavior == _enFormBehavior.enAdd)
                        {
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Failed to Save this Reservation.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void FormActionButtons_OnDeleteButton()
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this appointment?",
                "Confirm Deletion", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                bool isDeleted = clsAppointmentServices
                    .DeleteAppointment(_Appointment.AppointmentID);
                if (isDeleted)
                {
                    MessageBox.Show("Appointment is deleted successfully.", 
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to delete the appointment.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Close();
            }
        }
    }
}
