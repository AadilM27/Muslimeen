<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Zakaah.aspx.cs" Inherits="Muslimeen.Zakaah" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <meta charset="utf-8"/>
        <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
        <meta name="description" content=""/>
        <meta name="author" content=""/>

        <title> Muslimeen - Zakaah </title> <!--Tab title-->

        <link href="../Home/css/bootstrap.min.css" rel="stylesheet"/>
        <link href="../Home/css/font-awesome.min.css" rel="stylesheet"/>
        <link href="../Home/css/animate.min.css" rel="stylesheet"/>
        <link href="../Home/css/prettyPhoto.css" rel="stylesheet"/>
        <link href="../Home/css/main.css" rel="stylesheet"/>
        <link href="../Home/css/responsive.css" rel="stylesheet"/>
     <link href="Login/LogIn_Bootstrap/css/Zakaah.css" rel="stylesheet" />
        <!--[if lt IE 9]>
            <script src="js/html5shiv.js"></script>
            <script src="js/respond.min.js"></script>
            <![endif]-->
   

        <link rel="shortcut icon" href="../Home/images/ico/logo.ico"/> <!--Logo on the tab-->

</head>

    <body class="homepage">
        <form role="form" runat="server">
        <header id="header">
            <div class="top-bar">
                <div class="container">
                    <div class="row">
                        <div class="col-sm-6 col-xs-4">
                            <div class="top-number"><p> </p></div>
                        </div>
                        <div class="col-sm-6 col-xs-8">
                            <div class="social">
                                <div class="search">                                 
                                    <asp:TextBox ID="txtSearch" runat="server" class="search-form" autocomplete="off" placeholder="Search"></asp:TextBox>
                                    <i class="fa fa-search"></i>                                    
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            
            <nav class="navbar navbar-inverse" role="banner">
                <div class="container">
                    <div class="navbar-header">
                        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                            <span class="sr-only">Toggle navigation</span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>
                        
                        <a class="navbar-brand" href="index.html"><img src="../Home/images/Final Logo.png" alt="logo" width="110" height="70"/></a>
                    
                    </div>
                    <div class="collapse navbar-collapse navbar-right">
                        <ul class="nav navbar-nav"> <!--Change the link of pages to your page-->
                            <li class="active"><a href="Default.aspx">Home</a></li>                            
                            <li><a href="Mosque.aspx">Mosques</a></li>
                            <li><a href="prayers.html">Scholars</a></li>
                            <li><a href="portfolio.html">Learn Islam</a></li>
                            <li><a href="blog.html">Zakaah</a></li>
                            <li><a href="contact-us.html">Contact Us</a></li>
                        </ul>
                    </div>
                </div>
            </nav>
        </header>
            <div class ="col-container">
                <div class ="row">
                    <div class ="jumbotron">
                        <div>
                            <h1>Zakaah</h1>
                        </div>
                    </div>
                </div>
            </div>
            <div>
                <asp:Menu ID="Menu1" Orientation="Horizontal" StaticMenuItemStyle-CssClass="tab" Font-Size="Large" StaticSelectedStyle-CssClass="selectedtab" StaticMenuItemStyle-HorizontalPadding="50px" StaticSelectedStyle-BackColor="White" CssClass="tabs" runat="server" height="0px" vertical-align="top" align ="center" OnMenuItemClick="Menu1_MenuItemClick">
                    <Items>
                    <asp:MenuItem Text="What is Zakaah?" Value="0" Selected="true"></asp:MenuItem>
                        <asp:MenuItem Text="Zakaah Calculator" Value="1"></asp:MenuItem>
                        <asp:MenuItem Text="Organizations" Value="2"></asp:MenuItem>
                        <asp:MenuItem Text="Contact Us" Value="3"></asp:MenuItem>    
                </Items>
                </asp:Menu>

                <div class="tabcontents">
                    <asp:MultiView ID="MultiView1" ActiveViewIndex="0" runat="server">
                    <asp:View ID="View1" runat="server">
                     <div class="container ">
                         <div class="row">
                            <div class ="jumbotron2">
                             <h1>What is Zakaah?</h1>
                                <p>
                                   "Take from their wealth so that you might purify and sanctify them"
                                </p>
                                <p>(Quran 9:103)</p>
                                <p>The word means 'purity' or 'to purify';all Muslims who are wealthy
                                    enough,must purify their wealth through the act of giving charity.
                                </p>
                            </div>

                         </div>
                     </div>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                   <br />
                        tab1
                    </asp:View>
                    <asp:View ID="View3" runat="server">
                   <br /> tab 2
                    </asp:View>
                    <asp:View ID="View4" runat="server">
                   <br /> tab3
                    </asp:View>

                    </asp:MultiView>
                   
                </div>
                
            </div>

        <!--START INSERTING CODE FROM THIS POINT ON-->
        
        <footer id="footer" class="midnight-blue">
            <div class="container">
                <div class="row">
                    <div class="col-sm-6">
                        &copy; 2018 Muslimeen. All Rights Reserved.
                    </div>
                    <div class="col-sm-6">
                        <ul class="pull-right"> <!--Change the link of pages to your page-->
                            <li><a href="Default.aspx">Home</a></li>
                            <li><a href="Mosque.aspx">Mosques</a></li>
                            <li><a href="prayers.html">Scholars</a></li>
                            <li><a href="portfolio.html">Learn Islam</a></li>
                            <li><a href="blog.html">Zakaah</a></li>
                            <li><a href="contact-us.html">Contact Us</a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </footer>
        
        <script src="js/jquery.js"></script>
        <script src="js/bootstrap.min.js"></script>
        <script src="js/jquery.prettyPhoto.js"></script>
        <script src="js/jquery.isotope.min.js"></script>
        <script src="js/main.js"></script>
        <script src="js/wow.min.js"></script>
        </form>
    </body>
</html>