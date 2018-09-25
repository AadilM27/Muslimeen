<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Muslimeen.Register.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <meta charset="utf-8"/>
		<meta http-equiv="X-UA-Compatible" content="IE=edge"/>
	<meta name="viewport" content="width=device-width, height=device-height, initial-scale=0.0"/>
	
		<link rel="icon" href="../Login/LogIn_Bootstrap/muslimeen.ico"/>
	
		<link href="../Login/LogIn_Bootstrap/css/bootstrap.min.css" rel="stylesheet"/>
		
		<title> Muslimeen - Register a account </title>

        <script src="Register.js" type="text/javascript"></script>

		<link href="../Login/LogIn_Bootstrap/css/register.css" rel="stylesheet"/>
</head>
<body class="text-center">
    <div class="main-div">
			<asp:Image runat="server" CssClass="mb-2 mt-2" src="../Login/LogIn_Bootstrap/logo.png" width="200" height="130"/>
			<h1 class="h3 mb-1 mt-2 font-weight-bold">Register on Muslimeen</h1>
            <h1 class="h6 text-black-50 mt-2 mb-3">Access Muslimeen with<br />a free account</h1>
            
        <form class="form-register" runat="server" id="frmRegister" method="post">
            <div class="form-row">
                <div class="form-group col-sm-12 mb-1 mt-1">
                    <asp:TextBox CssClass="form-control col main-txtb" runat="server" ID="txtUserName" placeholder="User Name*"></asp:TextBox>
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-sm-5 mb-1 mt-1">
                    <asp:TextBox CssClass="form-control col main-txtb" runat="server" ID="txtName" placeholder="First Name*"></asp:TextBox>
                </div>
                <div class="form-group col-sm-7 mb-1 mt-1">
                    <asp:TextBox CssClass="form-control col main-txtb" runat="server" ID="txtLName" placeholder="Last Name*"></asp:TextBox>
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-sm-5 mb-1 mt-1">
                    <asp:TextBox CssClass="form-control col main-txtb" MaxLength="10" Onblur="NumbersOnly();" runat="server" ID="txtContactNum" placeholder="Contact Number"></asp:TextBox>
                </div>
                <div class="form-group col-sm-7 mb-1 mt-1">
                    <asp:TextBox CssClass="form-control col main-txtb" runat="server" MaxLength="10" Onkeyup="AddDateChars();" ID="txtDOB" placeholder="dd/mm/yyyy*"></asp:TextBox>
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-sm-5  mb-1 mt-1">
                 <asp:TextBox CssClass="form-control col main-txtb" Onblur="EmailValidation();" runat="server" ID="txtUserEmail" placeholder="Email Address*"></asp:TextBox>
                </div>
                <div class="form-group col-sm-7 mb-1 mt-1">
                    <asp:DropDownList CssClass="form-control col" runat="server" ID="ddUsertype" AutoPostBack="true" OnSelectedIndexChanged="ddUsertype_SelectedIndexChanged" OnTextChanged="ddUsertype_SelectedIndexChanged" >
                        <asp:ListItem Selected disabled Value="None" >Registration Type*</asp:ListItem>
                        <asp:ListItem Value="M">Member</asp:ListItem>
                        <asp:ListItem Value="S">Scholar</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-row">
                <div class=" form-group col-sm-12 mt-1 mb-1" id="divScholarQual" >
                    <asp:DropDownList runat="server" CssClass=" form-control main-txtb" Visible="false" ID="ddScholarQual" placeholder="Qualification description:"></asp:DropDownList>
                </div>
                <div class="form-group col-sm-12 mb-1 mt-1">
                    <asp:TextBox runat="server" CssClass="form-control main-txtb" Onblur="VarifyPassword('btnRegister', 'lblErrorPass');" ID="txtPassword" type="password" placeholder="Password*"></asp:TextBox>
                </div>
                <div class=" form-group col-sm-12 mt-1 mb-1">
                    <asp:TextBox runat="server"  CssClass="form-control" Onblur="VarifyPassword('btnRegister','lblErrorPass');" ID="txtRetypePass" type="password" placeholder="Retype Password*"></asp:TextBox>
                </div>
                <div class="col-sm-12 mt-0 mb-0 text-left form-check-inline">
                    <input type="checkbox" class=" form-check form-check-input mt-1 mb-1" onclick="CheckPassword()" /><label class=" small text-justify form-check-label">Show Password</label>
                </div>
                <div class="form-group col " style="text-align:center;">
                    <asp:Label CssClass="lblError" runat="server" ID="lblErrorPass"></asp:Label>
                </div>
            </div>
                <asp:button runat="server" CssClass="btn btn-primary main-btn mt-2 " ID="btnRegister" Text="Register" OnClick="btnRegister_Click"></asp:button>

            <p class="mt-3 mb-0">Have a account ? <asp:HyperLink CssClass=" font-weight-bold text-dark" runat="server" NavigateUrl="../Login/Login.aspx"  Text="Log in"></asp:HyperLink></p>
            <asp:Label CssClass="" runat="server" Text="OR" Style="font-size:smaller;"></asp:Label>
            <p class=" text-center">Go back to the <asp:HyperLink CssClass=" font-weight-bold text-dark" runat="server" NavigateUrl="../Content/Default.aspx"  Text="Home page"></asp:HyperLink></p>
            <input type="hidden" id="hfdPassword" value=""/>
        </form>
     </div>
    <div class="bottom-nav w-100">
        <span class="bottom-nav-text" style="">©2018 NexTech</span>
    </div>
</body>
</html>
