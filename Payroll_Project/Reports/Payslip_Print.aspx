<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Payslip_Print.aspx.cs" Inherits="Payroll_Project.Reports.Payslip_Print" %>

<!DOCTYPE html>

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
    <link href="assets/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" /

</head>
<body>
    <form id="form1" runat="server">
        <div>

            <br />

            <div class="row">

                <div class="col-md-2">
                    <asp:Label ID="lblEmployeeNo" runat="server" Text="Employee No"></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:TextBox ID="txtEmployeeNo" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="col-md-1">
                    <asp:Label ID="lblYear" runat="server" Text="Year"></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:TextBox ID="txtYear" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="col-md-1">
                    <asp:Label ID="lblMonth" runat="server" Text="Month"></asp:Label>
                </div>

                <div class="col-md-2">
                    <asp:TextBox ID="txtMonth" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                </div>

            </div>

            <hr />
            <br />

            <table class="center" id="tblPaySlips" runat="server" border="5" bordercolor=" #C0C0C0" align="center">
                <tr>
                    <th colspan="6">ZAMBOU FINANCIAL SERVICES LIMITED</th>
                    <%-- &nbsp&nbsp&nbsp--%>
                    <th>CURRENCY: (K)</th>
                </tr>
                <tr>
                    <th colspan="7">Pay Statement For February 2023    &nbsp&nbsp&nbsp   &nbsp&nbsp&nbsp  &nbsp&nbsp&nbsp &nbsp&nbsp&nbsp         EXCH.RATE:1.00</th>
                </tr>
                <tr style="background-color: lightyellow">
                    <th colspan="2" align='left'>Emp Name:
              
             <%--<input id="Text1" type="CECILIA KATAI" />--%>
                    </th>

                    <th align='left'>Emp No.</th>
                    <th colspan="2">NRC.No.</th>
                    <th>Eng.Date</th>
                    <th>Basic</th>

                </tr>
                <tr>
                    <th colspan="2" style="align: left; font-family: Calibri; font-size: small;">
                        <asp:Label ID="lblEmpname" runat="server" Text=""></asp:Label></th>
                    <th style="font-family: Calibri; font-size: small;">
                        <asp:Label ID="lblEmpno" runat="server" Text="ZFS012"></asp:Label></th>
                    <th colspan="2" style="font-family: Calibri; font-size: small;">
                        <asp:Label ID="lblNRCNo" runat="server" Text="458758/61/1"></asp:Label>
                    </th>
                    <th style="font-family: Calibri; font-size: small;">
                        <asp:Label ID="lblEngDate" runat="server" Text="01 Sep 2018"></asp:Label></th>
                    <th style="font-family: Calibri; font-size: small;">
                        <asp:Label ID="lblBasic" runat="server" Text="4,000.00"></asp:Label></th>

                </tr>

                <tr style="background-color: lightyellow">
                    <th>Taxable Pay YTD</th>
                    <th>Tax Year to Date</th>
                    <th>ZNPF/NAPSA YTD </th>
                    <th>Soc.Sec.No.</th>
                    <th>Leave Days</th>
                    <th colspan="2">Leave Value</th>
                </tr>
                <tr>
                    <th style="font-family: Calibri; font-size: small;">
                        <asp:Label ID="lblTPYTD" runat="server" Text="8,000.00"></asp:Label></th>
                    <th style="font-family: Calibri; font-size: small;">
                        <asp:Label ID="lblTDate" runat="server" Text="0.00"></asp:Label></th>
                    <th style="font-family: Calibri; font-size: small;">
                        <asp:Label ID="lblYNAPSA" runat="server" Text="400.00"></asp:Label>
                    </th>
                    <th>
                        <asp:Label ID="LblSocioSecurityNo" runat="server"></asp:Label></th>
                    <th style="font-family: Calibri; font-size: small;">
                        <asp:Label ID="lblLdays" runat="server" Text="48.00"></asp:Label></th>
                    <th colspan="2" style="font-family: Calibri; font-size: small;">
                        <asp:Label ID="lblLvalue" runat="server" Text="7,384.62"></asp:Label></th>
                </tr>
                <tr aria-multiline="True" style="background-color: #C0C0C0">
                    <th>DEDUCTIONS</th>
                    <th>Outstanding Months</th>
                    <th>Balance</th>
                    <th>This Month</th>
                    <th>INCOMES</th>
                    <th>Units</th>
                    <th>This Month</th>
                </tr>
                <tr style="height: 200px" valign="TOP">
                    <th style="align: left; vertical-align: top font-family: Calibri; font-size: small">TAX<br />
                        NAPSA<br />
                        NATIONAL HEALTH INS.(NHIS)<br />
                        ZAMBOU LOAN
                    </th>
                    <th>
                        <br />
                        <br />
                        <br />
                        <asp:Label ID="lblZloan" runat="server" Text="1"></asp:Label>

                    </th>
                    <th>
                        <br />
                        <br />
                        <br />
                        <asp:Label ID="lblZloanB" runat="server" Text="1,867.32"></asp:Label>
                    </th>
                    <th>
                        <br />
                        <asp:Label ID="lblNApsaMonth" runat="server" Text="200.00"></asp:Label>
                        <br />
                        <asp:Label ID="lblNHISMonth" runat="server" Text="40.00"></asp:Label><br />
                        <asp:Label ID="lblZLM" runat="server" Text="1,867.33"></asp:Label>
                    </th>
                    <th>Basic Pay</th>
                    <th>
                        <asp:Label ID="lblunits" runat="server" Text="(1)"></asp:Label>
                    </th>
                    <th>
                        <asp:Label ID="lblBasicPayMonth" runat="server" Text="4,000.00"></asp:Label></th>

                </tr>
                <tr>
                    <th align='left' style="background-color: lightyellow;">Grade :
                <asp:Label ID="lblGrade" runat="server" ForeColor="Black"></asp:Label>
                    </th>

                    <th align='left' style="color: blue">Pay Point<br />
                        <asp:Label ID="lblPpoint" runat="server" ForeColor="Black"></asp:Label>
                    </th>
                    <th style="color: blue">Total Deductions
                <br />
                        <asp:Label ID="lblTDed" runat="server" ForeColor="Black"></asp:Label>
                    </th>
                    <th style="font-size: xx-small; font-family: Calibri">Payroll System by RIS
                <br />
                        Tel 9652406277 INDIA
                <br />
                        email:info@rashmitha.com
                    </th>
                    <th style="color: blue">Leave Days Taken
                <br />
                        <asp:Label ID="lblleavesTaken" runat="server" Text="0.00" ForeColor="Black"></asp:Label>
                    </th>
                    <th colspan="2" style="color: blue">Total Incomes<br />
                        <asp:Label ID="lblTincomes" runat="server" Text="4,000.00" ForeColor="Black"></asp:Label>

                    </th>
                </tr>
                <tr>
                    <th colspan="2" align='left' style="color: blue">Bank Name:<asp:Label ID="lblBname" runat="server" Text="XXXX"></asp:Label></th>
                    <th style="color: blue">Taxable This Month<br />
                        <asp:Label ID="lblTMonth" runat="server" Text="4,000.00" ForeColor="Black"></asp:Label>
                    </th>
                    <th style="color: blue">Xmas Bonus<br />
                        <asp:Label ID="lblXBonus" runat="server" Text="0.00" ForeColor="Black"></asp:Label>
                    </th>
                    <th style="color: blue">Gross YTD
                <br />
                        <asp:Label ID="lblGYTD1" runat="server" Text="8,000.00" ForeColor="Black"></asp:Label>
                    </th>

                    <th colspan="2" style="color: blue">Net Pay (Bank)<br />
                        <asp:Label ID="lblNPay" runat="server" Text="1,892.67" ForeColor="Black"></asp:Label>

                    </th>

                </tr>
                <tr>
                    <th colspan="2" align='left' style="color: blue">ACC No:<asp:Label ID="lblAccountno" runat="server" Text="123" ForeColor="Black"></asp:Label>
                    </th>
                    <th style="color: blue">000002:ADMINISTRATION</th>
                    <th colspan="2" align='left' style="color: blue">DIVISION 1</th>
                    <th colspan="2" align='left' style="color: blue">Job:<asp:Label ID="lbljob" runat="server" Text="Admin" ForeColor="Black"></asp:Label>
                    </th>
                </tr>
            </table>

            <br />

            <div class="row">
                <div class="col-md-6"></div>
                <div class="col-sm-6">
                    <input type="button" id="btnPrint" class="btn btn-primary " onclick="window.print()" value="Print" />
                    <asp:Button ID="btnClose" runat="server" CssClass="btn  btn-danger" Text="Close" OnClick="btnClose_Click"/>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
