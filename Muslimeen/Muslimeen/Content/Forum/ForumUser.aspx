<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForumUser.aspx.cs" Inherits="Muslimeen.Content.Forum.ForumUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/Forum.css" rel="stylesheet" />
<script  type="text/javascript">
			function Validate(theForm)
			{
			if (theForm.frmUserName.value == "")
   			{
			      alert("Please enter a username");
                theForm.frmUserName.focus();
                return (false);
			   }
			return (true)
			}
		</script>

</head>
<body onload="Javascript: document.form1.frmUserName.focus()">
    <form id="form1" method="post" runat="server" onSubmit="return Validate(this)" >
        <div>
            <table border="0" align= "center" cellspacing="1" cellpadding="5" bgcolor="purple">
				<tr>
					<td width="100%" class="TableItem">
						<b>Enter the Forum:</b>
						<table border="0" cellspacing="0" cellpadding="0">
							<tr>
								<td valign="top">
									Name:
									<asp:TextBox id="frmUserName" runat="server" Columns="15"></asp:TextBox>
								</td>
								<td valign="top" rowspan="2">
									<asp:Button id="Button1" runat="server" OnClick="DoLogin" Text="Go" CssClass="button"></asp:Button>
								</td>
							</tr>
							<tr>
								<td valign="top" align="right">
									<asp:TextBox id="frmPassword" Visible="False" runat="server" Columns="15" TextMode="Password"></asp:TextBox>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
        </div>
    </form>
</body>
</html>
