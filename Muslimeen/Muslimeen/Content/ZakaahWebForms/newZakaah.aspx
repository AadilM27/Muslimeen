<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="newZakaah.aspx.cs" Inherits="Muslimeen.Content.newZakaah" %>

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
        
  
    <title>MyMuslimeen -Zakaah</title>
    <link rel="icon" href="/Login/LogIn_Bootstrap/muslimeen.ico"/>
    <link href="../../Login/LogIn_Bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="Default/css/Default.css" rel="stylesheet" />
    <link href="../Zakaah/css/newZakaah.css" rel="stylesheet" />
</head>
    <body style="background-color:white">
        
        <form id="newZakaah" runat="server" class="">
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
                                <asp:Button runat="server" Text="Go" CssClass="topnav search-btn form-control form-control-sm" />
                            </li>
                            <li class=" nav-item mr-2">
                            <asp:Button runat="server" Text="Login" ID="btnLogin" CssClass="topnav btn btn-sm btn-outline-light" OnClick="btnLogin_Click" />
                            </li>
                            <li class="nav-item mr-2">
                            <asp:Button runat="server" Text="Register" ID="btnRegister" CssClass=" topnav btn btn-sm btn-outline-light" OnClick="btnRegister_Click" />
                            </li>
                        </ul>
                    </div>
                    <div class="row">
                        <ul class="col navbar-nav flex-row ml-4 mb-0 mt-0 pt-2 justify-content-end">
                            <li><asp:HyperLink ToolTip="Edit user profile" runat="server" ID="hplUserProfile" NavigateUrl="~/Content/ProfileEditer.aspx" CssClass="nav-item mb-0 mr-3 user"></asp:HyperLink></li>
                        </ul>
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
                            <li class="nav-item navbarText navbaritems">
                                <asp:Button runat="server" ID="btnMyMuslimeen" Text="MyMuslimeen"  CssClass=" btn btn-link nav-item navText"/>
                            </li><li class="NavDevider">|</li><!--deviders-->
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

        <div class="content" id="content"><!--add content here -->
           
        <div class="zakaah-content" style="position:static;">
            <nav class="navbar navbar-expand-sm navbar-dark" style="position:static; background-color:#256297;">
              <a class="navbar-brand navt " href="newZakaah.aspx" >Zakaah</a>
              <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#collapsibleNavbar">
                <span class="navbar-toggler-icon"></span>
              </button>
              <div class="collapse navbar-collapse" id="collapsibleNavbar">
                <ul class="navbar-nav">
                  <li class="nav-item">
                    <a class="nav-link" href="ZakaahCalculator.aspx">Calculator</a>
                  </li>
                  <li class="nav-item">
                    <a class="nav-link" href="ZakaahFacts.aspx">Gallery</a>
                  </li>
                  <li class="nav-item">
                    <a class="nav-link" href="ZakaahOrganizations.aspx">Organizations</a>
                  </li>    
                </ul>
              </div>  
            </nav>

                    <div class="container" style="margin-top:10px; position:static;">
                      <div class="row" style="position:static;right:50px">
                          <div class="col-lg-8" style="position:static;">
                              <button id="btnWhatIsZakaah" class="collapsible" style="background-color:#256297;width:100%">What is Zakaah or Zakat?</button>
                    <div class="content2">
                        <br />
                        <asp:Label ID="LblWhatIsZakaah" runat="server"></asp:Label>
                    </div>
                    <button class="collapsible"  style="background-color:#256297;width:100%">Conditions of Zakaah</button>
                    <div class="content2">
                        <br />
                      <h2>Conditions of Zakat</h2>
                          <iframe width="560" height="315"  src="https://www.youtube.com/embed/kEon0omN5SA" frameborder="0" allow="autoplay; encrypted-media" allowfullscreen>
                          </iframe>
                        <asp:Label ID="LblConditions" runat="server" Text=""></asp:Label>
                     </div>
                    <button class="collapsible" style="background-color:#256297;width:100%" >Cautions of Zakaah</button>
                    <div class="content2">
                        <asp:Label ID="LblCaution" runat="server" Text=""></asp:Label>
                                          </div>
                    <button class="collapsible" style="background-color:#256297;width:100%" >To whom is Zakaah permissible?</button>
                    <div class="content2">
                        <asp:Label ID="LblPermissble" runat="server" Text=""></asp:Label>
                    </div>
                     <button class="collapsible" style="background-color:#256297;width:100%" >Assets Of Zakaah</button>
                    <div class="content2">
                        <asp:Label ID="LblAssets" runat="server" Text=""></asp:Label>
                    </div>
                     <button class="collapsible" style="background-color:#256297;width:100%" >To whom is Zakaah Applicable?</button>
                    <div class="content2">
                        <asp:Label ID="LblApplicable" runat="server" Text=""></asp:Label>
                    </div>
                     <button class="collapsible" style="background-color:#256297;width:100%" >Calculation of Zakaah?</button>
                    <div class="content2">
                        <asp:Label ID="LblCalculations" runat="server" Text=""></asp:Label>
                    </div>
                              
                    </div>
                     <script src="../Zakaah/newZakaah.js"></script>
                    <div class="col-lg-4" style="position:static;">
                       <!---javascript code to translate language--->
                        <p>Translate this page:</p>
                       <div id="google_translate_element"></div>

                      <script type="text/javascript">
                          function googleTranslateElementInit()
                          {
                            new google.translate.TranslateElement({pageLanguage: 'en'}, 'google_translate_element');
                          }
                     </script>
                     <script type="text/javascript" src="//translate.google.com/translate_a/element.js?cb=googleTranslateElementInit"></script>
                    <!---end of javascript code--->
                     <h2 style="color:#256297">Zakaah Facts</h2>
                    <img src="../Zakaah/ZakaahPics/alms.jpg" />
                    <div class="rightcolumn">
                    <div class="card" style="position:static">
                    

                    <div style="height:50px;width:40px;">
                     
                    </div>
                    <p>Some text about me in culpa qui officia deserunt mollit anim..</p>
                    </div>
                    <div class="card" style="position:static">
                     <h3>Popular Post</h3>
                      <div class="fakeimg" style="position:static">Image</div><br />
                      <div class="fakeimg" style="position:static">Image</div><br />
                      <div class="fakeimg" style="position:static">Image</div>
                    </div>
                    <div class="card"style="position:static" >
                     <h3>Follow Me</h3>
                     <p>Some text..</p>
                    </div>
                    </div>
                        <br />
                       
                          <p>Some text about me in culpa qui officia deserunt mollit anim..</p>
                          <h3>Some Links</h3>
                          <p>Lorem ipsum dolor sit ame.</p>
                          <ul class="nav nav-pills flex-column">
                            <li class="nav-item">
                              <a class="nav-link active" href="#">Active</a>
                            </li>
                            <li class="nav-item">
                              <a class="nav-link" href="#">Link</a>
                            </li>
                            <li class="nav-item">
                              <a class="nav-link" href="#">Link</a>
                            </li>
                            <li class="nav-item">
                              <a class="nav-link disabled" href="#">Disabled</a>
                            </li>
                          </ul>
                          <hr class="d-sm-none" />
                        </div>
    
                      </div>
                    </div>
           
            
             
                   </div>     
                  </div>

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
        <script src="../Default/Default.js"></script>
    </body>
</html>
