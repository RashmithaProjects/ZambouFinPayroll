<%@ Page Title="" Language="C#" MasterPageFile="~/Master3.Master" AutoEventWireup="true" CodeBehind="GrossSalaryAndWages.aspx.cs" Inherits="Payroll_Project.Reports.GrossSalaryAndWages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder1" runat="server">

    <%--<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/css/bootstrap.min.css">
  <script src="https://cdn.jsdelivr.net/npm/jquery@3.7.1/dist/jquery.slim.min.js"></script>
  <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js"></script>
  <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/js/bootstrap.bundle.min.js"></script>
    <style>
         table {
          
        border-collapse:collapse ;
        border-spacing: 0 15px;
      }
      </style>--%>


    <div class="row">
        <div class="col-md-4">
            <asp:DropDownList ID="ddl_Export" runat="server">
                <asp:ListItem Value="0">Select</asp:ListItem>
                <asp:ListItem Value="1">Pdf</asp:ListItem>
                <asp:ListItem Value="2">Excel</asp:ListItem>
            </asp:DropDownList>

            <asp:Button ID="btnGo" Text="Go" runat="server" OnClick="btnGo_Click" />
        </div>
    </div>

    <br />

    <div class="row">
        <div class="col-md-4"></div>
        <div class="col-md-6">
            <asp:Label ID="lblHeading" runat="server" Text="GROSS SALARIES & WAGES - " Font-Bold="true" ></asp:Label>
           <asp:Label ID="lblYear" runat="server" Font-Bold="true"></asp:Label>
        </div>
    </div>

    <br />

    <div class="row" runat="server">
        <div class="col-md-12">
            <asp:GridView ID="grdReport" runat="server" AutoGenerateColumns="false"
                class="table table-sm table-striped table-bordered table-responsive table-hover" CssClass="display table"
                EmptyDataText="No records Found." ShowFooter="true"
                Width="100%" Font-Size="Smaller">
                <Columns>

                    <%--                        <asp:TemplateField HeaderText="Reference No" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblReferenceId" Text='<%# Eval("ReferenceId") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>

                    <asp:TemplateField HeaderText="Employee Name">
                        <ItemTemplate>
                            <asp:Label ID="lblEmpName" Text='<%# Eval("EmployeeName") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Employee No">
                        <ItemTemplate>
                            <asp:Label ID="lblEmpNo" Text='<%# Eval("EmployeeNo") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="January">
                        <ItemTemplate>
                            <asp:Label ID="lblJanuary" Text='<%# Eval("January") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lblTotalJanuary" runat="server" Font-Bold="true" />
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Febraury">
                        <ItemTemplate>
                            <asp:Label ID="lblFebraury" Text='<%# Eval("February") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lblTotalFebraury" runat="server" Font-Bold="true" />
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="March">
                        <ItemTemplate>
                            <asp:Label ID="lblMarch" Text='<%# Eval("March") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lblTotalMarch" runat="server" Font-Bold="true" />
                        </FooterTemplate>
                    </asp:TemplateField>




                    <asp:TemplateField HeaderText="April">
                        <ItemTemplate>
                            <asp:Label ID="lblApril" Text='<%# Eval("April") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lblTotalApril" runat="server" Font-Bold="true" />
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="May">
                        <ItemTemplate>
                            <asp:Label ID="lblMay" Text='<%# Eval("May") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lblTotalMay" runat="server" Font-Bold="true" />
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="June">
                        <ItemTemplate>
                            <asp:Label ID="lblJune" Text='<%# Eval("June") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lblTotalJune" runat="server" Font-Bold="true" />
                        </FooterTemplate>
                    </asp:TemplateField>



                    <asp:TemplateField HeaderText="July">
                        <ItemTemplate>
                            <asp:Label ID="lblJuly" Text='<%# Eval("July") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lblTotalJuly" runat="server" Font-Bold="true" />
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="August">
                        <ItemTemplate>
                            <asp:Label ID="lblAugust" Text='<%# Eval("August") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lblTotalAugust" runat="server" Font-Bold="true" />
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="September">
                        <ItemTemplate>
                            <asp:Label ID="lblSeptember" Text='<%# Eval("September") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lblTotalSeptember" runat="server" Font-Bold="true" />
                        </FooterTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="October">
                        <ItemTemplate>
                            <asp:Label ID="lblOctober" Text='<%# Eval("October") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lblTotalOctober" runat="server" Font-Bold="true" />
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="November">
                        <ItemTemplate>
                            <asp:Label ID="lblNovember" Text='<%# Eval("November") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lblTotalNovember" runat="server" Font-Bold="true" />
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="December">
                        <ItemTemplate>
                            <asp:Label ID="lblDecember" Text='<%# Eval("December") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lblTotalDecember" runat="server" Font-Bold="true" />
                        </FooterTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="Total">
                        <ItemTemplate>
                            <asp:Label ID="lblTotal" Text='<%# Eval("Total") %>' Font-Bold="true" runat="server"></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lblTotal" runat="server" Font-Bold="true" />
                        </FooterTemplate>
                    </asp:TemplateField>



                </Columns>
                <PagerSettings Mode="NumericFirstLast" PageButtonCount="4" FirstPageText="First" LastPageText="Last" />

                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />

            </asp:GridView>

        </div>
    </div>


    <table runat ="server" visible="false" class="center" border="5" bordercolor=" #C0C0C0" align="center">
        <tr>
            <th colspan="16" style="text-align: center">ZAMBOU FINANCIAL SERVICES </th>
        </tr>
        <tr>
            <th colspan="16" style="font-family: Calibri; font-size: medium">NET SALARIES & WAGES - SCHEDULE AS AT DECEMBER 31,2022</th>
        </tr>
        <tr style="font-family: Calibri; font-size: medium">

            <th>SNO</th>
            <th>EMPLOYEE NAME</th>
            <th>EMPL NO.</th>
            <th>Jan-22</th>
            <th>Feb-22</th>
            <th>Mar-22</th>
            <th>Apr-22</th>
            <th>May-22</th>
            <th>Jun-22</th>
            <th>Jul-22</th>
            <th>Aug-22</th>
            <th>Sep-22</th>
            <th>Oct-22</th>
            <th>Nov-22</th>
            <th>Dec-22</th>
            <th>TOTAL</th>
        </tr>
        <tr style="height: 200px">
            <th>1<br />
                2<br />
                3<br />
                4<br />
                5<br />
                6<br />
                7<br />
                8<br />
            </th>
            <th>
                <asp:Label ID="lblEname" runat="server" Text="ROBERT DANIEL BOUWER"></asp:Label>
                <br />
                <asp:Label ID="lblEnamee" runat="server" Text="BASILIO MUSONDA"></asp:Label><br />
                <asp:Label ID="lblEnameee" runat="server" Text="PRISCILLA"></asp:Label><br />
                <asp:Label ID="IblEnameeee" runat="server" Text="BRIAN K KAFWIMBI"></asp:Label><br />
                <asp:Label ID="Label4" runat="server" Text="CECILIA KATAI"></asp:Label><br />
                <asp:Label ID="Label5" runat="server" Text="KUDZAI S.H.MWELWA"></asp:Label><br />
                <asp:Label ID="Label6" runat="server" Text="MUSONDA KALOBWE"></asp:Label><br />
                <asp:Label ID="Label7" runat="server" Text="CHUNGU MWAPE"></asp:Label>
            </th>
            <th>
                <asp:Label ID="lblEmpno" runat="server" Text="ZFS001"></asp:Label><br />
                <asp:Label ID="Label1" runat="server" Text="ZFS002"></asp:Label><br />
                <asp:Label ID="Label2" runat="server" Text="ZFS003"></asp:Label><br />
                <asp:Label ID="Label3" runat="server" Text="ZFS004"></asp:Label><br />
                <asp:Label ID="Label8" runat="server" Text="ZFS005"></asp:Label><br />
                <asp:Label ID="Label9" runat="server" Text="ZFS006"></asp:Label><br />
                <asp:Label ID="Label10" runat="server" Text="ZFS007"></asp:Label><br />
                <asp:Label ID="Label11" runat="server" Text="ZFS008"></asp:Label><br />
            </th>
            <th>
                <asp:Label ID="lblJ" runat="server" Text="1,000.00"></asp:Label><br />
                <asp:Label ID="Label12" runat="server" Text="1,500.00"></asp:Label><br />
                -<br />
                -<br />
                -<br />
                -<br />
                -<br />
                -<br />

            </th>
            <th>-<br />
                -<br />
                -<br />
                -<br />
                -<br />
                -<br />
                -<br />
                -<br />
            </th>
            <th>-<br />
                -<br />
                -<br />
                -<br />
                -<br />
                -<br />
                -<br />
                -<br />
            </th>
            <th>-<br />
                -<br />
                -<br />
                -<br />
                -<br />
                -<br />
                -<br />
                -<br />
            </th>
            <th>-<br />
                -<br />
                -<br />
                -<br />
                -<br />
                -<br />
                -<br />
                -<br />
            </th>
            <th>-<br />
                -<br />
                -<br />
                -<br />
                -<br />
                -<br />
                -<br />
                -<br />
            </th>
            <th>-<br />
                -<br />
                -<br />
                -<br />
                -<br />
                -<br />
                -<br />
                -<br />
            </th>
            <th>-<br />
                -<br />
                -<br />
                -<br />
                -<br />
                -<br />
                -<br />
                -<br />
            </th>
            <th>-<br />
                -<br />
                -<br />
                -<br />
                -<br />
                -<br />
                -<br />
                -<br />
            </th>
            <th>-<br />
                -<br />
                -<br />
                -<br />
                -<br />
                -<br />
                -<br />
                -<br />
            </th>
            <th>-<br />
                -<br />
                -<br />
                -<br />
                -<br />
                -<br />
                -<br />
                -<br />
            </th>
            <th>-<br />
                -<br />
                -<br />
                -<br />
                -<br />
                -<br />
                -<br />
                -<br />
            </th>
            <th>
                <asp:Label ID="lbljantotal" runat="server" Text="1,000.00"></asp:Label><br />
                <asp:Label ID="Label13" runat="server" Text="1,500.00"></asp:Label><br />
                -<br />
                -<br />
                -<br />
                -<br />
                -<br />
                -<br />
            </th>
            <%--<th colspan="2"></th>--%>
        </tr>

        <tr>
            <th></th>
            <th></th>
            <th></th>
            <th style="border: 1px; height: 30px">
                <asp:Label ID="lblJan" runat="server" Text="2,500.00"></asp:Label></th>
            <th>-</th>
            <th>-</th>
            <th>-</th>
            <th>-</th>
            <th>-</th>
            <th>-</th>
            <th>-</th>
            <th>-</th>
            <th>-</th>
            <th>-</th>
            <th>-</th>
            <th>
                <asp:Label ID="lbltotal" runat="server" Text="2,500.00"></asp:Label>
            </th>
        </tr>
        <tr>
            <th colspan="2">Prepared By:
            </th>
            <th colspan="14" style="text-align: center">Checked By:
            </th>
        </tr>
        <tr>
            <th colspan="2">Date:
            </th>
            <th colspan="14" style="text-align: center">Date:
            </th>
        </tr>
    </table>


</asp:Content>
