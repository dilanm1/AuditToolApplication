<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AuditSaved.aspx.cs" Inherits="AuditMgtNew.AuditSaved" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type = "text/javascript" >
        function changeHashOnLoad() {
            window.location.href += "#";
            setTimeout("changeHashAgain()", "50");
        }

        function changeHashAgain() {
            window.location.href += "1";
        }

        var storedHash = window.location.hash;
        window.setInterval(function () {
            if (window.location.hash != storedHash) {
                window.location.hash = storedHash;
            }
        }, 50);


</script>
 <link href="Style/StyleSheet3.css" rel="stylesheet" type="text/css" />
</head>
<body onload="changeHashOnLoad();">
    <form id="form1" runat="server">
    <div class="wrapper">
    <div id="header">
    <div class="logo">   <asp:Image ID="Image1" runat="server" Height="77px" 
            ImageUrl="~/Images/dubai_holding_logo.png" Width="178px" /> </div>
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
      <asp:table ID="tblAudit" runat="server" border="0" style="font-size: 100%; font-family: Verdana;" >
       <asp:TableRow>
        <asp:TableCell Width="30%" HorizontalAlign="Left" style="font-weight:normal; color: #878787; background-color: " Font-Size="Small">
                    <asp:Label ID="lblLocation" runat="server" Text="Location"></asp:Label></asp:TableCell> 
       </asp:TableRow>
            <asp:TableRow Width="84%">
                <asp:TableCell  Width="50%" HorizontalAlign="Left" style="font-weight:normal; color: #878787; background-color: " Font-Size="Small">
                    <asp:Label ID="lblIndicatorName" runat="server" Text="Name"></asp:Label></asp:TableCell>
                    
                <asp:TableCell Width="50%" HorizontalAlign="right" style="font-weight:normal; color: #878787; background-color: " Font-Size="Small">
                    <asp:Label ID="lblQnum" runat="server" Text="Qnum"  style="font-weight:normal; color: #878787; background-color: " Font-Size="Small"></asp:Label></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
            <asp:TableCell HorizontalAlign="Left">
                <asp:Label ID="lblQid" runat="server" Text="Label"  style="font-weight:normal; color: #878787; background-color: " Font-Size="Small"></asp:Label>
            </asp:TableCell>
            </asp:TableRow>
    </asp:table>
    
    <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine"></asp:TextBox>
   <%-- <asp:CustomValidator id="CustomValidator1" runat="server" Visible="true" 
            Display="Dynamic" ErrorMessage="Conformance status is missing!" 
            ClientValidationFunction="CustomValidator1_ClientValidate" ForeColor="White" 
            OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>--%>
    <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Estimated Conformance Status:" 
            ForeColor="#878787"></asp:Label><%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                ControlToValidate="TextBox3" ErrorMessage="Evidence is missing!" 
                Font-Bold="True" 
                style="width: 5px; height: 19px" BackColor="#FF3300">Required</asp:RequiredFieldValidator>--%>
       
    <br />
    <table id="table1">
    <tr>
    <td>
    <asp:RadioButton ID="rbAns1" runat="server" GroupName="answer" Text="0" 
            Font-Bold="True" ForeColor="#FF3300" AutoPostBack="false" />
    </td>    
    <td style="width: 3px">
    <pre runat="server" id="ans1"></pre>
    </td>
        <%-- </tr>    
    <tr>--%>
    <td>
    <asp:RadioButton ID="rbAns2" runat="server" GroupName="answer" Text="1" 
            Font-Bold="True" ForeColor="Red" AutoPostBack="false" />
    </td>
    <td style="width: 3px">
    <pre runat="server" id="ans2"></pre>
    </td>
        <%-- </tr>    
    <tr>--%>
    <td>
    <asp:RadioButton ID="rbAns3" runat="server" GroupName="answer" Text="2" 
            Font-Bold="True" ForeColor="Red" AutoPostBack="false" />
    </td>
    <td style="width: 3px">
    <pre runat="server" id="ans3"></pre>
    </td>
        <%-- </tr>    
    <tr>--%>
    <td>
    <asp:RadioButton ID="rbAns4" runat="server" GroupName="answer" Text="3" 
            Font-Bold="True" ForeColor="Red" AutoPostBack="false" />
    </td>
    <td style="width: 3px">
    <pre runat="server" id="ans4"></pre>
    </td>
     <td>
    <asp:RadioButton ID="rbAns5" runat="server" GroupName="answer" Text="4" 
             Font-Bold="True" ForeColor="Red" AutoPostBack="false" />
    </td>    
    <td style="width: 3px">
    <pre runat="server" id="Pre1"></pre>
    </td>
     <td>
    <asp:RadioButton ID="rbAns6" runat="server" GroupName="answer" Text="5" 
             Font-Bold="True" ForeColor="Red" AutoPostBack="false" />
    </td>    
    <td style="width: 3px">
    <pre runat="server" id="Pre2"></pre>
    </td>
     <td>
    <asp:RadioButton ID="rbAns7" runat="server" GroupName="answer" Text="6" 
             Font-Bold="True" ForeColor="Red" />
    </td>    
    <td style="width: 3px">
    <pre runat="server" id="Pre3"></pre>
    </td>
     <td>
    <asp:RadioButton ID="rbAns8" runat="server" GroupName="answer" Text="7" 
             Font-Bold="True" ForeColor="Red" AutoPostBack="false" />
    </td>    
    <td style="width: 3px">
    <pre runat="server" id="Pre4"></pre>
    </td>
     <td>
    <asp:RadioButton ID="rbAns9" runat="server" GroupName="answer" Text="8" 
             Font-Bold="True" ForeColor="Red" AutoPostBack="false" />
    </td>    
    <td style="width: 3px">
    <pre runat="server" id="Pre5"></pre>
    </td>
     <td>
    <asp:RadioButton ID="rbAns10" runat="server" GroupName="answer" Text="9" 
             Font-Bold="True" ForeColor="Red" AutoPostBack="false" />
    </td>    
    <td style="width: 3px">
    <pre runat="server" id="Pre6"></pre>
    </td>
     <td>
    <asp:RadioButton ID="rbAns11" runat="server" GroupName="answer" Text="10" 
             Font-Bold="True" ForeColor="Red" AutoPostBack="false" />
    </td>    
    <td style="width: 3px">
    <pre runat="server" id="Pre7"></pre>
    </td>    
    </tr>      
   </table>
    <script type="text/javascript" src="//ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
  <script type = "text/javascript">
      function ValidateRadio(sender, args) {
          args.IsValid = $("[name=answer]:checked").length > 0;
      }
  </script>
  <asp:CustomValidator ID="CustomValidator1"  ValidationGroup="Submit" runat="server" 
            ErrorMessage="Conformance Status is required!!" 
            ClientValidationFunction = "ValidateRadio" ForeColor="Red"></asp:CustomValidator>
  
  
  <%-- <script language="javascript" type="text/javascript" >
       function CustomValidator1_ClientValidate(source, args) {
           if (document.getElementById("<%= rbAns1.ClientID %>").checked || document.getElementById("<%= rbAns2.ClientID %>").checked || document.getElementById("<%= rbAns3.ClientID %>").checked) {
               args.IsValid = true;
           }
           else {
               args.IsValid = false;
           }

       }
</script>--%>
  <br />
  
   <br />      
        <asp:table ID="tblAudit2" runat="server" border="0" style="font-size: 100%; font-family: Verdana;" >
            <asp:TableRow Width="100%">
                <asp:TableCell  Width="300" HorizontalAlign="Left" style="font-weight:normal; color: #878787; background-color: " Font-Size="Small">Evidence</asp:TableCell>
                <asp:TableCell Width="300" HorizontalAlign="Left" style="font-weight:normal; color: #878787; background-color: " Font-Size="Small">Auditors Comments</asp:TableCell>
                <asp:TableCell Width="300" HorizontalAlign="Left" style="font-weight:normal; color: #878787; background-color: " Font-Size="Small">Action</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow Width="100%">
                <asp:TableCell  Width="43%" HorizontalAlign="Left" style="font-weight:normal; color: #878787; background-color: " Font-Size="Small"><asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine" Width="99%"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
        ErrorMessage="Please Enter Evidence." ControlToValidate="TextBox2" ForeColor="Red" ValidationGroup="Submit">
        </asp:RequiredFieldValidator></asp:TableCell>
                        <asp:TableCell Width="43%" HorizontalAlign="Left" style="font-weight:normal; color: #878787; background-color: " Font-Size="Small"><asp:TextBox ID="TextBox3"
                    runat="server" TextMode="MultiLine" Width="99%"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ErrorMessage="Please Enter Comments."
        ControlToValidate="TextBox3" ForeColor="Red" ValidationGroup="Submit">
</asp:RequiredFieldValidator></asp:TableCell><asp:TableCell VerticalAlign="Top">
    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Vertical" Font-Size="Small" BorderStyle="Solid" BorderColor="#CCCCCC" BorderWidth="1px">
    <asp:ListItem Text="No Action" Value="No Action"></asp:ListItem>
    <asp:ListItem Text="Immediately" Value="Immediately"></asp:ListItem>
    <asp:ListItem Text="Within 1 month" Value="Within 1 month"></asp:ListItem>
    <asp:ListItem Text="Within 2 month" Value="Within 1 month"></asp:ListItem>
    <asp:ListItem Text="Within 4 month" Value="Within 4 month"></asp:ListItem>
    <asp:ListItem Text="Within 6 month" Value="Within 6 month"></asp:ListItem>


  <%--  <asp:ListItem>No Action</asp:ListItem>
    <asp:ListItem>Immediately</asp:ListItem>
    <asp:ListItem>Within 1 month</asp:ListItem>
    <asp:ListItem>Within 2 month</asp:ListItem>
    <asp:ListItem>Within 4 month</asp:ListItem>
    <asp:ListItem>Within 6 month</asp:ListItem>--%>
    </asp:RadioButtonList><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
        ErrorMessage="Please Select Action."
        ControlToValidate="RadioButtonList1" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator></asp:TableCell>
            </asp:TableRow>
    </asp:table>
    
      <asp:table ID="tblButtons" runat="server" border="0" style="font-size: 100%; font-family: Verdana;" >
            <asp:TableRow Width="100%">
                <asp:TableCell  Width="5%" HorizontalAlign="Left" style="font-weight:normal; color: #878787; background-color: " Font-Size="Small"> <asp:ImageButton ID="ImageButton6" runat="server" ImageUrl="~/Images/guidance_button.png" /></asp:TableCell>
                <asp:TableCell Width="5%" HorizontalAlign="Left" style="font-weight:normal; color: #878787; background-color: " Font-Size="Small"><asp:ImageButton ID="ImageButton7" runat="server" ImageUrl="~/Images/references_button.png" /></asp:TableCell>
                <asp:TableCell Width="5%" HorizontalAlign="Left" style="font-weight:normal; color: #878787; background-color: " Font-Size="Small"><asp:ImageButton ID="ImageButton1" onclick ="ImageButton1_ServerClick" runat="server" ImageUrl="~/Images/glossary_button.png" /></asp:TableCell>
                 <asp:TableCell Width="5%" HorizontalAlign="right" style="font-weight:normal; color: #878787; background-color: " Font-Size="Small"><asp:ImageButton ID="ImageButton3" runat="server" onclick="ImageButton3_ServerClick" ImageUrl="~/Images/cancel.png" Visible="True" /></asp:TableCell>
                 <asp:TableCell Width="5%" HorizontalAlign="right" style="font-weight:normal; color: #878787; background-color: " Font-Size="Small"><asp:ImageButton ID="ImageButton8" runat="server" onclick="ImageButton8_ServerClick" ImageUrl="~/Images/save_button.png"/></asp:TableCell>
                <%-- <asp:TableCell Width="5%" HorizontalAlign="right" style="font-weight:normal; color: #878787; background-color: " Font-Size="Small"><asp:ImageButton ID="ImageButton9" runat="server" onclick="ImageButton9_ServerClick" ImageUrl="~/Images/previous_button.png" /></asp:TableCell>--%>
                 <asp:TableCell Width="5%" HorizontalAlign="right" style="font-weight:normal; color: #878787; background-color: " Font-Size="Small"><asp:ImageButton ID="btnNext" runat="server" ValidationGroup="Submit" onclick="btnNext_ServerClick" ImageUrl="~/Images/savenext_button.png" /><asp:ImageButton ID="ImageButton2" runat="server" Visible="false" onclick="btnNext_ServerClick" ImageUrl="~/Images/viewreport_button.png" /></asp:TableCell>
            </asp:TableRow>
           
    </asp:table>
    <br />
    
    <ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajax:ToolkitScriptManager>

    <%-- <asp:HyperLink runat="server" ID="HyperLink1" NavigateUrl="" Text="New Employee"  />--%>    <%-- <asp:LinkButton ID="LinkButton2" runat="server" onclick="">Guidance</asp:LinkButton>--%>
    <%--<asp:Panel ID="Panel1" runat="server" BorderColor="Black" BackColor="White" Height="600px"
        Width="800px" HorizontalAlign="Center" BorderStyle="Solid">
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
            GridLines="None" Height="90%" onrowdatabound="GridView1_RowDataBound" 
            ShowHeader="true" Width="100%" RowStyle-HorizontalAlign="Left" 
            AutoGenerateColumns="True">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
           <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="submit" OnClick="Button2_Click" margin-bottom="0px"/>
        <asp:Button ID="Button2" runat="server" Text="cancel" onclick="can_Click" margin-bottom="0px" />
    </asp:Panel>    --%>

 <asp:Panel ID="ModalPanel" runat="server" BorderColor="Black" BackColor="White" Height="550px"
        Width="600px" HorizontalAlign="Center" BorderStyle="Solid">
        <h3 style="text-align: center;"id="h1">Guidance</h3>
  <asp:TextBox ID="TextBox4" runat="server" ForeColor="Black" Height="450px" 
            TextMode="MultiLine" Width="500px"  BackColor="White" BorderStyle="None" 
            BorderColor="White" ontextchanged="TextBox4_TextChanged"></asp:TextBox>
          
 <asp:Button ID="OKButton1" runat="server" Text="Close" />
</asp:Panel>

   <%-- <ajax:ModalPopupExtender ID="MPE" runat="server" TargetControlID="Button3" PopupControlID="Panel1"
        BackgroundCssClass="modalBackground" CancelControlID="can" Drag="True" 
        DropShadow="True"> 
   </ajax:ModalPopupExtender>--%>

   <ajax:ModalPopupExtender ID="mpe" runat="server" TargetControlId="ImageButton6" 
 PopupControlID="ModalPanel" OkControlID="OKButton1" BackgroundCssClass="modalBackground" Drag="True" 
 DropShadow="True" PopupDragHandleControlID="ModalPanel" />

  <asp:Panel ID="Panel1" runat="server" BorderColor="Black" BackColor="White" Height="550px"
        Width="600px" HorizontalAlign="Center" BorderStyle="Solid">
        <h3 style="text-align: center;"id="header1">Reference</h3>
        <asp:TextBox ID="TextBox5" runat="server" ForeColor="Black" Height="450px" 
            TextMode="MultiLine" Width="500px"  BackColor="White" BorderStyle="None" 
            BorderColor="Silver" ontextchanged="TextBox5_TextChanged"></asp:TextBox>
<%-- <asp:GridView ID="GridView2" runat="server" CellPadding="4" ForeColor="#333333" 
            GridLines="None" Height="90%" onrowdatabound="GridView2_RowDataBound" 
          Width="100%" RowStyle-HorizontalAlign="Left" 
            AutoGenerateColumns="False">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>--%>
          
 <asp:Button ID="Button123" runat="server" Text="Close" />
</asp:Panel>

<ajax:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlId="ImageButton7" 
 PopupControlID="Panel1" OkControlID="Button123" BackgroundCssClass="modalBackground" Drag="True" 
 DropShadow="True" PopupDragHandleControlID="Panel1" />

    <%-- <ajax:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="LinkButton2" PopupControlID="Panel1"
        BackgroundCssClass="modalBackground" CancelControlID="can" Drag="True" BehaviorID="popUp2"
        DropShadow="True"  PopupDragHandleControlID="header">
    </ajax:ModalPopupExtender>--%>
   
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

