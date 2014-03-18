using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace QuestMaker.Classes
{
    class CCommonText
    {
        private XDocument doc = new XDocument(new XElement("root"));
        string fileName;
        public static string section;
        public string writtenText;

        public CCommonText(string sectionName)
        {
            section = sectionName;
            fileName = Common.path + section + ".xml";
            writtenText = "";
        }

        public void updateTextFromUI(string newText)
        {
            writtenText = newText;
        }

        public void saveTextToFile(string file = "")
        {
            file = (file.Length == 0) ? (fileName) : (file);
            Common.createFileIfNotExists(file);
            doc = XDocument.Load(file);
            IEnumerable<XElement> del = doc.Root.Element(section).Descendants("text").ToList();
            del.Remove();
            doc.Save(file);

            XElement element = new XElement("text", writtenText);

            doc.Root.Element(section).Add(element);            

            System.Xml.XmlWriterSettings settings = new System.Xml.XmlWriterSettings();
            settings.Encoding = new UTF8Encoding(false);
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;
            settings.NewLineOnAttributes = true;
            using (System.Xml.XmlWriter w = System.Xml.XmlWriter.Create(file, settings))
            {
                doc.Save(w);
            }
            //            doc.Save(fileName);
        }
        public void loadItemsFromFile()
        {
            writtenText = "";
            doc = XDocument.Load(fileName);
            string qwer = doc.Root.Element(section).Element("text").Value;
            writtenText = qwer;            
        }


    }

    class CRules : CCommonText
    {
        public CRules()
            : base("rules")
        { }
    }
}
