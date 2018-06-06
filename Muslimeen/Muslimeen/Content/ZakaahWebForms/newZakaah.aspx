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
        
  <style>
  * {
    box-sizing: border-box;
}



/* Center website */
.main {
    max-width: 1000px;
    margin: auto;
}

h1 {
    font-size: 50px;
    word-break: break-all;
}

.row {
    margin: 8px -16px;
}

/* Add padding BETWEEN each column */
.row,
.row > .column {
    padding: 8px;
}

/* Create four equal columns that floats next to each other */
.column {
    float: left;
    width: 25%;
}

/* Clear floats after rows */ 
.row:after {
    content: "";
    display: table;
    clear: both;
}

/* Content */
.content {
    background-color: white;
    padding: 10px;
}

/* Responsive layout - makes a two column-layout instead of four columns */
@media screen and (max-width: 900px) {
    .column {
        width: 50%;
    }
}

/* Responsive layout - makes the two columns stack on top of each other instead of next to each other */
@media screen and (max-width: 600px) {
    .column {
        width: 100%;
    }
}
      .fakeimg {
      height: 200px;
      background: #aaa;
  }
  .collapsible {
    background-color: #777;
    color: white;
    cursor: pointer;
    padding: 18px;
    width:80%;
    border: none;
    text-align: left;
    outline: none;
    font-size: 15px;
    
    
}

.active, .collapsible:hover {
    background-color: #555;
}

.content2 {
    padding: 0 18px;
    background-color: #f1f1f1;
}
</style>
    <title>MyMuslimeen -Zakaah</title>
    <link rel="icon" href="/Login/LogIn_Bootstrap/muslimeen.ico"/>
    <link href="../Login/LogIn_Bootstrap/css/bootstrap.min.css" rel="stylesheet" />
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
                            <asp:Button runat="server" Text="Register" ID="btnRegister" CssClass="topnav btn btn-sm btn-outline-light" OnClick="btnRegister_Click" />
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
           
        <div class="zakaah-content">
            <nav class="navbar navbar-expand-sm navbar-dark " style="background-color:#256297;">
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

                    <div class="container" style="margin-top:10px">
                      <div class="row" style="position:relative;right:50px">
                          <div class="col-md-8">
                              <button class="collapsible" style="background-color:#256297;width:100%">What is Zakaah or Zakat?</button>
                    <div class="content2">
                        <br />
                          <p>Some text..</p>
                          <p>Sunt in culpa qui officia deserunt mollit anim id est laborum consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco.</p>
                    </div>
                    <button class="collapsible"  style="background-color:#256297;width:100%">Conditions of Zakaah</button>
                    <div class="content2">
                      <h2>Conditions of Zakat</h2>
                          <iframe width="560" height="315"  src="https://www.youtube.com/embed/kEon0omN5SA" frameborder="0" allow="autoplay; encrypted-media" allowfullscreen>
                          </iframe>
                          <p>Some text..</p>
                          <p>Sunt in culpa qui officia deserunt mollit anim id est laborum consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco.</p>
                    </div>
                    <button class="collapsible" style="background-color:#256297;width:100%" >Cautions of Zakaah</button>
                    <div class="content2">
                    <p><strong>Nasihah (Advice): Caution when giving Zakaat:</strong><br />
                    Ramadhan, the month of fasting, is also the time when many Muslims calculate and discharge their Zakaat. One of the fundamentals of Zakaat is to discharge Zakaat to eligible recipients.</p>
                    <p>It is the onus of the individual to verify the Zakaat eligibility of the recipient. If verification is not done and the person was not eligible for Zakaat, then that Zakaat has to be repaid. </p>
                    <p>It is of great concern that many individuals hand over their Zakaat to beggars standing at traffic lights. Many of these individuals are “professional” beggars who make so much money that it is compulsory on them to pay Zakaat let alone receive it.<br />
                    Individuals experiencing difficulty in discharging their Zakaat may forward their Zakaat to the Jamiat and have their Zakaat discharged to eligible recipients verified by Ulama.</p>
                      </div>
                    <button class="collapsible" style="background-color:#256297;width:100%" >To whom is Zakaah permissible?</button>
                    <div class="content2">
                      <h2> Upon who is Zakaat fard(compulsory)?</h2> 

                    <p>A.  Zakaat is Fard on a Muslim male or female who is mature (Baaligh) and sane. He/she must also be the owner of Nisaab. Nisaab is the minimum amount of wealth which makes a person liable for Zakaat. If one is the owner of Nisaab after one lunar year, then Zakaat will be Fardh upon him. The Zakaat should be paid annually on the Islamic date of a lunar year.</p>
                    </div>

                              <!----javascript code for collapsible-->
                           <script>
                           var coll = document.getElementsByClassName("collapsible");
                           var i;

                               for (i = 0; i < coll.length; i++)
                               {
                                   coll[i].addEventListener("click", function ()
                                   {
                                    this.classList.toggle("active");
                                    var content = this.nextElementSibling;
                                       if (content.style.display === "block")
                                       {
                                            content.style.display = "none";
                                       }
                                       else
                                       {
                                            content.style.display = "block";
                                       }
                                });
                            }
                               </script><!--end of javascript code--->
                              </div>
   
                          <div class="col-md-4">
                          <h2>About Me</h2>
                          <h5>Photo of me:</h5>
                          <!-- MAIN (Center website) -->
                    <div class="main">

                    <h2>MYLOGO.COM</h2>
                    <hr />

                    <h3>PORTFOLIO</h3>
                    <p>Resize the browser window to see the responsive effect.</p>

                    <!-- Portfolio Gallery Grid -->
                    <div class="row">
                      <div class="column">
                        <div class="content2">
                          <img src="../Zakaah/ZakaahPics/Zakat-Image.jpg" alt="Mountains" style="width:100%;" />
                          <h3>My Work</h3>
                          <p>Lorem ipsum dolor sit amet, tempor prodesset eos no. Temporibus necessitatibus sea ei, at tantas oporteat nam. Lorem ipsum dolor sit amet, tempor prodesset eos no.</p>
                        </div>
                      </div>
                      <div class="column">
                        <div class="content2">
                        <img src="/w3images/lights.jpg" alt="Lights" style="width:100%" />
                          <h3>My Work</h3>
                          <p>Lorem ipsum dolor sit amet, tempor prodesset eos no. Temporibus necessitatibus sea ei, at tantas oporteat nam. Lorem ipsum dolor sit amet, tempor prodesset eos no.</p>
                        </div>
                      </div>
                      <div class="column">
                        <div class="content2">
                        <img src="/w3images/nature.jpg" alt="Nature" style="width:100%" />
                          <h3>My Work</h3>
                          <p>Lorem ipsum dolor sit amet, tempor prodesset eos no. Temporibus necessitatibus sea ei, at tantas oporteat nam. Lorem ipsum dolor sit amet, tempor prodesset eos no.</p>
                        </div>
                      </div>
                      <div class="column">
                        <div class="content">
                        <img src="/w3images/mountains.jpg" alt="Mountains" style="width:100%" />
                          <h3>My Work</h3>
                          <p>Lorem ipsum dolor sit amet, tempor prodesset eos no. Temporibus necessitatibus sea ei, at tantas oporteat nam. Lorem ipsum dolor sit amet, tempor prodesset eos no.</p>
                        </div>
                      </div>
                    <!-- END GRID -->
                    </div>

                    <div class="content2">
                      <img src="/w3images/p3.jpg" alt="Bear" style="width:100%" />
                      <h3>Some Other Work</h3>
                      <p>Lorem ipsum dolor sit amet, tempor prodesset eos no. Temporibus necessitatibus sea ei, at tantas oporteat nam. Lorem ipsum dolor sit amet, tempor prodesset eos no.</p>
                      <p>Lorem ipsum dolor sit amet, tempor prodesset eos no. Temporibus necessitatibus sea ei, at tantas oporteat nam. Lorem ipsum dolor sit amet, tempor prodesset eos no.</p>
                    </div>

                    <!-- END MAIN -->
                    </div>

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
