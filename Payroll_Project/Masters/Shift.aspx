<%@ Page Title="" Language="C#" MasterPageFile="~/Master3.Master" AutoEventWireup="true" CodeBehind="Shift.aspx.cs" Inherits="Payroll_Project.Masters.Shift" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder1" runat="server">
    <h4>Shift Type</h4>
    <div>
        <div class="breadcrumb">
            <div class="breadcrumb-item"><a href="">Masters</a></div>
            <div class="breadcrumb-item">Shift Type</div>
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
            <asp:Label ID="lblShiftType" runat="server" Text="Shift Type"></asp:Label>
        </div>
        <div class="col-md-2">
            <asp:DropDownList ID="ddlshifttype" runat="server" CssClass="form-select">
                <asp:ListItem>select</asp:ListItem>
                <asp:ListItem>Shift-A</asp:ListItem>
                <asp:ListItem>Shift-B</asp:ListItem>
                <asp:ListItem>Shift-C</asp:ListItem>
                <asp:ListItem>General</asp:ListItem>
                <asp:ListItem></asp:ListItem>
            </asp:DropDownList>
        </div>

        <div class="col-md-2">
            <asp:Label ID="lblShiftName" runat="server" Text="Shift Name"></asp:Label>
        </div>
        <div class="col-md-2">
            <asp:TextBox ID="txtShiftName" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>

    <div class="row">
        <div class="col-md-2">
            <asp:Label ID="lblTimings" runat="server" Text="Timings"></asp:Label>
        </div>
        <div class="col-md-1">
            <asp:TextBox ID="txtFrom" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-1">
            <asp:Label ID="lblTo" runat="server" Text="To"></asp:Label>
        </div>

        <div class="col-md-1">
            <asp:TextBox ID="txtTo" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>

    <br />

    <div class="row">
        <asp:GridView ID="grdShift" runat="server" AllowPaging="true" PageSize="10" AutoGenerateColumns="false" Width="50%" OnPageIndexChanging="grdShift_PageIndexChanging" OnRowDataBound="grdShift_RowDataBound" OnRowDeleting="grdShift_RowDeleting" OnSelectedIndexChanged="grdShift_SelectedIndexChanged">
            <Columns>

                <asp:TemplateField HeaderText="SiftId" ItemStyle-HorizontalAlign="Center" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblSiftId" Text='<%# Eval("SiftId") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Shift Type" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblshifttype" Text='<%# Eval("shift_type") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Shift Name" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblshiftname" Text='<%# Eval("shift_name") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>


                <asp:TemplateField HeaderText="From Time" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblFromTime" Text='<%# Eval("timing1") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>


                <asp:TemplateField HeaderText="To Time" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblToTime" Text='<%# Eval("timing2") %>' runat="server"></asp:Label>
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
