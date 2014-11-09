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
    public partial class ReportScoreLocationDP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //string query = ("select distinct locationid,location from tbllocation where verticalid =" + 1);
                string query = ("select distinct locationid,location from tbllocation where verticalid =" + 2);
                DataSet1 dt = GetData(query);
                ddlCountries.DataSource = dt;
                ddlCountries.DataTextField = "location";
                ddlCountries.DataValueField = "location";
                ddlCountries.DataBind();
                ddlCountries.Items.Insert(0, new ListItem("Select", ""));
            }
        }
        private DataSet1 GetData(string query)
        {

            SqlCommand cmd = new SqlCommand(query);
            using (SqlConnection con = new SqlConnection(DBUtil.ConnectionString))
            {

                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    cmd.Parameters.Add("@mid", SqlDbType.Int).Value = Session["mid"].ToString();
                    cmd.Parameters.Add("@location", SqlDbType.NVarChar).Value = ddlCountries.SelectedValue;
                    sda.SelectCommand = cmd;


                    using (DataSet1 dsCustomers = new DataSet1())
                    {
                        sda.Fill(dsCustomers, "DataTable1");
                        con.Close();
                        return dsCustomers;
                    }
                }
            }
        }

        protected void ddlCountries_SelectedIndexChanged(object sender, EventArgs e)
        {

            SqlConnection con2 = new SqlConnection(DBUtil.ConnectionString);
            con2.Open();
            SqlCommand cmd2 = new SqlCommand("select ( max(auditid)) from oe_subjects_status_saved where location=@location2 and mid =@mid2", con2);

            ////cmd2.CommandText = ("select ( max(examid))  from tblSavedAnswers where locationid=@location2 and mid =@mid2");
            cmd2.Parameters.Add("@location2", SqlDbType.NVarChar).Value = ddlCountries.SelectedValue;
            cmd2.Parameters.Add("@mid2", SqlDbType.Int).Value = Session["mid"].ToString();
            ////cmd2.Parameters.Add("@auditid", SqlDbType.Date).Value = examid;
            object obj = cmd2.ExecuteScalar();

            if (!obj.Equals(DBNull.Value))
            {



                ReportViewer1.Visible = true;
                lbl1.Visible = false;
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                //   ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report1.rdlc");
                ReportViewer1.LocalReport.ReportEmbeddedResource = "AuditMgtNew.Report1.rdlc";
                //AuditDBDataSet dsCustomers = GetData("SELECT Distinct tblBuilding.id, tblBuilding.locationid, tblBuilding.VerticalName, tblBuilding.Unit, tblBuilding.SubUnit, tblBuilding.Address, tblBuilding.Nature, tblBuilding.Sector,tblBuilding.Usage, tblBuilding.Number, tblBuilding.Square, tblBuilding.year, tblBuilding.Emp, tblBuilding.Visitors, tblBuilding.Guests, tblBuilding.Residents,tblBuilding.LeadAuditor, tblBuilding.Auditor1, tblBuilding.Auditor2, tblBuilding.Auditor3, tblBuilding.CEO, tblBuilding.COO, tblBuilding.DM, tblBuilding.DE,tblBuilding.Other, tblSavedAnswers.qid, tblSavedAnswers.question, tblSavedAnswers.answer, tblSavedAnswers.evidence,tblSavedAnswers.comments, oe_subjects.sname,oe_subjects.sid,tbllocation.location, oe_subjects.score FROM tblBuilding INNER JOIN tbllocation ON tblBuilding.locationid = tbllocation.locationid INNER JOIN oe_subjects ON tbllocation.locationid = oe_subjects.locationid INNER JOIN tblSavedAnswers ON oe_subjects.sid = tblSavedAnswers.sid WHERE oe_subjects.locationid=" + 1);
                //  AuditDBDataSet dsCustomers = new AuditDBDataSet();
                DataSet1 dsCustomers = GetData("SELECT oe_subjects_status_saved.sid, oe_subjects_status_saved.mid, oe_subjects.sname, oe_subjects_status_saved.status, oe_subjects_status_saved.score, oe_subjects_status_saved.location, oe_subjects.sname FROM  oe_subjects INNER JOIN oe_subjects_status_saved ON oe_subjects.sid = oe_subjects_status_saved.sid WHERE oe_subjects_status_saved.mid=@mid and oe_subjects_status_saved.location=@location and oe_subjects_status_saved.auditid ='" + obj + "'");
                ReportDataSource datasource = new ReportDataSource("DataSet1", dsCustomers.Tables[0]);
                //  ReportDataSource datasource2 = new ReportDataSource("DataSet2", dsCustomers.Tables[0]);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(datasource);
                //  ReportViewer1.LocalReport.DataSources.Add(datasource2);
            }
            else
            {

                lbl1.Text = "You Have No Complete Audit Report to Analyze in This Location!";
                lbl1



                    .ForeColor = System.Drawing.Color.Red;
                lbl1.Visible = true;
                ReportViewer1.Visible = false;
            }
        }

        protected void btnlogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();

            Session.Abandon();

            Response.Redirect("Login.aspx");
        }



    }
}

