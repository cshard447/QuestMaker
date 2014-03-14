using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.ComponentModel;
using QuestMaker.Classes;
using Telerik.WinControls.UI;

namespace QuestMaker
{
    public enum AimType { primary = 0, secondary = 1, transitional = 2};
    public class CAim
    {
        private int id;
        protected string name;
        public string description;
        public AimType type;

        public CAim()
        {
        }
        public CAim(int _id, string _name, string _description, AimType _type)
        {
            id = _id;
            name = _name;
            description = _description;
            type = _type;
        }
        public string getName()
        {
            return name;
        }
        public void setName(string _name)
        {
            name = _name;
        }
        public int getID()
        {
            return id;
        }
    }

    public class AimTypeDataSourceObject
    {
        private string displayString;
        public string DisplayString
        {
            get { return displayString; }
            set { displayString = value; }
        }

        private AimType type;
        public AimType Type
        {
            get { return type; }
            set { type = value; }
        }
    }

    public class CAimManager : CAim
    { 
        private Dictionary<int, CAim> aims = new Dictionary<int, CAim>();
        private XDocument doc = new XDocument(new XElement("root"));
        Dictionary<string, AimType> strToType = new Dictionary<string,AimType>();

        public BindingList<AimTypeDataSourceObject> list = new BindingList<AimTypeDataSourceObject>();

        string fileName = Common.path + "aims.xml";
        public const string section = "aims";
        const int MAX_ITEMS = 1000;

        public CAimManager() : base ()
        {
            initDict();
        }
        public void addAim(int _id, string _name, string _description, AimType _type)
        { 
            aims.Add(_id, new CAim(_id, _name, _description, _type));
        }

        public int addAim(string _name, string _description, AimType _type)
        {
            int newID;
            for (newID = 0; newID < MAX_ITEMS; newID++)
                if (!aims.Keys.Contains(newID))
                    break;

            aims.Add(newID, new CAim(newID, _name, _description, _type ) );
            return newID;
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

        public void UpdateAimsFromGrid(RadGridView gridView)
        {
            List<int> idsInTable = new List<int>();
            for (int row = 0; row < gridView.RowCount; row++)
            {
                int id = int.Parse(gridView.Rows[row].Cells["columnID"].Value.ToString());
                string name = Common.convertNullString(gridView.Rows[row].Cells["columnName"].Value);
                string desc = Common.convertNullString(gridView.Rows[row].Cells["columnDescription"].Value);
                AimType type = (AimType) gridView.Rows[row].Cells["columnType"].Value;                

                if (!aims.ContainsKey(id))
                    id = this.addAim(name, desc, type);
                else
                {
                    aims[id].setName(name);
                    aims[id].description = desc;
                    aims[id].type = type;                    
                }
                idsInTable.Add(id);
            }

            foreach (int id in aims.Keys.ToList())
            {
                if (!idsInTable.Contains(id))
                    this.removeAim(id);
            }        

        }
        public void saveAimsToFile(string file = "")
        {
            file = (file.Length == 0) ? (fileName) : (file);
            Common.createFileIfNotExists(file);
            XDocument doc = XDocument.Load(file);
            IEnumerable<XElement> del = doc.Root.Element(section).Descendants("aim").ToList();
            del.Remove();
            doc.Save(file);

            foreach (CAim aim in aims.Values)
            {
                IEnumerable<XElement> find = doc.Root.Element(section).Descendants("aim").Where(
                            t => t.Element("aimId").Value == aim.getID().ToString());
                foreach (XElement elem in find)
                    elem.Remove();

                XElement element = new XElement("aim",
                                new XElement("aimId", aim.getID()),
                                new XElement("aimName", aim.getName()),
                                new XElement("aimDescription", aim.description),
                                new XElement("aimType", aim.type.ToString()));

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
            //  doc.Save(fileName);
        }
        public void loadAimsFromFile()
        {
            removeAllAims();
            doc = XDocument.Load(fileName);
            foreach (XElement elem in doc.Root.Element(section).Elements())
            {
                int id = int.Parse(elem.Element("aimId").Value.ToString());
                string name = elem.Element("aimName").Value.ToString();
                string desc = elem.Element("aimDescription").Value.ToString();
                string strtype = elem.Element("aimType").Value.ToString();
                AimType type = getType(strtype);
                addAim(id, name, desc, type);
            }
        }

        private void initDict()
        { 
            strToType.Add("primary", AimType.primary);
            strToType.Add("secondary", AimType.secondary);
            strToType.Add("transitional", AimType.transitional);

            AimTypeDataSourceObject obj1 = new AimTypeDataSourceObject();
            obj1.DisplayString = "Главная";
            obj1.Type = AimType.primary;
            list.Add(obj1);
            AimTypeDataSourceObject obj2 = new AimTypeDataSourceObject();
            obj2.DisplayString = "Побочная";
            obj2.Type = AimType.secondary;
            list.Add(obj2);
            AimTypeDataSourceObject obj3 = new AimTypeDataSourceObject();
            obj3.DisplayString = "Промежуточная";
            obj3.Type = AimType.transitional;
            list.Add(obj3);

        }
        
        public AimType getType (string type)
        {
            if (strToType.ContainsKey(type))
                return strToType[type];
            else
                return AimType.secondary;                        
        }
        
    }
}