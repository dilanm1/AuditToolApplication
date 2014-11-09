<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeJM.aspx.cs" Inherits="AuditMgtNew.HomeJM" %>

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
			<li><a href="#">Tecom</a></li>
			<li><a href="#">Dubai Properties</a></li>
			<li><a href="#">Jumeirah</a></li>
			<li><a href="#">Home</a></li>
		</ul>
       
	</div>
    <div id="content">
       <center>  
        <asp:table ID="tblLoginJM" runat="server" border="0" 
            style="font-size: 100%; font-family: Verdana;" BackColor="White" 
            Height="100px" >
            <asp:TableHeaderRow height="10px"></asp:TableHeaderRow>
            <asp:TableRow>
            <asp:TableCell ColumnSpan="2" HorizontalAlign="center" style="font-weight:normal; color: white; font-size: large; color: #FF0000">To begin, please enter your credentials</asp:TableCell> 
            </asp:TableRow>
            <asp:TableRow>
            <asp:TableCell HorizontalAlign="Right">
            <asp:Label ID="Label3" runat="server" Text="Username:" Font-Size="Small"></asp:Label> </asp:TableCell>
            <asp:TableCell HorizontalAlign="Left">
            <asp:TextBox ID="txtLname" runat="server"></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                ControlToValidate="txtLname" ErrorMessage="Llogin name is missing!" 
                Font-Bold="True">*</asp:RequiredFieldValidator></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
            <asp:TableCell HorizontalAlign="Right">
            <asp:Label ID="Label4" runat="server" Text="Password:" Font-Size="Small"></asp:Label> </asp:TableCell>
            <asp:TableCell HorizontalAlign="Left">
            <asp:TextBox ID="txtPwd" runat="server" TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
            ControlToValidate="txtPwd" ErrorMessage="Password is missing!" Font-Bold="True" Font-Size="Small">*</asp:RequiredFieldValidator></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell HorizontalAlign="left">
            <asp:CheckBox ID="CheckBox1" runat="server" Text="Remember Me" 
                    oncheckedchanged="chkRemember_CheckedChanged" 
                    ForeColor="#878787" />
            </asp:TableCell>          
            </asp:TableRow>
            <asp:TableRow>
            <asp:TableCell></asp:TableCell> 
            <asp:TableCell HorizontalAlign="left">            
             <asp:ImageButton ID="ImageButton2" runat="server"  
                ImageUrl="~/Images/login_button.png" 
                 onclick="ImageButton1_Click" /> 
            </asp:TableCell>                 
            </asp:TableRow>
            <asp:TableRow>
           <asp:TableCell></asp:TableCell>
            <asp:TableCell > 
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" Font-Bold="False" 
                HeaderText="Please correct the following errors:" 
                DisplayMode="List" />    
            </asp:TableCell>            
            </asp:TableRow>
            <asp:TableRow>
            <asp:TableCell HorizontalAlign="Right">
            <a href="newuser.aspx" style="color: white">New User?</a>
            </asp:TableCell>
            <asp:TableCell HorizontalAlign="Center">
            <a href="all/forgotpassword.aspx" style="color: white">Forgot Password?</a>
            </asp:TableCell>
            </asp:TableRow> 
            <asp:TableRow>
            <asp:TableCell><asp:Label ID="lblMsg" runat="server" Text="Label" Visible="False" ForeColor="#CC3300"></asp:Label></asp:TableCell>
            </asp:TableRow>          
            
    </asp:table>  
        
                             
        <asp:SqlDataSource ID="dsLogin" runat="server" ConnectionString="<%$ ConnectionStrings:examConnectionString %>"
            SelectCommand="select * from members where  lname = @lname and pwd = @pwd">
            <SelectParameters>
                <asp:Parameter Name="lname" />
                <asp:Parameter Name="pwd" />
            </SelectParameters>
        </asp:SqlDataSource>
   
    </center>  


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
