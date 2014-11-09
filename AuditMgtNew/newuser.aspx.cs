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
    public partial class newuser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            // register 
            SqlConnection con = new SqlConnection(DBUtil.ConnectionString);
            try
            {
                con.Open();
                // check whether login name is unique 
                SqlCommand cmd = new SqlCommand("select * from oe_members where lname = @lname", con);
                cmd.Parameters.Add("@lname", SqlDbType.VarChar, 10).Value = txtLname.Text;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    lblMsg.Text = "Login name is not unqiue. Plase enter a different login name!";
                    return;
                }
                dr.Close();

                // check whether email address is unique
                cmd.Parameters.Clear();
                cmd.CommandText = "select * from oe_members where email = @email";
                cmd.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = txtEmail.Text;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    lblMsg.Text = "Email address is not unqiue!";
                    return;
                }
                dr.Close();

                // get next MID
                cmd.CommandText = "select  isnull(max(mid),0) + 1 from oe_members";
                int mid = (Int32)cmd.ExecuteScalar();
                // insert row into OE_MEMEBERS
                cmd.Parameters.Clear();
                cmd.CommandText = "insert into oe_members values(@mid,@lname,@pwd,@fullname,@email,null,getdate())";
                cmd.Parameters.Add("@mid", SqlDbType.Int).Value = mid;
                cmd.Parameters.Add("@lname", SqlDbType.VarChar, 10).Value = txtLname.Text;
                cmd.Parameters.Add("@pwd", SqlDbType.VarChar, 10).Value = txtPwd.Text;
                cmd.Parameters.Add("@fullname", SqlDbType.VarChar, 30).Value = txtFname.Text;
                cmd.Parameters.Add("@email", SqlDbType.VarChar, 30).Value = txtEmail.Text;
                if (cmd.ExecuteNonQuery() > 0)
                    lblMsg.Text = "Registration is successful. Please click <a href=../Login.aspx>here</a> to login!";
                else
                    lblMsg.Text = "Sorry! Some error occured during registration!";
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

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("../login.aspx");
        }
    }
}