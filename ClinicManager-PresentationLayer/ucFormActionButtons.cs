using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClinicManager_PresentationLayer
{
    public partial class ucFormActionButtons : UserControl
    {
        public ucFormActionButtons()
        {
            InitializeComponent();
        }

        public void ConfigureForEdit()
        {
            btnDelete.Visible = true;
        }

        public void ConfigureForAdd()
        {
            btnDelete.Visible = false;
        }

        private void btnCancel_MouseHover(object sender, EventArgs e)
        {
            btnCancel.BackColor = Color.FromArgb(115, 132, 150);
        }

        public event Action OnCancelButton;
        protected virtual void CancelButton()
        {
            Action Handler = OnCancelButton;
            if (Handler != null)
            {
                Handler();
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if(OnCancelButton != null)
            {
                CancelButton();
            }
        }

        private void btnCancel_MouseLeave(object sender, EventArgs e)
        {
            btnCancel.BackColor = Color.FromArgb(90, 107, 125);
        }

        private void btnSave_MouseHover(object sender, EventArgs e)
        {
            btnSave.BackColor = Color.FromArgb(95, 162, 255);
        }

        public event Action OnSaveButton;
        protected virtual void SaveButton()
        {
            Action Handler = OnSaveButton;
            if (Handler != null)
            {
                Handler();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(OnSaveButton != null)
            {
                SaveButton();
            }
        }

        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            btnSave.BackColor = Color.FromArgb(58, 141, 255);
        }

        private void btnDelete_MouseHover(object sender, EventArgs e)
        {
            btnDelete.BackColor = Color.FromArgb(255, 107, 92);
        }

        public event Action OnDeleteButton;
        protected virtual void DeleteButton()
        {
            Action Handler = OnDeleteButton;
            if (Handler != null)
            {
                Handler();
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(OnDeleteButton != null)
            {
                DeleteButton();
            }
        }

        private void btnDelete_MouseLeave(object sender, EventArgs e)
        {
            btnDelete.BackColor = Color.FromArgb(231, 76, 60);
        }
    }
}
