<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZakaahFacts.aspx.cs" Inherits="Muslimeen.Content.ZakaahWebForms.ZakaahFacts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
     <head runat="server">
    <meta charset="utf-8"/>
	<meta http-equiv="X-UA-Compatible" content="IE=edge"/>
	<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
     <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.1.0/css/bootstrap.min.css" />
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.0/umd/popper.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.1.0/js/bootstrap.min.js"></script>
  <style>
  .fakeimg {
      height: 200px;
      background: #aaa;
  }
  </style>
  
  
 

 

    <title>MyMuslimeen -Zakaah</title>
    <link rel="icon" href="/Login/LogIn_Bootstrap/muslimeen.ico"/>
    <link href="../Login/LogIn_Bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="Default/css/Default.css" rel="stylesheet" />
        <link href="../Content/Zakaah/css/newZakaah.css" rel="stylesheet" />
    
</head>
    <body style="background-color:white">
        
        <form id="newZakaah" runat="server" class="">
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
            </form><!--content starts here--->
          <div class="footerr" > <!--End of content, start of footer-->
                <div class="row">
                    <div class="col text-center">
                       <h5>Content</h5>
                        <ul class="navbar-nav">
                           <li class="nav-item">
                               <a href="Default.aspx">Home</a>
                           </li>
                           <li class="nav-item">
                               <a href="Mosque.aspx">Mosques</a>
                           </li>
                           <li class="nav-item">
                               <a href="#">Scholars</a>
                           </li>
                           <li class="nav-item">
                               <a href="#">Learn Islam</a>
                           </li>
                           <li class="nav-item">
                               <a href="Zakaah.aspx">Zakaah</a>
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
        
        <script src="Default/Default.js" type="text/javascript"></script>

            </body>

</html>
