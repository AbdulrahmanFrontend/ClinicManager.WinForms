using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BusinessLayer
{
    public class clsAppointment
    {
        public int AppointmentID { get; private set; }
        public DateTime? AppointmentDateTime { get; set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        private int _AppointmentStatusID;
        public int AppointmentStatusID 
        { 
            get
            {
                return _AppointmentStatusID; 
            }
            set
            {
                _AppointmentStatusID = value;
                clsAppointmentStatus Status = 
                    clsAppointmentStatus.FindByStatusID(_AppointmentStatusID);
                if (Status != null)
                {
                    foreach(var Pair in StatusDictionary)
                    {
                        if (Pair.Value.Equals(Status.StatusName))
                        {
                            _NewStatus = Pair.Key;
                        }
                    }
                }
            }
        }
        public int PaymentsID { get; set; }
        public int MedicalRecordID { get; set; }
        public enum enAppointmentType
        { 
            enExamination, enConsultation, enUndefined
        }
        public enAppointmentType AppointmentType { get; set; }
        public Dictionary<enAppointmentType, string> AppointmentTypeDictionary =
            new Dictionary<enAppointmentType, string>()
            {
                { enAppointmentType.enExamination, "Examination" },
                { enAppointmentType.enConsultation, "Consultation" }
            };
        public enum enMode { AddNew, Update }
        public enMode Mode { get; set; }
        public enum enStatus 
        { 
            enCompleted, enConfirmed, enRescheduled, enPending, enCanceled, enNoShow,
            enUndefined
        }
        public Dictionary<enStatus, string> StatusDictionary =
            new Dictionary<enStatus, string>()
            {
                { enStatus.enCompleted, "Completed" },
                { enStatus.enConfirmed, "Confirmed" },
                { enStatus.enRescheduled, "Rescheduled" },
                { enStatus.enPending, "Pending" },
                { enStatus.enCanceled, "Canceled" },
                { enStatus.enNoShow, "No Show" },
                { enStatus.enUndefined, "Undefined" }
            };
        private enStatus _enFailedStatus { get; set; }
        private enStatus _NewStatus { get; set; } = enStatus.enUndefined;
        public enStatus SuccessStatus()
        {
            string Status = GetStatus();
            foreach (KeyValuePair<enStatus, string> Pair in StatusDictionary)
            {
                if (Pair.Value == Status)
                {
                    return Pair.Key;
                }
            }
            return enStatus.enUndefined;
        }
        public clsAppointment()
        {
            this.AppointmentID = -1;
            this.AppointmentDateTime = null;
            this.PatientID = -1;
            this.DoctorID = -1;
            this.AppointmentStatusID = -1;
            this.PaymentsID = -1;
            this.MedicalRecordID = -1;
            this.Mode = enMode.AddNew;
            this.AppointmentType = enAppointmentType.enExamination;
            this._enFailedStatus = enStatus.enUndefined;
            this._NewStatus = enStatus.enUndefined;
        }
        private clsAppointment(int AppointmentID, DateTime? AppointmentDateTime, 
            int PatientID, int DdoctorID, int AppointmentStatusID, int PaymentsID, 
            int MedicalRecordID, string AppointmentType)
        {
            this.AppointmentID = AppointmentID;
            this.AppointmentDateTime = AppointmentDateTime;
            this.PatientID = PatientID;
            this.DoctorID = DdoctorID;
            this.AppointmentStatusID = AppointmentStatusID;
            this.PaymentsID = PaymentsID;
            this.MedicalRecordID = MedicalRecordID;
            this.Mode = enMode.Update;
            foreach(KeyValuePair<enAppointmentType, string> Pair in 
                this.AppointmentTypeDictionary)
            {
                if (Pair.Value == AppointmentType)
                {
                    this.AppointmentType = Pair.Key;
                    break;
                }
            }
            this._enFailedStatus = enStatus.enUndefined;
        }
        public static clsAppointment FindByAppointmentID(int AppointmentID)
        {
            var Appointment = 
                clsAppointmentDataAccess.GetByAppointmentID(AppointmentID);
            if(Appointment.HasValue)
            {
                DateTime? AppointmentDateTime = 
                    Appointment.Value.AppointmentDateTime;
                int PatientID = Appointment.Value.PatientID,
                    DoctorID = Appointment.Value.DoctorID,
                    AppointmentStatusID = Appointment.Value.AppointmentStatusID,
                    PaymentsID = Appointment.Value.PaymentsID,
                    MedicalRecord = Appointment.Value.MedicalRecordID;
                string AppointmentTypeStr = Appointment.Value.AppointmentTypeStr;
                return new clsAppointment(AppointmentID, AppointmentDateTime,
                    PatientID, DoctorID, AppointmentStatusID, PaymentsID,
                    MedicalRecord, AppointmentTypeStr);
            }
            return null;
        }
        public bool IsAppointmentDateTimeVaild()
        {
            return this.AppointmentDateTime.HasValue && 
                this.AppointmentDateTime.Value.Date >= DateTime.Today.Date;
        }
        public static bool ReservedAppointment(int AppointmentID,
            int DoctorID, int PatientID, DateTime? AppointmentDateTime)
        {
            return clsAppointmentDataAccess.ReservedAppointment(AppointmentID, 
                DoctorID, PatientID, AppointmentDateTime);
        }
        private bool _ValidateIntervalReservation(int MaxDays = 7, int MinDays = 0)
        {
            int IntervalReservation =
                (this.AppointmentDateTime.Value.Date - DateTime.Today).Days;
            return IntervalReservation <= MaxDays && IntervalReservation > MinDays;
        }
        private bool _ValidateRescheduleAppointment()
        {
            if (_ValidateIntervalReservation())
            {
                enStatus Status = SuccessStatus();
                if(Status == enStatus.enConfirmed || Status == enStatus.enPending)
                {
                    if (StatusDictionary.TryGetValue(enStatus.enPending,
                                out string StrStatus))
                    {
                        clsAppointmentStatus objStatus =
                            clsAppointmentStatus.FindByStatusName(StrStatus);
                        if (objStatus != null)
                        {
                            this.AppointmentStatusID = objStatus.StatusID;
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        private bool _ValidatePendingAppointment()
        {
            enStatus Status = SuccessStatus();
            if (_ValidateIntervalReservation(6))
            {
                return _NewStatus == enStatus.enRescheduled || 
                    Status == enStatus.enUndefined;
            }
            return Status == enStatus.enPending;
        }
        private bool _ValidateConfirmAppointment()
        {
            enStatus Status = SuccessStatus();
            if (this.AppointmentDateTime.Value.Date == DateTime.Today.Date)
            {
                return Status == enStatus.enUndefined || Status == enStatus.enPending;
            }
            return Status == enStatus.enConfirmed;
        }
        private bool _ValidateCompleteAppointment()
        {
            enStatus Status = SuccessStatus();
            if (this.AppointmentDateTime.Value.Date == DateTime.Today.Date)
            {
                return Status == enStatus.enConfirmed;
            }
            return Status == enStatus.enCompleted;
        }
        private bool _ValidateCancelAppointment()
        {
            enStatus Status = SuccessStatus();
            if (_ValidateIntervalReservation(6, -1))
            {
                return Status == enStatus.enPending ||
                    Status == enStatus.enConfirmed;
            }
            return Status == enStatus.enCanceled;
        }
        private bool _ValidateNoShowAppointment()
        {
            enStatus Status = SuccessStatus();
            if (this.AppointmentDateTime.Value.Date == DateTime.Today.Date)
            {
                return Status == enStatus.enPending;
            }
            return Status == enStatus.enNoShow;
        }
        public bool ValidateStatus()
        {
            if (this.AppointmentDateTime.HasValue)
            {
                switch (_NewStatus)
                {
                    case enStatus.enCompleted:
                        if (_ValidateCompleteAppointment())
                        {
                            return true;
                        }
                        _enFailedStatus = enStatus.enCompleted;
                        return false;
                    case enStatus.enConfirmed:
                        if (_ValidateConfirmAppointment())
                        {
                            return true;
                        }
                        _enFailedStatus = enStatus.enConfirmed;
                        return false;
                    case enStatus.enRescheduled:
                        if (_ValidateRescheduleAppointment())
                        {
                            _NewStatus = enStatus.enRescheduled;
                            return true;
                        }
                        _enFailedStatus = enStatus.enRescheduled;
                        return false;
                    case enStatus.enCanceled:
                        if (_ValidateCancelAppointment())
                        {
                            return true;
                        }
                        _enFailedStatus = enStatus.enCanceled;
                        return false;
                    case enStatus.enNoShow:
                        if (_ValidateNoShowAppointment())
                        {
                            return true;
                        }
                        _enFailedStatus = enStatus.enNoShow;
                        return false;
                    case enStatus.enPending:
                        if (_ValidatePendingAppointment())
                        {
                            return true;
                        }
                        _enFailedStatus = enStatus.enPending;
                        return false;
                    case enStatus.enUndefined:
                        _enFailedStatus = enStatus.enUndefined;
                        return false;
                    default:
                        _enFailedStatus = enStatus.enUndefined;
                        return false;
                }
            }
            return false;
        }
        public string ValidationStatusMSG()
        {
            switch (this._enFailedStatus)
            {
                case enStatus.enCompleted:
                    return "the Appointment should be first confirmed and has a " +
                        "medical record;";
                case enStatus.enConfirmed:
                    return "Date and Time of Appointment should be fixed, the " +
                        "date should be date of today and the old status should be " +
                        "not completed or canceled or no show;";
                case enStatus.enRescheduled:
                    return "The New Date & Time should be not in today and in" +
                        " interval 7 days and the appointment could be confirmed" +
                        " or pending before;";
                case enStatus.enCanceled:
                    return "The reservation can be canceled before its appointment" +
                        " by less than or equal 7 days and could be confirmed" +
                        " or pending before;";
                case enStatus.enNoShow:
                    return "The Date & Time should be today and the appointment " +
                        "should be pending before;";
                case enStatus.enPending:
                    return "The Date & Time should be in interval 7 days from " +
                        "tomorrow and the appointment should be not completed, " +
                        "confirmed, canceled or no show;";
                case enStatus.enUndefined:
                    return "Status is not unknown!!";
                default:
                    return "Status is not unknown!!";
            }
        }
        public bool IsPatientIDValid()
        {
            return clsPatient.IsPatientExist(this.PatientID);
        }
        public string ValidationPatientMSG()
        {
            return "Patient is not found!!";
        }
        public string ValidationDoctorMSG()
        {
            return "Doctor is not found!!";
        }
        public string ValidationReserveAppointmentMSG()
        {
            return "This Appointment is already Reserved!!";
        }
        public bool IsDoctorIDValid()
        {
            return clsDoctor.IsDoctorExist(this.DoctorID);
        }
        //public bool IsMedicalRecordIDValid()
        //{
        //    if (SuccessStatus() == enStatus.enConfirmed && 
        //        _NewStatus == enStatus.enCompleted)
        //    {
        //        return clsMedicalRecord.IsMedicalRecordExist(this.MedicalRecordID);
        //    }
        //    return MedicalRecordID == -1;
        //}
        public bool IsPaymentsIDValid()
        {
            if (SuccessStatus() == enStatus.enCompleted)
            {
                return clsPayments.IsPaymentsExist(this.PaymentsID);
            }
            return PaymentsID == -1;
        }
        public bool IsAppointmentValid()
        {
            return IsPatientIDValid() && IsDoctorIDValid() && IsPaymentsIDValid()
                && ValidateStatus();
        }
        private bool _AddNew()
        {
            if (IsAppointmentValid())
            {
                this.AppointmentID = clsAppointmentDataAccess.AddNewAppointment(
                    this.AppointmentDateTime, this.PatientID, this.DoctorID, 
                    this.AppointmentStatusID, this.PaymentsID, this.MedicalRecordID, 
                    this.AppointmentTypeDictionary[this.AppointmentType]);
            }
            return this.AppointmentID != -1;
        }
        private bool _Update()
        {
            if (IsAppointmentValid())
            {
                return clsAppointmentDataAccess.UpdateAppointment(this.AppointmentID, 
                    this.AppointmentDateTime, this.PatientID, this.DoctorID, 
                    this.AppointmentStatusID, this.PaymentsID, this.MedicalRecordID, 
                    this.AppointmentTypeDictionary[this.AppointmentType]);
            }
            return false;
        }
        public bool Save()
        {
            switch (this.Mode)
            {
                case enMode.AddNew:
                    if (_AddNew())
                    {
                        this.Mode = enMode.Update;
                        this._enFailedStatus = enStatus.enUndefined;
                        return true;
                    }
                    return false;
                case enMode.Update:
                    if (_Update())
                    {
                        this._enFailedStatus = enStatus.enUndefined;
                        return true;
                    }
                    return false;
                default:
                    return false;
            }
        }
        public static DataTable GetAllReservations()
        {
            return clsAppointmentDataAccess.GetAllReservations();
        }
        public static DataTable GetAllTodayAppointments()
        {
            return clsAppointmentDataAccess.GetAllTodayAppointments();
        }
        public static bool IsAppointmentExist(int AppointmentID)
        {
            return clsAppointmentDataAccess.IsAppointmentExist(AppointmentID);
        }
        public static DataTable GetTopFiveTodayAppointments()
        {
            return clsAppointmentDataAccess.GetTopFiveTodayAppointments();
        }
        public static int GetTodayAppointmentsCount()
        {
            return clsAppointmentDataAccess.GetTodayAppointmentsCount();
        }
        public static DataTable 
            FilterReservationsByPatientName(string PatientName)
        {
            return clsAppointmentDataAccess.
                FilterReservationsByPatientName(PatientName);
        }
        public static DataTable FilterReservationsByDoctorName(string DoctorName)
        {
            return clsAppointmentDataAccess.
                FilterReservationsByDoctorName(DoctorName);
        }
        public static DataTable 
            FilterTodayAppointmentsByDoctorName(string DoctorName)
        {
            return clsAppointmentDataAccess.
                FilterTodayAppointmentsByDoctorName(DoctorName);
        }
        public static DataTable FilterReservationsByStatus(string Status)
        {
            return clsAppointmentDataAccess.FilterReservationsByStatus(Status);
        }
        public static DataTable FilterReservationsByDate(DateTime? DateFrom, 
            DateTime? DateTo)
        {
            return clsAppointmentDataAccess.
                FilterReservationsByDate(DateFrom, DateTo);
        }
        public string GetPatientName()
        {
            return clsAppointmentDataAccess.GetPatientName(this.AppointmentID);
        }
        public string GetDoctorName()
        {
            return clsAppointmentDataAccess.GetDoctorName(this.AppointmentID);
        }
        public string GetStatus()
        {
            string Status = clsAppointmentDataAccess.GetStatus(this.AppointmentID);
            return Status == string.Empty ?
                this.StatusDictionary[enStatus.enUndefined] : Status;
        }
        public decimal GetPayments()
        {
            return clsAppointmentDataAccess.GetPayments(this.AppointmentID);
        }
    }
}
