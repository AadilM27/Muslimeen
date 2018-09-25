<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListMosque.aspx.cs" Inherits="Muslimeen.Content.Mosque.ListMosque" %>

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
<body style="background-color: white">
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
                        <asp:HyperLink ID="hplUserProfile" ToolTip="Edit user profile" runat="server" NavigateUrl="../Content/ProfileEditer.aspx" CssClass="nav-item mb-0 mr-1 ml-1 user">
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
        <div class="content" id="content">
            <div class="container" style="width: 900px">
                <br />
                <div style="text-align: center; background-color: #256297; color: white;">
                    <h1 style="text-align: center; width: 100%">List of Mosques</h1>
                </div>
                <h4 style="text-align: center; background-color: #256297; color: white; margin-bottom: 0px">Search Mosque:</h4>
                <div class="jumbotron" style="height: 50px">

                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 55%; position: relative; bottom: 50px; color: #256297; font-weight: bold">Mosque Suburb&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="ddlMosqueSuburb" runat="server" Height="60px" Width="250px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                            </asp:DropDownList></td>
                            <td style="width: 55%; position: relative; bottom: 50px; color: #256297; font-weight: bold">Mosque Type&nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButton ID="rdoHanafie" runat="server" Text="Hanafie" GroupName="MosqueType" AutoPostBack="True" OnCheckedChanged="rdoHanafie_CheckedChanged" />&nbsp
                                <asp:RadioButton ID="rdoShafie" runat="server" Text="Shafie" GroupName="MosqueType" AutoPostBack="True" OnCheckedChanged="rdoShafie_CheckedChanged" />
                            </td>
                        </tr>
                    </table>


                </div>
            </div>
            <asp:Repeater ID="rptGetMosques" runat="server">
                <ItemTemplate>
                    <div class="container" style="width: 900px">
                        <div class="position-static basic-div-styling p-0 form-group">
                            <div class="head-div-2 p-2 mb-0 col">
                                <h4 class="text-center">
                                    <asp:Label ID="lblName" runat="server" Text='<%#Eval("MosqueName")%>'></asp:Label></th>
                                </h4>
                            </div>
                            <div class="row">
                                <div class="col-4 mb-2 mt-2">
                                    <div id="image" class="ml-3">
                                        <asp:Image ID="MosquePic" ImageUrl='<%# "../" + Eval("MosqueImage")%>' runat="server" Width="200px" Height="180px" />
                                    </div>
                                </div>
                                <div class="col-4 mt-5">
                                    <div id="mosqueType" class="row">
                                        <h6>Mosque Type:&nbsp;</h6>
                                        <asp:Label ID="lblmosqueType" runat="server" Text='<%#Eval("MosqueType")%>'></asp:Label>
                                        </br>
                                    </div>
                                    <div id="mosqueSuburb" class="row">
                                        <h6>Mosque Suburb:&nbsp;</h6>
                                        <asp:Label ID="lblMosqueSuburb" runat="server" Text='<%#Eval("MosqueSuburb")%>'></asp:Label>
                                        </br>
                                    </div>
                                    <div id="mosqueSize" class="row">
                                        <h6>Mosque Size:&nbsp;</h6>
                                        <asp:Label ID="lblSize" runat="server" Text='<%#Eval("MosqueSize")%>'></asp:Label>
                                        </br>
                                    </div>
                                </div>
                                <div class="col-4 mt-5 p-1">
                                    <asp:LinkButton ID="btnViewDetails" Text="View Mosque Details" CssClass="btn btn-info center" runat="server" OnClick="btnViewDetails_Click" EnableViewState="true" CommandArgument='<%#Eval("MosqueID")%>' Style="background-color: #256297; color: white;" />
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>

                <SeparatorTemplate>
                    <div class="divider" style="height: 1em"></div>
                </SeparatorTemplate>
            </asp:Repeater>
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
</body>
</html>
