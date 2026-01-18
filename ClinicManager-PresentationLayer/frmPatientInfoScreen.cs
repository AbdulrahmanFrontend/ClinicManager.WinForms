using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;
using static QRCoder.PayloadGenerator;

namespace ClinicManager_PresentationLayer
{
    public partial class frmPatientInfoScreen : Form
    {
        clsPatient _Patient;

        private enum _enFormBehavior { enAdd, enEdit }
        private _enFormBehavior _FormBehavior { get; set; }

        public frmPatientInfoScreen()
        {
            InitializeComponent();
            _FormBehavior = _enFormBehavior.enAdd;
            _Patient = new clsPatient();
            HeaderBar.ConfigureScreenName("Add New Patient");
            FormActionButtons.ConfigureForAdd();
            PatientCard.ConfigureGenderComboBox(_GetGendersList());
        }

        public frmPatientInfoScreen(int PatientID)
        {
            InitializeComponent();
            _Patient = clsPatient.FindByPatientID(PatientID);
            if (_Patient == null)
            {
                MessageBox.Show("Patient is not found!", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            _FormBehavior = _enFormBehavior.enEdit;
            HeaderBar.ConfigureScreenName("Edit Patient Info");
            FormActionButtons.ConfigureForEdit();
            PatientCard.ConfigureGenderComboBox(_GetGendersList());
            PatientCard.GetOutput(_Patient.Name, _Patient.PhoneNumber, 
                _Patient.Address, _Patient.Email,
                _Patient.GenderDictionary[_Patient.Gender], _Patient.DateOfBirth);
        }

        private List<string> _GetGendersList()
        {
            List<string> GendersList = new List<string>();
            foreach (KeyValuePair<clsPatient.GenderType, string> Pair in
                _Patient.GenderDictionary)
            {
                GendersList.Add(Pair.Value);
            }
            return GendersList;
        }

        private void FormActionButtons_OnCancelButton()
        {
            this.Close();
        }

        private void _SetError(object sender, string ErrorMessage)
        {
            errorpInfo.Clear();
            MessageBox.Show("Failed to Save this Patient.\n" + ErrorMessage, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (sender is TextBox)
            {
                errorpInfo.SetError((TextBox)sender, ErrorMessage);
            }
            else if (sender is DateTimePicker)
            {
                errorpInfo.SetError((DateTimePicker)sender, ErrorMessage);
            }
        }
        private bool _ValidatePatient()
        {
            switch (_FormBehavior)
            {
                case _enFormBehavior.enAdd:
                    if (clsPatient.IsPhoneNumberFound(_Patient.PhoneNumber))
                    {
                        _SetError(PatientCard.TextBoxPhone, 
                            _Patient.ValidationPhoneExistMSG());
                        return false;
                    }
                    break;
                case _enFormBehavior.enEdit:
                    if (clsPatient.IsPhoneNumberFound(_Patient.PatientID,
                        _Patient.PhoneNumber))
                    {
                        _SetError(PatientCard.TextBoxPhone,
                            _Patient.ValidationPhoneUsedMSG());
                        return false;
                    }
                    break;
            }
            if (!_Patient.IsNameValid())
            {
                _SetError(PatientCard.TextBoxName, _Patient.ValidationNameMSG());
                return false;
            }
            if (!_Patient.IsDateOfBirthValid())
            {
                _SetError(PatientCard.DateTimePackerBirthDate,
                    _Patient.ValidationBirthDateMSG());
                return false;
            }
            if (!_Patient.IsPhoneNumberValid())
            {
                _SetError(PatientCard.TextBoxPhone, _Patient.ValidationPhoneMSG());
                return false;
            }
            if (!_Patient.IsAddressValid())
            {
                _SetError(PatientCard.TextBoxAddress, 
                    _Patient.ValidationAddressMSG());
                return false;
            }
            if (!_Patient.IsEmailValid())
            {
                _SetError(PatientCard.TextBoxEmail, _Patient.ValidationEmailMSG());
                return false;
            }
            return true;
        }
        private void FormActionButtons_OnSaveButton()
        {
            var InputPatient = PatientCard.GetInput();
            _Patient.Name = InputPatient.Name;
            _Patient.PhoneNumber = InputPatient.Phone;
            _Patient.Address = InputPatient.Address;
            _Patient.Email = InputPatient.Email;
            _Patient.DateOfBirth = InputPatient.BirthDate;
            foreach (KeyValuePair<clsPatient.GenderType, string> Pair in
                _Patient.GenderDictionary)
            {
                if (Pair.Value == InputPatient.Gender)
                {
                    _Patient.Gender = Pair.Key;
                    break;
                }
            }
            if (_ValidatePatient())
            {
                DialogResult ConfirmRequest = MessageBox.Show(
                    "Do you sure to save this patient?", "Confirm Request",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1);
                if (ConfirmRequest == DialogResult.OK)
                {
                    if (clsPatientServices.SavePatient(_Patient))
                    {
                        MessageBox.Show("Patient Saved Successfully.", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (_FormBehavior == _enFormBehavior.enAdd)
                        {
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Failed to Saved This Patient.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void FormActionButtons_OnDeleteButton()
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this patient?", "Confirm Deletion",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                bool isDeleted = clsPatientServices.DeletePatient(_Patient.PatientID);
                if (isDeleted)
                {
                    MessageBox.Show("Patient is deleted successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to delete the patient.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Close();
            }
        }
    }
}
