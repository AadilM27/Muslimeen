﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyAdmin.aspx.cs" Inherits="Muslimeen.Content.MyAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
	<meta http-equiv="X-UA-Compatible" content="IE=edge"/>
	<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>

    <title>MyMuslimeen - Home</title>
    <link rel="icon" href="/Login/LogIn_Bootstrap/muslimeen.ico"/>
    <link href="../Login/LogIn_Bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="MyAdmin/css/MyAdmin.css" rel="stylesheet" />
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
                                <asp:ImageButton runat="server" Text="Go" ImageUrl="~/Content/Default/icons/Search.png" Height="31px" Width="31px" CssClass="topnav search-btn form-control form-control-sm" />
                            </li>
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
                        </ul>
                    </div>
                </div>
            </header>
            <div class="content" id="content"><!--add content here -->
                <div class="row">
                    <div class="col-3" style="background-color:yellow; height:90px;">
                        <div runat="server"  class="row justify-content-around align-content-center" style="background-color:green; height:auto;">
                            <a runat="server" id="lnkViewwPendingSch" class="btn btn-block lnkPendingReg">View Pending reg</a>
                        </div>
                        <div class="row justify-content-around align-content-center" style="background-color:green; height:auto;">
                            <a runat="server" id="lnkViewwPendingMod" class="btn btn-block lnkPendingReg">View Pending Mod</a>
                        </div>
                    </div>
                    <div class="col-9" style="background-color:blue; height:90px;">
                        <div class="row divContainers" runat="server" id="divViewPendingSch" style="background-color:pink; height:80px;">

                        </div>
                        <div runat="server" id="divViewPendingMod" class="row divContainers" style="background-color:pink; height:80px;">

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
            <script src="Default/Default.js" type="text/javascript"></script>
            <script src="Default/Default.js" type="text/javascript"></script>
            <script src="MyAdmin/js/MyAdmin.js"></script>
    </body>
</html>
