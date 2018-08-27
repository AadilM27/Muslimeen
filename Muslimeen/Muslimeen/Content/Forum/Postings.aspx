<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Postings.aspx.cs" Inherits="Muslimeen.Content.Forum.Postings" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/Forum.css" rel="stylesheet" />
    <script type="text/javascript">
			function Validate(theForm)
			{
			if (theForm.frmPost.value == "")
   			{
			      alert("Please enter a Posting message");
			      theForm.frmPost.focus();
			      return (false);
			   }
			return (true)
			}
		</script>
</head>
<body>
   <form id="AddPosting" method="post" runat="server" onSubmit="return Validate(this)">
			<h3>
				Discussion Forum
			</h3>
			<div ID="TopicSubject" Runat="server">
			</div>
			<p>
				To add a post, enter your name and Message.
			</p>
			<div id="Div1" runat="server">
				<table cellpadding="5" cellspacing="1" border="0" class="DataTable">
					<tr>
						<td class="TableItem">
							Message from
							<asp:Label ID="frmName" Runat="server"></asp:Label>:
							<br>
							<asp:TextBox id="frmPost" runat="server" TextMode="MultiLine" MaxLength="255" Columns="40" Rows="5"></asp:TextBox>
							<table border="0" width="100%" cellspacing="0" cellpadding="0">
								<tr>
									<td width="100%" align="right">
										<asp:Button onClick="DoAddPost" Text="Add Post" Runat="server" id="Button1" CssClass="button"></asp:Button>
									</td>
								</tr>
							</table>
						</td>
					</tr>
				</table>
				<p>
					<a href="Topics.aspx">Back to Topic List</a>
				</p>
			</div>
			<div id="outError" runat="server">
				<asp:DataGrid EnableViewState="False" DataKeyField="PostID" id="DataGrid1" runat="server" AutoGenerateColumns="False" HeaderStyle-CssClass="TableHeader" AlternatingItemStyle-CssClass="AltTableItem" ItemStyle-CssClass="TableItem" CssClass="DataTable" CellPadding="5">
					<HeaderStyle CssClass="TableHeader"></HeaderStyle>
					<PagerStyle NextPageText="Next &amp;gt;" PrevPageText="&lt; Prev"></PagerStyle>
					<AlternatingItemStyle CssClass="AltTableItem"></AlternatingItemStyle>
					<ItemStyle CssClass="TableItem"></ItemStyle>
					<Columns>
						<asp:TemplateColumn HeaderText="Posted By">
							<ItemTemplate>
								<asp:Label Runat='server' ID="lblAdminLink">
									<%# DataBinder.Eval(Container.DataItem, "PostCreateName") %>
									<% if (Session["admin"] == "yes")
										{ %>
									<br>
									<a class="adminlink" href="DeleteRecord.aspx?S=<%# Request.QueryString["S"] %>&TID=<%# Request.QueryString["ID"] %>&T=P&ID=<%# DataBinder.Eval(Container.DataItem, "PostID") %>">
										Delete</a>
									<%	}
									%>
									<br>
								</asp:Label>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:BoundColumn DataField="PostContent" HeaderText="Post"></asp:BoundColumn>
						<asp:BoundColumn DataField="PostCreateDate" HeaderText="Posted"></asp:BoundColumn>
					</Columns>
				</asp:DataGrid>
			</div>
		</form>
</body>
</html>
