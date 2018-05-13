using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace Muslimeen
{
    public partial class Zakaah : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            int index = int.Parse(e.Item.Value);
            MultiView1.ActiveViewIndex = index;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {


        }

        protected void txtEligibleZakaah_TextChanged(object sender, EventArgs e)
        {


        }

        protected void txtTotalAssets_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {

            try
            {
                double total = 0;
                total += double.Parse(txtCashAtHome.Text);

                total += double.Parse(txtBankAccount.Text);
                total += double.Parse(txtInvestment.Text);
                total += double.Parse(txtMerchandise.Text);
                total += double.Parse(txtGoldSilver.Text);

                txtTotalAssets.Text = Convert.ToString(total);

                

                if (txtCashAtHome.Text == "" )
                {
                    txtCashAtHome.BackColor = ColorTranslator.FromHtml("Red");
                }
                else if (txtBankAccount.Text == "")
                {
                    txtBankAccount.BackColor = ColorTranslator.FromHtml("Red");
                }
                else if (txtInvestment.Text == "" )
                {
                    txtInvestment.BackColor = ColorTranslator.FromHtml("Red");
                }
                else if (txtMerchandise.Text == ""  )
                {
                    txtMerchandise.BackColor = ColorTranslator.FromHtml("Red");
                }
                else if (txtDebts.Text == "" )
                {
                    txtDebts.BackColor = ColorTranslator.FromHtml("Red");
                }
                else
                {
                    txtGoldSilver.BackColor = ColorTranslator.FromHtml("Red");
                }
            }
            catch(Exception ex)
            {
                ex.ToString();

            }
            


        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                double eligible = 0;
                eligible = double.Parse(txtTotalAssets.Text.ToString()) - double.Parse(txtDebts.Text.ToString());
                txtEligibleZakaah.Text = Convert.ToString(eligible);

                double actualZakaah = 0;
                actualZakaah = double.Parse(txtEligibleZakaah.Text.ToString()) * 25 / 1000;
                double nisab = 4404;

                if (double.Parse(txtEligibleZakaah.Text) <= nisab)
                {
                    Label1.Text = "You are not eligible to pay Zakaah";
                }
                else if (double.Parse(txtEligibleZakaah.Text) > nisab)
                {
                    txtCalculatedZakaah.Text = Convert.ToString(actualZakaah);
                    Label1.Text = "You are eligible to pay Zakaah!!";

                }
            }
            catch(Exception ex)
            {
                ex.ToString();
            }
            
            
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
           

            }
        }
    } 