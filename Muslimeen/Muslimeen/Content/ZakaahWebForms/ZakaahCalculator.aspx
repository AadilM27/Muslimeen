<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZakaahCalculator.aspx.cs" Inherits="Muslimeen.Content.ZakaahWebForms.ZakaahCalculator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
 <head runat="server">
    <meta charset="utf-8"/>
	<meta http-equiv="X-UA-Compatible" content="IE=edge"/>
	<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>

    <title>MyMuslimeen - Calculator</title>
     <link rel="icon" href="../../Login/LogIn_Bootstrap/muslimeen.ico" />
     <link href="../../Login/LogIn_Bootstrap/css/bootstrap.min.css" rel="stylesheet" />
     <link href="../Default/css/Default.css" rel="stylesheet" />
     <link href="../Zakaah/css/newZakaah.css" rel="stylesheet" />
     
</head>
    <body>
        <form id="frmScholar" runat="server" class=" ">   
            <header >
                <nav class="navFixed">
                    <div class="row align-self-end">
                        <ul class=" col-7 navbar-nav flex-row justify-content-start">
                            <asp:HiddenField runat="server" ID="hfAdjustDate" Value="-2" /> <!--Need to get value from DB let admin adjust this -->
                            <li class="nav-item ml-4 mr-0 mb-0 pt-2"> <p class="IslamicDate mb-0" id="lstIslamicDate"></p></li>
                            <script src="../Default/DatesEnglishHijri.js"></script>
                        </ul>
                        <ul class="col-5 navbar-nav flex-row justify-content-end">
                            <li class="nav-item ml-0 mr-0">
                            <asp:TextBox ID="txtSearch" TextMode="Search" runat="server"  class=" search-box form-control form-control-sm" autocomplete="off" placeholder="Search"></asp:TextBox>
                            </li>
                            <li class="nav-item mr-2">
                                <asp:ImageButton runat="server" Text="Go" ImageUrl="~/Content/Default/icons/Search.png" Height="31px" Width="31px" CssClass="topnav search-btn form-control form-control-sm" />
                            </li>
                            <li class=" nav-item mr-2">
                            <asp:Button runat="server" Text="Login" ID="btnLogin" CssClass="topnav btn btn-sm btn-outline-light" OnClick="btnLogin_Click" />
                            </li>
                            <li class="nav-item mr-2">
                            <asp:Button runat="server" Text="Register" ID="btnRegister" CssClass="topnav btn btn-sm btn-outline-light" OnClick="btnRegister_Click" />
                            </li>
                        </ul> <!---->
                    </div>
                    <div class="row" runat="server" id="divUserProfile" >
                        <div class="col navbar-nav flex-row ml-4 mb-0 mt-0 pt-2 justify-content-end">
                            <asp:HyperLink ID="hplUserProfile" ToolTip="Edit user profile" runat="server" NavigateUrl="~/Content/ProfileEditer.aspx" CssClass="nav-item mb-0 mr-1 ml-1 user">
                            </asp:HyperLink><asp:Image style="height:15px; width:15px;" runat="server" id="imgEditProfile" CssClass="mt-1 mr-3" ImageUrl="~/Content/Default/icons/EditProfile.png"/>
                        </div>
                    </div>
                </nav>
                <div id="navbar" class="navbar navbar-expand flex-column navv flex-md-row" style="box-shadow: 0 0 0 0.1rem rgba(0, 123, 255, 0.50);">
                    <div class=" text-center">
                        <asp:Image runat="server" CssClass="mb-0 ml-0" src="/Login/LogIn_Bootstrap\logo.png" width="185" height="110"/>
                        </div>
                    <div class="ml-2 navbar-nav-scroll align-self-end justify-content-start">
                        <ul class="navbar-nav row">
                            <li class="nav-item navbarText navbaritems">
                                <asp:Button runat="server" ID="btnHome" Text="Home"  CssClass=" btn btn-link nav-item navText" OnClick="btnHome_Click"/>
                            </li><li class="NavDevider">|</li><!--deviders-->
                            <li class="nav-item navbarText navbaritems" runat="server" id="liMyMusbtn">
                                <asp:Button runat="server" ID="btnMyMuslimeen" Text="MyMuslimeen"  CssClass=" btn btn-link nav-item navText" OnClick="btnMyMuslimeen_Click"/>
                            </li><li runat="server" id="liMyMusDivi" class=" NavDevider">|</li><!--deviders-->
                            <li class="nav-item navbarText navbaritems">
                                <asp:Button runat="server" ID="btnMosques" Text="Mosques"  CssClass="nav-item navText btn-link btn" OnClick="btnMosques_Click"/>
                            </li><li class="NavDevider">|</li><!--deviders-->
                            <li class="nav-item navbarText navbaritems">
                                <asp:Button runat="server" ID="btnScholars" Text="Scholars"  CssClass="nav-item navText btn-link btn" OnClick="btnScholars_Click"/>
                            </li><li class="NavDevider">|</li><!--deviders-->
                            <li class="nav-item navbarText navbaritems">
                                <asp:Button runat="server" ID="btnLearnIslam" Text="Learn Islam"  CssClass="nav-item navText btn-link btn" OnClick="btnLearnIslam_Click"/>
                            </li><li class="NavDevider">|</li><!--deviders-->
                            <li class="nav-item navbarText navbaritems">
                                <asp:Button runat="server" ID="btnZakaah" Text="Zakaah"  CssClass="nav-item navText btn-link btn" OnClick="btnZakaah_Click"/>
                            </li><li class="NavDevider">|</li><!--deviders-->
                            <li class="nav-item navbarText navbaritems">
                                <asp:Button runat="server" ID="btnAboutUs" Text="About us"  CssClass="nav-item navText btn-link btn" OnClick="btnAboutUs_Click"/>
                            </li>
                        </ul>
                    </div>
                </div>
            </header>
        
   <div class="content" id="content"><!--add content here -->
           
        <div class="zakaah-content" style="position:static;">
            <nav class="navbar navbar-expand-sm navbar-dark" style="position:static; background-color:#256297;">
              <a class="navbar-brand navt " href="newZakaah.aspx" >Zakaah</a>
              <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#collapsibleNavbar">
                <span class="navbar-toggler-icon"></span>
              </button>
              <div class="collapse navbar-collapse" id="collapsibleNavbar">
                <ul class="navbar-nav">
                  <li class="nav-item">
                    <a class="navbar-brand navt" href="ZakaahCalculator.aspx">Calculator</a>
                  </li>
                  <li class="nav-item">
                    <a class="navbar-brand navt" href="ZakaahFacts.aspx">Gallery</a>
                  </li>
                  <li class="nav-item">
                    <a class="navbar-brand navt" href="ZakaahOrganizations.aspx">Organizations</a>
                  </li>    
                </ul>
              </div>  
            </nav>

                    <div class="container" style="margin-top:10px; position:static;">
                      <div class="row" style="position:static;right:50px">
                          <div class="col-lg-8" style="position:static;">
                             
        
            
                    <div style="text-align:center;color:white;background-color:#256297;font-size:20px">
                    <strong >Assets and Liabilities</strong>

                    </div>
                    <br />
                     
                    <div style="width: 580px; height: 50px; clear: both;">
                    <div style="float: left;color:white;background-color:#256297">
                    <asp:Label ID="Label1" runat="server" Text="Label">Cash at Home</asp:Label>
                    </div>
                    <div style="float: right;">
                    <asp:TextBox ID="txtCashAtHome" runat="server" OnTextChanged="txtCashAtHome_TextChanged"></asp:TextBox>  
                    </div>

                    </div>
                    <div style="width: 580px; height: 50px; clear: both;">
                    <div style="float: left;color:white;background-color:#256297">
                    <asp:Label ID="Label2" runat="server" Text="Label">Balance held in Bank Account</asp:Label>
                    </div>
                    <div style="float: right;">
                    <asp:TextBox ID="txtBankAccount" runat="server" OnTextChanged="txtBankAccount_TextChanged"></asp:TextBox>
                    </div>

                    </div>
                    <div style="width: 580px; height: 50px; clear: both;">
                    <div style="float: left;color:white;background-color:#256297">
                    <asp:Label ID="Label3" runat="server" Text="Label">Market value of short term investments</asp:Label>
                    </div>
                    <div style="float: right;">
                    <asp:TextBox ID="txtInvestment" runat="server" OnTextChanged="txtInvestment_TextChanged"></asp:TextBox>
                    </div>

                    </div>
                    <div style="width: 580px; height: 50px; clear: both;">
                    <div style="float: left;color:white;background-color:#256297">
                    <asp:Label ID="Label4" runat="server" Text="Label">Business Merchandise</asp:Label>
                    </div>
                    <div style="float: right;" >
                    <asp:TextBox ID="txtMerchandise" runat="server" OnTextChanged="txtMerchandise_TextChanged"></asp:TextBox>
                    </div>

                    </div>
                   <div style="width: 580px; height: 50px; clear: both;">
                   <div style="float: left;color:white;background-color:#256297">
                   <asp:Label ID="Label5" runat="server" Text="Label">Gold &amp; Silver (at current value)</asp:Label>
                   </div>
                   <div style="float: right;">
                   <asp:TextBox ID="txtGoldSilver" runat="server" OnTextChanged="txtGoldSilver_TextChanged"></asp:TextBox></div>
                   </div>
                   <div style="width: 580px; height: 50px; clear: both;">
                   <div style="float: left; color:white;font-size: 15px;color:white;background-color:#256297">
                   <asp:Label ID="Label6" runat="server" Text="Label">Total of Assets Liable for Zakah</asp:Label>
                   </div>
                   <div style="float: right;">
                   <asp:TextBox ID="txtTotalAssets" runat="server" OnTextChanged="txtTotalAssets_TextChanged" ></asp:TextBox>
                   </div>

                   </div>
                   <div style="width: 580px; height: 50px; clear: both;">
                   <div style="float: left;color:white;background-color:#256297">
                   <asp:Label ID="Label7" runat="server" Text="Label">Deduct Debts</asp:Label>
                   </div>
                   <div style="float: right;">
                   <asp:Textbox ID="txtAllDebts" runat="server" OnTextChanged="txtAllDebts_TextChanged"></asp:Textbox>
                   </div>

                   </div>
                   <div style="width: 580px; height: 50px;clear:both">
                   <div style="float: left; color:white;font-size: 15px;color:white;background-color:#256297">
                   <asp:Label ID="Label8" runat="server" Text="Label"><strong><em>Zakah-Eligible</em> Total</strong></asp:Label>
                   </div>
                   <div style="float: right;">
                   <asp:TextBox ID="txtEligibleZakaah" runat="server" OnTextChanged="txtEligibleZakaah_TextChanged"></asp:TextBox>
                   </div>

                  </div>
                  <div style="width: 580px; height: 50px; clear: both;">
                  <div style="float: left;color: #256297;font-size: 15px;">
                  <strong>Ensure that <em>Zakah-Eligible</em> Total Exceeds <em>Nisab</em></strong>
                  </div>
                  <div style="float: right;">
                  <asp:TextBox ID="txtNisab" runat="server" value="4404"></asp:TextBox>
                  </div>

                  </div>
                  <div style="width: 580px; height: 50px; clear: both;">
                  <div style="float: left;color: #256297;font-size: 15px;">
                  <asp:Label ID="Label9" runat="server" Text="Label"><strong>Your <em>Zakah</em></strong><strong>(0.025 x <em>Zakah-Eligible</em> Total)</strong></asp:Label>
                  </div>
                  <div style="float: right;">
                  <asp:TextBox ID="txtCalculatedZakaah" runat="server" OnTextChanged="txtCalculatedZakaah_TextChanged"></asp:TextBox> 
                  </div>

                  </div>
                  
                  <div style="text-align:center;color:white;font-size:20px;background-color:#256297">
                  <asp:Label ID="LblMessage" runat="server" Text=""></asp:Label>
                  </div>
                  <br />
                  <div style="position:static;align-items:center">
                  <asp:Button ID="Button1" runat="server" Text="Calculate  Assets" BackColor="#256297" BorderStyle="none" ForeColor="white" ToolTip="click here to calculate your total Assets" OnClick="Button1_Click1" autopostback="true" />                      
                  <asp:Button ID="Button2" runat="server" Text="Calculate Zakaah" BackColor="#256297" ForeColor="white" BorderStyle="none" ToolTip="Calculate your zakaah after deductions" autopostback="true" OnClick="Button2_Click"/>
                  </div>
                              <br />
                   <div style="text-align:center;color:white;background-color:#256297;font-size:20px">
                    <strong >Example of how Zakaat can be calculated:</strong>
                    </div>
                  <iframe width="560" height="315" src="https://www.youtube.com/embed/zERfWrdCrEY"  allowfullscreen></iframe>
                  </div>
                  <div class="col-lg-4" style="position:static;">
                       <!---javascript code to translate language--->
                        <p>Translate this page:</p>
                       <div id="google_translate_element"></div>

                      <script type="text/javascript">
                          function googleTranslateElementInit()
                          {
                            new google.translate.TranslateElement({pageLanguage: 'en'}, 'google_translate_element');
                          }
                     </script>
                     <script type="text/javascript" src="//translate.google.com/translate_a/element.js?cb=googleTranslateElementInit"></script>
                    <!---end of javascript code--->
                     <h2 style="color:#256297">Zakaah Facts</h2>
                    <img src="../Zakaah/ZakaahPics/alms.jpg" />
                    <div class="rightcolumn">
                    <div class="card" style="position:static">
                    

                    <div style="height:50px;width:40px;">
                     
                    </div>
                    <p>Some text about me in culpa qui officia deserunt mollit anim..</p>
                    </div>
                    <div class="card" style="position:static">
                     <h3>Popular Post</h3>
                      <div class="fakeimg" style="position:static">Image</div><br />
                      <div class="fakeimg" style="position:static">Image</div><br />
                      <div class="fakeimg" style="position:static">Image</div>
                    </div>
                    <div class="card"style="position:static" >
                     <h3>Follow Me</h3>
                     <p>Some text..</p>
                    </div>
                    </div>
                        <br />
                       
                          <p>Some text about me in culpa qui officia deserunt mollit anim..</p>
                          <h3>Some Links</h3>
                          <p>Lorem ipsum dolor sit ame.</p>
                          <ul class="nav nav-pills flex-column">
                            <li class="nav-item">
                              <a class="nav-link active" href="#">Active</a>
                            </li>
                            <li class="nav-item">
                              <a class="nav-link" href="#">Link</a>
                            </li>
                            <li class="nav-item">
                              <a class="nav-link" href="#">Link</a>
                            </li>
                            <li class="nav-item">
                              <a class="nav-link disabled" href="#">Disabled</a>
                            </li>
                          </ul>
                          <hr class="d-sm-none" />
                        </div>
                    
            
                   
                       
                </div>
                </div>
                </div>
                </div>
               </form>   
              <div class="footerr"> <!--End of content, start of footer-->
                <div class="row">
                    <div class="col text-center position-static">
                       <h6>Content</h6>
                        <ul class="navbar-nav">
                           <li class="nav-item">
                               <a class="footerr-text" href="Default.aspx">Home</a>
                           </li>
                           <li class="nav-item">
                               <a class="footerr-text" href="Mosque.aspx">Mosques</a>
                           </li>
                           <li class="nav-item">
                               <a class="footerr-text" href="#">Scholars</a>
                           </li>
                           <li class="nav-item">
                               <a class="footerr-text" href="#">Learn Islam</a>
                           </li>
                           <li class="nav-item">
                               <a class="footerr-text" href="Zakaah.aspx">Zakaah</a>
                           </li>
                        </ul>
                    </div>
                    <div class="col  text-center position-static">
                        <h6>About us</h6>
                        <ul class="navbar-nav">
                            <li class="nav-item">
                                <a class="footerr-text" href="#">Content</a>
                            </li>
                            <li class="nav-item">
                                <a class="footerr-text" href="#">Content</a>
                            </li>
                            <li class="nav-item">
                                <a class="footerr-text" href="#">Content</a>
                            </li>
                        </ul>
                    </div>
                    <div class="col  text-center position-static">
                        <h6>Contact us</h6>
                        <ul class="navbar-nav">
                            <li class="nav-item">
                                <a class="footerr-text" href="#">Content</a>
                            </li>
                            <li class="nav-item">
                                <a class="footerr-text" href="#">Content</a>
                            </li>
                            <li class="nav-item">
                                <a class="footerr-text" href="#">Content</a>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        <script src="../Default/Default.js"></script>
    </body>
        <script src="../Default/Default.js"></script>
         </html>
