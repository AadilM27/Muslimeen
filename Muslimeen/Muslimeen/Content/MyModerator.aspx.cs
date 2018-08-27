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



namespace Muslimeen.Content.MyModerator
{
    public partial class MyModerator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            try
            {
                DBHandler dBHandler = new DBHandler();
               
                divViewPendingArt.Visible = false;
                divViewPendingSch.Visible = false;
                divDisplaySch.Visible = false;
                divViewArt.Visible = false;
                divDisplayReports.Visible = false;
                divSchDetails.Visible = false;
                divSchDetailsOverlay.Visible = false;
                

                if (Session["UserName"] != null)
                {
                    uspGetMember uspGetMember = new uspGetMember();
                    uspGetMember = dBHandler.BLL_GetMember(Convert.ToString(Session["UserName"]));

                    if (uspGetMember.MemberType == 'O')
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
                        Response.Redirect("~/Content/Error.aspx");
                    }
                }
                else if (Session["UserName"] == null)
                {
                    liMyMusbtn.Visible = false;
                    liMyMusDivi.Visible = false;

                    divUserProfile.Visible = false;
                    Session.Clear();
                    Response.Redirect("~/Login/Login.aspx");
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
                divViewArt.Visible = true;
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
                Response.Redirect("~/Login/Login.aspx");
            }
            else if (btnLogin.Text == "Log out")
            {

                Session.Clear();
                Session.Abandon();
                Response.Redirect("~/Content/MyModerator.aspx");
                btnLogin.Text = "Login";
                btnRegister.Visible = true;
            }
        }

        protected void btnUpdateIslmDate_Click(object sender, EventArgs e)
        {
           
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

                if (uspGetMember.MemberType == 'O')
                {
                    Response.Redirect("~/Content/MyModerator.aspx");
                }
                else if (uspGetMember.MemberType == 'A')
                {
                    Response.Redirect("~/Content/MyAdmin.aspx");
                }
                else if (uspGetMember.MemberType == 'M')
                {
                    Response.Redirect("~/Content/MyMember.aspx");
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


                lblArticleTitle.InnerText = article.ArticleTitle.ToString();
                lblArticleContent.InnerText = article.ArticleContent.ToString();

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
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Article Accepted!')", true);
                    }

                    divViewArt.Visible = true;
                    divViewPendingArt.Visible = true;
                }
            }
            catch
            {
                throw;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)//btnRejectArticles
        {
            try
            {
               
                if (txtRejectReason.Text.ToString() == "" || txtRejectReason == null)
                {
                    lblRejection.Text = "Cannot reject an article without a reason!";
                    txtRejectReason.BorderColor = System.Drawing.Color.Red;

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

                    dBHandler.BLL_RejectArticle(reject);                
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Article Rejected!')", true);
                    lblRejection.Text = "";
                    txtRejectReason.Text = "";
                    txtRejectReason.BorderColor = System.Drawing.Color.Empty;

                }
                
                divViewArt.Visible = true;
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

        protected void BtnPDF_Click(object sender, EventArgs e)
        {
           
        }

        protected void PDF_ServerClick(object sender, EventArgs e)
        {
            try
            {


                DBHandler han = new DBHandler();
                PdfPTable pdfTable = new PdfPTable(grdReports.HeaderRow.Cells.Count);
                pdfTable.HorizontalAlignment = 0;
                foreach (TableCell Headercell in grdReports.HeaderRow.Cells)
                {
                    
                    if(Session["btnType"].ToString() == "AcceptedScholars")
                    {
                        grdReports.HeaderRow.Cells[0].Text = "FirstName";
                        grdReports.HeaderRow.Cells[1].Text = "LastName";
                        grdReports.HeaderRow.Cells[2].Text = "Date Of Birth";
                        grdReports.HeaderRow.Cells[3].Text = "Active";
                        grdReports.HeaderRow.Cells[4].Text = "Email Address";
                        grdReports.HeaderRow.Cells[5].Text = "Contact Number";
                    }
                     else if(Session["btnType"].ToString() == "RejectedScholars")
                    {
                        grdReports.HeaderRow.Cells[0].Text = "FirstName";
                        grdReports.HeaderRow.Cells[1].Text = "LastName";
                        grdReports.HeaderRow.Cells[2].Text = "Date Of Birth";
                        grdReports.HeaderRow.Cells[3].Text = "Active";
                        grdReports.HeaderRow.Cells[4].Text = "Email Address";
                        grdReports.HeaderRow.Cells[5].Text = "Contact Number";
                    }
                    else if (Session["btnType"].ToString() == "AcceptedArticle")
                    {
                        grdReports.HeaderRow.Cells[0].Text = "Title";
                        grdReports.HeaderRow.Cells[1].Text = "Content";
                        grdReports.HeaderRow.Cells[2].Text = "Date Created";
                        grdReports.HeaderRow.Cells[3].Text = "Scholar";
                        grdReports.HeaderRow.Cells[4].Text = "Moderator";

                    }
                    else if (Session["btnType"].ToString() == "RejectedArticle")
                    {
                        grdReports.HeaderRow.Cells[0].Text = "Title";
                        grdReports.HeaderRow.Cells[1].Text = "Content";
                        grdReports.HeaderRow.Cells[2].Text = "Date Created";
                        grdReports.HeaderRow.Cells[3].Text = "Rejection Reason";
                        grdReports.HeaderRow.Cells[4].Text = "Scholar";
                        grdReports.HeaderRow.Cells[5].Text = "Moderator";

                    }
                    else if(Session["btnType"].ToString() == "MosqueReports")
                    {
                        grdReports.HeaderRow.Cells[0].Text = "Mosque Name";
                        grdReports.HeaderRow.Cells[1].Text = "Street";
                        grdReports.HeaderRow.Cells[2].Text = "Suburb";
                        grdReports.HeaderRow.Cells[3].Text = "Mosque Type";
                        grdReports.HeaderRow.Cells[4].Text = "Mosque Size";
                        

                    }
                    else if(Session["btnType"].ToString() == "EventsReports")
                    {
                        grdReports.HeaderRow.Cells[0].Text = "Event Title";
                        grdReports.HeaderRow.Cells[1].Text = "Start Time";
                        grdReports.HeaderRow.Cells[2].Text = "End Time";
                        grdReports.HeaderRow.Cells[3].Text = "Speaker";
                        grdReports.HeaderRow.Cells[4].Text = "Event Description";
                        grdReports.HeaderRow.Cells[5].Text = "Date";
                    }

                    Font font = new Font();
                    font.Color = new BaseColor(grdReports.HeaderStyle.ForeColor);

                    PdfPCell pdfCell = new PdfPCell(new Phrase(Headercell.Text, font));
                    pdfCell.BackgroundColor = new BaseColor(grdReports.HeaderStyle.BackColor);
                    pdfTable.AddCell(pdfCell);

                }

                foreach (GridViewRow gridviewrow in grdReports.Rows)
                {
                    foreach (TableCell tablecell in gridviewrow.Cells)
                    {
                        Font font = new Font();
                        font.Color = new BaseColor(grdReports.RowStyle.ForeColor);

                        PdfPCell pdfcell = new PdfPCell(new Phrase(tablecell.Text));
                        pdfcell.BackgroundColor = new BaseColor(grdReports.RowStyle.BackColor);
                        pdfTable.AddCell(pdfcell);
                    }
                }

                Document pdfDocument = new Document(new RectangleReadOnly(842, 595), 10f, -200f, 10f, 0f);
                PdfAWriter.GetInstance(pdfDocument, Response.OutputStream);

                pdfDocument.Open();
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
    }
}