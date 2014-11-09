<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AuditHistoryJM.aspx.cs" Inherits="AuditMgtNew.AuditHistory" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title></title>
    <link href="Style/Sheet2.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
     <div class="wrapper">
    <div id="header">
     <div class="logo">   <asp:Image ID="Image1" runat="server" Height="77px" 
            ImageUrl="~/Images/jumeirah_group_logo.png" Width="178px" /> </div>
        <ul>
			<li><a href="MainPage.aspx">Logout</a></li>
			<li><a href="ReportScoreLocation.aspx">Analysis</a></li>
			<li><a href="ReportAuditorJM.aspx">Reports</a></li>
			<li><a href="AuditLevelJM.aspx">Audit</a></li>
			<li><a href="/Admin/AdminJM.aspx">Admin</a></li>
		</ul>
       
	</div>
    <div id="content">
       <center>  
        <asp:table ID="tblLoginJM" runat="server" border="0" 
            style="font-size: 100%; font-family: Verdana;" BackColor="White" 
            Height="100px" >
            <asp:TableHeaderRow height="10px"></asp:TableHeaderRow>
            <asp:TableRow>
            <asp:TableCell ColumnSpan="2" HorizontalAlign="center" style="font-weight:normal; color: white; font-size: large; color: #FF0000">To begin, please select location</asp:TableCell> 
            </asp:TableRow>
            <asp:TableRow>
            <asp:TableCell HorizontalAlign=" right">
            <asp:Label ID="Label3" runat="server" Text="Complete Audits:" Font-Size="Small"></asp:Label> </asp:TableCell>
            <asp:TableCell HorizontalAlign="Left">
                <asp:DropDownList ID="DropDownList1" runat="server" Width="260px" AppendDataBoundItems="false" AutoPostBack="True">
                </asp:DropDownList>
            </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
            <asp:TableCell HorizontalAlign="right">
            <asp:Label ID="Label4" runat="server" Text="Incomplete Audits:" Font-Size="Small"></asp:Label> </asp:TableCell>
            <asp:TableCell HorizontalAlign="Left">
                <asp:DropDownList ID="DropDownList2" runat="server" Width="260px" AppendDataBoundItems="false" AutoPostBack="True">
                </asp:DropDownList>
            </asp:TableCell>
            </asp:TableRow>            
            <asp:TableRow>
            <asp:TableCell Height ="20px"></asp:TableCell>         
            <asp:TableCell HorizontalAlign="left">
             <asp:ImageButton ID="ImageButton2" runat="server"  
                ImageUrl="~/Images/continue.png" 
                 onclick="ImageButton1_Click" /> 
            </asp:TableCell>                 
            </asp:TableRow>         
            
    </asp:table>        
                             
      
    </center>  


    </div>

    <div class="push"></div>
    
    </div>
     <div class="footer">
      <div class="copy">© CONSUS International LTD 2014</div>
       <%-- <div id="navigation1">--%>
		<ul>
			<li><a href="/HomePageTC.aspx ">Tecom</a></li>
			<li><a href="/HomePageDP.aspx">Dubai Properties</a></li>
			<li><a href="/HomePageJM.aspx">Jumeirah</a></li>
			<li><a href="/MainPage.aspx">Home</a></li>
		</ul>
     </div>  
    </form>
</body>
</html>
