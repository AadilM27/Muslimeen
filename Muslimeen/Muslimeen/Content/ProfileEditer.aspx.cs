﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TypeLib.ViewModels;
using TypeLib.Models;
using Muslimeen.BLL;
using System.Drawing;

namespace Muslimeen.Content
{
    public partial class ProfileEditer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorPass.ForeColor = Color.Red;
            lblErrorPass.Text = "";
            txtName.BorderColor = Color.Empty;
            txtLName.BorderColor = Color.Empty;
            txtUserEmail.BorderColor = Color.Empty;
            txtOldPassword.BorderColor = Color.Empty;
            txtPassword.BorderColor = Color.Empty;
            txtRetypePass.BorderColor = Color.Empty;

            if (!IsPostBack)
            {
                divChangePassword.Visible = false;
                ddAssignedMosques.Items.Add(new ListItem("None", null));
                ddAssignedMosques.SelectedValue = null;

                txtUserName.ReadOnly = true;
                txtDOB.ReadOnly = true;
                txtQual.ReadOnly = true;
                txtMemberType.ReadOnly = true;
                txtActivationDate.ReadOnly = true;

                DBHandler dBHandler = new DBHandler();
                uspGetAllMosques uspGetAllMosques = new uspGetAllMosques();
                List<uspGetAllMosques> list = new List<uspGetAllMosques>();

                list = dBHandler.BLL_GetAllMosques();
                foreach (uspGetAllMosques mosque in list)
                {
                    ddAssignedMosques.Items.Add(new ListItem(mosque.MosqueName.ToString(),
                        mosque.MosqueID.ToString()));
                }

                uspGetMember uspGetMember = new uspGetMember();
                uspGetMember = dBHandler.BLL_GetMember(Session["UserName"].ToString());

                if (uspGetMember.MemberType.ToString() == "O") //O stands for Moderator.
                {
                    uspGetModeratorDetails uspGetModeratorDetails = new uspGetModeratorDetails();
                    uspGetModeratorDetails = dBHandler.BLL_GetModeratorDetails(Session["UserName"].ToString());

                    txtUserName.Text = Convert.ToString(uspGetModeratorDetails.ModeratorID);
                    txtName.Text = Convert.ToString(uspGetModeratorDetails.MemberName);
                    txtLName.Text = Convert.ToString(uspGetModeratorDetails.MemberLastName);
                    txtContactNum.Text = Convert.ToString(uspGetModeratorDetails.ContactNo);
                    txtDOB.Text = Convert.ToString(uspGetModeratorDetails.MemberDOB).Remove(11, 12);
                    txtUserEmail.Text = Convert.ToString(uspGetModeratorDetails.Email);
                    if (uspGetModeratorDetails.MemberType.ToString() == "O")
                    {
                        txtMemberType.Text = "Moderator";
                    }
                    txtQual.Text = Convert.ToString(uspGetModeratorDetails.QualificationDescription);
                    ddAssignedMosques.SelectedValue = Convert.ToString(uspGetModeratorDetails.MosqueID);
                    txtActivationDate.Text = Convert.ToString(uspGetModeratorDetails.ActivationDate);

                }
                else if (uspGetMember.MemberType.ToString() == "S") //S stands for Scholar.
                {
                    uspGetScholarDetails uspGetScholarDetails = new uspGetScholarDetails();
                    uspGetScholarDetails = dBHandler.BLL_GetScholarDetails(Session["UserName"].ToString());

                    txtUserName.Text = Convert.ToString(uspGetScholarDetails.ScholarID);
                    txtName.Text = Convert.ToString(uspGetScholarDetails.MemberName);
                    txtLName.Text = Convert.ToString(uspGetScholarDetails.MemberLastName);
                    txtContactNum.Text = Convert.ToString(uspGetScholarDetails.ContactNo);
                    txtDOB.Text = Convert.ToString(uspGetScholarDetails.MemberDOB).Remove(11, 12);
                    txtUserEmail.Text = Convert.ToString(uspGetScholarDetails.Email);
                    if (uspGetScholarDetails.MemberType.ToString() == "S")
                    {
                        txtMemberType.Text = "Scholar";
                    }
                    txtQual.Text = Convert.ToString(uspGetScholarDetails.QualificationDescription);
                    ddAssignedMosques.SelectedValue = Convert.ToString(uspGetScholarDetails.MosqueID);
                    txtActivationDate.Text = Convert.ToString(uspGetScholarDetails.ActivationDate);
                }
                else if (uspGetMember.MemberType.ToString() == "M" || uspGetMember.MemberType.ToString() == "A") //M stands for Member, A for Admin.
                {
                    divQual.Visible = false;
                    txtUserName.Text = Convert.ToString(uspGetMember.MemberID);
                    txtName.Text = Convert.ToString(uspGetMember.MemberName);
                    txtLName.Text = Convert.ToString(uspGetMember.MemberLastName);
                    txtContactNum.Text = Convert.ToString(uspGetMember.ContactNo);
                    txtDOB.Text = Convert.ToString(uspGetMember.MemberDOB).Remove(11, 12);
                    txtUserEmail.Text = Convert.ToString(uspGetMember.Email);
                    if (uspGetMember.MemberType.ToString() == "M")
                    {
                        txtMemberType.Text = "Member";
                    }
                    else if(uspGetMember.MemberType.ToString() == "A")
                    {
                        txtMemberType.Text = "Admin";
                    }
                    ddAssignedMosques.SelectedValue = Convert.ToString(uspGetMember.MosqueID);
                    txtActivationDate.Text = Convert.ToString(uspGetMember.ActivationDate);
                }
            }
        }

        protected void chkChangePassword_CheckedChanged(object sender, EventArgs e)
        {
            if(chkChangePassword.Checked)
            {
                divChangePassword.Visible = true;
            }
            else if(chkChangePassword.Checked == false)
            {
                divChangePassword.Visible = false;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int continueProcess = 0;
                UpdateMember updateMember = new UpdateMember();
                DBHandler dBHandler = new DBHandler();

                if(txtName.Text == null || txtName.Text == "")
                {
                    lblErrorPass.Text = "Name field can not be empty";
                    txtName.BorderColor = Color.Red;
                    continueProcess += 1;
                }
                else if(txtLName.Text == null || txtLName.Text == "")
                {
                    txtLName.BorderColor = Color.Red;
                    continueProcess += 1;
                    lblErrorPass.Text = "Last Name field can not be empty";
                }
                else if(txtUserEmail.Text == null || txtUserEmail.Text == "")
                {
                    txtUserEmail.BorderColor = Color.Red;
                    continueProcess += 1;
                    lblErrorPass.Text = "Email field can not be empty";
                }


                if (chkChangePassword.Checked == false)
                {
                    updateMember.MemberID = Session["UserName"].ToString();
                    updateMember.MemberName = txtName.Text.ToString();
                    updateMember.MemberLastName = txtLName.Text.ToString();
                    if (ddAssignedMosques.Text != "None")
                    {
                        updateMember.MosqueID = Convert.ToInt32(ddAssignedMosques.SelectedValue);
                    }

                    updateMember.ContactNo = txtContactNum.Text.ToString();
                    updateMember.Email = txtUserEmail.Text.ToString();

                    dBHandler.BLL_UpdateMember(updateMember);
                }
                else if (chkChangePassword.Checked == true)
                {
                    if (txtPassword.Text.ToString() != txtRetypePass.Text.ToString() || txtPassword.Text == null || txtRetypePass == null)
                    {
                        txtRetypePass.BorderColor = Color.Red;
                        txtPassword.BorderColor = Color.Red;
                        lblErrorPass.Text = "Passwords do not match";
                        continueProcess += 1;
                    }


                    if (!(continueProcess > 0))
                    {
                        uspGetMember uspGetMember = new uspGetMember();
                        uspGetMember = dBHandler.BLL_GetMember(Convert.ToString(Session["UserName"]));

                        string encryptionPass = Session["UserName"].ToString();
                        Encryption encryption = new Encryption();
                        string dencryptedString = encryption.Decrypt(encryptionPass, Convert.ToString(uspGetMember.Password)); //decrypt old password.

                        if (dencryptedString == Convert.ToString(txtOldPassword.Text))
                        {
                            updateMember.MemberID = Session["UserName"].ToString();
                            updateMember.MemberName = txtName.Text.ToString();
                            updateMember.MemberLastName = txtLName.Text.ToString();
                            if (ddAssignedMosques.Text != "None")
                            {
                                updateMember.MosqueID = Convert.ToInt32(ddAssignedMosques.SelectedValue.ToString());
                            }
                            updateMember.ContactNo = txtContactNum.Text.ToString();
                            updateMember.Email = txtUserEmail.Text.ToString();

                            dBHandler.BLL_UpdateMember(updateMember);

                            UpdateMemberPassword updateMemberPassword = new UpdateMemberPassword();
                            string encryptionPass2 = Session["UserName"].ToString();

                            updateMemberPassword.MemberID = Session["UserName"].ToString();
                            string newPassword = encryption.Encrypt(encryptionPass2, Convert.ToString(txtPassword.Text)); //encrypt new passworda.
                            updateMemberPassword.Password = newPassword;

                            dBHandler.BLL_UpdateMemberPassword(updateMemberPassword);
                        }
                        else
                        {
                            lblErrorPass.Text = "Your password is incorrect";
                            txtOldPassword.BorderColor = Color.Red;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblErrorPass.Text = ex.Message + "\n Contact muslimeen for more information";
            }
            
        }
    }
}