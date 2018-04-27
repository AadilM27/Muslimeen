﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Muslimeen.SignIn.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

        <meta charset="utf-8"/>
		<meta http-equiv="X-UA-Compatible" content="IE=edge"/>
		<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
	
		<link rel="icon" href="LogIn_Bootstrap/muslimeen.ico"/>
	
		<link href="LogIn_Bootstrap/css/bootstrap.min.css" rel="stylesheet"/>
		
		<title> Muslimeen - Log In </title>
	
		<link href="LogIn_Bootstrap/css/LogIn.css" rel="stylesheet"/>

</head>
<body class="text-center">
    <div class="main-div">

		<form class="form-logIn" runat="server">
			<asp:Image runat="server" CssClass="mb-2" src="LogIn_Bootstrap\logo.png" width="220" height="130"/>
			<h1 class="h3 mb-1 mt-2 font-weight-bold">Log in to Muslimeen</h1>
            <h1 class="h6 text-black-50 mt-2 mb-3">Access Muslimeen with<br /> a free account</h1>
            <div class=" mb-2">
                <asp:TextBox runat="server" ID="inputEmail" CssClass=" form-control main-txtb" placeholder="Email address"/>
            </div>
			<div class="mb-2">
                <asp:TextBox runat="server" ID="inputPassword" CssClass="form-control main-txtb" placeholder="Password"/>
			</div>
			<div class=" form-check mt-3 mb-3">
                <asp:CheckBox runat="server" CssClass="form-check-input position-static"/>
				<asp:Label runat="server" CssClass="form-check-label" Text="Remember me">
				</asp:Label>
			</div>
			
			<asp:button runat="server" CssClass="btn btn-primary btn-lg btn-block main-btn " ID="btnLogIn" Text="Log in"></asp:button>
            <div class="mb-2 mt-2">
                <asp:Label runat="server" Text="OR" Style="font-weight:bold; font-size:smaller;"></asp:Label>
            </div>
            <asp:button runat="server" CssClass="btn btn-primary btn-lg btn-block main-btn " ID="btnRegister" Text="Register" OnClick="btnRegister_Click"></asp:button>

		</form>
        </div>
	</body>
</html>