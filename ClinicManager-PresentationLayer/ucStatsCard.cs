using System.Drawing;
using System.Windows.Forms;

namespace ClinicManager_PresentationLayer
{
    public partial class ucStatsCard : UserControl
    {
        public ucStatsCard()
        {
            InitializeComponent();
        }

        public void Configure(Image Icon, string Title, string NumberText)
        {
            pbIcon.Image = Icon;
            lblTitle.Text = Title;
            lblNumber.Text = NumberText;
        }

        private void ucStatsCard_MouseHover(object sender, System.EventArgs e)
        {
            this.BackColor = Color.FromArgb(52, 66, 84);
        }

        private void ucStatsCard_MouseLeave(object sender, System.EventArgs e)
        {
            this.BackColor = Color.FromArgb(46, 58, 74);
        }
    }
}
