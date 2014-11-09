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
    public partial class MainPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String m_systemVersion;
            Assembly assembly = Assembly.GetExecutingAssembly();
            m_systemVersion = assembly.GetName().Version.ToString();
            lblversion.Text = "Version:" + m_systemVersion;
           

            SqlConnection con = new SqlConnection(DBUtil.ConnectionString);

              

                con.Open();
                SqlCommand cmd = new SqlCommand("select * from oe_members where mid = @mid", con);
                cmd.Parameters.Add("@mid", SqlDbType.Int).Value = Session["mid"];
              

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {

                    lblmsg.Text = "Welcome: " + dr["fullname"].ToString();
                    lblmsg2.Text = "Last Visited On: " + dr["dlv"].ToString();
                }

        }
        protected void ImageButton4_ServerClick(object sender, ImageClickEventArgs e)
        {
            //foreach (ListItem item in contentcheck.Items)
            //{
            //    if (item.Selected)
            //    {
            //        if (contentcheck.SelectedValue == "Internal Audit")
            //            Response.Redirect("HomePageJM.aspx");
            //        else
            //            if (contentcheck.SelectedValue == "External Audit")
            //                Response.Redirect("HomeJMConsus.aspx");

            //    }
            //}


            Response.Redirect("HomePageJM.aspx");

        }
        protected void ImageButton5_ServerClick(object sender, EventArgs e)
        {
            //foreach (ListItem item in contentcheck.Items)
            //{
            //    if (item.Selected)
            //    {
            //        if (contentcheck.SelectedValue == "Internal Audit")
            //            Response.Redirect("HomePageDP.aspx");
            //        else
            //            if (contentcheck.SelectedValue == "External Audit")
            //                Response.Redirect("HomeDPConsus.aspx");

            //    }
            //}

            Response.Redirect("HomePageDP.aspx");


        }    



        protected void ImageButton6_ServerClick(object sender, EventArgs e)
        {
            //foreach (ListItem item in contentcheck.Items)
            //{
            //    if (item.Selected)
            //    {
            //        if (contentcheck.SelectedValue == "Internal Audit")
            //            Response.Redirect("HomePageTC.aspx");
            //        else
            //            if (contentcheck.SelectedValue == "External Audit")
            //                Response.Redirect("HomeTCConsus.aspx");

            //    }
            //}

            Response.Redirect("HomePageTC.aspx");


        }

      

        protected void btnlogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();

            Session.Abandon();

            Response.Redirect("Login.aspx");
        }
    }
}