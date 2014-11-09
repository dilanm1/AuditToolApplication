using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuditMgtNew.Old_App_Code
{
    public class QuestionAnswers
    {
     public String question;
     public int answer;
     public int examid;
     public int qid;
     public String sname;



     public int ExamId
     {
         get { return examid; }
     }
    public int QuestionId
    {
        get { return qid; }
    }

    public String SubName
    {
        get { return sname; }
    }


    public String QuestionText
    {
        get { return question; }
    }

   

    public int YourAnswer
    {
        get { return answer; }
    }

    public QuestionAnswers(int examid, int qid,String sname, String question,int answer)
	{
        this.examid = examid;
        this.qid = qid;
        this.sname = sname;
        this.question = question;
        this.answer = answer;
	}
   
    }
}


