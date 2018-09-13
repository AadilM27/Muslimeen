<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Scholar.aspx.cs" Inherits="Muslimeen.Content.Scholar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
	<meta http-equiv="X-UA-Compatible" content="IE=edge"/>
	<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=yes"/>
    <title>MyMuslimeen - Scholar</title>
    <link rel="icon" href="../Login/LogIn_Bootstrap/muslimeen.ico"/>
    <link href="../Login/LogIn_Bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="Scholar/css/Scholar.css" rel="stylesheet" />
</head>
<body>
    <asp:HyperLink ID="lnk1" runat="server" href="HelpPage.aspx"></asp:HyperLink>
    <form id="frmScholar" runat="server">
        <header >
                <nav class="navFixed">
                    <div class="row align-self-end">
                        <ul class=" col-7 navbar-nav flex-row justify-content-start">
                            <asp:HiddenField runat="server" ID="hdfAdjustDate" Value="" /> <!--Need to get value from DB let admin adjust this -->
                            <li class="nav-item ml-4 mr-0 mb-0 pt-2 text-truncate"> <p class="IslamicDate mb-0 text-truncate position-static" id="lstIslamicDate"></p></li>
                            <script src="Default/DatesEnglishHijri.js" type="text/javascript"></script>
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
                            <asp:HyperLink ID="hplUserProfile" ToolTip="Edit user profile" runat="server" NavigateUrl="ProfileEditer.aspx" CssClass="nav-item mb-0 mr-1 ml-1 user">
                            </asp:HyperLink><asp:Image style="height:15px; width:15px;" runat="server" id="imgEditProfile" CssClass="mt-1 mr-3" ImageUrl="Default/icons/EditProfile.png"/>
                        </div>
                    </div>
                </nav>
                <div id="navbar" class="navbar navbar-expand flex-column navv flex-md-row" style="box-shadow: 0 0 0 0.1rem rgba(0, 123, 255, 0.50); z-index:1000">
                    <div class=" text-center">
                        <asp:Image runat="server" CssClass="mb-0 ml-0" src="../Login/LogIn_Bootstrap/logo.png" width="185" height="110"/>
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
                         Help    <asp:Image runat="server" ID="ImgHelp" ImageUrl="MyMember/icons/helpIcon.png" style="height: 1.1em; width:1.1em;" /></asp:LinkButton>   
                        </li>
                        </ul>
                    </div>
                </div>
            </header>

        <div class="content position-relative" id="content">
            <!--add content here -->
            <div class="row bg-light m-0 divContainers p-1 flex-nowrap position-relative">
                <div class="side-bar p-0 basic-div-styling mr-1 position-relative">
                    <!--contains the buttons-->
                    <div class="head-div text-center p-2">
                        <p class="p-0 m-0">Search:</p>
                    </div>
                    <nav class="nav flex-column pt-2 pb-2 pr-0">
                        <!--ADD LEFT NAVBAR ITEMS-->
                        <div class="form-group mb-1 ml-2 mr-2">
                            <strong><asp:Label ID="Label1" runat="server" Text="Mosque: "></asp:Label></strong>
                            <asp:DropDownList ID="drpMosque" runat="server" CssClass="form-control main-txtb" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" AutoPostBack="true" OnSelectedIndexChanged="drpMosque_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </nav>
                </div>
                <div class=" position-static basic-div-styling p-0 w-100 position-relative">
                    <div class=" head-div text-center p-2 mb-1">
                        <h4 runat="server" id="lblTaskHead" class="p-0 m-0">List Of Scholars</h4>
                    </div>
                    <div class="row p-0 m-0 right-bottom-div p-1 flex-nowrap justify-content-xl-start">
                        <%-- Pending Scholar registration List--%>
                        <div class="col-6 col-xl-6 p-0 mr-1" runat="server" id="divViewPendingSch">
                            <div class=" head-div-2 p-2 mb-1 text-left">
                                <p class="m-0">Scholars</p>
                            </div>
                            <div class=" p-1 lst-container" style="overflow-y: scroll;">
                                <asp:Repeater ID="rptViewPendingSch" runat="server">
                                    <HeaderTemplate>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnShow" CommandArgument='<%#Eval("MemberID") %>' CssClass="position-static lstBtn btn btn-block" runat="server" OnClick="btnShow_Click">
                                                    <div class="p-0 form-row m-0 position-static p-1">
                                                        <div class=" col-auto position-static p-0">
                                                            <div class="">
                                                                <p style="font-size:small" class="p-0 m-0 text-truncate"><b>Scholar&nbsp;Name: </b><%#Eval("MemberName")%>&nbsp;<%#Eval("MemberLastName")%><br/></p>
                                                            </div>
                                                                <hr class=" mr-4 m-0 p-0"/>
                                                            <div class="">
                                                                <p  style="font-size:smaller;" class="p-0 m-0 text-truncate"><b>Date Registered: </b><%#Convert.ToDateTime(Eval("ActivationDate")).ToString("dd MM yyyy")%></p>
                                                            </div>
                                                        </div>
                                                    </div>
                                        </asp:LinkButton>
                                        <hr class="p-0 m-1" />
                                    </ItemTemplate>
                                    <FooterTemplate>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </div>
                        </div>

                        <%-- Overlay for Scholar Registration List selection--%>
                        <div class="col-8 col-sm-6 col-xl-4 text-nowrap" runat="server" id="divSchDetailsOverlay">
                            <div class="w-100 h-100 container text-center">
                                <div class=" container h-25 mb-3"></div>
                                <h6 class="card-title h-50 mt-5 pt-5">
                                    <img class="figure-img mr-2" src="MyAdmin/icons/outline_error_outline_black_18dp.png" />No Scholar Selected.</h6>
                                <div class=" container h-25"></div>
                            </div>
                        </div>
                        <%-- Diaplay Pending Scholar Details --%>
                        <div runat="server" id="divDisplaySch" class=" col-6 col-xl-6 col-md-6 flex-nowrap p-0">
                            <asp:HiddenField runat="server" ID="hdfSchId" Value="" />
                            <div class=" head-div-2 p-2 mb-0 text-left ">
                                <p class="m-0">Scholar Details</p>
                            </div>
                            <hr class="m-3 ml-3 mr-3 bg-secondary" />
                            <div class="container text-nowrap" runat="server" id="divSchDetails">
                                <div class="row mb-1 position-static">
                                    <div class="col position-static"><b>User Name:</b></div>
                                    <div class="col position-static text-truncate">
                                        <label class="m-0" runat="server" id="lblMemberID"></label>
                                    </div>
                                </div>
                                <div class="row mb-1 position-static">
                                    <div class="col position-static"><b>First Name:</b></div>
                                    <div class="col position-static text-truncate">
                                        <label class="m-0" runat="server" id="lblMemberName"></label>
                                    </div>
                                </div>
                                <div class="row mb-1 position-static">
                                    <div class="col position-static"><b>Last Name:</b></div>
                                    <div class="col position-static text-truncate">
                                        <label class="m-0" runat="server" id="lblMemberLastName"></label>
                                    </div>
                                </div>
                                <div class="row mb-1 position-static">
                                    <div class="col position-static"><b>Date of Birth:</b></div>
                                    <div class="col position-static text-truncate">
                                        <label class="m-0" runat="server" id="lblMemberDOB"></label>
                                    </div>
                                </div>
                                <div class="row mb-1 position-static">
                                    <div class="col position-static"><b>E-mail:</b></div>
                                    <div class="col position-static">
                                        <label class="m-0" runat="server" id="lblEmail"></label>
                                    </div>
                                </div>
                                <div class="row mb-1 position-static">
                                    <div class="col position-static"><b>Contact No.</b></div>
                                    <div class="col position-static text-truncate">
                                        <label class="m-0" runat="server" id="lblContactNo"></label>
                                    </div>
                                </div>
                                <div class="row mb-1 position-static">
                                    <div class="col position-static "><b>Qualification:</b></div>
                                    <div class="col position-static text-truncate">
                                        <label class="m-0" runat="server" id="lblScholarQual"></label>
                                    </div>
                                </div>
                            </div>
                            <hr class="m-3 ml-3 mr-3 bg-secondary" />                            
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </form>
    <div class="footerr">
        <!--End of content, start of footer-->
        <div class="row bg-light">
            <div class="col text-center position-static">
                <h6>Content</h6>
                <ul class="navbar-nav">
                    <li class="nav-item">
                        <a class="footerr-text" href="Mosque.aspx">Mosques</a>
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
                        <a class="footerr-text" href="https://www.youtube.com/user/UCp87ZLRrUz3SbzPPP2uaIEg">YouTube</a>
                    </li>
                </ul>
            </div>
        </div>
    </div>
    <script src="Default/Default.js" type="text/javascript"></script>
    <script src="MyAdmin/js/MyAdmin.js"></script>
    <script src="Default/DefaultJq.js"></script>
</body>
</html>
