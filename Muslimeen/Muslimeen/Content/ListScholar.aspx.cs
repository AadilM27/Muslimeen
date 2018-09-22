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
            divAlertPopup.Visible = false;
            divSchDetailsOverlay.Visible = true;
            divDisplaySch.Visible = false;

            Context.Response.Cache.SetCacheability(HttpCacheability.NoCache);

            DBHandler db = new DBHandler();
            List<CounterCalender> counterCalender = new List<CounterCalender>();
            try
            {
                counterCalender = db.BLL_GetCounterCalender();
                hdfAdjustDate.Value = counterCalender[3].Val.ToString();

                if (Session["UserName"] != null)
                {
                    uspGetMember uspGetMember = new uspGetMember();

                    uspGetMember = db.BLL_GetMember(Convert.ToString(Session["UserName"]));
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
            catch
            {

            }

            DBHandler han = new DBHandler();

            if (!IsPostBack)
            {
                List<uspGetMosqueList> mosque = han.BLL_GetMosqueList();

                drpMosque.Items.Add("All");
                foreach (uspGetMosqueList mos in mosque)
                {
                    drpMosque.Items.Add(new System.Web.UI.WebControls.ListItem(mos.MosqueName.ToString(), mos.MosqueID.ToString()));
                }
                drpMosque.DataBind();

                rptViewPendingSch.DataSource = han.BLL_GetScholarByMosque(Int32.Parse("0"));
                rptViewPendingSch.DataBind();

                //Populate Dropdown for Qualification

                List<uspGetQualification> list = han.BLL_GetQualification();

                drpQuali.Items.Add("All");
                foreach (uspGetQualification qua in list)
                {
                    drpQuali.Items.Add(new System.Web.UI.WebControls.ListItem(qua.QualificationDescription.ToString(), qua.QualificationID.ToString()));
                }
                drpQuali.DataBind();
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
                divAlertPopup.Visible = true;
                DBHandler han = new DBHandler();

                if (drpMosque.SelectedItem.ToString() != "All")
                {
                    rptViewPendingSch.DataSource = han.BLL_GetScholarByMosque(Int32.Parse(drpMosque.SelectedValue.ToString()));
                    rptViewPendingSch.DataBind();
                }
                else if (drpMosque.SelectedItem.ToString() == "All")
                {
                    rptViewPendingSch.DataSource = han.BLL_GetScholarByMosque(Int32.Parse("0"));
                    rptViewPendingSch.DataBind();
                }

                if (rptViewPendingSch.Items.Count < 1)
                {
                    lblAlertError.InnerText = "No Scholars Assinged to this Mosque";

                    this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "ListScholar", "var divpop = document.getElementById('divAlertPopup');divpop.classList.add('visible2')" +
                        ";setTimeout(function Flash3() {divpop.style.display = 'none';}, 4000)", true);
                }

            }
            catch
            {

            }
        }

        protected void drpQuali_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                divAlertPopup.Visible = true;
                DBHandler han = new DBHandler();

                if(drpQuali.SelectedItem.ToString() != "All")
                {
                    rptViewPendingSch.DataSource = han.BLL_GetScholarByQualification(drpQuali.SelectedItem.ToString());
                    rptViewPendingSch.DataBind();
                }
                else if (drpQuali.SelectedItem.ToString() == "All")
                {
                    rptViewPendingSch.DataSource = han.BLL_GetScholarByQualification("All");
                    rptViewPendingSch.DataBind();
                }

                if (rptViewPendingSch.Items.Count < 1)
                {
                    lblAlertError.InnerText = "No scholars have the following qualification";

                    this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "ListScholar", "var divpop = document.getElementById('divAlertPopup');divpop.classList.add('visible2')" +
                        ";setTimeout(function Flash3() {divpop.style.display = 'none';}, 4000)", true);
                }
            }
            catch
            {

            }

        }
    }
}