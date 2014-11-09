using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditMgtNew
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblName.Text = "Welcome To " + Session["fullname"];
            lblDate.Text = "Lasted Visited At : " + Session["dlv"];
            Response.Redirect("MainPage.aspx");
        }
    }
}