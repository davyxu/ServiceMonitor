using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ServiceMonitor
{
    class MonitorController
    {
        public Func<ProcessModel, object> OnProcessCreate;

        Control _invoker;

        public static string TabFileName = "profile.json";

        public MonitorController( MonitorView view )
        {
            _invoker = view;
        }

        public void Init( )
        {
            TabSettings.LoadSettings(TabFileName, (tab) =>
            {
                CreateProcess(tab.FileName, tab.Args);
            });


            ColorSettings.LoadColorTable("color.json");
        }

        public void Exit( )
        {
            StopAllProcess();

            var list = new List<TabInfo>();

            foreach (ProcessModel model in _modelByID.Values)
            {
                var tabInfo = new TabInfo();
                tabInfo.FileName = model.FileName;
                tabInfo.Args = model.Args;
                list.Add(tabInfo);
            }

            TabSettings.SaveSettings(TabFileName, list);

            
        }

        Dictionary<object, ProcessModel> _modelByID = new Dictionary<object, ProcessModel>();

        public ProcessModel GetModelByObject(object obj)
        {
            if (obj == null)
                return null;

            ProcessModel model;
            if ( _modelByID.TryGetValue( obj, out model ) )
            {
                return model;
            }

            return null;
        }


        public void StartAllProcess( )
        {
            foreach( ProcessModel model in _modelByID.Values )
            {
                model.Start();
            }
        }

        public void ClearAllProcessLog()
        {
            foreach (ProcessModel model in _modelByID.Values)
            {
                model.ClearLog();
            }
        }

        public void StopAllProcess()
        {
            foreach (ProcessModel model in _modelByID.Values)
            {
                model.Stop();
            }
        }

        public void CreateProcess(string filename, string arg )
        {
            var model = new ProcessModel( );
            model.FileName = filename;
            model.Args = arg;
            model.invoker = _invoker;

            var obj = OnProcessCreate( model );

            _modelByID.Add(obj, model);
        }




    }
}
