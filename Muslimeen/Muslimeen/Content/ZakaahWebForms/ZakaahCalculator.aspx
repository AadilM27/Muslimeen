<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZakaahCalculator.aspx.cs" Inherits="Muslimeen.Content.ZakaahWebForms.ZakaahCalculator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
 <head runat="server">
    <meta charset="utf-8"/>
	<meta http-equiv="X-UA-Compatible" content="IE=edge"/>
	<meta name="viewport" content="width=device-width, height=device-height, initial-scale=0.0"/>

    <title>MyMuslimeen - Zakaah Calculator</title>
     <link rel="icon" href="../../Login/LogIn_Bootstrap/muslimeen.ico" />
     
     <link href="../../Login/LogIn_Bootstrap/css/bootstrap.min.css" rel="stylesheet" />
     <link href="../Zakaah/css/ProperZakaah.css" rel="stylesheet" />
     <script src="../../Login/LogIn_Bootstrap/js/jquery-3.3.1.min.js"></script>
     <script language="JavaScript" type="text/javascript">
        function onlyNumbers(evt)
        {
        var e = event || evt; // for trans-browser compatibility
        var charCode = e.which || e.keyCode;

        if (charCode > 31 && (charCode < 48 || charCode > 57))
            return false;

        return true;

        }
        </script>
</head>
    <body>
       <asp:HyperLink ID="lnk1" runat="server" href="HelpPage.aspx"></asp:HyperLink>
           <div id="divAlertPopup" runat="server" style="display:none;" class="container-fluid text-center p-2 m-0 w-100 alert alert-success visible">
                <label class="h6" id="lblAlertError"  runat="server" ></label>
        </div>
        <form id="frmScholar" runat="server" class=" ">   
            <header >
                <nav class="navFixed">
                    <div class="row align-self-end">
                        <ul class=" col-7 navbar-nav flex-row justify-content-start">
                            <asp:HiddenField runat="server" ID="hdfAdjustDate" Value="" /> <!--Need to get value from DB let admin adjust this -->
                            <li class="nav-item ml-4 mr-0 mb-0 pt-2"> <p class="IslamicDate mb-0" id="lstIslamicDate"></p></li>
                            <script src="../Default/DatesEnglishHijri.js" type="text/javascript"></script>
                        </ul>
                        <ul class="col-5 navbar-nav flex-row justify-content-end">
                            <li class=" nav-item mr-2">
                            <asp:Button runat="server" Text="Login" ID="btnLogin" CssClass="topnav btn btn-sm btn-outline-light" OnClick="btnLogin_Click" />
                            </li>
                            <li class="nav-item mr-2">
                            <asp:Button runat="server" Text="Register" ID="btnRegister" CssClass="topnav btn btn-sm btn-outline-light" OnClick="btnRegister_Click" />
                            </li>
                        </ul>
                    </div>
                    <div class="row" runat="server" id="divUserProfile" >
                        <div class="col navbar-nav flex-row ml-4 mb-0 mt-0 pt-2 justify-content-end">
                            <asp:HyperLink ID="hplUserProfile" ToolTip="Edit user profile" runat="server" NavigateUrl="../ProfileEditer.aspx" CssClass="nav-item mb-0 mr-1 ml-1 user">
                            </asp:HyperLink><asp:Image style="height:15px; width:15px;" runat="server" id="imgEditProfile" CssClass="mt-1 mr-3" ImageUrl="../Default/icons/EditProfile.png"/>
                        </div>
                    </div>
                </nav>
                <div id="navbar" class="navbar navbar-expand flex-column navv flex-md-row" style="box-shadow: 0 0 0 0.1rem rgba(0, 123, 255, 0.50);">
                    <div class=" text-center">
                        <asp:Image runat="server" CssClass="mb-0 ml-0" src="../../Login/LogIn_Bootstrap/logo.png" width="185" height="110"/>
                        </div>
                    <div class="ml-2 navbar-nav-scroll align-self-end justify-content-start">
                        <ul class="navbar-nav row">
                            <li class="nav-item navbarText navbaritems">
                                <asp:Button runat="server" ID="btnHome" Text="Home"  CssClass=" btn btn-link nav-item navText" OnClick="btnHome_Click"/>
                            </li><li class="NavDevider">|</li><!--deviders-->
                            <li class="nav-item navbarText navbaritems" runat="server" id="liMyMusbtn">
                                <asp:Button runat="server" ID="btnMyMuslimeen" Text="MyMuslimeen"  CssClass=" btn btn-link nav-item navText" OnClick="btnMyMuslimeen_Click"/>
                            </li><li runat="server" id="liMyMusDivi" class="NavDevider">|</li><!--deviders-->
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
                            <li class="NavDevider">|</li>
                         <!--deviders-->
                        <li class="nav-item navbarText navbaritems">
                        <asp:LinkButton ID="LnkHelp" runat="server"  OnClick="btnHelp_Click" CssClass="nav-item navText btn-link btn" ToolTip="How this page works" ><%--CssClass="nav-item navText btn-link btn"--%>
                         Help    <asp:Image runat="server" ID="ImgHelp" ImageUrl="../MyMember/icons/helpIcon.png" style="height: 1.1em; width:1.1em;" /></asp:LinkButton>   
                        </li>
                        </ul>
                    </div>
                </div>
            </header>
        
   <div class="content" id="content"><!--add content here -->
           
        <div class="zakaah-content " style="position:static;" >
            <nav class="navbar navbar-expand-sm navbar-dark topnav btn btn-sm btn-outline-light mr-2 " style="position:static; background-color:#256297;">
              <a class="navbar-brand navt " href="Zakaah.aspx" >Zakaah</a>
              <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#collapsibleNavbar">
                <span class="navbar-toggler-icon"></span>
              </button>
              <div class="collapse navbar-collapse" id="collapsibleNavbar">
                <ul class="navbar-nav">
                  <li class="nav-item">
                    <a class="navbar-brand navt" href="ZakaahCalculator.aspx">Calculator</a>
                  </li>
                  <li class="nav-item">
                    <a class="navbar-brand navt" href="ZakaahGallery.aspx">Gallery</a>
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
                             
        
            
                    <div style="text-align:center;color:white;background-color:#256297;font-size:20px;width:100%" class=" topnav btn btn-sm btn-outline-light mr-2 ">
                    <strong >Assets and Liabilities</strong>

                    </div>
                    <br />
                    <br />
                     
                    <div style="width:100%; height: 50px; clear: both;background-color:transparent" class=" btn btn-sm btn-outline-light mr-2 ">
                    <div style="float: left;color:#256297">
                    <asp:Label ID="Label1" runat="server" Text="Label">Cash at Home</asp:Label>
                    </div>
                    <div style="float: right;">
                    <asp:TextBox ID="txtCashAtHome" CssClass="form-control form-control-sm topnav  mr-2 " runat="server" OnTextChanged="txtCashAtHome_TextChanged" onKeyPress ="return onlyNumbers();"></asp:TextBox>  
                    </div>

                    </div>
                    <div style="width:100%; height: 50px; clear: both;background-color:transparent" class=" btn btn-sm btn-outline-light mr-2 ">
                    <div style="float: left;color:#256297">
                    <asp:Label ID="Label2" runat="server" Text="Label">Balance held in Bank Account</asp:Label>
                    </div>
                    <div style="float: right;">
                    <asp:TextBox ID="txtBankAccount" CssClass="form-control form-control-sm topnav  mr-2 " runat="server" OnTextChanged="txtBankAccount_TextChanged" onKeyPress ="return onlyNumbers();" ></asp:TextBox>
                    </div>

                    </div>
                    <div style="width:100%; height: 50px; clear: both;background-color:transparent" class=" btn btn-sm btn-outline-light mr-2 ">
                    <div style="float: left;color:#256297">
                    <asp:Label ID="Label3" runat="server" Text="Label">short term investments</asp:Label>
                    </div>
                    <div style="float: right;">
                    <asp:TextBox ID="txtInvestment" CssClass="form-control form-control-sm topnav   mr-2 "  runat="server" OnTextChanged="txtInvestment_TextChanged" onKeyPress ="return onlyNumbers();" ></asp:TextBox>
                    </div>

                    </div>
                    <div style="width:100%; height: 50px; clear: both;background-color:transparent" class=" btn btn-sm btn-outline-light mr-2 ">
                    <div style="float: left;color:#256297">
                    <asp:Label ID="Label4" runat="server" Text="Label">Business Merchandise</asp:Label>
                    </div>
                    <div style="float: right;" >
                    <asp:TextBox ID="txtMerchandise" CssClass=" form-control form-control-sm topnav   mr-2 " runat="server" OnTextChanged="txtMerchandise_TextChanged" onKeyPress ="return onlyNumbers();"></asp:TextBox>
                    </div>

                    </div>
                   <div style="width:100%; height: 50px; clear: both;background-color:transparent" class=" btn btn-sm btn-outline-light mr-2 ">
                   <div style="float: left;color:#256297">
                   <asp:Label ID="Label5" runat="server" Text="Label">Gold &amp; Silver (at current value)</asp:Label>
                   </div>
                   <div style="float: right;">
                   <asp:TextBox ID="txtGoldSilver" CssClass="form-control form-control-sm topnav   mr-2 " runat="server" OnTextChanged="txtGoldSilver_TextChanged" onKeyPress ="return onlyNumbers();" ></asp:TextBox></div>
                   </div>
                   <div style="width:100%; height: 50px; clear: both;background-color:transparent" class=" btn btn-sm btn-outline-light mr-2 ">
                   <div style="float: left; color:white;color:#256297">
                   <asp:Label ID="Label6" runat="server" Text="Label">Total of Assets Liable for Zakah</asp:Label>
                   </div>
                   <div style="float: right;">
                   <asp:TextBox ID="txtTotalAssets"  CssClass="form-control form-control-sm topnav   mr-2 "   runat="server" OnTextChanged ="txtTotalAssets_TextChanged" ReadOnly="true" onKeyPress ="return onlyNumbers();" ></asp:TextBox>
                    <br />
                       <asp:Label ID="LblRequire" runat="server" Text=""></asp:Label>
                   </div>

                   </div>
                   <div style="width:100%; height: 50px; clear: both;background-color:transparent" class=" btn btn-sm btn-outline-light mr-2 ">
                   <div style="float: left;color:#256297">
                   <asp:Label ID="Label7" runat="server" Text="Label">Deduct Debts</asp:Label>
                   </div>
                   <div style="float: right;">
                   <asp:Textbox ID="txtAllDebts" CssClass="form-control form-control-sm topnav   mr-2 "  runat="server" OnTextChanged="txtAllDebts_TextChanged" onKeyPress ="return onlyNumbers();"></asp:Textbox>
                       <br />
                       <div runat="server" id="divRequire" style ="float:right">
                       <asp:Label ID="LblRequire1" runat="server" Text=""></asp:Label>
                           </div>
                   </div>

                   </div>
                   <div style="width:100%; height: 50px; clear: both;background-color:transparent" class=" btn btn-sm btn-outline-light mr-2 ">
                   <div style="float: left; color:white;font-size: 15px;color:#256297">
                   <asp:Label ID="Label8" runat="server" Text="Label"><strong><em>Zakah-Eligible</em> Total</strong></asp:Label>
                   </div>
                   <div style="float: right;">
                   <asp:TextBox ID="txtEligibleZakaah" CssClass="form-control form-control-sm topnav   mr-2 " runat="server" OnTextChanged="txtEligibleZakaah_TextChanged" ReadOnly="true" onKeyPress ="return onlyNumbers();"></asp:TextBox>
                   </div>

                  </div>
                  <div style="width:100%; height: 50px; clear: both;background-color:transparent" class=" btn btn-sm btn-outline-light mr-2 ">
                  <div style="float: left;color: #256297;font-size: 15px;">
                  <strong >Total that Exceeds <em>Nisab</em></strong>
                  </div>
                  <div style="float: right;">
                  <asp:TextBox ID="txtNisab" CssClass="form-control form-control-sm topnav   mr-2 " runat="server" value="4404" ReadOnly="true" onKeyPress ="return onlyNumbers();"></asp:TextBox>
                  </div>

                  </div>
                  <div style="width:100%; height: 50px; clear: both;background-color:transparent" class=" btn btn-sm btn-outline-light mr-2 ">
                  <div style="float: left;color: #256297;font-size: 15px;">
                  <asp:Label ID="Label9" runat="server" Text="Label"><strong>Your <em>Zakah</em></strong><strong>(2.5% Total)</strong></asp:Label>
                  </div>
                  <div style="float: right;">
                  <asp:TextBox ID="txtCalculatedZakaah" CssClass="form-control form-control-sm topnav   mr-2 " runat="server" OnTextChanged="txtCalculatedZakaah_TextChanged" ReadOnly="true" onKeyPress ="return onlyNumbers();"></asp:TextBox> 
                  </div>

                  </div>
                  <br />
                  <div style="text-align:center;color:white;font-size:15px;background-color:#256297">
                  <asp:Label ID="LblMessage" runat="server" Text=""></asp:Label>
                  </div>
                  <br />
                  <div style="position:static;align-items:center;vertical-align:central">
                  <asp:Button ID="Button1" runat="server" Text="Calculate  Assets" CssClass=" topnav btn btn-sm btn-outline-light mr-2 " ToolTip="click here to calculate your total Assets" OnClick="Button1_Click1" autopostback="true" />                      
                  <asp:Button ID="Button2" runat="server" Text="Calculate Zakaah" CssClass=" topnav btn btn-sm btn-outline-light mr-2 " ToolTip="Calculate your zakaah after deductions" autopostback="true" OnClick="Button2_Click"/>
                  </div>
                              <br />
                  
                  </div>
                  <div class="col-lg-4" style="position:static;">
                       <!---javascript code to translate language--->
                      <div class="carder" style="width:500px">
                        <img src="../Zakaah/ZakaahPics/SANZAF_580x363.jpg" alt="zakaat" style="width:100%"/>
                        <div class="container-fluid" style="background-color:#256297;color:white;padding-left:10em">
                      <h1 >SANZAF</h1>
                       </div>
                        <div class ="container-fluid" style="color:#256297;padding-left:7em">
                      <p >South African National Zakaah Fund</p>
                      <p>Bursary Scheme for those in need.</p>
                        <div class="button" >
                     <a href="https://sanzaf.org.za/appeals/sanzaf-bursary-program.html">Contact:WWW.SANZAF.ORG.ZA</a>
                       </div>
                       </div>
                    </div>
                        <br /> 
                      
                   
                  </div>
                </div>
                        
                </div>
                </div>
                </div>
               </form>   
            <div class="footerr"> <!--End of content, start of footer-->
                <div class="row bg-light">
                    <div class="col text-center position-static">
                       <h6>Content</h6>
                        <ul class="navbar-nav">
                           <li class="nav-item">
                               <a class="footerr-text" href="../Mosque/ListMosque.aspx">Mosques</a>
                           </li>
                           <li class="nav-item">
                               <a class="footerr-text" href="../ListScholar.aspx">Scholars</a>
                           </li>
                           <li class="nav-item">
                               <a class="footerr-text" href="../Learn Islam/LearnIslam.aspx">Learn Islam</a>
                           </li>
                           <li class="nav-item">
                               <a class="footerr-text" href="../ZakaahWebForms/Zakaah.aspx">Zakaah</a>
                           </li>
                        </ul>
                    </div>
                    <div class="col  text-center position-static">
                        <h6>Support</h6>
                        <ul class="navbar-nav">
                            <li class="nav-item">
                                <a class="footerr-text" href="../AboutUs.aspx">About Us</a>
                            </li>
                            <li class="nav-item">
                                <a class="footerr-text" href="../HelpPage.aspx">Help</a>
                            </li>
                            <li class="nav-item">
                                <a class="footerr-text" href="../HelpCenter.aspx">Help Center</a>
                            </li>
                            <li class="nav-item">
                                <a class="footerr-text" href="../TermsOfService.aspx">Terms</a>
                            </li>
                        </ul>
                    </div>
                    <div class="col  text-center position-static">
                        <h6>Contact us</h6>
                        <ul class="navbar-nav">
                            <li class="nav-item">
                                <a class="footerr-text" href="mailto:nextechgrp@gmail.com">Email</a>
                            </li>
                            <li class="nav-item">
                                <a class="footerr-text" href="#">+27743784081</a>
                            </li>
                            <li class="nav-item">
                                <a class="footerr-text" href="https://www.youtube.com/channel/UCp87ZLRrUz3SbzPPP2uaIEg">YouTube</a>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        <script src="../Default/Default.js"></script>
    </body>
    <script src="../MyAdmin/js/MyAdmin.js"></script>
        <script src="../Default/Default.js"></script>
         </html>
