using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsPaymentMethod
    {
        public enum enMode { enAddNew, enUpdate }
        public enMode Mode { get; set; }
        public int MethodID { get; private set; }
        public string MethodName { get; set; }
        private clsPaymentMethod(int MethodID, string MethodName)
        {
            this.MethodID = MethodID;
            this.MethodName = MethodName;
            this.Mode = enMode.enUpdate;
        }
        public static clsPaymentMethod FindByMethodName(string MethodName)
        {
            var Method = 
                clsPaymentMethodDataAccess.FindMethodByMethodName(MethodName);
            if (Method.HasValue)
            {
                int MethodID = Method.Value.MethodID;
                return new clsPaymentMethod(MethodID, MethodName);
            }
            return null;
        }
        public static List<string> GetMethodsList()
        {
            return clsPaymentMethodDataAccess.GetMethodsList();
        }
        public static bool IsPaymentMethodFound(int PaymentMethodID)
        {
            return clsPaymentMethodDataAccess.IsPaymentMethodFound(PaymentMethodID);
        }
    }
}
