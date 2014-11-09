using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.Security;

namespace AuditMgtNew
{
    public partial class GridViewEdit : System.Web.UI.Page
    {




        //    SqlConnection con = new SqlConnection(DBUtil.ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {


            lblLocation.Text = Session["location"].ToString();

            //        if (!IsPostBack)
            //        {


            //            BindEmployeeDetails();

            //            // lblName.Text = (row.FindControl("lblName") as Label).Text;
            //            //  lblCountry.Text = row.Cells[2].Text;  
            //        }
            //    }



            //    protected void BindEmployeeDetails()
            //    {



            //        lblLocation.Text = (string)Session["location"];
            //        // lblSublocation.Text = (string)Session["Month"];

            //        //  string s = Request.QueryString["sid"].ToString();
            //        if (this.Page.PreviousPage != null)
            //        {

            //            int rowIndex = int.Parse(Request.QueryString["RowIndex"]);
            //            GridView GridView1 = (GridView)this.Page.PreviousPage.FindControl("GridView1");
            //           // GridView1.DataBind(); 
            //            GridViewRow row = GridView1.Rows[rowIndex];
            //            string sid = row.Cells[0].Text;
            //            string sname = row.Cells[1].Text.ToString();
            //            lblindicator.Text = sname;


            //            //  int sid = Convert.ToInt32(gvDetails.DataKeys[e.RowIndex].Value.ToString());
            //            //  string sid = Request.QueryString["sid"].ToString();
            //            string name = lblLocation.Text;
            //            SqlConnection con = new SqlConnection(DBUtil.ConnectionString);
            //            //string color_na = textBox3.Text;
            //            string commandQuery = "Select * from tblSavedAnswers where sid = @sid and location=@loc and mid=@mid";
            //            using (SqlCommand cmd = new SqlCommand(commandQuery, con))
            //            {
            //                cmd.Parameters.AddWithValue("@mid", Session["mid"]);
            //                //  cmd.Parameters.AddWithValue("@sid", Session["sid"]);
            //                cmd.Parameters.Add("@sid", SqlDbType.Int).Value = sid;
            //                cmd.Parameters.Add("@loc", SqlDbType.NVarChar).Value = lblLocation.Text;
            //                //cmd.Parameters.AddWithValue("@model", Area);


            //                //  SqlConnection con2 = new SqlConnection(conn);
            //                using (con)
            //                {
            //                    con.Open();
            //                    // SqlDataReader reader = cmd.ExecuteReader();
            //                    // bool initialized above is set here
            //                    SqlDataAdapter da = new SqlDataAdapter(cmd);
            //                    DataSet ds = new DataSet();
            //                    da.Fill(ds);
            //                    con.Close();
            //                    if (ds.Tables[0].Rows.Count > 0)
            //                    {
            //                        gvDetails.DataSource = ds;
            //                        gvDetails.DataBind();



            //                    }

            //                    else
            //                    {
            //                        ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            //                        gvDetails.DataSource = ds;
            //                        gvDetails.DataBind();
            //                        int columncount = gvDetails.Rows[0].Cells.Count;
            //                        gvDetails.Rows[0].Cells.Clear();
            //                        gvDetails.Rows[0].Cells.Add(new TableCell());
            //                        gvDetails.Rows[0].Cells[0].ColumnSpan = columncount;
            //                        gvDetails.Rows[0].Cells[0].Text = "No Records Found";
            //                    }
            //                }
            //            }


            //        }
            //    }
            //    protected void gvDetails_RowDataBound(object sender, GridViewRowEventArgs e)
            //    {
            //        e.Row.Cells[0].Attributes["width"] = "20px";
            //        e.Row.Cells[1].Attributes["width"] = "50px";
            //        e.Row.Cells[2].Attributes["width"] = "450px";
            //        e.Row.Cells[3].Attributes["width"] = "600px";
            //        e.Row.Cells[4].Attributes["width"] = "600px";
            //        e.Row.Cells[5].Attributes["width"] = "5px";


            //    }
            //    protected void gvDetails_RowEditing(object sender, GridViewEditEventArgs e)
            //    {


            //        gvDetails.EditIndex = e.NewEditIndex;
            //        gvDetails.DataBind();
            //       // BindEmployeeDetails();            


            //    }
            //    protected void gvDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
            //    {
            //      //  int index = gvDetails.SelectedIndex;
            //        string qid = gvDetails.DataKeys[e.RowIndex].Values["qid"].ToString();
            //        string sid = gvDetails.DataKeys[e.RowIndex].Values["sid"].ToString(); 

            //      //  int sid = Convert.ToInt32(gvDetails.DataKeys[e.RowIndex].Value.ToString());
            //      //  int qid = Convert.ToInt32(gvDetails.DataKeys[e.RowIndex].Value.ToString());
            //        // string username = gvDetails.DataKeys[e.RowIndex].Values["UserName"].ToString();
            //        TextBox txtcity = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtDesg");
            //        TextBox txtDesignation = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtDesg3");
            //        TextBox txtDesignation2 = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtDesg2");
            //        con.Open();
            //        SqlCommand cmd = new SqlCommand("update tblSavedAnswers set evidence='" + txtcity.Text + "', comments ='" + txtDesignation.Text + "', answer ='" + txtDesignation2.Text + "' where mid =@mid and sid= @sid and qid=@qid and location=@loc", con);

            //        cmd.Parameters.Add("@sid", SqlDbType.Int).Value = sid;
            //        cmd.Parameters.Add("@qid", SqlDbType.NVarChar).Value = qid;
            //        cmd.Parameters.Add("@loc", SqlDbType.NVarChar).Value = lblLocation.Text;
            //        cmd.Parameters.AddWithValue("@mid", Session["mid"]);
            //        cmd.ExecuteNonQuery();
            //        con.Close();
            //        lblresult.Visible = true;
            //        lblresult.ForeColor = Color.Green;
            //        lblresult.Text = " Details Updated successfully";
            //        gvDetails.EditIndex = -1;
            //        gvDetails.DataBind();
            //        BindEmployeeDetails();
            //    }
            //    protected void gvDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
            //    {
            //        gvDetails.EditIndex = -1;
            //        gvDetails.DataBind();
            //        BindEmployeeDetails();
            //    }

            //    protected void gvDetails_RowDataBound1(object sender, GridViewRowEventArgs e)
            //    {
            //        e.Row.Cells[0].Attributes["width"] = "20px";
            //        e.Row.Cells[1].Attributes["width"] = "5px";
            //        e.Row.Cells[2].Attributes["width"] = "5px";
            //        e.Row.Cells[3].Attributes["width"] = "600px";
            //        e.Row.Cells[4].Attributes["width"] = "600px";
            //        e.Row.Cells[5].Attributes["width"] = "600px";
            //        e.Row.Cells[6].Attributes["width"] = "5px";

            //    }
            //}
        }

        protected void btnlogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();

            Session.Abandon();

            Response.Redirect("Login.aspx");
        }
    }
}
    
          