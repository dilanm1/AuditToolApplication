using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Web.Security;


namespace AuditMgtNew
{
    public partial class AddAuditLocation : System.Web.UI.Page
    {
        // string location;
        public string GetName
        {
            get { return DropDownList1.SelectedItem.Text.ToString(); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
           // Button1.Text = "OK";

            Label52.Visible = false;
            TextBox123.Text = "Jumeirah Group Corporate";
                                 

            foreach (ListItem item in contentcheck.Items)
            {
                if (item.Selected)
                {
                    if (contentcheck.SelectedValue == "Add Corporate")
                    {
                        // Response.Redirect("JMIndicatorsCorporate.aspx");
                        DropDownList1.Visible = false;
                        DropDownList2.Visible = false;
                        DropDownList2.Enabled = false;
                        //  Session["location"] = DropDownList1.SelectedItem.Text;

                    }
                    else

                        if (contentcheck.SelectedValue == "Add SBU")
                        {
                            // Response.Redirect("JMIndicatorsCorporate.aspx");
                            DropDownList1.Visible = true;
                            DropDownList2.Visible = false;
                            DropDownList2.Enabled = false;
                            //  Session["location"] = DropDownList1.SelectedItem.Text;

                        }
                        else
                            if (contentcheck.SelectedValue == "Add Sub SBU")
                                DropDownList2.Visible = true;
                    DropDownList2.Enabled = true;
                    //   Session["location"] = DropDownList2.SelectedItem.Text;
                }

                if (!IsPostBack)
                {
                    BindBusinessdropdown();
                    BindBusinessNames();


                }
            }
        }


              
        protected void BindBusinessdropdown()
        {
            try
            {
                //conenction path for database
                SqlConnection con = new SqlConnection(DBUtil.ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Business", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                con.Close();
                DropDownList8.DataSource = ds;
                DropDownList8.DataTextField = "name";
                DropDownList8.DataValueField = "BusinessID";
                DropDownList8.DataBind();
                // DropDownList8.Items.Insert(0, new ListItem("--Select--", "0"));
                //  DropDownList1312.Items.Insert(0, new ListItem("--Select--", "0"));
                // ddlRegion.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            catch (Exception ex)
            {
                // Handle the error
            }

            DropDownList8.Items.Insert(0, new ListItem("<Select>", "0"));
        }

        protected void BindBusinessNames()
        {
            try
            {

                SqlConnection con = new SqlConnection(DBUtil.ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from SubVertical WHERE VerticalID= " + 1, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                con.Close();
                DropDownList1.DataSource = ds;
                DropDownList1.DataTextField = "name";
                //   DropDownList1.DataValueField = "SubVerticalID";
                DropDownList1.DataValueField = "SubVerticalID";
                DropDownList1.DataBind();
                //  DropDownList1.Items.Insert(0, "");
                //   DropDownList1.Items.Insert(0, new ListItem("--Select--", "0"));
                //   DropDownList2.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            catch (Exception ex)
            {
                // Handle the error
            }
            DropDownList1.Items.Insert(0, new ListItem("<Select>", "0"));

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            foreach (ListItem item in contentcheck.Items)
            {
                if (item.Selected)
                {



                    if (contentcheck.SelectedValue == "Add Corporate")
                    {
                        SqlConnection conn = new SqlConnection(DBUtil.ConnectionString);
                        DataTable dt = new DataTable();
                        try
                        {
                            conn.Open();


                            String sql = "SELECT location FROM tblBuilding WHERE location = @location";
                            SqlCommand cmd = new SqlCommand(sql, conn);
                            cmd.Parameters.AddWithValue("@location", "Jumeirah Group Corporate");
                            SqlDataAdapter ad = new SqlDataAdapter(cmd);
                            ad.Fill(dt);


                            if (dt.Rows.Count > 0)
                            {
                                Label52.Text = "Location Already Exist!";
                                Label52.Visible = true;
                                //CALL the UPDATE method here and pass its parameter values
                                //UpdateInfo("Value1",location);
                            }
                            else
                            {
                                SqlConnection con7 = new SqlConnection(DBUtil.ConnectionString);
                                con7.Open();
                                SqlCommand cmd7 = new SqlCommand("select locationid from tbllocation where location ='" + "Jumeirah Group Corporate" + "'", con7);
                                int locationid = (Int32)cmd7.ExecuteScalar();

                                //SqlCommand command = conn.CreateCommand();
                                //command.CommandText = "INSERT INTO personTraining (name,training_id, training,trainingDate,trainingHour, trainingSession)SELECT @Val1,training_id,training,trainingDate,trainingHour,trainingSession FROM tbl_training WHERE  training_id = @trainingID";

                                //command.Parameters.AddWithValue("@trainingID", dateSelected);
                                //command.ExecuteNonQuery();


                                string _query = "INSERT INTO tblBuilding (location,locationid,Verticalid,VerticalName,Unit,SubUnit,Address,Nature,Sector,Usage,Number,Square,year,Emp,Visitors,Guests,Residents,LeadAuditor,Auditor1,Auditor2,Auditor3,CEO,COO,DM,DE,Other) Values (@location,@loc,@vid,@name,@unit,@subunit,@address,@nature,@sector,@usage,@no,@sq,@year,@emp,@visitors,@guests,@residents,@lead,@aud1,@aud2,@aud3,@ceo,@coo,@dm,@de,@other)";
                                String val;
                                if (!String.IsNullOrEmpty(DropDownList2.SelectedValue))
                                {
                                    val = DropDownList2.SelectedValue;
                                }


                                using (SqlConnection conn3 = new SqlConnection(DBUtil.ConnectionString))
                                {

                                    using (SqlCommand comm = new SqlCommand())
                                    {
                                        //string location = Session.

                                        comm.Connection = conn3;
                                        comm.CommandType = CommandType.Text;
                                        comm.CommandText = _query;
                                        comm.Parameters.AddWithValue("@location", "Jumeirah Group Corporate");
                                        comm.Parameters.AddWithValue("@loc", locationid);
                                        comm.Parameters.AddWithValue("@vid", 1);
                                        comm.Parameters.AddWithValue("@name", TextBox123.Text);
                                        comm.Parameters.AddWithValue("@unit", "");
                                        comm.Parameters.AddWithValue("@subunit", "");
                                        comm.Parameters.AddWithValue("@address", TextBox321.Text);
                                        comm.Parameters.AddWithValue("@nature", DropDownList8.SelectedItem.Text);
                                        comm.Parameters.AddWithValue("@sector", DropDownList1312.SelectedItem.Text);
                                        comm.Parameters.AddWithValue("@usage", DropDownList1443.SelectedItem.Text);
                                        comm.Parameters.AddWithValue("@no", TextBox1c.Text);
                                        comm.Parameters.AddWithValue("@sq", TextBox2c.Text);
                                        comm.Parameters.AddWithValue("@year", TextBox3c.Text);
                                        comm.Parameters.AddWithValue("@emp", TextBox7.Text);
                                        comm.Parameters.AddWithValue("@visitors", TextBox8.Text);
                                        comm.Parameters.AddWithValue("@guests", TextBox5.Text);
                                        comm.Parameters.AddWithValue("@residents", TextBox6.Text);
                                        comm.Parameters.AddWithValue("@lead", TextBox1b.Text);
                                        comm.Parameters.AddWithValue("@aud1", TextBox2bd.Text);
                                        comm.Parameters.AddWithValue("@aud2", TextBox3b.Text);
                                        comm.Parameters.AddWithValue("@aud3", TextBox5b.Text);
                                        comm.Parameters.AddWithValue("@ceo", TextBox1d.Text);
                                        comm.Parameters.AddWithValue("@coo", TextBox2d.Text);
                                        comm.Parameters.AddWithValue("@dm", TextBox1de.Text);
                                        comm.Parameters.AddWithValue("@de", TextBox2de.Text);
                                        comm.Parameters.AddWithValue("@other", TextBox3de.Text);


                                        try
                                        {
                                            conn3.Open();
                                            comm.ExecuteNonQuery();
                                            Label52.Text = "Location Added to the Database Sucessfully";
                                            Label52.Visible = true;
                                            //  ImageButton1.Visible = true;

                                            // Session["location"] = DropDownList1.SelectedItem.Text;


                                            //Response.Redirect("JMIndicators.aspx");
                                            //LabelAdd.Text = DropDownList1.SelectedItem.Text;
                                        }
                                        catch (SqlException ex)
                                        {
                                            Label52.Text = "Error Adding record to the Database!";
                                            Label52.Visible = true;
                                            Label52.ForeColor = Color.Red;
                                            // other codes here
                                            // do something with the exception
                                            // don't swallow it.
                                        }
                                    }
                                }
                            }
                        }

                        finally
                        {
                            conn.Close();

                        }
                    }
                    else 
                        if (contentcheck.SelectedValue == "Add SBU")
                        {
                            SqlConnection conna = new SqlConnection(DBUtil.ConnectionString);
                            DataTable dt1 = new DataTable();
                            try
                            {
                                conna.Open();


                                String sql = "SELECT location FROM tblBuilding WHERE location = @location";
                                SqlCommand cmd2 = new SqlCommand(sql, conna);
                                cmd2.Parameters.AddWithValue("@location", DropDownList1.SelectedItem.Text);
                                SqlDataAdapter ad1 = new SqlDataAdapter(cmd2);
                                ad1.Fill(dt1);


                                if (dt1.Rows.Count > 0)
                                {
                                    Label52.Text = "Location Already Exist!";
                                    Label52.Visible = true;
                                    //CALL the UPDATE method here and pass its parameter values
                                    //UpdateInfo("Value1",location);
                                }
                                else
                                {
                                    SqlConnection con7 = new SqlConnection(DBUtil.ConnectionString);
                                    con7.Open();
                                    SqlCommand cmd7 = new SqlCommand("select locationid from tbllocation where location ='" + DropDownList1.SelectedItem.Text + "'", con7);
                                    int locationid = (Int32)cmd7.ExecuteScalar();
                                    string name = DropDownList1.SelectedItem.Text;

                                    // string _connStr = "Data Source=DILAN-PC;Initial Catalog=master;Integrated Security=True";
                                    // string _query = "INSERT INTO [tblBuilding] (KnownAs,PostCode,OrderNo,ExCountry,OriginCountry,Quater,Security,Description,[Group],CNCode1,CNCode2,CNCode3,Regulation,Quantity,QuantityWords,Notes,Date,Place) values (@ref,@name,@order,@excountry,@orgcountry,@quater,@security,@des,@group,@cn1,@cn2,@cn3,@reg,@qty,@qtywords,@notes,@date,@date,@place)";
                                    // string _query = "INSERT INTO tblBuilding (Name,Unit,SubUnit,Address,Nature,Sector,Usage,Number,Square,year,Emp,Visitors,Guests,Residents,LeadAuditor,Auditor1,Auditor2,Auditor3,CEO,COO,DM,DE,Other) Values (@name,@unit,@subunit,@address,@nature,@sector,@usage,@no,@sq,@year,@use,@floors,@year,@emp,@visitors,@guests,@residents,@lead,@aud1,@aud2,@aud3,@ceo,@coo,@dm,@de,@other)";
                                    string _query = "INSERT INTO tblBuilding (location,locationid,Verticalid,VerticalName,Unit,SubUnit,Address,Nature,Sector,Usage,Number,Square,year,Emp,Visitors,Guests,Residents,LeadAuditor,Auditor1,Auditor2,Auditor3,CEO,COO,DM,DE,Other) Values (@location,@loc,@vid,@name,@unit,@subunit,@address,@nature,@sector,@usage,@no,@sq,@year,@emp,@visitors,@guests,@residents,@lead,@aud1,@aud2,@aud3,@ceo,@coo,@dm,@de,@other)";
                                    String val;
                                    if (!String.IsNullOrEmpty(DropDownList2.SelectedValue))
                                    {
                                        val = DropDownList2.SelectedItem.Text;
                                    }


                                    using (SqlConnection conn4 = new SqlConnection(DBUtil.ConnectionString))
                                    {

                                        using (SqlCommand comm = new SqlCommand())
                                        {
                                            //string location = Session.


                                            comm.Connection = conn4;
                                            comm.CommandType = CommandType.Text;
                                            comm.CommandText = _query;
                                            comm.Parameters.AddWithValue("@location", DropDownList1.SelectedItem.Text);
                                            comm.Parameters.AddWithValue("@loc", locationid);
                                            comm.Parameters.AddWithValue("@vid", 1);
                                            comm.Parameters.AddWithValue("@name", TextBox123.Text);
                                            comm.Parameters.AddWithValue("@unit", DropDownList1.SelectedItem.Text);
                                            comm.Parameters.AddWithValue("@subunit", "");
                                            comm.Parameters.AddWithValue("@address", TextBox321.Text);
                                            comm.Parameters.AddWithValue("@nature", DropDownList8.SelectedItem.Text);
                                            comm.Parameters.AddWithValue("@sector", DropDownList1312.SelectedItem.Text);
                                            comm.Parameters.AddWithValue("@usage", DropDownList1443.SelectedItem.Text);
                                            comm.Parameters.AddWithValue("@no", TextBox1c.Text);
                                            comm.Parameters.AddWithValue("@sq", TextBox2c.Text);
                                            comm.Parameters.AddWithValue("@year", TextBox3c.Text);
                                            comm.Parameters.AddWithValue("@emp", TextBox7.Text);
                                            comm.Parameters.AddWithValue("@visitors", TextBox8.Text);
                                            comm.Parameters.AddWithValue("@guests", TextBox5.Text);
                                            comm.Parameters.AddWithValue("@residents", TextBox6.Text);
                                            comm.Parameters.AddWithValue("@lead", TextBox1b.Text);
                                            comm.Parameters.AddWithValue("@aud1", TextBox2bd.Text);
                                            comm.Parameters.AddWithValue("@aud2", TextBox3b.Text);
                                            comm.Parameters.AddWithValue("@aud3", TextBox5b.Text);
                                            comm.Parameters.AddWithValue("@ceo", TextBox1d.Text);
                                            comm.Parameters.AddWithValue("@coo", TextBox2d.Text);
                                            comm.Parameters.AddWithValue("@dm", TextBox1de.Text);
                                            comm.Parameters.AddWithValue("@de", TextBox2de.Text);
                                            comm.Parameters.AddWithValue("@other", TextBox3de.Text);

                                            try
                                            {
                                                conn4.Open();
                                                comm.ExecuteNonQuery();
                                                Label52.Text = "Location Added to the Database Sucessfully";
                                                Label52.Visible = true;
                                               // Session["location"] = DropDownList1.SelectedItem.Text;

                                                // Response.Redirect("JMIndicators.aspx");
                                                //LabelAdd.Text = DropDownList1.SelectedItem.Text;
                                            }
                                            catch (SqlException ex)
                                            {
                                                Label52.Text = "Error Adding record to the Database";
                                                Label52.Visible = true;
                                                Label52.ForeColor = Color.Red;
                                                // other codes here
                                                // do something with the exception
                                                // don't swallow it.
                                            }
                                        }
                                    }
                                }
                            }
                            finally
                            {
                                conna.Close();

                            }
                        }

                        else
                            if (contentcheck.SelectedValue == "Add Sub SBU")
                            {
                                SqlConnection conns = new SqlConnection(DBUtil.ConnectionString);
                                DataTable dt2 = new DataTable();
                                try
                                {
                                    conns.Open();


                                    String sql = "SELECT location FROM tblBuilding WHERE location = @location";
                                    SqlCommand cmd = new SqlCommand(sql, conns);
                                    cmd.Parameters.AddWithValue("@location", DropDownList2.SelectedItem.Text);
                                    SqlDataAdapter ad2 = new SqlDataAdapter(cmd);
                                    ad2.Fill(dt2);


                                    if (dt2.Rows.Count > 0)
                                    {
                                        Label52.Text = "Location Already Exist!";
                                        Label52.Visible = true;
                                        //CALL the UPDATE method here and pass its parameter values
                                        //UpdateInfo("Value1",location);
                                    }
                                    else
                                    {





                                        SqlConnection con7 = new SqlConnection(DBUtil.ConnectionString);
                                        con7.Open();
                                        SqlCommand cmd7 = new SqlCommand("select locationid from tbllocation where location ='" + DropDownList2.SelectedItem.Text + "'", con7);
                                        int locationid = (Int32)cmd7.ExecuteScalar();
                                        string name = DropDownList2.SelectedItem.Text;

                                        // string _connStr = "Data Source=DILAN-PC;Initial Catalog=master;Integrated Security=True";
                                        // string _query = "INSERT INTO [tblBuilding] (KnownAs,PostCode,OrderNo,ExCountry,OriginCountry,Quater,Security,Description,[Group],CNCode1,CNCode2,CNCode3,Regulation,Quantity,QuantityWords,Notes,Date,Place) values (@ref,@name,@order,@excountry,@orgcountry,@quater,@security,@des,@group,@cn1,@cn2,@cn3,@reg,@qty,@qtywords,@notes,@date,@date,@place)";
                                        // string _query = "INSERT INTO tblBuilding (Name,Unit,SubUnit,Address,Nature,Sector,Usage,Number,Square,year,Emp,Visitors,Guests,Residents,LeadAuditor,Auditor1,Auditor2,Auditor3,CEO,COO,DM,DE,Other) Values (@name,@unit,@subunit,@address,@nature,@sector,@usage,@no,@sq,@year,@use,@floors,@year,@emp,@visitors,@guests,@residents,@lead,@aud1,@aud2,@aud3,@ceo,@coo,@dm,@de,@other)";
                                        string _query = "INSERT INTO tblBuilding (location,locationid,Verticalid,VerticalName,Unit,SubUnit,Address,Nature,Sector,Usage,Number,Square,year,Emp,Visitors,Guests,Residents,LeadAuditor,Auditor1,Auditor2,Auditor3,CEO,COO,DM,DE,Other) Values (@location,@loc,@vid,@name,@unit,@subunit,@address,@nature,@sector,@usage,@no,@sq,@year,@emp,@visitors,@guests,@residents,@lead,@aud1,@aud2,@aud3,@ceo,@coo,@dm,@de,@other)";
                                        String val;
                                        if (!String.IsNullOrEmpty(DropDownList2.SelectedValue))
                                        {
                                            val = DropDownList2.SelectedItem.Text;
                                        }


                                        using (SqlConnection conn5 = new SqlConnection(DBUtil.ConnectionString))
                                        {

                                            using (SqlCommand comm = new SqlCommand())
                                            {
                                                //string location = Session.


                                                comm.Connection = conn5;
                                                comm.CommandType = CommandType.Text;
                                                comm.CommandText = _query;
                                                comm.Parameters.AddWithValue("@location", DropDownList2.SelectedItem.Text);
                                                comm.Parameters.AddWithValue("@loc", locationid);
                                                comm.Parameters.AddWithValue("@vid", 1);
                                                comm.Parameters.AddWithValue("@name", TextBox123.Text);
                                                comm.Parameters.AddWithValue("@unit", "");
                                                comm.Parameters.AddWithValue("@subunit", name);
                                                comm.Parameters.AddWithValue("@address", TextBox321.Text);
                                                comm.Parameters.AddWithValue("@nature", DropDownList8.SelectedItem.Text);
                                                comm.Parameters.AddWithValue("@sector", DropDownList1312.SelectedItem.Text);
                                                comm.Parameters.AddWithValue("@usage", DropDownList1443.SelectedItem.Text);
                                                comm.Parameters.AddWithValue("@no", TextBox1c.Text);
                                                comm.Parameters.AddWithValue("@sq", TextBox2c.Text);
                                                comm.Parameters.AddWithValue("@year", TextBox3c.Text);
                                                comm.Parameters.AddWithValue("@emp", TextBox7.Text);
                                                comm.Parameters.AddWithValue("@visitors", TextBox8.Text);
                                                comm.Parameters.AddWithValue("@guests", TextBox5.Text);
                                                comm.Parameters.AddWithValue("@residents", TextBox6.Text);
                                                comm.Parameters.AddWithValue("@lead", TextBox1b.Text);
                                                comm.Parameters.AddWithValue("@aud1", TextBox2bd.Text);
                                                comm.Parameters.AddWithValue("@aud2", TextBox3b.Text);
                                                comm.Parameters.AddWithValue("@aud3", TextBox5b.Text);
                                                comm.Parameters.AddWithValue("@ceo", TextBox1d.Text);
                                                comm.Parameters.AddWithValue("@coo", TextBox2d.Text);
                                                comm.Parameters.AddWithValue("@dm", TextBox1de.Text);
                                                comm.Parameters.AddWithValue("@de", TextBox2de.Text);
                                                comm.Parameters.AddWithValue("@other", TextBox3de.Text);

                                                try
                                                {
                                                    conn5.Open();
                                                    comm.ExecuteNonQuery();
                                                    Label52.Text = "Location Added to the Database Sucessfully";
                                                    Label52.Visible = true;
                                                  //  Session["location"] = DropDownList2.SelectedItem.Text;

                                                    // Response.Redirect("JMIndicators.aspx");
                                                    //LabelAdd.Text = DropDownList1.SelectedItem.Text;
                                                }
                                                catch (SqlException ex)
                                                {
                                                    Label52.Text = "Error Adding record to the Database.Location Already Exists";
                                                    Label52.Visible = true;
                                                    Label52.ForeColor = Color.Red;
                                                    // other codes here
                                                    // do something with the exception
                                                    // don't swallow it.
                                                }
                                            }
                                        }
                                    }

                                }

                                finally
                                {
                                    conns.Close();

                                }
                            }
                    }
                }
            }
        

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddAuditLocation.aspx");

        }
        protected void DropDownList8_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                int CountryID1 = Convert.ToInt32(DropDownList8.SelectedValue);
                SqlConnection con = new SqlConnection(DBUtil.ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Sector where BusinessID=" + CountryID1, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                con.Close();
                DropDownList1312.DataSource = ds;
                DropDownList1312.DataTextField = "name";
                DropDownList1312.DataValueField = "SectorID";
                DropDownList1312.DataBind();
                // DropDownList1312.Items.Insert(0, new ListItem("--Select--", "0"));
                //if (DropDownList1312.SelectedValue == "0")
                //{
                //    ddlRegion.Items.Clear();
                //    ddlRegion.Items.Insert(0, new ListItem("--Select--", "0"));
                //}
            }
            catch (Exception ex)
            {

            }

        }
        protected void ClearTextBoxes(Control p1)
        {
            foreach (Control ctrl in p1.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox t = ctrl as TextBox;

                    if (t != null)
                    {
                        t.Text = String.Empty;
                    }
                }
                else
                {
                    if (ctrl.Controls.Count > 0)
                    {
                        ClearTextBoxes(ctrl);
                    }
                }
            }
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lbllocation.Text = DropDownList1.SelectedItem.Text.ToString();

                int CountryID = Convert.ToInt32(DropDownList1.SelectedValue);
                SqlConnection con2 = new SqlConnection(DBUtil.ConnectionString);
                con2.Open();
                SqlCommand cmd2 = new SqlCommand("select * from SubSubVerticalName where SubVertcalID=" + CountryID, con2);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd2);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);
                con2.Close();
                DropDownList2.DataSource = ds1;
                DropDownList2.DataTextField = "name";
                DropDownList2.DataValueField = "SubSubVerticalID";
                DropDownList2.DataBind();
                if (contentcheck.SelectedValue == "SBU Audit")
                {


                 
                    Session["Month"] = DropDownList1.SelectedItem.Text;


                    
                  
                }
            }
            catch (Exception ex)
            {

            }
            DropDownList2.Items.Insert(0, new ListItem("<Select>", "0"));
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {


            //  DropDownList2.Items.Insert(0, new ListItem("--Select--", "0"));
            //if (DropDownList1312.SelectedValue == "0")
            //{
            //    ddlRegion.Items.Clear();
            //    ddlRegion.Items.Insert(0, new ListItem("--Select--", "0"));
            //}
            lbllocation.Text = DropDownList2.SelectedItem.Text.ToString();

         


        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Session["ViewState"] = null;
            Response.Redirect("AddAuditLocation.aspx");
        }

        protected void btncontinue_Click(object sender, EventArgs e)
        {
            Response.Redirect("JMIndicators.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {

            foreach (ListItem item in contentcheck.Items)
            {
                if (item.Selected)
                {
                    if (contentcheck.SelectedValue == "SBU Audit")
                    {
                        string name = TextBox123.Text;
                        string _query = "INSERT INTO tblBuilding (locationid,VerticalName,Address,Nature,Sector,Usage,Number,Square,year,Emp,Visitors,Guests,Residents,LeadAuditor,Auditor1,Auditor2,Auditor3,CEO,COO,DM,DE,Other) Values (@locid,@vname,@address,@nature,@sector,@usage,@no,@sq,@year,@emp,@visitors,@guests,@residents,@lead,@aud1,@aud2,@aud3,@ceo,@coo,@dm,@de,@other)";
                        //  String val;
                        //if (!String.IsNullOrEmpty(DropDownList2.SelectedValue))
                        //{
                        //    val = DropDownList2.SelectedValue;
                        //}


                        using (SqlConnection conn = new SqlConnection(DBUtil.ConnectionString))
                        {

                            using (SqlCommand comm = new SqlCommand())
                            {
                                //string location = Session.


                                comm.Connection = conn;
                                comm.CommandType = CommandType.Text;
                                comm.CommandText = _query;
                                comm.Parameters.AddWithValue("@locid", 1);
                                comm.Parameters.AddWithValue("@vname", "Jumeirah Group Corporate");
                                //  comm.Parameters.AddWithValue("@uname", "");
                                //    comm.Parameters.AddWithValue("@subname", "");
                                //  comm.Parameters.AddWithValue("@subunit", DropDownList2.SelectedItem.Value);
                                comm.Parameters.AddWithValue("@address", TextBox321.Text);
                                comm.Parameters.AddWithValue("@nature", DropDownList8.SelectedItem.Text);
                                comm.Parameters.AddWithValue("@sector", DropDownList1312.SelectedItem.Text);
                                comm.Parameters.AddWithValue("@usage", DropDownList1443.SelectedItem.Text);
                                comm.Parameters.AddWithValue("@no", TextBox1c.Text);
                                comm.Parameters.AddWithValue("@sq", TextBox2c.Text);
                                comm.Parameters.AddWithValue("@year", TextBox3c.Text);
                                comm.Parameters.AddWithValue("@emp", TextBox7.Text);
                                comm.Parameters.AddWithValue("@visitors", TextBox8.Text);
                                comm.Parameters.AddWithValue("@guests", TextBox5.Text);
                                comm.Parameters.AddWithValue("@residents", TextBox6.Text);
                                comm.Parameters.AddWithValue("@lead", TextBox1b.Text);
                                comm.Parameters.AddWithValue("@aud1", TextBox2bd.Text);
                                comm.Parameters.AddWithValue("@aud2", TextBox3b.Text);
                                comm.Parameters.AddWithValue("@aud3", TextBox5b.Text);
                                comm.Parameters.AddWithValue("@ceo", TextBox1d.Text);
                                comm.Parameters.AddWithValue("@coo", TextBox2d.Text);
                                comm.Parameters.AddWithValue("@dm", TextBox1de.Text);
                                comm.Parameters.AddWithValue("@de", TextBox2de.Text);
                                comm.Parameters.AddWithValue("@other", TextBox3de.Text);

                                try
                                {
                                    conn.Open();
                                    comm.ExecuteNonQuery();
                                    Label52.Text = "Location Added to the Database Sucessfully";
                                    Label52.Visible = true;
                                    //  ImageButton1.Visible = true;

                                   // Session["location"] = name;


                                   // Response.Redirect("JMIndicators.aspx");
                                    //  Response.Redirect("JMIndicatorsCorporate.aspx");
                                    //LabelAdd.Text = DropDownList1.SelectedItem.Text;
                                }
                                catch (SqlException ex)
                                {
                                    Label52.Text = "Error Adding record to the Database";
                                    Label52.Visible = true;
                                    Label52.ForeColor = Color.Red;
                                    // other codes here
                                    // do something with the exception
                                    // don't swallow it.
                                }
                            }
                        }
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
    }
}