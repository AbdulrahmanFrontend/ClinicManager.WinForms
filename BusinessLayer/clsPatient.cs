using DataAccessLayer;
using LoggingLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{ 
    public class clsPatient : clsPerson
    { 
        public int PatientID { get; set; } 
        public clsPatient() : base()
        { 
            this.PatientID = -1;
        } 
        private clsPatient(int PersonID, int PatientID, string Name, 
            string PhoneNumber, DateTime? DateOfBirth, string Gender, string Address,
            string Email) : 
            base(PersonID, Name, PhoneNumber, DateOfBirth, Gender, Address, Email)
        { 
            this.PatientID = PatientID;
        } 
        public static clsPatient FindByPatientID(int PatientID)
        {
            var Patient = clsPatientDataAccess.GetPatientByPatientID(PatientID);
            if (Patient.HasValue)
            {
                int PersonID = Patient.Value.PersonID;
                string Name = Patient.Value.Name, PhoneNumber = Patient.Value.Phone,
                    Gender = Patient.Value.Gender, Address = Patient.Value.Address,
                    Email = Patient.Value.Email;
                DateTime? DateOfBirth = Patient.Value.BirthDate;
                return new clsPatient(PersonID, PatientID, Name, PhoneNumber,
                    DateOfBirth, Gender, Address, Email);
            }
            return null;
        }
        public override bool IsDateOfBirthValid()
        { 
            if (this.DateOfBirth.HasValue) 
            { 
                int age = DateTime.Today.Year - DateOfBirth.Value.Year; 
                return age >= 0 && age <= 120;
            }
            return true;
        }
        public bool IsPatientIDValid()
        {
            return clsPatientDataAccess.IsPatientExist(this.PatientID);
        }
        public string ValidationBirthDateMSG()
        {
            return "Age of patient should be larger than or equal to 0 years old " +
                "and less than or equal 120 years old;";
        }
        public static bool IsPhoneNumberFound(int PatientID, string PhoneNumber)
        {
            int PersonID = clsPatientDataAccess.GetPersonID(PatientID);
            return _IsPhoneNumberFound(PersonID, PhoneNumber);
        }
        public static DataTable GetAllPatients()
        {
            return clsPatientDataAccess.GetAllPatients();
        }
        public static bool IsPatientExist(int PatientID)
        {
            return clsPatientDataAccess.IsPatientExist(PatientID);
        }
        public static DataTable GetFromPatientsDetails()
        {
            return clsPatientDataAccess.GetFromPatientsDetails();
        }
        public static int GetTotalPatients()
        {
            return clsPatientDataAccess.GetTotalPatients();
        }
        public static DataTable FilterByName(string Name)
        {
            return clsPatientDataAccess.FilterPatientsByPatientName(Name);
        }
        public static DataTable FilterByPhone(string Phone)
        {
            return clsPatientDataAccess.FilterPatientsByPhoneNumber(Phone);
        }
        public static DataTable FilterByBirthDateFrom(DateTime? BirthDateFrom)
        {
            return clsPatientDataAccess.FilterPatientsByBirthDateFrom(BirthDateFrom);
        }
        public static DataTable FilterByBirthDateYear(DateTime? BirthDateFrom,
            DateTime? BirthDateTo)
        {
            return clsPatientDataAccess.FilterPatientsByBirthDateYear(BirthDateFrom, 
                BirthDateTo);
        }
        public static DataTable FilterByGender(string Gender)
        {
            return clsPatientDataAccess.FilterPatientsByGender(Gender);
        }
        public static DataTable FilterByAddress(string Address)
        {
            return clsPatientDataAccess.FilterPatientsByAddress(Address);
        }
        public static DataTable FilterByEmail(string Email)
        {
            return clsPatientDataAccess.FilterPatientsByEmail(Email);
        }
    }
}
