using Payroll_Project.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Payroll_Project.Reports
{
    public partial class Payslip_Print : System.Web.UI.Page
    {
        Dal dal = new Dal();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

            //txtYear.Text = DateTime.Now.Year.ToString();
            

            if (!IsPostBack)
            {
                BindDetails();
            }
        }

        public void BindDetails()
        {
            int Year = Convert.ToInt32(Request.QueryString["Year"]);
            string Month = Convert.ToString(Request.QueryString["Month"]);
            int ReferenceId = Convert.ToInt32(Request.QueryString["ReferenceId"]);



            dt = dal.Fun_PaySlip(Year,Month, ReferenceId);
            if (dt.Rows.Count > 0)
            {

                txtYear.Text = Year.ToString();
                txtMonth.Text = Month.ToString();
                txtEmployeeNo.Text = dt.Rows[0]["employee_no"].ToString();


                lblEmpname.Text = dt.Rows[0]["first_name"].ToString();
                lblEmpno.Text = dt.Rows[0]["employee_no"].ToString();
                lblNRCNo.Text = dt.Rows[0]["Nrcno"].ToString();
                lblEngDate.Text = DateTime.Now.ToString("dd MMMM yyyy");
                lblBasic.Text = dt.Rows[0]["YearlyBasicPay"].ToString();



                lblTPYTD.Text = dt.Rows[0]["ActualGrossPay"].ToString();
                lblTDate.Text = dt.Rows[0]["YearlyPayee"].ToString();
                lblYNAPSA.Text = dt.Rows[0]["YearlyNAPSA"].ToString();
                LblSocioSecurityNo.Text = dt.Rows[0]["Socio_Security_No"].ToString();
                lblLdays.Text = dt.Rows[0]["YearlyLeaves"].ToString();
                //lblLvalue.Text = dt.Rows[0]["no_of_days"].ToString();


                //deductions
                lblNApsaMonth.Text = dt.Rows[0]["NAPSA"].ToString();
                lblNHISMonth.Text = dt.Rows[0]["NHIMA"].ToString();
                lblZloanB.Text = dt.Rows[0]["ZamboLoanRepayment"].ToString();
                lblZLM.Text = dt.Rows[0]["ZamboLoanRepayment"].ToString();

                //allowances
                lblBasicPayMonth.Text = dt.Rows[0]["basic_pay"].ToString();

                lblGrade.Text = dt.Rows[0]["PositionName"].ToString();
                //lblPpoint.Text = dt.Rows[0]["PositionName"].ToString();
                lblTDed.Text = dt.Rows[0]["TotalDeductions"].ToString();
                lblleavesTaken.Text = dt.Rows[0]["no_of_days"].ToString();
                lblTincomes.Text = dt.Rows[0]["basic_pay"].ToString();



                lblBname.Text = dt.Rows[0]["bank_name"].ToString();
                lblTMonth.Text = dt.Rows[0]["Paye"].ToString();
                //lblXBonus.Text = dt.Rows[0]["Paye"].ToString();
                lblGYTD1.Text = dt.Rows[0]["ActualGrossPay"].ToString();
                lblNPay.Text = dt.Rows[0]["NetPay"].ToString();

                lblAccountno.Text = dt.Rows[0]["account_no"].ToString();
                //lblAccountno.Text = dt.Rows[0]["account_no"].ToString();
                //lblAccountno.Text = dt.Rows[0]["account_no"].ToString();
                //lblAccountno.Text = dt.Rows[0]["account_no"].ToString();



            }
            else
            {
                tblPaySlips.Visible = false;
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("Payslips.aspx");
        }
    }
}