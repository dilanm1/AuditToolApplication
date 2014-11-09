<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportAuditorJMIncomplete.aspx.cs" Inherits="AuditMgtNew.ReportAuditorJMIncomplete" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
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
            ImageUrl="~/Images/dubai_holding_logo.png" Width="178px" /> </div>
        <ul>
			<li><asp:Button ID="btnlogout" runat="server" Text="logout" BackColor="White" 
                ForeColor="#FF3300" BorderColor="White" BorderStyle="Solid" 
                onclick="btnlogout_Click" /></li>
			<li><a href="ReportScoreLocation.aspx">Analysis</a></li>
			<li><a href="ReportAuditorJM.aspx">Reports</a></li>
            <li><a href="MainPage.aspx">Home</a></li>


			<%--<li><a href="AuditLevelJM.aspx">Audit</a></li>
			<li><a href="/Admin/AdminJM.aspx">Admin</a></li>--%>
		</ul>
       
	</div>
    <div id="content" style="width: 100%">      
    
    <asp:Label ID="LabelL" runat="server" Text="Audit Report-Incomplete:" Font-Size="Medium"></asp:Label>
   
  <%--  <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" AppendDataBoundItems="False" onselectedindexchanged="DropDownList1_SelectedIndexChanged">
    </asp:DropDownList>--%>
    <br />    
    <asp:Label ID="Label2b" runat="server" Text="Select Date:" Visible="false"></asp:Label>
  <%--  <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" AppendDataBoundItems="true"
            DataSourceID="SqlDataSource1" DataTextField="DateComplete" 
            DataValueField="DateComplete"  Visible="false">
        <asp:ListItem>Select Date</asp:ListItem>
            
    </asp:DropDownList>--%>
    <br />
    <hr ID = "hr1" runat="server" size="2"  
            style="color: #000080; top: 0px; left: -10px; width: 100%;"/> 
       <%-- <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:examConnectionString %>" 
            SelectCommand="SELECT DISTINCT [DateComplete] FROM [View_Answers_Building_2] WHERE (([mid] = @mid) AND ([Expr1] = @Expr1))">
            <SelectParameters>
                <asp:SessionParameter Name="mid" SessionField="mid" Type="Int32" />
                <asp:ControlParameter ControlID="DropDownList1" Name="Expr1" 
                    PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>--%>
    <br />   
    <asp:Label ID="Label1m" runat="server" Text="Label" Visible="False"></asp:Label>
    <br />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <center>
      <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="1300px" Height="800px">
    </rsweb:ReportViewer></center>
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









    
  


