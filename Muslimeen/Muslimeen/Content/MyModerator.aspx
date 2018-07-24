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
                
                <div class="row m-0 divContainers p-2">
                    <div class=" col-3 position-static bg-light mr-2 p-2 "> <!--contains the buttons-->
                        <nav class="nav nav-pills flex-column pl-2">
                            <p class="navbar-brand text-center text-uppercase font-weight-bold">Admin Tasks:</p>
                            <asp:Button runat="server" ID="btn" OnClick="btnViewPendingSch_Click" CssClass=" mb-2 btn taskBtn" Text="View Pending Scholars"/>
                            <asp:Button runat="server" ID="btnViewPendingMod" CssClass=" mb-2 btn taskBtn" OnClick="btnViewPendingMod_Click" Text="View Pending Moderators"/>
                            <asp:Button runat="server" ID="btnViewPendingArticles" CssClass=" mb-2 btn taskBtn" OnClick="btnViewPendingArticles_Click" Text="View Pending Articles"/>
                            <asp:Button runat="server" ID="btnUpdateIslmDate" CssClass=" mb-2  btn taskBtn" OnClick="btnUpdateIslmDate_Click" Text="Update Islamic Date"/>
                        </nav>
                    </div>
                    <div class=" col-4 p-3 bg-light position-static" runat="server" id="divViewPendingSch"> <!--Contains the List of items-->
                        <div class="row position-static list-group justify-content-end">
                            <asp:Repeater ID="rptViewPendingSch" runat="server" OnItemCommand="rptViewPendingSch_ItemCommand">
                                <HeaderTemplate>
                                </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnShow" EnableViewState="true"  CommandArgument='<%#Eval("MemberID") %>' CssClass=" position-static align-self-center list-group-item list-group-item-action  p-1 m-0" runat="server" OnClick="btnShow_Click"><img src="MyAdmin/icons/PendingReg.png" class=" img-thumbnail" style="width:32px; height:32px;" /><b>&nbsp;&nbsp;User&nbsp;Name: </b><%#Eval("MemberID")%><br /><b style="font-size:smaller;">&emsp;&emsp;&emsp;Date Registered: </b><%#Eval("ActivationDate")%></asp:LinkButton>
                                    </ItemTemplate>
                                <FooterTemplate>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                    <div class="col-4 p-3 bg-light position-static" runat="server" id="divViewPendingArt"> <!--Contains the List of items-->
                        <div class="row position-static list-group justify-content-end">
                            <asp:Repeater ID="rptViewPendingArticles" runat="server">
                                <HeaderTemplate>
                                </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnShowArt" EnableViewState="true"  CommandArgument='<%#Eval("ArticleID")%>' CssClass=" position-static list-group-item list-group-item-action  p-1 m-0" runat="server" OnClick="btnShowArt_Click" ><b style="font-size:smaller;">Article Title: </b><%#Eval("ArticleTitle")%><br /></b> <b style="font-size:smaller;">Date Created: </b><%#Eval("DateCreated")%></asp:LinkButton>
                                    </ItemTemplate>
                                <FooterTemplate>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                    <div runat="server" id="divDisplaySch" class="bg-light position-static col-4 p-3 divContainers">
                        <asp:HiddenField runat="server" ID="hdfSchId" Value=""/>
                            <div class="head-div mb-0 p-2">
                                <p class="text-uppercase font-weight-bold">Member Details:</p>
                            </div>
                            <div class="body-div mt-0 p-2">
                                <div class="row position-static">
                                    <div class="col position-static"><b>Member  ID:</b></div><div class="col position-static"><label runat ="server" id="lblMemberID"></label></div>
                                </div>
                                <div class="row position-static">
                                    <div  class="col position-static"><b>Member Name:</b></div><div class="col position-static"><label runat="server" id="lblMemberName"></label></div>
                                </div>
                                <div class="row position-static">
                                    <div  class="col position-static"><b>Member Lastname:</b></div><div class="col position-static"><label runat="server" id="lblMemberLastName"></label></div>
                                </div>
                                <div class="row position-static">
                                    <div  class="col position-static"><b>Member DOB:</b></div><div class="col position-static"><label runat="server" id="lblMemberDOB"></label></div>
                                </div>
                                <div class="row position-static">
                                    <div  class="col position-static"><b>Member Type:</b></div><div class="col position-static"><label runat="server" id="lblMemberType"></label></div>
                                </div>
                                <div class="row position-static">
                                    <div class="col position-static"><b>Status:</b></div><div class="col position-static"><label runat="server" id="lblActiveTypeID"></label></div>
                                </div>
                                <div class="row position-static">
                                    <div class="col position-static"><b>Email Address:</b></div><div class="col position-static"><label runat="server" id="lblEmail"></label></div>
                                </div>
                                <div class="row position-static">
                                    <div class="col position-static"><b>Contact No.</b></div><div class="col position-static"><label runat="server" id="lblContactNo"></label></div>
                                </div>
                                <div class="row position-static">
                                    <div class="col position-static"><b>Activation Expiry:</b></div><div class="col position-static"><label runat="server" id="lblActivationExpiry"></label></div>
                                </div>
                                <div class="row position-static">
                                    <div class="col position-static"><b>Activation Date:</b></div><div class="col position-static"><label runat="server" id="lblActivationDate"></label></div>
                                </div>
                                <div class="row position-static justify-content-center align-content-center mt-4">
                                        <asp:Button CssClass=" topnav btn btn-sm btn-outline-light mr-3" runat="server" ID="btnAcceptReg" Text="Accept Registration" OnClick="btnAcceptReg_Click" />
                                        <asp:Button CssClass=" topnav btn-dark btn btn-sm btn-outline-light mr-3" runat="server" ID="btnRejectReg" Text="Reject Registration" OnClick="btnRejectReg_Click" />
                                </div>
                            </div>
                        </div>
                        <div class=" col bg-light position-static col-4 p-3 divContainers" runat="server" id="divViewArt" >
                            <div class="row" style="overflow:scroll;">
                                <div class="row ml-4" >
                                    <label runat="server" id="lblArticleTitle"></label>
                                </div>
                                <div class="row ml-4 p-2">
                                    <label runat="server" id="lblArticleContent"></label>
                                </div>
                            </div>
                            <div class="row position-static justify-content-center align-content-center mt-4">
                                <asp:Button CssClass=" topnav btn btn-sm btn-outline-light mr-3" runat="server" ID="btnAccept" Text="Accept Article" OnClick="btnAccept_Click" />
                                <asp:Button CssClass=" topnav btn-dark btn btn-sm btn-outline-light mr-3" runat="server" ID="Button2" Text="Reject Article" OnClick="Button2_Click" />
                                <asp:TextBox runat="server" CssClass=" form-control mt-3" id="txtRejectReason" OnTextChanged="txtRejectReason_TextChanged"></asp:TextBox>
                            </div>
                        </div>
                    <div class="bg-light position-static col-4 p-3 divContainers" runat="server" id="divUpdateIslmDate">
                        <p class="text-center text-uppercase font-weight-bold">Update Islamic Date:</p>
                        <div class=" row position-static">
                            <label class="col">Islamic Date:</label>
                            <asp:TextBox runat="server" CssClass=" col form-control" ID="txtIslmDate" Placeholder="yyyy-M-dd"></asp:TextBox>
                            <asp:Button runat="server" CssClass="col form-control" ID="btnChngIslmDate" Text="Update Date" />
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
        <script src="../Default/Default.js"></script>
        <script src="../MyAdmin/js/MyAdmin.js"></script>
        <script src="../Default/DefaultJq.js"></script>
    </body>
</html>
