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
using System.Drawing;
using System.IO;
using System.Globalization;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace Muslimeen.Content
{
    public partial class Scholar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            divSchDetailsOverlay.Visible = true;
            divDisplaySch.Visible = false;

            Context.Response.Cache.SetCacheability(HttpCacheability.NoCache);

            DBHandler han = new DBHandler();

            rptViewPendingSch.DataSource = han.BLL_GetScholarByMosque(Int32.Parse("Select"));
            rptViewPendingSch.DataBind();

            if (!IsPostBack)
            {
                List<uspGetMosqueList> mosque = han.BLL_GetMosqueList();

                drpMosque.Items.Add("Select");
                foreach (uspGetMosqueList mos in mosque)
                {
                    drpMosque.Items.Add(new System.Web.UI.WebControls.ListItem(mos.MosqueName.ToString(), mos.MosqueID.ToString()));
                }
                drpMosque.DataBind();
            }
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
                Response.Redirect("MyAdmin.aspx");
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
            Response.Redirect("Default.aspx");
        }

        protected void btnMosques_Click(object sender, EventArgs e)
        {
            Response.Redirect("Mosque/ListMosque.aspx");
        }

        protected void btnScholars_Click(object sender, EventArgs e)
        {
            //redirect user to the scholars list page.
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

                if (uspGetMember.MemberType == 'A')
                {
                    Response.Redirect("MyAdmin.aspx");
                }
                else if (uspGetMember.MemberType == 'M')
                {
                    Response.Redirect("MyMember.aspx");
                }
                else if (uspGetMember.MemberType == 'O')
                {
                    Response.Redirect("MyModerator.aspx");
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
            divSchDetailsOverlay.Visible = false;
            divDisplaySch.Visible = true;

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
                lblMemberDOB.InnerText = scholarDetails.MemberDOB.ToString("dd MM yyyy");
                lblEmail.InnerText = scholarDetails.Email.ToString();
                lblContactNo.InnerText = scholarDetails.ContactNo.ToString();
                lblScholarQual.InnerText = scholarDetails.QualificationDescription.ToString();
            }
            catch
            {

            }
        }

        protected void drpMosque_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DBHandler han = new DBHandler();

                if (drpMosque.SelectedItem.ToString() != "Select")
                {
                    rptViewPendingSch.DataSource = han.BLL_GetScholarByMosque(Int32.Parse(drpMosque.SelectedItem.ToString()));
                    rptViewPendingSch.DataBind();
                }
            }
            catch
            {

            }
        }
    }
}