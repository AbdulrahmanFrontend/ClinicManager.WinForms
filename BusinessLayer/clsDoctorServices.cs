using DataAccessLayer;
using LoggingLayer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsDoctorServices
    {
        private struct _stAppointmentInfo
        {
            public int AppID { get; set; }
            public int MedID { get; set; }
            public int PayID { get; set; }
            public List<int> PrescIDs { get; set; }
        }
        public static bool DeleteDoctor(int DoctorID)
        {
            if (!clsDoctor.IsDoctorExist(DoctorID))
            {
                return false;
            }
            _stAppointmentInfo App;
            List<int> AppointmentIDs = clsDoctorDataAccess
                .AppointmentIDsList(DoctorID);
            int PersonID = clsDoctorDataAccess.GetPersonID(DoctorID);

            var AppointmentsDetails = new List<_stAppointmentInfo>();
            if (AppointmentIDs.Count > 0)
            {
                foreach (int AppointmentID in AppointmentIDs)
                {
                    App = new _stAppointmentInfo();
                    App.AppID = AppointmentID;
                    App.MedID = clsAppointmentDataAccess
                        .GetMedicalRecordID(App.AppID);
                    if(App.MedID != -1)
                    {
                        App.PrescIDs = new List<int>();
                        App.PrescIDs.Add(-1);
                    }
                    else
                    {
                        App.PrescIDs = clsPrescriptionDataAccess
                            .PrescriptionIDsList(App.MedID);
                    }
                    App.PayID =
                        clsAppointmentDataAccess.GetPaymentsID(App.AppID);
                    AppointmentsDetails.Add(App);
                }
            }
            using (SqlConnection con = clsDataAccessHelper.CreateConnection)
            {
                con.Open();
                SqlTransaction tran = con.BeginTransaction();
                try
                {
                    if (AppointmentsDetails.Count > 0)
                    {
                        foreach (var Appointment in AppointmentsDetails)
                        {
                            clsAppointmentDataAccess
                                .DeleteAppointment(Appointment.AppID, tran, con);

                            if (Appointment.MedID != -1)
                            {
                                if (Appointment.PrescIDs.Count > 0)
                                {
                                    foreach(int PrescID in Appointment.PrescIDs)
                                    {
                                        clsPrescriptionDataAccess
                                            .DeletePrescription(PrescID, tran, con);
                                    }
                                }

                                clsMedicalRecordDataAccess
                                    .DeleteMedicalRecord(Appointment.MedID, tran, con);
                            }

                            if (Appointment.PayID != -1)
                            {
                                clsPaymentsDataAccess
                                    .DeletePayments(Appointment.PayID, tran, con);
                            }
                        }
                    }

                    clsDoctorDataAccess.DeleteDoctor(DoctorID, tran, con);

                    if (PersonID != -1)
                    {
                        clsPersonDataAccess.DeletePerson(PersonID, tran, con);
                    }

                    tran.Commit();
                    Logger.LogInfo($"Deleting Doctor [{DoctorID}] Done " +
                        $"Successfully in clsDoctorServices;");
                    return true;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Logger.LogError("Delete operation failed," +
                        " changes rolled back.", ex);
                    return false;
                }
            }
        }
        private static bool _AddNewDoctor(clsDoctor Doctor)
        {
            if (!Doctor.IsValid())
            {
                return false;
            }
            if (clsDoctor.IsPhoneNumberFound(Doctor.PhoneNumber))
            {
                return false;
            }
            using (SqlConnection con = clsDataAccessHelper.CreateConnection)
            {
                con.Open();
                SqlTransaction tran = con.BeginTransaction();
                try
                {
                    Doctor.PersonID = clsPersonDataAccess.AddNewPerson(Doctor.Name,
                        Doctor.PhoneNumber, Doctor.DateOfBirth,
                        Doctor.GenderDictionary[Doctor.Gender], Doctor.Address,
                        Doctor.Email, tran, con);

                    Doctor.DoctorID = clsDoctorDataAccess.AddNewDoctor(Doctor.PersonID, 
                        Doctor.SpecializationID, tran, con);

                    tran.Commit();
                    Logger.LogInfo($"Adding New Doctor [{Doctor.DoctorID}] Done " +
                        $"Successfully in clsDoctorDataAccess");
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Logger.LogError("Adding New Doctor Operation Failed," +
                        " Changes Rolled Back.", ex);
                }
            }
            return Doctor.DoctorID != -1;
        }
        private static bool _UpdateDoctor(clsDoctor Doctor)
        {
            if (!Doctor.IsValid())
            {
                return false;
            }
            if (clsDoctor.IsPhoneNumberFound(Doctor.DoctorID, Doctor.PhoneNumber))
            {
                return false;
            }
            if (!clsDoctor.IsDoctorExist(Doctor.DoctorID))
            {
                return false;
            }
            using (SqlConnection con = clsDataAccessHelper.CreateConnection)
            {
                con.Open();
                SqlTransaction tran = con.BeginTransaction();
                try
                {
                    clsPersonDataAccess.UpdatePerson(Doctor.PersonID,
                        Doctor.Name, Doctor.PhoneNumber, Doctor.DateOfBirth,
                        Doctor.GenderDictionary[Doctor.Gender], Doctor.Address,
                        Doctor.Email, tran, con);

                    clsDoctorDataAccess.UpdateDoctor(Doctor.PersonID, Doctor.DoctorID,
                        Doctor.SpecializationID, tran, con);

                    tran.Commit();
                    Logger.LogInfo($"Updating Doctor [{Doctor.DoctorID}] Done " +
                        $"Successfully in clsDoctorDataAccess");
                    return true;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Logger.LogError("Updating Doctor Operation Failed," +
                        " Changes Rolled Back.", ex);
                    return false;
                }
            }
        }
        public static bool SaveDoctor(clsDoctor Doctor)
        {
            switch (Doctor.Mode)
            {
                case clsDoctor.enMode.AddNew:
                    if (_AddNewDoctor(Doctor))
                    {
                        Doctor.Mode = clsDoctor.enMode.Update;
                        return true;
                    }
                    return false;
                case clsDoctor.enMode.Update:
                    return _UpdateDoctor(Doctor);
                default:
                    return false;
            }
        }
    }
}
