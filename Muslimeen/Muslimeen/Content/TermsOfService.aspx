﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TermsOfService.aspx.cs" Inherits="Muslimeen.Content.TermsOfService" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
	<meta http-equiv="X-UA-Compatible" content="IE=edge"/>
	<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>

    <title>TermsAndPolicies</title>
    <link rel="icon" href="/Login/LogIn_Bootstrap/muslimeen.ico"/>
    <link href="../Login/LogIn_Bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="Default/css/Default.css" rel="stylesheet" />
    <link href="../Content/HelpPage/HelpPage.css" rel="stylesheet" />

</head>
    <body>
        <form id="frmScholar" runat="server" class=" ">  
           <header >
                <nav class="navFixed">
                    <div class="row align-self-end">
                        <ul class=" col-7 navbar-nav flex-row justify-content-start">
                            <asp:HiddenField runat="server" ID="hfAdjustDate" Value="-2" /> <!--Need to get value from DB let admin adjust this -->
                            <li class="nav-item ml-4 mr-0 mb-0 pt-2"> <p class="IslamicDate mb-0" id="lstIslamicDate"></p></li>
                            <script src="Default/DatesEnglishHijri.js" type="text/javascript"></script>
                        </ul>
                        <ul class="col-5 navbar-nav flex-row justify-content-end">
                            <li class="nav-item ml-0 mr-0">
                            <asp:TextBox ID="txtSearch" TextMode="Search" runat="server"  class=" search-box form-control form-control-sm" autocomplete="off" placeholder="Search"></asp:TextBox>
                            </li>
                            <li class="nav-item mr-2">
                                <asp:Button runat="server" Text="Go" CssClass="topnav search-btn form-control form-control-sm" />
                            </li>
                            <li class=" nav-item mr-2">
                            <asp:Button runat="server" Text="Login" ID="btnLogin" CssClass="topnav btn btn-sm btn-outline-light" OnClick="btnLogin_Click" />
                            </li>
                            <li class="nav-item mr-2">
                            <asp:Button runat="server" Text="Register" ID="btnRegister" CssClass="topnav btn btn-sm btn-outline-light" OnClick="btnRegister_Click" />
                            </li>
                        </ul>
                    </div>
                    <div class="row">
                        <ul class="col navbar-nav flex-row ml-4 mb-0 mt-0 pt-2 justify-content-end">
                            <li><asp:HyperLink ToolTip="Edit user profile" runat="server" ID="hplUserProfile" NavigateUrl="~/Content/ProfileEditer.aspx" CssClass="nav-item mb-0 mr-3 user"></asp:HyperLink></li>
                        </ul>
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
                            <li class="nav-item navbarText navbaritems">
                                <asp:Button runat="server" ID="btnMyMuslimeen" Text="MyMuslimeen"  CssClass=" btn btn-link nav-item navText"/>
                            </li><li class="NavDevider">|</li><!--deviders-->
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
     <!--Add content-->
             <div class="container"> 
                 <br />
            <h1 class="title">Terms and Policies     <asp:Image runat="server" CssClass="mb-0 ml-0"  src="../Content/HelpPage/icons/docs.png" width="90" height="70"/></h1> 
                <hr />


                 <p>
                      <b>Terms of service:</b><br />
                     These terms of use are effective on January 2018. <br />
                     By using My Muslimeen website, you are agreeing to be bound by the following terms and conditions ("Terms of service"). <br />
                 </p>

                 <ol>
                     <li>
                         You must be 10 years or older to use this site.
                     </li>
                     <li>
                         You are responsible for keeping your password secure.
                     </li>
                     <li>
                         You may not harass or threaten our scholars regarding their content uploaded.
                     </li>
                     <li>
                         You may not use My Muslimeen for illegal or unauthorized purposes.
                     </li>
                     <li>
                         Each user is responsible for their own profile and conduct. 
                     </li>
                     <li>
                         You may not modify, adapt or hack my Muslimeen so as to falsely say that it is associated with My Muslimeen.
                     </li>
                   
                 </ol>

                 <b>General Conditions:</b><br />
                 <ol>
                     <li>
                         We reserve the right to alter these terms at any time. If we terminate your access to the Service, 
                         your articles and all other data will no longer be accessible through your account.
                     </li>
                     <li>
                         We reserve the right to refuse access to the Service to anyone for any reason at any time.
                     </li>
                     <li>
                         We reserve the right to force forfeiture of any name for any reason.
                     </li>
                     <li>
                         You are solely responsible for your interaction with other users of the Service.
                     </li>
                 </ol>
                 <br />

                 <b>Violation of these agreements will result in the termination of your account.</b>
                 <br />
                 </div>

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
            </form>
        <script src="Default/Default.js" type="text/javascript"></script>
    </body>
        <script src="Default/Default.js" type="text/javascript"></script>
</html>