using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace ServiceMonitor
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        #region Settings

        struct TabInfo
        {
            public string FileName;
            public string Args;
        }

        class Profile
        {
            public List<TabInfo> Tabs = new List<TabInfo>();            
        }


        Profile _profile;

        void LoadSettings(string filename)
        {
            var ser = new JavaScriptSerializer();

            string content = string.Empty;
            try
            {
                content = File.ReadAllText(filename, Encoding.UTF8);
            }
            catch( Exception )
            {

            }


            try
            {
                _profile = ser.Deserialize<Profile>(content);    
            }
            catch ( Exception)
            {
                return;
            }

            if (_profile == null)
            {
                return;
            }


            foreach (var tabInfo in _profile.Tabs)
            {
                CreateTab(tabInfo.FileName, tabInfo.Args);
            }
        }


        void SaveSettings(string filename)
        {
            if (_profile == null )
            {
                _profile = new Profile();
            }

            _profile.Tabs.Clear();
            foreach (TabPage tab in tabMain.TabPages)
            {
                var pipe = GetPipe(tab);
                if (pipe == null)
                    continue;

                var tabInfo = new TabInfo();
                tabInfo.FileName = pipe.FileName;
                tabInfo.Args = pipe.Args;

                _profile.Tabs.Add(tabInfo);
            }

            var ser = new JavaScriptSerializer();
            var content = ser.Serialize(_profile);

            File.WriteAllText(filename, content, Encoding.UTF8);
        }

        #endregion

        #region Tab API

        void StartTab(TabPage page)
        {
            if (page == null)
                return;

            var pipe = GetPipe( page );
            if ( pipe == null )
                return;

            pipe.Start();
            RefreshButtonStatus(pipe);

            var textbox = GetTextBox( page );

            AppendText(textbox, "进程启动", Color.Yellow );
        }

        void StopTab(TabPage page)
        {
            if (page == null)
                return;

            var pipe = GetPipe(page);
            if (pipe == null)
                return;

            var textbox = GetTextBox(page);

            AppendText(textbox, "进程停止", Color.Yellow);

            pipe.Stop();
            RefreshButtonStatus(pipe);

            
        }

        ProcessPipe GetPipe( TabPage page )
        {
            if (page == null)
                return null;

            return page.Tag as ProcessPipe;
        }

        ListBox GetTextBox( TabPage page )
        {
            if (page == null)
                return null;

            if (page.Controls.Count == 0)
                return null;

            return page.Controls[0] as ListBox;
        }

        void CreateTab( string filename, string arg )
        {
            var name = Path.GetFileNameWithoutExtension( filename );

            var tab = new TabPage(name);

            tab.ContextMenuStrip = mnuTab;            

            var text = new ListBox();
            text.Dock = DockStyle.Fill;
            text.BackColor = Color.Black;
            text.DrawMode = DrawMode.OwnerDrawVariable;
            text.DrawItem += text_DrawItem;
            text.MouseDown += text_MouseDown;
            text.DoubleClick += text_DoubleClick;

            tab.Controls.Add( text );
            tabMain.TabPages.Add(tab);
            var pipe = new ProcessPipe(filename, arg, (ProcessEvent e) =>
            {
                if (e is ProcessLogData)
                {
                    var ev = e as ProcessLogData;

                    if (string.IsNullOrEmpty(ev.Data))
                        return;

                    AppendText(GetTextBox(tab), ev.Data, SelectColorFromText(ev.Data));
                }
                else if (e is ProcessExit)
                {
                    StopTab(tab);
                }
            }, this );

            RefreshButtonStatus(pipe);

            tab.Tag = pipe;

            AppendText(text, "就绪", Color.Yellow);

            tabMain.SelectedTab = tab;
        }

        #endregion

        #region Text Management
        

        struct ColorDef
        {
            public string KeyWords;
            public Color C;
            public ColorDef( string keywords, Color c )
            {
                C =c;
                KeyWords = keywords;
            }
        }

        //static ColorDef[] tables = 
        //{
        //    new ColorDef( "#recvpacket", Color.MediumOrchid ),
        //    new ColorDef( "#sendpacket", Color.RosyBrown ),

        //    new ColorDef( "#connected", Color.CadetBlue ),
        //    new ColorDef( "#accepted", Color.CadetBlue ),
        //    new ColorDef( "#postpacket", Color.Thistle ),
        //    new ColorDef( "#closed", Color.DarkGoldenrod ),
       
        //};


        Dictionary<Color, Brush> _color2brush = new Dictionary<Color, Brush>();
        Brush ColorToBrush( Color c )
        {
            Brush b;
            if ( _color2brush.TryGetValue( c, out b ) )
            {
                return b;
            }

            b = new SolidBrush(c);
            _color2brush[c] = b;

            return b;
        }

        class ColorFile
        {
            public List<ColorDef> ColorTab = new List<ColorDef>();
        }

        ColorFile _colorFile = new ColorFile();

        void LoadColorTable(string filename)
        {
            var ser = new JavaScriptSerializer();

            var content = File.ReadAllText(filename, Encoding.UTF8);

            try
            {
                _colorFile = ser.Deserialize<ColorFile>(content);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }


        Color SelectColorFromText( string text )
        {
            foreach (ColorDef tab in _colorFile.ColorTab)
            {
                if (text.IndexOf(tab.KeyWords) == -1 )
                {
                    continue;
                }

                return tab.C;
            }

            return Color.Gray;
        }

        public class MyListBoxItem
        {
            public Brush fg;
            public Brush bg;
            public string m;
            public MyListBoxItem(Brush b, string m)
            {
                this.fg = b;
                this.m = m;
            }

            public override string ToString()
            {
                return m;
            }
        }

        SolidBrush textBg = new SolidBrush(Color.Black);
        void text_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1)
                return;

            var listbox = sender as ListBox;

            MyListBoxItem item = listbox.Items[e.Index] as MyListBoxItem; // Get the current item and cast it to MyListBoxItem
            if (item != null)
            {                
                e.Graphics.FillRectangle(item.bg != null ? item.bg:textBg, e.Bounds);

                e.Graphics.DrawString( // Draw the appropriate text in the ListBox
                    item.m, // The message linked to the item
                    listbox.Font, // Take the font from the listbox
                    item.fg, // Set the color 
                    e.Bounds // Y pixel coordinate.  Multiply the index by the ItemHeight defined in the listbox.
                );
                
            }
            else
            {
                // The item isn't a MyListBoxItem, do something about it
            }
        }

        const int MaxCount = 200;
        void AppendText( ListBox ctrl, string text, Color c )
        {
            if (ctrl == null)
                return;

            bool autoScroll = true;

            var currList = GetTextBox(tabMain.SelectedTab);
            if ( currList == ctrl )
            {
                var pipe = GetPipe(tabMain.SelectedTab);
                autoScroll = pipe.AutoScroll;

            }

            var index = ctrl.Items.Add(new MyListBoxItem( ColorToBrush(c ), text + "\n"));

            if ( autoScroll )
            {
                ctrl.TopIndex = index;
            }           
        }
        

        #endregion

        #region DragDrop
        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                CreateTab(file, "");
            }
        }
        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                e.Effect = DragDropEffects.All;
            }

        }

        #endregion

        #region Main board function

        static string ConfigFilename = "profile.json";
        private void MainForm_Load(object sender, EventArgs e)
        {           
            LoadSettings(ConfigFilename);
            LoadColorTable("color.json");
        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            StartTab(tabMain.SelectedTab);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            StopCurrTab();
        }

        void StopCurrTab()
        {
            var pipe = GetPipe(tabMain.SelectedTab);
            if (pipe == null)
                return;

            pipe.Stop();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings(ConfigFilename);

            foreach (TabPage p in tabMain.TabPages)
            {
                var pipe = GetPipe(p);
                if (pipe == null)
                    continue;

                pipe.Stop();
            }

            
        }

        private void btnStartAll_Click(object sender, EventArgs e)
        {
            foreach (TabPage p in tabMain.TabPages)
            {
                StartTab(p);
            }
        }

        private void btnStopAll_Click(object sender, EventArgs e)
        {
            foreach (TabPage p in tabMain.TabPages)
            {
                var pipe = GetPipe(p);
                if (pipe == null)
                    continue;

                pipe.Stop();
            }
        }

        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            var pipe = GetPipe(tabMain.SelectedTab);
            RefreshButtonStatus(pipe);
            DismarkSearchLine();
        }


        bool _disableTextNotify;
        void RefreshButtonStatus(ProcessPipe pipe)
        {
            if (pipe == null)
                return;

            btnStart.Enabled = !pipe.Running;
            btnStop.Enabled = pipe.Running;

            _disableTextNotify = true;
            txtArgs.Text = pipe.Args;
            _disableTextNotify = false;
        }


       

        

        private void txtArgs_TextChanged(object sender, EventArgs e)
        {
            if (_disableTextNotify)
                return;

            var pipe = GetPipe(tabMain.SelectedTab);
            if (pipe != null)
            {
                pipe.Args = txtArgs.Text;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearContent();
        }

        void ClearContent( )
        {
            var listbox = GetTextBox(tabMain.SelectedTab);
            if (listbox == null)
                return;

            listbox.Items.Clear();
        }

        private void ClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearContent();
        }
        #endregion

        #region Tab Menu And Data

        private void mnuCopyTab_Click(object sender, EventArgs e)
        {
            var tab = tabMain.SelectedTab;
            if (tab == null)
                return;

            var pipe = GetPipe(tab);
            if (pipe != null)
            {
                CreateTab(pipe.FileName, pipe.Args);
            }
        }

        private void mnuCloseTab_Click(object sender, EventArgs e)
        {
            var tab = tabMain.SelectedTab;
            if (tab == null)
                return;

            var pipe = GetPipe(tab);
            if (pipe != null)
            {
                pipe.Stop();
            }

            tabMain.TabPages.Remove(tab);

        }

        private void mnuAddTab_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "exe files (*.exe)|*.exe|bat files(*.bat)|*.bat";
            dialog.FilterIndex = 1;
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                CreateTab(dialog.FileName, "");
            }
        }
        void text_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                var listbox = sender as ListBox;
                listbox.SelectedIndex = listbox.IndexFromPoint(e.X, e.Y);
            }
            catch( Exception )
            {

            }
          
        }

        void text_DoubleClick(object sender, EventArgs e)
        {
            var ee = e as MouseEventArgs;
            try
            {
                var listbox = sender as ListBox;
                listbox.SelectedIndex = listbox.IndexFromPoint(ee.X, ee.Y);

                var dialog = new TextDialog(listbox.SelectedItem.ToString());
                dialog.ShowDialog();
            }
            catch (Exception)
            {

            }
        }

        private void CopyLineTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var listbox = GetTextBox(tabMain.SelectedTab);
            if (listbox == null)
                return;

            var item = listbox.SelectedItem;
            if (item == null)
                return;
 

            Clipboard.SetText(item.ToString());
        }

        private void LogSaveToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = " txt files(*.txt)|*.txt|All files(*.*)|*.*";  
            dialog.RestoreDirectory = true ;
            if ( dialog.ShowDialog( ) == System.Windows.Forms.DialogResult.OK )
            {
                File.WriteAllText(dialog.FileName, LogToString());
                
            }
        }

        string LogToString( )
        {
            var listbox = GetTextBox(tabMain.SelectedTab);
            if (listbox == null)
                return "";


            var sb = new StringBuilder();

            foreach( var item in listbox.Items )
            {
                sb.Append(item.ToString());
            }

            return sb.ToString();

        }

        private void ClearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (TabPage p in tabMain.TabPages)
            {
                var listbox = GetTextBox(p);
                listbox.Items.Clear();
            }
        }

 

        private void AutoScrollToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var item = sender as ToolStripMenuItem;
            item.Checked = !item.Checked;

            var pipe = GetPipe(tabMain.SelectedTab);
            if ( pipe != null )
            {
                pipe.AutoScroll = item.Checked;
            }
        }

        private void mnuTab_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var pipe = GetPipe(tabMain.SelectedTab);
            if (pipe != null)
            {
                AutoScrollToolStripMenuItem.Checked = pipe.AutoScroll;
            }
           
        }

        void MarkSearchLine(string content)
        {
            var listbox = GetTextBox(tabMain.SelectedTab);
            if (listbox == null)
                return;

            foreach (var item in listbox.Items)
            {
                var it = item as MyListBoxItem;
                if (it.ToString().IndexOf(content) != -1)
                {
                    it.bg = ColorToBrush(Color.BlanchedAlmond);
                }

            }

            this.Refresh();
        }

        void DismarkSearchLine()
        {
            var listbox = GetTextBox(tabMain.SelectedTab);
            if (listbox == null)
                return;

            foreach (var item in listbox.Items)
            {
                var it = item as MyListBoxItem;
                it.bg = null;
            }
        }

        string _lastSearch;
        private void SearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new SearchDialog(_lastSearch);
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _lastSearch = dialog.Content;

                DismarkSearchLine();

                if (!string.IsNullOrEmpty(dialog.Content))
                {
                    MarkSearchLine(dialog.Content);
                }                
            }
        }


        #endregion

        private void BuildToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StopCurrTab();

            RunTableShell(tabMain.SelectedTab);
        }

        // 命名规则: 与svc同目录下,  svc.exe 对应的批处理是 svc_Build.bat
        void RunTableShell(TabPage page, Action doneCallback = null)
        {
            var svc = page.Tag as ProcessPipe;
            var buildcmd = Path.Combine(Path.GetDirectoryName(svc.FileName), Path.GetFileNameWithoutExtension(svc.FileName) + "_Build") + ".bat";

            var pipe = new ProcessPipe(buildcmd, "", (ProcessEvent e ) =>
            {
                if (e is ProcessLogData)
                {
                    var ev = e as ProcessLogData;

                    if (string.IsNullOrEmpty(ev.Data))
                        return;

                    AppendText(GetTextBox(page), ev.Data, SelectColorFromText(ev.Data));
                }
                else if (e is ProcessStart)
                {
                    var ev = e as ProcessStart;
                    AppendText(GetTextBox(page), "启动Shell: " + ev.FileName, Color.Yellow);
                }
                else if (e is ProcessExit)
                {
                    AppendText(GetTextBox(page), "结束Shell", Color.Yellow);

                    if (doneCallback != null)
                    {
                        doneCallback();
                    }
                }
            }, this );


            pipe.Start();
        }

        private void BuildRunFToolStripMenuItem_Click(object sender, EventArgs e)
        {

            StopCurrTab();

            RunTableShell(tabMain.SelectedTab, () =>{
                StartTab(tabMain.SelectedTab);
            });

            

        }


    }
}
