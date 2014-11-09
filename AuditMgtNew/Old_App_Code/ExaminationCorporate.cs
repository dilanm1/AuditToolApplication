using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace AuditMgtNew.Old_App_Code
{
    public class ExaminationCorporate
    {
        public int SIZE;
        public int mid;
        public String location;
        public int sid;
        public String sname;
        public int ncans;
        public List<Question> questions;
        public DateTime StartTime;
        public int curpos = 0;
        public Decimal score;


        public ExaminationCorporate(int mid, int sid, String sname, String location)
        {
            this.mid = mid;
            this.location = location;
            this.sid = sid;
            this.sname = sname;
            StartTime = DateTime.Now;
        }

        public void GetQuestions()
        {

            SqlConnection con = new SqlConnection(DBUtil.ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select sid,qid,question,ref,guid from tblQuestionsJMSubCorp where sid = " + sid, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "questions");
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
            questions = new List<Question>();
            //  DataRow dr;
            Question q;
            foreach (DataRow data in ds.Tables[0].Rows)
            {
                // dr = ds.Tables[0].Rows[pos];
                q = new Question(Convert.ToInt32(data["sid"]), data["qid"].ToString(), data["question"].ToString(), data["guid"].ToString(), data["ref"].ToString());
                questions.Add(q);
            }

        }
    }
}


