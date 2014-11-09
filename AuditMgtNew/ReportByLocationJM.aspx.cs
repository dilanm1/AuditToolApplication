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

namespace AuditMgtNew
{
    public partial class ReportByLocationJM : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
      
        }
       
        
        //{
        //    ReportViewer1.ProcessingMode = ProcessingMode.Local;
        //    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/ReportAuditExternel.rdlc");
        //    //AuditDBDataSet dsCustomers = GetData("SELECT Distinct tblBuilding.id, tblBuilding.locationid, tblBuilding.VerticalName, tblBuilding.Unit, tblBuilding.SubUnit, tblBuilding.Address, tblBuilding.Nature, tblBuilding.Sector,tblBuilding.Usage, tblBuilding.Number, tblBuilding.Square, tblBuilding.year, tblBuilding.Emp, tblBuilding.Visitors, tblBuilding.Guests, tblBuilding.Residents,tblBuilding.LeadAuditor, tblBuilding.Auditor1, tblBuilding.Auditor2, tblBuilding.Auditor3, tblBuilding.CEO, tblBuilding.COO, tblBuilding.DM, tblBuilding.DE,tblBuilding.Other, tblSavedAnswers.qid, tblSavedAnswers.question, tblSavedAnswers.answer, tblSavedAnswers.evidence,tblSavedAnswers.comments, oe_subjects.sname,oe_subjects.sid,tbllocation.location, oe_subjects.score FROM tblBuilding INNER JOIN tbllocation ON tblBuilding.locationid = tbllocation.locationid INNER JOIN oe_subjects ON tbllocation.locationid = oe_subjects.locationid INNER JOIN tblSavedAnswers ON oe_subjects.sid = tblSavedAnswers.sid WHERE oe_subjects.locationid=" + 1);
        //    //  AuditDBDataSet dsCustomers = new AuditDBDataSet();
        //    //AuditDBDataSet dsCustomers = GetData("SELECT Distinct tblSavedAnswers.id,tblSavedAnswers.qid,tblBuilding.locationid, tblBuilding.VerticalName, tblBuilding.Unit, tblBuilding.SubUnit, tblBuilding.Address, tblBuilding.Nature, tblBuilding.Sector,tblBuilding.Usage, tblBuilding.Number, tblBuilding.Square, tblBuilding.year, tblBuilding.Emp, tblBuilding.Visitors, tblBuilding.Guests, tblBuilding.Residents,tblBuilding.LeadAuditor, tblBuilding.Auditor1, tblBuilding.Auditor2, tblBuilding.Auditor3, tblBuilding.CEO, tblBuilding.COO, tblBuilding.DM, tblBuilding.DE,tblBuilding.Other, oe_subjects.sid, tblSavedAnswers.question, tblSavedAnswers.answer, tblSavedAnswers.evidence,tblSavedAnswers.comments, oe_subjects.sname, tbllocation.location, oe_subjects.score  FROM tblBuilding INNER JOIN tbllocation ON tblBuilding.locationid = tbllocation.locationid INNER JOIN oe_subjects ON tbllocation.locationid = oe_subjects.locationid INNER JOIN tblSavedAnswers ON oe_subjects.sid = tblSavedAnswers.sid Group by tblSavedAnswers.id,tblBuilding.id,tblBuilding.VerticalName, tblBuilding.Unit, tblBuilding.SubUnit, tblBuilding.Address, tblBuilding.Nature, tblBuilding.Sector,tblBuilding.Usage, tblBuilding.Number, tblBuilding.Square, tblBuilding.year, tblBuilding.Emp, tblBuilding.Visitors, tblBuilding.Guests, tblBuilding.Residents,tblBuilding.LeadAuditor, tblBuilding.Auditor1, tblBuilding.Auditor2, tblBuilding.Auditor3, tblBuilding.CEO, tblBuilding.COO, tblBuilding.DM, tblBuilding.DE,tblBuilding.Other, oe_subjects.sid, tblSavedAnswers.question, tblSavedAnswers.answer, tblSavedAnswers.evidence,tblSavedAnswers.comments, oe_subjects.sname, tbllocation.location, oe_subjects.score,tblBuilding.locationid,tblSavedAnswers.qid");



        //    DataSet1 dsCustomers1 = GetData1("SELECT tblSavedAnswers.*, tblBuilding.*, oe_subjects_status.*, tbllocation.* FROM  tblSavedAnswers INNER JOIN oe_subjects_status ON tblSavedAnswers.id = oe_subjects_status.id INNER JOIN  tbllocation ON oe_subjects_status.locationid = tbllocation.locationid INNER JOIN tblBuilding ON oe_subjects_status.locationid = tblBuilding.locationid");
        //    ReportDataSource datasource = new ReportDataSource("DataSet1", dsCustomers1.Tables[0]);
        //    //ReportParameter rp = new ReportParameter("ReportParameter1", Session["location"].ToString());

        //    //ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp });
        //    //  ReportDataSource datasource2 = new ReportDataSource("DataSet2", dsCustomers.Tables[0]);
        //    ReportViewer1.LocalReport.DataSources.Clear();
        //    ReportViewer1.LocalReport.DataSources.Add(datasource);
        //}
        protected void ddlCountries_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/ReportAuditor.rdlc");
            //AuditDBDataSet dsCustomers = GetData("SELECT Distinct tblBuilding.id, tblBuilding.locationid, tblBuilding.VerticalName, tblBuilding.Unit, tblBuilding.SubUnit, tblBuilding.Address, tblBuilding.Nature, tblBuilding.Sector,tblBuilding.Usage, tblBuilding.Number, tblBuilding.Square, tblBuilding.year, tblBuilding.Emp, tblBuilding.Visitors, tblBuilding.Guests, tblBuilding.Residents,tblBuilding.LeadAuditor, tblBuilding.Auditor1, tblBuilding.Auditor2, tblBuilding.Auditor3, tblBuilding.CEO, tblBuilding.COO, tblBuilding.DM, tblBuilding.DE,tblBuilding.Other, tblSavedAnswers.qid, tblSavedAnswers.question, tblSavedAnswers.answer, tblSavedAnswers.evidence,tblSavedAnswers.comments, oe_subjects.sname,oe_subjects.sid,tbllocation.location, oe_subjects.score FROM tblBuilding INNER JOIN tbllocation ON tblBuilding.locationid = tbllocation.locationid INNER JOIN oe_subjects ON tbllocation.locationid = oe_subjects.locationid INNER JOIN tblSavedAnswers ON oe_subjects.sid = tblSavedAnswers.sid WHERE oe_subjects.locationid=" + 1);
            //  AuditDBDataSet dsCustomers = new AuditDBDataSet();
            DataSet1 dsCustomers = GetData("SELECT oe_subjects_status.sid, oe_subjects_status.mid, oe_subjects_status.sname, oe_subjects_status.status, oe_subjects_status.score, oe_subjects_status.location,tbllocation.locationid FROM oe_subjects_status INNER JOIN tbllocation ON oe_subjects_status.location = tbllocation.location WHERE tbllocation.locationid =" + ddlCountries.SelectedValue);
            ReportDataSource datasource = new ReportDataSource("DataSet1", dsCustomers.Tables[0]);
            //  ReportDataSource datasource2 = new ReportDataSource("DataSet2", dsCustomers.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);
            //  ReportViewer1.LocalReport.DataSources.Add(datasource2

        }
        private DataSet1 GetData(string query)
        {

            SqlCommand cmd = new SqlCommand(query);
            using (SqlConnection con = new SqlConnection(DBUtil.ConnectionString))
            {

                using (SqlDataAdapter sda1 = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda1.SelectCommand = cmd;



                    using (DataSet1 dsCustomers = new DataSet1())
                    {
                        sda1.Fill(dsCustomers, "DataTable1");
                        con.Close();
                        return dsCustomers;
                    }
                }
            }
        }
    }
}