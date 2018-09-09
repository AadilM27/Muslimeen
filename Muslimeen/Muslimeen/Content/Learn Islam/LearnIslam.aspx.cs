using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TypeLib.ViewModels;
using Muslimeen.BLL;
using TypeLib.Models;
using System.Data;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace Muslimeen.Content.Learn_Islam
{
    public partial class LearnIslam : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DBHandler db = new DBHandler();
            List<CounterCalender> counterCalender = new List<CounterCalender>();

            counterCalender = db.BLL_GetCounterCalender();
            hdfAdjustDate.Value = counterCalender[3].Val.ToString();

            DBHandler dBHandler = new DBHandler();

            //Pending Link Article Source
            repeatLink.DataSource = dBHandler.BLL_GetLearnArticle();
            repeatLink.DataBind();

            divNoSelected.Visible = false;
            divPendingArticles.Visible = true;
            

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

                divUserProfile.Visible = false;
                Session.Clear();
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
            //redirect user to the scholars list page.
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

            LinkButton linkButton = (LinkButton)sender;

            string art = linkButton.CommandArgument.ToString();
            hdfArtID.Value = art;

            DBHandler han = new DBHandler();
            uspGetSelectedLearnArticle pen = new uspGetSelectedLearnArticle();

            //Labels for Learn Article
            pen = han.BLL_GetSelectedLearnArticle(int.Parse(art));
            lblTitle.InnerText = pen.ArticleTitle.ToString();
            lblContent.InnerText = pen.ArticleContent.ToString();
            string dateCreated = pen.DateCreated.ToString("yyyy/MM/dd");
            lblDate.InnerText = Convert.ToDateTime(dateCreated).ToString("dd/MM/yyyy");
            lblScholar.InnerText = pen.ScholarName.ToString();

            //Repeater Data Surce for Comments
            CommentRepeater.DataSource = han.BLL_GetComment(int.Parse(art));
            CommentRepeater.DataBind();            
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
                PdfPCell pdfDate = new PdfPCell(new Phrase("Date: " + lblDate.InnerText, content));

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
            try
            {
                DBHandler han = new DBHandler();
                Comment com = new Comment();

                com.CommentMessage = Convert.ToString(txtComment.Text);
                com.CommentDate = DateTime.Now;
                com.ArticleID = Convert.ToInt32(hdfArtID.Value);
                com.MemberID = Convert.ToString(Session["UserName"]);
                com.CommentID = null;

                han.BLL_AddComment(com);

                CommentRepeater.DataSource = han.BLL_GetComment(int.Parse(hdfArtID.Value));
                CommentRepeater.DataBind();

                divNoSelected.Visible = true;
            }
            catch
            {
                
            }
        }
    }
}