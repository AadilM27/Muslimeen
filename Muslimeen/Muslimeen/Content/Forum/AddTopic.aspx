<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddTopic.aspx.cs" Inherits="Muslimeen.Content.Forum.AddTopic" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/Forum.css" rel="stylesheet" />
    <script  type="text/javascript">
			function Validate(theForm)
			{
			if (theForm.frmPost.value == "")
   			{
			      alert("Please enter a Topic subject");
			      theForm.frmPost.focus();
			      return (false);
			   }
			return (true)
			}
		</script>
</head>
<body>
    <form id="AddTopic" method="post" runat="server" onSubmit="return Validate(this)">
        <h3>
				Discussion Forum
			</h3>
			<p>
				To add a topic, enter your name and
				<br />
				give the topic a brief subject.
			</p>
			<div id="outError" runat="server">
				<table cellpadding="5" cellspacing="1" border="0" class="DataTable">
					<tr>
						<td class="TableItem">
							<asp:Label ID="frmName" Runat="server"></asp:Label>
							<br />
							Brief Topic Subject: (255 character Max)
							<br />
							<asp:TextBox id="frmPost" runat="server" TextMode="MultiLine" MaxLength="255" Columns="40" Rows="5"></asp:TextBox>
							<table border="0" width="100%" cellspacing="0" cellpadding="0">
								<tr>
									<td width="100%" align="right">
										<asp:Button onClick="DoAddTopic" Text="Submit" Runat="server" id="BtnAddTopic" CssClass="button"></asp:Button>
									</td>
								</tr>
							</table>
						</td>
					</tr>
				</table>
				<p>
				</p>
				<a href="Topics.aspx">Back to Topic List</a>
			</div>
    </form>
</body>
</html>
