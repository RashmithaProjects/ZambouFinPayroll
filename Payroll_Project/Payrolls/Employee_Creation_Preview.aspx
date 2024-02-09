<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employee_Creation_Preview.aspx.cs" Inherits="Payroll_Project.Payrolls.Employee_Creation_Preview" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <link rel="icon" type="image/x-icon" href="/images/world_oil2.ico">
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />

    <script src="Scripts/jquery-3.3.1.slim.min.js"></script>

    <link rel="icon" type="image/x-icon" href="/images/world_oil2.ico">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.3.1.slim.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>

    <meta name="robots" content="noindex, nofollow" />
    <meta content="" name="description" />
    <meta content="" name="keywords" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="../assets/img/favicon.png" rel="icon" />
    <link href="../assets/img/apple-touch-icon.png" rel="apple-touch-icon" />

    <!-- Google Fonts -->
    <link href="https://fonts.gstatic.com" rel="preconnect" />
    <link href="https://fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i|Nunito:300,300i,400,400i,600,600i,700,700i|Poppins:300,300i,400,400i,500,500i,600,600i,700,700i" rel="stylesheet" />
    <link href="../Assets/Bootstrap/Css/bootstrap.css" rel="stylesheet" />
    <link href="../Assets/Bootstrap/Css/bootstrap.min.css" rel="stylesheet" />
    <!-- Vendor CSS Files -->
    <link href="assets/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />



</head>
<body>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.3.1.slim.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>

    <script type="text/javascript">
        function printPageArea(areaID) {
            var printContent = document.getElementById(areaID).innerHTML;
            var originalContent = document.body.innerHTML;
            document.body.innerHTML = printContent;
            window.print();
            document.body.innerHTML = originalContent;
        }
    </script>

    <form id="form1" runat="server">
        <h4>Personal Details</h4>
        <table>
            <tr>
                <td>
                    <asp:Label ID="LblFirstName" runat="server" Text="FirstName"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lblMiddleName" runat="server" Text="MiddleName"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtMiddleName" runat="server" CssClass="form-control txtbox" Enabled="false"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lblLastName" runat="server" Text="LastName"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control txtbox" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblEmpNo" runat="server" Text="Emp No"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEmpNo" runat="server" CssClass="form-control txtbox" Enabled="false"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lblGender" runat="server" Text="Gender"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtGender" runat="server" CssClass="form-control txtbox" Enabled="false"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="LblMaritialStatus" runat="server" Text="Martial Status"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtMaritialStatus" runat="server" CssClass="form-control txtbox" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" Font-Size="Smaller" TextMode="MultiLine" Enabled="false"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lblAddress1" runat="server" Text="Address1"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtAddress1" runat="server" CssClass="form-control" Font-Size="Smaller" TextMode="MultiLine" Enabled="false"> </asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lblcompanylocation" runat="server" Text="Company Location"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCompanyLocation" runat="server" CssClass="form-control txtbox" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Work Location"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtWorkLocation" runat="server" CssClass="form-control txtbox" Enabled="false"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lblDOB" runat="server" Text="DOB"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDob"
                        ErrorMessage="Enter Payroll Month">*</asp:RequiredFieldValidator>
                </td>

                <td>
                    <asp:TextBox ID="txtDob" runat="server" CssClass="form-control txtbox" Enabled="false"></asp:TextBox>
                    <asp:Label ID="lblAge" runat="server" Text="   " Font-Size="Small" ForeColor="#0066ff"></asp:Label>
                </td>

                <td>
                    <asp:Label ID="lblEmpon" runat="server" Text="Employee On"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtEmpon"
                        ErrorMessage="Enter Payroll Month">*</asp:RequiredFieldValidator>

                </td>
                <td>
                    <asp:TextBox ID="txtEmpon" runat="server"  CssClass="form-control txtbox" Enabled="false"></asp:TextBox>

                </td>

            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblContractStart" runat="server" Text="Contract Start"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtContractStart"
                        ErrorMessage="Enter Payroll Month">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtContractStart" runat="server" CssClass="form-control txtbox" Enabled="false"></asp:TextBox>
                </td>

                <td>
                    <asp:Label ID="lblContractExpired" runat="server" Text="Contract Expired"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtContractExpired"
                        ErrorMessage="Enter Payroll Month">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtContractExpired" runat="server" CssClass="form-control txtbox" Enabled="false"></asp:TextBox>

                </td>

                <td>
                    <asp:Label ID="lblContractRenuval" runat="server" Text="Contract Renuval"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtContractRenuval"
                        ErrorMessage="Enter Payroll Month">*</asp:RequiredFieldValidator>

                </td>
                <td>
                    <asp:TextBox ID="txtContractRenuval" runat="server" CssClass="form-control txtbox" Enabled="false"></asp:TextBox>
                </td>

            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblPosition" runat="server" Text="Position"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPosition" runat="server" CssClass="form-control txtbox" Enabled="false"></asp:TextBox>
                </td>

                <td>
                    <asp:Label ID="lblDepartment" runat="server" Text="Department"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDepartment" runat="server" CssClass="form-control txtbox" Enabled="false"></asp:TextBox>
                </td>

                <td>
                    <asp:Label ID="lblShiftType" runat="server" Text="Shift Type"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtShiftType" runat="server" CssClass="form-control txtbox" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblbankname" runat="server" Text="Bank Name"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtBankName" runat="server" CssClass="form-control txtbox" Enabled="false"></asp:TextBox>
                </td>

                <td>
                    <asp:Label ID="lblBankBranch" runat="server" Text="Bank Branch"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtBankBranch" runat="server" CssClass="form-control txtbox" Enabled="false"></asp:TextBox>
                </td>

                <td>
                    <asp:Label ID="lblAccoutno" runat="server" Text="Account No"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtAccountno" runat="server" CssClass="form-control txtbox" Enabled="false"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="lblPassport" runat="server" Text="Passport"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPassport" runat="server" CssClass="form-control txtbox" Enabled="false"></asp:TextBox>
                </td>

                <td>
                    <asp:Label ID="lblBasicPay" runat="server" Text="BasicPay"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtBasicPay" runat="server" CssClass="form-control txtbox" Enabled="false"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lblChildren" runat="server" Text="Children"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtChildren" runat="server" CssClass="form-control txtbox" Enabled="false"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="lblSpouse" runat="server" Text="Spouse"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSpouse" runat="server" CssClass="form-control txtbox" Enabled="false"></asp:TextBox>
                </td>

                <td>
                    <asp:Label ID="lblStatus" runat="server" Text="Status"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtStatus" runat="server" CssClass="form-control txtbox" Enabled="false"></asp:TextBox>
                </td>

                <td>
                    <asp:Label ID="lblEmployementType" runat="server" Text="Employement Type"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEmploymentType" runat="server" CssClass="form-control txtbox" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblEmailId" runat="server" Text="Email Id"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEmailId" runat="server" CssClass="form-control txtbox" Enabled="false"></asp:TextBox>
                </td>

                <td>
                    <asp:Label ID="lblMobileNo" runat="server" Text="Mobile No"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtMobileNo" runat="server" CssClass="form-control txtbox" Enabled="false"></asp:TextBox>
                </td>

                <td>
                    <asp:Label ID="lblNRCNo" runat="server" Text="NRCNo"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtNRCNo" runat="server" CssClass="form-control txtbox" Enabled="false"></asp:TextBox>
                </td>

            </tr>

            <tr>
                <td>
                    <asp:Label ID="lblTpin" runat="server" Text="TPin"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtTPin" runat="server" CssClass="form-control txtbox" Enabled="false"></asp:TextBox>
                </td>

                <td>
                    <asp:Label ID="lblSocio_Security_No" runat="server" Text="Socio Security No"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSocio_Security_No" runat="server" CssClass="form-control txtbox" Enabled="false"></asp:TextBox>
                </td>

                <td>
                    <asp:Label ID="lblTitle" runat="server" Text="Title" Visible="false"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control txtbox" Visible="false"></asp:TextBox>
                </td>

            </tr>


            <tr>
                <td>
                    <asp:Label ID="lblImage" runat="server" Text="Photo"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Image ID="image" runat="server" Height="105px" Width="133px" ImageAlign="AbsMiddle" />
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="lblSignature" runat="server" Text="Signature"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Image ID="imgSignature" runat="server" Height="105px" Width="133px" ImageAlign="AbsMiddle" />
                </td>
            </tr>
        </table>
        <table>

            <tr id="divContribution">
                <td>
                    <h4>Contribution</h4>
                    <asp:GridView ID="grdContribution" runat="server" Width="100%" OnRowDataBound="grdContribution_RowDataBound" GridLines="Horizontal">
                        <HeaderStyle HorizontalAlign="Center" BackColor="#80ccff" />
                        <RowStyle HorizontalAlign="Center" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <h4>Allowances</h4>
                    <asp:Label ID="Label6" runat="server" Text="Basic Pay  :"></asp:Label>
                    <asp:Label ID="lblAllowanceBasicPay" runat="server" Text=""></asp:Label>&nbsp&nbsp
                                <asp:Label ID="Label4" runat="server" Text="Total Allowances  :"></asp:Label>
                    <asp:Label ID="lblAllowancesTotalAmount" runat="server" Text=""></asp:Label>
                    &nbsp&nbsp 
                            <asp:Label ID="Label5" runat="server" Text="Gross Salary  :  "></asp:Label>
                    <asp:Label ID="lblAllowanceGrossAmount" runat="server" Text=""></asp:Label>

                    <asp:GridView ID="grdAllowances" runat="server" OnRowDataBound="grdAllowances_RowDataBound">
                        <HeaderStyle HorizontalAlign="Right" BackColor="#80ccff" />
                        <Columns>
                        </Columns>
                    </asp:GridView>
                </td>
            
                

                <td>
                    <h4>Deductions</h4>
                    <asp:Label ID="Label3" runat="server" Text=" Basic Pay  :"></asp:Label>
                    <asp:Label ID="lblDeductionBasicPay" runat="server" Text=""></asp:Label>
                    &nbsp
                                <asp:Label ID="Label7" runat="server" Text=" Total Deductions  : "></asp:Label>
                    <asp:Label ID="lblTotalDeductions" runat="server" Text=""></asp:Label>
                    &nbsp
                                <asp:Label ID="Label8" runat="server" Text=" Gross Salary :"></asp:Label>
                    <asp:Label ID="lblDeductionGrossSalary" runat="server" Text=""></asp:Label>
                    &nbsp
                                <asp:Label ID="Label9" runat="server" Text=" CTC :"></asp:Label>
                    <asp:Label ID="lblDeductionsCTC" runat="server" Text=""></asp:Label>


                    <asp:GridView ID="grdDeductions" AutoGenerateColumns="false" runat="server"  OnRowDataBound="grdDeductions_RowDataBound" BorderStyle="Solid">
                        <HeaderStyle HorizontalAlign="Center" BackColor="#80ccff" />
                        <RowStyle />
                        <Columns>


                            <asp:TemplateField HeaderText="Name" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblDeductionName" Text='<%# Eval("Name") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Deduction And CTC">
                                <ItemTemplate>
                                    <asp:Label ID="lblDeductionDescription" Text='<%# Eval("Description") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Amount">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtDeductionAmount" Enabled="false" Text='<%# Eval("Amount") %>' runat="server" Style="text-align: right; width: 100px" onkeypress="return isNumberKey(event)" AutoPostBack="true"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Ceiling Amount">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtDeductionRange" Enabled="false" runat="server" Text='<%# Eval("Range") %>' Style="text-align: right; width: 100px" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>

                    </asp:GridView>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblSalarySummary" runat="server" Text="Salary Summary" Font-Bold="true" CssClass="lblSalarySummarycss"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Basic Pay:"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblSalarySummaryBasicPay" runat="server"></asp:Label>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="Label10" runat="server" Text="Total Allowances :"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblSalarySummaryTotalAllowance" runat="server"></asp:Label>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="Label11" runat="server" Text="Gross Salary:"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblSalarySummaryGrossPay" Font-Bold="true" runat="server"></asp:Label>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="Label12" runat="server" Text="Standard Deductions"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblSalarySummaryStandardDeductions" runat="server"></asp:Label>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="Label13" runat="server" Text="Net Salary:"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblSalarySummaryNetSalary" Font-Bold="true" runat="server"></asp:Label>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="Label14" runat="server" Text="CTC Contribution:"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblSalarySummaryCTCContribution" Font-Bold="true" runat="server"></asp:Label>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="Label15" runat="server" Text="Total CTC:"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblSalarySummaryTotalCTC" Font-Bold="true" runat="server"></asp:Label>
                </td>
            </tr>

            <tr>

                <td>
                    <input type="button" id="btnPrint" class="btn btn-primary " onclick="window.print()" value="Print" />
                    <asp:Button ID="btnClose" runat="server" CssClass="btn  btn-danger" Text="Close" OnClick="btnClose_Click" />
                </td>
            </tr>

        </table>
    </form>
</body>
</html>
