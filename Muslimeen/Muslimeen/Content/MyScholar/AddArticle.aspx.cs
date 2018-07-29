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

namespace Muslimeen.Content.MyScholar
{
    public partial class AddArticle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                DBHandler dBHandler = new DBHandler();

                divAddArticle.Visible = true;
                divPendingArticles.Visible = false;
                divRejectedArticles.Visible = false;

                //Pending Article Source
                repeatPendingArticle.DataSource = dBHandler.BLL_GetPendingArticle();
                repeatPendingArticle.DataBind();

                //RejectedArticle Source
                repeatRejectedArticle.DataSource = dBHandler.BLL_GetRejectedArticle();
                repeatRejectedArticle.DataBind();

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

                if (!IsPostBack)
                {
                    //Populating dropdown box wiht values
                    List<uspGetTopics> tops = dBHandler.BLL_GetTopics();

                    foreach (uspGetTopics qual in tops)
                    {
                        drpTopics.Items.Add(new ListItem(qual.TopicDescription.ToString(), qual.TopicID.ToString()));
                    }
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

        protected void btnViewArticles_Click(object sender, EventArgs e)
        {
            try
            {
                divAddArticle.Visible = true;
                divPendingArticles.Visible = false;
                divRejectedArticles.Visible = false;

                DBHandler dBHandler = new DBHandler();
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
                divRejectedArticles.Visible = false;

                DBHandler dBHandler = new DBHandler();
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
                divRejectedArticles.Visible = true;

                DBHandler dBHandler = new DBHandler();
            }
            catch
            {

            }
        }

        protected void btnAddArticle_Click(object sender, EventArgs e)
        {
            divAddArticle.Visible = true;

            DBHandler dBHandler = new DBHandler();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DBHandler han = new DBHandler();
            Article art = new Article();

            //lblErrorPass.Text = "";

            try
            {
                if (txtHeading.Text == null && txtContent.Text == null)
                {
                    //lblErrorPass.Text = "One or more fields are left empty";
                }
                else
                {
                    art.DateCreated = Convert.ToDateTime(DateTime.Today);
                    art.Status = Convert.ToChar("P");
                    art.RejectionReason = Convert.ToString(" ");
                    art.Active = Convert.ToChar("T");
                    art.RemovalReason = Convert.ToString(" ");

                    //Scholar ID input with session...
                    art.ScholarID = Convert.ToString(Session["UserName"]);
                    //art.ScholarID = Convert.ToString(" ");
                    art.ModeratorID = Convert.ToString(" ");
                    art.TopicID = Convert.ToInt32(drpTopics.SelectedValue);
                    art.ArticleTitle = Convert.ToString(txtHeading.Text);
                    art.ArticleContent = Convert.ToString(txtContent.Text);

                    han.BLL_InsertArticle(art);

                    bool success = han.BLL_InsertArticle(art);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Add Succesfull');</script>");
                    txtHeading.Text = " ";
                    txtContent.Text = " ";

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Successfully Added Article');</script>");
                }
            }
            catch
            {
                
            }
        }
    }
}