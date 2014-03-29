using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls.UI;

namespace QuestMaker.Classes
{
    public enum Sex {male, female, flexible};
    public enum Clan { empty = 0, red = 1, green = 2, blue = 3, violet = 4};
    public class CPerson
    {
        private int id;
        protected string name;
        public Sex sex;
        public string description;
        public bool unremovable;
        public string comment;
        public string altName;
        public Clan clan;
        List<CItem> items;
        List<CAim> aims;

        public CPerson(int _id, string _name, Sex _sex, string _description, bool _unremovable, string _comment, string _altName = "", Clan _clan = 0 )
        {
            id = _id;
            name = _name;
            sex = _sex;
            description = _description;
            unremovable = _unremovable;
            comment = _comment;
            altName = _altName;
            clan = _clan;
        }

        public string getName()
        {
            return name;
        }
        public int getID()
        {
            return id;
        }
        public void setName(string _name)
        {
            name = _name;
        }
    }

    public class SexDataSourceObject
    {
        private string displayString;
        public string DisplayString
        {
            get { return displayString; }
            set { displayString = value; }
        }

        private Sex enumSex;
        public Sex EnumSex
        {
            get { return enumSex; }
            set { enumSex = value; }
        }
    }


    public class CPersonManager
    {
        private Dictionary<int, CPerson> persons = new Dictionary<int, CPerson>();
        private XDocument doc = new XDocument(new XElement("root"));
        string fileName = Common.path + "persons.xml";
        public const string section = "persons";
        const int MAX_PERSONS = 100;
        public BindingList<SexDataSourceObject> list = new BindingList<SexDataSourceObject>();
        Dictionary<string, Sex> strToSex = new Dictionary<string, Sex>();

        public CPersonManager()
        {
            initDict();
        }

        public void addPerson(int _id, string _name, Sex _sex, string _description, bool _unremovable, string _comment, string _altName = "", Clan _clan = 0 )
        {
            persons.Add(_id, new CPerson(_id, _name, _sex, _description, _unremovable, _comment, _altName, _clan ));
        }
        public int addPerson(string _name, Sex _sex, string _description, bool _unremovable, string _comment, string _altName = "", Clan _clan = 0)
        {
            int newID;
            for (newID = 0; newID < MAX_PERSONS; newID++)
                if (!persons.Keys.Contains(newID))
                    break;

            persons.Add(newID, new CPerson(newID, _name, _sex, _description, _unremovable, _comment, _altName, _clan));
            return newID;        
        }
        public bool removePerson(int idToDelete)
        {
            return persons.Remove(idToDelete);
        }
        public void removeAllPersons()
        {
            persons.Clear();
        }
        public CPerson getPerson(int idToFind)
        {
            CPerson desired;
            persons.TryGetValue(idToFind, out desired);
            return desired;
        }
        public Dictionary<int, CPerson> getAllPersons()
        {
            return persons;
        }
        public void UpdatePersonsFromGrid(RadGridView gridView)
        {
            List<int> idsInTable = new List<int>();
            for (int row = 0; row < gridView.RowCount; row++)
            {
                int id = int.Parse(gridView.Rows[row].Cells["columnID"].Value.ToString());
                string name = Common.convertNullString(gridView.Rows[row].Cells["columnName"].Value);
                Sex sex = (Sex) gridView.Rows[row].Cells["columnSex"].Value;
                string desc = Common.convertNullString(gridView.Rows[row].Cells["columnDescription"].Value);
                bool unrem = (bool)gridView.Rows[row].Cells["columnUnremovable"].Value;
                string alt = Common.convertNullString(gridView.Rows[row].Cells["columnAltName"].Value);
                string comm = Common.convertNullString(gridView.Rows[row].Cells["columnComment"].Value);

                if (!persons.ContainsKey(id))
                    id = this.addPerson(name, sex, desc, unrem, comm, alt);
                else
                {
                    persons[id].setName(name);
                    persons[id].sex = sex;
                    persons[id].description = desc;
                    persons[id].unremovable = unrem;
                    persons[id].comment = comm;
                    persons[id].altName = alt;
                }
                idsInTable.Add(id);
            }

            foreach (int id in persons.Keys.ToList())
            {
                if (!idsInTable.Contains(id))
                    this.removePerson(id);
            }
        }

        public void savePersonsToFile(string file = "")
        {
            file = (file.Length == 0) ? (fileName) : (file);
            Common.createFileIfNotExists(file);
            XDocument doc = XDocument.Load(file);
            IEnumerable<XElement> del = doc.Root.Element(section).Descendants("person").ToList();
            del.Remove();
            doc.Save(file);

            foreach (CPerson person in persons.Values)
            {
                IEnumerable<XElement> find = doc.Root.Element(section).Descendants("person").Where(
                            t => t.Element("personId").Value == person.getID().ToString());
                foreach (XElement elem in find)
                    elem.Remove();

                XElement element = new XElement("person",
                                new XElement("personId", person.getID()),
                                new XElement("personName", person.getName()),
                                new XElement("personSex", person.sex),
                                new XElement("personDescription", person.description),
                                new XElement("personUnremovable", person.unremovable),
                                new XElement("personComment", person.comment),
                                new XElement("personAltName", person.altName));
                                //new XElement("personClan", person.clan));

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
        public void loadPersonsFromFile()
        {
            removeAllPersons();
            doc = XDocument.Load(fileName);
            foreach (XElement elem in doc.Root.Element(section).Elements())
            {
                int id = int.Parse(elem.Element("personId").Value.ToString());
                string name = elem.Element("personName").Value.ToString();
                Sex sex = getSexEnum( elem.Element("personSex").Value.ToString() );
                string desc = elem.Element("personDescription").Value.ToString();
                string unrem = elem.Element("personUnremovable").Value.ToString();
                string comm = elem.Element("personComment").Value.ToString();
                string alt = elem.Element("personAltName").Value.ToString();                

                addPerson(id, name, sex, desc, ConvertStringToBool(unrem), comm, alt);
            }
        }

        public static bool ConvertStringToBool(string str)
        {
            return str.Equals("true");
        }

        private void initDict()
        {
            strToSex.Add("male", Sex.male);
            strToSex.Add("female", Sex.female);
            strToSex.Add("flexible", Sex.flexible);

            SexDataSourceObject[] obj = { new SexDataSourceObject(), new SexDataSourceObject(), new SexDataSourceObject() };
            obj[0].DisplayString = "Мужик";
            obj[0].EnumSex = Sex.male;
            list.Add(obj[0]);
            obj[1].DisplayString = "Девушка";
            obj[1].EnumSex = Sex.female;
            list.Add(obj[1]);
            obj[2].DisplayString = "Не определился";
            obj[2].EnumSex = Sex.flexible;
            list.Add(obj[2]);            
        }

        public Sex getSexEnum(string sex)
        {
            if (strToSex.ContainsKey(sex))
                return strToSex[sex];
            else
                return Sex.flexible;
        }

    }

    
}
