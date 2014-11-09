using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Reflection;

namespace AuditMgtNew
{
    public partial class Login1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String m_systemVersion;
            Assembly assembly = Assembly.GetExecutingAssembly();
            m_systemVersion = assembly.GetName().Version.ToString();
            lblversion.Text = "Version:" + m_systemVersion;
          

            if (!IsPostBack && HttpContext.Current != null && HttpContext.Current.User != null && HttpContext.Current.User.Identity.IsAuthenticated)
            {
                FormsAuthentication.SignOut();      // If end-up at this page, ensure the user is actually logged-off.

                // Need to do a re-direct for this to take effect.
                // Otherwise the master page may re-activate the session using the
                // (not quite released) user authentication.
                Response.Redirect(Request.Url.ToString());
            }

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            SqlConnection con = new SqlConnection(DBUtil.ConnectionString);
            try
            {
                var haveSession = Session["mid"] != null;

                var username = txtLname.Text.Trim();
                var password = txtPwd.Text.Trim();

                con.Open();
                SqlCommand cmd = new SqlCommand("select * from oe_members where lname = @lname and pwd = @pwd", con);
                cmd.Parameters.Add("@lname", SqlDbType.VarChar, 10).Value = username;
                cmd.Parameters.Add("@pwd", SqlDbType.VarChar, 10).Value = password;

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    // Check that the user is the same: if not then may leak
                    // some session data => security risk.
                    if (haveSession && !string.Equals(dr["mid"], Session["mid"]))
                    {
                        Session.Clear();
                        haveSession = false;
                    }

                    Session.Add("mid", dr["mid"]);
                    Session.Add("fullname", dr["fullname"]);
                    Session.Add("dlv", dr["dlv"]);
                    // update MEMBERS table for DLV
                    dr.Close();
                    cmd.CommandText = "update oe_members set dlv = getdate() where lname = @lname";
                    cmd.ExecuteNonQuery();

                    // Force to always go to homepage if have also lost session as pages assume the session is valid.
                    if (haveSession)
                    {
                        FormsAuthentication.RedirectFromLoginPage(username, createPersistentCookie: false);
                    }
                    else
                    {
                        FormsAuthentication.SetAuthCookie(username, createPersistentCookie: false);
                        Response.Redirect(FormsAuthentication.DefaultUrl);
                    }
                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Invalid Login!";
                    dr.Close();
                }

            }
            catch (Exception ex)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Error --> " + ex.Message;
            }
            finally
            {
                con.Close();
            }
        }
        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {

            Response.Redirect("pdfViwerGuide.aspx");

        }
        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {

            Response.Redirect("Registration.aspx");

        }



    }
}
