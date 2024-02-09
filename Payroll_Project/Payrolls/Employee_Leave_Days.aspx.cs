using Payroll_Project.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Payroll_Project.Masters
{
    public partial class Employee_Leave_Days : System.Web.UI.Page
    {
        Dal dal = new Dal();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
          calEmployeeOn.Format = dal.dateFormat;
            if (!IsPostBack)
            {
                BindEmployeeId();
                BindLeaves();
                BindWorkLocation();
                Bindgrid();
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
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ddlworklocation.SelectedIndex == 0)
            {
                ShowPopUpMsg("Please select Work Location");
            }
            else if (ddlEmployeNo.SelectedIndex == 0)
            {
                ShowPopUpMsg("Please select Employee Number");
            }

            else if (txtEmployeeName.Text == "")
            {
                ShowPopUpMsg("Please enter Employee Name");
            }
            else if (ddlLeaveName.SelectedIndex == 0)
            {
                ShowPopUpMsg("Please select Leave Name");
            }
            else if (txtEmployeeOn.Text == "")
            {
                ShowPopUpMsg("Please enter Employee On");
            }
            else if (txtNoofDays.Text == "")
            {
                ShowPopUpMsg("Please enter No of Days");
            }
            //else if (txtBalancedNoofDays.Text == "")
            //{
            //    ShowPopUpMsg("please enter Balanced No of Days");
            //}
            else if (txtTotalNoofDays.Text == "")
            {
                txtTotalNoofDays.Text = "0";
            }

            else
            {
                DateTime EmployeeOn = DateTime.ParseExact(txtEmployeeOn.Text, dal.dateFormat, null);
                dt = dal.Fun_Employee_Leave_InsUpd(Convert.ToInt32(ddlEmployeNo.SelectedValue), ddlEmployeNo.SelectedItem.ToString(), txtEmployeeName.Text, Convert.ToInt32(ddlLeaveName.SelectedValue), ddlLeaveName.SelectedItem.ToString(), EmployeeOn, Convert.ToInt32(txtNoofDays.Text), 0, Convert.ToInt32(txtTotalNoofDays.Text), ddlcompanylocation.SelectedValue, Convert.ToInt32(ddlworklocation.SelectedValue), "Insert");
                if (dt.Rows[0]["result"].ToString() == "1")
                {
                    ShowPopUpMsg("Employee Leave Created Successfully");
                    Bindgrid();
                    Clear();
                }
            }
        }
        public void Bindgrid()
        {
           
            dt = dal.Fun_Employee_Leave_Get("bind");
            grdEmployeeLeaves.DataSource = dt;
            grdEmployeeLeaves.DataBind();
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            Clear();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
          
            if (ddlworklocation.SelectedIndex == 0)
            {
                ShowPopUpMsg("Please select Work Location");
            }
            else if (ddlEmployeNo.SelectedIndex == 0)
            {
                ShowPopUpMsg("Please select Employee Number");
            }

            else if (txtEmployeeName.Text == "")
            {
                ShowPopUpMsg("Please enter Employee Name");
            }
            else if (ddlLeaveName.SelectedIndex == 0)
            {
                ShowPopUpMsg("Please select Leave Name");
            }
            else if (txtEmployeeOn.Text == "")
            {
                ShowPopUpMsg("Please enter Employee On");
            }
            else if (txtNoofDays.Text == "")
            {
                ShowPopUpMsg("Please enter No of Days");
            }
            //else if (txtBalancedNoofDays.Text == "")
            //{
            //    ShowPopUpMsg("please enter Balanced No of Days");
            //}
            else if (txtTotalNoofDays.Text == "")
            {
                txtTotalNoofDays.Text = "0";
            }

            else
            {
                DateTime EmployeeOn = DateTime.ParseExact(txtEmployeeOn.Text, dal.dateFormat, null);
                dt = dal.Fun_Employee_Leave_InsUpd(Convert.ToInt32(ddlEmployeNo.SelectedValue), ddlEmployeNo.SelectedItem.ToString(), txtEmployeeName.Text, Convert.ToInt32(ddlLeaveName.SelectedValue), ddlLeaveName.SelectedItem.ToString(), EmployeeOn, Convert.ToInt32(txtNoofDays.Text), 0, Convert.ToInt32(txtTotalNoofDays.Text), ddlcompanylocation.SelectedValue, Convert.ToInt32(ddlworklocation.SelectedValue), "Update");
                if (dt.Rows[0]["result"].ToString() == "1")
                {
                    ShowPopUpMsg("Employee Leave Updated Successfully");
                    Bindgrid();
                    Clear();
                }
            }
        }

        protected void btnList_Click(object sender, EventArgs e)
        {
            Bindgrid();
        }
        protected void ddlEmployeNo_SelectedIndexChanged(object sender, EventArgs e)
        {

            dt = dal.Fun_Emp_Details_GetbyReferenceId(Convert.ToInt32(ddlEmployeNo.SelectedValue.ToString()));
            txtEmployeeName.Text = dt.Rows[0]["first_name"].ToString() + " "+ dt.Rows[0]["middle_name"].ToString() + " "+ dt.Rows[0]["last_name"].ToString();
            txtEmployeeOn.Text = System.Convert.ToDateTime(dt.Rows[0]["employed_on"]).ToString(dal.dateFormat);
        }

       
        public void BindEmployeeId()
        {
            dt = dal.Fun_Emp_Details_Get("");
            ddlEmployeNo.DataSource = dt;
            ddlEmployeNo.DataTextField = "employee_no";
            ddlEmployeNo.DataValueField = "ReferenceId";
            ddlEmployeNo.DataBind();
            ddlEmployeNo.Items.Insert(0, new ListItem("Select", "0"));

        }

        public void BindLeaves()
        {
            dt = dal.Fun_Leaves(0,null,0, "Select");
            ddlLeaveName.DataSource = dt;
            ddlLeaveName.DataTextField = "Leave_name";
            ddlLeaveName.DataValueField = "LeaveId";
            ddlLeaveName.DataBind();
            ddlLeaveName.Items.Insert(0, new ListItem("Select", "0"));

        }

        public void BindWorkLocation()
        {
            dt = dal.Fun_WorkLocation(0,null, null, "bind");
            ddlworklocation.DataSource = dt;
            ddlworklocation.DataTextField = "working_location";
            ddlworklocation.DataValueField = "sno";
            ddlworklocation.DataBind();
            ddlworklocation.Items.Insert(0, new ListItem("Select", "0"));

        }

        public void Clear()
        {
            ddlworklocation.SelectedIndex = 0;
            BindEmployeeId();
            ddlEmployeNo.SelectedIndex = 0;
            txtEmployeeName.Text = "";
            BindLeaves();
            ddlLeaveName.SelectedIndex = 0;
            txtEmployeeOn.Text = "";
            txtNoofDays.Text = "";
            txtBalancedNoofDays.Text = "";
            txtTotalNoofDays.Text = "";
            btnSave.Visible = true;
            btnUpdate.Visible = false;
        }

        protected void ddlLeaveName_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt = dal.Fun_Leaves(Convert.ToInt32(ddlLeaveName.SelectedValue), null, 0, "SelectById");
            txtNoofDays.Text = dt.Rows[0]["no_days"].ToString();
            txtTotalNoofDays.Text = dt.Rows[0]["no_days"].ToString();
        }

        protected void grdEmployeeLeaves_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ddlLeaveName.Items.Insert(0, new ListItem("Select", "0"));
            //BindEmployeeId();
            //BindLeaves();
            //BindWorkLocation();
            hfId.Value = (grdEmployeeLeaves.SelectedRow.FindControl("lblsno") as Label).Text;
            ddlworklocation.SelectedValue = (grdEmployeeLeaves.SelectedRow.FindControl("lblWorkLocation") as Label).Text;
            ddlEmployeNo.SelectedValue = (grdEmployeeLeaves.SelectedRow.FindControl("lblReferenceId") as Label).Text;
            txtEmployeeName.Text = (grdEmployeeLeaves.SelectedRow.FindControl("lblEmpName") as Label).Text;
            ddlLeaveName.SelectedValue = (grdEmployeeLeaves.SelectedRow.FindControl("lblleaveId") as Label).Text;
            txtNoofDays.Text = (grdEmployeeLeaves.SelectedRow.FindControl("lblNoofDays") as Label).Text;
            txtEmployeeOn.Text = (grdEmployeeLeaves.SelectedRow.FindControl("lblEmpOn") as Label).Text;
            //txtTotalNoofDays.Text = (grdEmployeeLeaves.SelectedRow.FindControl("lblTotaldays") as Label).Text;
            btnSave.Visible = false;
            btnUpdate.Visible = true;
        }

        protected void grdEmployeeLeaves_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void grdEmployeeLeaves_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label lblEmpOn = (e.Row.FindControl("lblEmpOn") as Label);
                DateTime date = Convert.ToDateTime(lblEmpOn.Text);
                lblEmpOn.Text = date.ToString(dal.dateFormat);


            }
        }
    }
}