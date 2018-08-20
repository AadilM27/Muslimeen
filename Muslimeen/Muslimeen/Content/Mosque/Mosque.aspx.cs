using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TypeLib.ViewModels;
using Muslimeen.BLL;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;


namespace Muslimeen.Content.Mosque
{
    public partial class MosquePage : System.Web.UI.Page
    {
        DBHandler db = new DBHandler();
        protected void Page_Load(object sender, EventArgs e)
        {



            if (Session["UserName"] != null)
            {
                uspGetMember uspGetMember = new uspGetMember();

                uspGetMember = db.BLL_GetMember(Convert.ToString(Session["UserName"]));
                hplUserProfile.Text = uspGetMember.MemberLastName + ", " + uspGetMember.MemberName;
                divUserProfile.Visible = true;

                liMyMusbtn.Visible = true;
                liMyMusDivi.Visible = true;

                btnLogin.Text = "Log out";
                btnRegister.Visible = false;

            }
            else if (Session["UserName"] == null)
            {
                liMyMusbtn.Visible = false;
                liMyMusDivi.Visible = false;

                divUserProfile.Visible = false;
                Session.Clear();
            }


            try
            {

                Session["MosqueID"] = Request.QueryString["MosqueID"];

                rptGetEvents.DataSource = db.Bll_GetMosqueEvents(int.Parse(Session["MosqueID"].ToString()));
                rptGetEvents.DataBind();
                #region LoadAdd/UpdatePrayer



                try
                {

                    DateTime date = DateTime.Today;
                    uspGetSpecificDayPrayerTimes time = new uspGetSpecificDayPrayerTimes();
                    time = db.BLL_GetSpecficDayPrayerTimes(int.Parse(Session["MosqueID"].ToString()), date);
                    lblFajrAzaan.Text = time.FajrA.ToString();
                    lblFajrJamaat.Text = time.FajrJ.ToString();
                    lblDhuhrAzaan.Text = time.DhuhrA.ToString();
                    lblDhuhrJamaat.Text = time.DhuhrJ.ToString();
                    lblAsrAzaan.Text = time.AsrA.ToString();
                    lblAsrJamaat.Text = time.AsrJ.ToString();
                    lblMagribAzaan.Text = time.MagribA.ToString();
                    lblMagribJamaat.Text = time.MagribJ.ToString();
                    lblEishaAzaan.Text = time.EishaA.ToString();
                    lblEishaJamaat.Text = time.EishaJ.ToString();
                }
                catch { }
                try
                {

                    uspGetMosque mosque = new uspGetMosque();
                    mosque = db.GetMosque(int.Parse(Session["MosqueID"].ToString()));
                    Session["lblMosqueName"] = mosque.MosqueName.ToString();
                    lblMosqueAddress.Text = mosque.MosqueStreet + " " + mosque.MosqueSuburb;
                    Session["Address"] = lblMosqueAddress.Text.ToString();
                    lblYearEstablished.Text = mosque.YearEstablished.ToString().Substring(0, 10);
                    lblMosqueType.Text = mosque.MosqueType;
                    lblMosqueSize.Text = mosque.MosqueSize;
                    lblQuote.Text = mosque.MosqueQuote;
                    imgMosque.ImageUrl = mosque.MosqueImage;
                    lblMembers.Text = mosque.MemberCount.ToString();
                    uspGetMember member = new uspGetMember();
                    member = db.BLL_GetMosqueRep(int.Parse(Session["MosqueID"].ToString()));
                    lblMosqueRep.Text = member.MemberName.ToString() + " " + member.MemberLastName.ToString();
                }
                catch { throw; }
                #endregion LoadAdd/UpdatePrayer
            }
            catch { }
            if (!IsPostBack)
            {
                divDetails.Visible = false;
                divEvent.Visible = false;
                divLocation.Visible = false;
                divPrayerTimes.Visible = false;
                divPrayerTable.Visible = false;
                divgrid.Visible = false;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (btnLogin.Text == "Login")
            {
                Response.Redirect("~/Login/Login.aspx");
            }
            else if (btnLogin.Text == "Log out")
            {

                Session.Clear();
                Session.Abandon();
                Response.Redirect("~/Content/Default.aspx");
                btnLogin.Text = "Login";
                btnRegister.Visible = true;
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Register/Register.aspx");
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Content/Default.aspx");
        }

        protected void btnMosques_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Content/Mosque/ListMosque.aspx");
        }

        protected void btnScholars_Click(object sender, EventArgs e)
        {
            //redirect user to the scholars list page.
        }

        protected void btnLearnIslam_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Content/Learn Islam/LearnIslam.aspx");
        }

        protected void btnZakaah_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Content/ZakaahWebForms/Zakaah.aspx");
        }

        protected void btnAboutUs_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Content/AboutUs.aspx");
        }

        protected void btnMyMuslimeen_Click(object sender, EventArgs e)
        {
            DBHandler dBHandler = new DBHandler();

            uspGetMember uspGetMember = new uspGetMember();

            uspGetMember = dBHandler.BLL_GetMember(Convert.ToString(Session["UserName"]));

            if (uspGetMember.MemberType == 'A')
            {
                Response.Redirect("~/Content/MyAdmin.aspx");
            }
            else if (uspGetMember.MemberType == 'M')
            {
                Response.Redirect("~/Content/MyMember.aspx");
            }
            else if (uspGetMember.MemberType == 'O')
            {
                Response.Redirect("~/Content/MyModerator.aspx");
            }
            else if (uspGetMember.MemberType == 'S')
            {
                Response.Redirect("~/Content/MyScholar/AddArticle.aspx");
            }


        }

        protected void btnListEvents_Click(object sender, EventArgs e)
        {
            try
            {
               divViewActiveEvents.Visible = true;
               DateTime startDate = Convert.ToDateTime(txtStartDate.Text.ToString());
                DateTime EndDate = Convert.ToDateTime(txtEndDate.Text.ToString());
                rptGetEvents.DataSource = db.Bll_GetMosqueEventsDateRange(int.Parse(Session["MosqueID"].ToString()), startDate, EndDate);
                rptGetEvents.DataBind();
            }
            catch
            {

            }

        }

        protected void btnListPrayer_Click(object sender, EventArgs e)
        {
            lblTaskHeader.InnerText = btnPrayerTimes.Text.ToString();
            divDetails.Visible = false;
            divEvent.Visible = false;
            divLocation.Visible = false;
            divPrayerTable.Visible = true;
            divgrid.Visible = false;
            try
            {
                List<uspGetMosquePrayerTimes> list = new List<uspGetMosquePrayerTimes>();
                List<uspGetSpecificDayPrayerTimes> times = new List<uspGetSpecificDayPrayerTimes>();
                DateTime startDate = Convert.ToDateTime(txtPrayerStartDate.Text.ToString());
                DateTime endDate = Convert.ToDateTime(txtPrayerEndDate.Text.ToString());
                list = db.BLL_GetMosquePrayerTimes(int.Parse(Session["MosqueID"].ToString()), startDate, endDate);

                int count = 0;

                uspGetSpecificDayPrayerTimes pt = new uspGetSpecificDayPrayerTimes();

                foreach (uspGetMosquePrayerTimes prayer in list)
                {

                    if (count == 0)
                    {


                        pt.PrayerDate = prayer.PrayerDate.Date;
                        pt.PrayerDay = Convert.ToDateTime(pt.PrayerDate).DayOfWeek.ToString();
                        pt.FajrA = prayer.AdhaanTime;
                        pt.FajrJ = prayer.JamaatTime;


                    }
                    else if (count == 1)
                    {
                        pt.DhuhrA = prayer.AdhaanTime;
                        pt.DhuhrJ = prayer.JamaatTime;

                    }
                    else if (count == 2)
                    {
                        pt.AsrA = prayer.AdhaanTime;
                        pt.AsrJ = prayer.JamaatTime;


                    }
                    else if (count == 3)
                    {
                        pt.MagribA = prayer.AdhaanTime;
                        pt.MagribJ = prayer.JamaatTime;

                    }
                    else if (count == 4)
                    {
                        pt.EishaA = prayer.AdhaanTime;
                        pt.EishaJ = prayer.JamaatTime;
                        count = -1;
                        times.Add(pt);
                        pt = new uspGetSpecificDayPrayerTimes();

                    }

                    count++;

                }
                rptPrayerTimes.DataSource = times;
                rptPrayerTimes.DataBind();
                grdReports.DataSource = times;
                grdReports.DataBind();
            }
            catch { }
        }

        protected void btnMosqueDetails_Click(object sender, EventArgs e)
        {
            lblTaskHeader.InnerText = Session["lblMosqueName"].ToString();
            divDetails.Visible = true;
            divEvent.Visible = false;
            divLocation.Visible = false;
            divPrayerTimes.Visible = false;
        }

        protected void btnEvents_Click(object sender, EventArgs e)
        {
            lblTaskHeader.InnerText = btnEvents.Text.ToString();
            divDetails.Visible = false;
            divEvent.Visible = true;
            divLocation.Visible = false;
            divPrayerTimes.Visible = false;
            divPrayerTable.Visible = false;
            divgrid.Visible = false;
            divDisplayEvent.Visible = false;
            divViewActiveEvents.Visible = false;
        }

        protected void btnAddress_Click(object sender, EventArgs e)
        {
            lblTaskHeader.InnerText = btnAddress.Text.ToString();
            divDetails.Visible = false;
            divEvent.Visible = false;
            divLocation.Visible = true;
            divPrayerTimes.Visible = false;
            divPrayerTable.Visible = false;
            divgrid.Visible = false;


        }

        protected void btnPrayerTimes_Click(object sender, EventArgs e)
        {
            lblTaskHeader.InnerText = btnPrayerTimes.Text.ToString();
            divDetails.Visible = false;
            divEvent.Visible = false;
            divLocation.Visible = false;
            divPrayerTimes.Visible = true;
            divPrayerTable.Visible = false;
            divgrid.Visible = false;

        }

        protected void btnListPrayers_Click(object sender, EventArgs e)
        {

        }

        protected void PDF_ServerClick(object sender, EventArgs e)
        {
            try
            {
                PdfPTable pdfTable = new PdfPTable(grdReports.HeaderRow.Cells.Count);
                pdfTable.HorizontalAlignment = 0;
                foreach (TableCell Headercell in grdReports.HeaderRow.Cells)
                {
                    grdReports.HeaderRow.Cells[0].Text = "Date";
                    grdReports.HeaderRow.Cells[1].Text = "Day";
                    grdReports.HeaderRow.Cells[2].Text = "Fajr Adhaan";
                    grdReports.HeaderRow.Cells[3].Text = "Fajr Jamaat";
                    grdReports.HeaderRow.Cells[4].Text = "Dhuhr Adhaan";
                    grdReports.HeaderRow.Cells[5].Text = "Dhuhr Jamaat ";
                    grdReports.HeaderRow.Cells[6].Text = "Asr Adhaan";
                    grdReports.HeaderRow.Cells[7].Text = "Asr Jamaat ";
                    grdReports.HeaderRow.Cells[8].Text = "Magrib Adhaan";
                    grdReports.HeaderRow.Cells[9].Text = "Magrib Jamaat ";
                    grdReports.HeaderRow.Cells[10].Text = "Eisha Adhaan";
                    grdReports.HeaderRow.Cells[11].Text = "Eisha Jamaat";
                    Font font = new Font();
                    font.Color = new BaseColor(grdReports.HeaderStyle.ForeColor);
                    PdfPCell pdfCell = new PdfPCell(new Phrase(Headercell.Text, font));
                    pdfCell.BackgroundColor = new BaseColor(grdReports.HeaderStyle.BackColor);
                    pdfTable.AddCell(pdfCell);
                }

                foreach (GridViewRow gridviewrow in grdReports.Rows)
                {
                    foreach (TableCell tablecell in gridviewrow.Cells)
                    {
                        Font font = new Font();
                        font.Color = new BaseColor(grdReports.RowStyle.ForeColor);

                        PdfPCell pdfcell = new PdfPCell(new Phrase(tablecell.Text));
                        pdfcell.BackgroundColor = new BaseColor(grdReports.RowStyle.BackColor);
                        pdfTable.AddCell(pdfcell);
                    }
                }

                Document pdfDocument = new Document(new RectangleReadOnly(842, 595), 10f, -200f, 10f, 0f);
                // Document pdfDocument = new Document(new RectangleReadOnly(842, 595), widthstart, cell width, heightstart);
                PdfAWriter.GetInstance(pdfDocument, Response.OutputStream);

                pdfDocument.Open();
                pdfDocument.Add(pdfTable);
                pdfDocument.Close();

                Response.ContentType = "application/pdf";
                Response.AppendHeader("content-disposition", "attachment;filename=PrayerTimeTable.pdf");
                Response.Write(pdfDocument);
                Response.Flush();
                Response.End();
            }
            catch { }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string ID = btn.CommandArgument.ToString();
            uspGetSpecificEvent events = new uspGetSpecificEvent();
            divDisplayEvent.Visible = true;
            events = db.BLL_GetuspGetSpecificEvent(Convert.ToInt32(Convert.ToInt32(ID)));
            lblEventDescription.InnerText = events.EventDescription;
            lblEventStartTime.InnerText = events.EventStartTime;
            lblEventEndTime.InnerText = events.EventEndTime;
            lblEventDate.InnerText = events.EventDate.ToString();
            lblSpeaker.InnerText = events.Speaker;

        }
    }
}