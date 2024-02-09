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
    public partial class Payroll_Generation : System.Web.UI.Page
    {
        Dal dal = new Dal();
        DataTable dt = new DataTable();
        int days = 0;


        public int DaysInMonth(string Month)
        {
            switch (Month)
            {
                case "January":
                    {
                        days = 31;
                        break;
                    }
                case "February":
                    {
                        // k=int.Parse(txtyear.Text ) %4;
                        int febmonth = int.Parse(txtYear.Text) % 4;
                        if (febmonth == 0)
                        {
                            days = 29;
                        }
                        else
                        {
                            days = 28;
                        }

                        break;
                    }
                case "March":
                    {
                        days = 31;
                        break;
                    }

                case "April":
                    {
                        days = 30;
                        break;
                    }
                case "May":
                    {
                        days = 31;
                        break;
                    }
                case "June":
                    {
                        days = 30;
                        break;
                    }
                case "July":
                    {
                        days = 31;
                        break;
                    }
                case "August":
                    {
                        days = 31;
                        break;
                    }
                case "September":
                    {
                        days = 30;
                        break;
                    }
                case "October":
                    {
                        days = 31;
                        break;
                    }
                case "November":
                    {
                        days = 30;
                        break;
                    }
                case "December":
                    {
                        days = 31;
                        break;
                    }

                    //default:

            }

            return days;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            txtYear.Text = DateTime.Now.Year.ToString();
            if (!IsPostBack)
            {
                BindPayrollApprovedGrid();
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

        public void BindPayrollApprovedGrid()
        {
            dt = dal.Fun_PayrollGeneration_Get("All");
            grdPayrollApproved.DataSource = dt;
            grdPayrollApproved.DataBind();
        }

        protected void grdPayrollApproved_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdPayrollApproved.PageIndex = e.NewPageIndex;
            BindPayrollApprovedGrid();
        }
        protected void lnkViewHistory_Click(object sender, EventArgs e)
        {
            BindPayrollApprovedGrid();
            grdPayrollApproved.Visible = true;
            grdPayrollGeneration.Visible = false;
            grdPayrollTotalSummary.Visible = false;
        }

        public void BindPayrollSummmaryGrid()
        {
            
            PayrollTotalSummary();
        }


        protected void btnPrint_Click(object sender, EventArgs e)
        {
            //Label lblCTC = (Label)grdPayrollGeneration.FooterRow.FindControl("lblTotalCTC");
            //var footer = (GridViewRow)((WebControl)sender).NamingContainer;
            //var lblTotalCTC = (Label)footer.FindControl("lblTotalCTC");
            //txtYear.Text = lblTotalCTC.Text;


        }

        public void PayrollTotalSummary()
        {
            dt = dal.Fun_PayrollTotalSummary(Convert.ToInt32(txtYear.Text), ddlMonth.SelectedValue);
            grdPayrollTotalSummary.DataSource = dt;
            grdPayrollTotalSummary.DataBind();
        }
        public void Clear()
        {
            ddlMonth.SelectedIndex = 0;
            txtCompanyWokringDays.Text = "";
            grdPayrollGeneration.Visible = false;
            grdPayrollTotalSummary.Visible = false;
            grdPayrollApproved.Visible = false;
            //  Response.Redirect("~/Payrolls/Payroll_Generation.aspx");
        }
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            Clear();
            panelmsg.Visible = false;
        }

        public void BindPayrollGenerationGrid(int Year,string Month)
        {
            dt = dal.Fun_PayrollGeneration(Year,Month);

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

        protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCompanyWokringDays.Text = DaysInMonth(ddlMonth.SelectedItem.ToString()).ToString();
            grdPayrollGeneration.Visible = true;
            grdPayrollTotalSummary.Visible = true;
            grdPayrollApproved.Visible = false;

            BindPayrollGenerationGrid(Convert.ToInt32(txtYear.Text), ddlMonth.SelectedValue);
            if (grdPayrollGeneration.Rows.Count > 0)
            {
                BindPayrollSummmaryGrid();

            }
            else
            {
                grdPayrollTotalSummary.Visible = false;
            }
        }


        protected void grdPayrollGeneration_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblEmployeName = (Label)e.Row.FindControl("lblEmployeName");
                // for full name
                e.Row.Cells[2].Text = string.Format("{0} {1} {2}", DataBinder.Eval(e.Row.DataItem, "FirstName"), DataBinder.Eval(e.Row.DataItem, "MiddleName"), DataBinder.Eval(e.Row.DataItem, "LastName"));


                // for calcualte footer sum

                //Label lblBasicPay = (Label)e.Row.FindControl("lblBasicPay");
                //Label lblHouseAllowance = (Label)e.Row.FindControl("lblHouseAllowance");
                //Label lblLunchAllowance = (Label)e.Row.FindControl("lblLunchAllowance");
                //Label lblTransportAllowance = (Label)e.Row.FindControl("lblTransportAllowance");
                //Label lblResponsibilityAllowance = (Label)e.Row.FindControl("lblResponsibilityAllowance");
                //Label lblGrossPay = (Label)e.Row.FindControl("lblGrossPay");
                //Label lblGrossPayRate = (Label)e.Row.FindControl("lblGrossPayRate");
                //Label lblActualGrossPay = (Label)e.Row.FindControl("lblActualGrossPay");
                //Label lblNAPSA = (Label)e.Row.FindControl("lblHouseAllowance");
                //Label lblNHIMA = (Label)e.Row.FindControl("lblNHIMA");
                //Label lblPaye = (Label)e.Row.FindControl("lblPaye");
                //Label lblNetPay = (Label)e.Row.FindControl("lblNetPay");

                //Label lblGratuity = (Label)e.Row.FindControl("lblGratuity");
                //Label lblNapsaCom = (Label)e.Row.FindControl("lblNapsaCom");
                //Label lblCTC = (Label)e.Row.FindControl("lblCTC");


                //BasicPay = BasicPay + Convert.ToDecimal(lblBasicPay.Text);
                //HouseAllowance = HouseAllowance + Convert.ToDecimal(lblHouseAllowance.Text);
                //LunchAllowance = LunchAllowance + Convert.ToDecimal(lblLunchAllowance.Text);
                //TransportAllowance = TransportAllowance + Convert.ToDecimal(lblTransportAllowance.Text);
                //ResponsibilityAllowance = ResponsibilityAllowance + Convert.ToDecimal(lblResponsibilityAllowance.Text);
                //GrossPay = GrossPay + Convert.ToDecimal(lblGrossPay.Text);
                //GrossPayRate = GrossPayRate + Convert.ToDecimal(lblGrossPayRate.Text);
                //ActualGrossPay = ActualGrossPay + Convert.ToDecimal(lblActualGrossPay.Text);
                //NAPSA = NAPSA + Convert.ToDecimal(lblNAPSA.Text);
                //NHIMA = NHIMA + Convert.ToDecimal(lblNHIMA.Text);
                //Paye = Paye + Convert.ToDecimal(lblPaye.Text);
                //NetPay = NetPay + Convert.ToDecimal(lblNetPay.Text);
                //Gratuity = Gratuity + Convert.ToDecimal(lblGratuity.Text);
                //NapsaCom = NapsaCom + Convert.ToDecimal(lblNapsaCom.Text);
                //CTC = CTC + Convert.ToDecimal(lblCTC.Text);

            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                //Label lblTotalBasicPay = (Label)e.Row.FindControl("lblTotalBasicPay");
                //Label lblTotalHouseAllowance = (Label)e.Row.FindControl("lblTotalHouseAllowance");
                //Label lblTotalLunchAllowance = (Label)e.Row.FindControl("lblTotalLunchAllowance");
                //Label lblTotalTransportAllowance = (Label)e.Row.FindControl("lblTotalTransportAllowance");
                //Label lblTotalResponsibilityAllowance = (Label)e.Row.FindControl("lblTotalResponsibilityAllowance");

                //Label lblTotalGrossPay = (Label)e.Row.FindControl("lblTotalGrossPay");
                //Label lblTotalActualGrossPay = (Label)e.Row.FindControl("lblTotalActualGrossPay");

                //Label lblTotalNAPSA = (Label)e.Row.FindControl("lblTotalNAPSA");
                //Label lblTotalNHIMA = (Label)e.Row.FindControl("lblTotalNHIMA");
                //Label lblTotalPaye = (Label)e.Row.FindControl("lblTotalPaye");
                //Label lblTotalNetPay = (Label)e.Row.FindControl("lblTotalNetPay");
                //Label lblTotalGratuity = (Label)e.Row.FindControl("lblTotalGratuity");
                //Label lblTotalNapsaCom = (Label)e.Row.FindControl("lblTotalNapsaCom");
                //Label lblTotalCTC = (Label)e.Row.FindControl("lblTotalCTC");



                //lblTotalBasicPay.Text = BasicPay.ToString();
                //lblTotalHouseAllowance.Text = HouseAllowance.ToString();
                //lblTotalLunchAllowance.Text = LunchAllowance.ToString();
                //lblTotalTransportAllowance.Text = TransportAllowance.ToString();
                //lblTotalResponsibilityAllowance.Text = ResponsibilityAllowance.ToString();
                //lblTotalGratuity.Text = Gratuity.ToString();
                //lblTotalGrossPay.Text = GrossPay.ToString();
                //lblTotalActualGrossPay.Text = ActualGrossPay.ToString();
                //lblTotalNAPSA.Text = NAPSA.ToString();
                //lblTotalNHIMA.Text = NHIMA.ToString();
                //lblTotalPaye.Text = Paye.ToString();
                //lblTotalNetPay.Text = NetPay.ToString();
                //lblTotalGratuity.Text = Gratuity.ToString();
                //lblTotalNapsaCom.Text = NapsaCom.ToString();
                //lblTotalCTC.Text = CTC.ToString();

            }

        }

        protected void txtSalesAndMarketingCommision_TextChanged(object sender, EventArgs e)
        {


            decimal totalSalescommision = 0;
            foreach (GridViewRow row in grdPayrollGeneration.Rows)
            {
                TextBox txtSalesAndMarketingCommision = (TextBox)row.FindControl("txtSalesAndMarketingCommision");
                Label lblReferenceId = (Label)row.FindControl("lblReferenceId");
                if (txtSalesAndMarketingCommision.Text != "")
                {
                    dt = dal.Fun_PayrollGeneration_SalesAndMarketing(Convert.ToInt32(txtYear.Text),ddlMonth.SelectedValue, Convert.ToInt32(lblReferenceId.Text),  Convert.ToDecimal(txtSalesAndMarketingCommision.Text));

                    BindPayrollGenerationGrid(Convert.ToInt32(txtYear.Text), ddlMonth.SelectedValue);
                }
            }
            //CalculateFooterSum();
        }


        protected void txtSalaryAdvancedRepayment_TextChanged(object sender, EventArgs e)
        {

            foreach (GridViewRow row in grdPayrollGeneration.Rows)
            {
                TextBox txtSalaryAdvancedRepayment = (TextBox)row.FindControl("txtSalaryAdvancedRepayment");
                Label lblReferenceId = (Label)row.FindControl("lblReferenceId");
                    if (txtSalaryAdvancedRepayment.Text != "")
                    {
                        dt = dal.Fun_PayrollGeneration_Deductions(Convert.ToInt32(txtYear.Text), ddlMonth.SelectedValue, Convert.ToInt32(lblReferenceId.Text), Convert.ToDecimal(txtSalaryAdvancedRepayment.Text),0,"SalaryAdvanced");
                    //grdPayrollGeneration.DataSource = dt;
                    //grdPayrollGeneration.DataBind();

                    BindPayrollGenerationGrid(Convert.ToInt32(txtYear.Text), ddlMonth.SelectedValue);

                }
                    
            }
           // CalculateFooterSum();

            BindPayrollSummmaryGrid();
            PayrollTotalSummary();

       

        }


        protected void txtZamboLoanRepayment_TextChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in grdPayrollGeneration.Rows)
            {
                TextBox txtZamboLoanRepayment = (TextBox)row.FindControl("txtZamboLoanRepayment");
                Label lblReferenceId = (Label)row.FindControl("lblReferenceId");
                if (txtZamboLoanRepayment.Text != "")
                {
                    dt = dal.Fun_PayrollGeneration_Deductions(Convert.ToInt32(txtYear.Text), ddlMonth.SelectedValue, Convert.ToInt32(lblReferenceId.Text), 0, Convert.ToDecimal(txtZamboLoanRepayment.Text),"ZamboLoan");
                    //grdPayrollGeneration.DataSource = dt;
                    //grdPayrollGeneration.DataBind();
                    BindPayrollGenerationGrid(Convert.ToInt32(txtYear.Text), ddlMonth.SelectedValue);
                }
                

            }
            BindPayrollSummmaryGrid();
            PayrollTotalSummary();
            //CalculateFooterSum();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if (ddlMonth.SelectedIndex == 0)
            {
                ShowPopUpMsg("Please Select Month");
            }
            else
            {
                panelmsg.Visible = true;
             
            }
            /// show in grid   
            ///  sno    payrollID  payroll month     payroll year    payroll date  summary   
            ///  // approval or reject   
            ///  two grids with same columns 

        }



        protected void grdPayrollGenerationDetails_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnyes_Click(object sender, EventArgs e)
        {
            dt = dal.Fun_PayrollGeneration_InsUpd(Convert.ToInt32(txtYear.Text), ddlMonth.SelectedItem.ToString(), null, "Pending", "Insert");
            int sno = Convert.ToInt32(dt.Rows[0]["sno"]);
            if (sno == 0)
            {

                panelmsg.Visible = false;
                ShowPopUpMsg("Payroll already generated for this month");

            }
            else
            {
                foreach (GridViewRow row in grdPayrollGeneration.Rows)
                {


                    Label lblReferenceId = (Label)row.FindControl("lblReferenceId");
                    
                    try
                    {

                        dt = dal.Fun_Payroll_Generation_Details_Active(Convert.ToInt32(lblReferenceId.Text), Convert.ToInt32(txtYear.Text), ddlMonth.SelectedItem.ToString());


                    }
                    catch (Exception ex)
                    {

                    }
                }
                if (dt.Rows.Count > 0)
                {
                    ShowPopUpMsg("Payroll Generated Successfully");
                }
                panelmsg.Visible = false;
                Clear();

            }

            //  Response.Redirect("~/Payrolls/Payroll_Approved.aspx");
        }

        protected void btnno_Click(object sender, EventArgs e)
        {
            Clear();
            panelmsg.Visible = false;
        }





     
        public void CalculateFooterSum()
        {

            decimal GrossPay = 0;
            decimal BasicPay = 0;
            decimal HouseAllowance = 0;
            decimal LunchAllowance = 0;
            decimal TransportAllowance = 0;
            decimal ResponsibilityAllowance = 0;
            decimal SalesAndMarketingCommission = 0;
            decimal TotalGrossPay = 0;
            decimal GrossPayRate = 0;
            decimal ActualGrossPay = 0;
            decimal NAPSA = 0;
            decimal NHIMA = 0;
            decimal Paye = 0;
            decimal SalaryAndAdvancedRepayment = 0;
            decimal ZamboLoanRepayment = 0;
            decimal NetPay = 0;
            decimal Gratuity = 0;
            decimal NapsaCom = 0;
            decimal CTC = 0;
        

            decimal TotalBasicPay = 0;
            decimal TotalHouseAllowance = 0;
            decimal TotalLunchAllowance = 0;
            decimal TotalTransportAllowance = 0;
            decimal TotalResponsibilityAllowance = 0;
            decimal TotalSalesAndMarketingCommission = 0;
            decimal TotalGrossPayRate = 0;
            decimal TotalActualGrossPay = 0;
            decimal TotalNAPSA = 0;
            decimal TotalNHIMA = 0;
            decimal TotalPaye = 0;
            decimal TotalSalaryAdvancedRepayment = 0;
            decimal TotalZamboLoanRepayment = 0;
            decimal TotalNetPay = 0;
            decimal TotalGratuity = 0;
            decimal TotalNapsaCom = 0;
            decimal TotalCTC = 0;

            foreach (GridViewRow row in grdPayrollGeneration.Rows)
            {

                Label lblReferenceId = (Label)row.FindControl("lblReferenceId");
                Label lblEmpNo = (Label)row.FindControl("lblEmpNo");
                Label lblEmployeName = (Label)row.FindControl("lblEmployeName");
                //lblEmployeName.Text = row.Cells[2].Text;
                Label lblBasicPay = (Label)row.FindControl("lblBasicPay");
                Label lblHouseAllowance = (Label)row.FindControl("lblHouseAllowance");
                Label lblLunchAllowance = (Label)row.FindControl("lblLunchAllowance");
                Label lblTransportAllowance = (Label)row.FindControl("lblTransportAllowance");
                Label lblResponsibilityAllowance = (Label)row.FindControl("lblResponsibilityAllowance");
                Label lblTotalAllowance = (Label)row.FindControl("lblTotalAllowance");
                TextBox txtSalesAndMarketingCommision = (TextBox)row.FindControl("txtSalesAndMarketingCommision");
                Label lblGrossPay = (Label)row.FindControl("lblGrossPay");
                Label lblPresentDays = (Label)row.FindControl("lblPresentDays");
                Label lblGrossPayRate = (Label)row.FindControl("lblGrossPayRate");
                Label lblActualGrossPay = (Label)row.FindControl("lblActualGrossPay");
                Label lblNAPSA = (Label)row.FindControl("lblNAPSA");
                Label lblNHIMA = (Label)row.FindControl("lblNHIMA");
                Label lblPaye = (Label)row.FindControl("lblPaye");
                TextBox txtSalaryAdvancedRepayment = (TextBox)row.FindControl("txtSalaryAdvancedRepayment");
                TextBox txtZamboLoanRepayment = (TextBox)row.FindControl("txtZamboLoanRepayment");
                Label lblNetPay = (Label)row.FindControl("lblNetPay");
                Label lblAccountNo = (Label)row.FindControl("lblAccountNo");
                Label lblGratuity = (Label)row.FindControl("lblGratuity");
                Label lblNapsaCom = (Label)row.FindControl("lblNapsaCom");
                Label lblCTC = (Label)row.FindControl("lblCTC");

                if (!string.IsNullOrEmpty(lblBasicPay.Text))
                {
                    BasicPay = Convert.ToDecimal(lblBasicPay.Text);
                }

                if (!string.IsNullOrEmpty(lblHouseAllowance.Text))
                {
                    HouseAllowance = Convert.ToDecimal(lblHouseAllowance.Text);
                }
                if (!string.IsNullOrEmpty(lblLunchAllowance.Text))
                {
                    LunchAllowance = Convert.ToDecimal(lblLunchAllowance.Text);
                }

                if (!string.IsNullOrEmpty(lblTransportAllowance.Text))
                {
                    TransportAllowance = Convert.ToDecimal(lblTransportAllowance.Text);
                }
                if (!string.IsNullOrEmpty(lblResponsibilityAllowance.Text))
                {
                    ResponsibilityAllowance = Convert.ToDecimal(lblResponsibilityAllowance.Text);
                }
                if (!string.IsNullOrEmpty(txtSalesAndMarketingCommision.Text))
                {
                    SalesAndMarketingCommission = Convert.ToDecimal(txtSalesAndMarketingCommision.Text);
                }


                if (!string.IsNullOrEmpty(lblGrossPay.Text))
                {
                    GrossPay = Convert.ToDecimal(lblGrossPay.Text);
                }


                if (!string.IsNullOrEmpty(lblGrossPayRate.Text))
                {
                    GrossPayRate = Convert.ToDecimal(lblGrossPayRate.Text);
                }

                if (!string.IsNullOrEmpty(lblActualGrossPay.Text))
                {
                    ActualGrossPay = Convert.ToDecimal(lblActualGrossPay.Text);
                }
                if (!string.IsNullOrEmpty(lblNAPSA.Text))
                {
                    NAPSA = Convert.ToDecimal(lblNAPSA.Text);
                }

                if (!string.IsNullOrEmpty(lblNHIMA.Text))
                {
                    NHIMA = Convert.ToDecimal(lblNHIMA.Text);
                }
                if (!string.IsNullOrEmpty(lblPaye.Text))
                {
                    Paye = Convert.ToDecimal(lblPaye.Text);
                }
                if (!string.IsNullOrEmpty(lblNetPay.Text))
                {
                    NetPay = Convert.ToDecimal(lblNetPay.Text);
                }

                if (!string.IsNullOrEmpty(txtSalaryAdvancedRepayment.Text))
                {
                    SalaryAndAdvancedRepayment = Convert.ToDecimal(txtSalaryAdvancedRepayment.Text);
                }
                if (!string.IsNullOrEmpty(txtZamboLoanRepayment.Text))
                {
                    ZamboLoanRepayment = Convert.ToDecimal(txtZamboLoanRepayment.Text);
                }

                if (!string.IsNullOrEmpty(lblGratuity.Text))
                {
                    Gratuity = Convert.ToDecimal(lblGratuity.Text);
                }

                if (!string.IsNullOrEmpty(lblNapsaCom.Text))
                {
                    NapsaCom = Convert.ToDecimal(lblNapsaCom.Text);
                }
                if (!string.IsNullOrEmpty(lblCTC.Text))
                {
                    CTC = Convert.ToDecimal(lblCTC.Text);
                }


                Label lblTotalBasicPay = (Label)grdPayrollGeneration.FooterRow.FindControl("lblTotalBasicPay");
                Label lblTotalHouseAllowance = (Label)grdPayrollGeneration.FooterRow.FindControl("lblTotalHouseAllowance");
                Label lblTotalLunchAllowance = (Label)grdPayrollGeneration.FooterRow.FindControl("lblTotalLunchAllowance");
                Label lblTotalTransportAllowance = (Label)grdPayrollGeneration.FooterRow.FindControl("lblTotalTransportAllowance");
                Label lblTotalResponsibilityAllowance = (Label)grdPayrollGeneration.FooterRow.FindControl("lblTotalResponsibilityAllowance");
                Label lblTotalGrossPayRate = (Label)grdPayrollGeneration.FooterRow.FindControl("lblTotalGrossPayRate");
                Label lblTotalSalesAndMarketingCommission = (Label)grdPayrollGeneration.FooterRow.FindControl("lblTotalSalesAndMarketingCommission");

                Label lblTotalGrossPay = (Label)grdPayrollGeneration.FooterRow.FindControl("lblTotalGrossPay");

                Label lblTotalActualGrossPay = (Label)grdPayrollGeneration.FooterRow.FindControl("lblTotalActualGrossPay");
                Label lblTotalNAPSA = (Label)grdPayrollGeneration.FooterRow.FindControl("lblTotalNAPSA");
                Label lblTotalNHIMA = (Label)grdPayrollGeneration.FooterRow.FindControl("lblTotalNHIMA");
                Label lblTotalPaye = (Label)grdPayrollGeneration.FooterRow.FindControl("lblTotalPaye");
                Label lblTotalNetPay = (Label)grdPayrollGeneration.FooterRow.FindControl("lblTotalNetPay");
                Label lblTotalGratuity = (Label)grdPayrollGeneration.FooterRow.FindControl("lblTotalGratuity");
                Label lblTotalSalaryAdvanceRepayment = (Label)grdPayrollGeneration.FooterRow.FindControl("lblTotalSalaryAdvanceRepayment");
                Label lblTotalZamboLoanRepayment = (Label)grdPayrollGeneration.FooterRow.FindControl("lblTotalZamboLoanRepayment");
                Label lblTotalNapsaCom = (Label)grdPayrollGeneration.FooterRow.FindControl("lblTotalNapsaCom");
                Label lblTotalCTC = (Label)grdPayrollGeneration.FooterRow.FindControl("lblTotalCTC");


                TotalBasicPay = TotalBasicPay + BasicPay;
                TotalHouseAllowance = TotalHouseAllowance + HouseAllowance;
                TotalLunchAllowance = TotalLunchAllowance + LunchAllowance;
                TotalTransportAllowance = TotalTransportAllowance + TransportAllowance;
                TotalResponsibilityAllowance = TotalResponsibilityAllowance + ResponsibilityAllowance;
                if (!string.IsNullOrEmpty(lblTotalSalesAndMarketingCommission.Text))
                {
                    TotalSalesAndMarketingCommission = Convert.ToDecimal(lblTotalSalesAndMarketingCommission.Text) + SalesAndMarketingCommission;
                }
                TotalGrossPay = TotalGrossPay + GrossPay;

                TotalGrossPayRate = TotalGrossPayRate + GrossPayRate;
                TotalActualGrossPay = TotalActualGrossPay + ActualGrossPay;
                TotalNAPSA = TotalNAPSA + NAPSA;
                TotalNHIMA = TotalNHIMA + NHIMA;
                TotalPaye = TotalPaye + Paye;
                TotalSalaryAdvancedRepayment = TotalSalaryAdvancedRepayment + SalaryAndAdvancedRepayment;
                TotalZamboLoanRepayment = TotalZamboLoanRepayment + ZamboLoanRepayment;
                TotalNetPay = TotalNetPay + NetPay;
                TotalGratuity = TotalGratuity + Gratuity;
                TotalNapsaCom = TotalNapsaCom + NapsaCom;
                TotalCTC = TotalCTC + CTC;


                lblTotalBasicPay.Text = TotalBasicPay.ToString();
                lblTotalHouseAllowance.Text = TotalHouseAllowance.ToString();
                lblTotalLunchAllowance.Text = TotalLunchAllowance.ToString();
                lblTotalTransportAllowance.Text = TotalTransportAllowance.ToString();
                lblTotalResponsibilityAllowance.Text = TotalResponsibilityAllowance.ToString();
                lblTotalSalesAndMarketingCommission.Text = TotalSalesAndMarketingCommission.ToString();
                lblTotalGrossPay.Text = TotalGrossPay.ToString();
                lblTotalGrossPayRate.Text = TotalGrossPayRate.ToString();
                lblTotalActualGrossPay.Text = TotalActualGrossPay.ToString();
                lblTotalNAPSA.Text = TotalNAPSA.ToString();
                lblTotalNHIMA.Text = TotalNHIMA.ToString();
                lblTotalPaye.Text = TotalPaye.ToString();
                lblTotalSalaryAdvanceRepayment.Text = SalaryAndAdvancedRepayment.ToString();
                lblTotalZamboLoanRepayment.Text = TotalZamboLoanRepayment.ToString();
                lblTotalNetPay.Text = TotalNetPay.ToString();
                lblTotalGratuity.Text = TotalGratuity.ToString();
                lblTotalNapsaCom.Text = TotalNapsaCom.ToString();
                lblTotalCTC.Text = TotalCTC.ToString();



            }

        }


 

        public void CalcuationSalesAndMarektingCommission(decimal salesandmarketingcommission)
        {
            decimal GrossPay = 0;
            decimal BasicPay = 0;
            decimal TotalAllowance = 0;
            decimal SalesAndMarketingCommission = 0;
            decimal GrossPayRate = 0;
            decimal ActualGrossPay = 0;
            decimal NAPSA = 0;
            decimal NHIMA = 0;
            decimal Paye = 0;
            decimal SalaryAndAdvancedRepayment = 0;
            decimal ZamboLoanRepayment = 0;
            decimal NetPay = 0;
            decimal Gratuity = 0;
            decimal NapsaCom = 0;
            decimal CTC = 0;
            decimal BasicPayRate = 0;
            decimal ActualBasicPay = 0;
            decimal NapsaEmploye = 0;
            decimal NapsaEmployer = 0;
            decimal TotalDeductions = 0;
            decimal NapsaCompany = 0;
            decimal TotalSalesAndMarketingCommission = 0;
            int PresentDays = 0;


            
            foreach (GridViewRow row in grdPayrollGeneration.Rows)
            {
                Label lblTotalAllowance = (Label)row.FindControl("lblTotalAllowance");
                Label lblBasicPay = (Label)row.FindControl("lblBasicPay");

                Label lblGrossPay = (Label)row.FindControl("lblGrossPay");
                Label lblPresentDays = (Label)row.FindControl("lblPresentDays");
                Label lblGrossPayRate = (Label)row.FindControl("lblGrossPayRate");
                Label lblActualGrossPay = (Label)row.FindControl("lblActualGrossPay");
                Label lblNAPSA = (Label)row.FindControl("lblNAPSA");
                Label lblPaye = (Label)row.FindControl("lblPaye");
                Label lblNHIMA = (Label)row.FindControl("lblNHIMA");
                Label lblNAPSARange = (Label)row.FindControl("lblNAPSARange");

                TextBox txtSalesAndMarketingCommision = (TextBox)row.FindControl("txtSalesAndMarketingCommision");
                TextBox txtSalaryAdvancedRepayment = (TextBox)row.FindControl("txtSalaryAdvancedRepayment");
                TextBox txtZamboLoanRepayment = (TextBox)row.FindControl("txtZamboLoanRepayment");


                Label lblNetPay = (Label)row.FindControl("lblNetPay");
                Label lblAccountNo = (Label)row.FindControl("lblAccountNo");
                Label lblGratuity = (Label)row.FindControl("lblGratuity");
                Label lblNapsaCom = (Label)row.FindControl("lblNapsaCom");
                Label lblCTC = (Label)row.FindControl("lblCTC");




                if (!string.IsNullOrEmpty(lblBasicPay.Text))
                {
                    BasicPay = Convert.ToDecimal(lblBasicPay.Text);
                }

                if (!string.IsNullOrEmpty(txtSalesAndMarketingCommision.Text))
                {
                    SalesAndMarketingCommission = Convert.ToDecimal(txtSalesAndMarketingCommision.Text);
                }


                if (!string.IsNullOrEmpty(lblGrossPay.Text))
                {
                    GrossPay = Convert.ToDecimal(lblGrossPay.Text);
                }


                if (!string.IsNullOrEmpty(lblGrossPayRate.Text))
                {
                    GrossPayRate = Convert.ToDecimal(lblGrossPayRate.Text);
                }

                if (!string.IsNullOrEmpty(lblActualGrossPay.Text))
                {
                    ActualGrossPay = Convert.ToDecimal(lblActualGrossPay.Text);
                }
                if (!string.IsNullOrEmpty(lblNAPSA.Text))
                {
                    NAPSA = Convert.ToDecimal(lblNAPSA.Text);
                }

                if (!string.IsNullOrEmpty(lblNHIMA.Text))
                {
                    NHIMA = Convert.ToDecimal(lblNHIMA.Text);
                }
                if (!string.IsNullOrEmpty(lblPaye.Text))
                {
                    Paye = Convert.ToDecimal(lblPaye.Text);
                }
                if (!string.IsNullOrEmpty(lblNetPay.Text))
                {
                    NetPay = Convert.ToDecimal(lblNetPay.Text);
                }

                if (!string.IsNullOrEmpty(txtSalaryAdvancedRepayment.Text))
                {
                    SalaryAndAdvancedRepayment = Convert.ToDecimal(txtSalaryAdvancedRepayment.Text);
                }
                if (!string.IsNullOrEmpty(txtZamboLoanRepayment.Text))
                {
                    ZamboLoanRepayment = Convert.ToDecimal(txtZamboLoanRepayment.Text);
                }

                if (!string.IsNullOrEmpty(lblGratuity.Text))
                {
                    Gratuity = Convert.ToDecimal(lblGratuity.Text);
                }

                if (!string.IsNullOrEmpty(lblNapsaCom.Text))
                {
                    NapsaCom = Convert.ToDecimal(lblNapsaCom.Text);
                }
                if (!string.IsNullOrEmpty(lblCTC.Text))
                {
                    CTC = Convert.ToDecimal(lblCTC.Text);
                }
                if (txtSalesAndMarketingCommision.Text != "")
                {

                    TotalSalesAndMarketingCommission += Convert.ToDecimal(txtSalesAndMarketingCommision.Text);
                    Label lblTotalSalesAndMarketingCommission = (Label)grdPayrollGeneration.FooterRow.FindControl("lblTotalSalesAndMarketingCommission");
                    lblTotalSalesAndMarketingCommission.Text = TotalSalesAndMarketingCommission.ToString();

                }


                if (txtSalesAndMarketingCommision.Text != "")
                {
                    salesandmarketingcommission = Convert.ToDecimal(txtSalesAndMarketingCommision.Text);
                }
                if (txtSalaryAdvancedRepayment.Text != "")
                {
                    SalaryAndAdvancedRepayment = Convert.ToDecimal(txtSalaryAdvancedRepayment.Text);
                }
                if (txtZamboLoanRepayment.Text != "")
                {
                    ZamboLoanRepayment = Convert.ToDecimal(txtZamboLoanRepayment.Text);
                }
                if (lblPresentDays.Text != "")
                {
                    PresentDays = Convert.ToInt32(lblPresentDays.Text);
                }

                decimal TotalNapsa = NapsaEmploye + NapsaEmployer;
                decimal NapsaRange = Convert.ToDecimal(lblNAPSARange.Text);

                TotalAllowance = TotalAllowance + salesandmarketingcommission;
                GrossPay = BasicPay + TotalAllowance;
                //GrossPayRate = GrossPay / Convert.ToDecimal(DaysInMonth(ddlMonth.SelectedItem.ToString()));
                //BasicPayRate = BasicPay / Convert.ToDecimal(DaysInMonth(ddlMonth.SelectedItem.ToString()));
                GrossPayRate = GrossPay / PresentDays;
                BasicPayRate = BasicPay / PresentDays;
                ActualBasicPay = PresentDays * BasicPayRate;
                ActualGrossPay = PresentDays * GrossPayRate;

                NapsaEmploye = Convert.ToDecimal(5) / 100 * ActualGrossPay;
                NapsaEmployer = Convert.ToDecimal(5) / 100 * ActualGrossPay;
                NHIMA = Convert.ToDecimal(1) / 100 * ActualBasicPay;
                TotalDeductions = NapsaEmploye + NHIMA + SalaryAndAdvancedRepayment + ZamboLoanRepayment;
                NetPay = ActualGrossPay - TotalDeductions;
                Gratuity = (Convert.ToDecimal(25) / 100) * Convert.ToDecimal(ActualGrossPay);
                CTC = NetPay + Gratuity + NapsaCompany;


                //if (TotalNapsa > NapsaRange)
                //{
                //    NapsaEmploye = NapsaRange;
                //}

                lblGrossPay.Text = GrossPay.ToString("0.00");
                lblGrossPayRate.Text = GrossPayRate.ToString("0.00");
                lblActualGrossPay.Text = ActualGrossPay.ToString("0.00");
                lblNAPSA.Text = NapsaEmploye.ToString("0.00");
                lblNHIMA.Text = NHIMA.ToString("0.00");
            }
        }

        public void Calculations()
        {

            decimal SalaryAdvancedRepayment = 0;
            decimal ActualGrossPay = 0;
            decimal NAPSA = 0;
            decimal NHIMA = 0;
            decimal Paye = 0;
            decimal ZamboLoanRepayment = 0;
            decimal NetPay = 0;
            decimal Gratuity = 0;
            decimal CTC = 0;
            decimal NapsaEmploye = 0;
            decimal TotalDeductions = 0;
            decimal NapsaCompany = 0;
            

            foreach (GridViewRow row in grdPayrollGeneration.Rows)
            {
                Label lblNAPSA = (Label)row.FindControl("lblNAPSA");
                Label lblNHIMA = (Label)row.FindControl("lblNHIMA");
                Label lblActualGrossPay = (Label)row.FindControl("lblActualGrossPay");

                Label lblNetPay = (Label)row.FindControl("lblNetPay");
                Label lblGratuity = (Label)row.FindControl("lblGratuity");
                Label lblNapsaCom = (Label)row.FindControl("lblNapsaCom");
                Label lblCTC = (Label)row.FindControl("lblCTC");

                TextBox txtSalaryAdvancedRepayment = (TextBox)row.FindControl("txtSalaryAdvancedRepayment");
                TextBox txtZamboLoanRepayment = (TextBox)row.FindControl("txtZamboLoanRepayment");

                if (lblNAPSA.Text != "")
                {
                    NAPSA = Convert.ToDecimal(lblNAPSA.Text);

                }

                if (lblNHIMA.Text != "")
                {
                    NHIMA = Convert.ToDecimal(lblNHIMA.Text);

                }
                if (lblActualGrossPay.Text != "")
                {
                    ActualGrossPay = Convert.ToDecimal(lblActualGrossPay.Text);

                }

                if (txtSalaryAdvancedRepayment.Text != "")
                {
                    SalaryAdvancedRepayment = Convert.ToDecimal(txtSalaryAdvancedRepayment.Text);

                }
                if (txtZamboLoanRepayment.Text != "")
                {
                    ZamboLoanRepayment = Convert.ToDecimal(txtZamboLoanRepayment.Text);
                }
                if (lblGratuity.Text != "")
                {
                    Gratuity = Convert.ToDecimal(lblGratuity.Text);
                }


                TotalDeductions = NapsaEmploye + NHIMA + SalaryAdvancedRepayment + ZamboLoanRepayment;
                NetPay = ActualGrossPay - TotalDeductions;
                Gratuity = (Convert.ToDecimal(25) / 100) * Convert.ToDecimal(ActualGrossPay);
                CTC = NetPay + Gratuity + NapsaCompany;




                lblNetPay.Text = NetPay.ToString("0.00");
                lblGratuity.Text = Gratuity.ToString("0.00");
                lblNapsaCom.Text = NAPSA.ToString("0.00");
                lblCTC.Text = CTC.ToString("0.00");
            }

        }

        protected void grdPayrollApproved_SelectedIndexChanged(object sender, EventArgs e)
        {

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