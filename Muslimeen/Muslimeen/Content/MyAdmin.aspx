<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyAdmin.aspx.cs" Inherits="Muslimeen.Content.MyAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
	<meta http-equiv="X-UA-Compatible" content="IE=edge"/>
	<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=yes"/>
    <title>MyMuslimeen - MyAdmin</title>
    <link rel="icon" href="../Login/LogIn_Bootstrap/muslimeen.ico"/>
    <link href="../Login/LogIn_Bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="MyAdmin/css/MyAdmin.css" rel="stylesheet" />
</head>
    <body>
        <asp:HyperLink ID="lnk1" runat="server" href="HelpPage.aspx"></asp:HyperLink>
        <div id="divAlertPopup" runat="server" style="display:none;" class="container-fluid text-center p-2 m-0 w-100 alert alert-success visible">
                <label class="h6" id="lblAlertError"  runat="server" ></label>
        </div>
        <form id="frmScholar" runat="server" class="">
            <header>
                <nav class="navFixed">
                    <div class="row align-self-end">
                        <ul class=" col-7 navbar-nav flex-row justify-content-start">
                            <asp:HiddenField runat="server" ID="hdfAdjustDate" Value="" /> <!--Need to get value from DB let admin adjust this -->
                            <li class="nav-item ml-4 mr-0 mb-0 pt-2 text-truncate"> <p class="IslamicDate mb-0 text-truncate position-static" id="lstIslamicDate"></p></li>
                            <script src="Default/DatesEnglishHijri.js" type="text/javascript"></script>
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
                         Help    <asp:Image runat="server" ID="ImgHelp" ImageUrl="MyMember/icons/helpIcon.png" style="height: 1.1em; width:1.1em;" /></asp:LinkButton>   
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
                            <p class="pl-2 btn taskBtn mb-1">My Mosque &#11167;</p>
                                <asp:Button runat="server" ToolTip="Go to the Home tab" ID="btnMosqueEvents" OnClick="btnMosqueEvents_Click" CssClass=" pl-2 btn sub-taskBtn mb-1 " Text="Events" />
                                <asp:Button runat="server" ToolTip="Go to the Home tab" ID="btnTodaysPrayerTime" OnClick="btnTodaysPrayerTime_Click" CssClass=" pl-2 btn sub-taskBtn mb-1 " Text="Todays Prayer Times" />
                            <asp:Button runat="server" ToolTip="View All Members with thier Details" ID="btnViewAllMembers" OnClick="btnViewAllMembers_Click" CssClass="pl-2 btn mb-1 taskBtn" Text="View All Members" />
                            <asp:Button runat="server" ToolTip="Pending Scholar Registrations." ID="btnViewPendingSch" OnClick="btnViewPendingSch_Click" CssClass="pl-2 btn mb-1 taskBtn" Text="View Pending Scholars" />
                            <asp:Button runat="server" ToolTip="Add a Mosque on Muslimeen" ID="btnAddMosque" OnClick="btnAddMosque_Click" CssClass="pl-2 btn mb-1 taskBtn" Text="Add Mosque" />
                                <asp:Button ID="btnUpdateMosque" CssClass=" pl-2 btn sub-taskBtn mb-1"   runat ="server" Text="Update Mosque Details" OnClick="btnUpdateMosque_Click" />
                            <asp:Button runat="server" ID="btnAddMod" CssClass=" pl-2 btn taskBtn mb-1" OnClick="btnAddMod_Click" Text="Add a Moderater" />
                            <asp:Button runat="server" ID="btnAddAdmin" CssClass=" pl-2 btn taskBtn mb-1" OnClick="btnAddAdmin_Click" Text="Add an Administrator" />
                            <asp:Button ID="btnAddZakaahOrg" CssClass="pl-2 btn taskBtn mb-1"   runat ="server" Text="Add New Organization" OnClick="btnAddZakaahOrg_Click" />
                                <asp:Button runat="server" ID="btUpdateZakaahOrg" CssClass="pl-2 btn sub-taskBtn mb-1 pl-2 btn taskBtn mb-1" OnClick="btnUpdateZakaahOrg_Click" Text="Update Zakaah Organization" />
                            <asp:Button ID="btnAddNotice" CssClass="pl-2 btn taskBtn mb-1"   runat ="server" Text="Add new Notice" OnClick="btnAddNotice_Click" />
                                <asp:Button runat="server" ID="btnUpdateNotice" CssClass=" pl-2 btn sub-taskBtn mb-1 " OnClick="btnUpdateNotice_Click" Text="Update a Notice" />
                            <asp:Button runat="server" ID="btnUpdateDateCounter" CssClass=" pl-2 btn taskBtn mb-1" OnClick="btnUpdateDateCounter_Click" Text="Update Date and Count Down" />
                            <a class="pl-2 btn taskBtn mb-1">View Reports &#11167;</a>
                                    <asp:Button runat="server" ID="btnReportViewMembers" CssClass="pl-2 btn sub-taskBtn mb-1 " OnClick="btnReportViewMembers_Click" Text="All Member Details Reports" />
                                    <asp:Button runat="server" ID="btnReportViewActiveMembers" CssClass=" pl-2 btn sub-taskBtn mb-1 " OnClick="btnReportViewActiveMembers_Click" Text="All Active Members" />
                                    <asp:Button runat="server" ID="btnReportUnactiveMembers" CssClass=" pl-2 btn sub-taskBtn mb-1 " OnClick="btnReportUnactiveMembers_Click" Text="All Unactive Members" />                     
                                    <asp:Button runat="server" ID="btnReportAllMosques" CssClass=" pl-2 btn sub-taskBtn mb-1 " OnClick="btnReportAllMosques_Click" Text="All Mosques Details" />                     
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
                                                    <div class="p-0 form-row m-0 position-static p-1">
                                                        <div class=" col-auto position-static p-0">
                                                            <div class="">
                                                                <p style="font-size:small" class="p-0 m-0 text-truncate"><b>User&nbsp;Name: </b><%#Eval("MemberID")%><br/></p>
                                                            </div>
                                                                <hr class=" mr-4 m-0 p-0"/>
                                                            <div class="">
                                                                <p  style="font-size:smaller;" class="p-0 m-0 text-truncate"><b>Date Registered: </b><%#Convert.ToDateTime(Eval("ActivationDate")).ToString("dd MMM yyyy")%></p>
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
                            <%--Add Mosque Rep--%>
                            <div class="col-6 col-xl-4 align p-0" runat="server" id="divAddMosqueRep">
                                <div class=" head-div-2 p-2 mb-1 text-left">
                                    <p class="m-0">Add Mosque Representative</p>
                                </div>
                                <div class=" position-static p-1 lst-container align-content-xl-center">
                                    <div class="form-row">
                                        <div class="form-group col-sm-12 mb-1">
                                        <label class="col mb-0 p-0 small">User Name*</label>
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
                                            <asp:TextBox MaxLength="10" onblur="NumbersOnlyRep();" CssClass=" form-control form-control-sm col main-txtb" runat="server" ID="txtContactNum" ></asp:TextBox>
                                        </div>
                                        <div class="form-group col-sm-6 mb-1">
                                            <label class="col mb-0 p-0 text "><small>Date of Birth*</small></label>
                                            <asp:TextBox MaxLength="10" Onkeyup="AddDateChars();" CssClass=" form-control form-control-sm col main-txtb" runat="server" ID="txtDOB" placeholder="dd/mm/yyyy"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="form-group col-sm-12 mb-1">
                                            <label class="col mb-0 p-0"><small>E-mail*</small></label>
                                            <asp:TextBox Onblur="EmailValidation();" CssClass="form-control form-control-sm col main-txtb" runat="server" ID="txtUserEmail"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="form-group col-sm-12 mb-1 ">
                                            <label class="col mb-0 p-0 "><small>Password*</small></label>
                                            <asp:TextBox TextMode="Password" Onkeyup="ShowPass();" Onblur="VarifyPassword('btnRegMosque','lblError');" CssClass="form-control form-control-sm col main-txtb" runat="server" ID="txtPassword"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="form-group col-sm-12 mb-1 position-static">
                                            <label class="col mb-0 p-0 "><small>Retype Password*</small></label>
                                            <asp:TextBox TextMode="Password" Onkeyup="ShowPass();" Onblur="VarifyPassword('btnRegMosque','lblError');" CssClass="form-control form-control-sm col main-txtb" runat="server" ID="txtRetypePassword"></asp:TextBox>
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
                                            <asp:TextBox TextMode="Date" CssClass="form-control form-control-sm col main-txtb" runat="server" Format="dd/MM/yyyy" ID="txtMosqueEstab"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="form-group col-sm-6 col-6 mb-1">
                                            <label class="col mb-0 p-0"><small>Mosque Size*</small></label>
                                            <asp:DropDownList CssClass="form-control form-control-sm col main-txtb" runat="server" ID="ddMosqueSize">
                                                <asp:ListItem Selected disabled Value="None">None</asp:ListItem>
                                                <asp:ListItem Value="Small">Small</asp:ListItem>
                                                <asp:ListItem Value="Medium">Medium</asp:ListItem>
                                                <asp:ListItem Value="Large">Large</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="form-group col-sm-6 col-6 mb-0">
                                            <label class="col mb-0 p-0 small">Active*</label>
                                            <asp:DropDownList CssClass="form-control form-control-sm col main-txtb" runat="server" ID="ddMosqueActive">
                                                <asp:ListItem Selected disabled Value="None"></asp:ListItem>
                                                <asp:ListItem  Value="Y">Yes</asp:ListItem>
                                                <asp:ListItem Value="N">No</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="form-group col-sm-12 mb-1">
                                            <label class="col mb-0 p-0"><small>Mosque Quote</small></label>
                                            <asp:TextBox TextMode="MultiLine" Style=" max-height:90px; min-height:90px;" MaxLength="500" CssClass=" position-static form-control form-control-sm col main-txtb" runat="server" ID="txtMosqueQuote"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="form-group col-sm-12 mb-1">
                                            <label class="col mb-0 p-0"><small>Mosque Image</small></label>
                                            <asp:FileUpload CssClass=" form-control form-control-sm col main-txtb" runat="server" ID="fupMosqueImage" />
                                        </div>
                                    </div>
                                    <div class="form-row m-0 p-0">
                                        <div class="form-group col-sm-12 m-0 p-0 flex-wrap" style="overflow:hidden;">
                                            <asp:Label runat="server"  ID="lblError" CssClass=" small m-0 p-0"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <%-- Update Mosque List --%>
                            <div class="col-6 col-xl-4 p-0 mr-1" runat="server" id="divMosqueList">
                                <div class=" head-div-2 p-2 mb-1 text-left">
                                    <p class="m-0">Pending Registrations</p>
                                </div>
                                <div class=" p-1 lst-container"  style="overflow-y:scroll;" >
                                    <asp:Repeater ID="rptMosqueList" runat="server">
                                        <HeaderTemplate>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnShowMosque" CommandArgument='<%#Eval("MosqueID") %>' CssClass="position-static lstBtn btn btn-block" runat="server" OnClick="btnShowMosque_Click">
                                                    <div class="p-0 form-row m-0 position-static p-1">
                                                        <div class="col-auto position-static">
                                                            <img src="<%# Eval("MosqueImage")%>" class="" style="height:40px; width:35px;"/>
                                                        </div>
                                                        <div class=" col-auto position-static p-0">
                                                            <div class="">
                                                                <p style="font-size:small" class="p-0 m-0 text-truncate"><b>Mosque Name: </b><%#Eval("MosqueName")%><br/></p>
                                                            </div>
                                                                <hr class=" mr-4 m-0 p-0"/>
                                                            <div class="">
                                                                <p  style="font-size:smaller;" class="p-0 m-0 text-truncate"><b>Year Established: </b><%# Convert.ToDateTime(Eval("YearEstablished")).ToString("dd MMM yyyy") %></p>
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
                            <asp:HiddenField runat="server" ID="hdfMosqueID" Value="" />
                            <div class="col-6 col-xl-4 text-nowrap" runat="server" id="divUpdateMosqueOverlay">
                                <div class="w-100 h-100 container text-center">
                                    <div class=" container h-25 mb-3"></div>
                                        <h6 class="card-title h-50 mt-5 pt-5"><img class="figure-img mr-2" src="MyAdmin/icons/outline_error_outline_black_18dp.png" />No Scholar registration selected.</h6>
                                    <div class=" container h-25"></div>
                                </div>
                            </div>
                            <%-- Update Mosque Details --%>
                            <div class="col-6 col-sm-6 col-xl-4 flex-nowrap pl-1" style="overflow:hidden;" runat="server" id="divUpdateMosque">
                                <div class=" head-div-2 p-2 mb-1 text-left">
                                    <p class="m-0">Add Mosque</p>
                                </div>
                                <div class="position-static p-1 lst-container">
                                    <div class="form-row">
                                        <div class="form-group col-sm-12 mb-1">
                                            <label class="col mb-0 p-0"><small>Mosque Name*</small></label>
                                            <asp:TextBox CssClass="form-control form-control-sm col main-txtb" runat="server" ID="txtUpdateMosqueName"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="form-group col-sm-12 mb-1">
                                            <label class="col mb-0 p-0"><small>Mosque Address*</small></label>
                                            <asp:TextBox CssClass="form-control form-control-sm col main-txtb" runat="server" ID="txtUpdateMosqueAddr"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="form-group col-sm-12 mb-1">
                                            <label class="col mb-0 p-0"><small>Mosque Suburb*</small></label>
                                            <asp:TextBox CssClass="form-control form-control-sm col main-txtb" runat="server" ID="txtUpdateMosqueSuburb"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="form-group col-sm-12 mb-1">
                                            <label class="col mb-0 p-0"><small>Mosque Type*</small></label>
                                            <asp:DropDownList CssClass="form-control form-control-sm col main-txtb" runat="server" ID="ddUpdateMosqueType">
                                                <asp:ListItem Selected disabled Value="None">Please select a Type</asp:ListItem>
                                                <asp:ListItem Value="Hanafie">Hanafie</asp:ListItem>
                                                <asp:ListItem Value="Shaafie">Shaafie</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="form-group col-sm-12 mb-1">
                                            <label class="col mb-0 p-0"><small>Date Established*</small></label>
                                            <asp:TextBox TextMode="Date" CssClass="form-control form-control-sm col main-txtb" runat="server" Format="yyyy/MM/dd" ID="txtUpdateMosqueEstab"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="form-group col-sm-6 col-6 mb-1">
                                            <label class="col mb-0 p-0"><small>Mosque Size*</small></label>
                                            <asp:DropDownList CssClass="form-control form-control-sm col main-txtb" runat="server" ID="ddUpdateMosqueSize">
                                                <asp:ListItem Selected disabled Value="None"></asp:ListItem>
                                                <asp:ListItem Value="Small">Small</asp:ListItem>
                                                <asp:ListItem Value="Medium">Medium</asp:ListItem>
                                                <asp:ListItem Value="Large">Large</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="form-group col-sm-6 col-6 mb-0">
                                            <label class="col mb-0 p-0 small">Active*</label>
                                            <asp:DropDownList CssClass="form-control form-control-sm col main-txtb" runat="server" ID="ddUpdateMosqueActive">
                                                <asp:ListItem Selected disabled Value="None"></asp:ListItem>
                                                <asp:ListItem  Value="Y">Yes</asp:ListItem>
                                                <asp:ListItem Value="N">No</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="form-group col-sm-12 mb-1">
                                            <label class="col mb-0 p-0"><small>Mosque Quote</small></label>
                                            <asp:TextBox TextMode="MultiLine" Style=" max-height:90px; min-height:90px;" MaxLength="500" CssClass=" position-static form-control form-control-sm col main-txtb" runat="server" ID="txtUpdateMosqueQuote"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="form-group col-sm-12 mb-1">
                                            <label class="col mb-0 p-0"><small>Mosque Image</small></label>
                                            <asp:FileUpload CssClass=" form-control form-control-sm col main-txtb" runat="server" ID="fupUpdateMosqueImage" />
                                        </div>
                                    </div>
                                    <div class="form-row m-0 p-0">
                                        <div class="form-group col-sm-12 m-0 p-0 flex-wrap" style="overflow:hidden;">
                                            <asp:Label runat="server"  ID="lblUpdateMosqueError" CssClass=" small m-0 p-0"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="card-footer text-center text-nowrap border-top-0">
                                        <asp:Button CssClass="topnav btn btn-sm btn-outline-light mr-2" runat="server" ID="btnUpdateMosqueDetails" Text="Update Details" OnClick="btnUpdateMosqueDetails_Click"/>
                                        <asp:Button CssClass="topnav btn btn-sm btn-outline-light" runat="server" ID="btnCancelMosqueUpdate" Text="Cancel" OnClick="btnCancelMosqueUpdate_Click"/>
                                    </div>
                                </div>
                            </div>
                            <%-- Overlay for Scholar Registration List selection--%>
                            <div class="col-6 col-sm-6 col-xl-4 text-nowrap" runat="server" id="divSchDetailsOverlay">
                                <div class="w-100 h-100 container text-center">
                                    <div class=" container h-25 mb-3"></div>
                                        <h6 class="card-title h-50 mt-5 pt-5"><img class="figure-img mr-2" src="MyAdmin/icons/outline_error_outline_black_18dp.png" />No Scholar Selected.</h6>
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
                                            <div class="col position-static"><b>User Name:</b></div>
                                            <div class="col position-static text-truncate">
                                                <label class="m-0" runat="server" id="lblMemberID"></label>
                                            </div>
                                        </div>
                                        <div class="row mb-1 position-static">
                                            <div class="col position-static"><b>First Name:</b></div>
                                            <div  class="col position-static text-truncate">
                                                <label class="m-0" runat="server" id="lblMemberName"></label>
                                            </div>
                                        </div>
                                        <div class="row mb-1 position-static">
                                            <div class="col position-static"><b>Last Name:</b></div>
                                            <div class="col position-static text-truncate">
                                                <label class="m-0" runat="server" id="lblMemberLastName"></label>
                                            </div>
                                        </div>
                                        <div class="row mb-1 position-static">
                                            <div class="col position-static"><b>Date of Birth:</b></div>
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
                                            <div class="col position-static"><b>E-mail:</b></div>
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
                                            <asp:TextBox MaxLength="10" Onblur="NumbersOnlyMod();" CssClass=" form-control form-control-sm col main-txtb" runat="server" ID="txtModContactNo"></asp:TextBox>
                                        </div>
                                        <div class="form-group col-sm-6 mb-1">
                                            <label class="col mb-0 p-0 text "><small>Date of Birth*</small></label>
                                            <asp:TextBox MaxLength="10" Onkeyup="AddDateChars();" CssClass=" form-control form-control-sm col main-txtb" runat="server" ID="txtModDOB" placeholder="dd/mm/yyyy*"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="form-group col-sm-6 mb-1">
                                            <label class="col mb-0 p-0"><small>E-mail*</small></label>
                                            <asp:TextBox OnBlur="EmailValidationMod();" CssClass="form-control form-control-sm col main-txtb" runat="server" ID="txtModEmail"></asp:TextBox>
                                        </div>
                                        <div class="form-group col-sm-6 mb-1">
                                            <label class="col mb-0 p-0 text "><small>Qualification*</small></label>
                                            <asp:DropDownList CssClass=" form-control form-control-sm col main-txtb" ID="ddModQualification" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="form-group col-sm-12 mb-1 ">
                                            <label class="col mb-0 p-0 "><small>Password*</small></label>
                                            <asp:TextBox TextMode="Password" Onkeyup="ShowPass();" Onblur="VarifyPassword('btnRegModerater','lblModError');" CssClass="form-control form-control-sm col main-txtb" runat="server" ID="txtModPassword"></asp:TextBox>
                                        </div>
                                    </div>   
                                    <div class="form-row">
                                        <div class="form-group col-sm-12 mb-1 position-static">
                                            <label class="col mb-0 p-0 "><small>Retype Password*</small></label>
                                            <asp:TextBox TextMode="Password" Onkeyup="ShowPass();" Onblur="VarifyPassword('btnRegModerater','lblModError');" CssClass="form-control form-control-sm col main-txtb" runat="server" ID="txtModRetypePassword"></asp:TextBox>
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
                            <%-- Add a Administrator --%>
                            <div runat="server" id="divAddAdmin" class=" col-sm-12 col-xl-4 flex-nowrap p-0">
                                <div class=" head-div-2 p-2 mb-0 text-left">
                                    <p class="m-0">Add Details of Administrator</p>
                                </div>
                                <div class=" position-static p-1 lst-container align-content-xl-center">
                                    <div class="form-row">
                                        <div class="form-group col-sm-12 mb-1">
                                            <label class="col mb-0 p-0"><small>User Name*</small></label>
                                            <asp:TextBox CssClass="form-control form-control-sm col main-txtb" runat="server" ID="txtAdminUserName"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="form-group col-sm-6 mb-1">
                                            <label class="col mb-0 p-0 "><small>First Name*</small></label>
                                            <asp:TextBox CssClass="form-control form-control-sm col main-txtb" runat="server" ID="txtAdminFName"></asp:TextBox>
                                        </div>
                                        <div class="form-group col-sm-6 mb-1 ">
                                            <label class="col mb-0 p-0 "><small>Last Name*</small></label>
                                            <asp:TextBox CssClass=" form-control form-control-sm col main-txtb" runat="server" ID="txtAdminLName"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="form-group col-sm-6 mb-1 ">
                                            <label class="col mb-0 p-0 "><small>Contact Number</small></label>
                                            <asp:TextBox MaxLength="10" Onblur="NumbersOnlyAdmin();" CssClass=" form-control form-control-sm col main-txtb" runat="server" ID="txtAdminContactNo"></asp:TextBox>
                                        </div>
                                        <div class="form-group col-sm-6 mb-1">
                                            <label class="col mb-0 p-0 text "><small>Date of Birth*</small></label>
                                            <asp:TextBox MaxLength="10" Onkeyup="AddDateChars();" CssClass=" form-control form-control-sm col main-txtb" runat="server" ID="txtAdminDOB" placeholder="dd/mm/yyyy*"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="form-group col-sm-12 mb-1">
                                            <label class="col mb-0 p-0"><small>E-mail*</small></label>
                                            <asp:TextBox  Onblur="EmailValidationAdmin();" CssClass="form-control form-control-sm col main-txtb" runat="server" ID="txtAdminEmail"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="form-group col-sm-12 mb-1 ">
                                            <label class="col mb-0 p-0 "><small>Password*</small></label>
                                            <asp:TextBox TextMode="Password" Onkeyup="ShowPass();" Onblur="VarifyPassword('btnRegAdmin','lblAdminError');" CssClass="form-control form-control-sm col main-txtb" runat="server" ID="txtAdminPassword"></asp:TextBox>
                                        </div>
                                    </div>   
                                    <div class="form-row">
                                        <div class="form-group col-sm-12 mb-1 position-static">
                                            <label class="col mb-0 p-0 "><small>Retype Password*</small></label>
                                            <asp:TextBox TextMode="Password" Onkeyup="ShowPass();" Onblur="VarifyPassword('btnRegAdmin','lblAdminError');" CssClass="form-control form-control-sm col main-txtb" runat="server" ID="txtAdminRetypePassword"></asp:TextBox>
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
                                            <asp:Button CssClass="topnav btn btn-sm btn-outline-light mr-2" runat="server" ID="btnRegAdmin" OnClick="btnRegAdmin_Click" Text="Register Administrator" />
                                            <asp:Button CssClass="topnav btn btn-sm btn-outline-light" runat="server" ID="btnAdminRegCancel" OnClick="btnAdminRegCancel_Click" Text="Cancel" />
                                        </div>
                                        <div class="form-row mt-2 mb-0">
                                            <div class="form-group col-sm-12 m-0 flex-wrap text-truncate" style="overflow:hidden;">
                                                <small><asp:Label runat="server" ID="lblAdminError" CssClass="col m-0 p-0"></asp:Label></small>
                                            </div>
                                        </div>
                                        <hr class="mt-3 ml-3 mr-3 bg-secondary" />
                                    </div>
                                </div>
                            </div>
                            <%--Add/Update a Zakaah Organization--%>
                            <div class="col-6 col-xl-4 p-0 mr-1" runat="server" id="divZakaahOrgList">
                                <div class=" head-div-2 p-2 mb-1 text-left">
                                    <p class="m-0">All Organizations</p>
                                </div>
                                <div class=" p-1 lst-container"  style="overflow-y:scroll;">
                                    <asp:Repeater ID="rptZakaahOrg" runat="server">
                                        <HeaderTemplate>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnShowOrg" CommandArgument='<%#Eval("OrganizationID") %>' ToolTip="Select" CssClass="position-static lstBtn btn btn-block" runat="server" OnClick="btnShowOrg_Click">
                                                    <div class="p-0 form-row p-1 m-0 position-static flex-nowrap">
                                                        <div class="col-auto position-static p-0">
                                                            <div class="">
                                                                <p style="font-size:small;" class=" p-0 m-0"><b>Name: </b><%#Eval("Name")%><br/></p>
                                                            </div>
                                                                <hr class=" mr-4 m-0 p-0"/>
                                                            <div class="">
                                                                <p  style="font-size:smaller;" class="p-0 m-0 text-truncate"><b>Contact No. </b><%#Eval("ContactNo")%>&emsp;<b>Active:</b> <%#Convert.ToString(Eval("Active")).Replace("Y", "Yes") .Replace("N", "No")%></p>
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
                            <%-- Overlay for the Org --%>
                            <div class="col-sm-6 col-xl-4 text-nowrap" runat="server" id="divOrgOverlay">
                                <div class="w-100 h-100 container text-center">
                                    <div class=" container h-25 mb-3"></div>
                                    <h6 class="card-title h-50 mt-5 pt-5">
                                        <img class="figure-img mr-2" src="MyAdmin/icons/outline_error_outline_black_18dp.png" />No Zakaah Organization selected.</h6>
                                    <div class=" container h-25"></div>
                                </div>
                            </div>
                            <%-- Add/Update Organizations --%>
                            <div runat="server" id="divAddUpdateZakaahOrg" class=" col-sm-6 col-xl-4 flex-nowrap p-0">
                                <div class=" head-div-2 p-2 mb-0 text-left ">
                                    <p class="m-0">Add Details of Organization</p>
                                </div>
                                <div class=" position-static p-1 lst-container align-content-xl-center">
                                    <div class="form-row mt-2 mb-2" runat="server" id="divOrgImg">
                                        <div class="form-group col-sm-12 mb-1 text-center" style=" height:100px; width:150px">
                                            <asp:Image runat="server" ID="imgOrgImage" AlternateText="Organization Logo not set" CssClass=" img-thumbnail figure-img" Style=" height:100px; width:150px" />
                                        </div>
                                    </div>
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
                                            <asp:TextBox MaxLength="12" Onblur="NumbersOnly();" CssClass="form-control form-control-sm col main-txtb" runat="server" ID="txtOrgContactNo"></asp:TextBox>
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
                                            <label class="col mb-0 p-0"><small>Organization Image or Logo</small></label>
                                            <asp:FileUpload CssClass="form-control form-control-sm col main-txtb" runat="server" ID="fupOrgImage"></asp:FileUpload>
                                        </div>
                                    </div>
                                    <hr class="mt-2 ml-3 mr-3 bg-secondary" />
                                    <div class="card-footer text-center text-nowrap border-top-0">
                                        <asp:Button CssClass="topnav btn btn-sm btn-outline-light mr-2" runat="server" ID="btnAddUpdateOrg" OnClick="btnAddUpdateOrg_Click" Text="Update Details" />
                                        <asp:Button CssClass="topnav btn btn-sm btn-outline-light" runat="server" ID="btnCancelAddUpdateOrg" OnClick="btnCancelAddUpdateOrg_Click" Text="Cancel" />
                                    </div>
                                    <hr class="mt-1 ml-3 mr-3 bg-secondary" />
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
                                                    <div class="p-0 form-row p-1 m-0 position-static flex-nowrap">
                                                        <div class="col-auto position-static p-0">
                                                            <div class="">
                                                                <p style="font-size:small;" class=" p-0 m-0"><b>Notice Title: </b><%#Eval("NoticeTitle")%><br/></p>
                                                            </div>
                                                                <hr class=" mr-4 m-0 p-0"/>
                                                            <div class="">
                                                                <p  style="font-size:smaller;" class="p-0 m-0 text-truncate"><b>Expiry Date: </b><%#Convert.ToDateTime(Eval("DateExpiry")).ToString("dd MMM yyyy")%>&emsp;<b>Active:</b> <%#Convert.ToString(Eval("Active")).Replace("Y", "Yes") .Replace("N", "No")%></p>
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
                            <%-- Overlay for Notices --%>
                            <div class="col-sm-6 col-xl-4 text-nowrap" runat="server" id="divNoticeOverlay">
                                <div class="w-100 h-100 container text-center">
                                    <div class=" container h-25 mb-3"></div>
                                    <h6 class="card-title h-50 mt-5 pt-5">
                                        <img class="figure-img mr-2" src="MyAdmin/icons/outline_error_outline_black_18dp.png" />No Noitce selected.</h6>
                                    <div class=" container h-25"></div>
                                </div>
                            </div>
                            <%-- Add/Update Notices --%>
                            <div runat="server" id="divAddUpdateNotice" class=" col-sm-10 col-xl-4 flex-nowrap p-0">
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
                                            <asp:TextBox  Enabled="false" CssClass="form-control form-control-sm col main-txtb" runat="server" MaxLength="35" ID="txtNoticeDateCreated"></asp:TextBox>
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
                            <%-- Update Islamic Date and Counter --%>
                            <div runat="server" id="divCounterCalander" class=" col-sm-12 col-xl-6 flex-nowrap p-0">
                                <div class=" head-div-2 p-2 mb-0 text-left">
                                    <p class="m-0">Update Islamic Date and Counter</p>
                                </div>
                                <div class=" position-static p-1 lst-container align-content-xl-center">
                                    <div class=" mt-1 card-header">
                                        <div class="form-group col-12 mb-1">
                                            <label class=" h5">Set up Count Down</label>
                                        </div>
                                    </div>
                                    <div class="form-row card-body">
                                        <div class="col">
                                            <div class="form-group col-12 mb-1">
                                                <label class="col mb-0 p-0"><small> Current Counter Title</small></label>
                                                <asp:TextBox Enabled="false" CssClass="form-control form-control-sm col main-txtb border-0" runat="server" MaxLength="25" ID="txtCurCounterTitle"></asp:TextBox>
                                            </div>
                                            <div class="form-group col-12 mb-1">
                                                <label class="col mb-0 p-0"><small>Current Counter End Title</small></label>
                                                <asp:TextBox Enabled="false" CssClass="form-control form-control-sm col main-txtb border-0" runat="server" ID="txtCurCounterEndTitle"></asp:TextBox>
                                            </div>
                                            <div class="form-group col-12 mb-1">
                                                <label class="col mb-0 p-0"><small> Current Counter End Date</small></label>
                                                <asp:TextBox Enabled="false" CssClass="form-control form-control-sm col main-txtb border-0" runat="server" ID="txtCurCounterEndDate"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col">
                                            <div class="form-group col-12 mb-1">
                                                <label class="col mb-0 p-0"><small>Counter Title*</small></label>
                                                <asp:TextBox CssClass="form-control form-control-sm col main-txtb" runat="server" MaxLength="23" ID="txtCounterTitle"></asp:TextBox>
                                            </div>
                                            <div class="form-group col-12 mb-1">
                                                <label class="col mb-0 p-0"><small>Counter End Title*</small></label>
                                                <asp:TextBox CssClass="form-control form-control-sm col main-txtb" runat="server" MaxLength="23" ID="txtCounterEndTitle"></asp:TextBox>
                                            </div>
                                            <div class="form-group col-12 mb-1">
                                                <label class="col mb-0 p-0"><small>Counter End Date*</small></label>
                                                <asp:TextBox TextMode="Date" CssClass="form-control form-control-sm col main-txtb" runat="server" ID="txtCounterEndDate"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class=" card-footer text-center">
                                        <asp:Button CssClass="topnav btn btn-sm btn-outline-light" runat="server" Text="Update Count Down" ID="btnUpdateCounter" OnClick="btnUpdateCounter_Click"></asp:Button>
                                    </div>
                                    <hr class="m-3 ml-3 mr-3 bg-secondary" />
                                    <div class=" card-header mt-3">
                                        <div class="form-group col-12 mb-1">
                                            <label class=" h5 ml-3">Adjust Islamic Date</label>
                                        </div>
                                    </div>
                                    <div class=" form-row card-body">
                                        <div class="col">
                                            <div class="form-group col-12 mb-1">
                                                <label class="col mb-0 p-0"><small>Current Adjustment</small></label>
                                                <asp:TextBox Enabled="false" CssClass="form-control form-control-sm col main-txtb border-0" runat="server" ID="txtCurIsalmicDate"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col">
                                            <div class="form-group col-12 mb-1">
                                                <label class="col mb-0 p-0"><small>Islamic Date Adjust Number</small></label>
                                                <asp:TextBox  MaxLength="2" placeholder="e.g 1, 2, -1, -2" CssClass="form-control form-control-sm col main-txtb" runat="server" ID="txtIslamicDate"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="card-footer text-center">
                                        <asp:Button CssClass="topnav btn btn-sm btn-outline-light" runat="server" Text="Update Count Down" ID="btnUpdateIslamicDate" OnClick="btnUpdateIslamicDate_Click"></asp:Button>
                                    </div>
                                </div>
                            </div>
                            <%-- View all Members List --%>
                            <div class="col-6 col-xl-4 p-0 mr-1" runat="server" id="divAllMembersList">
                                <div class=" head-div-2 p-2 mb-1 text-left">
                                    <p class="m-0">Pending Registrations</p>
                                </div>
                                <div class=" p-1 lst-container"  style="overflow-y:scroll;" >
                                    <asp:Repeater ID="rptMemberList" runat="server" OnItemCommand="rptViewPendingSch_ItemCommand">
                                        <HeaderTemplate>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnShowMember" CommandArgument='<%#Eval("MemberID") %>' CssClass="position-static lstBtn btn btn-block" runat="server" OnClick="btnShowMember_Click">
                                                    <div class="p-0 m-0 position-static p-1">
                                                        <div class="col-auto p-0 position-static">
                                                            <p style="font-size:small" class="p-0 border-0 m-0 text-truncate"><b>User&nbsp;Name: </b><%#Eval("MemberID")%><br/></p>
                                                        </div>
                                                        <div class=" col-auto position-static p-0">
                                                            <div class="">
                                                                <p style="font-size:small" class="p-0 m-0 text-truncate"><b>Full&nbsp;Name: </b><%#Eval("MemberName")%> <%#Eval("MemberLastName")%><br/></p>
                                                            </div>
                                                                <hr class=" m-0 p-0"/>
                                                            <div class="">
                                                                <p  style="font-size:smaller;" class="p-0 m-0 text-truncate"><b>Registration Date: </b><%#Convert.ToDateTime(Eval("ActivationDate")).ToString("dd MMM yyyy")%>&emsp;<b>Active:</b> <%#Convert.ToString(Eval("ActiveTypeID")).Replace("Y", "Yes") .Replace("N", "No") .Replace("T", "Temporary")%></p>
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
                            <%-- Overlay For AllMember List --%>
                            <div class="col-sm-6 col-xl-4 text-nowrap" runat="server" id="divMemberDetailsOverlay">
                                <div class="w-100 h-100 container text-center">
                                    <div class=" container h-25 mb-3"></div>
                                    <h6 class="card-title h-50 mt-5 pt-5">
                                        <img class="figure-img mr-2" src="MyAdmin/icons/outline_error_outline_black_18dp.png" />No Member selected.</h6>
                                    <div class=" container h-25"></div>
                                </div>
                            </div>
                            <%-- Display Details of All Members, Update Member active status --%>
                            <div runat="server" id="divMemberDetails" class=" col-6 col-xl-4 flex-nowrap p-0">
                                <asp:HiddenField runat="server" ID="hdfAllMemberID" Value="" />
                                <div class=" head-div-2 p-2 mb-0 text-left ">
                                    <p class="m-0">Scholar Details</p>
                                </div>
                                    <hr class="m-3 ml-3 mr-3 bg-secondary"/>
                                <div class="container text-nowrap" runat="server" id="div2">
                                    <div class="row mb-1 position-static">
                                        <div class="col position-static"><b>Member  ID:</b></div>
                                        <div class="col position-static text-truncate">
                                            <label class="m-0" runat="server" id="lblAllMemberID"></label>
                                        </div>
                                    </div>
                                    <div class="row mb-1 position-static">
                                        <div class="col position-static"><b>First Name:</b></div>
                                        <div  class="col position-static text-truncate">
                                            <label class="m-0" runat="server" id="lblAllMemberName"></label>
                                        </div>
                                    </div>
                                    <div class="row mb-1 position-static">
                                        <div class="col position-static"><b>Last Name:</b></div>
                                        <div class="col position-static text-truncate">
                                            <label class="m-0" runat="server" id="lblAllMemberLastName"></label>
                                        </div>
                                    </div>
                                    <div class="row mb-1 position-static">
                                        <div class="col position-static"><b>Date of Birth:</b></div>
                                        <div class="col position-static text-truncate">
                                            <label class="m-0" runat="server" id="lblAllMemberDOB"></label>
                                        </div>
                                    </div>
                                    <div class="row mb-1 position-static">
                                        <div class="col position-static"><b>Member Type:</b></div>
                                        <div class="col position-static text-truncate">
                                            <label class="m-0" runat="server" id="lblAllMemberType"></label>
                                        </div>
                                    </div>
                                    <div class="row mb-1 position-static">
                                        <div class="col position-static"><b>E-mail:</b></div>
                                        <div class="col position-static text-truncate">
                                            <label class="m-0" runat="server" id="lblAllEmail"></label>
                                        </div>
                                    </div>
                                    <div class="row mb-1 position-static">
                                        <div class="col position-static"><b>Contact No.</b></div>
                                        <div class="col position-static text-truncate">
                                            <label class="m-0" runat="server" id="lblAllContactNo"></label>
                                        </div>
                                    </div>
                                    <div class="row mb-1 position-static">
                                        <div class="col position-static"><b>Mosque ID:</b></div>
                                        <div class="col position-static text-truncate">
                                            <label class="m-0" runat="server" id="lblAllMosque"></label>
                                        </div>
                                    </div>
                                    <div class="row mb-1 position-static">
                                        <div class="col position-static"><b>Activation Date:</b></div>
                                        <div class="col position-static text-truncate">
                                            <label class="m-0" runat="server" id="lblAllActivationDate"></label>
                                        </div>
                                    </div>
                                    <div class="row mb-1 position-static">
                                        <div class="col position-static "><b>Active:</b></div>
                                        <div class="col position-static text-truncate">
                                            <asp:DropDownList CssClass="form-control form-control-sm col main-txtb" runat="server" ID="ddAllctiveTypeID"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                    <hr class="m-3 ml-3 mr-3 bg-secondary"/>
                                <div class="container p-0 m-2 task-action">
                                    <h6 class="w-100 card-title card-header">
                                        <img class="figure-img mr-2 mb-1 " src="MyAdmin/icons/outline_warning_black_18dp.png" />Before Changing Members Active status</h6>
                                    <div class=" position-static m-0 pb-sm-0 pb-xl-5 card-body">
                                        <ul class="pl-1">
                                            <li><p class="mb-0" ><small class="card-text">Changing the active status will disable the members account</small></p></li>
                                            <li><p class="mb-0"><small class="card-text">Mosque representative and the Mosque they represent will be disabled</small></p></li>
                                        </ul>
                                    </div>
                                    <div class="card-footer text-center position-static text-nowrap">
                                        <asp:Button CssClass=" topnav btn btn-sm btn-outline-light mr-2" runat="server" ID="btnUpdateAllMember" Text="Update Active Status" OnClick="btnUpdateAllMember_Click" />
                                        <asp:Button CssClass=" topnav btn btn-sm btn-outline-light" runat="server" ID="btnUpdateCancelAllMember" Text="Cancel" OnClick="btnUpdateCancelAllMember_Click" />
                                    </div>
                                </div>
                            </div>
                            <div runat="server" id="divAdminReports" class="col-12 col-xl-12 p-0 mr-1">
                                <div class=" head-div-2 p-2 mb-0 text-center ">
                                    <p class="m-0" runat ="server" id ="lblAdminReportHeading">Report</p>
                                </div>
                                <div class="m-0 p-0 pt-2 pl-2">
                                    <a runat="server" id="lnkAdminPrintPDF" onserverclick="lnkAdminPrintPDF_ServerClick"><img src="MyModerator/Adobe_PDF.png" /><small>Download as PDF</small></a>
                                    <hr class="m-0 mt-1 p-0" style="background-color:#0026ff; height:1px;" />
                                </div>
                                <div class=" p-1 report-container pre-scrollable" >
                                    <asp:GridView CssClass="flex-grow-1" ID="grdAdminReports"  RowStyle-Wrap="true" runat="server" style="font-size:smaller;" ForeColor="#333333" >
                                        <AlternatingRowStyle BackColor="White"  />
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" Font-Size="12" HorizontalAlign="Center" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#EFF3FB"  Wrap="true"  HorizontalAlign="Center"/>
                                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                    </asp:GridView>
                                </div>
                            </div>
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
                        <script src="../Content/Zakaah/slideshow.js"></script>
                  
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
                                   <a class="footerr-text" href="Mosque.aspx">Mosques</a>
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
