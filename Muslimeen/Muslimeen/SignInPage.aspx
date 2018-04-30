<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignInPage.aspx.cs" Inherits="Signin_Page.SignInPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	
		<meta charset="utf-8"/>
		<meta http-equiv="X-UA-Compatible" content="IE=edge"/>
		<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
	
		<link rel="icon" href="Signin_Bootstrap/muslimeen.ico"/>
	
		<link href="Signin_Bootstrap/css/bootstrap.min.css" rel="stylesheet"/>
		
		<title> Muslimeen - Sign In </title>
	
		<link href="Signin_Bootstrap/css/signin.css" rel="stylesheet"/>
	</head>
	
	<body class="text-center">
		<form class="form-signin">
			<img class="mb-4" src="logo.png" width="220" height="130"/>
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
			
			<button class="btn btn-lg btn-primary btn-block" type="submit"> Sign in </button>
		</form>
	</body>
</html>

