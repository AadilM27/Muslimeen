<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Muslimeen.Content.Error" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
	<meta name="viewport" content="width=device-width, height=device-height, initial-scale=0.0"/>

    <link rel="icon" href="../Login/LogIn_Bootstrap/muslimeen.ico"/>
    <title>Muslimeen - Error</title>
    <link href="../Signin_Bootstrap/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="frmError" runat="server">
        <div class=" form-row align-content-center">
            <div class=" col-5">
                <img class="img-fluid" src="../Signin_Bootstrap/logo.png" />   
            </div>
            <div class="col-7">

            </div>
        </div>
        <div class="form-row mt-4">
            <div class="col text-center">
                <h3>The page you have requested is not available</h3>
            </div>
        </div>
        <div class="form-row mt-5">
            <div class="col-2">

            </div>
            <div class="col-7">
                <h5>Reasons why:</h5>
            </div>
        </div>
        <div class="form-row mt-4 ml-5 align">
            <div class="col-2">

            </div>
            <div class="col-7">
                <ul>
                    <li>
                        You may not have access to this page
                    </li>
                    <li>
                        The page may be temporarily unavailable
                    </li>
                    <li>
                        The page requested is spelt wrong
                    </li>
                    <li>
                        The page requested may not exist
                    </li>
                </ul>
            </div>
        </div>
        <div class="form-row mt-4 ml-5 align">
            <a href="Default.aspx" class="alert-primary">Return to Home Page...</a> 
        </div>

    </form>
</body>
</html>
