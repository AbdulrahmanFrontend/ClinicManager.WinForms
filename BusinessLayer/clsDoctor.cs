using DataAccessLayer;
using LoggingLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace BusinessLayer 
{
    public class clsDoctor : clsPerson
    { 
        public int DoctorID { get; set; }
        public int SpecializationID { set; get; }
        public clsDoctor() : base()
        {
            this.DoctorID = -1;
            this.SpecializationID = -1;
        }
        private clsDoctor(int PersonID, int DoctorID, string Name, 
            int SpecializationID, string PhoneNumber, DateTime? DateOfBirth, 
            string Gender, string Address, string Email) : 
            base(PersonID, Name, PhoneNumber, DateOfBirth, Gender, Address, Email)
        {
            this.DoctorID = DoctorID;
            this.SpecializationID = SpecializationID;
        }
        public static clsDoctor FindByDoctorID(int DoctorID)
        {
            var Doctor = clsDoctorDataAccess.GetDoctorByDoctorID(DoctorID);
            if (Doctor.HasValue)
            {
                int PersonID = Doctor.Value.PersonID,
                    SpecializationID = Doctor.Value.DoctorID;
                string Name = Doctor.Value.Name, PhoneNumber = Doctor.Value.Phone,
                    Gender = Doctor.Value.Gender, Address = Doctor.Value.Address,
                    Email = Doctor.Value.Email;
                DateTime? DateOfBirth = Doctor.Value.BirthDate;
                return new clsDoctor(PersonID, DoctorID, Name, SpecializationID,
                    PhoneNumber, DateOfBirth, Gender, Address, Email);
            }
            return null;
        }
        public override bool IsDateOfBirthValid()
        {
            if (this.DateOfBirth.HasValue)
            {
                int age = DateTime.Today.Year - DateOfBirth.Value.Year;
                return age >= 25 && age <= 80;
            }
            return true;
        }
        public bool IsSpecializationIDValid()
        {
            return clsSpecialization.IsSpecializationFound(this.SpecializationID);
        }
        public string ValidationBirthDateMSG()
        {
            return "Date of Birth should be less than or equal 80 years old and " +
                "larger than or equal 25 years old;";
        }
        public string ValidationSpecializationMSG()
        {
            return "This Specialization is not found!";
        }
        public static bool IsPhoneNumberFound(int DoctorID, string PhoneNumber)
        {
            int PersonID = clsDoctorDataAccess.GetPersonID(DoctorID);
            return _IsPhoneNumberFound(PersonID, PhoneNumber);
        }
        public bool IsDoctorIDValid()
        {
            return clsDoctorDataAccess.IsDoctorExist(this.DoctorID);
        }
        public override bool IsValid()
        {
            return base.IsValid() && IsSpecializationIDValid();
        }
        public static DataTable GetAllDoctors()
        {
            return clsDoctorDataAccess.GetAllDoctors();
        }
        public static bool IsDoctorExist(int DoctorID)
        {
            return clsDoctorDataAccess.IsDoctorExist(DoctorID);
        }
        public static int GetTotalDoctors()
        {
            return clsDoctorDataAccess.GetTotalDoctors();
        }
        public static DataTable FilterByName(string Name)
        {
            return clsDoctorDataAccess.FilterDoctorsByDoctorName(Name);
        }
        public static DataTable FilterByPhone(string Phone)
        {
            return clsDoctorDataAccess.FilterDoctorsByPhoneNumber(Phone);
        }
        public static DataTable FilterByBirthDateFrom(DateTime? BirthDateFrom)
        {
            return clsDoctorDataAccess.FilterDoctorsByBirthDateFrom(BirthDateFrom);
        }
        public static DataTable FilterByBirthDateYear(DateTime? BirthDateFrom,
            DateTime? BirthDateTo)
        {
            return clsDoctorDataAccess.FilterDoctorsByBirthDateYear(BirthDateFrom, 
                BirthDateTo);
        }
        public static DataTable FilterByGender(string Gender)
        {
            return clsDoctorDataAccess.FilterDoctorsByGender(Gender);
        }
        public static DataTable FilterByAddress(string Address)
        {
            return clsDoctorDataAccess.FilterDoctorsByAddress(Address);
        }
        public static DataTable FilterByEmail(string Email)
        {
            return clsDoctorDataAccess.FilterDoctorsByEmail(Email);
        }
        public static DataTable FilterBySpecialization(string SpecializationName)
        {
            return clsDoctorDataAccess.
                FilterDoctorsBySpecialization(SpecializationName);
        }
        public string GetSpecializationName()
        {
            return clsDoctorDataAccess.GetSpecializationNameByDoctorID(this.DoctorID);
        }
        public static List<string> GetDoctorsList()
        {
            return clsDoctorDataAccess.GetDoctorsList();
        }
    } 
}
