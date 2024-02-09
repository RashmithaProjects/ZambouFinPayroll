using Payroll_Project.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Payroll_Project.Payrolls
{
    public partial class Employee_List : System.Web.UI.Page
    {
        Dal dal = new Dal();
        static string fs = "", fs1 = "", path = "";
        DataTable dt = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            string searchtext = Request.QueryString["searchtext"];
            BindGrid(searchtext);
        }

        public void BindGrid(string searchtext)
        {

            if (searchtext == null)
            {
                dt = dal.Fun_Emp_Details_Get("");
                grdEmployees.DataSource = dt;
                grdEmployees.DataBind();
            }
            else
            {
                dt = dal.Fun_Emp_Details_Get(searchtext);
                grdEmployees.DataSource = dt;
                grdEmployees.DataBind();
            }



        }


        protected void lnkbutton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Employee_Creation.aspx");
        }

        protected void grdEmployees_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label lblCreateedOn = (e.Row.FindControl("lblCreateedOn") as Label);
                DateTime date = Convert.ToDateTime(lblCreateedOn.Text);
                lblCreateedOn.Text = date.ToString(dal.dateFormat);


            }
        }

        protected void grdEmployees_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdEmployees.PageIndex = e.NewPageIndex;
            BindGrid("");
        }

        protected void grdEmployees_Sorting(object sender, GridViewSortEventArgs e)
        {

        }
    }
}