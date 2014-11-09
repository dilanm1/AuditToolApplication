using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;


namespace AuditMgtNew.Old_App_Code
{
    public class AuditAnswers
    {
        public int SIZE;
        public int mid;
        int qid;
        public int examid;
        public String sname;
        public int ncans;
        public List<QuestionAnswers> questionsAnswers;
        public DateTime StartTime;
        public int curpos = 0;
        private int p;
        private int p_2;
        private int p_3;

        public AuditAnswers(int mid, int examid, int qid, string sname)
        {
            this.mid = mid;
            this.examid = examid;
            this.qid = qid;
            this.sname = sname;
            StartTime = DateTime.Now;
        }

      
        public void GetQuestionsAnswers()
        {
            // get questions from OE_QUESTIONS table
            SqlConnection con = new SqlConnection(DBUtil.ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select Distinct examid,qid,sname,question,answer from tblFinalData where examid = " + examid, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "questions1");
            int nquestions = ds.Tables[0].Rows.Count;
            SIZE = nquestions;

            // get N no. of random number
            //Random r = new Random();

            //int r = Convert.ToInt32(ds.Tables[0].Rows[0]["qid"]);
            //int[] positions = new int[SIZE];
            //int num;
            //for (int pos = 0; pos < SIZE; )
            //{
            //    num = Math.Abs(r.Next(SIZE));
            //    // check whether the number is already in the array
            //    bool found = false;
            //    for( int i = 0; i < pos ; i ++)
            //        if (num == positions[i]) { found = true; break; }

            //    if (!found)
            //    {   positions[pos] = num;
            //        pos++;
            //    }
            //} // end of for

            // load data from DataSet into Question Objects
            questionsAnswers = new List<QuestionAnswers>();
            //  DataRow dr;
            QuestionAnswers q;
            foreach (DataRow data in ds.Tables[0].Rows)
            {
                // dr = ds.Tables[0].Rows[pos];
                q = new QuestionAnswers(Convert.ToInt32(data["examid"]), Convert.ToInt32(data["qid"]),data["sname"].ToString(), data["question"].ToString(), Convert.ToInt32(data["answer"]));
                questionsAnswers.Add(q);
            }

        } // end of GetQuestions()
    }
}// end of Class
