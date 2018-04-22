<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Muslimeen.SignIn.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
        <meta charset="utf-8"/>
		<meta http-equiv="X-UA-Compatible" content="IE=edge"/>
		<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
	
		<link rel="icon" href="SignIn_Bootstrap/muslimeen.ico"/>
	
		<link href="SignIn_Bootstrap/css/bootstrap.min.css" rel="stylesheet"/>
		
		<title> Muslimeen - Sign In </title>
	
		<link href="SignIn_Bootstrap/css/signin.css" rel="stylesheet"/>
</head>
    <body class="text-center">
		<form class="form-signin" runat="server">
			<img class="mb-4" src="SignIn_Bootstrap\logo.png" width="220" height="130"/>
			<h1 class="h3 mb-3 font-weigth-normal"> Please sign in </h1>
			<label for="inputEmail" class="sr-only"> Email address </label>
			<input type="email" id="inputEmail" class="form-control" placeholder="Email address"/> <%--Put required validation--%>
			<label for="inputPassword" class="sr-only"> Password </label>
			<input type="password" id="inputPassword" class="form-control" placeholder="Password"/> <%--Put required validation--%>
			
			<div class="checkbox mb-3">
				<label>
					<input type="checkbox" value="remember me"/> Remember me
				</label>
			</div>
			
			<asp:button runat="server" CssClass="btn btn-lg btn-primary btn-block" ID="btnSignIn" Text="Sign In"></asp:button>
		</form>
	</body>
</html>
