using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Muslimeen.BLL;
using TypeLib.Models;
using TypeLib.ViewModels;
using System.Drawing;

namespace Muslimeen.Content.MyScholar
{
    public partial class AddArticle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            DBHandler db = new DBHandler();
            List<CounterCalender> counterCalender = new List<CounterCalender>();

            try
            {

                divAddArticle.Visible = false;
                divPendingArticles.Visible = false;
                divRejectedArticles.Visible = false;
                divPenDetailsOverlay.Visible = false;
                divDisplayRejectedOverlay.Visible = false;
                divNoSelected.Visible = false;
                divNoRejectedSelected.Visible = false;
                divDisplayArticle.Visible = false;
                divDisplayRejected.Visible = false;
                divDisplaySalahTimetable.Visible = false;
                divDisplayEvents.Visible = false;
                divListEventDetails.Visible = false;
                divListEvent.Visible = false;
                divEvent.Visible = false;
                divEventDetails.Visible = false;
                divEventOverlay.Visible = false;

                counterCalender = db.BLL_GetCounterCalender();
                hdfAdjustDate.Value = counterCalender[3].Val.ToString();

                DBHandler dBHandler = new DBHandler();

                if (Session["UserName"] != null)
                {
                    uspGetMember uspGetMember = new uspGetMember();

                    uspGetMember = dBHandler.BLL_GetMember(Convert.ToString(Session["UserName"]));

                    if (uspGetMember.MemberType == 'S')
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
                        Response.Redirect("../Error.aspx");
                    }
                }
                else if (Session["UserName"] == null)
                {
                    liMyMusbtn.Visible = false;
                    liMyMusDivi.Visible = false;

                    divUserProfile.Visible = false;
                    Session.Clear();
                    Response.Redirect("../../Login/Login.aspx");
                }

                if (!IsPostBack)
                {
                    //Populating dropdown box wiht values
                    List<uspGetTopics> tops = dBHandler.BLL_GetTopics();
                    drpTopics.Items.Add("Select");
                    foreach (uspGetTopics qual in tops)
                    {
                        drpTopics.Items.Add(new ListItem(qual.TopicDescription.ToString(), qual.TopicID.ToString()));
                    }
                    drpTopics.DataBind();
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
                Response.Redirect("../../Login/Login.aspx");
            }
            else if (btnLogin.Text == "Log out")
            {

                Session.Clear();
                Session.Abandon();
                Response.Redirect("../MyAdmin.aspx");
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
            Response.Redirect("../Default.aspx");
        }

        protected void btnMosques_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Mosque/ListMosque.aspx");
        }

        protected void btnScholars_Click(object sender, EventArgs e)
        {
            Response.Redirect("../ListScholar.aspx");
        }

        protected void btnLearnIslam_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Learn Islam/LearnIslam.aspx");
        }

        protected void btnZakaah_Click(object sender, EventArgs e)
        {
            Response.Redirect("../ZakaahWebForms/Zakaah.aspx");
        }

        protected void btnAboutUs_Click(object sender, EventArgs e)
        {
            Response.Redirect("../AboutUs.aspx");
        }
        protected void btnHelp_Click(object sender, EventArgs e)
        {
            Response.Redirect("../HelpCenter.aspx");
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
                    Response.Redirect("../MyAdmin.aspx");
                }
                else if (uspGetMember.MemberType == 'M')
                {
                    Response.Redirect("../MyMember.aspx");
                }
                else if (uspGetMember.MemberType == 'O')
                {
                    Response.Redirect("../MyModerator.aspx");
                }
                else if (uspGetMember.MemberType == 'S')
                {
                    Response.Redirect("../MyScholar/AddArticle.aspx");
                }
                else if (uspGetMember.MemberType == 'R')
                {
                    Response.Redirect("../Mosque/MosqueRep.aspx");
                }
            }
            catch
            {

            }
        }

        protected void btnPendingArticles_Click(object sender, EventArgs e)
        {
            try
            {
                divAddArticle.Visible = false;
                divPendingArticles.Visible = true;
                divPenDetailsOverlay.Visible = true;
                divNoSelected.Visible = false;
                divRejectedArticles.Visible = false;
                divDisplayRejectedOverlay.Visible = false;
                divDisplayRejected.Visible = false;

                lblTaskHead.InnerText = btnPendingArticles.Text.ToString();

                DBHandler dBHandler = new DBHandler();

                //Pending Link Article Source
                repeatLink.DataSource = dBHandler.BLL_GetPendingArticle();
                repeatLink.DataBind();

            }
            catch
            {

            }
        }

        protected void btnRejectedArticles_Click(Object sender, EventArgs e)
        {
            try
            {
                divAddArticle.Visible = false;
                divPendingArticles.Visible = false;
                divPenDetailsOverlay.Visible = false;
                divRejectedArticles.Visible = true;
                divDisplayRejectedOverlay.Visible = true;
                divDisplayRejected.Visible = true;
                divNoSelected.Visible = false;

                lblTaskHead.InnerText = btnRejectedArticles.Text.ToString();

                DBHandler dBHandler = new DBHandler();

                //RejectedArticle Source
                repeatLinkRejected.DataSource = dBHandler.BLL_GetRejectedArticle();
                repeatLinkRejected.DataBind();
            }
            catch
            {

            }
        }

        protected void btnAddArticle_Click(object sender, EventArgs e)
        {
            divAddArticle.Visible = true;
            btnUpdate.Visible = false;
            lblTaskHead.InnerText = btnAddArticle.Text.ToString();

            txtHeading.BorderColor = Color.Empty;
            txtContent.BorderColor = Color.Empty;

            DBHandler dBHandler = new DBHandler();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            divAddArticle.Visible = true;
            txtHeading.BorderColor = Color.Empty;
            txtContent.BorderColor = Color.Empty;
            drpTopics.BorderColor = Color.Empty;

            try
            {
                DBHandler han = new DBHandler();
                InsertArticle art = new InsertArticle();

                if(drpTopics.SelectedValue.ToString() == "Select" && txtHeading.Text == null && txtContent.Text == null)
                {
                    drpTopics.BorderColor = Color.Red;
                    txtHeading.BorderColor = Color.Red;
                    txtHeading.BorderColor = Color.Red;
                }
                else if(drpTopics.SelectedValue.ToString() == "Select")
                {
                    drpTopics.BorderColor = Color.Red;
                }
                else if (txtHeading.Text == "" || txtHeading.Text == null)
                {
                    txtHeading.BorderColor = Color.Red;
                }
                else if (txtContent.Text == "" || txtContent.Text == null)
                {
                    txtHeading.BorderColor = Color.Red;
                }
                else
                {
                    art.DateCreated = Convert.ToDateTime(DateTime.Today);
                    art.Status = Convert.ToChar("P");
                    art.Active = Convert.ToChar("T");

                    //Scholar ID input with session...
                    art.ScholarID = Convert.ToString(Session["UserName"]);
                    //art.ScholarID = Convert.ToString(" ");
                    art.TopicID = Convert.ToInt32(drpTopics.SelectedValue);
                    art.ArticleTitle = Convert.ToString(txtHeading.Text);
                    art.ArticleContent = Convert.ToString(txtContent.Text);

                    han.BLL_InsertArticle(art);
                    divAddArticle.Visible = true;
                    txtHeading.Text = string.Empty;
                    txtContent.Text = string.Empty;

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Successfully Added Article');</script>");
                    Response.Redirect("../MyScholar/AddArticle.aspx", true);
                }
            }
            catch
            {
                
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {

            try
            {
                LinkButton linkButton = (LinkButton)sender;

                string art = linkButton.CommandArgument.ToString();
                hdfSchId.Value = art;

                DBHandler han = new DBHandler();
                uspGetSelectedPendingArticle pen = new uspGetSelectedPendingArticle();

                pen = han.BLL_GetSelectedPendingArticle(int.Parse(art));
                lblTitle.InnerText = pen.ArticleTitle.ToString();
                lblContent.InnerText = pen.ArticleContent.ToString();
                lblDate.InnerText = pen.DateCreated.ToString();

                divPenDetailsOverlay.Visible = false;
                divPendingArticles.Visible = true;
                divDisplayArticle.Visible = true;
                divNoSelected.Visible = true;
            }
            catch
            {

            }
        }

        protected void btnShowRejected_Click1(object sender, EventArgs e)
        {
            try
            {
                LinkButton linkButton = (LinkButton)sender;

                string art = linkButton.CommandArgument.ToString();
                hfdRej.Value = art;

                DBHandler han = new DBHandler();
                uspGetSelectedRejectedArticle pen = new uspGetSelectedRejectedArticle();

                pen = han.BLL_GetSelectedRejectedArticle(int.Parse(art));
                lblRTitle.InnerText = pen.ArticleTitle.ToString();
                lblRContent.InnerText = pen.ArticleContent.ToString();
                lblRDate.InnerText = pen.DateCreated.ToString();
                lblReason.InnerText = pen.RejectionReason.ToString();
                
                divRejectedArticles.Visible = true;
                divDisplayRejected.Visible = true;
                divNoRejectedSelected.Visible = true;
                divAddArticle.Visible = false;
            }
            catch
            {
                throw;
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            btnSave.Visible = false;
            btnUpdate.Visible = true;
            divAddArticle.Visible = true;
            lblTaskHead.InnerText = "Edit Article";

            DBHandler db = new DBHandler();

            drpTopics.SelectedValue = db.BLL_GetSelectedRejectedArticle(Convert.ToInt32(hfdRej.Value)).TopicID.ToString();
            txtContent.Text = lblRContent.InnerText;
            txtHeading.Text = lblRTitle.InnerText;


        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {            
            UpdateArticle art = new UpdateArticle();
            DBHandler han = new DBHandler();

            art.ArticleTitle = Convert.ToString(txtHeading.Text);
            art.ArticleContent = Convert.ToString(txtContent.Text);
            art.ArticleTopic = Convert.ToInt32(drpTopics.SelectedValue.ToString());
            art.ArticleID = Convert.ToInt32(hfdRej.Value);
            art.Status = Convert.ToChar("P");
            art.Active = Convert.ToChar("T");
            art.ScholarID = Convert.ToString(Session["UserName"]);

            han.BLL_UpdateArticle(art);

            txtHeading.Text = string.Empty;
            txtContent.Text = string.Empty;

            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Successfully Updated Article');</script>");
        }

        protected void btnMosqueEvents_Click(object sender, EventArgs e)
        {
            divDisplaySalahTimetable.Visible = false;
            divDisplayEvents.Visible = true;
            divEventOverlay.Visible = true;

            lblTaskHead.InnerText = btnMosqueEvents.Text.ToString();
        }

        protected void btnTodaysPrayerTime_Click(object sender, EventArgs e)
        {
            try
            {
                divDisplaySalahTimetable.Visible = true;
                lblTaskHead.InnerText = btnTodaysPrayerTime.Text.ToString();

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
            catch
            {

            }
        }

        protected void btnListEvents_Click(object sender, EventArgs e)
        {
            lblTaskHead.InnerText = btnListEvents.Text.ToString();
            divDisplaySalahTimetable.Visible = false;
            divDisplayEvents.Visible = true;
            divEventOverlay.Visible = true;
            lblEventError.Text = String.Empty;
            lblEventError.ForeColor = Color.Empty;
            txtStartDate.BorderColor = Color.Empty;

            DBHandler db = new DBHandler();

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
                RptEventList.DataSource = db.Bll_GetMosqueEventsDateRange(int.Parse(Session["MosqueID"].ToString()), Convert.ToDateTime(txtStartDate.Text.ToString()), Convert.ToDateTime(txtEndDate.Text.ToString()));
                RptEventList.DataBind();
                DateTime startDate = Convert.ToDateTime(txtStartDate.Text.ToString());
                DateTime EndDate = Convert.ToDateTime(txtEndDate.Text.ToString());
                if (startDate.Date <= EndDate.Date)
                {

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
                        divDisplayEvents.Visible = true;
                        divEvent.Visible = false;
                        lblEventError.Text = "No Events Found for Specified Date Range";
                        divEventOverlay.Visible = true;
                    }
                }
                else if (startDate.Date > EndDate.Date)
                {
                    divListEvent.Visible = false;
                    divListEventDetails.Visible = false;
                    divDisplayEvents.Visible = true;
                    divEvent.Visible = false;
                    lblEventError.Text = "Invalid Date Range";
                    divEventOverlay.Visible = true;
                }
            }
        }

        protected void btnEventList_Click(object sender, EventArgs e)
        {
            divEvent.Visible = true;
            divDisplaySalahTimetable.Visible = false;
            lblTaskHead.InnerText = btnMosqueEvents.Text.ToString();

            LinkButton btn = (LinkButton)sender;
            uspGetSpecificEvent events = new uspGetSpecificEvent();
            DBHandler db = new DBHandler();
            Session["EventID"] = btn.CommandArgument.ToString();
            events = db.BLL_GetuspGetSpecificEvent(int.Parse(btn.CommandArgument.ToString()));

            lblEventTitle.InnerText = events.EventTitle.ToString();
            lblEventDescription.InnerText = events.EventDescription.ToString();
            lblSpeaker.InnerText = events.Speaker.ToString();
            lblEventDate.InnerText = Convert.ToDateTime(events.EventDate).ToString("dd-MM-yyyy");
            lblEventStartTime.InnerText = events.EventStartTime.ToString();
            lblEventEndTime.InnerText = events.EventEndTime.ToString();

            divListEvent.Visible = true;
            divListEventDetails.Visible = true;
            divDisplayEvents.Visible = true;
            divEvent.Visible = true;
            divEventOverlay.Visible = false;
            divEventDetails.Visible = true;
        }
    }
}