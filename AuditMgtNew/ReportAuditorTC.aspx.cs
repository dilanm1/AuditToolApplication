using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.Reporting.WebForms;
using System.Web.Security;


namespace AuditMgtNew
{
    public partial class ReportAuditorTC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BindBusinessNames();

                //  @Parameter_Name varchar(1000) = ;
                //  Label1.Text = Session["location"].ToString();


            }

        }
        private Customers GetData(string query)
        {



            SqlCommand cmd = new SqlCommand(query);
            using (SqlConnection con = new SqlConnection(DBUtil.ConnectionString))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    cmd.Parameters.Add("@mid", SqlDbType.Int).Value = Session["mid"].ToString();
                    cmd.Parameters.Add("@location", SqlDbType.NVarChar).Value = DropDownList1.SelectedValue;
                    // cmd.Parameters.Add("@auditid", SqlDbType.Date).Value = examid;
                    sda.SelectCommand = cmd;
                    using (Customers dsCustomers = new Customers())
                    {
                        sda.Fill(dsCustomers, "DataTable1");
                        return dsCustomers;
                    }
                }
            }
        }
        protected void BindBusinessNames()
        {
            try
            {

                SqlConnection con = new SqlConnection(DBUtil.ConnectionString);
                con.Open();
                //SqlCommand cmd = new SqlCommand("select * from tbllocation WHERE VerticalID= " + 1, con);
                //SqlDataAdapter da = new SqlDataAdapter(cmd);
                SqlCommand cmd = new SqlCommand("select * from tbllocation WHERE VerticalID = " + 3, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                con.Close();
                DropDownList1.DataSource = ds;
                DropDownList1.DataTextField = "location";
                //   DropDownList1.DataValueField = "SubVerticalID";
                DropDownList1.DataValueField = "locationid";
                DropDownList1.DataBind();
                //  DropDownList1.Items.Insert(0, "");
                //   DropDownList1.Items.Insert(0, new ListItem("--Select--", "0"));
                //   DropDownList2.Items.Insert(0, new ListItem("--Select--", "0"));


                //cmd.CommandText = ("select locationid from tbllocation where location ='" + exam.location + "'");
                //int locationid = (Int32)cmd.ExecuteScalar();



            }
            catch (Exception ex)
            {
                // Handle the error
            }
            DropDownList1.Items.Insert(0, new ListItem("Select Location", "0"));

        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

            //string mid = Session["mid"].ToString();

            SqlConnection con2 = new SqlConnection(DBUtil.ConnectionString);
            con2.Open();
            SqlCommand cmd2 = new SqlCommand("select ( max(examid))  from tblSavedAnswers where locationid=@location2 and mid =@mid2", con2);

            ////cmd2.CommandText = ("select ( max(examid))  from tblSavedAnswers where locationid=@location2 and mid =@mid2");
            cmd2.Parameters.Add("@location2", SqlDbType.Int).Value = DropDownList1.SelectedValue;
            cmd2.Parameters.Add("@mid2", SqlDbType.Int).Value = Session["mid"].ToString();
            ////cmd2.Parameters.Add("@auditid", SqlDbType.Date).Value = examid;
            //int examid = (Int32)cmd2.ExecuteScalar();
            object obj = cmd2.ExecuteScalar();

            if (!obj.Equals(DBNull.Value))
            {
                //cmd2.ExecuteNonQuery();
                //int examid = cmd2.Parameters["@id"].SqlDbType(Int32);
                ReportViewer1.Visible = true;

                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportEmbeddedResource = "AuditMgtNew.ReportAuditReport.rdlc";
                //Customers dsCustomers = GetData("select * from View_Answers_Building_2  where mid=@mid and locid=@location and auditid='" + 2 + "'");
                Customers dsCustomers = GetData("select * from View_Answers_Building_2  where mid=@mid and locid=@location and auditid='" + obj + "' Order By sid ASC");
                ReportDataSource datasource = new ReportDataSource("Customers", dsCustomers.Tables[0]);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(datasource);




            }
            else
            {

                Label2b.Text = "You Have No Complete Audit Report to View in This Location!";
                Label2b.ForeColor = System.Drawing.Color.Red;
                Label2b.Visible = true;
                ReportViewer1.Visible = false;



            }


        }
        //protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //    string mid = Session["mid"].ToString();



        //    ReportViewer1.ProcessingMode = ProcessingMode.Local;
        //    ReportViewer1.LocalReport.ReportEmbeddedResource = "AuditMgtNew.ReportAuditReport.rdlc";
        //    Customers dsCustomers = GetData("select * from View_Answers_Building_2  where mid=@mid and Expr1=@location");


        //    ReportDataSource datasource = new ReportDataSource("Customers", dsCustomers.Tables[0]);
        //    ReportViewer1.LocalReport.DataSources.Clear();
        //    ReportViewer1.LocalReport.DataSources.Add(datasource);

        //}

        protected void btnlogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();

            Session.Abandon();

            Response.Redirect("Login.aspx");
        }


    }
}




