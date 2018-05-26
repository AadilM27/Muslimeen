<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Zakaah.aspx.cs" Inherits="Muslimeen.Zakaah" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <meta charset="utf-8"/>
        <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
        <meta name="description" content=""/>
        <meta name="author" content=""/>

        <title> Muslimeen - Zakaah </title> <!--Tab title-->

        <link href="../Home/css/bootstrap.min.css" rel="stylesheet"/>
        <link href="../Home/css/font-awesome.min.css" rel="stylesheet"/>
        <link href="../Home/css/animate.min.css" rel="stylesheet"/>
        <link href="../Home/css/prettyPhoto.css" rel="stylesheet"/>
        <link href="../Home/css/main.css" rel="stylesheet"/>
        <link href="../Home/css/responsive.css" rel="stylesheet"/>
     <link href="../Content/Zakaah/css/Zakaah.css" rel="stylesheet" />
    
        <!--[if lt IE 9]>
            <script src="js/html5shiv.js"></script>
            <script src="js/respond.min.js"></script>
            <![endif]-->
   

        <link rel="shortcut icon" href="../Home/images/ico/logo.ico"/> <!--Logo on the tab-->

        <style type="text/css">
            .col-md-12 {
                margin-right: 351px;
            }
            .post-inner {
                margin-right: 0px;
            }
            #Form1 {
                width: 949px;
            }
        </style>

</head>

    <body class="homepage">
        <form role="form" runat="server">
        <header id="header">
            <div class="top-bar">
                <div class="container">
                    <div class="row">
                        <div class="col-sm-6 col-xs-4">
                            <div class="top-number"><p> </p></div>
                        </div>
                        <div class="col-sm-6 col-xs-8">
                            <div class="social">
                                <div class="search">                                 
                                    <asp:TextBox ID="txtSearch" runat="server" class="search-form" autocomplete="off" placeholder="Search"></asp:TextBox>
                                    <i class="fa fa-search"></i>                                    
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            
            <nav class="navbar navbar-inverse" role="banner">
                <div class="container">
                    <div class="navbar-header">
                        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                            <span class="sr-only">Toggle navigation</span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>
                        
                        <a class="navbar-brand" href="index.html"><img src="../Content/Zakaah/images/Final Logo.png" alt="logo" width="110" height="70"/></a>
                    
                    </div>
                    <div class="collapse navbar-collapse navbar-right">
                        <ul class="nav navbar-nav"> <!--Change the link of pages to your page-->
                            <li class="active"><a href="Default.aspx">Home</a></li>                            
                            <li><a href="Mosque.aspx">Mosques</a></li>
                            <li><a href="prayers.html">Scholars</a></li>
                            <li><a href="portfolio.html">Learn Islam</a></li>
                            <li><a href="blog.html">Zakaah</a></li>
                            <li><a href="contact-us.html">Contact Us</a></li>
                        </ul>
                    </div>
                </div>
            </nav>
        </header>
            <!---start of zakaah content--->
            <div class ="container col-md-12">
                <div class ="row">
                    <div >
                        <div class ="background" >
                            <h1 class="h1b">Zakaah</h1>
                        </div>
                    </div>
                </div>
            </div>
            <!---end of 1st jumbotron of background image-->

            <!---start of zakaah tabs--->
            <div class="background">
                <asp:Menu ID="Menu1" class="container-fluid col-lg-40" Orientation="Horizontal" StaticMenuItemStyle-CssClass="tab" Font-Size="Large" StaticSelectedStyle-CssClass="selectedtab" StaticMenuItemStyle-HorizontalPadding="50px" StaticSelectedStyle-BackColor="White" CssClass="tabs" runat="server" height="0px" vertical-align="top" align ="center" OnMenuItemClick="Menu1_MenuItemClick">
                    <Items>
                    <asp:MenuItem Text="What is Zakaah?" Value="0" Selected="true"></asp:MenuItem>
                        <asp:MenuItem Text="Zakaah Calculator" Value="1"></asp:MenuItem>
                        <asp:MenuItem Text="Organizations" Value="2"></asp:MenuItem>
                        <asp:MenuItem Text="Contact Us" Value="3"></asp:MenuItem>    
                </Items>
                </asp:Menu>

                <div class="tabcontents">
                    <asp:MultiView ID="MultiView1"  ActiveViewIndex="0" runat="server">
                    <asp:View ID="View1" runat="server">
                     <div class="container-fluid newcon">
                         
                         <div class="row">
                            <div class ="jumbotron2">
                             <h1>What is Zakaah?</h1>
                                <p>
                                   "Take from their wealth so that you might purify and sanctify them"
                                </p>
                                <p>(Quran 9:103)</p>
                                <p>The word means 'purity' or 'to purify';all Muslims who are wealthy
                                    enough,must purify their wealth through the act of giving charity.
                                </p>
                            </div>
                         </div>
                     </div>
                     <div>
                        
                     <div class="post-inner newcon">
                         <h1 class="name post-title entry-title"><span itemprop="name">Zakaat Rulings</span></h1> 
                         <div class="videos">
                             <h3 class="h3">Explanation of Zakaah:</h3>
                         <iframe id="I1" allow="autoplay; encrypted-media" allowfullscreen="" frameborder="0" height="315" name="I1" src="https://www.youtube.com/embed/3FsNtlGTQuU" width="560">

                         </iframe>
                             <h3 class="h3">Conditions of Zakaah:</h3>
<iframe width="560" height="315"  src="https://www.youtube.com/embed/kEon0omN5SA" frameborder="0" allow="autoplay; encrypted-media" allowfullscreen></iframe>
                         </div>
                                                                       
                         
                 
                         <!--- start of entry div-->
                         <div class="entry">
					<p><strong>Nasihah (Advice): Caution when giving Zakaat:</strong><br />
Ramadhan, the month of fasting, is also the time when many Muslims calculate and discharge their Zakaat. One of the fundamentals of Zakaat is to discharge Zakaat to eligible recipients.</p>
<p>It is the onus of the individual to verify the Zakaat eligibility of the recipient. If verification is not done and the person was not eligible for Zakaat, then that Zakaat has to be repaid. </p>
<p>It is of great concern that many individuals hand over their Zakaat to beggars standing at traffic lights. Many of these individuals are “professional” beggars who make so much money that it is compulsory on them to pay Zakaat let alone receive it.<br />
Individuals experiencing difficulty in discharging their Zakaat may forward their Zakaat to the Jamiat and have their Zakaat discharged to eligible recipients verified by Ulama.</p>
<div>
Question and Answer:<br/>
<h2> Upon who is Zakaat fard(compulsory)?</h2> 
</div>
<p>A.  Zakaat is Fard on a Muslim male or female who is mature (Baaligh) and sane. He/she must also be the owner of Nisaab. Nisaab is the minimum amount of wealth which makes a person liable for Zakaat. If one is the owner of Nisaab after one lunar year, then Zakaat will be Fardh upon him. The Zakaat should be paid annually on the Islamic date of a lunar year.</p>
<div>
<h2>How do I calculate Zakaat?</h2>
</div>
<p>A. Zakaat is payable on all Zakaatable assets to the value of nisaab or more at the end of one’s Zakaatable year. Zakaatable assets are generally gold, silver, cash, dividends, debtors and trading stock. The Zakaatable year is the lunar year after the day one acquired possession of Zakaatable assets to the value of Nisaab. Creditors are subtracted from the sum of Zakaatable assets and 2.5% of these are paid as Zakaat.</p>
<p>For example, A person owns Zakaatable assets to the value of Nisaab on the first day of Ramadhaan 1432. If on the first of Ramadhaan 1433 he still owns zakaatable  assets to the value of Nisaab then 2.5% of the total Zakaatable assets on hand on the first of Ramadhaan 1433 is liable for Zakaat irrespective of the fluctuation during the year. If, however, the amount during the year reached zero then a new year will start after one owns Zakaatable assets to the value of Nisaab again.</p>
<div >
<h2>What are the assets on which we have to pay Zakat? What is basic rule for the payment of Zakat?</h2> 
</div>
<p>A.Allah Ta‘ālā states in the Holy Quran,</p>
<p>وَأَقِيمُوا الصَّلَاةَ وَآَتُوا الزَّكَاةَ وَمَا تُقَدِّمُوا لِأَنْفُسِكُمْ مِنْ خَيْرٍ تَجِدُوهُ عِنْدَ اللَّهِ إِنَّ اللَّهَ بِمَا تَعْمَلُونَ بَصِيرٌ</p>
<p>“And establish Salāh and pay Zakāh; whatever good you send forth for yourselves, you will find it with Allah. Certainly, Allah is watchful of what you do.”</p>
<p>Zakāh has two denotations in Arabic, namely growth and purification. Zakāh is paid as a means of purifying one’s wealth and fulfilling the obligation will be a means of increase and growth in the remainder of one’s wealth.</p>
<div>
<h2>Is Zakat applicable for Diamond or other precious metals/stones?</h2>
</div>
<p>A:If diamonds or precious stone are purchased for trading purpose, i.e. with a clear intention of their resale, they are certainly subject to Zakah like any other item purchased with the same intention. But if a diamond or a precious stone is kept for personal use only, in that case Zakah is not obligatory on its value.<br/>
The Principle governing the levy of Zakah is that only those assets are Zakatable which either fall within the definition of money, or are the metals universally accepted as a medium of exchange like silver and gold. All other assets are not zakatable unless they are meant for trade and resale.<br/>
The precious stones, including diamonds, are, no doubt, very valuable assets. But if they are not purchased for trading, they are not subject to Zakah. This principle is based on a Hadith:<br/>
“There is no Zakah on a stone”<br/>
On the basis of the above, the overwhelming majority of the Muslim jurists are of the view that precious stones are not subject to the levy of Zakah unless they are acquired for the purpose of resale. There are, however, some jurists like Imam Ahmed who believe that all precious stones are liable to Zakah, even if they are kept for personal use.<br/>
Therefore, if somebody pays Zakah on the value of these stones, it will be free from all doubts and will promise more reward. But so far as the mandatory nature of the levy is concerned, the view of the majority is supportive of non- obligation of Zakah, because they are neither money nor a universally accepted medium of exchange. Moreover, the value of precious stones depends on their scarcity and rareness. They have no intrinsic value. Therefore they are like valuable antiques or manuscripts which, on account of their rareness, sometimes have more value than gold. Still, they are not subject to Zakah unless they are purchased for trade or resale.<br/>
Likewise precious stones may have more value than gold. Yet, the obligation of Zakah is not imposed if they are not meant for the trade.  ”<br/>
(Contemporary Fatawa, Mufti Taqi Saheb, Pg. 101)</p>
						
                     </div>
                         			</div>

                       
                         <div>
                         </div>
                     </div>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                      <p class="margain"><strong style="color:white; font-size: 22px; font-weight:200; line-height: 10px;">
    In order to calculate your Zakat, please fill all of the fields below:
   </strong></p>
    <div id="zform" style="padding: 10px 0 10px 0;">
        <div class="style9 jqtransformdone" id="Form1" >
            <div style="width: 580px; height: 50px; clear: both;">
                <div style="float: left; color:white;font-size: 22px;font-weight: bold;line-height: 22px;">
                    <strong>Assets and Liabilities</strong></div><div style="float: right; color:white;font-size: 22px;font-weight: bold;line-height: 22px;">
                        <strong>Value in ZAR</strong></div></div><div style="width: 580px; height: 50px; clear: both;"><div style="float: left;">Cash at Home</div><div style="float: right;">
                            <asp:TextBox ID="txtCashAtHome" runat="server" OnTextChanged="txtCashAtHome_TextChanged"></asp:TextBox>  
                        </div>
                        </div>
            <div style="width: 580px; height: 50px; clear: both;"><div style="float: left;">
                Balance Held in Bank Accounts</div>
                <div style="float: right;">
                    <asp:TextBox ID="txtBankAccount" runat="server" OnTextChanged="txtBankAccount_TextChanged"></asp:TextBox>

                </div>

            </div>
            <div style="width: 580px; height: 50px; clear: both;">
                <div style="float: left;">Market value of short term investments</div>
                <div style="float: right;"><asp:TextBox ID="txtInvestment" runat="server" OnTextChanged="txtInvestment_TextChanged"></asp:TextBox>

                </div>

            </div><div style="width: 580px; height: 50px; clear: both;"><div style="float: left;">Business Merchandise</div>
                <div style="float: right;" >
                    <asp:TextBox ID="txtMerchandise" runat="server" OnTextChanged="txtMerchandise_TextChanged"></asp:TextBox></div>

                  </div>
            <div style="width: 580px; height: 50px; clear: both;">
                <div style="float: left;">Gold &amp; Silver (at current value)</div>
                <div style="float: right;">
                    <asp:TextBox ID="txtGoldSilver" runat="server" OnTextChanged="txtGoldSilver_TextChanged"></asp:TextBox></div>
            </div><div style="width: 580px; height: 50px; clear: both;">
                <div style="float: left; color:white;font-size: 15px;"><strong>Total of Assets Liable for <em>Zakah</em></strong>
                    
                </div>
                <div style="float: right;">
                    <asp:TextBox ID="txtTotalAssets" runat="server" OnTextChanged="txtTotalAssets_TextChanged" ></asp:TextBox></div>

                  </div>
            <div style="width: 580px; height: 50px; clear: both;"><div style="float: left;">Deduct Debts</div>
                <div style="float: right;">
                    <asp:TextBox ID="txtDebts" runat="server" OnTextChanged="txtDebts_TextChanged"></asp:TextBox></div>

            </div><div style="width: 580px; height: 50px; clear: both;"><div style="float: left; color:white;font-size: 15px;"><strong><em>Zakah-Eligible</em> Total</strong></div>
                <div style="float: right;">
                    <asp:TextBox ID="txtEligibleZakaah" runat="server" OnTextChanged="txtEligibleZakaah_TextChanged"></asp:TextBox></div>

                  </div>
            <div style="width: 580px; height: 50px; clear: both;"><div style="float: left;color: #007bb7;font-size: 15px;"><strong>Ensure that <em>Zakah-Eligible</em> Total Exceeds <em>Nisab</em></strong>
             </div><div style="float: right;">
                 <asp:TextBox ID="txtNisab" runat="server" value="4404">R4404</asp:TextBox></div>

            </div>
            <div style="width: 580px; height: 50px; clear: both;">
                <div style="float: left;color: #007bb7;font-size: 15px;"><strong>Your <em>Zakah</em></strong><strong>(0.025 x <em>Zakah-Eligible</em> Total)</strong></div><div style="float: right;">
                    <asp:TextBox ID="txtCalculatedZakaah" runat="server" OnTextChanged="txtCalculatedZakaah_TextChanged"></asp:TextBox> </div>

            </div>
            <div class="button">
                            <asp:Button ID="Button1" runat="server" Text="Calculate Assets" BackColor="#CCCCCC" BorderColor="#CCCCCC" BorderStyle="Solid" ForeColor="#000066" ToolTip="click here to calculate your total Assets" OnClick="Button1_Click1" autopostback="true" /> 
                        </div>
            <div class="button2">
                <asp:Button ID="Button2" runat="server" Text="Calculate Eligible Zakaah" ToolTip="Calculate your zakaah after deductions" autopostback="true" OnClick="Button2_Click"/>

            </div>
           
            <div class="lbl">
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            </div>
            </div>
                   </div> 
                    <div class="col-md-auto move">
                  <aside id="nav_menu-4" class="widget widget_nav_menu">
            <h3 class="widgettitle fontsize" >Related Links</h3>
            <div class="menu-ramadan-container">
                <ul id="menu-ramadan" class="menu">
                    <li id="menu-item-11284" class="menu-item menu-item-type-post_type menu-item-object-page menu-item-11284"><a href="https://www.islamic-relief.org.za/zakat/">Zakat</a></li>
                    <li id="menu-item-11283" class="menu-item menu-item-type-post_type menu-item-object-page current-menu-item page_item page-item-6843 current_page_item menu-item-11283"><a href="https://www.islamic-relief.org.za/zakat-calculator/">Zakat Calculator</a></li>
                    <li id="menu-item-11285" class="menu-item menu-item-type-post_type menu-item-object-page menu-item-11285"><a href="https://www.islamic-relief.org.za/ramadan/">Ramadan</a></li>
                    <li id="menu-item-11282" class="menu-item menu-item-type-post_type menu-item-object-page menu-item-11282"><a href="https://www.islamic-relief.org.za/zakat-al-fitrah/">Zakat-ul-Fitrah</a></li>
                    <li id="menu-item-11300" class="menu-item menu-item-type-post_type menu-item-object-page menu-item-11300"><a href="https://www.islamic-relief.org.za/fidyah-and-kaffarah/">Fidyah and Kaffarah</a></li>
                </ul>
            </div>
        </aside>
                   </div>
                        
                  


        
        
        <div class="cl">
        </div>
    


                        
                        
                    </asp:View>
                    <asp:View ID="View3" runat="server">
                   <br /> tab 2
                    </asp:View>
                    <asp:View ID="View4" runat="server">
                   <br /> tab3
                    </asp:View>

                    </asp:MultiView>
                   
                </div>
                
            </div>
            <!--end of view tabs-->
        <!--START INSERTING CODE FROM THIS POINT ON-->
        
        <footer id="footer" class="midnight-blue">
            <div class="container">
                <div class="row">
                    <div class="col-sm-6">
                        &copy; 2018 Muslimeen. All Rights Reserved.
                    </div>
                    <div class="col-sm-6">
                        <ul class="pull-right"> <!--Change the link of pages to your page-->
                            <li><a href="Default.aspx">Home</a></li>
                            <li><a href="Mosque.aspx">Mosques</a></li>
                            <li><a href="prayers.html">Scholars</a></li>
                            <li><a href="portfolio.html">Learn Islam</a></li>
                            <li><a href="blog.html">Zakaah</a></li>
                            <li><a href="contact-us.html">Contact Us</a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </footer>
        
        <script src="js/jquery.js"></script>
        <script src="js/bootstrap.min.js"></script>
        <script src="js/jquery.prettyPhoto.js"></script>
        <script src="js/jquery.isotope.min.js"></script>
        <script src="js/main.js"></script>
        <script src="js/wow.min.js"></script>
        </form>
    </body>
</html>