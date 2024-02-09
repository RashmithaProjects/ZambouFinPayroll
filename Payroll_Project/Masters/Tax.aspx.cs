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
    public partial class Tax : System.Web.UI.Page
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

            if (txtTaxCode.Text == "")
            {
                ShowPopUpMsg("Please enter Tax Code");

            }
            else if (txtLowerRange.Text == "")
            {
                ShowPopUpMsg("Please enter Lower Range");
            }
            else if (txtUpperRange.Text == "")
            {
                ShowPopUpMsg("Please enter Upper Range");
            }
            else if(txtFixedAmount.Text == "")
            {
                ShowPopUpMsg("Please enter Fixed Amount");
            }
            else if (txtPercentAmount.Text == "")
            {
                ShowPopUpMsg("Please enter Percentage Amount");
            }
            else if (TaxCredit.Text == "")
            {
                ShowPopUpMsg("Please enter TaxCredit");
            }
            else
            {

                dt = dal.Fun_Tax(0,txtTaxCode.Text, Convert.ToDecimal(txtLowerRange.Text), Convert.ToDecimal(txtUpperRange.Text), Convert.ToDecimal(txtFixedAmount.Text), Convert.ToDecimal(txtPercentAmount.Text), Convert.ToDecimal(TaxCredit.Text), "Insert");
                if (dt.Rows[0]["result"].ToString() == "1")
                {
                    ShowPopUpMsg("Tax Created Successfully");
                    Clear();
                    Bindgrid();
                }
                else if (dt.Rows[0]["result"].ToString() == "0")
                {
                    ShowPopUpMsg("Tax Already Exists");
                   // Clear();
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {



            dt = dal.Fun_Tax(Convert.ToInt32 (hfId.Value), txtTaxCode.Text, Convert.ToDecimal(txtLowerRange.Text), Convert.ToDecimal(txtUpperRange.Text), Convert.ToDecimal(txtFixedAmount.Text), Convert.ToDecimal(txtPercentAmount.Text), 0, "Update");
            if (dt.Rows[0]["result"].ToString() == "1")
            {
                ShowPopUpMsg("Tax Updated Successfully");
                Clear();
                Bindgrid();
            }
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            Clear();
        }

        protected void btnList_Click(object sender, EventArgs e)
        {
            Bindgrid();

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }


        public void Clear()
        {
            txtTaxCode.Text = "";
            txtLowerRange.Text = "";
            txtUpperRange.Text = "";
            txtFixedAmount.Text = "";
            txtPercentAmount.Text = "";
            TaxCredit.Text = "";
            btnSave.Visible = true;
            btnUpdate.Visible = false;
        }

        public void Bindgrid()
        {
            dt = dal.Fun_Tax(0, null, 0,0, 0,0,0, "Select");
            grdTax.DataSource = dt;
            grdTax.DataBind();
        }
        protected void grdTax_SelectedIndexChanged(object sender, EventArgs e)
        {
            hfId.Value = (grdTax.SelectedRow.FindControl("lblTaxId") as Label).Text;
            txtTaxCode.Text = (grdTax.SelectedRow.FindControl("lbltaxCode") as Label).Text;
            txtLowerRange.Text = (grdTax.SelectedRow.FindControl("lblLowerRange") as Label).Text;
            txtUpperRange.Text = (grdTax.SelectedRow.FindControl("lblUpperRange") as Label).Text;
            txtPercentAmount.Text = (grdTax.SelectedRow.FindControl("lblPercentage") as Label).Text;
       
            btnSave.Visible = false;
            btnUpdate.Visible = true;


        }

        protected void grdTax_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void grdTax_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void grdTax_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdTax.PageIndex = e.NewPageIndex;
            Bindgrid();
        }
    }
}