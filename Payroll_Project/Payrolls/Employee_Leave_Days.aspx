<%@ Page Title="" Language="C#" MasterPageFile="~/Master3.Master" AutoEventWireup="true" CodeBehind="Employee_Leave_Days.aspx.cs" Inherits="Payroll_Project.Masters.Employee_Leave_Days" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

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



    <h4>Employee Leave Days</h4>
    <asp:HiddenField ID="hfReferenceId" runat="server" />
    <div>
        <div class="breadcrumb">
            <div class="breadcrumb-item"><a href="">Payroll</a></div>
            <div class="breadcrumb-item">Leave Days</div>

        </div>
    </div>

    <div class="containter">
        <div class="row">
            <asp:HiddenField ID="hfId" runat="server" />
            <div class="col-md-6">
                <asp:Button ID="btnSave" runat="server" Text="Save" Height="30px" Width="100px" Style="background: #3F698F; color: white; border-radius: 8px; border: none" OnClick="btnSave_Click" OnClientClick="" />
                <asp:Button ID="btnRefresh" runat="server" Text="Refresh" Height="30px" Width="100px" CausesValidation="false" Style="background: #3F698F; color: white; border-radius: 8px; border: none" OnClick="btnRefresh_Click" />
                <asp:Button ID="btnUpdate" Visible="false" runat="server" Text="Update" Height="30px" Width="100px" CausesValidation="false" Style="background: #3F698F; color: white; border-radius: 8px; border: none" OnClick="btnUpdate_Click" />
                <asp:Button ID="btnList" runat="server" Text="Search List" Height="30px" Width="100px" CausesValidation="false" Style="background: #3F698F; color: white; border-radius: 8px; border: none" OnClick="btnList_Click" />

            </div>
        </div>

        <hr style="height: 2px; border-width: 0; background-color: black">

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
                <asp:Label ID="Label2" runat="server" Text="Work Location"></asp:Label>
            </div>
            <div class="col-md-2">
                <asp:DropDownList ID="ddlworklocation" runat="server" CssClass="form-select txtbox" AutoPostBack="True" TabIndex="13">
                    <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="reqw" runat="server" ControlToValidate="ddlworklocation" InitialValue="Select" ErrorMessage="*"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="row">
            <div class="col-md-2">
                <asp:Label ID="lblEmployeeNo" runat="server" Text="Employee No" Width="500px"></asp:Label>
            </div>
            <div class="col-lg-2">
                <asp:DropDownList ID="ddlEmployeNo" runat="server" CssClass="form-select txtbox"
                    AutoPostBack="True" OnSelectedIndexChanged="ddlEmployeNo_SelectedIndexChanged">
                    <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-md-2">
                <asp:Label ID="lblEmpName" runat="server" Text="Employee Name"></asp:Label>
            </div>
            <div class="col-md-2">
                <asp:TextBox ID="txtEmployeeName" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>
        </div>


        <div class="row">
            <div class="col-md-2">
                <asp:Label ID="lblLeaveName" runat="server" Text="Leave Name" Width="500px"></asp:Label>
            </div>
            <div class="col-lg-2">
                <asp:DropDownList ID="ddlLeaveName" AutoPostBack="true" runat="server" CssClass="form-select txtbox"
                    OnSelectedIndexChanged="ddlLeaveName_SelectedIndexChanged">
                    <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-md-2">
                <asp:Label ID="lblEmployeeOn" runat="server" Text="Employee On"></asp:Label>
            </div>
            <div class="col-md-2">
                <asp:TextBox ID="txtEmployeeOn" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:CalendarExtender ID="calEmployeeOn" runat="server" TargetControlID="txtEmployeeOn"></asp:CalendarExtender>
            </div>
        </div>


        <div class="row">
            <div class="col-md-2">
                <asp:Label ID="lblNoofDays" runat="server" Text="No.of Days" Width="500px"></asp:Label>
            </div>
            <div class="col-lg-2">
                <asp:TextBox ID="txtNoofDays" runat="server" Enabled="false" onkeypress="return isNumberKey(event)" CssClass="form-control"></asp:TextBox>

            </div>
            <div class="col-md-2" runat="server" visible="false">
                <asp:Label ID="lblBalancedNoofDays" runat="server" Text="Balanced No of Days"></asp:Label>
            </div>
            <div class="col-md-2" runat="server" visible="false">
                <asp:TextBox ID="txtBalancedNoofDays" runat="server" onkeypress="return isNumberKey(event)" CssClass="form-control"></asp:TextBox>
            </div>
        </div>

        <div class="row" runat="server" visible="false">
            <div class="col-md-2">
                <asp:Label ID="lblTotalNoofDays" runat="server" Text="Total No.of Days" Width="500px"></asp:Label>
            </div>
            <div class="col-lg-2">
                <asp:TextBox ID="txtTotalNoofDays" Enabled="false" onkeypress="return isNumberKey(event)" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>

        <br />

        <div class="row">
            <asp:GridView ID="grdEmployeeLeaves" AllowPaging="true" PageSize="10" runat="server" AutoGenerateColumns="false" Width="80%" OnRowDataBound="grdEmployeeLeaves_RowDataBound" OnRowDeleting="grdEmployeeLeaves_RowDeleting" OnSelectedIndexChanged="grdEmployeeLeaves_SelectedIndexChanged">
                <Columns>

                    <asp:TemplateField HeaderText="sno" ItemStyle-HorizontalAlign="Center" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblsno" Text='<%# Eval("sno") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Reference Id" ItemStyle-HorizontalAlign="Center" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblReferenceId" Text='<%# Eval("ReferenceId") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="leave Id" ItemStyle-HorizontalAlign="Center" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblleaveId" Text='<%# Eval("leave_Id") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Work Location" ItemStyle-HorizontalAlign="Center" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblWorkLocation" Text='<%# Eval("work_location") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Employee No" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblEmpNo" Text='<%# Eval("emp_no") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Employee Name" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblEmpName" Text='<%# Eval("emp_name") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Leave Name" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblleavename" Text='<%# Eval("leave_name") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Employee On" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblEmpOn" Text='<%# Eval("employee_on")  %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="No of Days" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblNoofDays" Text='<%# Eval("no_of_days") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <%--<asp:TemplateField HeaderText="Balance Days" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblBaldays" Text='<%# Eval("bal_days") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>

                    <%--<asp:TemplateField HeaderText="Total Days" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblTotaldays" Text='<%# Eval("tot_days") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>

                    <asp:ButtonField Text="Edit" CommandName="Select" />
                    <asp:CommandField ShowDeleteButton="True" Visible="false" />


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



</asp:Content>
