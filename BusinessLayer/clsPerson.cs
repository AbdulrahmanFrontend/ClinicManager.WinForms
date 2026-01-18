using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusinessLayer 
{ 
    public abstract class clsPerson
    { 
        public enum enMode { AddNew, Update }
        public enMode Mode { get; set; }
        public int PersonID { get; set; } 
        public string Name { get; set; } 
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; } 
        public string Email { get; set; }
        public enum GenderType { Male, Female, Unspecified }
        public GenderType Gender { get; set; }
        public Dictionary<GenderType, string> GenderDictionary = 
            new Dictionary<GenderType, string>()
            {
                { GenderType.Male, "M" },
                { GenderType.Female, "F" },
                { GenderType.Unspecified, "" }
            };
        public clsPerson()
        { 
            this.PersonID = -1;
            this.Name = string.Empty;
            this.Address = string.Empty;
            this.PhoneNumber = string.Empty;
            this.Email = string.Empty;
            this.DateOfBirth = null;
            this.Gender = GenderType.Unspecified;
            this.Mode = enMode.AddNew;
        } 
        public clsPerson(int PersonID, string Name, string PhoneNumber, 
            DateTime? DateOfBirth, string Gender, string Address, string Email) 
        { 
            this.PersonID = PersonID; 
            this.Name = Name; 
            this.PhoneNumber = PhoneNumber;
            this.DateOfBirth = DateOfBirth;
            this.Address = Address;
            this.Email = Email; 
            this.Mode = enMode.Update;
            foreach (KeyValuePair<GenderType, string> Pair in GenderDictionary)
            {
                if(string.IsNullOrEmpty(Gender))
                {
                    this.Gender = GenderType.Unspecified;
                    break;
                }
                else if(Pair.Value == Gender)
                {
                    this.Gender = Pair.Key;
                    break;
                }
            }
        }
        public bool IsNameValid()
        {
            return !string.IsNullOrEmpty(Name) && Name.Length > 2 &&
                Name.Length <= 100;
        }
        public bool IsEmailValid() 
        { 
            if (!string.IsNullOrEmpty(Email))
            { 
                return Regex.IsMatch(this.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$") && 
                    Email.Length <= 100; 
            }
            return true;
        }
        public bool IsPhoneNumberValid()
        {
            return !string.IsNullOrEmpty(PhoneNumber) && 
                Regex.IsMatch(this.PhoneNumber, @"^01[0125][0-9]{8}$") && 
                PhoneNumber.Length <= 20;
        }
        protected static bool _IsPhoneNumberFound(int PersonID,
            string PhoneNumber)
        {
            return clsPersonDataAccess.IsPhoneNumberFound(PersonID, PhoneNumber);
        }
        public static bool IsPhoneNumberFound(string PhoneNumber)
        {
            return clsPersonDataAccess.IsPhoneNumberFound(PhoneNumber);
        }
        public abstract bool IsDateOfBirthValid();
        public bool IsAddressValid()
        {
            if (!string.IsNullOrEmpty(Address))
            {
                return Address.Length <= 200;
            }
            return true;
        }
        public bool IsPersonIDValid()
        {
            return clsPersonDataAccess.IsPersonExist(this.PersonID);
        }
        public string ValidationNameMSG()
        {
            return "Name is Required and should be larger than 2 or shorter than " +
                "100;";
        }
        public string ValidationPhoneMSG()
        {
            return "Phone is required, should be start with " +
                "{'010','011','012','015'} and contain 11 digits;";
        }
        public string ValidationPhoneExistMSG()
        {
            return @"Phone should be not addedd before;";
        }
        public string ValidationPhoneUsedMSG()
        {
            return @"Phone should be not used by another;";
        }
        public string ValidationAddressMSG()
        {
            return "Address is should be larger than 5 and shorter than or equal " +
                "200;";
        }
        public string ValidationEmailMSG()
        {
            return "Email should be contain '@' and '.' and be shorter than or " +
            "equal 100;";
        }
        public virtual bool IsValid()
        {
            return IsNameValid() && IsPhoneNumberValid() && IsEmailValid() && 
                IsDateOfBirthValid() && IsAddressValid();
        }
    } 
}
