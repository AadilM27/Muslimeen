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

namespace Muslimeen.Content
{
    public partial class MyAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DBHandler dBHandler = new DBHandler();

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


            lnkViewPendingSch.ServerClick += LnkViewPendingSch_ServerClick1;
            lnkViewPendingMod.ServerClick += LnkViewPendingMod_ServerClick;
            lnkViewPendingArticles.ServerClick += LnkViewPendingArticles_ServerClick;
            divDisplaySch.Visible = false;
        }

        private void LnkViewPendingArticles_ServerClick(object sender, EventArgs e)
        {
            divDisplaySch.Visible = false;
            divViewPendingSch.Visible = false;
            divViewPendingArt.Visible = true;

            DBHandler dBHandler = new DBHandler();

            rptViewPendingArticles.DataSource = dBHandler.BLL_GetPendingArticle();
            rptViewPendingArticles.DataBind();

        }

        private void LnkViewPendingMod_ServerClick(object sender, EventArgs e)
        {
            divViewPendingArt.Visible = false;
            divDisplaySch.Visible = true;
            divViewPendingSch.Visible = true;

            DBHandler dBHandler = new DBHandler();

            rptViewPendingSch.DataSource = dBHandler.BLL_GetAllPendingModeraters();
            rptViewPendingSch.DataBind();
        }

        private void LnkViewPendingSch_ServerClick1(object sender, EventArgs e)
        {
            divViewPendingArt.Visible = false;
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
            Response.Redirect("~/Content/Mosque.aspx");
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

        protected void rptViewPendingSch_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            

        }

        protected void btnShow_Click(object sender, EventArgs e)
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

        protected void btnAcceptReg_Click(object sender, EventArgs e)
        {
            if (hdfSchId.Value != null)
            {
                DBHandler db = new DBHandler();
                uspVerifyMember uspVerifyMember = new uspVerifyMember();

                string memberId = hdfSchId.Value.ToString();

                uspVerifyMember.MemberID = memberId;
                db.BLL_VerifyMember(uspVerifyMember);

            }
        }

        protected void btnRejectReg_Click(object sender, EventArgs e)
        {
            DBHandler db = new DBHandler();
            uspRejectReg rejectReg = new uspRejectReg();

            rejectReg.MemberID = hdfSchId.Value.ToString();

            db.BLL_RejectReg(rejectReg);
        }

        protected void btnShowArt_Click(object sender, EventArgs e)
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
    }
}