using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace ClinicManager_PresentationLayer
{
    public partial class ucPatientCard : UserControl
    {
        public ucPatientCard()
        {
            InitializeComponent();
        }

        public TextBox TextBoxName
        {
            get
            {
                return tbName;
            }
        }
        public TextBox TextBoxPhone
        {
            get
            {
                return tbPhone;
            }
        }
        public TextBox TextBoxAddress
        {
            get
            {
                return tbAddress;
            }
        }
        public TextBox TextBoxEmail
        {
            get
            {
                return tbEmail;
            }
        }
        public ComboBox ComboBoxGender
        {
            get
            {
                return cbGender;
            }
        }
        public DateTimePicker DateTimePackerBirthDate
        {
            get
            {
                return dtpBirthDate;
            }
        }

        public struct stPatientInput
        {
            public string Name { get; set; }
            public string Phone { get; set; }
            public string Address { get; set; }
            public string Email { get; set; }
            public string Gender { get; set; }
            public DateTime? BirthDate { get; set; }
        }

        public stPatientInput GetInput()
        {
            return new stPatientInput
            {
                Name = tbName.Text.Trim(),
                Phone = tbPhone.Text.Trim(),
                Email = tbEmail.Text.Trim(),
                Address = tbAddress.Text.Trim(),
                Gender = cbGender.SelectedItem?.ToString() == "Unknown" ?
                string.Empty : cbGender.SelectedItem?.ToString(),
                BirthDate = dtpBirthDate.Value.Date
            };
        }

        public void ConfigureGenderComboBox(List<string> GenderTypes)
        {
            cbGender.Items.Clear();
            if (GenderTypes.Count > 0)
            {
                foreach (string Gender in GenderTypes)
                {
                    if (Gender == string.Empty)
                    {
                        cbGender.Items.Add("Unknown");
                    }
                    else
                    {
                        cbGender.Items.Add(Gender);
                    }
                }
                cbGender.SelectedItem = "Unknown";
            }
        }

        public void GetOutput(string Name, string Phone, string Address,
            string Email, string Gender, DateTime? BirthDate)
        {
            tbName.Text = Name.Trim();
            tbPhone.Text = Phone.Trim();
            tbEmail.Text = string.IsNullOrEmpty(Email) ? string.Empty : Email.Trim();
            tbAddress.Text = string.IsNullOrEmpty(Address) ? 
                string.Empty : Address.Trim();
            cbGender.SelectedItem = string.IsNullOrEmpty(Gender) ? 
                "Unknown" : Gender.Trim();
            if(BirthDate.Value.Date < dtpBirthDate.MinDate)
            {
                dtpBirthDate.MinDate = BirthDate.Value.Date;
            }
            dtpBirthDate.Value = BirthDate.Value.Date;
        }

        private void ucPatientCard_Load(object sender, EventArgs e)
        {
            dtpBirthDate.MaxDate = DateTime.Today;
            dtpBirthDate.MinDate = DateTime.Today.AddYears(-120);
        }
    }
}
