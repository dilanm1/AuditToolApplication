<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetAuditProcessTC.aspx.cs" Inherits="AuditMgtNew.Admin.ResetAuditProcessTC" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title></title>
    <link href="/Style/StyleSheet3.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
     <div class="wrapper">
	<div id="header">
     <div class="logo">   <asp:Image ID="Image1" runat="server" Height="77px" 
            ImageUrl="~/Images/tecom_logo.png" Width="178px" /> </div>
        <ul>
             <li><asp:Button ID="btnlogout" runat="server" Text="logout" BackColor="White" 
                ForeColor="#FF3300" BorderColor="White" BorderStyle="Solid" 
                onclick="btnlogout_Click" /></li>
            <li><a href="/ReportScoreLocationTC.aspx">Analysis</a></li>
			<li><a href="/ReportAuditorTC.aspx">Reports</a></li>
			<li><a href="/AuditLevelTC.aspx">Audit</a></li>
			<li><a href="AdminTC.aspx">Admin</a></li>
			<li><a href="/HomePageTC.aspx">Home</a></li>
		</ul>
       
	</div>
     <%-- <div id="navigation">
		<ul>
			<li><a href="#">Home</a></li>
			<li><a href="#">About</a></li>
			<li><a href="#">Services</a></li>
			<li><a href="#">Contact us</a></li>
		</ul>
	</div>--%>
     
     <div id="content">
        
    <center>
        <h2>Please Delete acordingly for Repeat Audit Process</h2>
    <br />
        <asp:Label ID="Label2d" runat="server" Text="Select Location:"></asp:Label>
        <br />
        <asp:DropDownList
            ID="DropDownList1" runat="server" AutoPostBack="True" 
            DataSourceID="SqlDataSource2" DataTextField="location" 
            DataValueField="location">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:examConnectionString %>" 
            
            SelectCommand="SELECT [locationid], [location] FROM [tbllocation] WHERE ([verticalid] = @verticalid)">
            <SelectParameters>
                <asp:Parameter DefaultValue="3" Name="verticalid" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" 
            AutoGenerateColumns="False" CellPadding="4" DataKeyNames="id" 
            ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:CommandField ShowDeleteButton="True" />
                <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" 
                    SortExpression="id" InsertVisible="False" Visible="False" />
                <asp:BoundField DataField="sid" HeaderText="Indicator ID" 
                    SortExpression="sid" />
                <asp:BoundField DataField="mid" HeaderText="User ID" 
                    SortExpression="mid" />
                <asp:BoundField DataField="status" HeaderText="Status" 
                    SortExpression="status" />
                <asp:BoundField DataField="score" HeaderText="Score" 
                    SortExpression="score" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:examConnectionString %>" 
            DeleteCommand="DELETE FROM [oe_subjects_status] WHERE [id] = @id" 
            InsertCommand="INSERT INTO [oe_subjects_status] ([sid], [mid], [status], [score]) VALUES (@sid, @mid, @status, @score)" 
            SelectCommand="SELECT [id], [sid], [mid], [status], [score] FROM [oe_subjects_status] WHERE ([location] = @location)" 
            
            
            UpdateCommand="UPDATE [oe_subjects_status] SET [sid] = @sid, [mid] = @mid, [status] = @status, [score] = @score WHERE [id] = @id">
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="sid" Type="Int32" />
                <asp:Parameter Name="mid" Type="Int32" />
                <asp:Parameter Name="status" Type="String" />
                <asp:Parameter Name="score" Type="Double" />
            </InsertParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="location" 
                    PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="sid" Type="Int32" />
                <asp:Parameter Name="mid" Type="Int32" />
                <asp:Parameter Name="status" Type="String" />
                <asp:Parameter Name="score" Type="Double" />
                <asp:Parameter Name="id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>

    </center>
   



     </div>

     <div class="push"></div>
     </div>
     
       <div class="footer">
	  <div class="copy">© CONSUS International LTD 2014</div>
       <%-- <div id="navigation1">--%>
		<ul>
			<li><a href="/HomePageTC.aspx">Tecom</a></li>
			<li><a href="/HomePageDP.aspx">Dubai Properties</a></li>
			<li><a href="/HomePageJM.aspx">Jumeirah</a></li>
			<li><a href="/MainPage.aspx">Home</a></li>
		</ul>
	<%--</div>--%>
       
	</div>
    </form>
</body>
</html>
