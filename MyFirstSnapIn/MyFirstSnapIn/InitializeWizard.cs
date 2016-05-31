using System;
using System.Windows.Forms;

namespace MyFirstSnapIn
{
    public partial class InitializeWizard : Form
    {
        public InitializeWizard()
        {
            InitializeComponent();
            this.SelectedSnapInName = "Unknown";
        }

        public string SelectedSnapInName
        {
            get
            {
                return SnapInName.Text;
            }
            set
            {
                SnapInName.Text = value;
            }
        }

        private void OK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
