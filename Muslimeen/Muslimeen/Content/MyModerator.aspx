<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyModerator.aspx.cs" Inherits="Muslimeen.Content.MyModerator.MyModerator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
    <meta charset="utf-8"/>
	<meta http-equiv="X-UA-Compatible" content="IE=edge"/>
	<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>

    <title>MyMuslimeen - Home</title>
    <link rel="icon" href="../Login/LogIn_Bootstrap/muslimeen.ico"/>
    <link href="../Login/LogIn_Bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="MyModerator/css/MyModerator.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css" />
</head>
    <body>
        <asp:HyperLink ID="lnk1" runat="server" href="HelpPage.aspx"></asp:HyperLink>
        <form id="frmScholar" runat="server" class=" ">   
            <header >
                <nav class="navFixed">
                    <div class="row align-self-end">
                        <ul class=" col-7 navbar-nav flex-row justify-content-start">
                            <asp:HiddenField runat="server" ID="hfAdjustDate" Value="-2" /> <!--Need to get value from DB let admin adjust this -->
                            <li class="nav-item ml-4 mr-0 mb-0 pt-2"> <p class="IslamicDate mb-0" id="lstIslamicDate"></p></li>
                            <script src="Default/DatesEnglishHijri.js"></script>
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
                        </ul>
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
                        <asp:Image runat="server" CssClass="mb-0 ml-0" src="\Login\LogIn_Bootstrap\logo.png" width="185" height="110"/>
                        </div>
                    <div class="ml-2 navbar-nav-scroll align-self-end justify-content-start">
                        <ul class="navbar-nav row">
                            <li class="nav-item navbarText navbaritems">
                                <asp:Button runat="server" ID="btnHome" Text="Home"  CssClass=" btn btn-link nav-item navText" OnClick="btnHome_Click"/>
                            </li><li class="NavDevider">|</li><!--deviders-->
                            <li class="nav-item navbarText navbaritems" runat="server" id="liMyMusbtn">
                                <asp:Button runat="server" ID="btnMyMuslimeen" Text="MyMuslimeen"  CssClass=" btn btn-link nav-item navText" OnClick="btnMyMuslimeen_Click"/>
                            </li><li runat="server" id="liMyMusDivi" class="NavDevider">|</li><!--deviders-->
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
            <div class="content" id="content"><!--add content here -->
                <div class="row bg-light m-0 divContainers p-1 flex-nowrap">
                    <div class="side-bar p-0 basic-div-styling mr-1">
                        <!--contains the buttons-->
                        <div class="head-div text-center p-2">
                            <p class="text-uppercase m-0 font-weight-bold" style="font-size:20px">Moderator Tasks</p>
                        </div>
                        <nav class="nav flex-column pt-2 pb-2 pr-0">
                            <asp:Button runat="server" ToolTip="Pending Scholar Registrations." ID="btnViewPendingSch" OnClick="btnViewPendingSch_Click" CssClass="pl-2 btn mb-1 taskBtn" Text="View Pending Scholars" />
                            <asp:Button runat="server" ID="btnViewPendingArticles" CssClass=" pl-2 btn taskBtn mb-1" OnClick="btnViewPendingArticles_Click" Text="View Pending Articles" />
                            <p class="pl-2 btn taskBtn mb-1">View Reports &#11167;</p>
                                <%-- sub buttons of report button --%>
                                <asp:Button ID="BtnAcceptedScholars" CssClass=" pl-2 btn sub-taskBtn mb-1 " runat="server" Text="Accepted Scholars" OnClick="BtnAcceptedScholars_Click" />                                  
                                <asp:Button ID="btnRejectedScholars"  CssClass=" pl-2 btn sub-taskBtn mb-1" runat="server" Text="Rejected Scholars" OnClick="btnRejectedScholars_Click" />
                                <asp:Button ID="BtnAcceptedArticles" CssClass=" pl-2 btn sub-taskBtn mb-1"   runat ="server" Text="Accepted Articles" OnClick="BtnAcceptedArticles_Click" />
                                <asp:Button ID="BtnRejectedArticles" CssClass=" pl-2 btn sub-taskBtn mb-1"   runat ="server" Text="Rejected Articles" OnClick="BtnRejectedArticles_Click" />
                                <asp:Button ID="BtnMosqueReports" CssClass=" pl-2 btn sub-taskBtn mb-1"   runat ="server" Text="List of Mosques" OnClick="BtnMosqueReports_Click" />
                                <asp:Button ID="BtnEventReports" CssClass=" pl-2 btn sub-taskBtn mb-1"   runat ="server" Text="List of Events" OnClick="BtnEventReports_Click" />
                        </nav>
                    </div>
                    <div class=" position-static basic-div-styling p-0  w-100" >
                        <div runat="server" id="divTaskHead" class=" head-div text-center p-2 mb-1">
                            <h4> <asp:Label ID="LblHeading" runat="server" class=" p-0 m-0"></asp:Label></h4>
                        </div>
                        <div class="row p-0 m-0 right-bottom-div p-1 flex-nowrap justify-content-xl-start" >
                            <div class="col-6 col-xl-4 p-0 mr-1" runat="server" id="divViewPendingSch" style="position:static">
                                <!--Contains the List of items-->
                                <div class=" head-div-2 p-2 mb-1 text-left">
                                    <p class="m-0">Pending Registrations</p>
                                </div>
                                <div class="position-static p-1 lst-container" style="overflow-y:scroll;">
                                    <asp:Repeater ID="rptViewPendingSch" runat="server" OnItemCommand="rptViewPendingSch_ItemCommand">
                                        <HeaderTemplate>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnShow" CommandArgument='<%#Eval("MemberID") %>' CssClass="position-static lstBtn btn btn-block" runat="server" OnClick="btnShow_Click">
                                                    <div class="p-0 form-row m-0 position-static">
                                                        <div class="col-auto position-static">
                                                            <img src="MyAdmin/icons/PendingReg.png" class="" style="height:40px; width:35px;"/>
                                                        </div>
                                                        <div class=" col-auto position-static p-0">
                                                            <div class="">
                                                                <p style="font-size:small" class="p-0 m-0 text-truncate"><b>User&nbsp;Name: </b><%#Eval("MemberID")%><br/></p>
                                                            </div>
                                                                <hr class=" mr-4 m-0 p-0"/>
                                                            <div class="">
                                                                <p  style="font-size:smaller;" class="p-0 m-0 text-truncate"><b>Date Registered: </b><%#Eval("ActivationDate")%></p>
                                                            </div>
                                                        </div>
                                                    </div>
                                            </asp:LinkButton>
                                            <hr class="p-0 m-1" />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                            <div class="col-6 col-xl-4 p-0 mr-1" runat="server" id="divViewPendingArt" style="position:static">
                                <!--Contains the List of items-->
                                <div class=" head-div-2 p-2 mb-1 ">
                                    <p class="m-0">Pending Articles</p>
                                </div>
                                <div class="position-static p-1 lst-container" style="overflow-y:scroll;">
                                    <asp:Repeater ID="rptViewPendingArticles" runat="server">
                                        <HeaderTemplate>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnShowArt" CommandArgument='<%#Eval("ArticleID") %>' CssClass="position-static lstBtn btn btn-block" runat="server" OnClick="btnShowArt_Click">
                                                    <div class="p-0 form-row m-0 position-static">
                                                        <div class="col-auto position-static">
                                                            <img src="MyAdmin/icons/PendingReg.png" class="" style="height:40px; width:35px;"/>
                                                        </div>
                                                        <div class=" col-auto position-static p-0">
                                                            <div class="">
                                                                <p style="font-size:small" class="p-0 m-0 text-truncate"><b>User&nbsp;Name: </b><%#Eval("ArticleTitle")%><br/></p>
                                                            </div>
                                                                <hr class=" mr-4 m-0 p-0"/>
                                                            <div class="">
                                                                <p  style="font-size:smaller;" class="p-0 m-0 text-truncate"><b>Date Registered: </b><%#Eval("DateCreated")%></p>
                                                            </div>
                                                        </div>
                                                    </div>
                                            </asp:LinkButton>
                                            <hr class="p-0 m-1" />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                             <%-- Overlay for Scholar Registration List selection--%>
                            <div class="col-6 col-xl-4 text-nowrap" runat="server" id="divSchDetailsOverlay">
                                <div class="w-100 h-100 container text-center">
                                    <div class=" container h-25 mb-3"></div>
                                        <h6 class="card-title h-50 mt-5 pt-5"><img class="figure-img mr-2" src="MyAdmin/icons/outline_error_outline_black_18dp.png" />No Scholar registration selected.</h6>
                                    <div class=" container h-25"></div>
                                </div>
                            </div>
                            <div runat="server" id="divDisplaySch" class=" col-6 col-xl-4 flex-nowrap p-0" style="position:static">
                                <asp:HiddenField runat="server" ID="hdfSchId" Value="" />
                                <div class=" head-div-2 p-2 mb-0 text-left">
                                    <p class="m-0">Scholar Details:</p>
                                </div>
                                    <hr class="m-3 ml-3 mr-3 bg-secondary"/>  
                                     <div class="container text-nowrap" runat="server" id="divSchDetails">
                                        <div class="row mb-1 position-static">
                                            <div class="col position-static"><b>Member  ID:</b></div>
                                            <div class="col position-static text-truncate">
                                                <label class="m-0" runat="server" id="lblMemberID"></label>
                                            </div>
                                        </div>
                                        <div class="row mb-1 position-static">
                                            <div class="col position-static"><b>Member Name:</b></div>
                                            <div class="col position-static text-truncate">
                                                <label class="m-0" runat="server" id="lblMemberName"></label>
                                            </div>
                                        </div>
                                        <div class="row mb-1 position-static">
                                            <div class="col position-static"><b>Member Lastname:</b></div>
                                            <div class="col position-static text-truncate">
                                                <label class="m-0" runat="server" id="lblMemberLastName"></label>
                                            </div>
                                        </div>
                                        <div class="row mb-1 position-static">
                                            <div class="col position-static"><b>Member DOB:</b></div>
                                            <div class="col position-static text-truncate">
                                                <label class="m-0" runat="server" id="lblMemberDOB"></label>
                                            </div>
                                        </div>
                                        <div class="row mb-1 position-static">
                                            <div class="col position-static"><b>Member Type:</b></div>
                                            <div class="col position-static text-truncate">
                                                <label class="m-0" runat="server" id="lblMemberType"></label>
                                            </div>
                                        </div>
                                        <div class="row mb-1 position-static">
                                            <div class="col position-static"><b>Email Address:</b></div>
                                            <div class="col position-static text-truncate">
                                                <label class="m-0" runat="server" id="lblEmail"></label>
                                            </div>
                                        </div>
                                        <div class="row mb-1 position-static">
                                            <div class="col position-static"><b>Contact No.</b></div>
                                            <div class="col position-static text-truncate">
                                                <label class="m-0" runat="server" id="lblContactNo"></label>
                                            </div>
                                        </div>
                                        <div class="row mb-1 position-static">
                                            <div class="col position-static"><b>Activation Expiry:</b></div>
                                            <div class="col position-static text-truncate">
                                                <label class="m-0" runat="server" id="lblActivationExpiry"></label>
                                            </div>
                                        </div>
                                        <div class="row mb-1 position-static">
                                            <div class="col position-static"><b>Activation Date:</b></div>
                                            <div class="col position-static text-truncate">
                                                <label class="m-0" runat="server" id="lblActivationDate"></label>
                                            </div>
                                        </div>
                                        <div class="row mb-1 position-static">
                                            <div class="col position-static "><b>Qualification:</b></div>
                                            <div class="col position-static text-truncate">
                                                <label class="m-0" runat="server" id="lblScholarQual"></label>
                                            </div>
                                        </div>
                                    </div>
                                        <hr class="m-3 ml-3 mr-3 bg-secondary"/>
                                    <div class="container p-0 m-2 task-action">
                                        <h6 class="w-100 card-title card-header">
                                            <img class="figure-img mr-2 mb-1 " src="MyAdmin/icons/outline_warning_black_18dp.png" />Before accepting registration:</h6>
                                        <div class=" position-static m-0 card-body">
                                            <ul class="pl-1">
                                                <li><p class="mb-0" ><small class="card-text">The Qualification that the scholar claims to have must be verified</small></p></li>
                                                <li><p class="mb-0"><small class="card-text">Admins may contact the members by phone or email to set up interviews</small></p></li>
                                            </ul>
                                        </div>
                                       <div class="card-footer text-center position-static text-nowrap">
                                        <asp:Button CssClass=" topnav btn btn-sm btn-outline-light mr-2" runat="server" ID="btnAcceptReg" Text="Accept Registration" OnClick="btnAcceptReg_Click" />
                                        <asp:Button CssClass=" topnav btn btn-sm btn-outline-light mr-2" runat="server" ID="btnRejectReg" Text="Reject Registration" OnClick="btnRejectReg_Click" />
                                    </div>
                                  </div>
                                </div>
                            
                            <div class=" col-12 col-md-8 flex-nowrap p-0" runat="server" id="divViewArt" style="position:static">
                                 <div class=" head-div-2 p-2 mb-0 ">
                                    <p class="m-0">Article Details:</p>
                                </div>
                                <div class="" style="overflow-x:scroll;overflow-y:scroll;position:static">
                                    <div class="row ml-4" style="position:static">
                                        <label runat="server" id="lblArticleTitle"></label>
                                    </div>
                                    <div class="row ml-4 p-2" style="position:static">
                                        <label runat="server" id="lblArticleContent"></label>
                                    </div>
                                </div>
                                <div class="card-footer text-center position-static text-nowrap" style="position:static">
                                    <asp:Button CssClass=" topnav btn btn-sm btn-outline-light mr-2 " runat="server" ID="btnAccept" Text="Accept Article" OnClick="btnAccept_Click" />
                                    <asp:Button CssClass=" topnav btn btn-sm btn-outline-light mr-2 " runat="server" ID="Button2" Text="Reject Article" OnClick="Button2_Click" />
                                    <br />
                                    <br />
                                    <asp:Label ID="Label1" CssClass=" form-control-sm col main-txtb " ForeColor="#256297" runat="server" Text="Rejection Reason:"></asp:Label> <asp:TextBox runat="server" CssClass=" text-justify btn btn-sm  mr-2 position-static" ID="txtRejectReason" BorderColor="#256297" Width="50%" OnTextChanged="txtRejectReason_TextChanged" ></asp:TextBox>
                                    <br />
                                    <asp:Label ID="lblRejection" CssClass="align-content-center" ForeColor="Red" runat="server" Text=""></asp:Label>
                                </div>
                        </div>
                            <div runat="server" id="divDisplayReports" class=" col-12 col-xl-12 mw-100 p-0" style="position:static">
                                <div class=" head-div-2 p-2 mb-0 text-center ">
                                    <p class="m-0">Report</p>
                                </div>
                                <div class="m-0 p-0 pt-2 pl-2">
                                    <a runat="server" id="PDF" onserverclick="PDF_ServerClick"><img src="MyModerator/Adobe_PDF.png" /><small>Download as PDF</small></a>
                                    <hr class="m-0 mt-1 p-0" style="background-color:#0026ff; height:1px;" />
                                </div>
                                <div class=" col-12 col-xl-12 p-2" style="overflow-x:scroll;position:static">
                                    <asp:GridView ID="grdReports" RowStyle-Wrap="true" runat="server" style="position:static; font-size:smaller;" CellPadding="6" ForeColor="#333333" GridLines="none" >
                                        <AlternatingRowStyle BackColor="White" />
                                        <EditRowStyle BackColor="#2461BF" />
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#EFF3FB"  Wrap="true" />
                                        <SelectedRowStyle  BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                    </asp:GridView>
                                </div>
                            </div>  
                        </div>
                    </div>
                </div>
            </div>
            </form>
                <div class="footerr"> <!--End of content, start of footer-->
                    <div class="row bg-light">
                        <div class="col text-center position-static">
                           <h6>Content</h6>
                            <ul class="navbar-nav">
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
       
        <script src="Default/Default.js"></script>
        
        <script src="MyAdmin/js/MyAdmin.js"></script>
        <script src="Default/DefaultJq.js"></script>
    </body>
</html>
