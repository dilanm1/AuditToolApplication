using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace AuditMgtNew.Old_App_Code
{
    public class SavedExaminationCorporateJM
    {
    public int SIZE = 5;
        public int mid;
        public int sid;
        public String sname;
        public int answer;
        public List<SavedQuestions> questions;
        public DateTime StartTime;
        public int curpos = 0;
       

    public SavedExaminationCorporateJM(int mid, int sid, String sname)
    {
        this.mid = mid;
        this.sid = sid;
        this.sname = sname;
        StartTime = DateTime.Now;
    }

   

    public void GetSavedQuestions()
    {
        int Sid = sid;
        // get questions from OE_QUESTIONS table
        SqlConnection con = new SqlConnection(DBUtil.ConnectionString );
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "SELECT DISTINCT tblQuestionsJMSubCorp.id,tblQuestionsJMSubCorp.qid, tblQuestionsJMSubCorp.question, tblQuestionsJMSubCorp.ref, tblQuestionsJMSubCorp.guid, ISNULL(tblSavedAnswersAuditorCorporateJM.answer, 0) as answer,ISNULL(tblSavedAnswersAuditorCorporateJM.evidence, 0) as evidence,ISNULL(tblSavedAnswersAuditorCorporateJM.comments, 0) as comments, tblQuestionsJMSubCorp.sid FROM tblQuestionsJMSubCorp LEFT JOIN tblSavedAnswersAuditorCorporateJM ON tblQuestionsJMSubCorp.qid = tblSavedAnswersAuditorCorporateJM.qid WHERE (tblQuestionsJMSubCorp.sid =@sid)ORDER BY tblQuestionsJMSubCorp.id";
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



} 
}// end of Class
