<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportScoreLocation.aspx.cs" Inherits="AuditMgtNew.ReportScoreLocation" %>

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
    <div class="logo">   <asp:Image ID="Image1" runat="server" Height="77px" 
            ImageUrl="~/Images/jumeirah_group_logo.png" Width="178px" /> </div>
        <ul>
			<li><asp:Button ID="btnlogout" runat="server" Text="logout" BackColor="White" 
                ForeColor="#FF3300" BorderColor="White" BorderStyle="Solid" 
                onclick="btnlogout_Click" /></li>
			<li><a href="ReportScoreLocation.aspx">Analysis</a></li>
			<li><a href="ReportAuditorJM.aspx">Reports</a></li>
		<%--	<li><a href="AuditLevelJM.aspx">Audit</a></li>
			<li><a href="/Admin/AdminJM.aspx">Admin</a></li>--%>
             <li><a href="MainPage.aspx">Home</a></li>
		</ul>
       
	</div>
    <div id="content">
      <asp:Label ID="lblLocation" runat="server" Text="Please select a Location:"></asp:Label>
   
        <asp:DropDownList ID="ddlCountries" runat="server"
    onselectedindexchanged="ddlCountries_SelectedIndexChanged" AutoPostBack = "true">
    </asp:DropDownList>
    <br />
    <br />
    <asp:Label ID="lbl1" runat="server" Text="Label" Visible="false"></asp:Label>
     <hr ID = "hr1" runat="server" size="2"  
            style="color: #000080; top: 0px; left: -10px; width: 103%;"/> 
    
       <center> <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="900px" Width="900px">
        </rsweb:ReportViewer></center>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
     
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
