using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Xml.Linq;
using System.Drawing;
using Telerik.WinControls.UI;
using QuestMaker.Classes;


namespace QuestMaker
{
    public class CItem
    {
        private int id;
        protected string name;
        public string description;
        public string comment;
        public string pathToImage;
        public Image image;
        public bool visibility;
        public bool singleUse;
        public CItem()
        { 
        
        }
        public CItem(int _id, string _name, string _description, string _comment, string _path, bool _visibility, bool _single)
        {
            id = _id;
            name = _name;
            description = _description;
            comment = _comment;
            pathToImage = _path;
            visibility = _visibility;
            singleUse = _single;
            if (pathToImage != "")
                image = Image.FromFile(pathToImage);
        }
        public string getName()
        {
            return name;
        }
        public int getID()
        {
            return id;
        }
        public void setName( string _name)
        {
            name = _name;
        }
    }

    public class ItemDataSourceObject
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string displayString;
        public string DisplayString
        {
            get { return displayString; }
            set { displayString = value; }
        }
        public ItemDataSourceObject(int _id, string _display)
        {
            id = _id;
            displayString = _display;
        }
    }

    public class CItemManager : CItem
    {
        private Dictionary<int, CItem> items = new Dictionary<int, CItem>();
        private XDocument doc = new XDocument(new XElement("root"));      
        string fileName = Common.path + "items.xml";
        public const string section = "items";
        const int MAX_ITEMS = 1000;
        private BindingList<ItemDataSourceObject> itemList = new BindingList<ItemDataSourceObject>();

        public CItemManager() : base ()
        { 
        
        }
        int calcNewID()
        {
            int newID;
            for (newID = 0; newID < MAX_ITEMS; newID++)
                if (!items.Keys.Contains(newID))
                    break;
            return newID;        
        }
        public void addItem(int _id, string _name, string _description, string _comment, string _path, bool _visibility, bool _singleUse)
        {
            items.Add(_id, new CItem(_id, _name, _description, _comment, _path, _visibility, _singleUse));
        }
        public int addItem(string _name, string _description, string _comment, string _path, bool _visibility, bool _singleUse)
        {
            int newID = calcNewID();
            items.Add(newID, new CItem(newID, _name, _description, _comment, _path, _visibility, _singleUse ) );
            return newID;
        }
        public void addItem(CItem item)
        {
            int newID = calcNewID();
            addItem(newID, item.getName(), item.description, item.comment, item.pathToImage, item.visibility, item.singleUse);
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

        public void UpdateItemsFromGrid(RadGridView gridView)
        {
            List<int> idsInTable = new List<int>();
            for (int row = 0; row < gridView.RowCount; row++)
            {
                int id = Common.convertNullInt(gridView.Rows[row].Cells["columnID"].Value);
                string name = Common.convertNullString(gridView.Rows[row].Cells["columnName"].Value);
                string desc = Common.convertNullString(gridView.Rows[row].Cells["columnDescription"].Value);
                string comm = Common.convertNullString(gridView.Rows[row].Cells["columnComment"].Value);
                string path = Common.convertNullString(gridView.Rows[row].Cells["columnPath"].Value);
                bool vis = (bool) gridView.Rows[row].Cells["columnVisibility"].Value;
                bool single = (bool) gridView.Rows[row].Cells["columnSingleUse"].Value;

                if (!items.ContainsKey(id))
                    id = this.addItem(name, desc, comm, path, vis, single);
                else
                {
                    items[id].setName(name);
                    items[id].description = desc;
                    items[id].comment = comm;
                    items[id].pathToImage = path;
                    items[id].visibility = vis;
                    items[id].singleUse = single;
                }                
                idsInTable.Add(id);
            }
            
            foreach (int id in items.Keys.ToList())
            {
                if (!idsInTable.Contains(id))
                    this.removeItem(id);
            }
        }

        public void saveItemsToFile(string file = "")
        {
            file = (file.Length == 0) ? (fileName) : (file);
            Common.createFileIfNotExists(file);
            XDocument doc = XDocument.Load(file);
            IEnumerable<XElement> del = doc.Root.Element(section).Descendants("item").ToList();
            del.Remove();
            doc.Save(file);
            
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
                                new XElement("itemVisibility", item.visibility),
                                new XElement("itemSingleUse", item.singleUse));

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
//            doc.Save(fileName);
        }
        public void loadItemsFromFile()
        {
            removeAllItems();
            doc = XDocument.Load(fileName);
            foreach (XElement elem in doc.Root.Element(section).Elements())
            {
                int id = int.Parse(elem.Element("itemId").Value.ToString());
                string name = elem.Element("itemName").Value.ToString();
                string desc = elem.Element("itemDescription").Value.ToString();
                string comm = elem.Element("itemComment").Value.ToString();
                string path = elem.Element("itemImagePath").Value.ToString();
                string vis = elem.Element("itemVisibility").Value.ToString();
                string single = elem.Element("itemSingleUse").Value.ToString();

                addItem(id, name, desc, comm, path, ConvertStringToBool(vis), ConvertStringToBool(single));
            }
        }
        public void TestXML()
        {

        }

        public string getItemsNamesFromId(List<int> ids)
        {
            string result = "";
            foreach (int id in ids)
                result += items[id].getName() + "; ";
            return result;
        }

        public BindingList<ItemDataSourceObject> getItemsList()
        {
            itemList.Clear();
            foreach (CItem item in items.Values)
                itemList.Add(new ItemDataSourceObject(item.getID(), item.getName()));
            return itemList;
        }

        public static bool ConvertStringToBool(string str)
        {
            return str.Equals("true");
        }
    }
}
