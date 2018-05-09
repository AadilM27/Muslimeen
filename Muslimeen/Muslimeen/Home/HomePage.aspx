<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Muslimeen.HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>

    <title>Muslimeen - Homepage</title>

    <link href="css/bootstrap.min.css" rel="stylesheet"/>
    <link href="css/font-awesome.min.css" rel="stylesheet"/>
    <link href="css/animate.min.css" rel="stylesheet"/>
    <link href="css/responsive.css" rel="stylesheet"/>
    <link href="css/main.css" rel="stylesheet" />

</head>
<body>
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
                                    <span class="glyphicon glyphicon-search" aria-hidden="true"></span>                                    
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
                        
                        <a class="navbar-brand" href="index.html">
                            <img src="Final%20Logo.png" width="110" height="70"/>
                        </a>
                    
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
