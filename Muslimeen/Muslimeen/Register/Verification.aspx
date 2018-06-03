<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Verification.aspx.cs" Inherits="Muslimeen.Register.Verification" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

        <meta charset="utf-8"/>
		<meta http-equiv="X-UA-Compatible" content="IE=edge"/>
		<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
	
        <link rel="icon" href="/Login/LogIn_Bootstrap/muslimeen.ico"/>
		
        <link href="/Login/LogIn_Bootstrap/css/bootstrap.min.css" rel="stylesheet"/>
		
		<title> Muslimeen - Verify Account </title>

		<link href="/Login/LogIn_Bootstrap/css/Verification.css" rel="stylesheet"/>

</head>
<body class="text-center">
    <div class="main-div">
		<form class="form-logIn" runat="server">
			<asp:Image runat="server" CssClass="mb-2" src="/Login/LogIn_Bootstrap/logo.png" width="220" height="130"/>
			<h1 class="h3 mb-1 mt-2 font-weight-bold">Please Verify Your<br />Muslimeen Account</h1>
            <h1 class="h6 text-black-50 mt-2 mb-3">Access Muslimeen with<br /> a free account</h1>
            <div class=" mb-2">
                <asp:TextBox runat="server" ID="txtMemberID" CssClass=" form-control main-txtb" placeholder="User Name"/>
            </div>
			<div class="mb-5">
                <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="form-control main-txtb" placeholder="Password"/>
			</div>
            <div class="form-group col " style="text-align:center;">
                <asp:Label CssClass="lblError" runat="server" ID="lblErrorPass" style="text-decoration-color:red;" ></asp:Label>
            </div>
			<asp:button runat="server" CssClass="btn btn-primary main-btn" ID="btnVerify" Text="Verify Account" OnClick="btnVerify_Click"></asp:button>

            <p class="mt-3 mb-0" style="font-size:smaller;">Don't want to verify your account ?<br /> <asp:HyperLink CssClass=" font-weight-bold text-dark" runat="server" NavigateUrl="~/Register/Register.aspx"  Text="Register new account"></asp:HyperLink></p>
            <asp:Label CssClass="" runat="server" Text="OR" Style="font-size:smaller;"></asp:Label>
            <p class=" text-center" style="font-size:smaller;">Go back to the <asp:HyperLink CssClass=" font-weight-bold text-dark" runat="server" NavigateUrl="~/Content/Default.aspx"  Text="Home page"></asp:HyperLink></p>
		</form>
        </div>
	</body>
</html>