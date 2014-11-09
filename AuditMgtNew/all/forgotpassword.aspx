<%@ Page Language="C#" MasterPageFile="~/all/all.master" Title="Untitled Page" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Net.Mail" %>

<script runat="server">

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("../login.aspx");
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        // Check email address
        SqlConnection con = new SqlConnection(DBUtil.ConnectionString );
        try
        {
            con.Open();
            // check whether email address is preset
            SqlCommand cmd = new SqlCommand("select * from oe_members where email = @email", con);
            cmd.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = txtEmail.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            if (!dr.Read())
            {
                lblMsg.Text = "Sorry! Email address is not found!";
                return;     
            }
            // send mail 
            MailAddress from = new MailAddress("admin@classroom");
            MailAddress to = new MailAddress(txtEmail.Text);
            MailMessage msg = new MailMessage(from , to);
            msg.Subject = "Password Reminder";
            msg.IsBodyHtml = true;
            msg.Body = "Dear Subscriber <p>Please use the following details to login.<p>Login name : " + dr["lname"] + "<br>Password : " + dr["pwd"] + "<p>WebMaster<br>DJTechnologies.com";
            SmtpClient client = new SmtpClient("localhost");
            client.Send(msg); 
            lblMsg.Text = "Details of your account are sent to your email address. Please use them to login!";
           }
        catch (Exception ex)
        {
            lblMsg.Text = "Error --> " + ex.Message;
        }
        finally
        {
            con.Close();
        }
    }
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>Password Reminder</h2>
    Enter email address :
    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail"
        ErrorMessage="Email address is required!"></asp:RequiredFieldValidator><br />
    <br />
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />&nbsp;<asp:Button ID="btnCancel"
        runat="server" CausesValidation="False" OnClick="btnCancel_Click" Text="Cancel" /><br />
    <br />
    <asp:Label ID="lblMsg" runat="server"></asp:Label>
</asp:Content>

