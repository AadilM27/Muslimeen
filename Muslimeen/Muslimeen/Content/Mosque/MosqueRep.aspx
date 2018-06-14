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
    <link href="../AboutUs/AboutUs.css" rel="stylesheet" />

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




        <div style="background-color: white">
            <br />
            <asp:Menu ID="Menu1" class="container-fluid col-lg-40" Orientation="Horizontal" StaticMenuItemStyle-CssClass="tab" Font-Size="Large" StaticSelectedStyle-CssClass="selectedtab" StaticMenuItemStyle-HorizontalPadding="50px" StaticSelectedStyle-BackColor="White" CssClass="tabs" runat="server" Height="0px" vertical-align="top" align="center" OnMenuItemClick="Menu1_MenuItemClick">
                <Items>
                    <asp:MenuItem Text="Add Event" Value="0" Selected="true"></asp:MenuItem>
                    <asp:MenuItem Text="Update/Remove Event" Value="1"></asp:MenuItem>
                    <asp:MenuItem Text="Manage Prayer Times" Value="2"></asp:MenuItem>
                </Items>
            </asp:Menu>

            <asp:MultiView ID="MultiView" ActiveViewIndex="0" runat="server">

                <asp:View ID="View1" runat="server">
                    <br />
                    <br />
                    <div class="container">

                        <div class="contentHolder mt-4">
                            <div class="header mb-3">
                                <h4 class="text-center">Add Events:
                               <br />
                                </h4>

                            </div>
                            <div class="container">

                                <table>
                                    <tr>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>Event Title: </td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtEventTitle" MaxLength="50"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td>Event Date:</td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtEventDate"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td>Event Start Time</td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtEventStartTime" MaxLength="20"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td>Event End Time: </td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtEventEndTime" MaxLength="20"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td>Event Speaker: </td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtSpeaker" MaxLength="50"></asp:TextBox></td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <p></p>
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Event Description: </td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtEventDescription" Width="200px" Height="150" MaxLength="250"></asp:TextBox></td>
                                                    <td>
                                                        <asp:Button runat="server" ID="btnAddEvent" Text="Add Event" OnClick="btnAddEvent_Click" /></td>
                                                </tr>

                                            </table>
                                        </td>
                                    </tr>
                                </table>


                                <asp:Label ID="lblEventMessage" runat="server" />

                            </div>
                        </div>





                    </div>
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <br />
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
                                                    <asp:LinkButton ID="btnSelectEvent" Text="Select Event" CssClass="btn btn-info center" runat="server" OnClick="btnSelectEvent_Click" EnableViewState="true" CommandArgument='<%#Eval("EventID")%>'/></td>
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
                                                    <asp:TextBox ID="txtUpdateEventDate" runat="server" Width="500px" ></asp:TextBox>
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





                </asp:View>
                <asp:View ID="View3" runat="server">
                    <br><br/>
                    <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
                    <h3>Selected Date:
                    <asp:Label ID="lblDate" runat="server" /></h3>
                    <h4>
                        <asp:Label ID="lblMessage" runat="server" /></h4>
                    <table>
                        <tbody>
                            <tr>
                                
                                <td rowspan="2">
                                    <asp:Image ID="icoPrayer" ImageUrl="download.png" runat="server" Width="121px" Height="121px" />
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
                                    <asp:TextBox ID="txtFajrA" runat="server" MaxLength="5"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtFajrJ" runat="server" MaxLength="5"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>Dhuhr</th>
                                <td>
                                    <asp:TextBox ID="txtDhuhrA" runat="server" MaxLength="5"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtDhuhrJ" runat="server" MaxLength="5"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <th class="auto-style1">Asr</th>
                                <td class="auto-style1">
                                    <asp:TextBox ID="txtAsrA" runat="server" MaxLength="5"></asp:TextBox></td>
                                <td class="auto-style1">
                                    <asp:TextBox ID="txtAsrJ" runat="server" MaxLength="5"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <th>Magrib</th>
                                <td>
                                    <asp:TextBox ID="txtMagribA" runat="server" MaxLength="5"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtMagribJ" runat="server" MaxLength="5"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <th>Eisha</th>
                                <td>
                                    <asp:TextBox ID="txtEishaA" runat="server" MaxLength="5"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtEishaJ" runat="server" MaxLength="5"></asp:TextBox></td>
                            </tr>
                        </tbody>
                    </table>
                    <asp:Button ID="BtnAdd" runat="server" Text="Add Prayer Times" OnClick="BtnAdd_Click" />
                    <asp:Button ID="BtnUpdate" runat="server" Text="Update Prayer Times" OnClick="BtnUpdate_Click" />

                </asp:View>
            </asp:MultiView>
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
