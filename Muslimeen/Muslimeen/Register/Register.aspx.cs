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
            txtDOB.MaxLength = 15;

            if (IsPostBack)
            {
                txtPassword.Attributes["Value"] = txtPassword.Text;
                txtRetypePass.Attributes["Value"] = txtRetypePass.Text;
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
                    ddScholarQual.Items.Add(new ListItem(qual.QualificationDescription.ToString(), qual.QualificationID.ToString()));
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

            if (txtMemberID.Text == "" || txtMemberID.Text == null)
            {
                txtMemberID.BorderColor = Color.IndianRed;
                lblErrorPass.Text = "Member ID field can not be empty";
                continueProcess += 1;
            }
            else if (txtMemberID.Text.Length > 15 || txtMemberID.Text.Length < 5)
            {
                txtMemberID.BackColor = Color.IndianRed;
                lblErrorPass.Text = "Member ID is too long or too short";
                continueProcess += 1;
            }

            if (txtMemberID.Text != "" || txtMemberID.Text != null)
            {
                try
                {
                    if (dBHandler.BLL_GetMember(txtMemberID.Text.ToString()) != null)
                    {
                        lblErrorPass.Text = "Error- Member ID taken";
                        txtMemberID.BorderColor = Color.IndianRed;
                        lblErrorPass.ForeColor = Color.Red;
                        continueProcess += 1;
                    }
                }
                catch (Exception ex)
                {
                    txtMemberID.BorderColor = Color.IndianRed;
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
            if (txtLName.Text == "" || txtLName.Text == null)
            {
                txtLName.BorderColor = Color.IndianRed;
                continueProcess += 1;
            }
            if (txtContactNum.Text == "" || txtContactNum == null)
            {
                txtContactNum.BorderColor = Color.IndianRed;
                continueProcess += 1;
            }
            if (txtDOB.Text == "" || txtDOB == null)
            {
                txtDOB.BorderColor = Color.IndianRed;
                continueProcess += 1;
            }
            if (txtUserEmail.Text == "" || txtUserEmail == null)
            {
                txtUserEmail.BorderColor = Color.IndianRed;
                continueProcess += 1;
            }
            if (ddScholarQual.SelectedValue == "None")
            {
                ddScholarQual.BorderColor = Color.IndianRed;
                continueProcess += 1;
            }

            if (continueProcess == 0)
            {

                txtMemberID.BorderColor = Color.Empty;
                txtName.BorderColor = Color.Empty;
                txtLName.BorderColor = Color.Empty;
                txtContactNum.BorderColor = Color.Empty;
                txtDOB.BorderColor = Color.Empty;
                txtUserEmail.BorderColor = Color.Empty;
                ddUsertype.BorderColor = Color.Empty;
                txtPassword.BorderColor = Color.Empty;
                txtRetypePass.BorderColor = Color.Empty;
                lblErrorPass.Text = "";

                try
                {
                    Member member = new Member
                    {
                        MemberID = Convert.ToString(txtMemberID.Text),
                        MemberName = Convert.ToString(txtName.Text),
                        MemberLastName = Convert.ToString(txtLName.Text),
                        MemberDOB = Convert.ToDateTime(txtDOB.Text.ToString()),
                        Password = Convert.ToString(txtPassword.Text),
                        MemberType = Convert.ToChar(ddUsertype.SelectedValue),
                        Active = 'Y',
                        Email = Convert.ToString(txtUserEmail.Text),
                        ContactNo = Convert.ToString(txtContactNum.Text)
                    };

                    bool success = dBHandler.BLL_AddMember(member);

                    if (ddUsertype.SelectedValue == "S")
                    {
                        Scholar scholar = new Scholar
                        {
                            ScholarID = Convert.ToString(txtMemberID.Text),
                            QualificationID = Convert.ToString(ddScholarQual.SelectedValue)
                        };

                        dBHandler.BLL_AddScholarQualification(scholar);
                    }

                    EmailService emailService = new EmailService();

                    emailService.AutoEmailService(txtUserEmail.Text.ToString(), ddUsertype.SelectedItem.ToString());
                }
                catch(Exception ex)
                {
                    lblErrorPass.Text = ex.Message;
                }


            }
                

        }
    }


}





    
