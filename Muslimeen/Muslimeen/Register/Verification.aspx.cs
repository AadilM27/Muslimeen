using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TypeLib.ViewModels;
using TypeLib.Models;
using Muslimeen.BLL;
using System.Drawing;

namespace Muslimeen.Register
{
    public partial class Verification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorPass.Text = "";
        }

        protected void btnVerify_Click(object sender, EventArgs e)
        {
            int ContProcess = 0;
            bool success = false;

            if (txtMemberID.Text == null || txtMemberID.Text == "")
            {
                ContProcess += 1;
                lblErrorPass.Text = "Please Enter your User Name";
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
                    string memberPassword = Convert.ToString(txtPassword.Text);
                    string encryptionPass = Convert.ToString(txtMemberID.Text);
                    Encryption encryption = new Encryption();
                    DBHandler dBHandler = new DBHandler();
                    uspGetMember uspGetMember = new uspGetMember();

                    uspGetMember = dBHandler.BLL_GetMember(txtMemberID.Text.ToString());

                    string decryptedString = encryption.Decrypt(encryptionPass, Convert.ToString(uspGetMember.Password));

                    if (uspGetMember.MemberID == txtMemberID.Text.ToString())
                    {
                        if (decryptedString == Convert.ToString(txtPassword.Text))
                        {
                            uspVerifyMember uspVerifyMember = new uspVerifyMember()
                            {
                                MemberID = Convert.ToString(txtMemberID.Text.ToString())
                            };

                            dBHandler.BLL_VerifyMember(uspVerifyMember);//Change the Expiry date to NULL and Active Status to Y.
                            success = true;
                        }
                        else
                        {
                            lblErrorPass.Text = "Incorrect Password or User Name";
                        }
                    }
                    else
                    {
                        lblErrorPass.Text = "Incorrect Password or User Name";
                    }
                }
                catch (InvalidCastException)
                {   //ActivationExpiry returns null.
                   lblErrorPass.Text = "Incorrect Password or Member is already verified";
                }
                catch(NullReferenceException)
                {   //No User Name does not exist in database.
                    lblErrorPass.Text = "Incorrect Password or User Name";
                }
                catch(Exception ex)
                {
                    lblErrorPass.Text = ex.Message + "\nContact Muslimeen for help, copy the above error information.";
                }
                finally
                {

                }

                if(success == true)
                {
                    lblErrorPass.ForeColor = Color.Black;
                    lblErrorPass.Text = "Thank you";
                    Response.Redirect("~/Content/Default.aspx");
                }
            }
        }
    }
}