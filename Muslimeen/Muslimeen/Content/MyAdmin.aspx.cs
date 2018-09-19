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
    public partial class MyAdmin : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Context.Response.Cache.SetCacheability(HttpCacheability.NoCache);

            try
            {

                divListEvent.Visible = false;
                divEventOverlay.Visible = false;
                divDisplayEvents.Visible = false;
                divEvent.Visible = false;
                divListEventDetails.Visible = false;
                divDisplaySalahTimetable.Visible = false;
                divAddAdmin.Visible = false;
                divAdminReports.Visible = false;
                divAllMembersList.Visible = false;
                divMemberDetails.Visible = false;
                divMemberDetailsOverlay.Visible = false;
                divUpdateMosqueOverlay.Visible = false;
                divMosqueList.Visible = false;
                divUpdateMosque.Visible = false;
                divOrgImg.Visible = false;
                divCounterCalander.Visible = false;
                divNoticeOverlay.Visible = false;
                divOrgOverlay.Visible = false;
                divAddUpdateNotice.Visible = false;
                divNoticeList.Visible = false;
                divZakaahOrgList.Visible = false;
                divAddUpdateZakaahOrg.Visible = false;
                divViewPendingSch.Visible = false;
                divDisplaySch.Visible = false;
                divSchDetails.Visible = false;
                divSchDetailsOverlay.Visible = false;
                divAddMosque.Visible = false;
                divViewPendingSch.Visible = false;
                divAddMosque.Visible = false;
                divAddMosqueRep.Visible = false;
                divAddMod.Visible = false;
                ddModQualification.Items.Clear();
                ddModQualification.Dispose();

                //Collapsing of the dropdown list...
                if (IsPostBack)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>if(divReports.classList.contains('collapsing')){divReports.classList.remove('collapsing');} else{divReports.classList.add('collapsing');}</script>");
                }

                DBHandler dBHandler = new DBHandler();
                DBHandler db = new DBHandler();
                List<CounterCalender> counterCalender = new List<CounterCalender>();

                counterCalender = db.BLL_GetCounterCalender();
                hdfAdjustDate.Value = counterCalender[3].Val.ToString();


                if (Session["UserName"] != null)
                {
                    uspGetMember uspGetMember = new uspGetMember();
                    uspGetMember = dBHandler.BLL_GetMember(Convert.ToString(Session["UserName"]));

                    if (uspGetMember.MemberType == 'A')
                    {

                        hplUserProfile.Text = uspGetMember.MemberLastName + ", " + uspGetMember.MemberName;
                        divUserProfile.Visible = true;

                        liMyMusbtn.Visible = true;
                        liMyMusDivi.Visible = true;

                        btnLogin.Text = "Log out";
                        btnRegister.Visible = false;

                        List<uspGetQualification> list = dBHandler.BLL_GetQualification();

                        foreach (uspGetQualification qual in list)
                        {
                            ddModQualification.Items.Add(new System.Web.UI.WebControls.ListItem(qual.QualificationDescription.ToString(),
                                qual.QualificationID.ToString()));
                        }

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
                    Response.Redirect("../Login/Login.aspx");
                }

                divDisplaySch.Visible = false;
            }
            catch
            {

            }
        }


        protected void btnViewPendingSch_Click(object sender, EventArgs e)
        {
            try
            {
                divDisplaySch.Visible = false;
                divSchDetailsOverlay.Visible = true;
                divViewPendingSch.Visible = true;

                lblTaskHead.InnerText = btnViewPendingSch.Text.ToString();
                DBHandler dBHandler = new DBHandler();

                rptViewPendingSch.DataSource = dBHandler.BLL_GetAllPendingScholars();
                rptViewPendingSch.DataBind();
            }
            catch
            {

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
                switch (scholarDetails.MemberType.ToString())
                {
                    case "S":
                        lblMemberType.InnerText = "Scholar";
                        break;
                }
                lblEmail.InnerText = scholarDetails.Email.ToString();
                lblContactNo.InnerText = scholarDetails.ContactNo.ToString();
                lblActivationExpiry.InnerText = scholarDetails.ActivationExpiry.ToString("dd MM yyyy");
                lblActivationDate.InnerText = scholarDetails.ActivationDate.ToString("dd MM yyyy");
                lblScholarQual.InnerText = scholarDetails.QualificationDescription.ToString();

                divViewPendingSch.Visible = true;
                divDisplaySch.Visible = true;
                divSchDetails.Visible = true;

            }
            catch
            {

            }

        }

        protected void btnAcceptReg_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdfSchId.Value != null)
                {

                    DBHandler db = new DBHandler();
                    uspVerifyMember uspVerifyMember = new uspVerifyMember();

                    string memberId = hdfSchId.Value.ToString();

                    uspVerifyMember.MemberID = memberId;
                    bool verifySchSuccess = db.BLL_VerifyMember(uspVerifyMember);

                    if (verifySchSuccess == true)
                    {
                        //Sends an email informing the scholar that his registration has be accepted.
                        EmailService email = new EmailService();
                        uspGetMember member = new uspGetMember();
                        member = db.BLL_GetMember(hdfSchId.Value.ToString());

                        email.AutoEmailService(member.Email, "null", "null", "AcceptedScholars", member.MemberID.ToString(), "null");

                        //Help with keeping selected task open.
                        divViewPendingSch.Visible = true;
                        divDisplaySch.Visible = false;
                        divSchDetailsOverlay.Visible = true;

                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Scripts", "<script>alert('Scholar Registration accepted.');</script>");

                        rptViewPendingSch.DataSource = db.BLL_GetAllPendingScholars();
                        rptViewPendingSch.DataBind();
                    }
                    else
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Scripts", "<script>alert('Scholar Registration rejected.');</script>");
                    }
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Scripts", "<script>alert('Failed to perform action, please try again.');</script>");
                    divViewPendingSch.Visible = false;
                    divDisplaySch.Visible = false;
                    divSchDetails.Visible = false;

                }
            }
            catch
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Scripts", "<script>alert('Failed to perform action, please try again.');</script>");
            }
        }

        protected void btnRejectReg_Click(object sender, EventArgs e)
        {
            try
            {
                DBHandler db = new DBHandler();
                uspRejectReg rejectReg = new uspRejectReg();

                rejectReg.MemberID = hdfSchId.Value.ToString();
                bool rejectSchReg = db.BLL_RejectReg(rejectReg);

                if (rejectSchReg == true)
                {
                    EmailService email = new EmailService();
                    uspGetMember member = new uspGetMember();
                    member = db.BLL_GetMember(hdfSchId.Value.ToString());

                    email.AutoEmailService(member.Email, "null", "null", "RejectedScholars", member.MemberID.ToString(), "null");

                    divViewPendingSch.Visible = true;
                    divDisplaySch.Visible = false;
                    divSchDetailsOverlay.Visible = true;

                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Scripts", "<script>alert('Scholar registration rejected.');</script>");

                    rptViewPendingSch.DataSource = db.BLL_GetAllPendingScholars();
                    rptViewPendingSch.DataBind();
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Scripts", "<script>alert('Scholar registration rejection failed.');</script>");
                    divViewPendingSch.Visible = false;
                    divDisplaySch.Visible = false;
                    divSchDetails.Visible = false;
                }
            }
            catch
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Scripts", "<script>alert('Failed to perform action, please try again.');</script>");
                divViewPendingSch.Visible = false;
                divDisplaySch.Visible = false;
                divSchDetails.Visible = false;
            }
        }

        protected void rptViewPendingSch_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void btnAddMosque_Click(object sender, EventArgs e)
        {
            try
            {
                divAddMosque.Visible = true;
                divAddMosqueRep.Visible = true;
                ddMosqueActive.SelectedValue = "Y";
                ddMosqueActive.Enabled = false;
                lblTaskHead.InnerText = btnAddMosque.Text.ToString();
            }
            catch
            {

            }
        }

        protected void btnRegMosque_Click(object sender, EventArgs e)
        {
            divAddMosque.Visible = true;
            divAddMosqueRep.Visible = true;

            txtUserName.BorderColor = Color.Empty;
            txtName.BorderColor = Color.Empty;
            txtLName.BorderColor = Color.Empty;
            txtDOB.BorderColor = Color.Empty;
            txtUserEmail.BorderColor = Color.Empty;
            txtPassword.BorderColor = Color.Empty;
            txtRetypePassword.BorderColor = Color.Empty;
            txtMosqueName.BorderColor = Color.Empty;
            txtMosqueAddr.BorderColor = Color.Empty;
            txtMosqueSuburb.BorderColor = Color.Empty;
            txtMosqueQuote.BorderColor = Color.Empty;
            lblError.Text = "";


            try
            {
                DBHandler db = new DBHandler();
                Encryption encryption = new Encryption();
                uspAddMosque addMosque = new uspAddMosque();
                EmailService emailService = new EmailService();

                int continueProcess = 0;

                if (txtPassword.Text.ToString() != txtRetypePassword.Text.ToString() ||
                    txtPassword.Text == null || txtRetypePassword == null)
                {
                    txtRetypePassword.BorderColor = Color.Red;
                    txtPassword.BorderColor = Color.Red;
                    lblError.Text = "Passwords do not match";
                    lblError.ForeColor = Color.Red;
                    continueProcess += 1;
                }
                else if (txtUserName.Text == "" || txtUserName.Text == null)
                {
                    txtUserName.BorderColor = Color.Red;
                    lblError.Text = "User name field can not be empty";
                    lblError.ForeColor = Color.Red;
                    continueProcess += 1;
                }
                else if (txtUserName.Text.Length > 15 || txtUserName.Text.Length < 5 || txtUserName.Text == "")
                {
                    txtUserName.BackColor = Color.Red;
                    lblError.Text = "User Name is too long or too short";
                    lblError.ForeColor = Color.Red;
                    continueProcess += 1;
                }
                else if (txtUserName.Text != "" || txtUserName.Text != null)
                {
                    try
                    {
                        if (db.BLL_GetMember(txtUserName.Text.ToString()) != null)
                        {
                            lblError.Text = "User Name taken, Please retype a new one";
                            txtUserName.BorderColor = Color.Red;
                            lblError.ForeColor = Color.Red;
                            continueProcess += 1;
                        }
                    }
                    catch (Exception ex)
                    {
                        txtUserName.BorderColor = Color.Red;
                        lblError.Text = ex.Message;
                        lblError.ForeColor = Color.Red;
                        continueProcess += 1;
                    }
                }

                if (lblError.Text == "" || lblError.Text == null)
                {
                    if (txtMosqueName.Text == "" || txtMosqueName.Text == null)
                    {
                        txtMosqueName.BorderColor = Color.Red;
                        continueProcess += 1;
                    }
                    else if (txtMosqueAddr.Text == "" || txtMosqueAddr.Text == null)
                    {
                        txtMosqueAddr.BorderColor = Color.Red;
                        continueProcess += 1;
                    }
                    else if (txtMosqueSuburb.Text == "" || txtMosqueSuburb.Text == null)
                    {
                        txtMosqueSuburb.BorderColor = Color.Red;
                        continueProcess += 1;
                    }
                    else if (ddMosqueType.SelectedIndex == 0)
                    {
                        ddMosqueType.BorderColor = Color.Red;
                        continueProcess += 1;
                    }
                    else if (txtMosqueEstab.Text == "dd --- yyyy")
                    {
                        txtMosqueEstab.BorderColor = Color.Red;
                        continueProcess += 1;
                    }
                    else if (ddMosqueSize.SelectedIndex == 0)
                    {
                        ddMosqueSize.BorderColor = Color.Red;
                        continueProcess += 1;
                    }
                    else if (txtName.Text == "" || txtName.Text == null)
                    {
                        txtName.BorderColor = Color.Red;
                        continueProcess += 1;
                    }
                    else if (txtLName.Text == "" || txtLName.Text == null)
                    {
                        txtLName.BorderColor = Color.Red;
                        continueProcess += 1;
                    }
                    else if (txtDOB.Text == "" || txtDOB == null)
                    {
                        txtDOB.BorderColor = Color.Red;
                        continueProcess += 1;
                    }
                    else if (txtDOB.Text.Length > 10 || txtDOB.Text.Length < 10)
                    {
                        txtDOB.BorderColor = Color.Red;
                        continueProcess += 1;
                        lblError.Text = "Please follow the format: yyyy-mm-dd";
                        lblError.ForeColor = Color.Red;
                    }
                    else if (txtUserEmail.Text == "" || txtUserEmail == null)
                    {
                        txtUserEmail.BorderColor = Color.Red;
                        lblError.Text = "Please enter your Email address";
                        lblError.ForeColor = Color.Red;
                        continueProcess += 1;
                    }
                    else if (ddMosqueType.SelectedValue == "None")
                    {
                        ddMosqueType.BorderColor = Color.Red;
                        continueProcess += 1;
                    }
                    else if (ddMosqueSize.SelectedValue == "None")
                    {
                        ddMosqueSize.BorderColor = Color.Red;
                        continueProcess += 1;
                        lblError.Text = "Registration type not selected";
                        lblError.ForeColor = Color.Red;
                    }
                    else if (txtPassword.Text == null || txtPassword.Text == "")
                    {
                        lblError.Text = "Please create a Password";
                        lblError.ForeColor = Color.Red;
                        continueProcess += 1;
                        txtPassword.BorderColor = Color.Red;
                    }
                    else if (txtRetypePassword.Text == null || txtRetypePassword.Text == "")
                    {
                        lblError.Text = "Please retype your Password";
                        lblError.ForeColor = Color.Red;
                        continueProcess += 1;
                        txtRetypePassword.BorderColor = Color.Red;
                    }
                    else if (txtContactNum.Text.Length > 10 || txtContactNum.Text.Length < 10)
                    {
                        if (txtContactNum.Text.Length != 0)
                        {
                            lblError.Text = "Please enter a correct contact number";
                            lblError.ForeColor = Color.Red;
                            continueProcess += 1;
                            txtContactNum.BorderColor = Color.Red;
                        }
                    }
                    else if (ddMosqueActive.SelectedValue == "None")
                    {
                        lblError.Text = "Mosque has to be either Yes or No";
                        lblError.ForeColor = Color.Red;
                        continueProcess += 1;
                        ddMosqueActive.BorderColor = Color.Red;
                    }
                    if (fupMosqueImage.HasFile)
                    {
                        string fileName = fupMosqueImage.FileName.ToString();
                        string fileFormat = fileName.Substring(fileName.Length - 3);
                        switch (fileFormat)
                        {
                            case "png":
                            case "jpg":
                            case "gif":
                            case "bmp":
                                break;
                            default:
                                continueProcess += 1;
                                lblError.Text = "The file Uploaded is not of the correct format.";
                                lblError.ForeColor = Color.Red;
                                break;
                        }
                    }
                }



                if (continueProcess == 0)
                {
                    string encryptedString = encryption.Encrypt(txtUserName.Text.ToString(),
                        Convert.ToString(txtPassword.Text.ToString()));

                    addMosque.MemberID = txtUserName.Text.ToString();
                    addMosque.MemberName = txtName.Text.ToString();
                    addMosque.MemberLastName = txtLName.Text.ToString();
                    addMosque.ContactNo = txtContactNum.Text.ToString();
                    string DOB = Convert.ToDateTime(txtDOB.Text.ToString()).ToString("yyyy-MM-dd");
                    addMosque.MemberDOB = Convert.ToDateTime(DOB);
                    addMosque.Email = txtUserEmail.Text.ToString();
                    addMosque.MemberType = 'R';
                    addMosque.ActiveTypeID = 'Y';
                    addMosque.ActivationDate = DateTime.Today.Date;
                    addMosque.Password = encryptedString; //password encrypted

                    addMosque.MosqueName = txtMosqueName.Text.ToString();
                    addMosque.MosqueStreet = txtMosqueAddr.Text.ToString();
                    addMosque.MosqueSuburb = txtMosqueSuburb.Text.ToString();
                    addMosque.MosqueType = ddMosqueType.SelectedValue.ToString();
                    if (fupMosqueImage.HasFile)//Add Image save to directory and path to DB.
                    {
                        string fileName = fupMosqueImage.FileName.ToString();
                        string fileFormat = fileName.Substring(fileName.Length - 3); //get last character of Image name.

                        fupMosqueImage.SaveAs(Server.MapPath("Images/MosqueImages/") + txtMosqueName.Text.ToString().ToString() + "." + fileFormat.ToString()); //Image to upload ...

                        addMosque.MosqueImage = ("Images/MosqueImages/" + txtMosqueName.Text.ToString() + "." + fileFormat.ToString());
                    }
                    else
                    {
                        addMosque.MosqueImage = "Images/ImageUnavailable.jpg";
                    }
                    addMosque.MosqueSize = ddMosqueSize.SelectedValue.ToString();
                    addMosque.MosqueQuote = txtMosqueQuote.Text.ToString();
                    string yearEstablished = Convert.ToDateTime(txtMosqueEstab.Text).ToString("yyyy-MM-dd");
                    addMosque.YearEstablished = Convert.ToDateTime(yearEstablished);
                    addMosque.Active = 'Y';

                    bool success = db.BLL_AddMosque(addMosque); // if true mosque has been added.

                    if (success == true)
                    {
                        emailService.AddMosque(txtUserName.Text.ToString(), (txtName.Text.ToString() + " " + txtLName.Text.ToString()), txtMosqueName.Text.ToString(), txtPassword.Text.ToString(), txtUserEmail.Text.ToString());
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Scripts", "<script>alert('Mosque has been succesfully added.');</script>");
                        divAddMosque.Visible = false;
                        divAddMosqueRep.Visible = false;
                        
                        //Clear the textboxes.
                        txtUserName.Text = string.Empty;
                        txtName.Text = string.Empty;
                        txtLName.Text = string.Empty;
                        txtContactNum.Text = string.Empty;
                        txtDOB.Text = string.Empty;
                        txtUserEmail.Text = string.Empty;
                        txtPassword.Text = string.Empty;
                        txtRetypePassword.Text = string.Empty;

                        txtMosqueName.Text = string.Empty;
                        txtMosqueAddr.Text = string.Empty;
                        txtMosqueSuburb.Text = string.Empty;
                        ddMosqueType.SelectedIndex = 0;
                        txtMosqueEstab.Text = "";
                        ddMosqueSize.SelectedIndex = 0;
                        txtMosqueQuote.Text = string.Empty;
                        fupMosqueImage.Attributes.Clear();

                        btnTodaysPrayerTime_Click(sender, e);
                    }
                    else
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Scripts", "<script>alert('Mosque registration was unsuccessful, please try again.');</script>");
                    }
                }
                else if (lblError.Text == "")
                {
                    lblError.Text = "Registration Unsuccessful, Incomplete form";
                    lblError.ForeColor = Color.Red;
                }
            }
            catch
            {

            }
        }

        protected void btnCancelMosqueReg_Click(object sender, EventArgs e)
        {
            try
            {
                //keep the two displayed after clicking cancel.
                divAddMosque.Visible = true;
                divAddMosqueRep.Visible = true;

                txtUserName.Text = string.Empty;
                txtName.Text = string.Empty;
                txtLName.Text = string.Empty;
                txtContactNum.Text = string.Empty;
                txtDOB.Text = string.Empty;
                txtUserEmail.Text = string.Empty;
                txtPassword.Text = string.Empty;
                txtRetypePassword.Text = string.Empty;

                txtMosqueName.Text = string.Empty;
                txtMosqueAddr.Text = string.Empty;
                txtMosqueSuburb.Text = string.Empty;
                ddMosqueType.SelectedIndex = 0;
                txtMosqueEstab.Text = "";
                ddMosqueSize.SelectedIndex = 0;
                txtMosqueQuote.Text = string.Empty;
                fupMosqueImage.Attributes.Clear();
            }
            catch
            {

            }

        }

        protected void btnAddMod_Click(object sender, EventArgs e)
        {
            divAddMod.Visible = true;
            lblTaskHead.InnerText = btnAddMod.Text;
            ddModQualification.SelectedValue = "NQ";
        }

        protected void btnRegModerater_Click(object sender, EventArgs e)
        {
            try
            {
                DBHandler db = new DBHandler();

                int continueProcess = 0;

                divAddMod.Visible = true;

                if (txtModPassword.Text.ToString() != txtModRetypePassword.Text.ToString() ||
                       txtModPassword.Text == null || txtModRetypePassword == null)
                {
                    txtModRetypePassword.BorderColor = Color.Red;
                    txtModPassword.BorderColor = Color.Red;
                    lblModError.Text = "Passwords do not match";
                    lblModError.ForeColor = Color.Red;
                    continueProcess += 1;
                }
                else if (txtModUserName.Text == "" || txtModUserName.Text == null)
                {
                    txtModUserName.BorderColor = Color.Red;
                    lblModError.Text = "User name field can not be empty";
                    continueProcess += 1;
                }
                else if (txtModUserName.Text.Length > 15 || txtModUserName.Text.Length < 5 || txtModUserName.Text == "")
                {
                    txtModUserName.BackColor = Color.Red;
                    lblModError.Text = "User Name is too long or too short";
                    continueProcess += 1;
                }
                else if (txtModUserName.Text != "" || txtModUserName.Text != null)
                {
                    try
                    {
                        if (db.BLL_GetMember(txtModUserName.Text.ToString()) != null)
                        {
                            lblModError.Text = "User Name taken, Please retype a new one";
                            txtModUserName.BorderColor = Color.Red;
                            lblModError.ForeColor = Color.Red;
                            continueProcess += 1;
                        }
                    }
                    catch (Exception ex)
                    {
                        txtModUserName.BorderColor = Color.Red;
                        lblModError.Text = ex.Message;
                        lblModError.ForeColor = Color.Red;
                        continueProcess += 1;
                    }
                }

                if (lblModError.Text == "" || lblModError.Text == null)
                {
                    if (txtModFName.Text == "" || txtModFName.Text == null)
                    {
                        txtModFName.BorderColor = Color.Red;
                        continueProcess += 1;
                    }
                    else if (txtModLName.Text == "" || txtModLName.Text == null)
                    {
                        txtModLName.BorderColor = Color.Red;
                        continueProcess += 1;
                    }
                    else if (txtModDOB.Text == "" || txtModDOB == null)
                    {
                        txtModDOB.BorderColor = Color.Red;
                        continueProcess += 1;
                    }
                    else if (txtModDOB.Text.Length > 10 || txtModDOB.Text.Length < 10)
                    {
                        txtModDOB.BorderColor = Color.Red;
                        continueProcess += 1;
                        lblModError.Text = "Please follow the format: yyyy-mm-dd";
                        lblModError.ForeColor = Color.Red;
                    }
                    else if (txtModEmail.Text == "" || txtModEmail == null)
                    {
                        txtModEmail.BorderColor = Color.Red;
                        lblModError.Text = "Please enter your Email address";
                        lblModError.ForeColor = Color.Red;
                        continueProcess += 1;
                    }
                    else if (txtModPassword.Text == null || txtModPassword.Text == "")
                    {
                        lblModError.Text = "Please create a Password";
                        lblModError.ForeColor = Color.Red;
                        continueProcess += 1;
                        txtModPassword.BorderColor = Color.Red;
                    }
                    else if (txtModRetypePassword.Text == null || txtModRetypePassword.Text == "")
                    {
                        lblModError.Text = "Please retype your Password";
                        lblModError.ForeColor = Color.Red;
                        continueProcess += 1;
                        txtModRetypePassword.BorderColor = Color.Red;
                    }
                    else if (txtModContactNo.Text.Length > 10 || txtModContactNo.Text.Length < 10)
                    {
                        if (txtModContactNo.Text.Length != 0) //!0 contact number field is allowed to be left empty.
                        {
                            lblModError.Text = "Please enter a correct contact number";
                            lblModError.ForeColor = Color.Red;
                            continueProcess += 1;
                            txtModContactNo.BorderColor = Color.Red;
                        }
                    }
                }

                if (continueProcess == 0)
                {
                    string encryptionPass = Convert.ToString(txtModUserName.Text);
                    Encryption encryption = new Encryption();
                    Member member = new Member();

                    string encryptedString = encryption.Encrypt(encryptionPass, Convert.ToString(txtModPassword.Text));

                    member.MemberID = Convert.ToString(txtModUserName.Text);
                    member.MemberName = Convert.ToString(txtModFName.Text);
                    member.MemberLastName = Convert.ToString(txtModLName.Text);
                    member.MemberDOB = Convert.ToDateTime(txtModDOB.Text);
                    member.Password = Convert.ToString(encryptedString);
                    member.MemberType = 'O';
                    member.ActiveTypeID = 'Y';
                    member.Email = Convert.ToString(txtModEmail.Text);
                    member.ContactNo = Convert.ToString(txtModContactNo.Text);
                    member.ActivationExpiry = Convert.ToDateTime(DateTime.Today.AddDays(1));
                    member.ActivationDate = Convert.ToDateTime(DateTime.Today.ToLocalTime());

                    bool MemberRegsuccess = db.BLL_AddMember(member);

                    Moderater moderater = new Moderater();
                    moderater.ModeraterID = txtModUserName.Text;
                    moderater.QualificationID = ddModQualification.SelectedValue.ToString();

                    bool modQualSuccess = db.BLL_AddModeraterQualification(moderater);

                    if (modQualSuccess == true && MemberRegsuccess == true)
                    {
                        EmailService email = new EmailService();
                        email.AddMod(txtModUserName.Text.ToString(), txtModFName.Text.ToString(), txtModEmail.Text.ToString(), txtModPassword.Text.ToString());

                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Scripts", "<script>alert('Moderater registration was successful.');</script>");

                        txtModUserName.Text = string.Empty;
                        txtModFName.Text = string.Empty;
                        txtModLName.Text = string.Empty;
                        txtModContactNo.Text = string.Empty;
                        txtModDOB.Text = string.Empty;
                        txtModEmail.Text = string.Empty;
                        Response.Redirect(Request.Url.AbsoluteUri);
                    }
                    else
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Scripts", "<script>alert('Moderater registration was unsuccessful, please try again.');</script>");
                    }

                }
            }
            catch
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Scripts", "<script>alert('Moderater registration was unsuccessful, please try again.');</script>");
            }
        }

        protected void btnModRegCancel_Click(object sender, EventArgs e)
        {
            divAddMod.Visible = true;

            txtModUserName.Text = string.Empty;
            txtModFName.Text = string.Empty;
            txtModLName.Text = string.Empty;
            txtModContactNo.Text = string.Empty;
            txtModDOB.Text = string.Empty;
            txtModEmail.Text = string.Empty;
            txtModRetypePassword.Text = string.Empty;
            txtModPassword.Text = string.Empty;

        }

        protected void btnUpdateZakaahOrg_Click(object sender, EventArgs e)
        {
            try
            {
                divOrgOverlay.Visible = true;
                divAddUpdateZakaahOrg.Visible = false;
                divZakaahOrgList.Visible = true;
                ddOrgActive.Enabled = true;
                txtOrgName.BorderColor = Color.Empty;
                txtOrgContactNo.BorderColor = Color.Empty;
                lblOrgError.Text = String.Empty;
                lblTaskHead.InnerText = "Update Zakaah Organization Details";
                btnAddUpdateOrg.Text = "Update Details";

                DBHandler db = new DBHandler();

                rptZakaahOrg.DataSource = db.BLL_GetOrganization();
                rptZakaahOrg.DataBind();
            }
            catch
            {

            }
        }

        protected void btnShowOrg_Click(object sender, EventArgs e)
        {
            try
            {
                //show from the list...
                LinkButton linkButton = (LinkButton)sender;

                string orgID = linkButton.CommandArgument.ToString();
                hdfZakaahOrg.Value = orgID;

                Cache.Remove("divAddUpdateZakaahOrg");

                DBHandler db = new DBHandler();
                Organization org = new Organization();

                org = db.BLL_GetSelectedZakaahOrg(Convert.ToInt32(orgID));

                txtOrgName.Text = org.Name;
                txtOrgWebAddr.Text = org.WebsiteAddress;
                txtOrgContactNo.Text = org.ContactNo;
                txtOrgPhyAddress.Text = org.PhysicalAddress;
                ddOrgActive.SelectedValue = Convert.ToString(org.Active);
                imgOrgImage.ImageUrl = org.Image.ToString();
                divZakaahOrgList.Visible = true;
                divAddUpdateZakaahOrg.Visible = true;
                divOrgImg.Visible = true;


            }
            catch
            {

            }
        }

        protected void btnAddUpdateOrg_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnAddUpdateOrg.Text == "Add Organization")
                {
                    divZakaahOrgList.Visible = false;
                    divAddUpdateZakaahOrg.Visible = true;
                }
                else if (btnAddUpdateOrg.Text == "Update Details")
                {
                    divZakaahOrgList.Visible = true;
                    divAddUpdateZakaahOrg.Visible = false;
                }
                DBHandler db = new DBHandler();

                int continueProcess = 0;

                if (txtOrgName.Text == "" || txtOrgName.Text == null)
                {
                    txtOrgName.BorderColor = Color.Red;
                    lblOrgError.Text = "Incomplete Form, Please provide a Organization Name";
                    lblOrgError.ForeColor = Color.Red;
                    continueProcess += 1;
                }
                else if (txtOrgContactNo.Text == "" || txtOrgContactNo.Text == null)
                {
                    lblOrgError.Text = "Incomplete Form, Please provide the contact number for the Organization";
                    lblOrgError.ForeColor = Color.Red;
                    txtOrgContactNo.BorderColor = Color.Red;
                    continueProcess += 1;
                }

                if (fupOrgImage.HasFile)
                {
                    string fileName = fupOrgImage.FileName.ToString();
                    string fileFormat = fileName.Substring(fileName.Length - 3); //get last character of Image name.
                    switch (fileFormat)
                    {
                        case "png":
                        case "jpg":
                        case "gif":
                        case "bmp":
                            break;
                        default:
                            continueProcess += 1;
                            lblOrgError.Text = "The file Uploaded is not of the correct format.";
                            lblOrgError.ForeColor = Color.Red;
                            break;
                    }
                }

                if (btnAddUpdateOrg.Text == "Add Organization")
                {
                    if (continueProcess == 0)
                    {
                        uspAddZakaahOrg addZakaahOrg = new uspAddZakaahOrg();

                        addZakaahOrg.Name = txtOrgName.Text.ToString();
                        addZakaahOrg.WebsiteAddress = txtOrgWebAddr.Text.ToString();
                        addZakaahOrg.ContactNo = txtOrgContactNo.Text.ToString();
                        addZakaahOrg.PhysicalAddress = txtOrgPhyAddress.Text.ToString();
                        addZakaahOrg.Active = 'Y';
                        if (fupOrgImage.HasFile)
                        {
                            string fileName = fupOrgImage.FileName.ToString();
                            string fileFormat = fileName.Substring(fileName.Length - 3); //get last character of Image name.

                            fupOrgImage.SaveAs(Server.MapPath("Images/ZakaahOrgImages/") + txtOrgName.Text.ToString().ToString() + "." + fileFormat.ToString()); //Image to upload ...

                            addZakaahOrg.Image = ("Images/ZakaahOrgImages/" + txtOrgName.Text.ToString() + "." + fileFormat.ToString());
                        }
                        else
                        {
                            addZakaahOrg.Image = "Images/ImageUnavailable.jpg";
                        }

                        bool OrgSuccess = db.BLL_AddZakaahOrganization(addZakaahOrg);

                        if (OrgSuccess == true) //test
                        {
                            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Scripts", "<script>alert('Zakaah Organization has been successfully Added.');</script>");

                            divZakaahOrgList.Visible = false;
                            divAddUpdateZakaahOrg.Visible = true;
                            ddOrgActive.Enabled = false;

                            txtOrgName.Text = string.Empty;
                            txtOrgWebAddr.Text = string.Empty;
                            txtOrgContactNo.Text = string.Empty;
                            txtOrgPhyAddress.Text = string.Empty;
                            ddOrgActive.SelectedIndex = 0;
                            fupOrgImage.Attributes.Clear();
                            txtOrgName.BorderColor = Color.Empty;
                            txtOrgContactNo.BorderColor = Color.Empty;
                            lblOrgError.Text = String.Empty;

                            Response.Redirect(Request.Url.AbsoluteUri);
                        }
                        else
                        {
                            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Scripts", "<script>alert('Zakaah Organization has been successfully Added.');</script>");

                        }
                    }

                }
                else if (btnAddUpdateOrg.Text == "Update Details")
                {

                    if (continueProcess == 0)
                    {
                        uspUpdateZakaahOrg updateZakaahOrg = new uspUpdateZakaahOrg();

                        updateZakaahOrg.OrganizationID = Convert.ToInt32(hdfZakaahOrg.Value);
                        updateZakaahOrg.Name = txtOrgName.Text.ToString();
                        updateZakaahOrg.WebsiteAddress = txtOrgWebAddr.Text.ToString();
                        updateZakaahOrg.ContactNo = txtOrgContactNo.Text.ToString();
                        updateZakaahOrg.PhysicalAddress = txtOrgPhyAddress.Text.ToString();
                        updateZakaahOrg.Active = Convert.ToChar(ddOrgActive.SelectedValue);

                        if (fupOrgImage.HasFile)
                        {
                            string fileName = fupOrgImage.FileName.ToString();
                            string fileFormat = fileName.Substring(fileName.Length - 3); //get last character of Image name eg(.jpg).

                            fupOrgImage.SaveAs(Server.MapPath("Images/ZakaahOrgImages/") + txtOrgName.Text.ToString().ToString() + "." + fileFormat.ToString()); //Image to upload ...

                            updateZakaahOrg.Image = ("Images/ZakaahOrgImages/" + txtOrgName.Text.ToString() + "." + fileFormat.ToString());

                        }
                        else
                        {
                            updateZakaahOrg.Image = imgOrgImage.ImageUrl.ToString();
                        }

                        bool updateOrg = db.BLL_UpdateZakaahOrg(updateZakaahOrg);

                        if (updateOrg == true)
                        {
                            //Refresh the List...
                            rptZakaahOrg.DataSource = db.BLL_GetOrganization();
                            rptZakaahOrg.DataBind();

                            txtOrgName.Text = string.Empty;
                            txtOrgWebAddr.Text = string.Empty;
                            txtOrgContactNo.Text = string.Empty;
                            txtOrgPhyAddress.Text = string.Empty;
                            ddOrgActive.SelectedIndex = 0;
                            fupOrgImage.Attributes.Clear();
                            txtOrgName.BorderColor = Color.Empty;
                            txtOrgContactNo.BorderColor = Color.Empty;
                            lblOrgError.Text = String.Empty;

                            divOrgImg.Visible = false;
                            divAddUpdateZakaahOrg.Visible = false;
                            divZakaahOrgList.Visible = true;
                            divOrgOverlay.Visible = true;

                            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Scripts", "<script>alert('Zakaah Organization has been successfully Updated.');</script>");
                        }
                        else
                        {
                            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Scripts", "<script>alert('Zakaah Organization update failed, please try again.');</script>");
                        }

                    }
                }
            }
            catch
            {

            }
        }

        protected void btnAddZakaahOrg_Click(object sender, EventArgs e)
        {
            divZakaahOrgList.Visible = false;
            divAddUpdateZakaahOrg.Visible = true;
            ddOrgActive.Enabled = false;
            divOrgImg.Visible = false;

            txtOrgName.BorderColor = Color.Empty;
            txtOrgContactNo.BorderColor = Color.Empty;
            lblOrgError.Text = String.Empty;

            txtOrgName.Text = string.Empty;
            txtOrgWebAddr.Text = string.Empty;
            txtOrgContactNo.Text = string.Empty;
            txtOrgPhyAddress.Text = string.Empty;
            ddOrgActive.SelectedValue = "Y";
            fupOrgImage.Attributes.Clear();
            lblTaskHead.InnerText = "Add Zakaah Organization";
            btnAddUpdateOrg.Text = "Add Organization";
        }

        protected void btnCancelAddUpdateOrg_Click(object sender, EventArgs e)
        {
            divZakaahOrgList.Visible = false;
            divAddUpdateZakaahOrg.Visible = false;
            lblTaskHead.InnerText = string.Empty;

            txtOrgName.Text = string.Empty;
            txtOrgWebAddr.Text = string.Empty;
            txtOrgContactNo.Text = string.Empty;
            txtOrgPhyAddress.Text = string.Empty;
            ddOrgActive.SelectedIndex = 0;
            fupOrgImage.Attributes.Clear();
        }

        protected void btnUpdateNotice_Click(object sender, EventArgs e)
        {
            try
            {
                txtNoticeTitle.BorderColor = Color.Empty;
                lblNoticeError.Text = String.Empty;
                txtNoticeExpiryDate.BorderColor = Color.Empty;

                divNoticeOverlay.Visible = true;
                divAddUpdateNotice.Visible = false;
                divNoticeList.Visible = true;
                txtNoticeMemberID.Enabled = false;
                btnAddUpdateNotice.Text = "Update Notice";
                lblTaskHead.InnerText = "Update Notice Details";

                DBHandler db = new DBHandler();

                rptNotice.DataSource = db.BLL_GetAllNotices();
                rptNotice.DataBind();

                txtNoticeTitle.Text = string.Empty;
                txtNoticeDesc.Text = string.Empty;
                txtNoticeDateCreated.Text = string.Empty;
                txtNoticeExpiryDate.Text = string.Empty;
                txtNoticeMemberID.Text = string.Empty;
            }
            catch
            {

            }

        }

        protected void btnShowNotice_Click(object sender, EventArgs e)
        {
            try
            {
                divNoticeList.Visible = true;
                divAddUpdateNotice.Visible = true;

                LinkButton linkButton = (LinkButton)sender;

                string noticeID = linkButton.CommandArgument.ToString();
                hdfNotice.Value = noticeID;

                DBHandler db = new DBHandler();
                Notice notice = new Notice();

                notice = db.BLL_GetSelectedNotice(Convert.ToInt32(noticeID));


                txtNoticeTitle.Text = notice.NoticeTitle.ToString();
                txtNoticeDesc.Text = notice.NoticeDescription.ToString();
                txtNoticeDateCreated.Text = Convert.ToDateTime(notice.DateCreated).ToString("dd MM yyyy");
                txtNoticeExpiryDate.Text = notice.DateExpiry.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                txtNoticeMemberID.Text = notice.MemberID.ToString();
                ddNoticeActive.SelectedValue = notice.Active.ToString();
            }
            catch
            {

            }
        }

        protected void btnAddNotice_Click(object sender, EventArgs e)
        {
            txtNoticeTitle.BorderColor = Color.Empty;
            lblNoticeError.Text = String.Empty;
            txtNoticeExpiryDate.BorderColor = Color.Empty;

            txtNoticeTitle.Text = string.Empty;
            txtNoticeDesc.Text = string.Empty;
            txtNoticeDateCreated.Text = string.Empty;
            txtNoticeExpiryDate.Text = string.Empty;
            txtNoticeMemberID.Text = string.Empty;
            ddNoticeActive.SelectedIndex = 1;
            txtNoticeDateCreated.Text = DateTime.Now.Date.ToString("dd MM yyyy");
            divNoticeList.Visible = false;
            divAddUpdateNotice.Visible = true;
            btnAddUpdateNotice.Text = "Add Notice";
            txtNoticeMemberID.Enabled = false;
            ddNoticeActive.Enabled = false;
            txtNoticeMemberID.Text = Session["UserName"].ToString();
            lblTaskHead.InnerText = "Add New Notice";

        }

        protected void btnAddUpdateNotice_Click(object sender, EventArgs e)
        {
            try
            {

                if (btnAddUpdateNotice.Text == "Add Notice")
                {
                    divNoticeList.Visible = false;
                    divAddUpdateNotice.Visible = true;
                }
                else if (btnAddUpdateNotice.Text == "Update Notice")
                {
                    divNoticeList.Visible = true;
                    divAddUpdateNotice.Visible = true;
                }

                DBHandler db = new DBHandler();
                Notice notice = new Notice();
                int continueProcess = 0;

                if (txtNoticeTitle.Text == "" || txtNoticeTitle.Text == null)
                {
                    lblNoticeError.ForeColor = Color.Red;
                    lblNoticeError.Text = "Please enter a Notice title";
                    txtNoticeTitle.BorderColor = Color.Red;
                    continueProcess += 1;
                }
                else if (txtNoticeDesc.Text == "" || txtNoticeDesc.Text == null)
                {
                    lblNoticeError.ForeColor = Color.Red;
                    lblNoticeError.Text = "Please enter a Notice Description";
                    txtNoticeDesc.BorderColor = Color.Red;
                    continueProcess += 1;
                }
                else if (txtNoticeExpiryDate.Text == "" || txtNoticeExpiryDate.Text == "dd --- yyyy")
                {
                    lblNoticeError.ForeColor = Color.Red;
                    lblNoticeError.Text = "Please enter a Notice Expiry date";
                    txtNoticeExpiryDate.BorderColor = Color.Red;
                    continueProcess += 1;
                }

                if (btnAddUpdateNotice.Text == "Add Notice")
                {
                    if (continueProcess == 0)
                    {

                        notice.NoticeTitle = txtNoticeTitle.Text;
                        notice.NoticeDescription = txtNoticeDesc.Text;
                        notice.MemberID = Session["UserName"].ToString();
                        notice.DateCreated = Convert.ToDateTime(txtNoticeDateCreated.Text);
                        notice.DateExpiry = Convert.ToDateTime(txtNoticeExpiryDate.Text);
                        notice.Active = 'Y';

                        bool noticeAdd = db.BLL_AddNotice(notice);

                        if (noticeAdd == true)
                        {
                            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Scripts", "<script>alert('Notice added.');</script>");

                            txtNoticeTitle.Text = string.Empty;
                            txtNoticeTitle.BorderColor = Color.Empty;
                            txtNoticeExpiryDate.BorderColor = Color.Empty;
                            txtNoticeDesc.BorderColor = Color.Empty;
                            txtNoticeDesc.Text = string.Empty;
                            txtNoticeDateCreated.Text = string.Empty;
                            txtNoticeExpiryDate.Text = string.Empty;
                            txtNoticeMemberID.Text = string.Empty;
                            ddNoticeActive.SelectedIndex = 0;
                            lblNoticeError.Text = String.Empty;

                            Response.Redirect(Request.Url.AbsoluteUri);
                        }
                        else
                        {
                            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Scripts", "<script>alert(' Failed to add the Notice, please try again.');</script>");
                        }


                    }

                }
                else if (btnAddUpdateNotice.Text == "Update Notice")
                {
                    if (continueProcess == 0)
                    {

                        notice.NoticeID = Convert.ToInt32(hdfNotice.Value);
                        notice.NoticeTitle = txtNoticeTitle.Text;
                        notice.NoticeDescription = txtNoticeDesc.Text;
                        notice.MemberID = Session["UserName"].ToString();
                        notice.DateCreated = DateTime.Today.ToLocalTime();
                        notice.DateExpiry = Convert.ToDateTime(txtNoticeExpiryDate.Text);
                        notice.Active = Convert.ToChar(ddNoticeActive.SelectedValue);

                        bool noticeAdd = db.BLL_UpdateNotice(notice);

                        if (noticeAdd == true)
                        {
                            //Refresh list...
                            rptNotice.DataSource = db.BLL_GetAllNotices();
                            rptNotice.DataBind();

                            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Scripts", "<script>alert('Notice has been successfully add.');</script>");

                            txtNoticeTitle.Text = string.Empty;
                            txtNoticeTitle.BorderColor = Color.Empty;
                            txtNoticeDesc.Text = string.Empty;
                            txtNoticeDateCreated.Text = string.Empty;
                            txtNoticeExpiryDate.Text = string.Empty;
                            txtNoticeExpiryDate.BorderColor = Color.Empty;
                            txtNoticeMemberID.Text = string.Empty;
                            ddNoticeActive.SelectedIndex = 0;
                            lblNoticeError.Text = String.Empty;
                        }
                        else
                        {
                            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Scripts", "<script>alert(' Failed to add the Notice, please try again.');</script>");
                        }
                    }
                }
            }
            catch
            {

            }
        }

        protected void btnUpdateDateCounter_Click(object sender, EventArgs e)
        {
            try
            {
                divCounterCalander.Visible = true;
                lblTaskHead.InnerText = btnUpdateDateCounter.Text;

                DBHandler db = new DBHandler();
                List<CounterCalender> counterCalender = new List<CounterCalender>();
                counterCalender = db.BLL_GetCounterCalender();

                if (counterCalender[2].Val != null || counterCalender[2].Val != "")
                {
                    txtCurCounterTitle.Text = Convert.ToString(counterCalender[2].Val);
                }
                else if (counterCalender[2].Val == null || counterCalender[2].Val == "")
                {
                    txtCurCounterTitle.Text = "No Title";
                }

                if (counterCalender[1].Val != null || counterCalender[1].Val != "")
                {
                    txtCurCounterEndTitle.Text = Convert.ToString(counterCalender[1].Val);
                }
                else if (counterCalender[1].Val == null || counterCalender[1].Val == "")
                {
                    txtCurCounterEndTitle.Text = "No End Title added";
                }

                if (counterCalender[0].Val == "" || counterCalender[0].Val == null)
                {
                    txtCurCounterEndDate.Text = "No date set";
                }
                else if (!(counterCalender[0].Val == "") || !(counterCalender[0].Val == null))
                {
                    DateTime islamiceDate = Convert.ToDateTime(counterCalender[0].Val);
                    txtCurCounterEndDate.Text = islamiceDate.ToString("dd MM yyyy");
                }

                if (counterCalender[3].Val != null || counterCalender[3].Val != "")
                {
                    txtCurIsalmicDate.Text = Convert.ToString(counterCalender[3].Val);
                }
                else if (counterCalender[3].Val == null || counterCalender[3].Val == "")
                {
                    txtCurIsalmicDate.Text = "0";
                }
            }
            catch (FormatException)
            {
                divCounterCalander.Visible = true;
                lblTaskHead.InnerText = btnUpdateDateCounter.Text;
            }
        }

        protected void btnUpdateCounter_Click(object sender, EventArgs e)
        {
            try
            {
                divCounterCalander.Visible = true;

                int continueProcess = 0;

                if (txtCounterTitle.Text == "" || txtCounterTitle.Text == null)
                {
                    txtCounterTitle.BorderColor = Color.Red;
                    continueProcess += 1;
                }
                else if (txtCounterEndDate.Text == "" || txtCounterEndDate.Text == null)
                {
                    txtCounterEndDate.BorderColor = Color.Red;
                    continueProcess += 1;
                    txtCounterEndDate.Text = "Counter End Date cannot be empty";
                }
                else if (txtCounterEndTitle.Text == "" || txtCounterEndTitle.Text == null)
                {
                    txtCounterEndTitle.BorderColor = Color.Red;
                    continueProcess += 1;
                    txtCounterEndTitle.Text = "Counter End Title cannot be empty";
                }

                if (continueProcess == 0)
                {
                    DBHandler db = new DBHandler();
                    uspUpdateCountDown uspUpdateCountDown = new uspUpdateCountDown();


                    string[] endDate;
                    endDate = txtCounterEndDate.Text.ToString().Split('/');

                    string endDate2 = endDate[2] + "-" + endDate[1] + "-" + endDate[0];

                    uspUpdateCountDown.CounterDate = endDate2;
                    uspUpdateCountDown.CounterFinishTitle = txtCounterEndTitle.Text;
                    uspUpdateCountDown.CounterTitle = txtCounterTitle.Text;

                    bool updateCOuntDown = db.BLL_UpdateCountDown(uspUpdateCountDown);

                    if (updateCOuntDown == true)
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Scripts", "<script>alert('Update unsuccessful.');</script>");

                        txtCounterEndTitle.BorderColor = Color.Empty;
                        txtCounterEndTitle.Text = String.Empty;
                        txtCounterEndDate.BorderColor = Color.Empty;
                        txtCounterEndDate.Text = String.Empty;
                        txtCounterTitle.BorderColor = Color.Empty;
                        txtCounterTitle.Text = String.Empty;
                    }
                    else
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Scripts", "<script>alert('Update successful.');</script>");
                    }
                }
            }
            catch
            {

            }
        }

        protected void btnUpdateIslamicDate_Click(object sender, EventArgs e)
        {
            try
            {
                divCounterCalander.Visible = true;
                int continueProcess = 0;

                if (txtIslamicDate.Text == "" || txtIslamicDate.Text == null)
                {
                    txtIslamicDate.BorderColor = Color.Red;
                    continueProcess += 1;
                }

                if (continueProcess == 0)
                {
                    uspUpdateIslamicDate uspUpdateIslamicDate = new uspUpdateIslamicDate();
                    DBHandler db = new DBHandler();

                    uspUpdateIslamicDate.IslamicDate = Convert.ToString(txtIslamicDate.Text); //adjustment digit not actually a date.

                    bool islamicDate = db.BLL_UpdateIslamicDate(uspUpdateIslamicDate);

                    if (islamicDate == true)
                    {
                        txtIslamicDate.BackColor = Color.Empty;
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Scripts", "<script>alert('Update successful.');</script>");
                    }
                    else
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Scripts", "<script>alert('Update unsuccessful.');</script>");
                    }
                }

            }
            catch
            {

            }
        }

        protected void btnUpdateMosque_Click(object sender, EventArgs e)
        {
            try
            {
                divMosqueList.Visible = true;
                divUpdateMosqueOverlay.Visible = false;

                lblTaskHead.InnerText = btnUpdateMosque.Text;
                DBHandler db = new DBHandler();

                rptMosqueList.DataSource = db.BLL_GetMosques();
                rptMosqueList.DataBind();
            }
            catch
            {

            }
        }

        protected void btnUpdateMosqueDetails_Click(object sender, EventArgs e)
        {
            try
            {
                txtUpdateMosqueName.BorderColor = Color.Empty;
                txtUpdateMosqueAddr.BorderColor = Color.Empty;
                txtUpdateMosqueSuburb.BorderColor = Color.Empty;
                txtUpdateMosqueQuote.BorderColor = Color.Empty;
                lblUpdateMosqueError.Text = "";

                DBHandler db = new DBHandler();
                Encryption encryption = new Encryption();
                uspAddMosque addMosque = new uspAddMosque();
                int continueProcess = 0;

                if (lblUpdateMosqueError.Text == "" || lblUpdateMosqueError.Text == null)
                {
                    if (txtUpdateMosqueName.Text == "" || txtUpdateMosqueName.Text == null)
                    {
                        txtUpdateMosqueName.BorderColor = Color.Red;
                        continueProcess += 1;
                    }
                    else if (txtUpdateMosqueAddr.Text == "" || txtUpdateMosqueAddr.Text == null)
                    {
                        txtUpdateMosqueAddr.BorderColor = Color.Red;
                        continueProcess += 1;
                    }
                    else if (txtUpdateMosqueSuburb.Text == "" || txtUpdateMosqueSuburb.Text == null)
                    {
                        txtUpdateMosqueSuburb.BorderColor = Color.Red;
                        continueProcess += 1;
                    }
                    else if (ddUpdateMosqueType.SelectedIndex == 0)
                    {
                        ddUpdateMosqueType.BorderColor = Color.Red;
                        continueProcess += 1;
                    }
                    else if (txtUpdateMosqueEstab.Text == "dd --- yyyy")
                    {
                        txtUpdateMosqueEstab.BorderColor = Color.Red;
                        continueProcess += 1;
                    }
                    else if (ddUpdateMosqueSize.SelectedIndex == 0)
                    {
                        ddUpdateMosqueSize.BorderColor = Color.Red;
                        continueProcess += 1;
                    }
                    else if (ddUpdateMosqueType.SelectedValue == "None")
                    {
                        ddUpdateMosqueType.BorderColor = Color.Red;
                        continueProcess += 1;
                    }
                    else if (ddUpdateMosqueSize.SelectedValue == "None")
                    {
                        ddUpdateMosqueSize.BorderColor = Color.Red;
                        continueProcess += 1;
                        lblUpdateMosqueError.Text = "Registration type not selected";
                        lblUpdateMosqueError.ForeColor = Color.Red;
                    }
                    else if (ddUpdateMosqueActive.SelectedValue == "None")
                    {
                        lblUpdateMosqueError.Text = "Mosque has to be either Yes or No";
                        lblUpdateMosqueError.ForeColor = Color.Red;
                        continueProcess += 1;
                        ddUpdateMosqueActive.BorderColor = Color.Red;
                    }
                    if (fupUpdateMosqueImage.HasFile)
                    {
                        string fileName = fupUpdateMosqueImage.FileName.ToString();
                        string fileFormat = fileName.Substring(fileName.Length - 3);
                        switch (fileFormat)
                        {
                            case "png":
                            case "jpg":
                            case "gif":
                            case "bmp":
                                break;
                            default:
                                continueProcess += 1;
                                lblUpdateMosqueError.Text = "The file Uploaded is not of the correct format.";
                                lblUpdateMosqueError.ForeColor = Color.Red;
                                break;
                        }
                    }
                }

                if (continueProcess == 0)
                {
                    Mosques mosque = new Mosques();

                    mosque.MosqueID = Convert.ToInt32(hdfMosqueID.Value);
                    mosque.MosqueName = txtUpdateMosqueName.Text;
                    mosque.MosqueStreet = txtUpdateMosqueAddr.Text;
                    mosque.MosqueSuburb = txtUpdateMosqueSuburb.Text;
                    mosque.MosqueType = ddUpdateMosqueType.SelectedValue;
                    mosque.YearEstablished = Convert.ToDateTime(txtUpdateMosqueEstab.Text);
                    mosque.Active = Convert.ToChar(ddUpdateMosqueActive.SelectedValue);
                    if (fupUpdateMosqueImage.HasFile)//Add Image save to directory and path to DB.
                    {
                        string fileName = fupUpdateMosqueImage.FileName.ToString();
                        string fileFormat = fileName.Substring(fileName.Length - 3); //get last character of Image name.

                        fupUpdateMosqueImage.SaveAs(Server.MapPath("Images/MosqueImages/") + txtUpdateMosqueName.Text.ToString().ToString() + "." + fileFormat.ToString()); //Image to upload ...

                        mosque.MosqueImage = ("Images/MosqueImages/" + txtUpdateMosqueName.Text.ToString() + "." + fileFormat.ToString());
                    }
                    else
                    {
                        mosque.MosqueImage = fupUpdateMosqueImage.ToolTip.ToString();
                    }
                    mosque.MosqueSize = ddUpdateMosqueSize.SelectedValue;
                    mosque.MosqueQuote = txtUpdateMosqueQuote.Text;

                    bool mosqueUpdate = db.BLL_UpdateMosque(mosque);

                    if (mosqueUpdate == true)
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Scripts", "<script>alert('Mosque update successful.');</script>");

                        txtUpdateMosqueName.Text = string.Empty;
                        txtUpdateMosqueAddr.Text = string.Empty;
                        txtUpdateMosqueSuburb.Text = string.Empty;
                        ddUpdateMosqueType.SelectedValue = "None";
                        txtUpdateMosqueEstab.Text = string.Empty;
                        ddUpdateMosqueActive.SelectedValue = "None";
                        ddUpdateMosqueSize.SelectedValue = "None";
                        txtUpdateMosqueQuote.Text = string.Empty;
                    }
                    else
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Scripts", "<script>alert('Mosque update Unsuccessful.');</script>");
                    }
                }

                Cache.Remove("divMosqueList");

                rptMosqueList.DataSource = db.BLL_GetMosques();
                rptMosqueList.DataBind();

                Cache.Remove("divMosqueList");

                divUpdateMosque.Visible = false;
                divMosqueList.Visible = true;
                divUpdateMosqueOverlay.Visible = true;
            }
            catch
            {

            }
        }

        protected void btnCancelMosqueUpdate_Click(object sender, EventArgs e)
        {
            divUpdateMosqueOverlay.Visible = false;
            divUpdateMosque.Visible = false;
            divMosqueList.Visible = false;

            txtUpdateMosqueName.Text = string.Empty;
            txtUpdateMosqueAddr.Text = string.Empty;
            txtUpdateMosqueSuburb.Text = string.Empty;
            ddUpdateMosqueType.SelectedValue = "None";
            txtUpdateMosqueEstab.Text = string.Empty;
            ddUpdateMosqueActive.SelectedValue = "None";
            ddUpdateMosqueSize.SelectedValue = "None";
            txtUpdateMosqueQuote.Text = string.Empty;

        }

        protected void btnShowMosque_Click(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;

            string mosqueId = linkButton.CommandArgument.ToString();
            hdfMosqueID.Value = mosqueId;

            DBHandler db = new DBHandler();
            Mosques mosque = new Mosques();

            mosque = db.BLL_GetSpecificMosque(Convert.ToInt32(mosqueId));

            txtUpdateMosqueName.Text = mosque.MosqueName.ToString();
            txtUpdateMosqueAddr.Text = mosque.MosqueStreet.ToString();
            txtUpdateMosqueSuburb.Text = mosque.MosqueSuburb.ToString();
            ddUpdateMosqueType.SelectedValue = mosque.MosqueType.ToString();
            txtUpdateMosqueEstab.Text = Convert.ToDateTime(mosque.YearEstablished).ToString("yyyy-MM-dd");
            ddUpdateMosqueActive.SelectedValue = Convert.ToString(mosque.Active);
            ddUpdateMosqueSize.SelectedValue = Convert.ToString(mosque.MosqueSize);
            txtUpdateMosqueQuote.Text = Convert.ToString(mosque.MosqueQuote);
            fupUpdateMosqueImage.ToolTip = Convert.ToString(mosque.MosqueImage);

            divUpdateMosqueOverlay.Visible = false;
            divUpdateMosque.Visible = true;
            divMosqueList.Visible = true;
        }

        protected void btnViewAllMembers_Click(object sender, EventArgs e)
        {
            divAllMembersList.Visible = true;
            divMemberDetails.Visible = false;
            divMemberDetailsOverlay.Visible = true;
            lblTaskHead.InnerText = btnViewAllMembers.Text;

            DBHandler db = new DBHandler();
            Member member = new Member();

            rptMemberList.DataSource = db.BLL_GetAllMembers();
            rptMemberList.DataBind();

        }

        protected void btnShowMember_Click(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;

            string memberId = linkButton.CommandArgument.ToString();
            hdfAllMemberID.Value = memberId;

            DBHandler db = new DBHandler();
            uspGetMember member = new uspGetMember();
            List<ActiveType> activeType = new List<ActiveType>();

            divAllMembersList.Visible = true;
            divMemberDetails.Visible = true;
            divMemberDetailsOverlay.Visible = false;

            member = db.BLL_GetMember(memberId);

            ddAllctiveTypeID.Items.Clear();
            activeType = db.BLL_GetAllActiveTypes();
            ddAllctiveTypeID.Items.Add(new System.Web.UI.WebControls.ListItem(activeType[0].ActiveDescription.ToString(), activeType[0].ActiveTypeID.ToString()));
            ddAllctiveTypeID.Items.Add(new System.Web.UI.WebControls.ListItem(activeType[1].ActiveDescription.ToString(), activeType[1].ActiveTypeID.ToString()));
            ddAllctiveTypeID.Items.Add(new System.Web.UI.WebControls.ListItem(activeType[2].ActiveDescription.ToString(), activeType[2].ActiveTypeID.ToString()));

            lblAllMemberID.InnerText = member.MemberID;
            lblAllMemberName.InnerText = member.MemberName;
            lblAllMemberLastName.InnerText = member.MemberLastName;
            switch (member.MemberType.ToString())
            {
                case "A":
                    lblAllMemberType.InnerText = "Administrator";
                    break;
                case "S":
                    lblAllMemberType.InnerText = "Scholar";
                    break;
                case "M":
                    lblAllMemberType.InnerText = "Member";
                    break;
                case "O":
                    lblAllMemberType.InnerText = "Moderater";
                    break;
                case "R":
                    lblAllMemberType.InnerText = "Mosque Representative";
                    break;
            }

            lblAllMemberDOB.InnerText = member.MemberDOB.ToString("dd MM yyyy");
            lblAllEmail.InnerText = member.Email.ToString();
            lblAllContactNo.InnerText = member.ContactNo.ToString();
            lblAllMosque.InnerText = member.MosqueID.ToString();
            lblAllActivationDate.InnerText = member.ActivationDate.ToString("dd MM yyyy");
            ddAllctiveTypeID.SelectedValue = Convert.ToString(member.ActiveTypeID);
        }

        protected void btnUpdateAllMember_Click(object sender, EventArgs e)
        {
            divAllMembersList.Visible = true;
            divMemberDetails.Visible = false;
            divMemberDetailsOverlay.Visible = true;

            DBHandler dBHandler = new DBHandler();
            uspUpdateMemberActiveStatus updateMemberActiveStatus = new uspUpdateMemberActiveStatus();
            uspGetMember member = new uspGetMember();

            member = dBHandler.BLL_GetMember(hdfAllMemberID.Value.ToString());

            updateMemberActiveStatus.MemberID = hdfAllMemberID.Value.ToString();
            updateMemberActiveStatus.MemberType = Convert.ToChar(member.MemberType);
            updateMemberActiveStatus.ActiveTypeID = Convert.ToChar(ddAllctiveTypeID.SelectedValue);

            bool memberUpdated = dBHandler.BLL_UpdateMemberActiveStatus(updateMemberActiveStatus);

            if (memberUpdated == true)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Scripts", "<script>alert('Member active status update successful.');</script>");

                rptMemberList.DataSource = dBHandler.BLL_GetAllMembers();
                rptMemberList.DataBind();

                EmailService emailService = new EmailService();

                emailService.DisableEnableMember(member.Email.ToString(), member.MemberID); //notify the member via email.
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Scripts", "<script>alert('Member active status update failed.');</script>");
            }
        }

        protected void btnUpdateCancelAllMember_Click(object sender, EventArgs e)
        {
            divAllMembersList.Visible = false;
            divMemberDetails.Visible = false;
            divMemberDetailsOverlay.Visible = false;
            lblTaskHead.InnerText = String.Empty;
        }

        protected void lnkAdminPrintPDF_ServerClick(object sender, EventArgs e)
        {
            try
            {
                if (lblAdminReportHeading.InnerText == "All Members Details Report")
                {
                    grdAdminReports.HeaderRow.Cells[0].Text = "User Name";
                    grdAdminReports.HeaderRow.Cells[1].Text = "Firstname";
                    grdAdminReports.HeaderRow.Cells[2].Text = "Lastname";
                    grdAdminReports.HeaderRow.Cells[3].Text = "Date Of Birth";
                    grdAdminReports.HeaderRow.Cells[4].Text = "Member Type";
                    grdAdminReports.HeaderRow.Cells[5].Text = "Active";
                    grdAdminReports.HeaderRow.Cells[6].Text = "Email Address";
                    grdAdminReports.HeaderRow.Cells[7].Text = "Contact Number";
                    grdAdminReports.HeaderRow.Cells[8].Text = "Mosque";
                    grdAdminReports.HeaderRow.Cells[9].Text = "Date Registered";

                }
                if (lblAdminReportHeading.InnerText == "All Mosques Details Report")
                {

                }

                grdAdminReports.HeaderRow.Font.Size = 16;

                DBHandler han = new DBHandler();
                PdfPTable pdfTable = new PdfPTable(grdAdminReports.HeaderRow.Cells.Count);
                pdfTable.HorizontalAlignment = 0;

                foreach (TableCell Headercell in grdAdminReports.HeaderRow.Cells)
                {
                    iTextSharp.text.Font font = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 11, iTextSharp.text.Font.BOLD);
                    font.Color = new BaseColor(grdAdminReports.HeaderStyle.ForeColor);

                    PdfPCell pdfCell = new PdfPCell(new Phrase(Headercell.Text, font));
                    pdfCell.HorizontalAlignment = 1;
                    pdfCell.Padding = 5;
                    pdfCell.BackgroundColor = new BaseColor(grdAdminReports.HeaderStyle.BackColor);
                    pdfTable.AddCell(pdfCell);
                }

                foreach (GridViewRow gridviewrow in grdAdminReports.Rows)
                {
                    foreach (TableCell tablecell in gridviewrow.Cells)
                    {
                        iTextSharp.text.Font font = new iTextSharp.text.Font();
                        font.Color = new BaseColor(grdAdminReports.RowStyle.ForeColor);
                        iTextSharp.text.Font content = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.BOLD);
                        PdfPCell pdfcell = new PdfPCell(new Phrase(tablecell.Text, content));
                        pdfcell.HorizontalAlignment = 1;
                        pdfcell.VerticalAlignment = 2;
                        pdfcell.BackgroundColor = new BaseColor(grdAdminReports.RowStyle.BackColor);
                        pdfTable.AddCell(pdfcell);
                    }
                }

                Document pdfDocument = new Document(new RectangleReadOnly(842, 595), 10f, -200f, 10f, 0f);
                PdfAWriter.GetInstance(pdfDocument, Response.OutputStream);

                pdfTable.DefaultCell.Padding = 5;
                pdfTable.DefaultCell.VerticalAlignment = PdfPCell.ALIGN_CENTER;
                PdfPTable table = new PdfPTable(1);
                PdfPTable table2 = new PdfPTable(2);

                iTextSharp.text.Font fontH2 = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.BOLD);
                table2.WidthPercentage = 80;
                table2.HorizontalAlignment = 0;
                table2.DefaultCell.Padding = 8;
                table2.DefaultCell.HorizontalAlignment = 1;
                table2.DefaultCell.VerticalAlignment = 1;
                Paragraph date = new Paragraph("Date Created: " + DateTime.Now.Date.ToString("dd MMM yyyy"), fontH2);
                Paragraph extraPara = new Paragraph("Muslimeen Adminstrator Reports", fontH2);
                table2.AddCell(date);
                table2.AddCell(extraPara);

                if (lblAdminReportHeading.InnerText == "All Members Details Report" || lblAdminReportHeading.InnerText == "All Active Members Details Report" || lblAdminReportHeading.InnerText == "All Unactive Members Details Report")
                {
                    iTextSharp.text.Font fontH1 = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 24, iTextSharp.text.Font.BOLD);
                    table.WidthPercentage = 80;
                    table.HorizontalAlignment = 0;
                    table.DefaultCell.Padding = 20;
                    table.DefaultCell.HorizontalAlignment = 1;
                    table.DefaultCell.VerticalAlignment = 1;
                    if (lblAdminReportHeading.InnerText == "All Members Details Report")
                    {
                        Paragraph para = new Paragraph("Report of All Members Details", fontH1);
                        table.AddCell(para);
                    }
                    else if (lblAdminReportHeading.InnerText == "All Active Members Details Report")
                    {
                        Paragraph para = new Paragraph("Report of All Active Members Details", fontH1);
                        table.AddCell(para);
                    }
                    else if (lblAdminReportHeading.InnerText == "All Unactive Members Details Report")
                    {
                        Paragraph para = new Paragraph("Report of All Unactive Members Details", fontH1);
                        table.AddCell(para);
                    }

                    pdfDocument.Open();
                    pdfDocument.AddTitle("All Mosques Details Report");
                    pdfDocument.Add(table);
                    pdfDocument.Add(table2);
                    pdfDocument.Add(pdfTable);
                    pdfDocument.Close();

                    Response.ContentType = "application/pdf";
                    Response.AppendHeader("content-disposition", "attachment;filename=" + lblAdminReportHeading.InnerText + ".pdf");
                    Response.Write(pdfDocument);
                    Response.Flush();
                    Response.End();

                }
                else if (lblAdminReportHeading.InnerText == "All Mosques Details Report")
                {
                    iTextSharp.text.Font fontH1 = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 24, iTextSharp.text.Font.BOLD);
                    table.WidthPercentage = 80;
                    table.HorizontalAlignment = 0;
                    table.DefaultCell.Padding = 20;
                    table.DefaultCell.HorizontalAlignment = 1;
                    table.DefaultCell.VerticalAlignment = 1;
                    Paragraph para = new Paragraph("Report of All Mosques Details", fontH1);
                    table.AddCell(para);

                    pdfDocument.Open();
                    pdfDocument.AddTitle("All Mosques Details Report");
                    pdfDocument.Add(table);
                    pdfDocument.Add(table2);
                    pdfDocument.Add(pdfTable);
                    pdfDocument.Close();

                    Response.ContentType = "application/pdf";
                    Response.AppendHeader("content-disposition", "attachment;filename=" + lblAdminReportHeading.InnerText + ".pdf");
                    Response.Write(pdfDocument);
                    Response.Flush();
                    Response.End();

                }

            }
            catch (NullReferenceException)
            {

            }

        }

        protected void btnReportViewMembers_Click(object sender, EventArgs e)
        {
            divAdminReports.Visible = true;

            DBHandler db = new DBHandler();
            List<uspReportGetAllMembers> reportGetAllMembers = new List<uspReportGetAllMembers>();

            lblAdminReportHeading.InnerText = "All Members Details Report";

            reportGetAllMembers = db.BLL_ReportGetAllMembers("All Members");

            grdAdminReports.DataSource = reportGetAllMembers;
            grdAdminReports.DataBind();

            //grdAdminReports.RowStyle.BorderWidth = 1;
            //.Attributes["style"] = "border-width:2";
            grdAdminReports.GridLines = GridLines.Both;
            grdAdminReports.BorderColor = Color.Gray;
            grdAdminReports.CellPadding = 8;

            grdAdminReports.HeaderRow.Cells[0].Text = "User Name";
            grdAdminReports.HeaderRow.Cells[1].Text = "Firstname";
            grdAdminReports.HeaderRow.Cells[2].Text = "Lastname";
            grdAdminReports.HeaderRow.Cells[3].Text = "Date Of Birth";
            grdAdminReports.HeaderRow.Cells[4].Text = "Member Type";
            grdAdminReports.HeaderRow.Cells[5].Text = "Active";
            grdAdminReports.HeaderRow.Cells[6].Text = "Email Address";
            grdAdminReports.HeaderRow.Cells[7].Text = "Contact Number";
            grdAdminReports.HeaderRow.Cells[8].Text = "Mosque ID";
            grdAdminReports.HeaderRow.Cells[9].Text = "Date Registered";

            //go through all rows and change the date format and and other chars.
            for (int i = 0; i < grdAdminReports.Rows.Count; i++)
            {
                DateTime DOB = Convert.ToDateTime(grdAdminReports.Rows[i].Cells[3].Text);
                grdAdminReports.Rows[i].Cells[3].Text = DOB.ToString("dd MMM yyyy");

                string memberType = grdAdminReports.Rows[i].Cells[4].Text;
                grdAdminReports.Rows[i].Cells[4].Text = memberType.Replace("A", "Admin").Replace("M", "Member").Replace("O", "Moderater").Replace("S", "Scholar").Replace("R", "Mosque Rep");

                string active = grdAdminReports.Rows[i].Cells[5].Text;
                grdAdminReports.Rows[i].Cells[5].Text = active.Replace("N", "No").Replace("Y", "Yes").Replace("T", "Temporary");

                string mosqueID = grdAdminReports.Rows[i].Cells[8].Text;
                grdAdminReports.Rows[i].Cells[8].Text = mosqueID.Replace("&nbsp;", "No Mosque Assigned");

                DateTime regDate = Convert.ToDateTime(grdAdminReports.Rows[i].Cells[9].Text);
                grdAdminReports.Rows[i].Cells[9].Text = regDate.ToString("dd MMM yyyy");
            }
        }

        protected void btnReportViewActiveMembers_Click(object sender, EventArgs e)
        {
            divAdminReports.Visible = true;

            DBHandler db = new DBHandler();
            List<uspReportGetAllMembers> reportGetAllMembers = new List<uspReportGetAllMembers>();

            lblAdminReportHeading.InnerText = "All Active Members Details Report";

            reportGetAllMembers = db.BLL_ReportGetAllMembers("Active");

            grdAdminReports.DataSource = reportGetAllMembers;
            grdAdminReports.DataBind();

            //grdAdminReports.RowStyle.BorderWidth = 1;
            //.Attributes["style"] = "border-width:2";
            grdAdminReports.GridLines = GridLines.Both;
            grdAdminReports.BorderColor = Color.Gray;
            grdAdminReports.CellPadding = 8;

            grdAdminReports.HeaderRow.Cells[0].Text = "User Name";
            grdAdminReports.HeaderRow.Cells[1].Text = "Firstname";
            grdAdminReports.HeaderRow.Cells[2].Text = "Lastname";
            grdAdminReports.HeaderRow.Cells[3].Text = "Date Of Birth";
            grdAdminReports.HeaderRow.Cells[4].Text = "Member Type";
            grdAdminReports.HeaderRow.Cells[5].Text = "Active";
            grdAdminReports.HeaderRow.Cells[6].Text = "Email Address";
            grdAdminReports.HeaderRow.Cells[7].Text = "Contact Number";
            grdAdminReports.HeaderRow.Cells[8].Text = "Mosque ID";
            grdAdminReports.HeaderRow.Cells[9].Text = "Date Registered";

            //go through all rows and change the date format and and other chars.
            for (int i = 0; i < grdAdminReports.Rows.Count; i++)
            {
                DateTime DOB = Convert.ToDateTime(grdAdminReports.Rows[i].Cells[3].Text);
                grdAdminReports.Rows[i].Cells[3].Text = DOB.ToString("dd MMM yyyy");

                string memberType = grdAdminReports.Rows[i].Cells[4].Text;
                grdAdminReports.Rows[i].Cells[4].Text = memberType.Replace("A", "Admin").Replace("M", "Member").Replace("O", "Moderater").Replace("S", "Scholar").Replace("R", "Mosque Rep");

                string active = grdAdminReports.Rows[i].Cells[5].Text;
                grdAdminReports.Rows[i].Cells[5].Text = active.Replace("N", "No").Replace("Y", "Yes").Replace("T", "Temporary");

                string mosqueID = grdAdminReports.Rows[i].Cells[8].Text;
                grdAdminReports.Rows[i].Cells[8].Text = mosqueID.Replace("&nbsp;", "No Mosque Assigned");

                DateTime regDate = Convert.ToDateTime(grdAdminReports.Rows[i].Cells[9].Text);
                grdAdminReports.Rows[i].Cells[9].Text = regDate.ToString("dd MMM yyyy");
            }
        }

        protected void btnReportUnactiveMembers_Click(object sender, EventArgs e)
        {
            divAdminReports.Visible = true;
            DBHandler db = new DBHandler();
            List<uspReportGetAllMembers> reportGetAllMembers = new List<uspReportGetAllMembers>();

            lblAdminReportHeading.InnerText = "All Unactive Members Details Report";

            reportGetAllMembers = db.BLL_ReportGetAllMembers("Unactive");

            grdAdminReports.DataSource = reportGetAllMembers;
            grdAdminReports.DataBind();

            try
            { 
                grdAdminReports.GridLines = GridLines.Both;
                grdAdminReports.BorderColor = Color.Gray;
                grdAdminReports.CellPadding = 8;

                grdAdminReports.HeaderRow.Cells[0].Text = "User Name";
                grdAdminReports.HeaderRow.Cells[1].Text = "Firstname";
                grdAdminReports.HeaderRow.Cells[2].Text = "Lastname";
                grdAdminReports.HeaderRow.Cells[3].Text = "Date Of Birth";
                grdAdminReports.HeaderRow.Cells[4].Text = "Member Type";
                grdAdminReports.HeaderRow.Cells[5].Text = "Active";
                grdAdminReports.HeaderRow.Cells[6].Text = "Email Address";
                grdAdminReports.HeaderRow.Cells[7].Text = "Contact Number";
                grdAdminReports.HeaderRow.Cells[8].Text = "Mosque ID";
                grdAdminReports.HeaderRow.Cells[9].Text = "Date Registered";
            }
            catch (NullReferenceException)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Scripts", "<script>alert('There are no unactive members.');</script>");
                divAdminReports.Visible = false;
            }
            catch (ArgumentOutOfRangeException)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Scripts", "<script>alert('There are no unactive members.');</script>");
                divAdminReports.Visible = false;
            }
            //go through all rows and change the date format and and other chars.
            for (int i = 0; i < grdAdminReports.Rows.Count; i++)
            {
                DateTime DOB = Convert.ToDateTime(grdAdminReports.Rows[i].Cells[3].Text);
                grdAdminReports.Rows[i].Cells[3].Text = DOB.ToString("dd MMM yyyy");

                string memberType = grdAdminReports.Rows[i].Cells[4].Text;
                grdAdminReports.Rows[i].Cells[4].Text = memberType.Replace("A", "Admin").Replace("M", "Member").Replace("O", "Moderater").Replace("S", "Scholar").Replace("R", "Mosque Rep");

                string active = grdAdminReports.Rows[i].Cells[5].Text;
                grdAdminReports.Rows[i].Cells[5].Text = active.Replace("N", "No").Replace("Y", "Yes").Replace("T", "Temporary");

                string mosqueID = grdAdminReports.Rows[i].Cells[8].Text;
                grdAdminReports.Rows[i].Cells[8].Text = mosqueID.Replace("&nbsp;", "No Mosque Assigned");

                DateTime regDate = Convert.ToDateTime(grdAdminReports.Rows[i].Cells[9].Text);
                grdAdminReports.Rows[i].Cells[9].Text = regDate.ToString("dd MMM yyyy");
            }
        }

        protected void btnReportAllMosques_Click(object sender, EventArgs e)
        {
            divAdminReports.Visible = true;

            DBHandler db = new DBHandler();
            List <uspReportGetAllMosques> mosques = new List<uspReportGetAllMosques>();

            lblAdminReportHeading.InnerText = "All Mosques Details Report";

            mosques = db.BLL_ReportGetAllMosques();

            grdAdminReports.DataSource = mosques;
            grdAdminReports.DataBind();

            grdAdminReports.GridLines = GridLines.Both;
            grdAdminReports.BorderColor = Color.Gray;
            grdAdminReports.CellPadding = 8;

            grdAdminReports.HeaderRow.Cells[0].Text = "Mosque ID";
            grdAdminReports.HeaderRow.Cells[1].Text = "Name";
            grdAdminReports.HeaderRow.Cells[2].Text = "Mosque Address";
            grdAdminReports.HeaderRow.Cells[3].Text = "Mosque Suburb";
            grdAdminReports.HeaderRow.Cells[4].Text = "Year Established";
            grdAdminReports.HeaderRow.Cells[5].Text = "Mosque Type";
            grdAdminReports.HeaderRow.Cells[6].Text = "Active";
            grdAdminReports.HeaderRow.Cells[7].Text = "Mosque Size";
            grdAdminReports.HeaderRow.Cells[8].Text = "Mosque Representative";

            //go through all rows and change the date format and and other chars.
            for (int i = 0; i < grdAdminReports.Rows.Count; i++)
            {
                DateTime DOB = Convert.ToDateTime(grdAdminReports.Rows[i].Cells[4].Text);
                grdAdminReports.Rows[i].Cells[4].Text = DOB.ToString("dd MMM yyyy");

                string active = grdAdminReports.Rows[i].Cells[6].Text;
                grdAdminReports.Rows[i].Cells[6].Text = active.Replace("N", "No").Replace("Y", "Yes").Replace("T", "Temporary");
            }

        }

        protected void btnAddAdmin_Click(object sender, EventArgs e)
        {
            divAddAdmin.Visible = true;
            lblTaskHead.InnerText = btnAddAdmin.Text;
        }

        protected void btnRegAdmin_Click(object sender, EventArgs e)
        {

            divAddAdmin.Visible = true;

            DBHandler db = new DBHandler();

            int continueProcess = 0;

            if (txtAdminPassword.Text.ToString() != txtAdminRetypePassword.Text.ToString() ||
                   txtAdminPassword.Text == null || txtAdminRetypePassword == null)
            {
                txtAdminRetypePassword.BorderColor = Color.Red;
                txtAdminPassword.BorderColor = Color.Red;
                lblAdminError.Text = "Passwords do not match";
                lblAdminError.ForeColor = Color.Red;
                continueProcess += 1;
            }
            else if (txtAdminUserName.Text == "" || txtAdminUserName.Text == null)
            {
                txtAdminUserName.BorderColor = Color.Red;
                lblAdminError.Text = "User name field can not be empty";
                continueProcess += 1;
            }
            else if (txtAdminUserName.Text.Length > 15 || txtAdminUserName.Text.Length < 5 || txtAdminUserName.Text == "")
            {
                txtAdminUserName.BackColor = Color.Red;
                lblAdminError.Text = "User Name is too long or too short";
                continueProcess += 1;
            }
            else if (txtAdminUserName.Text != "" || txtAdminUserName.Text != null)
            {
                try
                {
                    if (db.BLL_GetMember(txtAdminUserName.Text.ToString()) != null)
                    {
                        lblAdminError.Text = "User Name taken, Please retype a new one";
                        txtAdminUserName.BorderColor = Color.Red;
                        lblAdminError.ForeColor = Color.Red;
                        continueProcess += 1;
                    }
                }
                catch (Exception ex)
                {
                    txtAdminUserName.BorderColor = Color.Red;
                    lblAdminError.Text = ex.Message;
                    lblAdminError.ForeColor = Color.Red;
                    continueProcess += 1;
                }
            }

            if (lblAdminError.Text == "" || lblAdminError.Text == null)
            {
                if (txtAdminFName.Text == "" || txtAdminFName.Text == null)
                {
                    txtAdminFName.BorderColor = Color.Red;
                    continueProcess += 1;
                }
                else if (txtAdminLName.Text == "" || txtAdminLName.Text == null)
                {
                    txtAdminLName.BorderColor = Color.Red;
                    continueProcess += 1;
                }
                else if (txtAdminDOB.Text == "" || txtAdminDOB == null)
                {
                    txtAdminDOB.BorderColor = Color.Red;
                    continueProcess += 1;
                }
                else if (txtAdminDOB.Text.Length > 10 || txtAdminDOB.Text.Length < 10)
                {
                    txtAdminDOB.BorderColor = Color.Red;
                    continueProcess += 1;
                    lblAdminError.Text = "Please follow the format: yyyy-mm-dd";
                    lblAdminError.ForeColor = Color.Red;
                }
                else if (txtAdminEmail.Text == "" || txtAdminEmail == null)
                {
                    txtAdminEmail.BorderColor = Color.Red;
                    lblAdminError.Text = "Please enter your Email address";
                    lblAdminError.ForeColor = Color.Red;
                    continueProcess += 1;
                }
                else if (txtAdminPassword.Text == null || txtAdminPassword.Text == "")
                {
                    lblAdminError.Text = "Please create a Password";
                    lblAdminError.ForeColor = Color.Red;
                    continueProcess += 1;
                    txtAdminPassword.BorderColor = Color.Red;
                }
                else if (txtAdminRetypePassword.Text == null || txtAdminRetypePassword.Text == "")
                {
                    lblAdminError.Text = "Please retype your Password";
                    lblAdminError.ForeColor = Color.Red;
                    continueProcess += 1;
                    txtAdminRetypePassword.BorderColor = Color.Red;
                }
                else if (txtAdminContactNo.Text.Length > 10 || txtAdminContactNo.Text.Length < 10)
                {
                    if (txtAdminContactNo.Text.Length != 0) //!0 contact number field is allowed to be left empty.
                    {
                        lblAdminError.Text = "Please enter a correct contact number";
                        lblAdminError.ForeColor = Color.Red;
                        continueProcess += 1;
                        txtAdminContactNo.BorderColor = Color.Red;
                    }
                }
            }

            if (continueProcess == 0)
            {
                string encryptionPass = Convert.ToString(txtAdminUserName.Text);
                Encryption encryption = new Encryption();
                Member member = new Member();

                string encryptedString = encryption.Encrypt(encryptionPass, Convert.ToString(txtAdminPassword.Text));

                member.MemberID = Convert.ToString(txtAdminUserName.Text);
                member.MemberName = Convert.ToString(txtAdminFName.Text);
                member.MemberLastName = Convert.ToString(txtAdminLName.Text);
                member.MemberDOB = Convert.ToDateTime(txtAdminDOB.Text);
                member.Password = Convert.ToString(encryptedString);
                member.MemberType = 'A';
                member.ActiveTypeID = 'Y';
                member.Email = Convert.ToString(txtAdminEmail.Text);
                member.ContactNo = Convert.ToString(txtAdminContactNo.Text);
                member.ActivationExpiry = Convert.ToDateTime(DateTime.Today.AddDays(1));
                member.ActivationDate = Convert.ToDateTime(DateTime.Today.ToLocalTime());

                bool success = db.BLL_AddMember(member);

                txtAdminUserName.Text = string.Empty;
                txtAdminFName.Text = string.Empty;
                txtAdminLName.Text = string.Empty;
                txtAdminContactNo.Text = string.Empty;
                txtAdminDOB.Text = string.Empty;
                txtAdminEmail.Text = string.Empty;
            }

        }

        protected void btnAdminRegCancel_Click(object sender, EventArgs e)
        {
            txtAdminUserName.Text = string.Empty;
            txtAdminFName.Text = string.Empty;
            txtAdminLName.Text = string.Empty;
            txtAdminContactNo.Text = string.Empty;
            txtAdminDOB.Text = string.Empty;
            txtAdminEmail.Text = string.Empty;

            divAddAdmin.Visible = true;

        }

        protected void btnTodaysPrayerTime_Click(object sender, EventArgs e)
        {
            try
            {
                divDisplaySalahTimetable.Visible = true;
                lblTaskHead.InnerText = btnTodaysPrayerTime.Text.ToString();

                DBHandler dBHandler = new DBHandler();
                DateTime todaysDate = DateTime.Today;

                uspGetSpecificDayPrayerTimes prayertimes = new uspGetSpecificDayPrayerTimes();
                prayertimes = dBHandler.BLL_GetSpecficDayPrayerTimes(int.Parse(Session["MosqueID"].ToString()), todaysDate);

                lblFajrAzaan.Text = prayertimes.FajrA.ToString();
                lblFajrJamaat.Text = prayertimes.FajrJ.ToString();
                lblDhuhrAzaan.Text = prayertimes.DhuhrA.ToString();
                lblDhuhrJamaat.Text = prayertimes.DhuhrJ.ToString();
                lblAsrAzaan.Text = prayertimes.AsrA.ToString();
                lblAsrJamaat.Text = prayertimes.AsrJ.ToString();
                lblMagribAzaan.Text = prayertimes.MagribA.ToString();
                lblMagribJamaat.Text = prayertimes.MagribJ.ToString();
                lblEishaAzaan.Text = prayertimes.EishaA.ToString();
                lblEishaJamaat.Text = prayertimes.EishaJ.ToString();


            }
            catch
            {

            }
        }

        protected void btnMosqueEvents_Click(object sender, EventArgs e) //button after the dates have been typed out.
        {
            divDisplaySalahTimetable.Visible = false;
            divDisplayEvents.Visible = true;
            divEventOverlay.Visible = true;

            lblTaskHead.InnerText = btnMosqueEvents.Text.ToString();
        }

        protected void btnEventList_Click(object sender, EventArgs e) //display selected event
        {
            divEvent.Visible = true;
            divDisplaySalahTimetable.Visible = false;
            lblTaskHead.InnerText = btnMosqueEvents.Text.ToString();

            LinkButton btn = (LinkButton)sender;
            uspGetSpecificEvent events = new uspGetSpecificEvent();
            DBHandler db = new DBHandler();
            Session["EventID"] = btn.CommandArgument.ToString();
            events = db.BLL_GetuspGetSpecificEvent(int.Parse(btn.CommandArgument.ToString()));

            lblEventTitle.InnerText = events.EventTitle.ToString();
            lblEventDescription.InnerText = events.EventDescription.ToString();
            lblSpeaker.InnerText = events.Speaker.ToString();
            lblEventDate.InnerText = Convert.ToDateTime(events.EventDate).ToString("dd-MM-yyyy");
            lblEventStartTime.InnerText = events.EventStartTime.ToString();
            lblEventEndTime.InnerText = events.EventEndTime.ToString();

            divListEvent.Visible = true;
            divListEventDetails.Visible = true;
            divDisplayEvents.Visible = true;
            divEvent.Visible = true;
            divEventOverlay.Visible = false;
        }

        protected void btnListEvents_Click(object sender, EventArgs e) //Show the list rpt.
        {
            try
            {

                lblTaskHead.InnerText = btnListEvents.Text.ToString();
                divDisplaySalahTimetable.Visible = false;
                divDisplayEvents.Visible = true;
                divEventOverlay.Visible = true;
                lblEventError.Text = String.Empty;
                lblEventError.ForeColor = Color.Empty;
                txtStartDate.BorderColor = Color.Empty;

                DBHandler db = new DBHandler();

                int cont = 0;
                if (txtStartDate.Text == null || txtStartDate.Text == "")
                {
                    lblEventError.Text = "No start date was selected";
                    lblEventError.ForeColor = Color.Red;
                    txtStartDate.BorderColor = Color.Red;
                    cont += 1;
                }
                else if (txtEndDate.Text == null || txtEndDate.Text == "")
                {
                    lblEventError.Text = "No end date was selected";
                    lblEventError.ForeColor = Color.Red;
                    txtEndDate.BorderColor = Color.Red;
                    cont += 1;
                }
                else if (Convert.ToDateTime(txtStartDate.Text.ToString()) >= Convert.ToDateTime(txtEndDate.Text.ToString()))
                {
                    lblEventError.Text = "Invalid date. The start date should be less than the end date.";
                    lblEventError.ForeColor = Color.Red;
                    txtStartDate.BorderColor = Color.Red;
                    txtEndDate.BorderColor = Color.Red;
                    cont += 1;
                }
                else if (Convert.ToDateTime(txtEndDate.Text.ToString()) <= Convert.ToDateTime(txtStartDate.Text.ToString()))
                {
                    lblEventError.Text = "Invalid date. The end date should be later than the start date.";
                    lblEventError.ForeColor = Color.Red;
                    txtStartDate.BorderColor = Color.Red;
                    txtEndDate.BorderColor = Color.Red;
                    cont += 1;
                }

                if (cont == 0)
                {
                    RptEventList.DataSource = db.Bll_GetMosqueEventsDateRange(int.Parse(Session["MosqueID"].ToString()), Convert.ToDateTime(txtStartDate.Text.ToString()), Convert.ToDateTime(txtEndDate.Text.ToString()));
                    RptEventList.DataBind();
                    DateTime startDate = Convert.ToDateTime(txtStartDate.Text.ToString());
                    DateTime EndDate = Convert.ToDateTime(txtEndDate.Text.ToString());
                    if (startDate.Date <= EndDate.Date)
                    {

                        if (RptEventList.Items.Count > 0)
                        {
                            divListEvent.Visible = true;
                            divListEventDetails.Visible = true;
                            divDisplayEvents.Visible = true;
                            divEvent.Visible = false;
                            divEventOverlay.Visible = false;
                        }
                        else if (RptEventList.Items.Count <= 0)
                        {
                            divListEvent.Visible = false;
                            divListEventDetails.Visible = false;
                            divDisplayEvents.Visible = true;
                            divEvent.Visible = false;
                            lblEventError.Text = "No Events Found for Specified Date Range";
                            divEventOverlay.Visible = true;
                        }
                    }
                    else if (startDate.Date > EndDate.Date)
                    {
                        divListEvent.Visible = false;
                        divListEventDetails.Visible = false;
                        divDisplayEvents.Visible = true;
                        divEvent.Visible = false;
                        lblEventError.Text = "Invalid Date Range";
                        divEventOverlay.Visible = true;
                    }
                }
            }
            catch(FormatException)
            {
                lblEventError.Text = "Start date or End date is incorrect.";
            }
            catch
            {

            }

        }
        
    }
}
