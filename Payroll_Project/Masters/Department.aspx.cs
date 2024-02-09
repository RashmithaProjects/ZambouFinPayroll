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
    public partial class Department : System.Web.UI.Page
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
            if (txtDepartment.Text == "")
            {
                ShowPopUpMsg("Please enter DepartmentName");
            }
            else
            {

                dt = dal.Fun_Department(0,txtDepartmentCode.Text, txtDepartment.Text, "Insert");
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


                //if (dt.Rows.Count > 0 && dt != null)
                //{

                //    if (dt.Rows[0]["result"].ToString() == "1")
                //    {
                //        Msg = dt.Rows[0]["Msg"].ToString();
                //        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + Msg + "');", true);

                //        this.BindGrid();
                //        txtdepartmentcode.Text = "";
                //        txtName.Text = "";
                //    }
                //    else if (dt.Rows[0]["result"].ToString() == "0")
                //    {
                //        Msg = dt.Rows[0]["Msg"].ToString();
                //        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + Msg + "');", true);
                //    }


                //}





            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int deptid = Convert.ToInt32(hfId.Value);
            dt = dal.Fun_Department(Convert.ToInt32(deptid), txtDepartmentCode.Text, txtDepartment.Text, "Update");
            Clear();
            Bindgrid();
            ShowPopUpMsg("Department Updated Successfully");



            //int deptid = Convert.ToInt32(hfId.Value);
            //dt = dal.Fun_Department(Convert.ToInt32(deptid), txtDepartmentCode.Text, txtDepartment.Text, "Update");
            //Msg = dt.Rows[0]["Msg"].ToString();
            //if (dt.Rows[0]["result"].ToString() == "1")
            //{
            //    ShowPopUpMsg(Msg);
            //    Bindgrid();
            //    Clear();
            //}
            //else if (dt.Rows[0]["result"].ToString() == "0")
            //{
            //    ShowPopUpMsg(Msg);
            //    //    Clear();
            //}



        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            Clear();
        }
        public void Clear()
        {
            txtDepartment.Text = "";
            txtDepartmentCode.Text = "";
            btnUpdate.Visible = false;
            btnSave.Visible = true;
        }

        public void Bindgrid()
        {
            
            dt = dal.Fun_Department(0,"", null, "Select");
            grdDepartment.DataSource = dt;
            grdDepartment.DataBind();
            grdDepartment.Visible = true;
        }

        protected void btnList_Click(object sender, EventArgs e)
        {
            Bindgrid();

        }

        protected void grdDepartment_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdDepartment.PageIndex = e.NewPageIndex;
            Bindgrid();
        }

        protected void grdDepartment_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdDepartment.EditIndex = e.NewEditIndex;
            Bindgrid();
        }

        protected void grdDepartment_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdDepartment.EditIndex = -1;
            this.Bindgrid();
        }

        protected void grdDepartment_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //GridViewRow row = (GridViewRow)grdDepartment.Rows[e.RowIndex];
            //Label lblDeptId = (Label)row.FindControl("lblDeptId");
            //TextBox txtDepartmentcode = (TextBox)row.FindControl("txtDepartmentcode");
            //TextBox txtDepartmentName = (TextBox)row.FindControl("txtDepartmentName");
            

            //dt = dal.Fun_Department(Convert.ToInt32(lblDeptId.Text), txtDepartmentcode.Text, txtDepartmentName.Text, "Update");
            //this.Bindgrid();
        }

        protected void grdDepartment_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)grdDepartment.Rows[e.RowIndex];
            Label lblDeptId = (Label)row.FindControl("lblDeptId");
            dt = dal.Fun_Department(Convert.ToInt32(lblDeptId.Text), null, null, "Delete");
            Bindgrid();
        }

        protected void grdDepartment_RowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void grdDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            hfId.Value = (grdDepartment.SelectedRow.FindControl("lblDeptId") as Label).Text;
            txtDepartment.Text = (grdDepartment.SelectedRow.FindControl("lbldept_name") as Label).Text;
            txtDepartmentCode.Text = (grdDepartment.SelectedRow.FindControl("lbldept_code") as Label).Text;

            btnSave.Visible = false;
            btnUpdate.Visible = true;
        }
    }
}