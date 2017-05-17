using System;
using System.Windows.Forms;

namespace ServiceMonitor
{
    public partial class WorkDirDialog : Form
    {
        public WorkDirDialog( string txt  )
        {
            InitializeComponent();

            txtMain.Text = txt;
        }

        public string WorkDir
        {
            get { return txtMain.Text; }
        }

        private void frmDialog_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
