using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace ServiceMonitor
{
    struct TabInfo
    {
        public string FileName;
        public string Args;
        public bool ManualControl;
        public string WorkDir;        

        public void OnLoad( ProcessModel model )
        {

            model.FileName = Path.GetFullPath(this.FileName);
            model.Args = this.Args;
            model.ManualControl = this.ManualControl;
            model.WorkDir = this.WorkDir;
        }

        public void OnSave( ProcessModel model )
        {   
            try
            {
                this.FileName = PathUtil.GetRelativePath(Application.StartupPath, model.FileName);    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            this.Args = model.Args;
            this.ManualControl = model.ManualControl;
            this.WorkDir = model.WorkDir;
        }
    }

    class Profile
    {
        public List<TabInfo> Tabs = new List<TabInfo>();
    }

    class TabSettings
    {
        public static void LoadSettings(string filename, Action<TabInfo> callback )
        {
            var ser = new JavaScriptSerializer();

            string content = string.Empty;
            try
            {
                content = File.ReadAllText(filename, Encoding.UTF8);
            }
            catch (Exception)
            {

            }

            Profile profile;

            try
            {
                profile = ser.Deserialize<Profile>(content);
            }
            catch (Exception)
            {
                return;
            }

            if (profile == null)
            {
                return;
            }


            foreach (var tabInfo in profile.Tabs)
            {
                callback(tabInfo);                
            }
        }


     
        public static void SaveSettings(string filename, List<TabInfo> list )
        {

            var profile = new Profile();

            profile.Tabs = list;

            var ser = new JavaScriptSerializer();
            var content = ser.Serialize(profile);

            File.WriteAllText(filename, content, Encoding.UTF8);
        }
    }
}
