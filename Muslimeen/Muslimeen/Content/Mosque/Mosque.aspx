<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mosque.aspx.cs" Inherits="Muslimeen.Content.Mosque.MosquePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
	<meta name="viewport" content="width=device-width, height=device-height, initial-scale=0.0"/>

    <title>MyMuslimeen - Home</title>
    <link href="../../Login/LogIn_Bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="icon" href="../../Login/LogIn_Bootstrap/muslimeen.ico" />
    <link href="css/MyMosque.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <nav class="navFixed">
                <div class="row align-self-end">
                    <ul class=" col-7 navbar-nav flex-row justify-content-start">
                        <asp:HiddenField runat="server" ID="hdfAdjustDate" Value="" />
                        <!--Need to get value from DB let admin adjust this -->
                        <li class="nav-item ml-4 mr-0 mb-0 pt-2">
                            <p class="IslamicDate mb-0" id="lstIslamicDate"></p>
                        </li>
                        <script src="../Default/DatesEnglishHijri.js" type="text/javascript"></script>
                    </ul>
                    <ul class="col-5 navbar-nav flex-row justify-content-end">
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
                        <asp:HyperLink ID="hplUserProfile" ToolTip="Edit user profile" runat="server" NavigateUrl="../ProfileEditer.aspx" CssClass="nav-item mb-0 mr-1 ml-1 user">
                        </asp:HyperLink><asp:Image Style="height: 15px; width: 15px;" runat="server" ID="imgEditProfile" CssClass="mt-1 mr-3" ImageUrl="../Default/icons/EditProfile.png" />
                    </div>
                </div>
            </nav>
            <div id="navbar" class="navbar navbar-expand flex-column navv flex-md-row" style="box-shadow: 0 0 0 0.1rem rgba(0, 123, 255, 0.50); z-index: 1000;">
                <div class=" text-center">
                    <asp:Image runat="server" CssClass="mb-0 ml-0" src="../../Login/LogIn_Bootstrap/logo.png" Width="185" Height="110" />
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
                        <li class="NavDevider">|</li>
                        <!--deviders-->
                        <li class="nav-item navbarText navbaritems">
                            <asp:LinkButton ID="LnkHelp" runat="server" OnClick="btnHelp_Click" CssClass="nav-item navText btn-link btn" ToolTip="How this page works">
                                <%--CssClass="nav-item navText btn-link btn"--%>
                         Help   
                                <asp:Image runat="server" ID="ImgHelp" ImageUrl="../MyMember/icons/helpIcon.png" Style="height: 1.1em; width: 1.1em;" />
                            </asp:LinkButton>
                        </li>
                    </ul>
                </div>
            </div>
        </header>


        <div id="content" class="content">
            <div class="row bg-light m-0 divContainers p-1 flex-nowrap">
                <div class="side-bar p-0 basic-div-styling mr-1">
                    <!--contains the buttons-->
                    <div class="head-div text-center p-2">
                        <p class="text-uppercase m-0 font-weight-bold">Tasks: </p>
                    </div>
                    <nav class="nav flex-column pt-2 pb-2 pr-0">
                        <asp:Button runat="server" ID="btnMosqueDetails" CssClass="pl-2 btn mb-1 taskBtn" Text="Mosque Details" OnClick="btnMosqueDetails_Click" />
                        <asp:Button runat="server" ID="btnEvents" CssClass="pl-2 btn mb-1 taskBtn" Text="Mosque Events" OnClick="btnEvents_Click" />
                        <asp:Button runat="server" ID="btnAddress" CssClass="pl-2 btn mb-1 taskBtn" Text="Mosque Location" OnClick="btnAddress_Click" />
                        <asp:Button runat="server" ID="btnPrayerTimes" CssClass="pl-2 btn mb-1 taskBtn" Text="Prayer Times" OnClick="btnPrayerTimes_Click" />
 </nav>
                </div>
                <div class=" position-static basic-div-styling p-0  w-100">
                    <div runat="server" id="divTaskHead" class=" head-div text-center p-2 mb-1">
                        <h4 class="p-0 m-0" id="lblTaskHeader" runat="server"></h4>
                    </div>
                    <div class="row p-0 m-0 tab-content right-bottom-div p-1">
                        <div class="col-12 bg-light position-static mt-2" runat="server" id="divDetails">
                            <div class="row">
                                <div class="col-7" id="divDetail" runat="server">
                                    <div class=" head-div-2 p-2 mb-1 text-left">
                                        <p class="m-0">Mosque Details</p>
                                    </div>
                                    <div class="table">
                                        <div class="form-row">
                                            <div class="col-4">
                                                <asp:Image runat="server" Height="290px" Width="300px" ID="imgMosque" />
                                            </div>
                                            <div class="col-7 ml-1 mt-5">
                                                <div class="row mb-1 position-static">
                                                    <div class="col-6 position-static"><b>Address:</b></div>
                                                    <div class="col-6 position-static text-truncate">
                                                        <asp:Label runat="server" Text="" ID="lblMosqueAddress"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="row mb-1 position-static">
                                                    <div class="col-6 position-static"><b>Year Established:</b></div>
                                                    <div class="col-6 position-static text-truncate">
                                                        <asp:Label runat="server" Text="" ID="lblYearEstablished"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="row mb-1 position-static">
                                                    <div class="col-6 position-static"><b>Mosque Type:</b></div>
                                                    <div class="col-6 position-static text-truncate">
                                                        <asp:Label runat="server" Text="" ID="lblMosqueType"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="row mb-1 position-static">
                                                    <div class="col-6 position-static"><b>Mosque Size:</b></div>
                                                    <div class="col-6 position-static text-truncate">
                                                        <asp:Label runat="server" Text="" ID="lblMosqueSize"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="row mb-1 position-static">
                                                    <div class="col-6 position-static"><b>Active Members:</b></div>
                                                    <div class="col-6 position-static text-truncate">
                                                        <asp:Label runat="server" Text="" ID="lblMembers"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="row mb-1 position-static">
                                                    <div class="col-6 position-static"><b>Mosque Representative:</b></div>
                                                    <div class="col-6 position-static text-truncate">
                                                        <asp:Label runat="server" Text="" ID="lblMosqueRep"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-row">
                                            <div class="col-12">
                                                <div class="row mb-1 position-static">
                                                    <div class="col position-static text-truncate">
                                                        <br>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row mb-1 position-static">
                                                <div class="col-12 position-static">
                                                    <i>Quote: 
                                                    <asp:Label runat="server" Text="" ID="lblQuote"></asp:Label></i>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-4" id="divTodayTimes" runat="server">
                                    <div class=" head-div-2 p-2 mb-1 text-left">
                                        <p class="m-0">Today's Prayer Times </p>
                                    </div>
                                    <div style="display: flex; justify-content: center" class="container">
                                        <table class="table " style="justify-content: center; width: 30%; height: 20%; align-self: center">

                                            <tr>
                                                <td rowspan="2">
                                                    <asp:Image ID="icoPrayer" ImageUrl="download.png" runat="server" Height="121px" Width="121px" />
                                                </td>
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
                        </div>
                        <div class=" col-12 bg-light position-static ml-1" runat="server" id="divEvent">
                            <div class="row">
                                <div class="col-3 p-0 mr-1">
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
                                                <asp:Button runat="server" ID="btnEvent" Text="List Events" CssClass="topnav btn btn-md btn-outline-light" OnClick="btnListEvents_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-3 col-xl-4 p-0 mr-1" runat="server" id="divViewActiveEvents">
                                    <div class=" head-div-2 p-2 mb-1 text-left">
                                        <p class="m-0">Mosque Events</p>
                                    </div>
                                    <div class="p-1 lst-container" style="overflow-y: scroll;">
                                        <asp:Repeater ID="rptGetEvents" runat="server">
                                            <HeaderTemplate>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnShow" CommandArgument='<%#Eval("EventID") %>' CssClass="position-static lstBtn btn btn-block" runat="server" OnClick="btnShow_Click" EnableViewState="true">
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
                                <div runat="server" id="divDisplayEvent" class=" col-3 col-xl-4 flex-nowrap p-0">
                                    <asp:HiddenField runat="server" ID="hdfEventId" Value="" />
                                    <div class=" head-div-2 p-2 mb-0 text-left ">
                                        <label runat="server" class="mb-0" id="lblTitle"></label>
                                    </div>
                                    <div class="container" runat="server" id="divEventDetails">
                                        <div class="row mb-1 position-static">
                                            <div class="col-3 position-static"><b>Description:</b></div>
                                            <div class="col position-static">
                                                <label class="m-0" runat="server" id="lblEventDescription"></label>
                                            </div>
                                        </div>
                                        <hr class="m-0 bg-secondary" />
                                        <div class="row mb-1 position-static">
                                            <div class="col-3 position-static"><b>Speaker:</b></div>
                                            <div class="col position-static text-truncate">
                                                <label class="m-0" runat="server" id="lblSpeaker"></label>
                                            </div>
                                        </div>
                                        <hr class="m-0 bg-secondary" />
                                        <div class="row mb-1 position-static">
                                            <div class="col-3 position-static"><b>Event Date:</b></div>
                                            <div class="col position-static text-truncate">
                                                <label class="m-0" runat="server" id="lblEventDate"></label>
                                            </div>
                                        </div>
                                        <hr class="m-0 bg-secondary" />
                                        <div class="row mb-1 position-static">
                                            <div class="col-3 position-static"><b>Start Time:</b></div>
                                            <div class="col position-static text-truncate">
                                                <label class="m-0" runat="server" id="lblEventStartTime"></label>
                                            </div>
                                        </div>
                                        <hr class="m-0 bg-secondary" />
                                        <div class="row mb-1 position-static">
                                            <div class="col-3 position-static"><b>End Time:</b></div>
                                            <div class="col position-static text-truncate">
                                                <label class="m-0" runat="server" id="lblEventEndTime"></label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-3 col-sm-3 col-xl-4 text-nowrap" runat="server" id="divEventOverlay">
                                    <div class="w-100 h-100 container text-center">
                                        <div class=" container h-25 mb-3"></div>
                                        <h6 class="card-title h-50 mt-5 pt-5">
                                            <img class="figure-img mr-2" src="../MyAdmin/icons/outline_error_outline_black_18dp.png" /><label id="lblEventError" runat="server"></label></h6>
                                        <div class=" container h-25"></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class=" col-12 p-3 bg-light position-static" runat="server" id="divLocation">
                            <br />
                            <style>
                                #map {
                                    height: 400px;
                                    width: 100%;
                                }

                                #floating-panel {
                                    position: absolute;
                                    top: 10px;
                                    left: 25%;
                                    z-index: 5;
                                    background-color: #fff;
                                    padding: 5px;
                                    border: 1px solid #999;
                                    text-align: center;
                                    font-family: 'Roboto', 'sans-serif';
                                    line-height: 30px;
                                    padding-left: 10px;
                                }
                            </style>


                            <!--The div element for the map -->


                            <div id="map"></div>
                            <script>
                                function initMap() {
                                    try {
                                        var map = new google.maps.Map(document.getElementById('map'), {
                                            zoom: 17,
                                            center: { lat: 0, lng: 0 }
                                        });
                                        var geocoder = new google.maps.Geocoder();

                                        geocodeAddress(geocoder, map)
                                    }
                                    catch{ }

                                }

                                function geocodeAddress(geocoder, resultsMap) {
                                    try {
                                        var address = '<%=Session["address"]%>';
                                        geocoder.geocode({ 'address': address }, function (results, status) {
                                            if (status === 'OK') {
                                                resultsMap.setCenter(results[0].geometry.location);
                                                var marker = new google.maps.Marker({
                                                    map: resultsMap,
                                                    position: results[0].geometry.location
                                                });
                                            } else {
                                                alert('Geocode was not successful for the following reason: ' + status);
                                            }
                                        });
                                    }
                                    catch{ }
                                }

                            </script>


                            <script async="async" defer="defer"
                                src="https://maps.googleapis.com/maps/api/js?key=AIzaSyAnDc6yCjL7rIqcd5HCsLSqz_rS_Ho8eW4&callback=initMap">
                            </script>

                            <div>
                            </div>

                        </div>
                        <div class="col-12 ml-1 bg-light position-static" runat="server" id="divPrayerTimes">
                            <div class="row">
                                <div class="col-3 ml-0 p-0">
                                    <div class=" head-div-2 p-2 mb-1 text-left">
                                        <p class="m-0">Enter Prayer Date Range</p>
                                    </div>
                                    <div class="table">
                                        <div class="form-row">
                                            <div class="form-group col-sm-6 mb-1">
                                                <label class="col mb-0 p-0">Start Date: </label>
                                                <asp:TextBox TextMode="Date" CssClass="form-control form-control-sm col main-txtb" runat="server" Format="yyyy/MM/dd" ID="txtPrayerStartDate"></asp:TextBox>
                                            </div>
                                            <div class="form-group col-sm-6 mb-1">
                                                <label class="col mb-0 p-0">End Date: </label>
                                                <asp:TextBox TextMode="Date" CssClass="form-control form-control-sm col main-txtb" runat="server" Format="yyyy/MM/dd" ID="txtPrayerEndDate"></asp:TextBox>
                                            </div>
                                            <div class="form-group col-1 mb-1 mt-1">
                                                <asp:Button runat="server" ID="btnListPrayer" Text="List Prayers" OnClick="btnListPrayer_Click" CssClass="topnav btn btn-md btn-outline-light" />
                                            </div>
                                        </div>

                                    </div>
                                </div>
                                <div class="col-9" id="divPrayerTable" runat="server">
                                    <div class=" head-div-2 p-2 mb-1 text-left">
                                        <p class="m-0">Prayer Table</p>
                                    </div>
                                    <div class="table" style="overflow-y: scroll; max-height: 75%">
                                        <table class="table table-primary">
                                            <thead>
                                                <tr>
                                                    <th colspan="2"></th>
                                                    <th colspan="2">Fajr</th>
                                                    <th colspan="2">Dhuhr</th>
                                                    <th colspan="2">Asr</th>
                                                    <th colspan="2">Magrib</th>
                                                    <th colspan="2">Eisha</th>

                                                </tr>
                                                <tr>
                                                    <th>Date</th>
                                                    <th>Day</th>
                                                    <th>Azaan</th>
                                                    <th>Jamaat</th>
                                                    <th>Azaan</th>
                                                    <th>Jamaat</th>
                                                    <th>Azaan</th>
                                                    <th>Jamaat</th>
                                                    <th>Azaan</th>
                                                    <th>Jamaat</th>
                                                    <th>Azaan</th>
                                                    <th>Jamaat</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater ID="rptPrayerTimes" runat="server">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td>
                                                                <asp:Label runat="server" Text='<%#Eval("PrayerDate").ToString().Substring(0,10)%>' ID="lblPrayerDate"></asp:Label><br />
                                                            </td>
                                                            <td>
                                                                <asp:Label runat="server" Text='<%#Eval("PrayerDay")%>' ID="lblDay"></asp:Label><br />
                                                            </td>
                                                            <td>
                                                                <asp:Label runat="server" Text='<%#Eval("FajrA")%>' ID="lblFajrA"></asp:Label><br />
                                                            </td>
                                                            <td>
                                                                <asp:Label runat="server" Text='<%#Eval("FajrJ")%>' ID="lblFajrJ"></asp:Label><br />
                                                            </td>
                                                            <td>
                                                                <asp:Label runat="server" Text='<%#Eval("DhuhrA")%>' ID="lblDhurA"></asp:Label><br />
                                                            </td>
                                                            <td>
                                                                <asp:Label runat="server" Text='<%#Eval("DhuhrJ")%>' ID="lblDhuhrJ"></asp:Label><br />
                                                            </td>
                                                            <td>
                                                                <asp:Label runat="server" Text='<%#Eval("AsrA")%>' ID="lblAsrA"></asp:Label><br />
                                                            </td>
                                                            <td>
                                                                <asp:Label runat="server" Text='<%#Eval("AsrJ")%>' ID="lblAsrJ"></asp:Label><br />
                                                            </td>
                                                            <td>
                                                                <asp:Label runat="server" Text='<%#Eval("MagribA")%>' ID="lblMagribA"></asp:Label><br />
                                                            </td>
                                                            <td>
                                                                <asp:Label runat="server" Text='<%#Eval("MagribJ")%>' ID="lblMagribJ"></asp:Label><br />
                                                            </td>
                                                            <td>
                                                                <asp:Label runat="server" Text='<%#Eval("EishaA")%>' ID="lblEishaA"></asp:Label><br />
                                                            </td>
                                                            <td>
                                                                <asp:Label runat="server" Text='<%#Eval("EishaJ")%>' ID="lblEishaJ"></asp:Label><br />
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </tbody>
                                        </table>
                                    </div>
                                    <div>
                                        <div runat="server" id="divDisplayReports" class=" col-12 col-xl-12 mw-100 p-0" style="position: static">
                                            <div class="m-0 p-0 pt-2 pl-2">
                                                <a runat="server" id="PDF" onserverclick="PDF_ServerClick">
                                                    <img src="../MyModerator/Adobe_PDF.png" /><small>Download as PDF</small></a>
                                            </div>
                                            <div id="divgrid" runat="server">
                                                <asp:GridView ID="grdReports" RowStyle-Wrap="true" runat="server" Style="position: static; font-size: x-small;" CellPadding="6" ForeColor="#333333" GridLines="none">
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <EditRowStyle BackColor="#2461BF" />
                                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                    <RowStyle BackColor="#EFF3FB" Wrap="true" />
                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-3 col-sm-3 col-xl-4 text-nowrap" runat="server" id="divPrayerOverlay">
                                    <div class="w-100 h-100 container text-center">
                                        <div class=" container h-25 mb-3"></div>
                                        <h6 class="card-title h-50 mt-5 pt-5">
                                            <img class="figure-img mr-2" src="../MyAdmin/icons/outline_error_outline_black_18dp.png" /><label id="lblPrayerError" runat="server"></label></h6>
                                        <div class=" container h-25"></div>
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
                        <a class="footerr-text" href="ListMosque.aspx">Mosques</a>
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
    <script src="../Zakaah/newZakaah.js"></script>
</body>
</html>
