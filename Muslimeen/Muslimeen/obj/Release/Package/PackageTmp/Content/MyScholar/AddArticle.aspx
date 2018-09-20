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
    <script src="js/AddArticle.js"></script>

    </head>
<body>
    <asp:HyperLink ID="lnk1" runat="server" href="HelpPage.aspx"></asp:HyperLink>

    <form id="frmAddArticle" runat="server">
        <!--Header-->
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
                <div id="navbar" class="navbar navbar-expand flex-column navv flex-md-row" style="box-shadow: 0 0 0 0.1rem rgba(0, 123, 255, 0.50); z-index:1000">
                    <div class=" text-center">
                        <asp:Image runat="server" CssClass="mb-0 ml-0" src="../../Login/LogIn_Bootstrap/logo.png" width="185" height="110"/>
                        </div>
                    <div class="ml-2 navbar-nav-scroll align-self-end justify-content-start">
                        <ul class="navbar-nav row">
                            <li class="nav-item navbarText navbaritems">
                                <asp:Button runat="server" ID="btnHome" Text="Home"  CssClass=" btn btn-link nav-item navText" OnClick="btnHome_Click"/>
                            </li><li class="NavDevider">|</li><!--deviders-->
                            <li class="nav-item navbarText navbaritems" runat="server" id="liMyMusbtn">
                                <asp:Button runat="server" ID="btnMyMuslimeen" Text="MyMuslimeen" CssClass=" btn btn-link nav-item navText" OnClick="btnMyMuslimeen_Click"/>
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
            <div class="row bg-light m-0 divContainers p-1 flex-nowrap">
                <div class="side-bar p-0 basic-div-styling mr-1">
                    <!--contains the buttons-->
                    <div class="head-div text-center p-2">
                        <p class="text-uppercase m-0 font-weight-bold">Scholar Tasks:</p>
                    </div>
                    <nav class="nav flex-column pt-2 pb-2 pr-0">
                        <p class="pl-2 btn taskBtn mb-1">My Mosque &#11167;</p>
                        <asp:Button runat="server" ToolTip="Go to the Home tab" ID="btnMosqueEvents" OnClick="btnMosqueEvents_Click" CssClass=" pl-2 btn sub-taskBtn mb-1 " Text="Events" />
                        <asp:Button runat="server" ToolTip="Go to the Home tab" ID="btnTodaysPrayerTime" OnClick="btnTodaysPrayerTime_Click" CssClass=" pl-2 btn sub-taskBtn mb-1 " Text="Todays Prayer Times" />
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
                        <%--View Prayer Times--%>
                        <div runat="server" id="divDisplaySalahTimetable" class="bg-light position-static col p-3 divContainers">
                                <div style="display: flex;justify-content: center" class=" position-static basic-div-styling w-50">
                                 <table class="table" style="justify-content: center; width: 50%; height: 20%; align-self: center">
                                    <tr>
                                        <td rowspan="2"; colspan="1"><asp:Image ID="icoPrayer" ImageUrl="../Mosque/download.png" runat="server" Height="110px" Width="110px" /></td>
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

                        <%-- View Events--%>
                        <div class=" row bg-light position-static ml-1 mr-1 flex-nowrap col-12 pl-0" runat="server" id="divDisplayEvents">
                                <%--flex-nowrap w-100--%>
                                <div class="col-3 col-sm-5 col-xl-4 p-0 mr-1">
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
                                                <asp:Button runat="server" ID="btnListEvents" Text="List Events" CssClass="topnav btn btn-md btn-outline-light" OnClick="btnListEvents_Click"/>
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
                                            <asp:Repeater ID="RptEventList" runat="server">
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
                                    <div runat="server" id="lblEventTitle" class="ml-3 p-2 h4" style="font-weight: 500">
                                        <h4 class="p-0 m-0"></h4>
                                    </div>
                                    <hr class="m-1 ml-3 mr-3 bg-secondary" />
                                    <div>
                                        <div class="container" runat="server" id="divEventDetails">
                                            <div class="row mb-1 position-static">
                                                <div class="col position-static"><b>Description:</b></div>
                                                <div class="col position-static">
                                                    <label class="m-0" runat="server" id="lblEventDescription"></label>
                                                </div>
                                            </div>
                                            <hr class="bg-secondary m-0 mt-2 mb-2 " />
                                            <div class="row mb-1 position-static">
                                                <div class="col position-static"><b>Speaker:</b></div>
                                                <div class="col position-static text-truncate">
                                                    <label class="m-0" runat="server" id="lblSpeaker"></label>
                                                </div>
                                            </div>
                                                <hr class="m-0 mt-2 mb-2  bg-secondary" />
                                            <div class="row mb-1 position-static">
                                                <div class="col position-static"><b>Event Date:</b></div>
                                                <div class="col position-static text-truncate">
                                                    <label class="m-0" runat="server" id="lblEventDate"></label>
                                                </div>
                                            </div>
                                            <hr class=" m-0 mt-2 mb-2 bg-secondary" />
                                            <div class="row mb-1 position-static">
                                                <div class="col position-static"><b>Start Time:</b></div>
                                                <div class="col position-static text-truncate">
                                                    <label class="m-0" runat="server" id="lblEventStartTime"></label>
                                                </div>
                                            </div>
                                            <hr class="bg-secondary m-0 mt-2 mb-2 " />
                                            <div class="row mb-1 position-static">
                                                <div class="col position-static"><b>End Time:</b></div>
                                                <div class="col position-static text-truncate">
                                                    <label class="m-0" runat="server" id="lblEventEndTime"></label>
                                                </div>
                                            </div>                                            
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-3 col-xl-4 text-nowrap" runat="server" id="divEventOverlay">
                                    <div class="w-100 h-100 container text-center">
                                        <div class=" container h-25 mb-3"></div>
                                        <h6 class="card-title h-50 mt-5 pt-5">
                                            <asp:Image runat="server" class="figure-img mr-2" ImageUrl="../MyMember/icons/outline_error_outline_black_18dp.png" /><asp:Label ID="lblEventError" runat="server">Please select a start and end date.</asp:Label></h6>
                                        <div class=" container h-25"></div>
                                    </div>
                                </div>

                            </div>

                        <%--Add Article--%>
                        <div class="col-12 col-sm-12 col-md-6 col-xl-8 p-0" runat="server" id="divAddArticle">
                            <div class=" head-div-2 p-2 mb-1 text-left">
                                <p class="m-0">Add Article Details</p>
                            </div>
                            <div class=" position-static p-1 lst-container">
                                <div class="form-row">
                                    <div class="form-group col-xl-6 col-sm-6 col-6 mb-1">
                                        <label class="col mb-0 p-0 position-static"><strong>Topic:</strong></label>
                                        <asp:DropDownList ID="drpTopics" runat="server" CssClass="form-control main-txtb" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" AutoPostBack="false"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="form-group col-sm-12 col-12 mb-1">
                                        <label class="col mb-0 p-0 position-static"><strong>Heading:</strong></label>
                                        <asp:TextBox CssClass="form-control"  Onblur="heading();" ID="txtHeading" runat="server" placeholder="Enter Heading"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="form-group col-sm-12 mb-1">
                                        <label class="col mb-0 p-0 position-static"><strong>Content:</strong></label>
                                        <asp:TextBox CssClass="form-control" ID="txtContent" runat="server" Style="max-height:350px; min-height:350px;" TextMode="MultiLine" placeholder="Enter Content"></asp:TextBox>
                                    </div>
                                </div>
                                <br />
                                <div class="form-row">
                                    <div class="form-group col-sm-12 mb-1 text-right position-static">
                                        <asp:Button CssClass=" topnav btn btn-outline-light" Style="width:150px;" ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="form-group col-sm-12 mb-1 text-right position-static">
                                        <asp:Button CssClass=" topnav btn btn-outline-light" Style="width:150px;" ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>

                        <%--Pending Articles--%>
                        <div class="col-5 col-sm-5 col-md-6 col-xl-4 p-0 mr-1" runat="server" id="divPendingArticles">
                            <div class=" head-div-2 p-2 mb-1 text-left">
                                <p class="m-0">Pending Articles</p>
                            </div>
                            <div class="p-1 lst-container" style="overflow-y: scroll;">
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
                        <div runat="server" id="divNoSelected" class="col-7 col-sm-7 col-xl-8 align p-0 text-justify">
                            <asp:HiddenField runat="server" ID="hdfSchId" Value="" />
                            <div class=" head-div-2 p-2 mb-0 text-left ">
                                <p class="m-0 ">Article Selected</p>
                            </div>
                            <div class="container mt-2 pre-scrollable" runat="server" id="divDisplayArticle">
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
                                        -
                                        <label class="m-0 font-italic mt-2" runat="server" id="lblDate"></label>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <%--Rejected Articles--%>
                        <div class="col-5 col-sm-5 col-xl-4 p-0 mr-1" runat="server" id="divRejectedArticles">
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
                        <div runat="server" id="divNoRejectedSelected" class="col-7 col-sm-7 col-xl-8 align p-0 text-justify">
                            <asp:HiddenField runat="server" ID="hfdRej" Value="" />
                            <div class=" head-div-2 p-2 mb-0 text-left ">
                                <p class="m-0">Article Selected</p>
                            </div>
                            <div class="container mt-2" runat="server" id="divDisplayRejected">
                                <div class="row mb-1 position-static">
                                    <div class="col-2 position-static"><b>Title:</b></div>
                                    <div class="col position-static text-truncate">
                                        <label class="m-0" runat="server" id="lblRTitle"></label>
                                    </div>
                                </div>
                                <div class="row mb-1 position-static">
                                    <div class="col-2 position-static"><b>Content:</b></div>
                                    <div class="col position-static">
                                        <label class="m-0 flex-wrap" runat="server" id="lblRContent"></label>
                                    </div>
                                </div>
                                <div class="row mb-1 position-static">
                                    <div class="col-2 position-static"><b>Date:</b></div>
                                    <div class="col position-static text-truncate">
                                        <label class="m-0" runat="server" id="lblRDate"></label>
                                    </div>
                                </div>
                                <div class="row mb-1 position-static">
                                    <div class="col-2 position-static"><b>Rejection<br /> Reason:</b></div>
                                    <div class="col position-static text-truncate">
                                        <label class="m-0" runat="server" id="lblReason"></label>
                                    </div>
                                </div>
                                <div class="container p-0 m-2 task-action">
                                        <h6 class="w-100 card-title card-header">
                                            <img class="figure-img mr-2 mb-1 " src="../MyAdmin/icons/outline_warning_black_18dp.png" />Before Editing Article.</h6>
                                        <div class=" position-static m-0 card-body">
                                            <ul class="pl-1">
                                                <li><p class="mb-0" ><small class="card-text">Clicking on the Edit button will able you to edit the selected article.</small></p></li>
                                            </ul>
                                        </div>
                                        <div class="card-footer text-center position-static text-nowrap">
                                            <asp:Button CssClass=" topnav btn btn-sm btn-outline-light mr-2" runat="server" ID="btnEdit" Text="Edit Article" OnClick="btnEdit_Click" />
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
                        <a class="footerr-text" href="../Mosque/Mosque.aspx">Mosques</a>
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

    <script src="../Default/Default.js" type="text/javascript"></script>
    <script src="../Default/DatesEnglishHijri.js" type="text/javascript"></script>
    <script src="../Default/DefaultJq.js"></script>
</body>
</html>
