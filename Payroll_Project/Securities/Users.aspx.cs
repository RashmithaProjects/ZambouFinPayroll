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
    public partial class Users : System.Web.UI.Page
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

            if (!IsPostBack)
            {
                BindRoles();
                
                Bindgrid();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtUserCode.Text == "")
            {
                ShowPopUpMsg("Please enter User Id");
            }
            else if (string.IsNullOrEmpty(txtUserName.Text))
            {
                ShowPopUpMsg("Please enter User Name");
            }
            
            else if (txtUserName.Text == "")
            {
                ShowPopUpMsg("Please enter UserName");

            }

            else if (txtPassword.Text == "")
            {
                ShowPopUpMsg("Please enter Password");

            }
            else if (txtConfirmPassword.Text == "")
            {
                ShowPopUpMsg("Please enter Confirm Password");

            }

            else if (txtConfirmPassword.Text != txtPassword.Text)
            {
                ShowPopUpMsg("Password and ConfirmPassword are MisMatching");

            }


            else if (ddlRoles.SelectedIndex==0)
            {
                ShowPopUpMsg("Please select Role");

            }
            
            else
            {
                dt = dal.Fun_Users(0,txtUserCode.Text, txtUserName.Text,txtPassword.Text , Convert.ToInt32(ddlRoles.SelectedValue), "Insert");
                
                if (dt.Rows[0]["result"].ToString() == "0")
                {
                    ShowPopUpMsg("User Already Exists");

                }
                else if (dt.Rows[0]["result"].ToString() == "1")
                {
                    ShowPopUpMsg("User Created Successfully");
                    Clear();
                    Bindgrid();
                }

            }
        }
        public void Clear()
        {
            BindRoles();
            txtUserCode.Text = "";
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            txtDescription.Text = "";
            ddlRoles.SelectedIndex = 0;
            btnUpdate.Visible = false;
            btnSave.Visible = true;

            divPassword.Visible = true;

            //txtPassword.Visible = true;
            //txtConfirmPassword.Visible = true;
        }
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            Clear();
        }

        protected void btnList_Click(object sender, EventArgs e)
        {

            Bindgrid();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            //BindRoles();
 
            int Id = Convert.ToInt32(hfId.Value);
            dt = dal.Fun_Users(Id, txtUserCode.Text, txtUserName.Text, txtDescription.Text, Convert.ToInt32(ddlRoles.SelectedValue), "Update");
            
            if (dt.Rows[0]["result"].ToString() == "1")
            {
                Clear();
                Bindgrid();
                ShowPopUpMsg("User Updated Successfully");
            }
            else
            {
                ShowPopUpMsg("User already Exists");
            }
        }

     
        public void Bindgrid()
        {
            dt = dal.Fun_Users(0, null,null, null, 0, "Select");
            grdUsers.DataSource = dt;
            grdUsers.DataBind();
        }
        protected void grdUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ddlRoles.Items.Add(new ListItem("Select", "Select"));
           // BindRoles();
            ddlRoles.Items.Insert(0, new ListItem("Select", "Select"));
           
            hfId.Value = (grdUsers.SelectedRow.FindControl("lblUserId") as Label).Text;
            txtUserName.Text = (grdUsers.SelectedRow.FindControl("lblUserName") as Label).Text;
            txtUserCode.Text= (grdUsers.SelectedRow.FindControl("lblUserCode") as Label).Text;
            ddlRoles.SelectedItem.Text = (grdUsers.SelectedRow.FindControl("lblRoleName") as Label).Text;
          //  ddlRoles.Items.Insert(0, new ListItem("Select", "Select"));

            //txtPassword.Visible = false;
            //txtConfirmPassword.Visible = false;

            divPassword.Visible = false;

            btnSave.Visible = false;
            btnUpdate.Visible = true;
        }

        protected void grdUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            GridViewRow row = grdUsers.Rows[e.RowIndex];
            Label lblUserId = (Label)row.FindControl("lblUserId");

            dt = dal.Fun_Users(Convert.ToInt32(lblUserId.Text),null,null, null, 0, "Delete");
            Bindgrid();
        }

        protected void grdUsers_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void grdUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdUsers.PageIndex = e.NewPageIndex;
            Bindgrid();
        }

        public void BindRoles()
        {

            dt = dal.Fun_Roles(0, null, null, "Select");
            ddlRoles.DataSource = dt;
            ddlRoles.DataTextField = "RoleName";
            ddlRoles.DataValueField = "RoleId";
            ddlRoles.DataBind();
            ddlRoles.Items.Insert(0, new ListItem("Select", "0"));

        }

    }
}