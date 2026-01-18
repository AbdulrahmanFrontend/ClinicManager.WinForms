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
    public class clsPaymentMethodDataAccess : clsDataAccessHelper
    {
        public struct stPaymentMethod
        {
            public int MethodID { get; set; }
            public string MethodName { get; set; }
        }
        public static stPaymentMethod? FindMethodByMethodName(string MethodName)
        {
            string Query = @"SELECT * FROM PaymentMethods 
            WHERE MethodName = @MethodName;";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@MethodName", MethodName }
            };
            DataRow Row = _GetFirstRow(Query, Params);
            if(Row != null)
            {
                return new stPaymentMethod
                {
                    MethodID = (int)Row["PaymentMethodID"],
                    MethodName = Row["MethodName"].ToString()
                };
            }
            return null;
        }
        public static List<string> GetMethodsList()
        {
            string Query = "SELECT * FROM PaymentMethods;";
            List<string> MethodsList = _GetDataTable(Query).AsEnumerable().
                Select(r => r["MethodName"].ToString()).ToList();
            return MethodsList;
        }
        public static bool IsPaymentMethodFound(int PaymentMethodID)
        {
            int num = 0;
            string Query = @"select IsFound = 1 from PaymentMethods 
            where PaymentMethodID = @PaymentMethodID;";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@PaymentMethodID", PaymentMethodID }
            };
            object Result = _GetScalar(Query, Params);
            if(Result != null)
            {
                int.TryParse(Result.ToString(), out num);
            }
            return num > 0;
        }
    }
}
