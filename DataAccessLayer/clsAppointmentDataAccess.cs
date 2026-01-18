using LoggingLayer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsAppointmentDataAccess : clsDataAccessHelper
    {
        public struct stAppointment
        {
            public int AppointmentID { get; set; }
            public DateTime? AppointmentDateTime { get; set; }
            public int PatientID { get; set; }
            public int DoctorID { get; set; }
            public int AppointmentStatusID { get; set; }
            public int PaymentsID { get; set; }
            public int MedicalRecordID { get; set; }
            public string AppointmentTypeStr { get; set; }
        }
        public static stAppointment? GetByAppointmentID(int AppointmentID)
        {
            string Query =
                "select * from Appointments where AppointmentID = @AppointmentID;";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@AppointmentID", AppointmentID }
            };
            DataRow Row = _GetFirstRow(Query, Params);
            if(Row != null)
            {
                return new stAppointment()
                {
                    AppointmentID = (int)Row["AppointmentID"],
                    AppointmentDateTime = (DateTime)Row["AppointmentDateTime"],
                    PatientID = (int)Row["PatientID"],
                    DoctorID = (int)Row["DoctorID"],
                    AppointmentStatusID = (int)Row["AppointmentStatusID"],
                    AppointmentTypeStr = Row["AppointmentType"].ToString(),
                    PaymentsID = Row["PaymentsID"] == (object)DBNull.Value ?
                        -1 : (int)Row["PaymentsID"],
                    MedicalRecordID = Row["MedicalRecordID"] == (object)DBNull.Value ?
                        -1 : (int)Row["MedicalRecordID"],
                };
            }
            return null;
        }
        public static DataTable FilterReservationsByDoctorName(string DoctorName)
        {
            string Query = @"select * from Reservations 
            where (DoctorName like '' + @DoctorName + '%')
            and (cast(AppointmentDateTime as date) >= getdate())
            and (Status not in ('No Show', 'Completed', 'Canceled'));";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@DoctorName", DoctorName },
            };
            return _GetDataTable(Query, Params);
        }
        public static DataTable 
            FilterTodayAppointmentsByDoctorName(string DoctorName)
        {
            string Query = @"select * from TodayAppointments
            where (cast(AppointmentDateTime as date) = cast(getdate() as date))
            and (Status not in ('No Show', 'Completed', 'Canceled'))
            and (DoctorName like '' + @DoctorName + '%')
            order by AppointmentID, AppointmentDateTime;";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@DoctorName", DoctorName },
            };
            return _GetDataTable(Query, Params);
        }
        public static DataTable 
            FilterReservationsByPatientName(string PatientName)
        {
            string Query = @"select * from Reservations 
            where (PatientName like '' + @PatientName + '%')
            and (cast(AppointmentDateTime as date) >= getdate())
            and (Status not in ('No Show', 'Completed', 'Canceled'));";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@PatientName", PatientName }
            };
            return _GetDataTable(Query, Params);
        }
        public static DataTable FilterReservationsByStatus(string Status)
        {
            string Query = @"select * from Reservations
            where (Status like '' + @Status + '%') 
            and (cast(AppointmentDateTime as date) >= getdate())
            and (Status not in ('No Show', 'Completed', 'Canceled'));";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@Status", Status }
            };
            return _GetDataTable(Query, Params);
        }
        public static DataTable FilterReservationsByDate(DateTime? DateFrom, 
            DateTime? DateTo)
        {
            string Query = @"select * from Reservations 
            where (cast(AppointmentDateTime as date) between @DateFrom and @DateTo)
            and (cast(AppointmentDateTime as date) >= getdate())
            and (Status not in ('No Show', 'Completed', 'Canceled'));";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@DateFrom", DateFrom },
                { "@DateTo", DateTo }
            };
            return _GetDataTable(Query, Params);
        }
        public static int AddNewAppointment(DateTime? AppointmentDateTime, 
            int PatientID, int DoctorID, int AppointmentStatusID, int PaymentsID,
            int MedicalRecordID, string AppointmentTypeStr)
        {
            int AppointmentID = -1;
            string Query = @"insert into Appointments 
            values (@AppointmentDateTime, @PatientID, @DoctorID,
            @AppointmentStatusID, @PaymentsID, @MedicalRecordID, @AppointmentType);
            select scope_identity();";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@AppointmentDateTime", AppointmentDateTime },
                { "@PatientID", PatientID },
                { "@DoctorID", DoctorID },
                { "@AppointmentStatusID", AppointmentStatusID },
                { "@PaymentsID", PaymentsID == -1 ? null : (object)PaymentsID },
                { "@MedicalRecordID", MedicalRecordID == -1 ? 
                null : (object)MedicalRecordID },
                { "@AppointmentType", AppointmentTypeStr },
            };
            object Result = _GetScalar(Query, Params);
            if(Result != null && int.TryParse(Result.ToString(), out AppointmentID))
            {
                Logger.LogInfo($"Adding New Appointment [{AppointmentID}] Done " +
                    $"Successfully in clsAppointmentDataAccess.");
                return AppointmentID;
            }
            return -1;
        }
        public static bool UpdateAppointment(int AppointmentID,
            DateTime? AppointmentDateTime, int PatientID, int DoctorID, 
            int AppointmentStatusID, int PaymentsID, int MedicalRecordID,
            string AppointmentTypeStr)
        {
            string Query = @"update Appointments
            set AppointmentDateTime = @AppointmentDateTime, PatientID = @PatientID,
            DoctorID = @DoctorID, AppointmentStatusID = @AppointmentStatusID, 
            PaymentsID = @PaymentsID, MedicalRecordID = @MedicalRecordID, 
            AppointmentType = @AppointmentType
            where AppointmentID = @AppointmentID;";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@AppointmentID", AppointmentID },
                { "@AppointmentDateTime", AppointmentDateTime },
                { "@PatientID", PatientID },
                { "@DoctorID", DoctorID },
                { "@AppointmentStatusID", AppointmentStatusID },
                { "@PaymentsID", PaymentsID == -1 ? null : (object)PaymentsID },
                { "@MedicalRecordID", MedicalRecordID == -1 ?
                null : (object)MedicalRecordID },
                { "@AppointmentType", AppointmentTypeStr },
            };
            if(_ExecuteNonQuery(Query, Params))
            {
                Logger.LogInfo($"Updating Appointment [{AppointmentID}] is done " +
                    $"successfully in clsAppointmentDataAccess.");
                return true;
            }
            return false;
        }
        public static bool UpdateAppointment(int AppointmentID,
            DateTime? AppointmentDateTime, int PatientID, int DoctorID,
            int AppointmentStatusID, int PaymentsID, int MedicalRecordID,
            string AppointmentTypeStr, SqlTransaction tran, SqlConnection con)
        {
            string Query = @"update Appointments
            set AppointmentDateTime = @AppointmentDateTime, PatientID = @PatientID,
            DoctorID = @DoctorID, AppointmentStatusID = @AppointmentStatusID, 
            PaymentsID = @PaymentsID, MedicalRecordID = @MedicalRecordID, 
            AppointmentType = @AppointmentType
            where AppointmentID = @AppointmentID;";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@AppointmentID", AppointmentID },
                { "@AppointmentDateTime", AppointmentDateTime },
                { "@PatientID", PatientID },
                { "@DoctorID", DoctorID },
                { "@AppointmentStatusID", AppointmentStatusID },
                { "@PaymentsID", PaymentsID == -1 ? null : (object)PaymentsID },
                { "@MedicalRecordID", MedicalRecordID == -1 ?
                null : (object)MedicalRecordID },
                { "@AppointmentType", AppointmentTypeStr },
            };
            return _ExecuteNonQuery(Query, tran, con, Params);
        }
        public static DataTable GetAllReservations()
        {
            string Query = @"select * from Reservations
            where (cast(AppointmentDateTime as date) >= cast(getdate() as date))
            and (Status not in ('No Show', 'Completed', 'Canceled'));";
            return _GetDataTable(Query);
        }
        public static DataTable GetAllTodayAppointments()
        {
            string Query = @"select * from TodayAppointments
            where (cast(AppointmentDateTime as date) = cast(getdate() as date))
            and (Status not in ('No Show', 'Completed', 'Canceled'))
            order by AppointmentID, AppointmentDateTime;";
            return _GetDataTable(Query);
        }
        public static bool IsAppointmentExist(int AppointmentID)
        {
            int num = 0;
            string Query = @"select IsFound = 1 from Appointments 
            where AppointmentID = @AppointmentID;";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@AppointmentID", AppointmentID }
            };
            object Result = _GetScalar(Query, Params);
            if (Result != null)
            {
                int.TryParse(Result.ToString(), out num);
            }
            return num > 0;
        }
        public static int GetMedicalRecordID(int AppointmentID)
        {
            int MedicalRecordID = -1;
            string Query = @"select MedicalRecordID from Appointments
            where AppointmentID = @AppointmentID;";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@AppointmentID", AppointmentID }
            };
            object Result = _GetScalar(Query, Params);
            if(Result != null)
            {
                int.TryParse(Result.ToString(), out MedicalRecordID);
            }
            return MedicalRecordID;
        }
        public static int GetPaymentsID(int AppointmentID)
        {
            int PaymentsID = -1;
            string Query = @"select PaymentsID from Appointments
            where AppointmentID = @AppointmentID;";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@AppointmentID", AppointmentID }
            };
            object Result = _GetScalar(Query, Params);
            if (Result != null)
            {
                int.TryParse(Result.ToString(), out PaymentsID);
            }
            return PaymentsID;
        }
        public static bool DeleteAppointment(int AppointmentID, SqlTransaction tran,
            SqlConnection con)
        {
            string Query = @"delete from Appointments 
            where AppointmentID = @AppointmentID;";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@AppointmentID", AppointmentID }
            };
            return _ExecuteNonQuery(Query, tran, con, Params);
        }
        public static DataTable GetTopFiveTodayAppointments()
        {
            string Query = @"select top 5 Time = AppointmentDateTime, PatientName,
            DoctorName from TodayAppointments order by AppointmentDateTime desc;";
            return _GetDataTable(Query);
        }
        public static int GetTodayAppointmentsCount()
        {
            int Count = 0;
            string Query = @"select 
            TodayAppointmentsCount = Count(AppointmentDateTime) from Appointments
            where cast(AppointmentDateTime as date) = cast(getdate() as date);";
            object Result = _GetScalar(Query);
            if(Result != null)
            {
                int.TryParse(Result.ToString(), out Count);
            }
            return Count;
        }
        public static string GetPatientName(int AppointmentID)
        {
            string Query = @"select PatientName from Reservations 
            where AppointmentID = @AppointmentID;";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@AppointmentID", AppointmentID }
            };
            object Result = _GetScalar(Query, Params);
            if (!(Result == null || string.IsNullOrEmpty(Result.ToString())))
            {
                return Result.ToString();
            }
            return string.Empty;
        }
        public static string GetDoctorName(int AppointmentID)
        {
            string Query = @"select DoctorName from Reservations 
            where AppointmentID = @AppointmentID;";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@AppointmentID", AppointmentID }
            };
            object Result = _GetScalar(Query, Params);
            if (!(Result == null || string.IsNullOrEmpty(Result.ToString())))
            {
                return Result.ToString();
            }
            return string.Empty;
        }
        public static string GetStatus(int AppointmentID)
        {
            string Query = @"select Status from Reservations 
            where AppointmentID = @AppointmentID;";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@AppointmentID", AppointmentID }
            };
            object Result = _GetScalar(Query, Params);
            if (!(Result == null || string.IsNullOrEmpty(Result.ToString())))
            {
                return Result.ToString();
            }
            return string.Empty;
        }
        public static bool ReservedAppointment(int AppointmentID, int DoctorID,
            int PatientID, DateTime? AppointmentDateTime)
        {
            int num = 0;
            string Query = @"SELECT TOP 1 1 FROM Appointments 
            WHERE (DoctorID = @DoctorID or PatientID = @PatientID)
            AND AppointmentID != @AppointmentID 
            AND AppointmentStatusID IN (1, 2)
            AND ABS(DATEDIFF(minute, 
            cast(AppointmentDateTime as smalldatetime), 
            cast(@AppointmentDateTime as smalldatetime))) < 10;";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@AppointmentID", AppointmentID },
                { "@DoctorID", DoctorID },
                { "@PatientID", PatientID },
            };
            object Result = _GetScalar(Query, Params);
            if (Result != null)
            {
                int.TryParse(Result.ToString(), out num);
            }
            return num > 0;
        }
        public static decimal GetPayments(int AppointmentID)
        {
            decimal Payments = 0;
            string Query = @"select Payments from TodayAppointments
            where AppointmentID = @AppointmentID;";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@AppointmentID", AppointmentID }
            };
            object Result = _GetScalar(Query, Params);
            if(Result != null)
            {
                decimal.TryParse(Result.ToString(), out Payments);
            }
            return Payments;
        }
    }
}
