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
    <link href="MyMember/css/MyMember.css" rel="stylesheet" />

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

        <div class="content position-relative " id="content">
            <!--Side menu-->
            <div class="row bg-light m-0 divContainers p-1 flex-nowrap position-relative">
                <div class="side-bar p-0 basic-div-styling mr-1 position-relative">
                    <!--contains the buttons-->
                    <div class="head-div text-center p-2">
                        <p class="text-uppercase m-0 font-weight-bold">Tasks :</p>
                    </div>
                        <nav class="nav flex-column pt-2 pb-2 pr-0">
                        <asp:Button runat="server" ID="btnTodaysPrayerTimes" OnClick="btnTodaysPrayerTime_Click" CssClass="pl-2 ml-1 btn taskBtn mb-1" Text="View todays prayer times" />
                        <asp:Button runat="server" ID="btnEvents" CssClass="pl-2 ml-1 btn taskBtn mb-1"  OnClick="btnEvents_Click" Text="View mosque events" />
                        <asp:Button runat="server" ID="btnNotifications" CssClass="pl-2 ml-1 btn taskBtn mb-1"  OnClick="btnNotifications_Click" Text="View notifications" />
                        <asp:Button runat="server" ID="btnArticles" CssClass="pl-2 ml-1 btn taskBtn mb-1"  OnClick="btnArticles_Click" Text="View latest articles" />
                    </nav>
                </div>
                <!--Side menu ends-->
                <!--Salaah Timetable-->
                <div class=" position-static basic-div-styling p-0  w-100 ">
                    <div runat="server" id="lblTaskHead" class=" head-div text-center p-2 mb-1">
                        <h4 class="p-0 m-0"></h4>
                    </div>
                    <div class="row p-0 m-0 tab-content right-bottom-div p-1 flex-nowrap">
                        <div runat="server" id="divDisplaySalahTimetable" class="bg-light position-static col p-3 divContainers">
                            <div style="display: flex;justify-content: center" class=" position-static basic-div-styling w-50">
                             <table class="table" style="justify-content: center; width: 50%; height: 20%; align-self: center">
                                <tr>
                                    <td rowspan="2"; colspan="1"><asp:Image ID="icoPrayer" ImageUrl="Mosque/download.png" runat="server" Height="110px" Width="110px" /> </td>
               
                                    <th colspan="2" class="text-uppercase m-0 font-weight-bold">Salah TimeTable</th>
                                </tr>
                                <tr>
                                    <th>AZAAN</th>
                                    <th>JAMAAT</th>
                                </tr>

                                <tr>
                                    <th colspan="1">Fajr</th>
                                    <td>
                                        <asp:Label ID="lblFajrAzaan" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblFajrJamaat" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <th colspan="1">Dhuhr</th>
                                    <td>
                                        <asp:Label ID="lblDhuhrAzaan" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblDhuhrJamaat" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <th colspan="1">Asr</th>
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
                  

                        <!--view mosque events-->

                        <div runat="server" id="divDisplayEvents" class="position-static row m-0 p-0">
                            <div class=" col position-static p-0">                         
                            <div class=" head-div-2 p-2 mb-0 ">
                                    <p class="m-0">List events by date range</p>
                            </div>
                                                <asp:Label ID="lblEventList" runat="server" Text="Please select a start and end date below " Font-Size="Medium" CssClass="pl-2 mb-3"></asp:Label>                               
                                                <asp:Label ID="lblStartDate" runat="server" Text="Start Date:" CssClass="pl-2 mb-1"></asp:Label>
                                                <asp:TextBox ID="txtStartDate" runat="server" TextMode="Date" CssClass="pl-2 mb-1"></asp:TextBox>
                                                <asp:Label ID="lblEndDate" runat="server" Text="End Date:" CssClass="pl-2 mb-1"></asp:Label>
                                                <asp:TextBox ID="txtEndDate" runat="server" TextMode="Date" CssClass="pl-2 mb-1"></asp:TextBox>
                                                <asp:Button CssClass="btn center btn-outline-light topnav" ID="btnListEvents" runat="server" Text="List Events" OnClick="btnListEvents_Click" />
<%--                                            <asp:CompareValidator ID="cmpVal1" ControlToCompare="txtStartDate" ControlToValidate="txtEndDate" Type="Date" Operator="GreaterThanEqual" ErrorMessage="*The end date has to be greater than the start date" runat="server"></asp:CompareValidator>--%>
                                    
                                <asp:Label ID="lblDateError" runat="server" Text="Please ensure a date is selected and the start date is before the end date"></asp:Label>
                            </div>
                        </div>

                        <div class="row" runat="server" id="divListEventDetails">
                        <div runat="server" id="divListEvent" class="position-static col m-0 p-0">
                            <div class=" head-div-2 p-2 mb-0 ">
                                    <p class="m-0">List of events:</p>
                            </div>
                            <div class="position-static p-1 lst-container" style="overflow-y:scroll;">
                                <asp:Repeater ID="RptEventList" runat="server" OnItemCommand="RptEventList_ItemCommand">
                                    <HeaderTemplate>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnEventList" CommandArgument='<%#Eval("EventID")%>' CssClass=" position-static list-group-item list-group-item-action  p-1 m-0" runat="server" OnClick="btnEventList_Click">
                                        <div class="p-0 form-row m-0 position-static">                       
                                                        <div class=" mr-4 m-0 p-0">
                                                                <p style="font-size:small" class="p-0 m-0 text-truncate"><b>Event&nbsp;Title: </b><%#Eval("EventTitle")%></p>                                       
                                                        </div>
                                                       <div class=" mr-4 m-0 p-0">
                                                                <p style="font-size:small" class="p-0 m-0 text-truncate"><b>Event&nbsp;Date: </b><%# Convert.ToDateTime(Eval("EventDate")).ToString("dd MM yyyy")%></p>
                                                        </div>
                                              </div>
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                   <FooterTemplate>
                                  </FooterTemplate>
                                </asp:Repeater>
                            </div>
                        </div>

                          <div runat="server" id="divEvent" class=" position-static col dash-content p-0 m-0">
                            <asp:HiddenField runat="server" ID="hdfEvent" Value="" />
                            <div class=" head-div-2 p-2 mb-0 ">
                                    <p class="m-0">Selected Event Details:</p>
                            </div>
                            <div class="position-static p-1 lst-container" style="overflow-y:scroll;">
                                <div class="mt-0 p-2">
                                     <div class="row position-static">
                                        <div class="col position-static"><b>Event Description: </b></div>
                                        <div class="col position-static">
                                            <label runat="server" id="lblEventDescription"></label>
                                        </div>
                                    </div>
                                    <div class="row position-static">
                                        <div class="col position-static"><b>Speaker: </b></div>
                                        <div class="col position-static">
                                            <label runat="server" id="lblSpeaker"></label>
                                        </div>
                                    </div>
                                    <div class="row position-static">
                                        <div class="col position-static"><b>Event Date: </b></div>
                                        <div class="col position-static">
                                            <label runat="server" id="lblEventDate"></label>
                                        </div>
                                    </div>
                                    <div class="row position-static">
                                        <div class="col position-static"><b>Start Time: </b></div>
                                        <div class="col position-static">
                                            <label runat="server" id="lblEventStarTime"></label>
                                        </div>
                                    </div>
                                    <div class="row position-static">
                                        <div class="col position-static"><b>End Time: </b></div>
                                        <div class="col position-static">
                                            <label runat="server" id="lblEventEndTime"></label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                            </div>
                        <!--Notifications-->
                        <div runat="server" id="divDiplayNotifications" class="position-static dash-content p-0">
                            <div class=" head-div-2 p-2 mb-0 ">
                                    <p class="m-0">Notices</p>
                            </div>
                            <div class="position-static p-1 lst-container" style="overflow-y:scroll;">
                                <asp:Repeater ID="rptNotifications" runat="server">
                                    <HeaderTemplate>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnShowNotice" CommandArgument='<%#Eval("NoticeID")%>' CssClass=" position-static list-group-item list-group-item-action  p-1 m-0" runat="server" OnClick="btnShowNotice_Click">
                                        <div class="p-0 form-row m-0 position-static">
                                                        <div class=" col-auto position-static p-0">
                                                            <div class="">
                                                                <p style="font-size:small" class="p-0 m-0 text-truncate"><b>Notice&nbsp;Title: </b><%#Eval("NoticeTitle")%><br/></p>
                                                            </div>
                                                            <hr class=" mr-4 m-0 p-0"/>
                                                            <div class="">
                                                                 <p style="font-size:small" class="p-0 m-0 text-truncate"><b>Notice&nbsp;Date: </b><%#Convert.ToDateTime(Eval("NoticeDate")).ToString("dd MM yyyy")%><br/></p>
                                                            </div>

                                                        </div>
                                         </div>
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>


                        <div runat="server" id="divNotices" class=" position-static dash-content p-0">
                            <asp:HiddenField runat="server" ID="hdnNotice" Value="" />
                            <div class=" head-div-2 p-2 mb-0 ">
                                    <p class="m-0">Notification Details:</p>
                            </div>
                            <div class="position-static p-1 lst-container" style="overflow-y:scroll;">
                                <div class="mt-0 p-2">
                                    <div class="row position-static">
                                        <div class="col position-static"><b>Notice Title: </b></div>
                                        <div class="col position-static">
                                            <label runat="server" id="lblNoticeTitle"></label>
                                        </div>
                                    </div>
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

                        <div runat="server" id="divDisplayArticles" class=" text-nowrap position-static dash-content p-0">
                            <div class=" head-div-2 p-2 mb-0 ">
                                    <p class="m-0">Latest Articles</p>
                                </div>
                            <div class="position-static p-1 lst-container" style="overflow-y:scroll;">
                                <asp:Repeater ID="rptDisplayArticles" runat="server">
                                    <HeaderTemplate>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnShowArt" EnableViewState="true" CommandArgument='<%#Eval("ArticleID")%>' CssClass=" position-static list-group-item list-group-item-action  p-1 m-0" runat="server" OnClick="btnShowArt_Click">
                                        <div class="p-0 form-row m-0 position-static">
                                                        <div class=" col-auto position-static p-0">
                                                            <div class="">
                                                                <p style="font-size:small" class="p-0 m-0 text-truncate"><b>Article&nbsp;Title: </b><%#Eval("ArticleTitle")%><br/></p>
                                                            </div>
                                                                <hr class=" mr-4 m-0 p-0"/>
                                                            <div class="">
                                                                <p  style="font-size:smaller;" class="p-0 m-0 text-truncate"><b>Author: </b><%#Eval("Names")%></p>
                                                            </div>
                                                            <hr class=" mr-4 m-0 p-0"/>
                                                            <div class="">
                                                                <p  style="font-size:smaller;" class="p-0 m-0 text-truncate"><b>Date Created: </b><%#Convert.ToDateTime(Eval("DateCreated")).ToString("dd MM yyyy")%></p>
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

                           <div class="container text-nowrap dash-content" runat="server" id="divSchDetailsOverlay">
                                <div class="w-100 h-100 container text-center">
                                    <div class=" container h-25 mb-3"></div>
                                    <h6 class="card-title h-50 mt-5 pt-5"><img class="figure-img mr-2" src="MyAdmin/icons/outline_error_outline_black_18dp.png" />No selection was made </h6>
                                    <div class=" container h-25"></div>
                                </div>
                            </div>

                    
                        <div runat="server" id="divDisplayArt" class=" position-static dash-content mw-100 align-self-center">
                            
                            <asp:HiddenField runat="server" ID="hdfArticleID" Value="" />
                            <div class=" head-div-2 p-2 mb-0 ">
                                    <p class="m-0">Selected Article Details</p>
                                </div>
                            <div class="position-static p-1 lst-container" style="overflow-y:scroll;">
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
