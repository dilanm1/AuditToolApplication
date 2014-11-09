using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace AuditMgtNew.Old_App_Code
{
    public class QuestionsSavedTC
    {
     public int SIZE = 5;
        public int mid;
        public int sid;
        public String location;
        public String sname;
        public int answer;
        public Decimal score;
        public List<SavedQuestions> questions;
        public DateTime StartTime;
        public int curpos = 0;

        public QuestionsSavedTC(int mid, int sid, String sname, String location)
        {
            this.mid = mid;
            this.sid = sid;
            this.sname = sname;
            StartTime = DateTime.Now;
            this.location = location;
        }

        public void GetSavedQuestions()
        {
            if (location == "TECOM Investments Corporate")
            {
                int Sid = sid;
                // get questions from OE_QUESTIONS table
                SqlConnection con = new SqlConnection(DBUtil.ConnectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT DISTINCT tblQuestionsTcomCorp.id,tblQuestionsTcomCorp.qid, tblQuestionsTcomCorp.question, tblQuestionsTcomCorp.ref, tblQuestionsTcomCorp.guid, ISNULL(tblSavedAnswersAuditor.answer, 0) as answer,ISNULL(tblSavedAnswersAuditor.evidence, 0) as evidence,ISNULL(tblSavedAnswersAuditor.comments, 0) as comments, tblQuestionsTcomCorp.sid FROM tblQuestionsTcomCorp LEFT JOIN tblSavedAnswersAuditor ON tblQuestionsTcomCorp.qid = tblSavedAnswersAuditor.qid WHERE (tblQuestionsTcomCorp.sid =@sid)ORDER BY tblQuestionsTcomCorp.id";
                cmd.Parameters.Add("@sid", SqlDbType.Int);
                cmd.Parameters["@sid"].Value = Sid;
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
                 //  q = new SavedQuestions(Convert.ToInt32(data["sid"]), data["qid"].ToString(), data["question"].ToString(), Convert.ToInt32(data["answer"]), data["evidence"].ToString(), data["comments"].ToString());
                  //  questions.Add(q);
                }
            } // end of GetQuestions()
            else
            {
                int Sid = sid;
                // get questions from OE_QUESTIONS table
                SqlConnection con = new SqlConnection(DBUtil.ConnectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT DISTINCT tblQuestionsTComSBU.id,tblQuestionsTComSBU.qid, tblQuestionsTComSBU.question, tblQuestionsTComSBU.ref, tblQuestionsTComSBU.guid, ISNULL(tblSavedAnswersAuditor.answer, 0) as answer,ISNULL(tblSavedAnswersAuditor.evidence, 0) as evidence,ISNULL(tblSavedAnswersAuditor.comments, 0) as comments, tblQuestionsTComSBU.sid FROM tblQuestionsTComSBU LEFT JOIN tblSavedAnswersAuditor ON tblQuestionsTComSBU.qid = tblSavedAnswersAuditor.qid WHERE (tblQuestionsTComSBU.sid =@sid)ORDER BY tblQuestionsTComSBU.id";
                cmd.Parameters.Add("@sid", SqlDbType.Int);
                cmd.Parameters["@sid"].Value = Sid;
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
                 //   q = new SavedQuestions(Convert.ToInt32(data["sid"]), data["qid"].ToString(), data["question"].ToString(), Convert.ToInt32(data["answer"]), data["evidence"].ToString(), data["comments"].ToString());
                 //   questions.Add(q);
                }



            }
        }// end of Class
    }
}
