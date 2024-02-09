using Payroll_Project.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Payroll_Project.Payrolls
{
    public partial class Payroll_Approved : System.Web.UI.Page
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
                BindPayrollApprovedGrid();
            }
        }


        public void BindPayrollApprovedGrid()
        {
            dt = dal.Fun_PayrollGeneration_Get("Pending");
            grdPayrollApproved.DataSource = dt;
            grdPayrollApproved.DataBind();
        }


        protected void lnk_View_Click(object sender, EventArgs e)
        {


            //Panel2.Visible = true;

            //dt.Clear();

            ////   dt = Regi.fun_product_doc(Session["rr"].ToString(), null, null, null, null, null, "BindDOC");
            //dt = dal.Fun_Customerkycupload(id, null, null, null, null, null, null, null, null, "BindDOC");
            //if (dt.Rows.Count > 0)
            //{
            //    GridView2.DataSource = dt;
            //    GridView2.DataBind();
            //}
            //else
            //{
            //    GridView2.DataSource = null;
            //    GridView2.DataBind();
            //}

        }



        protected void grdPayrollApproved_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdPayrollApproved.PageIndex = e.NewPageIndex;
            BindPayrollApprovedGrid();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow gr in grdPayrollApproved.Rows)
            {
                Label lblYear = gr.FindControl("lblYear") as Label;
                Label lblMonth = gr.FindControl("lblMonth") as Label;
                CheckBox chkApproved = gr.FindControl("chkApproved") as CheckBox;
                CheckBox chkReject = gr.FindControl("chkReject") as CheckBox;
                TextBox txtRemarks = gr.FindControl("txtRemarks") as TextBox;



                if (chkApproved.Checked == true)
                {
                    dt = dal.Fun_PayrollGeneration_InsUpd(Convert.ToInt32(lblYear.Text), lblMonth.Text, txtRemarks.Text, "Approved", "Update");
                    ShowPopUpMsg("Payroll Approved Successfully");
                }
                if (chkReject.Checked == true)
                {
                    dt = dal.Fun_PayrollGeneration_InsUpd(Convert.ToInt32(lblYear.Text), lblMonth.Text, txtRemarks.Text, "Rejected", "Update");
                    ShowPopUpMsg("Payroll Rejected");
                }

            }
            BindPayrollApprovedGrid();

        }
        protected void btnRefresh_Click(object sender, EventArgs e)
        {

        }

        protected void grdPayrollApproved_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label lblYear = (grdPayrollApproved.SelectedRow.FindControl("lblYear") as Label);
            Label lblMonth = (grdPayrollApproved.SelectedRow.FindControl("lblMonth") as Label);

            //string id = Convert.ToString((sender as LinkButton).CommandArgument);

            Response.Redirect(string.Format("~/Payrolls/Payroll_Summary.aspx?Year={0}&Month={1}", lblYear.Text, lblMonth.Text));
        }

        protected void grdPayrollApproved_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label lblCreateedOn = (e.Row.FindControl("lblCreateedOn") as Label);
                DateTime date = Convert.ToDateTime(lblCreateedOn.Text);
                lblCreateedOn.Text = date.ToString(dal.dateFormat);


            }
        }
    }
}