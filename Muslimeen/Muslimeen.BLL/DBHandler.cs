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
        DBAccess dBAccess = new DBAccess();

        public DBHandler()
        {

        }

        public List<uspGetQualification> BLL_GetQualification()
        {
            return dBAccess.GetQualification();
        }

        public bool BLL_AddMember(Member member)
        {
            return dBAccess.AddMember(member);
        }

        public bool BLL_AddScholarQualification(Scholar scholar)
        {
            return dBAccess.AddScholarQualification(scholar);
        }

        public uspGetMember BLL_GetMember(string memberID)
        {
            return dBAccess.GetMember(memberID);
        }

        public bool BLL_VerifyMember(uspVerifyMember uspVerifyMember)
        {
            return dBAccess.VerifyMember(uspVerifyMember);
        }

        public List<uspGetMosque> BLL_GetMosque()
        {
            return dBAccess.GetMosque();
        }
    }
}
