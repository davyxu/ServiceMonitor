using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LiteMate
{
    public class IniFile  
    {  
        string path;             //INI文件名  
  
        [DllImport("kernel32")]  
        private static extern long WritePrivateProfileString(string section,string key,  
                    string val,string filePath);  
  
        [DllImport("kernel32")]  
        private static extern int GetPrivateProfileString(string section,string key,string def,  
                    StringBuilder retVal,int size,string filePath);  
  
        //声明读写INI文件的API函数  
        public IniFile(string INIPath)  
        {            
            path = INIPath;  
        }  
  
        //类的构造函数，传递INI文件名  
        public void WriteValue(string Section,string Key,string Value)  
        {  
            WritePrivateProfileString(Section,Key,Value,this.path);  
        }  
  
        //写INI文件  
        public string ReadValue(string Section,string Key)  
        {  
            StringBuilder temp = new StringBuilder(255);  
            int i = GetPrivateProfileString(Section,Key,"",temp,255,this.path);  
            return temp.ToString();  
        }  
  
        //读取INI文件指定  
    }  
}
