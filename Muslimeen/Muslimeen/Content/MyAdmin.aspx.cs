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

namespace Muslimeen.Content
{
    public partial class MyAdmin : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
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

                DBHandler dBHandler = new DBHandler();

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
                            ddModQualification.Items.Add(new ListItem(qual.QualificationDescription.ToString(),
                                qual.QualificationID.ToString()));
                        }

                    }
                    else
                    {
                        Response.Redirect("~/Content/Error.aspx");
                    }
                }
                else if (Session["UserName"] == null)
                {
                    liMyMusbtn.Visible = false;
                    liMyMusDivi.Visible = false;

                    divUserProfile.Visible = false;
                    Session.Clear();
                    Response.Redirect("~/Login/Login.aspx");
                }


                divDisplaySch.Visible = false;
            }
            catch
            {

            }
        }


        protected void btnViewPendingSch_Click(object sender, EventArgs e)
        {
            //divUpdateIslmDate.Visible = false;
            divDisplaySch.Visible = false;
            divSchDetailsOverlay.Visible = true;
            divViewPendingSch.Visible = true;

            lblTaskHead.InnerText = btnViewPendingSch.Text.ToString();
            DBHandler dBHandler = new DBHandler();

            rptViewPendingSch.DataSource = dBHandler.BLL_GetAllPendingScholars();
            rptViewPendingSch.DataBind();

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
                Response.Redirect("~/Content/MyAdmin.aspx");
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
                lblMemberDOB.InnerText = scholarDetails.MemberDOB.ToString();
                lblMemberType.InnerText = scholarDetails.MemberType.ToString();
                lblEmail.InnerText = scholarDetails.Email.ToString();
                lblContactNo.InnerText = scholarDetails.ContactNo.ToString();
                lblActivationExpiry.InnerText = scholarDetails.ActivationExpiry.ToString();
                lblActivationDate.InnerText = scholarDetails.ActivationDate.ToString();
                lblScholarQual.InnerText = scholarDetails.QualificationDescription.ToString();

                divViewPendingSch.Visible = true;
                divDisplaySch.Visible = true;
                divSchDetails.Visible = true;

            }
            catch
            {
                throw;
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
                    db.BLL_VerifyMember(uspVerifyMember);

                    //Sends an email informing the scholar that his registration has be accepted.
                    EmailService email = new EmailService();
                    uspGetMember member = new uspGetMember();
                    member = db.BLL_GetMember(hdfSchId.Value.ToString());

                    email.AutoEmailService(member.Email, "null", "null", "AcceptedScholars", member.MemberID.ToString(), "null");

                    //Help with keeping selected task open.
                    divDisplaySch.Visible = false;
                    divSchDetailsOverlay.Visible = true;
                    divViewPendingSch.Visible = true;

                }
            }
            catch
            {

            }
        }

        protected void btnRejectReg_Click(object sender, EventArgs e)
        {
            try
            {
                DBHandler db = new DBHandler();
                uspRejectReg rejectReg = new uspRejectReg();

                rejectReg.MemberID = hdfSchId.Value.ToString();
                db.BLL_RejectReg(rejectReg);

                EmailService email = new EmailService();
                uspGetMember member = new uspGetMember();
                member = db.BLL_GetMember(hdfSchId.Value.ToString());

                email.AutoEmailService(member.Email, "null", "null", "RejectedScholars", member.MemberID.ToString(), "null");

            }
            catch
            {

            }
        }

        protected void rptViewPendingSch_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void btnAddMosque_Click(object sender, EventArgs e)
        {
            divAddMosque.Visible = true;
            divAddMosqueRep.Visible = true;

            lblTaskHead.InnerText = btnAddMosque.Text.ToString();

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
                    addMosque.MemberDOB = Convert.ToDateTime(txtDOB.Text.ToString());
                    addMosque.Email = txtUserEmail.Text.ToString();
                    addMosque.MemberType = 'R';
                    addMosque.ActiveTypeID = 'Y';
                    addMosque.ActivationDate = DateTime.Today.Date;
                    addMosque.Password = encryptedString; //password encrypted

                    addMosque.MosqueName = txtMosqueName.Text.ToString();
                    addMosque.MosqueStreet = txtMosqueAddr.Text.ToString();
                    addMosque.MosqueSuburb = txtMosqueSuburb.Text.ToString();
                    addMosque.MosqueType = ddMosqueType.SelectedValue.ToString();
                    if (fupMosqueImage.HasFile)
                    {
                        addMosque.MosqueImage = fupMosqueImage.FileBytes; //Image to upload ...
                    }
                    addMosque.MosqueSize = ddMosqueSize.SelectedValue.ToString();
                    addMosque.MosqueQuote = txtMosqueQuote.Text.ToString();
                    addMosque.YearEstablished = Convert.ToDateTime(txtMosqueEstab.Text.ToString());

                    db.BLL_AddMosque(addMosque);

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

                }
                else if (lblError.Text == "")
                {
                    lblError.Text = "Registration Unsuccessful, Incomplete form";
                    lblError.ForeColor = Color.Red;
                }
            }
            catch
            {
                throw;
            }
        }

        protected void btnCancelMosqueReg_Click(object sender, EventArgs e)
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

        protected void btnAddMod_Click(object sender, EventArgs e)
        {
            divAddMod.Visible = true;



        }

        protected void btnRegModerater_Click(object sender, EventArgs e)
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

                bool success = db.BLL_AddMember(member);

                Moderater moderater = new Moderater();
                moderater.ModeraterID = txtModUserName.Text;
                moderater.QualificationID = ddModQualification.SelectedValue.ToString();

                db.BLL_AddModeraterQualification(moderater);

                divAddMod.Visible = true;

                txtModUserName.Text = string.Empty;
                txtModFName.Text = string.Empty;
                txtModLName.Text = string.Empty;
                txtModContactNo.Text = string.Empty;
                txtModDOB.Text = string.Empty;
                txtModEmail.Text = string.Empty;

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
            divAddUpdateZakaahOrg.Visible = true;
            divZakaahOrgList.Visible = true;
            ddOrgActive.Enabled = true;
            btnAddUpdateOrg.Text = "Update Details";

            DBHandler db = new DBHandler();

            rptZakaahOrg.DataSource = db.BLL_GetOrganization();
            rptZakaahOrg.DataBind();
        }

        protected void btnShowOrg_Click(object sender, EventArgs e)
        {

            //show from the list...
            LinkButton linkButton = (LinkButton)sender;

            string orgID = linkButton.CommandArgument.ToString();
            hdfZakaahOrg.Value = orgID;

            DBHandler db = new DBHandler();
            Organization org = new Organization();

            org = db.BLL_GetSelectedZakaahOrg(Convert.ToInt32(orgID));

            txtOrgName.Text = org.Name;
            txtOrgWebAddr.Text = org.WebsiteAddress;
            txtOrgContactNo.Text = org.ContactNo;
            txtOrgPhyAddress.Text = org.PhysicalAddress;
            ddOrgActive.SelectedValue = Convert.ToString(org.Active);

            divZakaahOrgList.Visible = true;
            divAddUpdateZakaahOrg.Visible = true;
        }

        protected void btnAddUpdateOrg_Click(object sender, EventArgs e)
        {
            divZakaahOrgList.Visible = true;
            divAddUpdateZakaahOrg.Visible = true;
            DBHandler db = new DBHandler();

            int continueProcess = 0;

            if (txtOrgName.Text == "" || txtOrgName.Text == null)
            {
                txtOrgName.BorderColor = Color.Red;
                lblOrgError.Text = "Incomplete Form, Please provide a Organization Name";
                continueProcess += 1;
            }
            else if (txtOrgContactNo.Text == "" || txtOrgContactNo.Text == null)
            {
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

            if (continueProcess == 0)
            {
                if (btnAddUpdateOrg.Text == "Add Organization")
                {
                    uspAddZakaahOrg addZakaahOrg = new uspAddZakaahOrg();

                    addZakaahOrg.Name = txtOrgName.Text.ToString();
                    addZakaahOrg.WebsiteAddress = txtOrgWebAddr.Text.ToString();
                    addZakaahOrg.ContactNo = txtOrgContactNo.Text.ToString();
                    addZakaahOrg.PhysicalAddress = txtOrgPhyAddress.Text.ToString();
                    addZakaahOrg.Active = 'Y';
                    if(fupOrgImage.HasFile)
                    {
                        addZakaahOrg.Image = fupOrgImage.FileBytes; //Image to upload ...
                    }

                    db.BLL_AddZakaahOrganization(addZakaahOrg);


                    divZakaahOrgList.Visible = false;
                    divAddUpdateZakaahOrg.Visible = true;
                    ddOrgActive.Enabled = false;

                }
                else if (btnAddUpdateOrg.Text == "Update Details")
                {
                    uspUpdateZakaahOrg updateZakaahOrg = new uspUpdateZakaahOrg();

                    updateZakaahOrg.OrganizationID = Convert.ToInt32(hdfZakaahOrg.Value);
                    updateZakaahOrg.Name = txtOrgName.Text.ToString();
                    updateZakaahOrg.WebsiteAddress = txtOrgWebAddr.Text.ToString();
                    updateZakaahOrg.ContactNo = txtOrgContactNo.Text.ToString();
                    updateZakaahOrg.PhysicalAddress = txtOrgPhyAddress.Text.ToString();
                    updateZakaahOrg.Active = Convert.ToChar(ddOrgActive.SelectedValue);
                    updateZakaahOrg.Image = fupOrgImage.FileBytes; //Image to upload ...

                    db.BLL_UpdateZakaahOrg(updateZakaahOrg);

                    divZakaahOrgList.Visible = true;
                    divAddUpdateZakaahOrg.Visible = true;

                    //Refresh the List...
                    rptZakaahOrg.DataSource = db.BLL_GetOrganization();
                    rptZakaahOrg.DataBind();
                }

                txtOrgName.Text = string.Empty;
                txtOrgWebAddr.Text = string.Empty;
                txtOrgContactNo.Text = string.Empty;
                txtOrgPhyAddress.Text = string.Empty;
                ddOrgActive.SelectedIndex = 0;
                fupOrgImage.Attributes.Clear();
            }
        }

        protected void btnAddZakaahOrg_Click(object sender, EventArgs e)
        {
            divZakaahOrgList.Visible = false;
            divAddUpdateZakaahOrg.Visible = true;
            ddOrgActive.Enabled = false;

            txtOrgName.Text = string.Empty;
            txtOrgWebAddr.Text = string.Empty;
            txtOrgContactNo.Text = string.Empty;
            txtOrgPhyAddress.Text = string.Empty;
            ddOrgActive.SelectedIndex = 0;
            fupOrgImage.Attributes.Clear();

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
            divAddUpdateNotice.Visible = true;
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

        protected void btnShowNotice_Click(object sender, EventArgs e)
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
            txtNoticeDateCreated.Text = notice.DateCreated.ToString();
            txtNoticeExpiryDate.Text = notice.DateExpiry.ToString("yyyy-MM-dd");
            txtNoticeMemberID.Text = notice.MemberID.ToString();
            ddNoticeActive.SelectedValue = notice.Active.ToString();
        }

        protected void btnAddNotice_Click(object sender, EventArgs e)
        {
            txtNoticeTitle.Text = string.Empty;
            txtNoticeDesc.Text = string.Empty;
            txtNoticeDateCreated.Text = string.Empty;
            txtNoticeExpiryDate.Text = string.Empty;
            txtNoticeMemberID.Text = string.Empty;
            ddNoticeActive.SelectedIndex = 1;
            txtNoticeDateCreated.Text = Convert.ToString(DateTime.Now.Date);
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
            divNoticeList.Visible = true;
            divAddUpdateNotice.Visible = true;

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


            if (continueProcess > 0)
            {

                if (btnAddUpdateNotice.Text == "Add Notice")
                {
                    notice.NoticeTitle = txtNoticeTitle.Text;
                    notice.NoticeDescription = txtNoticeDesc.Text;
                    notice.MemberID = Session["UserName"].ToString();
                    notice.DateCreated = Convert.ToDateTime(txtNoticeDateCreated.Text);
                    notice.DateExpiry = Convert.ToDateTime(txtNoticeExpiryDate.Text);
                    notice.Active = 'Y';

                    db.BLL_AddNotice(notice);
                }
                else if (btnAddUpdateNotice.Text == "Update Notice")
                {
                    notice.NoticeID = Convert.ToInt32(hdfNotice.Value);
                    notice.NoticeTitle = txtNoticeTitle.Text;
                    notice.NoticeDescription = txtNoticeDesc.Text;
                    notice.MemberID = Session["UserName"].ToString();
                    notice.DateCreated = DateTime.Today.ToLocalTime();
                    notice.DateExpiry = Convert.ToDateTime(txtNoticeExpiryDate.Text);
                    notice.Active = Convert.ToChar(ddNoticeActive.SelectedValue);

                    db.BLL_UpdateNotice(notice);

                    //Refresh list...
                    rptNotice.DataSource = db.BLL_GetAllNotices();
                    rptNotice.DataBind();

                }

                txtNoticeTitle.Text = string.Empty;
                txtNoticeDesc.Text = string.Empty;
                txtNoticeDateCreated.Text = string.Empty;
                txtNoticeExpiryDate.Text = string.Empty;
                txtNoticeMemberID.Text = string.Empty;
                ddNoticeActive.SelectedIndex = 0;
            }
        }
    }
}