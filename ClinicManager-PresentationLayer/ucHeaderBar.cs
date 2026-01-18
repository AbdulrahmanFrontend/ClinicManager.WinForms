using System.Drawing;
using System.Windows.Forms;

namespace ClinicManager_PresentationLayer
{
    public partial class ucHeaderBar : UserControl
    {
        public ucHeaderBar()
        {
            InitializeComponent();
        }

        public void ConfigureScreenName(string ScreenName, Image Icon = null)
        {
            lblScreenName.Text = ScreenName;
            if (Icon != null)
            {
                pbIcon.Image = Icon;
                pbIcon.Visible = true;
                lblScreenName.TextAlign = ContentAlignment.MiddleLeft;
            }
            else
            {
                pbIcon.Visible = false;
                lblScreenName.TextAlign = ContentAlignment.MiddleCenter;
            }
        }
    }
}
