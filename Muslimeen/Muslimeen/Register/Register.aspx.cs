using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using TypeLib.ViewModels;
using TypeLib.Models;
using Muslimeen.BLL;
using System.Security.Cryptography;
using System.Data;



namespace Muslimeen.Register
{
    public partial class Register : System.Web.UI.Page
    {

        Encryption encryption = new Encryption();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                txtDOB.MaxLength = 10;
                if (!IsPostBack)
                {
                    ddUsertype.ClearSelection();
                }

                if (IsPostBack)
                {
                    txtPassword.Attributes["Value"] = txtPassword.Text;
                    txtRetypePass.Attributes["Value"] = txtRetypePass.Text;

                    txtUserName.BorderColor = Color.Empty;
                    txtName.BorderColor = Color.Empty;
                    txtLName.BorderColor = Color.Empty;
                    txtContactNum.BorderColor = Color.Empty;
                    txtDOB.BorderColor = Color.Empty;
                    txtUserEmail.BorderColor = Color.Empty;
                    ddUsertype.BorderColor = Color.Empty;
                    txtPassword.BorderColor = Color.Empty;
                    txtRetypePass.BorderColor = Color.Empty;
                    lblErrorPass.Text = "";
                    txtUserName.BorderColor = Color.Empty;
                    txtName.BorderColor = Color.Empty;
                    txtLName.BorderColor = Color.Empty;
                    txtUserEmail.BorderColor = Color.Empty;
                    ddUsertype.BorderColor = Color.Empty;
                    txtDOB.BorderColor = Color.Empty;
                    txtPassword.BorderColor = Color.Empty;
                    txtRetypePass.BorderColor = Color.Empty;
                    txtContactNum.BorderColor = Color.Empty;
                    txtUserEmail.BorderColor = Color.Empty;
                }
            }
            catch
            {

            }

        }

        protected void ddUsertype_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddUsertype.SelectedValue == "S")
                {
                    DBHandler dBHandler = new DBHandler();

                    ddScholarQual.Items.Clear();
                    ddScholarQual.Dispose();
                    ddScholarQual.Visible = true;

                    List<uspGetQualification> list = dBHandler.BLL_GetQualification();

                    foreach (uspGetQualification qual in list)
                    {
                        ddScholarQual.Items.Add(new ListItem(qual.QualificationDescription.ToString(),
                            qual.QualificationID.ToString()));
                    }
                }
                else
                {
                    ddScholarQual.Visible = false;
                    ddScholarQual.Items.Clear();
                    ddScholarQual.Dispose();
                }
            }
            catch
            {

            }

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                DBHandler dBHandler = new DBHandler();
                int continueProcess = 0;//if more than 1 then member will not be added.


                if (txtPassword.Text.ToString() != txtRetypePass.Text.ToString() ||
                    txtPassword.Text == null || txtRetypePass == null)
                {
                    txtRetypePass.BorderColor = Color.Red;
                    txtPassword.BorderColor = Color.Red;
                    lblErrorPass.Text = "Passwords do not match";
                    lblErrorPass.ForeColor = Color.Red;
                    continueProcess += 1;
                }
                else if (txtUserName.Text == "" || txtUserName.Text == null)
                {
                    txtUserName.BorderColor = Color.Red;
                    lblErrorPass.Text = "User name field can not be empty";
                    continueProcess += 1;
                }
                else if (txtUserName.Text.Length > 15 || txtUserName.Text.Length < 5 || txtUserName.Text == "")
                {
                    txtUserName.BackColor = Color.Red;
                    lblErrorPass.Text = "User Name is too long or too short";
                    continueProcess += 1;
                }
                else if (txtUserName.Text != "" || txtUserName.Text != null)
                {
                    try
                    {
                        if (dBHandler.BLL_GetMember(txtUserName.Text.ToString()) != null)
                        {
                            lblErrorPass.Text = "User Name taken, Please retype a new one";
                            txtUserName.BorderColor = Color.Red;
                            lblErrorPass.ForeColor = Color.Red;
                            continueProcess += 1;
                        }
                    }
                    catch (Exception ex)
                    {
                        txtUserName.BorderColor = Color.Red;
                        lblErrorPass.Text = ex.Message;
                        lblErrorPass.ForeColor = Color.Red;
                        continueProcess += 1;
                    }
                }

                if (lblErrorPass.Text == "" || lblErrorPass.Text == null)
                {
                    if (txtName.Text == "" || txtName.Text == null)
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
                        lblErrorPass.Text = "Please follow the format: yyyy-mm-dd";
                    }
                    else if (txtUserEmail.Text == "" || txtUserEmail == null)
                    {
                        txtUserEmail.BorderColor = Color.Red;
                        lblErrorPass.Text = "Please enter your Email address";
                        continueProcess += 1;
                    }
                    else if (ddScholarQual.SelectedValue == "None")
                    {
                        ddScholarQual.BorderColor = Color.Red;
                        continueProcess += 1;
                    }
                    else if (ddUsertype.SelectedValue == "None")
                    {
                        ddScholarQual.BorderColor = Color.Red;
                        continueProcess += 1;
                        lblErrorPass.Text = "Registration type not selected";
                    }
                    else if (txtPassword.Text == null || txtPassword.Text == "")
                    {
                        lblErrorPass.Text = "Please create a Password";
                        continueProcess += 1;
                        txtPassword.BorderColor = Color.Red;
                    }
                    else if (txtRetypePass.Text == null || txtRetypePass.Text == "")
                    {
                        lblErrorPass.Text = "Please retype your Password";
                        continueProcess += 1;
                        txtRetypePass.BorderColor = Color.Red;
                    }
                    else if (txtContactNum.Text.Length > 10 || txtContactNum.Text.Length < 10)
                    {
                        if (txtContactNum.Text.Length != 0)
                        {
                            lblErrorPass.Text = "Please enter a correct contact number";
                            continueProcess += 1;
                            txtContactNum.BorderColor = Color.Red;
                        }
                    }
                }
                if (continueProcess == 0)
                {

                    string encryptionPass = Convert.ToString(txtUserName.Text);
                    Encryption encryption = new Encryption();
                    Member member = new Member();

                    string encryptedString = encryption.Encrypt(encryptionPass,
                        Convert.ToString(txtPassword.Text));

                    member.MemberID = Convert.ToString(txtUserName.Text);
                    member.MemberName = Convert.ToString(txtName.Text);
                    member.MemberLastName = Convert.ToString(txtLName.Text);
                    member.MemberDOB = Convert.ToDateTime(txtDOB.Text);
                    member.Password = Convert.ToString(encryptedString);
                    member.MemberType = Convert.ToChar(ddUsertype.SelectedValue);
                    member.ActiveTypeID = 'T';
                    member.Email = Convert.ToString(txtUserEmail.Text);
                    member.ContactNo = Convert.ToString(txtContactNum.Text);
                    member.ActivationExpiry = Convert.ToDateTime(DateTime.Now.AddDays(1));
                    member.ActivationDate = Convert.ToDateTime(DateTime.Now);

                    bool success = dBHandler.BLL_AddMember(member);



                    if (ddUsertype.SelectedValue == "S")
                    {
                        Scholar scholar = new Scholar
                        {
                            ScholarID = Convert.ToString(txtUserName.Text),
                            QualificationID = Convert.ToString(ddScholarQual.SelectedValue)
                        };

                        dBHandler.BLL_AddScholarQualification(scholar);


                        EmailService emailService = new EmailService();

                        emailService.AutoEmailService(txtUserEmail.Text.ToString(),
                            ddUsertype.SelectedItem.ToString(), "null", "Scholar Registration", "null", "null"); //Add server Verification.aspx address.
                    }
                    else if (ddUsertype.SelectedValue == "M")
                    {
                       
                     

                        EmailService emailService = new EmailService();

                        emailService.AutoEmailService(txtUserEmail.Text.ToString(),
                            ddUsertype.SelectedItem.ToString(), "http://sict-iis.nmmu.ac.za/NEXTECH/Register/Verification.aspx", "Registration", "null", "null"); //Add server Verification.aspx address.
                    }
                    Response.Redirect("../Content/Default.aspx");
                }
            }
            catch (Exception ex)
            {
                lblErrorPass.Text = ex.Message;
            }


        }


    }

}





    
