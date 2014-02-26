using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Xml.Linq;
using System.Drawing;
using QuestMaker.Classes;


namespace QuestMaker
{
    public class CItem
    {
        private int id;
        protected string name;
        public string description;
        public string comment;
        public bool visibility;
        public string pathToImage;   // @todo think about it
        public Image image;
        public CItem()
        { 
        
        }
        public CItem(int _id, string _name, string _description, string _comment, bool _visibility)
        {
            id = _id;
            name = _name;
            description = _description;
            comment = _comment;
            visibility = _visibility;
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

    public class CItemManager : CItem
    {
        private Dictionary<int, CItem> items = new Dictionary<int, CItem>();
        private XDocument doc = new XDocument(new XElement("root"));      
        string fileName = Common.path + "items.xml";
        const string section = "items";
        const int MAX_ITEMS = 1000;

        public CItemManager() : base ()
        { 
        
        }

        public void addItem(string _name, string _description, string _comment, bool _visibility)
        {
            int newID;
            for (newID = 0; newID < MAX_ITEMS; newID++)
                if (!items.Keys.Contains(newID))
                    break;

            items.Add(newID, new CItem(newID, _name, _description, _comment, _visibility ) );
        }
        public bool removeItem(int idToDelete)
        {
            return items.Remove(idToDelete);
        }
        public void removeAllItems()
        {
            items.Clear();
        }

        public CItem getItem(int idToFind)
        { 
            CItem desired;
            items.TryGetValue(idToFind, out desired);
            return desired;            
        }
        public CItem getItem(string nameToFind)
        {
            foreach (CItem item in items.Values)
            {
                if (item.getName() == nameToFind)
                    return item;
            }
            return null;
        }
        public void updateItem(int id, string path)
        { 
            if ( !items.ContainsKey(id) )
                return;
            items[id].pathToImage = path;
        }
        public void updateItem(int id, Image _image)
        {
            if (!items.ContainsKey(id))
                return;
            items[id].image = _image;        
        }

        public Dictionary<int, CItem> getAllItems()
        {
            return items;
        }

        public void saveItemsToFile()
        {
            XDocument doc = XDocument.Load(fileName);
            IEnumerable<XElement> del = doc.Root.Element(section).Descendants("item").ToList();
            del.Remove();
            doc.Save(fileName);
            
            foreach (CItem item in items.Values)
            {
                IEnumerable<XElement> find = doc.Root.Element(section).Descendants("item").Where( 
                            t=> t.Element("itemId").Value == item.getID().ToString());
                foreach (XElement elem in find)
                    elem.Remove();

                XElement element = new XElement("item",
                                new XElement("itemId", item.getID()),
                                new XElement("itemName", item.getName()),
                                new XElement("itemDescription", item.description),
                                new XElement("itemComment", item.comment),
                                new XElement("itemImagePath", item.pathToImage),
                                new XElement("itemVisibility", item.visibility));

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
//            doc.Save(fileName);
        }
        public void loadItemsFromFile()
        {
            removeAllItems();
            doc = XDocument.Load(fileName);
            foreach (XElement elem in doc.Root.Element(section).Elements())
            {
                string name = elem.Element("itemName").Value.ToString();
                string desc = elem.Element("itemDescription").Value.ToString();
                string comm = elem.Element("itemComment").Value.ToString();
                string vis = elem.Element("itemVisibility").Value.ToString();

                addItem(name, desc, comm, ConvertStringToBool(vis));
            }
        }
        public void TestXML()
        {

        }

        public static bool ConvertStringToBool(string str)
        {
            return str.Equals("true");
        }
    }
}
