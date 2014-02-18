using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestMaker.Classes
{
    public class Common
    {
        public static string convertNullString(object obj)
        {
            if (obj == null)
                return "";
            else
                return obj.ToString();
        }
    }
}
