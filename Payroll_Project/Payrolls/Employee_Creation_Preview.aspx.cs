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
    public partial class Employee_Creation_Preview : System.Web.UI.Page
    {
        Dal dal = new Dal();
        static string fs = "", fs1 = "", path = "";
        DataTable dt = new DataTable();
        public bool InsertLastRec = false;
        int now; int count = 0;
        string Msg = null;


        protected void Page_Load(object sender, EventArgs e)
        {

            int ReferenceId = Convert.ToInt32(Request.QueryString["ReferenceId"]);
            BindDetails(ReferenceId);
            BindContributionGridview(ReferenceId);
            BindAllowancesGridview(ReferenceId);
            BindDeductionsGridView();
            SalarySummary();

            //BindDetails("401");
            //BindContributionGridview("401");
            //BindAllowancesGridview("401");
            //BindDeductionsGridView();
            //SalarySummary();

        }

        public void BindDetails(int ReferenceId)
        {

            dt = dal.Fun_Emp_Details_GetbyReferenceId(ReferenceId);
            if (dt.Rows.Count > 0)
            {

                DataRow row = dt.Rows[0];

                txtFirstName.Text = row["first_name"].ToString();
                txtMiddleName.Text = row["middle_name"].ToString();
                txtLastName.Text = row["last_name"].ToString();
                txtEmpNo.Text = row["employee_no"].ToString();
                txtGender.Text = (row["gen"].ToString());
                txtMaritialStatus.Text = row["martial_status"].ToString();
                txtAddress.Text = row["address"].ToString();
                txtAddress1.Text = row["address1"].ToString();
                txtCompanyLocation.Text = "Zambia";
                //txtCompanyLocation.Text = row["location_name"].ToString();
                txtWorkLocation.Text = row["working_location"].ToString();
                //txtDob.Text = row["dob"].ToString();
                txtDob.Text = System.Convert.ToDateTime(dt.Rows[0]["dob"]).ToString(dal.dateFormat);
                txtEmpon.Text = System.Convert.ToDateTime(dt.Rows[0]["employed_on"]).ToString(dal.dateFormat);
                txtContractStart.Text = System.Convert.ToDateTime(dt.Rows[0]["contract_start"]).ToString(dal.dateFormat);
                txtContractExpired.Text = System.Convert.ToDateTime(dt.Rows[0]["contract_expired"]).ToString(dal.dateFormat);
                txtContractRenuval.Text = System.Convert.ToDateTime(dt.Rows[0]["contract_renewal"]).ToString(dal.dateFormat);
                txtPosition.Text = row["PositionName"].ToString();
                txtDepartment.Text = row["deptname"].ToString();
                txtShiftType.Text = row["shift_type"].ToString();
                txtBankName.Text = row["bank_name"].ToString();
                txtBankBranch.Text = row["Bankbranch"].ToString();
                txtAccountno.Text = row["account_no"].ToString();
                txtPassport.Text = row["Passport"].ToString();
                txtChildren.Text = row["children"].ToString();
                txtSpouse.Text = row["spouse"].ToString();
                txtStatus.Text = row["status"].ToString();
                txtEmploymentType.Text = row["EmployementType"].ToString();
                image.ImageUrl = row["photo_id"].ToString();
                imgSignature.ImageUrl = row["signature"].ToString();
                txtBasicPay.Text = row["basic_pay"].ToString();
                txtEmailId.Text = row["emailId"].ToString();
                txtMobileNo.Text = row["MobileNo"].ToString();
                txtTitle.Text = row["title"].ToString();
                TxtNRCNo.Text = row["Nrcno"].ToString();
                txtTPin.Text = row["TPin"].ToString();
                txtSocio_Security_No.Text = row["Socio_Security_No"].ToString();

                lblAllowanceBasicPay.Text = row["basic_pay"].ToString();
                lblDeductionBasicPay.Text = row["basic_pay"].ToString();
                //lblAllowanceBasicPay.Text = row["basic_pay"].ToString();
                //lblDeductionBasicPay.Text = row["basic_pay"].ToString();
                //BindAllowancesGridview(txtEmpNo.Text);
                //BindContributionGridview(txtEmpNo.Text);
                //grdContribution.DataSource = dt;
                //grdContribution.DataBind();
            }
        }

        protected void BindContributionGridview(int ReferenceId)
        {

            dt = dal.Fun_EmployeeContribution_Get(ReferenceId, "SearchbyId");
            dt.Columns.Remove("sno1");
            dt.Columns.Remove("employee_no");
            dt.Columns.Remove("percentage1");
            dt.Columns.Remove("value1");
            dt.Columns.Remove("ReferenceId");
            grdContribution.DataSource = dt;
            grdContribution.DataBind();

        }

        protected void BindAllowancesGridview(int ReferenceId)
        {
            dt = dal.Fun_EmployeeAllowanc_Get(ReferenceId, "SearchbyId");
            dt.Columns.Remove("employee_no");
            dt.Columns.Remove("type");
            dt.Columns.Remove("company_location");
            dt.Columns.Remove("working_location");
            dt.Columns.Remove("Tran_no");
            dt.Columns.Remove("ReferenceId");
            dt.Columns.Remove("AllowanceId");
            dt.Columns.Add("CalculatedAmount");
            grdAllowances.DataSource = dt;
            grdAllowances.DataBind();
            double TotalCalculatedAmount = CalculateTotalAllowances();
            double basicpay = Convert.ToDouble(txtBasicPay.Text);
            double grossSalary = 0;

            grossSalary = basicpay + TotalCalculatedAmount;
            lblAllowancesTotalAmount.Text = TotalCalculatedAmount.ToString();
            lblAllowanceGrossAmount.Text = grossSalary.ToString();
        }
        public void BindDeductionsGridView()
        {
            // DataTable dt = new DataTable();
            // //  DataRow dr = null;
            // dt.Columns.Add(new DataColumn("Type", typeof(string)));
            // dt.Columns.Add(new DataColumn("Amount", typeof(string)));

            // //dt.Columns.Add(new DataColumn("NAPSA", typeof(string)));
            // //dt.Columns.Add(new DataColumn("NHIMA", typeof(string)));
            // //dt.Columns.Add(new DataColumn("Paye", typeof(string)));


            // //dr["sno"] = 1;
            // double BasicPay = Convert.ToDouble(txtBasicPay.Text);
            // double GrossPay = Convert.ToDouble(lblAllowanceGrossAmount.Text);

            // if (txtBasicPay.Text != "")
            // {
            //     BasicPay = Convert.ToDouble(txtBasicPay.Text);

            // }
            // //if (lblAllowanceGrossAmount.Text != "")
            // //{

            // //    GrossPay = Convert.ToDouble(lblAllowanceGrossAmount.Text);
            // //}

            //// double Paye = Convert.ToDouble(txtBasicPay.Text);
            // double NapsaEmploye = Convert.ToDouble(5) / 100 * GrossPay;
            // double NapsaEmployer = Convert.ToDouble(5) / 100 * GrossPay; ;
            // double NHIMA = Convert.ToDouble(1) / 100 * BasicPay;
            // double Gratuity = (Convert.ToDouble(25) / 100) * Convert.ToDouble(BasicPay);


            // DataRow dr1 = dt.NewRow();
            // dr1["Type"] = "NAPSA Employee @ 5% of Earned  Gross Salary";
            // dr1["Amount"] = NapsaEmploye.ToString();
            // dt.Rows.Add(dr1);

            // DataRow dr2 = dt.NewRow();
            // dr2["Type"] = "NAPSA Employer  @ 5% of Earned Gross Salary";
            // dr2["Amount"] = NapsaEmployer.ToString();
            // dt.Rows.Add(dr2);

            // DataRow dr3 = dt.NewRow();
            // dr3["Type"] = "NHIMA @ 1% of Basic Pay";
            // dr3["Amount"] = NHIMA.ToString();
            // dt.Rows.Add(dr3);

            // DataRow dr4 = dt.NewRow();
            // dr4["Type"] = "Pay e";
            // dr4["Amount"] = "Paye at Actuals";
            // dt.Rows.Add(dr4);

            // DataRow dr5 = dt.NewRow();
            // dr5["Type"] = "Gratuity @ 25% of Basic Pay";
            // dr5["Amount"] = Gratuity.ToString();
            // dt.Rows.Add(dr5);
            //int ReferenceId = Convert.ToInt32(Request.QueryString["ReferenceId"]);
            //dt = dal.Fun_EmployeeDeductions_Get(ReferenceId, "SearchbyId");


            dt = dal.Fun_CalculateDeductions_Get(Convert.ToDecimal(txtBasicPay.Text), Convert.ToDecimal(lblAllowanceGrossAmount.Text));
            grdDeductions.DataSource = dt;
            grdDeductions.DataBind();

            lblTotalDeductions.Text = CalculateTotalDeductions().ToString();
            lblDeductionGrossSalary.Text = lblAllowanceGrossAmount.Text;
            lblDeductionsCTC.Text = CalculateDeductionCTC().ToString();

        }

        public double CalculateTotalAllowances()
        {
            double TotalCalculatedAmount = 0;
            double basicpay = Convert.ToDouble(txtBasicPay.Text);

            for (int i = 0; i < grdAllowances.Rows.Count; i++)
            {
                string Percentage = (grdAllowances.Rows[i].Cells[1]).Text;
                string Amount = (grdAllowances.Rows[i].Cells[2]).Text;
                double CalculatedAmout = (basicpay * Convert.ToDouble(Percentage)) / 100;

                if (Percentage != "0")
                {
                    grdAllowances.Rows[i].Cells[3].Text = CalculatedAmout.ToString();
                    TotalCalculatedAmount += CalculatedAmout;
                }

                if (Amount != "0")
                {
                    grdAllowances.Rows[i].Cells[3].Text = (Amount).ToString();
                    TotalCalculatedAmount += Convert.ToDouble(Amount);
                }
                //TotalCalculatedAmount += CalculatedAmout;
            }
            return TotalCalculatedAmount;
        }

        public double CalculateTotalDeductions()
        {

            double deductions = 0;
            double Totaldeductions = 0;
            foreach (GridViewRow row in grdDeductions.Rows)
            {

                TextBox txttotalDeductions = (TextBox)row.FindControl("txtDeductionAmount");
                //if (row.RowIndex != 3)
                {
                    deductions = Convert.ToDouble(txttotalDeductions.Text);
                    Totaldeductions += deductions;
                }
            }
            return Totaldeductions;
        }

        public double CalculateDeductionCTC()
        {
            double CTC = 0;
            double deductions = 0;
            double grossSaalary = Convert.ToDouble(lblAllowanceGrossAmount.Text);
            double napsaEmployer = 0;
            double gratuity = 0;
            foreach (GridViewRow row in grdDeductions.Rows)
            {
                Label lblDeductionName = (Label)row.FindControl("lblDeductionName");
                TextBox txttotalDeductions = (TextBox)row.FindControl("txtDeductionAmount");
                if (lblDeductionName.Text == "NAPSA Employer")
                {
                    napsaEmployer = Convert.ToDouble(txttotalDeductions.Text);
                }
                if (lblDeductionName.Text == "Gratuity")
                {
                    gratuity = Convert.ToDouble(txttotalDeductions.Text);
                }

                //if (txttotalDeductions.Text != "")
                //{
                //    if (row.RowIndex == 1)
                //    {
                //        deductions = Convert.ToDouble(txttotalDeductions.Text);
                //        napsaEmployer = deductions;
                //    }

                //    if (row.RowIndex == 3)
                //    {
                //        deductions = Convert.ToDouble(txttotalDeductions.Text);
                //        gratuity = deductions;
                //    }
                //}
            }
            CTC = grossSaalary + napsaEmployer + gratuity;
            return CTC;
        }

        public void SalarySummary()
        {

            //decimal BasicPay = Convert.ToDouble(txtBasicPay.Text);
            //decimal grossSaalary = Convert.ToDouble(lblAllowanceGrossAmount.Text);
            //decimal NapsaEmployer = Convert.ToDouble(5) / 100 * grossSaalary;
            ////double Nhima = Convert.ToDouble(1)/100 * Convert.ToDouble(BasicPay);
            ////double Gratuity = (Convert.ToDouble(25) / 100) * Convert.ToDouble(BasicPay);
            //decimal CTCContribution = Gratuity + NapsaEmployer;// gratuity +napsaEmployer
            //decimal netSalary = grossSaalary - Convert.ToDouble(lblTotalDeductions.Text);// grossSalary -standardDeductions
            //decimal TotalCTC = netSalary + CTCContribution;
            //decimal StadnardDeductions = NapsaEmployer + Nhima;


            decimal Napsa = 0;
            decimal Nhima = 0;
            decimal Gratuity = 0;
            decimal StandardDeductions = 0;
            decimal netSalary = 0;
            decimal grossSaalary = Convert.ToDecimal(lblAllowanceGrossAmount.Text);
            decimal CTCContribution = 0;
            decimal TotalCTC = 0;

            dt = dal.Fun_CalculateDeductions_Get(Convert.ToDecimal(txtBasicPay.Text), Convert.ToDecimal(lblAllowanceGrossAmount.Text));
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                if(dt.Rows[i]["Name"].ToString() == "NAPSA")
                {
                    Napsa = Convert.ToDecimal(dt.Rows[i]["Amount"]);
                }
                if (dt.Rows[i]["Name"].ToString() == "NHIMA")
                {
                    Nhima = Convert.ToDecimal(dt.Rows[i]["Amount"]);
                }
                if (dt.Rows[i]["Name"].ToString() == "Gratuity")
                {
                    Gratuity = Convert.ToDecimal(dt.Rows[i]["Amount"]);
                }
            }

            StandardDeductions = Napsa + Nhima;
            //  netSalary = grossSaalary - Convert.ToDecimal(lblTotalDeductions.Text);
            netSalary = grossSaalary - StandardDeductions;
            CTCContribution = Gratuity + Napsa;
            TotalCTC = grossSaalary +Gratuity+Napsa;

            lblSalarySummaryBasicPay.Text = txtBasicPay.Text;
            lblSalarySummaryTotalAllowance.Text = lblAllowancesTotalAmount.Text;
            lblSalarySummaryGrossPay.Text = lblAllowanceGrossAmount.Text;
            lblSalarySummaryStandardDeductions.Text = StandardDeductions.ToString();
            lblSalarySummaryNetSalary.Text = netSalary.ToString();
            lblSalarySummaryCTCContribution.Text = CTCContribution.ToString();
            lblSalarySummaryTotalCTC.Text = TotalCTC.ToString();
            
        }



        protected void btnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("Employee_Creation.aspx");
        }

        protected void grdAllowances_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "Allowance Name"; // changing header text
            }
        }



        protected void grdDeductions_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;

        }

        protected void grdContribution_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[1].Text = "Contribution Number"; // changing header text
            }
        }
    }
}