<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MosqueEvents.aspx.cs" Inherits="Muslimeen.Content.MyScholar.MosqueEvents" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="utf-8"/>
	<meta http-equiv="X-UA-Compatible" content="IE=edge"/>
	<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>

    <title>Mosque Events</title>

    <link href="../../Login/LogIn_Bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/MyScholar.css" rel="stylesheet" />

</head>
<body>
    <form id="frmEvents" runat="server">
        <!--Header-->
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
                            <li><asp:HyperLink ToolTip="Edit user profile" runat="server" ID="hplUserProfile" href="../Content/ProfileEditer.aspx" CssClass="nav-item mb-0 mr-3 user"></asp:HyperLink></li>
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

        <!--Page Content-->
        <div class="d-flex flex-row mt-2">
            <ul class="nav nav-tabs nav-tabs--vertical nav-tabs--left" role="navigation">
                <li class="nav-item">
                    <a href="AddArticle.aspx" class="nav-link" data-toggle="tab" role="tab" aria-controls="lorem">Add Article</a>
                </li>
                <li class="nav-item">          
                    <a href="PendingArticle.aspx" class="nav-link" data-toggle="tab" role="tab" aria-controls="ipsum">Pending Article</a>
                </li>
                <li class="nav-item">
                    <a href="RejectedArticle.aspx" class="nav-link" data-toggle="tab" role="tab" aria-controls="dolor">Rejected Article</a>
                </li>
                <li class="nav-item">
                    <a href="MosqueEvents.aspx" class="nav-link active" data-toggle="tab" role="tab" aria-controls="sit-amet">Mosque Events</a>
                </li>
            </ul>
            
            <div class="tab-content">
                <div class="tab-pane fade show active" role="tabpanel">
                    <h2 class="text-center">Mosque Events</h2>                        
                </div>
            </div>

         </div>
    </form>    
    
    <!--Footer-->
<div class="footerr"> <!--End of content, start of footer-->
                <div class="row bg-light">
                    <div class="col text-center position-static">
                       <h6>Content</h6>
                        <ul class="navbar-nav">
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

    <script src="../Default/Default.js"></script>
    <script src="../Default/DatesEnglishHijri.js"></script>
</body>
</html>
