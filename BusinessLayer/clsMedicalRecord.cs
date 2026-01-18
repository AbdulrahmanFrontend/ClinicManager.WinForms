using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsMedicalRecord
    {
        public enum enMode { AddNew, Update }
        public enMode Mode { get; set; }
        public int MedicalRecordID { get; private set; }
        public string VisitDescription { get; set; }
        public string Diagnosis { get; set; }
        public string AdditionalNotes { get; set; }
        public clsMedicalRecord()
        {
            this.Mode = enMode.AddNew;
            this.MedicalRecordID = -1;
            this.VisitDescription = string.Empty;
            this.Diagnosis = string.Empty;
            this.AdditionalNotes = string.Empty;
        }
        private clsMedicalRecord(int MedicalRecord, string VisitDescription,
            string Diagnosis, string AdditionalNotes)
        {
            this.MedicalRecordID = MedicalRecord;
            this.VisitDescription = VisitDescription;
            this.Diagnosis = Diagnosis;
            this.AdditionalNotes = AdditionalNotes;
            this.Mode = enMode.Update;
        }
        public static clsMedicalRecord FindByMedicalRecordID(int MedicalRecordID)
        {
            var MedicalRecord = 
                clsMedicalRecordDataAccess.GetByMedicalRecordID(MedicalRecordID);
            if (MedicalRecord.HasValue)
            {
                string VisitDescription = MedicalRecord.Value.VisitDescription,
                    Diagnosis = MedicalRecord.Value.Diagnosis,
                    AdditionalNotes = MedicalRecord.Value.AdditionalNotes;
                return new clsMedicalRecord(MedicalRecordID, VisitDescription,
                    Diagnosis, AdditionalNotes);
            }
            return null;
        }
        private bool _IsPropertyValid(string Property, int Length)
        {
            return !string.IsNullOrEmpty(Property) && Property.Length > 2 && 
                Property.Length <= Length;
        }
        public bool IsVisitDescriptionValid()
        {
            return _IsPropertyValid(this.VisitDescription, 200);
        }
        public bool IsDiagnosisValid()
        {
            return _IsPropertyValid(this.Diagnosis, 200);
        }
        public bool IsAdditionalNotesValid()
        {
            return !string.IsNullOrEmpty(this.AdditionalNotes) ? 
                _IsPropertyValid(this.AdditionalNotes, 200) : true;
        }
        public bool IsMedicalRecordValid()
        {
            return IsVisitDescriptionValid() && IsDiagnosisValid() 
                && IsAdditionalNotesValid();
        }
        private bool _AddNew()
        {
            if (IsMedicalRecordValid())
            {
                this.MedicalRecordID = clsMedicalRecordDataAccess.AddNewMedicalRecord(
                    this.VisitDescription, this.Diagnosis, this.AdditionalNotes);
            }
            return this.MedicalRecordID != -1;
        }
        private bool _Update()
        {
            if (IsMedicalRecordValid())
            {
                return clsMedicalRecordDataAccess.UpdateMedicalRecord(this.MedicalRecordID,
                    this.VisitDescription, this.Diagnosis, this.AdditionalNotes);
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
        public static bool IsMedicalRecordExist(int MedicalRecordID)
        {
            return clsMedicalRecordDataAccess.IsMedicalRecordExist(MedicalRecordID);
        }
    }
}
