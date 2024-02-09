<%@ Page Title="" Language="C#" MasterPageFile="~/Master3.Master" AutoEventWireup="true" CodeBehind="Payroll_Generation.aspx.cs" Inherits="Payroll_Project.Payrolls.Payroll_Generation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode != 46 && charCode > 31
                && (charCode < 48 || charCode > 57))
                return false;
            return true;

        }


    </script>


    <h4>Monthly Payroll</h4>
    <div>
        <div class="breadcrumb">
            <div class="breadcrumb-item"><a href="">Payroll</a></div>
            <div class="breadcrumb-item">Monthly Payroll</div>

        </div>
    </div>


    <br />
    <br />
    <div class="row">
        <div class="col-md-10"></div>
        <div class="col-md-2">
            <asp:LinkButton ID="lnkViewHistory" runat="server" OnClick="lnkViewHistory_Click">View History</asp:LinkButton>
        </div>
    </div>

    <div class="container">
        <div class="row">
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
            <div class="col-md-2">
                <asp:Label ID="lblDaysinMonth" runat="server" Text="Days in Month"></asp:Label>
            </div>
            <div class="col-md-2">
                <asp:TextBox ID="txtCompanyWokringDays" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>
        </div>

        <br />

        <div class="row">
            <div class="col-md-6">
                <asp:Button ID="btnSubmit" CausesValidation="false" runat="server" Text="Submit for Approval" Height="30px" Width="150px" Style="background: #3F698F; color: white; border-radius: 8px; border: none" OnClientClick="" OnClick="btnSubmit_Click" />
                <%--  <asp:Button ID="btnPrint" CausesValidation="false" runat="server" Text="Print" Height="30px" Width="100px" Style="background: #3F698F; color: white; border-radius: 8px; border: none" OnClick="btnPrint_Click"   />--%>
                <asp:Button ID="btnRefresh" runat="server" Text="Refresh" Height="30px" Width="100px" CausesValidation="false" Style="background: #3F698F; color: white; border-radius: 8px; border: none" OnClick="btnRefresh_Click" />
                <%--<asp:Button ID="btnUpdate" runat="server" Text="Update"  Height="30px" Width="100px"   Style="background: #3F698F; color: white; border-radius: 8px; border: none" OnClick="btnUpdate_Click"  />
                --%>
                <asp:LinkButton ID="lnkPaymentDues" runat="server" Visible="false">Payments Dues</asp:LinkButton>
            </div>
        </div>
        <hr style="height: 2px; border-width: 0; background-color: black">

        <div class="row">
            <div class="col-sm-12">
                <asp:GridView ID="grdPayrollTotalSummary" runat="server" Width="100%">
                </asp:GridView>
            </div>
        </div>

        <br />

        <div class="row">
            <div class="col-md-12">
                <asp:GridView ID="grdPayrollGeneration" AllowPaging="true" PageSize="10" runat="server" AutoGenerateColumns="false"
                    class="table table-sm table-striped table-bordered table-responsive table-hover" CssClass="display table"
                    EmptyDataText="No records Found." ShowFooter="true"
                    Width="100%" Font-Size="Smaller" OnRowDataBound="grdPayrollGeneration_RowDataBound">
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

                        <asp:BoundField DataField="FirstName" HeaderText="Employee Name" />

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
                                <asp:TextBox ID="txtSalesAndMarketingCommision" onkeypress="return isNumberKey(event)" Text='<%# Eval("SalesAndMarketingCommision") %>' OnTextChanged="txtSalesAndMarketingCommision_TextChanged" AutoPostBack="true" runat="server" Style="text-align: right; width: 50px" CssClass="form-control"></asp:TextBox>
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

                        <asp:TemplateField HeaderText="Present Days" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblPresentDays" runat="server" Text='<%# Eval("present_days") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

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

                        <asp:TemplateField HeaderText="NAPSA Employee" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblNAPSA" runat="server" Text='<%# Eval("NAPSA") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblTotalNAPSA" runat="server" Font-Bold="true" />
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="NAPSARange" ItemStyle-HorizontalAlign="Center" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblNAPSARange" runat="server" Text='<%# Eval("NapsaRange") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblTotalNAPSARange" runat="server" Font-Bold="true" />
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
                                <asp:TextBox ID="txtSalaryAdvancedRepayment" onkeypress="return isNumberKey(event)" Text='<%# Eval("SalaryAdvancedRepayment") %>' OnTextChanged="txtSalaryAdvancedRepayment_TextChanged" AutoPostBack="true" runat="server" Style="text-align: right; width: 50px" CssClass="form-control"></asp:TextBox>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblTotalSalaryAdvanceRepayment" runat="server" Font-Bold="true" />
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Zambo Loan Repayment" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:TextBox ID="txtZamboLoanRepayment" onkeypress="return isNumberKey(event)" Text='<%# Eval("ZamboLoanRepayment") %>' OnTextChanged="txtZamboLoanRepayment_TextChanged" AutoPostBack="true" runat="server" Style="text-align: right; width: 50px" CssClass="form-control"></asp:TextBox>
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
        </div>

    </div>

    <div class="row">
        <div class="col-md-10">
            <p>Payroll Submitted History</p>
        </div>
    </div>

    <div class="row">
        <div class="col-md-10">
            <asp:GridView ID="grdPayrollApproved" AllowPaging="true" PageSize="10" runat="server" AutoGenerateColumns="false"
                class="table table-sm table-striped table-bordered table-responsive table-hover" CssClass="display table"
                EmptyDataText="No records Found."
                Width="100%" Font-Size="Smaller" OnPageIndexChanging="grdPayrollApproved_PageIndexChanging" OnRowDataBound="grdPayrollApproved_RowDataBound" OnSelectedIndexChanged="grdPayrollApproved_SelectedIndexChanged">
                <Columns>

                    <asp:TemplateField HeaderText="Year" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblYear" Text='<%# Eval("Year") %>' runat="server" CssClass="AlgRght"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Month" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblMonth" Text='<%# Eval("Month") %>' runat="server" CssClass="AlgRght"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Submitted On" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblCreateedOn" Text='<%# Eval("CreateedOn") %>' runat="server" CssClass="AlgRght"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="Approval Status" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblStatus" Text='<%# Eval("Status") %>' runat="server" CssClass="AlgRght"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Remarks" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblRemarks" Text='<%# Eval("Remarks") %>' runat="server" CssClass="AlgRght"></asp:Label>
                        </ItemTemplate>
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

    <div class="row">
        <div class="col-md-12">
            <asp:Panel ID="panelmsg" runat="server" BorderStyle="Groove" Style="z-index: 0; left: 450px; position: absolute; top: 320px; border-radius: 15px; height: 100px; width: 500px;"
                Visible="False" BackColor="WhiteSmoke">
                <asp:Label ID="lblsuccmsg" runat="server"></asp:Label>

                <asp:Label ID="lblconfirmation" runat="server" Text="Do you want this payroll to Submit for Approval"></asp:Label>
                <br />
                <br />
                <div class="row">
                    <div class="col-md-4"></div>
                    <div class="col-md-6">
                        <asp:Button ID="btnyes" runat="server" CssClass="btn  btn-primary" Text="Yes" OnClick="btnyes_Click" />
                        <asp:Button ID="btnno" runat="server" CssClass="btn  btn-danger" Text="No" OnClick="btnno_Click" />

                    </div>
                </div>


            </asp:Panel>
        </div>
    </div>


</asp:Content>
