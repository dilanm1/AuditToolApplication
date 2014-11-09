using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Web.Security;

namespace AuditMgtNew
{
    public partial class AuditHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBusinessdropdown();
                BindBusinessNames();
                //LabelAdd.Text = DropDownList1.SelectedItem.Text;




            }
        }
        protected void BindBusinessdropdown()
        {
            //conenction path for database
            SqlConnection con = new SqlConnection(DBUtil.ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT distinct tbllocation.location, oe_subjects.status, oe_subjects.locationid, tbllocation.status AS Expr1 FROM oe_subjects INNER JOIN tbllocation ON oe_subjects.locationid = tbllocation.locationid where oe_subjects.status  = '" + "complete" + "' ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            DropDownList1.DataSource = ds;
            DropDownList1.DataTextField = "location";
            DropDownList1.DataValueField = "locationid";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, "");
            // DropDownList8.Items.Insert(0, new ListItem("--Select--", "0"));
            //  DropDownList1312.Items.Insert(0, new ListItem("--Select--", "0"));
            // ddlRegion.Items.Insert(0, new ListItem("--Select--", "0"));

        }
        protected void BindBusinessNames()
        {

            SqlConnection con = new SqlConnection(DBUtil.ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tbllocation where status = '" + "Incomplete" + "' ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            DropDownList2.DataSource = ds;
            DropDownList2.DataTextField = "location";
            //   DropDownList1.DataValueField = "SubVerticalID";
            DropDownList2.DataValueField = "locationid";
            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, "");
            //   DropDownList1.Items.Insert(0, new ListItem("--Select--", "0"));
            //   DropDownList2.Items.Insert(0, new ListItem("--Select--", "0"));



        }
        protected void ImageButton1_Click(object sender, EventArgs e)
        {



        }
    }
}


        
  