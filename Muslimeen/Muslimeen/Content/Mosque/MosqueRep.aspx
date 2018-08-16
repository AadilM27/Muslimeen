<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MosqueRep.aspx.cs" Inherits="Muslimeen.Content.Mosque.MosqueRep" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />

    <title>MyMuslimeen - Home</title>
    <link href="../../Login/LogIn_Bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="icon" href="/Login/LogIn_Bootstrap/muslimeen.ico" />
    <link href="css/MyMosque.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
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
            <!--add content here -->
            <div class="row bg-light m-0 divContainers p-1 flex-nowrap">
                <div class="side-bar p-0 basic-div-styling mr-1">
                    <!--contains the buttons-->
                    <div class="head-div text-center p-2">
                        <p class="text-uppercase m-0 font-weight-bold">Rep Tasks: </p>
                    </div>
                    <nav class="nav flex-column pt-2 pb-2 pr-0">
                        <asp:Button runat="server" ID="btnNavAddEvent" CssClass="pl-2 btn mb-1 taskBtn" Text="Add Event" OnClick="btnNavAddEvent_Click" />
                        <asp:Button runat="server" ID="btnNavEditEvent" CssClass="pl-2 btn mb-1 taskBtn" Text="Update/Remove Event" OnClick="btnNavEditEvent_Click" />
                        <asp:Button runat="server" ID="btnNavManageTimes" CssClass="pl-2 btn mb-1 taskBtn" Text="Manage Prayer Times" OnClick="btnNavManageTimes_Click" />
                    </nav>
                </div>
                <div class=" position-static basic-div-styling p-0  w-100">
                    <div runat="server" id="divTaskHead" class=" head-div text-center p-2 mb-1">
                        <h4 class="p-0 m-0" id="lblTaskHeader" runat="server"></h4>
                    </div>
                    <div class="row p-0 m-0 tab-content right-bottom-div p-1">
                        <div class="flex-nowrap w-50" runat="server" id="divAddEvent">
                            <!--Contains the List of items-->
                            <div class=" head-div-2 p-2 mb-1 text-left">
                                <p class="m-0">Add Event</p>
                            </div>
                            <div class="position-static p-1 lst-container">
                                <div class="form-row">
                                    <div class="form-group col-sm-12 mb-1">
                                        <label class="col mb-0 p-0">Event Title*</label>
                                        <asp:TextBox CssClass="form-control form-control-md col main-txtb" runat="server" ID="txtEventTitle"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="form-group col-sm-12 mb-1">
                                        <label class="col mb-0 p-0">Event Date*</label>
                                        <asp:TextBox TextMode="Date" CssClass="form-control form-control-sm col main-txtb" runat="server" Format="yyyy/MM/dd" ID="txtEventDate"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="form-group col-sm-12 mb-1">
                                        <label class="col mb-0 p-0">Event Start Time*</label>
                                        <asp:TextBox CssClass="form-control form-control-sm col main-txtb" runat="server" ID="txtEventStartTime"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="form-group col-sm-12 mb-1">
                                        <label class="col mb-0 p-0">Event End Time*</></label>
                                        <asp:TextBox CssClass="form-control form-control-sm col main-txtb" runat="server" ID="txtEventEndTime"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="form-group col-sm-12 mb-1">
                                        <label class="col mb-0 p-0">Event Speaker*</label>
                                        <asp:TextBox CssClass="form-control form-control-sm col main-txtb" runat="server" ID="txtSpeaker"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="form-group col-sm-12 mb-1">
                                        <label class="col mb-0 p-0">Event Description</label>
                                        <asp:TextBox TextMode="MultiLine" Style="min-height: 200px; max-height: 200px" CssClass="form-control form-control-sm col main-txtb" runat="server" ID="txtEventDescription"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="form-group col-sm-12 mb-1 text-center">
                                        <asp:Button runat="server" ID="btnAddEvent" Text="Add Event" OnClick="btnAddEvent_Click" CssClass=" topnav btn btn-md btn-outline-light mr-2 mt-2" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class=" col-4 p-3 bg-light position-static" runat="server" id="divEditEvent">

                            <br />
                            <div class="container">
                                <div class="contentHolder mt-4">
                                    <div class="header mb-3">
                                        <h4 class="text-center">Update/Remove Events
                               <br />
                                        </h4>

                                    </div>
                                    <div class="paragraphDisplay p-2">
                                        Select the date of the event you are searching...
                            <asp:DropDownList ID="ddlUpdateEvent" runat="server" OnSelectedIndexChanged="ddlUpdateEvent_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>

                                    </div>
                                </div>




                                <br />
                                <br />
                                <asp:Repeater ID="rptUpdateEvents" runat="server">
                                    <ItemTemplate>
                                        <div class="contentHolder mt-4">
                                            <div class="header mb-3">
                                                <h4 class="text-center">
                                                    <asp:Label ID="lblEventTitle" runat="server" Text='<%#Eval("EventTitle")%>'></asp:Label>
                                                    <br />
                                                </h4>

                                            </div>
                                            <div class="paragraphDisplay p-2">

                                                <table class="table">

                                                    <tr>
                                                        <th>
                                                            <h3>Description: </h3>
                                                            <h3></h3>
                                                        </th>
                                                        <td>
                                                            <h4>
                                                                <asp:Label ID="lblEventDescription" runat="server" Text='<%#Eval("EventDescription")%>'></asp:Label>
                                                            </h4>
                                                            <h4></h4>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th>
                                                            <h3>Speaker:</h3>
                                                            <h3></h3>
                                                        </th>
                                                        <td>
                                                            <h4>
                                                                <asp:Label ID="lblSpeaker" runat="server" Text='<%#Eval("Speaker")%>'></asp:Label>
                                                            </h4>
                                                            <h4></h4>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th>
                                                            <h3>Event Date: </h3>
                                                            <h3></h3>
                                                        </th>
                                                        <td>
                                                            <h4>
                                                                <asp:Label ID="lblEventDate" runat="server" Text='<%#Eval("EventDate").ToString().Substring(0,10)%>'></asp:Label>
                                                            </h4>
                                                            <h4></h4>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th>
                                                            <h3>Start Time: </h3>
                                                            <h3></h3>
                                                        </th>
                                                        <td>
                                                            <h4>
                                                                <asp:Label ID="lblEventStarTime" runat="server" Text='<%#Eval("EventStartTime")%>'></asp:Label>
                                                            </h4>
                                                            <h4></h4>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th>
                                                            <h3>End Time: </h3>
                                                            <h3></h3>
                                                        </th>
                                                        <td>
                                                            <h4>
                                                                <asp:Label ID="lblEventEndTime" runat="server" Text='<%#Eval("EventEndTime")%>'></asp:Label>
                                                            </h4>
                                                            <h4></h4>
                                                        </td>
                                                        <td>
                                                            <asp:LinkButton ID="btnSelectEvent" Text="Select Event" CssClass="btn btn-info center" runat="server" OnClick="btnSelectEvent_Click" EnableViewState="true" CommandArgument='<%#Eval("EventID")%>' /></td>
                                                        </td>
                                                    </tr>

                                                </table>

                                            </div>
                                        </div>




                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                            <div id="divUpdateEvent" runat="server">
                                <div class="container">
                                    <div class="contentHolder mt-4">
                                        <div class="header mb-3">
                                            <h4 class="text-center">Update or Remove Event:
                               <br />
                                            </h4>

                                        </div>
                                        <div class="paragraphDisplay p-2">

                                            <table class="table">
                                                <tr>
                                                    <th>
                                                        <h3>Title: </h3>
                                                        <h3></h3>
                                                    </th>
                                                    <td>
                                                        <h4>
                                                            <asp:TextBox ID="txtUpdateEventTitle" runat="server" Width="500px"></asp:TextBox>
                                                        </h4>
                                                        <h4></h4>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>
                                                        <h3>Description: </h3>
                                                        <h3></h3>
                                                    </th>
                                                    <td>
                                                        <h4>
                                                            <asp:TextBox ID="txtUpdateEventDescription" runat="server" Width="500px" Height="300px"></asp:TextBox>
                                                        </h4>
                                                        <h4></h4>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>
                                                        <h3>Speaker:</h3>
                                                        <h3></h3>
                                                    </th>
                                                    <td>
                                                        <h4>
                                                            <asp:TextBox ID="txtUpdateSpeaker" runat="server" Width="500px"></asp:TextBox>
                                                        </h4>
                                                        <h4></h4>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>
                                                        <h3>Event Date: </h3>
                                                        <h3></h3>
                                                    </th>
                                                    <td>
                                                        <h4>
                                                            <asp:TextBox ID="txtUpdateEventDate" runat="server" Width="500px"></asp:TextBox>
                                                        </h4>
                                                        <h4></h4>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>
                                                        <h3>Start Time: </h3>
                                                        <h3></h3>
                                                    </th>
                                                    <td>
                                                        <h4>
                                                            <asp:TextBox ID="txtUpdateEventStartTime" runat="server" Width="500px"></asp:TextBox>
                                                        </h4>
                                                        <h4></h4>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>
                                                        <h3>End Time: </h3>
                                                        <h3></h3>
                                                    </th>
                                                    <td>
                                                        <h4>
                                                            <asp:TextBox ID="txtUpdateEventEndTime" runat="server" Width="500px"></asp:TextBox>
                                                        </h4>
                                                        <h4>&nbsp;</h4>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td>
                                                        <asp:Button ID="btnUpdateEvent" runat="server" Text="Update Event" OnClick="btnUpdateEvent_Click" CssClass="btn btn-info center" />
                                                        <asp:Button ID="btnRemoveEvent" runat="server" Text="Remove Event" OnClick="btnRemoveEvent_Click" CssClass="btn btn-info center" />
                                                    </td>
                                                </tr>
                                            </table>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-12 bg-light position-static mt-0" runat="server" id="divManageTimes">
                            <div class="row flex-nowrap">
                                <div class="col-sm-4 col-4 col-xl-3 p-0">
                                    <div class=" head-div-2 p-2 mb-1 text-left">
                                        <p class="m-0">Select a date to Add/Update Prayer</p>
                                    </div>
                                    <div class=" ml-5 mt-5 p-2">
                                        <asp:Calendar ID="Calendar1" runat="server" CssClass="" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
                                    </div>
                                </div>
                                <div class="col-sm-9 col-9 col-xl-4 p-0 ml-2">
                                    <div class=" head-div-2 p-2 mb-1 text-left">
                                        <p class="m-0">
                                            <asp:Label ID="lblMessage" runat="server"></asp:Label><asp:Label ID="lblDate" runat="server"></asp:Label>
                                        </p>
                                    </div>
                                    <div>
                                        <div class="table text-center mt-5 ml-3">
                                            <div class="form-row">
                                                <div class="form-group col col-xl-3 col-sm-2">
                                                </div>
                                                <div class="form-group col col-xl-3 col-sm-2">
                                                    <label class="font-weight-bold">Adhaan</label>
                                                </div>
                                                <div class="form-group col col-xl-3 col-sm-2">
                                                    <label class="font-weight-bold">Jamaat</label>
                                                </div>
                                            </div>
                                            <div class="form-row">
                                                <div class="form-group col col-xl-3 col-sm-2">
                                                    <label class="mb-0 p-0 font-weight-bold">Fajr</label>
                                                </div>
                                                <div class="form-group col col-xl-3 col-sm-2">
                                                    <asp:TextBox ID="txtFajrA" runat="server" MaxLength="5" CssClass=" form-control mb-1 border border-dark"></asp:TextBox>
                                                </div>
                                                <div class="form-group col col-xl-3 col-sm-2">
                                                    <asp:TextBox ID="txtFajrJ" runat="server" MaxLength="5" CssClass=" form-control mb-1 border border-dark"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-row">
                                                <div class="form-group col col-xl-3 col-sm-2">
                                                    <label class=" mb-0 p-0 font-weight-bold">Dhuhr</label>
                                                </div>
                                                <div class="form-group col col-xl-3 col-sm-2">
                                                    <asp:TextBox ID="txtDhuhrA" runat="server" MaxLength="5" CssClass="form-control mb-1 border border-dark"></asp:TextBox>
                                                </div>
                                                <div class="form-group col col-xl-3 col-sm-2">
                                                    <asp:TextBox ID="txtDhuhrJ" runat="server" MaxLength="5" CssClass="form-control mb-1 border border-dark"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-row">
                                                <div class="form-group col col-xl-3 col-sm-2">
                                                    <label class="col mb-0 p-0 font-weight-bold">Asr</label>
                                                </div>
                                                <div class="form-group col col-xl-3 col-sm-2">
                                                    <asp:TextBox ID="txtAsrA" runat="server" MaxLength="5" CssClass="form-control mb-1 border border-dark"></asp:TextBox>
                                                </div>
                                                <div class="form-group col col-xl-3 col-sm-2">
                                                    <asp:TextBox ID="txtAsrJ" runat="server" MaxLength="5" CssClass="form-control mb-1 border border-dark"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-row">
                                                <div class="form-group col col-xl-3 col-sm-2">
                                                    <label class="col mb-0 p-0 font-weight-bold">Magrib</label>
                                                </div>
                                                <div class="form-group col col-xl-3 col-sm-2">
                                                    <asp:TextBox ID="txtMagribA" runat="server" MaxLength="5" CssClass="form-control mb-1 border border-dark"></asp:TextBox>
                                                </div>
                                                <div class="form-group col col-xl-3 col-sm-2">
                                                    <asp:TextBox ID="txtMagribJ" runat="server" MaxLength="5" CssClass="form-control mb-1 border border-dark"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-row">
                                                <div class="form-group col col-xl-3 col-sm-2">
                                                    <label class="col mb-0 p-0 font-weight-bold">Eisha</label>
                                                </div>
                                                <div class="form-group col col-xl-3 col-sm-2">
                                                    <asp:TextBox ID="txtEishaA" runat="server" MaxLength="5" CssClass="form-control mb-1 border border-dark"></asp:TextBox>
                                                </div>
                                                <div class="form-group col col-xl-3 col-sm-2">
                                                    <asp:TextBox ID="txtEishaJ" runat="server" MaxLength="5" CssClass="form-control mb-1 border border-dark"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-row">
                                                <div class="form-group col col-xl-3 col-sm-2">
                                                </div>
                                                <div class="form-group col col-xl-3 col-sm-2">
                                                </div>
                                                <div class="form-group col col-xl-3 col-sm-2">
                                                    <asp:Button ID="BtnAdd" runat="server" Text="Add Prayer" OnClick="BtnAdd_Click" CssClass="topnav btn btn-md btn-outline-light" />
                                                    <asp:Button ID="BtnUpdate" runat="server" Text="Update Prayer" OnClick="BtnUpdate_Click" CssClass="topnav btn btn-md btn-outline-light" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
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
    <script src="Default/Default.js" type="text/javascript"></script>
</body>
<script src="Default/Default.js" type="text/javascript"></script>
</html>
