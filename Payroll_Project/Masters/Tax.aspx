<%@ Page Title="" Language="C#" MasterPageFile="~/Master3.Master" AutoEventWireup="true" CodeBehind="Tax.aspx.cs" Inherits="Payroll_Project.Masters.Tax" %>

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
    <div>
        <asp:HiddenField ID="hfId" runat="server" />
        <h4>Tax</h4>
        <div>
            <div class="breadcrumb">
                <div class="breadcrumb-item"><a href="">Masters</a></div>
                <div class="breadcrumb-item">Tax</div>

            </div>
        </div>
    </div>

    <br />

    <div class="row" style="margin-bottom: 15px">

        <%--      <div class="col-md-2">
            <asp:Button ID="btnSearch" runat="server" Text="Search" Height="30px" Width="100px" CausesValidation="false" Style="background: #3F698F; color: white; border-radius: 8px; border: none" OnClick="btnSearch_Click" />
        </div>--%>
        <div class="col-md-6">
            <asp:Button ID="btnSave" CausesValidation="false" runat="server" Text="Save" Height="30px" Width="100px" Style="background: #3F698F; color: white; border-radius: 8px; border: none" OnClick="btnSave_Click" OnClientClick="" />
            <asp:Button ID="btnUpdate" Visible="false" CausesValidation="false" runat="server" Text="Update" Height="30px" Width="100px" Style="background: #3F698F; color: white; border-radius: 8px; border: none" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnRefresh" runat="server" Text="Refresh" Height="30px" Width="100px" CausesValidation="false" Style="background: #3F698F; color: white; border-radius: 8px; border: none" OnClick="btnRefresh_Click" />
            <asp:Button ID="btnList" runat="server" Text="Search List" Height="30px" Width="100px" CausesValidation="false" Style="background: #3F698F; color: white; border-radius: 8px; border: none" OnClick="btnList_Click" />
            <%--<asp:Button ID="btnUpdate" runat="server" Text="Update"  Height="30px" Width="100px"   Style="background: #3F698F; color: white; border-radius: 8px; border: none" OnClick="btnUpdate_Click"  />
            --%>
            <asp:LinkButton ID="lnkPaymentDues" runat="server" Visible="false">Payments Dues</asp:LinkButton>
        </div>
    </div>

    <hr style="height: 2px; border-width: 0; background-color: black">

    <div class="row">
        <div class="col-md-2">
            <asp:Label ID="lblTaxCode" runat="server" Text="Tax Code"></asp:Label>
        </div>
        <div class="col-md-2">
            <asp:TextBox ID="txtTaxCode" runat="server" CssClass="form-control" Height="30px"></asp:TextBox>
        </div>
    </div>

    <div class="row">
        <div class="col-md-2">
            <asp:Label ID="lblLowerRange" runat="server" Text="Lower Range"></asp:Label>
        </div>
        <div class="col-md-2">
            <asp:TextBox ID="txtLowerRange" runat="server" onkeypress="return isNumberKey(event)" CssClass="form-control" Height="30px"></asp:TextBox>
        </div>
    </div>

    <div class="row">
        <div class="col-md-2">
            <asp:Label ID="lblUpperRange" runat="server" Text="Upper Range"></asp:Label>
        </div>
        <div class="col-md-2">
            <asp:TextBox ID="txtUpperRange" runat="server" onkeypress="return isNumberKey(event)" CssClass="form-control" Height="30px"></asp:TextBox>
        </div>
    </div>

    <div class="row">
        <div class="col-md-2">
            <asp:Label ID="lblFixedAmount" runat="server" Text="Fixed Amount"></asp:Label>
        </div>
        <div class="col-md-2">
            <asp:TextBox ID="txtFixedAmount" runat="server" onkeypress="return isNumberKey(event)" CssClass="form-control" Height="30px"></asp:TextBox>
        </div>
    </div>

    <div class="row">
        <div class="col-md-2">
            <asp:Label ID="lblPercentAmount" runat="server" Text="Percentage Amount"></asp:Label>
        </div>
        <div class="col-md-2">
            <asp:TextBox ID="txtPercentAmount" runat="server" onkeypress="return isNumberKey(event)" CssClass="form-control" Height="30px"></asp:TextBox>
        </div>
    </div>

    <div class="row">
        <div class="col-md-2">
            <asp:Label ID="lblTaxCredit" runat="server" Text="txtTaxCredit"></asp:Label>
        </div>
        <div class="col-md-2">
            <asp:TextBox ID="TaxCredit" runat="server" CssClass="form-control" Height="30px"></asp:TextBox>
        </div>
    </div>

    <br />

    <div class="row">
        <asp:GridView ID="grdTax" runat="server" AllowPaging="true" PageSize="10" AutoGenerateColumns="false" Width="50%" OnRowDataBound="grdTax_RowDataBound" OnRowDeleting="grdTax_RowDeleting" OnSelectedIndexChanged="grdTax_SelectedIndexChanged" OnPageIndexChanging="grdTax_PageIndexChanging">
            <Columns>

                <asp:TemplateField HeaderText="TaxId" ItemStyle-HorizontalAlign="Center" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblTaxId" Text='<%# Eval("taxId") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Tax Code" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lbltaxCode" Text='<%# Eval("tax_code") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Lower Range" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblLowerRange" Text='<%# Eval("lower_range") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>


                <asp:TemplateField HeaderText="Upper Range" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblUpperRange" Text='<%# Eval("upper_range") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>


                <asp:TemplateField HeaderText="Percentage" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblPercentage" Text='<%# Eval("percentage_amount") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

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

</asp:Content>
