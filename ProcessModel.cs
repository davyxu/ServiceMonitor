using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ServiceMonitor
{
    public class LogData
    {
        string _text;
        Color _color;
        int _index;

        public LogData(Color c, string text, int index )
        {
            _color = c;
            _text = text;
            _index = index;
        }

        public int Index
        {
            get { return _index; }
        }

        public string Text
        { 
            get { return _text; } 
        }
        public Color FontColor
        {
            get { return _color; }
        }

        public override string ToString()
        {
            return _text;
        }

    }

    public class ProcessModel
    {
        Process _process;
        public Control invoker;

        public LogView view;
                
        public Action<ProcessModel> OnStart;

        public Action<ProcessModel> OnStop;

        public Action<ProcessModel> OnExit;

        public Action OnClear;

        public Func<int, LogData> OnGetData;
        public Func<int> OnGetDataCount;

        public Func<string> OnGetAllLog;

        public Func<string> OnGetSelectedContent;

        public Action<ProcessModel, Color, string> OnLog;

        public Action<ProcessModel, Color, string> OnError;

        public bool Valid
        {
            get { return !string.IsNullOrEmpty(FileName); }
        }

        public int PID
        {
            get {
                if (_process == null)
                    return 0;

                return _process.Id;
            }
        }

        public string FileName{get;set;}

        public string Args{get;set;}        

        public bool AutoScroll  { get; set; }

        // 可停止的, shell不能停止, 因为可能是里面的另外进程在允许
        public bool CanStop { get; set; }

        public int ExitCode { get; set; }       

        public ProcessModel( )
        {
            CanStop = true;
            AutoScroll = true;            
        }

        public bool Running { get; set; }

        public void ClearLog( )
        {
            OnClear( );
        }

        public LogData GetData( int index )
        {
            return OnGetData( index);
        }

        public int GetDataCount( )
        {
            return OnGetDataCount();
        }

        public string GetAllLog( )
        {
            return OnGetAllLog( );
        }

        public string GetSelectedContext()
        {
            return OnGetSelectedContent();
        }

        public void Start()
        {
            if (Running)
                return;

            Running = true;

            var info = new ProcessStartInfo(FileName);

            info.Arguments = Args;
            info.RedirectStandardOutput = true;
            info.RedirectStandardError = true;
            info.RedirectStandardInput = true;
            info.StandardErrorEncoding = Encoding.UTF8;
            info.StandardOutputEncoding = Encoding.UTF8;
            info.UseShellExecute = false;
            info.CreateNoWindow = true;
            info.WorkingDirectory = Path.GetDirectoryName(FileName);

            ThreadPool.QueueUserWorkItem(delegate(object state)
            {

                SafeCall( delegate {

                    if (OnStart != null)
                    {
                        OnStart(this);
                    }
                });

                Process p = null;
                try
                {
                    p = Process.Start(info);
                    _process = p;
                }
                catch (Exception e)
                {
                    SafeCall( delegate { 
                        OnError( this, Color.Red, e.ToString() );
                    
                    });
                }

                if (p != null)
                {
                    p.OutputDataReceived += delegate(object sender, DataReceivedEventArgs e)
                    {
                        if (e.Data == null)
                            return;

                        var c = ColorSettings.PickColorFromText(e.Data);

                         SafeCall( delegate {

                             WriteLog(c, e.Data);
                         });
                    };

                    p.ErrorDataReceived += delegate(object sender, DataReceivedEventArgs e)
                    {
                        if (e.Data == null)
                            return;

                        var c = ColorSettings.PickColorFromText(e.Data);

                        SafeCall( delegate {

                            WriteLog(c, e.Data);
                         });
                    };

                    p.BeginOutputReadLine();
                    p.BeginErrorReadLine();

                    Application.DoEvents();
                    p.WaitForExit();

                    ExitCode = p.ExitCode;

                    p.Close();
                }


                SafeCall(delegate
                {
                    if (OnExit != null)
                    {                        
                        OnExit(this );
                    }
                });

                _process = null;
                Running = false;


            });
        }

        public void WriteLog(Color c, string text)
        {
            if ( OnLog != null )
            {
                OnLog(this, c, text);
            }
        }

        delegate void InvokeHandler( Action callback );
        void SafeCall(Action callback )
        {

            if (invoker != null && invoker.InvokeRequired)
            {
                invoker.BeginInvoke(new InvokeHandler(SafeCall), callback);
            }
            else
            {
                callback( );
            }
        }

        public void Stop()
        {
            if (!Running)
            {
                return;
            }

            Running = false;

            if (_process == null)
                return;

            try
            {
                _process.Kill();
            }
            catch(Exception e )
            {
                Debug.WriteLine(e.ToString());
            }

            if (OnStop != null )
            {
                OnStop(this);
            }
            
        }

    }
}
