using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TypeLib.ViewModels;
using TypeLib.Models;
using Muslimeen.BLL;

namespace Muslimeen.Login
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HttpCookie httpCookie = Request.Cookies["RememberMe"];

                if (httpCookie != null)
                {
                    if (httpCookie["DoRemember"] == "Yes")
                    {
                        txtUserName.Text = Convert.ToString(httpCookie["UserName"]);
                        chkRememberMe.Checked = true;
                    }
                }
                else
                {
                    chkRememberMe.Checked = false;
                }
            }            
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Register/Register.aspx");
        }

        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            Encryption encryption = new Encryption();
            string encryptionPass = "NexTech";
            DBHandler dBHandler = new DBHandler();
            uspGetMember uspGetMember = new uspGetMember();

            lblErrorPass.Text = "";

            try
            {
                uspGetMember = dBHandler.BLL_GetMember(txtUserName.Text.ToString());

                if (uspGetMember.MemberID == txtUserName.Text.ToString())
                {
                    string decryptedString = encryption.Decrypt(encryptionPass, Convert.ToString(uspGetMember.Password));

                    if (decryptedString == Convert.ToString(txtPassword.Text))
                    {
                        Session["UserName"] = txtUserName.Text.ToString();
                        Session.Timeout = 1;
                        Response.Redirect("~/Content/Default.aspx");
                    }
                    else
                    {
                        lblErrorPass.Text = "Incorrect password or Username";
                    }

                }
                else
                {
                    lblErrorPass.Text = " Incorrect password or Username";
                }
            }
            catch(System.NullReferenceException)
            {
                lblErrorPass.Text = "User name does not exist or is incorrect";
            }
            catch(Exception ex)
            {
                lblErrorPass.Text = ex.Message;
            }


        }

        protected void chkRememberMe_CheckedChanged(object sender, EventArgs e)
        {
            if(chkRememberMe.Checked)
            {
                HttpCookie httpCookie = new HttpCookie("RememberMe"); //create the cookie.

                httpCookie["UserName"] = Convert.ToString(txtUserName.Text);
                httpCookie["DoRemember"] = "Yes";
                httpCookie.Expires = DateTime.Now.AddYears(1);
                Response.Cookies.Add(httpCookie);
            }
            else if(!chkRememberMe.Checked)
            {
                HttpCookie httpCookie = new HttpCookie("RememberMe"); //remove the cookie.
                httpCookie.Expires = DateTime.Now.AddYears(-1);
                Response.Cookies.Add(httpCookie);
            }
        }
    }
}