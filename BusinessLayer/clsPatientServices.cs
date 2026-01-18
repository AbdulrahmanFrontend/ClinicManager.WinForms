using DataAccessLayer;
using LoggingLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace BusinessLayer
{
    public class clsPatientServices
    {
        private struct _stAppointmentInfo
        {
            public int AppID { get; set; }
            public int MedID { get; set; }
            public int PayID { get; set; }
            public List<int> PrescIDs { get; set; }
        }
        public static bool DeletePatient(int PatientID)
        {
            if (!clsPatient.IsPatientExist(PatientID))
            {
                return false;
            }
            _stAppointmentInfo App;
            List<int> AppointmentIDs = clsPatientDataAccess
                .AppointmentIDsList(PatientID);
            int PersonID = clsPatientDataAccess.GetPersonID(PatientID);

            var AppointmentsDetails = new List<_stAppointmentInfo>();
            if (AppointmentIDs.Count > 0)
            {
                foreach (int AppointmentID in AppointmentIDs)
                {
                    App = new _stAppointmentInfo();
                    App.AppID = AppointmentID;
                    App.MedID = clsAppointmentDataAccess
                        .GetMedicalRecordID(App.AppID);
                    if (App.MedID == -1)
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
                                    foreach (int PrescID in Appointment.PrescIDs)
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

                    clsPatientDataAccess.DeletePatient(PatientID, tran, con);

                    if (PersonID != -1)
                    {
                        clsPersonDataAccess.DeletePerson(PersonID, tran, con);
                    }

                    tran.Commit();
                    Logger.LogInfo($"Deleting Patient [{PatientID}] Done " +
                        $"Successfully in clsPatientDataAccess");
                    return true;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Logger.LogError("Delete operation failed, changes rolled back.",
                        ex);
                    return false;
                }
            }
        }
        private static bool _AddNewPatient(clsPatient Patient)
        {
            if (!Patient.IsValid())
            {
                return false;
            }
            if(clsPatient.IsPhoneNumberFound(Patient.PhoneNumber))
            {
                return false;
            }
            using (SqlConnection con = clsDataAccessHelper.CreateConnection)
            {
                con.Open();
                SqlTransaction tran = con.BeginTransaction();
                try
                {
                    Patient.PersonID = clsPersonDataAccess.AddNewPerson(Patient.Name, 
                        Patient.PhoneNumber, Patient.DateOfBirth, 
                        Patient.GenderDictionary[Patient.Gender], Patient.Address, 
                        Patient.Email, tran, con);
                    
                    Patient.PatientID = clsPatientDataAccess
                        .AddNewPatient(Patient.PersonID, tran, con);

                    tran.Commit();
                    Logger.LogInfo($"Adding New Patient [{Patient.PatientID}] Done " +
                        $"Successfully in clsPatientDataAccess");
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Logger.LogError("Adding New Patient Operation Failed," +
                        " Changes Rolled Back.", ex);
                }
            }
            return Patient.PatientID != -1;
        }
        private static bool _UpdatePatient(clsPatient Patient)
        {
            if (!Patient.IsValid())
            {
                return false;
            }
            if (clsPatient.IsPhoneNumberFound(Patient.PatientID,
                Patient.PhoneNumber))
            {
                return false;
            }
            if (!clsPatient.IsPatientExist(Patient.PatientID))
            {
                return false;
            }
            using (SqlConnection con = clsDataAccessHelper.CreateConnection)
            {
                con.Open();
                SqlTransaction tran = con.BeginTransaction();
                try
                {
                    clsPersonDataAccess.UpdatePerson(Patient.PersonID, Patient.Name,
                        Patient.PhoneNumber, Patient.DateOfBirth,
                        Patient.GenderDictionary[Patient.Gender], Patient.Address,
                        Patient.Email, tran, con);

                    clsPatientDataAccess.UpdatePatient(Patient.PersonID,
                        Patient.PatientID, tran, con);

                    tran.Commit();
                    Logger.LogInfo($"Updating Patient [{Patient.PatientID}] Done " +
                        $"Successfully in clsPatientDataAccess");
                    return true;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Logger.LogError("Updating Patient Operation Failed," +
                        " Changes Rolled Back.", ex);
                    return false;
                }
            }
        }
        public static bool SavePatient(clsPatient Patient)
        {
            switch (Patient.Mode)
            {
                case clsPatient.enMode.AddNew:
                    if (_AddNewPatient(Patient))
                    {
                        Patient.Mode = clsPatient.enMode.Update;
                        return true;
                    }
                    return false;
                case clsPatient.enMode.Update:
                    return _UpdatePatient(Patient);
                default:
                    return false;
            }
        }
    }
}
