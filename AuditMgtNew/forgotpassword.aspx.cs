using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Data;

using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;
using System.Net;

namespace AuditMgtNew
{
    public partial class Forgotpassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSubmitClick(object sender, EventArgs e)
        {
            // Check email address
            SqlConnection con = new SqlConnection(DBUtil.ConnectionString);
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
                //MailAddress from = new MailAddress("admin@classroom");
                //MailAddress to = new MailAddress(txtEmail.Text);
                //MailMessage msg = new MailMessage(from, to);
                //msg.Subject = "Password Reminder";
                //msg.IsBodyHtml = true;
                //msg.Body = "Dear Subscriber <p>Please use the following details to login.<p>Login name : " + dr["lname"] + "<br>Password : " + dr["pwd"] + "<p>WebMaster<br>DJTechnologies.com";
                //SmtpClient client = new SmtpClient("localhost");
                //client.Send(msg);
                SendEmail(dr["fullname"], txtEmail.Text.Trim(), dr["pwd"]);
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
 
       

        public void SendEmail(object firstname, string email, object password)
        {
            MailMessage emailMessage = new MailMessage("djnuni9@googlemail.com", email);
            emailMessage.Subject = "Password Recovery";

            string body = "Dear " + firstname + ",<br/><br/>";
            body += "Here is your password:'" + password + "'. <br/>";
            body += "Please login using your username and password. <br/><br/>";
            body += "Thank You. <br/><br/>";
            body += "Audit Tool Admin";

            emailMessage.Body = body;
            emailMessage.IsBodyHtml = true;

            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            NetworkCredential networkCred = new NetworkCredential("djnuni9@googlemail.com", "Sophie20");
            client.UseDefaultCredentials = true;
            client.Credentials = networkCred;
            client.Port = 587;
            client.Send(emailMessage);
        }

        protected void BtnCancelClick(object sender, EventArgs e)
        {
            Response.Redirect("../login.aspx");
        }
    }
}