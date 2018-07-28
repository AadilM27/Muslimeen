﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TypeLib.Models;
using TypeLib.ViewModels;
using Muslimeen.BLL;
using System.Data;

namespace Muslimeen.Content.MyModerator
{
    public partial class MyModerator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                DBHandler dBHandler = new DBHandler();
                divUpdateIslmDate.Visible = false;
                divViewPendingArt.Visible = false;
                divViewPendingSch.Visible = false;
                divDisplaySch.Visible = false;
                divViewArt.Visible = false;

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
                divDisplaySch.Visible = false;
                divViewPendingSch.Visible = false;
                divUpdateIslmDate.Visible = false;

                divViewPendingArt.Visible = true;

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
                divUpdateIslmDate.Visible = false;
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
            divViewPendingArt.Visible = false;
            divUpdateIslmDate.Visible = false;
            divDisplaySch.Visible = true;
            divViewPendingSch.Visible = true;

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
                Response.Redirect("~/Content/MyAdmin.aspx");
                btnLogin.Text = "Login";
                btnRegister.Visible = true;
            }
        }

        protected void btnUpdateIslmDate_Click(object sender, EventArgs e)
        {
            divUpdateIslmDate.Visible = true;
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

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton linkButton = (LinkButton)sender;

                string memberId = linkButton.CommandArgument.ToString();
                hdfSchId.Value = memberId;

                DBHandler dBHandler = new DBHandler();
                uspGetMember member = new uspGetMember();

                member = dBHandler.BLL_GetMember(memberId);

                lblMemberID.InnerText = member.MemberID.ToString();
                lblMemberName.InnerText = member.MemberName.ToString();
                lblMemberLastName.InnerText = member.MemberLastName.ToString();
                lblMemberDOB.InnerText = member.MemberDOB.ToString("yyyy-MM-dd");
                lblMemberType.InnerText = member.MemberType.ToString();
                lblActiveTypeID.InnerText = member.ActiveTypeID.ToString();
                lblEmail.InnerText = member.Email.ToString();
                lblContactNo.InnerText = member.ContactNo.ToString();
                lblActivationExpiry.InnerText = member.ActivationExpiry.ToString("yyyy-MM-dd");
                lblActivationDate.InnerText = member.ActivationDate.ToString("yyyy-MM-dd");

                divViewPendingSch.Visible = true;
                divViewArt.Visible = false;
                divDisplaySch.Visible = true;
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
                Article article = new Article();
                article = dBHandler.BLL_GetArticle(Convert.ToInt32(articleId));


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
                    AcceptArticle accept = new AcceptArticle();

                    string articleId = hdfSchId.Value.ToString();


                    accept.ModeraterID = Session["UserName"].ToString();
                    accept.Status = 'A';
                    accept.Active = 'Y';
                    accept.RejectionReason = "";
                    accept.ArticleID = Convert.ToInt32(articleId);
                    DBHandler dBHandler = new DBHandler();

                    dBHandler.BLL_AcceptArticle(accept);
                }
            }
            catch
            {

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                AcceptArticle accept = new AcceptArticle();

                string articleId = hdfSchId.Value.ToString();


                accept.ModeraterID = Session["UserName"].ToString();
                accept.Status = 'R';
                accept.Active = 'N';
                accept.RejectionReason = txtRejectReason.Text.ToString();
                accept.ArticleID = Convert.ToInt32(articleId);
                DBHandler dBHandler = new DBHandler();

                dBHandler.BLL_AcceptArticle(accept);
            }
            catch
            {

            }
        }

        protected void rptViewPendingSch_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

    }
}