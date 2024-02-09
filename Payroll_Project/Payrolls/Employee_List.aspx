<%@ Page Title="" Language="C#" MasterPageFile="~/Master3.Master" AutoEventWireup="true" CodeBehind="Employee_List.aspx.cs" Inherits="Payroll_Project.Payrolls.Employee_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-md-11">
        </div>
        <div class="col-md-1">

            <asp:LinkButton ID="lnkbutton" runat="server" OnClick="lnkbutton_Click">Back</asp:LinkButton>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">

            <asp:GridView ID="grdEmployees" runat="server"  AutoGenerateColumns="false" class="table table-sm table-striped table-bordered table-responsive table-hover" CssClass="display table"
                DataKeyNames="employee_no"
                AllowPaging="true" PageSize="10" EmptyDataText="No records Found." OnSorting="grdEmployees_Sorting" AllowSorting="True"
                Width="100%" Font-Size="Smaller" OnPageIndexChanging="grdEmployees_PageIndexChanging" OnRowDataBound="grdEmployees_RowDataBound">
                <Columns>

                    <asp:TemplateField HeaderText="Reference No" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblReferenceId" Text='<%# Eval("ReferenceId") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Employee No">
                        <ItemTemplate>
                            <asp:HyperLink ID="htpId" runat="server"
                                NavigateUrl='<%# "Employee_Creation.aspx?ReferenceId="+ DataBinder.Eval(Container.DataItem,"ReferenceId")%>'
                                Target="_self" Text='<%# DataBinder.Eval(Container.DataItem,"employee_no") %>'></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="first_name" HeaderText="Employee Name" />
                    <asp:BoundField DataField="middle_name" HeaderText="Middle Name" />
                    <asp:BoundField DataField="last_name" HeaderText="Last Name" />

                    <asp:TemplateField HeaderText="Employeed On" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblCreateedOn" Text='<%# Eval("employed_on")%>' runat="server"></asp:Label>
                            <%--<asp:Label ID="Label6" Text='<%# Eval("Date",  "{0:dd/MM/yyyy}")%>' runat="server"></asp:Label>--%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <%--                    <asp:BoundField DataField="employed_on" HeaderText="Employeed On" />--%>
                    <asp:BoundField DataField="martial_status" HeaderText="Martial Status" />
                    <asp:BoundField DataField="basic_pay" HeaderText="Basic Pay" />
                    <%--                    <asp:BoundField DataField="payroll_month" HeaderText="Payroll Month" />--%>
                    <asp:BoundField DataField="Location1" HeaderText="Company Location" />
                    <%--<asp:BoundField DataField="work_location" HeaderText="Work Location" />--%>
                    <asp:BoundField DataField="shift_type" HeaderText="Shift Type" />
                    <asp:BoundField DataField="address" HeaderText="Address" />
                    <%--                    <asp:BoundField DataField="Createdon" HeaderText="Created On"   DataFormatString="{0:dd/MM/yyyy}" />--%>
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
