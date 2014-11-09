using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace AuditMgtNew
{
    public partial class AuditLevelDP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            foreach (ListItem item in contentcheck.Items)
            {
                if (item.Selected)
                {
                    if (contentcheck.SelectedValue == "First Tier Audit")
                    {
                        // Response.Redirect("JMIndicatorsCorporate.aspx");

                        Response.Redirect("DPIndicatorsCorporate.aspx");
                        //  Session["location"] = "Jumeirah Group Corporate";

                    }
                    else
                        if (contentcheck.SelectedValue == "Second Tier Audit")
                        {

                            //  Response.Redirect("StartAuditJMTier2.aspx");
                            Response.Redirect("DPIndicators.aspx");
                            //  Session["location"] = "";

                        }
                }
            }

        }

        protected void btnlogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();

            Session.Abandon();

            Response.Redirect("Login.aspx");
        }

        protected void Image1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("HomePageDP.aspx");

        }
    }
}