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

    public partial class Shift : System.Web.UI.Page
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
            if (ddlshifttype.SelectedIndex == 0)
            {
                ShowPopUpMsg("Please select Shift Type");

            }
            else if (txtShiftName.Text == "")
            {
                ShowPopUpMsg("Please enter Shfit Name");
            }
            else if (txtFrom.Text == "")
            {
                ShowPopUpMsg("Please enter From Time");
            }
            else if (txtTo.Text == "")
            {
                ShowPopUpMsg("Please enter To Time");
            }

            else
            {
                dt = dal.Fun_ShiftDetails(0,ddlshifttype.SelectedValue, txtShiftName.Text, Convert.ToInt32(txtFrom.Text), Convert.ToInt32(txtTo.Text), "Insert");
                if (dt.Rows[0]["result"].ToString() == "1")
                {
                    ShowPopUpMsg("Shift Created Successfully");
                    Clear();
                    Bindgrid();
                }
                else if (dt.Rows[0]["result"].ToString() == "0")
                {
                    ShowPopUpMsg("Shift Already Exists");
                   // Clear();
                }

            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int ShiftId = Convert.ToInt32(hfId.Value);
            dt = dal.Fun_ShiftDetails(ShiftId, ddlshifttype.SelectedItem.ToString(),txtShiftName.Text, Convert.ToInt32(txtFrom.Text),Convert.ToInt32(txtTo.Text), "Update");
            Clear();
            Bindgrid();
            ShowPopUpMsg("Shift Updated Successfully");
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            Clear();
          
        }

        public void Clear()
        {
            ddlshifttype.SelectedIndex = 0;
            txtShiftName.Text = "";
            txtFrom.Text = "";
            txtTo.Text = "";

            btnUpdate.Visible = false;
            btnSave.Visible = true;
        }

        public void Bindgrid()
        {

            dt = dal.Fun_ShiftDetails(0,null, null,0,0, "bind");
            grdShift.DataSource = dt;
            grdShift.DataBind();
            grdShift.Visible = true;
        }

        protected void btnList_Click(object sender, EventArgs e)
        {
            Bindgrid();

        }

   

        protected void grdShift_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdShift.PageIndex = e.NewPageIndex;
            Bindgrid();
        }

        protected void grdShift_SelectedIndexChanged(object sender, EventArgs e)
        {
            hfId.Value = (grdShift.SelectedRow.FindControl("lblSiftId") as Label).Text;
            ddlshifttype.SelectedValue = (grdShift.SelectedRow.FindControl("lblshifttype") as Label).Text;
            txtShiftName.Text = (grdShift.SelectedRow.FindControl("lblshiftname") as Label).Text;
            txtFrom.Text = (grdShift.SelectedRow.FindControl("lblFromTime") as Label).Text;
            txtTo.Text = (grdShift.SelectedRow.FindControl("lblToTime") as Label).Text;

            btnSave.Visible = false;
            btnUpdate.Visible = true;

        }

        protected void grdShift_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grdShift.Rows[e.RowIndex];
            Label lblSiftId = (Label)row.FindControl("lblSiftId");

            dt = dal.Fun_ShiftDetails(Convert.ToInt32(lblSiftId.Text),null, null, 0,0, "Delete");
            Bindgrid();

        }

        protected void grdShift_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                foreach (LinkButton button in e.Row.Cells[6].Controls.OfType<LinkButton>())
                {
                    if (button.CommandName == "Delete")
                    {
                        button.Attributes["onclick"] = "if(!confirm('Do you want to delete ?')){ return false; };";
                    }
                }
            }

        }
    }
}