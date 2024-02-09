<%@ Page Title="" Language="C#" MasterPageFile="~/Master3.Master" AutoEventWireup="true" CodeBehind="Contribution_Details.aspx.cs" Inherits="Payroll_Project.Masters.Contribution_Details" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

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

    <h4>Contribution Details</h4>
    <div>
        <div class="breadcrumb">
            <div class="breadcrumb-item"><a href="">Masters</a></div>
            <div class="breadcrumb-item">Contribution Details</div>

        </div>
    </div>


    <div class="container">
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
            <div class="col-md-3">
                <asp:Label ID="lblDate" runat="server" Text="Date"></asp:Label>
            </div>
            <div class="col-md-2">
                <asp:TextBox ID="txtDate" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:CalendarExtender ID="calDate" runat="server" TargetControlID="txtDate"></asp:CalendarExtender>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
                <asp:Label ID="lblContributionType" runat="server" Text="Contribution"></asp:Label>
            </div>
            <div class="col-md-2">
                <asp:DropDownList ID="ddlContributionType" runat="server" CssClass="form-select">
                    <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="col-md-4">
                <asp:Label ID="Label5" runat="server" Text="Employer Contribution Required"></asp:Label>
            </div>
            <div class="col-md-2">
                <asp:DropDownList ID="ddlContributionRequired" runat="server" AutoPostBack="true" CssClass="form-select" OnSelectedIndexChanged="ddlContributionRequired_SelectedIndexChanged">
                    <asp:ListItem Value="0">Select</asp:ListItem>
                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                    <asp:ListItem Value="No">No</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>

        <div class="row" runat="server" visible="false">
            <div class="col-md-3">
                <asp:Label ID="lblDescription" runat="server" Text="Description"></asp:Label>
            </div>

            <div class="col-md-2">
                <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

        </div>

        <div class="row">
            <div class="col-md-3">
                <asp:Label ID="lblEmployeeContribution" runat="server" Text="Employee Contribution"></asp:Label>
            </div>
            <div class="col-md-1">
                <asp:TextBox ID="txtEmpeeContrPercent" runat="server" onkeypress="return isNumberKey(event)" CssClass="form-control" Width="65px"></asp:TextBox>
            </div>
            <div class="col-md-1">
                <asp:Label ID="Label1" runat="server" Text="%"></asp:Label>
            </div>
            <%--  <div class="col-md-2"  runat ="server" visible="false">
                 <asp:textbox id="txtEmpeeContrAmount" runat="server"  cssclass = "form-control"></asp:textbox>
            </div>--%>
        </div>


        <div class="row">
            <div class="col-md-3">
                <asp:Label ID="lblEmployerContribution" runat="server" Text="Employer Contribution"></asp:Label>
            </div>
            <div class="col-md-1">
                <asp:TextBox ID="txtEmprContrPercent" runat="server" onkeypress="return isNumberKey(event)" CssClass="form-control" Width="65px"></asp:TextBox>
            </div>

            <div class="col-md-1">
                <asp:Label ID="Label2" runat="server" Font-Names="Verdana" Font-Size="Small" Text="%"></asp:Label>

            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
                <asp:Label ID="Label3" runat="server" Text="Ceiling Amount"></asp:Label>
            </div>
            <div class="col-md-2">
                <asp:TextBox ID="txtCeilingAmount" runat="server" onkeypress="return isNumberKey(event)" CssClass="form-control"></asp:TextBox>
            </div>
        </div>


        <div class="row">
            <div class="col-md-3">
                <asp:Label ID="Label4" runat="server" Text="Applicable On"></asp:Label>
            </div>
            <div class="col-md-2">
                <asp:DropDownList ID="ddlApplicableon" runat="server" CssClass="form-select">
                    <asp:ListItem Value="0" Text="Select" />
                    <%--   <asp:ListItem Value="BasicPay" Text="Basic Pay" />
                    <asp:ListItem Value="GrossPay" Text="Gross Pay" />--%>
                </asp:DropDownList>
            </div>
        </div>

        <br />

        <div class="row">
            <asp:GridView ID="grdContributionDetails" runat="server" AllowPaging="true" PageSize="10" AutoGenerateColumns="false" Width="80%" OnRowDataBound="grdContributionDetails_RowDataBound" OnRowDeleting="grdContributionDetails_RowDeleting" OnSelectedIndexChanged="grdContributionDetails_SelectedIndexChanged">
                <Columns>

                    <asp:TemplateField HeaderText="Contribution Id" ItemStyle-HorizontalAlign="Center" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblContributionId" Text='<%# Eval("Sno") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <%--<asp:TemplateField HeaderText="Reference Id" ItemStyle-HorizontalAlign="Center" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblReferenceId" Text='<%# Eval("ReferenceId") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>




                    <asp:TemplateField HeaderText="Date" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblEmpDate" Text='<%# Eval("Date")%>' runat="server"></asp:Label>
                            <%--<asp:Label ID="Label6" Text='<%# Eval("Date",  "{0:dd/MM/yyyy}")%>' runat="server"></asp:Label>--%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Contribution Type" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblContributionType" Text='<%# Eval("ContributionType") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <%--                    <asp:TemplateField HeaderText="Description" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblDescription" Text='<%# Eval("Description") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>

                    <asp:TemplateField HeaderText="Employee Percentage" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblEmployeePercentage" Text='<%# Eval("Employee_Percentage") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Employer Percentage" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblEmployerPercentage" Text='<%# Eval("Employer_Percentage") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Ceiling Amount" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblCeilingAmount" Text='<%# Eval("Ceiling_Amount") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Applicable On" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblApplicableOn" Text='<%# Eval("ApplicableOn") %>' runat="server"></asp:Label>
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

    </div>


</asp:Content>
