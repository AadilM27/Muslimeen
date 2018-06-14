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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DBHandler han = new DBHandler();
            Article art = new Article();

            lblErrorPass.Text = "";

            try
            {
                if (txtHeading.Text == null && txtContent.Text == null)
                {
                    lblErrorPass.Text = "One or more fields are left empty";                    
                }
                else
                {
                    art.DateCreated = Convert.ToDateTime(DateTime.Today);
                    art.Status = Convert.ToChar("P");
                    art.RejectionReason = Convert.ToString(" ");
                    art.Active = Convert.ToChar("T");
                    art.RemovalReason = Convert.ToString(" ");

                    //Scholar ID input with session...
                    art.ScholarID = Convert.ToString(Session["UserName"] = "123");
                    //art.ScholarID = Convert.ToString(" ");
                    art.ModeratorID = Convert.ToString(" ");
                    art.TopicID = Convert.ToInt32(drpTopics.SelectedValue);
                    art.ArticleTitle = Convert.ToString(txtHeading.Text);
                    art.ArticleContent = Convert.ToString(txtContent.Text);

                    bool success = han.BLL_AddArticle(art);

                    txtHeading.Text = " ";
                    txtContent.Text = " ";
                }

            }
            catch
            {

            }
        }

        protected void drpTopics_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}