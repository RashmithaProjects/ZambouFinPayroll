<%@ Page Title="" Language="C#" MasterPageFile="~/Master3.Master" AutoEventWireup="true" CodeBehind="Position.aspx.cs" Inherits="Payroll_Project.Masters.Position" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder1" runat="server">


    <h4>Position</h4>
    <div>
        <div class="breadcrumb">
            <div class="breadcrumb-item"><a href="">Masters</a></div>
            <div class="breadcrumb-item">Position</div>
        </div>
    </div>

    <br />

    <div class="col-md-6">
        <asp:HiddenField ID="hfId" runat="server" />
        <asp:Button ID="btnSave" CausesValidation="false" runat="server" Text="Save" Height="30px" Width="100px" Style="background: #3F698F; color: white; border-radius: 8px; border: none" OnClick="btnSave_Click" OnClientClick="" />
        <asp:Button ID="btnUpdate" Visible="false" CausesValidation="false" runat="server" Text="Update" Height="30px" Width="100px" Style="background: #3F698F; color: white; border-radius: 8px; border: none" OnClick="btnUpdate_Click" />
        <asp:Button ID="btnRefresh" runat="server" Text="Refresh" Height="30px" Width="100px" CausesValidation="false" Style="background: #3F698F; color: white; border-radius: 8px; border: none" OnClick="btnRefresh_Click" />
        <asp:Button ID="btnList" runat="server" Text="Search List" Height="30px" Width="100px" CausesValidation="false" Style="background: #3F698F; color: white; border-radius: 8px; border: none" OnClick="btnList_Click" />
    </div>


    <hr style="height: 2px; border-width: 0; background-color: black">
    <div class="row">
        <div class="col-md-2">
            <asp:Label ID="lblPositionCode" runat="server" Text="Position Code"></asp:Label>
        </div>
        <div class="col-md-2">
            <asp:TextBox ID="txtPositionCode" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>

    <div class="row">
        <div class="col-md-2">
            <asp:Label ID="lblPositionName" runat="server" Text="Position Name"></asp:Label>
        </div>
        <div class="col-md-2">
            <asp:TextBox ID="txtPosition" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>


    <div class="row">
        <asp:GridView ID="grdPosition" runat="server" AllowPaging="true" PageSize="10" AutoGenerateColumns="false" Width="50%" OnPageIndexChanging="grdPosition_PageIndexChanging" OnRowDataBound="grdPosition_RowDataBound" OnRowDeleting="grdPosition_RowDeleting" OnSelectedIndexChanged="grdPosition_SelectedIndexChanged">
            <Columns>

                <asp:TemplateField HeaderText="PositionId" ItemStyle-HorizontalAlign="Center" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblPositionId" Text='<%# Eval("PositionId") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Position Code" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblPositionCode" Text='<%# Eval("PositionCode") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Position Name" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblPositionName" Text='<%# Eval("PositionName") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:ButtonField Text="Edit" CommandName="Select" />
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
