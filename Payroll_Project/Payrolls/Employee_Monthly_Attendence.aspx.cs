using Payroll_Project.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Payroll_Project.Payrolls
{
    public partial class Employee_Monthly_Attendence : System.Web.UI.Page
    {
        Dal dal = new Dal();
        DataTable dt = new DataTable();
        int days = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            txtYear.Text = DateTime.Now.Year.ToString();
            if (!IsPostBack)
            {
                // BindCompanyLocation();
                BindWorkLocation();
            }
        }

        private void ShowPopUpMsg(string msg)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("alert('");
            sb.Append(msg.Replace("\n", "\\n").Replace("\r", "").Replace("'", "\\'"));
            sb.Append("');");
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "showalert", sb.ToString(), true);
        }
        protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Text = "";

            days = DaysInMonth(ddlMonth.SelectedItem.ToString());

            txtCompanyWokringDays.Text = days.ToString();

            grdDetails.Visible = false;
            grdMonthlyAttendence.Visible = true;
            BindGrdidEmployee();
            foreach (GridViewRow row in grdMonthlyAttendence.Rows)
            {
                Label lbldays = (Label)row.FindControl("lblWorkDays");
                lbldays.Text = days.ToString();
            }

        }

        public int DaysInMonth(string Month)
        {
            switch (Month)
            {
                case "January":
                    {
                        days = 31;
                        break;
                    }
                case "February":
                    {
                        // k=int.Parse(txtyear.Text ) %4;
                        int febmonth = int.Parse(txtYear.Text) % 4;
                        if (febmonth == 0)
                        {
                            days = 29;
                        }
                        else
                        {
                            days = 28;
                        }

                        break;
                    }
                case "March":
                    {
                        days = 31;
                        break;
                    }

                case "April":
                    {
                        days = 30;
                        break;
                    }
                case "May":
                    {
                        days = 31;
                        break;
                    }
                case "June":
                    {
                        days = 30;
                        break;
                    }
                case "July":
                    {
                        days = 31;
                        break;
                    }
                case "August":
                    {
                        days = 31;
                        break;
                    }
                case "September":
                    {
                        days = 30;
                        break;
                    }
                case "October":
                    {
                        days = 31;
                        break;
                    }
                case "November":
                    {
                        days = 30;
                        break;
                    }
                case "December":
                    {
                        days = 31;
                        break;
                    }

                    //default:

            }
            return days;
        }

        protected void ddlcompanylocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindWorkLocation();
        }

        public void BindWorkLocation()
        {
            dt = dal.Fun_WorkLocation(0,null,null,"bind");
            ddlworklocation.DataSource = dt;
            ddlworklocation.DataTextField = "working_location";
            ddlworklocation.DataValueField = "sno";
            ddlworklocation.DataBind();
            ddlworklocation.Items.Insert(0, new ListItem("Select", "0"));

        }


        //public void BindCompanyLocation()
        //{
        //    dt = dal.Fun_CompnayLocation("bindb");
        //    ddlcompanylocation.DataSource = dt;
        //    ddlcompanylocation.DataTextField = "location_name";
        //    ddlcompanylocation.DataValueField = "location_code";
        //    ddlcompanylocation.DataBind();
        //    ddlcompanylocation.Items.Insert(0, new ListItem("Select", "0"));

        //}


        public void BindGrdidEmployee()
        {
            dt = dal.Fun_Emp_Details_Get("");
            grdMonthlyAttendence.DataSource = dt;
            grdMonthlyAttendence.DataBind();
        }

        //protected void grdEmployees_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    grdEmployees.PageIndex = e.NewPageIndex;
        //    BindGrdidEmployee();
        //}

        protected void txtPresentDays_TextChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in grdMonthlyAttendence.Rows)
            {
                TextBox txtPresentDays = (TextBox)row.FindControl("txtPresentDays");
                Label lblWorkDays = (Label)row.FindControl("lblWorkDays");
                Label lblAbsentDays = (Label)row.FindControl("lblAbsentDays");

                if (txtPresentDays.Text != "")
                {

                    int workingdays = Convert.ToInt32(lblWorkDays.Text);
                    int presentdays = Convert.ToInt32(txtPresentDays.Text);
                    int absentdays = workingdays - presentdays;
                    lblAbsentDays.Text = absentdays.ToString();
                }


            }


        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            clear();
        }

        protected void lnkMonth_Click(object sender, EventArgs e)
        {


        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ddlMonth.SelectedIndex == 0)
            {
                ShowPopUpMsg("Please select month");
            }
            else if (ddlcompanylocation.SelectedIndex == 0)
            {
                ShowPopUpMsg("Please select Company Location");
            }
            else if (ddlworklocation.SelectedIndex == 0)
            {
                ShowPopUpMsg("Please select Work Location");
            }
            else
            {
                dt = dal.Fun_EmployeeMonthlyAttendence_InsUpd(Convert.ToInt32(txtYear.Text), ddlMonth.SelectedValue, ddlcompanylocation.SelectedItem.ToString(), ddlworklocation.SelectedItem.ToString(), txtCompanyWokringDays.Text, "Insert");
                int sno = Convert.ToInt32(dt.Rows[0]["sno"]);
                if (sno == 0)
                {
                    ShowPopUpMsg("Attendence for this month is already generated");
                }
                else
                {
                    foreach (GridViewRow row in grdMonthlyAttendence.Rows)
                    {

                        string employeeno = row.Cells[1].Text;
                        string firstname = row.Cells[2].Text;

                        TextBox txtPresentDays = (TextBox)row.FindControl("txtPresentDays");
                        if (txtPresentDays.Text == "")
                        {
                            txtPresentDays.Text = "0";
                        }

                        Label lblWorkDays = (Label)row.FindControl("lblWorkDays");
                        if (lblWorkDays.Text == "")
                        {
                            lblWorkDays.Text = "0";
                        }
                        Label lblLeaveDays = (Label)row.FindControl("lblLeaveDays");
                        //if (lblLeaveDays.Text == "")
                        //{
                        //    lblLeaveDays.Text = "0";
                        //}
                        Label lblAbsentDays = (Label)row.FindControl("lblAbsentDays");
                        if (lblAbsentDays.Text == "")
                        {
                            lblAbsentDays.Text = "0";
                        }
                        TextBox txtComments = (TextBox)row.FindControl("txtComments");
                        Label lblReferenceId = (Label)row.FindControl("lblReferenceId");


                        dt = dal.Fun_EmployeeMonthlyAttendence_Details_InsUpd(sno, employeeno, firstname, null, Convert.ToInt32(txtPresentDays.Text), Convert.ToInt32(lblAbsentDays.Text), txtComments.Text, Convert.ToInt32(lblReferenceId.Text), "Insert");
                        if (dt.Rows.Count > 0)
                        {
                            ShowPopUpMsg("Attendence for this  month successfully generated");
                        }
                        clear();
                    }
                }


            }

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            grdDetails.Visible = true;
            grdMonthlyAttendence.Visible = false;
            grdMonthlyAttendenceReport.Visible = false;

            if (txtSearch.Text == "")
            {
                ShowPopUpMsg("Please enter Search month or year");
                grdDetails.Visible = false;
                //  BindDetailsGrid(0, null, "AllRecords");
            }
            else
            {
                int intValue;
                if (int.TryParse(txtSearch.Text, out intValue))
                {
                    BindDetailsGrid(intValue, null, "SearchByYear");
                    txtYear.Text = txtSearch.Text;
                }

                else
                {
                    BindDetailsGrid(0, txtSearch.Text, "SearchByMonth");
                }

            }
        }

        public void BindDetailsGrid(int year, string Month, string Trans)
        {
            dt = dal.Fun_Emp_Monhly_Attendence(year, Month, Trans);
            grdDetails.DataSource = dt;
            grdDetails.DataBind();
        }

        public void BindGridMonthlyAttendenceReport(int Year, string Month)
        {
            dt = dal.Fun_Emp_Monhly_Attendence(Year, Month, "Report");
            grdMonthlyAttendenceReport.DataSource = dt;
            grdMonthlyAttendenceReport.DataBind();
        }
        public void clear()
        {
            //grdMonthlyAttendence.DataSource = null;
            //grdMonthlyAttendence.DataBind();
            // grdEmployees.Visible = false;
            grdMonthlyAttendence.Visible = false;
            grdDetails.Visible = false;
            grdMonthlyAttendenceReport.Visible = false;
            ddlcompanylocation.SelectedIndex = 1;
            ddlworklocation.SelectedIndex = 0;
            ddlMonth.SelectedIndex = 0;
            ddlMonth.Enabled = true;
            txtCompanyWokringDays.Text = "";
            txtSearch.Text = "";
        }


        protected void grdMonthlyAttendence_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label lblReferenceId = (e.Row.FindControl("lblReferenceId") as Label);
                int ReferenceId = Convert.ToInt32(lblReferenceId.Text);
                dt = dal.Fun_Emp_Monhly_Attendence_Details(ReferenceId, Convert.ToInt32(txtYear.Text), ddlMonth.SelectedValue);
                if (dt.Rows.Count > 0)
                {
                    Label lblAbsentDays = e.Row.FindControl("lblAbsentDays") as Label;
                    TextBox txtPresentDays = e.Row.FindControl("txtPresentDays") as TextBox;
                    TextBox txtComments = e.Row.FindControl("txtComments") as TextBox;
                    txtPresentDays.Text = dt.Rows[0][4].ToString();
                    lblAbsentDays.Text = dt.Rows[0][5].ToString();
                    txtComments.Text = dt.Rows[0][6].ToString();
                }

            }

        }



        protected void grdDetails_SelectedIndexChanged(object sender, EventArgs e)
        {

            LinkButton lnkMonth = (LinkButton)grdDetails.SelectedRow.Cells[1].FindControl("lnkMonth");
            string Year = grdDetails.SelectedRow.Cells[1].Text;
            txtYear.Text = Year;
            ddlMonth.SelectedValue = lnkMonth.Text.ToString();
            ddlMonth.Enabled = false;
            grdDetails.Visible = false;
            grdMonthlyAttendenceReport.Visible = true;
            days = DaysInMonth(ddlMonth.SelectedItem.ToString());
            txtCompanyWokringDays.Text = days.ToString();
            BindGridMonthlyAttendenceReport(Convert.ToInt32(Year), lnkMonth.Text.ToString());


        }



        protected void grdMonthlyAttendenceReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdMonthlyAttendenceReport.PageIndex = e.NewPageIndex;
            BindGridMonthlyAttendenceReport(Convert.ToInt32(txtYear.Text), ddlMonth.SelectedItem.ToString());
        }

        protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdDetails.PageIndex = e.NewPageIndex;
            BindDetailsGrid(Convert.ToInt32(txtYear.Text), ddlMonth.SelectedItem.ToString(), "AllRecords");
        }

        protected void btnList_Click(object sender, EventArgs e)
        {
            grdDetails.Visible = true;
            grdMonthlyAttendence.Visible = false;
            BindDetailsGrid(0, null, "AllRecords");
        }
    }
}