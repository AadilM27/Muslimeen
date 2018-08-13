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
    <link href="../Zakaah/css/newZakaah.css" rel="stylesheet" />


</head>
<body style="background-color:white">
    <asp:HyperLink ID="lnk1" runat="server" href="HelpPage.aspx"></asp:HyperLink>
    <form id="frmLearnIslam" runat="server">
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

        <!--Page Content-->        
        <div class="content" id="content">
            <div class="container" style="margin-top: 10px; position: static;">
                <div class="row" style="position: static; right: 50px">
                    <div class="col-lg-7 flex-nowrap" style="position: static;">
                        <h1 class="title header mb-4 mt-0">Articles</h1>
                        <!--Modal pop-up code-->
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        
                        <asp:Repeater ID="repeatLink" runat="server">                                                       
                            <ItemTemplate>
                                <asp:LinkButton ID="btnShow" CommandArgument='<%#Eval("ArticleID") %>' CssClass="position-static lstBtn btn btn-block" runat="server" OnClick="btnShow_Click">
                                    <div class="p-0 form-row m-0 position-static">
                                        <div class=" col-auto position-static p-0">
                                            <div class="">
                                                <p style="font-size:small" class="p-0 m-0 text-truncate"><b>Article&nbsp;Title: </b><%#Eval("ArticleTitle")%><br/></p>
                                            </div>
                                            <hr class=" mr-4 m-0 p-0"/>
                                            <div class="">
                                                <p  style="font-size:smaller;" class="p-0 m-0 text-truncate"><b>Date Created: </b><%#Eval("DateCreated")%></p>
                                            </div>
                                            <div class="">
                                                <p  style="font-size:smaller;" class="p-0 m-0 text-truncate"><b>Scholar: </b><%#Eval("ScholarID")%></p>
                                            </div>
                                        </div>
                                    </div>
                                    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" okcontrolid="btnOkay" TargetControlId="btnShow" PopupControlID="Panel1" BackgroundCssClass="ModalPopupBG" drag="true"></ajaxToolkit:ModalPopupExtender>
                                </asp:LinkButton>
                                <hr class="p-0 m-1" />
                            </ItemTemplate>  
                        </asp:Repeater>  

                        <asp:Panel ID="Panel1" style="display: none" runat="server">
                            <asp:HiddenField runat="server" ID="hfdRej" Value="" />
                            <div class="HellowWorldPopup">
                                <div class="PopupHeader" id="PopupHeader">
                                    <label runat="server" id="lblRTitle"></label>
                                </div>
                                <div class="PopupBody">
                                    <p>
                                        <label runat="server" id="lblRContent"></label>
                                    </p>
                                    <p>
                                        <label runat="server" id="lblRDate"></label>
                                    </p>
                                    <p>
                                        <label runat="server" id="lblScholar"></label>
                                    </p>
                                </div>
                                <div class="Controls">
                                    <input id="btnOkay" type="button" value="Done" />
                                </div>
                            </div>
                        </asp:Panel>

                    </div>
                    <div class="col-lg-5" style="position: static;">
                            <h3 class="title header mb-4 mt-0">Videos</h3>
                            <iframe width="438" height="300" src="https://www.youtube.com/embed/kEon0omN5SA"></iframe>
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
