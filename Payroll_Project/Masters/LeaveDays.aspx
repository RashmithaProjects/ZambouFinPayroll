<%@ Page Title="" Language="C#" MasterPageFile="~/Master3.Master" AutoEventWireup="true" CodeBehind="LeaveDays.aspx.cs" Inherits="Payroll_Project.Masters.LeaveDays" %>

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
    <h4>Leave Days</h4>
    <div>
        <div class="breadcrumb">
            <div class="breadcrumb-item"><a href="">Masters</a></div>
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
                <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
            </div>
            <div class="col-md-2">
                <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>

        <br />

        <div class="row">
            <div class="col-md-2">
                <asp:Label ID="lblNoofDays" runat="server" Text="No. of Days"></asp:Label>
            </div>
            <div class="col-md-2">
                <asp:TextBox ID="txtNoofDays" runat="server" onkeypress="return isNumberKey(event)" CssClass="form-control"></asp:TextBox>
            </div>
        </div>

        <br />

        <div class="row">
            <asp:GridView ID="grdLeaves" runat="server" AllowPaging="true" PageSize="10"  AutoGenerateColumns="false" Width="50%" OnSelectedIndexChanged="grdLeaves_SelectedIndexChanged" OnRowDeleting="grdLeaves_RowDeleting" OnRowDataBound="grdLeaves_RowDataBound" OnPageIndexChanging="grdLeaves_PageIndexChanging">
                <Columns>

                    <asp:TemplateField HeaderText="LeaveId" ItemStyle-HorizontalAlign="Center" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblLeaveId" Text='<%# Eval("LeaveId") %>' runat="server" ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Leave Name" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblLeaveName" Text='<%# Eval("Leave_name") %>' runat="server" ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="No of Days" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblNoofDays" Text='<%# Eval("no_days") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:ButtonField Text="Edit" CommandName="Select"/>
                    <asp:CommandField  ShowDeleteButton="True" Visible="false" />

                  <%--  <asp:TemplateField HeaderText="Delete" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkDelete" runat="server" CausesValidation="False"
                             Text="Delete"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>--%>

                </Columns>

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
