<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mosque.aspx.cs" Inherits="Muslimeen.Content.Mosque" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
	<meta http-equiv="X-UA-Compatible" content="IE=edge"/>
	<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>

    <title>MyMuslimeen - Home</title>
    <link rel="icon" href="/Login/LogIn_Bootstrap/muslimeen.ico"/>
    <link href="../Login/LogIn_Bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="Mosque/Mosque.css" rel="stylesheet" />
</head>
    <body>
        <form id="frmMosque" runat="server">   
            <header >
                <nav class="navFixed">
                    <div class="row align-self-end">
                        <ul class=" col-7 navbar-nav flex-row justify-content-start">
                            <asp:HiddenField runat="server" ID="hfAdjustDate" Value="-2" /> <!--Need to get value from DB let admin adjust this -->
                            <li class="nav-item ml-3 mr-0"> <p id="lstIslamicDate"></p></li>
                            <script src="Default/DatesEnglishHijri.js" type="text/javascript"></script>
                        </ul>
                        <ul class="navbar-nav flex-row justify-content-end col-5">
                            <li class="nav-item ml-0 mr-0">
                            <asp:TextBox ID="txtSearch" TextMode="Search" runat="server"  class=" search-box form-control form-control-sm" autocomplete="off" placeholder="Search"></asp:TextBox>
                            </li>
                            <li class="nav-item ml-0 mr-2">
                                <asp:Button runat="server" Text="Go" CssClass="topnav search-btn form-control form-control-sm" />
                            </li>
                            <li class=" nav-item mr-2">
                            <asp:Button runat="server" Text="Login" CssClass="topnav btn btn-sm btn-outline-light" />
                            </li>
                            <li class="nav-item mr-2">
                            <asp:Button runat="server" Text="Register" CssClass="topnav btn btn-sm btn-outline-light" />
                            </li>
                        </ul>
                    </div>
                </nav>
                <div id="navbar" class="navbar navbar-expand flex-column navv flex-md-row">
                    <div class=" text-center">
                        <asp:Image runat="server" CssClass="mb-0 ml-0" src="/Login/LogIn_Bootstrap\logo.png" width="185" height="110"/>
                   
                        </div>
                    <div class=" ml-0 navbar-nav-scroll align-self-center justify-content-start">
                        <ul class="navbar-nav flex-row">
                            <li class="nav-item navbarText navbaritems"">
                                <asp:Button runat="server" Text="Home"  CssClass=" btn btn-link nav-item navText"/>
                            </li><li>|</li><!--deviders-->
                            <li class="nav-item navbarText navbaritems">
                                <asp:Button runat="server" Text="Mosques"  CssClass="nav-item navText btn-link btn"/>
                            </li><li>|</li><!--deviders-->
                            <li class="nav-item navbarText navbaritems">
                                <asp:Button runat="server" Text="Scholars"  CssClass="nav-item navText btn-link btn"/>
                            </li><li>|</li><!--deviders-->
                            <li class="nav-item navbarText navbaritems">
                                <asp:Button runat="server" Text="Learn Islam"  CssClass="nav-item navText btn-link btn"/>
                            </li><li>|</li><!--deviders-->
                            <li class="nav-item navbarText navbaritems">
                                <asp:Button runat="server" Text="Zakaah"  CssClass="nav-item navText btn-link btn"/>
                            </li><li>|</li><!--deviders-->
                            <li class="nav-item navbarText navbaritems">
                                <asp:Button runat="server" Text="About us"  CssClass="nav-item navText btn-link btn"/>
                            </li>
                        </ul>
                    </div>
                </div>
            </header>
        <div class="content"><!--add content here -->
                        <!-- =================================================================================================-->
             <asp:Repeater ID="rptMosque" runat="server">
            <ItemTemplate>
                <div class="container" style="background-color:#256297">
                    <div class="jumbotron">
                        <table class="table table-active align-content-center shadow-lg" style="color: gray">
                            <tr>
                                <td style="width: 200px">
                                    <asp:Image ID="MosquePic" ImageUrl='<%#Eval("MosqueImage")%>' runat="server" Width="200px" Height="180px" /></td>
                                <td>

                                    <table border="0">
                                        <tr>
                                            <th rowspan="2" style="font-size: x-large" class="font-weight-bold ">
                                                <asp:Label ID="lblName" runat="server" Text='<%#Eval("MosqueName")%>'></asp:Label></th>
                                            <td colspan="2">Mosque Type:
                                            <asp:Label ID="lblmosqueType" runat="server" Text='<%#Eval("MosqueType")%>'></asp:Label></td>
                                            <td rowspan="3">
                                    
                                            <asp:HyperLink CssClass="image" ID="Location" runat="server" ImageUrl='<%#Eval("LocationIMG")%>' NavigateUrl='<%#Eval("LocationLink")%>' ImageWidth="200px" ImageHeight="140px" />
                                            </td>

                                        </tr>
                                        <tr>
                                            <td colspan="2">Members:
                                            <asp:Label ID="lblMembers" runat="server" Text='123'></asp:Label></td>
                                            <td class="text-center">

                                                <asp:LinkButton ID="btnViewDetails" Text="View Mosque Deatils" CssClass="btn btn-info center" runat="server" EnableViewState="true" CommandArgument='<%#Eval("MosqueName")%>' /></td>


                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td colspan="2">Size:
                                            <asp:Label ID="lblSize" runat="server" Text='<%#Eval("MosqueSize")%>'></asp:Label></td>
                                            <td></td>
                                        </tr>
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
          <!--  ================================================================================================-->
            </div>
   
            <div class="footerr">
                <div class="row">
                    <div class="col text-center">
                       <h5>Content</h5>
                        <ul class="navbar-nav">
                           <li class="nav-item">
                               <a href="#">Home</a>
                           </li>
                           <li class="nav-item">
                               <a href="#">Mosques</a>
                           </li>
                           <li class="nav-item">
                               <a href="#">Scholars</a>
                           </li>
                           <li class="nav-item">
                               <a href="#">Learn Islam</a>
                           </li>
                           <li class="nav-item">
                               <a href="#">Zakaah</a>
                           </li>
                        </ul>
                    </div>
                    <div class="col  text-center">
                        <h5>About us</h5>
                        <ul class="navbar-nav">
                            <li class="nav-item">
                                <a href="#">Content</a>
                            </li>
                            <li class="nav-item">
                                <a href="#">Content</a>
                            </li>
                            <li class="nav-item">
                                <a href="#">Content</a>
                            </li>
                        </ul>
                    </div>
                    <div class="col  text-center">
                        <h5>Contact us</h5>
                        <ul class="navbar-nav">
                            <li class="nav-item">
                                <a href="#">Content</a>
                            </li>
                            <li class="nav-item">
                                <a href="#">Content</a>
                            </li>
                            <li class="nav-item">
                                <a href="#">Content</a>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
      
            
        </form>
        <script src="Default/Default.js" type="text/javascript"></script>
    </body>
</html>