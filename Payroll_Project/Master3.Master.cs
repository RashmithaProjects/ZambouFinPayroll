using Payroll_Project.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Payroll_Project
{
    public partial class Master3 : System.Web.UI.MasterPage
    {
        DataTable dt = new DataTable();
        Dal dal = new Dal();
        string Msg = null;
        DateTime d, d1;
        string DocRecId = null; string DocType = null;
        delegate void FormListDeleg();
        FtpClass _ftpObj = new FtpClass();
        string n = null;



        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                string sessionUserName = Session["UserName"] as string;
                string roleName = Session["RoleName"] as string;
                if (!string.IsNullOrEmpty(sessionUserName) && !string.IsNullOrEmpty(roleName))
                {
                    GetMenuData(0, Session["UserName"].ToString(), Session["RoleName"].ToString());
                    lblUserName.Text = Session["UserName"].ToString();
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }

                DateTime currentDateTime = DateTime.Now;
                // DateTime D = 210;
                string formattedDateTime = currentDateTime.ToString("dddd, dd MMMM yyyy HH:mm");
                labeldat.Text = formattedDateTime;
                DateTime dd = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("South Africa Standard Time"));
                labeldat.Text = dd.ToString("dddd, dd MMMM yyyy HH:mm");

                //_alert();


                //labela.Text = Session["authorizers"].ToString();
                //lblbranch.Text = Session["Branch"] + "~" + Session["BranchCode"];
                //img_profile.ImageUrl = "~/Users/" + Session["usid"] + ".png";
            }

        }
        public void _alert()
        {
            dt = dal.Fun_Alert("Admin");
            if (dt.Rows.Count > 0 && dt != null)
            {
                //txtn.Text = dt.Rows[0]["Id"].ToString();
                //txtn.Enabled = false;
            }
        }
        protected void lnk_out_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/Login.aspx");
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Notification.aspx");
        }

        private void GetMenuData(int ParentMenuId, string UserName, string RoleName)
        {

            // for restrict url

            string currentPage = System.IO.Path.GetFileName(Request.Url.AbsolutePath);


            // for restriction of url from typing url in browser for user
            dt = dal.Fun_MenuItems(UserName, RoleName);
            var urlAccess = from myRow in dt.AsEnumerable()
                            where myRow.Field<string>("Url").Contains(currentPage)
                            select myRow;
            int Count = urlAccess.Count();




            if (Count == 0 && Session["RoleName"].ToString()!="Admin")
            {
                Response.Redirect("~/Dashboard.aspx");
            }
            else
            {

                DataView view = new DataView(dt);
                view.RowFilter = "ParentMenuId =" + ParentMenuId;
                foreach (DataRowView row in view)
                {
                    MenuItem menuItem = new MenuItem(row["Description"].ToString(),
                    row["MenuId"].ToString());
                    menuItem.NavigateUrl = row["Url"].ToString();
                    menu_Items.Items.Add(menuItem);
                    AddChildItems(dt, menuItem);
                }
            }
        }
        private void AddChildItems(DataTable table, MenuItem menuItem)
        {
            DataView viewItem = new DataView(table);
            viewItem.RowFilter = "ParentMenuId=" + menuItem.Value;
            foreach (DataRowView childView in viewItem)
            {
                MenuItem childItem = new MenuItem(childView["Description"].ToString(),
                childView["MenuId"].ToString());
                childItem.NavigateUrl = childView["Url"].ToString();
                menuItem.ChildItems.Add(childItem);
                AddChildItems(table, childItem);
            }
        }







        //public DataTable GetData(int parentMenuId)
        //{
        //    string query = "SELECT [MenuId], [Title], [Description], [Url] FROM [Menus] WHERE ParentMenuId = @ParentMenuId";

        //    string constr = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        //    using (SqlConnection con = new SqlConnection(constr))
        //    {
        //        DataTable dt = new DataTable();
        //        using (SqlCommand cmd = new SqlCommand(query))
        //        {
        //            using (SqlDataAdapter sda = new SqlDataAdapter())
        //            {
        //                cmd.Parameters.AddWithValue("@ParentMenuId", parentMenuId);
        //                //cmd.Parameters.AddWithValue("@UserName", Session["UserName"].ToString());
        //                //cmd.Parameters.AddWithValue("@Role", Session["RoleName"].ToString());
        //                //cmd.Parameters.AddWithValue("@Tran", Session["RoleName"].ToString());
        //                //cmd.CommandType = CommandType.StoredProcedure;

        //                cmd.Connection = con;
        //                sda.SelectCommand = cmd;
        //                sda.Fill(dt);
        //            }
        //        }
        //        return dt;
        //    }
        //}

        //public void PopulateMenu(DataTable dt, int parentMenuId, MenuItem parentMenuItem)
        //{
        //    string currentPage = Path.GetFileName(Request.Url.AbsolutePath);
        //    foreach (DataRow row in dt.Rows)
        //    {
        //        MenuItem menuItem = new MenuItem
        //        {
        //            Value = row["MenuId"].ToString(),
        //            Text = row["Title"].ToString(),
        //            NavigateUrl = row["Url"].ToString(),
        //            Selected = row["Url"].ToString().EndsWith(currentPage, StringComparison.CurrentCultureIgnoreCase)
        //        };
        //        if (parentMenuId == 0)
        //        {
        //            menu_Items.Items.Add(menuItem);
        //            DataTable dtChild = dal.Fun_MenuItems(int.Parse(menuItem.Value), Session["UserName"].ToString(), Session["RoleName"].ToString());
        //            PopulateMenu(dtChild, int.Parse(menuItem.Value), menuItem);
        //        }
        //        else
        //        {
        //            parentMenuItem.ChildItems.Add(menuItem);
                   
        //        }
        //    }
        //}

       

        }
}