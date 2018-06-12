using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TypeLib.ViewModels;
using Muslimeen.BLL;
using TypeLib.Models;
using System.Drawing;


namespace Muslimeen.Content.ZakaahWebForms
{
    public partial class ZakaahCalculator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            DBHandler dBHandler = new DBHandler();


            if (Session["UserName"] != null)
            {
                uspGetMember uspGetMember = new uspGetMember();

                uspGetMember = dBHandler.BLL_GetMember(Convert.ToString(Session["UserName"]));
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
            Response.Redirect("~/Content/Mosque.aspx");
        }

        protected void btnScholars_Click(object sender, EventArgs e)
        {
            //redirect user to the scholars list page.
        }

        protected void btnLearnIslam_Click(object sender, EventArgs e)
        {
            //redirect user to the LearnIslam page.
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
                Response.Redirect("~/Content/MyScholar.aspx");
            }

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            try
            {
                double total = 0;
                if (txtCashAtHome.Text == "")
                {
                    txtCashAtHome.BackColor = ColorTranslator.FromHtml("#256297");
                }
                else
                {

                    total += double.Parse(txtCashAtHome.Text);
                }



                if (txtBankAccount.Text == "")
                {
                    txtBankAccount.BackColor = ColorTranslator.FromHtml("#256297");
                }
                else
                {

                    total += double.Parse(txtBankAccount.Text);
                }
                if (txtInvestment.Text == "")
                {
                    txtInvestment.BackColor = ColorTranslator.FromHtml("#256297");
                }
                else
                {

                    total += double.Parse(txtInvestment.Text);
                }
                if (txtMerchandise.Text == "")
                {
                    txtMerchandise.BackColor = ColorTranslator.FromHtml("#256297");
                }
                else
                {

                    total += double.Parse(txtMerchandise.Text);
                }

                if (txtGoldSilver.Text == "")
                {
                    txtGoldSilver.BackColor = ColorTranslator.FromHtml("#256297");
                }
                else
                {

                    total += double.Parse(txtGoldSilver.Text);
                }

                txtTotalAssets.Text = Convert.ToString(total);
            }
            catch (Exception ex)
            {
                ex.ToString();

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                double eligible = 0;
                if (txtAllDebts.Text == "")
                {
                    txtAllDebts.BackColor = ColorTranslator.FromHtml("#256297");
                }
                else
                {
                    eligible = double.Parse(txtTotalAssets.Text.ToString()) - double.Parse(txtAllDebts.Text.ToString());
                    txtEligibleZakaah.Text = Convert.ToString(eligible);

                    double actualZakaah = 0;
                    actualZakaah = double.Parse(txtEligibleZakaah.Text.ToString()) * 25 / 1000;
                    double nisab = 4404;

                    if (double.Parse(txtEligibleZakaah.Text) <= nisab)
                    {
                        txtCalculatedZakaah.Text = "";
                        LblMessage.Text = "You are not eligible to pay Zakaah";
                    }
                    else if (double.Parse(txtEligibleZakaah.Text) > nisab)
                    {
                        txtCalculatedZakaah.Text = Convert.ToString(actualZakaah);
                        LblMessage.Text = "You are eligible to pay Zakaah of" + " R"+ double.Parse(txtCalculatedZakaah.Text) + "!!";

                    }
                }


            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void txtCashAtHome_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtBankAccount_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtInvestment_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtMerchandise_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtGoldSilver_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtTotalAssets_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtAllDebts_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtEligibleZakaah_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtCalculatedZakaah_TextChanged(object sender, EventArgs e)
        {

        }
    }
}