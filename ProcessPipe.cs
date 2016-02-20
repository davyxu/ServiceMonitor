using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ServiceMonitor
{

    public class ProcessEvent
    {

    }


    public class ProcessStart : ProcessEvent
    {
        public string FileName;

        public ProcessStart(string filename)
        {
            FileName = filename;
        }
    }

    public class ProcessLogData : ProcessEvent
    {
        public string Data;

        public ProcessLogData( string data )
        {
            Data = data;
        }
    }

    public class ProcessExit : ProcessEvent
    {

    }

    public class ProcessError : ProcessEvent
    {
        public string Data;

        public ProcessError(string data)
        {
            Data = data;
        }
    }



    class ProcessPipe
    {
        Process _process;
        Control _invoker;
        string _filename;
        string _arg;
        bool _running;
        Action<ProcessEvent> _callback;

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


        public ProcessPipe(string filename, string arg, Action<ProcessEvent> callback, Control invoker)
        {
            _filename = filename;
            _arg = arg;
            _callback = callback;
            _invoker = invoker;
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

                SafeCall(new ProcessStart(_filename));

                Process p = null;
                try
                {
                    p = Process.Start(info);
                    _process = p;
                }
                catch (Exception e)
                {
                    SafeCall(new ProcessError(e.ToString()));
                }

                if (p != null )
                {
                    p.OutputDataReceived += delegate(object sender, DataReceivedEventArgs e)
                    {
                        SafeCall(new ProcessLogData(e.Data));
                    };

                    p.ErrorDataReceived += delegate(object sender, DataReceivedEventArgs e)
                    {
                        SafeCall(new ProcessLogData(e.Data));
                    };

                    p.BeginOutputReadLine();
                    p.BeginErrorReadLine();

                    Application.DoEvents();
                    p.WaitForExit();

                    p.Close();
                }


                SafeCall(new ProcessExit());

                _process = null;
                _running = false;
            
            
            });
        }

        delegate void InvokeHandler(ProcessEvent ev);
        void SafeCall(ProcessEvent ev)
        {
            if (_invoker != null && _invoker.InvokeRequired)
            {
                _invoker.BeginInvoke(new InvokeHandler( SafeCall ), ev );
            }
            else
            {
                _callback(ev);
            }
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
            catch
            {

            }

        }

    }
}
