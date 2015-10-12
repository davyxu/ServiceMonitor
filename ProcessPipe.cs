using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceMonitor
{
    enum ProcessStatus
    {
        LogData,
        Exit,
    }

    class ProcessPipe
    {
        Process _process;

        string _filename;
        string _arg;
        bool _running;
        Action<ProcessStatus, string> _callback;

        public string FileName
        {
            get { return _filename; }
        }

        public string Args
        {
            get { return _arg; }
            set { _arg = value; }
        }

        public bool AutoScroll
        {
            get;
            set;
        }


        public ProcessPipe(string filename, string arg, Action<ProcessStatus, string> callback)
        {
            _filename = filename;
            _arg = arg;
            _callback = callback;
            AutoScroll = true;
        }

        public bool Running
        {
            get { return _running; }
        }

        public void Start(  )
        {
            if (_running)
                return;

            _running = true;

            var info = new ProcessStartInfo(_filename);

            info.Arguments = _arg;
            info.RedirectStandardOutput = true;
            info.RedirectStandardError = true;
            info.RedirectStandardInput = true;
            info.StandardErrorEncoding = Encoding.UTF8;
            info.StandardOutputEncoding = Encoding.UTF8;
            info.UseShellExecute = false;
            info.CreateNoWindow = true;
            info.WorkingDirectory = Path.GetDirectoryName(_filename);


            ThreadPool.QueueUserWorkItem(delegate(object state) {

                var p = Process.Start(info);
                _process = p;

                p.OutputDataReceived += delegate(object sender, DataReceivedEventArgs e)
                {
                    _callback(ProcessStatus.LogData, e.Data);
                };

                p.ErrorDataReceived += delegate(object sender, DataReceivedEventArgs e)
                {
                    _callback(ProcessStatus.LogData, e.Data);
                };

                p.BeginOutputReadLine();
                p.BeginErrorReadLine();

                Application.DoEvents();
                p.WaitForExit();

                p.Close();

                _callback(ProcessStatus.Exit, null);

                _process = null;
                _running = false;
            
            
            });
        }

        public void Stop( )
        {
            if (!_running)
                return;

            _running = false;

            if (_process == null)
                return;

            try
            {
                _process.Kill();
            }
            catch( Exception )
            {

            }

            
            
        }

    }
}
