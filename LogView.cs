using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ServiceMonitor
{
    public class LogView : ListBox
    {        
        public LogView( )
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.Black;
            this.DrawMode = DrawMode.OwnerDrawVariable;
            this.DrawItem += OnDrawItem;
            this.MouseDown += OnMouseDown;
            this.DoubleClick += OnDoubleClick;
        }

        public void AddLog( Color c, string text, bool autoscroll )
        {
            int index = this.Items.Add(new LogData(c, text, this.Items.Count));

            if ( autoscroll )
            {
                TopIndex = index;
            }
        }

        public string AllLogToString()
        {
            var sb = new StringBuilder();

            foreach (var item in Items)
            {
                sb.Append(item.ToString());
            }

            return sb.ToString();
        }

        private TabControl tabControl1;
        private TabPage tabPage1;

        static readonly SolidBrush textBg = new SolidBrush(Color.Black);

        void OnDrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1)
                return;            

            LogData data = Items[e.Index] as LogData; // Get the current item and cast it to MyListBoxItem
            if (data != null)
            {
                e.Graphics.FillRectangle(textBg, e.Bounds);

                var brush = ColorSettings.ColorToBrush(data.FontColor);

                e.Graphics.DrawString( // Draw the appropriate text in the ListBox
                    data.Text, // The message linked to the item
                    Font, // Take the font from the listbox
                    brush, // Set the color 
                    e.Bounds // Y pixel coordinate.  Multiply the index by the ItemHeight defined in the listbox.
                );

            }
            else
            {
                // The item isn't a MyListBoxItem, do something about it
            }
        }

        void OnMouseDown(object sender, MouseEventArgs e)
        {
            try
            {                
                this.SelectedIndex = IndexFromPoint(e.X, e.Y);
            }
            catch (Exception)
            {

            }

        }

        void OnDoubleClick(object sender, EventArgs e)
        {
            var ee = e as MouseEventArgs;
            try
            {
                var listbox = sender as ListBox;
                this.SelectedIndex = IndexFromPoint(ee.X, ee.Y);

                var logdata = SelectedItem as LogData;

                var dialog = new TextDialog(logdata.Text);
                dialog.ShowDialog();
            }
            catch (Exception)
            {

            }
        }

        public void EnsureVisible( int index )
        {            
            this.TopIndex = index;
            this.Refresh();
        }

        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(200, 100);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(200, 100);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(200, 100);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private TabPage tabPage2;
    }
}
