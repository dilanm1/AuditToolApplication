<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AuditMgtNew.Login1" %>

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
    <div class="logo">    <asp:Image ID="Image1" runat="server" Height="77px" 
            ImageUrl="~/Images/dubai_holding_logo.png" Width="178px" /> </div>
       <%-- <ul>
			<li><a href="#">Tecom</a></li>
			<li><a href="#">Dubai Properties</a></li>
			<li><a href="#">Jumeirah</a></li>
			<li><a href="#">Home</a></li>
		</ul>--%>
       
	</div>
   
    <div id="content">      
       <center>      
        <asp:table ID="tblLoginJM" runat="server" border="0" width="700px"
            style="font-size: 100%; font-family: Verdana; left: 0px;" BackColor="White" 
            Height="100px">
            <asp:TableRow height="10px">
            <asp:TableCell ></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
            <asp:TableCell ColumnSpan="4" HorizontalAlign="left" style="font-weight:normal; color: white; font-size:medium; color: black"><div class="heading" style="color: #878787">Login</div></asp:TableCell> 
            </asp:TableRow>
            <asp:TableRow>
            <asp:TableCell></asp:TableCell><asp:TableCell HorizontalAlign="left">
            <asp:Label ID="Label3" runat="server" Text="Username:" Font-Size="Small"></asp:Label> </asp:TableCell>
            <asp:TableCell HorizontalAlign="left">
            <asp:TextBox ID="txtLname" runat="server" tabindex="1" Width="245px"></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="ImageButton1" runat="server" 
                ControlToValidate="txtLname" ErrorMessage="Login name is missing!" 
                Font-Bold="True" >Required!</asp:RequiredFieldValidator></asp:TableCell> <asp:TableCell></asp:TableCell>
            <asp:TableCell HorizontalAlign="left" BorderStyle="None" BorderColor="#CC0000">   
            <asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="~/Images/viewguide_button.png"  onclick="ImageButton3_Click" />         
            </asp:TableCell> <asp:TableCell HorizontalAlign="Left" Font-Size="Small">View User Guide</asp:TableCell>    
            </asp:TableRow>
            <asp:TableRow>
            <asp:TableCell></asp:TableCell><asp:TableCell HorizontalAlign="left">
            <asp:Label ID="Label4" runat="server" Text="Password:" Font-Size="Small"></asp:Label> </asp:TableCell>
            <asp:TableCell HorizontalAlign="left">
            <asp:TextBox ID="txtPwd" runat="server" tabindex="2" TextMode="Password" Width="245px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="ImageButton1" 
            ControlToValidate="txtPwd" ErrorMessage="Password is missing!" Font-Bold="True">Required!</asp:RequiredFieldValidator></asp:TableCell>            
            </asp:TableRow>
            <asp:TableRow height="10px"></asp:TableRow>
            <asp:TableRow>          
            <asp:TableCell></asp:TableCell><asp:TableCell></asp:TableCell><asp:TableCell HorizontalAlign="left">            
            <asp:ImageButton ID="ImageButton1" runat="server" tabindex="3"  
                ImageUrl="~/Images/login_button.png" 
                 onclick="ImageButton1_Click" ValidationGroup="ImageButton1" /><asp:Label ID="Label23" runat="server" Text="Label" Visible="true" Width="10px" ForeColor="White"></asp:Label> 
                  
           <asp:ImageButton ID="ImageButton2" runat="server" tabindex="4"  
                ImageUrl="~/Images/register.png" 
                 onclick="ImageButton2_Click" /> 
            </asp:TableCell>            
                      
            </asp:TableRow>
             <asp:TableRow>
             <asp:TableCell></asp:TableCell>
            <asp:TableCell><asp:Label ID="lblMsg" runat="server" Text="Label" Visible="False" ForeColor="#CC3300" Font-Bold="True"></asp:Label></asp:TableCell>
            </asp:TableRow>   
            <asp:TableRow>
           <asp:TableCell></asp:TableCell>
            <asp:TableCell > 
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" Font-Bold="False" ValidationGroup="ImageButton1"
                HeaderText="Please correct the following errors:" 
                DisplayMode="BulletList" Font-Size="Small" EnableClientScript="False" />    
            </asp:TableCell>            
            </asp:TableRow> 
                      
           <%-- <asp:TableRow>             
            <asp:TableCell HorizontalAlign="left" BorderStyle="None" BorderColor="#CC0000">   
            <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Images/viewguide_button.png"  onclick="ImageButton3_Click" />         
            </asp:TableCell>             
            <asp:TableCell HorizontalAlign="Left" Font-Size="Small">View User Guide</asp:TableCell>            
            </asp:TableRow>
            <asp:TableRow>
            <asp:TableCell></asp:TableCell>
            </asp:TableRow>--%>
            <asp:TableRow>
            <asp:TableCell HorizontalAlign="center" Width="100px">
          <%-- <a href="Registration.aspx" style="color:Blue">New User?</a>--%>
           <%--</asp:TableCell>
            <asp:TableCell HorizontalAlign="center">
              <a href="Registration.aspx" style="color:Blue">New User?</a>--%>
          <a href="forgotpassword.aspx" style="color:Blue; font-size: small; font-weight: bold;">Forgot Password?</a>
          </asp:TableCell>
           </asp:TableRow>
          <%-- <asp:TableRow>
           <asp:TableCell Height="10px"></asp:TableCell>
           </asp:TableRow>--%>
             
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
     <div class="version">
         <asp:Label ID="lblversion" runat="server" Text="Version"></asp:Label>     </div>
     <div class="copy">© CONSUS International LTD 2014</div>
       <%-- <div id="navigation1">--%>
		<%--<ul>
			<li><a href="#">Tecom</a></li>
			<li><a href="#">Dubai Properties</a></li>
			<li><a href="#">Jumeirah</a></li>
			<li><a href="#">Home</a></li>
		</ul>--%>
     </div>  
    </form>
</body>
</html>
