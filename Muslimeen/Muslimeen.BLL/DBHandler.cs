using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeLib.Models;
using TypeLib.ViewModels;
using Muslimeen.DAL;

namespace Muslimeen.BLL
{
    public class DBHandler
    {
        DBAccess db = new DBAccess();

        public DBHandler()
        {
            
        }

        public List<uspGetQualification> BLL_GetQualification()
        {
            return db.GetQualification();
        }
      
    }
}
