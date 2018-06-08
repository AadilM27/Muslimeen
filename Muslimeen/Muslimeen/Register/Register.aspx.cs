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

        protected void ddUsertype_SelectedIndexChanged(object sender, EventArgs e)
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

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            DBHandler dBHandler = new DBHandler();
            int continueProcess=0;//if more than 1 then member will not be added.

            
            if (txtPassword.Text.ToString() != txtRetypePass.Text.ToString() ||
                txtPassword.Text == null || txtRetypePass == null)
            {
                txtRetypePass.BorderColor = Color.IndianRed;
                txtPassword.BorderColor = Color.IndianRed;
                lblErrorPass.Text = "Passwords do not match";
                lblErrorPass.ForeColor = Color.Red;
                continueProcess += 1;
            }
            else if (txtUserName.Text == "" || txtUserName.Text == null)
            {
                txtUserName.BorderColor = Color.IndianRed;
                lblErrorPass.Text = "User name field can not be empty";
                continueProcess += 1;
            }
            else if (txtUserName.Text.Length > 15 || txtUserName.Text.Length < 5)
            {
                txtUserName.BackColor = Color.IndianRed;
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
                        txtUserName.BorderColor = Color.IndianRed;
                        lblErrorPass.ForeColor = Color.Red;
                        continueProcess += 1;
                    }
                }
                catch (Exception ex)
                {
                    txtUserName.BorderColor = Color.IndianRed;
                    lblErrorPass.Text = ex.Message;
                    lblErrorPass.ForeColor = Color.Red;
                    continueProcess += 1;
                }
            }
            
            if (txtName.Text == "" || txtName.Text == null)
            {
                txtName.BorderColor = Color.IndianRed;
                continueProcess += 1;
            }
            else if (txtLName.Text == "" || txtLName.Text == null)
            {
                txtLName.BorderColor = Color.IndianRed;
                continueProcess += 1;
            }
            else if (txtDOB.Text == "" || txtDOB == null)
            {
                txtDOB.BorderColor = Color.IndianRed;
                continueProcess += 1;
            }
            else if(txtDOB.Text.Length > 10)
            {
                txtDOB.BorderColor = Color.IndianRed;
                continueProcess += 1;
            }
            else if (txtUserEmail.Text == "" || txtUserEmail == null)
            {
                txtUserEmail.BorderColor = Color.IndianRed;
                continueProcess += 1;
            }
            else if (ddScholarQual.SelectedValue == "None")
            {
                ddScholarQual.BorderColor = Color.IndianRed;
                continueProcess += 1;
            }
            else if(ddUsertype.SelectedValue == "None")
            {
                ddScholarQual.BorderColor = Color.Red;
                continueProcess += 1;
                lblErrorPass.Text = "Registration type not selected";
            }
            else if(txtPassword.Text == null || txtPassword.Text == "")
            {
                lblErrorPass.Text = "Please create a Password";
                continueProcess += 1;
                txtPassword.BorderColor = Color.Red;
            }
            else if(txtRetypePass.Text == null || txtRetypePass.Text == "")
            {
                lblErrorPass.Text = "Please retype your Password";
                continueProcess += 1;
                txtRetypePass.BorderColor = Color.Red;
            }

            if (continueProcess == 0)
            {
                //make sure the DOB is in correct format yyy-mm-dd.
                if (txtDOB.Text.IndexOf('-', 4) == -1 || txtDOB.Text.IndexOf('-', 7) == -1)
                {
                    txtDOB.Text = txtDOB.Text.Insert(4, "-");
                    txtDOB.Text = txtDOB.Text.Insert(7, "-");
                }

                try
                {
                    string encryptionPass = Convert.ToString(txtUserName.Text);
                    Encryption encryption = new Encryption();
                    Member member = new Member();

                    string encryptedString = encryption.Encrypt(encryptionPass, 
                        Convert.ToString(txtPassword.Text));

                    member.MemberID = Convert.ToString(txtUserName.Text);
                    member.MemberName = Convert.ToString(txtName.Text);
                    member.MemberLastName = Convert.ToString(txtLName.Text);
                    member.MemberDOB = Convert.ToDateTime(txtDOB.Text.ToString());
                    member.Password = Convert.ToString(encryptedString);
                    member.MemberType = Convert.ToChar(ddUsertype.SelectedValue);
                    member.ActiveTypeID = 'T';
                    member.Email = Convert.ToString(txtUserEmail.Text);
                    member.ContactNo = Convert.ToString(txtContactNum.Text);
                    member.ActivationExpiry = Convert.ToDateTime(DateTime.Today.AddDays(1));
                    member.ActivationDate = Convert.ToDateTime(DateTime.Today);
                    

                    bool success = dBHandler.BLL_AddMember(member);

                    if (ddUsertype.SelectedValue == "S")
                    {
                        Scholar scholar = new Scholar
                        {
                            ScholarID = Convert.ToString(txtUserName.Text),
                            QualificationID = Convert.ToString(ddScholarQual.SelectedValue)
                        };

                        dBHandler.BLL_AddScholarQualification(scholar);
                    }

                    EmailService emailService = new EmailService();

                    emailService.AutoEmailService(txtUserEmail.Text.ToString(), 
                        ddUsertype.SelectedItem.ToString(), "http://www.google.co.za");

                }
                catch(Exception ex)
                {
                    lblErrorPass.Text = ex.Message;
                }


            }
                

        }

    }


}





    
