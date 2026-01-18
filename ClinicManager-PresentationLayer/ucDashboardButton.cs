using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClinicManager_PresentationLayer
{
    public partial class ucDashboardButton : UserControl
    {
        public ucDashboardButton()
        {
            InitializeComponent();
        }

        public void Configure(Image Icon, string ScreenName)
        {
            pbIcon.Image = Icon;
            btnDashboard.Text = ScreenName;
        }

        public event Action<object> DashboardButtonHovered;
        protected virtual void ButtonHovered(object sender)
        {
            Action<object> Handler = DashboardButtonHovered;
            if (Handler != null)
            {
                Handler(sender);
            }
        }
        private void ctrlDashboardButton_MouseHover(object sender, EventArgs e)
        {
            if (DashboardButtonHovered != null)
            {
                ButtonHovered(this);
            }
        }

        public event Action<object> DashboardButtonClicked;
        protected virtual void ButtonClicked(object sender)
        {
            Action<object> Handler = DashboardButtonClicked;
            if (Handler != null)
            {
                Handler(sender);
            }
        }
        private void ctrlDashboardButton_Click(object sender, EventArgs e)
        {
            if (DashboardButtonClicked != null)
            {
                ButtonClicked(this);
            }
        }

        public event Action<object> DashboardButtonLeft;
        protected virtual void ButtonLeft(object sender)
        {
            Action<object> Handler = DashboardButtonLeft;
            if(Handler != null)
            {
                Handler(sender);
            }
        }
        private void ctrlDashboardButton_MouseLeave(object sender, EventArgs e)
        {
            if (DashboardButtonLeft != null)
            {
                ButtonLeft(this);
            }
        }
    }
}
