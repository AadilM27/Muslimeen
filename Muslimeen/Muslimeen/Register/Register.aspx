<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Muslimeen.Register.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      
        <meta charset="utf-8"/>
		<meta http-equiv="X-UA-Compatible" content="IE=edge"/>
		<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
	
		<link rel="icon" href="/Login/LogIn_Bootstrap/muslimeen.ico"/>
	
		<link href="/Login/LogIn_Bootstrap/css/bootstrap.min.css" rel="stylesheet"/>
		
		<title> Muslimeen - Register </title>
	
		<link href="/Login/LogIn_Bootstrap/css/register.css" rel="stylesheet"/>

</head>
<body class="text-center">
    <div class="main-div">

		<form class="form-logIn" runat="server">
			<asp:Image runat="server" CssClass="mb-2" src="/Login/LogIn_Bootstrap\logo.png" width="220" height="130"/>
			<h1 class="h3 mb-1 mt-2 font-weight-bold">Register to Muslimeen</h1>
            <h1 class="h6 text-black-50 mt-2 mb-3">Access Muslimeen with<br />a free account</h1>
            <div class=" mb-2">
                <asp:TextBox runat="server" ID="txtInputEmail" CssClass=" form-control main-txtb" placeholder="Email address"/>
            </div>
			<div class="mb-2">
                <asp:TextBox runat="server" ID="txtInputPassword" CssClass="form-control main-txtb" placeholder="Password"/>
			</div>
            <div class=" mb-2">
                <asp:TextBox runat="server" ID="txtReEnterPass" CssClass=" form-control main-txtb" placeholder="Retype password"/>
            </div>
            <asp:button runat="server" CssClass="btn btn-primary btn-lg btn-block main-btn " ID="btnRegister2" Text="Register"></asp:button>

		</form>
        </div>
</body>
</html>
