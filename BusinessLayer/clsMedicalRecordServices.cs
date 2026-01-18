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
    public class clsMedicalRecordServices
    {
        public static bool DeleteMedicalRecord(int MedicalRecordID)
        {
            if (!clsMedicalRecord.IsMedicalRecordExist(MedicalRecordID))
            {
                return false;
            }
            List<int> PrescriptionIDs = clsPrescriptionDataAccess.
                PrescriptionIDsList(MedicalRecordID);
            using (SqlConnection con = clsDataAccessHelper.CreateConnection)
            {
                con.Open();
                SqlTransaction tran = con.BeginTransaction();
                try
                {
                    if (PrescriptionIDs.Count > 0)
                    {
                        foreach (int PrescriptionID in PrescriptionIDs)
                        {
                            clsPrescriptionDataAccess
                                .DeletePrescription(PrescriptionID, tran, con);
                        }
                    }

                    clsMedicalRecordDataAccess.DeleteMedicalRecord(MedicalRecordID,
                        tran, con);

                    tran.Commit();
                    Logger.LogInfo($"Deleting Medical Record [{MedicalRecordID}] " +
                        $"Done Successfully in clsMedicalRecordDataAccess.");
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
    }
}
