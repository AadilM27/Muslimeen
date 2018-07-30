<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyMember.aspx.cs" Inherits="Muslimeen.Content.MyMuslimeen_User_" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">


<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />

    <title>My Muslimeen</title>
    <link rel="icon" href="/Login/LogIn_Bootstrap/muslimeen.ico" />
    <link href="../Login/LogIn_Bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="MyMember/css/MyMember.css" rel="stylesheet" />
    <link href="AboutUs/AboutUs.css" rel="stylesheet" />
    <link href="MyAdmin/css/MyAdmin.css" rel="stylesheet" />

</head>
<body>
    <asp:HyperLink ID="lnk1" runat="server" href="HelpPage.aspx"></asp:HyperLink>
    <form id="frmScholar" runat="server" class=" ">
        <header>
            <nav class="navFixed">
                <div class="row align-self-end">
                    <ul class=" col-7 navbar-nav flex-row justify-content-start">
                        <asp:HiddenField runat="server" ID="hfAdjustDate" Value="-2" />
                        <!--Need to get value from DB let admin adjust this -->
                        <li class="nav-item ml-4 mr-0 mb-0 pt-2">
                            <p class="IslamicDate mb-0" id="lstIslamicDate"></p>
                        </li>
                        <script src="Default/DatesEnglishHijri.js" type="text/javascript"></script>
                    </ul>
                    <ul class="col-5 navbar-nav flex-row justify-content-end">
                        <li class="nav-item ml-0 mr-0">
                            <asp:TextBox ID="txtSearch" TextMode="Search" runat="server" class=" search-box form-control form-control-sm" autocomplete="off" placeholder="Search"></asp:TextBox>
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
                    <!---->
                </div>
                <div class="row" runat="server" id="divUserProfile">
                    <div class="col navbar-nav flex-row ml-4 mb-0 mt-0 pt-2 justify-content-end">
                        <asp:HyperLink ID="hplUserProfile" ToolTip="Edit user profile" runat="server" NavigateUrl="~/Content/ProfileEditer.aspx" CssClass="nav-item mb-0 mr-1 ml-1 user">
                        </asp:HyperLink><asp:Image Style="height: 15px; width: 15px;" runat="server" ID="imgEditProfile" CssClass="mt-1 mr-3" ImageUrl="~/Content/Default/icons/EditProfile.png" />
                    </div>
                </div>
            </nav>
            <div id="navbar" class="navbar navbar-expand flex-column navv flex-md-row" style="box-shadow: 0 0 0 0.1rem rgba(0, 123, 255, 0.50);">
                <div class=" text-center">
                    <asp:Image runat="server" CssClass="mb-0 ml-0" src="/Login/LogIn_Bootstrap\logo.png" Width="185" Height="110" />
                </div>
                <div class="ml-2 navbar-nav-scroll align-self-end justify-content-start">
                    <ul class="navbar-nav row">
                        <li class="nav-item navbarText navbaritems">
                            <asp:Button runat="server" ID="btnHome" Text="Home" CssClass=" btn btn-link nav-item navText" OnClick="btnHome_Click" />
                        </li>
                        <li class="NavDevider">|</li>
                        <!--deviders-->
                        <li class="nav-item navbarText navbaritems" runat="server" id="liMyMusbtn">
                            <asp:Button runat="server" ID="btnMyMuslimeen" Text="MyMuslimeen" CssClass=" btn btn-link nav-item navText" OnClick="btnMyMuslimeen_Click" />
                        </li>
                        <li runat="server" id="liMyMusDivi" class=" NavDevider">|</li>
                        <!--deviders-->
                        <li class="nav-item navbarText navbaritems">
                            <asp:Button runat="server" ID="btnMosques" Text="Mosques" CssClass="nav-item navText btn-link btn" OnClick="btnMosques_Click" />
                        </li>
                        <li class="NavDevider">|</li>
                        <!--deviders-->
                        <li class="nav-item navbarText navbaritems">
                            <asp:Button runat="server" ID="btnScholars" Text="Scholars" CssClass="nav-item navText btn-link btn" OnClick="btnScholars_Click" />
                        </li>
                        <li class="NavDevider">|</li>
                        <!--deviders-->
                        <li class="nav-item navbarText navbaritems">
                            <asp:Button runat="server" ID="btnLearnIslam" Text="Learn Islam" CssClass="nav-item navText btn-link btn" OnClick="btnLearnIslam_Click" />
                        </li>
                        <li class="NavDevider">|</li>
                        <!--deviders-->
                        <li class="nav-item navbarText navbaritems">
                            <asp:Button runat="server" ID="btnZakaah" Text="Zakaah" CssClass="nav-item navText btn-link btn" OnClick="btnZakaah_Click" />
                        </li>
                        <li class="NavDevider">|</li>
                        <!--deviders-->
                        <li class="nav-item navbarText navbaritems">
                            <asp:Button runat="server" ID="btnAboutUs" Text="About us" CssClass="nav-item navText btn-link btn" OnClick="btnAboutUs_Click" />
                        </li>
                    </ul>
                </div>
            </div>
        </header>

        <div class="content" id="content">
            <!--Side menu-->
            <div class="row m-0 divContainers p-2">
                <div class=" position-static mr-2 p-0 basic-div-styling" style="min-width: 250px;">
                    <!--contains the buttons-->
                    <div class="head-div text-center p-2">
                        <p class="text-uppercase m-0 font-weight-bold">Tasks :</p>
                    </div>
                    <nav class="nav flex-column pt-2 pb-2 pr-0">
                        <asp:Button runat="server" ID="btnTodaysPrayerTimes" OnClick="btnTodaysPrayerTime_Click" CssClass=" mb-2 btn taskBtn" Text="View todays prayer times" />
                        <asp:Button runat="server" ID="btnEvents" CssClass=" mb-2 btn taskBtn" OnClick="btnEvents_Click" Text="View mosque events" />
                        <asp:Button runat="server" ID="btnNotifications" CssClass=" mb-2 btn taskBtn" OnClick="btnNotifications_Click" Text="View notifications" />
                        <asp:Button runat="server" ID="btnArticles" CssClass=" mb-2 btn taskBtn" OnClick="btnArticles_Click" Text="View latest articles" />
                    </nav>
                </div>

                <!--Side menu ends-->




                <!--Salaah Timetable-->

                <div runat="server" id="divDisplaySalahTimetable" class="bg-light position-static col-6 p-3 divContainers">

                    <div class="contentHolder mt-4">
                        <div class="header mb-3">
                            <h4 class="text-center">Today's Prayer Times 
                               <br />
                            </h4>

                        </div>
                        <div style="display: flex; justify-content: center" class="container">
                            <table class="table " style="justify-content: center; width: 70%; height: 20%; align-self: center">

                                <tr>
                                    <td rowspan="2"></td>
                                    <asp:Image ID="icoPrayer" ImageUrl="Mosque/download.png" runat="server" Height="121px" Width="121px" />
                                    <th colspan="2">Salah TimeTable</th>
                                </tr>
                                <tr>
                                    <th>AZAAN</th>
                                    <th>JAMAAT</th>
                                </tr>

                                <tr>
                                    <th>Fajr</th>
                                    <td>
                                        <asp:Label ID="lblFajrAzaan" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblFajrJamaat" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <th>Dhuhr</th>
                                    <td>
                                        <asp:Label ID="lblDhuhrAzaan" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblDhuhrJamaat" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <th>Asr</th>
                                    <td>
                                        <asp:Label ID="lblAsrAzaan" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblAsrJamaat" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <th>Magrib</th>
                                    <td>
                                        <asp:Label ID="lblMagribAzaan" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblMagribJamaat" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <th>Eisha</th>
                                    <td>
                                        <asp:Label ID="lblEishaAzaan" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblEishaJamaat" runat="server"></asp:Label></td>
                                </tr>

                            </table>

                        </div>
                    </div>
                </div>


                <!--view mosque events-->


                <div runat="server" id="divDisplayEvents" class="bg-light position-static col p-3 divContainers">


                    <div class="contentHolder mt-6">
                        <div class="header mb-3">
                            <h4 class="text-center">View Mosque Events:
                               <br />
                            </h4>
                        </div>

                        <div class="paragraphDisplay p-2">
                            <table style="width: 30%">
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="lblEventList" runat="server" Text="List Events By Date Range "></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblStartDate" runat="server" Text="Start Date: "></asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="txtStartDate" runat="server" TextMode="Date"></asp:TextBox></td>
                                    <td>
                                        <asp:Label ID="lblEndDate" runat="server" Text="End Date:"></asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="txtEndDate" runat="server" TextMode="Date"></asp:TextBox></td>
                                    <td>
                                        <asp:Button CssClass="btn btn-info center" ID="btnListEvents" runat="server" Text="List Events" OnClick="btnListEvents_Click" /></td>
                                </tr>
                            </table>
                        </div>
                    </div>

                </div>

                <div runat="server" id="divEvent" class="bg-light position-static flex-nowrap p-3 divContainers">

                    <asp:Repeater ID="rptGetEvents" runat="server">

                        <ItemTemplate>
                            <div class="contentHolder mt-4">
                                <div class="header mb-3">
                                    <h4 class="text-center">
                                        <asp:Label ID="lblEventTitle" runat="server" Text='<%#Eval("EventTitle")%>'></asp:Label><h4>
                                            <br />
                                        </h4>
                                </div>
                                <div class="paragraphDisplay p-2">

                                    <div style="display: flex; justify-content: center" class="container">
                                        <div>
                                            <table class="table" style="justify-content: center; width: 70%; height: 20%; align-self: center">
                                                <tr>
                                                    <th>
                                                        <h3 style="font-size: medium">Description:
                                                        </h3>
                                                    </th>
                                                    <td>
                                                        <asp:Label ID="lblEventDescription" runat="server" Text='<%#Eval("EventDescription")%>'></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>
                                                        <h3 style="font-size: medium">Speaker:<h3>
                                                    </th>
                                                    <td>
                                                        <asp:Label ID="lblSpeaker" runat="server" Text='<%#Eval("Speaker")%>'></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>
                                                        <h3 style="font-size: medium">Event Date:
                                                    <h3>
                                                    </th>
                                                    <td>
                                                        <asp:Label ID="lblEventDate" runat="server" Text='<%#Eval("EventDate").ToString().Substring(0,10)%>'></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>
                                                        <h3 style="font-size: medium">Start Time:
                                                    <h3>
                                                    </th>
                                                    <td>
                                                        <asp:Label ID="lblEventStarTime" runat="server" Text='<%#Eval("EventStartTime")%>'></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>
                                                        <h3 style="font-size: medium">End Time:
                                                        </h3>
                                                    </th>
                                                    <td>
                                                        <asp:Label ID="lblEventEndTime" runat="server" Text='<%#Eval("EventEndTime")%>'></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            </div>

                        </ItemTemplate>

                    </asp:Repeater>

                </div>


                <!--Notifications-->
                <div runat="server" id="divDiplayNotifications" class="bg-light position-static col-4 p-3 divContainers">
                    <div class="header mb-3">
                        <p class="m-0">Notices</p>
                    </div>
                    <div class="row position-static list-group justify-content-end">
                        <asp:Repeater ID="rptNotifications" runat="server">
                            <HeaderTemplate>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnShowNotice" CommandArgument='<%#Eval("NoticeID")%>' CssClass=" position-static list-group-item list-group-item-action  p-1 m-0" runat="server" OnClick="btnShowNotice_Click">
                                        <b>Notice Date: </b><%#Eval("NoticeDate")%><br />
                                        <b style="font-size:smaller;"> Notice Description: </b><%#Eval("NoticeDescription")%> </b> <br />
                                </asp:LinkButton>
                            </ItemTemplate>
                            <FooterTemplate>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                </div>

                <div runat="server" id="divNotices" class=" col bg-light position-static col-4 p-3 divContainers">
                    <asp:HiddenField runat="server" ID="hdnNotice" Value="" />
                    <div class=" header mb-3 ">
                        <p class="m-0">Notification Details:</p>
                    </div>
                    <div class="row" style="overflow: scroll;">
                        <div class="mt-0 p-2">
                            <div class="row position-static">
                                <div class="col position-static"><b>Notice Date: </b></div>
                                <div class="col position-static">
                                    <label runat="server" id="lblNoticeDate"></label>
                                </div>
                            </div>
                            <div class="row position-static">
                                <div class="col position-static"><b>Notice Description: </b></div>
                                <div class="col position-static">
                                    <label runat="server" id="lblNoticeDescription"></label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>



                <!--articles-->

                <div runat="server" id="divDisplayArticles" class="bg-light position-static col-4 p-3 divContainers">
                    <div class="header mb-3">
                        <p class="m-0">Latest Articles</p>
                    </div>
                    <div class="row position-static list-group justify-content-end">
                        <asp:Repeater ID="rptDisplayArticles" runat="server">
                            <HeaderTemplate>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnShowArt" EnableViewState="true" CommandArgument='<%#Eval("ArticleID")%>' CssClass=" position-static list-group-item list-group-item-action  p-1 m-0" runat="server" OnClick="btnShowArt_Click">
                                        <b>Article Title: </b><%#Eval("ArticleTitle")%><br />
                                        <b style="font-size:smaller;"> By: </b><%#Eval("Names")%> </b> <br />
                                        <b style="font-size:smaller;"> Date Created: </b><%#Eval("DateCreated")%><br />
                                </asp:LinkButton>
                            </ItemTemplate>
                            <FooterTemplate>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                </div>


                <div runat="server" id="divDisplayArt" class="col bg-light position-static col-4 p-3 divContainers">
                    <asp:HiddenField runat="server" ID="hdfArticleID" Value="" />
                    <div class=" header mb-3 ">
                        <p class="m-0">Selected Article Details:</p>
                    </div>
                    <div class="row" style="overflow: scroll;">
                        <div class="mt-0 p-2">
                            <div class="row position-static">
                                <div class="col position-static"><b>Article Title: </b></div>
                                <div class="col position-static">
                                    <label runat="server" id="lblArticleTitle"></label>
                                </div>
                            </div>
                            <div class="row position-static">
                                <div class="col position-static"><b>Content: </b></div>
                                <div class="col position-static">
                                    <label runat="server" id="lblArticleContent"></label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>


            </div>

        </div>


        <!--close content-->
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
    </form>
    <script src="Default/DefaultJq.js"></script>
</body>
</html>
