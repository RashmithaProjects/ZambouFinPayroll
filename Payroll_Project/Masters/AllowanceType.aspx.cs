using Payroll_Project.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Payroll_Project.Masters
{
    public partial class AllowanceType : System.Web.UI.Page
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

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                ShowPopUpMsg("Please enter Name");
            }
            else
            {

                dt = dal.Fun_AllowanceType_InsUpd(txtName.Text, txtDescription.Text, "Insert");
                if (dt.Rows.Count > 0)
                {
                    ShowPopUpMsg("Allowance Type Created Successfully");
                    clear();

                }
            }

        }

        public void clear()
        {
            txtName.Text = "";
            txtDescription.Text = "";


        }

    }
}