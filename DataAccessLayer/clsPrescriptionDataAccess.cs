using LoggingLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsPrescriptionDataAccess : clsDataAccessHelper
    {
        public struct stPrescription
        {
            public int PrescriptionID { get; set; }
            public string Dosage { get; set; }
            public string MedicalName { get; set; }
            public string Frequently { get; set; }
            public string SpecialInstructions { get; set; }
            public DateTime? StartDate { get; set; }
            public DateTime? EndDate { get; set; }
            public int MedicalRecordID { get; set; }
        }
        public static stPrescription? GetPrescriptionByID(int PrescriptionID)
        {
            string Query = @"select * from Prescriptions 
            where PrescriptionID = @PrescriptionID;";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@PrescriptionID", PrescriptionID }
            };
            DataRow Row = _GetFirstRow(Query, Params);
            if(Row != null)
            {
                return new stPrescription
                {
                    Dosage = Row["Dosage"].ToString(),
                    MedicalName = Row["MedicalName"].ToString(),
                    Frequently = Row["Frequently"].ToString(),
                    SpecialInstructions = Row["SpecialInstructions"].ToString(),
                    StartDate = Convert.ToDateTime(Row["StartDate"]),
                    EndDate = Convert.ToDateTime(Row["EndDate"]),
                    MedicalRecordID = (int)Row["MedicalRecordID"]
                };
            };
            return null;
        }
        public static int AddNewPrescription(string Dosage, string MedicalName,
            string Frequently, string SpecialInstructions, DateTime? StartDate,
            DateTime? EndDate, int MedicalRecordID)
        {
            int PrescriptionID = -1;
            string Query = @"insert into Prescriptions
            values (@Dosage, @MedicalName, @Frequently, @SpecialInstructions,
            @StartDate, @EndDate, @MedicalRecordID);
            select scope_identity();";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@Dosage", Dosage },
                { "@Frequently", Frequently },
                { "@MedicalName", MedicalName },
                { "@SpecialInstructions", SpecialInstructions },
                { "@StartDate", StartDate },
                { "@EndDate", EndDate },
                { "@MedicalRecordID", MedicalRecordID }
            };
            object Result = _GetScalar(Query, Params);
            if(Result != null)
            {
                if(int.TryParse(Result.ToString(), out PrescriptionID))
                {
                    Logger.LogInfo($"Adding New Prescription [{PrescriptionID}]" +
                        $" Done Successfully in clsPrescriptionDataAccess.");
                }
            }
            return PrescriptionID;
        }
        public static bool UpdatePrescription(int PrescriptionID, string Dosage,
            string MedicalName, string Frequently, string SpecialInstructions,
            DateTime? StartDate, DateTime? EndDate, int MedicalRecordID)
        {
            string Query = @"update Prescriptions
            set Dosage = @Dosage, MedicalName = @MedicalName, Frequently = @Frequently,
            SpecialInstructions = @SpecialInstructions, StartDate = @StartDate,
            EndDate = @EndDate, MedicalRecordID = @MedicalRecordID
            where PrescriptionID = @PrescriptionID;";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@PrescriptionID", PrescriptionID },
                { "@Dosage", Dosage },
                { "@Frequently", Frequently },
                { "@MedicalName", MedicalName },
                { "@SpecialInstructions", SpecialInstructions },
                { "@StartDate", StartDate },
                { "@EndDate", EndDate },
                { "@MedicalRecordID", MedicalRecordID }
            };
            if (_ExecuteNonQuery(Query, Params))
            {
                Logger.LogInfo($"Updating Prescription {PrescriptionID} Done " +
                    $"Successfully in clsPrescriptionDataAccess.");
                return true;
            }
            return false;
        }
        public static bool IsPrescriptionExist(int PrescriptionID)
        {
            int num = 0;
            string Query = @"select IsFound = 1 from Prescriptions 
            where PrescriptionID = @PrescriptionID;";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@PrescriptionID", PrescriptionID }
            };
            object Result = _GetScalar(Query, Params);
            if(Result != null)
            {
                int.TryParse(Result.ToString(), out num);
            }
            return num > 0;
        }
        public static bool DeletePrescription(int PrescriptionID)
        {
            string Query = @"delete from Prescriptions 
            where PrescriptionID = @PrescriptionID;";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@PrescriptionID", PrescriptionID }
            };
            if(_ExecuteNonQuery(Query, Params))
            {
                Logger.LogInfo($"Deleting Prescription [{PrescriptionID}] Done " +
                    $"Successfully in clsPrescriptionDataAccess.");
                return true;
            }
            return false;
        }
        public static bool DeletePrescription(int PrescriptionID, SqlTransaction tran,
            SqlConnection con)
        {
            string Query = @"delete from Prescriptions 
            where PrescriptionID = @PrescriptionID;";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@PrescriptionID", PrescriptionID }
            };
            return _ExecuteNonQuery(Query, tran, con, Params);
        }
        public static List<int>PrescriptionIDsList(int MedicalRecordID)
        {
            string Query = @"select PrescriptionID from Prescriptions
            where MedicalRecordID = @MedicalRecordID;";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@MedicalRecordID", MedicalRecordID }
            };
            List<int> list = _GetDataTable(Query, Params).AsEnumerable()
                .Select(r => (int)r["PrescriptionID"]).ToList();
            return list;
        }
    }
}
