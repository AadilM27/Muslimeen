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
using System.Data;

namespace Muslimeen.Content.Forum
{
    public partial class DeleteRecordForum : System.Web.UI.Page
    {
        protected void Page_Load(object sender,EventArgs e)
        {
            // Page used to Delete any Record from the DataBase
            // QueryStrings: 
            //		"T"   = Type (i.e. posting or Topic)
            //		"ID"  = Record ID to Delete
            //		"TID" = TopicID (fro Postings.aspx)
            //		"S"   = Subject (for Postings.aspx)
            // Build DELETE statement based on Type

            try
            {
                DBHandler handle = new DBHandler();
                ForumTopics top = new ForumTopics();
                uspGetPostings post = new uspGetPostings();
                string strURL;

                top.ForumTopicID = int.Parse(Request.QueryString["ID"]);
                post.PostID = int.Parse(Request.QueryString["ID"]);

                if (Request.QueryString["T"] == "T")
                {
                    handle.BLL_DeleteForumTopics(top);
                    strURL = "Topics.aspx";
                }
                else
                {
                    handle.BLL_DeletePostings(post);
                    strURL = "Postings.aspx?ID=" + Request.QueryString["TID"] + "&S=" + Request.QueryString["S"];
                }
                Response.Redirect(strURL);
            }
            catch(Exception objError)
            {
                //display error details
                Response.Write("<b>Error while accessing data</b>.<br />" + objError.Message + "<br />" + objError.Source);
                
            }

        }
    }
}