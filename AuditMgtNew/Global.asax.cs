using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace AuditMgtNew
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            // If have lost session then need to force a re-login to ensure things are set-up again.
            // (pages don't like having a missing session).
            // Note: valid logins can out-last the session.

            // Requests for resources such as images *legitimately* have no session.
            if (Context == null || Context.Session == null) return;

            var userIsLoggedIn = User != null && User.Identity != null && User.Identity.IsAuthenticated;
            var haveSession = Session["mid"] != null;

            if (userIsLoggedIn && !haveSession)
            {
                FormsAuthentication.SignOut();
                Response.Redirect(FormsAuthentication.DefaultUrl);
            }
        }
    }
}