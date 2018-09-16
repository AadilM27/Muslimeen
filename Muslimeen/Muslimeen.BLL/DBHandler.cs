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
        public bool BLL_AddArticle(InsertArticle article)
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
        public List<Article> BLL_GetRemoveAcceptedArticle()
        {
            return dBAccess.GetRemoveAcceptedArticle();
        }

        public bool BLL_RejectReg(uspRejectReg uspRejectReg)
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
            return dBAccess.AddArticle(article);
        }

        public bool BLL_AcceptArticle(AcceptArticle acceptArticle)
        {
            return dBAccess.AcceptArticle(acceptArticle);

        }

        //Rejected Articles
        public List<Article> BLL_GetRejectedArticle()
        {
            return dBAccess.GetRejectedArticle();
        }

        public List<uspGetNotifications> BLL_GetNotifications(DateTime todaysDate, DateTime date)
        {
            return dBAccess.GetNotifications(todaysDate, date);
        }

        public List<uspViewLatestArticles> BLL_ViewLatestArticles(DateTime dateToday, DateTime date)
        {
            return dBAccess.ViewLatestArticles(dateToday, date);
        }

        public Notice BLL_GetNotice(int noticeID)
        {
            return dBAccess.GetNotice(noticeID);
        }
        public Event BLL_GetEventwithID(int EventID)
        {
            return dBAccess.GetEventwithID(EventID);
        }
        public List<uspGetAcceptedScholars> BLL_GetAcceptedScholars()
        {
            return dBAccess.GetAcceptedScholars();
        }
        public List<uspGetAcceptedScholars> BLL_GetRejectedScholars()
        {
            return dBAccess.GetRejectedScholars();
        }

        public uspGetSelectedPendingArticle BLL_GetSelectedPendingArticle(int articleID)
        {
            return dBAccess.GetSelectedPendingArticle(articleID);
        }

        public bool BLL_AddMosque(uspAddMosque addMosque)
        {
            return dBAccess.AddMosque(addMosque);
        }

        public List<uspGetMosqueReports> BLL_GetMosqueReports()
        {
            return dBAccess.GetMosqueReports();
        }

        public List<uspGetEventReports> BLL_GetEventReports()
        {
            return dBAccess.GetEventReports();
        }

        public uspGetMember BLL_GetMosqueRep(int mosqueID)
        {
            return dBAccess.GetMosqueRep(mosqueID);
        }

        public uspGetSelectedRejectedArticle BLL_GetSelectedRejectedArticle(int articleID)
        {
            return dBAccess.uspGetSelectedRejectedArticle(articleID);
        }

        //Learn Page Articles
        public List<Article> BLL_GetLearnArticle(string scholarID,string topic)
        {
            return dBAccess.GetLearnArticle(scholarID,topic);
        }

        public uspGetSelectedLearnArticle BLL_GetSelectedLearnArticle(int articleID)
        {
            return dBAccess.GetSelectedLearnArticle(articleID);
        }
        public bool BLL_AddModeraterQualification(Moderater moderater)
        {
            return dBAccess.AddModeraterQualification(moderater);
        }

        public bool BLL_AddZakaahOrganization(uspAddZakaahOrg organization)
        {
            return dBAccess.AddZakaahOrganization(organization);
        }

        public Organization BLL_GetSelectedZakaahOrg(int organizationID)
        {
            return dBAccess.GetSelectedZakaahOrg(organizationID);
        }

        public bool BLL_UpdateZakaahOrg(uspUpdateZakaahOrg updateZakaahOrg)
        {
            return dBAccess.UpdateZakaahOrg(updateZakaahOrg);
        }

        public bool BLL_AddNotice(Notice notice)
        {
            return dBAccess.AddNotice(notice);
        }

        public bool BLL_UpdateNotice(Notice notice)
        {
            return dBAccess.UpdateNotice(notice);
        }

        public List<Notice> BLL_GetAllNotices()
        {
            return dBAccess.GetAllNotices();
        }

        public Notice BLL_GetSelectedNotice(int notice)
        {
            return dBAccess.GetSelectedNotice(notice);
        }
        public bool BLL_RejectArticle(RejectArticle rejectArticle)
        {
            return dBAccess.RejectArticle(rejectArticle);
        }
        public bool BLL_updateRemoveArticle(RemoveArticle remove)
        {
            return dBAccess.RemoveArticle(remove);
        }
        public List<uspGetRemovedArticles> BLL_GetRemovedArticles()
        {
            return dBAccess.GetRemovedArticles();
        }

        public List<CounterCalender> BLL_GetCounterCalender()
        {
            return dBAccess.GetCounterCalender();
        }

        public bool BLL_UpdateIslamicDate(uspUpdateIslamicDate updateIslamicDate)
        {
            return dBAccess.UpdateIslamicDate(updateIslamicDate);
        }

        public bool BLL_UpdateCountDown(uspUpdateCountDown updateCountDown)
        {
            return dBAccess.UpdateCountDown(updateCountDown);
        }

        //Update Article
        public bool BLL_UpdateArticle(UpdateArticle art)
        {
            return dBAccess.UpdateArticle(art);
        }

        public bool BLL_UpdateMosque(Mosques mosque)
        {
            return dBAccess.UpdateMosque(mosque);
        }

        public List<Mosques> BLL_GetMosques()
        {
            return dBAccess.GetMosques();
        }

        public Mosques BLL_GetSpecificMosque(int mosqueID)
        {
            return dBAccess.GetSpecificMosque(mosqueID);
        }

        public List<RejectedArticlesReport> BLL_GetRejectedArticleReports()
        {
            return dBAccess.GetRejectedArticlesReport();
        }

        public List<Member> BLL_GetAllMembers()
        {
            return dBAccess.GetAllMembers();
        }

        public List<ActiveType> BLL_GetAllActiveTypes()
        {
            return dBAccess.GetAllActiveTypes();
        }

        public bool BLL_UpdateMemberActiveStatus(uspUpdateMemberActiveStatus updateMemberActiveStatus)
        {
            return dBAccess.UpdateMemberActiveStatus(updateMemberActiveStatus);
        }

        public List<uspReportGetAllMembers> BLL_ReportGetAllMembers( string reportType)
        {
            return dBAccess.ReportGetAllMembers(reportType);
        }

        public List<uspReportGetAllMosques> BLL_ReportGetAllMosques()
        {
            return dBAccess.ReportGetAllMosques();
        }

        //Adding Comment
        public bool BLL_AddComment(Comment com)
        {
            return dBAccess.InsertComment(com);
        }

        public List<uspGetComment> BLL_GetComment(int art)
        {
            return dBAccess.Comment(art);
        }
        public bool BLL_InsertRating(uspInsertRating rating)
        {
            return dBAccess.InsertRating(rating);
        }
        public uspAverageRating BLL_AverageRating(int articleID)
        {
            return dBAccess.GetAverageRating(articleID);
        }
        public uspRatingCount BLL_RatingCount(int articleID)
        {
            return dBAccess.GetRatingCount(articleID);
        }
        public int BLL_GetArticleRating(int articleID, string memberID)
        {
            return dBAccess.GetArticleRating(articleID, memberID);
        }        //Get All Scholar Learn Islam
        public List<uspGetScholarList> BLL_GetScholar()
        {
            return dBAccess.GetScholar();
        }
        //Get All Scholars
        public List<uspGetAllScholars> BLL_GetAllScholars()
        {
            return dBAccess.GetAllScholars();
        }
        public bool BLL_UpdateRating(uspUpdateRating rating)
        {
            return dBAccess.UpdateRating(rating);
        }

        //Get Mosque List
        public List<uspGetMosqueList> BLL_GetMosqueList()
        {
            return dBAccess.GetMosqueList();
        }

        //Scholar By Mosque
        public List<uspGetAllScholars> BLL_GetScholarByMosque(int MosqueID)
        {
            return dBAccess.GetScholarByMosque(MosqueID);
        }

        public bool BLL_ClearUnverifiedMembers()
        {
            return dBAccess.ClearUnverifiedMembers();
        }

        //Scholar By Qualification
        public List<uspGetAllScholars> BLL_GetScholarByQualification(string QualificationID)
        {
            return dBAccess.GetScholarByQualification(QualificationID);
        }
    }
}
