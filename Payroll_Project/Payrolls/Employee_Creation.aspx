<%@ Page Title="" Language="C#" MasterPageFile="~/Master3.Master" AutoEventWireup="true" CodeBehind="Employee_Creation.aspx.cs" Inherits="Payroll_Project.Payrolls.Employee_Creation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder1" runat="server">

    <script type="text/javascript">
        function isNumberKey(evt) {
            //var charCode = (evt.which) ? evt.which : evt.keyCode;
            //if (charCode > 31 && (charCode < 48 || charCode > 57))
            //    return false;
            //return true; F

            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode != 46 && charCode > 31
                && (charCode < 48 || charCode > 57))
                return false;
            return true;

        }

        function ShowImagePreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=image.ClientID%>').prop('src', e.target.result)
                        .width(150)
                        .height(150);
                };
                reader.readAsDataURL(input.files[0]);
            }
        }

        function ShowSignaturePreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=imgSignature.ClientID%>').prop('src', e.target.result)
                        .width(150)
                        .height(150);
                };
                reader.readAsDataURL(input.files[0]);
            }
        }

        function ValidateAllowances() {
            //Reference the GridView.
            var grid = document.getElementById("<%=grdAllowances.ClientID %>");

            //Reference all INPUT elements.
            var inputs = grid.getElementsByTagName("INPUT");

            //Set the Validation Flag to True.
            var isValid = true;
            for (var i = 0; i < inputs.length; i++) {
                //If TextBox.
                if (inputs[i].type == "text") {
                    //Reference the Error Label.
                    var label = inputs[i].parentNode.getElementsByTagName("SPAN")[0];

                    //If Blank, display Error Label.
                    if (inputs[i].value == "") {
                        alert("Please enter Allowances");
                        isValid = false;
                    } else {
                        label.style.display = "none";
                    }
                }
            }

            return isValid;
        }


        function openCity(evt, cityName) {
            var i, tabcontent, tablinks;
            tabcontent = document.getElementsByClassName("tabcontent");
            for (i = 0; i < tabcontent.length; i++) {
                tabcontent[i].style.display = "none";
            }
            tablinks = document.getElementsByClassName("tablinks");
            for (i = 0; i < tablinks.length; i++) {
                tablinks[i].className = tablinks[i].className.replace(" active", "");
            }
            document.getElementById(cityName).style.display = "block";
            evt.currentTarget.className += " active";
        }
    </script>

    <style type="text/css">
        .txtbox {
            height: 30px;
            /*width:120px;*/
        }


        .labelgap {
            width: 50px;
        }

        .pagetitles {
            margin-bottom: 10px;
        }

            .pagetitles h1 {
                font-size: 24px;
                margin-bottom: 0;
                font-weight: 600;
                color: #012970;
                background-color: #012970;
                width: 100%;
            }

        .tab {
            overflow: hidden;
            border: 1px solid #ccc;
            background-color: #f1f1f1;
        }

        /* Style the buttons inside the tab */
        .tabbutton {
            background-color: inherit;
            float: left;
            border: none;
            outline: none;
            cursor: pointer;
            padding: 14px 16px;
            transition: 0.3s;
            font-size: 20px;
            width: 100%;
        }

        /* Change background color of buttons on hover */
        .tab button:hover {
            background-color: #ddd;
        }

        /* Create an active/current tablink class */
        .tab button.active {
            background-color: #ccc;
        }

        /* Style the tab content */
        .tabcontent {
            display: none;
            padding: 6px 12px;
            border: 1px solid #ccc;
            border-top: none;
        }
    </style>
    <%--    <div class="row">
        <div class="col-md-12">
            <asp:Label ID="lblHeadig" runat="server" Font-Bold="True" Font-Italic="False" Font-Names="Verdana"
                Font-Size="Large" ForeColor="Black" Text="Employee Details" Width="184px"></asp:Label>
        </div>
    </div>--%>

    <div>
        <asp:HiddenField ID="hfRefId" runat="server" />
        <h4>Employee Details</h4>
        <div>
            <div class="breadcrumb">
                <div class="breadcrumb-item"><a href="">Payroll</a></div>
                <div class="breadcrumb-item">Employee Details</div>

            </div>
        </div>
    </div>

    <br />
    <br />


    <div class="row" style="margin-bottom: 15px">
        <div class="col-md-2">
            <asp:Label ID="labelc" runat="server" Text="Employee No"></asp:Label>
        </div>
        <div class="col-md-2">
            <asp:TextBox ID="txtSearch" runat="server" class="form-control"></asp:TextBox>
        </div>
        <div class="col-md-2">
            <asp:Button ID="btnSearch" runat="server" Text="Search" Height="30px" Width="100px" CausesValidation="false" Style="background: #3F698F; color: white; border-radius: 8px; border: none" OnClick="btnSearch_Click" />
        </div>
        <div class="col-md-6">
            <asp:Button ID="btnSave" CausesValidation="false" runat="server" Text="Save" Height="30px" Width="100px" Style="background: #3F698F; color: white; border-radius: 8px; border: none" OnClick="btnSave_Click" OnClientClick="" />
            <asp:Button ID="btnUpdate" Visible="false" CausesValidation="false" runat="server" Text="Update" Height="30px" Width="100px" Style="background: #3F698F; color: white; border-radius: 8px; border: none" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnPrint"   Visible="false"  CausesValidation="false" runat="server" Text="Print" Height="30px" Width="100px" Style="background: #3F698F; color: white; border-radius: 8px; border: none" OnClick="btnPrint_Click"/>
            <asp:Button ID="btnRefresh" runat="server" Text="Refresh" Height="30px" Width="100px" CausesValidation="false" Style="background: #3F698F; color: white; border-radius: 8px; border: none" OnClick="btnRefresh_Click" />
            <asp:Button ID="btnList" runat="server" Text="Search List" Height="30px" Width="100px" CausesValidation="false" Style="background: #3F698F; color: white; border-radius: 8px; border: none" OnClick="btnList_Click" />
            <%--<asp:Button ID="btnUpdate" runat="server" Text="Update"  Height="30px" Width="100px"   Style="background: #3F698F; color: white; border-radius: 8px; border: none" OnClick="btnUpdate_Click"  />
            --%>
            <asp:LinkButton ID="lnkPaymentDues" runat="server" Visible="false">Payments Dues</asp:LinkButton>
        </div>
    </div>

    <hr style="height: 2px; border-width: 0; background-color: black">

    <div>
        <div class="row tab">
            <div class="col-sm-3">
                <asp:Button ID="btnpersonaldetails" runat="server" Text="Personal details" CssClass="tabbutton" CausesValidation="false" OnClick="btnpersonaldetails_click" />
                <%--<span class="bi bi-key-fill input-group-text" ></span>--%>
            </div>
        </div>

        <div class="row" id="divPersonalDetails" runat="server">
            <%--  <div class="col-md-1">
        </div>--%>
            <div class="col-md-12">
                <p>Personal Details</p>
                <div class="row">
                    <div class="col-md-2">
                        <asp:Label ID="LblFirstName" runat="server" Text="FirstName"></asp:Label>
                    </div>
                    <div class="col-md-2">
                        <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" Height="30px"></asp:TextBox>
                    </div>

                    <div class="col-md-2">
                        <asp:Label ID="lblMiddleName" runat="server" Text="MiddleName"></asp:Label>
                    </div>
                    <div class="col-md-2">
                        <asp:TextBox ID="txtMiddleName" runat="server" CssClass="form-control txtbox"></asp:TextBox>
                    </div>

                    <div class="col-md-2">
                        <asp:Label ID="lblLastName" runat="server" Text="LastName" Width="200px"></asp:Label>
                    </div>
                    <div class="col-md-2">
                        <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control txtbox"></asp:TextBox>
                    </div>
                </div>


                <div class="row">
                    <div class="col-md-2">
                        <asp:Label ID="lblEmpNo" runat="server" Text="Emp No"></asp:Label>
                    </div>
                    <div class="col-md-2">
                        <asp:TextBox ID="txtEmpNo" runat="server" CssClass="form-control txtbox"></asp:TextBox>
                    </div>

                    <div class="col-md-2">
                        <asp:Label ID="lblGender" runat="server" Text="Gender"></asp:Label>
                    </div>
                    <div class="col-md-2">
                        <asp:DropDownList ID="ddl_gender" runat="server" CssClass="form-select" Font-Size="Smaller">
                            <asp:ListItem Value="0" Text="Select" />
                            <asp:ListItem Value="1" Text="Male" />
                            <asp:ListItem Value="2" Text="Female" />
                            <asp:ListItem Value="3" Text="Others" />
                        </asp:DropDownList>
                    </div>

                    <div class="col-md-2">
                        <asp:Label ID="LblMaritialStatus" runat="server" Text="Martial Status"></asp:Label>
                    </div>
                    <div class="col-md-2">
                        <asp:DropDownList ID="ddlMaratialStatus" runat="server" CssClass="form-select" Font-Size="Smaller">
                            <asp:ListItem Value="0" Text="Select" />
                            <asp:ListItem Value="1" Text="Single" />
                            <asp:ListItem Value="2" Text="Married" />
                            <asp:ListItem Value="3" Text="Divorced" />
                        </asp:DropDownList>
                    </div>
                </div>


                <div class="row">
                    <div class="col-md-2">
                        <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
                    </div>
                    <div class="col-md-2">
                        <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" Font-Size="Smaller" TextMode="MultiLine"></asp:TextBox>

                    </div>

                    <div class="col-md-2">
                        <asp:Label ID="lblAddress1" runat="server" Text="Address1"></asp:Label>
                    </div>
                    <div class="col-md-2">
                        <asp:TextBox ID="txtAddress1" runat="server" CssClass="form-control" Font-Size="Smaller" TextMode="MultiLine"></asp:TextBox>
                    </div>

                    <div class="col-md-2">
                        <asp:Label ID="lblcompanylocation" runat="server" Text="Company Location" Width="500px"></asp:Label>
                    </div>
                    <div class="col-md-2">
                        <asp:DropDownList ID="ddlcompanylocation" runat="server" Enabled="false" CssClass="form-select">
                            <asp:ListItem Value="0">Select</asp:ListItem>
                            <asp:ListItem Value="Zambia" Selected="true">Zambia</asp:ListItem>
                        </asp:DropDownList>
                        <%--<asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="ddlcompanylocation" ErrorMessage="select Company Location" OnServerValidate="CustomValidator1_ServerValidate">*</asp:CustomValidator>--%>
                    </div>
                </div>


                <div class="row">
                    <div class="col-md-2">
                        <asp:Label ID="Label2" runat="server" Text="Work Location"></asp:Label>
                    </div>
                    <div class="col-md-2">
                        <asp:DropDownList ID="ddlworklocation" runat="server" CssClass="form-select" AutoPostBack="True" >
                            <asp:ListItem Value="0">Select</asp:ListItem>
                        </asp:DropDownList>
                        
                    </div>

                    <div class="col-md-2">
                        <asp:Label ID="lblDOB" runat="server" Text="DOB"></asp:Label>
                 
                    </div>

                    <div class="col-md-2">
                        <asp:TextBox ID="txtDob" runat="server"
                            CssClass="form-control txtbox" OnTextChanged="txtDob_TextChanged" AutoPostBack="true"></asp:TextBox>
                        <asp:CalendarExtender ID="caldob" runat="server"  TargetControlID="txtDob"></asp:CalendarExtender>
                        <asp:Label ID="lblAge" runat="server" Text="   " Font-Size="Small" ForeColor="#0066ff"></asp:Label>
                    </div>

                    <div class="col-md-2">
                        <asp:Label ID="lblEmpon" runat="server" Text="Employee On"></asp:Label>
       
                    </div>
                    <div class="col-md-2">
                        <asp:TextBox ID="txtEmpon" runat="server" 
                            CssClass="form-control txtbox"></asp:TextBox>
                        <asp:CalendarExtender ID="calempon" runat="server" TargetControlID="txtEmpon"></asp:CalendarExtender>

                    </div>
                </div>

                <div class="row">
                    <div class="col-md-2">
                        <asp:Label ID="lblContractStart" runat="server" Text="Contract Start"></asp:Label>
                    </div>
                    <div class="col-md-2">
                        <asp:TextBox ID="txtContractStart" runat="server"
                            CssClass="form-control txtbox"></asp:TextBox>
                        <asp:CalendarExtender ID="calContractStart" runat="server" TargetControlID="txtContractStart"></asp:CalendarExtender>
                    </div>

                    <div class="col-md-2">
                        <asp:Label ID="lblContractExpired" runat="server" Text="Contract Expired" Width="500px"></asp:Label>
                    </div>
                    <div class="col-md-2">
                        <asp:TextBox ID="txtContractExpired" runat="server" 
                            CssClass="form-control txtbox"></asp:TextBox>
                        <asp:CalendarExtender ID="calcontractexpired" runat="server" TargetControlID="txtContractExpired"></asp:CalendarExtender>

                    </div>

                    <div class="col-md-2">
                        <asp:Label ID="lblContractRenuval" runat="server" Text="Contract Renuval" Width="500px"></asp:Label>
                        
                    </div>
                    <div class="col-md-2">
                        <asp:TextBox ID="txtContractRenuval" runat="server"  CssClass="form-control txtbox"></asp:TextBox>
                        <asp:CalendarExtender ID="calcontractrenuval" runat="server" TargetControlID="txtContractRenuval"></asp:CalendarExtender>
                    </div>
                </div>


                <div class="row">
                    <div class="col-md-2">
                        <asp:Label ID="lblPosition" runat="server" Text="Position"></asp:Label>
                    </div>
                    <div class="col-md-2">
                        <asp:DropDownList ID="ddlPosition" runat="server" CssClass="form-select">
                            <asp:ListItem Value="0">Select</asp:ListItem>
                        </asp:DropDownList>

                    </div>

                    <div class="col-md-2">
                        <asp:Label ID="lblDepartment" runat="server" Text="Department"></asp:Label>
                    </div>
                    <div class="col-md-2">
                        <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="form-select">
                            <asp:ListItem Value="0">Select</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="col-md-2">
                        <asp:Label ID="lblShiftType" runat="server" Text="Shift Type"></asp:Label>
                    </div>
                    <div class="col-md-2">
                        <asp:DropDownList ID="ddlShiftType" runat="server" CssClass="form-select">
                            <asp:ListItem Value="0">Select</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-2">
                        <asp:Label ID="lblbankname" runat="server" Text="Bank Name"></asp:Label>
                    </div>
                    <div class="col-md-2">
                        <asp:TextBox ID="txtBankName" runat="server" CssClass="form-control txtbox"></asp:TextBox>
                    </div>

                    <div class="col-md-2">
                        <asp:Label ID="lblBankBranch" runat="server" Text="Bank Branch"></asp:Label>
                    </div>
                    <div class="col-md-2">
                        <asp:TextBox ID="txtBankBranch" runat="server" CssClass="form-control txtbox"></asp:TextBox>
                    </div>

                    <div class="col-md-2">
                        <asp:Label ID="lblAccoutno" runat="server" Text="Account No" Width="200px"></asp:Label>
                    </div>
                    <div class="col-md-2">
                        <asp:TextBox ID="txtAccountno" runat="server" CssClass="form-control txtbox"></asp:TextBox>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-2">
                        <asp:Label ID="lblPassport" runat="server" Text="Passport"></asp:Label>
                    </div>
                    <div class="col-md-2">
                        <asp:TextBox ID="txtPassport" runat="server" CssClass="form-control txtbox"></asp:TextBox>
                    </div>

                    <div class="col-md-2">
                        <asp:Label ID="lblBasicPay" runat="server" Text="BasicPay"></asp:Label>
                    </div>
                    <div class="col-md-2">

                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtBasicPay" runat="server" CssClass="form-control txtbox" onkeypress="return isNumberKey(event)" AutoPostBack="true" OnTextChanged="txtBasicPay_TextChanged"></asp:TextBox>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="txtBasicPay" EventName="TextChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                    <div class="col-md-2">
                        <asp:Label ID="lblChildrend" runat="server" Text="Children"></asp:Label>
                    </div>
                    <div class="col-md-2">
                        <asp:TextBox ID="txtChildren" runat="server" CssClass="form-control txtbox"></asp:TextBox>
                    </div>
                </div>


                <div class="row">
                    <div class="col-md-2">
                        <asp:Label ID="lblSpouse" runat="server" Text="Spouse"></asp:Label>
                    </div>
                    <div class="col-md-2">
                        <asp:TextBox ID="txtSpouse" runat="server" CssClass="form-control txtbox"></asp:TextBox>
                    </div>

                    <div class="col-md-2">
                        <asp:Label ID="lblStatus" runat="server" Text="Status"></asp:Label>
                    </div>
                    <div class="col-md-2">
                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-select" Font-Size="Smaller">
                            <asp:ListItem Value="0" Text="Select" />
                            <asp:ListItem Value="1" Text="Active" />
                            <asp:ListItem Value="2" Text="Suspension" />
                            <asp:ListItem Value="3" Text="Deceased" />
                            <asp:ListItem Value="4" Text="Resigned" />
                        </asp:DropDownList>
                    </div>

                    <div class="col-md-2">
                        <asp:Label ID="lblEmployementType" runat="server" Text="Employement Type" Width="200px"></asp:Label>
                    </div>
                    <div class="col-md-2">
                        <asp:DropDownList ID="ddlEmploymentType" runat="server" CssClass="form-select" Font-Size="Smaller">

                            <asp:ListItem Value="0" Text="Select" />
                            <asp:ListItem Value="1" Text="Permanent" />
                            <asp:ListItem Value="2" Text="Contract" />
                            <asp:ListItem Value="3" Text="Temporal" />
                            <asp:ListItem Value="4" Text="Probation" />
                        </asp:DropDownList>
                    </div>


                </div>


                <div class="row">
                    <div class="col-md-2">
                        <asp:Label ID="lblEmailId" runat="server" Text="Email Id"></asp:Label>
                    </div>
                    <div class="col-md-2">
                        <asp:TextBox ID="txtEmailId" runat="server" CssClass="form-control txtbox"></asp:TextBox>
                    </div>

                    <div class="col-md-2">
                        <asp:Label ID="lblMobileNo" runat="server" Text="Mobile No"></asp:Label>
                    </div>
                    <div class="col-md-2">
                        <asp:TextBox ID="txtMobileNo" runat="server" CssClass="form-control txtbox"></asp:TextBox>
                    </div>

                     <div class="col-md-2">
                        <asp:Label ID="lblNRCNo" runat="server" Text="NRCNo"></asp:Label>
                    </div>
                    <div class="col-md-2">
                        <asp:TextBox ID="TxtNRCNo" runat="server" CssClass="form-control txtbox"></asp:TextBox>
                    </div>


                </div>

                <div class="row">
                      <div class="col-md-2">
                        <asp:Label ID="lblTpin" runat="server" Text="TPin"></asp:Label>
                    </div>
                    <div class="col-md-2">
                        <asp:TextBox ID="txtTPin" runat="server" CssClass="form-control txtbox"></asp:TextBox>
                    </div>

                      <div class="col-md-2">
                        <asp:Label ID="lblSocio_Security_No" runat="server" Text="Socio Security No"></asp:Label>
                    </div>
                    <div class="col-md-2">
                        <asp:TextBox ID="txtSocio_Security_No" runat="server" CssClass="form-control txtbox"></asp:TextBox>
                    </div>

                    <div class="col-md-2">
                        <asp:Label ID="lblTitle" runat="server" Text="Title" Visible="false"></asp:Label>
                    </div>
                    <div class="col-md-2">
                        <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control txtbox" Visible="false"></asp:TextBox>
                    </div>

                </div>
            </div>


        </div>

        <div class="row tab">
            <div class="col-sm-3">
                <asp:Button ID="btncontribution" runat="server" Text="Contribution" CssClass="tabbutton" CausesValidation="false" OnClick="btncontribution_click" />
            </div>
        </div>


        <div class="row" id="divContribution" runat="server" visible="false">
            <div class="col-md-12">
                <p>Contributions</p>
            </div>
            <div class="col-md-12">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="grdContribution" runat="server" AutoGenerateColumns="false" ShowFooter="true" OnRowDeleting="grdContribution_RowDeleting">
                            <Columns>
                                <%--<asp:BoundField DataField="sno1" HeaderText="Row Id" ReadOnly="true" />
                                <asp:TemplateField HeaderText="Contribution Type">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlContributionType" runat="server">
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>

                                <asp:TemplateField HeaderText="Contribution Type" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblContributionType" Text='<%# Eval("type") %>' runat="server" CssClass="AlgRght"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Contribution no">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtContributionNo" Text='<%# Eval("contribution_no") %>' runat="server" CssClass="form-control txtbox"></asp:TextBox>
                                    </ItemTemplate>

                                    <%--      <FooterTemplate>
                                        <asp:Button ID="btnAddContribution" runat="server" Text="Add" OnClick="btnAddContribution_Click" CausesValidation="false" />
                                    </FooterTemplate>--%>
                                </asp:TemplateField>
                                <asp:CommandField ShowDeleteButton="true" DeleteText="Clear" />
                            </Columns>

                            <HeaderStyle HorizontalAlign="Center" />

                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>



            </div>
        </div>

        <div class="row tab">
            <div class="col-sm-3">
                <asp:Button ID="btnallowances" runat="server" Text="Allowances" CssClass="tabbutton" CausesValidation="false" OnClick="btnallowances_click" />

            </div>
        </div>


        <div class="row" id="divAllowances" runat="server" visible="false">
            <div class="col-md-12">
                <p>Allowances</p>
                <asp:Label ID="Label6" runat="server" Text="Basic Pay  :"></asp:Label>
                <asp:Label ID="lblAllowanceBasicPay" runat="server" Text=""></asp:Label>
                <asp:TextBox ID="txtAllowanceBasicPay" runat="server" Visible="false" Style="text-align: right;" onkeypress="return isNumberKey(event)" AutoPostBack="true" OnTextChanged="txtAllowanceBasicPay_TextChanged"></asp:TextBox>
                <asp:LinkButton ID="LnkBasicPayEdit" runat="server" CausesValidation="false" Text="Edit" OnClick="LnkBasicPayEdit_Click" />
                <asp:LinkButton ID="LnkBasicPayUpdate" Visible="false" runat="server" CausesValidation="false" Text="Update" OnClick="LnkBasicPayUpdate_Click" />
                &nbsp&nbsp
                 <asp:Label ID="Label4" runat="server" Text="Total Allowances  :"></asp:Label>
                <asp:Label ID="lblAllowancesTotalAmount" runat="server" Text=""></asp:Label>
                &nbsp&nbsp &nbsp&nbsp
                 <asp:Label ID="Label5" runat="server" Text="Gross Salary  :  "></asp:Label>
                <asp:Label ID="lblAllowanceGrossAmount" runat="server"></asp:Label>

                <asp:GridView ID="grdAllowances" runat="server" Width="80%" AutoGenerateColumns="false" OnRowDeleting="grdAllowances_RowDeleting">
                    <Columns>

                        <%--  <asp:BoundField DataField="sno" HeaderText="Sno" ReadOnly="true" />--%>
                        <%-- <asp:BoundField DataField="allowance_name" HeaderText="Allowances" ReadOnly="true" />--%>

                        <asp:TemplateField HeaderText="AllowanceId" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblAllowanceId" Text='<%# Eval("AllowanceId") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Allowances">
                            <ItemTemplate>
                                <asp:Label ID="lblAllowanceName" Text='<%# Eval("allowance_name") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Type">
                            <ItemTemplate>
                                <asp:Label ID="lblType" runat="server" Text="Allowance"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Percentage" HeaderStyle-Width="150px" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:TextBox ID="txtAllowancePercentage" Text='<%# Eval("percentage") %>' runat="server" Style="text-align: right; width: 50px" OnTextChanged="txtAllowancePercentage_TextChanged" onkeypress="return isNumberKey(event)" AutoPostBack="true"></asp:TextBox>
                                <%-- <asp:TextBox ID="txtAllowancePercentage" runat="server" CssClass="form-control txtbox"></asp:TextBox>--%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Standard Amount" HeaderStyle-Width="150px" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:TextBox ID="txtAllowanceAmount" Text='<%# Eval("amount") %>' runat="server" Style="text-align: right; width: 100px" OnTextChanged="txtAllowanceAmount_TextChanged" onkeypress="return isNumberKey(event)" AutoPostBack="true"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Calculated Amount" HeaderStyle-Width="150px" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblTotalAmount" runat="server" Text=""></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <%--                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkClear" runat="server" OnClick="lnkAllowancesClear_Click" CausesValidation="false" Text="Clear" />
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:CommandField ShowDeleteButton="true" DeleteText="Clear" />
                    </Columns>
                    <HeaderStyle HorizontalAlign="center" />
                </asp:GridView>
            </div>
        </div>


        <div class="row tab">
            <div class="col-sm-5">
                <asp:Button ID="btnDeductions" runat="server" Text="Standard Deductions and CTC" CssClass="tabbutton" CausesValidation="false" OnClick="btnDeductions_Click" />
            </div>
        </div>

        <div class="row" id="divDeductions" runat="server" visible="false">
            <div class="col-md-12">
                <p>Deductions</p>

                <asp:Label ID="Label3" runat="server" Text=" Basic Pay  :"></asp:Label>
                <asp:Label ID="lblDeductionBasicPay" runat="server" Text=""></asp:Label>
                <asp:TextBox ID="txtDeductionBasicPay" runat="server" Visible="false" Style="text-align: right; width: 128px;" onkeypress="return isNumberKey(event)" AutoPostBack="true" OnTextChanged="txtDeductionBasicPay_TextChanged"></asp:TextBox>
                &nbsp&nbsp &nbsp&nbsp
                <asp:Label ID="Label7" runat="server" Text=" Total Deductions  : "></asp:Label>
                <asp:Label ID="lblTotalDeductions" runat="server" Text=""></asp:Label>
                &nbsp&nbsp &nbsp&nbsp
                <asp:Label ID="Label8" runat="server" Text=" Gross Salary :"></asp:Label>
                <asp:Label ID="lblDeductionGrossSalary" runat="server" Text=""></asp:Label>
                &nbsp&nbsp &nbsp&nbsp
                <asp:Label ID="Label9" runat="server" Text=" CTC :"></asp:Label>
                <asp:Label ID="lblDeductionsCTC" runat="server" Text=""></asp:Label>

                <asp:GridView ID="grdDeductions" runat="server" AutoGenerateColumns="false" Width="60%" OnRowDataBound="grdDeductions_RowDataBound">
                    <Columns>
                        <%--  <asp:TemplateField HeaderText="Contribution Type" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblContributionType" Text='<%# Eval("ContributionType") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>

                        <asp:TemplateField HeaderText="Name" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblDeductionName" Text='<%# Eval("Name") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Deduction And CTC">
                            <ItemTemplate>
                                <asp:Label ID="lblDeductionDescription" Text='<%# Eval("Description") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Amount">
                            <ItemTemplate>
                                <asp:TextBox ID="txtDeductionAmount" Enabled="false" Text='<%# Eval("Amount") %>' runat="server" Style="text-align: right; width: 100px" onkeypress="return isNumberKey(event)" AutoPostBack="true"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Ceiling Amount">
                            <ItemTemplate>
                                <asp:TextBox ID="txtDeductionRange" Enabled="false" runat="server" Text='<%# Eval("Range") %>' Style="text-align: right; width: 100px" onkeypress="return isNumberKey(event)"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle HorizontalAlign="center" />
                </asp:GridView>



            </div>
        </div>


        <div class="row tab">
            <div class="col-sm-3">
                <asp:Button ID="btnDocumentsUpload" runat="server" Text="Documents Upload" CssClass="tabbutton" CausesValidation="false" OnClick="btnDocumentsUpload_Click" />
            </div>
        </div>

        <div class="row" id="divDocuments" runat="server" visible="false">
            <div class="col-md-12">
                <p>Documents Upload</p>
                <div class="row">
                    <div class="col-md-2">
                        <asp:Label ID="lblImage" runat="server" Text="Photo"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-2">
                        <asp:Image ID="image" runat="server" Height="105px" Width="133px" ImageAlign="AbsMiddle" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-2">
                        <asp:FileUpload ID="fuImage" runat="server" Width="159px" onchange="ShowImagePreview(this);" />
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-2">
                        <asp:Label ID="lblSignature" runat="server" Text="Signature"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-2">
                        <asp:Image ID="imgSignature" runat="server" Height="105px" Width="133px" ImageAlign="AbsMiddle" />
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-2">
                        <asp:FileUpload ID="fuSignature" runat="server" Width="159px" onchange="ShowSignaturePreview(this);" />
                    </div>
                </div>
            </div>
        </div>

    </div>


    <div class="row">
        <div class="col-md-12">
            <asp:Panel ID="panelmsg" runat="server" BorderStyle="Groove" Style="z-index: 0; left: 450px; position: absolute; top: 320px; border-radius: 15px; height: 100px; width: 500px;"
                Visible="False" BackColor="WhiteSmoke">
                <asp:Label ID="lblsuccmsg" runat="server"></asp:Label>
                <br />
                <asp:Label ID="lblconfirmation" runat="server" Text="Do you want to preview"></asp:Label>
                <br />

                <div class="row">
                    <div class="col-md-4"></div>
                    <div class="col-md-6">
                        <asp:Button ID="btnyes" runat="server" CssClass="btn  btn-primary" Text="Yes" OnClick="btnyes_Click" />
                        <asp:Button ID="btnno" runat="server" CssClass="btn  btn-danger" Text="No" OnClick="btnno_Click" />

                    </div>
                </div>


            </asp:Panel>
        </div>
    </div>
</asp:Content>
