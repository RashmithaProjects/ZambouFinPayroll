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
    public partial class LeaveDays : System.Web.UI.Page
    {
        Dal dal = new Dal();
        DataTable dt = new DataTable();

        private void ShowPopUpMsg(string msg)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("alert('");
            sb.Append(msg.Replace("\n", "\\n").Replace("\r", "").Replace("'", "\\'"));
            sb.Append("');");
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "showalert", sb.ToString(), true);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.Bindgrid();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtName.Text))
            {
                ShowPopUpMsg("Please enter Leave Name");
            }
            else if (string.IsNullOrEmpty(txtNoofDays.Text))
            {
                ShowPopUpMsg("Please enter No of Days");

            }
            else
            {
                dt = dal.Fun_Leaves( 0,txtName.Text, Convert.ToInt32(txtNoofDays.Text), "Insert");
                if (dt.Rows[0]["result"].ToString()=="1")
                {
                    ShowPopUpMsg("Leave Created Successfully");
                    Clear();
                    Bindgrid();
                }
                else  if (dt.Rows[0]["result"].ToString() == "0")
                {
                    ShowPopUpMsg("Leave Already Exists");
                   
                }
            }
        }


        public void Clear()
        {
            txtName.Text = "";
            txtNoofDays.Text = "";
            btnUpdate.Visible = false;
            btnSave.Visible = true;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int LeavId = Convert.ToInt32(hfId.Value);
             dt = dal.Fun_Leaves(LeavId,txtName.Text,Convert.ToInt32(txtNoofDays.Text),"Update");
            Clear();
            Bindgrid();
            ShowPopUpMsg("Leave Updated Successfully");
        }

        protected void btnList_Click(object sender, EventArgs e)
        {
            Bindgrid();
        }

        public void Bindgrid()
        {
            dt = dal.Fun_Leaves(0,null,0, "Select");
            grdLeaves.DataSource = dt;
            grdLeaves.DataBind();
        }

        protected void grdLeaves_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int LeavId = Convert.ToInt32( grdLeaves.SelectedRow.Cells[0].Text);

            // dt = dal.Fun_Leaves(LeavId, null, 0, "SelectById");

            //txtName.Text = grdLeaves.SelectedRow.Cells[1].Text.ToString();
            //txtNoofDays.Text = grdLeaves.SelectedRow.Cells[2].Text.ToString();

            hfId.Value = (grdLeaves.SelectedRow.FindControl("lblLeaveId") as Label).Text;
            txtName.Text = (grdLeaves.SelectedRow.FindControl("lblLeaveName") as Label).Text;
            txtNoofDays.Text = (grdLeaves.SelectedRow.FindControl("lblNoofDays") as Label).Text;

            btnSave.Visible = false;
            btnUpdate.Visible = true;
        }

        protected void grdLeaves_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            
            GridViewRow row = grdLeaves.Rows[e.RowIndex];
            Label LeaveId = (Label)row.FindControl("lblLeaveId");

            dt = dal.Fun_Leaves(Convert.ToInt32(LeaveId.Text), null, 0, "Delete");
            Bindgrid();
        }

        protected void grdLeaves_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                
                foreach (LinkButton button in e.Row.Cells[4].Controls.OfType<LinkButton>())
                {
                    if (button.CommandName == "Delete")
                    {
                        button.Attributes["onclick"] = "if(!confirm('Do you want to delete ?')){ return false; };";
                    }
                }
            }
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            Clear();
          
        }

        protected void grdLeaves_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdLeaves.PageIndex = e.NewPageIndex;
            Bindgrid();
        }
    }
}