<%--<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>--%>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Payroll_Project.Login" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
     <meta charset="utf-8">
  <meta content="width=device-width, initial-scale=1.0" name="viewport">

  <title>Login</title>
  <meta content="" name="description"/>
  <meta content="" name="keywords"/>

  <!-- Favicons -->
  <link href="assets/img/favicon.png" rel="icon"/>
  <link href="assets/img/Logo.png" rel="apple-touch-icon"/>


    
  <!-- Google Fonts -->
  <link href="https://fonts.gstatic.com" rel="preconnect">
  <link href="https://fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i|Nunito:300,300i,400,400i,600,600i,700,700i|Poppins:300,300i,400,400i,500,500i,600,600i,700,700i" rel="stylesheet"/>

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
                  
                   

                    <img src="assets/img/logo.png" alt=""/>
                
                  <span class="d-none d-lg-block">Zambou Financial Services</span>
                </a>
              </div><!-- End Logo -->

              <div class="card mb-4">

                <div class="card-body">

                  <div class="pt-4 pb-2">

                    <h5 class="card-title text-center pb-0 fs-4">Login to Your Account</h5>
                    <p class="text-center small">Enter your username & password to login</p>
                  </div>

                  <form class="row g-3 needs-validation" novalidate>

                    <div class="col-12">
                      <label for="yourUsername" class="form-label">Username</label>
                      <div class="input-group has-validation">
                        <span class="input-group-text" id="inputGroupPrepend">@</span>
                      
                          <asp:TextBox ID="txtusername" runat="server" class="form-control"></asp:TextBox>
                        <div class="invalid-feedback">Please enter your username.</div>
                      </div>
                    </div>

                    <div class="col-12">
                      <label for="yourPassword" class="form-label">Password</label>
                    
                        <asp:TextBox ID="txtpassword" runat="server" class="form-control" TextMode="Password"></asp:TextBox>
                      <div class="invalid-feedback">Please enter your password!</div>
                    </div>

                    <div class="col-12">
                      <div class="form-check">
                       <%-- <input class="form-check-input" type="checkbox" name="remember" value="true" id="rememberMe">--%>
               <%--           <asp:CheckBox ID="rememberMe"  class="form-check-input" runat="server"   ></asp:CheckBox>
                        <label class="form-check-label" for="rememberMe">Remember me</label>--%>
                      </div>
                    </div>
                    <div class="col-12">
                     

                        <asp:Button ID="Btn_login" runat="server" Text="Login"  class="btn btn-primary w-100" OnClick="Btn_login_Click" ></asp:Button>
                    </div>
                    <div class="col-12">
                     <%-- <p class="small mb-0">Don't have account? <a href="pages-register.html">Create an account</a></p>--%>
                    </div>
                  </form>

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
