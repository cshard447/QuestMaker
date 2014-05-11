using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace QuestMaker.Classes
{
    public abstract class CCommonText
    {
        private XDocument doc = new XDocument(new XElement("root"));
        string fileName;
        public static string section;
        public string writtenText;

        public CCommonText(string sectionName)
        {
            setSection( sectionName );
            this.fileName = Common.path + getSection() + ".xml";
            writtenText = "";
        }

        virtual public void setSection(string _section)
        {
            section = _section;
        }
        virtual public string getSection()
        {
            return section;
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
            IEnumerable<XElement> del = doc.Root.Element(getSection()).Descendants("text").ToList();
            del.Remove();
            doc.Save(file);

            XElement element = new XElement("text", writtenText);

            doc.Root.Element(getSection()).Add(element);            

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
        public void loadTextFromFile(string file = "")
        {
            file = (file.Length == 0) ? (fileName) : (file);
            writtenText = "";
            doc = XDocument.Load(file);            
            writtenText = doc.Root.Element(getSection()).Element("text").Value;
        }

    }

    public class CRules : CCommonText
    {
        public static new string section;
        public CRules()
            : base("rules")
        { }

        public override string getSection()
        {
            return section;
        }
        public override void setSection(string _section)
        {
            section = _section;
        }
    }

    public class CPrehistory : CCommonText
    {
        public static new string section;
        public CPrehistory()
            : base("prehistory")
        { }
        public override string getSection()
        {
            return section;
        }
        public override void setSection(string _section)
        {
            section = _section;
        }
    }
}
