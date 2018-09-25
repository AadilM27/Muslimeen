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
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;


namespace Muslimeen.Content.Mosque
{
    public partial class MosqueRep : System.Web.UI.Page
    {
        DBHandler db = new DBHandler();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                divAlertPopup.Visible = false;
                divInfo.Visible = false;
                divDanger.Visible = false;

                DBHandler db = new DBHandler();
                List<CounterCalender> counterCalender = new List<CounterCalender>();

                counterCalender = db.BLL_GetCounterCalender();
                hdfAdjustDate.Value = counterCalender[3].Val.ToString();



                if (Session["UserName"] != null)
                {
                    uspGetMember uspGetMember = new uspGetMember();

                    uspGetMember = db.BLL_GetMember(Convert.ToString(Session["UserName"]));
                    Session["MosqueID"] = uspGetMember.MosqueID.ToString();
                    uspGetMosque mosque = new uspGetMosque();
                    mosque = db.GetMosque(int.Parse(Session["MosqueID"].ToString()));
                    Session["lblMosqueName"] = mosque.MosqueName.ToString();

                    if (uspGetMember.MemberType == 'R')
                    {

                        hplUserProfile.Text = uspGetMember.MemberLastName + ", " + uspGetMember.MemberName;
                        divUserProfile.Visible = true;

                        liMyMusbtn.Visible = true;
                        liMyMusDivi.Visible = true;

                        btnLogin.Text = "Log out";
                        btnRegister.Visible = false;
                    }
                    else
                    {
                        Response.Redirect("../Error.aspx");
                    }
                }
                else if (Session["UserName"] == null)
                {
                    liMyMusbtn.Visible = false;
                    liMyMusDivi.Visible = false;

                    divUserProfile.Visible = false;
                    Session.Clear();
                    Response.Redirect("../../Login/Login.aspx");
                }




                if (!IsPostBack)
                {
                    divAddEvent.Visible = true;
                    lblTaskHeader.InnerText = "Add Event";
                    divAddEventOverlay.Visible = false;
                    divManageTimes.Visible = false;
                    divManageEvent.Visible = false;
                    divPrayerTimes.Visible = false;
                    Session["Event"] = "N";
                    List<uspGetMosqueEvents> list = new List<uspGetMosqueEvents>();
                    list = db.Bll_GetMosqueEvents(int.Parse(Session["MosqueID"].ToString()));
                }
            }
            catch(ArgumentOutOfRangeException)
            {
                Response.Redirect("../Error.aspx");
            }
            catch
            {

            }
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
            Response.Redirect("../Mosque/ListMosque.aspx");
        }
        protected void btnScholars_Click(object sender, EventArgs e)
        {
            Response.Redirect("../ListScholar.aspx");
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
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {

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

            lblDate.Text = Calendar1.SelectedDate.ToShortDateString();
            divTimes.Visible = true;
            uspGetSpecificDayPrayerTimes time = new uspGetSpecificDayPrayerTimes();
            time = db.BLL_GetSpecficDayPrayerTimes(Convert.ToInt32(Session["MosqueID"]), Calendar1.SelectedDate);
            if (time != null)
            {
                divInfo.Visible = true;
                lblInfo.InnerText = "Prayer with selected date contains prayer times. Update Prayer times or select another date";

                this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MosqueRep", "var divpop = document.getElementById('divInfo');divpop.classList.add('visible2')" +
                    ";setTimeout(function Flash3() {divpop.style.display = 'none';}, 6000)", true);

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

        }
        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {



                if (txtFajrA.Text != "" && txtFajrJ.Text != "" && txtDhuhrA.Text != "" && txtDhuhrJ.Text != "" && txtAsrA.Text != "" && txtAsrJ.Text != "" && txtMagribA.Text != "" && txtMagribJ.Text != "" && txtEishaA.Text != "" && txtEishaJ.Text != "")
                {

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
                    bool valid = false;
                    int FajrA = Convert.ToInt32(txtFajrA.Text.ToString().Replace(":", string.Empty));
                    int FajrJ = Convert.ToInt32(txtFajrJ.Text.ToString().Replace(":", string.Empty));
                    int DhuhrA = Convert.ToInt32(txtDhuhrA.Text.ToString().Replace(":", string.Empty));
                    int DhuhrJ = Convert.ToInt32(txtDhuhrJ.Text.ToString().Replace(":", string.Empty));
                    int AsrA = Convert.ToInt32(txtAsrA.Text.ToString().Replace(":", string.Empty));
                    int AsrJ = Convert.ToInt32(txtAsrJ.Text.ToString().Replace(":", string.Empty));
                    int MagribA = Convert.ToInt32(txtMagribA.Text.ToString().Replace(":", string.Empty));
                    int MagribJ = Convert.ToInt32(txtMagribJ.Text.ToString().Replace(":", string.Empty));
                    int EishaA = Convert.ToInt32(txtEishaA.Text.ToString().Replace(":", string.Empty));
                    int EishaJ = Convert.ToInt32(txtEishaJ.Text.ToString().Replace(":", string.Empty));

                    if (FajrA < FajrJ)
                    {
                        txtFajrJ.BorderColor = Color.Empty;
                        if (FajrJ < DhuhrA)
                        {
                            txtDhuhrA.BorderColor = Color.Empty;

                            if (DhuhrA < DhuhrJ)
                            {
                                txtDhuhrJ.BorderColor = Color.Empty;

                                if (DhuhrJ < AsrA)
                                {
                                    txtAsrA.BorderColor = Color.Empty;

                                    if (AsrA < AsrJ)
                                    {
                                        txtAsrJ.BorderColor = Color.Empty;

                                        if (AsrJ < MagribA)
                                        {
                                            txtMagribA.BorderColor = Color.Empty;

                                            if (MagribA < MagribJ)
                                            {
                                                txtMagribJ.BorderColor = Color.Empty;

                                                if (MagribJ < EishaA)
                                                {
                                                    txtEishaA.BorderColor = Color.Empty;

                                                    if (EishaA < EishaJ)
                                                    {
                                                        txtEishaJ.BorderColor = Color.Empty;
                                                        valid = true;
                                                    }
                                                    else
                                                    {
                                                        valid = false;
                                                        txtEishaJ.BorderColor = Color.Red;
                                                    }
                                                }
                                                else
                                                {
                                                    valid = false;
                                                    txtEishaA.BorderColor = Color.Red;
                                                }
                                            }
                                            else
                                            {
                                                valid = false;
                                                txtMagribJ.BorderColor = Color.Red;
                                            }
                                        }
                                        else
                                        {
                                            valid = false;
                                            txtMagribA.BorderColor = Color.Red;
                                        }
                                    }
                                    else
                                    {
                                        valid = false;
                                        txtAsrJ.BorderColor = Color.Red;
                                    }
                                }
                                else
                                {
                                    valid = false;
                                    txtAsrA.BorderColor = Color.Red;
                                }
                            }
                            else
                            {
                                valid = false;
                                txtDhuhrJ.BorderColor = Color.Red;
                            }
                        }
                        else
                        {
                            valid = false;
                            txtDhuhrA.BorderColor = Color.Red;
                        }
                    }
                    else
                    {
                        valid = false;
                        txtFajrJ.BorderColor = Color.Red;
                    }

                    if (valid == true)
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
                                    divAlertPopup.Visible = true;

                                    type.PrayerDate = Calendar1.SelectedDate;
                                    type.MosqueID = Convert.ToInt32(Session["MosqueID"]);
                                    type.PrayerDescription = "Eisha";
                                    type.AdhaanTime = txtEishaA.Text.ToString();
                                    type.JamaatTime = txtEishaJ.Text.ToString();
                                    db.BLL_InsertPrayerType(type);
                                   
                                    lblAlertError.InnerText = "Successfully Added Prayer Times";

                                    this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MosqueRep", "var divpop = document.getElementById('divAlertPopup');divpop.classList.add('visible2')" +
                                        ";setTimeout(function Flash3() {divpop.style.display = 'none';}, 4000)", true);
                                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Successfully Added Prayer Times');</script>");
                                    BtnAdd.Visible = false;
                                    BtnUpdate.Visible = false;
                                }
                                count++;
                            }
                        }
                    }
                }
                else
                {
                    if (txtFajrA.Text == "")
                    {
                        txtFajrA.BorderColor = Color.Red;
                    }
                    else
                        txtFajrA.BorderColor = Color.Empty;
                    if (txtFajrJ.Text == "")
                    {
                        txtFajrJ.BorderColor = Color.Red;
                    }
                    else
                        txtFajrJ.BackColor = Color.Empty;

                    if (txtDhuhrA.Text == "")
                    {
                        txtDhuhrA.BorderColor = Color.Red;
                    }
                    else
                        txtDhuhrA.BorderColor = Color.Empty;

                    if (txtDhuhrJ.Text == "")
                    {
                        txtDhuhrJ.BorderColor = Color.Red;
                    }
                    else
                        txtDhuhrJ.BorderColor = Color.Empty;

                    if (txtAsrA.Text == "")
                    {
                        txtAsrA.BorderColor = Color.Red;
                    }
                    else
                        txtAsrA.BorderColor = Color.Empty;

                    if (txtAsrJ.Text == "")
                    {
                        txtAsrJ.BorderColor = Color.Red;
                    }
                    else
                        txtAsrJ.BorderColor = Color.Empty;

                    if (txtMagribA.Text == "")
                    {
                        txtMagribA.BorderColor = Color.Red;
                    }
                    else
                        txtMagribA.BorderColor = Color.Empty;

                    if (txtMagribJ.Text == "")
                    {
                        txtMagribJ.BorderColor = Color.Red;
                    }
                    else
                        txtMagribJ.BorderColor = Color.Empty;

                    if (txtEishaA.Text == "")
                    {
                        txtEishaA.BorderColor = Color.Red;
                    }
                    else
                        txtEishaA.BorderColor = Color.Empty;

                    if (txtEishaJ.Text == "")
                    {
                        txtEishaJ.BorderColor = Color.Red;
                    }
                    else
                        txtEishaJ.BorderColor = Color.Empty;


                }


            }

            catch (Exception ex)
            {
                divDanger.Visible = true;
                lblDan.InnerText = "Add Unsuccesfull";

                this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MosqueRep", "var divpop = document.getElementById('divDanger');divpop.classList.add('visible2')" +
                    ";setTimeout(function Flash3() {divpop.style.display = 'none';}, 4000)", true);
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Add Unsuccesfull+" + ex + "+');</script>");

            }


        }
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {


                if (txtFajrA.Text != "" && txtFajrJ.Text != "" && txtDhuhrA.Text != "" && txtDhuhrJ.Text != "" && txtAsrA.Text != "" && txtAsrJ.Text != "" && txtMagribA.Text != "" && txtMagribJ.Text != "" && txtEishaA.Text != "" && txtEishaJ.Text != "")
                {
                    bool valid = false;
                    int FajrA = Convert.ToInt32(txtFajrA.Text.ToString().Replace(":", string.Empty));
                    int FajrJ = Convert.ToInt32(txtFajrJ.Text.ToString().Replace(":", string.Empty));
                    int DhuhrA = Convert.ToInt32(txtDhuhrA.Text.ToString().Replace(":", string.Empty));
                    int DhuhrJ = Convert.ToInt32(txtDhuhrJ.Text.ToString().Replace(":", string.Empty));
                    int AsrA = Convert.ToInt32(txtAsrA.Text.ToString().Replace(":", string.Empty));
                    int AsrJ = Convert.ToInt32(txtAsrJ.Text.ToString().Replace(":", string.Empty));
                    int MagribA = Convert.ToInt32(txtMagribA.Text.ToString().Replace(":", string.Empty));
                    int MagribJ = Convert.ToInt32(txtMagribJ.Text.ToString().Replace(":", string.Empty));
                    int EishaA = Convert.ToInt32(txtEishaA.Text.ToString().Replace(":", string.Empty));
                    int EishaJ = Convert.ToInt32(txtEishaJ.Text.ToString().Replace(":", string.Empty));

                    if (FajrA < FajrJ)
                    {
                        txtFajrJ.BorderColor = Color.Empty;
                        if (FajrJ < DhuhrA)
                        {
                            txtDhuhrA.BorderColor = Color.Empty;

                            if (DhuhrA < DhuhrJ)
                            {
                                txtDhuhrJ.BorderColor = Color.Empty;

                                if (DhuhrJ < AsrA)
                                {
                                    txtAsrA.BorderColor = Color.Empty;

                                    if (AsrA < AsrJ)
                                    {
                                        txtAsrJ.BorderColor = Color.Empty;

                                        if (AsrJ < MagribA)
                                        {
                                            txtMagribA.BorderColor = Color.Empty;

                                            if (MagribA < MagribJ)
                                            {
                                                txtMagribJ.BorderColor = Color.Empty;

                                                if (MagribJ < EishaA)
                                                {
                                                    txtEishaA.BorderColor = Color.Empty;

                                                    if (EishaA < EishaJ)
                                                    {
                                                        txtEishaJ.BorderColor = Color.Empty;
                                                        valid = true;
                                                    }
                                                    else
                                                    {
                                                        valid = false;
                                                        txtEishaJ.BorderColor = Color.Red;
                                                    }
                                                }
                                                else
                                                {
                                                    valid = false;
                                                    txtEishaA.BorderColor = Color.Red;
                                                }
                                            }
                                            else
                                            {
                                                valid = false;
                                                txtMagribJ.BorderColor = Color.Red;
                                            }
                                        }
                                        else
                                        {
                                            valid = false;
                                            txtMagribA.BorderColor = Color.Red;
                                        }
                                    }
                                    else
                                    {
                                        valid = false;
                                        txtAsrJ.BorderColor = Color.Red;
                                    }
                                }
                                else
                                {
                                    valid = false;
                                    txtAsrA.BorderColor = Color.Red;
                                }
                            }
                            else
                            {
                                valid = false;
                                txtDhuhrJ.BorderColor = Color.Red;
                            }
                        }
                        else
                        {
                            valid = false;
                            txtDhuhrA.BorderColor = Color.Red;
                        }
                    }
                    else
                    {
                        valid = false;
                        txtFajrJ.BorderColor = Color.Red;
                    }

                    if (valid == true)
                    {
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
                                    divAlertPopup.Visible = true;

                                    type.PrayerDate = Calendar1.SelectedDate;
                                    type.MosqueID = Convert.ToInt32(Session["MosqueID"]);
                                    type.PrayerDescription = "Eisha";
                                    type.AdhaanTime = txtEishaA.Text.ToString();
                                    type.JamaatTime = txtEishaJ.Text.ToString();
                                    db.BLL_UpdatePrayerType(type);
                                    
                                    lblAlertError.InnerText = "Successfully Updated Prayer Times";

                                    this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MosqueRep", "var divpop = document.getElementById('divAlertPopup');divpop.classList.add('visible2')" +
                                        ";setTimeout(function Flash3() {divpop.style.display = 'none';}, 4000)", true);

                                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Successfully Updated Prayer Times');</script>");
                                }

                                count++;
                            }
                        }
                    }
                }
                else
                {
                    if (txtFajrA.Text == "")
                    {
                        txtFajrA.BorderColor = Color.Red;
                    }
                    else
                        txtFajrA.BorderColor = Color.Red;

                    if (txtFajrJ.Text == "")
                    {
                        txtFajrJ.BorderColor = Color.Red;
                    }
                    else
                        txtFajrJ.BorderColor = Color.Red;
                    if (txtDhuhrA.Text == "")
                    {
                        txtDhuhrA.BorderColor = Color.Red;
                    }
                    else
                        txtDhuhrA.BorderColor = Color.Red;
                    if (txtDhuhrJ.Text == "")
                    {
                        txtDhuhrJ.BorderColor = Color.Red;
                    }
                    else
                        txtDhuhrJ.BorderColor = Color.Red;
                    if (txtAsrA.Text == "")
                    {
                        txtAsrA.BorderColor = Color.Red;
                    }
                    else
                        txtAsrA.BorderColor = Color.Red;
                    if (txtAsrJ.Text == "")
                    {
                        txtAsrJ.BorderColor = Color.Red;
                    }
                    else
                        txtAsrJ.BorderColor = Color.Red;
                    if (txtMagribA.Text == "")
                    {
                        txtMagribA.BorderColor = Color.Red;
                    }
                    else
                        txtMagribA.BorderColor = Color.Red;
                    if (txtMagribJ.Text == "")
                    {
                        txtMagribJ.BorderColor = Color.Red;
                    }
                    else
                        txtMagribJ.BorderColor = Color.Red;
                    if (txtEishaA.Text == "")
                    {
                        txtEishaA.BorderColor = Color.Red;
                    }
                    else
                        txtEishaA.BorderColor = Color.Red;
                    if (txtEishaJ.Text == "")
                    {
                        txtEishaJ.BorderColor = Color.Red;
                    }
                    else
                        txtEishaJ.BorderColor = Color.Red;


                }
            }
            catch
            {
                divDanger.Visible = true;

                lblDan.InnerText = "Update Unsuccesfull";

                this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MosqueRep", "var divpop = document.getElementById('divDanger');divpop.classList.add('visible2')" +
                    ";setTimeout(function Flash3() {divpop.style.display = 'none';}, 4000)", true);

                //Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Update Unsuccesfull');</script>");
            }
        }
        protected void btnAddEvent_Click(object sender, EventArgs e)
        {
            try
            {

                if (Session["MosqueID"] != null)
                {

                    if (txtEventTitle.Text.Replace(" ", "") != "" && txtEventDescription.Text.Replace(" ", "") != "" && txtEventStartTime.Text.Replace(" ", "") != "" && txtEventEndTime.Text.Replace(" ", "") != "" && txtEventDate.Text.Replace(" ", "") != "" && txtSpeaker.Text.Replace(" ", "") != "")
                    {
                        divAlertPopup.Visible = true;
                        divAddEventOverlay.Visible = false;
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

                        lblAlertError.InnerText = "Successfully Added an Event";

                        this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MosqueRep", "var divpop = document.getElementById('divAlertPopup');divpop.classList.add('visible2')" +
                            ";setTimeout(function Flash3() {divpop.style.display = 'none';}, 4000)", true);
                    }
                    else
                    {
                        divAddEventOverlay.Visible = true;
                        lblAddEventOverlay.InnerText = "Please Enter Required Fields";
                        if (txtEventTitle.Text.Replace(" ", "") == "")
                        {
                            txtEventTitle.BorderColor = Color.Red;
                        }
                        else
                            txtEventTitle.BorderColor = Color.Empty;
                        if (txtEventDescription.Text.Replace(" ", "") == "")
                        {
                            txtEventDescription.BorderColor = Color.Red;
                        }
                        else
                            txtEventDescription.BorderColor = Color.Empty;
                        if (txtEventStartTime.Text.Replace(" ", "") == "")
                        {
                            txtEventStartTime.BorderColor = Color.Red;
                        }
                        else
                            txtEventStartTime.BorderColor = Color.Empty;
                        if (txtEventEndTime.Text.Replace(" ", "") == "")
                        {
                            txtEventEndTime.BorderColor = Color.Red;
                        }
                        else
                            txtEventEndTime.BorderColor = Color.Empty;
                        if (txtEventDate.Text.Replace(" ", "") == "")
                        {
                            txtEventDate.BorderColor = Color.Red;
                        }
                        else
                            txtEventDate.BorderColor = Color.Empty;
                        if (txtSpeaker.Text.Replace(" ", "") == "")
                        {
                            txtSpeaker.BorderColor = Color.Red;
                        }
                        else
                            txtSpeaker.BorderColor = Color.Empty;


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
                txtUpdateEventTitle.BorderColor = Color.Empty;
                txtUpdateEventDescription.BorderColor = Color.Empty;
                txtUpdateEventStartTime.BorderColor = Color.Empty;
                txtUpdateEventEndTime.BorderColor = Color.Empty;
                txtUpdateEventDate.BorderColor = Color.Empty;
                txtUpdateSpeaker.BorderColor = Color.Empty;


            }


        }
        protected void btnUpdateEvent_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUpdateEventDate.Text != "" && txtUpdateEventTitle.Text != "" && txtUpdateEventDescription.Text != "" && txtUpdateEventStartTime.Text != "" && txtUpdateEventEndTime.Text != "" && txtUpdateSpeaker.Text != "")
                {
                    divAlertPopup.Visible = true;
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
                    DateTime startDate = Convert.ToDateTime(txtStartDate.Text.ToString());
                    DateTime EndDate = Convert.ToDateTime(txtEndDate.Text.ToString());

                    lblAlertError.InnerText = "Successfully Updated an Event";

                    this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MosqueRep", "var divpop = document.getElementById('divAlertPopup');divpop.classList.add('visible2')" +
                        ";setTimeout(function Flash3() {divpop.style.display = 'none';}, 4000)", true);

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

                    divAddEvent.Visible = false;
                    divManageTimes.Visible = false;
                    divManageEvent.Visible = true;
                    divEventDateSearch.Visible = true;
                    divEventOverlay.Visible = false;
                    divViewActiveEvents.Visible =true;
                    divDisplayEditEvent.Visible = false;
                    divDisplayDeleteEvent.Visible = false;
                }
                else
                {
                    divDanger.Visible = true;

                    lblDan.InnerText = "Please Enter Required Fields";

                    this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MosqueRep", "var divpop = document.getElementById('divDanger');divpop.classList.add('visible2')" +
                        ";setTimeout(function Flash3() {divpop.style.display = 'none';}, 4000)", true);

                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Please Enter Required Fields');</script>");
                    if (txtUpdateEventTitle.Text == "")
                    {
                        txtUpdateEventTitle.BorderColor = Color.Red;
                    }
                    else
                        txtUpdateEventTitle.BorderColor = Color.Empty;
                    if (txtUpdateEventDescription.Text == "")
                    {
                        txtUpdateEventDescription.BorderColor = Color.Red;
                    }
                    else
                        txtUpdateEventDescription.BorderColor = Color.Empty;
                    if (txtUpdateEventStartTime.Text == "")
                    {
                        txtUpdateEventStartTime.BorderColor = Color.Red;
                    }
                    else
                        txtUpdateEventStartTime.BorderColor = Color.Empty;
                    if (txtUpdateEventEndTime.Text == "")
                    {
                        txtUpdateEventEndTime.BorderColor = Color.Red;
                    }
                    else
                        txtUpdateEventEndTime.BorderColor = Color.Empty;
                    if (txtUpdateEventDate.Text == "")
                    {
                        txtUpdateEventDate.BorderColor = Color.Red;
                    }
                    else
                        txtUpdateEventDate.BorderColor = Color.Empty;
                    if (txtUpdateSpeaker.Text == "")
                    {
                        txtUpdateSpeaker.BorderColor = Color.Red;
                    }
                    else
                        txtUpdateSpeaker.BorderColor = Color.Empty;
                }

            }
            catch
            {
                divDanger.Visible = true;

                lblDan.InnerText = "Update Event Unsuccessfull";

                this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MosqueRep", "var divpop = document.getElementById('divDanger');divpop.classList.add('visible2')" +
                    ";setTimeout(function Flash3() {divpop.style.display = 'none';}, 4000)", true);

                //Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Update Event Unsuccessfull');</script>");
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
                divAlertPopup.Visible = true;

                Event events = new Event();
                events.EventID = Convert.ToInt32(Session["EventID"].ToString());
                db.BLL_RemoveEvent(events);
                
                lblAlertError.InnerText = "Successfully Removed Event";

                this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MosqueRep", "var divpop = document.getElementById('divAlertPopup');divpop.classList.add('visible2')" +
                    ";setTimeout(function Flash3() {divpop.style.display = 'none';}, 4000)", true);

                //Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Successfully Removed Event');</script>");
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
                divPrayerTimes.Visible = false;
                txtStartDate.Text = "";
                txtEndDate.Text = "";
            }
            catch
            {
                divDanger.Visible = true;

                lblDan.InnerText = "Remove Event Unsuccesfull";

                this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MosqueRep", "var divpop = document.getElementById('divDanger');divpop.classList.add('visible2')" +
                    ";setTimeout(function Flash3() {divpop.style.display = 'none';}, 4000)", true);

                //Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Remove Event Unsucesfull');</script>");
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
            divPrayerTimes.Visible = false;
            divAddEventOverlay.Visible = false;
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
            divPrayerTimes.Visible = false;

        }
        protected void btnNavManageTimes_Click(object sender, EventArgs e)
        {
            lblTaskHeader.InnerText = btnNavManageTimes.Text.ToString();
            divAddEvent.Visible = false;
            divManageTimes.Visible = true;
            divManageEvent.Visible = false;
            divCalander.Visible = true;
            divTimes.Visible = false;
            divPrayerTimes.Visible = false;

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
            divPrayerTimes.Visible = false;

        }
        protected void btnNavSalahTimes_Click(object sender, EventArgs e)
        {
            lblTaskHeader.InnerText = btnNavSalahTimes.Text.ToString();
            divAddEvent.Visible = false;
            divManageTimes.Visible = false;
            divManageEvent.Visible = false;
            divEventDateSearch.Visible = false;
            divEventOverlay.Visible = false;
            divViewActiveEvents.Visible = false;
            divDisplayEditEvent.Visible = false;
            divDisplayDeleteEvent.Visible = false;
            divPrayerTimes.Visible = true;
            divPrayerTable.Visible = false;
            divPrayerOverlay.Visible = false;
            divgrid.Visible = false;
            txtPrayerStartDate.Text = "";
            txtPrayerEndDate.Text = "";
        }
        protected void btnListPrayer_Click(object sender, EventArgs e)
        {
            try
            {

                DateTime startDate = Convert.ToDateTime(txtPrayerStartDate.Text.ToString());
                DateTime endDate = Convert.ToDateTime(txtPrayerEndDate.Text.ToString());

                if (startDate.Date <= endDate.Date)
                {

                    List<uspGetMosquePrayerTimes> list = new List<uspGetMosquePrayerTimes>();
                    List<uspGetSpecificDayPrayerTimes> times = new List<uspGetSpecificDayPrayerTimes>();
                    list = db.BLL_GetMosquePrayerTimes(int.Parse(Session["MosqueID"].ToString()), startDate, endDate);
                    int count = 0;

                    uspGetSpecificDayPrayerTimes pt = new uspGetSpecificDayPrayerTimes();

                    foreach (uspGetMosquePrayerTimes prayer in list)
                    {

                        if (count == 0)
                        {


                            pt.PrayerDate = prayer.PrayerDate.Date;
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
                    grdReports.DataSource = times;
                    grdReports.DataBind();
                    if (rptPrayerTimes.Items.Count > 0)
                    {
                        divPrayerTable.Visible = true;
                        divPrayerOverlay.Visible = false;
                    }
                    else if (rptPrayerTimes.Items.Count <= 0)
                    {
                        divPrayerOverlay.Visible = true;
                        divPrayerTable.Visible = false;
                        lblPrayerError.InnerText = "No Prayer Times Found For Date Range";

                    }

                }

                else if (startDate.Date > endDate.Date)
                {
                    lblPrayerError.InnerText = "Invalid Date Range";
                    divPrayerOverlay.Visible = true;
                    divPrayerTable.Visible = false;

                }
            }
            catch
            {
                lblPrayerError.InnerText = "Please Enter Required Date Range Fields";
                divPrayerOverlay.Visible = true;
                divPrayerTable.Visible = false;

            }


        }
        protected void PDF_ServerClick(object sender, EventArgs e)
        {

            for (int i = 0; i < grdReports.Rows.Count; i++)
            {
                DateTime DOB = Convert.ToDateTime(grdReports.Rows[i].Cells[0].Text);
                grdReports.Rows[i].Cells[0].Text = DOB.ToString("dd MMM yyyy");

            }

            PdfPTable pdfTable = new PdfPTable(grdReports.HeaderRow.Cells.Count);
            pdfTable.HorizontalAlignment = 0;
            grdReports.HeaderRow.Cells[0].Text = "Date";
            grdReports.HeaderRow.Cells[1].Text = "Day";
            grdReports.HeaderRow.Cells[2].Text = "Fajr Adhaan";
            grdReports.HeaderRow.Cells[3].Text = "Fajr Jamaat";
            grdReports.HeaderRow.Cells[4].Text = "Dhuhr Adhaan";
            grdReports.HeaderRow.Cells[5].Text = "Dhuhr Jamaat ";
            grdReports.HeaderRow.Cells[6].Text = "Asr Adhaan";
            grdReports.HeaderRow.Cells[7].Text = "Asr Jamaat ";
            grdReports.HeaderRow.Cells[8].Text = "Magrib Adhaan";
            grdReports.HeaderRow.Cells[9].Text = "Magrib Jamaat ";
            grdReports.HeaderRow.Cells[10].Text = "Eisha Adhaan";
            grdReports.HeaderRow.Cells[11].Text = "Eisha Jamaat";
            foreach (TableCell Headercell in grdReports.HeaderRow.Cells)
            {
                iTextSharp.text.Font font = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 11, iTextSharp.text.Font.BOLD);
                font.Color = new BaseColor(grdReports.HeaderStyle.ForeColor);

                PdfPCell pdfCell = new PdfPCell(new Phrase(Headercell.Text, font));
                pdfCell.HorizontalAlignment = 1;
                pdfCell.Padding = 5;
                pdfCell.BackgroundColor = new BaseColor(grdReports.HeaderStyle.BackColor);
                pdfTable.AddCell(pdfCell);
            }


            foreach (GridViewRow gridviewrow in grdReports.Rows)
            {
                foreach (TableCell tablecell in gridviewrow.Cells)
                {
                    iTextSharp.text.Font font = new iTextSharp.text.Font();
                    font.Color = new BaseColor(grdReports.RowStyle.ForeColor);
                    iTextSharp.text.Font content = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.BOLD);
                    PdfPCell pdfcell = new PdfPCell(new Phrase(tablecell.Text, content));
                    pdfcell.HorizontalAlignment = 1;
                    pdfcell.VerticalAlignment = 2;
                    pdfcell.BackgroundColor = new BaseColor(grdReports.RowStyle.BackColor);
                    pdfTable.AddCell(pdfcell);
                }
            }

            Document pdfDocument = new Document(new RectangleReadOnly(842, 595), 10f, -200f, 10f, 0f);
            // Document pdfDocument = new Document(new RectangleReadOnly(842, 595), widthstart, cell width, heightstart);
            PdfAWriter.GetInstance(pdfDocument, Response.OutputStream);

            PdfPTable table = new PdfPTable(1);
            PdfPTable table2 = new PdfPTable(2);

            iTextSharp.text.Font fontH2 = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.BOLD);
            table2.WidthPercentage = 80;
            table2.HorizontalAlignment = 0;
            table2.DefaultCell.Padding = 8;
            table2.DefaultCell.HorizontalAlignment = 1;
            table2.DefaultCell.VerticalAlignment = 1;
            Paragraph date = new Paragraph("Selected Date Range: " + Convert.ToDateTime(txtPrayerStartDate.Text).ToString("dd MMM yyyy") + " to " + Convert.ToDateTime(txtPrayerEndDate.Text).ToString("dd MMM yyyy"), fontH2);
            Paragraph extraPara = new Paragraph("Date Created: " + DateTime.Now.Date.ToString("dd MMM yyyy"), fontH2);

            table2.AddCell(date);
            table2.AddCell(extraPara);

            iTextSharp.text.Font fontH1 = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 24, iTextSharp.text.Font.BOLD);
            table.WidthPercentage = 80;
            table.HorizontalAlignment = 0;
            table.DefaultCell.Padding = 20;
            table.DefaultCell.HorizontalAlignment = 1;
            table.DefaultCell.VerticalAlignment = 1;
            Paragraph para = new Paragraph("Salah Time Table For " + Session["lblMosqueName"].ToString(), fontH1);
            table.AddCell(para);

            pdfDocument.Open();
            pdfDocument.AddTitle("Prayer Time Table");
            pdfDocument.Add(table);
            pdfDocument.Add(table2);
            pdfDocument.Add(pdfTable);
            pdfDocument.Close();

            Response.ContentType = "application/pdf";
            Response.AppendHeader("content-disposition", "attachment;filename=PrayerTimeTable.pdf");
            Response.Write(pdfDocument);
            Response.Flush();
            Response.End();




        }

    }
}