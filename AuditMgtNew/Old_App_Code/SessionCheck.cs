using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using System.Net;
using System.Web.UI;

namespace AuditMgtNew.Old_App_Code
{
    public class SessionCheck : Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (Context.Session != null)
            {
                if (Session.IsNewSession)
                {
                    HttpCookie newSessionIdCookie = Request.Cookies["mid"];
                    if (newSessionIdCookie != null)
                    {
                        string newSessionIdCookieValue = newSessionIdCookie.Value;
                        if (newSessionIdCookieValue != string.Empty)
                        {
                            
                            Response.Redirect("Login.aspx");
                        }
                    }
                }
            }
        }
    }
}