using System;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using Telerik.WinControls.UI;

namespace QuestMaker.Classes
{
    public enum EventType { dataPass, itemEjection, announcement }
    public class CAuthorEvent
    {
        private int id;
        public string description;
        public string precondition;
        public decimal time;
        public EventType type;
        //List<CItem> items;
        //List<CThought> thoughts;

        public CAuthorEvent()
        {
        }

        public CAuthorEvent(int _id, string _desc, string _precond, decimal _time, EventType _type)
        {
            id = _id;
            description = _desc;
            precondition = _precond;
            time = _time;
            type = _type;           
        }

        public int getID()
        {
            return id;
        }
    }

    public class EventTypeDataSourceObject
    {
        private string displayString;
        public string DisplayString
        {
            get { return displayString; }
        }

        private EventType type;
        public EventType Type
        {
            get { return type; }
        }
        public EventTypeDataSourceObject(EventType _type, string _display)
        {
            type = _type;
            displayString = _display;
        }
    }

    public class CEventManager
    {
        private Dictionary<int, CAuthorEvent> events = new Dictionary<int,CAuthorEvent>();
        public static BindingList<EventTypeDataSourceObject> enumEventList = new BindingList<EventTypeDataSourceObject>();
        Dictionary<string, EventType> strToType = new Dictionary<string, EventType>();
        private XDocument doc = new XDocument(new XElement("root"));
        string fileName = Common.path + "events.xml";
        public const string section = "events";
        const int MAX_EVENTS = 100;

        public CEventManager()
        {
            initDict();
        }
        int calcNewID()
        {
            int newID;
            for (newID = 0; newID < MAX_EVENTS; newID++)
                if (!events.Keys.Contains(newID))
                    break;
            return newID;
        }
        public void addEvent(int _id, string _description, string _precondition, decimal _time, EventType _type)
        {
            events.Add(_id, new CAuthorEvent(_id, _description, _precondition, _time, _type));
        }
        public int addEvent(string _description, string _precondition, decimal _time, EventType _type)
        {
            int newID = calcNewID();
            events.Add(newID, new CAuthorEvent(newID, _description, _precondition, _time, _type));
            return newID;
        }
        public int addEvent(CAuthorEvent _event)
        {
            int newID = calcNewID();
            addEvent(newID, _event.description, _event.precondition, _event.time, _event.type);
            return newID;
        }

        public bool removeEvent(int idToDelete)
        {
            return events.Remove(idToDelete);
        }
        public void removeAllEvents()
        {
            events.Clear();
        }

        public CAuthorEvent getEvent(int idToFind)
        {
            CAuthorEvent desired;
            events.TryGetValue(idToFind, out desired);
            return desired;
        }
        public Dictionary<int, CAuthorEvent> getAllEvents()
        {
            return events;
        }
        public void UpdateEventsFromGrid(RadGridView gridView)
        {
            List<int> idsInTable = new List<int>();
            for (int row = 0; row < gridView.RowCount; row++)
            {
                int id = Common.convertNullInt(gridView.Rows[row].Cells["columnID"].Value);
                string desc = Common.convertNullString(gridView.Rows[row].Cells["columnDescription"].Value);
                string precond = Common.convertNullString(gridView.Rows[row].Cells["columnPrecondition"].Value);
                decimal time = (decimal) gridView.Rows[row].Cells["columnTime"].Value;
                EventType type = (EventType)gridView.Rows[row].Cells["columnEventType"].Value;

                if (!events.ContainsKey(id))
                    id = this.addEvent(desc, precond, time, type);
                else
                {                    
                    events[id].description = desc;
                    events[id].precondition = precond;
                    events[id].time = time;
                    events[id].type = type;
                }
                idsInTable.Add(id);
            }

            foreach (int id in events.Keys.ToList())
            {
                if (!idsInTable.Contains(id))
                    this.removeEvent(id);
            }
        }
        public void saveEventsToFile(string file = "")
        {
            file = (file.Length == 0) ? (fileName) : (file);
            Common.createFileIfNotExists(file);
            XDocument doc = XDocument.Load(file);
            IEnumerable<XElement> del = doc.Root.Element(section).Descendants("event").ToList();
            del.Remove();
            doc.Save(file);

            foreach (CAuthorEvent Event in events.Values)
            {
                IEnumerable<XElement> find = doc.Root.Element(section).Descendants("event").Where(
                            t => t.Element("eventId").Value == Event.getID().ToString());
                foreach (XElement elem in find)
                    elem.Remove();

                XElement element = new XElement("event",
                                new XElement("eventId", Event.getID()),
                                new XElement("eventDescription", Event.description),
                                new XElement("eventPrecondition", Event.precondition),
                                new XElement("eventTime", Event.time),
                                new XElement("eventType", Event.type));

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
        public void loadEventsFromFile(string file = "")
        {
            file = (file.Length == 0) ? (fileName) : (file);
            removeAllEvents();
            doc = XDocument.Load(file);
            foreach (XElement elem in doc.Root.Element(section).Elements())
            {
                int id = int.Parse(elem.Element("eventId").Value.ToString());
                string desc = elem.Element("eventDescription").Value.ToString();
                string precond = elem.Element("eventPrecondition").Value.ToString();
                string timestr = elem.Element("eventTime").Value.ToString();
                string strtype = elem.Element("eventType").Value.ToString();
                decimal time = Decimal.Parse(timestr);
                EventType type = getType(strtype);
                addEvent(id, desc, precond, time, type);
            }
        }

        private void initDict()
        {
            strToType.Add("dataPass", EventType.dataPass);
            strToType.Add("itemEjection", EventType.itemEjection);
            strToType.Add("announcement", EventType.announcement);

            enumEventList.Add(new EventTypeDataSourceObject(EventType.dataPass, "Передача данных"));
            enumEventList.Add(new EventTypeDataSourceObject(EventType.itemEjection, "Вброс предметов"));
            enumEventList.Add(new EventTypeDataSourceObject(EventType.announcement, "Объявление"));
        }
        public EventType getType(string type)
        {
            if (strToType.ContainsKey(type))
                return strToType[type];
            else
                return EventType.dataPass;
        }


    }


}
