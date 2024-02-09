<%@ Page Title="" Language="C#" MasterPageFile="~/Master3.Master" AutoEventWireup="true" CodeBehind="Department.aspx.cs" Inherits="Payroll_Project.Masters.Department" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder1" runat="server">


    <h4>Department</h4>
    <div>
        <div class="breadcrumb">
            <div class="breadcrumb-item"><a href="">Masters</a></div>
            <div class="breadcrumb-item">Department</div>
        </div>
    </div>

    <asp:HiddenField ID="hfId" runat="server" />
    <br />

    <div class="col-md-6">
        <asp:Button ID="btnSave" CausesValidation="false" runat="server" Text="Save" Height="30px" Width="100px" Style="background: #3F698F; color: white; border-radius: 8px; border: none" OnClick="btnSave_Click" OnClientClick="" />
        <asp:Button ID="btnUpdate" Visible="false" CausesValidation="false" runat="server" Text="Update" Height="30px" Width="100px" Style="background: #3F698F; color: white; border-radius: 8px; border: none" OnClick="btnUpdate_Click" />
        <asp:Button ID="btnRefresh" runat="server" Text="Refresh" Height="30px" Width="100px" CausesValidation="false" Style="background: #3F698F; color: white; border-radius: 8px; border: none" OnClick="btnRefresh_Click" />
        <asp:Button ID="btnList" runat="server" Text="Search List" Height="30px" Width="100px" CausesValidation="false" Style="background: #3F698F; color: white; border-radius: 8px; border: none" OnClick="btnList_Click" />
    </div>

    <hr style="height: 2px; border-width: 0; background-color: black">

    <div class="row">
        <div class="col-md-2">
            <asp:Label ID="lblDepartmentCode" runat="server" Text="Department Code"></asp:Label>
        </div>
        <div class="col-md-2">
            <asp:TextBox ID="txtDepartmentCode" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>

    <div class="row">
        <div class="col-md-2">
            <asp:Label ID="lblDepartmentName" runat="server" Text="Department Name"></asp:Label>
        </div>
        <div class="col-md-2">
            <asp:TextBox ID="txtDepartment" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>

    <br />

    <div class="row">
        <asp:GridView ID="grdDepartment" runat="server" AllowPaging="true" PageSize="10" AutoGenerateColumns="false" Width="50%" OnPageIndexChanging="grdDepartment_PageIndexChanging" OnRowCancelingEdit="grdDepartment_RowCancelingEdit" OnRowDataBound="grdDepartment_RowDataBound" OnRowDeleting="grdDepartment_RowDeleting" OnRowEditing="grdDepartment_RowEditing" OnRowUpdating="grdDepartment_RowUpdating" OnSelectedIndexChanged="grdDepartment_SelectedIndexChanged">
            <Columns>

                <asp:TemplateField HeaderText="DeptId" ItemStyle-HorizontalAlign="Center" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblDeptId" Text='<%# Eval("DeptId") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Department Code" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lbldept_code" Text='<%# Eval("dept_code") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtDepartmentcode" runat="server" Text='<%# Eval("dept_code") %>' Width="140" class="form-control"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Department Name" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lbldept_name" Text='<%# Eval("dept_name") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtDepartmentName" runat="server" Text='<%# Eval("dept_name") %>' Width="140" class="form-control"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

                <%--                <asp:CommandField ButtonType="Image" CancelImageUrl="../Assets/img/exits.png" EditImageUrl="../Assets/img/edit.png" ItemStyle-Width="24"
                    ShowEditButton="True" UpdateImageUrl="../Assets/img/updated.png" />
                <asp:CommandField ButtonType="Image" DeleteImageUrl="../Assets/img/Delete.png" ShowDeleteButton="True" ItemStyle-Width="24" />--%>

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
