using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using Telerik.WinControls.UI;

namespace QuestMaker.Classes
{
    public enum Sex {male, female, flexible};
    public class CPerson
    {
        private int id;
        protected string name;
        public Sex sex;
        public string description;
        public bool unremovable;
        public string comment;
        public string altName;
        public KnownColor clan;
        //public List<CItem> items;
        //public List<CAim> aims;

        public List<int> itemsId = new List<int>();
        public List<int> aimsId = new List<int>();

        public CPerson(int _id, string _name, Sex _sex, string _description, bool _unremovable, string _comment,
                            List<int> _itemsList, List<int> _aimsList, KnownColor _clan, string _altName = "")
        {
            id = _id;
            name = _name;
            sex = _sex;
            description = _description;
            unremovable = _unremovable;
            comment = _comment;
            itemsId = _itemsList;
            aimsId = _aimsList;
            clan = _clan;
            altName = _altName;
        }

        public CPerson(int _id, string _name, Sex _sex, string _description, bool _unremovable, string _comment,
                            KnownColor _clan, string _altName = "")
        {
            id = _id;
            name = _name;
            sex = _sex;
            description = _description;
            unremovable = _unremovable;
            comment = _comment;
            clan = _clan;
            altName = _altName;
        }

        public CPerson()
        {
            //id = null;
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
        public void setOwnItems(List<int> _ownItems)
        {
            itemsId = _ownItems;
        }
        public void setOwnAims(List<int> _ownAims)
        {
            aimsId = _ownAims;
        }

    }

    public class SexDataSourceObject
    {
        private string displayString;
        public string DisplayString
        {
            get { return displayString; }
        }

        private Sex enumSex;
        public Sex EnumSex
        {
            get { return enumSex; }
        }
        public SexDataSourceObject(Sex _sex, string _display)
        {
            enumSex = _sex;
            displayString = _display;
        }
    }

    public class ClanClass
    {
        private KnownColor clan;
        private string display;

        public string Display 
        {
            get { return display; }
        }
        public KnownColor Clan
        {
            get { return clan;}
        }
        public ClanClass(KnownColor _clan, string _display)
        {
            clan = _clan;
            display = _display;
        }
    }

    public class PersonNameObject
    {
        private int id;
        private string name;
        public int Id
        {
            get{return id;}
            set{id = value;}
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public PersonNameObject(int _id, string _name)
        {
            id = _id;
            name = _name;
        }
    }


    public class CPersonManager
    {
        private Dictionary<int, CPerson> persons = new Dictionary<int, CPerson>();
        private XDocument doc = new XDocument(new XElement("root"));
        string fileName = Common.path + "persons.xml";
        public const string section = "persons";
        const int MAX_PERSONS = 100;
        public static BindingList<SexDataSourceObject> enumSexList = new BindingList<SexDataSourceObject>();
        public static BindingList<ClanClass> clanList = new BindingList<ClanClass>();
        BindingList<PersonNameObject> personList = new BindingList<PersonNameObject>();
        Dictionary<string, Sex> strToSex = new Dictionary<string, Sex>();

        public CPersonManager()
        {
            initDict();
        }
        int calcNewID()
        {
            int newID;
            for (newID = 0; newID < MAX_PERSONS; newID++)
                if (!persons.Keys.Contains(newID))
                    break;
            return newID;        
        }

        public void addPerson(int _id, string _name, Sex _sex, string _description, bool _unremovable, string _comment,
                                List<int> _itemsList, List<int> _aimsList, KnownColor _clan, string _altName = "")
        {
            persons.Add(_id, new CPerson(_id, _name, _sex, _description, _unremovable, _comment, _itemsList, _aimsList, _clan , _altName));
        }
        public int addPerson(string _name, Sex _sex, string _description, bool _unremovable, string _comment, KnownColor _clan, string _altName = "")
        {
            int newID = calcNewID();
            persons.Add(newID, new CPerson(newID, _name, _sex, _description, _unremovable, _comment, _clan, _altName ));
            return newID;        
        }
        public void addPerson(CPerson person)
        {
            int newID = calcNewID();
            addPerson(newID, person.getName(), person.sex, person.description, person.unremovable, person.comment, person.itemsId, person.aimsId, person.clan, person.altName);
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
        public void updatePerson(CPerson updated)
        { 
            if (!this.persons.ContainsKey(updated.getID()))
                throw new System.ArgumentException("Персонажа с таким ID не существует!");
            persons[updated.getID()] = updated;
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
                int id = Common.convertNullInt(gridView.Rows[row].Cells["columnID"].Value);
                string name = Common.convertNullString(gridView.Rows[row].Cells["columnName"].Value);
                Sex sex = (Sex) gridView.Rows[row].Cells["columnSex"].Value;
                string desc = Common.convertNullString(gridView.Rows[row].Cells["columnDescription"].Value);
                bool unrem = (bool)gridView.Rows[row].Cells["columnUnremovable"].Value;
                string alt = Common.convertNullString(gridView.Rows[row].Cells["columnAltName"].Value);
                string comm = Common.convertNullString(gridView.Rows[row].Cells["columnComment"].Value);
                KnownColor clan = (KnownColor)gridView.Rows[row].Cells["columnClanColor"].Value;
                
                if (!persons.ContainsKey(id))
                    id = this.addPerson(name, sex, desc, unrem, comm, clan, alt);
                else
                {
                    persons[id].setName(name);
                    persons[id].sex = sex;
                    persons[id].description = desc;
                    persons[id].unremovable = unrem;
                    persons[id].comment = comm;
                    persons[id].altName = alt;
                    persons[id].clan = clan;
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
                                new XElement("personAltName", person.altName),
                                new XElement("personalItems", Common.getListAsStringWithDelimiter(person.itemsId, ",")),
                                new XElement("personalAims", Common.getListAsStringWithDelimiter(person.aimsId, ",")),
                                new XElement("personClan", person.clan));

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
        public void loadPersonsFromFile(string file = "")
        {
            file = (file.Length == 0) ? (fileName) : (file);
            removeAllPersons();
            doc = XDocument.Load(file);
            foreach (XElement elem in doc.Root.Element(section).Elements())
            {
                int id = int.Parse(elem.Element("personId").Value.ToString());
                string name = elem.Element("personName").Value.ToString();
                Sex sex = getSexFromString( elem.Element("personSex").Value.ToString() );
                string desc = elem.Element("personDescription").Value.ToString();
                string unrem = elem.Element("personUnremovable").Value.ToString();
                string comm = elem.Element("personComment").Value.ToString();
                string alt = elem.Element("personAltName").Value.ToString();
                string itemStr = elem.Element("personalItems").Value.ToString();
                string aimStr = elem.Element("personalAims").Value.ToString();
                KnownColor clan = (Color.FromName(elem.Element("personClan").Value.ToString())).ToKnownColor();

                List<int> itemsList = Common.splitStringIntoList(itemStr);
                List<int> aimsList = Common.splitStringIntoList(aimStr);

                addPerson(id, name, sex, desc, ConvertStringToBool(unrem), comm, itemsList, aimsList, clan, alt);
            }
        }

        public static bool ConvertStringToBool(string str)
        {
            return str.Equals("true");
        }

        public string getPersonsNamesFromId(List<int> ids)
        {
            string result = "";
            foreach (int id in ids)
            {
                try
                {
                    result += persons.ElementAt(id).Value.getName() + "; ";
                }
                catch (System.ArgumentOutOfRangeException e)
                {
                    CommonError.addErrorString("Не существует персонаж с ID = " + id.ToString());
                }
            }
            return result;
        }

        private void initDict()
        {
            strToSex.Add("male", Sex.male);
            strToSex.Add("female", Sex.female);
            strToSex.Add("flexible", Sex.flexible);
  
            enumSexList.Add( new SexDataSourceObject(Sex.male, "Мужчина") );
            enumSexList.Add( new SexDataSourceObject(Sex.female, "Женщина") );
            enumSexList.Add( new SexDataSourceObject(Sex.flexible, "Изменяемый") );

            clanList.Add( new ClanClass(KnownColor.Red, "Красный") );
            clanList.Add( new ClanClass(KnownColor.Pink, "Розовый") );
            clanList.Add( new ClanClass(KnownColor.Blue, "Синий") );
            clanList.Add( new ClanClass(KnownColor.Violet, "Фиолетовый") );
            clanList.Add( new ClanClass(KnownColor.Green, "Зеленый") );
            clanList.Add( new ClanClass(KnownColor.Gray, "Серый") );
        }

        public BindingList<PersonNameObject> getPersonsList()
        {
            personList.Clear();
            foreach (CPerson person in persons.Values)
                personList.Add(new PersonNameObject(person.getID(), person.getName()));
            return personList;
        }

        public Sex getSexFromString(string sex)
        {
            if (strToSex.ContainsKey(sex))
                return strToSex[sex];
            else
                return Sex.flexible;
        }

    }

    
}
