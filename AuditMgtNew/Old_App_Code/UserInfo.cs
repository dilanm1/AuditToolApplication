using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserInfo
/// </summary>
[Serializable()]
public class UserInfo
{
    #region variables
    private string name;
	private string dateofbirth;
	private string birthplace;
    private string place;
	private string languages;
	private string aboutme;
	private string employer;
	private string project;
	private string designation;
    private string university;
    #endregion variables

    #region Properties
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string DateofBirth
    {
        get { return dateofbirth; }
        set { dateofbirth = value; }
    }

    public string Languages
    {
        get { return languages; }
        set { languages = value; }
    }

    public string BirthPlace 
    {
        get { return birthplace; }
        set { birthplace = value; }
    }

    public string Place
    {
        get { return place; }
        set { place = value; }
    }

    public string AboutMe
    {
        get { return aboutme; }
        set { aboutme = value; }
    }

    public string Employer
    {
        get { return employer; }
        set { employer = value; } 
    }

    public string Project
    {
        get { return project; }
        set { project = value; }
    }

    public string Designation
    {
        get { return designation; }
        set { designation = value; }
    }

    public string University
    {
        get { return university; }
        set { university = value; }
    }

    #endregion Properties

    #region Constructors
    public UserInfo()
	{
		//
		// TODO: Add constructor logic here
		//
    }

    public UserInfo(string _name, string _dateofbirth, string _birthplace, string _place, string _languages, string _aboutme, string _employer,string _project, string _designation, string _university)
    {
        name = _name;
        dateofbirth = _dateofbirth;
        birthplace = _birthplace;
        place = _place;
        languages = _languages;
        aboutme = _aboutme;
        employer = _employer;
        project = _project;
        designation = _designation;
        university = _university;
    }
    #endregion Constructors
}