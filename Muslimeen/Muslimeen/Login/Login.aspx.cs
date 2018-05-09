using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TypeLib.ViewModels;
using TypeLib.Models;
using Muslimeen.BLL;

namespace Muslimeen.SignIn
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Register/Register.aspx");
        }

        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            DBHandler dBHandler = new DBHandler();
            uspGetMember uspGetMember = new uspGetMember();

            

        }
    }
}