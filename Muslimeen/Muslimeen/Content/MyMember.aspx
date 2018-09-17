<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyMember.aspx.cs" Inherits="Muslimeen.Content.MyMuslimeen_User_" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">


<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />

    <title>My Muslimeen</title>
    <link rel="icon" href="../Login/LogIn_Bootstrap/muslimeen.ico" />
    <link href="../Login/LogIn_Bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="Default/css/Default.css" rel="stylesheet" />
    <link href="AboutUs/AboutUs.css" rel="stylesheet" />
    <link href="MyMember/css/MyMember.css" rel="stylesheet" />
    <link href="../Content/MyMember/css/Slideshow.css" rel="stylesheet" />

     <style type="text/css">
        .Star {
            background-image: url(../Content/MyMember/icons/Star.gif);
            height: 17px;
            width: 17px;
        }

        .WaitingStar {
            background-image: url(../Content/MyMember/icons/WaitingStar.gif);
            height: 17px;
            width: 17px;
        }

        .FilledStar {
            background-image: url(../Content/MyMember/icons/FilledStar.gif);
            height: 17px;
            width: 17px;
        }
        </style>

    

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
                            <script src="Default/DatesEnglishHijri.js"></script>
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
                            </li><li class="NavDevider">|</li><!--deviders-->
                            <li class="nav-item navbarText navbaritems">
                            <asp:LinkButton ID="LnkHelp" runat="server"  OnClick="btnHelp_Click" CssClass="nav-item navText btn-link btn" ToolTip="Get help using Muslimeen" ><%--CssClass="nav-item navText btn-link btn"--%>
                                Help<asp:Image runat="server" ID="ImgHelp" ImageUrl="MyMember/icons/helpIcon.png" style="height: 1.1em; width:1.1em;" /></asp:LinkButton>   
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
                    <div class="row p-0 m-0 tab-content right-bottom-div p-1 flex-nowrap mr-5">
                        <div runat="server" id="divDisplaySalahTimetable" class="bg-light position-static col-12 p-3 divContainers flex-nowrap m-0 row">
                            <div style="display: flex;justify-content: center" class=" col-6 position-static basic-div-styling w-50">
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

                            
                    
                    <%--m-0 col-lg-4 ml-lg-5  position:static;--%><div class="slideshow-container ml-5" style="width:300px">
                        <h2 style="background-color:#256297;color:white;text-align:center"> Salah Quotes</h2>
                    <div class="mySlides">
                      <q> And be steadfast in prayer; practise regular charity; and bow down your heads with those who bow down (in worship).</q>
                      <p class="author">- Quraan [2:43]</p>
                    </div>

                    <div class="mySlides">
                      <q>As long as you are performing prayer, you are knocking at the door of Allah, and whoever is knocking at the door of Allah, Allah will open it for him. </q>
                      <p class="author">- Ibn-Al-Qayyim</p>
                    </div>

                    <div class="mySlides">
                      <q>And establish prayer and give zakah, and whatever good you put forward for yourselves – you will find it with Allah. Indeed, Allah of what you do, is Seeing.</q>
                      <p class="author"> – al-Quran 2:110</p>
                    </div>
                         <!-- Next/prev buttons -->
                    <a class="prev" onclick="plusSlides(-1)">❮</a>
                    <a class="next" onclick="plusSlides(1)">❯</a>

                    
                        <!-- Dots/bullets/indicators -->
                    <div class="dot-container" style= "position:static; width:300px"> <%--m-0 col-lg-4 ml-lg-5--%>
                      <span class="dot" onclick="currentSlide(1)"></span> 
                      <span class="dot" onclick="currentSlide(2)"></span> 
                      <span class="dot" onclick="currentSlide(3)"></span> 
                    </div>
                        <script src="../Content/Zakaah/slideshow.js"></script>
                  
                        </div>

                             <%--<div class="col-sm-3 col-xl-4 text-nowrap" runat="server" id="divNoSalaah">
                                <div class="w-100 h-100 container text-center">
                                    <div class=" container h-25 mb-3"></div>
                                    <h6 class="card-title h-50 mt-5 pt-5">
                                        <asp:Image runat="server" class="figure-img mr-2" ImageUrl="MyMember/icons/outline_error_outline_black_18dp.png" /><asp:Label ID="lblNoSalaah" runat="server">No salaah times were entered as yet.</asp:Label></h6>
                                    <div class=" container h-25"></div>
                                </div>
                            </div>--%>

                    </div>
                         
                  

                        <!--view mosque events-->

                             <div class=" row bg-light position-static ml-1 mr-1 flex-nowrap col-12 pl-0" runat="server" id="divDisplayEvents"><%--flex-nowrap w-100--%>
                                <div class="col-3 col-xl-4 p-0 mr-1">
                                    <div class=" head-div-2 p-2 mb-0 text-left ">
                                        <p class="m-0">Select Event Date Range</p>
                                    </div>
                                    <div class="table">
                                        <div class="form-row">
                                            <div class="form-group col-sm-6 mb-1">
                                                <label class="col mb-0 p-0">Start Date: </label>
                                                <asp:TextBox TextMode="Date" CssClass="form-control form-control-sm col main-txtb" runat="server" Format="yyyy/MM/dd" ID="txtStartDate"></asp:TextBox>
                                            </div>
                                            <div class="form-group col-sm-6 mb-1">
                                                <label class="col mb-0 p-0">End Date: </label>
                                                <asp:TextBox TextMode="Date" CssClass="form-control form-control-sm col main-txtb" runat="server" Format="yyyy/MM/dd" ID="txtEndDate"></asp:TextBox>
                                            </div>
                                            <div class="form-group col-1 mb-1 mt-1">
                                                <asp:Button runat="server" ID="btnListEvents" Text="List Events" CssClass="topnav btn btn-md btn-outline-light" OnClick="btnListEvents_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-3 col-xl-4 p-0 mr-1" runat="server" id="divListEventDetails">
                                    <div runat="server" id="divListEvent" class="position-static m-0 p-0">
                                    <div class=" head-div-2 p-2 mb-1 text-left">
                                        <p class="m-0">Mosque Events</p>
                                    </div>
                                    <div class="p-1 lst-container" style="overflow-y: scroll;">
                                        <asp:Repeater ID="RptEventList" runat="server" OnItemCommand="RptEventList_ItemCommand">
                                            <HeaderTemplate>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnEventList" CommandArgument='<%#Eval("EventID") %>' CssClass="position-static lstBtn btn btn-block" runat="server" OnClick="btnEventList_Click" EnableViewState="true">
                                                <div class="p-0 form-row m-0 position-static p-1">
                                                    <div class=" col-auto position-static p-0">
                                                        <div class="">
                                                            <p style="font-size: small" class="p-0 m-0 text-truncate">
                                                                <b>Event&nbsp;Title: </b><%#Eval("EventTitle").ToString()%><br />
                                                            </p>
                                                        </div>
                                                        <hr class=" mr-4 m-0 p-0" />
                                                        <div class="">
                                                            <p style="font-size: smaller;" class="p-0 m-0 text-truncate"><b>Event Date: </b><%#Convert.ToDateTime(Eval("EventDate")).ToString("dd MM yyyy")%></p>
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
                                    </div>

                                <div runat="server" id="divEvent" class="col-3 col-xl-4 flex-nowrap p-0 mr-1">
                                    <asp:HiddenField runat="server" ID="hdfEvent" Value="" />
                                    <div class=" head-div-2 p-2 mb-0 text-left ">
                                        <label runat="server" class="mb-0">Selected event details:</label>
                                    </div>
                                    <div runat="server" id="lblEventTitle" class=" h4 font-weight-bold  ml-3 p-2" style="font-weight:500" >
                                        <h4 class="p-0 m-0" ></h4>
                                    </div>
                                    <hr class="m-1 ml-3 mr-3 bg-secondary" />
                                    <div style="overflow-y: scroll;">
                                    <div class="container" runat="server" id="divEventDetails">
                                        <div class="row mb-1 position-static">
                                            <div class="col position-static"><b>Speaker:</b></div>
                                            <div class="col position-static text-truncate">
                                                <label class="m-0" runat="server" id="lblSpeaker"></label>
                                            </div>
                                        </div>
                                        <div class="row mb-1 position-static">
                                            <div class="col position-static"><b>Event Date:</b></div>
                                            <div class="col position-static text-truncate">
                                                <label class="m-0" runat="server" id="lblEventDate"></label>
                                            </div>
                                        </div>
                                        <div class="row mb-1 position-static">
                                            <div class="col position-static"><b>Start Time:</b></div>
                                            <div class="col position-static text-truncate">
                                                <label class="m-0" runat="server" id="lblEventStartTime"></label>
                                            </div>
                                        </div>
                                        <div class="row mb-1 position-static">
                                            <div class="col position-static"><b>End Time:</b></div>
                                            <div class="col position-static text-truncate">
                                                <label class="m-0" runat="server" id="lblEventEndTime"></label>
                                            </div>
                                        </div>
                                        <div class="row mb-1 position-static">
                                            <div class="col position-static"><b>Description:</b></div>
                                            <div class="col position-static">
                                                <label class="m-0" runat="server" id="lblEventDescription"></label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="col-sm-3 col-xl-4 text-nowrap" runat="server" id="divEventOverlay">
                                <div class="w-100 h-100 container text-center">
                                    <div class=" container h-25 mb-3"></div>
                                    <h6 class="card-title h-50 mt-5 pt-5">
                                        <asp:Image runat="server" class="figure-img mr-2" ImageUrl="MyMember/icons/outline_error_outline_black_18dp.png" /><asp:Label ID="lblEventError" runat="server">Please select a start and end date.</asp:Label></h6>
                                    <div class=" container h-25"></div>
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
                                        <asp:LinkButton ID="btnShowNotice" CommandArgument='<%#Eval("NoticeID")%>' CssClass="position-static lstBtn btn btn-block h-100" runat="server" OnClick="btnShowNotice_Click">
                                        <div class="p-0 form-row m-0 position-static">
                                                        <div class=" col-auto position-static p-0">
                                                            <div class="">
                                                                <p style="font-size:small" class="p-0 m-0 text-truncate"><b>Notice&nbsp;Title: </b><%#Eval("NoticeTitle")%><br/></p>
                                                            </div>
                                                            <hr class=" mr-4 m-0 p-0"/>
                                                            <div class="">
                                                                 <p style="font-size:small" class="p-0 m-0 text-truncate"><b>Notice&nbsp;Date: </b><%#Convert.ToDateTime(Eval("DateCreated")).ToString("dd MM yyyy")%><br/></p>
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
                                        <asp:LinkButton ID="btnShowArt" EnableViewState="true" CommandArgument='<%#Eval("ArticleID")%>' CssClass="position-static lstBtn btn btn-block" runat="server" OnClick="btnShowArt_Click">
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
                                                                <p  style="font-size:smaller;" class="p-0 m-0 text-truncate"><b>Date Created: </b><%#Convert.ToDateTime(Eval("DateCreated")).ToString("dd MMM yyyy")%></p>
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


                                   
                           <div class="container text-nowrap dash-content col-3" runat="server" id="divSchDetailsOverlay">
                                <div class="w-100 h-100 container text-center">
                                    <div class=" container h-25 mb-3"></div>
                                    <h6 class="card-title h-50 mt-5 pt-5"><img class="figure-img mr-2" src="MyAdmin/icons/outline_error_outline_black_18dp.png" />No selection was made </h6>
                                    <div class=" container h-25"></div>
                                </div>
                            </div>

                        <div runat="server" id="divDisplayArt" class=" mb-auto position-static dash-content mw-100 align-self-center">
                            
                            <asp:HiddenField runat="server" ID="hdfArticleID" Value="" />
                            <div class=" head-div-2 p-2 mb-0 ">
                                    <p class="m-0">Selected Article Details</p>
                                </div>
                            <div class="position-static p-1 lst-container m-2" style="overflow-y:scroll;">
                                <div class="row mb-3 mt-2">
                                    <div class="col">
                                        <label class="m-0 h2" runat="server" id="lblArticleTitle"></label>
                                    </div>
                                </div>
                                <div class="row mb-1 position-static">
                                    <div class="col position-static">
                                        <label class="m-0" runat="server" id="lblArticleContent"></label>
                                    </div>
                                </div>
                               <div class="row mb-1 position-static">
                                  <%--  <div class="col position-static font-italic text-left">
                                        Author:
                                        <label class="m-0 mt-2" runat="server" id="lblScholar"></label>
                                    </div>--%>
                                    <div class="row mb-1 position-static text-right m-2">
                                        <div class="col position-static font-italic">
                                            Date:
                                        <label class="m-0 font-italic mt-2" runat="server" id="lblDate"></label>
                                        </div>
                                    </div>
                                </div>
                                <!--PDF BUTTON-->
                                <div class="m-2">
                                    <a runat="server" id="lnkBack" onserverclick="lnkBack_ServerClick" ><small> << Back </small></a>
                                </div>
                                <div runat="server" id="divAdminReports" class="col-12 col-xl-12 p-0 mr-1">                                
                                <div class="m-0 p-0 pt-2 pl-2">
                                    <a runat="server" id="lnkAdminPrintPDF" onserverclick="lnkAdminPrintPDF_ServerClick" style="width:15px; height:15px"><img src="../Content/MyMember/icons/Adobe_PDF.png" /><small>Download as PDF</small></a>
                                <div id="divRating" runat="server" style="position: static; padding-left: 2em; padding-right: 2em; padding-top: 0,1em; float: right" class="row">
                                        <p class="text-nowrap h5 mr-4">Rating:&nbsp<asp:ScriptManager ID="ScriptManager1" runat="server">
                                        </asp:ScriptManager>
                                        <asp:UpdatePanel ID="updatepnl1" runat="server" class="pt-1">
                                            <ContentTemplate>
                                                <ajaxToolkit:rating ID="Rating1" AutoPostBack="true" OnClick="Rating1_Click" runat="server"
                                                    StarCssClass="Star" WaitingStarCssClass="WaitingStar" EmptyStarCssClass="Star"
                                                    FilledStarCssClass="FilledStar">
                                                </ajaxToolkit:rating>
                                            </ContentTemplate>
                                        </asp:UpdatePanel></p>
                                    </div>
                                </div>
                                  <%--  PDF GRID--%>
                                <div>
                                    <asp:GridView CssClass="flex-grow-1" ID="grdAdminReports"  RowStyle-Wrap="true" runat="server" style="font-size:smaller;" ForeColor="#333333" >
                                        <AlternatingRowStyle BackColor="White"  />
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" Font-Size="12" HorizontalAlign="Center" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#EFF3FB"  Wrap="true"  HorizontalAlign="Center"/>
                                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                    </asp:GridView>
                                </div>
                            </div>
                            <br />
                                                        <hr class="p-0 m-1" />
                            <!--Comment-->
                            <div class="" >
                                <div class="row p-0 m-0 ">
                                    <div class="col-10 ml-2 mt-3" >
                                        <asp:TextBox style="max-height:50px; min-height:50px;" CssClass="form-control col main-txtb" ID="txtComment" runat="server" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                    <div class="align-self-center">
                                        <asp:Button ID="btn_Submit" runat="server" Text="Comment" CssClass=" btn btn-sm" OnClick="btn_Submit_Click" />
                                    </div>
                                </div>
                                <br />
                                <asp:Label runat="server" ID="lblCommentCount"></asp:Label>
                                <br />
                                <!--Comments Repeater-->
                                <div class="position-static container pre-scrollable" style="overflow-y:scroll;max-height:230px;">
                                    <asp:Repeater ID="CommentRepeater" runat="server">
                                        <ItemTemplate>
                                            <div class="row" >
                                                <div class="col">
                                                    <strong><asp:Label ID="lblCommentName" ForeColor="#256297" runat="server" Text='<%#Eval("Name") %>'></asp:Label></strong>
                                                </div>
                                            </div>
                                            <div class="row" >
                                                <div class="col">
                                                    <asp:Label ID="lblComment" runat="server" Text='<%#Eval("CommentMessage") %>'></asp:Label>
                                                </div>
                                            </div>
                                            <div class="row" >
                                                <div style="font-size: small" class="col">
                                                    <asp:Label ID="lblCommentDate" runat="server" Text='<%#Convert.ToDateTime(Eval("CommentDate")).ToString("dd MMM yyyy HH:mm:ss tt") %>'></asp:Label>
                                                </div>
                                            </div>
                                            <hr />
                                        </ItemTemplate>
                                    </asp:Repeater>
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
                            <a class="footerr-text" href="Mosque/ListMosque.aspx">Mosques</a>
                        </li>
                        <li class="nav-item">
                            <a class="footerr-text" href="ListScholar.aspx">Scholars</a>
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
                            <a class="footerr-text" href="https://www.youtube.com/channel/UCp87ZLRrUz3SbzPPP2uaIEg">YouTube</a>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </form>
    <script src="Default/DefaultJq.js"></script>
    <script src="Default/Default.js"></script>
</body>
</html>
