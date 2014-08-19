using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestMaker.Classes;

namespace QuestMaker.Classes
{
    public class CSingleton
    {
        private static readonly CSingleton instance = new CSingleton();

        public static CSingleton Instance
        {
            get { return instance; }
        }

        /// Защищенный конструктор нужен, чтобы предотвратить создание экземпляра класса Singleton
        protected CSingleton() 
        {
            eventManager = new CEventManager();
            itemManager = new CItemManager();
            aimManager = new CAimManager();
            personManager = new CPersonManager();
        }

        public CEventManager eventManager;
        public CItemManager itemManager;
        public CAimManager aimManager;
        public CPersonManager personManager;
    }
}
