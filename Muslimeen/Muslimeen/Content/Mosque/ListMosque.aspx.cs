using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TypeLib.ViewModels;
using Muslimeen.BLL;
using TypeLib.Models;

namespace Muslimeen.Content.Mosque
{
    public partial class ListMosque : System.Web.UI.Page
    {
        DBHandler db = new DBHandler();
        protected void Page_Load(object sender, EventArgs e)
        {
            DBHandler db = new DBHandler();
            List<CounterCalender> counterCalender = new List<CounterCalender>();

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

            try
            {
                if (!IsPostBack)
                {
                    List<uspGetAllMosqueSuburbs> list = new List<uspGetAllMosqueSuburbs>();
                    list = db.BLL_GetAllMosqueSuburbs();

                    ddlMosqueSuburb.Items.Add("Any");
                    foreach (uspGetAllMosqueSuburbs suburb in list)
                    {
                        ddlMosqueSuburb.Items.Add(new ListItem(suburb.MosqueSuburb.ToString()));
                    }
                    ddlMosqueSuburb.DataBind();


                    rptGetMosques.DataSource = db.BLL_GetMosques("Any", "Any");
                    rptGetMosques.DataBind();
                }

            }
            catch { }

        }
        protected void btnViewDetails_Click(object sender, EventArgs e)
        {
            try
            {

                LinkButton btn = (LinkButton)sender;
                string ID = btn.CommandArgument.ToString();
                Response.Redirect("Mosque.aspx?MosqueID=" + ID);
            }
            catch { }

        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                rdoHanafie.Checked = false;
                rdoShafie.Checked = false;
                rptGetMosques.DataSource = db.BLL_GetMosques(ddlMosqueSuburb.SelectedValue.ToString(), "Any");
                rptGetMosques.DataBind();
            }
            catch { }

        }
        protected void rdoHanafie_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                rptGetMosques.DataSource = db.BLL_GetMosques(ddlMosqueSuburb.SelectedValue.ToString(), "Hanafie");
                rptGetMosques.DataBind();
            }
            catch { }
        }

        protected void rdoShafie_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                rptGetMosques.DataSource = db.BLL_GetMosques(ddlMosqueSuburb.SelectedValue.ToString(), "Shaafie");
                rptGetMosques.DataBind();
            }
            catch { }
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
            Response.Redirect("ListMosque.aspx");
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
            try
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
                    Response.Redirect("../MyScholar/AddArticle.aspx");
                }
                else if (uspGetMember.MemberType == 'R')
                {
                    Response.Redirect("MosqueRep.aspx");
                }

            }
            catch
            {

            }

        }
    }
}