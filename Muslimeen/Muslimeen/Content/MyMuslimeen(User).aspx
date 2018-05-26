<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyMuslimeen(User).aspx.cs" Inherits="Muslimeen.Content.MyMuslimeen_User_" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
        <meta charset="utf-8"/>
        <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
        <meta name="description" content=""/>
        <meta name="author" content=""/>

        <title> MyMuslimeen - User </title> <!--Tab title-->
        <link href="../Home/css/bootstrap.min.css" rel="stylesheet" />
        <link href="../Home/css/font-awesome.min.css" rel="stylesheet"/>
        <link href="../Home/css/animate.min.css" rel="stylesheet"/>
        <link href="../Home/css/prettyPhoto.css" rel="stylesheet"/>
        <link href="../Home/css/main.css" rel="stylesheet"/>
        <link href="../Home/css/responsive.css" rel="stylesheet"/>

        <!--[if lt IE 9]>
            <script src="js/html5shiv.js"></script>
            <script src="js/respond.min.js"></script>
            <![endif]-->
    <a href="../Home/images/ico/logo.ico"></a>

    

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

                    <!--<h1 class="midnight-blue">My Muslimeen</h1>-->
                    
                    <div class="collapse navbar-collapse navbar-right">
                        <ul class="nav navbar-nav"> <!--Change the link of pages to your page-->
                            <li><a href="Default.aspx">Home</a></li>                            
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

            <hr class ="midnight-blue" />
         <div class="container">
             
            <div class =" col-md-4">
                <h4 class="text-center">Salaah Times</h4>
            </div>


            <div class =" col-md-4">
                <h4 class="text-center">View Events&nbsp;&nbsp;&nbsp; <asp:RadioButton ID="MyMosque" runat="server" text="My Mosque"/>
            &nbsp;&nbsp;&nbsp; <asp:RadioButton ID="AllMosques" runat="server" text="All Mosques "/> </h4> &nbsp &nbsp 
            </div>

            <div class =" col-md-4">
               <h4 class="text-center">Notifications</h4> 
            </div>
          </div>
        

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
    </body></html>
