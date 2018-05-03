using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeLib.ViewModels;
using TypeLib.Models;
using Muslimeen.BLL;

namespace Muslimeen.BLL
{
    public class DBHandler
    {
        DBAccess dbAccess = new DBAccess();

        public DBHandler()
        {

        }

        public List<uspGetQualification> BLL_uspGetQualification()
        {
            return dbAccess.GetQualification();
        }

        public bool AddMember(Member member)
        {
            return  false;
        }
    }
}
