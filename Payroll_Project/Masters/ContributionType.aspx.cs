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
    public partial class ContributionType : System.Web.UI.Page
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
            if (txtName.Text == "")
            {
                ShowPopUpMsg("Please enter Name");
            }
            else
            {

                dt = dal.Fun_ContributionType(0,txtName.Text, txtDescription.Text, "Insert");
                if (dt.Rows[0]["result"].ToString() == "1")
                {
                    ShowPopUpMsg("ContributionType Created Successfully");
                    Bindgrid();
                    Clear();
                }
                else if (dt.Rows[0]["result"].ToString() == "0")
                {
                    ShowPopUpMsg("Contribution Already Exists");
                    //Clear();
                }
            }
        }

        public void Clear()
        {
            txtName.Text = "";
            txtDescription.Text = "";


        }

        protected void grdContributionType_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdContributionType.PageIndex = e.NewPageIndex;
            Bindgrid();
        }

        public void Bindgrid()
        {

            dt = dal.Fun_ContributionType(0,null,null,"Bind");
            grdContributionType.DataSource = dt;
            grdContributionType.DataBind();
            grdContributionType.Visible = true;
        }

        protected void btnList_Click(object sender, EventArgs e)
        {
            Bindgrid();

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int ContributionId = Convert.ToInt32(hfId.Value);
            dt = dal.Fun_ContributionType(ContributionId, txtName.Text, txtDescription.Text, "Update");
            Clear();
            Bindgrid();
            ShowPopUpMsg("Contribution Type Updated Successfully");
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            Clear();
        }

        protected void grdContributionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            hfId.Value = (grdContributionType.SelectedRow.FindControl("lblSno") as Label).Text;
            txtName.Text = (grdContributionType.SelectedRow.FindControl("lbltype") as Label).Text;
            txtDescription.Text = (grdContributionType.SelectedRow.FindControl("lblDescription") as Label).Text;

            btnSave.Visible = false;
            btnUpdate.Visible = true;
        }

        protected void grdContributionType_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grdContributionType.Rows[e.RowIndex];
            Label lblSno = (Label)row.FindControl("lblSno");

            dt = dal.Fun_ContributionType(Convert.ToInt32(lblSno.Text), null, null, "Delete");
            Bindgrid();
        }

        protected void grdContributionType_RowDataBound(object sender, GridViewRowEventArgs e)
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
    }
}