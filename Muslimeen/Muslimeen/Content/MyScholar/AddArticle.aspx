<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddArticle.aspx.cs" Inherits="Muslimeen.Content.MyScholar.AddArticle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="utf-8"/>
	<meta http-equiv="X-UA-Compatible" content="IE=edge"/>
	<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>

    <title>Add Article</title>

    <link href="../../Login/LogIn_Bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/MyScholar.css" rel="stylesheet" />
    </head>
<body>
    <asp:HyperLink ID="lnk1" runat="server" href="HelpPage.aspx"></asp:HyperLink>

    <form id="frmAddArticle" runat="server">
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

        <div class="content" id="content">
            <!--add content here -->
            <div class="row bg-light m-0 divContainers p-1 flex-nowrap">
                <div class="side-bar p-0 basic-div-styling mr-1">
                    <!--contains the buttons-->
                    <div class="head-div text-center p-2">
                        <p class="text-uppercase m-0 font-weight-bold">Scholar Tasks:</p>
                    </div>
                    <nav class="nav flex-column pt-2 pb-2 pr-0">
                        <asp:Button runat="server" ID="btnAddArticle" OnClick="btnAddArticle_Click" CssClass="pl-2 btn mb-1 taskBtn" Text="Add Article" />
                        <asp:Button runat="server" ID="btnPendingArticles" OnClick="btnPendingArticles_Click" CssClass="pl-2 btn mb-1 taskBtn" Text="View Pending Articles" />
                        <asp:Button runat="server" ID="btnRejectedArticles" CssClass=" pl-2 btn taskBtn mb-1" OnClick="btnRejectedArticles_Click" Text="View Rejected Articles" />
                    </nav>
                </div>
                <div class=" position-static basic-div-styling p-0  w-100">
                    <div class=" head-div text-center p-2 mb-1">
                        <h4 runat="server" id="lblTaskHead" class="p-0 m-0"></h4>
                    </div>
                    <div class="row p-0 m-0 right-bottom-div p-1 flex-nowrap">
                        <%--Add Article--%>
                        <div class="col-6 position-static p-0 dash-content" runat="server" id="divAddArticle">
                            <div class=" position-static p-1 lst-container">
                                <div class="form-row">
                                    <div class="form-group col-sm-6 mb-1 ml-2 position-static">
                                        <label class="col mb-0 p-0 position-static"><strong>Topic:</strong></label>
                                        <asp:DropDownList ID="drpTopics" runat="server" CssClass="form-control main-txtb" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" AutoPostBack="false"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="form-group col-sm-10 mb-1 ml-2 position-static">
                                        <label class="col mb-0 p-0 position-static"><strong>Heading:</strong></label>
                                        <asp:TextBox CssClass="form-control" ID="txtHeading" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="form-group col-sm-12 mb-1 ml-2 position-static">
                                        <label class="col mb-0 p-0 position-static"><strong>Content:</strong></label>
                                        <asp:TextBox CssClass="form-control" ID="txtContent" runat="server" Height="300px" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>
                                <br />
                                <div class="form-row">
                                    <div class="form-group col-sm-12 w-100 mb-1 text-right position-static">
                                        <asp:Button CssClass="btn btn-primary btn-lg position-static" ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>

                        <%--Pending Articles--%>
                        <div class="col-6 position-static p-0 dash-content" runat="server" id="divPendingArticles">
                            <div class=" head-div-2 p-2 mb-1 text-left">
                                <p class="m-0">Pending Articles</p>
                            </div>
                            <div class=" position-static p-1 lst-container" style="overflow-y: scroll;">
                                <asp:Repeater ID="repeatLink" runat="server">
                                    <HeaderTemplate>
                                    </HeaderTemplate>
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

                        <%-- Overlay for Pending Article Selection--%>
                        <div class="container text-nowrap" runat="server" id="divPenDetailsOverlay">
                            <div class="w-100 h-100 container text-center">
                                <div class=" container h-25 mb-3"></div>
                                <h6 class="card-title h-50 mt-5 pt-5">
                                    <img class="figure-img mr-2" src="../MyAdmin/icons/outline_error_outline_black_18dp.png" />No Pending Article selected.</h6>
                                <div class=" container h-25"></div>
                            </div>
                        </div>

                        <%--Display of Pending Articles--%>
                        <div runat="server" id="divNoSelected" class="position-static dash-content p-0">
                            <asp:HiddenField runat="server" ID="hdfSchId" Value="" />
                            <div class=" head-div-2 p-2 mb-0 text-left ">
                                <p class="m-0">Article Selected</p>
                            </div>
                            <div class="container text-nowrap" runat="server" id="divDisplayArticle">
                                <div class="row mb-1 position-static">
                                    <div class="col-2 position-static"><b>Title:</b></div>
                                    <div class="col position-static">
                                        <label class="m-0" runat="server" id="lblTitle"></label>
                                    </div>
                                </div>
                                <div class="row mb-1 position-static">
                                    <div class="col-2 position-static"><b>Content:</b></div>
                                    <div class="col position-static">
                                        <label class="m-0" runat="server" id="lblContent"></label>
                                    </div>
                                </div>
                                <div class="row mb-1 position-static">
                                    <div class="col-2 position-static"><b>Date:</b></div>
                                    <div class="col position-static text-truncate">
                                        <label class="m-0" runat="server" id="lblDate"></label>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <%--Rejected Articles--%>
                        <div class="col-6 position-static p-0 dash-content" runat="server" id="divRejectedArticles">
                            <div class=" head-div-2 p-2 mb-1 text-left">
                                <p class="m-0">Rejected Articles</p>
                            </div>
                            <div class=" position-static p-1 lst-container" style="overflow-y: scroll;">
                                <asp:Repeater ID="repeatLinkRejected" runat="server">
                                    <HeaderTemplate>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnShow" CommandArgument='<%#Eval("ArticleID") %>' CssClass="position-static lstBtn btn btn-block" runat="server" OnClick="btnShowRejected_Click1">
                                                    <div class="p-0 form-row m-0 position-static">
                                                        <div class=" col-auto position-static p-0">
                                                            <div class="">
                                                                <p style="font-size:small" class="p-0 m-0 text-truncate"><b>Article&nbsp;Title: </b><%#Eval("ArticleTitle")%><br/></p>
                                                            </div>
                                                                <hr class=" mr-4 m-0 p-0"/>
                                                            <div class="">
                                                                <p  style="font-size:smaller;" class="p-0 m-0 text-truncate"><b>Date Created: </b><%#Eval("DateCreated")%></p>
                                                            </div>
                                                        </div>
                                                    </div>
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </div>
                        </div>

                        <%-- Overlay for Rejected Article Selection--%>
                        <div class="container text-nowrap" runat="server" id="divDisplayRejectedOverlay">
                            <div class="w-100 h-100 container text-center">
                                <div class=" container h-25 mb-3"></div>
                                <h6 class="card-title h-50 mt-5 pt-5">
                                    <img class="figure-img mr-2" src="../MyAdmin/icons/outline_error_outline_black_18dp.png" />No Rejected Article selected.</h6>
                                <div class=" container h-25"></div>
                            </div>
                        </div>

                        <%--Display of Rejected Articles--%>
                        <div runat="server" id="divNoRejectedSelected" class="position-static dash-content p-0">
                            <asp:HiddenField runat="server" ID="hfdRej" Value="" />
                            <div class=" head-div-2 p-2 mb-0 text-left ">
                                <p class="m-0">Article Selected</p>
                            </div>
                            <div class="container text-nowrap" runat="server" id="divDisplayRejected">
                                <div class="row mb-1 position-static">
                                    <div class="col-2 position-static"><b>Title:</b></div>
                                    <div class="col position-static text-truncate">
                                        <label class="m-0" runat="server" id="Label1"></label>
                                    </div>
                                </div>
                                <div class="row mb-1 position-static">
                                    <div class="col-2 position-static"><b>Content:</b></div>
                                    <div class="col position-static">
                                        <label class="m-0 flex-wrap" runat="server" id="Label2"></label>
                                    </div>
                                </div>
                                <div class="row mb-1 position-static">
                                    <div class="col-2 position-static"><b>Date:</b></div>
                                    <div class="col position-static text-truncate">
                                        <label class="m-0" runat="server" id="Label3"></label>
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

    <script src="../Default/Default.js" type="text/javascript"></script>
    <script src="../Default/DatesEnglishHijri.js" type="text/javascript"></script>
    <script src="../Default/DefaultJq.js"></script>
</body>
</html>
