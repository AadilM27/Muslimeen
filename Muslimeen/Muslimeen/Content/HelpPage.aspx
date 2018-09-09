<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HelpPage.aspx.cs" Inherits="Muslimeen.Content.HelpPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
	<meta http-equiv="X-UA-Compatible" content="IE=edge"/>
	<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>

    <title>Help Page</title>
    <link rel="icon" href="../Login/LogIn_Bootstrap/muslimeen.ico"/>
    <link href="../Login/LogIn_Bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="HelpPage/HelpPage.css" rel="stylesheet" />
</head>
    <body>
        <asp:HyperLink ID="lnk1" runat="server" href="HelpPage.aspx"></asp:HyperLink>
        <form id="frmScholar" runat="server" class=" ">   
            <header >
                <nav class="navFixed">
                    <div class="row align-self-end">
                        <ul class=" col-7 navbar-nav flex-row justify-content-start">
                            <asp:HiddenField runat="server" ID="hdfAdjustDate" Value="" /> <!--Need to get value from DB let admin adjust this -->
                            <li class="nav-item ml-4 mr-0 mb-0 pt-2"> <p class="IslamicDate mb-0" id="lstIslamicDate"></p></li>
                            <script src="Default/DatesEnglishHijri.js" type="text/javascript"></script>
                        </ul>
                        <ul class="col-5 navbar-nav flex-row justify-content-end">
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
                            <asp:HyperLink ID="hplUserProfile" ToolTip="Edit user profile" runat="server" NavigateUrl="ProfileEditer.aspx" CssClass="nav-item mb-0 mr-1 ml-1 user">
                            </asp:HyperLink><asp:Image style="height:15px; width:15px;" runat="server" id="imgEditProfile" CssClass="mt-1 mr-3" ImageUrl="Default/icons/EditProfile.png"/>
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
                            <li class="NavDevider">|</li>
                         <!--deviders-->
                        <li class="nav-item navbarText navbaritems">
                        <asp:LinkButton ID="LnkHelp" runat="server"  OnClick="btnHelp_Click" CssClass="nav-item navText btn-link btn" ToolTip="How this page works" ><%--CssClass="nav-item navText btn-link btn"--%>
                         Help <asp:Image runat="server" ID="ImgHelp" ImageUrl="MyMember/icons/helpIcon.png" style="height: 1.1em; width:1.1em;" /></asp:LinkButton>   
                        </li>
                        </ul>
                    </div>
                </div>
            </header>
     <!--Add content-->
            <div class="content" id="content" style="min-height:500px; background-color:#256297">
                <div class="contentHolder p-0" ">
                    <div class="head-div text-center p-1 mb-2">
                        <h2 class="p-2 m-0">Help and Support</h2>
                    </div>
                    <hr style="background-color: #17a2b8" />
                    <div class="row contentHolder p-5"  >
                <!--Help Center-->
                        
                              <div class =" col text-center paragraphDisplay mb-3 p-1 " style="position:static; height:225px; border-radius:5px; ">
                                  <div class="position-static basic-div-styling p-3 h-100 " style= "background-color:white">
                                  <asp:Image runat="server" CssClass="mb-0 ml-0 " src="HelpPage/icons/help.png" width="90" height="70"/>
                                <h4 class="text-center"><a href="HelpCenter.aspx">Help Center</a></h4>
                                 <p class="text-center">
                                      Getting started <br/>
                                      Managing your account<br />
                                      How my Muslimeen feed works<br />
                                  </p>
                                  </div>
                              </div>
                        
                  <!--Privacy and Safety--> 
                            <div class =" col-4 text-center paragraphDisplay mb-3 ml-3 p-1" style="position:static; height:225px; border-radius:5px;"><!--and this one static also-->
                                 <div class="position-static basic-div-styling p-3 h-100" style= "background-color:white">
                                    <asp:Image runat="server" CssClass="mb-0 ml-0" src="HelpPage/icons/lock.png" width="90" height="70"/>
                                    <h4 class="text-center"><a href="PrivacyAndSafety.aspx"> Privacy and safety</a></h4>  
                
                                   Our data policy and your privacy      
                                </div>
                             </div>
            
                             <!--Terms and Policies -->
                            <div class ="col text-center paragraphDisplay mb-3 ml-3 p-1" style="position:static; height:225px; border-radius:5px; "> <!--Like this i made this position static-->
                                 <div class="position-static basic-div-styling p-3 h-100" style= "background-color:white" >
                                <asp:Image runat="server" CssClass="mb-0 ml-0"  src="HelpPage/icons/docs.png" width="90" height="70"/>
                                <h4 class="text-center"><a href="TermsOfService.aspx">Terms and policies</a></h4> 
                                <p class="text-center">
                                Terms of service<br />
                                </p>
                                  </div>
                        </div>
                    </div>  
              </div> <!--close Row-->
        </div>
            <div class="footerr"> <!--End of content, start of footer-->
                <div class="row bg-light">
                    <div class="col text-center position-static">
                       <h6>Content</h6>
                        <ul class="navbar-nav">
                           <li class="nav-item">
                               <a class="footerr-text" href="Mosque/ListMosque.aspx">Mosques</a>
                           </li>
                           <li class="nav-item">
                               <a class="footerr-text" href="ListScholars.aspx">Scholars</a>
                           </li>
                           <li class="nav-item">
                               <a class="footerr-text" href="Learn Islam/LearnIslam.aspx">Learn Islam</a>
                           </li>
                           <li class="nav-item">
                               <a class="footerr-text" href="ZakaahWebForms/Zakaah.aspx">Zakaah</a>
                           </li>
                        </ul>
                    </div>
                    <div class="col  text-center position-static">
                        <h6>Support</h6>
                        <ul class="navbar-nav">
                            <li class="nav-item">
                                <a class="footerr-text" href="AboutUs.aspx">About Us</a>
                            </li>
                            <li class="nav-item">
                                <a class="footerr-text" href="HelpPage.aspx">Help</a>
                            </li>
                            <li class="nav-item">
                                <a class="footerr-text" href="HelpCenter.aspx">Help Center</a>
                            </li>
                            <li class="nav-item">
                                <a class="footerr-text" href="TermsOfService.aspx">Terms</a>
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
            </form>
        <script src="Default/Default.js"></script>
    </body>
</html>
