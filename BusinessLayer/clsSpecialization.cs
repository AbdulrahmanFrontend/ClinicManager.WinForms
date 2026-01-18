using DataAccessLayer;
using LoggingLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BusinessLayer 
{
    public class clsSpecialization
    {
        public enum enMode { AddNew, Update }
        public enMode Mode;
        public int SpecializationID { get; private set; }
        public string SpecializationName { get; set; }
        public decimal Price { get; set; }
        private clsSpecialization(int SpecializationID, string SpacializationName, 
            decimal Price)
        {
            this.SpecializationID = SpecializationID;
            this.SpecializationName = SpacializationName;
            this.Price = Price;
            this.Mode = enMode.Update;
        }
        public static clsSpecialization 
            FindBySpecializationName(string SpecializationName)
        {
            var Specialization = clsSpecializationDataAccess.
                FindBySpecializatioName(SpecializationName);
            if (Specialization.HasValue)
            {
                int SpecializationID = Specialization.Value.SpecializationID;
                decimal Price = Specialization.Value.Price;
                return new 
                    clsSpecialization(SpecializationID, SpecializationName, Price);
            }
            return null;
        }
        public static List<string> GetSpecializationsList() =>
            clsSpecializationDataAccess.GetSpecializationsList();
        public static bool IsSpecializationFound(int SpecializationID)
            => clsSpecializationDataAccess.IsSpecializationFound(SpecializationID);
    } 
}
