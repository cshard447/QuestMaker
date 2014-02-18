using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace QuestMaker
{
    public enum AimType { primary, secondary, transitional};
    public class CAim
    {
        private int id;
        protected string name;
        public string description;
        public AimType type;

        public CAim()
        {
        }
        public CAim(int _id, string _name, string _description)
        {
            id = _id;
            name = _name;
            description = _description;
        }
        public string getName()
        {
            return name;
        }
        public int getID()
        {
            return id;
        }
    }

    public class CAimManager : CAim
    { 
        private Dictionary<int, CAim> aims = new Dictionary<int, CAim>();
        private XDocument doc = new XDocument(new XElement("root"));
        string fileName = "..\\..\\aims.xml";
        const string section = "aims";
        const int MAX_ITEMS = 1000;

        public CAimManager() : base ()
        { 
        
        }

        public void addAim(string _name, string _description)
        {
            int newID;
            for (newID = 0; newID < MAX_ITEMS; newID++)
                if (!aims.Keys.Contains(newID))
                    break;

            aims.Add(newID, new CAim(newID, _name, _description ) );
        }
        public bool removeAim(int idToDelete)
        {
            return aims.Remove(idToDelete);
        }
        public void removeAllAims()
        {
            aims.Clear();
        }

        public CAim getAim(int idToFind)
        { 
            CAim desired;
            aims.TryGetValue(idToFind, out desired);
            return desired;            
        }
        public CAim getAim(string nameToFind)
        {
            foreach (CAim aim in aims.Values)
            {
                if (aim.getName() == nameToFind)
                    return aim;
            }
            return null;
        }

        public Dictionary<int, CAim> getAllAims()
        {
            return aims;
        }
        public void saveItemsToFile()
        {
            XDocument doc = XDocument.Load(fileName);
            IEnumerable<XElement> del = doc.Root.Element(section).Descendants("aim").ToList();
            del.Remove();
            doc.Save(fileName);

            foreach (CAim aim in aims.Values)
            {
                IEnumerable<XElement> find = doc.Root.Element(section).Descendants("aim").Where(
                            t => t.Element("aimId").Value == aim.getID().ToString());
                foreach (XElement elem in find)
                    elem.Remove();

                XElement element = new XElement("aim",
                                new XElement("aimId", aim.getID()),
                                new XElement("aimName", aim.getName()),
                                new XElement("aimDescription", aim.description));

                doc.Root.Element(section).Add(element);
            }

            System.Xml.XmlWriterSettings settings = new System.Xml.XmlWriterSettings();
            settings.Encoding = new UTF8Encoding(false);
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;
            settings.NewLineOnAttributes = true;
            using (System.Xml.XmlWriter w = System.Xml.XmlWriter.Create(fileName, settings))
            {
                doc.Save(w);
            }
            //  doc.Save(fileName);
        }
        public void loadItemsFromFile()
        {
            removeAllAims();
            doc = XDocument.Load(fileName);
            foreach (XElement elem in doc.Root.Element(section).Elements())
            {
                string name = elem.Element("aimName").Value.ToString();
                string desc = elem.Element("aimDescription").Value.ToString();

                addAim(name, desc);
            }
        }

    }
}