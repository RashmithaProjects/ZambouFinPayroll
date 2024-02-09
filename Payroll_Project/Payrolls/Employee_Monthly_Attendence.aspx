<%@ Page Title="" Language="C#" MasterPageFile="~/Master3.Master" AutoEventWireup="true" CodeBehind="Employee_Monthly_Attendence.aspx.cs" Inherits="Payroll_Project.Payrolls.Employee_Monthly_Attendence" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder1" runat="server">


    <script type="text/javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true; F
        }
    </script>
    <div class="container">

        <div>
            <h4>Monthly Attendence Record</h4>
            <div>
                <div class="breadcrumb">
                    <div class="breadcrumb-item"><a href="">Masters</a></div>
                    <div class="breadcrumb-item">Monthly Attendence Record</div>

                </div>
            </div>
        </div>

        <br />
        <br />



        <div class="row" style="margin-bottom: 15px">
            <div class="col-md-2">
                <asp:Label ID="lblSearch" runat="server" Text="Month"></asp:Label>
            </div>
            <div class="col-md-2">
                <asp:TextBox ID="txtSearch" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="col-md-2">
                <asp:Button ID="btnSearch" runat="server" Text="Search" Height="30px" Width="100px" CausesValidation="false" Style="background: #3F698F; color: white; border-radius: 8px; border: none" OnClick="btnSearch_Click" />
            </div>
            <div class="col-md-6">
                <asp:Button ID="btnSave" CausesValidation="false" runat="server" Text="Save" Height="30px" Width="100px" Style="background: #3F698F; color: white; border-radius: 8px; border: none" OnClick="btnSave_Click" />
                <asp:Button ID="btnRefresh" runat="server" Text="Refresh" Height="30px" Width="100px" CausesValidation="false" Style="background: #3F698F; color: white; border-radius: 8px; border: none" OnClick="btnRefresh_Click" />
                <asp:Button ID="btnList" runat="server" Text="Search List" Height="30px" Width="100px" CausesValidation="false" Style="background: #3F698F; color: white; border-radius: 8px; border: none" OnClick="btnList_Click" />
                <asp:LinkButton ID="lnkPaymentDues" runat="server" Visible="false">Payments Dues</asp:LinkButton>
            </div>
        </div>

        <hr />

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
        </div>

        <div class="row">
            <div class="col-md-2">
                <asp:Label ID="lblcompanylocation" runat="server" Text="Company Location" Width="500px"></asp:Label>
            </div>
            <div class="col-lg-2">
                <asp:DropDownList ID="ddlcompanylocation" runat="server" Enabled="false" CssClass="form-select txtbox">
                    <asp:ListItem Value="0">Select</asp:ListItem>
                    <asp:ListItem Value="Zambia" Selected="true">Zambia</asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="col-md-2">
                <asp:Label ID="lblWorkLocation" runat="server" Text="Work Location"></asp:Label>
            </div>
            <div class="col-md-2">
                <asp:DropDownList ID="ddlworklocation" runat="server" CssClass="form-select txtbox" AutoPostBack="True">
                    <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>

        <div class="row">
            <div class="col-md-2">
                <asp:Label ID="lblCompanyworkingdays" runat="server" Text="Company Working Days" Width="500px"></asp:Label>
            </div>
            <div class="col-md-2">
                <asp:TextBox ID="txtCompanyWokringDays" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>
        </div>

        <br />
        <br />

        <div class="row">
            <div class="col-md-10">
                <asp:GridView ID="grdMonthlyAttendence" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="10"
                    class="table table-sm table-striped table-bordered table-responsive table-hover" CssClass="display table"
                    EmptyDataText="No records Found."
                    Width="100%" Font-Size="Smaller" OnRowDataBound="grdMonthlyAttendence_RowDataBound">
                    <Columns>

                        <asp:TemplateField HeaderText="Reference No" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblReferenceId" Text='<%# Eval("ReferenceId") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="employee_no" HeaderText="Employee No" />
                        <asp:BoundField DataField="first_name" HeaderText="First Name" />
                        <%--                <asp:BoundField DataField="middle_name" HeaderText="Middle Name" />
                    <asp:BoundField DataField="Location1" HeaderText="Company Location" />--%>
                        <asp:BoundField DataField="last_name" HeaderText="Last Name" />

                        <asp:TemplateField HeaderText="Present Days" HeaderStyle-Width="150px" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:TextBox ID="txtPresentDays" AutoPostBack="true" onkeypress="return isNumberKey(event)" runat="server" Style="text-align: right; width: 50px" OnTextChanged="txtPresentDays_TextChanged" CssClass="form-control"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="Work Days" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblWorkDays" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <%--   <asp:TemplateField HeaderText="Leave Days" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblLeaveDays" Text='<%# Eval("no_of_days") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>

                        <asp:TemplateField HeaderText="Absent Days" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblAbsentDays" Text="0" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Comments" HeaderStyle-Width="150px" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <%--<asp:TextBox ID="txtComments" Text='<%# Eval("amount") %>' runat="server" Style="text-align: right; width: 100px" OnTextChanged="txtAllowanceAmount_TextChanged" onkeypress="return isNumberKey(event)" AutoPostBack="true"></asp:TextBox>--%>
                                <asp:TextBox ID="txtComments" runat="server" Style="text-align: right; width: 100px" CssClass="form-control"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>



                    </Columns>

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



                    <PagerSettings Mode="NumericFirstLast" PageButtonCount="4" FirstPageText="First" LastPageText="Last" />
                </asp:GridView>

            </div>
        </div>

        <div class="row">
            <div class="col-md-10">
                <asp:GridView ID="grdDetails" AllowPaging="true" PageSize="10" runat="server" AutoGenerateColumns="false" Visible="false"
                    class="table table-sm table-striped table-bordered table-responsive table-hover" CssClass="display table"
                    EmptyDataText="No records Found."
                    Width="100%" Font-Size="Smaller" OnSelectedIndexChanged="grdDetails_SelectedIndexChanged" OnPageIndexChanging="grdDetails_PageIndexChanging">
                    <Columns>

                        <%-- <asp:TemplateField HeaderText="Reference No" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblReferenceId" Text='<%# Eval("ReferenceId") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>



                        <%-- <asp:BoundField DataField="sno" HeaderText="Sno" />--%>

                        <asp:TemplateField HeaderText="Month">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkMonth" Text='<%# Eval("att_month") %>' runat="server" CommandName="Select"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>



                        <asp:BoundField DataField="att_year" HeaderText="Year" />
                        <%--                        <asp:BoundField DataField="att_month" HeaderText="Month" />--%>
                        <asp:BoundField DataField="working_location" HeaderText="Work Location" />
                        <asp:BoundField DataField="no_of_work_days" HeaderText="No of Working Days" />

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
            <div class="col-md-10">
                <asp:GridView ID="grdMonthlyAttendenceReport" AllowPaging="true" PageSize="10" runat="server" AutoGenerateColumns="false" Width="100%" Visible="false" OnPageIndexChanging="grdMonthlyAttendenceReport_PageIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="emp_no" HeaderText="Emp No" />
                        <asp:BoundField DataField="emp_name" HeaderText="Emp Name" />
                        <%--                         <asp:BoundField DataField="emp_position" HeaderText="Position" />--%>
                        <asp:BoundField DataField="present_days" HeaderText="Present Days" />
                        <%--                        <asp:BoundField DataField="employee_no" HeaderText="Work Days" />--%>
                        <asp:BoundField DataField="absent_days" HeaderText="Absent Days" />
                        <asp:BoundField DataField="comments" HeaderText="Comments" />
                    </Columns>
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


</asp:Content>
