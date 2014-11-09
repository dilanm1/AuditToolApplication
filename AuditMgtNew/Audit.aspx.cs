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
    public partial class Audit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (this.Page.PreviousPage != null)
            {
                String sid, sname, location;

                int rowIndex = int.Parse(Request.QueryString["RowIndex"]);
                GridView GridView1 = (GridView)this.Page.PreviousPage.FindControl("GridView1");
                GridViewRow row = GridView1.Rows[rowIndex];
                sid = row.Cells[0].Text;
                sname = (row.FindControl("lblName") as Label).Text;
               // sname = row.Cells[1].Text;
                location = TextBox2.Text;



                //sid = ddlSubjects.SelectedItem.Value;
                //sname = ddlSubjects.SelectedItem.Text;
                Examination exam = new Examination(Int32.Parse(Session["mid"].ToString()), Int32.Parse(sid), sname,location);
                exam.GetQuestions();
                Session.Add("questions", exam);
                // Response.Redirect("Audit.aspx");







                //LinkButton2.Attributes.Add("onClick", "return false;");
                if (!Page.IsPostBack)
                    DisplayQuestion();

                Label1.Text = lblQuestionId.Text;
            }

        }
        public void DisplayQuestion()
        {
            // get data from session object
            Examination e = (Examination)Session["questions"];
            // display data
            lblSubject.Text = e.sname;
            lblQno.Text = e.curpos + 1 + "/" + e.SIZE;
            lblCtime.Text = DateTime.Now.ToString();
            lblStime.Text = e.StartTime.ToString();
            
           
            Question q = e.questions[e.curpos];
            // display details of question
            //question.InnerHtml = q.question;
            TextBox1.Text = q.question;
            lblQuestionId.Text = q.qid;
            TextBox4.Text = q.guid;
           
            TextBox5.Text = q.refe;
            TextBox5.Text.Replace("\n", "<br /> <br />");
            //TextBox4.Text = q.qid.ToString();
            //ans1.InnerHtml = q.ans1;
            //ans2.InnerHtml = q.ans2;
            //ans3.InnerHtml = q.ans3;
            //ans4.InnerHtml = q.ans4;

            // reset all radio buttons
            rbAns1.Checked = false;
            rbAns2.Checked = false;
            rbAns3.Checked = false;
            rbAns4.Checked = false;
            rbAns5.Checked = false;
            rbAns6.Checked = false;
            rbAns7.Checked = false;
            rbAns8.Checked = false;
            rbAns9.Checked = false;
            rbAns10.Checked = false;
            rbAns11.Checked = false;
            

            // disable and enable buttons
            if (e.curpos == 0)
                btnPrev.Enabled = false;
            else
                btnPrev.Enabled = true;

            if (e.curpos == e.SIZE - 1)
                btnNext.Text = "Finish";
            else
                btnNext.Text = "Next";

        

            SqlConnection con3 = new SqlConnection(DBUtil.ConnectionString);
            con3.Open();
            SqlDataAdapter myDataAdapter;
            DataSet ds;

            myDataAdapter = new SqlDataAdapter("SELECT guid FROM tblQuestionsJMSub  WHERE qid = '" + q.qid + "' ", con3);
           
            //DetailsID = '" + lstBoxCategory.SelectedValue.ToString() + "' ", connection);
            //string queryString = ("SELECT guid FROM oe_questions where qid = '" + q.qid.ToString() +"' ");
            //SqlDataAdapter adapter = new SqlDataAdapter(queryString, con3);

            ds = new DataSet();           
            myDataAdapter.Fill(ds, "oe_questions");
           
            con3.Close();

            //GridView1.DataSource = ds.Tables[0];
            //GridView1.DataBind();


            SqlConnection con = new SqlConnection(DBUtil.ConnectionString);
            con.Open();
            SqlDataAdapter myDataAdapter1;
            DataSet ds1;

            //myDataAdapter1 = new SqlDataAdapter("SELECT guid FROM oe_questions  WHERE qid = '" + q.qid.ToString() + "' ", con3);
            myDataAdapter1 = new SqlDataAdapter("SELECT ref FROM tblQuestionsJMSub WHERE qid = '" + q.qid + "' ", con);

            //DetailsID = '" + lstBoxCategory.SelectedValue.ToString() + "' ", connection);
            //string queryString = ("SELECT guid FROM oe_questions where qid = '" + q.qid.ToString() +"' ");
            //SqlDataAdapter adapter = new SqlDataAdapter(queryString, con3);

            ds1 = new DataSet();
            myDataAdapter1.Fill(ds1, "oe_questions1");

            con.Close();

            //GridView2.DataSource = ds1.Tables[0];
            //GridView2.DataBind();

           
          
        }

        public void ProcessQuestion()
        {
            Examination exam = (Examination)Session["questions"];
            Question q = exam.questions[exam.curpos];
           
            int answer;
          
            // find out the answer and assign it to 
            //if (rbAns1.Checked)
            //    answer = "1";
            //else
            //    if (rbAns2.Checked)
            //        answer = "2";
            //    else
            //        if (rbAns3.Checked)
            //            answer = "3";
            //        else
            //            if (rbAns4.Checked)
            //                answer = "4";
            //            else
            //                answer = "0";  // error
            if (rbAns1.Checked)
                answer = 0;
            else
                if (rbAns2.Checked)
                    answer = 1;
                else
                    if (rbAns3.Checked)
                        answer = 2;
                    else
                        if (rbAns4.Checked)
                            answer = 3;
                        else
                            answer = 4;  // error
            q.question = TextBox1.Text;
            q.answer = answer;
            exam.questions[exam.curpos] = q;
            Session.Add("questions", exam);
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            ProcessQuestion();
           
            Examination exam = (Examination)Session["questions"];
            Question q = exam.questions[exam.curpos];
            if (exam.curpos == exam.SIZE - 1)
                Response.Redirect("showresult.aspx");
            else
            {
                SqlConnection con = new SqlConnection(DBUtil.ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("select isnull( max(examid),0) + 1 from oe_exams", con);
                int examid = (Int32)cmd.ExecuteScalar();
                cmd.CommandText = "insert into tblSavedAnswers values(@mid,@examid,@sid,@qid,@question,@answer)";
                cmd.Parameters.Add("@examid", SqlDbType.Int).Value = examid;               
                cmd.Parameters.Add("@mid", SqlDbType.Int).Value = exam.mid;
                cmd.Parameters.Add("@sid", SqlDbType.Int).Value = exam.sid;
                cmd.Parameters.Add("@qid", SqlDbType.NVarChar).Value = q.qid;
                cmd.Parameters.Add("@question", SqlDbType.NVarChar).Value = q.question;
                cmd.Parameters.Add("@answer", SqlDbType.NVarChar).Value = q.answer;
                //cmd.Parameters.Add("@noq", SqlDbType.Int).Value = exam.SIZE;
                //cmd.Parameters.Add("@ncans", SqlDbType.Int).Value = exam.ncans;
                //cmd.Parameters.Add("@stdate", SqlDbType.DateTime).Value = exam.StartTime;
                cmd.ExecuteNonQuery();

                exam.curpos++;
                Session.Add("questions", exam);
                DisplayQuestion();
            }
        }

        protected void btnPrev_Click(object sender, EventArgs e)
        {
            // ProcessQuestion();
            Examination exam = (Examination)Session["questions"];
            exam.curpos--;
            Session.Add("questions", exam);
            DisplayQuestion();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            // Examination exam = (Examination)Session["questions"];
            Session.Remove("questions");
            //exam = null;
            Response.Redirect("default.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            Examination exam = (Examination)Session["questions"];
            lblSubject.Text = exam.sname;
            lblStime.Text = exam.StartTime.ToString();
            TimeSpan ts = DateTime.Now.Subtract(exam.StartTime);
            //lblMin.Text = ts.Minutes.ToString();
            //lblNquestions.Text = exam.SIZE.ToString();

            //// find how many correct answers
            //int cnt = 0;

            ////double per;
            //foreach (Question q in exam.questions)
            //{
            //    //if (q.IsCorrect())
                //    cnt++;
                //cnt = cnt + q.answer;

                SqlConnection con = new SqlConnection(DBUtil.ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("select isnull( max(examid),0) from oe_exams", con);
                int examid = (Int32)cmd.ExecuteScalar();
                cmd.CommandText = "insert into tblStatus(examid,status,datesaved) values(@examid,@status,@datesaved)";
                cmd.Parameters.Add("@examid", SqlDbType.Int).Value = examid;
                cmd.Parameters.Add("@status", SqlDbType.NVarChar).Value = "Half Complete";
                //cmd.Parameters.Add("@mid", SqlDbType.Int).Value = exam.mid;
                //cmd.Parameters.Add("@sid", SqlDbType.Int).Value = exam.sid;
                //cmd.Parameters.Add("@noq", SqlDbType.Int).Value = exam.SIZE;
                //cmd.Parameters.Add("@ncans", SqlDbType.Int).Value = exam.ncans;
                cmd.Parameters.Add("@datesaved", SqlDbType.DateTime).Value = exam.StartTime;
                cmd.ExecuteNonQuery();


            }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        protected void can_Click(object sender, EventArgs e)
        {

        }

       

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //GridViewRow row = e.Row;
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    row.Cells[0].Text = row.Cells[0].Text.Replace("\n", "<br /> <br />");
                
            //    //row.Cells[1].Text = row.Cells[1].Text.Replace("\n", "<br /> <br />");
            //}
            //if (LinkButton1 != null)
            //{

            //    //e.Row.Cells[1].Visible = false;

            //}
            //if (LinkButton2 != null)
            //{

            //    //e.Row.Cells[0].Visible = false;

            //}
        }

       
        protected void LinkButton1_Click(object sender, EventArgs e)
        {

            //LinkButton LinkButton1 = sender as LinkButton;
            //GridViewRow GridView1 = (GridViewRow)LinkButton1.NamingContainer;
            //lblID.Text = gvrow.Cells[0].Text;
            //txtname.Text = gvrow.Cells[1].Text;
            //txtpoints.Text = gvrow.Cells[2].Text;
           
           
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
           
            //ModalPopupExtender1.Show();
            //MPE.Hide();
            
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //MPE.Show();
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //GridViewRow row = e.Row;
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    row.Cells[0].Text = row.Cells[0].Text.Replace("\n", "<br /> <br />");
            //    //row.Cells[1].Text = row.Cells[1].Text.Replace("\n", "<br /> <br />");
            //}

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ClientButton_Click(object sender, EventArgs e)
        {
            TextBox4.Text.Replace("\n", "<br /> <br />");

        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            TextBox5.Text.Replace("\n", "<br /> <br />");
        }

        protected void TextBox4_TextChanged(object sender, EventArgs e)
        {
            TextBox4.Text.Replace("\n", "<br /> <br />");
        }

        protected void TextBox5_TextChanged(object sender, EventArgs e)
        {
            TextBox5.Text.Replace("\n", "<br /> <br />");
        }

       

      

      
            //per = (((double)cnt / 500) * 100);
            //Label1.Text = per.ToString() + "%";
            //lblNcans.Text = cnt.ToString();
            //exam.ncans = cnt;
            //Session.Add("questions", exam);

            //if (cnt > 3)
            //    lblGrade.Text = "Excellent";
            //else
            //    if (cnt > 1)
            //        lblGrade.Text = "Average";
            //    else
            //        lblGrade.Text = "Poor";
            // add row to OE_EXAMS table
           

      
        }

      

       
    }

