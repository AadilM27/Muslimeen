﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AboutUs.aspx.cs" Inherits="Muslimeen.Content.AboutUs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta charset="utf-8"/>
	<meta http-equiv="X-UA-Compatible" content="IE=edge"/>
	<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>

    <title>About Us</title>
    <link rel="icon" href="/Login/LogIn_Bootstrap/muslimeen.ico"/>
    <link href="../Login/LogIn_Bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="MyMember/css/MyMember.css" rel="stylesheet" />
    <link href="../Content/AboutUs/AboutUs.css" rel="stylesheet" />
</head>
    <body>
        <form id="frmScholar" runat="server" class=" ">   
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
        <!--START INSERTING CODE FROM THIS POINT ON-->
            <!--add your custom styling in MyMember.css in MyMember/css-->
                <h1 class="title">About us</h1>
                <hr />
                
               <div class="container">
                
                   <h4 class="text-center"> Our Mission:  <br/></h4>
                    <h5 class="text-center">
                        Enhance communication
                        within our community <br />
                        And educate our users more about Islam
                        
                    </h5>
                    <hr />


                <p class="paragraphDisplay">
                    Our mission is what drives us to do everything possible to increase the unity within our community. We do this by having
                    a centralised database where all members can access our safe and secure website anywhere, and at anytime. <br />
                    This website caters for those who would like to view events and salaah times or any other information about the mosque they attend or 
                    other mosques they are interested in. Our users may view scholar details to personally contact them for islamic advice
                    or simply learn more about Islam through our Learn Islam page. Our website strives for convenience where we don't only provide
                    zakaah information, but also allow members to calculate the amounts by using our zakaah calculator.
                </p>
               <hr />
                    <h4 class="text-center"> Innovation: <br/></h4>
                    <h5 class="text-center">
                        The big leap, the big risk<br />
                        the big change
                    </h5>
                <hr />

                   <p class="paragraphDisplay">
                       We are in the process of increasing the communication platform to increase our users satisfaction.
                       Our future communication platform will include a Muslimeen forum page where members may start a 
                       thread by asking questions as well as respond to a thread which was created.
                       We are also planning to create a direct messenger where we could communicate directly with our scholars, instead of using
                       another app.
                   </p>
                     <hr />
                    <h4 class="text-center"> Our Team: <br/></h4>
                    <h5 class="text-center">
                        A team that is empowered, diverse<br />
                        and inclusive
                        
                    </h5>
                <hr />

                   <p class="paragraphDisplay">
                       No matter where we come from, the love for Islam and helping others unites us.
                       Our team shares a singular goal: to inform members about what is happening within our community, foster convenience and help those
                       who would like to know more about Islam.
                       The world is contantly curious about Islam, and we've got a team of scholars which we are truly inspired by.
                   </p>
                    <!--<h4 class="text-center"> We dare to enhance our communication platform  <br/></h4>
                    <p>The world is our community. We are in the process of creating a forum platform to increase our
                       means of communication and learning.
                    </p>-->
                    </div>
                

                </div>
            <div class="footerr"><!--End content here, start of footer-->
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
    </body>
</html>


