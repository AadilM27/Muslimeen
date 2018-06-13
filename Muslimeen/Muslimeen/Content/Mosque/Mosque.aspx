<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mosque.aspx.cs" Inherits="Muslimeen.Content.Mosque.MosquePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />

    <title>MyMuslimeen - Home</title>
    <link href="../../Login/LogIn_Bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="icon" href="/Login/LogIn_Bootstrap/muslimeen.ico" />
    <link href="../Default/css/Default.css" rel="stylesheet" />

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


        <asp:Menu ID="Menu1" class="container-fluid col-lg-40" Orientation="Horizontal" StaticMenuItemStyle-CssClass="tab" Font-Size="Large" StaticSelectedStyle-CssClass="selectedtab" StaticMenuItemStyle-HorizontalPadding="50px" StaticSelectedStyle-BackColor="White" CssClass="tabs" runat="server" Height="0px" vertical-align="top" align="center" OnMenuItemClick="Menu1_MenuItemClick">
            <Items>
                <asp:MenuItem Text="Mosque Details" Value="0" Selected="true"></asp:MenuItem>
                <asp:MenuItem Text="Events" Value="1"></asp:MenuItem>
                <asp:MenuItem Text="Address" Value="2"></asp:MenuItem>
                <asp:MenuItem Text="Salah Times" Value="3"></asp:MenuItem>
            </Items>

        </asp:Menu>
        <asp:MultiView ID="MultiView1" ActiveViewIndex="0" runat="server">
            <asp:View ID="View1" runat="server">
                <br />

                <br />
                <br />
                <br />

                <div class="container">

                    <table class="table table-borderless">
                        <tr>
                            <td rowspan="7" style="width: 30%">

                                <asp:Image runat="server" Height="70%" Width="100%" ID="imgMosque" />

                            </td>
                        </tr>
                        <tr>
                            <td>
                                <h3>&nbsp;Address:
                                    <asp:Label runat="server" Text="" ID="lblMosqueAddress"></asp:Label></h3>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <h3>&nbsp;Year Established:
                                    <asp:Label runat="server" Text="" ID="lblYearEstablished"></asp:Label></h3>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <h3>&nbsp;Mosque Type:
                                    <asp:Label runat="server" Text="" ID="lblMosqueType"></asp:Label></h3>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <h3>&nbsp;Mosque Size:
                                <asp:Label runat="server" Text="" ID="lblMosqueSize"></asp:Label></h3>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <h3>&nbsp;Members:
                                <asp:Label runat="server" Text="" ID="lblMembers"></asp:Label></h3>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <h3>&nbsp;Mosque Representative: 
                                <asp:Label runat="server" Text="" ID="lblMosqueRep"></asp:Label></h3>
                            </td>
                        </tr>


                        <tr>
                            <td colspan="2">
                                <div>
                                    <i>
                                        <asp:Label runat="server" Text="" ID="lblQuote"></asp:Label></i>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div class="container" style="width: 100%; height: 100%; align-content: center; justify-content: center">
                    <table class="table table-bordered" style="justify-content: center; width: 30%; height: 20%">
                        <tbody>
                            <tr>
                                <td rowspan="2">
                                    <asp:Image ID="icoPrayer" ImageUrl="Content/download.png" runat="server" />
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
                        </tbody>
                    </table>
                </div>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />

                <br />
                <asp:Label ID="lblEventList" runat="server" Text="List Events By Date Range "></asp:Label>
                <asp:Label ID="lblStartDate" runat="server" Text="Start Date: "></asp:Label>
                <asp:TextBox ID="txtStartDate" runat="server" MaxLength="10"></asp:TextBox>
                <asp:Label ID="lblEndDate" runat="server" Text="End Date: "></asp:Label>
                <asp:TextBox ID="txtEndDate" runat="server" MaxLength="10"></asp:TextBox>
                <br />
                <asp:Button ID="btnListEvents" runat="server" Text="List Events" OnClick="btnListEvents_Click" />



                <asp:Repeater ID="rptGetEvents" runat="server">

                    <ItemTemplate>
                        <div class="container" style="position: center">

                            <div>
                                <br />
                                <br />
                                <br />
                                <table class="table">
                                    <tr>
                                        <th>
                                            <h3>Title:
                                                    <h3>
                                        </th>
                                        <td>
                                            <h4>
                                                <asp:Label ID="lblEventTitle" runat="server" Text='<%#Eval("EventTitle")%>'></asp:Label><h4>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            <h3>Description:
                                                    <h3>
                                        </th>
                                        <td>
                                            <h4>
                                                <asp:Label ID="lblEventDescription" runat="server" Text='<%#Eval("EventDescription")%>'></asp:Label><h4>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            <h3>Speaker:<h3>
                                        </th>
                                        <td>
                                            <h4>
                                                <asp:Label ID="lblSpeaker" runat="server" Text='<%#Eval("Speaker")%>'></asp:Label><h4>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            <h3>Event Date:
                                                    <h3>
                                        </th>
                                        <td>
                                            <h4>
                                                <asp:Label ID="lblEventDate" runat="server" Text='<%#Eval("EventDate").ToString().Substring(0,10)%>'></asp:Label><h4>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            <h3>Start Time:
                                                    <h3>
                                        </th>
                                        <td>
                                            <h4>
                                                <asp:Label ID="lblEventStarTime" runat="server" Text='<%#Eval("EventStartTime")%>'></asp:Label><h4>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            <h3>End Time:
                                                    <h3>
                                        </th>
                                        <td>

                                            <h4>
                                                <asp:Label ID="lblEventEndTime" runat="server" Text='<%#Eval("EventEndTime")%>'></asp:Label><h4>
                                        </td>
                                    </tr>

                                </table>
                            </div>
                        </div>
                    </ItemTemplate>

                </asp:Repeater>
            </asp:View>
            <asp:View ID="View3" runat="server">
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
                <h3>My Google Maps Demo</h3>

                <!--The div element for the map -->
                <form>

                    <div id="map"></div>
                    <script>
                        function initMap() {
                            var map = new google.maps.Map(document.getElementById('map'), {
                                zoom: 17,
                                center: { lat: 0, lng: 0 }
                            });
                            var geocoder = new google.maps.Geocoder();

                            geocodeAddress(geocoder, map)


                        }

                        function geocodeAddress(geocoder, resultsMap) {
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

                    </script>

                </form>
                <script async="async" defer="defer"
                    src="https://maps.googleapis.com/maps/api/js?key=AIzaSyAnDc6yCjL7rIqcd5HCsLSqz_rS_Ho8eW4&callback=initMap">
                </script>

                <div>
                </div>

            </asp:View>
            <asp:View ID="View4" runat="server">
                <div class="table" style="width: 0%">

                    <br />
                    <br />
                    <asp:Label ID="lblPrayerStartDate" runat="server" Text="Start Date" />
                    <asp:TextBox ID="txtPrayerStartDate" runat="server"></asp:TextBox>
                    <asp:Label ID="lblPrayerEndDate" runat="server" Text="End Date" />
                    <asp:TextBox ID="txtPrayerEndDate" runat="server"></asp:TextBox>
                    <asp:Button ID="btnListPrayer" runat="server" Text="List Prayers" OnClick="btnListPrayer_Click" />
                    <br />
                    <br />
                    <br />
                    <br />

                    <table class="table table-borderless">
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
                        <tr>
                            <asp:Repeater ID="rptPrayerTimes" runat="server">
                                <ItemTemplate>

                                    <tr>
                                        <td>
                                            <asp:Label runat="server" Text='<%#Eval("PrayerDate")%>' ID="lblPrayerDate"></asp:Label><br />
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
                        </tr>
                    </table>
                </div>
            </asp:View>

        </asp:MultiView>




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
