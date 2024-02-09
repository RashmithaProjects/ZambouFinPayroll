using Payroll_Project.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Payroll_Project
{
    public partial class Login : System.Web.UI.Page
    {
        Dal dal = new Dal();
        DataTable dt = new DataTable();

        private void ShowPopUpMsg(string msg)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("alert('");
            sb.Append(msg.Replace("\n", "\\n").Replace("\r", "").Replace("'", "\\'"));
            sb.Append("');");
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "showalert", sb.ToString(), true);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //BindWorkLocation();
            }
        }

        protected void txtusername_TextChanged(object sender, EventArgs e)
        {

        }

        //protected void txtpassword_TextChanged(object sender, EventArgs e)
        //{

        //    dt = dal.Fun_Login(txtusername.Text, txtpassword.Text);
        //    if (dt.Rows.Count == 0)
        //    {
        //        ShowPopUpMsg("Invalid username or Password");
        //        txtdate.Text = "";
        //        ddllocation.SelectedIndex = 0;
        //    }
        //    else
        //    {
        //        ddllocation.SelectedIndex = 2;
        //        txtdate.Text = DateTime.Now.ToString();
        //    }
        //    //if (txtusername.Text == "")
        //    //{
        //    //    ShowPopUpMsg("Please enter UserName");
        //    //}
        //    //else if (txtpassword.Text == "")
        //    //{
        //    //    ShowPopUpMsg("Please enter Password");
        //    //}
        //    //else
        //    //{
        //    //    dt = dal.Fun_Login(txtusername.Text, txtpassword.Text);
        //    //    //if (dt.Rows.Count > 0)
        //    //    //{
        //    //    //    Response.Redirect("~/Dashboard.aspx");
        //    //    //}
        //    //    if(dt.Rows.Count==0)
        //    //    {
        //    //        ShowPopUpMsg("Invalid username or Password");

        //    //    }
        //    //}

        //}

        protected void Btn_login_Click(object sender, EventArgs e)
        {

            //if (FormsAuthentication.Authenticate(txtusername.Text, txtpassword.Text))
            //{
            //    FormsAuthentication.RedirectFromLoginPage(txtusername.Text, false);
            //}
            //else
            //{
            //   string errrmsg = "Invalid User Name and/or Password";
            //}

            if (txtusername.Text == "")
            {
                ShowPopUpMsg("Please enter UserName");
            }
            //else if (txtpassword.Text == "")
            //{
            //    ShowPopUpMsg("Please enter Password");
            //}
            else
            {
                dt = dal.Fun_Login(txtusername.Text, txtpassword.Text);
                if (dt.Rows.Count > 0)
                {

                    Session["UserName"] = txtusername.Text;
                    Session["RoleName"] = dt.Rows[0]["RoleName"];
                    //if (dt.Rows[0]["FirstTimeLogin"].ToString()=="True")
                    //{
                    //    Response.Redirect("~/UpdatePasssword.aspx");
                    //}
                    //else
                    //{
                    //    //FormsAuthentication.RedirectFromLoginPage(txtusername.Text,false);
                    //    Response.Redirect("~/Dashboard.aspx");
                    //}
                    Response.Redirect("~/Dashboard.aspx");

                }
                else
                {
                    ShowPopUpMsg("Invalid username or Password");

                }
            }

            
        }

       
    }
}