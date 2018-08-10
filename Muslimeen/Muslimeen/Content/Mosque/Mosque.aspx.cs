using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TypeLib.ViewModels;
using Muslimeen.BLL;


namespace Muslimeen.Content.Mosque
{
    public partial class MosquePage : System.Web.UI.Page
    {
        DBHandler db = new DBHandler();
        protected void Page_Load(object sender, EventArgs e)
        {



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

                Session["MosqueID"] = Request.QueryString["MosqueID"];

                rptGetEvents.DataSource = db.Bll_GetMosqueEvents(int.Parse(Session["MosqueID"].ToString()));
                rptGetEvents.DataBind();
                #region LoadAdd/UpdatePrayer



                try
                {

                    DateTime date = DateTime.Today;
                    uspGetSpecificDayPrayerTimes time = new uspGetSpecificDayPrayerTimes();
                    time = db.BLL_GetSpecficDayPrayerTimes(int.Parse(Session["MosqueID"].ToString()), date);
                    lblFajrAzaan.Text = time.FajrA.ToString();
                    lblFajrJamaat.Text = time.FajrJ.ToString();
                    lblDhuhrAzaan.Text = time.DhuhrA.ToString();
                    lblDhuhrJamaat.Text = time.DhuhrJ.ToString();
                    lblAsrAzaan.Text = time.AsrA.ToString();
                    lblAsrJamaat.Text = time.AsrJ.ToString();
                    lblMagribAzaan.Text = time.MagribA.ToString();
                    lblMagribJamaat.Text = time.MagribJ.ToString();
                    lblEishaAzaan.Text = time.EishaA.ToString();
                    lblEishaJamaat.Text = time.EishaJ.ToString();
                }
                catch { }
                try
                {

                    uspGetMosque mosque = new uspGetMosque();
                    mosque = db.GetMosque(int.Parse(Session["MosqueID"].ToString()));
                    lblMosqueName.Text = mosque.MosqueName.ToString();
                    lblMosqueAddress.Text = mosque.MosqueStreet + " " + mosque.MosqueSuburb;
                    Session["Address"] = lblMosqueAddress.Text.ToString();
                    lblYearEstablished.Text = mosque.YearEstablished.ToString().Substring(0, 10);
                    lblMosqueType.Text = mosque.MosqueType;
                    lblMosqueSize.Text = mosque.MosqueSize;
                    lblQuote.Text = mosque.MosqueQuote;
                    imgMosque.ImageUrl=mosque.MosqueImage;
                    lblMembers.Text = mosque.MemberCount.ToString();
                    uspGetMember member = new uspGetMember();
                   member = db.BLL_GetMosqueRep(int.Parse(Session["MosqueID"].ToString()));
                   lblMosqueRep.Text = member.MemberName.ToString() + " " + member.MemberLastName.ToString();
                }
                catch { throw; }
                #endregion LoadAdd/UpdatePrayer
            }
            catch { }
            if (!IsPostBack)
            {
                divDetails.Visible = false;
                divEvent.Visible = false;
                divLocation.Visible = false;
                divPrayerTimes.Visible = false;
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
        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
         
        }

        protected void btnListEvents_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime startDate = Convert.ToDateTime(txtStartDate.Text.ToString());
                DateTime EndDate = Convert.ToDateTime(txtEndDate.Text.ToString());
                rptGetEvents.DataSource = db.Bll_GetMosqueEventsDateRange(int.Parse(Session["MosqueID"].ToString()), startDate, EndDate);
                rptGetEvents.DataBind();
            }
            catch
            {

            }

        }

        protected void btnListPrayer_Click(object sender, EventArgs e)
        {
            try
            {
                List<uspGetMosquePrayerTimes> list = new List<uspGetMosquePrayerTimes>();
                List<uspGetSpecificDayPrayerTimes> times = new List<uspGetSpecificDayPrayerTimes>();
                DateTime startDate = Convert.ToDateTime(txtPrayerStartDate.Text.ToString());
                DateTime endDate = Convert.ToDateTime(txtPrayerEndDate.Text.ToString());
                list = db.BLL_GetMosquePrayerTimes(int.Parse(Session["MosqueID"].ToString()), startDate, endDate);

                int count = 0;

                uspGetSpecificDayPrayerTimes pt = new uspGetSpecificDayPrayerTimes();

                foreach (uspGetMosquePrayerTimes prayer in list)
                {

                    if (count == 0)
                    {

                        pt.PrayerDescription = prayer.PrayerDescription;
                        pt.PrayerDate = prayer.PrayerDate;
                        pt.PrayerDay = Convert.ToDateTime(pt.PrayerDate).DayOfWeek.ToString();
                        pt.FajrA = prayer.AdhaanTime;
                        pt.FajrJ = prayer.JamaatTime;


                    }
                    else if (count == 1)
                    {
                        pt.DhuhrA = prayer.AdhaanTime;
                        pt.DhuhrJ = prayer.JamaatTime;

                    }
                    else if (count == 2)
                    {
                        pt.AsrA = prayer.AdhaanTime;
                        pt.AsrJ = prayer.JamaatTime;


                    }
                    else if (count == 3)
                    {
                        pt.MagribA = prayer.AdhaanTime;
                        pt.MagribJ = prayer.JamaatTime;

                    }
                    else if (count == 4)
                    {
                        pt.EishaA = prayer.AdhaanTime;
                        pt.EishaJ = prayer.JamaatTime;
                        count = -1;
                        times.Add(pt);
                        pt = new uspGetSpecificDayPrayerTimes();

                    }

                    count++;

                }
                rptPrayerTimes.DataSource = times;
                rptPrayerTimes.DataBind();
            }
            catch { }
        }

        protected void btnMosqueDetails_Click(object sender, EventArgs e)
        {
            divDetails.Visible = true;
            divEvent.Visible = false;
            divLocation.Visible  = false;
            divPrayerTimes.Visible = false;
        }

        protected void btnEvents_Click(object sender, EventArgs e)
        {
            divDetails.Visible = false;
            divEvent.Visible = true;
            divLocation.Visible = false;
            divPrayerTimes.Visible = false;
        }

        protected void btnAddress_Click(object sender, EventArgs e)
        {
            divDetails.Visible = false;
            divEvent.Visible = false;
            divLocation.Visible = true;
            divPrayerTimes.Visible = false;
        }

        protected void btnPrayerTimes_Click(object sender, EventArgs e)
        {
            divDetails.Visible = false;
            divEvent.Visible = false;
            divLocation.Visible = false;
            divPrayerTimes.Visible = true;
        }
    }
}