using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TypeLib.ViewModels;
using TypeLib.Models;
using Muslimeen.BLL;
using System.Text;

namespace Muslimeen.Login
{
    public partial class Login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            try
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
            catch
            {

            }
            
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Register/Register.aspx");
        }

        protected void btnLogIn_Click(object sender, EventArgs e)
        {

            Encryption encryption = new Encryption();
            string encryptionPass = Convert.ToString(txtUserName.Text);
            DBHandler dBHandler = new DBHandler();
            uspGetMember uspGetMember = new uspGetMember();

            lblErrorPass.Text = "";

            try
            {
                uspGetMember = dBHandler.BLL_GetMember(txtUserName.Text.ToString());

                if (uspGetMember.ActiveTypeID == 'Y')
                {

                    if (uspGetMember.MemberID == txtUserName.Text.ToString())
                    {
                        string decryptedString = encryption.Decrypt(encryptionPass, Convert.ToString(uspGetMember.Password));

                        if (decryptedString == Convert.ToString(txtPassword.Text))
                        {
                            Session["UserName"] = txtUserName.Text.ToString();
                            Session.Timeout = 30;
                            Session["MosqueID"] = uspGetMember.MosqueID.ToString();
                            Response.Redirect("../Content/Default.aspx");
                        }
                        else
                        {
                            lblErrorPass.Text = "Incorrect password or User Name";
                        }

                    }
                    else
                    {
                        lblErrorPass.Text = " Incorrect password or User Name";
                    }
                }
                else
                {
                    lblErrorPass.Text = "Please verify your account first";
                }
            }
            catch (System.NullReferenceException)
            {
                lblErrorPass.Text = "User name does not exist or is incorrect";
            }
            catch (System.Data.SqlClient.SqlException)
            {
                lblErrorPass.Text = "Server might be offline, please try again later";
            }
            catch (Exception ex)
            {
                lblErrorPass.Text = ex.Message + "\n Contact Muslimeen for more Information.";
            }
            finally
            {

            }



        }

        protected void chkRememberMe_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtUserName.Text == "" || txtUserName.Text == null) //this is to avoid storing a null in cookie
                {
                    lblErrorPass.Text = "Please enter your User name first";

                    if (chkRememberMe.Checked)
                    {
                        chkRememberMe.Checked = false;
                    }
                }
                else if (txtUserName.Text != "" || txtUserName.Text != null)
                {
                    if (chkRememberMe.Checked)
                    {
                        HttpCookie httpCookie = new HttpCookie("RememberMe"); //create the cookie.

                        httpCookie["UserName"] = Convert.ToString(txtUserName.Text);
                        httpCookie["DoRemember"] = "Yes";
                        httpCookie.Expires = DateTime.Now.AddYears(1);
                        Response.Cookies.Add(httpCookie);
                    }
                    else if (!chkRememberMe.Checked)
                    {
                        HttpCookie httpCookie = new HttpCookie("RememberMe"); //remove the cookie.
                        httpCookie.Expires = DateTime.Now.AddYears(-1);
                        Response.Cookies.Add(httpCookie);
                    }
                }
            }
            catch
            {

            }
        }

        protected void txtUserName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                HttpCookie httpCookie = new HttpCookie("RememberMe"); //replace the cookie value with new username, thats if the user kept the remember me check while loging in with different username. which he previously checked to remmeber 

                httpCookie["UserName"] = Convert.ToString(txtUserName.Text);
                httpCookie["DoRemember"] = "Yes";
                httpCookie.Expires = DateTime.Now.AddYears(1);
                Response.Cookies.Add(httpCookie);
            }
            catch
            {

            }
        }

        protected void btnForgotPass_Click(object sender, EventArgs e)
        {

            Response.Redirect("../Login/ResetPassword.aspx");
        }

    }
}