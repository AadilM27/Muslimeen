using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TypeLib.ViewModels;
using TypeLib.Models;
using Muslimeen.BLL;

namespace Muslimeen.Content
{
    public partial class ProfileEditer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            divChangePassword.Visible = false;
            ddAssignedMosques.Items.Add(new ListItem("None", null));
            ddAssignedMosques.Text = "None";

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

            if(uspGetMember.MemberType.ToString() == "O") //O stands for Moderator.
            {

                uspGetModeratorDetails uspGetModeratorDetails = new uspGetModeratorDetails();
                uspGetModeratorDetails = dBHandler.BLL_GetModeratorDetails(Session["UserName"].ToString());

                txtUserName.Text = Convert.ToString(uspGetModeratorDetails.ModeratorID);
                txtName.Text = Convert.ToString(uspGetModeratorDetails.MemberName);
                txtLName.Text = Convert.ToString(uspGetModeratorDetails.MemberLastName);
                txtContactNum.Text = Convert.ToString(uspGetModeratorDetails.ContactNo);
                txtDOB.Text = Convert.ToString(uspGetModeratorDetails.MemberDOB);
                txtUserEmail.Text = Convert.ToString(uspGetModeratorDetails.Email);
                txtMemberType.Text = Convert.ToString(uspGetModeratorDetails.MemberType);
                txtQual.Text = Convert.ToString(uspGetModeratorDetails.QualificationDescription);
                ddAssignedMosques.SelectedValue = Convert.ToString(uspGetModeratorDetails.MosqueID);
                txtActivationDate.Text = Convert.ToString(uspGetModeratorDetails.ActivationDate);
                
            }
            else if(uspGetMember.MemberType.ToString() == "S") //S stands for Scholar.
            {

                uspGetScholarDetails uspGetScholarDetails = new uspGetScholarDetails();
                uspGetScholarDetails = dBHandler.BLL_GetScholarDetails(Session["UserName"].ToString());

                txtUserName.Text = Convert.ToString(uspGetScholarDetails.ScholarID);
                txtName.Text = Convert.ToString(uspGetScholarDetails.MemberName);
                txtLName.Text = Convert.ToString(uspGetScholarDetails.MemberLastName);
                txtContactNum.Text = Convert.ToString(uspGetScholarDetails.ContactNo);
                txtDOB.Text = Convert.ToString(uspGetScholarDetails.MemberDOB);
                txtUserEmail.Text = Convert.ToString(uspGetScholarDetails.Email);
                txtMemberType.Text = Convert.ToString(uspGetScholarDetails.MemberType);
                txtQual.Text = Convert.ToString(uspGetScholarDetails.QualificationDescription);
                ddAssignedMosques.SelectedValue = Convert.ToString(uspGetScholarDetails.MosqueID);
                txtActivationDate.Text = Convert.ToString(uspGetScholarDetails.ActivationDate);
            }
            else if (uspGetMember.MemberType.ToString() == "M" || uspGetMember.MemberType.ToString() == "A") //M stands for Member, A for Admin.
            {

                txtUserName.Text = Convert.ToString(uspGetMember.MemberID);
                txtName.Text = Convert.ToString(uspGetMember.MemberName);
                txtLName.Text = Convert.ToString(uspGetMember.MemberLastName);
                txtContactNum.Text = Convert.ToString(uspGetMember.ContactNo);
                txtDOB.Text = Convert.ToString(uspGetMember.MemberDOB);
                txtUserEmail.Text = Convert.ToString(uspGetMember.Email);
                txtMemberType.Text = Convert.ToString(uspGetMember.MemberType);
                ddAssignedMosques.SelectedValue = Convert.ToString(uspGetMember.MosqueID);
                txtActivationDate.Text = Convert.ToString(uspGetMember.ActivationDate);
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
    }
}