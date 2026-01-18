using LoggingLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsPaymentsDataAccess : clsDataAccessHelper
    {
        public static int AddNewPayments(DateTime? PaymentDate, decimal AmountPaid,
            string AdditionalNotes, int MethodID)
        {
            int PaymentsID = -1;
            string Query = @"insert into Payments
            values (@PaymentDate, @AmountPaid, @AdditionalNotes, @MethodID);
            select scope_identity();";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@PaymentDate", PaymentDate },
                { "@AmountPaid", AmountPaid },
                { "@AdditionalNotes",
                    string.IsNullOrEmpty(AdditionalNotes) ? null : AdditionalNotes },
                { "@MethodID", MethodID }
            };
            object Result = _GetScalar(Query, Params);
            if(Result != null)
            {
                if(int.TryParse(Result.ToString(), out PaymentsID))
                {
                    Logger.LogInfo($"Adding New Payments [{PaymentsID}] " +
                        $"Done Successfully in clsPaymentsDataAccess.");
                }
            }
            return PaymentsID;
        }
        public static int AddNewPayments(DateTime? PaymentDate, decimal AmountPaid,
            string AdditionalNotes, int MethodID, SqlTransaction tran,
            SqlConnection con)
        {
            int PaymentsID = -1;
            string Query = @"insert into Payments
            values (@PaymentDate, @AmountPaid, @AdditionalNotes, @MethodID);
            select scope_identity();";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@PaymentDate", PaymentDate },
                { "@AmountPaid", AmountPaid },
                { "@AdditionalNotes",
                    string.IsNullOrEmpty(AdditionalNotes) ? null : AdditionalNotes },
                { "@MethodID", MethodID }
            };
            object Result = _GetScalar(Query, tran, con, Params);
            if (Result != null)
            {
                int.TryParse(Result.ToString(), out PaymentsID);
            }
            return PaymentsID;
        }
        public static bool UpdatePayments(int PaymentsID, DateTime? PaymentDate, 
            decimal AmountPaid, string AdditionalNotes, int MethodID)
        {
            string Query = @"update Payments
            set PaymentsID = @PaymentsID, PaymentDate = @PaymentDate, 
            AmountPaid = @AmountPaid, AdditionalNotes = @AdditionalNotes,
            MethodID = @MethodID;";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@PaymentsID", PaymentsID },
                { "@PaymentDate", PaymentDate },
                { "@AmountPaid", AmountPaid },
                { "@AdditionalNotes", AdditionalNotes },
                { "@MethodID", MethodID }
            };
            if(_ExecuteNonQuery(Query, Params))
            {
                Logger.LogInfo($"Update Payments [{PaymentsID}]" +
                    $" Done Successfully in clsPaymentsDataAccess.");
                return true;
            }
            return false;
        }
        public static int GetTotalTodayRevenue()
        {
            int Total = 0;
            string Query = @"select TotalTodayRevenue = sum(AmountPaid) from 
            Payments where cast(PaymentDate as date) = cast(getdate() as date);";
            object Result = _GetScalar(Query);
            if(Result != null)
            {
                int.TryParse(Result.ToString(), out Total);
            }
            return Total;
        }
        public static bool DeletePayments(int PaymentsID, SqlTransaction tran,
            SqlConnection con)
        {
            string Query = @"delete from Payments where PaymentsID = @PaymentsID;";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@PaymentsID", PaymentsID }
            };
            return _ExecuteNonQuery(Query, tran, con, Params);
        }
        public static bool DeletePayments(int PaymentsID)
        {
            string Query = @"delete from Payments where PaymentsID = @PaymentsID;";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@PaymentsID", PaymentsID }
            };
            if(_ExecuteNonQuery(Query, Params))
            {
                Logger.LogInfo("Deleting Payments [{PaymentsID}] Done Successfully" +
                    " in clsPaymentsDataAccess;");
                return true;
            }
            return false;
        }
        public static bool IsPaymentsExist(int PaymentsID)
        {
            int num = 0;
            string Query = @"select IsFound = 1 from Payments
            where PaymentsID = @PaymentsID;";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@PaymentsID", PaymentsID }
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
