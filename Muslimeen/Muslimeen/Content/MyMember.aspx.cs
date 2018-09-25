using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TypeLib.Models;
using TypeLib.ViewModels;
using Muslimeen.BLL;
using System.IO;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Drawing;
using AjaxControlToolkit;

namespace Muslimeen.Content
{
    public partial class MyMuslimeen_User_ : System.Web.UI.Page
    {

        DBHandler dBHandler = new DBHandler();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {


                lblTaskHead.InnerText = "Please select a task";

                divListEventDetails.Visible = false;
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
                divSchDetailsOverlay.Visible = false;
                divEventOverlay.Visible = false;
                divimageError.Visible = false;

                DBHandler dBHandler = new DBHandler();

                List<CounterCalender> counterCalender = new List<CounterCalender>();

                counterCalender = dBHandler.BLL_GetCounterCalender();
                hdfAdjustDate.Value = counterCalender[3].Val.ToString();
            
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
                        Response.Redirect("../Error.aspx");
                    }

                    DateTime todaysDate = DateTime.Today;
                    if (!IsPostBack)
                    {
                        btnTodaysPrayerTime_Click(sender, e);
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
                Response.Redirect("Default.aspx");
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
            Response.Redirect("Default.aspx");
        }

        protected void btnMosques_Click(object sender, EventArgs e)
        {
            Response.Redirect("Mosque/ListMosque.aspx");
        }

        protected void btnScholars_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListScholar.aspx");
        }

        protected void btnLearnIslam_Click(object sender, EventArgs e)
        {
            Response.Redirect("Learn Islam/LearnIslam.aspx");
        }

        protected void btnZakaah_Click(object sender, EventArgs e)
        {
            Response.Redirect("ZakaahWebForms/Zakaah.aspx");
        }

        protected void btnAboutUs_Click(object sender, EventArgs e)
        {
            Response.Redirect("AboutUs.aspx");
        }

        protected void btnHelp_Click(object sender, EventArgs e)
        {
            Response.Redirect("HelpCenter.aspx");
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
                    Response.Redirect("MyAdmin.aspx");
                }
                else if (uspGetMember.MemberType == 'M')
                {
                    Response.Redirect("MyMember.aspx");
                }
                else if (uspGetMember.MemberType == 'O')
                {
                    Response.Redirect("MyModerator.aspx");
                }
                else if (uspGetMember.MemberType == 'S')
                {
                    Response.Redirect("MyScholar/AddArticle.aspx");
                }
                else if (uspGetMember.MemberType == 'R')
                {
                    Response.Redirect("Mosque/MosqueRep.aspx");
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

            catch
            {
                divAlertPopup.Visible = true;

                lblAlertError.InnerText = "No salaah times have been entered for today.";

                this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyAdmin", "var divpop = document.getElementById('divAlertPopup');divpop.classList.remove('alert-success');divpop.classList.add('alert-danger');divpop.style.display = 'block';" +
                ";setTimeout(function Flash3() {divpop.style.display = 'none';}, 4000)", true);
            }

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
            try
            {
                lblTaskHead.InnerText = btnListEvents.Text.ToString();
                divDisplaySalahTimetable.Visible = false;
                divDisplayEvents.Visible = true;
                divEventOverlay.Visible = true;
                lblEventError.Text = String.Empty;
                lblEventError.ForeColor = Color.Empty;
                txtStartDate.BorderColor = Color.Empty;
                txtEndDate.BorderColor = Color.Empty;

                DateTime startDate = Convert.ToDateTime(txtStartDate.Text.ToString());
                DateTime EndDate = Convert.ToDateTime(txtEndDate.Text.ToString());

                if (startDate.Date <= EndDate.Date)
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
                        divDisplayEvents.Visible = true;
                        divEvent.Visible = false;
                        divimageError.Visible = true;
                        lblEventError.Text = "No Events Found for Specified Date Range";
                        divEventOverlay.Visible = true;
                    }
                }

                else if (startDate.Date > EndDate.Date)
                {
                    divimageError.Visible = true;
                    lblEventError.Text = "Invalid date. The start date should be less than the end date.";
                    lblEventError.ForeColor = Color.Red;
                    txtStartDate.BorderColor = Color.Red;
                    txtEndDate.BorderColor = Color.Red;
                }
            }
            catch
            {
                divimageError.Visible = true;
                lblEventError.Text = "Please enter required date fields.";
                lblEventError.ForeColor = Color.Red;
                txtStartDate.BorderColor = Color.Red;
                txtEndDate.BorderColor = Color.Red;
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
            try
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

                CommentRepeater.DataSource = dBHandler.BLL_GetComment(int.Parse(articleId));
                CommentRepeater.DataBind();

                Rating1.CurrentRating = dBHandler.BLL_GetArticleRating(int.Parse(articleId), Session["UserName"].ToString());

                string commentCount = CommentRepeater.Items.Count.ToString();
                lblCommentCount.Text = "Comments: " + commentCount;
            }
            catch (NullReferenceException)
            { }


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
            btnArticles_Click(sender, e);
        }
        protected void lnkAdminPrintPDF_ServerClick(object sender, EventArgs e)
        {
            try
            {
                DBHandler han = new DBHandler();
                //Title and Content will be in this table.
                PdfPTable pdfTop = new PdfPTable(1);
                //Date will be in this table.
                PdfPTable pdfBottom = new PdfPTable(2);

                pdfTop.HorizontalAlignment = 0;
                pdfBottom.HorizontalAlignment = 0;
                iTextSharp.text.Font fontH3 = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 18, iTextSharp.text.Font.BOLD);

                iTextSharp.text.Font font = new iTextSharp.text.Font();
                font.Color = new BaseColor(grdAdminReports.RowStyle.ForeColor);
                iTextSharp.text.Font content = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.BOLD);

                PdfPCell pdfTitle = new PdfPCell(new Phrase(lblArticleTitle.InnerText, fontH3));
                PdfPCell pdfContent = new PdfPCell(new Phrase(lblArticleContent.InnerText, content));

                PdfPCell pdfDate = new PdfPCell(new Phrase("Date: " + lblDate.InnerText, content));

                pdfTitle.HorizontalAlignment = 1;
                pdfTitle.VerticalAlignment = 2;
                pdfTitle.Padding = 10;
                pdfContent.Padding = 10;
                pdfDate.Padding = 10;
                pdfTitle.BackgroundColor = new BaseColor(grdAdminReports.RowStyle.BackColor);
                pdfTop.AddCell(pdfTitle);
                pdfTop.AddCell(pdfContent);

              
                pdfBottom.AddCell(pdfDate);

                Document pdfDocument = new Document(new RectangleReadOnly(842, 595), 10f, -200f, 10f, 0f);
                PdfAWriter.GetInstance(pdfDocument, Response.OutputStream);

                pdfTop.DefaultCell.Padding = 5;
                pdfTop.DefaultCell.VerticalAlignment = PdfPCell.ALIGN_CENTER;
                PdfPTable table = new PdfPTable(1);
                PdfPTable table2 = new PdfPTable(2);

                iTextSharp.text.Font fontH2 = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.BOLD);
                table2.WidthPercentage = 80;
                table2.HorizontalAlignment = 0;
                table2.DefaultCell.Padding = 8;
                table2.DefaultCell.HorizontalAlignment = 1;
                table2.DefaultCell.VerticalAlignment = 1;
                Paragraph date = new Paragraph("Date Printed: " + DateTime.Now.Date.ToString("dd MMM yyyy"), fontH2);
                Paragraph extraPara = new Paragraph("Muslimeen Article", fontH2);
                table2.AddCell(date);
                table2.AddCell(extraPara);


                iTextSharp.text.Font fontH1 = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 24, iTextSharp.text.Font.BOLD);
                table.WidthPercentage = 80;
                table.HorizontalAlignment = 0;
                table.DefaultCell.Padding = 20;
                table.DefaultCell.HorizontalAlignment = 1;
                table.DefaultCell.VerticalAlignment = 1;

                Paragraph para = new Paragraph("Muslimeen Article", fontH1);
                table.AddCell(para);


                pdfDocument.Open();
                pdfDocument.AddTitle("Muslimeen Article");
                pdfDocument.Add(table);
                pdfDocument.Add(table2);
                pdfDocument.Add(pdfTop);
                pdfDocument.Add(pdfBottom);
                pdfDocument.Close();

                Response.ContentType = "application/pdf";
                Response.AppendHeader("content-disposition", "attachment;filename=" + lblArticleTitle.InnerText + ".pdf");
                Response.Write(pdfDocument);
                Response.Flush();
                Response.End();

            }
            catch (NullReferenceException)
            {

            }
        }
        protected void Rating1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserName"] != null)
                {
                    DBHandler handler = new DBHandler();

                    uspInsertRating rating = new uspInsertRating();

                    int articleId = Convert.ToInt32(hdfArticleID.Value.ToString());//gets article id  from repeater when clicked on and saves n into hidden field

                    Rating1.MaxRating = 5;

                    if (handler.BLL_GetArticleRating(articleId, Session["UserName"].ToString()) == 0 || handler.BLL_GetArticleRating(articleId, Session["UserName"].ToString()).ToString() == null)//when user hasnt rated an article in goes into method to execute an insert to allow that user to rate an article.
                    {
                        rating.MemberID = Session["UserName"].ToString();
                        rating.articleID = Convert.ToInt32(articleId);
                        rating.rating = Rating1.CurrentRating;

                        handler.BLL_InsertRating(rating);
                        Response.Redirect(Request.Url.AbsoluteUri);
                    }
                    else if (handler.BLL_GetArticleRating(articleId, Session["UserName"].ToString()) > 0 && handler.BLL_GetArticleRating(articleId, Session["UserName"].ToString()) <= Rating1.MaxRating)
                    {
                        uspUpdateRating upRate = new uspUpdateRating();
                        upRate.ArticleID = Convert.ToInt32(hdfArticleID.Value.ToString());
                        upRate.MemberID = Session["UserName"].ToString();
                        upRate.rating = Rating1.CurrentRating;

                        handler.BLL_UpdateRating(upRate);
                        Response.Redirect(Request.Url.AbsoluteUri);
                    }



                }
                divDisplayArt.Visible = true;
                divRating.Visible = true;

            }
            catch
            {

            }

        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserName"] != null)
                {
                    btnArticles_Click(sender, e);

                    DBHandler han = new DBHandler();
                    Comment com = new Comment();

                    com.CommentMessage = Convert.ToString(txtComment.Text);
                    com.CommentDate = DateTime.Now;
                    com.ArticleID = Convert.ToInt32(hdfArticleID.Value);
                    com.MemberID = Convert.ToString(Session["UserName"]);
                    com.CommentID = null;

                    han.BLL_AddComment(com);

                    txtComment.Text = string.Empty;

                    lblAlertError.InnerText = "Comment successfully added";

                    this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyAdmin", "var divpop = document.getElementById('divAlertPopup');divpop.classList.remove('alert-danger');divpop.classList.add('alert-success');divpop.style.display = 'block';" +
                ";setTimeout(function Flash3() {divpop.style.display = 'none';}, 4000)", true);

                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Scripts", "<script>alert('Please login to add comment.');</script>");
                }
            }
            catch
            {

            }
        }
    }

}