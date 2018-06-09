<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZakaahGallery.aspx.cs" Inherits="Muslimeen.Content.ZakaahWebForms.ZakaahGallery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
    <meta charset="utf-8"/>
	<meta http-equiv="X-UA-Compatible" content="IE=edge"/>
	<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>

    <title>MyMuslimeen - Calculator</title>
     <link rel="icon" href="../../Login/LogIn_Bootstrap/muslimeen.ico" />
     <link href="../../Login/LogIn_Bootstrap/css/bootstrap.min.css" rel="stylesheet" />
     <link href="../Default/css/Default.css" rel="stylesheet" />
        <link href="../Zakaah/css/Gallery.css" rel="stylesheet" />
</head>
    <body style="background-color:white">
        <form id="frmScholar" runat="server" class=" ">   
            <header >
                <nav class="navFixed">
                    <div class="row align-self-end">
                        <ul class=" col-7 navbar-nav flex-row justify-content-start">
                            <asp:HiddenField runat="server" ID="hfAdjustDate" Value="-2" /> <!--Need to get value from DB let admin adjust this -->
                            <li class="nav-item ml-4 mr-0 mb-0 pt-2"> <p class="IslamicDate mb-0" id="lstIslamicDate"></p></li>
                            <script src="../Default/DatesEnglishHijri.js"></script>
                        </ul>
                        <ul class="col-5 navbar-nav flex-row justify-content-end">
                            <li class="nav-item ml-0 mr-0">
                            <asp:TextBox ID="txtSearch" TextMode="Search" runat="server"  class=" search-box form-control form-control-sm" autocomplete="off" placeholder="Search"></asp:TextBox>
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
                        </ul> <!---->
                    </div>
                    <div class="row" runat="server" id="divUserProfile" >
                        <div class="col navbar-nav flex-row ml-4 mb-0 mt-0 pt-2 justify-content-end">
                            <asp:HyperLink ID="hplUserProfile" ToolTip="Edit user profile" runat="server" NavigateUrl="~/Content/ProfileEditer.aspx" CssClass="nav-item mb-0 mr-1 ml-1 user">
                            </asp:HyperLink><asp:Image style="height:15px; width:15px;" runat="server" id="imgEditProfile" CssClass="mt-1 mr-3" ImageUrl="~/Content/Default/icons/EditProfile.png"/>
                        </div>
                    </div>
                </nav>
                <div id="navbar" class="navbar navbar-expand flex-column navv flex-md-row" style="box-shadow: 0 0 0 0.1rem rgba(0, 123, 255, 0.50);">
                    <div class=" text-center">
                        <asp:Image runat="server" CssClass="mb-0 ml-0" src="/Login/LogIn_Bootstrap\logo.png" width="185" height="110"/>
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
                        </ul>
                    </div>
                </div>
            </header>
            </form>
        <div class="content" id="content" style="background-color:white"><!--add content here -->
            <div class="zakaah-content" style="position:static;">
            <nav class="navbar navbar-expand-sm navbar-dark" style="position:static; background-color:#256297;">
              <a class="navbar-brand navt " href="newZakaah.aspx" >Zakaah</a>
              <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#collapsibleNavbar">
                <span class="navbar-toggler-icon"></span>
              </button>
              <div class="collapse navbar-collapse" id="collapsibleNavbar">
                <ul class="navbar-nav">
                  <li class="nav-item">
                    <a class="navbar-brand navt" href="ZakaahCalculator.aspx">Calculator</a>
                  </li>
                  <li class="nav-item">
                    <a class="navbar-brand navt" href="ZakaahFacts.aspx">Gallery</a>
                  </li>
                  <li class="nav-item">
                    <a class="navbar-brand navt" href="ZakaahOrganizations.aspx">Organizations</a>
                  </li>    
                </ul>
              </div>  
            </nav>

                    <div class="container" style="margin-top:10px; position:static;">
                    <div class="row" style="position:static;right:50px">
                    <div class="col-lg-12" style="position:static;">
                             
                    <div style="text-align:center;color:white;background-color:#256297;font-size:20px">
                    <strong >ZAKAAT GALLERY</strong>
                    </div>
                    <br />
                    <!-- MAIN (Center website) -->
                    <div class="main">
                    <div id="myBtnContainer">
                      <button class="btns active" onclick="filterSelection('all')"> Show all</button>
                      <button class="btns" onclick="filterSelection('Organizations')"> Zakaat Organization</button>
                      <button class="btns" onclick="filterSelection('cars')">alms giving</button>
                      <button class="btns" onclick="filterSelection('people')"> People</button>
                    </div>

                    <!-- Portfolio Gallery Grid -->
                    <div class="row">
                      <div class="column Organizations">
                        <div class="content">
                          <img src="/w3images/mountains.jpg" alt="Mountains" style="width:100%" />
                          <h4>Mountains</h4>
                          <p>Lorem ipsum dolor..</p>
                        </div>
                      </div>
                      <div class="column Organizations">
                        <div class="content">
                        <img src="/w3images/lights.jpg" alt="Lights" style="width:100%" />
                          <h4>Lights</h4>
                          <p>Lorem ipsum dolor..</p>
                        </div>
                      </div>
                      <div class="column Organizations">
                        <div class="content">
                        <img src="/w3images/nature.jpg" alt="Nature" style="width:100%" />
                          <h4>Forest</h4>
                          <p>Lorem ipsum dolor..</p>
                        </div>
                      </div>
  
                      <div class="column cars">
                        <div class="content">
                          <img src="/w3images/cars1.jpg" alt="Car" style="width:100%" />
                          <h4>Retro</h4>
                          <p>Lorem ipsum dolor..</p>
                        </div>
                      </div>
                      <div class="column cars">
                        <div class="content">
                        <img src="/w3images/cars2.jpg" alt="Car" style="width:100%" />
                          <h4>Fast</h4>
                          <p>Lorem ipsum dolor..</p>
                        </div>
                      </div>
                      <div class="column cars">
                        <div class="content">
                        <img src="/w3images/cars3.jpg" alt="Car" style="width:100%" />
                          <h4>Classic</h4>
                          <p>Lorem ipsum dolor..</p>
                        </div>
                      </div>

                      <div class="column people">
                        <div class="content">
                          <img src="/w3images/people1.jpg" alt="Car" style="width:100%" />
                          <h4>Girl</h4>
                          <p>Lorem ipsum dolor..</p>
                        </div>
                      </div>
                      <div class="column people">
                        <div class="content">
                        <img src="/w3images/people2.jpg" alt="Car" style="width:100%" />
                          <h4>Man</h4>
                          <p>Lorem ipsum dolor..</p>
                        </div>
                      </div>
                      <div class="column people">
                        <div class="content">
                        <img src="/w3images/people3.jpg" alt="Car" style="width:100%" />
                          <h4>Woman</h4>
                          <p>Lorem ipsum dolor..</p>
                        </div>
                      </div>
                    <!-- END GRID -->
                    </div>

                    <!-- END MAIN -->
                    </div>

                        <script src="../Zakaah/ZakaahGallery.js"></script>
                    </div>                
                            
                </div>
                </div>
                </div>
                </div>
              
     
   
              <div class="footerr"> <!--End of content, start of footer-->
                <div class="row">
                    <div class="col text-center position-static">
                       <h6>Content</h6>
                        <ul class="navbar-nav">
                           <li class="nav-item">
                               <a class="footerr-text" href="Default.aspx">Home</a>
                           </li>
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
                               <a class="footerr-text" href="Zakaah.aspx">Zakaah</a>
                           </li>
                        </ul>
                    </div>
                    <div class="col  text-center position-static">
                        <h6>About us</h6>
                        <ul class="navbar-nav">
                            <li class="nav-item">
                                <a class="footerr-text" href="#">Content</a>
                            </li>
                            <li class="nav-item">
                                <a class="footerr-text" href="#">Content</a>
                            </li>
                            <li class="nav-item">
                                <a class="footerr-text" href="#">Content</a>
                            </li>
                        </ul>
                    </div>
                    <div class="col  text-center position-static">
                        <h6>Contact us</h6>
                        <ul class="navbar-nav">
                            <li class="nav-item">
                                <a class="footerr-text" href="#">Content</a>
                            </li>
                            <li class="nav-item">
                                <a class="footerr-text" href="#">Content</a>
                            </li>
                            <li class="nav-item">
                                <a class="footerr-text" href="#">Content</a>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        <script src="../Default/Default.js"></script>
    </body>
        <script src="../Default/Default.js"></script>

</html>
