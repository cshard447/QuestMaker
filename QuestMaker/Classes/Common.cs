using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;

namespace QuestMaker.Classes
{
    public class Common
    {
        public static string path = "..\\..\\Result\\";

        public static string convertNullString(object obj)
        {
            if (obj == null)
                return "";
            else
                return obj.ToString();
        }

        public static void createFileIfNotExists(string fileName)
        {
            if (File.Exists(fileName))
                return;
            else
            {
                StreamWriter stream = File.CreateText(fileName);
                stream.WriteLine("<root>");
                stream.WriteLine("<" + CItemManager.section + "/>");
                stream.WriteLine("<" + CAimManager.section + "/>");
                stream.WriteLine("</root>");            
                stream.Flush();
                stream.Close();
            }    
        }

    }

}
