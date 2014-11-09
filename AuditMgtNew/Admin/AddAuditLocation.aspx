<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddAuditLocation.aspx.cs" Inherits="AuditMgtNew.AddAuditLocation" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title></title>
    <link href="/Style/StyleSheet3.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
     <div class="wrapper">
    <div id="header">
    <div class="logo">    <asp:Image ID="Image1" runat="server" Height="97px" 
            ImageUrl="~/Images/jumeirah_group_logo.png" Width="200px" /> </div>
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
    <asp:Label ID="Label11" runat="server" Text="Add Location" 
    Font-Size="Medium" ForeColor="#878787"></asp:Label><br /><asp:Label ID="lbllocation" runat="server"
        Text="Label" Visible="false"></asp:Label><br />
       
        <center>
        <asp:RadioButtonList ID="contentcheck" runat="server" 
            RepeatDirection="Horizontal" AutoPostBack="True">
            <asp:ListItem Selected="True">Add Corporate</asp:ListItem>
            <asp:ListItem>Add SBU</asp:ListItem>
            <asp:ListItem>Add Sub SBU</asp:ListItem>
        </asp:RadioButtonList>
          
        </center><%--<asp:CustomValidator runat="server" ID="cvmodulelist" ValidationGroup="Submit"
              ClientValidationFunction="ValidateModuleList"
              ErrorMessage="Please Select One!" ForeColor= "Red"></asp:CustomValidator>--%>


    <br />
    
     <asp:Button ID="Button4" runat="server" Text="Update" Visible="false" 
            onclick="Button4_Click" />
    <asp:Label ID="Label53" runat="server" Text="Label" Visible="False"></asp:Label>     
  
     <asp:table ID="tbl1" runat="server" border="0" 
            style="font-size: 100%; font-family: Verdana;">
            <asp:TableRow>
                <asp:TableHeaderCell HorizontalAlign="center" style="font-weight:normal; color: white; background-color: Red" Font-Size="Small">Company</asp:TableHeaderCell>
            </asp:TableRow>
           <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">
                 <asp:Label ID="Label121" runat="server" Font-Size="X-Small" Height="25px" Width="160px">Name/Title of Vertical:</asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                <asp:TextBox ID="TextBox123" runat="server" Height="20px" Width="220px" Enabled="True" ReadOnly="False" Font-Size="Smaller" ForeColor="#878787" AutoPostBack="True"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Right">
                    <asp:Label ID="Label411" runat="server" Font-Size="X-Small" Height="25px" Width="160px">Nature of Business:</asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                   <asp:DropDownList ID="DropDownList8"  runat="server" BackColor="#FFFFCC" Font-Size="X-Small" Width="220px" Height="20px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList8_SelectedIndexChanged" AppendDataBoundItems="false">
            
        </asp:DropDownList>
            </asp:TableCell>
            </asp:TableRow>
             <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">
                 <asp:Label ID="Label131" runat="server" Font-Size="X-Small" Height="25px" Width="160px">Name of Business Unit/Entity:</asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                <asp:DropDownList ID="DropDownList1" runat="server" BackColor="#FFFFCC" Font-Size="X-Small" Width="220px" Height="20px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AppendDataBoundItems="false"></asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Right">
                    <asp:Label ID="Label231" runat="server" Font-Size="X-Small" Height="25px" Width="160px">Sector:</asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                   <asp:DropDownList ID="DropDownList1312" runat="server" BackColor="#FFFFCC" Font-Size="X-Small" Width="220px" Height="20px" AutoPostBack="True" AppendDataBoundItems="true">
         <asp:ListItem Text="<Select>" Value="0" />  
        </asp:DropDownList>
            </asp:TableCell>
            </asp:TableRow>
             <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">
                 <asp:Label ID="Label523" runat="server" Font-Size="X-Small" Height="25px" Width="160px">Name of Sub Business Unit/Entity:</asp:Label>
                </asp:TableCell>
                <asp:TableCell>
              <asp:DropDownList ID="DropDownList2" runat="server" BackColor="#FFFFCC" Font-Size="X-Small" Width="220px" Height="20px" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Right">
                    <asp:Label ID="Label843" runat="server" Font-Size="X-Small" Height="25px" Width="160px">Principle Use of Buildings/Premises:</asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                <asp:DropDownList ID="DropDownList1443" runat="server" BackColor="#FFFFCC" Font-Size="X-Small" Width="220px" Height="20px" AppendDataBoundItems="true">
                <asp:ListItem Text="<Select>" Value="0" />
                <asp:ListItem>Hotel - Mixed</asp:ListItem>
                <asp:ListItem>Educational</asp:ListItem>
                <asp:ListItem>Research</asp:ListItem>
                <asp:ListItem>Commercial/Industrial</asp:ListItem>
                <asp:ListItem>Residential</asp:ListItem>
                <asp:ListItem>Retail (mixed)</asp:ListItem>
                <asp:ListItem>Theme Park</asp:ListItem>           
        </asp:DropDownList>
            </asp:TableCell>
            </asp:TableRow>
             <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">
                 <asp:Label ID="Label944" runat="server" Font-Size="X-Small" Height="25px" Width="160px">Location & Address of Business Unit:</asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                <asp:TextBox ID="TextBox321" runat="server" Height="80px" Width="220px" TextMode="MultiLine"></asp:TextBox>
                </asp:TableCell>
              </asp:TableRow> 
           
       </asp:table>
       <br />
      
    <asp:table ID="Table1c" runat="server" border="0" style="font-size: 100%; font-family: Verdana;" >
            <asp:TableRow>
                <asp:TableHeaderCell HorizontalAlign="center" Style =" font-weight:normal; color: white; background-color: Red" Font-Size="Small">Building</asp:TableHeaderCell>
                
            </asp:TableRow>
           <asp:TableRow>
                <asp:TableCell HorizontalAlign="right">
                 <asp:Label ID="Label1c" runat="server" Font-Size="X-Small" Height="25px" Width="160px">Number of Buildings on premises:</asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                <asp:TextBox ID="TextBox1c" runat="server" Height="20px" Width="220px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="right">
                    <asp:Label ID="Label2c" runat="server" Font-Size="X-Small" Height="25px" Width="160px">Approx.No of Employees:</asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                  <asp:TextBox ID="TextBox7" runat="server" Height="20px" Width="220px"></asp:TextBox>
            </asp:TableCell>
            </asp:TableRow>
             <asp:TableRow>
                <asp:TableCell HorizontalAlign="right">
                 <asp:Label ID="Label3c" runat="server" Font-Size="X-Small" Height="25px" Width="160px">Estimation of Total Square Meterage:</asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                <asp:TextBox ID="TextBox2c" runat="server" Height="20px" Width="220px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="right">
                    <asp:Label ID="Label4c" runat="server" Font-Size="X-Small" Height="25px" Width="160px">Average Occupancy/Annually:</asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                  <asp:TextBox ID="TextBox8" runat="server" Height="20px" Width="220px"></asp:TextBox>
            </asp:TableCell>
            </asp:TableRow>
             <asp:TableRow>
                <asp:TableCell HorizontalAlign="right">
                 <asp:Label ID="Label5c" runat="server" Font-Size="X-Small" Height="25px" Width="160px">Date of Commissioning:</asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                <asp:TextBox ID="TextBox3c" runat="server" Height="20px" Width="220px"></asp:TextBox>
                </asp:TableCell>               
            </asp:TableRow>
             <asp:TableRow>
                <asp:TableCell HorizontalAlign="right">
                
                </asp:TableCell>
                <asp:TableCell>
                
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="right">
                    <asp:Label ID="Label9c" runat="server" Font-Size="X-Small" Height="25px" Width="160px">Approx:No of Guests:</asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBox5" runat="server" Height="20px" Width="220px"></asp:TextBox>
            </asp:TableCell>
            </asp:TableRow>
             <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                 
                </asp:TableCell>
                <asp:TableCell>
               
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="right">
                    <asp:Label ID="Label13c" runat="server" Font-Size="X-Small" Height="25px" Width="250px">Average Resident/Tenant/Occupant Annually:</asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                   <asp:TextBox ID="TextBox6" runat="server" Height="20px" Width="220px"></asp:TextBox>
            </asp:TableCell>
            </asp:TableRow>
           
       </asp:table>
    
    <br />
    <asp:table ID="Table1b" runat="server" border="0" style="font-size: 100%; font-family: Verdana;" >
            <asp:TableRow>
                <asp:TableHeaderCell HorizontalAlign="center" style="font-weight:normal; color: white; background-color: Red" Font-Size="Small">Audit team </asp:TableHeaderCell>
                <asp:TableCell HorizontalAlign="center" style="font-weight: bold; color: white"></asp:TableCell>
                <asp:TableCell HorizontalAlign="center" style="font-weight: bold; color: white"></asp:TableCell>
                <asp:TableCell HorizontalAlign="center" style="font-weight:normal; color: white; background-color: Red" Font-Size="Small">Key Personalities</asp:TableCell>
               
            </asp:TableRow>
           <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">
                 <asp:Label ID="Label1b" runat="server" Font-Size="X-Small" Height="25px" Width="160px">Lead Auditor:</asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                <asp:TextBox ID="TextBox1b" runat="server" Height="20px" Width="220px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="right">
                    <asp:Label ID="Label2b" runat="server" Font-Size="X-Small" Height="25px" Width="160px">CEO:</asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                   <asp:TextBox ID="TextBox1d" runat="server" Height="20px" Width="220px"></asp:TextBox>
            </asp:TableCell>
            </asp:TableRow>
             <asp:TableRow>
                <asp:TableCell HorizontalAlign="right">
                 <asp:Label ID="Label5b" runat="server" Font-Size="X-Small" Height="25px" Width="160px">Auditor 1:</asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                <asp:TextBox ID="TextBox2bd" runat="server" Height="20px" Width="220px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="right">
                    <asp:Label ID="Label8b" runat="server" Font-Size="X-Small" Height="25px" Width="160px">COO:</asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                   <asp:TextBox ID="TextBox2d" runat="server" Height="20px" Width="220px"></asp:TextBox>
            </asp:TableCell>
            </asp:TableRow>
             <asp:TableRow>
                <asp:TableCell HorizontalAlign="right">
                 <asp:Label ID="Label9b" runat="server" Font-Size="X-Small" Height="25px" Width="160px">Auditor 2:</asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                <asp:TextBox ID="TextBox3b" runat="server" Height="20px" Width="220px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="right">
                    <asp:Label ID="Label12b" runat="server" Font-Size="X-Small" Height="25px" Width="160px">Head/Director HSE:</asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                   <asp:TextBox ID="TextBox1de" runat="server" Height="20px" Width="220px"></asp:TextBox>
            </asp:TableCell>
            </asp:TableRow>
             <asp:TableRow>
                <asp:TableCell HorizontalAlign="right">
                 <asp:Label ID="Label13b" runat="server" Font-Size="X-Small" Height="25px" Width="160px">Auditor 3:</asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                <asp:TextBox ID="TextBox5b" runat="server" Height="20px" Width="220px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="right">
                    <asp:Label ID="Label14b" runat="server" Font-Size="X-Small" Height="25px" Width="160px">Head/Director Risk(ERM):</asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBox2de" runat="server" Height="20px" Width="220px"></asp:TextBox>
            </asp:TableCell>
            </asp:TableRow>
             <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                
                </asp:TableCell>
                <asp:TableCell>
               
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="right">
                    <asp:Label ID="Label16b" runat="server" Font-Size="X-Small" Height="25px" Width="160px">Head/Director of Engineering:</asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                   <asp:TextBox ID="TextBox3de" runat="server" Height="20px" Width="220px"></asp:TextBox>
            </asp:TableCell>
            </asp:TableRow>
           
       </asp:table>
    <%--<script language="javascript" type="text/javascript" >
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
       </script>--%>
    <br />
     <br />
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Save" 
            Width="100px" BackColor="#82A45B" ForeColor="White" />
<asp:Button ID="Button2" runat="server" Text="Cancel" onclick="Button2_Click" 
            Width="100px" BackColor="#82A45B" ForeColor="White" />
    <asp:Button ID="Button3" runat="server" Text="Next Location" onclick="Button3_Click" 
    Width="100px" BackColor="#82A45B" ForeColor="White" />
<br />
<br />
<br />
<asp:Label ID="Label52" runat="server" ForeColor="#0000CC" Text="Label" 
    Visible="False"></asp:Label><br />
<br />

<br /> 
    
  
         
    </div>

    <div class="push"></div>
    
    </div>
     <div class="footer">
     <div class="copy">© CONSUS International LTD 2014</div>
       <%-- <div id="navigation1">--%>
		<ul>
			<li><a href="/HomePageTC.aspx">Tecom</a></li>
			<li><a href="/HomePageDP.aspx">Dubai Properties</a></li>
			<li><a href="/HomePageJM.aspx">Jumeirah</a></li>
			<li><a href="/MainPage.aspx">Home</a></li>
		</ul>
     </div>
    </form>
</body>
</html>
