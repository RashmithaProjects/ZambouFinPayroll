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
    public partial class Position : System.Web.UI.Page
    {
        Dal dal = new Dal();
        DataTable dt = new DataTable();
        string Msg;
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
            if (txtPositionCode.Text == "")
            {
                ShowPopUpMsg("Please enter Position Code");
            }
            else if (txtPosition.Text == "")
            {
                ShowPopUpMsg("Please enter Position Name");
            }
            else
            {

                dt = dal.Fun_Positions(0, txtPositionCode.Text, txtPosition.Text, "Insert");
                Msg = dt.Rows[0]["Msg"].ToString();
                if (dt.Rows[0]["result"].ToString() == "1")
                {
                    ShowPopUpMsg(Msg);
                    Bindgrid();
                    Clear();
                }
                else if (dt.Rows[0]["result"].ToString() == "0")
                {
                    ShowPopUpMsg(Msg);
                    //    Clear();
                }




                //dt = dal.Fun_Positions(0,txtPositionCode.Text, txtPosition.Text, "Insert");
                //if (dt.Rows[0]["result"].ToString() == "1")
                //{
                //    ShowPopUpMsg("Position Created Successfully");
                //    Bindgrid();
                //    Clear();
                //}
                //else if (dt.Rows[0]["result"].ToString() == "0")
                //{
                //    ShowPopUpMsg("Position Already Exists");
                //   // Clear();
                //}
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(hfId.Value);
            dt = dal.Fun_Positions(Id, txtPositionCode.Text, txtPosition.Text, "Update");
            Clear();
            Bindgrid();
            ShowPopUpMsg("Position Updated Successfully");
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            Clear();
        }
        public void Clear()
        {
            txtPosition.Text = "";
            txtPositionCode.Text = "";
            btnUpdate.Visible = false;
            btnSave.Visible = true;
        }

        public void Bindgrid()
        {

            dt = dal.Fun_Positions(0,"", null, "Select");
            grdPosition.DataSource = dt;
            grdPosition.DataBind();
            grdPosition.Visible = true;
        }

        protected void btnList_Click(object sender, EventArgs e)
        {
            Bindgrid();

        }

        protected void grdPosition_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdPosition.PageIndex = e.NewPageIndex;
            Bindgrid();
        }

        protected void grdPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            hfId.Value = (grdPosition.SelectedRow.FindControl("lblPositionId") as Label).Text;
            txtPositionCode.Text = (grdPosition.SelectedRow.FindControl("lblPositionCode") as Label).Text;
            txtPosition.Text = (grdPosition.SelectedRow.FindControl("lblPositionName") as Label).Text;

            btnSave.Visible = false;
            btnUpdate.Visible = true;
        }

        protected void grdPosition_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grdPosition.Rows[e.RowIndex];
            Label lblPositionId = (Label)row.FindControl("lblPositionId");

            dt = dal.Fun_Positions(Convert.ToInt32(lblPositionId.Text), null, null, "Delete");
            Bindgrid();
        }

        protected void grdPosition_RowDataBound(object sender, GridViewRowEventArgs e)
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