using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Data.SqlClient;
using System.Data;
using System.Web.Security;




namespace AuditMgtNew
{
    public partial class Audit1 : System.Web.UI.Page
    {
        public static int i;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (this.Page.PreviousPage != null)
            {
                String sid, sname, location, stddate;

                int rowIndex = int.Parse(Request.QueryString["RowIndex"]);
                GridView GridView1 = (GridView)this.Page.PreviousPage.FindControl("GridView1");
                GridViewRow row = GridView1.Rows[rowIndex];
                sid = row.Cells[0].Text;
                sname = row.Cells[1].Text.ToString();
                //  sname = (row.FindControl("lblName") as Label).Text;
                stddate = DateTime.Today.ToString();
                lblLocation.Text = (string)Session["location"];
                //  lblLoc.Text = (string)Session["Month"]; 
                //lblLoc.Text = "Jumeirah Group";
                location = lblLocation.Text;
                // sname = row.Cells[1].Text;



                //DropDownList dd2 = (DropDownList)PreviousPage.FindControl("DropDownList2");
                //lblLocation.Text = ddl.SelectedValue;


               

                //sid = ddlSubjects.SelectedItem.Value;
                //sname = ddlSubjects.SelectedItem.Text;
                Examination exam = new Examination(Int32.Parse(Session["mid"].ToString()), Int32.Parse(sid), sname, location);
                exam.GetQuestions();
                Session.Add("questions", exam);
                // Response.Redirect("Audit.aspx");

                //LinkButton2.Attributes.Add("onClick", "return false;");

                if (!Page.IsPostBack)
                    DisplayQuestion();

                // Label1.Text = lblQuestionId.Text;
            }


        }
       
        public void DisplayQuestion()
        {
            // get data from session object
            Examination e = (Examination)Session["questions"];
            // display data
            lblIndicatorName.Text = e.sname;
            lblQnum.Text = e.curpos + 1 + "/" + e.SIZE;
            //  lblCtime.Text = DateTime.Now.ToString();
            //   lblStime.Text = e.StartTime.ToString();
            lblLocation.Text = e.location;

            Question q = e.questions[e.curpos];
            // display details of question
            //question.InnerHtml = q.question;
            TextBox1.Text = q.question;
            lblQid.Text = q.qid;
            TextBox4.Text = q.guid;
            TextBox4.Text.Replace("\n", "<br /> <br />");
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
            RadioButtonList1.ClearSelection();

            // disable and enable buttons
            //if (e.curpos == 0)
            //    ImageButton9.Enabled = false;
            //else
            //    ImageButton9.Enabled = true;

            if (e.curpos == e.SIZE)
            {
                ImageButton2.Visible = true;
                btnNext.Visible = false;
            }
            else
                btnNext.Visible = true;


            //SqlConnection con3 = new SqlConnection(DBUtil.ConnectionString);
            //con3.Open();
            //SqlDataAdapter myDataAdapter;
            //DataSet ds;

            //myDataAdapter = new SqlDataAdapter("SELECT guid FROM tblQuestionsJMSub  WHERE qid = '" + q.qid + "' ", con3);

            ////DetailsID = '" + lstBoxCategory.SelectedValue.ToString() + "' ", connection);
            ////string queryString = ("SELECT guid FROM oe_questions where qid = '" + q.qid.ToString() +"' ");
            ////SqlDataAdapter adapter = new SqlDataAdapter(queryString, con3);

            //ds = new DataSet();
            //myDataAdapter.Fill(ds, "oe_questions");

            //con3.Close();

            ////GridView1.DataSource = ds.Tables[0];
            ////GridView1.DataBind();


            //SqlConnection con = new SqlConnection(DBUtil.ConnectionString);
            //con.Open();
            //SqlDataAdapter myDataAdapter1;
            //DataSet ds1;

            ////myDataAdapter1 = new SqlDataAdapter("SELECT guid FROM oe_questions  WHERE qid = '" + q.qid.ToString() + "' ", con3);
            //myDataAdapter1 = new SqlDataAdapter("SELECT ref FROM tblQuestionsJMSub WHERE qid = '" + q.qid + "' ", con);

            ////DetailsID = '" + lstBoxCategory.SelectedValue.ToString() + "' ", connection);
            ////string queryString = ("SELECT guid FROM oe_questions where qid = '" + q.qid.ToString() +"' ");
            ////SqlDataAdapter adapter = new SqlDataAdapter(queryString, con3);

            //ds1 = new DataSet();
            //myDataAdapter1.Fill(ds1, "oe_questions1");

            //con.Close();

            ////GridView2.DataSource = ds1.Tables[0];
            ////GridView2.DataBind();



        }

        public void ProcessQuestion()
        {
            Examination exam = (Examination)Session["questions"];
            Question q = exam.questions[exam.curpos];


            int answer;
            string evidence, comments, action;


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
                            if (rbAns5.Checked)
                                answer = 4;
                            else

                                if (rbAns6.Checked)
                                    answer = 5;
                                else

                                    if (rbAns7.Checked)
                                        answer = 6;
                                    else
                                        if (rbAns8.Checked)
                                            answer = 7;
                                        else
                                            if (rbAns9.Checked)
                                                answer = 8;
                                            else
                                                if (rbAns10.Checked)
                                                    answer = 9;
                                                else
                                                    if (rbAns11.Checked)
                                                        answer = 10;
                                                    else
                                                        answer = 0;          // error               
          
            evidence = TextBox2.Text;
            comments = TextBox3.Text;
            action = RadioButtonList1.Text;

            q.question = TextBox1.Text;
            q.answer = answer;
            q.evidence = evidence;
            q.comments = comments;
            q.action = action;

            exam.questions[exam.curpos] = q;
            Session.Add("questions", exam);
        }

        protected void TextBox4_TextChanged(object sender, EventArgs e)
        {
            TextBox4.Text.Replace("\n", "<br /> <br />");
        }

        protected void TextBox5_TextChanged(object sender, EventArgs e)
        {
            TextBox5.Text.Replace("\n", "<br /> <br />");
        }
        protected void TextBox4_DataBind(object sender, EventArgs e)
        {

            TextBox4.Text.Replace("\n", "<br /> <br />");

        }
        protected void TextBox5_DataBind(object sender, EventArgs e)
        {

            TextBox5.Text.Replace("\n", "<br /> <br />");

        }
        //protected void ImageButton9_ServerClick(object sender, EventArgs e)
        //{
           


        //    Examination e1 = (Examination)Session["questions"];
        //    Question q = e1.questions[e1.curpos - 1];

        //    if (e1.curpos >= 1)
        //    {
                  
        //        SqlConnection con = new SqlConnection(DBUtil.ConnectionString);
        //        SqlDataAdapter da;
        //        DataTable dt = new DataTable();
        //        DataRow dr;
        //        da = new SqlDataAdapter();
        //        da.SelectCommand = new SqlCommand("select * from tblSavedAnswersAuditor2 WHERE mid=@mid and location=@loc and sid=@sid and examid=@examid", con);
        //        da.SelectCommand.Parameters.Add("@mid", SqlDbType.Int);
        //        da.SelectCommand.Parameters.Add("@loc", SqlDbType.NVarChar);
        //        da.SelectCommand.Parameters.Add("@sid", SqlDbType.Int);
        //        da.SelectCommand.Parameters.Add("@examid", SqlDbType.Int);

        //        da.SelectCommand.Parameters["@mid"].Value = Session["mid"];
        //        da.SelectCommand.Parameters["@loc"].Value = lblLocation.Text;
        //        da.SelectCommand.Parameters["@sid"].Value = e1.sid;
        //        da.SelectCommand.Parameters["@examid"].Value = null;
                               
        //        da.Fill(dt);
        //        if (i == 0)
        //            Response.Write("First record !");
        //        else
        //            i--;
        //        dr = dt.Rows[i];
        //      //  TextBox1.Text = Convert.ToString(dr[0]);
        //        TextBox2.Text = Convert.ToString(dr[9]);
        //        TextBox3.Text = Convert.ToString(dr[10]);


        //        lblIndicatorName.Text = e1.sname;
        //        lblQnum.Text = e1.curpos + 1 + "/" + e1.SIZE;
        //        //  lblCtime.Text = DateTime.Now.ToString();
        //        //   lblStime.Text = e.StartTime.ToString();
        //        lblLocation.Text = e1.location;


        //        // display details of question
        //        //question.InnerHtml = q.question;
        //        TextBox1.Text = q.question;
        //        lblQid.Text = q.qid;
        //        TextBox4.Text = q.guid;
        //        TextBox4.Text.Replace("\n", "<br /> <br />");
        //        TextBox5.Text = q.refe;
        //        TextBox5.Text.Replace("\n", "<br /> <br />");
        //        //TextBox4.Text = q.qid.ToString();
        //        //ans1.InnerHtml = q.ans1;
        //        //ans2.InnerHtml = q.ans2;
        //        //ans3.InnerHtml = q.ans3;
        //        //ans4.InnerHtml = q.ans4;

        //        // reset all radio buttons
        //        rbAns1.Checked = false;
        //        rbAns2.Checked = false;
        //        rbAns3.Checked = false;
        //        rbAns4.Checked = false;
        //        rbAns5.Checked = false;
        //        rbAns6.Checked = false;
        //        rbAns7.Checked = false;
        //        rbAns8.Checked = false;
        //        rbAns9.Checked = false;
        //        rbAns10.Checked = false;
        //        rbAns11.Checked = false;


        //        // disable and enable buttons
        //        //if (e.curpos == 0)
        //        //    ImageButton9.Enabled = false;
        //        //else
        //        //    ImageButton9.Enabled = true;

        //        if (e1.curpos == e1.SIZE)
        //        {
        //            ImageButton2.Visible = true;
        //            btnNext.Visible = false;
        //        }
        //        else
        //            btnNext.Visible = true;


        //        //SqlConnection con3 = new SqlConnection(DBUtil.ConnectionString);
        //        //con3.Open();
        //        //SqlDataAdapter myDataAdapter;
        //        //DataSet ds;

        //        //myDataAdapter = new SqlDataAdapter("SELECT guid FROM tblQuestionsJMSub  WHERE qid = '" + q.qid + "' ", con3);

        //        ////DetailsID = '" + lstBoxCategory.SelectedValue.ToString() + "' ", connection);
        //        ////string queryString = ("SELECT guid FROM oe_questions where qid = '" + q.qid.ToString() +"' ");
        //        ////SqlDataAdapter adapter = new SqlDataAdapter(queryString, con3);

        //        //ds = new DataSet();
        //        //myDataAdapter.Fill(ds, "oe_questions");

        //        //con3.Close();

        //        ////GridView1.DataSource = ds.Tables[0];
        //        ////GridView1.DataBind();


        //        //SqlConnection con = new SqlConnection(DBUtil.ConnectionString);
        //        //con.Open();
        //        //SqlDataAdapter myDataAdapter1;
        //        //DataSet ds1;

        //        ////myDataAdapter1 = new SqlDataAdapter("SELECT guid FROM oe_questions  WHERE qid = '" + q.qid.ToString() + "' ", con3);
        //        //myDataAdapter1 = new SqlDataAdapter("SELECT ref FROM tblQuestionsJMSub WHERE qid = '" + q.qid + "' ", con);

        //        ////DetailsID = '" + lstBoxCategory.SelectedValue.ToString() + "' ", connection);
        //        ////string queryString = ("SELECT guid FROM oe_questions where qid = '" + q.qid.ToString() +"' ");
        //        ////SqlDataAdapter adapter = new SqlDataAdapter(queryString, con3);

        //        //ds1 = new DataSet();
        //        //myDataAdapter1.Fill(ds1, "oe_questions1");

        //        //con.Close();

        //        ////GridView2.DataSource = ds1.Tables[0];
        //        ////GridView2.DataBind();
        //        e1.curpos--;
        //        Session.Add("questions", e1);
        //        DisplayQuestion();

        //    }
        //    else           
        //    {
        //        //ImageButton9.Visible = false;
        //    }
        //}
        protected void btnNext_ServerClick(object sender, EventArgs e)
        {
//            //save as go for backbutton
//            ProcessQuestion();

//            Examination exam4 = (Examination)Session["questions"];

//            Question q4 = exam4.questions[exam4.curpos];

//            //SqlConnection con4 = new SqlConnection(DBUtil.ConnectionString);
//            //con.Open();

//            SqlConnection con9 = new SqlConnection(DBUtil.ConnectionString);
//            con9.Open();
//            SqlCommand cmd4 = new SqlCommand("select isnull( max(examid),0) + 1 from oe_exams", con9);
//            int examid2 = (Int32)cmd4.ExecuteScalar();
//            cmd4.CommandText = ("select locationid from tbllocation where location ='" + exam4.location + "'");
//            int locationid2 = (Int32)cmd4.ExecuteScalar();
//            cmd4.CommandText = @"
//				        MERGE tblSavedAnswersAuditor2 AS t
//					        USING (SELECT @mid AS mid, @sid AS sid, @qid AS qid, @location AS location) s
//					        ON t.mid = s.mid AND t.sid = s.sid AND t.qid = s.qid AND t.location = s.location
//				        WHEN MATCHED THEN
//					        UPDATE SET t.answer = @answer, t.evidence = @evidence, t.comments = @comments, t.action=@action
//				        WHEN NOT MATCHED THEN
//					        INSERT ( mid,sid, locationid, location, qid, question, answer, evidence, comments,action)
//					        VALUES (@mid,@sid,@locationid,@location,@qid,@question,@answer,@evidence,@comments,@action);
//			        ";

//            //cmd4.Parameters.Add("@examid", SqlDbType.Int).Value = null;
//            cmd4.Parameters.Add("@locationid", SqlDbType.NVarChar).Value = locationid2;
//            cmd4.Parameters.Add("@location", SqlDbType.NVarChar).Value = exam4.location;
//            cmd4.Parameters.Add("@mid", SqlDbType.Int).Value = exam4.mid;
//            cmd4.Parameters.Add("@sid", SqlDbType.Int).Value = exam4.sid;
//            cmd4.Parameters.Add("@qid", SqlDbType.NVarChar).Value = q4.qid;
//            cmd4.Parameters.Add("@question", SqlDbType.NVarChar).Value = q4.question;
//            cmd4.Parameters.Add("@answer", SqlDbType.Int).Value = q4.answer;
//            cmd4.Parameters.Add("@evidence", SqlDbType.NVarChar).Value = q4.evidence;
//            cmd4.Parameters.Add("@comments", SqlDbType.NVarChar).Value = q4.comments;
//            cmd4.Parameters.Add("@action", SqlDbType.NVarChar).Value = q4.action;
//            //cmd.Parameters.Add("@noq", SqlDbType.Int).Value = exam.SIZE;
//            //cmd.Parameters.Add("@ncans", SqlDbType.Int).Value = exam.ncans;
//            //cmd.Parameters.Add("@stdate", SqlDbType.DateTime).Value = exam.StartTime;
//            cmd4.ExecuteNonQuery();









            ProcessQuestion();
            Examination exam = (Examination)Session["questions"];
            Question q2 = exam.questions[exam.curpos];




            //SqlConnection con9 = new SqlConnection(DBUtil.ConnectionString);
            //con9.Open();
            //SqlCommand cmd4 = new SqlCommand("select isnull( max(examid),0) + 1 from oe_exams", con9);
            //int examid2 = (Int32)cmd4.ExecuteScalar();
            //cmd4.CommandText = ("select locationid from tbllocation where location ='" + exam.location + "'");
            //int locationid2 = (Int32)cmd4.ExecuteScalar();
            //cmd4.CommandText = "insert into tblSavedAnswersAuditor values(@examid,@locationid,@location,@mid,@sid,@qid,@question,@answer,@evidence,@comments)";
            //cmd4.Parameters.Add("@examid", SqlDbType.Int).Value = examid2;
            //cmd4.Parameters.Add("@locationid", SqlDbType.NVarChar).Value = locationid2;
            //cmd4.Parameters.Add("@location", SqlDbType.NVarChar).Value = exam.location;
            //cmd4.Parameters.Add("@mid", SqlDbType.Int).Value = exam.mid;
            //cmd4.Parameters.Add("@sid", SqlDbType.Int).Value = exam.sid;
            //cmd4.Parameters.Add("@qid", SqlDbType.NVarChar).Value = q2.qid;
            //cmd4.Parameters.Add("@question", SqlDbType.NVarChar).Value = q2.question;
            //cmd4.Parameters.Add("@answer", SqlDbType.Int).Value = q2.answer;
            //cmd4.Parameters.Add("@evidence", SqlDbType.NVarChar).Value = TextBox2.Text;
            //cmd4.Parameters.Add("@comments", SqlDbType.NVarChar).Value = TextBox3.Text;
            //cmd4.ExecuteNonQuery();
            
            //cmd.Parameters.Add("@noq", SqlDbType.Int).Value = exam.SIZE;
            //cmd.Parameters.Add("@ncans", SqlDbType.Int).Value = exam.ncans;
            //cmd.Parameters.Add("@stdate", SqlDbType.DateTime).Value = exam.StartTime;





            if (exam.curpos == exam.SIZE - 1)
            // Response.Redirect("showresult.aspx");
            {
                foreach (Question q in exam.questions)
                {

                    SqlConnection con = new SqlConnection(DBUtil.ConnectionString);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select isnull( max(examid),0) + 1 from oe_exams", con);
                    //int examid = (Int32)cmd.ExecuteScalar();
                    cmd.CommandText = ("select locationid from tbllocation where location ='" + exam.location + "'");
                    int locationid = (Int32)cmd.ExecuteScalar();
                    cmd.CommandText = "insert into tblSavedAnswers(locationid,location,mid,sid,qid,question,answer,evidence,comments,action,DateComplete) values(@locationid,@location,@mid,@sid,@qid,@question,@answer,@evidence,@comments,@action,@date)";
                   // cmd.Parameters.Add("@examid", SqlDbType.Int).Value = examid;
                    cmd.Parameters.Add("@locationid", SqlDbType.NVarChar).Value = locationid;
                    cmd.Parameters.Add("@location", SqlDbType.NVarChar).Value = exam.location;
                    cmd.Parameters.Add("@mid", SqlDbType.Int).Value = exam.mid;
                    cmd.Parameters.Add("@sid", SqlDbType.Int).Value = exam.sid;
                    cmd.Parameters.Add("@qid", SqlDbType.NVarChar).Value = q.qid;
                    cmd.Parameters.Add("@question", SqlDbType.NVarChar).Value = q.question;
                    cmd.Parameters.Add("@answer", SqlDbType.Int).Value = q.answer;
                    cmd.Parameters.Add("@evidence", SqlDbType.NVarChar).Value = q.evidence;
                    cmd.Parameters.Add("@comments", SqlDbType.NVarChar).Value = q.comments;
                    cmd.Parameters.Add("@action", SqlDbType.NVarChar).Value = q.action;
                    //cmd.Parameters.Add("@noq", SqlDbType.Int).Value = exam.SIZE;
                    //cmd.Parameters.Add("@ncans", SqlDbType.Int).Value = exam.ncans;
                    cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = DateTime.Now;
                    cmd.ExecuteNonQuery();


                  




                    SqlConnection con8 = new SqlConnection(DBUtil.ConnectionString);
                    con8.Open();
                    SqlCommand cmd8 = new SqlCommand("insert into tblSavedAnswersHistory(locationid,location,mid,sid,qid,question,answer,evidence,comments,action,DateComplete) values(@locationid,@location,@mid,@sid,@qid,@question,@answer,@evidence,@comments,@action,@date)", con8);
                    // cmd.CommandText = "insert into tblSavedAnswersHistory values(@examid,@locationid,@location,@mid,@sid,@qid,@question,@answer,@evidence,@comments,@date)";
                  //  cmd8.Parameters.Add("@examid", SqlDbType.Int).Value = null;
                    cmd8.Parameters.Add("@locationid", SqlDbType.NVarChar).Value = locationid;
                    cmd8.Parameters.Add("@location", SqlDbType.NVarChar).Value = exam.location;
                    cmd8.Parameters.Add("@mid", SqlDbType.Int).Value = exam.mid;
                    cmd8.Parameters.Add("@sid", SqlDbType.Int).Value = exam.sid;
                    cmd8.Parameters.Add("@qid", SqlDbType.NVarChar).Value = q.qid;
                    cmd8.Parameters.Add("@question", SqlDbType.NVarChar).Value = q.question;
                    cmd8.Parameters.Add("@answer", SqlDbType.Int).Value = q.answer;
                    cmd8.Parameters.Add("@evidence", SqlDbType.NVarChar).Value = q.evidence;
                    cmd8.Parameters.Add("@comments", SqlDbType.NVarChar).Value = q.comments;
                    cmd8.Parameters.Add("@action", SqlDbType.NVarChar).Value = q.action;
                    //cmd.Parameters.Add("@noq", SqlDbType.Int).Value = exam.SIZE;
                    //cmd.Parameters.Add("@ncans", SqlDbType.Int).Value = exam.ncans;
                    cmd8.Parameters.Add("@date", SqlDbType.DateTime).Value = DateTime.Today.ToString();
                    cmd8.ExecuteNonQuery();


                }
            



                Question q3 = exam.questions[exam.curpos];

                SqlConnection con5 = new SqlConnection(DBUtil.ConnectionString);
                SqlDataAdapter da5 = new SqlDataAdapter("select * from tblQuestionsJMSub where sid = " + q3.sid, con5);
                DataSet ds5 = new DataSet();
                da5.Fill(ds5, "questions");


                SqlConnection con4 = new SqlConnection(DBUtil.ConnectionString);
                SqlDataAdapter da = new SqlDataAdapter("select * from oe_subjects where sid = " + q3.sid, con4);
                DataSet ds = new DataSet();
                da.Fill(ds, "questions");

                int cnt = 0;
                Decimal per;
                int SIZE;
                Decimal score;

                Decimal weighting = decimal.Parse(ds.Tables[0].Rows[0][2].ToString());
                int nquestions = ds5.Tables[0].Rows.Count;
                SIZE = nquestions;

                foreach (Question q1 in exam.questions)
                {
                    //if (q.IsCorrect())
                    //    cnt++;
                    cnt = cnt + q1.answer;
                    //SqlConnection con4 = new SqlConnection(DBUtil.ConnectionString);
                    //con4.Open();
                    //SqlConnection con = new SqlConnection(DBUtil.ConnectionString);
                }
                //con.Open();                       

                per = (cnt / SIZE) * weighting;
                //  Label1.Text = per.ToString()+"%";
                //  lblNcans.Text = cnt.ToString();
                score = (Decimal)per;
                exam.score = (Decimal)score;
                Session.Add("questions", exam);


                SqlConnection con6 = new SqlConnection(DBUtil.ConnectionString);
                con6.Open();
                //SqlCommand cmd2 = new SqlCommand("select isnull( max(examid),0) + 1 from oe_exams", con2);
                //int examid = (Int32)cmd2.ExecuteScalar();
                //   SqlCommand cmd3 = new SqlCommand("Update View_subject_location Set score=@score,status=@status  WHERE sid =@sid and location=@loc", con6);
                SqlConnection cons = new SqlConnection(DBUtil.ConnectionString);
                cons.Open();
                SqlCommand cmds = new SqlCommand("select locationid from tbllocation where location ='" + exam.location + "'", cons);
                int locid = (Int32)cmds.ExecuteScalar();


                // SqlCommand cmd3 = new SqlCommand("UPDATE oe_subjects SET oe_subjects.score = @score,oe_subjects.status =@status FROM oe_subjects INNER JOIN tbllocation ON oe_subjects.locationid = tbllocation.id where tbllocation.location=@loc and oe_subject.sid=@sid ", con6);
                SqlCommand cmd3 = new SqlCommand("Insert into oe_subjects_status values(@sid,@mid,@locid,@loc,@sname,@status,@score)", con6);
                //  SqlCommand cmd3 = new SqlCommand("UPDATE View_subject_location SET View_subject_location.status=@status,View_subject_location.score=@score where View_subject_location.sid=@sid and View_subject_location.location=@loc", con6);
                // cmd2.CommandText = ("Update oe_subjects Set status=@status WHERE sid =@sid",con2);


                cmd3.Parameters.Add("@sid", SqlDbType.Int).Value = exam.sid;
                cmd3.Parameters.Add("@mid", SqlDbType.Int).Value = exam.mid;
                cmd3.Parameters.Add("@locid", SqlDbType.Int).Value = locid;
                cmd3.Parameters.Add("@loc", SqlDbType.NVarChar).Value = lblLocation.Text;
                cmd3.Parameters.Add("@sname", SqlDbType.NVarChar).Value = exam.sname;
                cmd3.Parameters.Add("@status", SqlDbType.NVarChar).Value = "complete";
                cmd3.Parameters.Add("@score", SqlDbType.Float).Value = exam.score;



                cmd3.ExecuteNonQuery();


                SqlConnection cons1 = new SqlConnection(DBUtil.ConnectionString);
                cons1.Open();
                SqlCommand cmda = new SqlCommand("Insert into oe_subjects_status_saved(sid,mid,locationid,location,sname,status,score,datecomplete) values(@sid,@mid,@locid,@loc,@sname,@status,@score,@date)", cons1);
               // int locid = (Int32)cmds.ExecuteScalar();

              //  SqlCommand cmda = new SqlCommand("Insert into oe_subjects_status_saved values(@sid,@mid,@locid,@loc,@sname,@status,@score)", con6);
                //  SqlCommand cmd3 = new SqlCommand("UPDATE View_subject_location SET View_subject_location.status=@status,View_subject_location.score=@score where View_subject_location.sid=@sid and View_subject_location.location=@loc", con6);
                // cmd2.CommandText = ("Update oe_subjects Set status=@status WHERE sid =@sid",con2);

                
                cmda.Parameters.Add("@sid", SqlDbType.Int).Value = exam.sid;
                cmda.Parameters.Add("@mid", SqlDbType.Int).Value = exam.mid;
                cmda.Parameters.Add("@locid", SqlDbType.Int).Value = locid;
                cmda.Parameters.Add("@loc", SqlDbType.NVarChar).Value = lblLocation.Text;
                cmda.Parameters.Add("@sname", SqlDbType.NVarChar).Value = exam.sname;
                cmda.Parameters.Add("@status", SqlDbType.NVarChar).Value = "complete";
                cmda.Parameters.Add("@score", SqlDbType.Float).Value = exam.score;
                cmda.Parameters.Add("@date", SqlDbType.DateTime).Value = DateTime.Today.ToString();



                cmda.ExecuteNonQuery();




                Question q6 = exam.questions[exam.curpos];

              






                string context = Session["location"].ToString();

                switch (context)
                {
                    case "Jumeirah Group Corporate":
                        {
                            Response.Redirect("JMIndicatorsCorporate.aspx");
                            break;
                        }
                    default:
                        {
                            Response.Redirect("JMIndicators.aspx");
                            break;

                        }






                }
            }

            else
            {
                exam.curpos++;
                Session.Add("questions", exam);                
                DisplayQuestion();
                TextBox2.Text = "";
                TextBox3.Text = "";
            }
        }




        //ProcessQuestion();
        //Examination exam = (Examination)Session["questions"];
        //Question q = exam.questions[exam.curpos];
        //if (exam.curpos == exam.SIZE - 1)
        //{

        //    SqlConnection con = new SqlConnection(DBUtil.ConnectionString);
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand("select isnull( max(examid),0) + 1 from oe_exams", con);
        //    int examid = (Int32)cmd.ExecuteScalar();
        //    cmd.CommandText = "insert into tblSavedAnswers values(@examid,@location,@mid,@sid,@qid,@question,@answer,@evidence,@comments)";
        //    cmd.Parameters.Add("@examid", SqlDbType.Int).Value = examid;
        //    cmd.Parameters.Add("@location", SqlDbType.NVarChar).Value = exam.location;
        //    cmd.Parameters.Add("@mid", SqlDbType.Int).Value = exam.mid;
        //    cmd.Parameters.Add("@sid", SqlDbType.Int).Value = exam.sid;
        //    cmd.Parameters.Add("@qid", SqlDbType.NVarChar).Value = q.qid;
        //    cmd.Parameters.Add("@question", SqlDbType.NVarChar).Value = q.question;
        //    cmd.Parameters.Add("@answer", SqlDbType.NVarChar).Value = q.answer;
        //    cmd.Parameters.Add("@evidence", SqlDbType.NVarChar).Value = q.evidence;
        //    cmd.Parameters.Add("@comments", SqlDbType.NVarChar).Value = q.comments;
        //    //cmd.Parameters.Add("@noq", SqlDbType.Int).Value = exam.SIZE;
        //    //cmd.Parameters.Add("@ncans", SqlDbType.Int).Value = exam.ncans;
        //    //cmd.Parameters.Add("@stdate", SqlDbType.DateTime).Value = exam.StartTime;
        //    cmd.ExecuteNonQuery();

        //    SqlConnection con5 = new SqlConnection(DBUtil.ConnectionString);
        //    SqlDataAdapter da5 = new SqlDataAdapter("select * from tblQuestionsJMSub where sid = " + q.sid, con5);
        //    DataSet ds5 = new DataSet();
        //    da5.Fill(ds5, "questions");


        //    SqlConnection con4 = new SqlConnection(DBUtil.ConnectionString);
        //    SqlDataAdapter da = new SqlDataAdapter("select * from oe_subjects_corporate where sid = " + q.sid, con4);
        //    DataSet ds = new DataSet();
        //    da.Fill(ds, "questions");

        //    int cnt = 0;
        //    Decimal per;
        //    int SIZE;
        //    Decimal score;

        //    Decimal weighting = decimal.Parse(ds.Tables[0].Rows[0][3].ToString());
        //    int nquestions = ds5.Tables[0].Rows.Count;
        //    SIZE = nquestions;

        //    foreach (Question q1 in exam.questions)
        //    {
        //        //if (q.IsCorrect())
        //        //    cnt++;
        //        cnt = cnt + q1.answer;
        //        //SqlConnection con4 = new SqlConnection(DBUtil.ConnectionString);
        //        //con4.Open();
        //        //SqlConnection con = new SqlConnection(DBUtil.ConnectionString);
        //    }
        //    //con.Open();                       

        //    per = (cnt / SIZE) * weighting;
        //    //  Label1.Text = per.ToString()+"%";
        //    //  lblNcans.Text = cnt.ToString();
        //    score = (Decimal)per;
        //    exam.score = (Decimal)score;
        //    Session.Add("questions", exam);

        //    //if (cnt > 3)
        //    //    lblGrade.Text = "Excellent";
        //    //else
        //    //    if (cnt > 1)
        //    //        lblGrade.Text = "Average";
        //    //    else
        //    //        lblGrade.Text = "Poor";
        //    // add row to OE_EXAMS table
        //    //SqlConnection con1 = new SqlConnection(DBUtil.ConnectionString);
        //    //con1.Open();
        //    //SqlCommand cmd2 = new SqlCommand("select isnull( max(examid),0) + 1 from oe_exams", con1);
        //    //int examid2 = (Int32)cmd1.ExecuteScalar();
        //    //cmd1.CommandText = "insert into oe_exams values(@examid,@mid,@sid,@noq,@ncans,@stdate,getdate())";
        //    //cmd1.Parameters.Add("@examid", SqlDbType.Int).Value = examid1;
        //    //cmd1.Parameters.Add("@mid", SqlDbType.Int).Value = exam.mid;
        //    //cmd1.Parameters.Add("@sid", SqlDbType.Int).Value = exam.sid;
        //    //cmd1.Parameters.Add("@noq", SqlDbType.Int).Value = exam.SIZE;
        //    //cmd1.Parameters.Add("@ncans", SqlDbType.Int).Value = exam.ncans;
        //    //cmd1.Parameters.Add("@stdate", SqlDbType.DateTime).Value = exam.StartTime;
        //    //cmd1.ExecuteNonQuery();
        //    //con1.Close();   




        //    SqlConnection con6 = new SqlConnection(DBUtil.ConnectionString);
        //    con6.Open();
        //    //SqlCommand cmd2 = new SqlCommand("select isnull( max(examid),0) + 1 from oe_exams", con2);
        //    //int examid = (Int32)cmd2.ExecuteScalar();
        // //   SqlCommand cmd3 = new SqlCommand("Update View_subject_location Set score=@score,status=@status  WHERE sid =@sid and location=@loc", con6);

        //   // SqlCommand cmd3 = new SqlCommand("UPDATE oe_subjects SET oe_subjects.score = @score,oe_subjects.status =@status FROM oe_subjects INNER JOIN tbllocation ON oe_subjects.locationid = tbllocation.id where tbllocation.location=@loc and oe_subject.sid=@sid ", con6);
        //    SqlCommand cmd3 = new SqlCommand("UPDATE View_subject_location SET View_subject_location.status=@status,View_subject_location.score=@score where View_subject_location.sid=@sid and View_subject_location.location=@loc", con6);
        //    // cmd2.CommandText = ("Update oe_subjects Set status=@status WHERE sid =@sid",con2);
        //    cmd3.Parameters.Add("@score", SqlDbType.Float).Value = exam.score;
        //    cmd3.Parameters.Add("@status", SqlDbType.NVarChar).Value = "complete";
        //    cmd3.Parameters.Add("@sid", SqlDbType.Int).Value = exam.sid;
        //    cmd3.Parameters.Add("@loc", SqlDbType.NVarChar).Value = lblLocation.Text;

        //    cmd3.ExecuteNonQuery();

        //    Response.Redirect("JMIndicators.aspx");

        //}
        //else
        //{

        //    SqlConnection con = new SqlConnection(DBUtil.ConnectionString);
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand("select isnull( max(examid),0) + 1 from oe_exams", con);
        //    int examid = (Int32)cmd.ExecuteScalar();
        //    cmd.CommandText = "insert into tblSavedAnswers values(@examid,@location,@mid,@sid,@qid,@question,@answer,@evidence,@comments)";
        //    cmd.Parameters.Add("@examid", SqlDbType.Int).Value = examid;
        //    cmd.Parameters.Add("@location", SqlDbType.NVarChar).Value = exam.location;
        //    cmd.Parameters.Add("@mid", SqlDbType.Int).Value = exam.mid;
        //    cmd.Parameters.Add("@sid", SqlDbType.Int).Value = exam.sid;
        //    cmd.Parameters.Add("@qid", SqlDbType.NVarChar).Value = q.qid;
        //    cmd.Parameters.Add("@question", SqlDbType.NVarChar).Value = q.question;
        //    cmd.Parameters.Add("@answer", SqlDbType.NVarChar).Value = q.answer;
        //    cmd.Parameters.Add("@evidence", SqlDbType.NVarChar).Value = q.evidence;
        //    cmd.Parameters.Add("@comments", SqlDbType.NVarChar).Value = q.comments;
        //    //cmd.Parameters.Add("@noq", SqlDbType.Int).Value = exam.SIZE;
        //    //cmd.Parameters.Add("@ncans", SqlDbType.Int).Value = exam.ncans;
        //    //cmd.Parameters.Add("@stdate", SqlDbType.DateTime).Value = exam.StartTime;
        //    cmd.ExecuteNonQuery();

        //    exam.curpos++;
        //    Session.Add("questions", exam);
        //    DisplayQuestion();







        protected void ImageButton1_ServerClick(object sender, EventArgs e)
        {
            Response.Write(string.Format("<script>window.open('{0}','_blank');</script>", "Default3.aspx"));
        }
        protected void ImageButton8_ServerClick(object sender, EventArgs e)
        {
            //lblLocation.Text = (string)Session["location"];
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {

                ProcessQuestion();

                Examination exam = (Examination)Session["questions"];
                //Question q = exam.questions[exam.curpos];
                //if (exam.curpos == exam.SIZE - 1)
                //    Response.Redirect("showresult.aspx");
                //else
                //{

                for (var questionPos = 0; questionPos <= exam.curpos; questionPos++)
                {
                    Question q = exam.questions[questionPos];

                    SqlConnection con = new SqlConnection(DBUtil.ConnectionString);
                    con.Open();

                    SqlConnection con9 = new SqlConnection(DBUtil.ConnectionString);
                    con9.Open();
                    SqlCommand cmd4 = new SqlCommand("select isnull( max(examid),0) + 1 from oe_exams", con9);
                    int examid2 = (Int32)cmd4.ExecuteScalar();
                    cmd4.CommandText = ("select locationid from tbllocation where location ='" + exam.location + "'");
                    int locationid2 = (Int32)cmd4.ExecuteScalar();
                    cmd4.CommandText = @"
				            MERGE tblSavedAnswersAuditor AS t
					            USING (SELECT @mid AS mid, @sid AS sid, @qid AS qid, @location AS location) s
					            ON t.mid = s.mid AND t.sid = s.sid AND t.qid = s.qid AND t.location = s.location
				            WHEN MATCHED THEN
					            UPDATE SET t.answer = @answer, t.evidence = @evidence, t.comments = @comments, t.action = @action
				            WHEN NOT MATCHED THEN
					            INSERT ( mid, examid, sid, locationid, location, qid, question, answer, evidence, comments, action)
					            VALUES (@mid,@examid,@sid,@locationid,@location,@qid,@question,@answer,@evidence,@comments,@action);
			            ";

                    cmd4.Parameters.Add("@examid", SqlDbType.Int).Value = examid2;
                    cmd4.Parameters.Add("@locationid", SqlDbType.NVarChar).Value = locationid2;
                    cmd4.Parameters.Add("@location", SqlDbType.NVarChar).Value = exam.location;
                    cmd4.Parameters.Add("@mid", SqlDbType.Int).Value = exam.mid;
                    cmd4.Parameters.Add("@sid", SqlDbType.Int).Value = exam.sid;
                    cmd4.Parameters.Add("@qid", SqlDbType.NVarChar).Value = q.qid;
                    cmd4.Parameters.Add("@question", SqlDbType.NVarChar).Value = q.question;
                    cmd4.Parameters.Add("@answer", SqlDbType.Int).Value = q.answer;
                    cmd4.Parameters.Add("@evidence", SqlDbType.NVarChar).Value = q.evidence;
                    cmd4.Parameters.Add("@comments", SqlDbType.NVarChar).Value = q.comments;
                    cmd4.Parameters.Add("@action", SqlDbType.NVarChar).Value = q.action;
                    //cmd.Parameters.Add("@noq", SqlDbType.Int).Value = exam.SIZE;
                    //cmd.Parameters.Add("@ncans", SqlDbType.Int).Value = exam.ncans;
                    //cmd.Parameters.Add("@stdate", SqlDbType.DateTime).Value = exam.StartTime;
                    cmd4.ExecuteNonQuery();

                    //exam.curpos--;
                    //Session.Add("questions", exam);
                    //DisplayQuestion();

                }



                SqlConnection cons = new SqlConnection(DBUtil.ConnectionString);
                cons.Open();
                SqlCommand cmds = new SqlCommand("select locationid from tbllocation where location ='" + exam.location + "'", cons);
                int locid = (Int32)cmds.ExecuteScalar();


                SqlConnection con2 = new SqlConnection(DBUtil.ConnectionString);
                con2.Open();
                //SqlCommand cmd2 = new SqlCommand("select isnull( max(examid),0) + 1 from oe_exams", con2);
                //int examid = (Int32)cmd2.ExecuteScalar();
                //SqlCommand cmd2 = new SqlCommand("Insert into oe_subjects_status values(@sid,@mid,@locid,@loc,@sname,@status,@score)", con2);


                cmds.CommandText = @"
				            MERGE oe_subjects_status  AS t
					            USING (SELECT @sid AS sid, @mid AS mid, @locid AS locationid, @loc AS location,@sname AS sname,@status AS status,@score AS score) s
					            ON t.sid = s.sid AND t.mid = s.mid AND t.locationid = s.locationid
				            WHEN MATCHED THEN
					            UPDATE SET t.status=@status, t.score=@score
				            WHEN NOT MATCHED THEN
					            INSERT ( sid, mid,locationid, location, sname,status,score)
					            VALUES (@sid,@mid,@locid,@loc,@sname,@status,@score);
			            ";


                cmds.Parameters.Add("@sid", SqlDbType.Int).Value = exam.sid;
                cmds.Parameters.Add("@mid", SqlDbType.Int).Value = exam.mid;
                cmds.Parameters.Add("@locid", SqlDbType.Int).Value = locid;
                cmds.Parameters.Add("@loc", SqlDbType.NVarChar).Value = lblLocation.Text;
                cmds.Parameters.Add("@sname", SqlDbType.NVarChar).Value = exam.sname;
                cmds.Parameters.Add("@status", SqlDbType.NVarChar).Value = "Incomplete";
                cmds.Parameters.Add("@score", SqlDbType.Float).Value = exam.score;
                // cmd2.Parameters.Add("@score", SqlDbType.Float).Value = exam.score;
                cmds.ExecuteNonQuery();



                //                SqlConnection cons2 = new SqlConnection(DBUtil.ConnectionString);
                //                cons2.Open();
                //                SqlCommand cmds2 = new SqlCommand("select locationid from tbllocation where location ='" + exam.location + "'", cons2);
                //                int locid2 = (Int32)cmds2.ExecuteScalar();                           


                //                cmds2.CommandText = @"
                //				        MERGE oe_subjects_status_saved  AS t
                //					        USING (SELECT @sid AS sid, @mid AS mid, @locid AS locationid, @loc AS location,@sname AS sname,@status AS status,@score AS score,@date AS datecomplete) s
                //					        ON t.sid = s.sid AND t.mid = s.mid AND t.locationid = s.locationid
                //				        WHEN MATCHED THEN
                //					        UPDATE SET t.status=@status, t.score=@score, t.datecomplete=@date
                //				        WHEN NOT MATCHED THEN
                //					        INSERT ( sid, mid,locationid, location, sname,status,score,datecomplete)
                //					        VALUES (@sid,@mid,@locid,@loc,@sname,@status,@score,@date);
                //			        ";


                //                cmds2.Parameters.Add("@sid", SqlDbType.Int).Value = exam.sid;
                //                cmds2.Parameters.Add("@mid", SqlDbType.Int).Value = exam.mid;
                //                cmds2.Parameters.Add("@locid", SqlDbType.Int).Value = locid;
                //                cmds2.Parameters.Add("@loc", SqlDbType.NVarChar).Value = lblLocation.Text;
                //                cmds2.Parameters.Add("@sname", SqlDbType.NVarChar).Value = exam.sname;
                //                cmds2.Parameters.Add("@status", SqlDbType.NVarChar).Value = "Incomplete";
                //                cmds2.Parameters.Add("@score", SqlDbType.Float).Value = exam.score;
                //                cmds2.Parameters.Add("@date", SqlDbType.DateTime).Value = DateTime.Today.ToString("dd/MM/yyyy");
                //                // cmd2.Parameters.Add("@score", SqlDbType.Float).Value = exam.score;
                //                cmds2.ExecuteNonQuery();




                SqlConnection con3 = new SqlConnection(DBUtil.ConnectionString);
                con3.Open();
                //SqlCommand cmd2 = new SqlCommand("select isnull( max(examid),0) + 1 from oe_exams", con2);
                //int examid = (Int32)cmd2.ExecuteScalar();
                SqlCommand cmd3 = new SqlCommand("Delete from tblSavedAnswers where mid=@mid and location=@loc and sid=@sid", con3);
                // cmd2.CommandText = ("Update oe_subjects Set status=@status WHERE sid =@sid",con2);
                cmd3.Parameters.Add("@mid", SqlDbType.Int).Value = exam.mid;
                cmd3.Parameters.Add("@sid", SqlDbType.NVarChar).Value = exam.sid;
                cmd3.Parameters.Add("@loc", SqlDbType.NVarChar).Value = lblLocation.Text;
                // cmd2.Parameters.Add("@score", SqlDbType.Float).Value = exam.score;
                cmd3.ExecuteNonQuery();

                //string context = Session["location"].ToString();

                //switch (context)
                //{
                //    case "Jumeirah Group Corporate":
                //        {
                //            Response.Redirect("JMIndicatorsCorporate.aspx");
                //            break;
                //        }
                //    default:
                //        {
                //            ViewState["PreviousPageURL"] = Request.UrlReferrer; 
                //            Session["PREVPAGE"] = "fooo.aspx";
                //            Session["location"] = lblLocation.Text;
                //            Response.Redirect("JMIndicators.aspx");
                //            break;

                //        }

                Session.Remove("location"); 
                Response.Redirect("HomePageJM.aspx");



            }
            else
            {
               
            }
        }




        

        protected void ImageButton3_ServerClick(object sender, EventArgs e)
        {
            // Response.Redirect("pdfViwerGuide.aspx", target="_blank");
            Session.Remove("questions");
            string context = Session["location"].ToString();

            switch (context)
            {
                case "Jumeirah Group Corporate":
                    {
                        Response.Redirect("JMIndicatorsCorporate.aspx");
                        break;
                    }
                default:
                    {
                        Response.Redirect("JMIndicators.aspx");
                        break;

                    }






            }
        }


        protected void btnCancel_ServerClick(object sender, EventArgs e)
        {


        }
        protected void ImageButton2_ServerClick(object sender, EventArgs e)
        {


        }
        protected void ImageButton6_ServerClick(object sender, EventArgs e)
        {

            TextBox4.Text.Replace("\n", "<br /> <br />");
        }
        protected void ImageButton7_ServerClick(object sender, EventArgs e)
        {

            TextBox5.Text.Replace("\n", "<br /> <br />");
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = rbAns1.Checked || rbAns2.Checked || rbAns3.Checked;
        }

        protected void btnlogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();

            Session.Abandon();

            Response.Redirect("Login.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Examination e1 = (Examination)Session["questions"];
            Question q = e1.questions[e1.curpos - 1];

            if(e1.curpos >= 1)
            {
                lblIndicatorName.Text = e1.sname;
                lblQnum.Text = e1.curpos + 1 + "/" + e1.SIZE;
                //  lblCtime.Text = DateTime.Now.ToString();
                //   lblStime.Text = e.StartTime.ToString();
                lblLocation.Text = e1.location;


                // display details of question
                //question.InnerHtml = q.question;
                TextBox1.Text = q.question;
                lblQid.Text = q.qid;
                TextBox4.Text = q.guid;
                TextBox4.Text.Replace("\n", "<br /> <br />");
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
                //if (e.curpos == 0)
                //    ImageButton9.Enabled = false;
                //else
                //    ImageButton9.Enabled = true;

                if (e1.curpos == e1.SIZE)
                {
                    ImageButton2.Visible = true;
                    btnNext.Visible = false;
                }
                else
                    btnNext.Visible = true;


                //SqlConnection con3 = new SqlConnection(DBUtil.ConnectionString);
                //con3.Open();
                //SqlDataAdapter myDataAdapter;
                //DataSet ds;

                //myDataAdapter = new SqlDataAdapter("SELECT guid FROM tblQuestionsJMSub  WHERE qid = '" + q.qid + "' ", con3);

                ////DetailsID = '" + lstBoxCategory.SelectedValue.ToString() + "' ", connection);
                ////string queryString = ("SELECT guid FROM oe_questions where qid = '" + q.qid.ToString() +"' ");
                ////SqlDataAdapter adapter = new SqlDataAdapter(queryString, con3);

                //ds = new DataSet();
                //myDataAdapter.Fill(ds, "oe_questions");

                //con3.Close();

                ////GridView1.DataSource = ds.Tables[0];
                ////GridView1.DataBind();


                //SqlConnection con = new SqlConnection(DBUtil.ConnectionString);
                //con.Open();
                //SqlDataAdapter myDataAdapter1;
                //DataSet ds1;

                ////myDataAdapter1 = new SqlDataAdapter("SELECT guid FROM oe_questions  WHERE qid = '" + q.qid.ToString() + "' ", con3);
                //myDataAdapter1 = new SqlDataAdapter("SELECT ref FROM tblQuestionsJMSub WHERE qid = '" + q.qid + "' ", con);

                ////DetailsID = '" + lstBoxCategory.SelectedValue.ToString() + "' ", connection);
                ////string queryString = ("SELECT guid FROM oe_questions where qid = '" + q.qid.ToString() +"' ");
                ////SqlDataAdapter adapter = new SqlDataAdapter(queryString, con3);

                //ds1 = new DataSet();
                //myDataAdapter1.Fill(ds1, "oe_questions1");

                //con.Close();

                ////GridView2.DataSource = ds1.Tables[0];
                ////GridView2.DataBind();
                e1.curpos--;
                Session.Add("questions", e1);
                DisplayQuestion();

            }
          

        }
    }
}