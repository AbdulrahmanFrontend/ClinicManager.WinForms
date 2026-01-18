using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsPayments
    {
        public enum enMode { AddNew, Update }
        public enMode Mode { get; set; }
        public int PaymentsID { get; set; }
        public DateTime? PaymentDate { get; set; }
        public decimal AmountPaid { get; set; }
        public string AdditionalNotes { get; set; }
        public int MethodID { get; set; }
        public clsPayments()
        {
            this.Mode = enMode.AddNew;
            this.PaymentsID = -1;
            this.PaymentDate = null;
            this.AmountPaid = 0;
            this.MethodID = -1;
            this.AdditionalNotes = string.Empty;
        }
        public bool IsPaymentDateValid()
        {
            return this.PaymentDate.HasValue;
        }
        public bool IsAmountPaidValid()
        {
            return AmountPaid >= 0;
        }
        public bool IsAdditionalNotesValid()
        {
            if (!string.IsNullOrEmpty(this.AdditionalNotes))
            {
                return this.AdditionalNotes.Length <= 200 && this.AdditionalNotes.Length > 2;
            }
            return true;
        }
        public bool IsPaymentsIDValid()
        {
            return clsPaymentsDataAccess.IsPaymentsExist(this.PaymentsID);
        }
        public bool IsPaymentsValid()
        {
            return IsPaymentDateValid() && IsAmountPaidValid() &&
                IsAdditionalNotesValid();
        }
        private bool _AddNew()
        {
            if (IsPaymentsValid())
            {
                this.PaymentsID = 
                    clsPaymentsDataAccess.AddNewPayments(this.PaymentDate, 
                    this.AmountPaid, this.AdditionalNotes, this.MethodID);
            }
            return this.PaymentsID != -1;
        }
        private bool _Update()
        {
            if (IsPaymentsValid())
            {
                return clsPaymentsDataAccess.UpdatePayments(this.PaymentsID,
                    this.PaymentDate, this.AmountPaid, this.AdditionalNotes,
                    this.MethodID);
            }
            return false;
        }
        public bool Save()
        {
            switch (this.Mode)
            {
                case enMode.AddNew:
                    if (_AddNew())
                    {
                        this.Mode = enMode.Update;
                        return true;
                    }
                    return false;
                case enMode.Update:
                    return _Update();
                default:
                    return false;
            }
        }
        public static int GetTotalTodayRevenue()
        {
            return clsPaymentsDataAccess.GetTotalTodayRevenue();
        }
        public static bool IsPaymentsExist(int PaymentsID)
        {
            return clsPaymentMethodDataAccess.IsPaymentMethodFound(PaymentsID);
        }
    }
}
