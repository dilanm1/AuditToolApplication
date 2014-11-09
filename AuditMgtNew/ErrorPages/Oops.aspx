<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Oops.aspx.cs" Inherits="AuditMgtNew.ErrorPages.Oops" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <title></title>   
    <link href="~/Style/StyleSheet3.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="wrapper">
    <div id="header">
    <div class="logo">    <asp:Image ID="Image1" runat="server" Height="77px" 
            ImageUrl="~/Images/dubai_holding_logo.png" Width="178px" /> </div>
        <ul>
			<li><a href="/MainPage.aspx">Logout</a></li>
			<li><a href="/ReportScoreLocation.aspx">Analysis</a></li>
			<li><a href="/ReportAuditorJM.aspx">Reports</a></li>
			<li><a href="/AuditLevelJM.aspx">Audit</a></li>
			<li><a href="/Admin/AdminJM.aspx">Admin</a></li>
		</ul>
       
	</div>
    <div id="content">
     <h2>An error Has Occured!</h2>

     <p>An unexpected error has occured in the application</p>

     <ul>
     <li>
         <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/MainPage.aspx">Return to the homepage</asp:HyperLink></li>     
     </ul>
   
     <div style="clear:both"></div>
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
