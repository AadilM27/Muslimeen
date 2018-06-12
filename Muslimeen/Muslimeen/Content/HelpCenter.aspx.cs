using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TypeLib.Models;
using TypeLib.ViewModels;
using Muslimeen.BLL;

namespace Muslimeen.Content
{
    public partial class HelpCenter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
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
            Response.Redirect("~/Content/Mosque.aspx");
        }

        protected void btnScholars_Click(object sender, EventArgs e)
        {
            //redirect user to the scholars list page.
        }

        protected void btnLearnIslam_Click(object sender, EventArgs e)
        {
            //redirect user to the LearnIslam page.
        }

        protected void btnZakaah_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Content/Zakaah.aspx");
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
    }
}