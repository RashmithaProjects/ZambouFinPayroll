<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdatePasssword.aspx.cs" Inherits="Payroll_Project.UpdatePasssword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<html xmlns="http://www.w3.org/1999/xhtml">
<meta charset="utf-8">
<meta content="width=device-width, initial-scale=1.0" name="viewport">

<title>Login</title>
<meta content="" name="description" />
<meta content="" name="keywords" />

<!-- Favicons -->
<link href="assets/img/favicon.png" rel="icon" />
<link href="assets/img/Logo.png" rel="apple-touch-icon" />



<!-- Google Fonts -->
<link href="https://fonts.gstatic.com" rel="preconnect">
<link href="https://fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i|Nunito:300,300i,400,400i,600,600i,700,700i|Poppins:300,300i,400,400i,500,500i,600,600i,700,700i" rel="stylesheet" />

<!-- Vendor CSS Files -->
<link href="Assets/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">
<link href="Assets/vendor/bootstrap-icons/bootstrap-icons.css" rel="stylesheet">
<link href="Assets/vendor/boxicons/css/boxicons.min.css" rel="stylesheet">
<link href="Assets/vendor/quill/quill.snow.css" rel="stylesheet">
<link href="Assets/vendor/quill/quill.bubble.css" rel="stylesheet">
<link href="Assets/vendor/remixicon/remixicon.css" rel="stylesheet">
<link href="Assets/vendor/simple-datatables/style.css" rel="stylesheet">

<!-- Template Main CSS File -->
<link href="Assets/css/style.css" rel="stylesheet">

<head runat="server">
    <title></title>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <main>
                <div class="container">

                    <section class="section register min-vh-100 d-flex flex-column align-items-center justify-content-center py-2">
                        <div class="container">
                            <div class="row justify-content-center">
                                <div class="col-lg-6 col-md-4 d-flex flex-column align-items-center justify-content-center">

                                    <div class="row">
                                        <div class="col-md-12">
                                            <h2>Payroll</h2>

                                        </div>
                                    </div>

                                    <div class="d-flex justify-content-center">
                                        <a href="" class="logo d-flex align-items-center w-auto">



                                            <img src="assets/img/logo.png" alt="" />

                                            <span class="d-none d-lg-block">Zambou Financial Services</span>
                                        </a>
                                    </div>
                                    <!-- End Logo -->

                                     <div class="row">
                                        <div class="col-md-6">
                                            <asp:Label ID="lblUserName" runat="server" Text="UserName"></asp:Label>
                                        </div>
                                        <div class="col-md-6">
                                            <asp:TextBox ID="txtUserName"  runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <br />

                                    <div class="row">
                                        <div class="col-md-6">
                                            <asp:Label ID="lblOldPassword" runat="server" Text="Current Password"></asp:Label>
                                        </div>
                                        <div class="col-md-6">
                                            <asp:TextBox ID="txtOldPassword" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-6">
                                            <asp:Label ID="lblNewPassword" runat="server" Text="New Password"></asp:Label>
                                        </div>
                                        <div class="col-md-6">
                                            <asp:TextBox ID="txtNewPassword" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-6">
                                            <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password"></asp:Label>
                                        </div>
                                        <div class="col-md-6">
                                            <asp:TextBox ID="txtConfirmPassword" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>

                                    <br />

                                    <div class="row">
                                        <div class="col-md-12">
                                             <asp:Button ID="BtnSubmit" runat="server" Text="Submit"  class="btn btn-primary w-100" OnClick="BtnSubmit_Click" ></asp:Button>
                                        </div>
                                    </div>

                                    <div class="credits">
                                        <!-- All the links in the footer should remain intact. -->
                                        <!-- You can delete the links only if you purchased the pro version. -->
                                        <!-- Licensing information: https://bootstrapmade.com/license/ -->
                                        <!-- Purchase the pro version with working PHP/AJAX contact form: https://bootstrapmade.com/nice-admin-bootstrap-admin-html-template/ -->
                                        Designed by <a href="https://rashmitha.com/">RIS</a>
                                    </div>

                                </div>
                            </div>
                        </div>

                    </section>

                </div>
            </main><!-- End #main -->

            <a href="#" class="back-to-top d-flex align-items-center justify-content-center"><i class="bi bi-arrow-up-short"></i></a>

            <!-- Vendor JS Files -->
            <script src="Assets/vendor/apexcharts/apexcharts.min.js"></script>
            <script src="Assets/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
            <script src="Assets/vendor/chart.js/chart.min.js"></script>
            <script src="Assets/vendor/echarts/echarts.min.js"></script>
            <script src="Assets/vendor/quill/quill.min.js"></script>
            <script src="Assets/vendor/simple-datatables/simple-datatables.js"></script>
            <script src="Assets/vendor/php-email-form/validate.js"></script>

            <!-- Template Main JS File -->
            <script src="Assets/js/main.js"></script>
        </div>
    </form>
</body>
</html>
