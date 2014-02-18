using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QuestMaker
{
    public enum AimType { primary, secondary, transitional};
    public class CAim
    {
        private int id;
        public string name;
        public string description;
        public AimType type;

        protected CAim()
        {
        }
    }
}