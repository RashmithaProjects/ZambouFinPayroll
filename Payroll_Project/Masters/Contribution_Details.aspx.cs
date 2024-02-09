using Payroll_Project.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Payroll_Project.Masters
{
    public partial class Contribution_Details : System.Web.UI.Page
    {
        Dal dal = new Dal();
        static string fs = "", fs1 = "", path = "";
        DataTable dt = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {

            calDate.Format = dal.dateFormat;
            if (!IsPostBack)
            {
                BindContributionTypes();
                BindApplicableOn();
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
            
            if (txtCeilingAmount.Text == "")
            {
                txtCeilingAmount.Text = "0";
            }
            if (txtEmprContrPercent.Text == "")
            {
                txtEmprContrPercent.Text = "0";
            }

            if (txtDate.Text == "")
            {
                ShowPopUpMsg("Please enter Date");

            }
            else if (ddlContributionType.SelectedIndex == 0)
            {
                ShowPopUpMsg("Please Select Contribution Type");
            }
            else if (ddlApplicableon.SelectedIndex == 0)
            {
                ShowPopUpMsg("Please Select Applicable On");
            }
            else if (txtEmpeeContrPercent.Text == "")
            {
                ShowPopUpMsg("Please enter Employee Contribution");
            }
            //else if (txtEmprContrPercent.Text == "")
            //{
            //    txtEmprContrPercent.Text = "0";
            //}
            //else if (txtCeilingAmount.Text == "")
            //{
            //    txtCeilingAmount.Text = "0";
            //}
            else
            {
                DateTime Date = DateTime.ParseExact(txtDate.Text, dal.dateFormat, null);
                dt = dal.Fun_Contribution_Details_InsUpd(Date, Convert.ToInt32(ddlContributionType.SelectedValue), ddlContributionType.SelectedItem.ToString(), txtDescription.Text, Convert.ToDecimal(txtEmpeeContrPercent.Text), Convert.ToDecimal(txtEmprContrPercent.Text), Convert.ToDecimal(txtCeilingAmount.Text), ddlApplicableon.SelectedItem.ToString(), "Insert");
                if (dt.Rows.Count > 0)
                {

                    ShowPopUpMsg("Contribution Details Created Successfully");
                    Bindgrid();
                    Clear();
                }
            }
        }

        public void BindContributionTypes()
        {

            dt = dal.Fun_ContributionType(0,null,null,"bind");
            ddlContributionType.DataSource = dt;
            ddlContributionType.DataTextField = "type";
            ddlContributionType.DataValueField = "Sno";
            ddlContributionType.DataBind();
            ddlContributionType.Items.Insert(0, new ListItem("Select", "0"));

        }

        public void BindApplicableOn()
        {
            
            //ddlApplicableon.Items.Insert(0, new ListItem("Select", "0"));
            ddlApplicableon.Items.Insert(1, new ListItem("Basic Pay", "Basic Pay"));
            ddlApplicableon.Items.Insert(2, new ListItem("Gross Pay", "Gross Pay"));

        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            Clear();
        }


        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            

            if (txtCeilingAmount.Text == "")
            {
                txtCeilingAmount.Text = "0";
            }
            if (txtEmprContrPercent.Text == "")
            {
                txtEmprContrPercent.Text = "0";
            }
            if (txtDate.Text == "")
            {
                ShowPopUpMsg("Please enter Date");

            }
            //else if (ddlContributionType.SelectedIndex == 0)
            //{
            //    ShowPopUpMsg("Please Select Contribution Type");
            //}
            else if (ddlApplicableon.SelectedIndex == 0)
            {
                ShowPopUpMsg("Please Select Applicable On");
            }
            else if (txtEmpeeContrPercent.Text == "")
            {
                ShowPopUpMsg("Please enter Employee Contribution");
            }
            //else if (txtEmprContrPercent.Text == "")
            //{
            //    txtEmprContrPercent.Text = "0";
            //}
            //else if (txtCeilingAmount.Text == "")
            //{
            //    txtCeilingAmount.Text = "0";
            //}
            else
            {
                DateTime Date = DateTime.ParseExact(txtDate.Text, dal.dateFormat, null);
                dt = dal.Fun_Contribution_Details_InsUpd(Date,  Convert.ToInt32(hfId.Value), ddlContributionType.SelectedItem.ToString(), txtDescription.Text, Convert.ToDecimal(txtEmpeeContrPercent.Text), Convert.ToDecimal(txtEmprContrPercent.Text), Convert.ToDecimal(txtCeilingAmount.Text), ddlApplicableon.SelectedItem.ToString(), "Update");
                if (dt.Rows.Count > 0)
                {
                    ShowPopUpMsg("Contribution Details Updated Successfully");
                    Bindgrid();
                    BindContributionTypes();
                    Clear();
                }
            }
        }

        protected void btnList_Click(object sender, EventArgs e)
        {
            Bindgrid();
        }

        protected void ddlContributionRequired_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlContributionRequired.SelectedValue == "No")
            {
                txtEmprContrPercent.Enabled = false;
                txtEmprContrPercent.Text = "0";
            }
            else
            {
                txtEmprContrPercent.Enabled = true;
                txtEmprContrPercent.Text = "";
            }

        }

        protected void grdContributionDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            hfId.Value = (grdContributionDetails.SelectedRow.FindControl("lblContributionId") as Label).Text;
            //ddlContributionType.Items.Insert(0, new ListItem("Select", "0"));
            //BindContributionTypes();

            //txtDate.Text=System.Convert.ToDateTime(dt.Rows[0]["contract_start"]).ToString(dal.dateFormat);
            txtDate.Text = (grdContributionDetails.SelectedRow.FindControl("lblEmpDate") as Label).Text;
            ddlContributionType.SelectedItem.Text = (grdContributionDetails.SelectedRow.FindControl("lblContributionType") as Label).Text;
            //lblContributionType.Text= (grdContributionDetails.SelectedRow.FindControl("lblContributionType") as Label).Text;
            txtEmpeeContrPercent.Text = (grdContributionDetails.SelectedRow.FindControl("lblEmployeePercentage") as Label).Text;
            txtEmprContrPercent.Text = (grdContributionDetails.SelectedRow.FindControl("lblEmployerPercentage") as Label).Text;
            txtCeilingAmount.Text = (grdContributionDetails.SelectedRow.FindControl("lblCeilingAmount") as Label).Text;
            ddlApplicableon.SelectedValue = (grdContributionDetails.SelectedRow.FindControl("lblApplicableOn") as Label).Text;
             
            if (txtEmprContrPercent.Text == "0")
            {
                ddlContributionRequired.SelectedValue = "No";
            }
            else
            {
                ddlContributionRequired.SelectedValue = "Yes";
            }

            btnSave.Visible = false;
            btnUpdate.Visible = true;

        }

        protected void grdContributionDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void grdContributionDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label lblEmpDate = (e.Row.FindControl("lblEmpDate") as Label);
                DateTime date = Convert.ToDateTime(lblEmpDate.Text);
                lblEmpDate.Text = date.ToString(dal.dateFormat);

                
            }

        }

        public void Clear()
        {
            txtDate.Text = "";
            BindContributionTypes();
            ddlContributionType.SelectedIndex = 0;
            ddlContributionRequired.SelectedIndex = 0;
            txtEmpeeContrPercent.Text = "";
            txtEmprContrPercent.Text = "";
            txtEmprContrPercent.Enabled = true;
            txtCeilingAmount.Text = "";
            ddlApplicableon.SelectedIndex = 0;
            btnSave.Visible = true;
            btnUpdate.Visible = false;
        }

        public void Bindgrid()
        {

            dt = dal.FunContribution_Details_Get_P();
            grdContributionDetails.DataSource = dt;
            grdContributionDetails.DataBind();
        }
    }
}