<%@ Page Title="" Language="C#" MasterPageFile="~/Master3.Master" AutoEventWireup="true" CodeBehind="AllowanceType.aspx.cs" Inherits="Payroll_Project.Masters.AllowanceType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder1" runat="server">

     <h4>Allowance Type</h4>
    <div>
        <div class="breadcrumb">
            <div class="breadcrumb-item"><a href="">Masters</a></div>
            <div class="breadcrumb-item">Allowance Type</div>

        </div>
    </div>

    <div class="containter">
        <div class="row">
          <div class="col-md-2">
            <asp:Button ID="btnSave" runat="server" Text="Save" Height="30px" Width="100px" Style="background: #3F698F; color: white; border-radius: 8px; border: none" OnClick="btnSave_Click" OnClientClick="" />
            </div>
        </div>

        <div class="row">
            <div class="col-md-2">
                 <asp:Label ID="lblName" runat="server"  Text="Name"></asp:Label>
            </div>
            <div class="col-md-2">
                <asp:TextBox ID="txtName" runat="server"  CssClass = "form-control"></asp:TextBox>
                
            </div>
        </div>

        <br />

         <div class="row">
            <div class="col-md-2">
                 <asp:Label ID="lblDescription" runat="server"  Text="Description"></asp:Label>
            </div>
            <div class="col-md-2">
                <asp:TextBox ID="txtDescription" runat="server"  CssClass = "form-control"></asp:TextBox>
            </div>
        </div>



    </div>



</asp:Content>
