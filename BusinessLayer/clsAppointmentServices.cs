using DataAccessLayer;
using LoggingLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsAppointmentServices
    {
        public static bool DeleteAppointment(int AppointmentID)
        {
            if (!clsAppointment.IsAppointmentExist(AppointmentID))
            {
                return false;
            }
            int MedicalRecordID = clsAppointmentDataAccess.
                GetMedicalRecordID(AppointmentID);
            List<int> PrescriptionIDsList =
                clsPrescriptionDataAccess.PrescriptionIDsList(MedicalRecordID);
            int PaymentsID = clsAppointmentDataAccess.GetPaymentsID(AppointmentID);
            using (SqlConnection con = clsDataAccessHelper.CreateConnection)
            {
                con.Open();
                SqlTransaction tran = con.BeginTransaction();
                try
                {
                    clsAppointmentDataAccess.DeleteAppointment(AppointmentID, tran,
                        con);

                    if (MedicalRecordID != -1)
                    {
                        if (PrescriptionIDsList.Count > 0)
                        {
                            foreach (int PrescriptionID in PrescriptionIDsList)
                            {
                                clsPrescriptionDataAccess
                                    .DeletePrescription(PrescriptionID, tran, con);
                            }
                        }

                        clsMedicalRecordDataAccess
                            .DeleteMedicalRecord(MedicalRecordID, tran, con);
                    }

                    if (PaymentsID != -1)
                    {
                        clsPaymentsDataAccess.DeletePayments(PaymentsID, tran, con);
                    }

                    tran.Commit();
                    Logger.LogInfo($"Deleting Appointment [{AppointmentID}] Done " +
                        $"Successfully in clsAppointmentServices;");
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
        public static bool UpdateAppointmentWithPayments(clsAppointment App,
            clsPayments Pay)
        {
            if(!(App.IsAppointmentValid() && Pay.IsPaymentsValid()))
            {
                return false;
            }
            using (SqlConnection con = clsDataAccessHelper.CreateConnection)
            {
                con.Open();
                SqlTransaction tran = con.BeginTransaction();
                try
                {
                    Pay.PaymentsID = clsPaymentsDataAccess.AddNewPayments(
                        Pay.PaymentDate, Pay.AmountPaid, Pay.AdditionalNotes,
                        Pay.MethodID, tran, con);

                    clsAppointmentDataAccess.UpdateAppointment(App.AppointmentID,
                        App.AppointmentDateTime, App.PatientID, App.DoctorID,
                        App.AppointmentStatusID, App.PaymentsID,
                        App.MedicalRecordID, 
                        App.AppointmentTypeDictionary[App.AppointmentType], tran,
                        con);

                    tran.Commit();
                    if (Pay.Mode == clsPayments.enMode.AddNew)
                    {
                        Pay.Mode = clsPayments.enMode.Update;
                    }
                    Logger.LogInfo($"Updating Appointment [{App.AppointmentID}] " +
                        $"With Payments [{Pay.PaymentsID}] Done Successfully in" +
                        $" clsAppointmentServices;");
                    return true;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Logger.LogError("Update operation failed, changes rolled back.",
                        ex);
                    return false;
                }
            }
        }
    }
}
