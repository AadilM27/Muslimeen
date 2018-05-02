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
                DBHandler dBHandler = new DBHandler();

                ddScholarQual.Dispose();
                ddScholarQual.Items.Clear();
                ddScholarQual.Visible = true;

                List<uspGetQualification> list = dBHandler.BLL_uspGetQualification();

                foreach (uspGetQualification qual in list)
                {
                    ddScholarQual.Items.Add(qual.QualificationDescription.ToString());
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