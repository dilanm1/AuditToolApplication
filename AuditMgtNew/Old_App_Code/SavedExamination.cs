using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;


namespace AuditMgtNew.Old_App_Code
{
    public class SavedExamination
    {
        public int SIZE;
        public int mid;
        public int sid;     
        public String location;
        public String sname;
        public int answer;
        public Decimal score;
        public List<SavedQuestions> questions;
        public DateTime StartTime;
        public int curpos;

        public SavedExamination(int mid, int sid, String sname, String location)
        {
            this.mid = mid;
            this.sid = sid;          
            this.sname = sname;
            StartTime = DateTime.Now;
            this.location = location;
        }

        public void GetSavedQuestions()
        {
            if (location == "Jumeirah Group Corporate")
            {
                int Sid = sid;
                int Mid = mid;
                string Location = location;
               
                // get questions from OE_QUESTIONS table
                SqlConnection con = new SqlConnection(DBUtil.ConnectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT tblQuestionsJMSubCorp.qid,tblQuestionsJMSubCorp.question,tblQuestionsJMSubCorp.ref,tblQuestionsJMSubCorp.guid, ISNULL(tblSavedAnswersAuditor.mid,0) as mid, ISNULL(tblSavedAnswersAuditor.answer,0) as answer,ISNULL(tblSavedAnswersAuditor.evidence,0) as evidence,ISNULL(tblSavedAnswersAuditor.comments,0) as comments,ISNULL(tblSavedAnswersAuditor.action,0) as action, tblQuestionsJMSubCorp.sid FROM  tblQuestionsJMSubCorp LEFT JOIN tblSavedAnswersAuditor ON tblQuestionsJMSubCorp.qid = tblSavedAnswersAuditor.qid and (@mid IS NULL OR tblSavedAnswersAuditor.mid = @mid) and (@loc IS NULL OR tblSavedAnswersAuditor.location=@loc) WHERE tblQuestionsJMSubCorp.sid=@sid ORDER BY tblQuestionsJMSubCorp.id";

               
                cmd.Parameters.Add("@mid", SqlDbType.Int);
                cmd.Parameters.Add("@loc", SqlDbType.NVarChar);                
                cmd.Parameters.Add("@sid", SqlDbType.Int);
              

           

               // cmd.Parameters["@mid"].Value = (Mid == null) ? (object)DBNull.Value : Mid;
                cmd.Parameters["@mid"].Value =  Mid;
               // cmd.Parameters["@loc"].Value = (Location == "Jumeirah Group Corporate") ? (object)DBNull.Value : Location;
                cmd.Parameters["@loc"].Value = Location;
                //cmd.Parameters["@sid"].Value = (Sid == null) ? (object)DBNull.Value : Sid;
                cmd.Parameters["@sid"].Value = Sid;

               
             //   cmd.Parameters["@sid"].Value = (Sid == null) ? (object)DBNull.Value : Sid;

                //cmd.Parameters["@mid"].Value = Mid;
                //cmd.Parameters["@loc"].Value = Location;
                //cmd.Parameters["@sid"].Value = Sid;

                //cmd.Parameters["@mid"].Value = Mid;
                //cmd.Parameters["@loc"].Value = Location;
                //SqlDataAdapter da = new SqlDataAdapter("select id,sid,qid,question,answer,evidence,comments from tblSavedAnswersAuditor where sid =" + sid, con);
                // SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT tblQuestionsJMSub.id,tblQuestionsJMSub.qid, tblQuestionsJMSub.question, tblQuestionsJMSub.ref, tblQuestionsJMSub.guid, ISNULL(tblSavedAnswersAuditor.answer, 0) as answer,ISNULL(tblSavedAnswersAuditor.evidence, 0) as evidence,ISNULL(tblSavedAnswersAuditor.comments, 0) as comments, tblQuestionsJMSub.sid FROM tblQuestionsJMSub LEFT JOIN tblSavedAnswersAuditor ON tblQuestionsJMSub.qid = tblSavedAnswersAuditor.qid WHERE (tblQuestionsJMSub.sid =@sid)ORDER BY tblQuestionsJMSub.id", con); 
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds, "questionsSaved");
                int nquestions = ds.Tables[0].Rows.Count;
                SIZE = nquestions;


                // load data from DataSet into Question Objects
                questions = new List<SavedQuestions>();
                //  DataRow dr;
                SavedQuestions q;
                foreach (DataRow data in ds.Tables[0].Rows)
                {
                   
                    // dr = ds.Tables[0].Rows[pos];
                    q = new SavedQuestions(Convert.ToInt32(data["mid"]), Convert.ToInt32(data["sid"]), data["qid"].ToString(), data["question"].ToString(), data["guid"].ToString(), data["ref"].ToString(), Convert.ToInt32(data["answer"]), data["evidence"].ToString(), data["comments"].ToString(), data["action"].ToString());
                        
                       questions.Add(q);
                 

                    
                }
            } // end of GetQuestions()
            else
            {
                int Sid = sid;
                int Mid = mid;
                string Location = location; 
                // get questions from OE_QUESTIONS table
                SqlConnection con = new SqlConnection(DBUtil.ConnectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT tblQuestionsJMSub.qid,tblQuestionsJMSub.question,tblQuestionsJMSub.ref,tblQuestionsJMSub.guid, ISNULL(tblSavedAnswersAuditor.mid,0) as mid, ISNULL(tblSavedAnswersAuditor.answer,0) as answer,ISNULL(tblSavedAnswersAuditor.evidence,0) as evidence,ISNULL(tblSavedAnswersAuditor.comments,0) as comments,ISNULL(tblSavedAnswersAuditor.action,0) as action, tblQuestionsJMSub.sid FROM  tblQuestionsJMSub LEFT JOIN tblSavedAnswersAuditor ON tblQuestionsJMSub.qid = tblSavedAnswersAuditor.qid and (@mid IS NULL OR tblSavedAnswersAuditor.mid = @mid) and (@loc IS NULL OR tblSavedAnswersAuditor.location=@loc) WHERE tblQuestionsJMSub.sid=@sid ORDER BY tblQuestionsJMSub.id";
                cmd.Parameters.Add("@mid", SqlDbType.Int);
                cmd.Parameters.Add("@loc", SqlDbType.NVarChar);
                cmd.Parameters.Add("@sid", SqlDbType.Int);


                cmd.Parameters["@mid"].Value = (Mid == null) ? (object)DBNull.Value : Mid;
                //cmd.Parameters["@mid"].Value = Mid;
                cmd.Parameters["@loc"].Value = (Location == null) ? (object)DBNull.Value : Location;
                cmd.Parameters["@sid"].Value = (Sid == null) ? (object)DBNull.Value : Sid;
                //cmd.Parameters["@sid"].Value = Sid;
                //SqlDataAdapter da = new SqlDataAdapter("select id,sid,qid,question,answer,evidence,comments from tblSavedAnswersAuditor where sid =" + sid, con);
                // SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT tblQuestionsJMSub.id,tblQuestionsJMSub.qid, tblQuestionsJMSub.question, tblQuestionsJMSub.ref, tblQuestionsJMSub.guid, ISNULL(tblSavedAnswersAuditor.answer, 0) as answer,ISNULL(tblSavedAnswersAuditor.evidence, 0) as evidence,ISNULL(tblSavedAnswersAuditor.comments, 0) as comments, tblQuestionsJMSub.sid FROM tblQuestionsJMSub LEFT JOIN tblSavedAnswersAuditor ON tblQuestionsJMSub.qid = tblSavedAnswersAuditor.qid WHERE (tblQuestionsJMSub.sid =@sid)ORDER BY tblQuestionsJMSub.id", con); 
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds, "questionsSaved");
                int nquestions = ds.Tables[0].Rows.Count;
                SIZE = nquestions;


                // load data from DataSet into Question Objects
                questions = new List<SavedQuestions>();
                //  DataRow dr;
                SavedQuestions q;
                foreach (DataRow data in ds.Tables[0].Rows)
                {
                    //if ((DBNull.Value.Equals(data["mid"]) && !DBNull.Value.Equals(data["sid"]) && !DBNull.Value.Equals(data["qid"]) && !DBNull.Value.Equals(data["question"]) && DBNull.Value.Equals(data["answer"]) && DBNull.Value.Equals(data["evidence"]) && DBNull.Value.Equals(data["comments"])))
                    //{
                        // dr = ds.Tables[0].Rows[pos];
                    q = new SavedQuestions(Convert.ToInt32(data["mid"]), Convert.ToInt32(data["sid"]), data["qid"].ToString(), data["question"].ToString(), data["guid"].ToString(), data["ref"].ToString(), Convert.ToInt32(data["answer"]), data["evidence"].ToString(), data["comments"].ToString(), data["action"].ToString());
                        questions.Add(q);
                    //}
                    //if 
                    //((DBNull.Value.Equals(data["mid"]) && DBNull.Value.Equals(data["sid"]) && !DBNull.Value.Equals(data["qid"]) && !DBNull.Value.Equals(data["question"]) && DBNull.Value.Equals(data["answer"]) && DBNull.Value.Equals(data["evidence"]) && DBNull.Value.Equals(data["comments"])))
                    //{

                    //    q = new SavedQuestions(Convert.ToInt32(data["mid"]), Convert.ToInt32(data["sid"]), data["qid"].ToString(), data["question"].ToString(), Convert.ToInt32(data["answer"]), data["evidence"].ToString(), data["comments"].ToString());
                    //    questions.Add(q);
                    //}
                }


            }
        }// end of Class
    }
}
