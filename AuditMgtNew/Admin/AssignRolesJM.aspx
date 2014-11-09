<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssignRolesJM.aspx.cs" Inherits="AuditMgtNew.Admin.Admin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
   <div style ="height:450px;">
<h2>Admin Panel:</h2>
<table>
<tr>
<td>
    <asp:TextBox ID="txtrolename" runat="server"></asp:TextBox>
    <asp:Button ID="btnCreateRole" runat="server" Text="CreateRole" OnClick="btnCreateRole_Click"/>
</td>
</tr>
<tr>
<td>
<table>
<tr>
<td>Available Users</td>
<td>Available Roles</td>
</tr>
<tr>
<td style="height: 72px">
    <asp:ListBox ID="lstusers" runat="server" Height="95px" Width="105px" 
        AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="lname" 
        DataValueField="lname"></asp:ListBox>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:examConnectionString %>" 
        SelectCommand="SELECT [lname] FROM [oe_members]"></asp:SqlDataSource>
</td>
<td style="height: 72px">
    <asp:ListBox ID="lstRoles" runat="server" Height="92px" Width="95px"></asp:ListBox>
</td>
</tr>
</table>
</td>
</tr>
<tr>
<td>
    <asp:Button ID="btnAssignRoleToUser" runat="server" Text="Assign Role To User" Width="175px" OnClick="btnAssignRoleToUser_Click" />
</td>
</tr>
<tr>
<td>
    <asp:Button ID="btnRemoveUserFromUser" runat="server" Text="Remove User From Role" OnClick="btnRemoveUserFromUser_Click" />
    
</td>
</tr>
<tr>
<td>
    <asp:Button ID="btnRemoveRoles" runat="server" Text="Delete Roles" Width="176px" OnClick="btnRemoveRoles_Click" />
</td>
</tr>
<tr>
<td>
    <asp:Label ID="Label1" runat="server"></asp:Label>
</td>
</tr>
</table>
</div>
    </form>
</body>
</html>
