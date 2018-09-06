using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TypeLib.Models;
using TypeLib.ViewModels;
using Muslimeen.BLL;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Drawing;

namespace Muslimeen.Content
{
    public partial class MyMuslimeen_User_ : System.Web.UI.Page
    {

        DBHandler dBHandler = new DBHandler();

        protected void Page_Load(object sender, EventArgs e)
        {
            lblTaskHead.InnerText = "Please select a task";

            divListEventDetails.Visible = false;
            divUserProfile.Visible = true;
            liMyMusbtn.Visible = true;
            liMyMusDivi.Visible = true;
            divDisplayEvents.Visible = false;
            divDisplaySalahTimetable.Visible = true;
            divDiplayNotifications.Visible = false;
            divDisplayArticles.Visible = false;
            divNotices.Visible = false;
            divDisplayArt.Visible = false;
            divEvent.Visible = false;
            divListEvent.Visible = false;
            divSchDetailsOverlay.Visible = false;
            divEventOverlay.Visible = false;

            DBHandler db = new DBHandler();
            List<CounterCalender> counterCalender = new List<CounterCalender>();

            counterCalender = db.BLL_GetCounterCalender();
            hdfAdjustDate.Value = counterCalender[3].Val.ToString();

            try
            {
                DBHandler dBHandler = new DBHandler();


                if (Session["UserName"] != null)
                {

                    uspGetMember uspGetMember = new uspGetMember();

                    uspGetMember = dBHandler.BLL_GetMember(Convert.ToString(Session["UserName"]));
                    Session["MosqueID"] = uspGetMember.MosqueID.ToString();

                    if (uspGetMember.MemberType == 'M')
                    {
                        hplUserProfile.Text = uspGetMember.MemberLastName + ", " + uspGetMember.MemberName;
                        divUserProfile.Visible = true;

                        liMyMusbtn.Visible = true;
                        liMyMusDivi.Visible = true;

                        btnLogin.Text = "Log out";
                        btnRegister.Visible = false;
                    }
                    else
                    {
                        Response.Redirect("../Content/Error.aspx");
                    }

                }
                else if (Session["UserName"] == null)
                {
                    liMyMusbtn.Visible = false;
                    liMyMusDivi.Visible = false;

                    divUserProfile.Visible = false;
                    Session.Clear();
                    Response.Redirect("../Login/Login.aspx");
                }
            }
            catch
            {

            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (btnLogin.Text == "Login")
            {
                Response.Redirect("../Login/Login.aspx");
            }
            else if (btnLogin.Text == "Log out")
            {

                Session.Clear();
                Session.Abandon();
                Response.Redirect("../Content/Default.aspx");
                btnLogin.Text = "Login";
                btnRegister.Visible = true;
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Register/Register.aspx");
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Content/Default.aspx");
        }

        protected void btnMosques_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Content/Mosque/ListMosque.aspx");
        }

        protected void btnScholars_Click(object sender, EventArgs e)
        {
            //redirect user to the scholars list page.
        }

        protected void btnLearnIslam_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Content/Learn Islam/LearnIslam.aspx");
        }

        protected void btnZakaah_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Content/ZakaahWebForms/Zakaah.aspx");
        }

        protected void btnAboutUs_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Content/AboutUs.aspx");
        }

        protected void btnHelp_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Content/HelpCenter.aspx");
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
                    Response.Redirect("../Content/MyAdmin.aspx");
                }
                else if (uspGetMember.MemberType == 'M')
                {
                    Response.Redirect("../Content/MyMember.aspx");
                }
                else if (uspGetMember.MemberType == 'O')
                {
                    Response.Redirect("../Content/MyModerator.aspx");
                }
                else if (uspGetMember.MemberType == 'S')
                {
                    Response.Redirect("../Content/MyScholar/AddArticle.aspx");
                }
            }
            catch
            {

            }
        }
        protected void btnTodaysPrayerTime_Click(object sender, EventArgs e)
        {
            divDisplaySalahTimetable.Visible = true;
            lblTaskHead.InnerText = btnTodaysPrayerTimes.Text.ToString();

            DBHandler dBHandler = new DBHandler();
            DateTime todaysDate = DateTime.Today;

            uspGetSpecificDayPrayerTimes prayertimes = new uspGetSpecificDayPrayerTimes();
            prayertimes = dBHandler.BLL_GetSpecficDayPrayerTimes(int.Parse(Session["MosqueID"].ToString()), todaysDate);

            lblFajrAzaan.Text = prayertimes.FajrA.ToString();
            lblFajrJamaat.Text = prayertimes.FajrJ.ToString();
            lblDhuhrAzaan.Text = prayertimes.DhuhrA.ToString();
            lblDhuhrJamaat.Text = prayertimes.DhuhrJ.ToString();
            lblAsrAzaan.Text = prayertimes.AsrA.ToString();
            lblAsrJamaat.Text = prayertimes.AsrJ.ToString();
            lblMagribAzaan.Text = prayertimes.MagribA.ToString();
            lblMagribJamaat.Text = prayertimes.MagribJ.ToString();
            lblEishaAzaan.Text = prayertimes.EishaA.ToString();
            lblEishaJamaat.Text = prayertimes.EishaJ.ToString();


        }

        protected void btnEvents_Click(object sender, EventArgs e)
        {
            divDisplaySalahTimetable.Visible = false;
            divSchDetailsOverlay.Visible = true;
            divDisplayEvents.Visible = true;
            divEventOverlay.Visible = true;

            lblTaskHead.InnerText = btnEvents.Text.ToString();

        }

        protected void btnListEvents_Click(object sender, EventArgs e)
        {
            lblTaskHead.InnerText = btnListEvents.Text.ToString();
            divDisplaySalahTimetable.Visible = false;
            divDisplayEvents.Visible = true;
            divEventOverlay.Visible = true;
            lblEventError.Text =String.Empty;
            lblEventError.ForeColor = Color.Empty;
            txtStartDate.BorderColor = Color.Empty;

            int cont = 0;
            if (txtStartDate.Text == null || txtStartDate.Text == "")
            {
                lblEventError.Text = "No start date was selected";
                lblEventError.ForeColor = Color.Red;
                txtStartDate.BorderColor = Color.Red;
                cont += 1;
            }
            else if (txtEndDate.Text == null || txtEndDate.Text == "")
            {
                lblEventError.Text = "No end date was selected";
                lblEventError.ForeColor = Color.Red;
                txtEndDate.BorderColor = Color.Red;
                cont += 1;
            }
            else if (Convert.ToDateTime(txtStartDate.Text.ToString()) >= Convert.ToDateTime(txtEndDate.Text.ToString()))
            {
                lblEventError.Text = "Invalid date. The start date should be less than the end date.";
                lblEventError.ForeColor = Color.Red;
                txtStartDate.BorderColor = Color.Red;
                txtEndDate.BorderColor = Color.Red;
                cont += 1;
            }
            else if (Convert.ToDateTime(txtEndDate.Text.ToString()) <= Convert.ToDateTime(txtStartDate.Text.ToString()))
            {
                lblEventError.Text = "Invalid date. The end date should be later than the start date.";
                lblEventError.ForeColor = Color.Red;
                txtStartDate.BorderColor = Color.Red;
                txtEndDate.BorderColor = Color.Red;
                cont += 1;
            }

            if (cont == 0)
            {
                RptEventList.DataSource = dBHandler.Bll_GetMosqueEventsDateRange(int.Parse(Session["MosqueID"].ToString()), Convert.ToDateTime(txtStartDate.Text.ToString()), Convert.ToDateTime(txtEndDate.Text.ToString()));
                RptEventList.DataBind();
                if (RptEventList.Items.Count > 0)
                {
                    divListEvent.Visible = true;
                    divListEventDetails.Visible = true;
                    divDisplayEvents.Visible = true;
                    divEvent.Visible = false;
                    divEventOverlay.Visible = false;
                }
                else if (RptEventList.Items.Count <= 0)
                {
                    divListEvent.Visible = false;
                    divListEventDetails.Visible = false;
                    divDisplayEvents.Visible = false;
                    divEvent.Visible = false;
                    lblEventError.Text = "No Events Found for Specified Date Range";
                    divEventOverlay.Visible = true;
                }

            }

        }



        protected void btnEventList_Click(object sender, EventArgs e)
        {
            divDisplaySalahTimetable.Visible = false;
            lblTaskHead.InnerText = btnEvents.Text.ToString();

            LinkButton btn = (LinkButton)sender;
            uspGetSpecificEvent events = new uspGetSpecificEvent();
            Session["EventID"] = btn.CommandArgument.ToString();
            events = dBHandler.BLL_GetuspGetSpecificEvent(int.Parse(btn.CommandArgument.ToString()));

            lblEventTitle.InnerText = events.EventTitle.ToString();
            lblEventDescription.InnerText = events.EventDescription.ToString();
            lblSpeaker.InnerText = events.Speaker.ToString();
            lblEventDate.InnerText = Convert.ToDateTime(events.EventDate).ToString("dd-MM-yyyy");
            lblEventStartTime.InnerText = events.EventStartTime.ToString();
            lblEventEndTime.InnerText = events.EventEndTime.ToString();

            divSchDetailsOverlay.Visible = false;
            divListEvent.Visible = true;
            divListEventDetails.Visible = true;
            divDisplayEvents.Visible = true;
            divEvent.Visible = true;
            divEventOverlay.Visible = false;


        }


        protected void btnNotifications_Click(object sender, EventArgs e)
        {
                lblTaskHead.InnerText = btnNotifications.Text.ToString();
                divDiplayNotifications.Visible = true;
                divSchDetailsOverlay.Visible = true;
                divDisplaySalahTimetable.Visible = false;

            DBHandler dBHandler = new DBHandler();

                DateTime todaysDate = DateTime.Today;
                DateTime date = DateTime.Today.AddDays(7);

                rptNotifications.DataSource = dBHandler.BLL_GetNotifications(todaysDate, date);
                rptNotifications.DataBind();

        }

        protected void btnArticles_Click(object sender, EventArgs e)
        {
                lblTaskHead.InnerText = btnArticles.Text.ToString();

                divDisplayArticles.Visible = true;
                divSchDetailsOverlay.Visible = true;
                divDisplaySalahTimetable.Visible = false;

            DBHandler dBHandler = new DBHandler();

            DateTime dateToday = DateTime.Today;
            DateTime date = dateToday.AddDays(-7);

            rptDisplayArticles.DataSource = dBHandler.BLL_ViewLatestArticles(dateToday,date);
            rptDisplayArticles.DataBind();


        }

        protected void btnShowArt_Click(object sender, EventArgs e)
        {
            lblTaskHead.InnerText = btnArticles.Text.ToString();

            divDisplayArt.Visible = true;
            divDisplaySalahTimetable.Visible = false;

            LinkButton linkButton = (LinkButton)sender;

            string articleId = linkButton.CommandArgument.ToString();
            hdfArticleID.Value = articleId;

            DBHandler dBHandler = new DBHandler();
            Article article = new Article();
            article = dBHandler.BLL_GetArticle(Convert.ToInt32(articleId));


            lblArticleTitle.InnerText = article.ArticleTitle.ToString();
            lblArticleContent.InnerText = article.ArticleContent.ToString();
            lblDate.InnerText = article.DateCreated.ToString("dd/MMM/yyyy");

        }
        protected void btnShowNotice_Click(object sender, EventArgs e)
        {
            lblTaskHead.InnerText = btnNotifications.Text.ToString();
            divDiplayNotifications.Visible = true;
            divNotices.Visible = true;
            divSchDetailsOverlay.Visible = false;
            divDisplaySalahTimetable.Visible = false;

            LinkButton linkButton = (LinkButton)sender;

            string NoticeID = linkButton.CommandArgument.ToString();
            hdnNotice.Value = NoticeID;

            DBHandler dBHandler = new DBHandler();
            Notice notice = new Notice();
            notice = dBHandler.BLL_GetNotice(Convert.ToInt32(NoticeID));

            lblNoticeTitle.InnerText = notice.NoticeTitle.ToString();
            lblNoticeDate.InnerText = notice.DateCreated.ToString();
            lblNoticeDescription.InnerText = notice.NoticeDescription.ToString();

        }

        protected void RptEventList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }
        protected void lnkBack_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect(Request.Url.ToString());
        }
    }

}