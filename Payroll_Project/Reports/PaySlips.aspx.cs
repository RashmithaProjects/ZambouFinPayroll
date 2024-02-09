using Payroll_Project.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Payroll_Project.Reports
{
    public partial class PaySlips : System.Web.UI.Page
    {
        Dal dal = new Dal();
        DataTable dt = new DataTable();


        protected void Page_Load(object sender, EventArgs e)
        {

            txtYear.Text = DateTime.Now.Year.ToString();
            if (!IsPostBack)
            {
                BindEmployeeNo();
            }
                tblPaySlips.Visible = false;

            if (ddlMonth.SelectedIndex == 0)
            {
                tblPaySlips.Visible = false;
            }
            if(ddlEmployeNo.SelectedIndex == 0)
            {
                tblPaySlips.Visible = false;
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

        public void BindDetails()
        {

            dt = dal.Fun_PaySlip(Convert.ToInt32(txtYear.Text), ddlMonth.SelectedItem.ToString(), Convert.ToInt32(ddlEmployeNo.SelectedValue));
            if (dt.Rows.Count > 0)
            {
                lblEmpname.Text = dt.Rows[0]["first_name"].ToString();
                lblEmpno.Text= dt.Rows[0]["employee_no"].ToString();
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
                lblGYTD1.Text=dt.Rows[0]["ActualGrossPay"].ToString();
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

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            ddlEmployeNo.SelectedIndex = 0 ;
            ddlMonth.SelectedIndex = 0;
            tblPaySlips.Visible = false;
        }

        protected void BtnPrint_Click(object sender, EventArgs e)
        {
            if (ddlEmployeNo.SelectedIndex == 0)
            {
                ShowPopUpMsg("Please Select Employee No");

            }
            else if (ddlMonth.SelectedIndex == 0)
            {
                ShowPopUpMsg("Please Select Month");
            }
            else
            {
                Response.Redirect(string.Format("~/Reports/Payslip_Print.aspx?Year={0}&Month={1}&ReferenceId={2}", txtYear.Text, ddlMonth.SelectedItem.ToString(), ddlEmployeNo.SelectedValue));
            }
        }


        public void BindEmployeeNo()
        {

            dt = dal.Fun_Emp_Details_Get("");
            ddlEmployeNo.DataSource = dt;
            ddlEmployeNo.DataTextField = "employee_no";
            ddlEmployeNo.DataValueField = "ReferenceId";
            ddlEmployeNo.DataBind();
            ddlEmployeNo.Items.Insert(0, new ListItem("Select", "0"));

        }

        protected void ddlEmployeNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlEmployeNo.SelectedIndex == 0 || ddlMonth.SelectedIndex==0)
            {
                tblPaySlips.Visible = false;
            }
            else
            {
                tblPaySlips.Visible = true;
                BindDetails();
            }
        }



        protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlMonth.SelectedIndex == 0 || ddlEmployeNo.SelectedIndex == 0)
            {
                tblPaySlips.Visible = false;
            }
            else
            {
                tblPaySlips.Visible = true;
                BindDetails();
            }
        }
    }
}