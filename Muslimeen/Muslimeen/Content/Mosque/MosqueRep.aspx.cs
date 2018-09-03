using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TypeLib.ViewModels;
using TypeLib.Models;
using Muslimeen.BLL;
using System.Drawing;

namespace Muslimeen.Content.Mosque
{
    public partial class MosqueRep : System.Web.UI.Page
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

            if (!IsPostBack)
            {
                divAddEvent.Visible = false;
                divManageTimes.Visible = false;
                divManageEvent.Visible = false;
                Session["Event"] = "N";
                List<uspGetMosqueEvents> list = new List<uspGetMosqueEvents>();
                list = db.Bll_GetMosqueEvents(int.Parse(Session["MosqueID"].ToString()));




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
        protected void btnHelp_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Content/HelpCenter.aspx");
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
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
        
            lblDate.Text = Calendar1.SelectedDate.ToShortDateString();
            divTimes.Visible = true;
            uspGetSpecificDayPrayerTimes time = new uspGetSpecificDayPrayerTimes();
            time = db.BLL_GetSpecficDayPrayerTimes(Convert.ToInt32(Session["MosqueID"]), Calendar1.SelectedDate);
            if (time != null)
            {

                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Prayer with selected date contains prayer times. Update Prayer times or select another date');</script>");
                lblMessage.Text = "Update Prayer Times For ";
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
                lblMessage.Text = "Add Prayer Times For ";
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
            txtFajrA.BorderColor = Color.Empty;
            txtFajrJ.BorderColor = Color.Empty;
            txtDhuhrA.BorderColor = Color.Empty;
            txtDhuhrJ.BorderColor = Color.Empty;
            txtAsrA.BorderColor = Color.Empty;
            txtAsrJ.BorderColor = Color.Empty;
            txtMagribA.BorderColor = Color.Empty;
            txtMagribJ.BorderColor = Color.Empty;
            txtEishaA.BorderColor = Color.Empty;
            txtEishaJ.BorderColor = Color.Empty;
        }
        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
            

                if (txtFajrA.Text != "" && txtFajrJ.Text != "" && txtDhuhrA.Text != "" && txtDhuhrJ.Text != "" && txtAsrA.Text != "" && txtAsrJ.Text != "" && txtMagribA.Text != "" && txtMagribJ.Text != "" && txtEishaA.Text != "" && txtEishaJ.Text != "")
                {
                    Prayer prayer = new Prayer();
                    prayer.PrayerDate = Calendar1.SelectedDate.Date;
                    prayer.MosqueID = Convert.ToInt32(Session["MosqueID"]);
                    db.BLL_InsertPrayer(prayer);
                    PrayerType type = new PrayerType();
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
                                BtnAdd.Visible = false;
                                BtnUpdate.Visible = false;
                            }
                            count++;
                        }
                    }
                }
                else
                {
                    if (txtFajrA.Text == "")
                    {
                        txtFajrA.BackColor = Color.Red;
                    }
                    if (txtFajrJ.Text == "")
                    {
                        txtFajrJ.BackColor = Color.Red;
                    }
                    if (txtDhuhrA.Text == "")
                    {
                        txtDhuhrA.BackColor = Color.Red;
                    }
                    if (txtDhuhrJ.Text == "")
                    {
                        txtDhuhrJ.BackColor = Color.Red;
                    }
                    if (txtAsrA.Text == "")
                    {
                        txtAsrA.BackColor = Color.Red;
                    }
                    if (txtAsrJ.Text == "")
                    {
                        txtAsrJ.BackColor = Color.Red;
                    }
                    if (txtMagribA.Text == "")
                    {
                        txtMagribA.BackColor = Color.Red;
                    }
                    if (txtMagribJ.Text == "")
                    {
                        txtMagribJ.BackColor = Color.Red;
                    }
                    if (txtEishaA.Text == "")
                    {
                        txtEishaA.BackColor = Color.Red;
                    }
                    if (txtEishaJ.Text == "")
                    {
                        txtEishaJ.BackColor = Color.Red;
                    }

                }

               
            }

            catch
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Add Unsuccesfull');</script>");
            }

         
        }
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
            

                if (txtFajrA.Text != "" && txtFajrJ.Text != "" && txtDhuhrA.Text != "" && txtDhuhrJ.Text != "" && txtAsrA.Text != "" && txtAsrJ.Text != "" && txtMagribA.Text != "" && txtMagribJ.Text != "" && txtEishaA.Text != "" && txtEishaJ.Text != "")
                {
                    BtnAdd.Visible = false;
                    BtnUpdate.Visible = true;
                    int count = 1;
                    PrayerType type = new PrayerType();

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
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Successfully Updated Prayer Times');</script>");
                            }

                            count++;
                        }
                    }
                }
                else
                {
                    if (txtFajrA.Text == "")
                    {
                        txtFajrA.BackColor = Color.Red;
                    }
                    if (txtFajrJ.Text == "")
                    {
                        txtFajrJ.BackColor = Color.Red;
                    }
                    if (txtDhuhrA.Text == "")
                    {
                        txtDhuhrA.BackColor = Color.Red;
                    }
                    if (txtDhuhrJ.Text == "")
                    {
                        txtDhuhrJ.BackColor = Color.Red;
                    }
                    if (txtAsrA.Text == "")
                    {
                        txtAsrA.BackColor = Color.Red;
                    }
                    if (txtAsrJ.Text == "")
                    {
                        txtAsrJ.BackColor = Color.Red;
                    }
                    if (txtMagribA.Text == "")
                    {
                        txtMagribA.BackColor = Color.Red;
                    }
                    if (txtMagribJ.Text == "")
                    {
                        txtMagribJ.BackColor = Color.Red;
                    }
                    if (txtEishaA.Text == "")
                    {
                        txtEishaA.BackColor = Color.Red;
                    }
                    if (txtEishaJ.Text == "")
                    {
                        txtEishaJ.BackColor = Color.Red;
                    }
                 
                }
            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Update Unsuccesfull');</script>");
            }
        }
        protected void btnAddEvent_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["MosqueID"] != null)
                {

                    if (txtEventTitle.Text != "" && txtEventDescription.Text != "" && txtEventStartTime.Text != "" && txtEventEndTime.Text != "" && txtEventDate.Text != "" && txtSpeaker.Text != "")
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
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Please Enter Required Fields');</script>");
                        if (txtEventTitle.Text == "")
                        {
                            txtEventTitle.BorderColor = Color.Red;
                        }
                        if (txtEventDescription.Text == "")
                        {
                            txtEventDescription.BorderColor = Color.Red;
                        }
                        if (txtEventStartTime.Text == "")
                        {
                            txtEventStartTime.BorderColor = Color.Red;
                        }
                        if (txtEventEndTime.Text == "")
                        {
                            txtEventEndTime.BorderColor = Color.Red;
                        }
                        if (txtEventDate.Text == "")
                        {
                            txtEventDate.BorderColor = Color.Red;
                        }
                        if (txtSpeaker.Text == "")
                        {
                            txtSpeaker.BorderColor = Color.Red;
                        }


                    }
                }

            }
            catch { }



        }
        protected void btnSelectEvent_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            uspGetSpecificEvent events = new uspGetSpecificEvent();
            Session["EventID"] = btn.CommandArgument.ToString();
            events = db.BLL_GetuspGetSpecificEvent(int.Parse(btn.CommandArgument.ToString()));


            if (lblTaskHeader.InnerText.ToString() == "Remove Event")
            {
                divDisplayEditEvent.Visible = false;
                divDisplayDeleteEvent.Visible = true;
                lblEventTitle.InnerText = events.EventTitle;
                lblEventDescription.InnerText = events.EventDescription;
                lblEventStartTime.InnerText = events.EventStartTime;
                lblEventEndTime.InnerText = events.EventEndTime;
                lblEventDate.InnerText = events.EventDate.ToString().Substring(0, 10);
                lblSpeaker.InnerText = lblTaskHeader.InnerText.ToString();
            }
            else if (lblTaskHeader.InnerText.ToString() == "Update Event")
            {
                divDisplayDeleteEvent.Visible = false;
                divDisplayEditEvent.Visible = true;
                txtUpdateEventTitle.Text = events.EventTitle;
                txtUpdateEventDescription.Text = events.EventDescription;
                txtUpdateEventStartTime.Text = events.EventStartTime;
                txtUpdateEventEndTime.Text = events.EventEndTime;
                txtUpdateEventDate.Text = events.EventDate.ToString().Substring(0, 10);
                txtUpdateSpeaker.Text = events.Speaker;
            }


        }
        protected void btnUpdateEvent_Click(object sender, EventArgs e)
        {
            try
            {
                Event events = new Event();
                events.EventTitle = txtUpdateEventTitle.Text.ToString();
                events.EventDescription = txtUpdateEventDescription.Text.ToString();
                events.EventStartTime = txtUpdateEventStartTime.Text.ToString();
                events.EventEndTime = txtUpdateEventEndTime.Text.ToString();
                events.EventDate = Convert.ToDateTime(txtUpdateEventDate.Text.ToString());
                events.Speaker = txtUpdateSpeaker.Text.ToString();
                events.EventID = int.Parse(Session["EventID"].ToString());
                events.MosqueID = int.Parse(Session["MosqueID"].ToString());
                db.BLL_UpdateEvent(events);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Successfully Updated Event');</script>");
                divAddEvent.Visible = false;
                divManageTimes.Visible = false;
                divManageEvent.Visible = true;
                divEventDateSearch.Visible = true;
                divEventOverlay.Visible = false;
                divViewActiveEvents.Visible = false;
                divDisplayEditEvent.Visible = false;
                divDisplayDeleteEvent.Visible = false;

            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Update Event Unsucessfull');</script>");
                divAddEvent.Visible = false;
                divManageTimes.Visible = false;
                divManageEvent.Visible = true;
                divEventDateSearch.Visible = true;
                divEventOverlay.Visible = false;
                divViewActiveEvents.Visible = false;
                divDisplayEditEvent.Visible = false;
                divDisplayDeleteEvent.Visible = false;
            }
        }
        protected void btnRemoveEvent_Click(object sender, EventArgs e)
        {
            try
            {
                Event events = new Event();
                events.EventID = Convert.ToInt32(Session["EventID"].ToString());
                db.BLL_RemoveEvent(events);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Successfully Removed Event');</script>");
                txtStartDate.Text = "";
                txtEndDate.Text = "";
                lblTaskHeader.InnerText = btnNavRemoveEvent.Text.ToString();
                divAddEvent.Visible = false;
                divManageTimes.Visible = false;
                divManageEvent.Visible = true;
                divEventDateSearch.Visible = true;
                divEventOverlay.Visible = false;
                divViewActiveEvents.Visible = false;
                divDisplayEditEvent.Visible = false;
                divDisplayDeleteEvent.Visible = false;
                txtStartDate.Text = "";
                txtEndDate.Text = "";
            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Remove Event Unsucesfull');</script>");
                divAddEvent.Visible = false;
                divManageTimes.Visible = false;
                divManageEvent.Visible = true;
                divEventDateSearch.Visible = true;
                divEventOverlay.Visible = false;
                divViewActiveEvents.Visible = false;
                divDisplayEditEvent.Visible = false;
                divDisplayDeleteEvent.Visible = false;
                txtStartDate.Text = "";
                txtEndDate.Text = "";
            }


        }
        protected void btnNavAddEvent_Click(object sender, EventArgs e)
        {
            lblTaskHeader.InnerText = btnNavAddEvent.Text.ToString();
            divAddEvent.Visible = true;
            divManageTimes.Visible = false;
            divManageEvent.Visible = false;
            txtEventTitle.BorderColor = Color.Empty;
            txtEventDescription.BorderColor = Color.Empty;
            txtEventStartTime.BorderColor = Color.Empty;
            txtEventEndTime.BorderColor = Color.Empty;
            txtEventDate.BorderColor = Color.Empty;
            txtSpeaker.BorderColor = Color.Empty;
            txtEventTitle.Text = "";
            txtEventDescription.Text = "";
            txtEventStartTime.Text = "";
            txtEventEndTime.Text = "";
            txtEventDate.Text = "";
            txtSpeaker.Text = "";



        }
        protected void btnNavEditEvent_Click(object sender, EventArgs e)
        {
            txtStartDate.Text = "";
            txtEndDate.Text = "";
            lblTaskHeader.InnerText = btnNavEditEvent.Text.ToString();
            divAddEvent.Visible = false;
            divManageTimes.Visible = false;
            divManageEvent.Visible = true;
            divEventDateSearch.Visible = true;
            divEventOverlay.Visible = false;
            divViewActiveEvents.Visible = false;
            divDisplayEditEvent.Visible = false;
            divDisplayDeleteEvent.Visible = false;
        }
        protected void btnNavManageTimes_Click(object sender, EventArgs e)
        {
            lblTaskHeader.InnerText = btnNavManageTimes.Text.ToString();
            divAddEvent.Visible = false;
            divManageTimes.Visible = true;
            divManageEvent.Visible = false;
            divCalander.Visible = true;
            divTimes.Visible = false;
        }
        protected void btnEvent_Click(object sender, EventArgs e)
        {

            try
            {
                divEventDateSearch.Visible = true;
                divEventOverlay.Visible = false;
                divViewActiveEvents.Visible = false;
                divDisplayEditEvent.Visible = false;
                divDisplayDeleteEvent.Visible = false;

                DateTime startDate = Convert.ToDateTime(txtStartDate.Text.ToString());
                DateTime EndDate = Convert.ToDateTime(txtEndDate.Text.ToString());
                if (startDate.Date <= EndDate.Date)
                {
                    rptGetEvents.DataSource = db.Bll_GetMosqueEventsDateRange(int.Parse(Session["MosqueID"].ToString()), startDate, EndDate);
                    rptGetEvents.DataBind();
                    if (rptGetEvents.Items.Count > 0)
                    {
                        divViewActiveEvents.Visible = true;
                        divDisplayEditEvent.Visible = false;
                        divDisplayDeleteEvent.Visible = false;
                    }
                    else if (rptGetEvents.Items.Count <= 0)
                    {
                        divViewActiveEvents.Visible = false;
                        divDisplayEditEvent.Visible = false;
                        divDisplayDeleteEvent.Visible = false;
                        lblEventError.InnerText = "No Events Found for Specified Date Range";
                        divEventOverlay.Visible = true;
                    }

                }
                else if (startDate.Date > EndDate.Date)
                {
                    divViewActiveEvents.Visible = false;
                    divDisplayEditEvent.Visible = false;
                    divDisplayDeleteEvent.Visible = false;
                    lblEventError.InnerText = "Invalid Date Range";
                    divEventOverlay.Visible = true;
                }

            }
            catch
            {
                divViewActiveEvents.Visible = false;
                divDisplayEditEvent.Visible = false;
                divDisplayDeleteEvent.Visible = false;
                lblEventError.InnerText = "Please Enter Required Date Fields";
                divEventOverlay.Visible = true;
            }
        }
        protected void btnNavRemoveEvent_Click(object sender, EventArgs e)
        {
            txtStartDate.Text = "";
            txtEndDate.Text = "";
            lblTaskHeader.InnerText = btnNavRemoveEvent.Text.ToString();
            divAddEvent.Visible = false;
            divManageTimes.Visible = false;
            divManageEvent.Visible = true;
            divEventDateSearch.Visible = true;
            divEventOverlay.Visible = false;
            divViewActiveEvents.Visible = false;
            divDisplayEditEvent.Visible = false;
            divDisplayDeleteEvent.Visible = false;
        }


    }
}