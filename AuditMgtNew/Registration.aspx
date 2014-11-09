<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="AuditMgtNew.Registration" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title></title>
    
    <link href="Style/StyleSheet3.css" rel="stylesheet" type="text/css" />
     <style type="text/css">
         .style1
         {
             height: 31px;
             width: 481px;
         }
         .style2
         {
             width: 155px;
         }
         .style3
         {
             height: 31px;
             width: 155px;
         }
         .style4
         {
             width: 481px;
         }
     </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="wrapper">
    <div id="header">
    <div class="logo">    <asp:Image ID="Image1" runat="server" Height="77px" 
            ImageUrl="~/Images/dubai_holding_logo.png" Width="178px" /> </div>
        <ul>
			
			<li><a href="HomePageTC.aspx">Tecom</a></li>
			<li><a href="HomePageDP.aspx">Dubai Properties</a></li>
			<li><a href="HomePageJM.aspx">Jumeirah</a></li>
			<li><a href="MainPage.aspx">Home</a></li>
		</ul>
       
	</div>
    <div id="content">
      <h2 align="center">
    New User Registration
    </h2>
    <center>
    <table ID="tblLoginJM" runat="server" border="0" width="1000px"
            style="font-size: 100%; font-family:Arial; left: 3px;" 
            height="100px" align="center">
        <tr>
            <td align="right" class="style2">
                Login name :</td>
            <td align="left" class="style4" width="800px" >
                <asp:TextBox ID="txtLname" runat="server" style="text-align: left"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLname"
                    ErrorMessage="Login Name Required!" ForeColor="Red" ValidationGroup="ImageButton1"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td align="right" class="style2" >
                Password :
            </td>
            <td align="left" class="style4" width="800px" >
                <asp:TextBox ID="txtPwd" runat="server" TextMode="Password" Width="149px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPwd"
                    ErrorMessage="Password is required!" ForeColor="Red" 
                    ValidationGroup="ImageButton1"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td align="right" class="style2" >
                Confirm Password :</td>
            <td align="left" class="style4" width="800px" >
                <asp:TextBox ID="txtCpwd" runat="server" TextMode="Password" Width="149px" 
                    Height="22px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCpwd"
                    ErrorMessage="Confirm password required!" ForeColor="Red" ValidationGroup="ImageButton1"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPwd"
                    ControlToValidate="txtCpwd" ErrorMessage="Passwords do not match!" 
                    ForeColor="Red" ValidationGroup="ImageButton1"></asp:CompareValidator></td>
        </tr>
        <tr>
            <td align="right" class="style2" >
                Fullname :</td>
            <td align="left" class="style4" width="800px" >
                <asp:TextBox ID="txtFname" runat="server" Width="243px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtFname"
                    ErrorMessage="Fullname is required!" ForeColor="Red" ValidationGroup="ImageButton1"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td align="right" class="style2" >
                Email Address :</td>
            <td align="left" class="style4" width="800px" >
                <asp:TextBox ID="txtEmail" runat="server" Width="240px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtEmail"
                    ErrorMessage="Email address is required!" ForeColor="Red" ValidationGroup="ImageButton1"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
        <td class="style3" align="right">
       
        </td>
        <td align="left" class="style1" width="800px">
             <asp:ImageButton ID="ImageButton1" runat="server" ValidationGroup="ImageButton1" 
                ImageUrl="~/Images/register.png" 
                 onclick="ImageButton1_Click" />  
             &nbsp;<asp:ImageButton ID="ImageButton2" runat="server"  
                ImageUrl="~/Images/cancel.png" 
                 onclick="ImageButton2_Click" /> 
        </td> 
        </tr>
        <tr><td class="style2"> <asp:Label ID="lblMsg" runat="server"></asp:Label></td>
        </tr>
    </table>    
    </center>
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
