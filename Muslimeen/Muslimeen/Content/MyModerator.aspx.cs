using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TypeLib.Models;
using TypeLib.ViewModels;
using Muslimeen.BLL;
using System.Data;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using AjaxControlToolkit;



namespace Muslimeen.Content.MyModerator
{
    public partial class MyModerator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            DBHandler db = new DBHandler();
            List<CounterCalender> counterCalender = new List<CounterCalender>();

            counterCalender = db.BLL_GetCounterCalender();
            hdfAdjustDate.Value = counterCalender[3].Val.ToString();

            try
            {
               
                DBHandler dBHandler = new DBHandler();

                //AjaxControlToolkit.Rating rating = (AjaxControlToolkit.Rating)sender;

                //if (rating != null)
                //{
                //    divViewPendingArt.Visible = true;
                //    divViewArt.Visible = true;
                //}
                //else if(rating == null)
                //{
                //    divViewPendingArt.Visible = false;
                //    divViewArt.Visible = false;
                //}
                divArticleOverlay.Visible = false;
                divViewPendingArt.Visible =false;
                divViewArt.Visible = false;
                divViewPendingSch.Visible = false;
                divDisplaySch.Visible = false;
                divDisplayReports.Visible = false;
                divSchDetails.Visible = false;
                divSchDetailsOverlay.Visible = false;               
                divViewRemoveAcceptedArticle.Visible = false;
                divDisplayRemoveAcceptedArticles.Visible = false;
                divListEvent.Visible = false;
                divEventOverlay.Visible = false;
                divDisplayEvents.Visible = false;
                divEvent.Visible = false;
                divListEventDetails.Visible = false;
                divDisplaySalahTimetable.Visible = false;
                divAlertPopup.Visible = false;
                


                if (Session["UserName"] != null)
                {
                    uspGetMember uspGetMember = new uspGetMember();
                    uspGetMember = dBHandler.BLL_GetMember(Convert.ToString(Session["UserName"]));
                    Session["MosqueID"] = uspGetMember.MosqueID.ToString();

                    if (uspGetMember.MemberType == 'O')
                    {
                        hplUserProfile.Text = uspGetMember.MemberLastName + ", " + uspGetMember.MemberName;
                        divUserProfile.Visible = true;

                        liMyMusbtn.Visible = true;
                        liMyMusDivi.Visible = true;

                        btnLogin.Text = "Log out";
                        btnRegister.Visible = false;

                        if(!IsPostBack)
                        {
                            btnTodaysPrayerTime_Click(sender, e);
                        }
                    }
                    else
                    {
                        Response.Redirect("Error.aspx");
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
               

                divDisplaySch.Visible = false;
               
            }
            catch
            {

            }
        }

        protected void btnViewPendingArticles_Click(object sender, EventArgs e)
        {
            try
            {
                LblHeading.Text = "Articles";
                divDisplaySch.Visible = false;
                divViewPendingSch.Visible = false;
                
               

                divViewPendingArt.Visible = true;
                divArticleOverlay.Visible = true;
                divViewArt.Visible = false;
                DBHandler dBHandler = new DBHandler();

                rptViewPendingArticles.DataSource = dBHandler.BLL_GetPendingArticle();
                rptViewPendingArticles.DataBind();

               
            }
            catch
            {

            }
        }

        protected void btnViewPendingMod_Click(object sender, EventArgs e)
        {
            try
            {
                divViewPendingArt.Visible = false;
                divDisplaySch.Visible = true;
                divViewPendingSch.Visible = true;

                DBHandler dBHandler = new DBHandler();

                rptViewPendingSch.DataSource = dBHandler.BLL_GetAllPendingModeraters();
                rptViewPendingSch.DataBind();
            }
            catch
            {

            }
        }

        protected void btnViewPendingSch_Click(object sender, EventArgs e)
        {
            LblHeading.Text = "Scholars";
            divViewPendingArt.Visible = false;
           
            divDisplaySch.Visible = false;
            divViewPendingSch.Visible = true;
            divSchDetailsOverlay.Visible = true;

            DBHandler dBHandler = new DBHandler();

            rptViewPendingSch.DataSource = dBHandler.BLL_GetAllPendingScholars();
            rptViewPendingSch.DataBind();

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
                Response.Redirect("MyModerator.aspx");
                btnLogin.Text = "Login";
                btnRegister.Visible = true;
            }
        }

        protected void btnUpdateIslmDate_Click(object sender, EventArgs e)
        {
           
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

                if (uspGetMember.MemberType == 'O')
                {
                    Response.Redirect("MyModerator.aspx");
                }
                else if (uspGetMember.MemberType == 'A')
                {
                    Response.Redirect("MyAdmin.aspx");
                }
                else if (uspGetMember.MemberType == 'M')
                {
                    Response.Redirect("MyMember.aspx");
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

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton linkButton = (LinkButton)sender;

                string memberId = linkButton.CommandArgument.ToString();
                hdfSchId.Value = memberId;

                DBHandler dBHandler = new DBHandler();
                uspGetScholarDetails scholarDetails = new uspGetScholarDetails();

                scholarDetails = dBHandler.BLL_GetScholarDetails(memberId);
                lblMemberID.InnerText = scholarDetails.ScholarID.ToString();
                lblMemberName.InnerText = scholarDetails.MemberName.ToString();
                lblMemberLastName.InnerText = scholarDetails.MemberLastName.ToString();
                lblMemberDOB.InnerText = scholarDetails.MemberDOB.ToString();
                lblMemberType.InnerText = scholarDetails.MemberType.ToString();
                lblEmail.InnerText = scholarDetails.Email.ToString();
                lblContactNo.InnerText = scholarDetails.ContactNo.ToString();
                lblActivationExpiry.InnerText = scholarDetails.ActivationExpiry.ToString();
                lblActivationDate.InnerText = scholarDetails.ActivationDate.ToString();
                lblScholarQual.InnerText = scholarDetails.QualificationDescription.ToString();

                divViewPendingSch.Visible = true;
                divViewArt.Visible = false;
                divDisplaySch.Visible = true;
                divSchDetails.Visible = true;
            }
            catch
            {

            }

        }

        protected void btnAcceptReg_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdfSchId.Value != null)
                {
                    DBHandler db = new DBHandler();
                    uspVerifyMember uspVerifyMember = new uspVerifyMember();

                    string memberId = hdfSchId.Value.ToString();

                    uspVerifyMember.MemberID = memberId;
                    db.BLL_VerifyMember(uspVerifyMember);

                    EmailService emailService = new EmailService();
                    uspGetMember uspGetMember = new uspGetMember();

                    uspGetMember = db.BLL_GetMember(memberId.ToString());


                    emailService.AutoEmailService(uspGetMember.Email.ToString(), "NULL", "NULL", "AcceptedScholars", memberId.ToString(), "NULL");
                    divDisplaySch.Visible = false;
                    divSchDetailsOverlay.Visible = true;
                    divViewPendingSch.Visible = true;
                    rptViewPendingSch.DataSource = db.BLL_GetAllPendingScholars();
                    rptViewPendingSch.DataBind();

                }
            }
            catch
            {

            }
        }

        protected void btnRejectReg_Click(object sender, EventArgs e)
        {
            try
            {
                DBHandler db = new DBHandler();
                uspVerifyMember uspVerifyMember = new uspVerifyMember();
                uspRejectReg rejectReg = new uspRejectReg();
              
                string memberID2 = hdfSchId.Value.ToString();

                rejectReg.MemberID = memberID2;

                db.BLL_RejectReg(rejectReg);

                EmailService emailService = new EmailService();
                uspGetMember uspGetMember = new uspGetMember();

                uspGetMember = db.BLL_GetMember(memberID2.ToString());


                emailService.AutoEmailService(uspGetMember.Email.ToString(), "NULL", "NULL", "RejectedScholars", memberID2.ToString(), "NULL");
                rptViewPendingSch.DataSource = db.BLL_GetAllPendingScholars();
                rptViewPendingSch.DataBind();
            }
            catch
            {

            }
        }

        protected void btnShowArt_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton linkButton = (LinkButton)sender;

                string articleId = linkButton.CommandArgument.ToString();
                hdfSchId.Value = articleId;

                DBHandler dBHandler = new DBHandler();
                uspGetSelectedPendingArticle article = new uspGetSelectedPendingArticle();
                article = dBHandler.BLL_GetSelectedPendingArticle(Convert.ToInt32(articleId));


                lblTitle.InnerText = article.ArticleTitle.ToString();
                lblContent.InnerText = article.ArticleContent.ToString();
                lblDate.InnerText = Convert.ToDateTime(article.DateCreated).ToString();
                lblScholar.InnerText = article.ScholarName.ToString();

            
                divViewPendingArt.Visible = true;
                divDisplaySch.Visible = false;
                divViewArt.Visible = true;
            }
            catch
            {

            }
        }

        protected void txtRejectReason_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (Session["UserName"] != null)
                {
                    divAlertPopup.Visible = true;
                    DBHandler dBHandler = new DBHandler();
                    Moderater m = new Moderater();
                    AcceptArticle accept = new AcceptArticle();

                    string articleId = hdfSchId.Value.ToString();

                    accept.ArticleID = Convert.ToInt32(articleId);
                    accept.ModeratorID =Session["UserName"].ToString();
                    accept.Status = 'A';
                    accept.Active = 'Y';
                   
                    if (dBHandler.BLL_AcceptArticle(accept))
                    {
                        lblAlertError.InnerText = "Article Approved";

                        this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyModerator", "var divpop = document.getElementById('divAlertPopup');divpop.style.display='block';" +
                            ";setTimeout(function Flash3() {divpop.style.display = 'none';}, 4000)", true);
                    }

                    divViewArt.Visible = false;
                    divViewPendingArt.Visible = true;
                    rptViewPendingArticles.DataSource = dBHandler.BLL_GetPendingArticle();
                    rptViewPendingArticles.DataBind();

                }
            }
            catch
            {
               
            }
        }

        protected void Button2_Click(object sender, EventArgs e)//btnRejectArticles
        {
            try
            {
                divAlertPopup.Visible = true;
                if (txtRejectReason.Text.ToString() == "" || txtRejectReason == null)
                {
                    lblRejection.Text = "Cannot reject an article without a reason!";
                    txtRejectReason.BorderColor = System.Drawing.Color.Red;
                    divViewArt.Visible = true;
                }
                else
                {
                   
                    DBHandler dBHandler = new DBHandler();
                    RejectArticle reject = new RejectArticle();

                    string articleId = hdfSchId.Value.ToString();

                    reject.ArticleID = Convert.ToInt32(articleId);
                    reject.Status = 'R';
                    reject.RejectionReason = txtRejectReason.Text.ToString();
                    reject.Active = 'N';
                    reject.ModeratorID = Session["UserName"].ToString();

                    if(dBHandler.BLL_RejectArticle(reject))
                    {
                        lblAlertError.InnerText = "Article Rejected.";

                        this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyModerator", "var divpop = document.getElementById('divAlertPopup');divpop.style.display='block';" +
                            ";setTimeout(function Flash3() {divpop.style.display = 'none';}, 4000)", true);

                        divViewArt.Visible = false;
                    }
                   
                    lblRejection.Text = "";
                    txtRejectReason.Text = "";
                    txtRejectReason.BorderColor = System.Drawing.Color.Empty;
                    rptViewPendingArticles.DataSource = dBHandler.BLL_GetPendingArticle();
                    rptViewPendingArticles.DataBind();


                }

              
                divViewPendingArt.Visible = true;
            }
            catch
            {

            }
        }

        protected void rptViewPendingSch_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void BtnAcceptedScholars_Click(object sender, EventArgs e)
        {
            Session["btnType"] = "AcceptedScholars";
            try
            {
                reportHeading.InnerText = "Accepted Scholars Report";
                divDisplayReports.Visible = true;
                
                DBHandler handler = new DBHandler();
                uspGetAcceptedScholars acc = new uspGetAcceptedScholars();
                
                grdReports.DataSource = handler.BLL_GetAcceptedScholars();
                grdReports.DataBind();

               
            }
            catch(Exception)
            {
               
            }
           
        }

        protected void btnRejectedScholars_Click(object sender, EventArgs e)
        {
            Session["btnType"] = "RejectedScholars";
            try
            {
                reportHeading.InnerText = "Rejected Scholars Report";
                divDisplayReports.Visible = true;
                
                DBHandler handler = new DBHandler();
                uspGetAcceptedScholars acc = new uspGetAcceptedScholars();

                grdReports.DataSource = handler.BLL_GetRejectedScholars();                
                grdReports.DataBind();
               
                
            }
            catch (Exception)
            {
                

            }
        }
        protected void BtnAcceptedArticles_Click(object sender,EventArgs e)
        {
            Session["btnType"] = "AcceptedArticle";
            try
            {
                reportHeading.InnerText = "Accepted Articles Report";
                divDisplayReports.Visible = true;
                
                DBHandler han = new DBHandler();
               

                grdReports.DataSource = han.BLL_GetAcceptedArticle();
                grdReports.DataBind();
            }
            catch(Exception)
            {

            }
        }
        protected void BtnRejectedArticles_Click(object sender, EventArgs e)
        {
            Session["btnType"] = "RejectedArticle";
            try
            {
                reportHeading.InnerText = "Rejected Articles Report";
                divDisplayReports.Visible = true;
                
                DBHandler han = new DBHandler();
                

                grdReports.DataSource = han.BLL_GetRejectedArticleReports();
                grdReports.DataBind();
            }
            catch (Exception)
            {

            }
        }
        protected void BtnMosqueReports_Click(object sender, EventArgs e)
        {
            Session["btnType"] = "MosqueReports";
            try
            {
                reportHeading.InnerText = "Available Mosque Report";
                divDisplayReports.Visible = true;
                
                DBHandler han = new DBHandler();
                uspGetMosqueReports mr = new uspGetMosqueReports();

                grdReports.DataSource = han.BLL_GetMosqueReports();
                grdReports.DataBind();
                
            }
            catch (Exception)
            {
               
            }
        }
        protected void BtnEventReports_Click(object sender, EventArgs e)
        {
            Session["btnType"] = "EventsReports";
            try
            {
                reportHeading.InnerText = "Available Events Report";
                divDisplayReports.Visible = true;
              
                DBHandler han = new DBHandler();
                uspGetEventReports mr = new uspGetEventReports();

                grdReports.DataSource = han.BLL_GetEventReports();
                grdReports.DataBind();
            }
            catch (Exception)
            {

            }
        }
        protected void BtnAllRemovedArticles_Click(object sender,EventArgs e)
        {
            Session["btnType"] = "RemovedArticles";
            try
            {
                reportHeading.InnerText = "Removed Articles Report";
                divDisplayReports.Visible = true;

                DBHandler han = new DBHandler();
                uspGetRemovedArticles mr = new uspGetRemovedArticles();

                grdReports.DataSource = han.BLL_GetRemovedArticles();
                grdReports.DataBind();
            }
            catch (Exception)
            {

            }
        }

        protected void BtnPDF_Click(object sender, EventArgs e)
        {
           
        }

        protected void PDF_ServerClick(object sender, EventArgs e)
        {
            try
            {
                if (Session["btnType"].ToString() == "AcceptedScholars")
                {
                    grdReports.HeaderRow.Cells[0].Text = "FirstName";
                    grdReports.HeaderRow.Cells[1].Text = "LastName";
                    grdReports.HeaderRow.Cells[2].Text = "Date Of Birth";
                    grdReports.HeaderRow.Cells[3].Text = "Active";
                    grdReports.HeaderRow.Cells[4].Text = "Email Address";
                    grdReports.HeaderRow.Cells[5].Text = "Contact Number";

                    for (int i = 0; i < grdReports.Rows.Count; i++)
                    {
                        DateTime DOB = Convert.ToDateTime(grdReports.Rows[i].Cells[2].Text);
                        grdReports.Rows[i].Cells[2].Text = DOB.ToString("dd MMM yyyy");

                        string active = grdReports.Rows[i].Cells[3].Text;
                        grdReports.Rows[i].Cells[3].Text = active.Replace("N", "No").Replace("Y", "Yes").Replace("T", "Temporary");

                    }
                }
                else if (Session["btnType"].ToString() == "RejectedScholars")
                {
                    grdReports.HeaderRow.Cells[0].Text = "FirstName";
                    grdReports.HeaderRow.Cells[1].Text = "LastName";
                    grdReports.HeaderRow.Cells[2].Text = "Date Of Birth";
                    grdReports.HeaderRow.Cells[3].Text = "Active";
                    grdReports.HeaderRow.Cells[4].Text = "Email Address";
                    grdReports.HeaderRow.Cells[5].Text = "Contact Number";

                    for (int i = 0; i < grdReports.Rows.Count; i++)
                    {
                        DateTime DOB = Convert.ToDateTime(grdReports.Rows[i].Cells[2].Text);
                        grdReports.Rows[i].Cells[2].Text = DOB.ToString("dd MMM yyyy");

                        string active = grdReports.Rows[i].Cells[3].Text;
                        grdReports.Rows[i].Cells[3].Text = active.Replace("N", "No").Replace("Y", "Yes").Replace("T", "Temporary");

                    }
                }
                else if (Session["btnType"].ToString() == "AcceptedArticle")
                {
                    grdReports.HeaderRow.Cells[0].Text = "Title";
                    grdReports.HeaderRow.Cells[1].Text = "Content";
                    grdReports.HeaderRow.Cells[2].Text = "Date Created";
                    grdReports.HeaderRow.Cells[3].Text = "Scholar";
                    grdReports.HeaderRow.Cells[4].Text = "Moderator";

                    for (int i = 0; i < grdReports.Rows.Count; i++)
                    {
                     
                        DateTime regDate = Convert.ToDateTime(grdReports.Rows[i].Cells[2].Text);
                        grdReports.Rows[i].Cells[2].Text = regDate.ToString("dd MMM yyyy");
                    }
                }
                else if (Session["btnType"].ToString() == "RejectedArticle")
                {
                    grdReports.HeaderRow.Cells[0].Text = "Title";
                    grdReports.HeaderRow.Cells[1].Text = "Content";
                    grdReports.HeaderRow.Cells[2].Text = "Date Created";
                    grdReports.HeaderRow.Cells[3].Text = "Rejection Reason";
                    grdReports.HeaderRow.Cells[4].Text = "Scholar";
                    grdReports.HeaderRow.Cells[5].Text = "Moderator";

                    for (int i = 0; i < grdReports.Rows.Count; i++)
                    {

                        DateTime regDate = Convert.ToDateTime(grdReports.Rows[i].Cells[2].Text);
                        grdReports.Rows[i].Cells[2].Text = regDate.ToString("dd MMM yyyy");
                    }

                }
                else if (Session["btnType"].ToString() == "RemovedArticles")
                {
                    grdReports.HeaderRow.Cells[0].Text = "Title";
                    grdReports.HeaderRow.Cells[1].Text = "Content";
                    grdReports.HeaderRow.Cells[2].Text = "Date Created";
                    grdReports.HeaderRow.Cells[3].Text = "Removal Reason";
                    grdReports.HeaderRow.Cells[4].Text = "Scholar";
                    grdReports.HeaderRow.Cells[5].Text = "Moderator";

                    for (int i = 0; i < grdReports.Rows.Count; i++)
                    {

                        DateTime regDate = Convert.ToDateTime(grdReports.Rows[i].Cells[2].Text);
                        grdReports.Rows[i].Cells[2].Text = regDate.ToString("dd MMM yyyy");
                    }

                }
                else if (Session["btnType"].ToString() == "MosqueReports")
                {
                    grdReports.HeaderRow.Cells[0].Text = "Mosque Name";
                    grdReports.HeaderRow.Cells[1].Text = "Street";
                    grdReports.HeaderRow.Cells[2].Text = "Suburb";
                    grdReports.HeaderRow.Cells[3].Text = "Mosque Type";
                    grdReports.HeaderRow.Cells[4].Text = "Mosque Size";

                }
                else if (Session["btnType"].ToString() == "EventsReports")
                {
                    grdReports.HeaderRow.Cells[0].Text = "Event Title";
                    grdReports.HeaderRow.Cells[1].Text = "Start Time";
                    grdReports.HeaderRow.Cells[2].Text = "End Time";
                    grdReports.HeaderRow.Cells[3].Text = "Speaker";
                    grdReports.HeaderRow.Cells[4].Text = "Event Description";
                    grdReports.HeaderRow.Cells[5].Text = "Date";

                    for (int i = 0; i < grdReports.Rows.Count; i++)
                    {
                      

                        DateTime regDate = Convert.ToDateTime(grdReports.Rows[i].Cells[5].Text);
                        grdReports.Rows[i].Cells[5].Text = regDate.ToString("dd MMM yyyy");
                    }
                }
                grdReports.HeaderRow.Font.Size = 16;
                DBHandler han = new DBHandler();
                PdfPTable pdfTable = new PdfPTable(grdReports.HeaderRow.Cells.Count);
                pdfTable.HorizontalAlignment = 0;

               
                foreach (TableCell Headercell in grdReports.HeaderRow.Cells)
                {
                    Font font = new Font(Font.FontFamily.HELVETICA, 11,Font.BOLD);
                    font.Color = new BaseColor(grdReports.HeaderStyle.ForeColor);

                    PdfPCell pdfCell = new PdfPCell(new Phrase(Headercell.Text, font));
                    pdfCell.HorizontalAlignment = 1;
                    pdfCell.Padding = 5;
                    pdfCell.BackgroundColor = new BaseColor(grdReports.HeaderStyle.BackColor);
                    pdfTable.AddCell(pdfCell);

                }

                foreach (GridViewRow gridviewrow in grdReports.Rows)
                {
                    foreach (TableCell tablecell in gridviewrow.Cells)
                    {
                        iTextSharp.text.Font font = new iTextSharp.text.Font();
                        font.Color = new BaseColor(grdReports.RowStyle.ForeColor);
                        iTextSharp.text.Font content = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.BOLD);
                        PdfPCell pdfcell = new PdfPCell(new Phrase(tablecell.Text, content));
                        pdfcell.HorizontalAlignment = 1;
                        pdfcell.VerticalAlignment = 2;
                        pdfcell.BackgroundColor = new BaseColor(grdReports.RowStyle.BackColor);
                        pdfTable.AddCell(pdfcell);
                    }
                }

                Document pdfDocument = new Document(new RectangleReadOnly(842, 595), 10f, -200f, 10f, 0f);
                PdfAWriter.GetInstance(pdfDocument, Response.OutputStream);

                pdfTable.DefaultCell.Padding = 5;
                pdfTable.DefaultCell.VerticalAlignment = PdfPCell.ALIGN_CENTER;
                PdfPTable table = new PdfPTable(1);
                PdfPTable table2 = new PdfPTable(2);

                Font fontH2 = new Font(Font.FontFamily.HELVETICA, 12,Font.BOLD);
                table2.WidthPercentage = 80;
                table2.HorizontalAlignment = 0;
                table2.DefaultCell.Padding = 8;
                table2.DefaultCell.HorizontalAlignment = 1;
                table2.DefaultCell.VerticalAlignment = 1;
                Paragraph date = new Paragraph("Date Created: " + DateTime.Now.Date.ToString("dd MMM yyyy"), fontH2);
                Paragraph extraPara = new Paragraph("Muslimeen Moderator Reports", fontH2);
                table2.AddCell(date);
                table2.AddCell(extraPara);

                if (Session["btnType"].ToString() == "AcceptedScholars" || Session["btnType"].ToString() == "RejectedScholars" || Session["btnType"].ToString() == "AcceptedArticle" || Session["btnType"].ToString() == "RejectedArticle" || Session["btnType"].ToString() == "MosqueReports" || Session["btnType"].ToString() == "EventsReports" || Session["btnType"].ToString() == "RemovedArticles")
                {
                    Font fontH1 = new Font(Font.FontFamily.HELVETICA, 24, Font.BOLD);
                    table.WidthPercentage = 80;
                    table.HorizontalAlignment = 0;
                    table.DefaultCell.Padding = 20;
                    table.DefaultCell.HorizontalAlignment = 1;
                    table.DefaultCell.VerticalAlignment = 1;

                    if (Session["btnType"].ToString() == "AcceptedScholars")
                    {
                        Paragraph para = new Paragraph("Report of All Accepted Scholars", fontH1);
                        table.AddCell(para);
                    }
                    else if (Session["btnType"].ToString() == "RejectedScholars")
                    {
                        Paragraph para = new Paragraph("Report of All Rejected Scholars", fontH1);
                        table.AddCell(para);
                    }
                    else if (Session["btnType"].ToString() == "AcceptedArticle")
                    {
                        Paragraph para = new Paragraph("Report of All Accepted Articles", fontH1);
                        table.AddCell(para);
                    }
                    else if (Session["btnType"].ToString() == "RejectedArticle")
                    {
                        Paragraph para = new Paragraph("Report of All Rejected Articles", fontH1);
                        table.AddCell(para);
                    }
                    else if (Session["btnType"].ToString() == "MosqueReports")
                    {
                        Paragraph para = new Paragraph("Report of All Mosques", fontH1);
                        table.AddCell(para);
                    }
                    else if (Session["btnType"].ToString() == "EventsReports")
                    {
                        Paragraph para = new Paragraph("Report of All Events", fontH1);
                        table.AddCell(para);
                    }
                    else if (Session["btnType"].ToString() == "RemovedArticles")
                    {
                        Paragraph para = new Paragraph("Report of All Articles Removed", fontH1);
                        table.AddCell(para);
                    }



                }

                pdfDocument.Open();
                pdfDocument.Add(table);
                pdfDocument.Add(table2);
                pdfDocument.Add(pdfTable);
                pdfDocument.Close();

                Response.ContentType = "application/pdf";
                Response.AppendHeader("content-disposition", "attachment;filename=MuslimeenReports.pdf");
                Response.Write(pdfDocument);
                Response.Flush();
                Response.End();
            }
            catch(NullReferenceException)
            {
                throw;
            }
        }

        protected void BtnSalaahTimeTable_Click(object sender, EventArgs e)
        {
          
        }

        protected void btnRate_Click(object sender, EventArgs e)
        {
          

        }
        protected void Rating1_Click(object sender,RatingEventArgs e)
        {
           



        }

        protected void BtnRemoveArticles_Click(object sender, EventArgs e)
        {
            try
            {
                LblHeading.Text = "Accepted Articles";
                divDisplaySch.Visible = false;
                divViewPendingSch.Visible = false;
                divViewPendingArt.Visible = false;
                divViewArt.Visible = false;



                divViewRemoveAcceptedArticle.Visible = true;
                divArticleOverlay.Visible = true;
                divDisplayRemoveAcceptedArticles.Visible = false;
                DBHandler dBHandler = new DBHandler();

                rptRemoveAcceptedArticles.DataSource = dBHandler.BLL_GetRemoveAcceptedArticle();
                rptRemoveAcceptedArticles.DataBind();


            }
            catch
            {

            }
        }
        protected void btnShowRemoveAcceptArt_Click(object sender,EventArgs e)
        {
            try
            {
                LinkButton linkButton = (LinkButton)sender;

                string articleId = linkButton.CommandArgument.ToString();
                hdfSchId.Value = articleId;

                DBHandler dBHandler = new DBHandler();
                uspGetSelectedPendingArticle article = new uspGetSelectedPendingArticle();
                article = dBHandler.BLL_GetSelectedPendingArticle(Convert.ToInt32(articleId));


                lblRemoveAcceptTitle.InnerText = article.ArticleTitle.ToString();
                lblRemoveAcceptContent.InnerText = article.ArticleContent.ToString();
                lblRemoveDate.InnerText = Convert.ToDateTime(article.DateCreated).ToString();
                lblRemoveAcceptScholar.InnerText = article.ScholarName.ToString();


                divViewRemoveAcceptedArticle.Visible = true;
                divDisplaySch.Visible = false;
                divDisplayRemoveAcceptedArticles.Visible = true;
            }
            catch
            {

            }

        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void BtnRemoveAcceptedArticle_Click(object sender, EventArgs e)
        {
            try
            {
                divAlertPopup.Visible = true;
                if ( txtRemovalReason.Text.ToString() == "" || txtRemovalReason == null)
                {
                    lblRemovalDisplay.Text = "Cannot remove an article without a reason!";
                    txtRemovalReason.BorderColor = System.Drawing.Color.Red;
                    divDisplayRemoveAcceptedArticles.Visible = true;
                }
                else
                {

                    DBHandler dBHandler = new DBHandler();
                    RemoveArticle remove = new RemoveArticle();

                    string articleId = hdfSchId.Value.ToString();

                    remove.ArticleID = Convert.ToInt32(articleId);
                    remove.Status = 'N';
                    remove.RemovalReason = txtRemovalReason.Text.ToString();
                    remove.Active = 'N';
                    remove.ModeratorID = Session["UserName"].ToString();

                    if (dBHandler.BLL_updateRemoveArticle(remove))//if the article was updated successfully the page will display a success message to keep the user on track
                    {
                        lblAlertError.InnerText = "Successfully removed this article.";

                        this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyModerator", "var divpop = document.getElementById('divAlertPopup');divpop.style.display='block';" +
                            ";setTimeout(function Flash3() {divpop.style.display = 'none';}, 4000)", true);
                        divDisplayRemoveAcceptedArticles.Visible = false;
                    }
                    else
                    {

                    }
                    lblRemovalDisplay.Text = "";
                        txtRemovalReason.Text = "";
                        txtRemovalReason.BorderColor = System.Drawing.Color.Empty;

                    rptRemoveAcceptedArticles.DataSource = dBHandler.BLL_GetRemoveAcceptedArticle();
                    rptRemoveAcceptedArticles.DataBind();

                }

               
                divViewRemoveAcceptedArticle.Visible = true;
            }
            catch(NullReferenceException)
            {

            }
        }

        protected void txtRemovalReason_TextChanged(object sender, EventArgs e)
        {

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
                divAlertPopup.Visible = true;
                lblAlertError.InnerText = "Unable to display todays prayer times, please make sure you are assigned to a mosque";

                this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyAdmin", "var divpop = document.getElementById('divAlertPopup');divpop.classList.remove('alert-success');divpop.classList.add('alert-danger');divpop.style.display = 'block';" +
                      ";setTimeout(function Flash3() {divpop.style.display = 'none';}, 4000)", true);
            }
        }

        protected void btnEventList_Click(object sender,EventArgs e)
        {
            try
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
            }
            catch(NullReferenceException)
            { 
}
        }

        protected void btnListEvents_Click(object sender,EventArgs e)
        {

            try
            {
                lblTaskHead.InnerText = btnListEvents.Text.ToString();
                divDisplaySalahTimetable.Visible = false;
                divDisplayEvents.Visible = true;
                divEventOverlay.Visible = true;
                lblEventError.Text = String.Empty;
                lblEventError.ForeColor = System.Drawing.Color.Empty;
                txtStartDate.BorderColor = System.Drawing.Color.Empty;

                DBHandler db = new DBHandler();

                int cont = 0;
                if (txtStartDate.Text == null || txtStartDate.Text == "")
                {
                    lblEventError.Text = "No start date was selected";
                    lblEventError.ForeColor = System.Drawing.Color.Red;
                    txtStartDate.BorderColor = System.Drawing.Color.Red;
                    cont += 1;
                }
                else if (txtEndDate.Text == null || txtEndDate.Text == "")
                {
                    lblEventError.Text = "No end date was selected";
                    lblEventError.ForeColor = System.Drawing.Color.Red;
                    txtEndDate.BorderColor = System.Drawing.Color.Red;
                    cont += 1;
                }
                else if (Convert.ToDateTime(txtStartDate.Text.ToString()) >= Convert.ToDateTime(txtEndDate.Text.ToString()))
                {
                    lblEventError.Text = "Invalid date. The start date should be less than the end date.";
                    lblEventError.ForeColor = System.Drawing.Color.Red;
                    txtStartDate.BorderColor = System.Drawing.Color.Red;
                    txtEndDate.BorderColor = System.Drawing.Color.Red;
                    cont += 1;
                }
                else if (Convert.ToDateTime(txtEndDate.Text.ToString()) <= Convert.ToDateTime(txtStartDate.Text.ToString()))
                {
                    lblEventError.Text = "Invalid date. The end date should be later than the start date.";
                    lblEventError.ForeColor = System.Drawing.Color.Red;
                    txtStartDate.BorderColor = System.Drawing.Color.Red;
                    txtEndDate.BorderColor = System.Drawing.Color.Red;
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
            catch { }
        
        }
    }
}