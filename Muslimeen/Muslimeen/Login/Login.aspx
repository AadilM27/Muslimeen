<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Muslimeen.Login.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server"><!-- Abdul-Hadi Bhat-->
        <meta charset="utf-8"/>
		<meta http-equiv="X-UA-Compatible" content="IE=edge"/>
		<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=yes"/>
	
		<link rel="icon" href="LogIn_Bootstrap/muslimeen.ico"/>
	
		<link href="LogIn_Bootstrap/css/bootstrap.min.css" rel="stylesheet"/>
		
		<title> Muslimeen - Log In </title>
	
		<link href="LogIn_Bootstrap/css/LogIn.css" rel="stylesheet"/>
        

</head>
<body class="text-center">
    <div class="main-div">

		<form class="form-logIn" runat="server">
			<asp:Image runat="server" CssClass="mb-2 mt-2" src="LogIn_Bootstrap/logo.png" width="220" height="130"/>
			<h1 class="h3 mb-1 mt-2 font-weight-bold">Log into Muslimeen</h1>
            <h1 class="h6 text-black-50 mt-2 mb-3">Access Muslimeen with<br /> your account</h1>
            <div class=" mb-2">
                <asp:TextBox runat="server" ID="txtUserName" CssClass=" form-control main-txtb" placeholder="User name" OnTextChanged="txtUserName_TextChanged"/>
            </div>
			<div class="mb-2">
                <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="form-control main-txtb" placeholder="Password"/>
			</div>
			<div class=" form-check mt-3 mb-3">
                <asp:CheckBox runat="server" AutoPostBack="true" ID="chkRememberMe" CssClass="form-check-input position-static"/>
				<asp:Label runat="server" CssClass="form-check-label" Text="Remember me">
				</asp:Label>
			</div>
			<asp:button runat="server" CssClass="btn btn-primary btn-lg btn-block main-btn " ID="btnLogIn" Text="Log in" OnClick="btnLogIn_Click"></asp:button>
            <div class="mb-2 mt-2">
                <asp:Label runat="server" Text="OR" Style="font-weight:bold; font-size:smaller;"></asp:Label>
            </div>
            <asp:button runat="server" CssClass="btn btn-primary btn-lg btn-block main-btn " ID="btnRegister" Text="Register" OnClick="btnRegister_Click"></asp:button>
            <p class="mt-3 mb-0" style="font-size:smaller;">Forgot your password ? <br /><asp:LinkButton CssClass=" font-weight-bold text-dark" ToolTip="Send new password to your email address" runat="server" ID="btnForgotPass" Text="Reset Password" OnClick="btnForgotPass_Click"></asp:LinkButton></p>
            <asp:Label CssClass="" runat="server" Text="OR" Style="font-size:smaller;"></asp:Label>
            <p class="mt-1 mb-0" style="font-size:smaller;">Go back to <asp:HyperLink CssClass=" font-weight-bold text-dark" runat="server" NavigateUrl="../Content/Default.aspx" Text="Home page"></asp:HyperLink></p>
            <div class=" mt-3 form-group col " style="text-align:center;">
                <asp:Label CssClass="lblError" runat="server" ID="lblErrorPass"></asp:Label>
            </div>
                <script src="js/Login.js"></script>
		</form>
        </div>
	</body>
</html>
