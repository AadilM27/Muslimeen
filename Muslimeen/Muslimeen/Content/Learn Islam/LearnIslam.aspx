<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LearnIslam.aspx.cs" Inherits="Muslimeen.Content.Learn_Islam.LearnIslam" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="utf-8"/>
	<meta http-equiv="X-UA-Compatible" content="IE=edge"/>
	<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>

    <title>learn Islam</title>

    <link href="../../Login/LogIn_Bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/learnIslam.css" rel="stylesheet" />

</head>
<body style="background-color:white">
    <asp:HyperLink ID="lnk1" runat="server" src="HelpPage.aspx"></asp:HyperLink>
    <form id="frmLearnIslam" runat="server">
        <!--Header-->
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

        <!--Page Content-->
        <div class="content" id="content" style="z-index:1000">
            <!--add content here -->
            <div class="row bg-light m-0 divContainers p-1 flex-nowrap">
                <div class="side-bar p-0 basic-div-styling mr-1">
                    <!--contains the buttons-->
                    <div class="head-div text-center p-2">
                        <p class="text-uppercase m-0 font-weight-bold">Search:</p>
                    </div>
                    <nav class="nav flex-column pt-2 pb-2 pr-0">
                        <!--Searching options will go here.-->
                    </nav>
                </div>
                <div class=" position-static basic-div-styling p-0  w-100">
                    <div class=" head-div text-center p-2 mb-1">
                        <h4 class="p-0 m-0">Learn Islam</h4>
                    </div>
                    <div class="row p-0 m-0 right-bottom-div p-1 flex-nowrap">
                        <%--Pending Articles--%>
                        <div class="col-5 col-sm-5 col-md-6 col-xl-4 p-0 mr-1" runat="server" id="divPendingArticles">
                            <div class=" head-div-2 p-2 mb-1 text-left">
                                <p class="m-0">Articles</p>
                            </div>
                            <div class="p-1 lst-container" style="overflow-y: scroll;">
                                <asp:Repeater ID="repeatLink" runat="server">
                                    <HeaderTemplate>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <div class="p-0 form-row m-0 position-static">
                                            <div class=" col-auto position-static p-0">
                                                <div class="">
                                                    <p style="font-size: small" class="p-0 m-0 text-truncate"><b>Article&nbsp;Title: </b><%#Eval("ArticleTitle")%><br />
                                                    </p>
                                                </div>
                                                <hr class=" mr-4 m-0 p-0" />
                                                <div class="">
                                                    <p style="font-size: small" class="p-0 m-0 text-truncate"><b>Content: </b><%#Eval("ArticleContent").ToString().PadRight(30).Substring(0,30).TrimEnd() + "..."%> 
                                                        <asp:LinkButton ID="btnShow" CommandArgument='<%#Eval("ArticleID") %>' runat="server" OnClick="btnShow_Click">
                                                            Read More
                                                        </asp:LinkButton>
                                                    </p>
                                                </div>
                                                <hr class=" mr-4 m-0 p-0" />
                                                <div class="">
                                                    <p style="font-size: small;" class="p-0 m-0 text-truncate"><b>Date Created: </b><%#Convert.ToDateTime(Eval("DateCreated")).ToString("dd/MM/yyyy")%></p>
                                                </div>
                                            </div>
                                        </div>
                                        <hr class="p-0 m-1" />
                                    </ItemTemplate>
                                    <FooterTemplate>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </div>
                        </div>

                        <%--Display of Pending Articles--%>
                        <div runat="server" id="divNoSelected" class="col-7 col-sm-7 col-xl-8 align p-0 text-justify">
                            <asp:HiddenField runat="server" ID="hdfSchId" Value="" />
                            <div class=" head-div-2 p-2 mb-0 text-left ">
                                <p class="m-0 ">Article Selected</p>
                            </div>
                            <div class="container" runat="server" id="divDisplayArticle">
                                <div class="row mb-3 mt-2">
                                    <div class="col">
                                        <label class="m-0 h2" runat="server" id="lblTitle"></label>
                                    </div>
                                </div>
                                <div class="row mb-1 position-static">
                                    <div class="col position-static">
                                        <label class="m-0" runat="server" id="lblContent"></label>
                                    </div>
                                </div>
                                <div class="row mb-1 position-static text-right">
                                    <div class="col position-static">
                                        <label class="m-0 font-italic mt-2" runat="server" id="lblDate"></label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        </div>
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
    <script src="../Default/DatesEnglishHijri.js"></script>
    <script src="../Default/Default.js"></script>
    <script src="../Default/DefaultJq.js"></script>
</body>
</html>
