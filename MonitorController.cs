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
                AddProcess(tab );
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
                tabInfo.OnSave(model);
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
                if (model.ManualControl)
                    continue;

                model.Start();
            }
        }

        public void ClearAllProcessLog()
        {
            foreach (ProcessModel model in _modelByID.Values)
            {
                if (model.ManualControl)
                    continue;

                model.ClearLog();
            }
        }

        public void StopAllProcess()
        {
            foreach (ProcessModel model in _modelByID.Values)
            {
                if (model.ManualControl)
                    continue;

                model.Stop();
            }
        }

        public void AddProcess(TabInfo tab)
        {
            var model = new ProcessModel( );
            model.invoker = _invoker;

            tab.OnLoad(model);

            var obj = OnProcessCreate( model );

            _modelByID.Add(obj, model);
        }

        public void RemoveProcess( object obj )
        {
            _modelByID.Remove(obj);
        }




    }
}
