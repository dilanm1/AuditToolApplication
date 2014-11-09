<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewPreviousAudits.aspx.cs" Inherits="AuditMgtNew.ViewPreviousAudits" %>

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
            ImageUrl="~/Images/jumeirah_group_logo.png" Width="178px" /> </div>
        <ul>
            <li><asp:Button ID="btnlogout" runat="server" Text="logout" BackColor="White" 
                ForeColor="#FF3300" BorderColor="White" BorderStyle="Solid" 
                onclick="btnlogout_Click" /></li>
			<li><a href="/HomeTC.aspx">Tecom</a></li>
			<li><a href="/ReportScoreLocation.aspx">Analytics</a></li>
			<li><a href="/ReportAuditorJM.aspx">Reports</a></li>
			<li><a href="/AuditLevelJM.aspx">Home</a></li>
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
        <asp:Label ID="Label2d" runat="server" Text="Select Location:"></asp:Label>
        <asp:DropDownList
            ID="DropDownList1" runat="server" AutoPostBack="True" 
            DataSourceID="SqlDataSource2" DataTextField="location" 
            DataValueField="locationid"
             AppendDataBoundItems="true">
  <asp:ListItem Value="">Select</asp:ListItem>
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:examConnectionString %>" 
            SelectCommand="SELECT DISTINCT [locationid], [location] FROM [tbllocation]">
        </asp:SqlDataSource>
        <br />
         <asp:Label ID="Label16" runat="server" Text="Select Auditor:"></asp:Label>
        <asp:DropDownList
            ID="DropDownList29" runat="server" AutoPostBack="True" 
            DataSourceID="SqlDataSource3" DataTextField="lname" 
            DataValueField="mid"
             AppendDataBoundItems="true">
  <asp:ListItem Value="">Select</asp:ListItem>
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
            ConnectionString="<%$ ConnectionStrings:examConnectionString %>" 
            SelectCommand="SELECT [lname], [mid] FROM [oe_members]"></asp:SqlDataSource>
        <br />
          <asp:Label ID="Label17" runat="server" Text="Select Audit ID:"></asp:Label>
        <asp:DropDownList
            ID="DropDownList27" runat="server" AutoPostBack="True" 
            DataSourceID="SqlDataSource4" DataTextField="examid" 
            DataValueField="examid"
             AppendDataBoundItems="true">
  <asp:ListItem Value="">Select</asp:ListItem>
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
            ConnectionString="<%$ ConnectionStrings:examConnectionString %>" 
            SelectCommand="SELECT DISTINCT [examid] FROM [tblSavedAnswers] WHERE ([mid] = @mid)">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList29" Name="mid" 
                    PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" 
            AutoGenerateColumns="False" CellPadding="4" DataKeyNames="id" 
            ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="examid" HeaderText="examid" 
                    SortExpression="examid" />
                <asp:BoundField DataField="location" HeaderText="location" 
                    SortExpression="location" />
                <asp:BoundField DataField="sid" HeaderText="sid" SortExpression="sid" />
                <asp:BoundField DataField="qid" HeaderText="qid" SortExpression="qid" />
                <asp:BoundField DataField="question" HeaderText="question" 
                    SortExpression="question" />
                <asp:BoundField DataField="answer" HeaderText="answer" 
                    SortExpression="answer" />
                <asp:BoundField DataField="evidence" HeaderText="evidence" 
                    SortExpression="evidence" />
                <asp:BoundField DataField="comments" HeaderText="comments" 
                    SortExpression="comments" />
                <asp:BoundField DataField="DateComplete" HeaderText="DateComplete" 
                    SortExpression="DateComplete" />
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" 
                    ReadOnly="True" SortExpression="id" />
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
            DeleteCommand="DELETE FROM [tblSavedAnswers] WHERE [id] = @id" 
            InsertCommand="INSERT INTO [tblSavedAnswers] ([examid], [location], [sid], [qid], [question], [answer], [evidence], [comments], [DateComplete]) VALUES (@examid, @location, @sid, @qid, @question, @answer, @evidence, @comments, @DateComplete)" 
            
            SelectCommand="SELECT [examid], [location], [sid], [qid], [question], [answer], [evidence], [comments], [DateComplete], [id] FROM [tblSavedAnswers] WHERE (([locationid] = @locationid) AND ([mid] = @mid) AND ([examid] = @examid))" 
            UpdateCommand="UPDATE [tblSavedAnswers] SET [examid] = @examid, [location] = @location, [sid] = @sid, [qid] = @qid, [question] = @question, [answer] = @answer, [evidence] = @evidence, [comments] = @comments, [DateComplete] = @DateComplete WHERE [id] = @id" >
            
            
            
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="examid" Type="Int32" />
                <asp:Parameter Name="location" Type="String" />
                <asp:Parameter Name="sid" Type="Int32" />
                <asp:Parameter Name="qid" Type="String" />
                <asp:Parameter Name="question" Type="String" />
                <asp:Parameter Name="answer" Type="String" />
                <asp:Parameter Name="evidence" Type="String" />
                <asp:Parameter Name="comments" Type="String" />
                <asp:Parameter Name="DateComplete" Type="DateTime" />
            </InsertParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="locationid" 
                    PropertyName="SelectedValue" Type="Int32" />
                <asp:ControlParameter ControlID="DropDownList29" Name="mid" 
                    PropertyName="SelectedValue" Type="Int32" />
                <asp:ControlParameter ControlID="DropDownList27" Name="examid" 
                    PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="examid" Type="Int32" />
                <asp:Parameter Name="location" Type="String" />
                <asp:Parameter Name="sid" Type="Int32" />
                <asp:Parameter Name="qid" Type="String" />
                <asp:Parameter Name="question" Type="String" />
                <asp:Parameter Name="answer" Type="String" />
                <asp:Parameter Name="evidence" Type="String" />
                <asp:Parameter Name="comments" Type="String" />
                <asp:Parameter Name="DateComplete" Type="DateTime" />
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
