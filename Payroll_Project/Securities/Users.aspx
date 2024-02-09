<%@ Page Title="" Language="C#" MasterPageFile="~/Master3.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="Payroll_Project.Securities.Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder1" runat="server">

    <script type="text/javascript">

</script>
    <h4>Users</h4>
    <div>
        <div class="breadcrumb">
            <div class="breadcrumb-item"><a href="">Masters</a></div>
            <div class="breadcrumb-item">Users</div>

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
                <asp:Label ID="lblUserCode" runat="server" Text="User Id"></asp:Label>
            </div>
            <div class="col-md-2">
                <asp:TextBox ID="txtUserCode" runat="server" CssClass="form-control"></asp:TextBox>
            </div>


            <div class="col-md-2">
                <asp:Label ID="lblUserName" runat="server" Text="User Name"></asp:Label>
            </div>
            <div class="col-md-2">
                <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>

        <br />


        <div class="row" runat ="server" id="divPassword">
            <div class="col-md-2">
                <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
            </div>
            <div class="col-md-2">
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="col-md-2">
                <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password"></asp:Label>
            </div>
            <div class="col-md-2">
                <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>

        <br />
        <div class="row">
            <div class="col-md-2">
                <asp:Label ID="lblRoles" runat="server" Text="Role" Width="500px"></asp:Label>
            </div>
            <div class="col-md-2">
                <asp:DropDownList ID="ddlRoles" runat="server" CssClass="form-select txtbox">
                    <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList>

            </div>
        </div>

        <div class="row" runat="server" visible="false">
            <div class="col-md-2">
                <asp:Label ID="lblDescription" runat="server" Text="Description"></asp:Label>
            </div>
            <div class="col-md-2">
                <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
    </div>

    <br />

    <div class="row">
        <asp:GridView ID="grdUsers" runat="server" AutoGenerateColumns="false" Width="50%" OnSelectedIndexChanged="grdUsers_SelectedIndexChanged" OnRowDeleting="grdUsers_RowDeleting" OnRowDataBound="grdUsers_RowDataBound" OnPageIndexChanging="grdUsers_PageIndexChanging">
            <Columns>

                <asp:TemplateField HeaderText="User Code" ItemStyle-HorizontalAlign="Center" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblUserId" Text='<%# Eval("UserId") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="User Id" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblUserCode" Text='<%# Eval("user_code") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="User Name" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblUserName" Text='<%# Eval("UserName") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="RoleName" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblRoleName" Text='<%# Eval("RoleName") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:ButtonField Text="Edit" CommandName="Select"   />
                <asp:CommandField ShowDeleteButton="True" Visible="false" />

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
