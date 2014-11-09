using System;
using System.Web;
using System.Configuration;
using System.Web.Configuration;

/// <summary>
/// Summary description for DBUtil
/// </summary>
public class DBUtil
{

    public static String ConnectionString
    {
        get
        {
            ConnectionStringSettings constr = WebConfigurationManager.ConnectionStrings["examConnectionString"];
            return constr.ConnectionString;
        }

    }
}
