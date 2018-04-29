using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
    }
}