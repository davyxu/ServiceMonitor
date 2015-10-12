using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceMonitor
{
    public partial class SearchDialog : Form
    {        
        public SearchDialog( string text )
        {
            InitializeComponent();

            txtMain.Text = text;
        }

        public string Content
        {
            get { return txtMain.Text; }
        }

        private void txtMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ( e.KeyChar == (char)13)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
