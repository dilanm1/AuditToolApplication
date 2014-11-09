<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePageJM.aspx.cs" Inherits="AuditMgtNew.HomePageJM" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title></title>
    <link href="Style/Sheet2.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .newStyle1
        {
            font-weight: bold;
        }
    </style>
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
			<li><a href="ReportScoreLocation.aspx">Analysis</a></li>
			<li><a href="ReportAuditorJM.aspx">Reports</a></li>
			<li><a href="AuditLevelJM.aspx">Audit</a></li>
			<li><a href="/Admin/AdminJM.aspx">Admin</a></li>
		</ul>                   
              
	</div>
    <div id="content">
     <asp:table ID="tblLogin" runat="server" border="0" 
            style="font-size: 100%; font-family: Verdana;" BackColor="White" >
            <asp:TableRow Width="100%" Height="180px">
                <asp:TableCell  Width="50%" HorizontalAlign="Left" style="font-weight:normal; color: #878787; background-color: " Font-Size="x-large"><p id ="para1" style="font-family: Arial; font-size: x-large; color: #878787">Introduction:</p>
                      <p id = "para2" style= "margin:10px;float:left; font-size:medium; color: #878787; text-align: left; display: block; font-family: Arial; font-weight: normal;"><br />
                      Risk management is a core process and is required to be fully integrated within Dubai Holding (DH) business undertakings and decision making processes.  The strategic position of DH is steered from a ‘risk’ perspective through the Enterprise Risk Management (ERM) framework. The effective, proportionate management of HSE is central to the continued success and reputation of DH.</p><p id = "para3" style="font-weight: bold">(Refer to  Dubai Holding Core Process 3: Steer Strategic Risk Position   DH Transition Management Office, Revision#: 3 – September 2013 for risk guidance and methodology &  DH HSE Policy (Version 1.1))</p>
<p id = "para4" style= "margin:10px;float:left; font-size:medium; color: #878787; text-align: left; display: block; font-family: Arial; font-weight: normal;">This audit tool is ‘unique’ as it has been customised to reflect the diverse risk management requirements of DH. The primary aim and intent of the audit tool is to assist, support and guide DH ‘Verticals’ in demonstrating HSE risks are proficiently controlled and managed. The provision of ‘safe’ buildings and premises is a core business objective and the importance of ‘safety’ is  fully recognised to enable the Executive to have confidence in the efficacy of the HSE risk mitigation measures applied and they remain both business and cost sensitive.</p> 
 
            
            </asp:TableCell>
                <asp:TableCell Width="50%" HorizontalAlign="Center" style="font-weight:normal; color: #878787; background-color: " Font-Size="Small">
                    <asp:Image ID="ImageLogin" runat="server" ImageUrl="~/Images/main_image.png" /></asp:TableCell>
            </asp:TableRow>
    </asp:table>        
       <br />
       <br />
       
       
       <br />
       
      
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
