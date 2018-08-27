using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TypeLib.Models;
using TypeLib.ViewModels;
using Muslimeen.BLL;
using System.IO;
using System.Globalization;

namespace Muslimeen.Content.Forum
{
    public partial class AddTopic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserName"].ToString().Length < 1)
                {
                    Response.Redirect("default.aspx");
                }
                frmName.Text = "<b>" + Session["UserName"].ToString() + "</b>";

            }
            catch (NullReferenceException)
            {

            }

        }
        public void DoAddTopic(object sender, System.EventArgs e)
        {
            try
            {
                DBHandler han = new DBHandler();

                ForumTopics frm = new ForumTopics();

                frm.TopicSubject = frmPost.Text;
                frm.TopicCreateName = Session["UserName"].ToString();
                han.BLL_InsertForumTopics(frm);

                Response.Redirect("Topics.aspx", true);
            }
            catch (Exception objError)
            {
                // display error details
                outError.InnerHtml = "<b>* Error while accessing data</b>.<br />" + objError.Message + "<br />" + objError.Source;
                return;  //and stop execution

            }

        }

    }
}