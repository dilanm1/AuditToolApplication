<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AuditLevelDP.aspx.cs" Inherits="AuditMgtNew.AuditLevelDP" %>

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
    <div class="logo">    <asp:ImageButton ID="Image1" runat="server" Height="77px" 
            ImageUrl="~/Images/dubai_properties_logo.png" Width="178px" 
            onclick="Image1_Click" /></div>
        <ul>
			<li><asp:Button ID="btnlogout" runat="server" Text="logout" BackColor="White" 
                ForeColor="#FF3300" BorderColor="White" BorderStyle="Solid" 
                onclick="btnlogout_Click" /></li>
            <li><a href="ReportScoreLocationDP.aspx">Analysis</a></li>
			<li><a href="ReportAuditorDP.aspx">Reports</a></li>			
			<li><a href="/Admin/AdminDP.aspx">Admin</a></li>
			<li><a href="HomePageDP.aspx">Home</a></li>
		</ul>
       
	</div>
    <div id="content">
       <center>  
        <asp:table ID="tblLoginJM" runat="server" border="0" 
            style="font-size: 100%; font-family: Verdana;" BackColor="White" 
            Height="100px" >
            <asp:TableRow height="5px"></asp:TableRow>
            <asp:TableRow>
            <asp:TableCell ColumnSpan="1" HorizontalAlign="center" style="font-weight:normal; color: white; font-size: small; color: #FF0000">To Begin, Please Select Audit Level</asp:TableCell> 
            </asp:TableRow>
            <asp:TableRow><asp:TableCell Height="5px"></asp:TableCell></asp:TableRow>
            <asp:TableRow>
            <asp:TableCell>
            <center><asp:radiobuttonlist id="contentcheck" repeatdirection="Horizontal" 
                runat="server" BackColor="White" Height="30px" Font-Size="small">
            <asp:listitem>First Tier Audit</asp:listitem>
            <asp:listitem>Second Tier Audit</asp:listitem>
            </asp:radiobuttonlist></center>
            </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
            <asp:TableCell> <asp:CustomValidator runat="server" ID="cvmodulelist"
              ClientValidationFunction="ValidateModuleList"
              ErrorMessage="Please Select One!"  ForeColor= "Red"></asp:CustomValidator></asp:TableCell>
            </asp:TableRow> 
            <asp:TableRow></asp:TableRow>          
            <asp:TableRow>
            <asp:TableCell HorizontalAlign="center">            
             <asp:ImageButton ID="ImageButton2" runat="server"  
                ImageUrl="~/Images/continue.png" 
                 onclick="ImageButton1_Click" /> 
            </asp:TableCell>                 
            </asp:TableRow>
            <asp:TableRow Height="10px"></asp:TableRow>            
            
    </asp:table>  
       <script language="javascript" type="text/javascript" >
           // javascript to add to your aspx page
           function ValidateModuleList(source, args) {
               var chkListModules = document.getElementById('<%= contentcheck.ClientID%>');
               var chkListinputs = chkListModules.getElementsByTagName("input");
               for (var i = 0; i < chkListinputs.length; i++) {
                   if (chkListinputs[i].checked) {
                       args.IsValid = true;
                       return;
                   }
               }
               args.IsValid = false;
           }
       </script>
    </center>  


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

