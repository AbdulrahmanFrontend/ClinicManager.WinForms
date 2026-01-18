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
    public class clsSpecializationDataAccess : clsDataAccessHelper
    {
        public struct stSpecialization
        {
            public int SpecializationID { get; set; }
            public string SpecializationName { get; set; }
            public decimal Price { get; set; }
        }
        public static stSpecialization? 
            FindBySpecializatioName(string SpecializationName)
        {
            string Query = @"select * from Specializations 
            where Name = @SpecializationName";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@SpecializationName", SpecializationName }
            };
            DataRow Row = _GetFirstRow(Query, Params);
            if (Row != null)
            {
                return new stSpecialization
                {
                    SpecializationID = (int)Row["SpecializationID"],
                    SpecializationName = Row["Name"].ToString(),
                    Price = (decimal)Row["Price"],
                };
            }
            return null;
        }
        public static bool IsSpecializationFound(int SpecializationID)
        {
            int num = 0;
            string Query = @"select IsFound = 1 from Specializations 
            where SpecializationID = @SpecializationID;";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@SpecializationID", SpecializationID }
            };
            object Result = _GetScalar(Query, Params);
            if(Result != null)
            {
                int.TryParse(Result.ToString(), out num);
            }
            return num > 0;
        }
        public static List<string> GetSpecializationsList()
        {
            string Query = @"select Name from Specializations;";
            List<string> SpecializationsList = _GetDataTable(Query).AsEnumerable().
                Select(r => r["Name"].ToString()).ToList();
            return SpecializationsList;
        }
    }
}
