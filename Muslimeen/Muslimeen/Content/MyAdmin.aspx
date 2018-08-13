<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyAdmin.aspx.cs" Inherits="Muslimeen.Content.MyAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
	<meta http-equiv="X-UA-Compatible" content="IE=edge"/>
	<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=yes"/>

    <title>MyMuslimeen - MyAdmin</title>
    <link rel="icon" href="/Login/LogIn_Bootstrap/muslimeen.ico"/>
    <link href="../Login/LogIn_Bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="MyAdmin/css/MyAdmin.css" rel="stylesheet" />
</head>
    <body>
        <asp:HyperLink ID="lnk1" runat="server" href="HelpPage.aspx"></asp:HyperLink>
        <form id="frmScholar" runat="server" class="">   
            <header >
                <nav class="navFixed">
                    <div class="row align-self-end">
                        <ul class=" col-7 navbar-nav flex-row justify-content-start">
                            <asp:HiddenField runat="server" ID="hfAdjustDate" Value="-2" /> <!--Need to get value from DB let admin adjust this -->
                            <li class="nav-item ml-4 mr-0 mb-0 pt-2 text-truncate"> <p class="IslamicDate mb-0 text-truncate position-static" id="lstIslamicDate"></p></li>
                            <script src="Default/DatesEnglishHijri.js" type="text/javascript"></script>
                        </ul>
                        <ul class="col-5 navbar-nav flex-row justify-content-end">
                            <li class="nav-item ml-0 mr-0">
                            <asp:TextBox ID="txtSearch" TextMode="Search" runat="server"  class="search-box form-control form-control-sm" autocomplete="off" placeholder="Search"></asp:TextBox>
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
                <div id="navbar" class="navbar navbar-expand flex-column navv flex-md-row" style="box-shadow: 0 0 0 0.1rem rgba(0, 123, 255, 0.50); z-index:1000">
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
            <div class="content position-relative" id="content">
                <!--add content here -->
                <div class="row bg-light m-0 divContainers p-1 flex-nowrap position-relative">
                    <div class="side-bar p-0 basic-div-styling mr-1 position-relative">
                        <!--contains the buttons-->
                        <div class="head-div text-center p-2">
                            <p class="text-uppercase m-0 font-weight-bold">Admin Tasks</p>
                        </div>
                        <nav class="nav flex-column pt-2 pb-2 pr-0">
                            <asp:Button runat="server" ToolTip="Pending Scholar Registrations." ID="btnViewPendingSch" OnClick="btnViewPendingSch_Click" CssClass="pl-2 btn mb-1 taskBtn" Text="View Pending Scholars" />
                            <asp:Button runat="server" ToolTip="Add a Mosque on Muslimeen" ID="btnAddMosque" OnClick="btnAddMosque_Click" CssClass="pl-2 btn mb-1 taskBtn" Text="Add Mosque" />
                            <asp:Button runat="server" ID="btnAddMod" CssClass=" pl-2 btn taskBtn mb-1" OnClick="btnAddMod_Click" Text="Add a Moderater" />
                            <asp:Button runat="server" ID="btUpdateZakaahOrg" CssClass=" pl-2 btn taskBtn mb-1" OnClick="btnUpdateZakaahOrg_Click" Text="Update Zakaah Organization" />
                                <asp:Button ID="btnAddZakaahOrg" CssClass=" pl-2 btn sub-taskBtn mb-1"   runat ="server" Text="Add New Organization" OnClick="btnAddZakaahOrg_Click" />
                            <asp:Button runat="server" ID="btnUpdateNotice" CssClass=" pl-2 btn taskBtn mb-1" OnClick="btnUpdateNotice_Click" Text="Update Notice" />
                                <asp:Button ID="btnAddNotice" CssClass=" pl-2 btn sub-taskBtn mb-1"   runat ="server" Text="Add new Notice" OnClick="btnAddNotice_Click" />
                        </nav>
                    </div>
                    <div class=" position-static basic-div-styling p-0 w-100 position-relative">
                        <div class=" head-div text-center p-2 mb-1">
                            <h4 runat="server" id="lblTaskHead"  class="p-0 m-0"></h4>
                        </div>
                        <div class="row p-0 m-0 right-bottom-div p-1 flex-nowrap justify-content-xl-start" >
                            <%-- Pending Scholar registration List--%>
                            <div class="col-6 col-xl-4 p-0 mr-1" runat="server" id="divViewPendingSch">
                                <div class=" head-div-2 p-2 mb-1 text-left">
                                    <p class="m-0">Pending Registrations</p>
                                </div>
                                <div class=" p-1 lst-container"  style="overflow-y:scroll;" >
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
                                </div>s
                            </div>
                            <%--Add Mosque Rep--%>
                            <div class="col-6 col-xl-4 align p-0" runat="server" id="divAddMosqueRep">
                                <div class=" head-div-2 p-2 mb-1 text-left">
                                    <p class="m-0">Add Mosque Representative</p>
                                </div>
                                <div class=" position-static p-1 lst-container align-content-xl-center">
                                    <div class="form-row">
                                        <div class="form-group col-sm-12 mb-1">
                                        <label class="col mb-0 p-0"><small>User Name*</small></label>
                                            <asp:TextBox CssClass="form-control form-control-sm col main-txtb" runat="server" ID="txtUserName"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="form-group col-sm-6 mb-1">
                                        <label class="col mb-0 p-0 "><small>First Name*</small></label>
                                            <asp:TextBox CssClass="form-control form-control-sm col main-txtb" runat="server" ID="txtName" ></asp:TextBox>
                                        </div>
                                        <div class="form-group col-sm-6 mb-1 ">
                                            <label class="col mb-0 p-0 "><small>Last Name*</small></label>
                                            <asp:TextBox CssClass=" form-control form-control-sm col main-txtb" runat="server" ID="txtLName" ></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="form-group col-sm-6 mb-1 ">
                                            <label class="col mb-0 p-0 "><small>Contact Number</small></label>
                                            <asp:TextBox CssClass=" form-control form-control-sm col main-txtb" runat="server" ID="txtContactNum" ></asp:TextBox>
                                        </div>
                                        <div class="form-group col-sm-6 mb-1">
                                            <label class="col mb-0 p-0 text "><small>Date of Birth*</small></label>
                                            <asp:TextBox CssClass=" form-control form-control-sm col main-txtb" runat="server" ID="txtDOB" placeholder="yyyy-mm-dd*"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="form-group col-sm-12 mb-1">
                                            <label class="col mb-0 p-0"><small>Email*</small></label>
                                            <asp:TextBox CssClass="form-control form-control-sm col main-txtb" runat="server" ID="txtUserEmail"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="form-group col-sm-12 mb-1 ">
                                            <label class="col mb-0 p-0 "><small>Password*</small></label>
                                            <asp:TextBox TextMode="Password" CssClass="form-control form-control-sm col main-txtb" runat="server" ID="txtPassword"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="form-group col-sm-12 mb-1 position-static">
                                            <label class="col mb-0 p-0 "><small>Retype Password*</small></label>
                                            <asp:TextBox TextMode="Password" CssClass="form-control form-control-sm col main-txtb" runat="server" ID="txtRetypePassword"></asp:TextBox>
                                        </div>
                                    </div>
                                        <hr class="m-3 ml-3 mr-3 bg-secondary"/>
                                    <div class=" p-0 m-1">
                                        <h6 class="w-100 card-title card-header">
                                            <img class="figure-img mr-2 mb-1 " src="MyAdmin/icons/outline_warning_black_18dp.png" />Before Registering:</h6>
                                        <div class=" m-0 card-body p-2">
                                            <ul class="pl-3 pb-3 mb-0">
                                                <li>
                                                    <p class="mb-0"><small class="card-text">Before adding the Mosque, administrators must verify the legitimacy of the details of the mosque.</small></p>
                                                </li>
                                            </ul>
                                        </div>
                                        <div class="card-footer text-center text-nowrap">
                                            <asp:Button CssClass="topnav btn btn-sm btn-outline-light mr-2" runat="server" ID="btnRegMosque" Text="Register Mosque" OnClick="btnRegMosque_Click"/>
                                            <asp:Button CssClass="topnav btn btn-sm btn-outline-light" runat="server" ID="btnCancelMosqueReg" Text="Cancel" OnClick="btnCancelMosqueReg_Click"/>
                                        </div>
                                            <hr class="mt-3 ml-3 mr-3 bg-secondary"/>
                                    </div>
                                </div>
                            </div>
                            <%-- Add the Mosque --%>
                            <div class="col-6 col-xl-4 flex-nowrap pl-1" style="overflow:hidden;" runat="server" id="divAddMosque">
                                <div class=" head-div-2 p-2 mb-1 text-left">
                                    <p class="m-0">Add Mosque</p>
                                </div>
                                <div class="position-static p-1 lst-container">
                                    <div class="form-row">
                                        <div class="form-group col-sm-12 mb-1">
                                            <label class="col mb-0 p-0"><small>Mosque Name*</small></label>
                                            <asp:TextBox CssClass="form-control form-control-sm col main-txtb" runat="server" ID="txtMosqueName"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="form-group col-sm-12 mb-1">
                                            <label class="col mb-0 p-0"><small>Mosque Address*</small></label>
                                            <asp:TextBox CssClass="form-control form-control-sm col main-txtb" runat="server" ID="txtMosqueAddr"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="form-group col-sm-12 mb-1">
                                            <label class="col mb-0 p-0"><small>Mosque Suburb*</small></label>
                                            <asp:TextBox CssClass="form-control form-control-sm col main-txtb" runat="server" ID="txtMosqueSuburb"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="form-group col-sm-12 mb-1">
                                            <label class="col mb-0 p-0"><small>Mosque Type*</small></label>
                                            <asp:DropDownList CssClass="form-control form-control-sm col main-txtb" runat="server" ID="ddMosqueType">
                                                <asp:ListItem Selected disabled Value="None">Please select a Type</asp:ListItem>
                                                <asp:ListItem Value="Hanafie">Hanafie</asp:ListItem>
                                                <asp:ListItem Value="Shaafie">Shaafie</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="form-group col-sm-12 mb-1">
                                            <label class="col mb-0 p-0"><small>Date Established*</small></label>
                                            <asp:TextBox TextMode="Date" CssClass="form-control form-control-sm col main-txtb" runat="server" Format="yyyy/MM/dd" ID="txtMosqueEstab"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="form-group col-sm-12 mb-1">
                                            <label class="col mb-0 p-0"><small>Mosque Size*</small></label>
                                            <asp:DropDownList CssClass="form-control form-control-sm col main-txtb" runat="server" ID="ddMosqueSize">
                                                <asp:ListItem Selected disabled Value="None">Please select a size</asp:ListItem>
                                                <asp:ListItem Value="Small">Small</asp:ListItem>
                                                <asp:ListItem Value="Medium">Medium</asp:ListItem>
                                                <asp:ListItem Value="Large">Large</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="form-group col-sm-12 mb-1">
                                            <label class="col mb-0 p-0"><small>Mosque Quote</small></label>
                                            <asp:TextBox TextMode="MultiLine" Style=" max-height:80px; min-height:80px;" CssClass=" position-static form-control form-control-sm col main-txtb" runat="server" ID="txtMosqueQuote"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="form-group col-sm-12 mb-1">
                                            <label class="col mb-1 p-0"><small>Mosque Image</small></label>
                                            <asp:FileUpload CssClass=" form-control form-control-sm col main-txtb" runat="server" ID="fupMosqueImage" />
                                        </div>
                                    </div>
                                    <div class="form-row mt-2">
                                        <div class="form-group col-sm-12 mb-1 flex-wrap" style="overflow:hidden;">
                                            <small><asp:Label runat="server"  ID="lblError" CssClass="col p-0"></asp:Label></small>
                                        </div>
                                    </div>
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
                            <%-- Diaplay Pending Scholar Details --%>
                            <div runat="server" id="divDisplaySch" class=" col-6 col-xl-4 flex-nowrap p-0">
                                <asp:HiddenField runat="server" ID="hdfSchId" Value="" />
                                <div class=" head-div-2 p-2 mb-0 text-left ">
                                    <p class="m-0">Scholar Details</p>
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
                                            <div  class="col position-static text-truncate">
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
                                            <asp:Button CssClass=" topnav btn btn-sm btn-outline-light" runat="server" ID="btnRejectReg" Text="Reject Registration" OnClick="btnRejectReg_Click" />
                                        </div>
                                    </div>
                                </div>
                                <%--Add a Moderator--%>
                            <div runat="server" id="divAddMod" class=" col-sm-12 col-xl-4 flex-nowrap p-0">
                                <div class=" head-div-2 p-2 mb-0 text-left ">
                                    <p class="m-0">Add Details of Moderater</p>
                                </div>
                                <div class=" position-static p-1 lst-container align-content-xl-center">
                                    <div class="form-row">
                                        <div class="form-group col-sm-12 mb-1">
                                            <label class="col mb-0 p-0"><small>User Name*</small></label>
                                            <asp:TextBox CssClass="form-control form-control-sm col main-txtb" runat="server" ID="txtModUserName"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="form-group col-sm-6 mb-1">
                                            <label class="col mb-0 p-0 "><small>First Name*</small></label>
                                            <asp:TextBox CssClass="form-control form-control-sm col main-txtb" runat="server" ID="txtModFName"></asp:TextBox>
                                        </div>
                                        <div class="form-group col-sm-6 mb-1 ">
                                            <label class="col mb-0 p-0 "><small>Last Name*</small></label>
                                            <asp:TextBox CssClass=" form-control form-control-sm col main-txtb" runat="server" ID="txtModLName"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="form-group col-sm-6 mb-1 ">
                                            <label class="col mb-0 p-0 "><small>Contact Number</small></label>
                                            <asp:TextBox CssClass=" form-control form-control-sm col main-txtb" runat="server" ID="txtModContactNo"></asp:TextBox>
                                        </div>
                                        <div class="form-group col-sm-6 mb-1">
                                            <label class="col mb-0 p-0 text "><small>Date of Birth*</small></label>
                                            <asp:TextBox CssClass=" form-control form-control-sm col main-txtb" runat="server" ID="txtModDOB" placeholder="yyyy-mm-dd*"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="form-group col-sm-6 mb-1">
                                            <label class="col mb-0 p-0"><small>Email*</small></label>
                                            <asp:TextBox CssClass="form-control form-control-sm col main-txtb" runat="server" ID="txtModEmail"></asp:TextBox>
                                        </div>
                                        <div class="form-group col-sm-6 mb-1">
                                            <label class="col mb-0 p-0 text "><small>Qualification*</small></label>
                                            <asp:DropDownList CssClass=" form-control form-control-sm col main-txtb" ID="ddModQualification" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="form-group col-sm-12 mb-1 ">
                                            <label class="col mb-0 p-0 "><small>Password*</small></label>
                                            <asp:TextBox TextMode="Password" CssClass="form-control form-control-sm col main-txtb" runat="server" ID="txtModPassword"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="form-group col-sm-12 mb-1 position-static">
                                            <label class="col mb-0 p-0 "><small>Retype Password*</small></label>
                                            <asp:TextBox TextMode="Password" CssClass="form-control form-control-sm col main-txtb" runat="server" ID="txtModRetypePassword"></asp:TextBox>
                                        </div>
                                    </div>
                                    <hr class="m-3 ml-3 mr-3 bg-secondary" />
                                    <div class=" p-0 m-1">
                                        <h6 class="w-100 card-title card-header">
                                            <img class="figure-img mr-2 mb-1 " src="MyAdmin/icons/outline_warning_black_18dp.png" />Before Registering:</h6>
                                        <div class=" m-0 card-body p-2">
                                            <ul class="pl-3 pb-3 mb-0">
                                                <li>
                                                    <p class="mb-0"><small class="card-text">Please make sure that the moderater is qualified for the membership</small></p>
                                                </li>
                                            </ul>
                                        </div>
                                        <div class="card-footer text-center text-nowrap">
                                            <asp:Button CssClass="topnav btn btn-sm btn-outline-light mr-2" runat="server" ID="btnRegModerater" OnClick="btnRegModerater_Click" Text="Register Moderater" />
                                            <asp:Button CssClass="topnav btn btn-sm btn-outline-light" runat="server" ID="btnModRegCancel" OnClick="btnModRegCancel_Click" Text="Cancel" />
                                        </div>
                                        <div class="form-row mt-2 mb-0">
                                            <div class="form-group col-sm-12 m-0 flex-wrap text-truncate" style="overflow:hidden;">
                                                <small><asp:Label runat="server" ID="lblModError" CssClass="col m-0 p-0"></asp:Label></small>
                                            </div>
                                        </div>
                                        <hr class="mt-3 ml-3 mr-3 bg-secondary" />
                                    </div>
                                </div>
                            </div>
                            <%--Add/Update a Zakaah Organization--%>
                            <div class="col-6 col-xl-4 p-0 mr-1" runat="server" id="divZakaahOrgList">
                                <div class=" head-div-2 p-2 mb-1 text-left">
                                    <p class="m-0">Current Organizations</p>
                                </div>
                                <div class=" p-1 lst-container"  style="overflow-y:scroll;" >
                                    <asp:Repeater ID="rptZakaahOrg" runat="server">
                                        <HeaderTemplate>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnShowOrg" CommandArgument='<%#Eval("OrganizationID") %>' ToolTip="Select" CssClass="position-static lstBtn btn btn-block" runat="server" OnClick="btnShowOrg_Click">
                                                    <div class="p-0 form-row m-0 position-static flex-nowrap">
                                                        <div class="col-auto pl-0 position-static ">
                                                            <img src='<%#Eval("Image") %>' class="" alt="n/a" style="height:40px; width:35px;"/>
                                                        </div>
                                                        <div class="col-auto position-static p-0">
                                                            <div class="">
                                                                <p style="font-size:small;" class=" p-0 m-0"><b>Name: </b><%#Eval("Name")%><br/></p>
                                                            </div>
                                                                <hr class=" mr-4 m-0 p-0"/>
                                                            <div class="">
                                                                <p  style="font-size:smaller;" class="p-0 m-0 text-truncate"><b>Contact No. </b><%#Eval("ContactNo")%>&emsp;<b>Active:</b> <%#Eval("Active")%></p>
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
                            <asp:HiddenField runat="server" ID="hdfZakaahOrg" Value="" />
                            <div runat="server" id="divAddUpdateZakaahOrg" class=" col-sm-6 col-xl-4 flex-nowrap p-0">
                                <div class=" head-div-2 p-2 mb-0 text-left ">
                                    <p class="m-0">Add Details of Organization</p>
                                </div>
                                <div class=" position-static p-1 lst-container align-content-xl-center">
                                    <div class="form-row">
                                        <div class="form-group col-sm-12 mb-1">
                                            <label class="col mb-0 p-0"><small>Organization Name*</small></label>
                                            <asp:TextBox CssClass="form-control form-control-sm col main-txtb" runat="server" MaxLength="35" ID="txtOrgName"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="form-group col-sm-12 mb-1">
                                            <label class="col mb-0 p-0"><small>WebsiteAddress</small></label>
                                            <asp:TextBox CssClass="form-control form-control-sm col main-txtb" runat="server" ID="txtOrgWebAddr"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="form-group col-sm-12 mb-1">
                                            <label class="col mb-0 p-0"><small>Contact Number*</small></label>
                                            <asp:TextBox CssClass="form-control form-control-sm col main-txtb" runat="server" ID="txtOrgContactNo"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="form-group col-sm-6 mb-1">
                                            <label class="col mb-0 p-0"><small>Physical Address*</small></label>
                                            <asp:TextBox CssClass="form-control form-control-sm col main-txtb" runat="server" ID="txtOrgPhyAddress"></asp:TextBox>
                                        </div>
                                        <div class="form-group col-sm-6 mb-1">
                                            <label class="col mb-0 p-0"><small>Active</small></label>
                                            <asp:DropDownList CssClass="form-control form-control-sm col main-txtb" runat="server" ID="ddOrgActive">
                                                <asp:ListItem Selected Disabled Text="" Value=""></asp:ListItem>
                                                <asp:ListItem Text="Yes" Value="Y" ></asp:ListItem>
                                                <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="form-group col-sm-12 mb-1">
                                            <label class="col mb-0 p-0"><small>Organizatinal Image or Logo</small></label>
                                            <asp:FileUpload CssClass="form-control form-control-sm col main-txtb" runat="server" ID="fupOrgImage"></asp:FileUpload>
                                        </div>
                                    </div>
                                    <hr class="mt-3 ml-3 mr-3 bg-secondary" />
                                    <div class="card-footer text-center text-nowrap border-top-0">
                                        <asp:Button CssClass="topnav btn btn-sm btn-outline-light mr-2" runat="server" ID="btnAddUpdateOrg" OnClick="btnAddUpdateOrg_Click" Text="Update Details" />
                                        <asp:Button CssClass="topnav btn btn-sm btn-outline-light" runat="server" ID="btnCancelAddUpdateOrg" OnClick="btnCancelAddUpdateOrg_Click" Text="Cancel" />
                                    </div>
                                    <hr class="mt-3 ml-3 mr-3 bg-secondary" />
                                    <div class="form-row mt-2 mb-0">
                                        <div class="form-group col-sm-12 m-0 flex-wrap text-truncate" style="overflow: hidden;">
                                            <small><asp:Label runat="server" ID="lblOrgError" CssClass="col m-0 p-0"></asp:Label></small>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <%--Add/Delete Notices --%>
                            <div class="col-6 col-xl-4 p-0 mr-1" runat="server" id="divNoticeList">
                                <div class=" head-div-2 p-2 mb-1 text-left">
                                    <p class="m-0">Current List of Notices</p>
                                </div>
                                <div class=" p-1 lst-container"  style="overflow-y:scroll;" >
                                    <asp:Repeater ID="rptNotice" runat="server">
                                        <HeaderTemplate>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnShowNotice" CommandArgument='<%#Eval("NoticeID") %>' ToolTip="Select" CssClass="position-static lstBtn btn btn-block" runat="server" OnClick="btnShowNotice_Click">
                                                    <div class="p-0 form-row m-0 position-static flex-nowrap">
                                                        <div class="col-auto position-static p-0">
                                                            <div class="">
                                                                <p style="font-size:small;" class=" p-0 m-0"><b>Notice Title: </b><%#Eval("NoticeTitle")%><br/></p>
                                                            </div>
                                                                <hr class=" mr-4 m-0 p-0"/>
                                                            <div class="">
                                                                <p  style="font-size:smaller;" class="p-0 m-0 text-truncate"><b>Expiry Date: </b><%#Eval("DateExpiry")%>&emsp;<b>Active:</b> <%#Eval("Active")%></p>
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
                            <asp:HiddenField runat="server" ID="hdfNotice" Value=""/>
                            <div runat="server" id="divAddUpdateNotice" class=" col-sm-12 col-xl-4 flex-nowrap p-0">
                                <div class=" head-div-2 p-2 mb-0 text-left ">
                                    <p class="m-0">Add Notice details</p>
                                </div>
                                <div class=" position-static p-1 lst-container align-content-xl-center">
                                    <div class="form-row">
                                        <div class="form-group col-sm-12 mb-1">
                                            <label class="col mb-0 p-0"><small>Notice Title*</small></label>
                                            <asp:TextBox CssClass="form-control form-control-sm col main-txtb" runat="server" MaxLength="25" ID="txtNoticeTitle"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="form-group col-sm-12 mb-1">
                                            <label class="col mb-0 p-0"><small>Notice Description*</small></label>
                                            <asp:TextBox TextMode="MultiLine" Style=" max-height:80px; min-height:80px;" CssClass="form-control form-control-sm col main-txtb" runat="server" MaxLength="500" ID="txtNoticeDesc"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="form-group col-sm-12 mb-1">
                                            <label class="col mb-0 p-0"><small>Notice Added by</small></label>
                                            <asp:TextBox CssClass="form-control form-control-sm col main-txtb" runat="server" MaxLength="35" ID="txtNoticeMemberID"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="form-group col-sm-12 mb-1">
                                            <label class="col mb-0 p-0"><small>Active</small></label>
                                            <asp:DropDownList  CssClass="form-control form-control-sm col main-txtb" runat="server" MaxLength="35" ID="ddNoticeActive">
                                                <asp:ListItem Selected="True" disabled Text="" Value=""></asp:ListItem>
                                                <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="form-group col-sm-6 mb-1">
                                            <label class="col mb-0 p-0"><small>Date Added</small></label>
                                            <asp:TextBox Enabled="false" CssClass="form-control form-control-sm col main-txtb" runat="server" MaxLength="35" ID="txtNoticeDateCreated"></asp:TextBox>
                                        </div>
                                        <div class="form-group col-sm-6 mb-1">
                                            <label class="col mb-0 p-0"><small>Notice Expiry Date*</small></label>
                                            <asp:TextBox TextMode="Date" CssClass="form-control form-control-sm col main-txtb" ToolTip="How long you want the Notice to last on the System" runat="server" ID="txtNoticeExpiryDate"></asp:TextBox>
                                        </div>
                                    </div>
                                    <hr class="m-3 ml-3 mr-3 bg-secondary" />
                                    <div class=" p-0 m-1">
                                        <div class="card-footer text-center text-nowrap border-top-0">
                                            <asp:Button CssClass="topnav btn btn-sm btn-outline-light mr-2" runat="server" ID="btnAddUpdateNotice" OnClick="btnAddUpdateNotice_Click"  Text=" " />
                                            <asp:Button CssClass="topnav btn btn-sm btn-outline-light" runat="server" ID="btnNoticeAddCancel" Text="Cancel" />
                                        </div>
                                        <div class="form-row mt-2 mb-0">
                                            <div class="form-group col-sm-12 m-0 flex-wrap text-truncate" style="overflow:hidden;">
                                                <small><asp:Label runat="server" ID="lblNoticeError" CssClass="col m-0 p-0"></asp:Label></small>
                                            </div>
                                        </div>
                                        <hr class="mt-3 ml-3 mr-3 bg-secondary" />
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
                                    <a class="footerr-text" href="https://www.youtube.com/user/UCp87ZLRrUz3SbzPPP2uaIEg">YouTube</a>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
            <script src="Default/Default.js" type="text/javascript"></script>
            <script src="MyAdmin/js/MyAdmin.js"></script>
        <script src="Default/DefaultJq.js"></script>
    </body>
</html>
