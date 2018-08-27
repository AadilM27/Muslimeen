using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TypeLib.Models;
using TypeLib.ViewModels;
using Muslimeen.BLL;


namespace Muslimeen.Content.Forum
{
    public partial class Postings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UserName"] == null)
            {
                Response.Redirect("default.aspx");
            }

            frmName.Text = "<b>" + Session["UserName"].ToString() + "</b>";
            ListPostings();
        }
        private void ListPostings()
        {
            try
            {
                DBHandler han = new DBHandler();
                DataGrid1.DataSource = han.BLL_GetPostings(int.Parse(Request.QueryString["ID"]));
                DataGrid1.DataBind();

                if (DataGrid1.Items.Count == 0)
                {
                    outError.InnerHtml = "There are currently no Postings for this topic, start the posts with the form above.";
                }

                //Write the Topic Subject as the Page Header
                TopicSubject.InnerHtml = "<h4>" + Request.QueryString["S"] + "</h4>";

            }
            catch (Exception objError)
            {
                DBHandler han = new DBHandler();
                //display error details
                outError.InnerHtml = "<b>* Error while accessing data</b>.<br />" + objError.Message + "<br />" + objError.InnerException + "<P>" + objError.Source + "<P>" + objError.StackTrace + "<P>" + han.BLL_GetPostings(int.Parse(Request.QueryString["ID"]));
                return;  //and stop execution

            }
            
        }
        public string AdminVisible()
        {
            if (Session["admin"] == "yes")
            {
                return " Visible=true";
            }
            else
            {
                return "";
            }
        }
        public void DoAddPost(object sender,EventArgs e)
        {
            try
            {
                DBHandler han = new DBHandler();
                uspGetPostings p = new uspGetPostings();
                p.PostContent = frmPost.Text;
                p.PostCreateName = Session["UserName"].ToString();
                p.ForumTopicID = int.Parse(Request.QueryString["ID"]);

                han.BLL_InsertPostings(p);

                Response.Redirect("Postings.aspx?ID=" + Request.QueryString["ID"] + "&S=" + Request.QueryString["S"], true);
                
            }
            catch(Exception objError)
            {
                // display error details

                outError.InnerHtml = "<b>* Error while accessing data</b>.<br />"
                    + objError.Message + "<br />" + objError.Source;
                return;  //and stop execution
            }
        }

    }
}