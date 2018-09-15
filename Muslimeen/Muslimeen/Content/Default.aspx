<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Muslimeen.Content.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
	<meta http-equiv="X-UA-Compatible" content="IE=edge"/>
	<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>

    <title>MyMuslimeen - Home</title>
    <link rel="icon" href="../Login/LogIn_Bootstrap/muslimeen.ico"/>
    <link href="../Login/LogIn_Bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="Default/css/Default.css" rel="stylesheet" />
    <script src="../Login/LogIn_Bootstrap/js/jquery-3.3.1.min.js"></script>
    <link href="Default/css/Slideshow.css" rel="stylesheet" />
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
                <div id="navbar" class="navbar navbar-expand flex-column navv flex-md-row" style="box-shadow: 0 0 0 0.1rem rgba(0, 123, 255, 0.50); z-index:1000">
                    <div class=" text-center">
                        <asp:Image runat="server" CssClass="mb-0 ml-0" src="../Login/LogIn_Bootstrap/logo.png" width="185" height="110"/>
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
                            </li><li class="NavDevider">|</li><!--deviders-->
                            <li class="nav-item navbarText navbaritems">
                            <asp:LinkButton ID="LnkHelp" runat="server"  OnClick="btnHelp_Click" CssClass="nav-item navText btn-link btn" ToolTip="Get help using Muslimeen" ><%--CssClass="nav-item navText btn-link btn"--%>
                                Help<asp:Image runat="server" ID="ImgHelp" ImageUrl="MyMember/icons/helpIcon.png" style="height: 1.1em; width:1.1em;" /></asp:LinkButton>   
                            </li>
                        </ul>
                    </div>
                </div>
            </header>
        <div class="content" id="content"><!--add content here -->
            <div class=" pt-2 countDown-div">
                <div id="clockdiv" class="col">
                    <h2 style="font-family: Arial; color: #3F84C1" runat="server" id="lblCounterTitle"></h2>
                    <div class="">
                        <span id="spDays" class="days"></span>
                        <div class="smalltext">Days</div>
                    </div>
                    <div class="">
                        <span id="spHours" class="hours"></span>
                        <div class="smalltext">Hours</div>
                    </div>
                    <div class="">
                        <span id="spMinutes" class="minutes"></span>
                        <div class="smalltext">Minutes</div>
                    </div>
                    <div class="">
                        <span id="spSeconds" class="seconds"></span>
                        <div class="smalltext">Seconds</div>
                    </div>
                </div>
                <asp:HiddenField ID="hdfCounterDate" runat="server" Value="" />
                <!--updated by the admin yyyy-mm-dd-->
                <asp:HiddenField ID="hdfCounterFinishTitle" runat="server" Value="" />
                <asp:HiddenField ID="hdfCounterTitle" runat="server" Value="" />
                <script src="Default/CountDown.js" type="text/javascript"></script>
            </div>
            <br />
            <!--Islamic Quotes-->
            <div class=" row justify-content-center">
                <div class="col-4 col-sm-5 col-xl-4 p-0 slideshow-container">
                    <h2 class="p-2" style="background-color: #256297; color: white; text-align: center">Islamic Quotes</h2>
                    <div class="mySlides">
                        <q>Don't ruin your happiness with worry, and don't ruin your mind with pessimism. Don't ruin your success with deception and don't ruin the optimism of others by destroying it. Don't ruin your day by looking back at yesterday</q>
                        <p class="author">- Ibn-Al-Qayyim (R.A)</p>
                    </div>

                    <div class="mySlides">
                        <q>I am amazed by the believer. Verily, Allah does not decree anything for the believer except what is good for him. </q>
                        <p class="author">- Ibn Al-Qayyim (R.A)</p>
                    </div>

                    <div class="mySlides">
                        <q>A person does not have an understanding of the religion of Islam until he thinks of a hardship as being a blessing, and comfort and luxury as being a tribulation.</q>
                        <p class="author">– Ibn Al-Qayyim (R.A)</p>
                    </div>

                    <div class="mySlides">
                        <q>Don't depend too much on anyone in this world becayse even your own shadow leaves you when you are in the dark.</q>
                        <p class="author">– Ibn Taymiyyah (R.A)</p>
                    </div>

                    <div class="mySlides">
                        <q>Know that the happiest people are those who are stringest in their love of God.</q>
                        <p class="author">– Imaam Al-Ghazali</p>
                    </div>
                    <div class="mySlides">
                        <q>A person's tongue can give you the taste of his heart.</q>
                        <p class="author">– Ibn Al-Qayyim</p>
                    </div>
                    <div class="mySlides">
                        <q>Do not be fooled by the one who recites the Quran. His recitation is but speech, but look to those who act according to it.</q>
                        <p class="author">– Hazrat Umar ibn al-Khattab (R.A)</p>
                    </div>
                    <!-- Next/prev buttons -->
                    <a class="prev pl-3 pr-2 m" onclick="plusSlides(-1)">❮</a>
                    <a class="next pl-2 pr-3" onclick="plusSlides(1)">❯</a>


                    <!-- Dots/bullets/indicators -->
                    <div class="dot-container" style="position: static">
                        <%--m-0 col-lg-4 ml-lg-5--%>
                        <span class="dot" onclick="currentSlide(1)"></span>
                        <span class="dot" onclick="currentSlide(2)"></span>
                        <span class="dot" onclick="currentSlide(3)"></span>
                        <span class="dot" onclick="currentSlide(4)"></span>
                        <span class="dot" onclick="currentSlide(5)"></span>
                        <span class="dot" onclick="currentSlide(6)"></span>
                        <span class="dot" onclick="currentSlide(7)"></span>
                    </div>
                    <script src="Zakaah/slideshow.js"></script>
                </div>
            </div>
            <br />
            <!--RSS Feed-->
            <div class="row justify-content-center">
                <div class="col-10">
                    <h2 class="p-2 col" style="font-family: Arial; background-color: #256297; color:white; text-align: center" runat="server" id="H2">Islamic World News</h2> 
                    <div style="max-height: 350px; overflow: auto" class="col position-static container pre-scrollable">
                        <asp:GridView ID="gvRss" runat="server" AutoGenerateColumns="false" ShowHeader="false" Width="100%">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                            <table style="width:100%; border:none; border-color:#256297" cellpadding:0; cellspacing:5>
                                            <tr>
                                                <td>
                                                    <h3 style="color: #3F84C1"><%#Eval("Title") %></h3>
                                                </td>
                                                <td>
                                                    <%#Eval("PublishDate") %>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <hr />
                                                    <%#Eval("Description") %>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td style="text-align:right">
                                                    <a href='<%#Eval("Link") %>' target="_blank">Read More...</a>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
            <br />
            <!--Calendar-->
        </div>                       
            
    </form>
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
        <script src="Default/Default.js" type="text/javascript"></script>
        <script src="Default/DefaultJq.js"></script>
    </body>
</html>