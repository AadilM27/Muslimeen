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
    public partial class Mosque : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DBHandler dBHandler = new DBHandler();
            rptMosque.DataSource = dBHandler.BLL_GetMosque();
            rptMosque.DataBind();
        }
    }
}