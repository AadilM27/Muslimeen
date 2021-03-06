﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZakaahOrganizations.aspx.cs" Inherits="Muslimeen.Content.ZakaahWebForms.ZakaahOrganizations" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
	<meta name="viewport" content="width=device-width, height=device-height, initial-scale=0.0"/>

    <title>MyMuslimeen - Organizations</title>
    <link rel="icon" href="../../Login/LogIn_Bootstrap/muslimeen.ico" />    
    <link href="../../Login/LogIn_Bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    
    <link href="../Zakaah/css/ProperZakaah.css" rel="stylesheet" />
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
                            <script src="../Default/DatesEnglishHijri.js" type="text/javascript"></script>
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
                            <asp:HyperLink ID="hplUserProfile" ToolTip="Edit user profile" runat="server" NavigateUrl="../ProfileEditer.aspx" CssClass="nav-item mb-0 mr-1 ml-1 user">
                            </asp:HyperLink><asp:Image style="height:15px; width:15px;" runat="server" id="imgEditProfile" CssClass="mt-1 mr-3" ImageUrl="../Default/icons/EditProfile.png"/>
                        </div>
                    </div>
                </nav>
                <div id="navbar" class="navbar navbar-expand flex-column navv flex-md-row" style="box-shadow: 0 0 0 0.1rem rgba(0, 123, 255, 0.50); z-index:1000;">
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
                         Help    <asp:Image runat="server" ID="ImgHelp" ImageUrl="../MyMember/icons/helpIcon.png" style="height: 1.1em; width:1.1em;" /></asp:LinkButton>   
                        </li>
                        </ul>
                    </div>
                </div>
            </header>
        <div class="content" id="content">
            <!--add content here -->
            <div class="zakaah-content" style="position: static;">
                <nav class="navbar navbar-expand-sm navbar-dark" style="position: static; background-color: #256297;">
                    <a class="navbar-brand navt " href="Zakaah.aspx">Zakaah</a>
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

                <div class="container" style="margin-top: 10px; position: static;">
                    <div class="row" style="position: static; right: 50px">
                        <div class="col-lg-12" style="position: static; background-color: #256297">



                            <div style="text-align: center; color: white; background-color: #256297; font-size: 20px; width: 100%">
                                <strong>List of Zakaat Organizations</strong>

                            </div>
                            <br />
                            <asp:Repeater ID="rptOrganization" runat="server">
                                <ItemTemplate>
                                    <div class="container">
                                        <div class="jumbotron">
                                            <table class="table table-active align-content-center shadow-lg" style="color: gray">
                                                <tr>
                                                    <td rowspan="3">
                                                        <asp:Image ID="OrganizationIMG" ImageUrl='<%# "../" + Eval("Image")%>' runat="server" Width="200px" Height="180px" />
                                                    </td>
                                                    <td>
                                                       <label style="font-size:20px;font-weight:500;color:#256297">Organization: </label> <asp:Label ID="lblOrgName" runat="server" Text='<%#Eval("Name")%>'></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                       
                                                    <label style="font-size:medium;font-weight:500;color:#256297">Website: </label>&nbsp<asp:HyperLink ID="linkAddress" runat="server" NavigateUrl='<%#Eval("WebsiteAddress")%>' Text='<%#Eval("WebsiteAddress")%>' /> </td> 
                                                   
                                                </tr>
                                                <tr>
                                                    <td><label style="font-size:medium;font-weight:500;color:#256297">ContactNo: </label><br /><asp:Label ID="lblContactNo" runat="server" Text='<%#Eval("ContactNo")%>'></asp:Label></td>
                                                    <td><label style="font-size:medium;font-weight:500;color:#256297">Physical Address:</label><br /><asp:Label ID="LblPhysical" runat="server" Text='<%#Eval("PhysicalAddress")%>'></asp:Label></td>                                                
                                                    </tr>
                                            </table>
                                        </div>
                                </ItemTemplate>

                                <SeparatorTemplate>
                                    <div class="divider" style="height: 1em"></div>
                                </SeparatorTemplate>
                            </asp:Repeater>

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
<script src="../Default/Default.js"></script>

</html>
