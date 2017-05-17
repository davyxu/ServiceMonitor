using System;
using System.Windows.Forms;

namespace ServiceMonitor
{
    public partial class TextDialog : Form
    {
        public TextDialog(string txt)
        {
            InitializeComponent();

            txtMain.Text = txt;
        }

        private void frmDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
