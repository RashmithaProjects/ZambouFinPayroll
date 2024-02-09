using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Payroll_Project.DAL
{
    public class Dal
    {
        SqlConnection _Con, paycon;
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        DataSet ds = new DataSet();
       // public string dateFormat = "MM/dd/yyyy";
        public string dateFormat = "dd/MM/yyyy";

        public Dal()
        {
            //_Con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings.Get("connection"));
            _Con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
           
            //_Con = System.Configuration.ConfigurationSettings.AppSettings.Get(0);
            //
            // TODO: Add constructor logic here
            //
        }

      
        public DataTable Fun_Alert(string tran)
        {
            ClearDataTable();
            da = new SqlDataAdapter("Exec Alerts_P '" + tran + "'", _Con);
            da.SelectCommand.CommandTimeout = 300;
            ds.Clear();
            da.Fill(ds, "fat");
            dt = ds.Tables["fat"];
            return dt;
        }

        public DataTable Fun_Login(string UserCode, string Password)
        {
            ClearDataTable();
            da = new SqlDataAdapter("Exec Login_P '" + UserCode + "','" + Password + "'", _Con);
            da.SelectCommand.CommandTimeout = 300;
            ds.Clear();
            da.Fill(ds, "user_reg");
            dt = ds.Tables["user_reg"];
            return dt;
        }

        public DataTable Fun_UpdatePassword(string UserCode, string OlPassword,string NewPassword)
        {
            ClearDataTable();
            da = new SqlDataAdapter("Exec UpdatePassword_P '" + UserCode + "','" + OlPassword + "','" + NewPassword + "'", _Con);
            da.SelectCommand.CommandTimeout = 300;
            ds.Clear();
            da.Fill(ds, "user_reg");
            dt = ds.Tables["user_reg"];
            return dt;
        }

        public DataTable Fun_CompnayLocation(string Tran)
        {
            ClearDataTable();
            da = new SqlDataAdapter("Exec CompnayLocation_P '" + Tran + "'", _Con);
            da.SelectCommand.CommandTimeout = 300;
            ds.Clear();
            da.Fill(ds, "Locations");
            dt = ds.Tables["Locations"];
            return dt;
        }

        public DataTable Fun_WorkLocation(int WorkLocationId,string WorkingLocation, string CompanyLocation, string Tran)
        {
            ClearDataTable();
            da = new SqlDataAdapter("Exec WorkLocation_P '" + WorkLocationId + "','" + WorkingLocation + "','" + CompanyLocation + "','"+ Tran + "'", _Con);
            da.SelectCommand.CommandTimeout = 300;
            ds.Clear();
            da.Fill(ds, "employee_working_location");
            dt = ds.Tables["employee_working_location"];
            return dt;
        }

        public DataTable Fun_Department(int DeptId,string DeptCode, string DeptName,string Tran)
        {
            ClearDataTable();
            da = new SqlDataAdapter("Exec Department_P '" + DeptId + "','"+ DeptCode + "','" + DeptName + "','"+ Tran + "'", _Con);
            da.SelectCommand.CommandTimeout = 300;
            ds.Clear();
            da.Fill(ds, "emp_dept");
            dt = ds.Tables["emp_dept"];
            return dt;
        }

        public DataTable Fun_Positions(int PositionId, string PositionCode, string PositionName, string Tran)
        {
            ClearDataTable();
            da = new SqlDataAdapter("Exec Position_P '" + PositionId + "','" + PositionCode + "','" + PositionName + "','" + Tran + "'", _Con);
            da.SelectCommand.CommandTimeout = 300;
            ds.Clear();
            da.Fill(ds, "emp_Position");
            dt = ds.Tables["emp_Position"];
            return dt;
        }

        public DataTable Fun_ShiftDetails(int ShiftId,string ShiftType, string ShiftName,int Fromtime,int ToTime, string Tran)
        {
            ClearDataTable();
            da = new SqlDataAdapter("Exec Shift_P '" + ShiftId + "','"+ ShiftType + "','" + ShiftName + "','" + Fromtime + "','" + ToTime + "','" + Tran + "'", _Con);
            da.SelectCommand.CommandTimeout = 300;
            ds.Clear();
            da.Fill(ds, "emp_shift");
            dt = ds.Tables["emp_shift"];
            return dt;
        }

        public DataTable Fun_ContributionDetails(string Tran)
        {
            ClearDataTable();
            da = new SqlDataAdapter("Exec ContributionType_P '" + Tran + "'", _Con);
            da.SelectCommand.CommandTimeout = 300;
            ds.Clear();
            da.Fill(ds, "payroll_contribution_type");
            dt = ds.Tables["payroll_contribution_type"];
            return dt;
        }

        public DataTable Fun_EmpDetails(string FirstName, string MiddleName, string LastName, string Empno, string Gender, string MartialStatus, string Address,
            string Address1, string CompanyLocation, string WorkLocation, DateTime Dob, DateTime Empon, DateTime contstractStart, DateTime ContractExpired,
            DateTime ContractRenuval, string Position, string Department, string ShiftType, string ShiftId, string BankName, string BankBranch, string Accountno,
            string Passport, string children, string spouse, string imagepath, string signature, string Status, string EmployementType, double BasicPay,
            string EmailId, string MobileNo, string Title, int ReferenceId, string NRCNo, string TPin,string Socio_Security_No, string tran)
        {
            try
            {
                ClearDataTable();
                da = new SqlDataAdapter("Exec Emp_Details_InsUpd_P '" + FirstName + "','" + MiddleName + "','" + LastName + "','" + Empno + "','" + Gender + "','" + MartialStatus + "','" + Address + "','" + Address1 + "','" + CompanyLocation + "','" + WorkLocation + "','" + Dob + "','" + Empon + "','" + contstractStart + "','" + ContractExpired + "','" + ContractRenuval + "','" + Position + "','" + Department + "','" + ShiftType + "','" + ShiftId + "','" + BankName + "','" + BankBranch + "','" + Accountno + "','" + Passport + "','" + children + "','" + spouse + "','" + imagepath + "','" + signature + "','" + Status + "' ,'" + EmployementType + "','" + BasicPay + "','" + EmailId + "','" + MobileNo + "','" + Title + "', '" + ReferenceId + "','" + NRCNo + "','" + TPin +  "','" + Socio_Security_No + "','" + tran + "'", _Con);
                da.SelectCommand.CommandTimeout = 300;
                ds.Clear();
                da.Fill(ds, "Employee_details");
                dt = ds.Tables["Employee_details"];
                return dt;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        //public DataTable  Fun_EmpDetails(string FirstName,string MiddleName,string LastName,string Empno,string Gender,string MartialStatus,string Address, 
        //    string Address1, string CompanyLocation
        //    ,string WorkLocation,DateTime Dob ,DateTime Empon,DateTime contstractStart,string ContractExpired,string ContractRenuval,string Position 
        //    ,string Department,string ShiftType
        //    ,string BankName,string BankBranch,string Accountno,string Passport,double BasicPay,string tran)
        //{
        //    _Con.Open();
        //    SqlCommand cmd = new SqlCommand("Emp_Details_P", _Con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@FirstName", SqlDbType.NVarChar).Value = FirstName;
        //    cmd.Parameters.AddWithValue("@MiddleName", SqlDbType.NVarChar).Value = MiddleName;
        //    cmd.Parameters.AddWithValue("@LastName", SqlDbType.NVarChar).Value = LastName;
        //    cmd.Parameters.AddWithValue("@EmpNo", SqlDbType.NVarChar).Value = Empno;
        //    cmd.Parameters.AddWithValue("@Gender", SqlDbType.NVarChar).Value = Gender;
        //    cmd.Parameters.AddWithValue("@MartialStatus", SqlDbType.NVarChar).Value = MartialStatus;
        //    cmd.Parameters.AddWithValue("@Address", SqlDbType.NVarChar).Value = Address;
        //    cmd.Parameters.AddWithValue("@Address1", SqlDbType.NVarChar).Value = Address1;
        //    cmd.Parameters.AddWithValue("@CompanyLocation", SqlDbType.Date).Value = CompanyLocation;
        //    cmd.Parameters.AddWithValue("@WorkLocation", SqlDbType.Date).Value = WorkLocation;
        //    cmd.Parameters.AddWithValue("@Dob", SqlDbType.Date).Value = Dob;
        //    cmd.Parameters.AddWithValue("@EmpOn", SqlDbType.NVarChar).Value = Empon;
        //    cmd.Parameters.AddWithValue("@contractStart", SqlDbType.Date).Value = contstractStart;
        //    cmd.Parameters.AddWithValue("@ContractExpired", SqlDbType.Date).Value = ContractExpired;
        //    cmd.Parameters.AddWithValue("@ContractRenuval", SqlDbType.NVarChar).Value = ContractRenuval;
        //    cmd.Parameters.AddWithValue("@Position", SqlDbType.NVarChar).Value = Position;
        //    cmd.Parameters.AddWithValue("@Department", SqlDbType.NVarChar).Value = Department;
        //    cmd.Parameters.AddWithValue("@ShiftType", SqlDbType.NVarChar).Value = ShiftType;
        //    cmd.Parameters.AddWithValue("@BankName", SqlDbType.NVarChar).Value = BankName;
        //    cmd.Parameters.AddWithValue("@BankBranch", SqlDbType.NVarChar).Value = BankBranch;
        //    cmd.Parameters.AddWithValue("@AccountNo", SqlDbType.NVarChar).Value = Accountno;
        //    cmd.Parameters.AddWithValue("@Passport", SqlDbType.NVarChar).Value = FirstName;
        //    cmd.Parameters.AddWithValue("@BasicPay", SqlDbType.Float).Value = BasicPay;
        //    cmd.Parameters.AddWithValue("@tran", SqlDbType.NVarChar).Value = "Insert";
        //    //sql_cmnd.Parameters.AddWithValue("@AGE", SqlDbType.Int).Value = age;
        //    return cmd.ExecuteNonQuery();
        //}

        public DataTable Fun_Positions()
        {
            using (SqlCommand cmd = new SqlCommand("positions_P", _Con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }

        }

        public DataTable Fun_Emp_Details_UpdateBasicPay(string empNo, double BasicPay)
        {
            ClearDataTable();
            da = new SqlDataAdapter("Exec Emp_Details_UpdateBasicPay_P '" + empNo + "','" + BasicPay + "'", _Con);
            da.SelectCommand.CommandTimeout = 300;
            ds.Clear();
            da.Fill(ds, "Employee_details");
            dt = ds.Tables["Employee_details"];
            return dt;
        }
        public DataTable Fun_Emp_Details_Get(string SearchText)
        {
            SqlCommand cmd = new SqlCommand("Emp_search_P", _Con);
            cmd.Parameters.AddWithValue("@SearchText", SqlDbType.NVarChar).Value = SearchText;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public DataTable Fun_Emp_Details_GetbyReferenceId(int ReferenceId)
        {
            ClearDataTable();
            da = new SqlDataAdapter("Exec Emp_GetbyReferenceId_P '" + ReferenceId + "'", _Con);
            da.SelectCommand.CommandTimeout = 300;
            ds.Clear();
            da.Fill(ds, "Employee_details");
            dt = ds.Tables["Employee_details"];
            return dt;
        }

        public DataTable Fun_Emp_Details_GetbyEmpNo(string EmpNo)
        {
            ClearDataTable();
            da = new SqlDataAdapter("Exec Emp_GetbyEmpNo_P '" + EmpNo + "'", _Con);
            da.SelectCommand.CommandTimeout = 300;
            ds.Clear();
            da.Fill(ds, "Employee_details");
            dt = ds.Tables["Employee_details"];
            return dt;
        }

        //public DataTable Fun_Emp_Details_GetbyReferenceId(int ReferenceId)
        //{
        //    SqlCommand cmd = new SqlCommand("Emp_GetbyReferenceId_P", _Con);
        //    cmd.Parameters.AddWithValue("@ReferenceId", SqlDbType.Int).Value = ReferenceId;
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    sda.Fill(dt);
        //    return dt;
        //}

        public DataTable Fun_Emp_Details_Contribution(string employeeNo, string contributionType, string contributionNo, int ReferenceId, string Tran)
        {


            ClearDataTable();
            da = new SqlDataAdapter("Exec Emp_Details_Contribution_P '" + employeeNo + "','" + contributionType + "','" + contributionNo + "','" + ReferenceId + "','" + Tran + "'", _Con);
            da.SelectCommand.CommandTimeout = 300;
            ds.Clear();
            da.Fill(ds, "payroll_employee_contribution_details");
            dt = ds.Tables["payroll_employee_contribution_details"];
            return dt;

            //SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(_Con);
            //sqlBulkCopy.DestinationTableName = "dbo.payroll_employee_contribution_details";
            //sqlBulkCopy.ColumnMappings.Add("rowid", "sno1");
            //sqlBulkCopy.ColumnMappings.Add("type", "type");
            //sqlBulkCopy.ColumnMappings.Add("contribution_no", "contribution_no");
            //_Con.Open();
            //sqlBulkCopy.WriteToServer(dt);
            //_Con.Close();


        }

        public DataTable Fun_EmployeeContribution_Get(int ReferenceId, string Tran)
        {

            ClearDataTable();
            da = new SqlDataAdapter("Exec Emp_Details_Contribution_Search_P '" + ReferenceId + "','" + Tran + "'", _Con);
            da.SelectCommand.CommandTimeout = 300;
            ds.Clear();
            da.Fill(ds, "payroll_employee_contribution_details");
            dt = ds.Tables["payroll_employee_contribution_details"];
            return dt;
        }

        public DataTable Fun_AllowanceType_InsUpd(string Name, string Description, string Tran)
        {
            ClearDataTable();
            da = new SqlDataAdapter("Exec AllowanceType_InsUpd_P '" + Name + "','" + Description + "','" + Tran + "'", _Con);
            da.SelectCommand.CommandTimeout = 300;
            ds.Clear();
            da.Fill(ds, "AllowanceType_T");
            dt = ds.Tables["AllowanceType_T"];
            return dt;
        }

        public DataTable Fun_AllowanceType_Get()
        {
            ClearDataTable();
            da = new SqlDataAdapter("Exec AllowanceType_Get_P", _Con);
            da.SelectCommand.CommandTimeout = 300;
            ds.Clear();
            da.Fill(ds, "AllowanceType_T");
            dt = ds.Tables["AllowanceType_T"];
            return dt;
        }
        public DataTable Fun_EmployeeAllowance(int AllowanceId, string employeeNo, string allowance_name, decimal percentage, decimal amount, string type, string company_location, string working_location, int ReferenceId, string Tran)
        {

            ClearDataTable();
            da = new SqlDataAdapter("Exec Emp_Details_Allowances_P '" + AllowanceId + "','" + employeeNo + "','" + allowance_name + "','" + percentage + "','" + amount + "','" + type + "','" + company_location + "','" + working_location + "','" + ReferenceId + "','" + Tran + "'", _Con);
            da.SelectCommand.CommandTimeout = 300;
            ds.Clear();
            da.Fill(ds, "employee_details_allowances");
            dt = ds.Tables["employee_details_allowances"];
            return dt;
        }

        public DataTable Fun_EmployeeAllowanc_Get(int ReferenceId, string Tran)
        {

            ClearDataTable();
            da = new SqlDataAdapter("Exec Emp_Details_Allowances_Search_P '" + ReferenceId + "','" + Tran + "'", _Con);
            da.SelectCommand.CommandTimeout = 300;
            ds.Clear();
            da.Fill(ds, "employee_details_allowances");
            dt = ds.Tables["employee_details_allowances"];
            return dt;
        }

        public DataTable Fun_EmployeeDeductions_InsUpd(int ReferenceId, string EmployeeNo, string Description, decimal Amount, decimal DeductionRange, string Tran)
        {

            ClearDataTable();
            da = new SqlDataAdapter("Exec Emp_Details_Deductions_InsUpd_P '" + ReferenceId + "','" + EmployeeNo + "','" + Description + "','" + Amount + "','" + DeductionRange + "', '" + Tran + "'", _Con);
            da.SelectCommand.CommandTimeout = 300;
            ds.Clear();
            da.Fill(ds, "employee_details_allowances");
            dt = ds.Tables["employee_details_allowances"];
            return dt;
        }

        public DataTable Fun_EmployeeDeductions_Get(int ReferenceId, string Tran)
        {

            ClearDataTable();
            da = new SqlDataAdapter("Exec Emp_Details_Deductions_Search_P '" + ReferenceId + "','" + Tran + "'", _Con);
            da.SelectCommand.CommandTimeout = 300;
            ds.Clear();
            da.Fill(ds, "Employee_Deductions_Details");
            dt = ds.Tables["Employee_Deductions_Details"];
            return dt;
        }

        public DataTable Fun_CalculateDeductions_Get(decimal BasicPay, decimal GrossPay)
        {

            ClearDataTable();
            da = new SqlDataAdapter("Exec CalculateDeducations_P '" + BasicPay + "','" + GrossPay + "'", _Con);
            da.SelectCommand.CommandTimeout = 300;
            ds.Clear();
            da.Fill(ds, "Employee_Deductions_Details");
            dt = ds.Tables["Employee_Deductions_Details"];
            return dt;
        }

       

        public DataTable Fun_EmployeeMonthlyAttendence_InsUpd(int Year, string Month, string CompanyLocation, string WorkLocation, string WorkingDays, string Tran)
        {

            ClearDataTable();
            da = new SqlDataAdapter("Exec Employee_Monthly_Attendence_InsUpd_P '" + Year + "','" + Month + "','" + CompanyLocation + "','" + WorkLocation + "','" + WorkingDays + "','" + Tran + "'", _Con);
            da.SelectCommand.CommandTimeout = 300;
            ds.Clear();
            da.Fill(ds, "employee_monthly_attendance");
            dt = ds.Tables["employee_monthly_attendance"];
            return dt;
        }

        public DataTable Fun_Emp_Monhly_Attendence(int year, string Month, string Tran)
        {
            ClearDataTable();
            da = new SqlDataAdapter("Exec employee_monthly_attendance_P '" + year + "','" + Month + "','" + Tran + "'", _Con);
            da.SelectCommand.CommandTimeout = 300;
            ds.Clear();
            da.Fill(ds, "employee_monthly_attendance");
            dt = ds.Tables["employee_monthly_attendance"];
            return dt;
        }
        public DataTable Fun_EmployeeMonthlyAttendence_Details_InsUpd(int Sno, string EmployeeNo, string EmployeeName, string EmployeePosition, int PresentDays, int AbsentDays, string Comments, int ReferenceId, string Tran)
        {

            ClearDataTable();
            da = new SqlDataAdapter("Exec Employee_Monthly_Attendence_Details_InsUpd_P '" + Sno + "','" + EmployeeNo + "','" + EmployeeName + "','" + EmployeePosition + "','" + PresentDays + "','" + AbsentDays + "','" + Comments + "','" + ReferenceId + "', '" + Tran + "'", _Con);
            da.SelectCommand.CommandTimeout = 300;
            ds.Clear();
            da.Fill(ds, "employee_monthly_attendancedetails");
            dt = ds.Tables["employee_monthly_attendancedetails"];
            return dt;
        }


        public DataTable Fun_Emp_Monhly_Attendence_Details(int ReferenceId, int Year, string Month)
        {
            ClearDataTable();
            da = new SqlDataAdapter("Exec Employee_Monthly_Attendence_Details_P '" + ReferenceId + "','" + Year + "','" + Month + "'", _Con);
            da.SelectCommand.CommandTimeout = 300;
            ds.Clear();
            da.Fill(ds, "employee_monthly_attendancedetails");
            dt = ds.Tables["employee_monthly_attendancedetails"];
            return dt;
        }


        public DataTable Fun_PayrollGeneration(int Year, string Month)
        {
            ClearDataTable();
            da = new SqlDataAdapter("Exec Payroll_Generation_Details_InsUpd_P '" + Year + "','" + Month + "'", _Con);
            da.SelectCommand.CommandTimeout = 300;
            ds.Clear();
            da.Fill(ds, "Payroll_Generation_T");
            dt = ds.Tables["Payroll_Generation_T"];
            return dt;
        }

        public DataTable Fun_PayrollGeneration_SalesAndMarketing(int Year, string Month, int ReferenceId, decimal SalesAndMarketingCommission)
        {
            ClearDataTable();
            da = new SqlDataAdapter("Exec Payroll_Generation_Details_SalesAndMarketing_P '" + Year + "','" + Month + "','"  + ReferenceId + "', '" + SalesAndMarketingCommission + "'", _Con);
            da.SelectCommand.CommandTimeout = 300;
            ds.Clear();
            da.Fill(ds, "Payroll_Generation_T");
            dt = ds.Tables["Payroll_Generation_T"];
            return dt;
        }

        public DataTable Fun_PayrollGeneration_Deductions(int Year, string Month, int ReferenceId, decimal SalaryAdvancedRepayment, decimal ZoanLoanRepayment, string Tran)
        {
            ClearDataTable();
            da = new SqlDataAdapter("Exec Payroll_Generation_Details_Deductions_P '" + Year + "','" + Month + "','" + ReferenceId + "', '" + SalaryAdvancedRepayment + "', '" + ZoanLoanRepayment + "','" + Tran + "'", _Con);
            da.SelectCommand.CommandTimeout = 300;
            ds.Clear();
            da.Fill(ds, "Payroll_Generation_T");
            dt = ds.Tables["Payroll_Generation_T"];
            return dt;
        }

        public DataTable Fun_PayrollGeneration_InsUpd(int Year, string Month, string Remarks, string Status, string Tran)
        {
            ClearDataTable();
            da = new SqlDataAdapter("Exec Payroll_Generation_InsUpd_P '" + Year + "','" + Month + "','" + Remarks + "','" + Status + "','" + Tran + "'", _Con);
            da.SelectCommand.CommandTimeout = 300;
            ds.Clear();
            da.Fill(ds, "Payroll_Generation_T");
            dt = ds.Tables["Payroll_Generation_T"];
            return dt;
        }

        public DataTable Fun_PayrollGeneration_Get(string Tran)
        {
            ClearDataTable();
            da = new SqlDataAdapter("Exec Payroll_Generation_Get_P'" + Tran + "'", _Con);
            da.SelectCommand.CommandTimeout = 300;
            ds.Clear();
            da.Fill(ds, "Payroll_Generation_T");
            dt = ds.Tables["Payroll_Generation_T"];
            return dt;
        }

        public DataTable Fun_PayrollGeneration_Details_Get(int Year, string Month)
        {
            ClearDataTable();
            da = new SqlDataAdapter("Exec Payroll_Generation_Details_Get_P '" + Year + "','" + Month + "'", _Con);
            da.SelectCommand.CommandTimeout = 300;
            ds.Clear();
            da.Fill(ds, "Payroll_Generation_T");
            dt = ds.Tables["Payroll_Generation_T"];
            return dt;
        }

        public DataTable Fun_PayrollTotalSummary(int Year, string Month)
        {
            ClearDataTable();
            da = new SqlDataAdapter("Exec Payroll_Total_Summary_P '" + Year + "','" + Month + "'", _Con);
            da.SelectCommand.CommandTimeout = 300;
            ds.Clear();
            da.Fill(ds, "Payroll_Generation_T");
            dt = ds.Tables["Payroll_Generation_T"];
            return dt;
        }

        public DataTable Fun_PayrollGeneration_Details_InsUpd(int Sno, int ReferenceId, int Year, string Month, string Employee_no, string EmployeeName, decimal BasicPay, decimal HouseAllowance, decimal LunchAllowance, decimal TransportAllowance, decimal ResponsibilityAllowance, decimal TotalAllowance, decimal SalaesAndCommission, decimal GrossPay, decimal GrossPayRate, decimal ActualGrossPay, decimal Napsa, decimal Nhima, decimal Paye, decimal SalaryAndAdvancedRepayment, decimal ZamboLoanRepayment, decimal NetPay, string AccountNo, decimal Gratuity, decimal NapsaCom, decimal CTC)
        {
            ClearDataTable();
            da = new SqlDataAdapter("Exec Payroll_Generation_Details_InsUpd_P '" + Sno + "','" + ReferenceId + "','" + Year + "','" + Month + "', '" + Employee_no + "','" + EmployeeName + "', '" + BasicPay + "','" + HouseAllowance + "', '" + LunchAllowance + "','" + TransportAllowance + "', '" + ResponsibilityAllowance + "','" + TotalAllowance + "', '" + SalaesAndCommission + "','" + GrossPay + "', '" + GrossPayRate + "','" + ActualGrossPay + "', '" + Napsa + "','" + Nhima + "', '" + Paye + "','" + SalaryAndAdvancedRepayment + "', '" + ZamboLoanRepayment + "','" + NetPay + "', '" + AccountNo + "','" + Gratuity + "', '" + Napsa + "','" + CTC + "'", _Con);
            da.SelectCommand.CommandTimeout = 300;
            ds.Clear();
            da.Fill(ds, "Payroll_Generation_Details_T");
            dt = ds.Tables["Payroll_Generation_Details_T"];
            return dt;
        }

        public DataTable Fun_Payroll_Generation_Details_Active(int ReferenceId, int Year, string Month)
        {
            ClearDataTable();
            da = new SqlDataAdapter("Exec Payroll_Generation_Details_Active_P '" + ReferenceId + "','" + Year + "','" + Month + "'", _Con);
            da.SelectCommand.CommandTimeout = 300;
            ds.Clear();
            da.Fill(ds, "Payroll_Generation_Details_T");
            dt = ds.Tables["Payroll_Generation_Details_T"];
            return dt;
        }


        public DataTable Fun_ContributionType(int ContributionId, string Name, string Description, string Tran)
        {
            ClearDataTable();
            da = new SqlDataAdapter("Exec ContributionType_P '" +ContributionId + "','" + Name + "','" + Description + "','" + Tran + "'", _Con);
            da.SelectCommand.CommandTimeout = 300;
            ds.Clear();
            da.Fill(ds, "ContributionType_T");
            dt = ds.Tables["ContributionType_T"];
            return dt;
        }

        //public DataTable Fun_ContributionType_Get()
        //{
        //    ClearDataTable();
        //    da = new SqlDataAdapter("Exec ContributionType_Get_P", _Con);
        //    da.SelectCommand.CommandTimeout = 300;
        //    ds.Clear();
        //    da.Fill(ds, "ContributionType_T");
        //    dt = ds.Tables["ContributionType_T"];
        //    return dt;
        //}

     
        public DataTable Fun_Contribution_Details_InsUpd(DateTime Date, int ContributionId, string ContributionType, string Description, decimal Employee_Percentage, decimal Employer_Percentage, decimal Ceiling_Amount, string ApplicableOn, string Tran)
        {
            ClearDataTable();
            da = new SqlDataAdapter("Exec ContributionDetails_InsUpd_P '" + Date + "','" + ContributionId + "','" + ContributionType + "','" + Description + "','" + Employee_Percentage + "','" + Employer_Percentage + "','" + Ceiling_Amount + "','" + ApplicableOn + "','" + Tran + "'", _Con);
            da.SelectCommand.CommandTimeout = 300;
            ds.Clear();
            da.Fill(ds, "ContributionDetails_T");
            dt = ds.Tables["ContributionDetails_T"];
            return dt;
        }


        public DataTable FunContribution_Details_Get_P()
        {
            ClearDataTable();
            da = new SqlDataAdapter("Exec Contribution_Details_Get_P", _Con);
            da.SelectCommand.CommandTimeout = 300;
            ds.Clear();
            da.Fill(ds, "ContributionDetails_T");
            dt = ds.Tables["ContributionDetails_T"];
            return dt;
        }

        public DataTable Fun_Tax(int TaxId, string taxcode, decimal lowerrange, decimal upperrange, decimal FixedAmount, decimal PercentageAmount, decimal TaxCredit, string Tran)
        {

            ClearDataTable();
            da = new SqlDataAdapter("Exec Tax_P '" + TaxId + "','"+ taxcode + "','" + lowerrange + "','" + upperrange + "','" + FixedAmount + "','" + PercentageAmount + "','" + TaxCredit + "','" + Tran + "'", _Con);
            da.SelectCommand.CommandTimeout = 300;
            ds.Clear();
            da.Fill(ds, "payroll_tax");
            dt = ds.Tables["payroll_tax"];
            return dt;
        }
        public DataTable Fun_Leaves(int LeaveId, string  LeaveName, int NoofDays, string Tran)
        {
            ClearDataTable();
            da = new SqlDataAdapter("Exec Leaves_P '" + LeaveId + "','" + LeaveName + "','" + NoofDays + "','" +Tran+ "'", _Con);
            da.SelectCommand.CommandTimeout = 300;
            ds.Clear();
            da.Fill(ds, "leaves");
            dt = ds.Tables["leaves"];
            return dt;
        }

        public DataTable Fun_Employee_Leave_InsUpd(int ReferenceId ,string EmpNo, string EmpName, int LeaveId,string LeaveName,DateTime EmployeeeOn ,int NoofDays,int BalDays,int TotalDays,string CompanyLocation,int WorkLocation, string Tran)
        {
            ClearDataTable();
            da = new SqlDataAdapter("Exec Employee_Leaves_InsUpd_P '" + ReferenceId + "','" + EmpNo + "','" + EmpName + "','" + LeaveId + "','" + LeaveName + "','"+ EmployeeeOn + "','" + NoofDays + "','" + BalDays + "','" + TotalDays + "','" + CompanyLocation + "','" + WorkLocation + "','" + Tran + "'", _Con);
            da.SelectCommand.CommandTimeout = 300;
            ds.Clear();
            da.Fill(ds, "employee_leave_days");
            dt = ds.Tables["employee_leave_days"];
            return dt;
        }

        public DataTable Fun_Employee_Leave_Get(string Tran)
        {
            ClearDataTable();
            da = new SqlDataAdapter("Exec Employee_Leaves_Get_P '"  + Tran + "'", _Con);
            da.SelectCommand.CommandTimeout = 300;
            ds.Clear();
            da.Fill(ds, "employee_leave_days");
            dt = ds.Tables["employee_leave_days"];
            return dt;
        }

        public DataTable Fun_Roles(int RoleId, string RoleName, string Description, string Tran)
        {
            ClearDataTable();
            da = new SqlDataAdapter("Exec Roles_P '" + RoleId + "','" + RoleName + "','" + Description + "','" + Tran + "'", _Con);
            da.SelectCommand.CommandTimeout = 300;
            ds.Clear();
            da.Fill(ds, "Roles");
            dt = ds.Tables["Roles"];
            return dt;
        }

        public DataTable Fun_Users(int UserId, string UserCode, string UserName,  string Password, int RoleId, string Tran)
        {
            ClearDataTable();
            da = new SqlDataAdapter("Exec User_P '" + UserId + "','" + UserCode +  "','" + UserName + "','" + Password +"','" + RoleId + "','" + Tran + "'", _Con);
            da.SelectCommand.CommandTimeout = 300;
            ds.Clear();
            da.Fill(ds, "user_reg");
            dt = ds.Tables["user_reg"];
            return dt;
        }

        public DataTable Fun_PaySlip(int Year, string Month,  int ReferenceId)
        {
            ClearDataTable();
            da = new SqlDataAdapter("Exec Report_Payslip '" + Year + "','" + Month +  "','" + ReferenceId + "'", _Con);
            da.SelectCommand.CommandTimeout = 300;
            ds.Clear();
            da.Fill(ds, "user_reg");
            dt = ds.Tables["user_reg"];
            return dt;
        }

        public DataTable Fun_NetSalaryAndWage()
        {
            ClearDataTable();
            da = new SqlDataAdapter("Exec Report_Net_SalaryAndWage", _Con);
            da.SelectCommand.CommandTimeout = 300;
            ds.Clear();
            da.Fill(ds, "user_reg");
            dt = ds.Tables["user_reg"];
            return dt;
        }

        public DataTable Fun_GrossSalaryAndWage()
        {
            ClearDataTable();
            da = new SqlDataAdapter("Exec Report_GrossSalaryAndWage", _Con);
            da.SelectCommand.CommandTimeout = 300;
            ds.Clear();
            da.Fill(ds, "user_reg");
            dt = ds.Tables["user_reg"];
            return dt;
        }

        public DataTable Fun_NapsaExpenses()
        {
            ClearDataTable();
            da = new SqlDataAdapter("Exec Report_NapsaExpenses", _Con);
            da.SelectCommand.CommandTimeout = 300;
            ds.Clear();
            da.Fill(ds, "user_reg");
            dt = ds.Tables["user_reg"];
            return dt;
        }

        public DataTable Fun_NhimaShedule()
        {
            ClearDataTable();
            da = new SqlDataAdapter("Exec Report_NhimaShedule", _Con);
            da.SelectCommand.CommandTimeout = 300;
            ds.Clear();
            da.Fill(ds, "user_reg");
            dt = ds.Tables["user_reg"];
            return dt;
        }

        public DataTable Skill_Development_Schedule()
        {
            ClearDataTable();
            da = new SqlDataAdapter("Exec Report_Skill_Development_Schedule", _Con);
            da.SelectCommand.CommandTimeout = 300;
            ds.Clear();
            da.Fill(ds, "user_reg");
            dt = ds.Tables["user_reg"];
            return dt;
        }

        public DataTable Provision_For_Gratuity_Expense()
        {
            ClearDataTable();
            da = new SqlDataAdapter("Exec Report_Provision_For_Gratuity_Expense", _Con);
            da.SelectCommand.CommandTimeout = 300;
            ds.Clear();
            da.Fill(ds, "user_reg");
            dt = ds.Tables["user_reg"];
            return dt;
        }

        public DataTable Provision_For_Gratuity()
        {
            ClearDataTable();
            da = new SqlDataAdapter("Exec Report_Provision_For_Gratuity", _Con);
            da.SelectCommand.CommandTimeout = 300;
            ds.Clear();
            da.Fill(ds, "user_reg");
            dt = ds.Tables["user_reg"];
            return dt;
        }

        public DataTable Provision_For_LeaveDays()
        {
            ClearDataTable();
            da = new SqlDataAdapter("Exec Report_Provision_For_LeaveDays", _Con);
            da.SelectCommand.CommandTimeout = 300;
            ds.Clear();
            da.Fill(ds, "user_reg");
            dt = ds.Tables["user_reg"];
            return dt;
        }

        public DataTable PayeeReport()
        {
            ClearDataTable();
            da = new SqlDataAdapter("Exec [Report_Payee]", _Con);
            da.SelectCommand.CommandTimeout = 300;
            ds.Clear();
            da.Fill(ds, "user_reg");
            dt = ds.Tables["user_reg"];
            return dt;
        }

        public DataTable Fun_MenuItems1(int ParentMenuId, string UserName,int MenuId, string Tran)
        {
            ClearDataTable();
            da = new SqlDataAdapter("Exec MenuItems_P'" + ParentMenuId + "','" + UserName + "','" + MenuId + "','" + Tran + "'", _Con);
            da.SelectCommand.CommandTimeout = 300;
            ds.Clear();
            da.Fill(ds, "Menus");
            dt = ds.Tables["Menus"];
            return dt;
        }

      

        public DataTable Fun_MenuItems(string UserName,string RoleName)
        {
            //string query = "SELECT [MenuId], [Title], [Description], [Url] FROM [Menus] WHERE ParentMenuId = @ParentMenuId";

            string constr = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                DataTable dt = new DataTable();
                using (SqlCommand cmd = new SqlCommand("MenuItems_P"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                       // cmd.Parameters.AddWithValue("@ParentMenuId", parentMenuId);
                        cmd.Parameters.AddWithValue("@UserName", UserName);
                        cmd.Parameters.AddWithValue("@RoleName", RoleName);
                        //cmd.Parameters.AddWithValue("@Tran", Session["RoleName"].ToString());
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        sda.Fill(dt);
                    }
                }
                return dt;
            }
        }
        public DataTable Fun_AccessRights(int UserId, int MenuId, string Tran)
        {

            ClearDataTable();
            da = new SqlDataAdapter("Exec AccesRights_P '" + UserId + "','" + MenuId + "','" + Tran + "'", _Con);
            da.SelectCommand.CommandTimeout = 300;
            ds.Clear();
            da.Fill(ds, "Menus_Users");
            dt = ds.Tables["Menus_Users"];
            return dt;
        }
        public void ClearDataTable()
        {
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    dt.Rows.Clear();
                    dt.Columns.Clear();
                    dt.Clear();
                }
            }
        }


    }
}