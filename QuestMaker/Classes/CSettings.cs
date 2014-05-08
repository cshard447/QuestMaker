using System;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Telerik.WinControls.UI;

namespace QuestMaker.Classes
{
    class CSettings
    {
        static Dictionary<string, int> setting = new Dictionary<string,int>();  
        const string section = "settings";

        public static void setFormSettings(RadForm form)
        {
            string name = form.Name;
            if (!setting.ContainsKey(form.Name))
            {
                setting.Add(name, 1);
                setting.Add(name + "Left", form.Left);
                setting.Add(name + "Top", form.Top);
                setting.Add(name + "Width", form.Width);
                setting.Add(name + "Height", form.Height);
            }
            else
            {
                setting[name + "Left"] = form.Left;
                setting[name + "Top"] = form.Top;
                setting[name + "Width"] = form.Width;
                setting[name + "Height"] = form.Height;
            }
        }

        public static void fillFormSettings(RadForm form)
        {
            string name = form.Name;
            form.Left = setting[name + "Left"];
            form.Top = setting[name + "Top"];
            form.Width = setting[name + "Width"];
            form.Height = setting[name + "Height"];
        }

        public static void setGridViewSettings(RadGridView gridView)
        {
            string name = gridView.Name + "_";
            foreach (GridViewDataColumn column in gridView.Columns)
            {
                if (!setting.ContainsKey(name + column.Name))
                    setting.Add(name + column.Name, column.Width);
                else
                    setting[name + column.Name] = column.Width;
                //column.Index
            }
        }

        public static void fillGridViewSettings(RadGridView gridView)
        {
            string name = gridView.Name + "_";
            foreach (GridViewDataColumn column in gridView.Columns)
            {
                try
                {
                    column.Width = setting[name + column.Name];
                }
                catch
                {
                    column.Width = 50;
                }
            }
        }

        public static void saveSettingsToFile()
        {
            string file = Common.path + "settings.xml";
            XDocument doc = XDocument.Load(file);
            IEnumerable<XElement> del = doc.Root.Element(section).Descendants().ToList();
            del.Remove();
            doc.Save(file);

            foreach(string key in setting.Keys)
            {
                XElement element = new XElement(key, setting[key]);
                doc.Root.Element(section).Add(element);
            }

            System.Xml.XmlWriterSettings settings = new System.Xml.XmlWriterSettings();
            settings.Encoding = new UTF8Encoding(false);
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;
            settings.NewLineOnAttributes = true;
            using (System.Xml.XmlWriter w = System.Xml.XmlWriter.Create(file, settings))
            {
                doc.Save(w);
            }                       
        }

        public static void loadSettingsFromFile()
        {
            string file = Common.path + "settings.xml";
            XDocument doc = XDocument.Load(file);
            setting.Clear();
            foreach (XElement elem in doc.Root.Element(section).Elements())
                setting.Add( elem.Name.ToString(), int.Parse(elem.Value.ToString()) );            
        }

    }
}
