using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TypeLib.ViewModels;
using TypeLib.Models;
using Muslimeen.BLL;
using System.Drawing;

namespace Muslimeen.Login
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorPass.ForeColor = Color.Red;
            
            if(!IsPostBack)
            {
                lblErrorPass.Text = "";
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            int continueProcess = 0;

            uspGetMember member = new uspGetMember();
            DBHandler dBHandler = new DBHandler();
            Encryption encryption = new Encryption();
            EmailService emailService = new EmailService();
            UpdateMemberPassword updatePassword = new UpdateMemberPassword();

            try
            {
                if (txtUserName.Text == null || txtUserName.Text == "")
                {
                    lblErrorPass.Text = "Please enter your user name";
                    continueProcess += 1;
                }
                else if (dBHandler.BLL_GetMember(txtUserName.Text.ToString()) == null)
                {
                    lblErrorPass.Text = "User Name does not exist";
                    continueProcess += 1;
                }


                if (continueProcess == 0)
                {

                    member = dBHandler.BLL_GetMember(txtUserName.Text.ToString());

                    string newPassword = CreatePassword(8).ToString(); //generate new password.

                    emailService.AutoEmailService(member.Email.ToString(),
                        member.MemberType.ToString(), "null", "ForgotPassword",
                            member.MemberID.ToString(), newPassword.ToString()); //Send user email with new password.

                    string encryptedString = encryption.Encrypt(txtUserName.Text.ToString(), Convert.ToString(newPassword)); //encrypt new password.
                    updatePassword.Password = encryptedString;
                    updatePassword.MemberID = txtUserName.Text.ToString();

                    dBHandler.BLL_UpdateMemberPassword(updatePassword); //update user password.

                    Response.Redirect("~/Content/Default.aspx");
                }
            }
            catch (Exception ex)
            {
                lblErrorPass.Text = ex.Message;
            }
        }

        public string CreatePassword(int length) //build Temp new passwords
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }

    }
}