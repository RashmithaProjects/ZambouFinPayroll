<%@ Page Title="" Language="C#" MasterPageFile="~/Master3.Master" AutoEventWireup="true" CodeBehind="Payroll_Approved.aspx.cs" Inherits="Payroll_Project.Payrolls.Payroll_Approved" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder1" runat="server">

     <script type="text/javascript">
        function CheckBoxCheck(ob) {

            var gridvalue = ob.parentNode.parentNode.parentNode;
            var inputs = gridvalue.getElementsByTagName("input");

            for (var i = 0; i < inputs.length; i++) {
                if (inputs[i].type == "checkbox") {
                    if (ob.checked && inputs[i] != ob && inputs[i].checked) {
                        inputs[i].checked = false;
                    }
                }
            }
        }
    </script>

    <div>
        <h4>Payroll Approval</h4>
        <div>
            <div class="breadcrumb">
                <div class="breadcrumb-item"><a href="">Payroll</a></div>
                <div class="breadcrumb-item">Payroll Approval</div>

            </div>
        </div>
    </div>

    <br />


    <div class="row">
        <div class="col-md-6">
            <asp:Button ID="btnSave" CausesValidation="false" runat="server" Text="Submit" Height="30px" Width="100px" Style="background: #3F698F; color: white; border-radius: 8px; border: none" OnClick="btnSave_Click" OnClientClick="" />
            <asp:Button ID="btnRefresh" runat="server" Text="Refresh" Height="30px" Width="100px" CausesValidation="false" Style="background: #3F698F; color: white; border-radius: 8px; border: none" OnClick="btnRefresh_Click" />
        </div>
    </div>

      <hr style="height: 2px; border-width: 0; background-color: black">

    <div class="row">
        <div class="col-md-10">
            <asp:GridView ID="grdPayrollApproved" AllowPaging="true" PageSize="10" runat="server" AutoGenerateColumns="false"
                class="table table-sm table-striped table-bordered table-responsive table-hover" CssClass="display table"
                EmptyDataText="No records Found."
                Width="100%" Font-Size="Smaller" OnPageIndexChanging="grdPayrollApproved_PageIndexChanging" OnSelectedIndexChanged="grdPayrollApproved_SelectedIndexChanged" OnRowDataBound="grdPayrollApproved_RowDataBound">
                <Columns>

                    <%-- <asp:TemplateField HeaderText="Reference No" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblReferenceId" Text='<%# Eval("ReferenceId") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>



                    <%-- <asp:BoundField DataField="sno" HeaderText="Sno" />--%>

                    <%--                    <asp:TemplateField HeaderText="Sno">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkSno" Text='<%# Eval("Sno") %>' runat="server" CommandName="Select"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
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

                    <asp:TemplateField HeaderText="CreateedOn" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblCreateedOn" Text='<%# Eval("CreateedOn") %>' runat="server" CssClass="AlgRght"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Payroll Sheet">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="lnk_View" ForeColor="Blue" Font-Size="Small" Width="100px" Text="View" CommandName="Select" CommandArgument='<%# Eval("Sno") %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Approve">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkApproved" runat="server" Width="40px" AutoPostBack="true" onclick="CheckBoxCheck(this);"></asp:CheckBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Reject">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkReject" runat="server" Width="40px" AutoPostBack="true" onclick="CheckBoxCheck(this);"></asp:CheckBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Remarks">
                        <ItemTemplate>
                            <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine">
                            </asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>


                </Columns>
                <PagerSettings Mode="NumericFirstLast" PageButtonCount="4" FirstPageText="First" LastPageText="Last" />

                 <AlternatingRowStyle BackColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White"/>
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
