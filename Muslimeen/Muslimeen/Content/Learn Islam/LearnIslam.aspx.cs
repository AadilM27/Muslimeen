using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TypeLib.ViewModels;
using Muslimeen.BLL;
using TypeLib.Models;
using System.Data.SqlClient;
using System.Data;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using AjaxControlToolkit;
using System.Drawing;

namespace Muslimeen.Content.Learn_Islam
{
    public partial class LearnIslam : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {


                DBHandler db = new DBHandler();
                List<CounterCalender> counterCalender = new List<CounterCalender>();

                counterCalender = db.BLL_GetCounterCalender();
                hdfAdjustDate.Value = counterCalender[3].Val.ToString();

                DBHandler dBHandler = new DBHandler();

      
                


                if (Session["UserName"] != null)
                {
                    uspGetMember uspGetMember = new uspGetMember();

                    uspGetMember = dBHandler.BLL_GetMember(Convert.ToString(Session["UserName"]));
                    hplUserProfile.Text = uspGetMember.MemberLastName + ", " + uspGetMember.MemberName;
                    divUserProfile.Visible = true;

                    liMyMusbtn.Visible = true;
                    liMyMusDivi.Visible = true;

                    btnLogin.Text = "Log out";
                    btnRegister.Visible = false;

                }
                else if (Session["UserName"] == null)
                {
                    liMyMusbtn.Visible = false;
                    liMyMusDivi.Visible = false;
                    Rating1.CurrentRating = 0;
                    divUserProfile.Visible = false;
                    Session.Clear();
                    Rating1.ReadOnly = true;
                }
              
                if (!IsPostBack)
                {
                    divPendingArticles.Visible = true;
                    divRating.Visible = true;
                    divNoSelected.Visible = false;
                    //Link Article Source
                    repeatLink.DataSource = dBHandler.BLL_GetLearnArticle("Select", "Select");
                    repeatLink.DataBind();
                    List<uspGetScholarList> scholar = dBHandler.BLL_GetScholar();

                    drpScholar.Items.Add("Select");
                    foreach (uspGetScholarList sch in scholar)
                    {
                        drpScholar.Items.Add(new System.Web.UI.WebControls.ListItem(sch.ScholarName.ToString(), sch.ScholarID.ToString()));
                    }

                    drpScholar.DataBind();

                    //Populating dropdown box wiht values
                    List<uspGetTopics> tops = dBHandler.BLL_GetTopics();
                    drpTopic.Items.Add("Select");
                    foreach (uspGetTopics qual in tops)
                    {
                        drpTopic.Items.Add(new System.Web.UI.WebControls.ListItem(qual.TopicDescription.ToString(), qual.TopicID.ToString()));
                    }
                    drpTopic.DataBind();
                }

                CommentRepeater.DataSource = dBHandler.BLL_GetComment(int.Parse(hdfArtID.Value));
                CommentRepeater.DataBind();

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
                Response.Redirect("../Default.aspx");
                btnLogin.Text = "Login";
                btnRegister.Visible = true;
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("../../Register/Register.aspx");
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
                Response.Redirect("../AddArticle.aspx");
            }
            else if (uspGetMember.MemberType == 'R')
            {
                Response.Redirect("../Mosque/MosqueRep.aspx");
            }


        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            divNoSelected.Visible = true;
            try
            {

                LinkButton linkButton = (LinkButton)sender;

                string art = linkButton.CommandArgument.ToString();
                hdfArtID.Value = art;

                DBHandler han = new DBHandler();
                uspGetSelectedLearnArticle pen = new uspGetSelectedLearnArticle();
                uspRatingCount count = new uspRatingCount();

                //Labels for Learn Article
                pen = han.BLL_GetSelectedLearnArticle(int.Parse(art));
                lblTitle.InnerText = pen.ArticleTitle.ToString();
                lblContent.InnerText = pen.ArticleContent.ToString();
                string dateCreated = pen.DateCreated.ToString();
                lblDate.InnerText = Convert.ToDateTime(dateCreated).ToString();
                lblScholar.InnerText = pen.ScholarName.ToString();

                //Repeater Data Surce for Comments
                CommentRepeater.DataSource = han.BLL_GetComment(int.Parse(art));
                CommentRepeater.DataBind();

                Rating1.CurrentRating = han.BLL_GetArticleRating(int.Parse(art), Session["UserName"].ToString());

                string commentCount = CommentRepeater.Items.Count.ToString();
                lblCommentCount.Text = "Comments: " + commentCount;
               
                 
                lblRatingCount.Text = "Members rated: " + han.BLL_RatingCount(int.Parse(art)).ToString();
                
               

            }
            catch (NullReferenceException)
            {
            }
        }

        protected void lnkAdminPrintPDF_ServerClick(object sender, EventArgs e)
        {
            try
            {
                DBHandler han = new DBHandler();
                //Title and Content will be in this table.
                PdfPTable pdfTop = new PdfPTable(1);
                //Author and Date will be in this table.
                PdfPTable pdfBottom = new PdfPTable(2);

                pdfTop.HorizontalAlignment = 0;
                pdfBottom.HorizontalAlignment = 0;
                iTextSharp.text.Font fontH3 = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 18, iTextSharp.text.Font.BOLD);

                iTextSharp.text.Font font = new iTextSharp.text.Font();
                font.Color = new BaseColor(grdAdminReports.RowStyle.ForeColor);
                iTextSharp.text.Font content = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.BOLD);

                PdfPCell pdfTitle = new PdfPCell(new Phrase(lblTitle.InnerText, fontH3));
                PdfPCell pdfContent = new PdfPCell(new Phrase(lblContent.InnerText, content));

                PdfPCell pdfAuthor = new PdfPCell(new Phrase("Author: " + lblScholar.InnerText, content));
                PdfPCell pdfDate = new PdfPCell(new Phrase("Date Written: " + lblDate.InnerText, content));

                pdfTitle.HorizontalAlignment = 1;
                pdfTitle.VerticalAlignment = 2;
                pdfTitle.Padding = 10;
                pdfContent.Padding = 10;
                pdfAuthor.Padding = 10;
                pdfDate.Padding = 10;
                pdfTitle.BackgroundColor = new BaseColor(grdAdminReports.RowStyle.BackColor);
                pdfTop.AddCell(pdfTitle);
                pdfTop.AddCell(pdfContent);

                pdfBottom.AddCell(pdfAuthor);
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

                if (Session["UserName"] != null)
                {
                    uspGetMember uspGetMember = new uspGetMember();
                    DBHandler dBHandler = new DBHandler();

                    uspGetMember = dBHandler.BLL_GetMember(Convert.ToString(Session["UserName"]));

                    Paragraph extraPara = new Paragraph("Printed By: " + uspGetMember.MemberLastName + ", " + uspGetMember.MemberName, fontH2); 
                    table2.AddCell(date);
                    table2.AddCell(extraPara);
                }
                else
                {
                    Paragraph extraPara = new Paragraph("Printed By: N/A", fontH2); 
                    table2.AddCell(date);
                    table2.AddCell(extraPara);
                }
                


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
                Response.AppendHeader("content-disposition", "attachment;filename=" + lblTitle.InnerText + ".pdf");
                Response.Write(pdfDocument);
                Response.Flush();
                Response.End();

            }
            catch (NullReferenceException)
            {

            }
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            txtComment.BorderColor = Color.Empty;

            try
            {
              
                DBHandler han = new DBHandler();
                Comment com = new Comment();
                if (Session["UserName"] != null)
                {
                    if (txtComment.Text != "")
                    { 
                        com.CommentMessage = Convert.ToString(txtComment.Text);
                        com.CommentDate = DateTime.Now;
                        com.ArticleID = Convert.ToInt32(hdfArtID.Value);
                        com.MemberID = Convert.ToString(Session["UserName"]);
                        com.CommentID = null;

                        han.BLL_AddComment(com);
                        //Response.Redirect(Request.RawUrl);

                        txtComment.Text = string.Empty;

                        CommentRepeater.DataSource = han.BLL_GetComment(int.Parse(hdfArtID.Value));
                        CommentRepeater.DataBind();

                        string commentCount = CommentRepeater.Items.Count.ToString();
                        lblCommentCount.Text = "Comments: " + commentCount;
                    }
                    else
                    {
                        txtComment.BorderColor = Color.Red;
                    }
                }
                else
                {
                    lblAlertError.InnerText = "Please Login to Comment";

                    this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "LearnIslam", "var divpop = document.getElementById('divAlertPopup');divpop.style.display = 'block';" +
                        ";setTimeout(function Flash3() {divpop.style.display = 'none';}, 4000)", true);

                    txtComment.Text = string.Empty;
                    CommentRepeater.DataSource = han.BLL_GetComment(int.Parse(hdfArtID.Value));
                    CommentRepeater.DataBind();
                    string commentCount = CommentRepeater.Items.Count.ToString();
                    lblCommentCount.Text = "Comments: " + commentCount;
                }                
            }
            catch
            {

            }
        }

        protected void drpScholar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                divNoSelected.Visible = false;
                divAdminReports.Visible = false;
                divPendingArticles.Visible = true;


                DBHandler dBHandler = new DBHandler();
                if (drpScholar.SelectedValue.ToString() != "Select")
                {
                    if (drpTopic.SelectedItem.ToString() != "Select")
                    {
                        repeatLink.DataSource = dBHandler.BLL_GetLearnArticle(drpScholar.SelectedValue.ToString(), drpTopic.SelectedItem.ToString());
                        repeatLink.DataBind();
                    }
                    else
                    {
                        repeatLink.DataSource = dBHandler.BLL_GetLearnArticle(drpScholar.SelectedValue.ToString(), "Select");
                        repeatLink.DataBind();
                    }
                }
                else
                {
                    if (drpTopic.SelectedItem.ToString() != "Select")
                    {
                        repeatLink.DataSource = dBHandler.BLL_GetLearnArticle("Select", drpTopic.SelectedItem.ToString());
                        repeatLink.DataBind();
                    }
                    else
                    {
                        repeatLink.DataSource = dBHandler.BLL_GetLearnArticle("Select", "Select");
                        repeatLink.DataBind();
                    }
                }
            }
            catch { }

        }

        protected void drpTopic_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                divNoSelected.Visible = false;
                divAdminReports.Visible = false;
                divPendingArticles.Visible = true;

                DBHandler dBHandler = new DBHandler();
                if (drpScholar.SelectedValue.ToString() != "Select")
                {
                    if (drpTopic.SelectedItem.ToString() != "Select")
                    {
                        repeatLink.DataSource = dBHandler.BLL_GetLearnArticle(drpScholar.SelectedValue.ToString(), drpTopic.SelectedItem.ToString());
                        repeatLink.DataBind();
                    }
                    else
                    {
                        repeatLink.DataSource = dBHandler.BLL_GetLearnArticle(drpScholar.SelectedValue.ToString(), "Select");
                        repeatLink.DataBind();
                    }
                }
                else
                {
                    if (drpTopic.SelectedItem.ToString() != "Select")
                    {
                        repeatLink.DataSource = dBHandler.BLL_GetLearnArticle("Select", drpTopic.SelectedItem.ToString());
                        repeatLink.DataBind();
                    }
                    else
                    {
                        repeatLink.DataSource = dBHandler.BLL_GetLearnArticle("Select", "Select");
                        repeatLink.DataBind();
                    }
                }
            }
            catch { }
        }
        protected void Rating1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserName"] != null)
                {
                    DBHandler handler = new DBHandler();

                    uspInsertRating rating = new uspInsertRating();

                    int articleId = Convert.ToInt32(hdfArtID.Value.ToString());//gets article id  from repeater when clicked on and saves n into hidden field

                    Rating1.MaxRating = 5;

                    if (handler.BLL_GetArticleRating(articleId, Session["UserName"].ToString()) == 0 || handler.BLL_GetArticleRating(articleId, Session["UserName"].ToString()).ToString() == null)//when user hasnt rated an article in goes into method to execute an insert to allow that user to rate an article.
                    {
                        rating.MemberID = Session["UserName"].ToString();
                        rating.articleID = Convert.ToInt32(articleId);
                        rating.rating = Rating1.CurrentRating;

                        handler.BLL_InsertRating(rating);
                        Response.Redirect(Request.Url.AbsoluteUri);
                        divNoSelected.Visible = true;
                    }
                    else if (handler.BLL_GetArticleRating(articleId, Session["UserName"].ToString()) > 0 && handler.BLL_GetArticleRating(articleId, Session["UserName"].ToString()) <= Rating1.MaxRating)
                    {
                        uspUpdateRating upRate = new uspUpdateRating();
                        upRate.ArticleID = Convert.ToInt32(hdfArtID.Value.ToString());
                        upRate.MemberID = Session["UserName"].ToString();
                        upRate.rating = Rating1.CurrentRating;

                        handler.BLL_UpdateRating(upRate);
                        Response.Redirect(Request.Url.AbsoluteUri);
                        divNoSelected.Visible = true;
                    }       
                }
                divDisplayArticle.Visible = true;
                divRating.Visible = true;
            }
            catch
            {

            }
        }
    }
}