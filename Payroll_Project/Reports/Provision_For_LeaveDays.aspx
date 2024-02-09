<%@ Page Title="" Language="C#" MasterPageFile="~/Master3.Master" AutoEventWireup="true" CodeBehind="Provision_For_LeaveDays.aspx.cs" Inherits="Payroll_Project.Reports.Provision_For_LeaveDays" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder1" runat="server">

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
            <asp:Label ID="lblHeading" runat="server" Text="PROVISION FOR LEAVE DAYS - " Font-Bold="true"></asp:Label>
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

                    <asp:TemplateField HeaderText="Leave Days">
                        <ItemTemplate>
                            <asp:Label ID="lblLeaveDays" Text='<%# Eval("LeaveDays") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Basic Pay">
                        <ItemTemplate>
                            <asp:Label ID="lblBasicPay" Text='<%# Eval("BasicPay") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lblTotalBasicPay" runat="server" Font-Bold="true" />
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="VALUEE(ZMW)">
                        <ItemTemplate>
                            <asp:Label ID="lblJanuary" Text='<%# Eval("ZMW") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lblTotalZMW" runat="server" Font-Bold="true" />
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


</asp:Content>
