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
    public partial class WorkingLocation : System.Web.UI.Page
    {
        Dal dal = new Dal();
        DataTable dt = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.Bindgrid();
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
            if (txtWorkingLocation.Text == "")
            {
                ShowPopUpMsg("Please enter  Work Location");
            }
            else if(ddlCompanyLocation.SelectedIndex == 0)
            {
                ShowPopUpMsg("Please select Company Location");
            }
            else
            {

                dt = dal.Fun_WorkLocation(0,txtWorkingLocation.Text, ddlCompanyLocation.SelectedValue, "Insert");
                if (dt.Rows[0]["result"].ToString() == "1")
                {
                    ShowPopUpMsg("Work Location Created Successfully");
                    Bindgrid();
                    Clear();
                }
                else if (dt.Rows[0]["result"].ToString() == "0")
                {
                    ShowPopUpMsg("Work Location Already Exists");
                  //  Clear();
                }
            }
        }

        public void Bindgrid()
        {
            
            dt = dal.Fun_WorkLocation(0, null, null, "bind");
            grdWorkLocation.DataSource = dt;
            grdWorkLocation.DataBind();
        }
        protected void btnList_Click(object sender, EventArgs e)
        {
            Bindgrid();

        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(hfId.Value);
            dt = dal.Fun_WorkLocation(Id, txtWorkingLocation.Text,ddlCompanyLocation.SelectedItem.ToString() , "Update");
            Clear();
            Bindgrid();
            ShowPopUpMsg("Work Location Updated Successfully");
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            Clear();
        }
        public void Clear()
        {
            txtWorkingLocation.Text = "";
            ddlCompanyLocation.SelectedIndex = 0;
            btnSave.Visible = true;
            btnUpdate.Visible = false;
        }

        protected void grdWorkLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            hfId.Value = (grdWorkLocation.SelectedRow.FindControl("lblWorkLocationId") as Label).Text;
            txtWorkingLocation.Text = (grdWorkLocation.SelectedRow.FindControl("lblWorkLocation") as Label).Text;
            ddlCompanyLocation.SelectedValue = (grdWorkLocation.SelectedRow.FindControl("lblCompanyLocation") as Label).Text;

            btnSave.Visible = false;
            btnUpdate.Visible = true;

        }

        protected void grdWorkLocation_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grdWorkLocation.Rows[e.RowIndex];
            Label lblWorkLocationId = (Label)row.FindControl("lblWorkLocationId");

            dt = dal.Fun_WorkLocation(Convert.ToInt32(lblWorkLocationId.Text), null, null, "Delete");
            Bindgrid();

        }

        protected void grdWorkLocation_RowDataBound(object sender, GridViewRowEventArgs e)
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


        protected void grdWorkLocation_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void grdWorkLocation_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdWorkLocation.PageIndex = e.NewPageIndex;
            Bindgrid();
        }
    }
}