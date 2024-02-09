using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using Payroll_Project.DAL;

namespace Payroll_Project.Reports
{
    public partial class Provision_For_LeaveDays : System.Web.UI.Page
    {
        Dal dal = new Dal();
        DataTable dt = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            //ScriptManager.GetCurrent(Page).RegisterPostBackControl(btnGo);
            lblYear.Text = DateTime.Now.Year.ToString();
            BindGrid();
        }

        public void BindGrid()
        {
            dt = dal.Provision_For_LeaveDays();
            if (dt.Rows.Count > 0)
            {
                grdReport.DataSource = dt;
                grdReport.DataBind();

                //decimal January = dt.AsEnumerable().Sum(row => row.Field<decimal?>("January") ?? 0);
                //decimal February = dt.AsEnumerable().Sum(row => row.Field<decimal?>("February") ?? 0);
                //decimal March = dt.AsEnumerable().Sum(row => row.Field<decimal?>("March") ?? 0);
                //decimal April = dt.AsEnumerable().Sum(row => row.Field<decimal?>("April") ?? 0);
             
                //decimal Total = dt.AsEnumerable().Sum(row => row.Field<decimal?>("Total") ?? 0);
              

            }

        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {

            if (ddl_Export.SelectedIndex == 1)
                ExporttoPdf();
            if (ddl_Export.SelectedIndex == 2)
                ExporttoExcel();
        }

        public void ExporttoPdf()
        {
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    grdReport.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());
                    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    pdfDoc.Close();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename=ProvisionForLeaveDays.pdf");
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Write(pdfDoc);
                    Response.End();
                }
            }
        }

        public void ExporttoExcel()
        {
            if (grdReport.Rows.Count > 0)
            {
                grdReport.AllowPaging = false;
                Response.ClearContent();
                string filname = "ProvisionForLeaveDays" + DateTime.Now.ToString("ddMMyyyy");
                Response.AddHeader("content-disposition", "attachment;" + "filename=" + filname + ".xls");
                Response.ContentType = "application/excel";
                System.IO.StringWriter sw = new System.IO.StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);
                grdReport.RenderControl(htw);
                Response.Write(sw.ToString());
                Response.End();

            }


        }

    }
}