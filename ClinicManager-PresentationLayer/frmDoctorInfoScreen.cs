using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static QRCoder.PayloadGenerator;

namespace ClinicManager_PresentationLayer
{
    public partial class frmDoctorInfoScreen : Form
    {
        private clsDoctor _Doctor;

        private enum _enFormBehavior { enAdd, enEdit }
        private _enFormBehavior _FormBehavior { get; set; }

        public frmDoctorInfoScreen()
        {
            InitializeComponent();
            _Doctor = new clsDoctor();
            HeaderBar.ConfigureScreenName("Add New Doctor");
            FormActionButtons.ConfigureForAdd();
            DoctorCard.
                GetSpecializationsList(clsSpecialization.GetSpecializationsList());
            DoctorCard.ConfigureGenderComboBox(_GetGendersList());
            _FormBehavior = _enFormBehavior.enAdd;
        }

        public frmDoctorInfoScreen(int DoctorID)
        {
            InitializeComponent();
            _Doctor = clsDoctor.FindByDoctorID(DoctorID);
            if (_Doctor == null)
            {
                MessageBox.Show("Doctor is not found!", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                this.Close();
            }
            HeaderBar.ConfigureScreenName("Edit Doctor Info");
            FormActionButtons.ConfigureForEdit();
            DoctorCard.
                GetSpecializationsList(clsSpecialization.GetSpecializationsList());
            DoctorCard.ConfigureGenderComboBox(_GetGendersList());
            DoctorCard.GetOutput(_Doctor.Name, _Doctor.GetSpecializationName(),
                _Doctor.PhoneNumber, _Doctor.Address, _Doctor.Email,
                _Doctor.GenderDictionary[_Doctor.Gender], _Doctor.DateOfBirth);
            _FormBehavior = _enFormBehavior.enEdit;
        }

        private List<string> _GetGendersList()
        {
            List<string> GendersList = new List<string>();
            foreach (KeyValuePair<clsDoctor.GenderType, string> Pair in
                _Doctor.GenderDictionary)
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
            MessageBox.Show("Failed to Save this Doctor.\n" + ErrorMessage, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            if(sender is TextBox)
            {
                errorpInfo.SetError((TextBox)sender, ErrorMessage);
            }
            else if (sender is ComboBox)
            {
                errorpInfo.SetError((ComboBox)sender, ErrorMessage);
            }
            else if (sender is DateTimePicker)
            {
                errorpInfo.SetError((DateTimePicker)sender, ErrorMessage);
            }
        }
        private bool _ValidateDoctor()
        {
            errorpInfo.Clear();
            switch (_FormBehavior)
            {
                case _enFormBehavior.enAdd:
                    if (clsDoctor.IsPhoneNumberFound(_Doctor.PhoneNumber))
                    {
                        _SetError(DoctorCard.TextBoxPhone, 
                            _Doctor.ValidationPhoneExistMSG());
                        return false;
                    }
                    break;
                case _enFormBehavior.enEdit:
                    if (clsDoctor.IsPhoneNumberFound(_Doctor.DoctorID, 
                        _Doctor.PhoneNumber))
                    {
                        _SetError(DoctorCard.TextBoxPhone,
                            _Doctor.ValidationPhoneUsedMSG());
                        return false;
                    }
                    break;
            }
            if (!_Doctor.IsNameValid())
            {
                _SetError(DoctorCard.TextBoxName, _Doctor.ValidationNameMSG());
                return false;
            }
            if (!_Doctor.IsDateOfBirthValid())
            {
                _SetError(DoctorCard.DateTimePackerBirthDate,
                    _Doctor.ValidationBirthDateMSG());
                return false;
            }
            if (!_Doctor.IsPhoneNumberValid())
            {
                _SetError(DoctorCard.TextBoxPhone, _Doctor.ValidationPhoneMSG());
                return false;
            }
            if (!_Doctor.IsAddressValid())
            {
                _SetError(DoctorCard.TextBoxAddress, _Doctor.ValidationAddressMSG());
                return false;
            }
            if (!_Doctor.IsEmailValid())
            {
                _SetError(DoctorCard.TextBoxEmail, _Doctor.ValidationEmailMSG());
                return false;
            }
            if (!_Doctor.IsSpecializationIDValid())
            {
                _SetError(DoctorCard.ComboBoxSpecialization,
                    _Doctor.ValidationSpecializationMSG());
                return false;
            }
            return true;
        }
        private void FormActionButtons_OnSaveButton()
        {
            var InputDoctor = DoctorCard.GetInput();
            clsSpecialization Specialization = clsSpecialization.
                FindBySpecializationName(InputDoctor.Specialization);
            if (Specialization == null)
            {
                MessageBox.Show("Specialization is not found!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _Doctor.Name = InputDoctor.Name;
            _Doctor.SpecializationID = Specialization.SpecializationID;
            _Doctor.PhoneNumber = InputDoctor.Phone;
            _Doctor.Address = InputDoctor.Address;
            _Doctor.Email = InputDoctor.Email;
            _Doctor.DateOfBirth = InputDoctor.BirthDate;
            foreach (KeyValuePair<clsPatient.GenderType, string> Pair in
                _Doctor.GenderDictionary)
            {
                if (Pair.Value == InputDoctor.Gender)
                {
                    _Doctor.Gender = Pair.Key;
                    break;
                }
            }
            if (_ValidateDoctor())
            {
                DialogResult ConfirmRequest = MessageBox.Show(
                    "Do you sure to save this doctor?", "Confirm Request", 
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1);
                if (ConfirmRequest == DialogResult.OK)
                {
                    if (clsDoctorServices.SaveDoctor(_Doctor))
                    {
                        MessageBox.Show("Doctor Saved Successfully.", "Success", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (_FormBehavior == _enFormBehavior.enAdd)
                        {
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Failed to Save this Doctor.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void FormActionButtons_OnDeleteButton()
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this doctor?", "Confirm Deletion",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
            {
                bool isDeleted = clsDoctorServices.DeleteDoctor(_Doctor.DoctorID);
                if (isDeleted)
                {
                    MessageBox.Show("Doctor is deleted successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to delete the Doctor.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Close();
            }
        }
    }
}
