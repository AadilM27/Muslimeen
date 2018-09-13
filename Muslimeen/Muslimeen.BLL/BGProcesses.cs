using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Muslimeen.BLL
{
    public class BGProcesses
    {
        //public bool ClearUnverifiedMembers()
        //{
            
        //}
        System.Timers.Timer TimerObj = new System.Timers.Timer(3600000);



        public bool ClearUnverifiedMembers()
        {
            bool success = false;
            DBHandler db = new DBHandler();

           success = db.BLL_ClearUnverifiedMembers();

            return success;
        }
    }
}
