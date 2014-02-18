using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestMaker.Classes
{
    public enum EventType { dataPass, itemEjection }
    class CAuthorEvent
    {
        private int id;
        public string description;
        public string precondition;
        public EventType type;
        List<CItem> items;
        List<CThought> thoughts;
    }
}
