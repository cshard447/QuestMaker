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
        public static int convertNullInt(object obj)
        {
            if (obj == null)
                return -1;
            else
                return int.Parse(obj.ToString());        
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
                stream.WriteLine("<" + CRules.section + "/>");
                stream.WriteLine("<" + CPrehistory.section + "/>");
                stream.WriteLine("<" + CPersonManager.section + "/>");
                stream.WriteLine("</root>");            
                stream.Flush();
                stream.Close();
            }    
        }

        public static string getListAsStringWithDelimiter(List<int> ids, string delimiter)
        {
            string result = "";
            foreach (int id in ids)
                result += id.ToString() + delimiter;
            return result;
        }

        public static List<int> splitStringIntoList(string listedString)
        {
            string[] itemsArr = listedString.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            List<int> itemsList = new List<int>();
            if (listedString != "")
                foreach (string str in itemsArr)
                    itemsList.Add(int.Parse(str));
            return itemsList;
        }

    }

    public class CommonError
    {
        private static string currentError = "";
        public static bool isError = false;
        public static void addErrorString(string error)
        {
            isError = true;
            currentError += error + "\n";
        }
        public static string getCurrentError()
        {
            string result = currentError;
            currentError = "";
            isError = false;
            return result;
        }
    
    }

}
