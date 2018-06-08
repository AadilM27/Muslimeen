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

        public List<uspGetAllMosques> BLL_GetAllMosques()
        {
            return dBAccess.GetAllMosques();
        }
        public uspGetModeratorDetails BLL_GetModeratorDetails(string memberID)
        {
            return dBAccess.GetModeratorDetails(memberID);
        }

        public uspGetScholarDetails BLL_GetScholarDetails(string memberID)
        {
            return dBAccess.GetScholarDetails(memberID);
        }

        //Adding a new Article by the Scholar...
        public bool BLL_AddArticle(Article article)
        {
            return dBAccess.AddArticle(article);
        }
        public bool BLL_UpdateMember(UpdateMember updateMember)
        {
            return dBAccess.UpdateMember(updateMember);
        }

        public bool BLL_UpdateMemberPassword(UpdateMemberPassword updateMemberPassword)
        {
            return dBAccess.UpdateMemberPassword(updateMemberPassword);
        }
        public Zakaah BLL_GetZakaah()
        {
             return dBAccess.GetZakaah();
        }
        public List<uspGetOrganizations> BLL_GetOrganization()
        {
            return dBAccess.GetOrganization();
        }
        //Get All Topics
        public List<uspGetTopics> BLL_GetTopics()
        {
            return dBAccess.GetTopics();
        }
    }
}
