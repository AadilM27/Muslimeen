<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyModerator.aspx.cs" Inherits="Muslimeen.Content.MyModerator.MyModerator" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
    <meta charset="utf-8"/>
	<meta http-equiv="X-UA-Compatible" content="IE=edge"/>
	<meta name="viewport" content="width=device-width, height=device-height, initial-scale=0.0"/>

    <title>MyMuslimeen - MyModerator</title>
    <link rel="icon" href="../Login/LogIn_Bootstrap/muslimeen.ico"/>
    <link href="../Login/LogIn_Bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="MyModerator/css/MyModerator.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css" />
        <link href="Zakaah/css/Slideshow.css" rel="stylesheet" />
</head>
    <body>
        <asp:HyperLink ID="lnk1" runat="server" href="HelpPage.aspx"></asp:HyperLink>
          <div id="divAlertPopup" runat="server" style="display:none;" class="container-fluid text-center p-2 m-0 w-100 alert alert-success visible">
                <label class="h6" id="lblAlertError"  runat="server" ></label>
        </div>
        <form id="frmScholar" runat="server" class=" ">   
            <header >
                <nav class="navFixed">
                    <div class="row align-self-end">
                        <ul class=" col-7 navbar-nav flex-row justify-content-start">
                            <asp:HiddenField runat="server" ID="hdfAdjustDate" Value="" /> <!--Need to get value from DB let admin adjust this -->
                            <li class="nav-item ml-4 mr-0 mb-0 pt-2"> <p class="IslamicDate mb-0" id="lstIslamicDate"></p></li>
                            <script src="Default/DatesEnglishHijri.js"></script>
                        </ul>
                        <ul class="col-5 navbar-nav flex-row justify-content-end">
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
                            <asp:HyperLink ID="hplUserProfile" ToolTip="Edit user profile" runat="server" NavigateUrl="ProfileEditer.aspx" CssClass="nav-item mb-0 mr-1 ml-1 user">
                            </asp:HyperLink><asp:Image style="height:15px; width:15px;" runat="server" id="imgEditProfile" CssClass="mt-1 mr-3" ImageUrl="Default/icons/EditProfile.png"/>
                        </div>
                    </div>
                </nav>
                <div id="navbar" class="navbar navbar-expand flex-column navv flex-md-row" style="box-shadow: 0 0 0 0.1rem rgba(0, 123, 255, 0.50);">
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
                            <li class="NavDevider">|</li>
                         <!--deviders-->
                        <li class="nav-item navbarText navbaritems">
                        <asp:LinkButton ID="LnkHelp" runat="server"  OnClick="btnHelp_Click" CssClass="nav-item navText btn-link btn" ToolTip="How this page works" ><%--CssClass="nav-item navText btn-link btn"--%>
                         Help<asp:Image runat="server" ID="ImgHelp" ImageUrl="MyMember/icons/helpIcon.png" style="height: 1.1em; width:1.1em;" /></asp:LinkButton>   
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
                             <p class="pl-2 btn taskBtn mb-1">My Mosque &#11167;</p>
                             <asp:Button runat="server" ToolTip="Go to the Home tab" ID="btnMosqueEvents" OnClick="btnMosqueEvents_Click" CssClass=" pl-2 btn sub-taskBtn mb-1 " Text="Events" />
                                <asp:Button runat="server" ToolTip="Go to the Home tab" ID="btnTodaysPrayerTime" OnClick="btnTodaysPrayerTime_Click" CssClass=" pl-2 btn sub-taskBtn mb-1 " Text="Todays Prayer Times" />

                            <asp:Button runat="server" ToolTip="Pending Scholar Registrations." ID="btnViewPendingSch" OnClick="btnViewPendingSch_Click" CssClass="pl-2 btn mb-1 taskBtn" Text="View Pending Scholars" />
                            <asp:Button runat="server" ID="btnViewPendingArticles" CssClass=" pl-2 btn taskBtn mb-1" OnClick="btnViewPendingArticles_Click" Text="View Pending Articles" />
                            <p class="pl-2 btn taskBtn mb-1">View Reports &#11167;</p>
                                <%-- sub buttons of report button --%>
                           
                                <asp:Button ID="BtnAcceptedScholars" CssClass=" pl-2 btn sub-taskBtn mb-1 " runat="server" Text="Accepted Scholars" OnClick="BtnAcceptedScholars_Click" />                                  
                                <asp:Button ID="btnRejectedScholars"  CssClass=" pl-2 btn sub-taskBtn mb-1" runat="server" Text="Rejected Scholars" OnClick="btnRejectedScholars_Click" />
                                <asp:Button ID="BtnAcceptedArticles" CssClass=" pl-2 btn sub-taskBtn mb-1"   runat ="server" Text="Accepted Articles" OnClick="BtnAcceptedArticles_Click" />
                                <asp:Button ID="BtnRejectedArticles" CssClass=" pl-2 btn sub-taskBtn mb-1"   runat ="server" Text="Rejected Articles" OnClick="BtnRejectedArticles_Click" />
                                 <asp:Button ID="BtnAllRemovedArticles" CssClass=" pl-2 btn sub-taskBtn mb-1"   runat ="server" Text="Removed Articles" OnClick="BtnAllRemovedArticles_Click" />
                                <asp:Button ID="BtnMosqueReports" CssClass=" pl-2 btn sub-taskBtn mb-1"   runat ="server" Text="List of Mosques" OnClick="BtnMosqueReports_Click" />
                                <asp:Button ID="BtnEventReports" CssClass=" pl-2 btn sub-taskBtn mb-1"   runat ="server" Text="List of Events" OnClick="BtnEventReports_Click" />
                           
                            <asp:Button ID="BtnRemoveArticles" CssClass=" pl-2 btn taskBtn mb-1"   runat ="server" Text="Remove Articles" OnClick="BtnRemoveArticles_Click" />

                        </nav>
                    </div>
                    <div class=" position-static basic-div-styling p-0  w-100" >
                        <div runat="server" id="divTaskHead" class=" head-div text-center p-2 mb-1">
                            <h4> <asp:Label ID="LblHeading" runat="server" class=" p-0 m-0"></asp:Label></h4>
                             <h4 runat="server" id="lblTaskHead"  class="p-0 m-0"></h4>
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
                                                    <div class="p-0 form-row m-0 position-static p-1">
                                                        <div class=" col-auto position-static p-0">
                                                            <div class="">
                                                                <p style="font-size:small" class="p-0 m-0 text-truncate"><b>User&nbsp;Name: </b><%#Eval("MemberID")%><br/></p>
                                                            </div>
                                                                <hr class=" mr-4 m-0 p-0"/>
                                                            <div class="">
                                                                <p  style="font-size:smaller;" class="p-0 m-0 text-truncate"><b>Date Registered: </b><%#Convert.ToDateTime(Eval("ActivationDate")).ToString("dd MM yyyy")%></p>
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
                            <!---divViewPendingArticles-->
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
                                                    <div class="p-0 form-row m-0 position-static p-1">
                                      
                                                        <div class=" col-auto position-static p-0">
                                                            <div class="">
                                                                <p style="font-size:small" class="p-0 m-0 text-truncate"><b>User&nbsp;Name: </b><%#Eval("ArticleTitle")%><br/></p>
                                                            </div>
                                                                <hr class=" mr-4 m-0 p-0"/>
                                                            <div class="">
                                                                <p  style="font-size:smaller;" class="p-0 m-0 text-truncate"><b>Date Registered: </b><%#Convert.ToDateTime(Eval("DateCreated")).ToString("dd MM yyyy")%></p>
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
                             <div class="col-6 col-xl-4 p-0 mr-1" runat="server" id="divViewRemoveAcceptedArticle" style="position:static">
                                <!--Contains the List of items-->
                                <div class=" head-div-2 p-2 mb-1 ">
                                    <p class="m-0">Learn Islam Articles</p>
                                </div>
                                <div class="position-static p-1 lst-container" style="overflow-y:scroll;">
                                    <asp:Repeater ID="rptRemoveAcceptedArticles" runat="server" OnItemCommand="Repeater1_ItemCommand">
                                        <HeaderTemplate>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnShowRemoveAcceptArt" CommandArgument='<%#Eval("ArticleID") %>' CssClass="position-static lstBtn btn btn-block" runat="server" OnClick="btnShowRemoveAcceptArt_Click">
                                                    <div class="p-0 form-row m-0 position-static p-1">
                                                        <div class=" col-auto position-static p-0">
                                                            <div class="">
                                                                <p style="font-size:small" class="p-0 m-0 text-truncate"><b>User&nbsp;Name: </b><%#Eval("ArticleTitle")%><br/></p>
                                                            </div>
                                                                <hr class=" mr-4 m-0 p-0"/>
                                                            <div class="">
                                                                <p  style="font-size:smaller;" class="p-0 m-0 text-truncate"><b>Date Registered: </b><%#Convert.ToDateTime(Eval("DateCreated")).ToString("dd MM yyyy")%></p>
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
                            <!---divDisplayScholars-->
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
                            <!---divViewArticles--->
                            <div class=" col-12 col-md-8 flex-nowrap p-0" runat="server" id="divViewArt" style="position:static">
                                 <div class=" head-div-2 p-2 mb-0 ">
                                    <p class="m-0">Article Details:</p>
                                </div>
                                <div class="container" runat="server" id="divDisplayArticle" style="position:static;overflow-x:hidden;overflow-y:scroll; height:490px;">
                                <div class="row mb-3 mt-2" style="position:static">
                                    <div class="col position-static">
                                        <label class="m-0 h2" runat="server" id="lblTitle"></label>
                                    </div>
                                </div>
                                <div class="row mb-1 position-static">
                                    <div class="col position-static">
                                        <textarea class="m-0 article-content" runat="server" id="lblContent"></textarea>
                                    </div>
                                </div>
                                <div class="row mb-1 position-static">
                                    <div class="col position-static font-italic text-left">
                                        Author:
                                        <label class="m-0 mt-2" runat="server" id="lblScholar"></label>
                                    </div>
                                    <div class="row mb-1 position-static text-right">
                                        <div class="col position-static font-italic">
                                            Date:
                                        <label class="m-0 font-italic mt-2" runat="server" id="lblDate"></label>
                                        </div>
                                    </div>
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
                            <!---divViewRemoveAcceptArticles--->
                            <div class=" col-12 col-md-8 flex-nowrap p-0" runat="server" id="divDisplayRemoveAcceptedArticles" style="position:static">
                                 <div class=" head-div-2 p-2 mb-0 ">
                                    <p class="m-0">Article Details:</p>
                                </div>
                                <div class="container" runat="server" id="div2" style="position:static;overflow-x:hidden;overflow-y:scroll; height:490px;">
                                <div class="row mb-3 mt-2" style="position:static">
                                    <div class="col position-static">
                                        <label class="m-0 h2" runat="server" id="lblRemoveAcceptTitle"></label>
                                    </div>
                                </div>
                                <div class="row mb-1 position-static">
                                    <div class="col position-static">
                                        <textarea class="m-0 article-content" runat="server" id="lblRemoveAcceptContent"></textarea>
                                    </div>
                                </div>
                                <div class="row mb-1 position-static">
                                    <div class="col position-static font-italic text-left">
                                        Author:
                                        <label class="m-0 mt-2" runat="server" id="lblRemoveAcceptScholar"></label>
                                    </div>
                                    <div class="row mb-1 position-static text-right">
                                        <div class="col position-static font-italic">
                                            Date:
                                        <label class="m-0 font-italic mt-2" runat="server" id="lblRemoveDate"></label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                                <div class="card-footer text-center position-static text-nowrap" style="position:static">
                                    <asp:Button CssClass=" topnav btn btn-sm btn-outline-light mr-2 " runat="server" ID="BtnRemoveAcceptedArticle" Text="Remove Article" OnClick="BtnRemoveAcceptedArticle_Click" />
                                   
                                    <br />
                                    <br />   
                                    
                                    <asp:Label ID="Label6" CssClass=" form-control-sm col main-txtb " ForeColor="#256297" runat="server" Text="Removal Reason:"></asp:Label> <asp:TextBox runat="server" CssClass=" text-justify btn btn-sm  mr-2 position-static" ID="txtRemovalReason" BorderColor="#256297" Width="50%" OnTextChanged="txtRemovalReason_TextChanged" ></asp:TextBox>
                                    <br />
                                    <asp:Label ID="lblRemovalDisplay" CssClass="align-content-center" ForeColor="Red" runat="server" Text=""></asp:Label>
                                </div>
                        </div>
                             <%-- Overlay for Articles List selection--%>
                            <div class="col-6 col-xl-4 text-nowrap" runat="server" id="divArticleOverlay">
                                <div class="w-100 h-100 container text-center">
                                    <div class=" container h-25 mb-3"></div>
                                        <h6 class="card-title h-50 mt-5 pt-5"><img class="figure-img mr-2" src="MyAdmin/icons/outline_error_outline_black_18dp.png" />No Article selected.</h6>
                                    <div class=" container h-25"></div>
                                </div>
                            </div>
                            <div runat="server" id="divDisplayReports" class=" col-12 col-xl-12 mw-100 p-0" style="position:static">
                                <div class=" head-div-2 p-2 mb-0 text-center ">
                                    <p class="m-0" runat ="server" id ="reportHeading">Report</p>
                                </div>
                                <div class="m-0 p-0 pt-2 pl-2">
                                    <a runat="server" id="PDF" onserverclick="PDF_ServerClick"><img src="MyModerator/Adobe_PDF.png" /><small>Download as PDF</small></a>
                                    <hr class="m-0 mt-1 p-0" style="background-color:#0026ff; height:1px;" />
                                </div>
                                <div class=" col-12 col-xl-12 p-2" style="overflow-x:scroll;overflow-y:scroll;position:static;max-height:500px;max-width:1550px">
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
                            <!---divSalaahTimeTable-->
                              <div runat="server" id="divDisplaySalahTimetable" class="bg-light  position-static col-12 p-3 divContainers flex-nowrap m-0 row">
                            <div style="display: flex;justify-content: center" class=" col-6 position-static basic-div-styling w-50">
                             <table class="table" style="justify-content: center; width: 55%; height: 20%; align-self: center">
                                <tr>
                                    <td rowspan="2"; colspan="1"><asp:Image ID="icoPrayer" ImageUrl="Mosque/download.png" runat="server" Height="110px" Width="110px" /> </td>
                                    <th colspan="2" class=" h4 text-uppercase m-0 align-middle font-weight-bold">Salah TimeTable</th>
                                </tr>
                                <tr>
                                    <th>AZAAN</th>
                                    <th>JAMAAT</th>
                                </tr>

                                <tr>
                                    <th colspan="1">Fajr</th>
                                    <td>
                                        <asp:Label ID="lblFajrAzaan" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblFajrJamaat" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <th colspan="1">Dhuhr</th>
                                    <td>
                                        <asp:Label ID="lblDhuhrAzaan" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblDhuhrJamaat" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <th colspan="1">Asr</th>
                                    <td>
                                        <asp:Label ID="lblAsrAzaan" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblAsrJamaat" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <th>Magrib</th>
                                    <td> 
                                        <asp:Label ID="lblMagribAzaan" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblMagribJamaat" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <th>Eisha</th>
                                    <td>
                                        <asp:Label ID="lblEishaAzaan" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblEishaJamaat" runat="server"></asp:Label></td>
                                </tr>

                            </table>  
                         </div>

                            
                    
                    <%--m-0 col-lg-4 ml-lg-5  position:static;--%><div class="slideshow-container ml-5" style="width:300px">
                        <h2 style="background-color:#256297;color:white;text-align:center"> Salah Quotes</h2>
                    <div class="mySlides">
                      <q> And be steadfast in prayer; practise regular charity; and bow down your heads with those who bow down (in worship).</q>
                      <p class="author">- Quraan [2:43]</p>
                    </div>

                    <div class="mySlides">
                      <q>As long as you are performing prayer, you are knocking at the door of Allah, and whoever is knocking at the door of Allah, Allah will open it for him. </q>
                      <p class="author">- Ibn-Al-Qayyim</p>
                    </div>

                    <div class="mySlides">
                      <q>And establish prayer and give zakah, and whatever good you put forward for yourselves – you will find it with Allah. Indeed, Allah of what you do, is Seeing.</q>
                      <p class="author"> – al-Quran 2:110</p>
                    </div>
                         <!-- Next/prev buttons -->
                    <a class="prev" onclick="plusSlides(-1)">❮</a>
                    <a class="next" onclick="plusSlides(1)">❯</a>

                    
                        <!-- Dots/bullets/indicators -->
                    <div class="dot-container" style= "position:static; width:300px"> <%--m-0 col-lg-4 ml-lg-5--%>
                      <span class="dot" onclick="currentSlide(1)"></span> 
                      <span class="dot" onclick="currentSlide(2)"></span> 
                      <span class="dot" onclick="currentSlide(3)"></span> 
                    </div>
                        <script src="Zakaah/slideshow.js"></script>
                        </div>

                             <%--<div class="col-sm-3 col-xl-4 text-nowrap" runat="server" id="divNoSalaah">
                                <div class="w-100 h-100 container text-center">
                                    <div class=" container h-25 mb-3"></div>
                                    <h6 class="card-title h-50 mt-5 pt-5">
                                        <asp:Image runat="server" class="figure-img mr-2" ImageUrl="MyMember/icons/outline_error_outline_black_18dp.png" /><asp:Label ID="lblNoSalaah" runat="server">No salaah times were entered as yet.</asp:Label></h6>
                                    <div class=" container h-25"></div>
                                </div>
                            </div>--%>

                    </div>
                   <%-- View Events--%>
                            <div class=" row bg-light position-static ml-1 mr-1 flex-nowrap col-12 pl-0" runat="server" id="divDisplayEvents">
                                <%--flex-nowrap w-100--%>
                                <div class="col-3 col-sm-5 col-xl-4 p-0 mr-1">
                                    <div class=" head-div-2 p-2 mb-0 text-left ">
                                        <p class="m-0">Select Event Date Range</p>
                                    </div>
                                    <div class="table">
                                        <div class="form-row">
                                            <div class="form-group col-sm-6 mb-1">
                                                <label class="col mb-0 p-0">Start Date: </label>
                                                <asp:TextBox TextMode="Date" CssClass="form-control form-control-sm col main-txtb" runat="server" Format="yyyy/MM/dd" ID="txtStartDate"></asp:TextBox>
                                            </div>
                                            <div class="form-group col-sm-6 mb-1">
                                                <label class="col mb-0 p-0">End Date: </label>
                                                <asp:TextBox TextMode="Date" CssClass="form-control form-control-sm col main-txtb" runat="server" Format="yyyy/MM/dd" ID="txtEndDate"></asp:TextBox>
                                            </div>
                                            <div class="form-group col-1 mb-1 mt-1">
                                                <asp:Button runat="server" ID="btnListEvents" Text="List Events" CssClass="topnav btn btn-md btn-outline-light" OnClick="btnListEvents_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-3 col-xl-4 p-0 mr-1" runat="server" id="divListEventDetails">
                                    <div runat="server" id="divListEvent" class="position-static m-0 p-0">
                                        <div class=" head-div-2 p-2 mb-1 text-left">
                                            <p class="m-0">Mosque Events</p>
                                        </div>
                                        <div class="p-1 lst-container" style="overflow-y: scroll;">
                                            <asp:Repeater ID="RptEventList" runat="server">
                                                <HeaderTemplate>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnEventList" CommandArgument='<%#Eval("EventID") %>' CssClass="position-static lstBtn btn btn-block" runat="server" OnClick="btnEventList_Click" EnableViewState="true">
                                                <div class="p-0 form-row m-0 position-static p-1">
                                                    <div class=" col-auto position-static p-0">
                                                        <div class="">
                                                            <p style="font-size: small" class="p-0 m-0 text-truncate">
                                                                <b>Event&nbsp;Title: </b><%#Eval("EventTitle").ToString()%><br />
                                                            </p>
                                                        </div>
                                                        <hr class=" mr-4 m-0 p-0" />
                                                        <div class="">
                                                            <p style="font-size: smaller;" class="p-0 m-0 text-truncate"><b>Event Date: </b><%#Convert.ToDateTime(Eval("EventDate")).ToString("dd MM yyyy")%></p>
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
                                </div>

                                <div runat="server" id="divEvent" class="col-3 col-xl-4 flex-nowrap p-0 mr-1">
                                    <asp:HiddenField runat="server" ID="hdfEvent" Value="" />
                                    <div class=" head-div-2 p-2 mb-0 text-left ">
                                        <label runat="server" class="mb-0">Selected event details:</label>
                                    </div>
                                    <div runat="server" id="lblEventTitle" class="ml-3 p-2 h4" style="font-weight: 500">
                                        <h4 class="p-0 m-0"></h4>
                                    </div>
                                    <hr class="m-1 ml-3 mr-3 bg-secondary" />
                                    <div>
                                        <div class="container" runat="server" id="divEventDetails">
                                            <div class="row mb-1 position-static">
                                                <div class="col position-static"><b>Description:</b></div>
                                                <div class="col position-static">
                                                    <label class="m-0" runat="server" id="lblEventDescription"></label>
                                                </div>
                                            </div>
                                            <hr class="bg-secondary m-0 mt-2 mb-2 " />
                                            <div class="row mb-1 position-static">
                                                <div class="col position-static"><b>Speaker:</b></div>
                                                <div class="col position-static text-truncate">
                                                    <label class="m-0" runat="server" id="lblSpeaker"></label>
                                                </div>
                                            </div>
                                                <hr class="m-0 mt-2 mb-2  bg-secondary" />
                                            <div class="row mb-1 position-static">
                                                <div class="col position-static"><b>Event Date:</b></div>
                                                <div class="col position-static text-truncate">
                                                    <label class="m-0" runat="server" id="lblEventDate"></label>
                                                </div>
                                            </div>
                                            <hr class=" m-0 mt-2 mb-2 bg-secondary" />
                                            <div class="row mb-1 position-static">
                                                <div class="col position-static"><b>Start Time:</b></div>
                                                <div class="col position-static text-truncate">
                                                    <label class="m-0" runat="server" id="lblEventStartTime"></label>
                                                </div>
                                            </div>
                                            <hr class="bg-secondary m-0 mt-2 mb-2 " />
                                            <div class="row mb-1 position-static">
                                                <div class="col position-static"><b>End Time:</b></div>
                                                <div class="col position-static text-truncate">
                                                    <label class="m-0" runat="server" id="lblEventEndTime"></label>
                                                </div>
                                            </div>                                            
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-3 col-xl-4 text-nowrap" runat="server" id="divEventOverlay">
                                    <div class="w-100 h-100 container text-center">
                                        <div class=" container h-25 mb-3"></div>
                                        <h6 class="card-title h-50 mt-5 pt-5">
                                            <asp:Image runat="server" class="figure-img mr-2" ImageUrl="MyMember/icons/outline_error_outline_black_18dp.png" /><asp:Label ID="lblEventError" runat="server">Please select a start and end date.</asp:Label></h6>
                                        <div class=" container h-25"></div>
                                    </div>
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
       
        <script src="Default/Default.js"></script>
        
        <script src="MyAdmin/js/MyAdmin.js"></script>
        <script src="MyModerator/js/MyModerator.js"></script>
        <script src="Default/DefaultJq.js"></script>
    </body>

</html>
