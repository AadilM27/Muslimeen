using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TypeLib.ViewModels;
using TypeLib.Models;
using Muslimeen.BLL;

namespace Muslimeen.Register
{
    public partial class Verification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnVerify_Click(object sender, EventArgs e)
        {
            int ContProcess = 0;

            if (txtMemberID.Text == null || txtMemberID.Text == "")
            {
                ContProcess += 1;
                lblErrorPass.Text = "Please Enter your Member ID";
            }
            else if (txtPassword.Text == null || txtPassword.Text == "")
            {
                ContProcess += 1;
                lblErrorPass.Text = "Please Enter your Password";
            }

            if (ContProcess == 0)
            {
                try
                {
                    DBHandler dBHandler = new DBHandler();
                    uspGetMember uspGetMember = new uspGetMember();

                    uspGetMember = dBHandler.BLL_GetMember(txtMemberID.Text.ToString());

                    if (uspGetMember.MemberID == txtMemberID.Text.ToString() && uspGetMember.Password == Convert.ToString(txtPassword.Text))
                    {
                        uspVerifyMember uspVerifyMember = new uspVerifyMember()
                        {
                            MemberID = Convert.ToString(txtMemberID.Text.ToString())
                        };

                        dBHandler.BLL_VerifyMember(uspVerifyMember);

                        lblErrorPass.Text = "";
                    }
                    else
                    {
                        lblErrorPass.Text = "Wrong Password or Member ID";
                    }
                }
                catch (InvalidCastException)
                {
                    lblErrorPass.Text = "Incorrect Password or Member is already verified";
                }
                catch(NullReferenceException)
                {
                    lblErrorPass.Text = "Incorrect Member ID";
                }
            }
        }
    }
}