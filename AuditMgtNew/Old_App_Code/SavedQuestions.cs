using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuditMgtNew.Old_App_Code
{
    public class SavedQuestions
    {
        public String question;
        public int mid,sid,answer;
        public String qid,guid,refe,evidence, comments, action;


        public int MemberId
        {
            get { return mid; }
        }


        public int SubjectId
        {
            get { return sid; }
        }

        public String QuestionId
        {
            get { return qid; }
        }
        public String Guidance
        {
            get { return guid; }
        }
        public String Reference
        {
            get { return refe; }
        }
        public String Evidence
        {
            get { return evidence; }
        }
      

        public String Comments
        {
            get { return comments; }
        }
        public String Action
        {
            get { return action; }
        }
        public int Answer
        {
            get { return answer; }
        }
     


        public SavedQuestions(int mid,int sid, String qid,String question,String guid, String refe,int answer, String evidence, String comments, String action)
        {
            this.mid = mid;
            this.sid = sid;
            this.qid = qid;
            this.question = question;
            this.guid = guid;
            this.refe = refe;
            this.evidence = evidence;
            this.comments = comments;
            this.action = action;
            this.answer = answer;
           

        }
        //public bool IsCorrect()
        //{
        //    return answer.Equals(cans);
        //}

    }
}