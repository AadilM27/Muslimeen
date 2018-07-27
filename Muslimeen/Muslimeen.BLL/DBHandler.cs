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

        public uspGetMosque GetMosque(int mosqueID)
        {
            return dBAccess.GetMosque(mosqueID);
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

        public List<uspGetAllPendingScholars> BLL_GetAllPendingScholars()
        {
            return dBAccess.GetAllPendingScholars();
        }

        //Pending Articles
        public List<Article> BLL_GetPendingArticle()
        {
            return dBAccess.GetPendingArticle();
        }

        public bool BLL_RejectReg (uspRejectReg uspRejectReg)
        {
            return dBAccess.RejectReg(uspRejectReg);
        }

        public List<uspGetAllPendingModeraters> BLL_GetAllPendingModeraters()
        {
            return dBAccess.GetAllPendingModeraters();
        }

        public List<uspGetMosques> BLL_GetMosques(string suburb, string mosqueType)
        {
            return dBAccess.GetMosques(suburb, mosqueType);
        }

        public List<uspGetAllMosqueSuburbs> BLL_GetAllMosqueSuburbs()
        {
            return dBAccess.GetAllMosqueSuburbs();
        }

        public List<uspGetMosqueEvents> Bll_GetMosqueEvents(int MosqueID)
        {
            return dBAccess.GetMosqueEvents(MosqueID);
        }
        public List<uspGetMosqueEventsDateRange> Bll_GetMosqueEventsDateRange(int MosqueID, DateTime StartDate, DateTime EndDate)
        {
            return dBAccess.GetMosqueEventsDateRange(MosqueID, StartDate, EndDate);
        }
        public uspGetSpecificDayPrayerTimes BLL_GetSpecficDayPrayerTimes(int mosqueID, DateTime date)
        {
            return dBAccess.GetSpecficDayPrayerTimes(mosqueID, date);
        }
        public bool BLL_InsertPrayer(Prayer prayer)
        {
            return dBAccess.InsertPrayer(prayer);
        }
        public bool BLL_InsertPrayerType(PrayerType type)
        {
            return dBAccess.InsertPrayerType(type);
        }
        public bool BLL_UpdatePrayerType(PrayerType type)
        {
            return dBAccess.UpdatePrayerType(type);
        }
        public List<uspGetMosquePrayerTimes> BLL_GetMosquePrayerTimes(int mosqueID, DateTime StartDate, DateTime EndDate)
        {
            return dBAccess.GetMosquePrayerTimes(mosqueID, StartDate, EndDate);
        }
        public bool BLL_InsertEvent(Event mosqueEvent)
        {
            return dBAccess.InsertEvent(mosqueEvent);
        }
        public bool BLL_UpdateEvent(Event mosqueEvent)
        {
            return dBAccess.UpdateEvent(mosqueEvent);
        }
        public uspGetSpecificEvent BLL_GetuspGetSpecificEvent(int EventID)
        {
            return dBAccess.GetSpecificEvent(EventID);
        }
        public bool BLL_RemoveEvent(Event mosqueEvent)
        {
            return dBAccess.RemoveEvent(mosqueEvent);
        }

        public Article BLL_GetArticle(int articleID)
        {
            return dBAccess.GetArticle(articleID);
        }
        //Accepted Articles for learn Islam
        public List<uspGetAcceptedArticle> BLL_GetAcceptedArticle()
        {
            return dBAccess.GetAcceptedArticle();
        }

        //Insert of Article
        public bool BLL_InsertArticle(InsertArticle article)
        {
            return dBAccess.InsertArticle(article);
        }

        public bool  BLL_AcceptArticle(AcceptArticle acceptArticle)
        {
            return dBAccess.AcceptArticle(acceptArticle);

        }
        public Notice BLL_GetNotifications(int NoticeID)
        {
            return dBAccess.GetNotifications(NoticeID);
        }

        public List<uspViewLatestArticles> BLL_ViewLatestArticles()
        {
            return dBAccess.ViewLatestArticles();
        }
    }
}
