<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AnalyticalInitialTC.aspx.cs" Inherits="AuditMgtNew.AnalyticalInitialTC" %>

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
            ImageUrl="~/Images/dubai_holding_logo.png" Width="178px" /> </div>
        <ul>
			<li><a href="#">Tecom</a></li>
			<li><a href="#">Dubai Properties</a></li>
			<li><a href="#">Jumeirah</a></li>
			<li><a href="#">Home</a></li>
		</ul>
       
	</div>
    <div id="content">
      <asp:table ID="tblAudit" runat="server" border="0" style="font-size: 100%; font-family: Verdana;" >
       <asp:TableRow>
        <asp:TableCell Width="30%" HorizontalAlign="Left" style="font-weight:normal; color: #878787; background-color: " Font-Size="Small">
                    <asp:Label ID="lblLocation" runat="server" Text="Please select a Location:"></asp:Label><asp:Label
                        ID="lblLoc" runat="server" Text="Label" Visible="false"></asp:Label></asp:TableCell> 
       </asp:TableRow>          
    </asp:table>
    <center>
        <asp:DropDownList ID="ddlCountries" runat="server"
    onselectedindexchanged="ddlCountries_SelectedIndexChanged" AutoPostBack = "true">
    </asp:DropDownList><hr />
    <asp:Chart ID="Chart1" runat="server" Height="600px" Width="700px" 
            Visible = "false">
        <Titles>
            <asp:Title ShadowOffset="3" Name="Items" />
        </Titles>
        <Legends>
            <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default" LegendStyle="Row" />
        </Legends>
        <Series>
            <asp:Series Name="Default" />
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1" BorderWidth="0" />
        </ChartAreas>
    </asp:Chart> 
    </center>   
   
     <div style="clear:both"></div>
    </div>
         
    <div class="push"></div>
    
    </div>
     <div class="footer">
     <div class="copy">© CONSUS International LTD 2014</div>
       <%-- <div id="navigation1">--%>
		<ul>
			<li><a href="#">Tecom</a></li>
			<li><a href="#">Dubai Properties</a></li>
			<li><a href="#">Jumeirah</a></li>
			<li><a href="#">Home</a></li>
		</ul>
     </div>
    </form>
</body>
</html>
