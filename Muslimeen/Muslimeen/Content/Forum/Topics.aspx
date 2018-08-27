<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Topics.aspx.cs" Inherits="Muslimeen.Content.Forum.Topics" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/Forum.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" method="post" runat="server">
        <h3>
				Discussion Forum
			</h3>
			<div id="welcome" runat="server" />
			<a href="AddTopic.aspx">Add a topic</a>
			
			<div id="outError" runat="server">
				<asp:DataGrid id="DataGrid1" runat="server" AutoGenerateColumns="False" HeaderStyle-CssClass="TableHeader" AlternatingItemStyle-CssClass="AltTableItem" ItemStyle-CssClass="TableItem" CssClass="DataTable" CellPadding="5">
					<Columns>
						<asp:TemplateColumn HeaderText="Posted By">
							<ItemTemplate>
								<asp:Label Runat='server' ID="lblAdminLink">
									<%# DataBinder.Eval(Container.DataItem, "TopicCreateName") %>
									<% if (Session["admin"] == "yes")
										{ %>
									<br>
									<a class="adminlink" href="DeleteRecord.aspx?T=T&ID=<%# DataBinder.Eval(Container.DataItem, "ForumTopicID") %>">
										Delete</a>
									<%	}
									%>
									<br>
								</asp:Label>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="Topic: click to view posts">
							<ItemTemplate>
								<asp:Label Runat='server' ID="lblSubject">
									<a href="Postings.aspx?ID=<%#  DataBinder.Eval(Container.DataItem, "ForumTopicID") %>&S=<%# DataBinder.Eval(Container.DataItem, "TopicSubject") %>">
										<%# DataBinder.Eval(Container.DataItem, "TopicSubject") %>
									</a>
								</asp:Label>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:BoundColumn DataField="TopicCreateDate" HeaderText="Posted"></asp:BoundColumn>
					</Columns>
				</asp:DataGrid>
			</div>
    </form>
</body>
</html>
