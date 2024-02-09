using Payroll_Project.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Payroll_Project.Securities
{
    public partial class AccessRights : System.Web.UI.Page
    {
        Dal dal = new Dal();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindUsers();
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
        public void Bindgrid()
        {
          

            dt = dal.Fun_AccessRights(0,0, "Select");
            grdAccessRights.DataSource = dt;
            grdAccessRights.DataBind();

            foreach (GridViewRow row in grdAccessRights.Rows)
            {
                Label lblParentMenuId = (Label)row.FindControl("lblParentMenuId");
                CheckBox chkAccess = (CheckBox)row.FindControl("chkAccesRights");
                if (lblParentMenuId.Text == "0")
                {
                    chkAccess.Checked = true;
                    row.Visible = false;
                }
            }
        }

        public void BindUsers()
        {
            dt = dal.Fun_Users(0, null,null, null, 0, "Select");
            ddlUsers.DataSource = dt;
            ddlUsers.DataTextField = "user_code";
            ddlUsers.DataValueField = "UserId";
            ddlUsers.DataBind();
            ddlUsers.Items.Insert(0, new ListItem("Select", "0"));
            
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ddlUsers.SelectedIndex == 0)
            {
                ShowPopUpMsg("Please Select User");
            }
            else
            {
                foreach (GridViewRow row in grdAccessRights.Rows)
                {
                    Label lblMenuId = (Label)row.FindControl("lblMenuId");
                    CheckBox chkAccess = (CheckBox)row.FindControl("chkAccesRights");
                    //IList<int> lstMenuids = new List<int>();
                    //lstMenuids.Add(Convert.ToInt32(lblMenuId.Text));


                    DataTable dtaccessrights = new DataTable();
                    DataColumn dtColumn;
                    DataRow myDataRow;

                    // Create id column
                    dtColumn = new DataColumn();
                    dtColumn.DataType = typeof(Int32);
                    dtColumn.ColumnName = "MenuId";
                    dtColumn.Caption = "MenuId";
                    dtaccessrights.Columns.Add(dtColumn);

                    myDataRow = dtaccessrights.NewRow();
                    myDataRow["MenuId"] = Convert.ToInt32(lblMenuId.Text);

                    dtaccessrights.Rows.Add(myDataRow);

                    if (chkAccess.Checked)
                    {
                        dt = dal.Fun_AccessRights(Convert.ToInt32(ddlUsers.SelectedValue), Convert.ToInt32(lblMenuId.Text), "Insert");
                        ShowPopUpMsg("User Access is Created Successfully");
                        Bindgrid();
                    }

                    else
                    {
                        dt = dal.Fun_AccessRights(Convert.ToInt32(ddlUsers.SelectedValue), Convert.ToInt32(lblMenuId.Text), "Delete");
                        Bindgrid();

                    }
                }
            }
        }

       protected void ddlUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            dt1 = dal.Fun_Users(Convert.ToInt32(ddlUsers.SelectedValue), null, null, null, 0, "SelectById");
            txtName.Text = dt1.Rows[0]["UserName"].ToString();
            txtRole.Text = dt1.Rows[0]["RoleName"].ToString();
            Bindgrid();
          
            dt = dal.Fun_AccessRights(Convert.ToInt32( ddlUsers.SelectedValue), 0, "SelectbyUserId");
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    foreach (GridViewRow row in grdAccessRights.Rows)
                    {
                        Label lblMenuId = (Label)row.FindControl("lblMenuId");
                        CheckBox chkMenuId = (CheckBox)row.FindControl("chkAccesRights");
                        if (dr["MenuId"].ToString() == lblMenuId.Text)
                        {
                            chkMenuId.Checked = true;
                        }
                    }
                }
            }
            
        }

        protected void grdAccessRights_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdAccessRights.PageIndex = e.NewPageIndex;
            Bindgrid();

            dt = dal.Fun_AccessRights(Convert.ToInt32(ddlUsers.SelectedValue), 0, "SelectbyUserId");
            if (dt.Rows.Count > 0)
            {

                foreach (DataRow dr in dt.Rows)
                {
                    foreach (GridViewRow row in grdAccessRights.Rows)
                    {
                        Label lblMenuId = (Label)row.FindControl("lblMenuId");
                        CheckBox chkMenuId = (CheckBox)row.FindControl("chkAccesRights");
                        if (dr["MenuId"].ToString() == lblMenuId.Text)
                        {
                            chkMenuId.Checked = true;
                        }
                    }
                }
            }

        }


        protected void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {

        }

        protected void btnList_Click(object sender, EventArgs e)
        {

        }
    }
}