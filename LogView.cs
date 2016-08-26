using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ServiceMonitor
{
    class LogView : ListBox
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
            int index = this.Items.Add(new LogData(c, text));

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
    }
}
