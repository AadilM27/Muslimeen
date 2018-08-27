using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Muslimeen.Content.Forum
{
    public partial class ForumUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void DoLogin(object sender, EventArgs e)
        {
            if (frmUserName.Text == "admin")
            {
                if (frmPassword.Text == "password")
                {
                    Session["UserName"] = frmUserName.Text;
                    Session["admin"] = "yes";
                    Response.Redirect("Topics.aspx");
                }
                else
                {
                    frmPassword.Visible = true;
                }
            }
            else
            {
                Session["UserName"] = frmUserName.Text;
                Response.Redirect("Topics.aspx");
            }
        }
    }
}