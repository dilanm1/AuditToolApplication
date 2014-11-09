<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportByLocationJM.aspx.cs" Inherits="AuditMgtNew.ReportByLocationJM" %>
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
        <asp:Image ID="Image1" runat="server" Height="77px" 
            ImageUrl="~/Images/dubai_holding_logo.png" Width="178px" />
        <ul>
			<li><a href="HomePageTC.aspx">Tecom</a></li>
			<li><a href="HomePageDP.aspx">Dubai Properties</a></li>
			<li><a href="HomePageJM.aspx">Jumeirah</a></li>
			<li><a href="MainPage.aspx">Home</a></li>
		</ul>
       
	</div>
    <div id="content" style="color: #000080">
      <asp:table ID="tblAudit" runat="server" border="0" style="font-size: 100%; font-family: Verdana;" >
       <asp:TableRow>
        <asp:TableCell Width="30%" HorizontalAlign="Left" style="font-weight:normal; color: #878787; background-color: " Font-Size="Small">
                    <asp:Label ID="lblLocation" runat="server" Text="Please select a Location:"></asp:Label><asp:Label
                        ID="lblLoc" runat="server" Text="Label" Visible="false"></asp:Label></asp:TableCell><asp:TableCell> <asp:DropDownList ID="ddlCountries" runat="server"
    onselectedindexchanged="ddlCountries_SelectedIndexChanged" AutoPostBack = "True" 
            DataSourceID="SqlDataSource1" DataTextField="location" 
            DataValueField="locationid">
    </asp:DropDownList></asp:TableCell> 
       </asp:TableRow>          
    </asp:table>
   
   <hr ID = "hr1" runat="server" size="2"  
            style="color: #000080; top: 0px; left: -10px; width: 100%;"/> 

       
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:examConnectionString %>" 
            SelectCommand="SELECT DISTINCT [locationid], [location], [verticalid] FROM [tbllocation]">
        </asp:SqlDataSource>
       
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="900px" 
            Width="900px" Font-Names="Verdana" Font-Size="8pt" 
            InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana" 
            WaitMessageFont-Size="14pt">
            <LocalReport ReportPath="ReportAuditExternel.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="SqlDataSource2" Name="DataSet1" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server">
        </asp:ObjectDataSource>
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
