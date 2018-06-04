<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfileEditer.aspx.cs" Inherits="Muslimeen.Content.ProfileEditer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <meta charset="utf-8"/>
		<meta http-equiv="X-UA-Compatible" content="IE=edge"/>
		<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
	
		<link rel="icon" href="/Login/LogIn_Bootstrap/muslimeen.ico"/>
	
		<link href="/Login/LogIn_Bootstrap/css/bootstrap.min.css" rel="stylesheet"/>
		
		<title> Muslimeen - Edit Profile</title>

        <script src="/Register/Register.js" type="text/javascript"></script>

		<link href="..\Content\ProfileEditer\css\ProfileEditer.css" rel="stylesheet"/>
</head>
<body class="text-center">
    <div class="main-div">
			<asp:Image runat="server" CssClass="mb-2 mt-2" src="../Login/LogIn_Bootstrap/logo.png" width="200" height="130"/>
			<h1 class="h3 mb-1 mt-2 font-weight-bold">Update your profile</h1>
            <h1 class="h6 text-black-50 mt-2 mb-3">Update your profile as desired</h1>
        
        <form class=" form-profileEditer" runat="server" id="frmRegister" method="post">
            <div class="form-row">
                <div class="form-group col-sm-12 mb-1 mt-1">
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
                    <asp:TextBox CssClass="form-control col main-txtb" runat="server" ID="txtContactNum" placeholder="Contact Number"></asp:TextBox>
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-sm-5  mb-1 mt-1">
                 <asp:TextBox CssClass="form-control col main-txtb" runat="server" ID="txtUserEmail" placeholder="Email Address*"></asp:TextBox>
                </div>
            </div>
            <div class="form-row">
                <div class=" form-group col-sm-12 mt-1 mb-1" id="divScholarQual" >
                    <asp:DropDownList runat="server" CssClass=" form-control main-txtb" Visible="false" ID="ddScholarQual" placeholder="Qualification description:"></asp:DropDownList>
                </div>
                <div class="form-group col-sm-12 mb-1 mt-1">
                    <asp:TextBox runat="server" CssClass="form-control main-txtb" ID="TextBox1" type="password" placeholder="Old Password*"></asp:TextBox>
                </div>
                <div class="form-group col-sm-12 mb-1 mt-1">
                    <asp:TextBox runat="server" CssClass="form-control main-txtb" ID="txtPassword" type="password" placeholder="New Password*"></asp:TextBox>
                </div>
                <div class=" form-group col-sm-12 mt-1 mb-2">
                    <asp:TextBox runat="server"  CssClass="form-control" ID="txtRetypePass" type="password" placeholder="Retype New Password*"></asp:TextBox>
                </div>
                <div style="text-align:left; padding-left:10px;" class=" form-group col-sm-12 mt-0 mb-0">
                    <input type="checkbox" id="chkShowPassword" onclick="CheckPassword()"/>
                    <label  for="chkShowPassword"  runat="server">Show Password</label>
                </div>
                <div class="form-group col " style="text-align:center;">
                    <asp:Label CssClass="lblError" runat="server" ID="lblErrorPass"></asp:Label>
                </div>
            </div>
                <asp:button runat="server" CssClass="btn btn-primary main-btn mt-2 " ID="btnRegister" Text="Register"></asp:button>
            <p class=" text-center mt-3">Go back to the <asp:HyperLink CssClass=" font-weight-bold text-dark" runat="server" NavigateUrl="~/Content/Default.aspx"  Text="Home page"></asp:HyperLink></p>
            <input type="hidden" id="hfdPassword" value=""/>
        </form>
     </div>
</body>
</html>
