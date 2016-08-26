using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ServiceMonitor
{
    public partial class MonitorView : Form
    {
        MonitorController _controller;

        public MonitorView()
        {
            _controller = new MonitorController(this);
            _controller.OnProcessCreate += OnProcessCreate;

            InitializeComponent();
        }



        #region Model获取封装,基础功能封装

        ProcessModel SafeGetModel(object obj)
        {
            var model = _controller.GetModelByObject(obj);
            if (model == null)
            {
                return new ProcessModel();
            }

            return model;
        }

        ProcessModel SafeGetCurrTableModel()
        {
            return SafeGetModel(tabMain.SelectedTab);
        }

        // 命名规则: 与svc同目录下,  svc.exe 对应的批处理是 svc_Build.bat
        void RunSvcShell(ProcessModel svcModel, bool startAfterDone)
        {
            if (!svcModel.Valid)
                return;

            // 还在跑的进程, 必须停下来
            if (svcModel.Running)
            {
                svcModel.Stop();
            }

            var buildcmd = Path.Combine(Path.GetDirectoryName(svcModel.FileName), Path.GetFileNameWithoutExtension(svcModel.FileName) + "_Build") + ".bat";

            var shellModel = new ProcessModel();
            shellModel.FileName = buildcmd;
            shellModel.invoker = this;
            shellModel.CanStop = false;

            shellModel.OnStart += (m) =>
            {
                m.WriteLog(Color.Yellow, "启动Shell: " + buildcmd);
            };

            Action<ProcessModel> stopProc = (m) =>
            {
                m.WriteLog(Color.Yellow, "结束Shell: " + buildcmd);

                RefreshButtonStatus(shellModel);

                if (startAfterDone)
                {
                    svcModel.Start();
                }
            };


            shellModel.OnStop += stopProc;
            shellModel.OnExit += stopProc;

            shellModel.OnLog += svcModel.OnLog;
            shellModel.OnError += svcModel.OnError;

            shellModel.Start();

            RefreshButtonStatus(shellModel);
        }

        #endregion

        #region Process创建,开启,关闭行为

        object OnProcessCreate(ProcessModel model)
        {
            var name = Path.GetFileNameWithoutExtension(model.FileName);

            var page = new TabPage(name);
            page.ContextMenuStrip = logMenu;
            var logview = new LogView();

            page.Controls.Add(logview);
            tabMain.TabPages.Add(page);

            RefreshButtonStatus(model);

            tabMain.SelectedTab = page;
            tabMain.MouseClick += (sender, e) =>
            {
                if ( e.Button == System.Windows.Forms.MouseButtons.Right )
                {
                    tabMenu.Show(tabMain, e.Location);
                }
            };

            Action<ProcessModel, Color, string> logProc = (m, c, data) =>
            {
                logview.AddLog(c, data, model.AutoScroll);
            };

            model.OnStart += OnProcessStart;
            model.OnStop += OnProcessStop;
            model.OnExit += OnProcessExit;

            model.OnLog += logProc;
            model.OnError += logProc;
            

            model.OnClear += delegate()
            {
                logview.Items.Clear();
            };

            model.OnGetData += ( index ) =>
            {
                return logview.Items[index] as LogData;
            };

            model.OnGetAllLog += delegate()
            {
                return logview.AllLogToString();
            };

            model.OnGetSelectedContent += delegate()
            {
                var logdata = logview.SelectedItem as LogData;
                if (logdata == null)
                    return string.Empty;

                return logdata.Text;
            };

            model.WriteLog(Color.Yellow, "就绪");

            return page;
        }


        void OnProcessStart(ProcessModel model )
        {            
            model.WriteLog(Color.Yellow, "进程启动 ");

            RefreshButtonStatus(model);
        }

        void OnProcessStop(ProcessModel model)
        {
            RefreshButtonStatus(model);

            model.WriteLog(Color.Yellow, "进程停止");            
        }

        void OnProcessExit(ProcessModel model)
        {
            RefreshButtonStatus(model);

            model.WriteLog(Color.Yellow, "进程结束");
        }


        #endregion

        #region 主面板MainForm及按钮行为

        void MainForm_Load(object sender, EventArgs e)
        {
            _controller.Init();
        }


        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                _controller.CreateProcess(file, "");                
            }
        }
        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                e.Effect = DragDropEffects.All;
            }

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _controller.Exit();
        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            SafeGetCurrTableModel().Start();            
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            SafeGetCurrTableModel().Stop();            
        }
        private void btnStartAll_Click(object sender, EventArgs e)
        {
            _controller.StartAllProcess();            
        }

        private void btnStopAll_Click(object sender, EventArgs e)
        {
            _controller.StopAllProcess();
        }

        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshButtonStatus(SafeGetCurrTableModel());
        }


        bool _disableTextNotify;
        void RefreshButtonStatus(ProcessModel pm)
        {
            btnStart.Enabled = !pm.Running;

            if ( pm.CanStop )
            {
                btnStop.Enabled = pm.Running;
            }
            else
            {
                btnStop.Enabled = false;
            }
            

            _disableTextNotify = true;
            txtArgs.Text = pm.Args;
            _disableTextNotify = false;
        }


        private void txtArgs_TextChanged(object sender, EventArgs e)
        {
            if (_disableTextNotify)
                return;

            SafeGetCurrTableModel().Args = txtArgs.Text;            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            SafeGetCurrTableModel().ClearLog();
        }

        #endregion

        #region 日志菜单

        private void ClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SafeGetCurrTableModel().ClearLog();
        }


        private void CopyLineTextToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var text = SafeGetCurrTableModel().GetSelectedContext();
            Clipboard.SetText(text);
        }

        private void LogSaveToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = " txt files(*.txt)|*.txt|All files(*.*)|*.*";  
            dialog.RestoreDirectory = true ;
            if ( dialog.ShowDialog( ) == System.Windows.Forms.DialogResult.OK )
            {
                File.WriteAllText(dialog.FileName, SafeGetCurrTableModel().GetAllLog() );
                
            }
        }

        private void ClearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _controller.ClearAllProcessLog();
        }

        private void AutoScrollToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var item = sender as ToolStripMenuItem;
            item.Checked = !item.Checked;

            SafeGetCurrTableModel( ).AutoScroll = item.Checked;
        }

        private void mnuTab_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var model = SafeGetCurrTableModel();
            if (!string.IsNullOrEmpty(model.FileName))
            {
                AutoScrollToolStripMenuItem.Checked = model.AutoScroll;
            }
           
        }

        string _lastSearch;
        private void SearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new SearchDialog(_lastSearch);
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _lastSearch = dialog.Content;

                // DismarkSearchLine();

                if (!string.IsNullOrEmpty(dialog.Content))
                {
                    //   MarkSearchLine(dialog.Content);
                }
            }
        }

        // 编译并运行
        private void BuildRunFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunSvcShell(SafeGetCurrTableModel(), true);
        }

        // 编译
        private void BuildToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunSvcShell(SafeGetCurrTableModel(), false);
        }

        #endregion

        #region Tab菜单

        private void AddTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "exe files (*.exe)|*.exe|bat files(*.bat)|*.bat";
            dialog.FilterIndex = 1;
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _controller.CreateProcess(dialog.FileName, "");
            }
        }

        private void CloseTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SafeGetCurrTableModel().Stop();

            var tab = tabMain.SelectedTab;
            if (tab != null)
            {
                tabMain.TabPages.Remove(tab);
            }
        }

        private void CopyTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var model = SafeGetCurrTableModel();
            if (!string.IsNullOrEmpty(model.FileName))
            {
                _controller.CreateProcess(model.FileName, model.Args);
            }
        }

        private void OpenDirToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            var model = SafeGetCurrTableModel();
            if (!string.IsNullOrEmpty(model.FileName))
            {
                Process.Start("explorer.exe", Path.GetDirectoryName(model.FileName));
            }
        }
        #endregion





  



   
        
       
 

    }
}
