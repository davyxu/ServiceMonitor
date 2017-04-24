using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
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
                sb.Append("\n");
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

                try
                {
                    // 文本太长时, 这里会造成崩溃
                    e.Graphics.DrawString( // Draw the appropriate text in the ListBox
                    data.Text, // The message linked to the item
                    Font, // Take the font from the listbox
                    brush, // Set the color 
                    e.Bounds // Y pixel coordinate.  Multiply the index by the ItemHeight defined in the listbox.
                );
                }
                catch
                {

                }

                

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

        bool ParseLineText(string text, out string filename, out string line )
        {
            var regex = new Regex(@"(?<file>\w*:[/\S]*):(?<line>\d\d)", RegexOptions.IgnoreCase
| RegexOptions.CultureInvariant
| RegexOptions.IgnorePatternWhitespace
| RegexOptions.Compiled);
            var result = regex.Match(text);
            if (result.Success)
            {
                filename = result.Groups["file"].Value;
                line = result.Groups["line"].Value;
                return true;
            }

            filename = "";
                line = "";

            return false;
        }

        static bool OpenFile(string filename, string line)
        {
            if (!File.Exists(filename))
                return false;


            var nppDir = (string)Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Notepad++", null, null);
            var nppExePath = Path.Combine(nppDir, "Notepad++.exe");
            Process.Start(nppExePath, string.Format("\"{0}\" -n{1}", filename, line));

            return true;
        }

        void OnDoubleClick(object sender, EventArgs e)
        {
            var ee = e as MouseEventArgs;
            try
            {
                var listbox = sender as ListBox;
                this.SelectedIndex = IndexFromPoint(ee.X, ee.Y);

                var logdata = SelectedItem as LogData;

                string filename, line;
                if ( ParseLineText( logdata.Text,  out filename, out line))
                {
                    OpenFile(filename, line);
                }
                else
                {
                    var dialog = new TextDialog(logdata.Text);
                    dialog.ShowDialog();
                }

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
