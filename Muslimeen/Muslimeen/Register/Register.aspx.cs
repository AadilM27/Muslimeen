using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace Muslimeen.Register
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void ddUsertype_SelectedIndexChanged(object sender, EventArgs e)
        {

            if(ddUsertype.Text == "Scholar")
            {
                txtScholarQual.Visible = true;
                
            }
            else
            {
                txtScholarQual.Visible = false;
            }
                
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text.ToString() != txtRetypePass.Text.ToString())
            {
                txtRetypePass.BorderColor = Color.IndianRed;
                txtPassword.BorderColor = Color.IndianRed;
                lblErrorPass.Text = "Passwords do not match";
                lblErrorPass.ForeColor = Color.Red;
            }
            else if (txtPassword.Text.ToString() == txtRetypePass.Text.ToString())
            {
                txtRetypePass.BorderColor = Color.Empty;
                txtPassword.BorderColor = Color.Empty;
                lblErrorPass.Text = "";

            }
        }

        protected void btnShowPass_Click(object sender, EventArgs e)
        {
            if (txtPassword.TextMode == TextBoxMode.Password && txtRetypePass.TextMode == TextBoxMode.Password)
            {
                txtPassword.TextMode = TextBoxMode.SingleLine;
                txtRetypePass.TextMode = TextBoxMode.SingleLine;
            }
            else if (txtPassword.TextMode == TextBoxMode.SingleLine && txtRetypePass.TextMode == TextBoxMode.SingleLine)
            {
                txtPassword.TextMode = TextBoxMode.Password;
                txtRetypePass.TextMode = TextBoxMode.Password;
            }

        }

        protected void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (txtPassword.TextMode == TextBoxMode.Password && txtRetypePass.TextMode == TextBoxMode.Password)
            {
                txtPassword.TextMode = TextBoxMode.SingleLine;
                txtRetypePass.TextMode = TextBoxMode.SingleLine;
            }
            else if (txtPassword.TextMode == TextBoxMode.SingleLine && txtRetypePass.TextMode == TextBoxMode.SingleLine)
            {
                txtPassword.TextMode = TextBoxMode.Password;
                txtRetypePass.TextMode = TextBoxMode.Password;
            }
        }
    }
}