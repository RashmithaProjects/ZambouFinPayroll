<%@ Page Title="" Language="C#" MasterPageFile="~/Master3.Master" AutoEventWireup="true" CodeBehind="ContributionType.aspx.cs" Inherits="Payroll_Project.Masters.ContributionType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder1" runat="server">

    <h4>Contribution Type</h4>
    <div>
        <div class="breadcrumb">
            <div class="breadcrumb-item"><a href="">Masters</a></div>
            <div class="breadcrumb-item">Contribution Type</div>

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
                <asp:Label ID="lblDescription" runat="server" Text="Description"></asp:Label>
            </div>
            <div class="col-md-2">
                <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>

        <br />

        <div class="row">
            <asp:GridView ID="grdContributionType" runat="server" AllowPaging="true" PageSize="10" AutoGenerateColumns="false" Width="50%" OnPageIndexChanging="grdContributionType_PageIndexChanging" OnRowDataBound="grdContributionType_RowDataBound" OnRowDeleting="grdContributionType_RowDeleting" OnSelectedIndexChanged="grdContributionType_SelectedIndexChanged">
                <Columns>

                    <asp:TemplateField HeaderText="Sno" ItemStyle-HorizontalAlign="Center" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblSno" Text='<%# Eval("Sno") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="type" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lbltype" Text='<%# Eval("type") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Description" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblDescription" Text='<%# Eval("Description") %>' runat="server"></asp:Label>
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


    </div>

</asp:Content>
