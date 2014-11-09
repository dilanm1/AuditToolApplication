using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace AuditMgtNew
{
    public partial class HomeDP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void chkRemember_CheckedChanged(object sender, EventArgs e)
        {

        }
       
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

            SqlConnection con = new SqlConnection(DBUtil.ConnectionString);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from oe_members where lname = @lname and pwd = @pwd", con);
                cmd.Parameters.Add("@lname", SqlDbType.VarChar, 10).Value = txtLname.Text;
                cmd.Parameters.Add("@pwd", SqlDbType.VarChar, 10).Value = txtPwd.Text;

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Session.Add("mid", dr["mid"]);
                    Session.Add("fullname", dr["fullname"]);
                    Session.Add("dlv", dr["dlv"]);
                    // update MEMBERS table for DLV
                    dr.Close();
                    cmd.CommandText = "update oe_members set dlv = getdate() where lname = @lname";
                    cmd.ExecuteNonQuery();
                    Response.Redirect("AuditLevelDP.aspx");
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

    }
}