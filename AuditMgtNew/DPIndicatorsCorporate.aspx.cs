using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using AuditMgtNew.Old_App_Code;
using System.Web.Security;

namespace AuditMgtNew
{
    public partial class DPIndicatorsCorporate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Remove("location");

            SqlConnection conn = new SqlConnection(DBUtil.ConnectionString);
            DataTable dt = new DataTable();
            try
            {
                conn.Open();


                String sql = "SELECT location FROM tblBuilding WHERE location = @location";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@location", "Dubai Property Group Corporate");
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);


                if (dt.Rows.Count > 0)
                {
                    lblLocation.Text = "Dubai Property Group Corporate";


                    if (!IsPostBack)
                    {
                        BindEmployeeDetails();

                        lblLocation.Text = "Dubai Property Group Corporate";

                        Session["location"] = "Dubai Property Group Corporate";



                    }
                    // Label52.Visible = true;
                    //CALL the UPDATE method here and pass its parameter values
                    //UpdateInfo("Value1",location);
                }
                else
                {

                    lblLocation.Text = "Please Add Location Details To Start An Audit!!";
                    lblLocation.ForeColor = System.Drawing.Color.Red;
                    GridView1.Enabled = false;

                }
            }
            catch (SqlException ex)
            {


            }

            finally
            {
                conn.Close();

            }
        }
        protected void BindEmployeeDetails()
        {
            //if ((string)Session["location"] != null)
            //{

            //  Session["location"] = lblLocation.Text;

            //}
            //else
            //    lblLocation.Text = (string)Session["location2"];
            //  lblLoc.Text = (string)Session["sublocation"];

            ExaminationDP exam = (ExaminationDP)Session["questionsd"];
            //  string name = lblLocation.Text.ToString();
            string name = lblLocation.Text;
            SqlConnection con = new SqlConnection(DBUtil.ConnectionString);
            //string color_na = textBox3.Text;
            // string commandQuery = "select oe_subjects.sid, oe_subjects.sname, oe_subjects.status, oe_subjects.score FROM oe_subjects INNER JOIN tbllocation ON oe_subjects.locationid = tbllocation.locationid where tbllocation.location=@loc and tbllocation.mid=@mid";
            string commandQuery = ("SELECT oe_subjects.sid, oe_subjects.sname, oe_subjects_status.mid, oe_subjects_status.location, oe_subjects_status.status, oe_subjects_status.score FROM oe_subjects left outer JOIN oe_subjects_status ON oe_subjects.sid = oe_subjects_status.sid and oe_subjects_status.location ='" + lblLocation.Text + "' and oe_subjects_status.mid =@mid");
            using (SqlCommand cmd = new SqlCommand(commandQuery, con))
            {
                //  cmd.Parameters.AddWithValue("@loc",name);
                cmd.Parameters.AddWithValue("@mid", Session["mid"]);
                //cmd.Parameters.AddWithValue("@model", Area);


                //  SqlConnection con2 = new SqlConnection(conn);
                using (con)
                {
                    con.Open();
                    // SqlDataReader reader = cmd.ExecuteReader();
                    // bool initialized above is set here
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    con.Close();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        GridView1.DataSource = ds;
                        GridView1.DataBind();



                    }
                    else
                    {
                        //ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                        //GridView1.DataSource = ds;
                        //GridView1.DataBind();
                        //int columncount = GridView1.Rows[0].Cells.Count;
                        //GridView1.Rows[0].Cells.Clear();
                        //GridView1.Rows[0].Cells.Add(new TableCell());
                        //GridView1.Rows[0].Cells[0].ColumnSpan = columncount;
                        //GridView1.Rows[0].Cells[0].Text = "No Records Found";
                    }
                }
            }
        }
        private static DataTable GetSampleData()
        {
            //DataTable dt = new DataTable();
            //dt.Columns.AddRange(new DataColumn[3] { new DataColumn("sid"), new DataColumn("sname"), new DataColumn("Country") });
            //dt.Rows.Add(1, "Risk Assessment and Management", "Berlin");
            //dt.Rows.Add(2, "México D.F.", "Mexico");
            //dt.Rows.Add(3, "México D.F.", "Mexico");
            //dt.Rows.Add(4, "London", "UK");
            //dt.Rows.Add("Christina Berglund", "Luleå", "Sweden");
            //dt.Rows.Add("Hanna Moos", "Mannheim", "Germany");
            //dt.Rows.Add("Frédérique Citeaux", "Strasbourg", "France");
            //dt.Rows.Add("Martín Sommer", "Madrid", "Spain");
            //dt.Rows.Add("Laurence Lebihan", "Marseille", "France");
            //dt.Rows.Add("Elizabeth Lincoln", "Tsawassen", "Canada");
            //dt.Rows.Add("Victoria Ashworth", "London", "UK");
            //dt.Rows.Add("Patricio Simpson", "Buenos Aires", "Argentina");
            //dt.Rows.Add("Francisco Chang", "México D.F.", "Mexico");
            //dt.Rows.Add("Yang Wang", "Bern", "Switzerland");
            //dt.Rows.Add("Pedro Afonso", "Sao Paulo", "Brazil");

            //return dt;

            SqlConnection con = new SqlConnection(DBUtil.ConnectionString);
            DataTable listRecords = new DataTable();
            // string sorgu = ("select * from oe_subjects where IndicatorID = " + id);
            string sorgu = ("select * from oe_subjects_corporate");
            SqlCommand cmd = new SqlCommand(sorgu, con);
            con.Open();
            listRecords.Load(cmd.ExecuteReader());


            //GridView1.DataSource = ds.Tables[0];
            //GridView1.DataBind();
            return listRecords;



        }
        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //GridView2.PageIndex = e.NewPageIndex;
            //GridView2.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        string value;
        double total = 0;
        protected void GridView1_RowDataBound1(object sender, GridViewRowEventArgs e)
        {


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (DataBinder.Eval(e.Row.DataItem, "score") != DBNull.Value)
                {
                    total += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "score"));
                }


            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblamount = (Label)e.Row.FindControl("lblTotal");
                lblamount.Text = total.ToString();
                value = lblamount.Text.ToString();

            }

            Session["sid"] = e.Row.Cells[0].Text;
            Session["sname"] = e.Row.Cells[1].Text;


            e.Row.Cells[4].Visible = false;
            e.Row.Cells[0].Attributes["width"] = "20px";


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[4].Text.ToString() == "complete")
                {
                    // e.Row.Cells[0].Visible = false;   //0 is autogenerate edit column index
                    //  e.Row.Cells[1].Visible = false;  // 1  is autogenerate delete column index
                    btnConfirm.Visible = true;
                }
                else
                    btnConfirm.Visible = false;


            }

            if (e.Row.DataItemIndex == 0 && e.Row.Cells[4].Text.ToString() == DBNull.Value.ToString())
            {
                e.Row.Cells[3].Enabled = true;




                // return;  
            }

            if (e.Row.DataItemIndex == 0 && e.Row.Cells[4].Text.ToString() == "Incomplete")
            {
                e.Row.Cells[3].Enabled = false;
                e.Row.Cells[3].Text = "Incomplete";
                // return;  
            }
            if (e.Row.DataItemIndex == 0 && e.Row.Cells[4].Text.ToString() == "complete")
            {
                e.Row.Cells[3].Enabled = false;
                e.Row.Cells[3].Text = "complete";
                // return;  
            }
            if (e.Row.DataItemIndex > 0)
            {
                var thisRow = e.Row;
                var prevRow = GridView1.Rows[e.Row.DataItemIndex - 1];
                if (prevRow.Cells[4].Text.ToString() == DBNull.Value.ToString())
                {
                    thisRow.Cells[3].Enabled = false;

                }
                if (prevRow.Cells[4].Text.ToString() == "Incomplete")
                {
                    thisRow.Cells[3].Enabled = false;

                }
                else
                    if (prevRow.Cells[4].Text.ToString() == "complete")
                    {
                        thisRow.Cells[3].Enabled = true;

                    }

                if (thisRow.Cells[4].Text.ToString() == "complete")
                {
                    thisRow.Cells[3].Enabled = true;
                    thisRow.Cells[3].Text = "complete";
                    //   thisRow.Cells[5].Visible = true;
                }
                if (thisRow.Cells[4].Text.ToString() == "Incomplete")
                {
                    thisRow.Cells[3].Enabled = true;
                    thisRow.Cells[3].Text = "Incomplete";
                    thisRow.Cells[5].Visible = true;
                    thisRow.Cells[5].Enabled = true;
                }
                else
                    if (thisRow.Cells[4].Text.ToString() == "Start Audit")
                    {
                        thisRow.Cells[5].Visible = false;

                    }



            }



            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.Cells[3].Text.ToString() == "complete")
                {
                    LinkButton btn = (LinkButton)row.FindControl("Button1");
                    //row.Cells[5].Enabled = true;
                    //row.Cells[5].Visible = true;
                    //row.Cells[5].ForeColor = System.Drawing.Color.Red;
                    btn.ForeColor = System.Drawing.Color.YellowGreen;
                    //   row.Cells[3].Text = "Edit";
                    btn.Enabled = true;
                    LinkButton btn2 = (LinkButton)row.FindControl("btnreport");
                    //row.Cells[5].Enabled = true;
                    //row.Cells[5].Visible = true;
                    //row.Cells[5].ForeColor = System.Drawing.Color.Red;
                    btn2.ForeColor = System.Drawing.Color.Green;
                    //   row.Cells[3].Text = "Edit";
                    btn2.Visible = true;
                    btn2.Enabled = true;

                }
                else

                    if (row.Cells[3].Text.ToString() == "Incomplete")
                    {
                        LinkButton btn = (LinkButton)row.FindControl("Button2");
                        //row.Cells[5].Visible = true;
                        //row.Cells[5].Text = "Resume";
                        btn.Visible = true;
                        btn.Text = "Resume";
                        btn.ForeColor = System.Drawing.Color.Red;
                        btn.Enabled = true;
                        //row.Cells[5].Enabled = true;
                        //row.Cells[5].ForeColor = System.Drawing.Color.Red;
                        //   row.Cells[3].Text = "Edit";

                    }

                    else
                    {
                        // row.Cells[5].Enabled = false;
                        //   row.Cells[5].Enabled = false;
                        //  row.Cells[5].ForeColor = System.Drawing.Color.Black;
                        //   row.Cells[3].Text = "Edit";
                        LinkButton btn = (LinkButton)row.FindControl("Button1");
                        //row.Cells[5].Visible = true;
                        //row.Cells[5].Text = "Resume";
                        btn.Text = "Edit";
                        btn.Enabled = false;

                    }

            }
            //var thisRow = e.Row;   
            //var prevRow = GridView1.Rows[e.Row.DataItemIndex-1];
            //prevRow.Cells[3].Enabled = false;

            //e.Row.Cells[4]. = (thisRow.Cells[1].Text == prevRow.Cells[1].Text) ? Color.Green : Color.Red;  
        }





        public void OnConfirm(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {

                string name = (GridView1.FooterRow.FindControl("lblTotal") as Label).Text;


                SqlConnection con2 = new SqlConnection(DBUtil.ConnectionString);
                con2.Open();
                SqlCommand cmd2 = new SqlCommand("select isnull( max(auditid),0) + 1 from oe_Audits_Location", con2);
                int auditid = (Int32)cmd2.ExecuteScalar();
                cmd2.CommandText = "insert into oe_Audits_Location values(@examid,@mid,@location,@score,@status,@enddate)";
                cmd2.Parameters.Add("@examid", SqlDbType.Int).Value = auditid;
                cmd2.Parameters.Add("@mid", SqlDbType.Int).Value = Session["mid"];
                //    cmd2.Parameters.Add("@sid", SqlDbType.Int).Value = Session["sid"];
                cmd2.Parameters.Add("@location", SqlDbType.NVarChar).Value = lblLocation.Text;
                cmd2.Parameters.Add("@score", SqlDbType.NVarChar).Value = name;
                cmd2.Parameters.Add("@status", SqlDbType.NVarChar).Value = "complete";
                //cmd.Parameters.Add("@noq", SqlDbType.Int).Value = exam.SIZE;
                //cmd.Parameters.Add("@ncans", SqlDbType.Int).Value = exam.ncans;
                //  cmd2.Parameters.Add("@stdate", SqlDbType.DateTime).Value = exam.StartTime;
                cmd2.Parameters.Add("@enddate", SqlDbType.DateTime).Value = DateTime.Today.ToString();

                cmd2.ExecuteNonQuery();


                SqlConnection cone = new SqlConnection(DBUtil.ConnectionString);
                cone.Open();
                SqlCommand cmde = new SqlCommand("select isnull( max(examid),0)+1 from oe_exams", cone);
                int examid2 = (Int32)cmde.ExecuteScalar();
                //cmde.CommandText = ("select locationid from tbllocation where location ='" + exam.location + "'");
                int locationid2 = (Int32)cmde.ExecuteScalar();
                cmde.CommandText = ("insert into oe_exams(examid,mid,locationid,location,enddate) values(@examid,@mid,@locationid,@location,@date)");
                cmde.Parameters.Add("@examid", SqlDbType.Int).Value = examid2;
                cmde.Parameters.Add("@mid", SqlDbType.Int).Value = Session["mid"];
                //cmde.Parameters.Add("@sid", SqlDbType.Int).Value = exam.sid;
                cmde.Parameters.Add("@locationid", SqlDbType.Int).Value = 14;
                cmde.Parameters.Add("@location", SqlDbType.NVarChar).Value = lblLocation.Text; ;
                //cmde.Parameters.Add("@date", SqlDbType.DateTime).Value = DateTime.Today.ToString("dd/MM/yyyy");
                cmde.Parameters.Add("@date", SqlDbType.DateTime).Value = DateTime.Today.ToString();
                //cmd.Parameters.Add("@noq", SqlDbType.Int).Value = exam.SIZE;
                //cmd.Parameters.Add("@ncans", SqlDbType.Int).Value = exam.ncans;

                cmde.ExecuteNonQuery();


                SqlConnection coneu = new SqlConnection(DBUtil.ConnectionString);
                coneu.Open();
                SqlCommand cmdeu = new SqlCommand("select isnull( max(examid),0)+1 from oe_exams", coneu);
                // int examid2 = (Int32)cmde.ExecuteScalar();
                //cmde.CommandText = ("select locationid from tbllocation where location ='" + exam.location + "'");
                // int locationid2 = (Int32)cmde.ExecuteScalar();
                cmdeu.CommandText = ("update tblSavedAnswers Set examid=@examid where mid=@mid and locationid=@locationid and examid IS NULL");
                cmdeu.Parameters.Add("@examid", SqlDbType.Int).Value = examid2;
                cmdeu.Parameters.Add("@mid", SqlDbType.Int).Value = Session["mid"];
                //cmde.Parameters.Add("@sid", SqlDbType.Int).Value = exam.sid;
                cmdeu.Parameters.Add("@locationid", SqlDbType.Int).Value = 14;
                // cmde.Parameters.Add("@location", SqlDbType.NVarChar).Value = lblLocation.Text; ;
                //  cmde.Parameters.Add("@date", SqlDbType.DateTime).Value = DateTime.Today.ToString("dd/MM/yyyy");

                //cmd.Parameters.Add("@noq", SqlDbType.Int).Value = exam.SIZE;
                //cmd.Parameters.Add("@ncans", SqlDbType.Int).Value = exam.ncans;

                cmdeu.ExecuteNonQuery();


                SqlConnection constatus = new SqlConnection(DBUtil.ConnectionString);
                constatus.Open();
                SqlCommand cmdstatus = new SqlCommand("select isnull( max(examid),0)+1 from oe_subjects_status_saved", constatus);
                //  int examid3 = (Int32)cmde.ExecuteScalar();
                //cmde.CommandText = ("select locationid from tbllocation where location ='" + exam.location + "'");
                // int locationid2 = (Int32)cmde.ExecuteScalar();
                cmdstatus.CommandText = ("update  oe_subjects_status_saved Set auditid=@examid where mid=@mid and locationid=@locationid and auditid IS NULL");
                cmdstatus.Parameters.Add("@examid", SqlDbType.Int).Value = examid2;
                cmdstatus.Parameters.Add("@mid", SqlDbType.Int).Value = Session["mid"];
                //cmde.Parameters.Add("@sid", SqlDbType.Int).Value = exam.sid;
                cmdstatus.Parameters.Add("@locationid", SqlDbType.Int).Value = 14;

                cmdstatus.ExecuteNonQuery();




                SqlConnection con4 = new SqlConnection(DBUtil.ConnectionString);
                con4.Open();
                SqlCommand cmd4 = new SqlCommand("Delete from oe_subjects_status Where mid=@mid and location =@location", con4);

                cmd4.Parameters.Add("@mid", SqlDbType.Int).Value = Session["mid"];
                //    cmd2.Parameters.Add("@sid", SqlDbType.Int).Value = Session["sid"];
                cmd4.Parameters.Add("@location", SqlDbType.NVarChar).Value = lblLocation.Text;


                cmd4.ExecuteNonQuery();
           

                Response.Redirect("DPIndicatorsCorporate.aspx");




        }
            else
            {
                Response.Redirect("DPIndicatorsCorporate.aspx");
            }


        }

        protected void btnlogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();

            Session.Abandon();

            Response.Redirect("Login.aspx");
        }


        //e.Row.Cells[0].Text = "<a href=''>" + e.Row.Cells[0].Text + "</a>";

        //String sname, sid;


        /////  sid = e.Row.Cells[0].ToString();
        //sname = e.Row.Cells[1].Text;
        //Examination exam = new Examination(Int32.Parse(Session["mid"].ToString()), 1, sname);
        //exam.GetQuestions();
        //Session.Add("questions", exam);
        //Response.Redirect("Audit.aspx");

    }




}



