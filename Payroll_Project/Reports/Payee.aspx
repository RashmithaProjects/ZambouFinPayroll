<%@ Page Title="" Language="C#" MasterPageFile="~/Master3.Master" AutoEventWireup="true" CodeBehind="Payee.aspx.cs" Inherits="Payroll_Project.Reports.Payee" %>
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
        <div class="col-md-6">
            <asp:Label ID="lblHeading" runat="server" Text="PAYE REPORT - " Font-Bold="true" ></asp:Label>
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
                    <asp:TemplateField HeaderText="TPin">
                        <ItemTemplate>
                            <asp:Label ID="lblTPin" Text='<%# Eval("Tpin") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Employee Name">
                        <ItemTemplate>
                            <asp:Label ID="lblFullName" Text='<%# Eval("FullName") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="EmploymentNature">
                        <ItemTemplate>
                            <asp:Label ID="lblEmploymentNature" Text='<%# Eval("EmploymentNature") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                       <asp:TemplateField HeaderText="GrossEmoluments">
                        <ItemTemplate>
                            <asp:Label ID="lblGrossEmoluments" Text='<%# Eval("GrossEmoluments") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="ChargeableEmoluments">
                        <ItemTemplate>
                            <asp:Label ID="lblChargeableEmoluments" Text='<%# Eval("ChargeableEmoluments") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                       <asp:TemplateField HeaderText="TotalTaxCredit">
                        <ItemTemplate>
                            <asp:Label ID="lblTotalTaxCredit" Text='<%# Eval("TotalTaxCredit") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="TaxDeducted">
                        <ItemTemplate>
                            <asp:Label ID="lblTaxDeducted" Text='<%# Eval("TaxDeducted") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                       <asp:TemplateField HeaderText="TaxAdjusted">
                        <ItemTemplate>
                            <asp:Label ID="lblTaxAdjusted" Text='<%# Eval("TaxAdjusted") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>


                
                <%--    <asp:TemplateField HeaderText="Total">
                        <ItemTemplate>
                            <asp:Label ID="lblTotal" Text='<%# Eval("Total") %>' Font-Bold="true" runat="server"></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lblTotal" runat="server" Font-Bold="true" />
                        </FooterTemplate>
                    </asp:TemplateField>--%>



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
