using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace ServiceMonitor
{
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

        class ColorFile
        {
            public List<ColorDef> ColorTab = new List<ColorDef>();
        }

        class ColorSettings
        {
            static Dictionary<Color, Brush> _color2brush = new Dictionary<Color, Brush>();

            public static Brush ColorToBrush( Color c )
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

             static ColorFile _colorFile = new ColorFile();

             public static void LoadColorTable(string filename)
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

             public static Color PickColorFromText(string text)
             {
                 foreach (ColorDef tab in _colorFile.ColorTab)
                 {
                     if (text.IndexOf(tab.KeyWords) == -1)
                     {
                         continue;
                     }

                     return tab.C;
                 }

                 return Color.Gray;
             }
        }

        

}
