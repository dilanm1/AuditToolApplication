<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditBuildingJM.aspx.cs" Inherits="AuditMgtNew.Admin.EditBuildingJM" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title></title>
     <link href="/Style/StyleJM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
     <div class="wrapper">
    <div id="header">
    <div class="logo">    <asp:Image ID="Image1" runat="server" Height="77px" 
            ImageUrl="~/Images/jumeirah_group_logo.png" Width="178px" /> </div>
        <ul>
            <li><asp:Button ID="btnlogout" runat="server" Text="logout" BackColor="White" 
                ForeColor="#FF3300" BorderColor="White" BorderStyle="Solid" 
                onclick="btnlogout_Click" /></li>
            <li><a href="/ReportScoreLocation.aspx">Analysis</a></li>
			<li><a href="/ReportAuditorJM.aspx">Reports</a></li>
			<li><a href="/AuditLevelJM.aspx">Audit</a></li>
			<li><a href="AdminJM.aspx">Admin</a></li>
			<li><a href="/HomePageJM.aspx">Home</a></li>
		</ul>
       
	</div>
    <div id="content">
  
        <asp:Label ID="Label19" runat="server" Text="Edit Building Details:"></asp:Label>
      
       
        <asp:DropDownList
            ID="DropDownList1" runat="server" AutoPostBack="True" 
            DataSourceID="SqlDataSource2" DataTextField="location" 
            DataValueField="locationid">
        </asp:DropDownList><br />
    <center>
        <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="600px" 
            AllowPaging="True" AutoGenerateRows="False" DataKeyNames="id" 
            DataSourceID="SqlDataSource1" BackColor="White" BorderColor="#999999" 
            BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="None" 
            CellSpacing="5">
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <EditRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <Fields>
                <asp:BoundField DataField="id" HeaderText="id" 
                    SortExpression="id" InsertVisible="False" ReadOnly="True" >
                </asp:BoundField>
                <asp:BoundField DataField="location" HeaderText="location" 
                    SortExpression="location" >
                </asp:BoundField>
                <asp:BoundField DataField="locationid" HeaderText="locationid" 
                    SortExpression="locationid" >
                </asp:BoundField>
                <asp:BoundField DataField="Verticalid" HeaderText="Verticalid" 
                    SortExpression="Verticalid" >
                </asp:BoundField>
                <asp:BoundField DataField="VerticalName" HeaderText="VerticalName" 
                    SortExpression="VerticalName" >
                </asp:BoundField>
                <asp:BoundField DataField="Unit" HeaderText="Unit" 
                    SortExpression="Unit" >
                </asp:BoundField>
                <asp:BoundField DataField="SubUnit" HeaderText="SubUnit" 
                    SortExpression="SubUnit" >
                </asp:BoundField>
                <asp:BoundField DataField="Address" HeaderText="Address" 
                    SortExpression="Address" >
                </asp:BoundField>
                <asp:BoundField DataField="Nature" HeaderText="Nature" 
                    SortExpression="Nature" >
                </asp:BoundField>
                <asp:BoundField DataField="Sector" HeaderText="Sector" SortExpression="Sector" >
                </asp:BoundField>
                <asp:BoundField DataField="Usage" HeaderText="Usage" SortExpression="Usage" >
                </asp:BoundField>
                <asp:BoundField DataField="Number" HeaderText="Number" 
                    SortExpression="Number" >
                </asp:BoundField>
                <asp:BoundField DataField="Square" HeaderText="Square" 
                    SortExpression="Square" >
                </asp:BoundField>
                <asp:BoundField DataField="year" HeaderText="year" 
                    SortExpression="year" >
                </asp:BoundField>
                <asp:BoundField DataField="Emp" HeaderText="Emp" 
                    SortExpression="Emp" >
                </asp:BoundField>
                <asp:BoundField DataField="Visitors" HeaderText="Visitors" 
                    SortExpression="Visitors" >
                </asp:BoundField>
                <asp:BoundField DataField="Guests" HeaderText="Guests" 
                    SortExpression="Guests" >
                </asp:BoundField>
                <asp:BoundField DataField="Residents" HeaderText="Residents" 
                    SortExpression="Residents" >
                </asp:BoundField>
                <asp:BoundField DataField="LeadAuditor" HeaderText="LeadAuditor" 
                    SortExpression="LeadAuditor" >
                </asp:BoundField>
                <asp:BoundField DataField="Auditor1" HeaderText="Auditor1" 
                    SortExpression="Auditor1" >
                </asp:BoundField>
                <asp:BoundField DataField="Auditor2" HeaderText="Auditor2" 
                    SortExpression="Auditor2" >
                </asp:BoundField>
                <asp:BoundField DataField="Auditor3" HeaderText="Auditor3" 
                    SortExpression="Auditor3" >
                </asp:BoundField>
                <asp:BoundField DataField="CEO" HeaderText="CEO" SortExpression="CEO" >
                </asp:BoundField>
                <asp:BoundField DataField="COO" HeaderText="COO" SortExpression="COO" />
                <asp:BoundField DataField="DM" HeaderText="Head/Director HSE" 
                    SortExpression="DM" />
                <asp:BoundField DataField="DE" HeaderText="Head/Director Risk(ERM)" 
                    SortExpression="DE" />
                <asp:BoundField DataField="Other" HeaderText="Head/Director of Engineering" 
                    SortExpression="Other" />
                <asp:CommandField ShowEditButton="True" ButtonType="Image" 
                    CancelImageUrl="~/Images/cancel.png" EditImageUrl="~/Images/edit.png" 
                    UpdateImageUrl="~/Images/update.png" />
            </Fields>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        </asp:DetailsView>
    </center>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:examConnectionString %>" 
            DeleteCommand="DELETE FROM [tblBuilding] WHERE [id] = @id" 
            InsertCommand="INSERT INTO [tblBuilding] ([VerticalName], [Unit], [SubUnit], [Address], [Nature], [Sector], [Usage], [Number], [Square], [year], [Emp], [Visitors], [Guests], [Residents], [LeadAuditor], [Auditor1], [Auditor2], [Auditor3], [CEO], [COO], [DM], [DE], [Other]) VALUES (@VerticalName, @Unit, @SubUnit, @Address, @Nature, @Sector, @Usage, @Number, @Square, @year, @Emp, @Visitors, @Guests, @Residents, @LeadAuditor, @Auditor1, @Auditor2, @Auditor3, @CEO, @COO, @DM, @DE, @Other)" 
            SelectCommand="SELECT * from tblBuilding WHERE ([locationid] = @locationid)" 
            
            UpdateCommand="UPDATE [tblBuilding] SET [VerticalName] = @VerticalName, [Unit] = @Unit, [SubUnit] = @SubUnit, [Address] = @Address, [Nature] = @Nature, [Sector] = @Sector, [Usage] = @Usage, [Number] = @Number, [Square] = @Square, [year] = @year, [Emp] = @Emp, [Visitors] = @Visitors, [Guests] = @Guests, [Residents] = @Residents, [LeadAuditor] = @LeadAuditor, [Auditor1] = @Auditor1, [Auditor2] = @Auditor2, [Auditor3] = @Auditor3, [CEO] = @CEO, [COO] = @COO, [DM] = @DM, [DE] = @DE, [Other] = @Other WHERE [id] = @id">
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="VerticalName" Type="String" />
                <asp:Parameter Name="Unit" Type="String" />
                <asp:Parameter Name="SubUnit" Type="String" />
                <asp:Parameter Name="Address" Type="String" />
                <asp:Parameter Name="Nature" Type="String" />
                <asp:Parameter Name="Sector" Type="String" />
                <asp:Parameter Name="Usage" Type="String" />
                <asp:Parameter Name="Number" Type="Int32" />
                <asp:Parameter Name="Square" Type="Int32" />
                <asp:Parameter Name="year" Type="Int32" />
                <asp:Parameter Name="Emp" Type="Int32" />
                <asp:Parameter Name="Visitors" Type="Int32" />
                <asp:Parameter Name="Guests" Type="Int32" />
                <asp:Parameter Name="Residents" Type="Int32" />
                <asp:Parameter Name="LeadAuditor" Type="String" />
                <asp:Parameter Name="Auditor1" Type="String" />
                <asp:Parameter Name="Auditor2" Type="String" />
                <asp:Parameter Name="Auditor3" Type="String" />
                <asp:Parameter Name="CEO" Type="String" />
                <asp:Parameter Name="COO" Type="String" />
                <asp:Parameter Name="DM" Type="String" />
                <asp:Parameter Name="DE" Type="String" />
                <asp:Parameter Name="Other" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="locationid" 
                    PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="VerticalName" Type="String" />
                <asp:Parameter Name="Unit" Type="String" />
                <asp:Parameter Name="SubUnit" Type="String" />
                <asp:Parameter Name="Address" Type="String" />
                <asp:Parameter Name="Nature" Type="String" />
                <asp:Parameter Name="Sector" Type="String" />
                <asp:Parameter Name="Usage" Type="String" />
                <asp:Parameter Name="Number" Type="Int32" />
                <asp:Parameter Name="Square" Type="Int32" />
                <asp:Parameter Name="year" Type="Int32" />
                <asp:Parameter Name="Emp" Type="Int32" />
                <asp:Parameter Name="Visitors" Type="Int32" />
                <asp:Parameter Name="Guests" Type="Int32" />
                <asp:Parameter Name="Residents" Type="Int32" />
                <asp:Parameter Name="LeadAuditor" Type="String" />
                <asp:Parameter Name="Auditor1" Type="String" />
                <asp:Parameter Name="Auditor2" Type="String" />
                <asp:Parameter Name="Auditor3" Type="String" />
                <asp:Parameter Name="CEO" Type="String" />
                <asp:Parameter Name="COO" Type="String" />
                <asp:Parameter Name="DM" Type="String" />
                <asp:Parameter Name="DE" Type="String" />
                <asp:Parameter Name="Other" Type="String" />
                <asp:Parameter Name="id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:examConnectionString %>" 
            SelectCommand="SELECT DISTINCT [locationid], [location] FROM [tbllocation] WHERE ([verticalid] = @verticalid)">
            <SelectParameters>
                <asp:Parameter DefaultValue="1" Name="verticalid" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
    

   
    


    </div>

    <div class="push"></div>
    
    </div>
     <div class="footer">
      <div class="copy">© CONSUS International LTD 2014</div>
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

