using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TypeLib.ViewModels;
using TypeLib.Models;
using Muslimeen.BLL;

namespace Muslimeen.Content.Mosque
{
    public partial class MosqueRep : System.Web.UI.Page
    {
        DBHandler db = new DBHandler();
        protected void Page_Load(object sender, EventArgs e)
        {
           


            if (Session["UserName"] != null)
            {
                uspGetMember uspGetMember = new uspGetMember();

                uspGetMember = db.BLL_GetMember(Convert.ToString(Session["UserName"]));
                Session["MosqueID"] = uspGetMember.MosqueID.ToString();

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

            
            BtnUpdate.Visible = false;
            BtnAdd.Visible = false;
            divUpdateEvent.Visible = false;

            if (!IsPostBack)
            {
                List<uspGetMosqueEvents> list = new List<uspGetMosqueEvents>();
                list = db.Bll_GetMosqueEvents(int.Parse(Session["MosqueID"].ToString()));
                ddlUpdateEvent.Items.Add("Select Event Date");

                foreach (uspGetMosqueEvents events in list)
                {
                    ddlUpdateEvent.Items.Add(new ListItem(events.EventDate.ToString().Substring(0, 10)));
                }
                ddlUpdateEvent.DataBind();


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
            int index = int.Parse(e.Item.Value);
            MultiView.ActiveViewIndex = index;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            lblDate.Text = Calendar1.SelectedDate.ToShortDateString();
            uspGetSpecificDayPrayerTimes time = new uspGetSpecificDayPrayerTimes();
            time = db.BLL_GetSpecficDayPrayerTimes(Convert.ToInt32(Session["MosqueID"]), Calendar1.SelectedDate);
            if (time != null)
            {
                 
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Prayer with selected date contains prayer times. Update Prayer times or select another date');</script>");
                txtFajrA.Text = time.FajrA.ToString();
                txtFajrJ.Text = time.FajrJ.ToString();
                txtDhuhrA.Text = time.DhuhrA.ToString();
                txtDhuhrJ.Text = time.DhuhrJ.ToString();
                txtAsrA.Text = time.AsrA.ToString();
                txtAsrJ.Text = time.AsrJ.ToString();
                txtMagribA.Text = time.MagribA.ToString();
                txtMagribJ.Text = time.MagribJ.ToString();
                txtEishaA.Text = time.EishaA.ToString();
                txtEishaJ.Text = time.EishaJ.ToString();
                BtnUpdate.Visible = true;
                BtnAdd.Visible = false;
            }
            else
            {
                lblMessage.Text = "Add Prayer Times";
                txtFajrA.Text = "";
                txtFajrJ.Text = "";
                txtDhuhrA.Text = "";
                txtDhuhrJ.Text = "";
                txtAsrA.Text = "";
                txtAsrJ.Text = "";
                txtMagribA.Text = "";
                txtMagribJ.Text = "";
                txtEishaA.Text = "";
                txtEishaJ.Text = "";
                BtnUpdate.Visible = false;
                BtnAdd.Visible = true;
            }
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                Prayer prayer = new Prayer();
                prayer.PrayerDate = Calendar1.SelectedDate.Date;
                prayer.MosqueID = Convert.ToInt32(Session["MosqueID"]);
                db.BLL_InsertPrayer(prayer);
                PrayerType type = new PrayerType();
                string time = txtFajrA.Text.ToString();
                int count = 1;
                if (Session["MosqueID"] != null)
                {
                    while (count <= 5)
                    {
                        if (count == 1)
                        {
                            type.PrayerDescription = "Fajr";
                            type.PrayerDate = Calendar1.SelectedDate;
                            type.MosqueID = Convert.ToInt32(Session["MosqueID"]);
                            type.AdhaanTime = txtFajrA.Text.ToString();
                            type.JamaatTime = txtFajrJ.Text.ToString();
                            db.BLL_InsertPrayerType(type);
                        }
                        else if (count == 2)
                        {
                            type.PrayerDate = Calendar1.SelectedDate;
                            type.PrayerDescription = "Dhuhr";
                            type.MosqueID = Convert.ToInt32(Session["MosqueID"]);
                            type.AdhaanTime = txtDhuhrA.Text.ToString();
                            type.JamaatTime = txtDhuhrJ.Text.ToString();
                            db.BLL_InsertPrayerType(type);
                        }
                        else if (count == 3)
                        {
                            type.PrayerDate = Calendar1.SelectedDate;
                            type.MosqueID = Convert.ToInt32(Session["MosqueID"]);
                            type.PrayerDescription = "Asr";
                            type.AdhaanTime = txtAsrA.Text.ToString();
                            type.JamaatTime = txtAsrJ.Text.ToString();
                            db.BLL_InsertPrayerType(type);
                        }
                        else if (count == 4)
                        {
                            type.PrayerDate = Calendar1.SelectedDate;
                            type.MosqueID = Convert.ToInt32(Session["MosqueID"]);
                            type.PrayerDescription = "Magrib";
                            type.AdhaanTime = txtMagribA.Text.ToString();
                            type.JamaatTime = txtMagribJ.Text.ToString();
                            db.BLL_InsertPrayerType(type);
                        }
                        else if (count == 5)
                        {
                            type.PrayerDate = Calendar1.SelectedDate;
                            type.MosqueID = Convert.ToInt32(Session["MosqueID"]);
                            type.PrayerDescription = "Eisha";
                            type.AdhaanTime = txtEishaA.Text.ToString();
                            type.JamaatTime = txtEishaJ.Text.ToString();
                            db.BLL_InsertPrayerType(type);
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Successfully Added Prayer Times');</script>");
                            lblMessage.Text = "";
                        }

                        count++;
                    }
                }
            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Add Unsuccesfull');</script>");

            }
            BtnAdd.Visible = false;
            BtnUpdate.Visible = false;
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            BtnAdd.Visible = false;
            BtnUpdate.Visible = false;
            int count = 1;
            PrayerType type = new PrayerType();
            try
            {
                if (Session["MosqueID"] != null)
                {
                    while (count <= 5)
                    {
                        if (count == 1)
                        {
                            type.PrayerDescription = "Fajr";
                            type.PrayerDate = Calendar1.SelectedDate;
                            type.MosqueID = Convert.ToInt32(Session["MosqueID"]);
                            type.AdhaanTime = txtFajrA.Text.ToString();
                            type.JamaatTime = txtFajrJ.Text.ToString();
                            db.BLL_UpdatePrayerType(type);
                        }
                        else if (count == 2)
                        {
                            type.PrayerDate = Calendar1.SelectedDate;
                            type.PrayerDescription = "Dhuhr";
                            type.MosqueID = Convert.ToInt32(Session["MosqueID"]);
                            type.AdhaanTime = txtDhuhrA.Text.ToString();
                            type.JamaatTime = txtDhuhrJ.Text.ToString();
                            db.BLL_UpdatePrayerType(type);
                        }
                        else if (count == 3)
                        {
                            type.PrayerDate = Calendar1.SelectedDate;
                            type.MosqueID = Convert.ToInt32(Session["MosqueID"]);
                            type.PrayerDescription = "Asr";
                            type.AdhaanTime = txtAsrA.Text.ToString();
                            type.JamaatTime = txtAsrJ.Text.ToString();
                            db.BLL_UpdatePrayerType(type);
                        }
                        else if (count == 4)
                        {
                            type.PrayerDate = Calendar1.SelectedDate;
                            type.MosqueID = Convert.ToInt32(Session["MosqueID"]);
                            type.PrayerDescription = "Magrib";
                            type.AdhaanTime = txtMagribA.Text.ToString();
                            type.JamaatTime = txtMagribJ.Text.ToString();
                            db.BLL_UpdatePrayerType(type);
                        }
                        else if (count == 5)
                        {
                            type.PrayerDate = Calendar1.SelectedDate;
                            type.MosqueID = Convert.ToInt32(Session["MosqueID"]);
                            type.PrayerDescription = "Eisha";
                            type.AdhaanTime = txtEishaA.Text.ToString();
                            type.JamaatTime = txtEishaJ.Text.ToString();
                            db.BLL_UpdatePrayerType(type);
                            lblMessage.Text = "Prayer Times Successfully Updated";
                        }

                        count++;
                    }
                }
            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Add Unsuccesfull');</script>");
            }





        }

        protected void btnAddEvent_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["MosqueId"] != null)
                {
                    Event mosqueEvent = new Event();
                    mosqueEvent.EventTitle = txtEventTitle.Text.ToString();
                    mosqueEvent.EventDescription = txtEventDescription.Text.ToString();
                    mosqueEvent.EventStartTime = txtEventStartTime.Text.ToString();
                    mosqueEvent.EventEndTime = txtEventEndTime.Text.ToString();
                    mosqueEvent.EventDate = Convert.ToDateTime(txtEventDate.Text.ToString());
                    mosqueEvent.MosqueID = int.Parse(Session["MosqueID"].ToString());
                    mosqueEvent.Speaker = txtSpeaker.Text.ToString();
                    mosqueEvent.Active = 'Y';
                    db.BLL_InsertEvent(mosqueEvent);
                    txtEventTitle.Text = "";
                    txtEventDescription.Text = "";
                    txtEventStartTime.Text = "";
                    txtEventEndTime.Text = "";
                    txtEventDate.Text = "";
                    txtSpeaker.Text = "";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Successfully Added Event');</script>");

                }

            }
            catch { }



        }

        protected void ddlUpdateEvent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUpdateEvent.SelectedValue.ToString() != "Select Event Date")
            {
                rptUpdateEvents.Visible = true;
                DateTime startDate = Convert.ToDateTime(ddlUpdateEvent.SelectedValue.ToString());
                DateTime EndDate = Convert.ToDateTime(ddlUpdateEvent.SelectedValue.ToString());
                rptUpdateEvents.DataSource = db.Bll_GetMosqueEventsDateRange(int.Parse(Session["MosqueID"].ToString()), startDate, EndDate);
                rptUpdateEvents.DataBind();
            }
            else if (ddlUpdateEvent.SelectedValue.ToString() == "Select Event Date")
            {
                rptUpdateEvents.DataSource = null;
                rptUpdateEvents.DataBind();
            }
        }

        protected void btnViewDetails_Click(object sender, EventArgs e)
        {

        }

        protected void btnSelectEvent_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            rptUpdateEvents.Visible = false;
            divUpdateEvent.Visible = true;
            uspGetSpecificEvent events = new uspGetSpecificEvent();
            Session["EventID"] = btn.CommandArgument.ToString();
            events = db.BLL_GetuspGetSpecificEvent(int.Parse(btn.CommandArgument.ToString()));
            txtUpdateEventTitle.Text = events.EventTitle;
            txtUpdateEventDescription.Text = events.EventDescription;
            txtUpdateEventStartTime.Text = events.EventStartTime;
            txtUpdateEventEndTime.Text = events.EventEndTime;
            txtUpdateEventDate.Text = events.EventDate.ToString();
            txtUpdateSpeaker.Text = events.Speaker;


        }

        protected void btnUpdateEvent_Click(object sender, EventArgs e)
        {

            try
            {
                Event events = new Event();
                events.EventID = 1;

                events.EventTitle = txtUpdateEventTitle.Text.ToString();
                events.EventDescription = txtUpdateEventDescription.Text.ToString();
                events.EventStartTime = txtUpdateEventStartTime.Text.ToString();
                events.EventEndTime = txtUpdateEventEndTime.Text.ToString();
                events.EventDate = Convert.ToDateTime(txtUpdateEventDate.Text.ToString());
                events.Speaker = txtUpdateSpeaker.Text.ToString();
                events.MosqueID = int.Parse(Session["MosqueID"].ToString());
                db.BLL_UpdateEvent(events);
                ddlUpdateEvent.SelectedIndex = 0;
            }
            catch { }
        }

        protected void btnRemoveEvent_Click(object sender, EventArgs e)
        {
            try
            {
                Event events = new Event();
                events.EventID = int.Parse(Session["EventID"].ToString());
                db.BLL_RemoveEvent(events);

                List<uspGetMosqueEvents> list = new List<uspGetMosqueEvents>();
                list = db.Bll_GetMosqueEvents(int.Parse(Session["MosqueID"].ToString()));

                ddlUpdateEvent.Items.Clear();
                ddlUpdateEvent.Items.Add("Select Event Date");

                foreach (uspGetMosqueEvents even in list)
                {
                    ddlUpdateEvent.Items.Add(new ListItem(even.EventDate.ToString().Substring(0, 10)));
                }
                ddlUpdateEvent.DataBind();

                ddlUpdateEvent.SelectedIndex = 0;
            }
            catch { }

        }
    }
}