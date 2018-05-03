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
			<asp:Image runat="server" CssClass="mb-2" src="/Login/LogIn_Bootstrap\logo.png" width="220" height="130"/>
			<h1 class="h3 mb-1 mt-2 font-weight-bold">Register on Muslimeen</h1>
            <h1 class="h6 text-black-50 mt-2 mb-3">Access Muslimeen with<br />a free account</h1>
            
        <form class="form-logIn" runat="server" id="frmRegister">
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
                    <asp:TextBox CssClass="form-control col main-txtb" runat="server" ID="txtContactNum" placeholder="Contact Number"></asp:TextBox>
                </div>
                <div class="form-group col-sm-2 mb-1 mt-1">
                    <asp:TextBox CssClass="form-control col main-txtb" runat="server" ID="txtDD" placeholder="DOB:DD*"></asp:TextBox>
                </div>
                <div class="form-group col-sm-2 mb-1 mt-1">
                    <asp:TextBox CssClass="form-control col main-txtb" runat="server" ID="txtMM" placeholder="DOB:MM*"></asp:TextBox>
                </div>
                <div class="form-group col-sm-3 mb-1 mt-1">
                    <asp:TextBox CssClass="form-control col main-txtb" runat="server" ID="txtYYYY" placeholder="DOB:YYYY*"></asp:TextBox>
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-sm-5  mb-1 mt-1">
                 <asp:TextBox CssClass="form-control col main-txtb" AutoPostBack="true" runat="server" ID="txtUserEmail" placeholder="Email Address*"></asp:TextBox>
                </div>
                <div class="form-group col-sm-7 mb-1 mt-1">
                    <asp:DropDownList CssClass="form-control col" runat="server" ID="ddUsertype" AutoPostBack="true" OnSelectedIndexChanged="ddUsertype_SelectedIndexChanged" OnTextChanged="ddUsertype_SelectedIndexChanged" >
                        <asp:ListItem Selected="True" Value="">Registration type . . .*</asp:ListItem>
                        <asp:ListItem Value="Member" >Member</asp:ListItem>
                        <asp:ListItem Value="Scholar">Scholar</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-row">
                <div class=" form-group col-sm-12 mt-1 mb-1" aria-disabled="false" id="divScholarQual" >
                    <asp:DropDownList runat="server" CssClass=" form-control main-txtb" Visible="false" ID="ddScholarQual" placeholder="Qualification description:"></asp:DropDownList>
                </div>
                <div class="form-group col-sm-12 mb-1 mt-1">
                    <asp:TextBox runat="server" CssClass="form-control main-txtb" ID="txtPassword" TextMode="Password" placeholder="Password*"></asp:TextBox>
                </div>
                <div class=" form-group col-sm-12 mt-1 mb-2">
                    <asp:TextBox runat="server"  CssClass="form-control" ID="txtRetypePass" TextMode="Password" placeholder="Retype Password*"></asp:TextBox>
                </div>
                <div style="text-align:left; padding-left:10px;" class=" form-group col-sm-12 mt-0 mb-0">
                    <asp:CheckBox runat="server" AutoPostBack="true" ID="chkShowPassword" OnCheckedChanged="chkShowPassword_CheckedChanged"/>
                    <asp:Label  AssociatedControlID="chkShowPassword" Text="Show Password" runat="server"></asp:Label>
                </div>
                <div class="form-group col " style="text-align:center;">
                    <asp:Label CssClass="lblErrorPass" runat="server" Text="" ID="lblErrorPass"></asp:Label>
                </div>
            </div>
                <asp:button runat="server" CssClass="btn btn-primary main-btn mt-2 " ID="btnRegister" Text="Register" OnClick="btnRegister_Click" UseSubmitBehavior="True"></asp:button>

            <p class="mt-3">Have a account? <asp:HyperLink CssClass=" font-weight-bold text-dark" runat="server" NavigateUrl="~/Login/Login.aspx"  Text="Log in"></asp:HyperLink></p>
        </form>
     </div>
</body>
</html>
