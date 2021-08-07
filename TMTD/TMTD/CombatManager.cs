using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMTD
{
    public class CombatManager
    {
        private static CombatManager instance;
        public static CombatManager GetInstance() 
        {
            if (instance == null)
            {
                instance = new CombatManager();
            }
            return instance;
        }
        private CombatManager() 
        {

        }

    }
}
