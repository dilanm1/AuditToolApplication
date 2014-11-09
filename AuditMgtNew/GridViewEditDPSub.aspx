<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GridViewEditDPSub.aspx.cs" Inherits="AuditMgtNew.GridViewEditDPSub" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
  
    <link href="Style/StyleSheet3.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="wrapper">
    <div id="header">
    <div class="logo">    <asp:Image ID="Image1" runat="server" Height="77px" 
            ImageUrl="~/Images/dubai_properties_logo.png" Width="178px" /> </div>
        <ul>
			<li><asp:Button ID="btnlogout" runat="server" Text="logout" BackColor="White" 
                ForeColor="#FF3300" BorderColor="White" BorderStyle="Solid" 
                onclick="btnlogout_Click" /></li>
			<li><a href="ReportScoreLocationDP.aspx">Analysis</a></li>
			<li><a href="ReportAuditorDP.aspx">Reports</a></li>
			<li><a href="AuditLevelDP.aspx">Audit</a></li>
			<li><a href="/Admin/AdminDP.aspx">Admin</a></li>
		</ul>
       
	</div>
    <div id="content">
      <asp:Label ID="lblLocation" runat="server" Text="Please select a Location:"></asp:Label>
        <asp:DropDownList ID="ddlCountries" runat="server"
    AutoPostBack = "True" 
            DataSourceID="SqlDataSource1" DataTextField="location" 
            DataValueField="locationid"
             AppendDataBoundItems="true">
  <asp:ListItem Value="">Select</asp:ListItem>
        
    </asp:DropDownList>
    <br />
     <asp:Label ID="Label1x" runat="server" Text="Please Select The Indicator:" Visible="True"></asp:Label>
        <asp:DropDownList
            ID="DropDownList2" runat="server" AutoPostBack="True" 
            DataSourceID="SqlDataSource3" DataTextField="sname" DataValueField="sid"
             AppendDataBoundItems="true">
  <asp:ListItem Value="">Select</asp:ListItem>
          
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
            ConnectionString="<%$ ConnectionStrings:examConnectionString %>" 
            SelectCommand="SELECT DISTINCT [sid], [sname] FROM [oe_subjects] ORDER BY [sid], [sname]">
        </asp:SqlDataSource>
        <br/>
       <center>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                CellPadding="4" DataKeyNames="id" DataSourceID="SqlDataSource2" 
                ForeColor="#333333">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:CommandField ShowEditButton="True" />
                    <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" 
                        ReadOnly="True" SortExpression="id" Visible="False" />
<asp:BoundField DataField="examid" HeaderText="examid" SortExpression="examid" Visible="False"></asp:BoundField>
                    <asp:BoundField DataField="sid" HeaderText="sid" 
                        SortExpression="sid" Visible="False" ReadOnly="True">
                    </asp:BoundField>
                    <asp:BoundField DataField="qid" HeaderText="QID" 
                        SortExpression="qid" ReadOnly="True">
                    </asp:BoundField>
                    <asp:BoundField DataField="question" HeaderText="Question" 
                        SortExpression="question" ReadOnly="True">
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Evidence" SortExpression="evidence">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("evidence") %>' 
                                TextMode="MultiLine"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("evidence") %>'></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Height="200px" Width="300px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Comments" SortExpression="comments">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("comments") %>' 
                                TextMode="MultiLine"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("comments") %>'></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Height="200px" Width="300px" />
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="Action" SortExpression="action">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("action") %>' 
                                TextMode="MultiLine"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("action") %>'></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Height="200px" Width="300px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="location" HeaderText="location" 
                        SortExpression="location" Visible="False">
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Score" SortExpression="answer">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("answer") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("answer") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
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
        </center>  
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:examConnectionString %>" 
            
            
            SelectCommand="SELECT * FROM [tblSavedAnswers] WHERE (([locationid] = @location) AND ([mid] = @mid) AND ([sid] = @sid))" 
            DeleteCommand="DELETE FROM [tblSavedAnswers] WHERE [id] = @id" 
            InsertCommand="INSERT INTO [tblSavedAnswers] ([examid], [locationid], [location], [mid], [sid], [qid], [question], [answer], [evidence], [comments],[action]) VALUES (@examid, @locationid, @location, @mid, @sid, @qid, @question, @answer, @evidence, @comments, @action)" 
            
            
            
          UpdateCommand="UPDATE [tblSavedAnswers] SET  [answer] = @answer, [evidence] = @evidence, [comments] = @comments, [action] = @action  WHERE [id] = @id">
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="examid" Type="Int32" />
                <asp:Parameter Name="locationid" Type="Int32" />
                <asp:Parameter Name="location" Type="String" />
                <asp:Parameter Name="mid" Type="Int32" />
                <asp:Parameter Name="sid" Type="Int32" />
                <asp:Parameter Name="qid" Type="String" />
                <asp:Parameter Name="question" Type="String" />
                <asp:Parameter Name="answer" Type="String" />
                <asp:Parameter Name="evidence" Type="String" />
                <asp:Parameter Name="comments" Type="String" />
                <asp:Parameter Name="action" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlCountries" Name="location" 
                    PropertyName="SelectedValue" />
                <asp:SessionParameter Name="mid" SessionField="mid" Type="Int32" />
                <asp:ControlParameter ControlID="DropDownList2" Name="sid" 
                    PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="examid" Type="Int32" />
                <asp:Parameter Name="locationid" Type="Int32" />
                <asp:Parameter Name="location" Type="String" />
                <asp:Parameter Name="mid" Type="Int32" />
                <asp:Parameter Name="sid" Type="Int32" />
                <asp:Parameter Name="qid" Type="String" />
                <asp:Parameter Name="question" Type="String" />
                <asp:Parameter Name="answer" Type="String" />
                <asp:Parameter Name="evidence" Type="String" />
                <asp:Parameter Name="comments" Type="String" />
                <asp:Parameter Name="action" Type="String" />
                <asp:Parameter Name="id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:examConnectionString %>" 
            
            
            
            SelectCommand="SELECT [locationid], [location] FROM [tbllocation] WHERE ([verticalid] = @verticalid) AND ([locationid] != 14)">
            <SelectParameters>
                <asp:Parameter DefaultValue="2" Name="verticalid" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <hr />
        
     
   
     <div style="clear:both"></div>
    </div>
         
    <div class="push"></div>
    
    </div>
     <div class="footer">
     <div class="copy">© CONSUS International LTD FZE 2014</div>
       <%-- <div id="navigation1">--%>
		<ul>
			<li><a href="HomePageTC.aspx">Tecom</a></li>
			<li><a href="HomePageDP.aspx">Dubai Properties</a></li>
			<li><a href="HomePageJM.aspx">Jumeirah</a></li>
			<li><a href="MainPage.aspx">Home</a></li>
		</ul>
     </div>
    </form>
</body>
</html>
