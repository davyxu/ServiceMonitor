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
        ProcessModel _model;

        public SearchDialog( ProcessModel model )
        {
            InitializeComponent();
            splitContainer1.IsSplitterFixed = true;

            _model = model;
        }

        public string Content
        {
            get { return txtMain.Text; }
        }

        void SearchText( string text, bool caseSense )
        {            

            string textToSearch = text.Trim();
            if (caseSense )
            {
                textToSearch = text.Trim().ToLower();
            }

            resultList.BeginUpdate();
            resultList.Items.Clear();
            
            if ( textToSearch != "")
            {
                int count = _model.GetDataCount();

                for (int i = 0; i < count; i++)
                {
                    var item = _model.GetData(i);
                    if (item.Text.IndexOf(textToSearch) != -1)
                    {
                        resultList.Items.Add(item);
                    }
                }
            }

            resultList.EndUpdate();
        }

        private void txtMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ( e.KeyChar == (char)13)
            {
                SearchText(txtMain.Text, caseSense.Checked );
            }
        }

        private void search_Click(object sender, EventArgs e)
        {
            SearchText(txtMain.Text, caseSense.Checked);
        }

        private void resultList_DoubleClick(object sender, EventArgs e)
        {
            var ee = e as MouseEventArgs;

            resultList.SelectedIndex = resultList.IndexFromPoint(ee.X, ee.Y);

            var item = resultList.SelectedItem as LogData;

            if ( item != null )
            {
                _model.view.EnsureVisible(item.Index);
            }

            
        }
    }
}
