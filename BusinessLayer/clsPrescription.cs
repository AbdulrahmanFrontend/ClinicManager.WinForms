using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsPrescription
    {
        public enum enMode { AddNew, Update }
        public enMode Mode { get; set; }
        public int PrescriptionID { get; private set; }
        public string Dosage {  get; set; }
        public string MedicalName { get; set; }
        public string Frequently { get; set; }
        public string SpecialInstructions { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int MedicalRecordID { get; set; }
        private clsPrescription(int PrescriptionID, string Dosage,
            string MedicalName, string Frequently, string SpecialInstructions,
            DateTime? StartDate, DateTime? EndDate, int medicalRecordID)
        {
            this.PrescriptionID = PrescriptionID;
            this.Dosage = Dosage;
            this.MedicalName = MedicalName;
            this.Frequently = Frequently;
            this.SpecialInstructions = SpecialInstructions;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.Mode = enMode.Update;
            MedicalRecordID = medicalRecordID;
        }
        public clsPrescription()
        {
            this.PrescriptionID = -1;
            this.Dosage = string.Empty;
            this.MedicalName = string.Empty;
            this.Frequently = string.Empty;
            this.SpecialInstructions = "No Special Instructions";
            this.StartDate = DateTime.Today;
            this.EndDate = null;
            this.Mode = enMode.AddNew;
            this.MedicalRecordID = -1;
        }
        public static clsPrescription findByPrescriptionID(int PrescriptionID)
        {
            var Prescription = 
                clsPrescriptionDataAccess.GetPrescriptionByID(PrescriptionID);
            if (Prescription.HasValue)
            {
                string Dosage = Prescription.Value.Dosage,
                    MedicalName = Prescription.Value.MedicalName,
                    Frequently = Prescription.Value.Frequently, 
                    SpecialInstructions = Prescription.Value.SpecialInstructions;
                DateTime? StartDate = Prescription.Value.StartDate,
                    EndDate = Prescription.Value.EndDate;
                int MedicalRecordID = Prescription.Value.MedicalRecordID;
                return new clsPrescription(PrescriptionID, Dosage, MedicalName, 
                    Frequently, SpecialInstructions, StartDate, EndDate,
                    MedicalRecordID);
            }
            return null;
        }
        public bool IsDosageValid()
        {
            return !string.IsNullOrEmpty(this.Dosage) && Dosage.Length > 2
                && Dosage.Length <= 50;
        }
        public bool IsMedicalNameValid()
        {
            return !string.IsNullOrEmpty(this.MedicalName) && MedicalName.Length > 2 
                && MedicalName.Length <= 100;
        }
        public bool IsFrequentlyValid()
        {
            return !string.IsNullOrWhiteSpace(this.Frequently) && Frequently.Length > 2
                && Frequently.Length <= 50;
        }
        public bool IsSpecialInstructionsValid()
        {
            if (!string.IsNullOrEmpty(this.SpecialInstructions))
            {
                return SpecialInstructions.Length > 2 && 
                    SpecialInstructions.Length <= 200;
            }
            this.SpecialInstructions = "No Special Instructions";
            return true;
        }
        public bool IsDateValid()
        {
            if (EndDate.HasValue)
            {
                return StartDate.HasValue && StartDate >= DateTime.Today && 
                    EndDate.Value > StartDate;
            }
            return true;
        }
        public bool IsMedicalRecordIDValid()
        {
            return clsMedicalRecord.IsMedicalRecordExist(this.MedicalRecordID);
        }
        public bool IsValid()
        {
            return IsDosageValid() && IsMedicalNameValid() && IsFrequentlyValid() 
                && IsDateValid() && IsMedicalNameValid();
        }
        private bool _AddNew()
        {
            if (IsValid())
            {
                this.PrescriptionID = clsPrescriptionDataAccess.AddNewPrescription(
                    this.Dosage, this.MedicalName, this.Frequently,
                    this.SpecialInstructions, this.StartDate, this.EndDate,
                    this.MedicalRecordID);
            }
            return PrescriptionID != -1;
        }
        private bool _Update()
        {
            if (IsValid())
            {
                return clsPrescriptionDataAccess.UpdatePrescription(
                    this.PrescriptionID, this.Dosage, this.MedicalName,
                    this.Frequently, this.SpecialInstructions, this.StartDate, 
                    this.EndDate, this.MedicalRecordID);
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
        public static bool Delete(int PrescriptionID)
        {
            if(!IsPrescriptionExist(PrescriptionID))
            {
                return false;
            }
            return clsPrescriptionDataAccess.DeletePrescription(PrescriptionID);
        }
        public static bool IsPrescriptionExist(int PrescriptionID)
        {
            return clsPrescriptionDataAccess.IsPrescriptionExist(PrescriptionID);
        }
    }
}
