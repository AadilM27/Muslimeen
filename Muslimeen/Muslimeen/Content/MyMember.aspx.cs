using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TypeLib.Models;
using TypeLib.ViewModels;
using Muslimeen.BLL;

namespace Muslimeen.Content
{
    public partial class MyMuslimeen_User_ : System.Web.UI.Page
    {
        
        DBHandler dBHandler = new DBHandler();
        protected void Page_Load(object sender, EventArgs e)
        {


           
            
            try
            {
                DBHandler dBHandler = new DBHandler();
               

                if (Session["UserName"] != null)
                {
                    uspGetMember uspGetMember = new uspGetMember();

                    uspGetMember = dBHandler.BLL_GetMember(Convert.ToString(Session["UserName"]));
                    Session["MosqueID"] = uspGetMember.MosqueID.ToString();
                    hplUserProfile.Text = uspGetMember.MemberLastName + ", " + uspGetMember.MemberName;
                    divUserProfile.Visible = true;

                    liMyMusbtn.Visible = true;
                    liMyMusDivi.Visible = true;
                    divDisplayEvents.Visible = false;
                    divDisplaySalahTimetable.Visible = false;
                    divDiplayNotifications.Visible = false;
                    divDisplayArticles.Visible = false;
                    divNotices.Visible = false;
                    divDisplayArt.Visible = false;
                    divEvent.Visible = false;
                    divListEvent.Visible = false;

                    btnLogin.Text = "Log out";
                    btnRegister.Visible = false;

                }
                else if (Session["UserName"] == null)
                {
                    liMyMusbtn.Visible = false;
                    liMyMusDivi.Visible = false;
                    divDisplayEvents.Visible = false;
                    divDisplaySalahTimetable.Visible = false;
                    divDisplayArticles.Visible = false;
                    divDiplayNotifications.Visible = false;
                    divNotices.Visible = false;
                    divDisplayArt.Visible = false;
                    divEvent.Visible = false;
                    divListEvent.Visible = false;

                    divUserProfile.Visible = false;
                    Session.Clear();
                }
                try
                {   //######### IDK what you using this for but this is causing a conflict with the other repeater.############## <<<<<<<<<<<<<<< READ
                    //RptEventList.DataSource = dBHandler.Bll_GetMosqueEvents(int.Parse(Session["MosqueID"].ToString()));
                    //RptEventList.DataBind();
                    //DateTime date = DateTime.Today;
                    //uspGetSpecificDayPrayerTimes time = new uspGetSpecificDayPrayerTimes();
                    //time = dBHandler.BLL_GetSpecficDayPrayerTimes(int.Parse(Session["MosqueID"].ToString()), date);
                    //lblFajrAzaan.Text = time.FajrA.ToString();
                    //lblFajrJamaat.Text = time.FajrJ.ToString();
                    //lblDhuhrAzaan.Text = time.DhuhrA.ToString();
                    //lblDhuhrJamaat.Text = time.DhuhrJ.ToString();
                    //lblAsrAzaan.Text = time.AsrA.ToString();
                    //lblAsrJamaat.Text = time.AsrJ.ToString();
                    //lblMagribAzaan.Text = time.MagribA.ToString();
                    //lblMagribJamaat.Text = time.MagribJ.ToString();
                    //lblEishaAzaan.Text = time.EishaA.ToString();
                    //lblEishaJamaat.Text = time.EishaJ.ToString();
                }
                catch { }
            }
            catch
            {

            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (btnLogin.Text == "Login")
            {
                Response.Redirect("~/Login/Login.aspx");
            }
            else if (btnLogin.Text == "Log out")
            {

                Session.Clear();
                Session.Abandon();
                Response.Redirect("~/Content/Default.aspx");
                btnLogin.Text = "Login";
                btnRegister.Visible = true;
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Register/Register.aspx");
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Content/Default.aspx");
        }

        protected void btnMosques_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Content/Mosque/ListMosque.aspx");
        }

        protected void btnScholars_Click(object sender, EventArgs e)
        {
            //redirect user to the scholars list page.
        }

        protected void btnLearnIslam_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Content/Learn Islam/LearnIslam.aspx");
        }

        protected void btnZakaah_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Content/ZakaahWebForms/Zakaah.aspx");
        }

        protected void btnAboutUs_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Content/AboutUs.aspx");
        }

        protected void btnMyMuslimeen_Click(object sender, EventArgs e)
        {
            try
            {
                DBHandler dBHandler = new DBHandler();

                uspGetMember uspGetMember = new uspGetMember();

                uspGetMember = dBHandler.BLL_GetMember(Convert.ToString(Session["UserName"]));

                if (uspGetMember.MemberType == 'A')
                {
                    Response.Redirect("~/Content/MyAdmin.aspx");
                }
                else if (uspGetMember.MemberType == 'M')
                {
                    Response.Redirect("~/Content/MyMember.aspx");
                }
                else if (uspGetMember.MemberType == 'O')
                {
                    Response.Redirect("~/Content/MyModerator.aspx");
                }
                else if (uspGetMember.MemberType == 'S')
                {
                    Response.Redirect("~/Content/MyScholar/AddArticle.aspx");
                }
            }
            catch
            {

            }
        }
        protected void btnTodaysPrayerTime_Click(object sender, EventArgs e)
        {
            try
            {
                divDisplayEvents.Visible = false;
                divDisplaySalahTimetable.Visible = true;
                divDiplayNotifications.Visible = false;
                divDisplayArticles.Visible = false;
                divDisplayArt.Visible = false;
                divEvent.Visible = false;
                divListEvent.Visible = false;
            }
            catch
            {

            }
        }
        protected void btnEvents_Click(object sender, EventArgs e)
        {
            try
            {
                divDisplayEvents.Visible = true;
                divDisplaySalahTimetable.Visible = false;
                divDiplayNotifications.Visible = false;
                divDisplayArticles.Visible = false;
                divDisplayArt.Visible = false;
                divEvent.Visible = false;
                divListEvent.Visible = false;


            }
            catch
            { }
        }

        protected void btnListEvents_Click(object sender, EventArgs e)
        {// button on selecting date

                divEvent.Visible = true;
                divListEvent.Visible = true;
                DateTime startDate = Convert.ToDateTime(txtStartDate.Text.ToString());
                DateTime EndDate = Convert.ToDateTime(txtEndDate.Text.ToString());
                RptEventList.DataSource = dBHandler.Bll_GetMosqueEventsDateRange(int.Parse(Session["MosqueID"].ToString()), startDate, EndDate);
                RptEventList.DataBind();
           
        }

        protected void btnEventList_Click(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;

            string EventID = linkButton.CommandArgument.ToString();
            hdfEvent.Value = EventID;

            DBHandler dBHandler = new DBHandler();

            Event ev = new Event();
            ev = dBHandler.BLL_GetEventwithID(Convert.ToInt32(EventID));

            try
            {
                lblEventDescription.InnerText = ev.EventDescription.ToString();
                lblSpeaker.InnerText = ev.Speaker.ToString();
                lblEventDate.InnerText = ev.EventDate.ToString();
                lblEventStarTime.InnerText = ev.EventStartTime.ToString();
                lblEventEndTime.InnerText = ev.EventEndTime.ToString();
                divEvent.Visible = true;
                divListEvent.Visible = true;

            }
            catch
            {
                throw;
            }
        }

        protected void btnNotifications_Click(object sender, EventArgs e)
        {

                divDisplayEvents.Visible = false;
                divDisplaySalahTimetable.Visible = false;
                divDiplayNotifications.Visible = true;
                divDisplayArticles.Visible = false;
                divNotices.Visible = true;
                divDisplayArt.Visible = false;
                divEvent.Visible = false;
                divListEvent.Visible = false;

                DBHandler dBHandler = new DBHandler();

                DateTime todaysDate = DateTime.Today;
                DateTime date = DateTime.Today.AddDays(7);

                rptNotifications.DataSource = dBHandler.BLL_GetNotifications(todaysDate, date);
                rptNotifications.DataBind();

        }

        protected void btnArticles_Click(object sender, EventArgs e)
        {

                divDisplayEvents.Visible = false;
                divDisplaySalahTimetable.Visible = false;
                divDiplayNotifications.Visible = false;
                divDisplayArticles.Visible = true;
                divDisplayArt.Visible = true;
                divEvent.Visible = false;
                divListEvent.Visible = false;


                DBHandler dBHandler = new DBHandler();

                DateTime dateToday = DateTime.Today;
                DateTime date = DateTime.Today.AddDays(-7);

                rptDisplayArticles.DataSource = dBHandler.BLL_ViewLatestArticles(dateToday,date);
                rptDisplayArticles.DataBind();


        }

        protected void btnShowArt_Click(object sender, EventArgs e)
        {
            divDisplayArt.Visible = true;

            LinkButton linkButton = (LinkButton)sender;

            string articleId = linkButton.CommandArgument.ToString();
            hdfArticleID.Value = articleId;

            DBHandler dBHandler = new DBHandler();
            Article article = new Article();
            article = dBHandler.BLL_GetArticle(Convert.ToInt32(articleId));


            lblArticleTitle.InnerText = article.ArticleTitle.ToString();
            lblArticleContent.InnerText = article.ArticleContent.ToString();

        }
        protected void btnShowNotice_Click(object sender, EventArgs e)
        {
            divDiplayNotifications.Visible = true;
            divNotices.Visible = true;

            LinkButton linkButton = (LinkButton)sender;

            string NoticeID = linkButton.CommandArgument.ToString();
            hdnNotice.Value = NoticeID;

            DBHandler dBHandler = new DBHandler();
            Notice notice = new Notice();
            notice = dBHandler.BLL_GetNotice(Convert.ToInt32(NoticeID));

            lblNoticeTitle.InnerText = notice.NoticeTitle.ToString();
            lblNoticeDate.InnerText = notice.NoticeDate.ToString();
            lblNoticeDescription.InnerText = notice.NoticeDescription.ToString();

        }

        protected void RptEventList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }
    }

}