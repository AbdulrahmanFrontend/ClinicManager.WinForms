using LoggingLayer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;

namespace DataAccessLayer 
{ 
    public class clsDoctorDataAccess : clsDataAccessHelper
    { 
        private static T _GetValue<T>(DataRow Row, string Column)
        { 
            return Row[Column] == DBNull.Value ? default : (T)Row[Column];
        } 
        public struct stDoctor
        {
            public int PersonID { get; set; }
            public int DoctorID { get; set; }
            public string Name { get; set; }
            public int SpecializationID { get; set; }
            public string Phone { get; set; }
            public DateTime? BirthDate { get; set; }
            public string Gender { get; set; }
            public string Address { get; set; }
            public string Email { get; set; }
        }
        public static stDoctor? GetDoctorByDoctorID(int DoctorID)
        {
            string Query = 
                @"select * from DoctorsDetails where DoctorID = @DoctorID;";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@DoctorID", DoctorID }
            };
            DataRow Row = _GetFirstRow(Query, Params);
            if(Row != null)
            {
                return new stDoctor()
                {
                    PersonID = (int)Row["PersonID"],
                    DoctorID = (int)Row["DoctorID"],
                    Name = Row["DoctorName"].ToString(),
                    SpecializationID = (int)Row["SpecializationID"],
                    Phone = Row["PhoneNumber"].ToString(),
                    BirthDate = _GetValue<DateTime>(Row, "DateOfBirth"),
                    Gender = _GetValue<string>(Row, "Gender"),
                    Address = _GetValue<string>(Row, "Address"),
                    Email = _GetValue<string>(Row, "Email"),
                };
            }
            return null;
        }
        public static DataTable FilterDoctorsByDoctorName(string DoctorName)
        {
            string Query = @"select DoctorID, DoctorName, SpecializationName, 
            PhoneNumber, Gender, DateOfBirth, Email, Address from DoctorsDetails 
            where DoctorName like '' + @DoctorName + '%';";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@DoctorName", DoctorName }
            };
            return _GetDataTable(Query, Params);
        }
        public static DataTable FilterDoctorsByPhoneNumber(string PhoneNumber)
        {
            string Query = @"select DoctorID, DoctorName, SpecializationName, PhoneNumber, Gender,
            DateOfBirth, Email, Address from DoctorsDetails 
            where PhoneNumber like '' + @PhoneNumber + '%';";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@PhoneNumber", PhoneNumber }
            };
            return _GetDataTable(Query, Params);
        }
        public static DataTable FilterDoctorsByGender(string Gender)
        {
            string Query = @"select DoctorID, DoctorName, SpecializationName, PhoneNumber, Gender,
            DateOfBirth, Email, Address from DoctorsDetails
            where (@Gender is null and Gender is null) or (Gender = @Gender)";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@Gender", string.IsNullOrEmpty(Gender) ? null : Gender }
            };
            return _GetDataTable(Query, Params);
        }
        public static DataTable 
            FilterDoctorsByBirthDateFrom(DateTime? BirthDateFrom)
        {
            string Query = @"select DoctorID, DoctorName, SpecializationName, PhoneNumber, Gender,
            DateOfBirth, Email, Address from DoctorsDetails 
            where (@BirthDateFrom is null or DateOfBirth >= @BirthDateFrom);";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@BirthDateFrom", BirthDateFrom.HasValue ? BirthDateFrom : null }
            };
            return _GetDataTable(Query, Params);
        }
        public static DataTable FilterDoctorsByBirthDateYear(DateTime? BirthDateFrom, 
            DateTime? BirthDateTo)
        {
            string Query = @"select DoctorID, DoctorName, SpecializationName, PhoneNumber, Gender,
            DateOfBirth, Email, Address from DoctorsDetails 
            where DateOfBirth between @BirthDateFrom and @BirthDateTo;";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@BirthDateFrom", BirthDateFrom.HasValue ? BirthDateFrom : null },
                { "@BirthDateTo", BirthDateTo.HasValue ? BirthDateTo : null }
            };
            return _GetDataTable(Query, Params);
        }
        public static DataTable FilterDoctorsByAddress(string Address)
        {
            string Query = @"select DoctorID, DoctorName, SpecializationName, PhoneNumber, Gender,
            DateOfBirth, Email, Address from DoctorsDetails 
            where Address like '' + @Address + '%';";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@Address", string.IsNullOrEmpty(Address) ? null : Address }
            };
            return _GetDataTable(Query, Params);
        }
        public static DataTable FilterDoctorsByEmail(string Email)
        {
            string Query = @"select DoctorID, DoctorName, SpecializationName, PhoneNumber, Gender,
            DateOfBirth, Email, Address from DoctorsDetails 
            where Email like '' + @Email + '%';";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@Email", string.IsNullOrEmpty(Email) ? null : Email }
            };
            return _GetDataTable(Query, Params);
        }
        public static DataTable 
            FilterDoctorsBySpecialization(string Specialization)
        {
            string Query = @"select DoctorID, DoctorName, SpecializationName, PhoneNumber, Gender,
            DateOfBirth, Email, Address from DoctorsDetails 
            where SpecializationName like '' + @SpecializationName + '%';";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@SpecializationName", Specialization }
            };
            return _GetDataTable(Query, Params);
        }
        public static int AddNewDoctor(int PersonID, int SpecializationID,
            SqlTransaction tran, SqlConnection con)
        {
            int DoctorID = -1;
            string Query = @"insert into Doctors (PersonID, SpecializationID) 
            values (@PersonID, @SpecializationID); 
            select scope_identity();";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@PersonID", PersonID },
                { "@SpecializationID", SpecializationID }
            };
            object Result = _GetScalar(Query, tran, con, Params);
            if (Result != null)
            {
                int.TryParse(Result.ToString(), out DoctorID);
            }
            return DoctorID;
        }
        public static DataTable GetAllDoctors()
        {
            string Query = @"select DoctorID, DoctorName, SpecializationName,
            PhoneNumber, Gender, DateOfBirth, Email, Address from DoctorsDetails;";
            return _GetDataTable(Query); 
        } 
        public static bool UpdateDoctor(int PersonID, int DoctorID,
            int SpecializationID, SqlTransaction tran, SqlConnection con)
        {
            string Query = @"update Doctors 
            set PersonID = @PersonID, SpecializationID = @SpecializationID 
            where DoctorID = @DoctorID;";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@PersonID", PersonID },
                { "@SpecializationID", SpecializationID },
                { "@DoctorID", DoctorID }
            };
            return _ExecuteNonQuery(Query, tran, con, Params);
        }
        public static bool DeleteDoctor(int DoctorID, SqlTransaction tran,
            SqlConnection con)
        {
            string Query = @"delete from Doctors 
            where DoctorID = @DoctorID;";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@DoctorID", DoctorID }
            };
            return _ExecuteNonQuery(Query, tran, con, Params);
        }
        public static bool IsDoctorExist(int DoctorID)
        {
            int num = 0;
            string Query = @"select IsFound = 1 from Doctors 
            where DoctorID = @DoctorID;";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@DoctorID", DoctorID }
            };
            object Result = _GetScalar(Query, Params);
            if(Result != null)
            {
                int.TryParse(Result.ToString(), out num);
            }
            return num > 0;
        }
        public static int GetPersonID(int DoctorID)
        {
            int PersonID = -1;
            string Query = @"select PersonID from Doctors 
            where DoctorID = @DoctorID;";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@DoctorID", DoctorID }
            };
            object Result = _GetScalar(Query, Params);
            if(Result != null)
            {
                int.TryParse(Result.ToString(), out PersonID);
            }
            return PersonID;
        }
        public static int GetTotalDoctors()
        {
            int Count = 0;
            string Query = @"select TotalDoctors = count(DoctorID) from Doctors;";
            object Result = _GetScalar(Query);
            if(Result != null)
            {
                int.TryParse(Result.ToString(), out Count);
            }
            return Count;
        }
        public static string GetSpecializationNameByDoctorID(int DoctorID)
        {
            string Query = @"select SpecializationName from DoctorsDetails
            where DoctorID = @DoctorID;";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@DoctorID", DoctorID }
            };
            object Result = _GetScalar(Query, Params);
            if (!(Result == null || string.IsNullOrEmpty(Result.ToString())))
            {
                return Result.ToString();
            }
            return string.Empty;
        }
        public static List<int> AppointmentIDsList(int DoctorID)
        {
            string Query = @"select AppointmentID from Appointments
            where DoctorID = @DoctorID;";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@DoctorID", DoctorID }
            };
            List<int> AppointmentIDs = _GetDataTable(Query, Params).AsEnumerable().
                Select(r => (int)r["AppointmentID"]).ToList();
            return AppointmentIDs;
        }
        public static List<string> GetDoctorsList()
        {
            List<string> DoctorsList = new List<string>();
            string Query = @"select DoctorID, DoctorName
            from DoctorsDetails;";
            DoctorsList = _GetDataTable(Query).AsEnumerable()
                .Select(r => (int)r["DoctorID"] + ". " +
                r["DoctorName"].ToString()).ToList();
            return DoctorsList;
        }
    }
}
