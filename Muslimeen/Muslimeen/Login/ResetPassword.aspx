<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="Muslimeen.Login.ResetPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server"><!-- Abdul-Hadi Bhat-->
        <meta charset="utf-8"/>
		<meta http-equiv="X-UA-Compatible" content="IE=edge"/>
		<meta name="viewport" content="width=device-width, initial-scale=0.0"/>
	
		<link rel="icon" href="LogIn_Bootstrap/muslimeen.ico"/>
	
		<link href="LogIn_Bootstrap/css/bootstrap.min.css" rel="stylesheet"/>
		
		<title> Muslimeen - Log In </title>
	
		<link href="LogIn_Bootstrap/css/LogIn.css" rel="stylesheet"/>

</head>
<body class="text-center">
    <div class="main-div">

		<form class="form-logIn" runat="server">
			<asp:Image runat="server" CssClass="mb-2 mt-2" src="LogIn_Bootstrap/logo.png" width="220" height="130"/>
			<h1 class="h3 mb-1 mt-2 font-weight-bold">Reset your Password</h1>
            <h1 class="h6 text-black-50 mt-2 mb-3">Your new password will<br /> be sent via email </h1>
            <div class=" mb-2">
                <asp:TextBox runat="server" ID="txtUserName" CssClass="form-control main-txtb" placeholder="User name"/>
            </div>
			
			<asp:button runat="server" CssClass=" btn main-btn mt-3" style="color:white;" ID="btnReset" Text="Reset Password" OnClick="btnReset_Click"></asp:button>
            <p class="mt-3 mb-0" style="font-size:smaller;">Go back to <asp:HyperLink CssClass=" font-weight-bold text-dark" runat="server" NavigateUrl="../Content/Default.aspx" Text="Home page"></asp:HyperLink></p>
            <div class=" mt-3 form-group col " style="text-align:center;">
                <asp:Label CssClass="lblError" runat="server" ID="lblErrorPass"></asp:Label>
            </div>
		</form>
        </div>
        <div class="bottom-nav">
            <span class=" bottom-nav-text" style="">©2018 NexTech</span>
        </div>
	</body>
</html>
