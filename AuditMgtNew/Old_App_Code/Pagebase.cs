using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuditMgtNew
{
    public class Pagebase : System.Web.UI.Page
    {
        protected override void OnPreRender(EventArgs e)
        {

            base.OnPreRender(e);

            AutoRedirect();

        }

        public void AutoRedirect()
        {

            int int_MilliSecondsTimeOut = (this.Session.Timeout * 60000);

            string str_Script = @"

   <script type='text/javascript'> 

    intervalset = window.setInterval('Redirect()'," + int_MilliSecondsTimeOut.ToString() + @");

    function Redirect()

    {

       alert('Your session has been expired and system redirects to login page now.!\n\n');

       window.location.href='/Login.aspx'; 

    }

</script>";

            ClientScript.RegisterClientScriptBlock(this.GetType(), "Redirect", str_Script);

        }

    }
}