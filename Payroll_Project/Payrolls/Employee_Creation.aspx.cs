using Payroll_Project.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Payroll_Project.Payrolls
{
    public partial class Employee_Creation : System.Web.UI.Page
    {
        Dal dal = new Dal();
        static string fs = "", fs1 = "", path = "";
        DataTable dt = new DataTable();
        public bool InsertLastRec = false;
        int now; int count = 0;
        string Msg = null;
        int ReferenceId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.GetCurrent(Page).RegisterPostBackControl(btnSave);
            ScriptManager.GetCurrent(Page).RegisterPostBackControl(btnUpdate);

            caldob.Format = dal.dateFormat;
            calempon.Format = dal.dateFormat;
            calContractStart.Format = dal.dateFormat;
            calcontractexpired.Format = dal.dateFormat;
            calcontractrenuval.Format = dal.dateFormat;

            //if (Request.QueryString["ReferenceId"] != null) {
            //    int ReferenceId = Convert.ToInt32(Request.QueryString["ReferenceId"]);
            //}

            int ReferenceId = Convert.ToInt32(Request.QueryString["ReferenceId"]);
            if (ReferenceId != 0)
            {
                btnUpdate.Visible = true;
                btnSave.Visible = false;
                btnPrint.Visible = true;
            }
            else
            {
                btnSave.Visible = true;
                btnUpdate.Visible = false;
                btnPrint.Visible = false;
            }


            if (!IsPostBack)
            {
                txtAllowanceBasicPay.Visible = false;
                BindWorkLocation();
                BindDepartment();
                BindPositions();
                BindShiftDetails();

                //BindContributionGridview("");
                BindAllowances();
                BindContribution();
               


                if (ReferenceId != 0)
                {
                    BindDetails(ReferenceId);
                }
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

        protected void btnpersonaldetails_click(object sender, EventArgs e)
        {
            if (divPersonalDetails.Visible)
            {
                divPersonalDetails.Visible = false;
                divAllowances.Visible = false;
                divDeductions.Visible = false;
                divContribution.Visible = false;
                divDocuments.Visible = false;
            }
            else
            {
                divPersonalDetails.Visible = true;
                divAllowances.Visible = false;
                divDeductions.Visible = false;
                divContribution.Visible = false;
                divDocuments.Visible = false;
            }
        }

        protected void btncontribution_click(object sender, EventArgs e)
        {
            if (divContribution.Visible)
            {

                divPersonalDetails.Visible = false;
                divAllowances.Visible = false;
                divContribution.Visible = false;
                divDeductions.Visible = false;
                divDocuments.Visible = false;
            }
            else
            {

                divPersonalDetails.Visible = false;
                divAllowances.Visible = false;
                divContribution.Visible = true;
                divDeductions.Visible = false;
                divDocuments.Visible = false;
            }
        }

        protected void btnallowances_click(object sender, EventArgs e)
        {
            if (divAllowances.Visible)
            {
                divPersonalDetails.Visible = false;
                divAllowances.Visible = false;
                divContribution.Visible = false;
                divDeductions.Visible = false;
                divDocuments.Visible = false;
            }
            else
            {
                divPersonalDetails.Visible = false;
                divAllowances.Visible = true;
                divContribution.Visible = false;
                divDeductions.Visible = false;
                divDocuments.Visible = false;
            }
            int ReferenceId = Convert.ToInt32(Request.QueryString["ReferenceId"]);
            if (ReferenceId != 0)
            {
                double AllowanceTotalAmount = CalculateTotalAllowances();
                double basicpay = Convert.ToDouble(txtBasicPay.Text);
                double GrossAmount = basicpay + AllowanceTotalAmount;
                lblAllowancesTotalAmount.Text = AllowanceTotalAmount.ToString();
                lblAllowanceGrossAmount.Text = GrossAmount.ToString();
            }

        }
        protected void btnDeductions_Click(object sender, EventArgs e)
        {
            int ReferenceId = Convert.ToInt32(Request.QueryString["ReferenceId"]);
            if (ReferenceId != 0)
            {
                double AllowanceTotalAmount = CalculateTotalAllowances();
                double GrossAmount = Convert.ToDouble(txtBasicPay.Text) + AllowanceTotalAmount;
                lblAllowancesTotalAmount.Text = AllowanceTotalAmount.ToString();
                lblAllowanceGrossAmount.Text = GrossAmount.ToString();
            }


            if (txtBasicPay.Text == "")
            {
                ShowPopUpMsg("Please enter Basic Pay");
            }

            else if (lblAllowanceGrossAmount.Text == "")
            {
                ShowPopUpMsg("Pleae enter Allowances");
            }
            else
            {
                if (divDeductions.Visible)
                {

                    divPersonalDetails.Visible = false;
                    divAllowances.Visible = false;
                    divContribution.Visible = false;
                    divDeductions.Visible = false;
                    divDocuments.Visible = false;
                }
                else
                {
                    divPersonalDetails.Visible = false;
                    divAllowances.Visible = false;
                    divContribution.Visible = false;
                    divDeductions.Visible = true;
                    divDocuments.Visible = false;
                }
                BindDeductionsGridview(Convert.ToDecimal(txtBasicPay.Text), Convert.ToDecimal(lblAllowanceGrossAmount.Text));
                lblTotalDeductions.Text = CalculateTotalDeductions().ToString();
                lblDeductionGrossSalary.Text = lblAllowanceGrossAmount.Text;
                lblDeductionsCTC.Text = CalculateDeductionCTC().ToString();


            }
        }

        protected void btnDocumentsUpload_Click(object sender, EventArgs e)
        {
        
            if (divDocuments.Visible)
            {

                divPersonalDetails.Visible = false;
                divAllowances.Visible = false;
                divContribution.Visible = false;
                divDeductions.Visible = false;
                divDocuments.Visible = false;
            }
            else
            {

                divPersonalDetails.Visible = false;
                divAllowances.Visible = false;
                divContribution.Visible = false;
                divDeductions.Visible = false;
                divDocuments.Visible = true;
            }

        }

        protected void ddlcompanylocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindWorkLocation();
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            clear();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtEmpNo.Text == "")
            {
                ShowPopUpMsg("Please enter Employeee Number");
            }
            else if (txtDob.Text == "")
            {
                ShowPopUpMsg("Please enter Date of Birth");
            }
            else if (txtEmpon.Text == "")
            {
                ShowPopUpMsg("Please enter Employee On");
            }
            else if (txtContractStart.Text == "")
            {
                ShowPopUpMsg("Please enter Contract Start");
            }

            else if (txtContractExpired.Text == "")
            {
                ShowPopUpMsg("Please enter Contract Expired");
            }
            else if (txtContractRenuval.Text == "")
            {
                ShowPopUpMsg("Please enter Contract Renuval");
            }
            else if (txtBasicPay.Text == "")
            {
                ShowPopUpMsg("Please enter Basic Pay");
            }
            else if (txtEmailId.Text == "")
            {
                ShowPopUpMsg("Please enter email Id");
            }
            else if (txtMobileNo.Text == "")
            {
                ShowPopUpMsg("Please enter Mobile Number");
            }
            else if (ddlcompanylocation.SelectedIndex == 0)
            {
                ShowPopUpMsg("Please select Comapany location");
            }
            else if (ddlworklocation.SelectedIndex == 0)
            {
                ShowPopUpMsg("Please select Work location");
            }
            else if (ddlPosition.SelectedIndex == 0)
            {
                ShowPopUpMsg("Please select Positions");
            }
            else if (ddlDepartment.SelectedIndex == 0)
            {
                ShowPopUpMsg("Please Select Department");
            }

            else if (ddlShiftType.SelectedIndex == 0)
            {
                ShowPopUpMsg("Please Select Shift Type");
            }
            //else if (ddlStatus.SelectedIndex == 0)
            //{
            //    ShowPopUpMsg("Please Select Status");
            //}

            //else if (ddlEmploymentType.SelectedIndex == 0)
            //{
            //    ShowPopUpMsg("Please Select Employment Type");
            //}

            else if (TxtNRCNo.Text == "")
            {
                ShowPopUpMsg("Please enter NRCNo");
            }
            else if (txtTPin.Text == "")
            {
                ShowPopUpMsg("Please enter TPinNo");
            }
            else if (txtSocio_Security_No.Text == "")
            {
                ShowPopUpMsg("Please enter Socio Security No");
            }

            
            else if (grdContribution.Rows.Count == 1)
            {
                ShowPopUpMsg("Please enter Contribution");
            }

            else     //for update
            {
                DateTime dob = DateTime.ParseExact(txtDob.Text, dal.dateFormat, null);
                DateTime empon = DateTime.ParseExact(txtEmpon.Text, dal.dateFormat, null);
                DateTime contractstart = DateTime.ParseExact(txtContractStart.Text, dal.dateFormat, null);
                DateTime contractExpired = DateTime.ParseExact(txtContractExpired.Text, dal.dateFormat, null);
                DateTime contractRenuval = DateTime.ParseExact(txtContractRenuval.Text, dal.dateFormat, null);
                ReferenceId = Convert.ToInt32(Request.QueryString["ReferenceId"]);


               // string folderPath = Server.MapPath("UploadedImages//");
               // if (!Directory.Exists(folderPath))
               // {
               //     Directory.CreateDirectory(folderPath);
               // }
               //// fuImage.SaveAs(folderPath + Path.GetFileName(txtEmpNo.Text + "_Photo.jpeg"));
               // string imagepath = "~/UploadedImages/" + txtEmpNo.Text + "_Photo.jpeg";

               // //fuSignature.SaveAs(folderPath + Path.GetFileName(txtEmpNo.Text + "_Signature.jpeg"));
               // string signaturepath = "~/UploadedImages/" + txtEmpNo.Text + "_Signature.jpeg";

                string imagepath = "~/UploadedImages/" + Path.GetFileName(ReferenceId + "_Image.png");
                string signaturepath = "~/UploadedImages/" + ReferenceId + "_Signature.png";


                string folderPath = Server.MapPath("~/UploadedImages/");
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                fuImage.SaveAs(folderPath + Path.GetFileName(ReferenceId + "_Image.png"));
                image.ImageUrl = "~/UploadedImages/" + Path.GetFileName(ReferenceId + "_Image.png");

                fuSignature.SaveAs(folderPath + Path.GetFileName(ReferenceId + "_Signature.png"));
                imgSignature.ImageUrl = "~/UploadedImages/" + Path.GetFileName(ReferenceId + "_Signature.png");

         

                foreach (GridViewRow row in grdContribution.Rows)
                {

                    Label lblContributionType = (Label)row.FindControl("lblContributionType");
                    TextBox txtContributionNo = (TextBox)row.FindControl("txtContributionNo");
                    dal.Fun_Emp_Details_Contribution(txtEmpNo.Text, lblContributionType.Text, txtContributionNo.Text, ReferenceId, "Update");
                }

                foreach (GridViewRow row in grdAllowances.Rows)
                {

                    Label lblAllowanceId = (Label)row.FindControl("lblAllowanceId");
                    Label lblAllowanceName = (Label)row.FindControl("lblAllowanceName");
                    Label lblAllowanceType = (Label)row.FindControl("lblType");
                    TextBox txtAllowancePercentage = (TextBox)row.FindControl("txtAllowancePercentage");
                    TextBox txtAllowanceAmount = (TextBox)row.FindControl("txtAllowanceAmount");
                    if (txtAllowancePercentage.Text == "")
                    {
                        txtAllowancePercentage.Text = "0";
                    }
                    if (txtAllowanceAmount.Text == "")
                    {
                        txtAllowanceAmount.Text = "0";
                    }
                    dal.Fun_EmployeeAllowance(Convert.ToInt32(lblAllowanceId.Text), txtEmpNo.Text, lblAllowanceName.Text, Convert.ToDecimal(txtAllowancePercentage.Text), Convert.ToDecimal(txtAllowanceAmount.Text), lblAllowanceType.Text, ddlcompanylocation.SelectedItem.ToString(), ddlworklocation.SelectedItem.ToString(), ReferenceId, "Update");
                }

                foreach (GridViewRow row in grdDeductions.Rows)
                {

                    Label lblDeductionDescription = (Label)row.FindControl("lblDeductionDescription");
                    TextBox txtDeductionAmount = (TextBox)row.FindControl("txtDeductionAmount");
                    TextBox txtDeductionRange = (TextBox)row.FindControl("txtDeductionRange");
                    if (lblDeductionDescription.Text == "Pay e")
                    {
                        txtDeductionAmount.Text = "0";
                    }
                    if (txtDeductionAmount.Text == "")
                    {
                        txtDeductionAmount.Text = "0";
                    }
                    if (txtDeductionRange.Text == "")
                    {
                        txtDeductionRange.Text = "0";
                    }


                    dal.Fun_EmployeeDeductions_InsUpd(ReferenceId, txtEmpNo.Text, lblDeductionDescription.Text, Convert.ToDecimal(txtDeductionAmount.Text), Convert.ToDecimal(txtDeductionRange.Text), "Update");
                }


                dt = dal.Fun_EmpDetails(txtFirstName.Text, txtMiddleName.Text, txtLastName.Text, txtEmpNo.Text, ddl_gender.SelectedItem.Text, ddlMaratialStatus.SelectedItem.Text,
                         txtAddress.Text, txtAddress1.Text, ddlcompanylocation.SelectedValue, ddlworklocation.SelectedValue, dob,
                         empon, contractstart, contractExpired, contractRenuval,
                         ddlPosition.SelectedValue, ddlDepartment.SelectedValue, ddlShiftType.SelectedItem.ToString(), ddlShiftType.SelectedValue, txtBankName.Text, txtBankBranch.Text,
                         txtAccountno.Text, txtPassport.Text, txtChildren.Text, txtSpouse.Text, imagepath, signaturepath, ddlStatus.SelectedItem.ToString(),
                         ddlEmploymentType.SelectedItem.ToString(), Convert.ToDouble(txtBasicPay.Text),
                         txtEmailId.Text, txtMobileNo.Text, txtTitle.Text, ReferenceId, TxtNRCNo.Text, txtTPin.Text,txtSocio_Security_No.Text ,"Update");
                // Session["ReferenceId"] = ReferenceId;
                if (dt.Rows.Count > 0)
                {

                    //  Response.Redirect(string.Format("~/Payrolls/Employee_Creation_Preview.aspx?ReferenceId={0}", Convert.ToInt32(Request.QueryString["ReferenceId"])));

                    //clear();
                    //ShowPopUpMsg("Employee Updated Successfully");

                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Employee Updated Successfully');window.location ='Employee_Creation_Preview.aspx?ReferenceId={0}"+Convert.ToInt32(Request.QueryString["ReferenceId"]), true);

                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('User details saved sucessfully');window.location ='~/Payrolls/Employee_Creation_Preview.aspx?ReferenceId={0}" +Convert.ToInt32(Request.QueryString["ReferenceId"]),true);
                    panelmsg.Visible = true;
                    lblsuccmsg.Text = "Employee Details Updated succesfully";

                }

            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            //string totalnum = txtFirstName.Text.Trim() + ' ' + txtMiddleName.Text.Trim() + ' ' + txtLastName.Text.Trim() + '-' + txtEmpNo.Text.Trim();
            dt = dal.Fun_Emp_Details_GetbyEmpNo(txtEmpNo.Text);

            if (txtEmpNo.Text == "")
            {
                ShowPopUpMsg("Please enter Employeee Number");
            }
            else if (txtDob.Text == "")
            {
                ShowPopUpMsg("Please enter Date of Birth");
            }
            else if (txtEmpon.Text == "")
            {
                ShowPopUpMsg("Please enter Employee On");
            }
            else if (txtContractStart.Text == "")
            {
                ShowPopUpMsg("Please enter Contract Start");
            }

            else if (txtContractExpired.Text == "")
            {
                ShowPopUpMsg("Please enter Contract Expired");
            }
            else if (txtContractRenuval.Text == "")
            {
                ShowPopUpMsg("Please enter Contract Renuval");
            }
            else if (txtBasicPay.Text == "")
            {
                ShowPopUpMsg("Please enter Basic Pay");
            }
            else if (txtEmailId.Text == "")
            {
                ShowPopUpMsg("Please enter email Id");
            }
            else if (txtMobileNo.Text == "")
            {
                ShowPopUpMsg("Please enter Mobile Number");
            }
            else if (ddlcompanylocation.SelectedIndex == 0)
            {
                ShowPopUpMsg("Please select Comapany location");
            }
            else if (ddlworklocation.SelectedIndex == 0)
            {
                ShowPopUpMsg("Please select Work location");
            }
            else if (ddlPosition.SelectedIndex == 0)
            {
                ShowPopUpMsg("Please select Positions");
            }

            else if (ddlDepartment.SelectedIndex == 0)
            {
                ShowPopUpMsg("Please select Department");
            }

            else if (ddlShiftType.SelectedIndex == 0)
            {
                ShowPopUpMsg("Please Select Shift Type");
            }
            else if (ddlStatus.SelectedIndex == 0)
            {
                ShowPopUpMsg("Please Select Status");
            }

            else if (ddlEmploymentType.SelectedIndex == 0)
            {
                ShowPopUpMsg("Please Select Employment Type");
            }
            else if (TxtNRCNo.Text == "")
            {
                ShowPopUpMsg("Please enter NRCNo");
            }
            else if (txtTPin.Text == "")
            {
                ShowPopUpMsg("Please enter TPinNo");
            }
            else if (txtSocio_Security_No.Text == "")
            {
                ShowPopUpMsg("Please enter Socio Security No");
            }
            else if (grdContribution.Rows.Count == 1)
            {
                ShowPopUpMsg("Please enter Contribution");
            }

            else
            {


                if (dt.Rows.Count > 0)
                {
                    ShowPopUpMsg("Number already exists");
                }
                else   // for insert
                {

                    DateTime dob = DateTime.ParseExact(txtDob.Text, dal.dateFormat, null);
                    DateTime empon = DateTime.ParseExact(txtEmpon.Text, dal.dateFormat, null);
                    DateTime contractstart = DateTime.ParseExact(txtContractStart.Text, dal.dateFormat, null);
                    DateTime contractExpired = DateTime.ParseExact(txtContractExpired.Text, dal.dateFormat, null);
                    DateTime contractRenuval = DateTime.ParseExact(txtContractRenuval.Text, dal.dateFormat, null);

                    //try
                    //{
                        //string folderPath = Server.MapPath("~/UploadedImages/");
                        //if (!Directory.Exists(folderPath))
                        //{
                        //    Directory.CreateDirectory(folderPath);
                        //}
                        //fuImage.SaveAs(folderPath + Path.GetFileName(txtEmpNo.Text + "_Photo.jpeg"));
                        //string imagepath = "~/UploadedImages/" + txtEmpNo.Text + "_Photo.jpeg";

                        //fuSignature.SaveAs(folderPath + Path.GetFileName(txtEmpNo.Text + "_Signature.jpeg"));
                        //string signaturepath = "~/UploadedImages/" + txtEmpNo.Text + "_Signature.jpeg";

                        Random random = new Random();
                        ReferenceId = random.Next();
                        hfRefId.Value = ReferenceId.ToString();

                    //string imagepath = "~/UploadedImages/" + Path.GetFileName(ReferenceId + "_Image.png");
                    //string signaturepath = "~/UploadedImages/" + ReferenceId + "_Signature.png";


                    //string folderPath = Server.MapPath("~/UploadedImages/");
                    //if (!Directory.Exists(folderPath))
                    //{
                    //    Directory.CreateDirectory(folderPath);
                    //}
                    //fuImage.SaveAs(folderPath + Path.GetFileName(ReferenceId + "_Image.png"));
                    //image.ImageUrl = "~/UploadedImages/" + Path.GetFileName(ReferenceId + "_Image.png");

                    //fuSignature.SaveAs(folderPath + Path.GetFileName(ReferenceId + "_Signature.png"));
                    //imgSignature.ImageUrl = "~/UploadedImages/" + Path.GetFileName(ReferenceId + "_Signature.png");



                    string imagepath = "~/UploadedImages/" + Path.GetFileName(ReferenceId + "_Image.png");
                    string signaturepath = "~/UploadedImages/" + ReferenceId + "_Signature.png";


                    string folderPath = Server.MapPath("~/UploadedImages/");
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }
                    fuImage.SaveAs(folderPath + Path.GetFileName(ReferenceId + "_Image.png"));
                    image.ImageUrl = "~/UploadedImages/" + Path.GetFileName(ReferenceId + "_Image.png");

                    fuSignature.SaveAs(folderPath + Path.GetFileName(ReferenceId + "_Signature.png"));
                    imgSignature.ImageUrl = "~/UploadedImages/" + Path.GetFileName(ReferenceId + "_Signature.png");





                    foreach (GridViewRow row in grdAllowances.Rows)
                        {
                            
                            Label lblAllowanceId = (Label)row.FindControl("lblAllowanceId");
                            Label lblAllowanceName = (Label)row.FindControl("lblAllowanceName");
                            Label lblAllowanceType = (Label)row.FindControl("lblType");
                            TextBox txtAllowancePercentage = (TextBox)row.FindControl("txtAllowancePercentage");
                            TextBox txtAllowanceAmount = (TextBox)row.FindControl("txtAllowanceAmount");
                            if (txtAllowancePercentage.Text == "")
                            {
                                txtAllowancePercentage.Text = "0";
                            }
                            if (txtAllowanceAmount.Text == "")
                            {
                                txtAllowanceAmount.Text = "0";
                            }

                            dal.Fun_EmployeeAllowance(Convert.ToInt32(lblAllowanceId.Text),  txtEmpNo.Text, lblAllowanceName.Text, Convert.ToDecimal(txtAllowancePercentage.Text), Convert.ToDecimal(txtAllowanceAmount.Text), lblAllowanceType.Text, ddlcompanylocation.SelectedItem.ToString(), ddlworklocation.SelectedItem.ToString(), ReferenceId, "Insert");

                        }
                        foreach (GridViewRow row in grdContribution.Rows)
                        {

                            Label lblContributionType = (Label)row.FindControl("lblContributionType");
                            TextBox txtContributionNo = (TextBox)row.FindControl("txtContributionNo");
                            dal.Fun_Emp_Details_Contribution(txtEmpNo.Text, lblContributionType.Text, txtContributionNo.Text, ReferenceId, "Insert");
                        }

                        foreach (GridViewRow row in grdDeductions.Rows)
                        {

                            Label lblDeductionDescription = (Label)row.FindControl("lblDeductionDescription");
                            TextBox txtDeductionAmount = (TextBox)row.FindControl("txtDeductionAmount");
                            TextBox txtDeductionRange = (TextBox)row.FindControl("txtDeductionRange");

                            if (txtDeductionAmount.Text == "")
                            {
                                txtDeductionAmount.Text = "0";
                            }
                            if (txtDeductionRange.Text == "")
                            {
                                txtDeductionRange.Text = "0";
                            }

                            dal.Fun_EmployeeDeductions_InsUpd(ReferenceId, txtEmpNo.Text, lblDeductionDescription.Text, Convert.ToDecimal(txtDeductionAmount.Text), Convert.ToDecimal(txtDeductionRange.Text), "Insert");
                        }


                        dt = dal.Fun_EmpDetails(txtFirstName.Text, txtMiddleName.Text, txtLastName.Text, txtEmpNo.Text, ddl_gender.SelectedItem.Text, ddlMaratialStatus.SelectedItem.Text,
                          txtAddress.Text, txtAddress1.Text, ddlcompanylocation.SelectedValue, ddlworklocation.SelectedValue, dob,
                          empon, contractstart, contractExpired, contractRenuval, ddlPosition.SelectedValue, ddlDepartment.SelectedValue, ddlShiftType.SelectedItem.ToString(), ddlShiftType.SelectedValue,  txtBankName.Text, txtBankBranch.Text,
                          txtAccountno.Text, txtPassport.Text, txtChildren.Text, txtSpouse.Text, imagepath, signaturepath, ddlStatus.SelectedItem.ToString(),
                          ddlEmploymentType.SelectedItem.ToString(), Convert.ToDouble(txtBasicPay.Text), txtEmailId.Text, txtMobileNo.Text, txtTitle.Text, ReferenceId, TxtNRCNo.Text, txtTPin.Text,txtSocio_Security_No.Text ,"Insert");
                        //  Session["ReferenceId"] = ReferenceId;

                        if (dt.Rows.Count > 0)
                        {

                            //  Response.Redirect("Employee_Creation_Preview.aspx");

                            //ShowPopUpMsg("Employee Created Successfully");
                            //clear();
                            panelmsg.Visible = true;
                            lblsuccmsg.Text = "Employee Details Created Successfully";
                        }



                    //}

                    //catch (Exception ex)
                    //{
                    //    string s = ex.ToString();
                    //}

                }


            }
        }


        protected void btnyes_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                ReferenceId = Convert.ToInt32(Request.QueryString["ReferenceId"]);
            }
            else
            {
                ReferenceId = Convert.ToInt32(hfRefId.Value);
            }
            Response.Redirect(string.Format("~/Payrolls/Employee_Creation_Preview.aspx?ReferenceId={0}", ReferenceId));
        }

        protected void btnno_Click(object sender, EventArgs e)
        {
            clear();

        }


        protected void btnList_Click(object sender, EventArgs e)
        {
            Response.Redirect("Employee_List.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                ShowPopUpMsg("Please enter search textbox");
            }
            else
            {
                Response.Redirect(string.Format("~/Payrolls/Employee_List.aspx?searchtext={0}", txtSearch.Text));
            }
        }

        public void clear()
        {
            txtFirstName.Text = "";
            txtMiddleName.Text = "";
            txtLastName.Text = "";
            txtEmpNo.Text = "";
            ddl_gender.SelectedIndex = 0;
            ddlMaratialStatus.SelectedIndex = 0;
            txtAddress.Text = "";
            txtAddress1.Text = "";
            ddlcompanylocation.SelectedIndex = 0;
            ddlworklocation.SelectedIndex = 0;
            // txtDob.Text = DateTime.Now.ToString();
            txtDob.Text = "";
            txtEmpon.Text = "";
            txtContractStart.Text = "";
            txtContractExpired.Text = "";
            txtContractRenuval.Text = "";
            ddlPosition.SelectedIndex = 0;
            ddlDepartment.SelectedIndex = 0;
            ddlShiftType.SelectedIndex = 0;
            txtBankName.Text = "";
            txtBankBranch.Text = "";
            txtAccountno.Text = "";
            txtPassport.Text = "";
            txtSearch.Text = "";
            txtChildren.Text = "";
            txtSpouse.Text = "";
            txtBasicPay.Text = "";
            ddlStatus.SelectedIndex = 0;
            ddlEmploymentType.SelectedIndex = 0;
            BindAllowances();
            //BindDeductions();
            // SearchDeductionsGridview(Convert.ToDecimal(txtBasicPay.Text), Convert.ToDecimal(lblAllowanceGrossAmount.Text));
            Response.Redirect("Employee_Creation.aspx");

        }
        public void BindDetails(int ReferenceId)
        {
            BindWorkLocation();
            dt = dal.Fun_Emp_Details_GetbyReferenceId(ReferenceId);
            if (dt.Rows.Count > 0)
            {

                DataRow row = dt.Rows[0];

                txtSearch.Text = row["employee_no"].ToString();
                txtFirstName.Text = row["first_name"].ToString();
                txtMiddleName.Text = row["middle_name"].ToString();
                txtLastName.Text = row["last_name"].ToString();
                txtEmpNo.Text = row["employee_no"].ToString();
                ddl_gender.SelectedItem.Text = (row["gen"].ToString());
                ddlMaratialStatus.SelectedItem.Text = row["martial_status"].ToString();
                txtAddress.Text = row["address"].ToString();
                txtAddress1.Text = row["address1"].ToString();
                ddlcompanylocation.SelectedValue = row["location1"].ToString();
                ddlworklocation.SelectedValue = row["work_location"].ToString();
                //txtDob.Text = row["dob"].ToString();
                txtDob.Text = System.Convert.ToDateTime(dt.Rows[0]["dob"]).ToString(dal.dateFormat);
                txtEmpon.Text = System.Convert.ToDateTime(dt.Rows[0]["employed_on"]).ToString(dal.dateFormat);
                txtContractStart.Text = System.Convert.ToDateTime(dt.Rows[0]["contract_start"]).ToString(dal.dateFormat);
                txtContractExpired.Text = System.Convert.ToDateTime(dt.Rows[0]["contract_expired"]).ToString(dal.dateFormat);
                txtContractRenuval.Text = System.Convert.ToDateTime(dt.Rows[0]["contract_renewal"]).ToString(dal.dateFormat);
                ddlPosition.SelectedValue = row["grade"].ToString();
                ddlDepartment.SelectedValue = row["dept_name"].ToString();
                ddlShiftType.SelectedValue = row["shiftId"].ToString();
                txtBankName.Text = row["bank_name"].ToString();
                txtBankBranch.Text = row["Bankbranch"].ToString();
                txtAccountno.Text = row["account_no"].ToString();
                txtPassport.Text = row["Passport"].ToString();
                txtChildren.Text = row["children"].ToString();
                txtSpouse.Text = row["spouse"].ToString();
                ddlStatus.SelectedItem.Text = row["status"].ToString();
                ddlEmploymentType.SelectedItem.Text = row["EmployementType"].ToString();
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
                SearchAllowancesGridview(ReferenceId);
                SearchContributionGridview(ReferenceId);
                //SearchDeductionsGridview(ReferenceId);
            }
        }
        
        public void BindWorkLocation()
        {
            dt = dal.Fun_WorkLocation(0,null,null, "bind");
            ddlworklocation.DataSource = dt;
            ddlworklocation.DataTextField = "working_location";
            ddlworklocation.DataValueField = "sno";
            ddlworklocation.DataBind();
            ddlworklocation.Items.Insert(0, new ListItem("Select", "0"));

        }


        public void BindCompanyLocation()
        {
            dt = dal.Fun_CompnayLocation("bindb");
            ddlcompanylocation.DataSource = dt;
            ddlcompanylocation.DataTextField = "location_name";
            ddlcompanylocation.DataValueField = "location_code";
            ddlcompanylocation.DataBind();
            ddlcompanylocation.Items.Insert(0, new ListItem("Select", "0"));

        }

        public void BindDepartment()
        {

            dt = dal.Fun_Department(0,null,null, "bind");
            ddlDepartment.DataSource = dt;
            ddlDepartment.DataTextField = "dept_name";
            ddlDepartment.DataValueField = "DeptId";
            ddlDepartment.DataBind();
            ddlDepartment.Items.Insert(0, new ListItem("Select", "0"));

        }

        public void BindPositions()
        {

            dt = dal.Fun_Positions(0,null,null, "bind");
            ddlPosition.DataSource = dt;
            ddlPosition.DataTextField = "PositionName";
            ddlPosition.DataValueField = "PositionId";
            ddlPosition.DataBind();
            ddlPosition.Items.Insert(0, new ListItem("Select", "0"));

        }

        public void BindShiftDetails()
        {

            dt = dal.Fun_ShiftDetails(0,null,null,0,0, "bind");
            ddlShiftType.DataSource = dt;
            ddlShiftType.DataTextField = "shift_type";
            ddlShiftType.DataValueField = "SiftId";
            ddlShiftType.DataBind();
            ddlShiftType.Items.Insert(0, new ListItem("Select", "0"));

        }

   
        protected void grdContribution_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            int index = Convert.ToInt32(e.RowIndex);
            GridViewRow row = grdContribution.Rows[index];
            TextBox txtContributionNo = (row.FindControl("txtContributionNo") as TextBox);
            txtContributionNo.Text = "";

            //if (ViewState["Contribution"] != null)
            //{
            //    DataTable dt = (DataTable)ViewState["Contribution"];
            //    DataRow drCurrentRow = null;
            //    int rowindex = Convert.ToInt32(e.RowIndex);
            //    if (dt.Rows.Count >= 1)
            //    {
            //        if (rowindex < dt.Rows.Count)
            //        {
            //            dt.Rows.Remove(dt.Rows[rowindex]);
            //            drCurrentRow = dt.NewRow();
            //            ViewState["Contribution"] = dt;
            //            grdContribution.DataSource = dt;
            //            grdContribution.DataBind();

            //            for (int i = 0; i < grdContribution.Rows.Count - 1; i++)
            //            {
            //                grdContribution.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
            //            }
            //            LastGridViewRow();
            //            SetContributionOldData();
            //        }

            //    }
            //}
        }




        protected void txtDob_TextChanged(object sender, EventArgs e)
        {
            now = int.Parse(DateTime.Today.ToString("yyyyMMdd"));
            DateTime dat = DateTime.ParseExact(txtDob.Text, dal.dateFormat, null);

            DateTime dt_now = DateTime.Now;
            DateTime dt_18 = dt_now.AddYears(-18);
            if (dat.Date >= dt_18.Date)
            {
                Msg = "Age Should Be more Than 18 Years";
                ShowPopUpMsg(Msg);
                txtDob.Text = "";
            }
            else
            {

                now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
                int dob = int.Parse(dat.ToString("yyyyMMdd"));
                int age = (now - dob) / 10000;
                lblAge.Text = "Age: " + (age.ToString());

            }
        }

        protected void txtAllowancePercentage_TextChanged(object sender, EventArgs e)

        {
            double basicpay = 0;
            double AllowanceTotalAmount = 0;
            double GrossAmount = 0;
            if (txtBasicPay.Text == "")
            {
                ShowPopUpMsg("Please enter Basic Pay");
               
            }
            else
            {
                basicpay = Convert.ToDouble(txtBasicPay.Text);

                for (int i = 0; i < grdAllowances.Rows.Count; i++)
                {
                    TextBox txtAllowancePercentage = (TextBox)grdAllowances.Rows[i].Cells[2].FindControl("txtAllowancePercentage");
                    TextBox txtAllowanceAmount = (TextBox)grdAllowances.Rows[i].Cells[3].FindControl("txtAllowanceAmount");
                    Label lblTotalAmount = (Label)grdAllowances.Rows[i].Cells[3].FindControl("lblTotalAmount");
                    if (txtAllowancePercentage.Text != "" && txtAllowancePercentage.Text != "0")
                    {
                        txtAllowanceAmount.Enabled = false;
                        txtAllowanceAmount.Text = "0";
                        double AllowancePercentage = Convert.ToDouble(txtAllowancePercentage.Text);
                        double Amount = Convert.ToDouble(txtAllowanceAmount.Text);
                        double CalculatedAmount = (basicpay * AllowancePercentage) / 100;

                        lblTotalAmount.Text = CalculatedAmount.ToString();
                        AllowanceTotalAmount = CalculateTotalAllowances();

                    }

                }
                basicpay = Convert.ToDouble(txtBasicPay.Text);
                GrossAmount = basicpay + AllowanceTotalAmount;
                lblAllowancesTotalAmount.Text = AllowanceTotalAmount.ToString();
                lblAllowanceGrossAmount.Text = GrossAmount.ToString();
            }
        }

        protected void txtAllowanceAmount_TextChanged(object sender, EventArgs e)
        {
            double AllowanceTotalAmount = 0;
            double GrossAmount = 0;
            double basicpay = 0;
            if (txtBasicPay.Text == "")
            {
                ShowPopUpMsg("Please enter Basic Pay");
            }
            else
            {
                for (int i = 0; i < grdAllowances.Rows.Count; i++)
                {
                    TextBox txtAllowanceAmount = (TextBox)grdAllowances.Rows[i].Cells[2].FindControl("txtAllowanceAmount");
                    TextBox txtAllowancePercentage = (TextBox)grdAllowances.Rows[i].Cells[3].FindControl("txtAllowancePercentage");

                    if (txtAllowanceAmount.Text != "" && txtAllowanceAmount.Text != "0")
                    {
                        //txtAllowancePercentage.Enabled = false;
                        //txtAllowancePercentage.Text = "0";
                        //Label lblTotalAmount = (Label)grdAllowances.Rows[i].Cells[3].FindControl("lblTotalAmount");
                        //lblTotalAmount.Text = txtAllowanceAmount.Text;
                        //double basicpay = Convert.ToDouble(txtBasicPay.Text);
                        //double calculatedamount = Convert.ToDouble(lblTotalAmount.Text);
                        //AllowanceTotalAmount += calculatedamount;
                        //GrossAmount = basicpay + AllowanceTotalAmount;

                        txtAllowancePercentage.Enabled = false;
                        txtAllowancePercentage.Text = "0";
                        Label lblTotalAmount = (Label)grdAllowances.Rows[i].Cells[3].FindControl("lblTotalAmount");
                        lblTotalAmount.Text = txtAllowanceAmount.Text;
                        AllowanceTotalAmount = CalculateTotalAllowances();

                    }
                }
                basicpay = Convert.ToDouble(txtBasicPay.Text);
                GrossAmount = basicpay + AllowanceTotalAmount;
                lblAllowancesTotalAmount.Text = AllowanceTotalAmount.ToString();
                lblAllowanceGrossAmount.Text = GrossAmount.ToString();
            }
                // if (empNo != null)
            //{
            //    double AllowanceTotalAmount = CalculatedGrossPay("");
            //    double GrossAmount = Convert.ToDouble(txtBasicPay.Text) + AllowanceTotalAmount;
            //    lblAllowancesTotalAmount.Text = AllowanceTotalAmount.ToString();
            //    lblAllowanceGrossAmount.Text = GrossAmount.ToString();
            //}
        }





        public void BindAllowances()
        {
            //DataTable dt = new DataTable();
            ////dt.Columns.Add(new DataColumn("sno", typeof(string)));
            //dt.Columns.Add(new DataColumn("allowance_name", typeof(string)));
            //dt.Columns.Add(new DataColumn("type", typeof(string)));
            //dt.Columns.Add(new DataColumn("percentage", typeof(string)));
            //dt.Columns.Add(new DataColumn("amount", typeof(string)));

            //DataRow dr = dt.NewRow();
            ////dr["sno"] = 1;
            //dr["allowance_name"] = "House Rent";
            //dr["type"] = "Allowance";
            //dr["percentage"] = string.Empty;
            //dr["amount"] = string.Empty;
            //dt.Rows.Add(dr);


            //DataRow dr1 = dt.NewRow();
            ////dr1["sno"] = 2;
            //dr1["allowance_name"] = "Lunch";
            //dr1["type"] = "Allowance";
            //dr1["percentage"] = string.Empty;
            //dr1["amount"] = string.Empty;
            //dt.Rows.Add(dr1);

            //DataRow dr2 = dt.NewRow();
            ////dr2["sno"] = 3;
            //dr2["allowance_name"] = "Transport";
            //dr2["type"] = "Allowance";
            //dr2["percentage"] = string.Empty;
            //dr2["amount"] = string.Empty;
            //dt.Rows.Add(dr2);

            //DataRow dr3 = dt.NewRow();
            //// dr3["sno"] = 4;
            //dr3["allowance_name"] = "Responsibility";
            //dr3["type"] = "Allowance";
            //dr3["percentage"] = string.Empty;
            //dr3["amount"] = string.Empty;
            //dt.Rows.Add(dr3);

            dt = dal.Fun_AllowanceType_Get();
            grdAllowances.DataSource = dt;
            grdAllowances.DataBind();
        }


        public void BindContribution()
        {
            dt = dal.Fun_ContributionType(0, null, null, "Bind");
            grdContribution.DataSource = dt;
            grdContribution.DataBind();


            //DataTable dt = new DataTable();
            //dt.Columns.Add(new DataColumn("type", typeof(string)));
            //dt.Columns.Add(new DataColumn("contribution_no", typeof(string)));

            //DataRow dr1 = dt.NewRow();
            ////dr1["sno"] = 2;
            //dr1["type"] = "NAPSA";
            //dr1["contribution_no"] = string.Empty;
            //dt.Rows.Add(dr1);


            //DataRow dr3 = dt.NewRow();
            //// dr3["sno"] = 4;
            //dr3["type"] = "Gratuity";
            //dr3["contribution_no"] = string.Empty;
            //dt.Rows.Add(dr3);

            //DataRow dr4 = dt.NewRow();
            //dr4["type"] = "NHIM";
            //dr4["contribution_no"] = string.Empty;
            //dt.Rows.Add(dr4);


        }

        
        protected void grdAllowances_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            GridViewRow row = grdAllowances.Rows[index];


            TextBox txtAllowancePercentage = (row.FindControl("txtAllowancePercentage") as TextBox);
            TextBox txtAllowanceAmount = (row.FindControl("txtAllowanceAmount") as TextBox);
            Label lblTotalAmount = (row.FindControl("lblTotalAmount") as Label);
            txtAllowancePercentage.Enabled = true;
            txtAllowanceAmount.Enabled = true;
            txtAllowanceAmount.Text = "";
            txtAllowancePercentage.Text = "";
            lblTotalAmount.Text = "";

            double AllowanceTotalAmount = CalculateTotalAllowances();
            double basicpay = Convert.ToDouble(txtBasicPay.Text);
            double GrossAmount = basicpay + AllowanceTotalAmount;
            lblAllowancesTotalAmount.Text = AllowanceTotalAmount.ToString();
            lblAllowanceGrossAmount.Text = GrossAmount.ToString();
        }
        //protected void grdAllowances_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    if (e.CommandName == "Delete")

        //    {

        //        int rowIndex = Convert.ToInt32(e.CommandArgument);
        //        GridViewRow row = grdAllowances.Rows[rowIndex];


        //        TextBox txtAllowancePercentage = (row.FindControl("txtAllowancePercentage") as TextBox);
        //        TextBox txtAllowanceAmount = (row.FindControl("txtAllowanceAmount") as TextBox);
        //        Label lblTotalAmount = (row.FindControl("lblTotalAmount") as Label);
        //        txtAllowancePercentage.Enabled = true;
        //        txtAllowanceAmount.Enabled = true;
        //        txtAllowanceAmount.Text = "";
        //        txtAllowancePercentage.Text = "";
        //        lblTotalAmount.Text = "";

        //    }
        //}

        protected void SearchContributionGridview(int ReferenceId)
        {

            if (txtSearch.Text != "")
            {
                dt = dal.Fun_EmployeeContribution_Get(ReferenceId, "SearchbyId");
                grdContribution.DataSource = dt;
                grdContribution.DataBind();
            }
        }
        protected void SearchAllowancesGridview(int ReferenceId)
        {
            if (txtSearch.Text != "")
            {
                DataTable dt = new DataTable();
                dt = dal.Fun_EmployeeAllowanc_Get(ReferenceId, "SearchbyId");
                grdAllowances.DataSource = dt;
                grdAllowances.DataBind();

                for (int i = 0; i < grdAllowances.Rows.Count; i++)   // for calculation calculated amount
                {
                    TextBox txtAllowanceAmount = (TextBox)grdAllowances.Rows[i].Cells[2].FindControl("txtAllowanceAmount");
                    TextBox txtAllowancePercentage = (TextBox)grdAllowances.Rows[i].Cells[3].FindControl("txtAllowancePercentage");
                    Label lblTotalAmount = (Label)grdAllowances.Rows[i].Cells[3].FindControl("lblTotalAmount");
                    if (txtAllowanceAmount.Text == "0")
                    {
                        txtAllowanceAmount.Enabled = false;
                        double AllowancePercentage = Convert.ToDouble(txtAllowancePercentage.Text);
                        double basicpay = Convert.ToDouble(txtBasicPay.Text);
                        double Amount = Convert.ToDouble(txtAllowanceAmount.Text);
                        double perecentage = (basicpay * AllowancePercentage) / 100;
                        lblTotalAmount.Text = perecentage.ToString();
                    }
                    if (txtAllowancePercentage.Text == "0")
                    {
                        txtAllowancePercentage.Enabled = false;
                        lblTotalAmount.Text = txtAllowanceAmount.Text;

                    }


                }

            }
        }

        protected void BindDeductionsGridview(decimal BasicPay, decimal GrossPay)
        {
            dt = dal.Fun_CalculateDeductions_Get(BasicPay, GrossPay);
            grdDeductions.DataSource = dt;
            grdDeductions.DataBind();
        }

        protected void txtBasicPay_TextChanged(object sender, EventArgs e)
        {
            lblAllowanceBasicPay.Visible = true;
            lblAllowanceBasicPay.Text = txtBasicPay.Text;
            txtAllowanceBasicPay.Text = txtBasicPay.Text;
            txtAllowanceBasicPay.Visible = false;
            lblDeductionBasicPay.Text = txtBasicPay.Text;
            txtDeductionBasicPay.Text = txtBasicPay.Text;

            lblDeductionBasicPay.Visible = true;
            txtDeductionBasicPay.Visible = false;
            lblAllowancesTotalAmount.Text = CalculateTotalAllowances().ToString();
            //if (txtSearch.Text == "")
            //{
            //    BindDeductions();
            //}
            //else
            //{
            //    // SearchDeductionsGridview(ReferenceId);
            //    SearchDeductionsGridview(Convert.ToDecimal(txtBasicPay.Text), Convert.ToDecimal(lblAllowanceGrossAmount.Text));
            //}

            if (lblAllowanceGrossAmount.Text != "")
            {
                BindDeductionsGridview(Convert.ToDecimal(txtBasicPay.Text), Convert.ToDecimal(lblAllowanceGrossAmount.Text));
            }
            double AllowanceTotalAmount = CalculateTotalAllowances();
            if (txtBasicPay.Text != "")
            {

                double basicpay = Convert.ToDouble(txtBasicPay.Text);
                double GrossAmount = basicpay + AllowanceTotalAmount;
                lblAllowanceGrossAmount.Text = GrossAmount.ToString();
                lblDeductionGrossSalary.Text = GrossAmount.ToString();


            }

        }





        protected void LnkBasicPayEdit_Click(object sender, EventArgs e)
        {
            lblAllowanceBasicPay.Visible = false;
            txtAllowanceBasicPay.Visible = true;
            txtAllowanceBasicPay.Text = lblAllowanceBasicPay.Text;
            LnkBasicPayEdit.Visible = false;
            LnkBasicPayUpdate.Visible = true;


        }

        protected void LnkBasicPayUpdate_Click(object sender, EventArgs e)
        {
            lblAllowanceBasicPay.Visible = true;
            LnkBasicPayEdit.Visible = true;
            txtAllowanceBasicPay.Visible = false;
            LnkBasicPayUpdate.Visible = false;
            lblAllowanceBasicPay.Text = txtAllowanceBasicPay.Text;
            txtBasicPay.Text = txtAllowanceBasicPay.Text;
            lblAllowanceBasicPay.Text = txtAllowanceBasicPay.Text;
            lblDeductionBasicPay.Text = lblAllowanceBasicPay.Text;
            double basicpay = Convert.ToDouble(txtAllowanceBasicPay.Text);




            foreach (GridViewRow row in grdAllowances.Rows)
            {
                TextBox txtAllowancePercentage = (TextBox)row.FindControl("txtAllowancePercentage");
                Label lblTotalAmount = (Label)row.FindControl("lblTotalAmount");

                if (txtAllowancePercentage.Text != "0" && txtAllowancePercentage.Text != "")
                {
                    double CalculatedAmount = (basicpay * Convert.ToDouble(txtAllowancePercentage.Text)) / 100;
                    lblTotalAmount.Text = CalculatedAmount.ToString();
                }

            }


            double TotalAllowances = CalculateTotalAllowances();
            double GrossSalary = basicpay + TotalAllowances;

            lblAllowancesTotalAmount.Text = TotalAllowances.ToString();
            lblAllowanceGrossAmount.Text = GrossSalary.ToString();
            int ReferenceId = Convert.ToInt32(Request.QueryString["ReferenceId"]);
            dt = dal.Fun_Emp_Details_UpdateBasicPay(txtEmpNo.Text, basicpay);

            BindDeductionsGridview(Convert.ToDecimal(txtAllowanceBasicPay.Text), Convert.ToDecimal(GrossSalary));
        }

        protected void txtAllowanceBasicPay_TextChanged(object sender, EventArgs e)
        {
            txtBasicPay.Text = txtAllowanceBasicPay.Text;
        }



        public double CalculateTotalAllowances()
        {
            double TotalAllowances = 0;
            double allowances = 0;
            foreach (GridViewRow row in grdAllowances.Rows)
            {

                Label lblTotalAmount = (Label)row.FindControl("lblTotalAmount");
                if (lblTotalAmount.Text != "")
                {
                    allowances = Convert.ToDouble(lblTotalAmount.Text);
                    TotalAllowances += allowances;
                }
            }
            return TotalAllowances;
        }


        public double CalculateTotalDeductions()
        {
            double Totaldeductions = 0;
            double deductions = 0;

            if (grdDeductions.Rows.Count > 0)
            {

                foreach (GridViewRow row in grdDeductions.Rows)
                {

                    TextBox txttotalDeductions = (TextBox)row.FindControl("txtDeductionAmount");
                    //if (row.RowIndex != 3)
                    if(txttotalDeductions.Text!="")
                    {
                        deductions = Convert.ToDouble(txttotalDeductions.Text);
                        Totaldeductions += deductions;
                    }
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
                if(lblDeductionName.Text == "NAPSA Employer")
                {
                    napsaEmployer = Convert.ToDouble(txttotalDeductions.Text);
                }
                if(lblDeductionName.Text == "Gratuity")
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
        protected void txtDeductionBasicPay_TextChanged(object sender, EventArgs e)
        {
            txtBasicPay.Text = txtDeductionBasicPay.Text;
        }

        protected void btnAddContribution_Click(object sender, EventArgs e)
        {
            AddContributionNewRow();
        }

        public void BindContributionGrdView()
        {
            {


                //for (int i = 0; i < grdAllowances.Rows.Count; i++)
                //{
                //    TextBox txtAllowanceAmount = (TextBox)grdAllowances.Rows[i].Cells[2].FindControl("txtAllowanceAmount");
                //    TextBox txtAllowancePercentage = (TextBox)grdAllowances.Rows[i].Cells[3].FindControl("txtAllowancePercentage");
                //    Label lblTotalAmount = (Label)grdAllowances.Rows[i].Cells[3].FindControl("lblTotalAmount");
                //    if (txtAllowanceAmount.Text == "0")
                //    {
                //        txtAllowanceAmount.Enabled = false;
                //        float AllowancePercentage = float.Parse(txtAllowancePercentage.Text);
                //        float basicpay = float.Parse(txtBasicPay.Text);
                //        float Amount = float.Parse(txtAllowanceAmount.Text);
                //        float perecentage = (basicpay * AllowancePercentage) / 100;
                //        lblTotalAmount.Text = perecentage.ToString();
                //    }
                //    if (txtAllowancePercentage.Text == "0")
                //    {
                //        txtAllowancePercentage.Enabled = false;
                //        lblTotalAmount.Text = txtAllowanceAmount.Text;

                //    }

                //}

                //}


                //if (txtSearch.Text == "")
                //{
                //    DataTable dt = new DataTable();
                //    DataRow dr = null;
                //    dt.Columns.Add("sno1", typeof(int));
                //    dt.Columns.Add("type", typeof(string));
                //    dt.Columns.Add("contribution_no", typeof(string));
                //    dr = dt.NewRow();
                //    dr["sno1"] = 1;
                //    dr["type"] = string.Empty;
                //    dr["contribution_no"] = string.Empty;
                //    dt.Rows.Add(dr);
                //    ViewState["Contribution"] = dt;
                //    grdContribution.DataSource = dt;
                //    grdContribution.DataBind();
                //}
                //else
                //{

                //dt.Clear();
                // dt = dal.Fun_Contribution(txtEmpNo.Text, "", "", "BindById");
                //DataTable dtcontribution = new DataTable();
                //foreach (DataRow row in dt.Rows)
                //{
                //    //DataRow dr = dtcontribution.NewRow();
                //    row["sno1"] = count;
                //    row["contribution_no"] = dt.Rows[2].ToString();
                //    // dtcontribution.Rows.Add(dr);
                //    dt.Rows.Add(row.ItemArray);
                //}
                //grdContribution.DataSource = dt;
                //grdContribution.DataBind();

                //if (dt.Rows.Count > 0)
                //    {
                //        //for (int i = 1; i < dt.Rows.Count; i++)
                //{



            }
            //DataRow rr = dt.NewRow();
            //rr["sno1"] = count+1;
            //rr["contribution_no"] = dt.Rows[2].ToString();
            //dt.Rows.Add(rr.ItemArray);
            //grdContribution.DataSource = dt;
            //grdContribution.DataBind();
            //if (dtCurrentTable.Rows.Count > 0)
            //{

            //    count = dtCurrentTable.Rows.Count;
            //    DataTable dt = new DataTable();
            //    DataRow dr = null;
            //    dt.Columns.Add(new DataColumn("sno1", typeof(string)));
            //    dt.Columns.Add(new DataColumn("employee_no", typeof(string)));
            //    dt.Columns.Add(new DataColumn("type", typeof(string)));
            //    dt.Columns.Add(new DataColumn("contribution_no", typeof(string)));
            //    dt.Columns.Add(new DataColumn("percentage1", typeof(string)));
            //    dt.Columns.Add(new DataColumn("value1", typeof(string)));

            //    dr = dt.NewRow();
            //    foreach (DataRow dr1 in dtCurrentTable.Rows)
            //    {
            //        dt.Rows.Add(dr1.ItemArray);
            //    }
            //    dr["sno1"] = count + 1;
            //    dr["type"] = dtCurrentTable.Rows[1].ToString();
            //    dr["contribution_no"] = dtCurrentTable.Rows[2].ToString();
            //    dt.Rows.Add(dr);

            //    grdContribution.DataSource = dt;
            //    grdContribution.DataBind();
            //}
            //    // dt = dal.Fun_Contribution(txtEmpNo.Text, "", "", "BindById");
            //    //DataRow drCurrentRow = null;
            //    //int rowIndex = 1;
            //    //for (int i = 1; i <= dt.Rows.Count; i++)
            //    //{
            //    //    foreach (GridViewRow gr in grdContribution.Rows)
            //    //    {

            //    //        TextBox txtContributionNo = (TextBox)gr.FindControl("txtContributionNo");
            //    //        DropDownList ddlContributionType = (DropDownList)gr.FindControl("ddlContributionType");
            //    //        txtContributionNo.Text = dt.Rows[i-1]["contribution_no"].ToString();

            //    //    }

            //    //    drCurrentRow = dt.NewRow();
            //    //    drCurrentRow["sno1"] =1;
            //    //    //dt.Rows[i]["type"] = ddlContributionType.SelectedValue;
            //    //    rowIndex++;
            //    //}

            //    //grdContribution.DataSource = dt;
            //    //grdContribution.DataBind();

            //    //TextboxFind(grd_Vochers, dt, null);
            //    //LastTextboxFind(grd_Vochers, dt, null);
            //}



            //grdContribution.Columns.Remove(grdContribution.Columns[0]);
            //DataTable dt = new DataTable();
            //dt = dal.Fun_Contribution(txtEmpNo.Text,"","", "BindById");
            //grdContribution.DataSource = dt;
            //grdContribution.DataBind();

            //  dt.Columns.Remove("sno1");
            //for (int i =1;i<dt.Rows.Count;i++)
            //{
            //    foreach(DataRow row in dt.Rows)
            //    {

            //    }

            //    TextBox box1 = (TextBox)grdContribution.Rows[i].Cells[1].FindControl("TextBox1");

            //    row["sno1"] = 1;
            //    row["type"] = string.Empty;
            //    row["contribution_no"] = string.Empty;
            //    grdContribution.DataSource = dt;
            //    grdContribution.DataBind();

            //}

            //foreach(GridView row in grdContribution.Rows)
            //{
            //    TextBox txtContributionNo = (TextBox)row.FindControl("txtContributionNo");
            //}
            //grdContribution.AutoGenerateColumns = false;
            //BoundField test = new BoundField();
            //test.DataField = "employee_no";
            //grdContribution.Columns.Add(test);

            //grdContribution.DataSource = dt;
            //DataColumn column = new DataColumn("sno1");
            //grdContribution.Columns.Remove(grdContribution.Columns[0]);
            //grdContribution.DataBind();
            //}
        }

        private void AddContributionNewRow()
        {
            int rowIndex = 0;


            foreach (GridViewRow gr in grdContribution.Rows)
            {

                TextBox txtContributionNo = (TextBox)gr.FindControl("txtContributionNo");
                DropDownList ddlContributionType = (DropDownList)gr.FindControl("ddlContributionType");
                if (ddlContributionType.SelectedIndex == 0)
                {
                    ShowPopUpMsg("Please select Contribution Type");
                    return;
                }
                if (txtContributionNo.Text == "")
                {
                    ShowPopUpMsg("Please enter Contribution Number");
                    return;
                }

            }


            if (ViewState["Contribution"] != null)
            {
                DataTable dt = (DataTable)ViewState["Contribution"];
                DataRow drCurrentRow = null;
                if (dt.Rows.Count > 0)
                {
                    for (int i = 1; i <= dt.Rows.Count; i++)
                    {

                        DropDownList ddlContributionType = (DropDownList)grdContribution.Rows[rowIndex].Cells[1].FindControl("ddlContributionType");
                        TextBox txtContributionNo = (TextBox)grdContribution.Rows[rowIndex].Cells[2].FindControl("txtContributionNo");

                        drCurrentRow = dt.NewRow();
                        drCurrentRow["sno1"] = i + 1;
                        dt.Rows[i - 1]["type"] = ddlContributionType.SelectedValue;
                        dt.Rows[i - 1]["contribution_no"] = txtContributionNo.Text;
                        rowIndex++;
                    }
                    dt.Rows.Add(drCurrentRow);
                    ViewState["Contribution"] = dt;
                    grdContribution.DataSource = dt;
                    grdContribution.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState Value is Null");
            }
            SetContributionOldData();
        }

        private void SetContributionOldData()
        {
            int rowIndex = 0;
            if (ViewState["Contribution"] != null)
            {
                DataTable dt = (DataTable)ViewState["Contribution"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DropDownList ddlContributionType = (DropDownList)grdContribution.Rows[rowIndex].Cells[1].FindControl("ddlContributionType");
                        TextBox txtContributionNo = (TextBox)grdContribution.Rows[rowIndex].Cells[2].FindControl("txtContributionNo");

                        ddlContributionType.SelectedValue = dt.Rows[i]["type"].ToString();
                        txtContributionNo.Text = dt.Rows[i]["contribution_no"].ToString();
                        rowIndex++;
                    }
                }
            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                ReferenceId = Convert.ToInt32(Request.QueryString["ReferenceId"]);
            }
            else
            {
                ReferenceId = Convert.ToInt32(hfRefId.Value);
            }
            Response.Redirect(string.Format("~/Payrolls/Employee_Creation_Preview.aspx?ReferenceId={0}", ReferenceId));
        }

        private void LastGridViewRow()
        {
            if (ViewState["Contribution"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["Contribution"];
                if (dtCurrentTable.Rows.Count > 0)
                {

                    count = dtCurrentTable.Rows.Count;
                    DataTable dt = new DataTable();
                    DataRow dr = null;
                    dt.Columns.Add(new DataColumn("sno1", typeof(string)));
                    dt.Columns.Add(new DataColumn("type", typeof(string)));
                    dt.Columns.Add(new DataColumn("contribution_no", typeof(string)));
                    dr = dt.NewRow();
                    foreach (DataRow dr1 in dtCurrentTable.Rows)
                    {
                        dt.Rows.Add(dr1.ItemArray);
                    }
                    dr["sno1"] = count + 1;
                    dr["type"] = string.Empty;
                    dr["contribution_no"] = string.Empty;
                    dt.Rows.Add(dr);
                    grdContribution.DataSource = dt;
                    grdContribution.DataBind();

                    //TextboxFind(grd_Vochers, dt, null);
                    //LastTextboxFind(grd_Vochers, dt, null);
                }
            }
            else
            {
                DataTable dt = new DataTable();
                DataRow dr = null;
                dt.Columns.Add(new DataColumn("sno1", typeof(string)));
                dt.Columns.Add(new DataColumn("type", typeof(string)));
                dt.Columns.Add(new DataColumn("contribution_no", typeof(string)));
                dr = dt.NewRow();
                dr["sno1"] = 2;
                dr["type"] = string.Empty;
                dr["contribution_no"] = string.Empty;
                dt.Rows.Add(dr);
                grdContribution.DataSource = dt;
                grdContribution.DataBind();
                //TextboxFind(grd_Vochers, dt, null);
                //  LastTextboxFind(grd_Vochers, dt, null);
            }
        }







        protected void grdDeductions_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //try
            //{
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    int colIndex = 0;
                    //  for (int colIndex = 0; colIndex < e.Row.Cells.Count; colIndex++)
                    {
                        if (colIndex == 1)
                        {

                            int rowIndex = colIndex;
                            TextBox txtName = new TextBox();
                            txtName.Width = 16;
                            txtName.ID = "txtboxname" + colIndex;
                            txtName.AutoPostBack = true;
                            e.Row.Cells[colIndex].Controls.Add(txtName);
                        }
                    }
                }
            //}



            //catch (Exception ex)
            //{
            //}

        }


        public void BindDeductions()
        {
            DataTable dt = new DataTable();
            //  DataRow dr = null;
            dt.Columns.Add(new DataColumn("Type", typeof(string)));
            dt.Columns.Add(new DataColumn("Amount", typeof(string)));
            dt.Columns.Add(new DataColumn("DeductionRange", typeof(string)));
            //dt.Columns.Add(new DataColumn("NAPSA", typeof(string)));
            //dt.Columns.Add(new DataColumn("NHIMA", typeof(string)));
            //dt.Columns.Add(new DataColumn("Paye", typeof(string)));


            //dr["sno"] = 1;
            double BasicPay = 0;
            double GrossPay = 0;

            if (txtBasicPay.Text == "")
            {
                ShowPopUpMsg("Please enter Basic Pay");
            }
            else
            {
                if (lblAllowanceGrossAmount.Text != "")
                {

                    GrossPay = Convert.ToDouble(lblAllowanceGrossAmount.Text);
                }
                BasicPay = Convert.ToDouble(txtBasicPay.Text);
                //  double NapsaEmploye = Convert.ToDouble(5) / 100 * GrossPay;
                //double NapsaEmployer = Convert.ToDouble(5) / 100 * GrossPay; ;
                //double NHIMA = Convert.ToDouble(1) / 100 * BasicPay;
                //double Gratuity = (Convert.ToDouble(25) / 100) * Convert.ToDouble(BasicPay);


                //DataRow dr1 = dt.NewRow();
                //dr1["Type"] = "NAPSA Employee @ 5% of Earned  Gross Salary";
                //dr1["Amount"] = NapsaEmploye.ToString();
                //dr1["DeductionRange"] = "20000";
                //dt.Rows.Add(dr1);

                //DataRow dr2 = dt.NewRow();
                //dr2["Type"] = "NAPSA Employer  @ 5% of Earned Gross Salary";
                //dr2["Amount"] = NapsaEmployer.ToString();
                //dr1["DeductionRange"] = string.Empty;
                //dt.Rows.Add(dr2);

                //DataRow dr3 = dt.NewRow();
                //dr3["Type"] = "NHIMA @ 1% of Basic Pay";
                //dr3["Amount"] = NHIMA.ToString();
                //dt.Rows.Add(dr3);

                //DataRow dr4 = dt.NewRow();
                //dr4["Type"] = "Pay e";
                //dr4["Amount"] = "Paye at Actuals";
                //dt.Rows.Add(dr4);

                //DataRow dr5 = dt.NewRow();
                //dr5["Type"] = "Gratuity @ 25% of Basic Pay";
                //dr5["Amount"] = Gratuity.ToString();
                //dt.Rows.Add(dr5);

                //grdDeductions.DataSource = dt;
                //grdDeductions.DataBind();

                dt = dal.FunContribution_Details_Get_P();
                grdDeductions.DataSource = dt;
                grdDeductions.DataBind();

                foreach (GridViewRow row in grdDeductions.Rows)
                {
                    Label lblContributionType = (Label)row.FindControl("lblContributionType");
                    TextBox txtAmount = (TextBox)row.FindControl("txtDeductionAmount");
                    TextBox txtDeductionRange = (TextBox)row.FindControl("txtDeductionRange");
                    double DeductionRange = 0;
                    if (txtDeductionRange.Text == "")
                    {
                        DeductionRange = 0;
                    }
                    else
                    {
                        DeductionRange = Convert.ToDouble(txtDeductionRange.Text);
                    }

                    if (lblContributionType.Text == "NapsaEmployee")
                    {
                        double NapsaEmploye = Convert.ToDouble(5) / 100 * GrossPay;
                        if (DeductionRange > NapsaEmploye)
                        {
                            txtAmount.Text = NapsaEmploye.ToString();
                        }
                        else
                        {
                            txtAmount.Text = DeductionRange.ToString();
                        }

                    }
                    else if (lblContributionType.Text == "NapsaEmployer")
                    {
                        double NapsaEmployer = Convert.ToDouble(5) / 100 * GrossPay; ;
                        if (DeductionRange > NapsaEmployer)
                        {
                            txtAmount.Text = NapsaEmployer.ToString();
                        }
                        else
                        {
                            txtAmount.Text = DeductionRange.ToString();
                        }
                    }

                    else if (lblContributionType.Text == "NHIMA")
                    {
                        double NHIMA = Convert.ToDouble(1) / 100 * BasicPay;
                        txtAmount.Text = NHIMA.ToString();
                    }
                    else if (lblContributionType.Text == "Gratuity")
                    {
                        double Gratuity = (Convert.ToDouble(25) / 100) * Convert.ToDouble(BasicPay);
                        txtAmount.Text = Gratuity.ToString();
                    }
                    else
                    {
                        txtAmount.Text = "0";
                    }
                }


                //if (txtSearch.Text != "")
                //{
                //    int ReferenceId = Convert.ToInt32(Request.QueryString["ReferenceId"]);
                //    SaveDeductionsGridview(ReferenceId);
                //}
            }
        }



    }
}