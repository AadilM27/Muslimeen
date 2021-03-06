﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfileEditer.aspx.cs" Inherits="Muslimeen.Content.ProfileEditer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <meta charset="utf-8"/>
		<meta http-equiv="X-UA-Compatible" content="IE=edge"/>
		<meta name="viewport" content="width=device-width,height=device-height, initial-scale=0.0"/>
	
		<link rel="icon" href="../Login/LogIn_Bootstrap/muslimeen.ico"/>
	
		<link href="../Login/LogIn_Bootstrap/css/bootstrap.min.css" rel="stylesheet"/>
		
		<title> Muslimeen - Edit Profile</title>

        <script src="../Register/Register.js" type="text/javascript"></script>

		<link href="ProfileEditer/css/ProfileEditer.css" rel="stylesheet"/>
</head>
    <div id="divAlertPopup" runat="server" style="display:none; position:absolute; top:0;" class="container-fluid text-center p-2 m-0 w-100 alert alert-success visible">
        <label class="h6" id="lblAlertError"  runat="server" ></label>
    </div>
<body class="text-center">
    <asp:HyperLink ID="lnk1" runat="server" href="HelpPage.aspx"></asp:HyperLink>
    <div class="main-div">
			<asp:Image runat="server" CssClass="mb-2 mt-2" src="../Login/LogIn_Bootstrap/logo.png" width="200" height="130"/>
			<h1 class="h3 mb-1 mt-2 font-weight-bold">Update your profile</h1>
            <h1 class="h6 text-black-50 mt-2 mb-3">Update your profile as desired</h1>
        
        <form class=" form-profileEditer" runat="server" id="frmRegister" method="post">
            <div class="form-row">
                <div class="form-group text-left col-sm-5 mb-1 mt-1">
                    <label>User Name: </label>
                </div>
                <div class="form-group col-sm-7 mb-1 mt-1">
                    <asp:TextBox CssClass="form-control col main-txtb" runat="server" ID="txtUserName"></asp:TextBox>
                </div>
            </div>
            <div class="form-row">
                <div class="form-group text-left col-sm-5 mb-1 mt-1">
                    <label>First Name:* </label>
                </div>
                <div class="form-group col-sm-7 mb-1 mt-1">
                    <asp:TextBox CssClass="form-control col main-txtb" runat="server" ID="txtName"></asp:TextBox>
                </div>
            </div>
            <div class="form-row">
                <div class="form-group text-left col-sm-5 mb-1 mt-1">
                    <label>Last Name:* </label>
                </div>
                <div class="form-group col-sm-7 mb-1 mt-1">
                    <asp:TextBox CssClass="form-control col main-txtb" runat="server" ID="txtLName"></asp:TextBox>
                </div>
            </div>
            <div class="form-row">
                <div class="form-group text-left col-sm-5 mb-1 mt-1">
                    <label>Contact Number: </label>
                </div>
                <div class="form-group text-left col-sm-7 mb-1 mt-1">
                    <asp:TextBox CssClass="form-control col main-txtb" Onblur="NumbersOnly();"  runat="server" MaxLength="10" ID="txtContactNum"></asp:TextBox>
                </div>
            </div>
            <div class="form-row">
                <div class="form-group text-left col-sm-5 mb-1 mt-1">
                    <label>Date Of Birth: </label>
                </div>
                <div class="form-group col-sm-7 mb-1 mt-1">
                    <asp:TextBox CssClass="form-control col main-txtb" runat="server" ID="txtDOB"></asp:TextBox>
                </div>
            </div>
            <div class="form-row ">
                <div class="form-group text-left col-sm-5 mb-1 mt-1">
                    <label>Email Address:* </label>
                </div>
                <div class="form-group col-sm-7  mb-1 mt-1">
                    <asp:TextBox CssClass="form-control col main-txtb" Onblur="EmailValidation();" runat="server" ID="txtUserEmail"></asp:TextBox>
                </div>
            </div>
            <div class="form-row">
                <div class="form-group text-left col-sm-5 mb-1 mt-1">
                    <label>Member Type: </label>
                </div>
                <div class="form-group col-sm-7 mb-1 mt-1">
                    <asp:TextBox CssClass="form-control col main-txtb" runat="server" ID="txtMemberType"></asp:TextBox>
                </div>
            </div>
            <div class="form-row" runat="server" id="divQual">
                <div class="form-group text-left col-sm-5 mb-1 mt-1">
                    <label>Qualification: </label>
                </div>
                <div class=" form-group col-sm-7 mt-1 mb-1" >
                    <asp:TextBox runat="server" CssClass=" form-control main-txtb" ID="txtQual" ></asp:TextBox>
                </div>
            </div>
            <div class="form-row">
                <div class="form-group text-left col-sm-5 mb-1 mt-1">
                    <label>Assigned Mosque: </label>
                </div>
                <div class=" form-group col-sm-7 mt-1 mb-1" id="">
                    <asp:DropDownList runat="server" CssClass=" form-control main-txtb" ID="ddAssignedMosques"></asp:DropDownList>
                </div>
            </div>
            <div class="form-row">
                <div class="form-group text-left col-sm-5 mb-1 mt-1">
                    <label>Activation Date: </label>
                </div>
                <div class=" form-group col-sm-7 mt-1 mb-1" id="">
                    <asp:TextBox runat="server" CssClass=" form-control main-txtb" ID="txtActivationDate"></asp:TextBox>
                </div>
            </div>
            <div class="form-row">
                <div class=" form-group col-sm-12 mt-2 mb-1 text-left">
                    <asp:CheckBox runat="server" autopostback="true" ID="chkChangePassword" OnCheckedChanged="chkChangePassword_CheckedChanged"/>
                    <asp:label runat="server" AssociatedControlID="chkChangePassword">Change Password</asp:label>
                </div>
            </div>

            <!--HIDE FROM HERE -->
            <div class="form-row" runat="server" id="divChangePassword">
                <div class="form-group col-sm-12 mb-1 mt-1">
                    <asp:TextBox runat="server" CssClass="form-control main-txtb"  Onblur="VarifyPassword('btnUpdate', 'lblErrorPass')" ID="txtOldPassword" type="password" placeholder="Old Password*"></asp:TextBox>
                </div>
                <div class="form-group col-sm-12 mb-1 mt-1">
                    <asp:TextBox runat="server" CssClass="form-control main-txtb" Onblur="VarifyPassword('btnUpdate', 'lblErrorPass')" ID="txtPassword" type="password" placeholder="New Password*"></asp:TextBox>
                </div>
                <div class=" form-group col-sm-12 mt-1 mb-2">
                    <asp:TextBox runat="server"  CssClass="form-control" ID="txtRetypePass" Onblur="VarifyPassword('btnUpdate', 'lblErrorPass')" type="password" placeholder="Retype New Password*"></asp:TextBox>
                </div>
                <div style="text-align:left; padding-left:10px;" class=" form-group col-sm-12 mt-0 mb-0">
                    <input type="checkbox" id="chkShowPassword" onclick="CheckPassword()"/>
                    <label  for="chkShowPassword"  runat="server">Show Password</label>
                </div>
            </div>
                <asp:button runat="server" CssClass="btn btn-primary main-btn mt-2 " ID="btnUpdate" Text="Update" OnClick="btnUpdate_Click"></asp:button>
                <div class="form-group col m-2" style="text-align:center;">
                    <asp:Label CssClass="lblError" runat="server" ID="lblErrorPass"></asp:Label>
                </div>
                <p class=" text-center mt-3">Go back to the <asp:HyperLink CssClass=" font-weight-bold text-dark" runat="server" NavigateUrl="../Content/Default.aspx"  Text="Home page"></asp:HyperLink></p>
                <input type="hidden" id="hfdPassword" value=""/>
        </form>
     </div>
    <script src="Default/DefaultJq.js"></script>
</body>
</html>
