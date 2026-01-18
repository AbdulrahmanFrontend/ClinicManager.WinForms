using LoggingLayer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccessLayer 
{ 
    public class clsPersonDataAccess : clsDataAccessHelper
    {
        public static int AddNewPerson(string Name, string PhoneNumber, 
            DateTime? DateOfBirth, string Gender, string Address, string Email,
            SqlTransaction tran, SqlConnection con)
        {
            int PersonID = -1;
            string Query = @"insert into Persons 
            Values (@Name, @DateOfBirth, @PhoneNumber, @Email, @Gender, @Address);
            select scope_identity();";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@Name", Name },
                { "@PhoneNumber", PhoneNumber },
                { "@DateOfBirth", DateOfBirth.HasValue ? DateOfBirth : null },
                { "@Gender", string.IsNullOrEmpty(Gender) ? null : Gender },
                { "@Address", string.IsNullOrEmpty(Address) ? null : Address },
                { "@Email", string.IsNullOrEmpty(Email) ? null : Email }
            };
            object Result = _GetScalar(Query, tran, con, Params);
            if (Result != null)
            {
                int.TryParse(Result.ToString(), out PersonID);
            }
            return PersonID;
        }
        public static bool UpdatePerson(int PersonID, string Name, string PhoneNumber, 
            DateTime? DateOfBirth, string Gender, string Address, string Email,
            SqlTransaction tran, SqlConnection con)
        {
            string Query = @"update Persons
            set Name = @Name, PhoneNumber = @PhoneNumber, DateOfBirth = @DateOfBirth,
            Gender = @Gender, Address = @Address, Email = @Email 
            where PersonID = @PersonID";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@PersonID", PersonID },
                { "@Name", Name },
                { "@PhoneNumber", PhoneNumber },
                { "@DateOfBirth", DateOfBirth.HasValue ? DateOfBirth : null },
                { "@Gender", string.IsNullOrEmpty(Gender) ? null : Gender },
                { "@Address", string.IsNullOrEmpty(Address) ? null : Address },
                { "@Email", string.IsNullOrEmpty(Email) ? null : Email }
            };
            return _ExecuteNonQuery(Query, tran, con, Params);
        }
        public static bool DeletePerson(int PersonID, SqlTransaction tran,
            SqlConnection con)
        {
            string Query = @"delete from Persons 
            where PersonID = @PersonID;";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@PersonID", PersonID }
            };
            return _ExecuteNonQuery(Query, tran, con, Params);
        }
        public static bool IsPhoneNumberFound(int PersonID, string PhoneNumber)
        {
            int num = 0;
            string Query = @"select IsFound = 1 from Persons 
            where (not PersonID = @PersonID) and PhoneNumber = @PhoneNumber;";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@PersonID", PersonID },
                { "@PhoneNumber", PhoneNumber }
            };
            object Result = _GetScalar(Query, Params);
            if (Result != null)
            {
                int.TryParse(Result.ToString(), out num);
            }
            return num > 0;
        }
        public static bool IsPhoneNumberFound(string PhoneNumber)
        {
            int num = 0;
            string Query = @"select IsFound = 1 from Persons 
            where PhoneNumber = @PhoneNumber;";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@PhoneNumber", PhoneNumber }
            };
            object Result = _GetScalar(Query, Params);
            if (Result != null)
            {
                int.TryParse(Result.ToString(), out num);
            }
            return num > 0;
        }
        public static bool IsPersonExist(int PersonID)
        {
            int num = 0;
            string Query = @"select IsFound = 1 from Persons 
            where PersonID = @PersonID;";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@PersonID", PersonID }
            };
            object Result = _GetScalar(Query, Params);
            if (Result != null)
            {
                int.TryParse(Result.ToString(), out num);
            }
            return num > 0;
        }
    }
}
