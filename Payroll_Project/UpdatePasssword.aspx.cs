using Payroll_Project.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Payroll_Project
{
    public partial class UpdatePasssword : System.Web.UI.Page
    {
        Dal dal = new Dal();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void ShowPopUpMsg(string msg)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("alert('");
            sb.Append(msg.Replace("\n", "\\n").Replace("\r", "").Replace("'", "\\'"));
            sb.Append("');");
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "showalert", sb.ToString(), true);
        }

        protected void Btn_login_Click(object sender, EventArgs e)
        {

        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "")
            {
                ShowPopUpMsg("Please enter UserName");
            }
            else if (txtOldPassword.Text == "")
            {
                ShowPopUpMsg("Please enter Old Password");
            }
            else if (txtNewPassword.Text == "")
            {
                ShowPopUpMsg("Please enter New Password");
            }
 
            else if (txtConfirmPassword.Text == "")
            {
                ShowPopUpMsg("Please enter ConfirmPassword");
            }
            else if(txtNewPassword.Text != txtConfirmPassword.Text)
            {
                ShowPopUpMsg("Password and ConfirmPassword are MisMatching");

            }

            else
            {
                dt = dal.Fun_UpdatePassword(txtUserName.Text, txtOldPassword.Text, txtNewPassword.Text);
                if(dt.Rows[0]["result"].ToString() == "0")
                {
                    ShowPopUpMsg("Old Password Is not Correct");
                }
                else if (dt.Rows[0]["result"].ToString() == "1")
                {
                    Response.Redirect("~/Dashboard.aspx");
                }
               
            }
        }
    }
}