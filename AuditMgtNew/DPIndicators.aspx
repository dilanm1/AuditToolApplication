<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DPIndicators.aspx.cs" Inherits="AuditMgtNew.DPIndicators" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Style/StyleJM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
     <div class="wrapper">
	<div id="header">
    <div class="logo">    <asp:Image ID="Image1" runat="server" Height="77px" 
            ImageUrl="~/Images/dubai_properties_logo.png" Width="178px" /></div>
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
     <%-- <div id="navigation">
		<ul>
			<li><a href="#">Home</a></li>
			<li><a href="#">About</a></li>
			<li><a href="#">Services</a></li>
			<li><a href="#">Contact us</a></li>
		</ul>
	</div>--%>
     
     <div id="content">
        
    <center>
        <asp:Label ID="Labelloc" runat="server" Text="Available Locations:"></asp:Label><asp:DropDownList
            ID="DropDownList1" runat="server" AutoPostBack="True" onselectedindexchanged="DropDownList1_SelectedIndexChanged">
        </asp:DropDownList>
     <asp:table ID="tblIndicatorJM" runat="server" border="0" Width ="80%"
            style="font-size: 100%; font-family: Verdana;" BackColor="White" 
            Height="80px" >
    <asp:TableRow>
    <asp:TableCell HorizontalAlign="left" Width="80%">
        <asp:Label ID="lblLocation" runat="server" Text="Location:" Visible="False"></asp:Label>
    </asp:TableCell>
    </asp:TableRow>    
    <asp:TableRow>
    <asp:TableCell HorizontalAlign="left" Width="40%" Text="Indicators">    
    </asp:TableCell>
    <asp:TableCell HorizontalAlign="right">
    <asp:Image ID="Image211" runat="server" ImageUrl="~/Images/complete_image.png" />    
    </asp:TableCell>   
    <asp:TableCell HorizontalAlign="left" Font-Size="small" Width ="10px" Text = "Complete">
    </asp:TableCell>
     <asp:TableCell HorizontalAlign="right">
    <asp:Image ID="Image232" runat="server" ImageUrl="~/Images/uncomplete_image.png" />    
    </asp:TableCell>   
    <asp:TableCell HorizontalAlign="left" Font-Size="small" Width="10px" Text = "Incomplete">
    </asp:TableCell>
     <asp:TableCell HorizontalAlign="right">
    <asp:Image ID="Image33" runat="server" ImageUrl="~/Images/nodata_image.png" />    
    </asp:TableCell>   
    <asp:TableCell HorizontalAlign="left" Font-Size="small" Width="20px" Text = "NoData">
    </asp:TableCell>
    </asp:TableRow>    
</asp:table>
   <h4 style="background-color: #E2E2E2; color:#787878; width:79%; line-height: 20px; vertical-align: middle; text-align: left; padding: 8px; margin: 2px">Please Select Indicators In Order</h4>
    <br />
    <asp:GridView ID="GridView1" runat="server"  CssClass ="gv1"  Width="80%" BorderStyle="None"  HeaderStyle-BackColor="White"
        HeaderStyle-ForeColor="Red" RowStyle-BackColor="#F0F0F0 " AlternatingRowStyle-BackColor="White"
        RowStyle-ForeColor="#3A3A3A" AutoGenerateColumns="false" PageSize="10" 
            HorizontalAlign="Center"  
            onselectedindexchanged="GridView1_SelectedIndexChanged" GridLines="none" 
            ShowHeader="true" AlternatingRowStyle-Wrap="False" 
            onrowdatabound="GridView1_RowDataBound1" ShowFooter="true" > 
            
        <Columns>
           
            <asp:BoundField DataField="sid" />
             <asp:TemplateField>
            <ItemTemplate>
                <asp:Label ID="lblName" runat="server" Text='<%# Eval("sname") %>' />
            </ItemTemplate>
        </asp:TemplateField>
           <%-- <asp:BoundField DataField="City" HeaderText="City" />--%>
          <%--  <asp:BoundField DataField="Country" HeaderText="Country" />--%>                   
           <asp:TemplateField>
                    <ItemTemplate>
                      <asp:Image ID="Image2"  runat="server" ImageAlign="Right" ImageUrl="~/images/nodata_image.png"  visible='<%# Eval("status") == DBNull.Value %>' /><asp:Image ID="Image3"  runat="server" ImageAlign="Right" ImageUrl="~/images/u  ncomplete_image.png" Visible ='<%# Eval("status").Equals("Incomplete") %>' />
                       <asp:Image ID="Image4"  runat="server" ImageAlign="Right" ImageUrl="~/images/complete_image.png" Visible ='<%#  Eval("status").Equals("complete") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton ID="lnkDetails" runat="server" Text="Start Audit" PostBackUrl='<%# "~/AuditDP.aspx?RowIndex=" + Container.DataItemIndex %>'></asp:LinkButton>
                
            </ItemTemplate> 
                   
        </asp:TemplateField>
         <asp:BoundField DataField="status" HeaderText="id" />
          <asp:TemplateField>
          <ItemTemplate>
                 <asp:LinkButton ID="Button1" runat="server" Text="Edit" PostBackUrl='<%# "~/GridViewEditDPSub.aspx?RowIndex=" + Container.DataItemIndex %>'></asp:LinkButton>
            </ItemTemplate> 
         </asp:TemplateField>
         <asp:TemplateField>
          <ItemTemplate>
                 <asp:LinkButton ID="Button2" runat="server" Text="Resume" PostBackUrl='<%# "~/AuditSavedDP.aspx?RowIndex=" + Container.DataItemIndex %>' Visible="False"></asp:LinkButton>
            </ItemTemplate> 
         </asp:TemplateField> 
          <asp:TemplateField>
          <ItemTemplate>
                 <asp:LinkButton ID="btnreport" runat="server" Text="View Report" PostBackUrl='<%# "~/ReportAuditorJMIncomplete.aspx?RowIndex=" + Container.DataItemIndex %>' Visible="False"></asp:LinkButton>
            </ItemTemplate> 
         </asp:TemplateField>                     
         <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Weighting Score" HeaderStyle-Font-Size="Small" ShowHeader="true"  ControlStyle-ForeColor="#000066">
            <ItemTemplate>
                <center><asp:Label ID="lblName1"  Visible ="true" runat="server" Text='<%# Eval("score") %>' /></center>
            </ItemTemplate>
            <FooterTemplate>
            <asp:Label ID="lbltxttotal" runat="server" Text="Audit Score"/>
            </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="">
            <ItemTemplate>
          
            </ItemTemplate>
            <FooterTemplate>
            <asp:Label ID="lblTotal" runat="server" />
            </FooterTemplate>
        </asp:TemplateField>
        </Columns>     

    </asp:GridView>
        <br />
        <br />

         <asp:Button ID="btnConfirm" runat="server" OnClick = "OnConfirm" 
            Text = "Save Audit" OnClientClick = "Confirm()" Visible="False"/>
    </center>
  <%--  <script type="text/Javascript" language ="javascript" >
        function alert_meth() {
            alert("Data will be transferered to the database!!");
        }
    </script>
--%>
  <script type = "text/javascript">
      function Confirm() {
          var confirm_value = document.createElement("INPUT");
          confirm_value.type = "hidden";
          confirm_value.name = "confirm_value";
          if (confirm("Audit will be finalized!! OR Press 'Cancel' should it be kept as a draft")) {
              confirm_value.value = "Yes";
          } else {
              confirm_value.value = "No";
          }
          document.forms[0].appendChild(confirm_value);
      }
    </script>


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
	<%--</div>--%>
       
	</div>
    </form>
</body>
</html>
