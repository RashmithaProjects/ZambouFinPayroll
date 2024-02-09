<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Payroll_Summary.aspx.cs" Inherits="Payroll_Project.Payrolls.Payroll_Summary" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="row">
                <div class="col-md-3" style="margin-top: 13px">
                    <asp:Label ID="labelz" runat="server" Text="Zambou Financial Services" Font-Size="X-Large" ForeColor="#336699" Font-Bold="true"></asp:Label>
                </div>
            </div>

            <br />

            <div class="row">
                <div class="col-md-6">
                    <input type="button" id="btnPrint" onclick="window.print()" value="Print" style="height: 30px; width: 100px; background: #3F698F; color: white; border-radius: 8px; border: none" />
                    <%--    <asp:Button ID="btnprint" CausesValidation="false" runat="server" Text="Print" Height="30px" Width="100px" Style="background: #3F698F; color: white; border-radius: 8px; border: none" OnClientClick="" />--%>
                    <asp:Button ID="btnClose" runat="server" Text="Close" Height="30px" Width="100px" CausesValidation="false" Style="background: #3F698F; color: white; border-radius: 8px; border: none" OnClick="btnClose_Click" />
                </div>
            </div>

            <br />

            <div class="row">
                <div class="col-sm-12">
                    <asp:GridView ID="grdPayrollSummary" runat="server" Width="100%">
                    </asp:GridView>
                </div>
            </div>

            <br />
            <br />

            <asp:GridView ID="grdPayrollGeneration" AllowPaging="true" PageSize="10" runat="server" AutoGenerateColumns="false"
                class="table table-sm table-striped table-bordered table-responsive table-hover" CssClass="display table"
                EmptyDataText="No records Found."
                Width="100%" Font-Size="Smaller" ShowFooter="true">
                <Columns>

                    <asp:TemplateField HeaderText="Reference No" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblReferenceId" Text='<%# Eval("ReferenceId") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Employee No">
                        <ItemTemplate>
                            <asp:Label ID="lblEmpNo" Text='<%# Eval("employee_no") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <%--                       <asp:TemplateField HeaderText="Employee Name">
                            <ItemTemplate>
                                <asp:Label ID="lblEmployeName" Text='<%# Eval("FirstName") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    --%>

                    <asp:BoundField DataField="EmployeeName" HeaderText="Employee Name" />

                    <asp:TemplateField HeaderText="BasicPay" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblBasicPay" runat="server" Text='<%# Eval("BasicPay") %>'></asp:Label>
                        </ItemTemplate>

                        <FooterTemplate>
                            <asp:Label ID="lblTotalBasicPay" runat="server" Font-Bold="true" />
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="House Allowance" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblHouseAllowance" runat="server" Text='<%# Eval("HouseAllowance") %>'></asp:Label>
                        </ItemTemplate>

                        <FooterTemplate>
                            <asp:Label ID="lblTotalHouseAllowance" runat="server" Font-Bold="true" />
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Lunch Allowance" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblLunchAllowance" runat="server" Text='<%# Eval("LunchAllowance") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lblTotalLunchAllowance" runat="server" Font-Bold="true" />
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Transport Allowance" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblTransportAllowance" runat="server" Text='<%# Eval("TransportAllowance") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lblTotalTransportAllowance" runat="server" Font-Bold="true" />
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Responsibility Allowance" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblResponsibilityAllowance" runat="server" Text='<%# Eval("ResponsibilityAllowance") %>'></asp:Label>
                        </ItemTemplate>

                        <FooterTemplate>
                            <asp:Label ID="lblTotalResponsibilityAllowance" runat="server" Font-Bold="true" />
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Total Allowance" ItemStyle-HorizontalAlign="Center" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblTotalAllowance" runat="server" Text='<%# Eval("TotalAllowance") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="Sales And Marketing Commision" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblSalesAndMarketingCommission" Text='<%# Eval("SalesAndMarketingCommision") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lblTotalSalesAndMarketingCommission" runat="server" Font-Bold="true" />
                        </FooterTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="GrossPay" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblGrossPay" runat="server" Text='<%# Eval("GrossPay") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lblTotalGrossPay" runat="server" Font-Bold="true" />
                        </FooterTemplate>
                    </asp:TemplateField>

                    <%-- <asp:TemplateField HeaderText="Present Days" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblPresentDays" runat="server" Text='<%# Eval("present_days") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="GrossPay Rate" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblGrossPayRate" runat="server" Text='<%# Eval("GrossPayRate") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lblTotalGrossPayRate" runat="server" Font-Bold="true" />
                        </FooterTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="Actual GrossPay" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblActualGrossPay" runat="server" Text='<%# Eval("ActualGrossPay") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lblTotalActualGrossPay" runat="server" Font-Bold="true" />
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="NAPSA" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblNAPSA" runat="server" Text='<%# Eval("NAPSA") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lblTotalNAPSA" runat="server" Font-Bold="true" />
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="NHIMA" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblNHIMA" runat="server" Text='<%# Eval("NHIMA") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lblTotalNHIMA" runat="server" Font-Bold="true" />
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Paye" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblPaye" runat="server" Text='<%# Eval("Paye") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lblTotalPaye" runat="server" Font-Bold="true" />
                        </FooterTemplate>
                    </asp:TemplateField>





                    <asp:TemplateField HeaderText="Salary Advanced Repayment" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblSalaryAdvancedRepayment" Text='<%# Eval("SalaryAdvancedRepayment") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lblTotalSalaryAdvanceRepayment" runat="server" Font-Bold="true" />
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Zambo Loan Repayment" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblZamboLoanRepayment" Text='<%# Eval("ZamboLoanRepayment") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lblTotalZamboLoanRepayment" runat="server" Font-Bold="true" />
                        </FooterTemplate>
                    </asp:TemplateField>

                    <%--<asp:BoundField DataField="" HeaderText="Salary Advanced Repayment" />
                        <asp:BoundField DataField="" HeaderText="Zambo Loan Repayment" />--%>

                    <asp:TemplateField HeaderText="NetPay" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblNetPay" runat="server" Text='<%# Eval("NetPay") %>'></asp:Label>
                        </ItemTemplate>

                        <FooterTemplate>
                            <asp:Label ID="lblTotalNetPay" runat="server" Font-Bold="true" />
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Account no" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblAccountNo" runat="server" Text='<%# Eval("AccountNo") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Gratuity" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblGratuity" runat="server" Text='<%# Eval("Gratuity") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lblTotalGratuity" runat="server" Font-Bold="true" />
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="NAPSA Company Contribution" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblNapsaCom" runat="server" Text='<%# Eval("NapsaCom") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lblTotalNapsaCom" runat="server" Font-Bold="true" />
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="CTC" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblCTC" runat="server" Text='<%# Eval("CTC") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lblTotalCTC" runat="server" Font-Bold="true" />
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
    </form>
</body>

</html>
