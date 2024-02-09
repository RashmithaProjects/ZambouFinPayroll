<%@ Page Title="" Language="C#" MasterPageFile="~/Master3.Master" AutoEventWireup="true" CodeBehind="AccessRights.aspx.cs" Inherits="Payroll_Project.Securities.AccessRights" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder1" runat="server">

    <script type="text/javascript" language="javascript">
        $(document).ready(function () {
            $('#<%=grdAccessRights.ClientID %>').Scrollable();
        }
        )
    </script>

    <div class="row">
        <div class="col-md-6">
            <asp:Button ID="btnSave" runat="server" Text="Save" Height="30px" Width="100px" Style="background: #3F698F; color: white; border-radius: 8px; border: none" OnClick="btnSave_Click" OnClientClick="" />
            <asp:Button ID="btnUpdate" Visible="false" CausesValidation="false" runat="server" Text="Update" Height="30px" Width="100px" Style="background: #3F698F; color: white; border-radius: 8px; border: none" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnRefresh" Visible="false" runat="server" Text="Refresh" Height="30px" Width="100px" CausesValidation="false" Style="background: #3F698F; color: white; border-radius: 8px; border: none" OnClick="btnRefresh_Click" />
            <asp:Button ID="btnList" Visible="false" runat="server" Text="Search List" Height="30px" Width="100px" CausesValidation="false" Style="background: #3F698F; color: white; border-radius: 8px; border: none" OnClick="btnList_Click" />
        </div>
    </div>

    <hr style="height: 2px; border-width: 0; background-color: black">


    <div class="row">
        <div class="col-md-2">
            <asp:Label ID="lblUsers" runat="server" Text="User"></asp:Label>
        </div>
        <div class="col-md-2">
            <asp:DropDownList ID="ddlUsers" AutoPostBack="true" runat="server" CssClass="form-select txtbox" OnSelectedIndexChanged="ddlUsers_SelectedIndexChanged">
                <asp:ListItem Value="0">Select</asp:ListItem>
            </asp:DropDownList>
        </div>

        <div class="col-md-2">
            <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
        </div>
        <div class="col-md-2">
            <asp:TextBox ID="txtName" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="col-md-2">
            <asp:Label ID="lblRole" runat="server" Text="Role"></asp:Label>
        </div>
        <div class="col-md-2">
            <asp:TextBox ID="txtRole" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
        </div>
    </div>

    <br />
    <div class="row" style="height: 400px; overflow: auto">
        <div class="col-md-12">
            <asp:GridView ID="grdAccessRights" runat="server" CellPadding="6" ForeColor="#333333" Width="800px" GridLines="Horizontal" AutoGenerateColumns="False" Font-Size="Small" HeaderStyle-CssClass="FixedHeader">
                <Columns>
                    <asp:TemplateField HeaderText="MenuId" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblMenuId" Text='<%# Eval("MenuId") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Parent MenuId" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblParentMenuId" Text='<%# Eval("ParentMenuId") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="ParentMenu" HeaderText="Parent Menu" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="200px"></asp:BoundField>
                    <asp:BoundField DataField="Title" HeaderText="Form Name" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="200px"></asp:BoundField>

                    <asp:TemplateField HeaderText="Access Right" HeaderStyle-Font-Size="small" ItemStyle-Height="25px">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkAccesRights" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" />
                <%--        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />--%>
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
