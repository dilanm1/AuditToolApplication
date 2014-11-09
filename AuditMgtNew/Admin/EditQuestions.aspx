<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditQuestions.aspx.cs" Inherits="AuditMgtNew.Admin.EditQuestions" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title></title>
    <link href="/Style/StyleJM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
     <div class="wrapper">
	<div id="header">
    <div class="logo">    <asp:Image ID="Image1" runat="server" Height="77px" 
            ImageUrl="~/Images/jumeirah_group_logo.png" Width="178px" /></div>
        
        <ul>
			<li><asp:Button ID="btnlogout" runat="server" Text="logout" BackColor="White" 
                ForeColor="#FF3300" BorderColor="White" BorderStyle="Solid" 
                onclick="btnlogout_Click" /></li>
			<li><a href="/ReportScoreLocation.aspx">Analysis</a></li>
			<li><a href="/ReportAuditorJM.aspx">Reports</a></li>
			<li><a href="/AuditLevelJM.aspx">Audit</a></li>
			<li><a href="/Admin/AdminJM.aspx">Admin</a></li>
		</ul>
       
	</div>
    <div id="content">
        <asp:Label ID="lblLocation" runat="server" Text="Label" Visible="false"></asp:Label>
        <br />
        <asp:Label ID="lblindicator" runat="server" Text="Label" Visible="false"></asp:Label>
      <br />  
        <asp:Label ID="lblsid" runat="server" Text="Please Select The Indicator:" Visible="True"></asp:Label><asp:DropDownList
            ID="DropDownList1" runat="server" AutoPostBack="True" 
            DataSourceID="SqlDataSource2" DataTextField="sname" DataValueField="sid">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:examConnectionString %>" 
            SelectCommand="SELECT DISTINCT [sid], [sname] FROM [oe_subjects] ORDER BY [sid], [sname]">
        </asp:SqlDataSource>
        <br />
        <center>        
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                CellPadding="4" DataKeyNames="id" DataSourceID="SqlDataSource1" 
                ForeColor="#333333">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:CommandField ShowEditButton="True" />
                    <asp:BoundField DataField="qid" HeaderText="qid" SortExpression="qid" >
                    <ControlStyle Width="20px" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="question" SortExpression="question">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Height="500px" 
                                Text='<%# Bind("question") %>' TextMode="MultiLine" Width="300px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("question") %>'></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Height="300px" Width="300px" />
                        <ItemStyle Height="300px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ref" SortExpression="ref">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Height="300px" 
                                Text='<%# Bind("ref") %>' TextMode="MultiLine" Width="300px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("ref") %>'></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Height="300px" Width="300px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="guid" SortExpression="guid">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox3" runat="server" Height="300px" 
                               Text='<%# Bind("guid")  %>' TextMode="MultiLine" Width="300px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox4" runat="server" Height="300px" TextMode="MultiLine" 
                                Text='<%# Bind("guid")  %>' Width="300px"></asp:TextBox>
                        </ItemTemplate>
                        <ControlStyle Height="300px" Width="300px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="id" HeaderText="id" 
                        SortExpression="id" Visible="False" ReadOnly="True" InsertVisible="False">
                    </asp:BoundField>
                </Columns>
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
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:examConnectionString %>" 
                DeleteCommand="DELETE FROM [tblQuestionsJMSub] WHERE [id] = @id" 
                InsertCommand="INSERT INTO [tblQuestionsJMSub] ([qid], [question], [ref], [guid]) VALUES (@qid, @question, @ref, @guid)" 
                SelectCommand="SELECT [qid], [question], [ref], [guid], [id] FROM [tblQuestionsJMSub] WHERE ([sid] = @sid)" 
                
                
                
                
                UpdateCommand="UPDATE [tblQuestionsJMSub] SET [qid] = @qid, [question] = @question, [ref] = @ref, [guid] = @guid WHERE [id] = @id">
                <DeleteParameters>
                    <asp:Parameter Name="id" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="qid" Type="String" />
                    <asp:Parameter Name="question" Type="String" />
                    <asp:Parameter Name="ref" Type="String" />
                    <asp:Parameter Name="guid" Type="String" />
                </InsertParameters>
                <SelectParameters>
                    <asp:ControlParameter ControlID="DropDownList1" Name="sid" 
                        PropertyName="SelectedValue" Type="Int32" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="qid" Type="String" />
                    <asp:Parameter Name="question" Type="String" />
                    <asp:Parameter Name="ref" Type="String" />
                    <asp:Parameter Name="guid" Type="String" />
                    <asp:Parameter Name="id" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </center>

    <%--<div>--%>
      <%--  <asp:GridView ID="gvDetails" DataKeyNames="examid,sid,qid" runat="server"
        AutoGenerateColumns="False" CssClass="Gridview" HeaderStyle-BackColor="#61A6F8"
        ShowFooter="True" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White" onrowediting="gvDetails_RowEditing"
        onrowupdating="gvDetails_RowUpdating" 
            onrowcancelingedit="gvDetails_RowCancelingEdit" 
            AlternatingRowStyle-BackColor="#E6FFFF" 
            onrowdatabound="gvDetails_RowDataBound1">
<AlternatingRowStyle BackColor="#E6FFFF"></AlternatingRowStyle>
      <Columns>
        <asp:TemplateField>
        <EditItemTemplate>
        <asp:ImageButton ID="imgbtnUpdate" CommandName="Update" runat="server" ImageUrl="~/Images/update.png" ToolTip="Update" Height="20px" Width="100px" />
        <asp:ImageButton ID="imgbtnCancel" runat="server" CommandName="Cancel" ImageUrl="~/Images/cancel.png" ToolTip="Cancel" Height="20px" Width="100px" />
        </EditItemTemplate>
        <ItemTemplate>
        <asp:ImageButton ID="imgbtnEdit" CommandName="Edit" runat="server" ImageUrl="~/Images/edit.png" ToolTip="Edit" Height="20px" Width="20px" />       
        </ItemTemplate>             
            <ControlStyle Width="100px" />
        </asp:TemplateField>
         <asp:TemplateField HeaderText="Subject ID">
        <EditItemTemplate>
        <asp:Label ID="lbleditusr1" runat="server" Text='<%#Eval("sid") %>'/>
        </EditItemTemplate>
        <ItemTemplate>
        <asp:Label ID="lblitemUsr1" runat="server" Text='<%#Eval("sid") %>'/>
        </ItemTemplate>        
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Question ID">
        <EditItemTemplate>
        <asp:Label ID="lbleditusr" runat="server" Text='<%#Eval("qid") %>'/>
        </EditItemTemplate>
        <ItemTemplate>
        <asp:Label ID="lblitemUsr" runat="server" Text='<%#Eval("qid") %>'/>
        </ItemTemplate>        
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Question">
        <ItemTemplate>
        <asp:Label ID="lblcity5" runat="server" Text='<%#Eval("question") %>'/>
        </ItemTemplate>       
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Evidence">
        <EditItemTemplate>
        <asp:TextBox ID="txtDesg" runat="server" Text='<%#Eval("evidence") %>'/>
        </EditItemTemplate>
         <ItemTemplate>
        <asp:Label ID="lblcity" runat="server" Text='<%#Eval("evidence") %>'/>
        </ItemTemplate>        
        </asp:TemplateField>
         <asp:TemplateField HeaderText="Comments">
        <EditItemTemplate>
        <asp:TextBox ID="txtDesg3" runat="server" Text='<%#Eval("comments") %>'/>
        </EditItemTemplate>
         <ItemTemplate>
        <asp:Label ID="lblcity3" runat="server" Text='<%#Eval("comments") %>'/>
        </ItemTemplate>        
        </asp:TemplateField>             
        <asp:TemplateField HeaderText="Conformance Score">
        <EditItemTemplate>
        <asp:TextBox ID="txtDesg2" runat="server" Text='<%#Eval("answer") %>'/>
        </EditItemTemplate>
        <ItemTemplate>
        <asp:Label ID="lblDesg2" runat="server" Text='<%#Eval("answer") %>'/>
        </ItemTemplate>     
        </asp:TemplateField>
        </Columns>

<HeaderStyle BackColor="#61A6F8" Font-Bold="True" ForeColor="White"></HeaderStyle>
        </asp:GridView>
        </div>

         <div>
             <asp:Label ID="lblresult" runat="server" Text="Label" Visible="False"></asp:Label>
         
         </div>   --%>
  
    


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
