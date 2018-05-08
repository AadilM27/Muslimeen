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
                    string memberPassword = Convert.ToString(txtPassword.Text);
                    string encryptionPass = "NexTech";
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

                            lblErrorPass.Text = "";
                        }
                        else
                        {
                            lblErrorPass.Text = "Decryption failier";
                        }

                        txtMemberID.Enabled = false;
                        txtPassword.Enabled = false;
                        lblErrorPass.Text = "Thank you";

                    }
                    else
                    {
                        lblErrorPass.Text = "Wrong Password or Member ID";
                    }
                }
                catch (InvalidCastException)
                {   //ActivationExpiry will be Null, this is why
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