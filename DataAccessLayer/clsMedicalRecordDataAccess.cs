using LoggingLayer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsMedicalRecordDataAccess : clsDataAccessHelper
    {
        public struct stMedicalRecord
        {
            public int MedicalRecordID { get; set; }
            public string VisitDescription { get; set; }
            public string Diagnosis { get; set; }
            public string AdditionalNotes { get; set; }
        }
        public static stMedicalRecord? GetByMedicalRecordID(int MedicalRecordID)
        {
            string Query = @"select * from MedicalRecords 
            where MedicalRecordID = @MedicalRecordID;";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@MedicalRecord", MedicalRecordID }
            };
            DataRow Row = _GetFirstRow(Query, Params);
            if (Row != null)
            {
                return new stMedicalRecord
                {
                    MedicalRecordID = (int)Row["MedicalRecord"],
                    VisitDescription = Row["VisitDescription"].ToString(),
                    Diagnosis = Row["Diagnosis"].ToString(),
                    AdditionalNotes = Row["AdditionalNotes"] == (object)DBNull.Value ? 
                    string.Empty : (string)Row["AdditionalNotes"],
                };
            }
            return null;
        }
        public static int AddNewMedicalRecord(string VisitDescription, 
            string Diagnosis, string AdditionalNotes)
        {
            int MedicalRecordID = -1;
            string Query = @"insert into MedicalRecords
            values (@VisitDescription, @Diagnosis, @AdditionalNotes);
            select scope_identity();";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@VisitDescription", VisitDescription },
                { "@Diagnosis", Diagnosis },
                { "@AdditionalNotes", string.IsNullOrEmpty(AdditionalNotes) ? 
                null : AdditionalNotes }
            };
            object Result = _GetScalar(Query, Params);
            if(Result != null)
            {
                if(int.TryParse(Result.ToString(), out MedicalRecordID))
                {
                    Logger.LogInfo($"Adding New Medical Record [{MedicalRecordID}] " +
                        $"Done Successfully in clsMedicalRecordDataAccess.");
                }
            }
            return MedicalRecordID;
        }
        public static bool UpdateMedicalRecord(int MedicalRecordID, 
            string VisitDescription, string Diagnosis, string AdditionalNotes)
        {
            string Query = @"update MedicalRecords
            set VisitDescription = @VisitDescription, Diagnosis = @Diagnosis, 
            AdditionalNotes = @AdditionalNotes, PrescriptionID = @PrescriptionID
            where MedicalRecordID = @MedicalRecordID;";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@MedicalRecordID", MedicalRecordID },
                { "@VisitDescription", VisitDescription },
                { "@Diagnosis", Diagnosis },
                { "@AdditionalNotes", string.IsNullOrEmpty(AdditionalNotes) ?
                null : AdditionalNotes }
            };
            if(_ExecuteNonQuery(Query, Params))
            {
                Logger.LogInfo($"Updating MedicalRecord [{MedicalRecordID}] Done " +
                        $"Successfully in clsMedicalRecordDataAccess.");
                return true;
            }
            return false;
        }
        public static bool IsMedicalRecordExist(int MedicalRecordID)
        {
            int num = 0;
            string Query = @"select IsFound = 1 from MedicalRecords
            where MedicalRecordID = @MedicalRecordID;";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@MedicalRecordID", MedicalRecordID }
            };
            object Result = _GetScalar(Query, Params);
            if(Result != null)
            {
                int.TryParse(Result.ToString(), out num);
            }
            return num > 0;
        }
        public static bool DeleteMedicalRecord(int MedicalRecordID,
            SqlTransaction tran, SqlConnection con)
        {
            string Query = @"delete from MedicalRecords 
            where MedicalRecordID = @MedicalRecordID;";
            var Params = new Dictionary<string, object>()
            {
                { "@MedicalRecordID", MedicalRecordID }
            };
            return _ExecuteNonQuery(Query, tran, con, Params);
        }
    }
}
