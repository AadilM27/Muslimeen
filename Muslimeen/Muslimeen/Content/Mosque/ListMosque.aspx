<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListMosque.aspx.cs" Inherits="Muslimeen.Content.Mosque.ListMosque" %>

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
<body style="background-color:white">
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


       
               <div class="container">
                   <br />
                <div style="text-align:center;background-color:#256297;color:white;">
                    <h1 style="text-align: center;width:100%">List of Mosques</h1>
                </div>
                   <h4 style="text-align:center;background-color:#256297;color:white;margin-bottom:0px">Search Mosque:</h4>
                <div class="jumbotron" style="height:50px" >
                    
                    <table style="width:100%;">
                        <tr>
                            <td style="width:55%;position:relative;bottom:50px;color:#256297;font-weight:bold">Mosque Suburb&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="ddlMosqueSuburb" runat="server" Height="60px" Width="250px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                 </asp:DropDownList></td>
                            <td style="width:55%;position:relative;bottom:50px;color:#256297;font-weight:bold" >Mosque Type&nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButton ID="rdoHanafie" runat="server" Text="Hanafie" GroupName="MosqueType" AutoPostBack="True" OnCheckedChanged="rdoHanafie_CheckedChanged" />&nbsp
                                <asp:RadioButton ID="rdoShafie" runat="server" Text="Shafie" GroupName="MosqueType" AutoPostBack="True" OnCheckedChanged="rdoShafie_CheckedChanged" />
                            </td>
                        </tr>
                    </table>



                </div>
            </div>
        
        <asp:Repeater ID="rptGetMosques" runat="server">
            <ItemTemplate>
                <div class="container">
                    <div class="jumbotron" style="height:300px" >
                        <table border="0" class="table" style="color: gray">
                            <tr>
                                <td style="width: 200px">
                                    <asp:Image ID="MosquePic" ImageUrl='<%#Eval("MosqueImage")%>' runat="server" Width="200px" Height="180px" /></td>
                                <td>

                                    <table  style="width: 100%; height: 100%;color:#256297;font-weight:bold;border:none">
                                        <tr>
                                            <th rowspan="2" style="font-size:22px;position:relative;bottom:61px;right:200px;border:none">
                                                <asp:Label ID="lblName" runat="server" Text='<%#Eval("MosqueName")%>'></asp:Label></th>
                                            <td colspan="2" >Mosque Type:
                                            <asp:Label ID="lblmosqueType" runat="server" Text='<%#Eval("MosqueType")%>'></asp:Label></td>


                                        </tr>
                                        <tr>
                                            <td colspan="2">Suburb:
                                            <asp:Label ID="lblMosqueSuburb" runat="server" Text='<%#Eval("MosqueSuburb")%>'></asp:Label></td>
                                            <td class="text-center" >

                                                <asp:LinkButton ID="btnViewDetails" Text="View Mosque Details" CssClass="btn btn-info center" runat="server" OnClick="btnViewDetails_Click" EnableViewState="true" CommandArgument='<%#Eval("MosqueID")%>' style="background-color:#256297;color:white;"/>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td colspan="2">Size:
                                            <asp:Label ID="lblSize" runat="server" Text='<%#Eval("MosqueSize")%>'></asp:Label></td>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>

                </div>
            </ItemTemplate>

            <SeparatorTemplate>
                <div class="divider" style="height: 1em"></div>
            </SeparatorTemplate>
        </asp:Repeater>



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
