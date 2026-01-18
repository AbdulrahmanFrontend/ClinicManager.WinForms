using LoggingLayer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccessLayer
{ 
    public class clsPatientDataAccess : clsDataAccessHelper
    {
        public struct stPatient
        {
            public int PersonID { get; set; }
            public int PatientID { get; set; }
            public string Name { get; set; }
            public string Phone { get; set; }
            public DateTime? BirthDate { get; set; }
            public string Gender { get; set; }
            public string Address { get; set; }
            public string Email { get; set; }
        }
        private static T _GetValue<T>(DataRow Row, string Column)
        {
            return Row[Column] == DBNull.Value ? default : (T)Row[Column];
        }
        public static stPatient? GetPatientByPatientID(int PatientID)
        {
            string Query = @"select * from PatientsDetails 
            where PatientID = @PatientID";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@PatientID", PatientID }
            };
            DataRow Row = _GetFirstRow(Query, Params);
            if(Row != null)
            {
                return new stPatient
                {
                    PersonID = (int)Row["PersonID"],
                    PatientID = (int)Row["PatientID"],
                    Name = Row["PatientName"].ToString(),
                    Phone = Row["PhoneNumber"].ToString(),
                    BirthDate = _GetValue<DateTime>(Row, "DateOfBirth"),
                    Gender = _GetValue<string>(Row, "Gender"),
                    Address = _GetValue<string>(Row, "Address"),
                    Email = _GetValue<string>(Row, "Email")
                };
            }
            return null;
        }
        public static DataTable FilterPatientsByPatientName(string PatientName)
        {
            string Query = @"select PatientID, PatientName, PhoneNumber, Gender,
            DateOfBirth, Email, Address from PatientsDetails 
            where PatientName like '' + @PatientName + '%';";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@PatientName", PatientName }
            };
            return _GetDataTable(Query, Params);
        }
        public static DataTable FilterPatientsByPhoneNumber(string PhoneNumber)
        {
            string Query = @"select PatientID, PatientName, PhoneNumber, Gender,
            DateOfBirth, Email, Address from PatientsDetails 
            where PhoneNumber like '' + @PhoneNumber + '%';";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@PhoneNumber", PhoneNumber }
            };
            return _GetDataTable(Query, Params);
        }
        public static DataTable FilterPatientsByGender(string Gender)
        {
            string Query = @"select PatientID, PatientName, PhoneNumber, Gender,
            DateOfBirth, Email, Address from PatientsDetails
            where (@Gender is null and Gender is null) or (Gender = @Gender)";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@Gender", string.IsNullOrEmpty(Gender) ? null : Gender }
            };
            return _GetDataTable(Query, Params);
        }
        public static DataTable
            FilterPatientsByBirthDateFrom(DateTime? BirthDateFrom)
        {
            string Query = @"select PatientID, PatientName, PhoneNumber, Gender,
            DateOfBirth, Email, Address from PatientsDetails 
            where (@BirthDateFrom is null or DateOfBirth >= @BirthDateFrom);";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@BirthDateFrom", BirthDateFrom.HasValue ? BirthDateFrom : null }
            };
            return _GetDataTable(Query, Params);
        }
        public static DataTable FilterPatientsByBirthDateYear(DateTime? BirthDateFrom, 
            DateTime? BirthDateTo)
        {
            string Query = @"select PatientID, PatientName, PhoneNumber, Gender,
            DateOfBirth, Email, Address from PatientsDetails 
            where DateOfBirth between @BirthDateFrom and @BirthDateTo;";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@BirthDateFrom", BirthDateFrom.HasValue ? BirthDateFrom : null },
                { "@BirthDateTo", BirthDateTo.HasValue ? BirthDateTo : null }
            };
            return _GetDataTable(Query, Params);
        }
        public static DataTable FilterPatientsByAddress(string Address)
        {
            string Query = @"select PatientID, PatientName, PhoneNumber, Gender,
            DateOfBirth, Email, Address from PatientsDetails 
            where Address like '' + @Address + '%';";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "address", string.IsNullOrEmpty(Address) ? null : Address },
            };
            return _GetDataTable(Query, Params);
        }
        public static DataTable FilterPatientsByEmail(string Email)
        {
            string Query = @"select PatientID, PatientName, PhoneNumber, Gender,
            DateOfBirth, Email, Address from PatientsDetails 
            where Email like '' + @Email + '%';";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@Email", string.IsNullOrEmpty(Email) ? null : Email }
            };
            return _GetDataTable(Query, Params);
        }
        public static int AddNewPatient(int PersonID, SqlTransaction tran, 
            SqlConnection con)
        {
            int PatientID = -1;
            string Query = @"insert into Patients (PersonID) 
            values (@PersonID); 
            select scope_identity();";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@PersonID", PersonID },
            };
            object Result = _GetScalar(Query, tran, con, Params);
            if (Result != null)
            {
                int.TryParse(Result.ToString(), out PatientID);
            }
            return PatientID;
        }
        public static DataTable GetAllPatients()
        {
            string Query = @"select PatientID, PatientName, PhoneNumber, Gender,
            DateOfBirth, Email, Address from PatientsDetails;";
            return _GetDataTable(Query);
        } 
        public static bool UpdatePatient(int PersonID, int PatientID,
            SqlTransaction tran, SqlConnection con)
        {
            string Query = @"update Patients set PersonID = @PersonID 
            where PatientID = @PatientID;";
            Dictionary <string, object> Params = new Dictionary<string, object>()
            {
                { "@PersonID", PersonID },
                { "@PatientID", PatientID }
            };
            return _ExecuteNonQuery(Query, tran, con, Params);
        }
        public static bool DeletePatient(int PatientID, SqlTransaction tran,
            SqlConnection con)
        {
            string Query = @"delete from Patients
            where PatientID = @PatientID;";
            Dictionary <string, object> Params = new Dictionary<string, object>()
            {
                { "@PatientID", PatientID }
            };
            return _ExecuteNonQuery(Query, tran, con, Params);
        }
        public static bool IsPatientExist(int PatientID)
        {
            int num = 0;
            string Query = @"select IsFound = 1 from Patients 
            where PatientID = @PatientID;";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@PatientID", PatientID }
            };
            object Result = _GetScalar(Query, Params);
            if(Result != null)
            {
                int.TryParse(Result.ToString(), out num);
            }
            return num > 0;
        }
        public static int GetPersonID(int PatientID)
        {
            int PersonID = -1;
            string Query = @"select PersonID from Patients 
            where PatientID = @PatientID;";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@PatientID", PatientID }
            };
            object Result = _GetScalar(Query, Params);
            if(Result != null)
            {
                int.TryParse(Result.ToString(), out PersonID);
            }
            return PersonID;
        }
        public static DataTable GetFromPatientsDetails()
        {
            string Query = @"select top 5 PatientName, 
            age = datediff(year, DateOfBirth, getdate()), PhoneNumber from 
            PatientsDetails order by PatientID desc;";
            return _GetDataTable(Query);
        }
        public static int GetTotalPatients()
        {
            int Count = 0;
            string Query = @"select TotalPatients = count(PatientID) from Patients;";
            object Result = _GetScalar(Query);
            if(Result != null)
            {
                int.TryParse(Result.ToString(), out Count);
            }
            return Count;
        }
        public static List<int>AppointmentIDsList(int PatientID)
        {
            string Query = @"select AppointmentID from Appointments
            where PatientID = @PatientID;";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@PatientID", PatientID }
            };
            List<int> AppointmentIDs = _GetDataTable(Query, Params).AsEnumerable().
                Select(r => (int)r["AppointmentID"]).ToList();
            return AppointmentIDs;
        }
    } 
}
