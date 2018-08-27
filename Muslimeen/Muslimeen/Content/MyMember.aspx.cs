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


namespace Muslimeen.Content
{
    public partial class MyMuslimeen_User_ : System.Web.UI.Page
    {
        
        DBHandler dBHandler = new DBHandler();

        protected void Page_Load(object sender, EventArgs e)
        {
            lblTaskHead.InnerText = "Please select a task";

            divListEventDetails.Visible = false;
            divUserProfile.Visible = false;
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
                    hplUserProfile.Text = uspGetMember.MemberLastName + ", " + uspGetMember.MemberName;

                    btnLogin.Text = "Log out";
                    btnRegister.Visible = false;

                }
                else if (Session["UserName"] == null)
                {
                    divUserProfile.Visible = false;
                    Session.Clear();
                }
                try
                {  

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

        protected void PDF_ServerClick(object sender, EventArgs e)
        {
            try
            {
                PdfPTable pdfTable = new PdfPTable(grdSalaah.HeaderRow.Cells.Count);
                pdfTable.HorizontalAlignment = 0;
                foreach (TableCell Headercell in grdSalaah.HeaderRow.Cells)
                {
                    grdSalaah.HeaderRow.Cells[0].Text = "Date";
                    grdSalaah.HeaderRow.Cells[1].Text = "Day";
                    grdSalaah.HeaderRow.Cells[2].Text = "Fajr Adhaan";
                    grdSalaah.HeaderRow.Cells[3].Text = "Fajr Jamaat";
                    grdSalaah.HeaderRow.Cells[4].Text = "Dhuhr Adhaan";
                    grdSalaah.HeaderRow.Cells[5].Text = "Dhuhr Jamaat ";
                    grdSalaah.HeaderRow.Cells[6].Text = "Asr Adhaan";
                    grdSalaah.HeaderRow.Cells[7].Text = "Asr Jamaat ";
                    grdSalaah.HeaderRow.Cells[8].Text = "Magrib Adhaan";
                    grdSalaah.HeaderRow.Cells[9].Text = "Magrib Jamaat ";
                    grdSalaah.HeaderRow.Cells[10].Text = "Eisha Adhaan";
                    grdSalaah.HeaderRow.Cells[11].Text = "Eisha Jamaat";
                    Font font = new Font();
                    font.Color = new BaseColor(grdSalaah.HeaderStyle.ForeColor);
                    PdfPCell pdfCell = new PdfPCell(new Phrase(Headercell.Text, font));
                    pdfCell.BackgroundColor = new BaseColor(grdSalaah.HeaderStyle.BackColor);
                    pdfTable.AddCell(pdfCell); 
                }

                foreach (GridViewRow gridviewrow in grdSalaah.Rows)
                {
                    foreach (TableCell tablecell in gridviewrow.Cells)
                    {
                        Font font = new Font();
                        font.Color = new BaseColor(grdSalaah.RowStyle.ForeColor);

                        PdfPCell pdfcell = new PdfPCell(new Phrase(tablecell.Text));
                        pdfcell.BackgroundColor = new BaseColor(grdSalaah.RowStyle.BackColor);
                        pdfTable.AddCell(pdfcell);
                    }
                }

                Document pdfDocument = new Document(new RectangleReadOnly(842, 595), 10f, -200f, 10f, 0f);
                // Document pdfDocument = new Document(new RectangleReadOnly(842, 595), widthstart, cell width, heightstart);
                PdfAWriter.GetInstance(pdfDocument, Response.OutputStream);

                pdfDocument.Open();
                pdfDocument.Add(pdfTable);
                pdfDocument.Close();

                Response.ContentType = "application/pdf";
                Response.AppendHeader("content-disposition", "attachment;filename=PrayerTimeTable.pdf");
                Response.Write(pdfDocument);
                Response.Flush();
                Response.End();
            }
            catch { }
        }
        protected void btnEvents_Click(object sender, EventArgs e)
        {
            divDisplaySalahTimetable.Visible = false;
            divSchDetailsOverlay.Visible = true;
            divListEvent.Visible = true;
            divListEventDetails.Visible = true;
            divDisplayEvents.Visible = false;
            divEvent.Visible = false;

            lblTaskHead.InnerText = btnEvents.Text.ToString();

        }

        protected void btnListEvents_Click(object sender, EventArgs e)
        {
            divDisplaySalahTimetable.Visible = false;
            lblTaskHead.InnerText = btnListEvents.Text.ToString();

            DateTime startDate = Convert.ToDateTime(txtStartDate.Text.ToString());
            DateTime EndDate = Convert.ToDateTime(txtEndDate.Text.ToString());

            //if (startDate!=null)
            //{
            //    if (EndDate!=null)
            //    {
            //        btnListEvents.Visible = true;
            //    }

            //}

            divSchDetailsOverlay.Visible = false;

            divListEvent.Visible = true;
            divListEventDetails.Visible = true;
            divDisplayEvents.Visible = true;
            divEvent.Visible = true;

            RptEventList.DataSource = dBHandler.Bll_GetMosqueEventsDateRange(int.Parse(Session["MosqueID"].ToString()), startDate, EndDate);
            RptEventList.DataBind();
           
           
           
        }

        protected void btnEventList_Click(object sender, EventArgs e)
        {
            divDisplaySalahTimetable.Visible = false;
            lblTaskHead.InnerText = btnEvents.Text.ToString();

            LinkButton linkButton = (LinkButton)sender;

            string EventID = linkButton.CommandArgument.ToString();
            hdfEvent.Value = EventID;

            DBHandler dBHandler = new DBHandler();

            Event ev = new Event();
            ev = dBHandler.BLL_GetEventwithID(Convert.ToInt32(EventID));
                lblEventTitle.InnerText = ev.EventTitle.ToString();
                lblEventDescription.InnerText = ev.EventDescription.ToString();
                lblSpeaker.InnerText = ev.Speaker.ToString();
                lblEventDate.InnerText = Convert.ToDateTime(ev.EventDate).ToString("dd-MM-yyyy");
                lblEventStartTime.InnerText = ev.EventStartTime.ToString();
                lblEventEndTime.InnerText = ev.EventEndTime.ToString();

                divSchDetailsOverlay.Visible = false;
                divListEvent.Visible = true;
                divListEventDetails.Visible = true;
                divDisplayEvents.Visible = true;
                divEvent.Visible = true;


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
                DateTime date = DateTime.Now.AddDays(-7);

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
    }

}