using System;
public class Question
{
    public String question;
    public String guid, refe, qid, evidence, comments, action;
  
    public int sid, answer;



    public int SubjectId
    {
        get { return sid; }
    }

    public String QuestionId
    {
        get { return qid; }
    }

    public String QuestionText
    {
        get { return question; }
    }
    //public String Location
    //{
    //    get { return location; }
    //}

    public String Guid
    {
        get { return guid; }
    }

    public String Refe
    {
        get { return refe; }
    }

    public int Answer
    {
        get { return answer; }
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

    //public String CorrectAnswer
    //{
    //    get { return cans; }
    //}

    //public int YourAnswer
    //{
    //    get { return answer; }
    //}
 


    public Question(int sid, string qid, String question, String guid, String refe)
    {
        this.sid = sid;
        this.qid = qid;
       // this.location = location;
        this.question = question;
        //this.ans1 = ans1;
        //this.ans2 = ans2;
        //this.ans3 = ans3;
        //this.ans4 = ans4;
        //this.cans = cans;
        this.guid = guid;
        this.refe = refe;
     //   this.answer = answer;
      //  this.comments = comments;
     //   this.evidence = evidence;

        //public bool IsCorrect()
        //{
        //    return answer.Equals(cans);
        //}

    }
}

