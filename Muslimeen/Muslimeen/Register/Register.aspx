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
            
            <form class="form-logIn" runat="server">

            <div class="form-row">
                <div class="form-group col-sm-5 mb-1 mt-1">
                    <asp:TextBox CssClass="form-control col" runat="server" ID="txtName" placeholder="First Name"></asp:TextBox>
                </div>
                <div class="form-group col-sm-7 mb-1 mt-1">
                    <asp:TextBox CssClass="form-control col" runat="server" ID="txtLName" placeholder="Last Name"></asp:TextBox>
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-sm-5 mb-1 mt-1">
                    <asp:TextBox CssClass="form-control col " runat="server" ID="TextBox2" placeholder="Phone Number"></asp:TextBox>
                </div>
                <div class="form-group col-sm-2 mb-1 mt-1">
                    <asp:TextBox CssClass="form-control col" runat="server" ID="txtDD" placeholder="DD"></asp:TextBox>
                </div>
                <div class="form-group col-sm-2 mb-1 mt-1">
                    <asp:TextBox CssClass="form-control col" runat="server" ID="txtMM" placeholder="MM"></asp:TextBox>
                </div>
                <div class="form-group col-sm-3 mb-1 mt-1">
                    <asp:TextBox CssClass="form-control col" runat="server" ID="txtYYYY" placeholder="YYYY"></asp:TextBox>
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-sm-5  mb-1 mt-1">
                 <asp:TextBox CssClass="form-control col" runat="server" ID="txtUserEmail" placeholder="Email Address"></asp:TextBox>
                </div>
                <div class="form-group col-sm-7  mb-1 mt-1">
                    <asp:DropDownList CssClass="form-control col" runat="server" ID="ddUsertype" AutoPostBack="true" OnSelectedIndexChanged="ddUsertype_SelectedIndexChanged" OnTextChanged="ddUsertype_SelectedIndexChanged" >
                        <asp:ListItem Selected="True" Value="">Registration type:</asp:ListItem>
                        <asp:ListItem Value="Member" >Member</asp:ListItem>
                        <asp:ListItem Value="Scholar">Scholar</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
                <div class="mt-2 mb-2">
                    <asp:TextBox runat="server" CssClass=" form-control" Visible="false" ID="txtScholarQual" placeholder="Qualification description:"></asp:TextBox>
                </div>
                <div class="input-group mt-1">
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtPassword" placeholder="Password"></asp:TextBox>
                    <div class="input-group-prepend">
                        <div>
                            <asp:Button Text="Show" ID="btnShowPass" CssClass="btn" runat="server"/>
                        </div>
                    </div>
               </div>
                <div class="mt-2 mb-3">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtRetypePass" placeholder="Retype Password"></asp:TextBox>
                </div>
                <asp:button runat="server" CssClass="btn btn-primary main-btn mt-2 " ID="btnRegister" Text="Register"></asp:button>
        </form>
</body>
</html>
