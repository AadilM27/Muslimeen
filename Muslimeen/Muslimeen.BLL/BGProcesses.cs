using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace Muslimeen.BLL
{
    public class BGProcesses
    {
        public bool ClearUnverifiedMembers()
        {
            DBHandler db = new DBHandler();
            db.BLL_ClearUnverifiedMembers();
        }
        
    }
}
