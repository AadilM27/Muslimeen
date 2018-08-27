using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using TypeLib.Models;
using TypeLib.ViewModels;
using Muslimeen.BLL;
using System.IO;
using System.Globalization;

namespace Muslimeen.Content.Forum
{
    public partial class Topics : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("default.aspx");
            }
            welcome.InnerHtml = "Welcome " + Session["UserName"] + ", choose a topic to see the postings.<P>";
            ListTopics();
        }
        public void ListTopics()
        {
            try
            {
                DBHandler han = new DBHandler();
                DataGrid1.DataSource = han.BLL_GetForumTopics();
                DataGrid1.DataBind();
                
                if (DataGrid1.Items.Count == 0)
                {
                    outError.InnerHtml = "There are currently no Postings for this topic, start the posts with the form above.";
                }

            }
            catch (Exception objError)
            {
                //display error details
                outError.InnerHtml = "<b>* Error while accessing data</b>.<br />"
                    + objError.Message + "<br />" + objError.Source;
                return;  //and stop execution

            }


        }
    }
}