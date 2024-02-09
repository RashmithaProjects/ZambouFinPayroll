<%@ Page Title="" Language="C#" MasterPageFile="~/Master3.Master" AutoEventWireup="true" CodeBehind="PaySlips.aspx.cs" Inherits="Payroll_Project.Reports.PaySlips" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder1" runat="server">



    <div class="row">
        <div class="col-md-2">
            <asp:Label ID="lblEmployeeNo" runat="server" Text="Employee No"></asp:Label>
        </div>
        <div class="col-md-2">
            <asp:DropDownList ID="ddlEmployeNo" runat="server" CssClass="form-select txtbox" AutoPostBack="true" OnSelectedIndexChanged="ddlEmployeNo_SelectedIndexChanged">
                <asp:ListItem Value="0">Select</asp:ListItem>
            </asp:DropDownList>

        </div>


        <div class="col-md-2">
            <asp:Label ID="lblYear" runat="server" Text="Year"></asp:Label>
        </div>
        <div class="col-md-2">
            <asp:TextBox ID="txtYear" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="col-md-2">
            <asp:Label ID="lblMonth" runat="server" Text="Month"></asp:Label>
        </div>

        <div class="col-md-2">
            <asp:DropDownList ID="ddlMonth" runat="server" CssClass="form-select txtbox" AutoPostBack="true" Font-Size="Smaller" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged">
                <asp:ListItem Value="0" Text="Select" />
                <asp:ListItem Value="January" Text="January" />
                <asp:ListItem Value="February" Text="February" />
                <asp:ListItem Value="March" Text="March" />
                <asp:ListItem Value="April" Text="April" />
                <asp:ListItem Value="May" Text="May" />
                <asp:ListItem Value="June" Text="June" />
                <asp:ListItem Value="July" Text="July" />
                <asp:ListItem Value="August" Text="August" />
                <asp:ListItem Value="September" Text="September" />
                <asp:ListItem Value="October" Text="October" />
                <asp:ListItem Value="November" Text="November" />
                <asp:ListItem Value="December" Text="December" />
            </asp:DropDownList>
        </div>
        </div>

        <br />   

      <div class="row">
        <div class="col-md-2">
            <asp:Button ID="btnRefresh" runat="server" Text="Refresh" Height="30px" Width="100px" CausesValidation="false" Style="background: #3F698F; color: white; border-radius: 8px; border: none" OnClick="btnRefresh_Click" />
        </div>
        <div class="col-md-2">
            <asp:Button ID="BtnPrint" runat="server" Text="Print" Height="30px" Width="100px" CausesValidation="false" Style="background: #3F698F; color: white; border-radius: 8px; border: none" OnClick="BtnPrint_Click" />
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


</asp:Content>
