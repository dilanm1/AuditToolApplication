<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Audit.aspx.cs" Inherits="AuditMgtNew.Audit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
  <h2>Audit</h2>
    <table width="100%" bgcolor="#dddddd">
    <tr>
    <td>
        Indicator Name: 
        <asp:Label ID="lblSubject" runat="server" Width="346px" Font-Bold="True" 
            Font-Names="Verdana" ForeColor="#666666"></asp:Label></td>
    <td>
        Question :
        <asp:Label ID="lblQno" runat="server" Font-Bold="True" Font-Names="Verdana" 
            ForeColor="Silver"></asp:Label></td>
           
    </tr>
    <tr>
    <td>
        Started At :
        <asp:Label ID="lblStime" runat="server" Font-Bold="True" Font-Names="Verdana" 
            ForeColor="Silver"></asp:Label></td>
    <td style="height: 22px">
        Current Time :<asp:Label ID="lblCtime" runat="server" Font-Bold="True" 
            Font-Names="Verdana" ForeColor="Silver"></asp:Label></td>
    </tr>
    <tr>
    <td>
        Question No:<asp:Label ID="lblQuestionId" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </td>
    <td style="height: 22px">
        &nbsp;</td>
    </tr>
    </table>
    
    <p />
        <%--<b><pre runat=server id="question" style="background-color:#eeeeee">question</pre> </b>--%>
    <asp:TextBox ID="TextBox1" runat="server" ForeColor="Black" Height="300px" 
            TextMode="MultiLine" Width="100%" BackColor="#E8E8E8" BorderStyle="Outset" 
            ontextchanged="TextBox1_TextChanged"></asp:TextBox>
    <p>Estimated Conformance Status:</p>
    <table>
    <tr>
    <td>
    <asp:RadioButton ID="rbAns1" runat="server" GroupName="answer" Text="0" 
            Font-Bold="True" ForeColor="#FF3300" />
    </td>    
    <td style="width: 3px">
    <pre runat="server" id="ans1"></pre>
    </td>
        <%-- </tr>    
    <tr>--%>
    <td>
    <asp:RadioButton ID="rbAns2" runat="server" GroupName="answer" Text="1" 
            Font-Bold="True" ForeColor="Red" />
    </td>
    <td style="width: 3px">
    <pre runat="server" id="ans2"></pre>
    </td>
        <%-- </tr>    
    <tr>--%>
    <td>
    <asp:RadioButton ID="rbAns3" runat="server" GroupName="answer" Text="2" 
            Font-Bold="True" ForeColor="Red" />
    </td>
    <td style="width: 3px">
    <pre runat="server" id="ans3"></pre>
    </td>
        <%-- </tr>    
    <tr>--%>
    <td>
    <asp:RadioButton ID="rbAns4" runat="server" GroupName="answer" Text="3" 
            Font-Bold="True" ForeColor="Red" />
    </td>
    <td style="width: 3px">
    <pre runat="server" id="ans4"></pre>
    </td>
     <td>
    <asp:RadioButton ID="rbAns5" runat="server" GroupName="answer" Text="4" 
             Font-Bold="True" ForeColor="Red" />
    </td>    
    <td style="width: 3px">
    <pre runat="server" id="Pre1"></pre>
    </td>
     <td>
    <asp:RadioButton ID="rbAns6" runat="server" GroupName="answer" Text="5" 
             Font-Bold="True" ForeColor="Red" />
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
             Font-Bold="True" ForeColor="Red" />
    </td>    
    <td style="width: 3px">
    <pre runat="server" id="Pre4"></pre>
    </td>
     <td>
    <asp:RadioButton ID="rbAns9" runat="server" GroupName="answer" Text="8" 
             Font-Bold="True" ForeColor="Red" />
    </td>    
    <td style="width: 3px">
    <pre runat="server" id="Pre5"></pre>
    </td>
     <td>
    <asp:RadioButton ID="rbAns10" runat="server" GroupName="answer" Text="9" 
             Font-Bold="True" ForeColor="Red" />
    </td>    
    <td style="width: 3px">
    <pre runat="server" id="Pre6"></pre>
    </td>
     <td>
    <asp:RadioButton ID="rbAns11" runat="server" GroupName="answer" Text="10" 
             Font-Bold="True" ForeColor="Red" />
    </td>    
    <td style="width: 3px">
    <pre runat="server" id="Pre7"></pre>
    </td>
    
    </tr>
    
    </table>    
    <p />
    <br />
        <%--<b><pre runat=server id="question" style="background-color:#eeeeee">question</pre> </b>--%>
    <asp:TextBox ID="TextBox2" runat="server" ForeColor="Black" Height="100px" 
            TextMode="MultiLine" Width="47%"  BackColor="White" BorderStyle="Groove" 
            BorderColor="Silver">Evidence</asp:TextBox>
     <asp:TextBox ID="TextBox3" runat="server" ForeColor="Black" Height="100px" 
            TextMode="MultiLine" Width="47%" BackColor="White" BorderStyle="Outset" 
            BorderColor="Silver">Comments</asp:TextBox>
    <br />
        <br />
        <asp:Button ID="btnPrev" runat="server" Text="Previous" OnClick="btnPrev_Click" 
            Width="115px" />&nbsp;<asp:Button ID="btnNext"
            runat="server" Text="Next" Width="115px" OnClick="btnNext_Click" />
        &nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel Audit" Width="115px" 
            OnClick="btnCancel_Click" />
        
    

        &nbsp;<asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" Text="Save" 
            Width="115px" />

       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

       <asp:Button ID="ClientButton" runat="server" Text="Guidance" Width="115px" 
            onclick="ClientButton_Click" />
        &nbsp;<asp:Button ID="Button2" runat="server" Text="Reference" Width="115px" 
            onclick="Button2_Click1" />

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

 <asp:Panel ID="ModalPanel" runat="server" BorderColor="Black" BackColor="White" Height="700px"
        Width="1000px" HorizontalAlign="Center" BorderStyle="Solid">
        <h3 style="text-align: center;"id="header">Guidance</h3>
  <asp:TextBox ID="TextBox4" runat="server" ForeColor="Black" Height="450px" 
            TextMode="MultiLine" Width="900px"  BackColor="White" BorderStyle="None" 
            BorderColor="White" ontextchanged="TextBox4_TextChanged">Evidence</asp:TextBox>
           <br />
        <br />
 <asp:Button ID="OKButton" runat="server" Text="Close" />
</asp:Panel>

   <%-- <ajax:ModalPopupExtender ID="MPE" runat="server" TargetControlID="Button3" PopupControlID="Panel1"
        BackgroundCssClass="modalBackground" CancelControlID="can" Drag="True" 
        DropShadow="True"> 
   </ajax:ModalPopupExtender>--%>

   <ajax:ModalPopupExtender ID="mpe" runat="server" TargetControlId="ClientButton" 
 PopupControlID="ModalPanel" OkControlID="OKButton" BackgroundCssClass="modalBackground" Drag="True" 
 DropShadow="True" PopupDragHandleControlID="header" />

  <asp:Panel ID="Panel1" runat="server" BorderColor="Black" BackColor="White" Height="700px"
        Width="800px" HorizontalAlign="Center" BorderStyle="Solid">
        <h3 style="text-align: center;"id="header1">Reference</h3>
        <asp:TextBox ID="TextBox5" runat="server" ForeColor="Black" Height="550px" 
            TextMode="MultiLine" Width="600px"  BackColor="White" BorderStyle="None" 
            BorderColor="Silver" ontextchanged="TextBox5_TextChanged">Evidence</asp:TextBox>
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
           <br />
        <br />
 <asp:Button ID="Button1" runat="server" Text="Close" />
</asp:Panel>

<ajax:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlId="Button2" 
 PopupControlID="Panel1" OkControlID="Button1" BackgroundCssClass="modalBackground" Drag="True" 
 DropShadow="True" PopupDragHandleControlID="header1" />

    <%-- <ajax:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="LinkButton2" PopupControlID="Panel1"
        BackgroundCssClass="modalBackground" CancelControlID="can" Drag="True" BehaviorID="popUp2"
        DropShadow="True"  PopupDragHandleControlID="header">
    </ajax:ModalPopupExtender>--%>

    
     
    
</asp:Content>
