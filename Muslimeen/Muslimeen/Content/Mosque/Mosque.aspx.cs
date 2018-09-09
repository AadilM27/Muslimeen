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
using TypeLib.Models;

namespace Muslimeen.Content.Mosque
{
    public partial class MosquePage : System.Web.UI.Page
    {
        DBHandler db = new DBHandler();
        protected void Page_Load(object sender, EventArgs e)
        {
            DBHandler db = new DBHandler();
            List<CounterCalender> counterCalender = new List<CounterCalender>();

            counterCalender = db.BLL_GetCounterCalender();
            hdfAdjustDate.Value = counterCalender[3].Val.ToString();


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
                Response.Redirect("../../Login/Login.aspx");
            }
            else if (btnLogin.Text == "Log out")
            {

                Session.Clear();
                Session.Abandon();
                Response.Redirect("../Default.aspx");
                btnLogin.Text = "Login";
                btnRegister.Visible = true;
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("../../Register/Register.aspx");
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Default.aspx");
        }

        protected void btnMosques_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Mosque/ListMosque.aspx");
        }

        protected void btnScholars_Click(object sender, EventArgs e)
        {
            //redirect user to the scholars list page.
        }

        protected void btnLearnIslam_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Learn Islam/LearnIslam.aspx");
        }

        protected void btnZakaah_Click(object sender, EventArgs e)
        {
            Response.Redirect("../ZakaahWebForms/Zakaah.aspx");
        }

        protected void btnAboutUs_Click(object sender, EventArgs e)
        {
            Response.Redirect("../AboutUs.aspx");
        }
        protected void btnHelp_Click(object sender, EventArgs e)
        {
            Response.Redirect("../HelpCenter.aspx");
        }
        protected void btnMyMuslimeen_Click(object sender, EventArgs e)
        {
            DBHandler dBHandler = new DBHandler();

            uspGetMember uspGetMember = new uspGetMember();

            uspGetMember = dBHandler.BLL_GetMember(Convert.ToString(Session["UserName"]));

            if (uspGetMember.MemberType == 'A')
            {
                Response.Redirect("../MyAdmin.aspx");
            }
            else if (uspGetMember.MemberType == 'M')
            {
                Response.Redirect("../MyMember.aspx");
            }
            else if (uspGetMember.MemberType == 'O')
            {
                Response.Redirect("../MyModerator.aspx");
            }
            else if (uspGetMember.MemberType == 'S')
            {
                Response.Redirect("../MyScholar/AddArticle.aspx");
            }
            else if (uspGetMember.MemberType == 'R')
            {
                Response.Redirect("MosqueRep.aspx");
            }


        }

        protected void btnListEvents_Click(object sender, EventArgs e)
        {
            try
            {
                divEventOverlay.Visible = false;
                divViewActiveEvents.Visible = false;
                divDisplayEvent.Visible = false;

                DateTime startDate = Convert.ToDateTime(txtStartDate.Text.ToString());
                DateTime EndDate = Convert.ToDateTime(txtEndDate.Text.ToString());
                if (startDate.Date <= EndDate.Date)
                {
                    rptGetEvents.DataSource = db.Bll_GetMosqueEventsDateRange(int.Parse(Session["MosqueID"].ToString()), startDate, EndDate);
                    rptGetEvents.DataBind();
                    if (rptGetEvents.Items.Count > 0)
                    {
                        divViewActiveEvents.Visible = true;
                        divDisplayEvent.Visible = false;
                    }
                    else if (rptGetEvents.Items.Count <= 0)
                    {
                        divViewActiveEvents.Visible = false;
                        divDisplayEvent.Visible = false;
                        lblEventError.InnerText = "No Events Found for Specified Date Range";
                        divEventOverlay.Visible = true;
                    }

                }
                else if (startDate.Date > EndDate.Date)
                {
                    divViewActiveEvents.Visible = false;
                    divDisplayEvent.Visible = false;
                    lblEventError.InnerText = "Invalid Date Range";
                    divEventOverlay.Visible = true;
                }

            }
            catch
            {
                divViewActiveEvents.Visible = false;
                divDisplayEvent.Visible = false;
                lblEventError.InnerText = "Please Enter Required Date Fields";
                divEventOverlay.Visible = true;
            }
        }

        protected void btnListPrayer_Click(object sender, EventArgs e)
        {
            lblTaskHeader.InnerText = btnPrayerTimes.Text.ToString();
            divDetails.Visible = false;
            divEvent.Visible = false;
            divLocation.Visible = false;
            divgrid.Visible = false;
            try
            {

                DateTime startDate = Convert.ToDateTime(txtPrayerStartDate.Text.ToString());
                DateTime endDate = Convert.ToDateTime(txtPrayerEndDate.Text.ToString());

                if (startDate.Date <= endDate.Date)
                {

                    List<uspGetMosquePrayerTimes> list = new List<uspGetMosquePrayerTimes>();
                    List<uspGetSpecificDayPrayerTimes> times = new List<uspGetSpecificDayPrayerTimes>();
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
                    if (rptPrayerTimes.Items.Count > 0)
                    {
                        divPrayerTable.Visible = true;
                        divPrayerOverlay.Visible = false;
                    }
                    else if (rptPrayerTimes.Items.Count <= 0)
                    {
                        divPrayerOverlay.Visible = true;
                        divPrayerTable.Visible = false;
                        lblPrayerError.InnerText = "No Prayer Times Found For Date Range";

                    }

                }

                else if (startDate.Date > endDate.Date)
                {
                    lblPrayerError.InnerText = "Invalid Date Range";
                    divPrayerOverlay.Visible = true;
                    divPrayerTable.Visible = false;

                }
            }
            catch
            {
                lblPrayerError.InnerText = "Please Enter Required Date Range Fields";
                divPrayerOverlay.Visible = true;
                divPrayerTable.Visible = false;

            }
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
            divEventOverlay.Visible = false;
            txtStartDate.Text = "";
            txtEndDate.Text = "";

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
            divEventOverlay.Visible = false;



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
            divPrayerOverlay.Visible = false;
            txtPrayerStartDate.Text = "";
            txtPrayerEndDate.Text = "";


        }

        protected void btnListPrayers_Click(object sender, EventArgs e)
        {

        }

        protected void PDF_ServerClick(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < grdReports.Rows.Count; i++)
                {
                    DateTime DOB = Convert.ToDateTime(grdReports.Rows[i].Cells[0].Text);
                    grdReports.Rows[i].Cells[0].Text = DOB.ToString("dd MMM yyyy");

                }

                PdfPTable pdfTable = new PdfPTable(grdReports.HeaderRow.Cells.Count);
                pdfTable.HorizontalAlignment = 0;
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
                foreach (TableCell Headercell in grdReports.HeaderRow.Cells)
                {
                    iTextSharp.text.Font font = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 11, iTextSharp.text.Font.BOLD);
                    font.Color = new BaseColor(grdReports.HeaderStyle.ForeColor);

                    PdfPCell pdfCell = new PdfPCell(new Phrase(Headercell.Text, font));
                    pdfCell.HorizontalAlignment = 1;
                    pdfCell.Padding = 5;
                    pdfCell.BackgroundColor = new BaseColor(grdReports.HeaderStyle.BackColor);
                    pdfTable.AddCell(pdfCell);
                }


                foreach (GridViewRow gridviewrow in grdReports.Rows)
                {
                    foreach (TableCell tablecell in gridviewrow.Cells)
                    {
                        iTextSharp.text.Font font = new iTextSharp.text.Font();
                        font.Color = new BaseColor(grdReports.RowStyle.ForeColor);
                        iTextSharp.text.Font content = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.BOLD);
                        PdfPCell pdfcell = new PdfPCell(new Phrase(tablecell.Text, content));
                        pdfcell.HorizontalAlignment = 1;
                        pdfcell.VerticalAlignment = 2;
                        pdfcell.BackgroundColor = new BaseColor(grdReports.RowStyle.BackColor);
                        pdfTable.AddCell(pdfcell);
                    }
                }

                Document pdfDocument = new Document(new RectangleReadOnly(842, 595), 10f, -200f, 10f, 0f);
                // Document pdfDocument = new Document(new RectangleReadOnly(842, 595), widthstart, cell width, heightstart);
                PdfAWriter.GetInstance(pdfDocument, Response.OutputStream);

                PdfPTable table = new PdfPTable(1);
                PdfPTable table2 = new PdfPTable(2);

                iTextSharp.text.Font fontH2 = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.BOLD);
                table2.WidthPercentage = 80;
                table2.HorizontalAlignment = 0;
                table2.DefaultCell.Padding = 8;
                table2.DefaultCell.HorizontalAlignment = 1;
                table2.DefaultCell.VerticalAlignment = 1;
                Paragraph date = new Paragraph("Selected Date Range: " + Convert.ToDateTime(txtPrayerStartDate.Text).ToString("dd MMM yyyy") + " to " + Convert.ToDateTime(txtPrayerEndDate.Text).ToString("dd MMM yyyy"), fontH2);
                Paragraph extraPara = new Paragraph("Date Created: " + DateTime.Now.Date.ToString("dd MMM yyyy"), fontH2);
              
                table2.AddCell(date);
                table2.AddCell(extraPara);

                iTextSharp.text.Font fontH1 = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 24, iTextSharp.text.Font.BOLD);
                table.WidthPercentage = 80;
                table.HorizontalAlignment = 0;
                table.DefaultCell.Padding = 20;
                table.DefaultCell.HorizontalAlignment = 1;
                table.DefaultCell.VerticalAlignment = 1;
                Paragraph para = new Paragraph("Salah Time Table For "+Session["lblMosqueName"].ToString(), fontH1);
                table.AddCell(para);

                pdfDocument.Open();
                pdfDocument.AddTitle("Prayer Time Table");
                pdfDocument.Add(table);
                pdfDocument.Add(table2);
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
            lblTitle.InnerText = events.EventTitle;
            lblEventDescription.InnerText = events.EventDescription;
            lblEventStartTime.InnerText = events.EventStartTime;
            lblEventEndTime.InnerText = events.EventEndTime;
            lblEventDate.InnerText = events.EventDate.ToString();
            lblSpeaker.InnerText = events.Speaker;

        }
    }
}