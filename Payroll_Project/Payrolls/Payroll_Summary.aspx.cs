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
    public partial class Payroll_Summary : System.Web.UI.Page
    {
        Dal dal = new Dal();
        DataTable dt = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            string Year = Request.QueryString["Year"];
            string Month = Request.QueryString["Month"];
            BindPayrollGenerationGrid(Convert.ToInt32(Year), Month);
            BindPayrollSummmaryGrid(Convert.ToInt32(Year), Month);
        }

        //public void BindPayrollGenerationGrid(int Year, string Month)
        //{

        //    dt = dal.Fun_PayrollGeneration_Details_Get(Year, Month);

        //    grdPayrollGeneration.DataSource = dt;
        //    grdPayrollGeneration.DataBind();
        //}

        public void BindPayrollGenerationGrid(int Year, string Month)
        {
            dt = dal.Fun_PayrollGeneration(Year, Month);

            grdPayrollGeneration.DataSource = dt;
            grdPayrollGeneration.DataBind();


            decimal BasicPay = dt.AsEnumerable().Sum(row => row.Field<decimal?>("BasicPay") ?? 0);
            decimal HouseAllowance = dt.AsEnumerable().Sum(row => row.Field<decimal?>("HouseAllowance") ?? 0);
            decimal LunchAllowance = dt.AsEnumerable().Sum(row => row.Field<decimal?>("LunchAllowance") ?? 0);
            decimal TransportAllowance = dt.AsEnumerable().Sum(row => row.Field<decimal?>("TransportAllowance") ?? 0);
            decimal ResponsibilityAllowance = dt.AsEnumerable().Sum(row => row.Field<decimal?>("ResponsibilityAllowance") ?? 0);
            decimal SalesAndMarketingCommision = dt.AsEnumerable().Sum(row => row.Field<decimal?>("SalesAndMarketingCommision") ?? 0);
            decimal GrossPay = dt.AsEnumerable().Sum(row => row.Field<decimal?>("GrossPay") ?? 0);
            decimal GrossPayRate = dt.AsEnumerable().Sum(row => row.Field<decimal?>("GrossPayRate") ?? 0);
            decimal ActualGrossPay = dt.AsEnumerable().Sum(row => row.Field<decimal?>("ActualGrossPay") ?? 0);
            decimal NAPSA = dt.AsEnumerable().Sum(row => row.Field<decimal?>("NAPSA") ?? 0);
            decimal NHIMA = dt.AsEnumerable().Sum(row => row.Field<decimal?>("NHIMA") ?? 0);
            decimal Paye = dt.AsEnumerable().Sum(row => row.Field<decimal?>("Paye") ?? 0);
            decimal SalaryAdvancedRepayment = dt.AsEnumerable().Sum(row => row.Field<decimal?>("SalaryAdvancedRepayment") ?? 0);
            decimal ZamboLoanRepayment = dt.AsEnumerable().Sum(row => row.Field<decimal?>("ZamboLoanRepayment") ?? 0);
            decimal NetPay = dt.AsEnumerable().Sum(row => row.Field<decimal?>("NetPay") ?? 0);
            decimal Gratuity = dt.AsEnumerable().Sum(row => row.Field<decimal?>("Gratuity") ?? 0);
            decimal NapsaCom = dt.AsEnumerable().Sum(row => row.Field<decimal?>("NapsaCom") ?? 0);
            decimal CTC = dt.AsEnumerable().Sum(row => row.Field<decimal?>("CTC") ?? 0);
            foreach (GridViewRow row in grdPayrollGeneration.Rows)
            {

                Label lblTotalBasicPay = (Label)grdPayrollGeneration.FooterRow.FindControl("lblTotalBasicPay");
                Label lblTotalHouseAllowance = (Label)grdPayrollGeneration.FooterRow.FindControl("lblTotalHouseAllowance");
                Label lblTotalLunchAllowance = (Label)grdPayrollGeneration.FooterRow.FindControl("lblTotalLunchAllowance");
                Label lblTotalTransportAllowance = (Label)grdPayrollGeneration.FooterRow.FindControl("lblTotalTransportAllowance");
                Label lblTotalResponsibilityAllowance = (Label)grdPayrollGeneration.FooterRow.FindControl("lblTotalResponsibilityAllowance");
                Label lblTotalSalesAndMarketingCommission = (Label)grdPayrollGeneration.FooterRow.FindControl("lblTotalSalesAndMarketingCommission");
                Label lblTotalGrossPay = (Label)grdPayrollGeneration.FooterRow.FindControl("lblTotalGrossPay");
                Label lblTotalGrossPayRate = (Label)grdPayrollGeneration.FooterRow.FindControl("lblTotalGrossPayRate");
                Label lblTotalActualGrossPay = (Label)grdPayrollGeneration.FooterRow.FindControl("lblTotalActualGrossPay");
                Label lblTotalNAPSA = (Label)grdPayrollGeneration.FooterRow.FindControl("lblTotalNAPSA");
                Label lblTotalNHIMA = (Label)grdPayrollGeneration.FooterRow.FindControl("lblTotalNHIMA");
                Label lblTotalPaye = (Label)grdPayrollGeneration.FooterRow.FindControl("lblTotalPaye");
                Label lblTotalSalaryAdvanceRepayment = (Label)grdPayrollGeneration.FooterRow.FindControl("lblTotalSalaryAdvanceRepayment");
                Label lblTotalZamboLoanRepayment = (Label)grdPayrollGeneration.FooterRow.FindControl("lblTotalZamboLoanRepayment");
                Label lblTotalNetPay = (Label)grdPayrollGeneration.FooterRow.FindControl("lblTotalNetPay");
                Label lblTotalGratuity = (Label)grdPayrollGeneration.FooterRow.FindControl("lblTotalGratuity");
                Label lblTotalNapsaCom = (Label)grdPayrollGeneration.FooterRow.FindControl("lblTotalNapsaCom");
                Label lblTotalCTC = (Label)grdPayrollGeneration.FooterRow.FindControl("lblTotalCTC");



                lblTotalBasicPay.Text = BasicPay.ToString();
                lblTotalHouseAllowance.Text = HouseAllowance.ToString();
                lblTotalLunchAllowance.Text = LunchAllowance.ToString();
                lblTotalTransportAllowance.Text = TransportAllowance.ToString();
                lblTotalResponsibilityAllowance.Text = ResponsibilityAllowance.ToString();
                lblTotalSalesAndMarketingCommission.Text = SalesAndMarketingCommision.ToString();
                lblTotalGrossPay.Text = GrossPay.ToString();
                lblTotalGrossPayRate.Text = GrossPayRate.ToString();
                lblTotalActualGrossPay.Text = ActualGrossPay.ToString();
                lblTotalNAPSA.Text = NAPSA.ToString();
                lblTotalNHIMA.Text = NHIMA.ToString();
                lblTotalPaye.Text = Paye.ToString();
                lblTotalSalaryAdvanceRepayment.Text = SalaryAdvancedRepayment.ToString();
                lblTotalZamboLoanRepayment.Text = ZamboLoanRepayment.ToString();
                lblTotalNetPay.Text = NetPay.ToString();
                lblTotalGratuity.Text = Gratuity.ToString();
                lblTotalNapsaCom.Text = NapsaCom.ToString();
                lblTotalCTC.Text = CTC.ToString();

            }


            //CalculateFooterSum();
        }

        public void BindPayrollSummmaryGrid(int Year, string Month)
        {
            dt = dal.Fun_PayrollTotalSummary(Year,Month);
            grdPayrollSummary.DataSource = dt;
            grdPayrollSummary.DataBind();

            //  DataRow dr = null;
            //dt.Columns.Add(new DataColumn("sno", typeof(string)));
            //dt.Columns.Add(new DataColumn("Employees", typeof(string)));
            //dt.Columns.Add(new DataColumn("Total Cost To Company", typeof(string)));
            //dt.Columns.Add(new DataColumn("NetWageRate", typeof(string)));
            //dt.Columns.Add(new DataColumn("LoanAndOtherRepayment", typeof(string)));
            //dt.Columns.Add(new DataColumn("Statutory Fees", typeof(string)));
            //DataRow dr1 = dt.NewRow();

            //Label lblTotalCTC = (Label)grdPayrollGeneration.FooterRow.FindControl("lblTotalCTC");
            //Label lblTotalNetPay = (Label)grdPayrollGeneration.FooterRow.FindControl("lblTotalNetPay");
            //Label lblTotalSalaryAdvanceRepayment = (Label)grdPayrollGeneration.FooterRow.FindControl("lblTotalSalaryAdvanceRepayment");
            //Label lblTotalZamboLoanRepayment = (Label)grdPayrollGeneration.FooterRow.FindControl("lblTotalZamboLoanRepayment");
            //Label lblTotalNAPSA = (Label)grdPayrollGeneration.FooterRow.FindControl("lblTotalNAPSA");
            //Label lblTotalPaye = (Label)grdPayrollGeneration.FooterRow.FindControl("lblTotalPaye");
            //Label lblTotalNHIMA = (Label)grdPayrollGeneration.FooterRow.FindControl("lblTotalNHIMA");
            //Label lblTotalGratuity = (Label)grdPayrollGeneration.FooterRow.FindControl("lblTotalGratuity");

            //decimal TotalSalaryAdvanceRepayment = 0;
            //decimal TotalZamboLoanRepayment = 0;
            //decimal TotalPaye = 0;
            //decimal TotalGratuity = 0;


            //if (lblTotalSalaryAdvanceRepayment.Text == "")
            //{
            //    TotalSalaryAdvanceRepayment = 0;
            //}
            //else
            //{
            //    TotalSalaryAdvanceRepayment = Convert.ToDecimal(lblTotalSalaryAdvanceRepayment.Text);
            //}
            //if (lblTotalZamboLoanRepayment.Text == "")
            //{
            //    TotalZamboLoanRepayment = 0;
            //}
            //else
            //{
            //    TotalZamboLoanRepayment = Convert.ToDecimal(lblTotalZamboLoanRepayment.Text);
            //}

            //if (lblTotalPaye.Text == "")
            //{
            //    TotalPaye = 0;
            //}
            //if (lblTotalGratuity.Text == "")
            //{
            //    Gratuity = 0;
            //}

            //dr1["Employees"] = grdPayrollGeneration.Rows.Count;
            //dr1["Total Cost To Company"] = lblTotalCTC.Text;            // ctc
            //dr1["NetWageRate"] = lblTotalNetPay.Text;                  // sum of net salary
            //dr1["LoanAndOtherRepayment"] = (TotalSalaryAdvanceRepayment + TotalZamboLoanRepayment).ToString();  // sum of  salary advanced repayment + Zambo Loan repayment        
            //dr1["Statutory Fees"] = Convert.ToDecimal(lblTotalNAPSA.Text) + Convert.ToDecimal(lblTotalNAPSA.Text) + Convert.ToDecimal(lblTotalNHIMA.Text) + Convert.ToDecimal(lblTotalPaye.Text) + Convert.ToDecimal(lblTotalGratuity.Text);                             // sum of napsa employe + sum of napsa Employer + paye+Nhima + gratuiy
            //dt.Rows.Add(dr1);


            //grdPayrollSummary.DataSource = dt;
            //grdPayrollSummary.DataBind();



        }


        protected void btnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("Payroll_Approved.Aspx");
        }

        decimal BasicPay = 0;
        decimal HouseAllowance = 0;
        decimal LunchAllowance = 0;
        decimal TransportAllowance = 0;
        decimal ResponsibilityAllowance = 0;
        decimal SalesAndMarketingCommission = 0;
        decimal GrossPay = 0;
        decimal GrossPayRate = 0;
        decimal ActualGrossPay = 0;
        decimal NAPSA = 0;
        decimal NHIMA = 0;
        decimal Paye = 0;
        decimal SalaryAdvancedRepayment = 0;
        decimal ZamboLoanRepayment = 0;
        decimal NetPay = 0;
        decimal Gratuity = 0;
        decimal NapsaCom = 0;
        decimal CTC = 0;

        

        

        protected void grdPayrollGeneration_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label lblBasicPay = (Label)e.Row.FindControl("lblBasicPay");
                Label lblHouseAllowance = (Label)e.Row.FindControl("lblHouseAllowance");
                Label lblLunchAllowance = (Label)e.Row.FindControl("lblLunchAllowance");
                Label lblTransportAllowance = (Label)e.Row.FindControl("lblTransportAllowance");
                Label lblResponsibilityAllowance = (Label)e.Row.FindControl("lblResponsibilityAllowance");
                Label lblSalesAndMarketingCommission = (Label)e.Row.FindControl("lblSalesAndMarketingCommission");
                Label lblGrossPay = (Label)e.Row.FindControl("lblGrossPay");
                Label lblGrossPayRate = (Label)e.Row.FindControl("lblGrossPayRate");
                Label lblActualGrossPay = (Label)e.Row.FindControl("lblActualGrossPay");
                Label lblNAPSA = (Label)e.Row.FindControl("lblHouseAllowance");
                Label lblNHIMA = (Label)e.Row.FindControl("lblNHIMA");
                Label lblPaye = (Label)e.Row.FindControl("lblPaye");
                Label lblSalaryAdvancedRepayment = (Label)e.Row.FindControl("lblSalaryAdvancedRepayment");
                Label lblZamboLoanRepayment = (Label)e.Row.FindControl("lblZamboLoanRepayment");



                Label lblNetPay = (Label)e.Row.FindControl("lblNetPay");

                Label lblGratuity = (Label)e.Row.FindControl("lblGratuity");
                Label lblNapsaCom = (Label)e.Row.FindControl("lblNapsaCom");
                Label lblCTC = (Label)e.Row.FindControl("lblCTC");


                BasicPay = BasicPay + Convert.ToDecimal(lblBasicPay.Text);
                HouseAllowance = HouseAllowance + Convert.ToDecimal(lblHouseAllowance.Text);
                LunchAllowance = LunchAllowance + Convert.ToDecimal(lblLunchAllowance.Text);
                TransportAllowance = TransportAllowance + Convert.ToDecimal(lblTransportAllowance.Text);
                ResponsibilityAllowance = ResponsibilityAllowance + Convert.ToDecimal(lblResponsibilityAllowance.Text);
                SalesAndMarketingCommission = SalesAndMarketingCommission + Convert.ToDecimal(lblSalesAndMarketingCommission.Text);
                GrossPay = GrossPay + Convert.ToDecimal(lblGrossPay.Text);
                GrossPayRate = GrossPayRate + Convert.ToDecimal(lblGrossPayRate.Text);
                ActualGrossPay = ActualGrossPay + Convert.ToDecimal(lblActualGrossPay.Text);
                NAPSA = NAPSA + Convert.ToDecimal(lblNAPSA.Text);
                NHIMA = NHIMA + Convert.ToDecimal(lblNHIMA.Text);
                Paye = Paye + Convert.ToDecimal(lblPaye.Text);
                SalaryAdvancedRepayment = SalaryAdvancedRepayment + Convert.ToDecimal(lblSalaryAdvancedRepayment.Text);
                ZamboLoanRepayment = ZamboLoanRepayment + Convert.ToDecimal(lblZamboLoanRepayment.Text);
                NetPay = NetPay + Convert.ToDecimal(lblNetPay.Text);
                Gratuity = Gratuity + Convert.ToDecimal(lblGratuity.Text);
                NapsaCom = NapsaCom + Convert.ToDecimal(lblNapsaCom.Text);
                CTC = CTC + Convert.ToDecimal(lblCTC.Text);

            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblTotalBasicPay = (Label)e.Row.FindControl("lblTotalBasicPay");
                Label lblTotalHouseAllowance = (Label)e.Row.FindControl("lblTotalHouseAllowance");
                Label lblTotalLunchAllowance = (Label)e.Row.FindControl("lblTotalLunchAllowance");
                Label lblTotalTransportAllowance = (Label)e.Row.FindControl("lblTotalTransportAllowance");
                Label lblTotalResponsibilityAllowance = (Label)e.Row.FindControl("lblTotalResponsibilityAllowance");
                Label lblTotalSalesAndMarketingCommission = (Label)e.Row.FindControl("lblTotalSalesAndMarketingCommission");

                Label lblTotalGrossPay = (Label)e.Row.FindControl("lblTotalGrossPay");
                Label lblTotalActualGrossPay = (Label)e.Row.FindControl("lblTotalActualGrossPay");

                Label lblTotalNAPSA = (Label)e.Row.FindControl("lblTotalNAPSA");
                Label lblTotalNHIMA = (Label)e.Row.FindControl("lblTotalNHIMA");
                Label lblTotalPaye = (Label)e.Row.FindControl("lblTotalPaye");
                Label lblTotalSalaryAdvanceRepayment = (Label)e.Row.FindControl("lblTotalSalaryAdvanceRepayment");
                Label lblTotalZamboLoanRepayment = (Label)e.Row.FindControl("lblTotalZamboLoanRepayment");

                Label lblTotalNetPay = (Label)e.Row.FindControl("lblTotalNetPay");
                Label lblTotalGratuity = (Label)e.Row.FindControl("lblTotalGratuity");
                Label lblTotalNapsaCom = (Label)e.Row.FindControl("lblTotalNapsaCom");
                Label lblTotalCTC = (Label)e.Row.FindControl("lblTotalCTC");



                lblTotalBasicPay.Text = BasicPay.ToString();
                lblTotalHouseAllowance.Text = HouseAllowance.ToString();
                lblTotalLunchAllowance.Text = LunchAllowance.ToString();
                lblTotalTransportAllowance.Text = TransportAllowance.ToString();
                lblTotalResponsibilityAllowance.Text = ResponsibilityAllowance.ToString();
                lblTotalSalesAndMarketingCommission.Text = SalesAndMarketingCommission.ToString();
                lblTotalGratuity.Text = Gratuity.ToString();
                lblTotalGrossPay.Text = GrossPay.ToString();
                lblTotalActualGrossPay.Text = ActualGrossPay.ToString();
                lblTotalNAPSA.Text = NAPSA.ToString();
                lblTotalNHIMA.Text = NHIMA.ToString();
                lblTotalPaye.Text = Paye.ToString();
                lblTotalSalaryAdvanceRepayment.Text = SalaryAdvancedRepayment.ToString();
                lblTotalZamboLoanRepayment.Text = ZamboLoanRepayment.ToString();

                lblTotalNetPay.Text = NetPay.ToString();
                lblTotalGratuity.Text = Gratuity.ToString();
                lblTotalNapsaCom.Text = NapsaCom.ToString();
                lblTotalCTC.Text = CTC.ToString();
            }
        }

    }
}