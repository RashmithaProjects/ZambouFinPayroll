<%@ Page Title="" Language="C#" MasterPageFile="~/Master3.Master" AutoEventWireup="true" CodeBehind="WorkingLocation.aspx.cs" Inherits="Payroll_Project.Masters.WorkingLocation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder1" runat="server">

    <h4>Working Location</h4>
    <div>
        <div class="breadcrumb">
            <div class="breadcrumb-item"><a href="">Masters</a></div>
            <div class="breadcrumb-item">Working Location</div>
        </div>
    </div>

    <br />

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
            <asp:Label ID="lblWorkingLocation" runat="server" Text="Working Location"></asp:Label>
        </div>
        <div class="col-md-2">
            <asp:TextBox ID="txtWorkingLocation" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>

    <div class="row">
        <div class="col-md-2">
            <asp:Label ID="lblCompanyLocation" runat="server" Text="Company Location"></asp:Label>
        </div>
        <div class="col-md-2">
            <asp:DropDownList ID="ddlCompanyLocation" runat="server" CssClass="form-select txtbox" Font-Size="Smaller">
                <asp:ListItem Value="0" Text="Select" />
                <asp:ListItem Value="Zambia" Text="Zambia" />
            </asp:DropDownList>
        </div>
    </div>

    <div class="row">
        <asp:GridView ID="grdWorkLocation" runat="server" AutoGenerateColumns="false" Width="50%" OnRowDataBound="grdWorkLocation_RowDataBound" OnRowDeleting="grdWorkLocation_RowDeleting" OnRowEditing="grdWorkLocation_RowEditing" OnSelectedIndexChanged="grdWorkLocation_SelectedIndexChanged" OnPageIndexChanging="grdWorkLocation_PageIndexChanging">
            <Columns>

                <asp:TemplateField HeaderText="Work Location Id" ItemStyle-HorizontalAlign="Center" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblWorkLocationId" Text='<%# Eval("sno") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Work Location" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblWorkLocation" Text='<%# Eval("working_location") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Company Location" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblCompanyLocation" Text='<%# Eval("com_location") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:ButtonField Text="Edit" CommandName="Select" />
                <asp:CommandField ShowDeleteButton="true" Visible="false" />

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
