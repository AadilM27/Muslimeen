<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HelpCenter.aspx.cs" Inherits="Muslimeen.Content.HelpCenter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
	<meta http-equiv="X-UA-Compatible" content="IE=edge"/>
	<meta name="viewport" content="width=device-width, height=device-height, initial-scale=0.0"/>

    <title>Help Center</title>
    <link rel="icon" href="../Login/LogIn_Bootstrap/muslimeen.ico"/>
    <link href="../Login/LogIn_Bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="HelpPage/HelpPage.css" rel="stylesheet" />
</head>
    <body>
        <asp:HyperLink ID="lnk1" runat="server" href="HelpPage.aspx"></asp:HyperLink>
        <form id="frmScholar" runat="server" class=" ">   
            <header >
                <nav class="navFixed">
                    <div class="row align-self-end">
                       <ul class=" col-7 navbar-nav flex-row justify-content-start">
                            <asp:HiddenField runat="server" ID="hdfAdjustDate" Value="" /> <!--Need to get value from DB let admin adjust this -->
                            <li class="nav-item ml-4 mr-0 mb-0 pt-2"> <p class="IslamicDate mb-0" id="lstIslamicDate"></p></li>
                            <script src="Default/DatesEnglishHijri.js" type="text/javascript"></script>
                        </ul>
                       <ul class="col-5 navbar-nav flex-row justify-content-end">
                            <li class=" nav-item mr-2">
                            <asp:Button runat="server" Text="Login" ID="btnLogin" CssClass="topnav btn btn-sm btn-outline-light" OnClick="btnLogin_Click" />
                            </li>
                            <li class="nav-item mr-2">
                            <asp:Button runat="server" Text="Register" ID="btnRegister" CssClass="topnav btn btn-sm btn-outline-light" OnClick="btnRegister_Click" />
                            </li>
                        </ul> <!---->
                    </div>
                    <div class="row" runat="server" id="divUserProfile" >
                        <div class="col navbar-nav flex-row ml-4 mb-0 mt-0 pt-2 justify-content-end">
                            <asp:HyperLink ID="hplUserProfile" ToolTip="Edit user profile" runat="server" NavigateUrl="ProfileEditer.aspx" CssClass="nav-item mb-0 mr-1 ml-1 user">
                            </asp:HyperLink><asp:Image style="height:15px; width:15px;" runat="server" id="imgEditProfile" CssClass="mt-1 mr-3" ImageUrl="Default/icons/EditProfile.png"/>
                        </div>
                    </div>
                </nav>
                <div id="navbar" class="navbar navbar-expand flex-column navv flex-md-row" style="box-shadow: 0 0 0 0.1rem rgba(0, 123, 255, 0.50);">
                    <div class=" text-center">
                        <asp:Image runat="server" CssClass="mb-0 ml-0" src="../../Login/LogIn_Bootstrap/logo.png" width="185" height="110"/>
                        </div>
                    <div class="ml-2 navbar-nav-scroll align-self-end justify-content-start">
                        <ul class="navbar-nav row">
                            <li class="nav-item navbarText navbaritems">
                                <asp:Button runat="server" ID="btnHome" Text="Home"  CssClass=" btn btn-link nav-item navText" OnClick="btnHome_Click"/>
                            </li><li class="NavDevider">|</li><!--deviders-->
                            <li class="nav-item navbarText navbaritems" runat="server" id="liMyMusbtn">
                                <asp:Button runat="server" ID="btnMyMuslimeen" Text="MyMuslimeen"  CssClass=" btn btn-link nav-item navText" OnClick="btnMyMuslimeen_Click"/>
                            </li><li runat="server" id="liMyMusDivi" class=" NavDevider">|</li><!--deviders-->
                            <li class="nav-item navbarText navbaritems">
                                <asp:Button runat="server" ID="btnMosques" Text="Mosques"  CssClass="nav-item navText btn-link btn" OnClick="btnMosques_Click"/>
                            </li><li class="NavDevider">|</li><!--deviders-->
                            <li class="nav-item navbarText navbaritems">
                                <asp:Button runat="server" ID="btnScholars" Text="Scholars"  CssClass="nav-item navText btn-link btn" OnClick="btnScholars_Click"/>
                            </li><li class="NavDevider">|</li><!--deviders-->
                            <li class="nav-item navbarText navbaritems">
                                <asp:Button runat="server" ID="btnLearnIslam" Text="Learn Islam"  CssClass="nav-item navText btn-link btn" OnClick="btnLearnIslam_Click"/>
                            </li><li class="NavDevider">|</li><!--deviders-->
                            <li class="nav-item navbarText navbaritems">
                                <asp:Button runat="server" ID="btnZakaah" Text="Zakaah"  CssClass="nav-item navText btn-link btn" OnClick="btnZakaah_Click"/>
                            </li><li class="NavDevider">|</li><!--deviders-->
                            <li class="nav-item navbarText navbaritems">
                                <asp:Button runat="server" ID="btnAboutUs" Text="About us"  CssClass="nav-item navText btn-link btn" OnClick="btnAboutUs_Click"/>
                            </li>
                            <li class="NavDevider">|</li>
                         <!--deviders-->
                        <li class="nav-item navbarText navbaritems">
                        <asp:LinkButton ID="LnkHelp" runat="server"  OnClick="btnHelp_Click" CssClass="nav-item navText btn-link btn" ToolTip="How this page works" ><%--CssClass="nav-item navText btn-link btn"--%>
                         Help    <asp:Image runat="server" ID="ImgHelp" ImageUrl="MyMember/icons/helpIcon.png" style="height: 1.1em; width:1.1em;" /></asp:LinkButton>   
                        </li>
                        </ul>
                    </div>
                </div>
            </header>
     <!--Add content-->
            
        <div class="content position-relative" id="content"><!--add content here -->
            <div class="row bg-light m-0 divContainers p-1 flex-nowrap position-relative">
              <div class="side-bar p-0 basic-div-styling mr-1 position-relative">
                    <!--contains the buttons-->
                    <div class="head-div text-center p-2">
                        <p class="text-uppercase m-0 font-weight-bold">Index :</p>
                   </div>
                     <nav class="list-group m-1" id="scrollspy">
                         
                             <a class="list-group-item list-group-item-action" onclick="flashDiv('divUser');" href="#divUser">User</a>
                             <a class="list-group-item list-group-item-action" onclick="flashDiv('divScholar');" href="#divScholar">Scholar</a>
                             <a class="list-group-item list-group-item-action" onclick="flashDiv('divMosqueRep');" href="#divMosqueRep">Mosque Representitive</a>
                             <a class="list-group-item list-group-item-action" onclick="flashDiv('divAdmin');" href="#divAdmin">Admin</a>
                             <a class="list-group-item list-group-item-action" onclick="flashDiv('divModerator');" href="#divModerator">Moderator</a>
                       
                         
                     </nav>
                </div>
                <!--End menu-->
             <div class=" position-static basic-div-styling p-0  w-100">
                    <div class=" head-div text-center p-2 mb-1">
                        <h4 class="p-0 m-0">Welcome to our help center<asp:Image runat="server" CssClass="mb-0 ml-0" src="HelpPage/icons/help.png" width="70" height="50"/></h4>
                    </div>

                <div class="container" data-spy="scroll" data-target="#scrollspy">
                <div class="position-static basic-div-styling p-0">
                    <div class="head-div-2 p-2 mb-0">
                        <h5 class="text-center">Getting started </h5>
                    </div>
                        <div class=" paragraphDisplay p-2 mt-3">

                            <p>
                            <b>User:</b><br />
                            A user will register on My Muslimeen. Once the user is registered and assigned himself to a mosque, he may then have the option to view his mosque 
                            salaah times, mosque events and notifications for this week or the latest articles. He may view mosques and scholars within
                            his city.
                            <br />
                            <br />
                            <b>Mosque Representitive:</b><br />
                            A mosque representitive is assigned to a mosque by the web master. He will be in control of updating their mosque salaah times 
                            as well as their mosque events and notifications. If there are any queries, please inform us via the details displayed 
                            on the contact us page.
                            <br />
                            <br />
                            <b>Scholar:</b><br />
                            A user has to request to become a scholar having the needed qualifications. When a scholar registered, his qualifications must be uploaded and the moderator will verify these qualifications. 
                            All articles uploaded by the scholar will be moderated as well, therefore no false content wil be uploaded. 
                            A scholar may do everything the user can do. The only difference is that a scholar may upload or edit their articles.
                            <br />
                            <br />
                            <b>Admin:</b><br />
                            The admin are the individulas who created this site. When they log in they may control and change anything as well as keep
                            the website up to date.
                            <br />
                            <br />
                            <b>Moderator:</b><br />
                            A user may become a moderator depedning on his qualifiction. When a moderator registers and is accepted by the admin, they may
                            view all the pending articles and users who requested to become a scholar. They are in control of the data uploaded onto this site.
                            </p>
                        </div>
                </div>
                    <br />
                <div class="position-static basic-div-styling p-0">
                    <div class="head-div-2 p-2 mb-0">
                     <h5 class="text-center">Manage your account</h5>
                     </div>
                     <div class=" paragraphDisplay p-2">
                     <p>
                         All accounts are verified via e-mail. When registering, a valid e-mail address should be used. A password containing one capital
                         letter, one number and a special character will be required for security purposes. Your account and privacy is fully protected. Should you want
                         to update any account details, you may do so by going to MyMuslimeen(Your Dashboard).
                     </p>
                     </div>
                </div>
                    <br />
                <div class="position-static basic-div-styling p-0">
                    <div class="head-div-2 p-2 mb-0">
                        <h5 class="text-center">How my Muslimeen feed works</h5>
                    </div>
                    <div class=" paragraphDisplay p-2">
                    <p>
                        Various users have access to and may do various tasks. 
                    </p>
                        <div runat="server" id="divUser" >
                            <b>User:</b><br />
                            <ul>
                                <li>View/edit profile</li>
                                <li>View prayer times</li>
                                <li>View mosque events</li>
                                <li>View notifications for this week</li>
                                <li>View latest articles</li>
                                <li>Search for specific results</li>
                                <li>View zakaah information, organisations as well as calculate zakaah</li>
                                <li>View Scholars</li>
                                <li>View a list of mosques and filter according to their needs</li>
                                <li>View articles on our Learn Islam page</li>
                                <li>Have online chats with the desired scholar</li>
                            </ul>

                        </div>
                        <div runat="server" id="divMosqueRep" >
                            <b>Mosque Representitive:</b><br />
                            <ul>
                                <li>View/update prayer times</li>
                                <li>Add/remove mosque events</li>
                                <li>View mosque details</li>
                                <li>View/Update profile</li>
                                <li>View number of assigned users to a specific mosque</li>
                                <li>Search for specific results</li>
                                <li>View zakaah information, organisations as well as calculate zakaah</li>
                                <li>View Scholars</li>
                                <li>View a list of mosques and filter according to their needs</li>
                                <li>View articles on our Learn Islam page</li>
                            </ul>
                            <a id="h"></a>
                        </div>
                        <div runat="server" id="divScholar">
                            <b>Scholar:</b><br />
                            <ul>
                                <li>Add/Edit articles</li>
                                <li>View/edit profile</li>
                                <li>View prayer times</li>
                                <li>View mosque events</li>
                                <li>Search for specific results</li>
                                <li>View zakaah information, organisations as well as calculate zakaah</li>
                                <li>View Scholars</li>
                                <li>View a list of mosques and filter according to their needs</li>
                                <li>View articles on our Learn Islam page</li>
                                <li>Have online chats with users</li>
                            </ul>
                        </div>
                        <div runat="server" id="divAdmin">
                            <b>Admin:</b><br />
                            <ul>
                                <li>Add/edit/delete a mosque</li>
                                <li>View/accept/reject scholar registration</li>
                                <li>Add a moderator</li>
                                <li>Add/Update zakaah organisations</li>
                                <li>Add/Update notices</li>
                            </ul>
                        </div>
                        <div runat="server" id="divModerator" >
                            <b>Moderator:</b><br />
                            <ul>
                                <li>View/edit their profile</li>
                                <li>View/accept/reject pending article uploads</li>
                                <li>View/accept/reject scholar registration</li>
                                <li>View mosque reports</li>
                                <li>View event reports</li>
                            </ul>
                        </div>
                    </div>
                    </div>
                </div>
                </div>
            </div>
            </div>
         
                <!--close content-->
            <div class="footerr"> <!--End of content, start of footer-->
                <div class="row bg-light">
                    <div class="col text-center position-static">
                       <h6>Content</h6>
                        <ul class="navbar-nav">
                           <li class="nav-item">
                               <a class="footerr-text" href="Mosque/ListMosque.aspx">Mosques</a>
                           </li>
                           <li class="nav-item">
                               <a class="footerr-text" href="ListScholar.aspx">Scholars</a>
                           </li>
                           <li class="nav-item">
                               <a class="footerr-text" href="Learn Islam/LearnIslam.aspx">Learn Islam</a>
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
            </form>
        <script src="Default/Default.js"></script>
        <script src="Default/DefaultJq.js"></script>
    </body>
</html>
