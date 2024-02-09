using Payroll_Project.DAL;
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
namespace Payroll_Project.Reports
{
    public partial class NetSalaryAndWages : System.Web.UI.Page
    {
        Dal dal = new Dal();
        DataTable dt = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            // ScriptManager.GetCurrent(Page).RegisterPostBackControl(btnGo);
            lblYear.Text = DateTime.Now.Year.ToString();
            BindGrid();
        }

        public void BindGrid()
        {
            dt = dal.Fun_NetSalaryAndWage();
            if (dt.Rows.Count > 0)
            {
                grdReport.DataSource = dt;
                grdReport.DataBind();

                decimal January = dt.AsEnumerable().Sum(row => row.Field<decimal?>("January") ?? 0);
                decimal February = dt.AsEnumerable().Sum(row => row.Field<decimal?>("February") ?? 0);
                decimal March = dt.AsEnumerable().Sum(row => row.Field<decimal?>("March") ?? 0);
                decimal April = dt.AsEnumerable().Sum(row => row.Field<decimal?>("April") ?? 0);
                decimal May = dt.AsEnumerable().Sum(row => row.Field<decimal?>("May") ?? 0);
                decimal June = dt.AsEnumerable().Sum(row => row.Field<decimal?>("June") ?? 0);
                decimal July = dt.AsEnumerable().Sum(row => row.Field<decimal?>("July") ?? 0);
                decimal August = dt.AsEnumerable().Sum(row => row.Field<decimal?>("August") ?? 0);
                decimal September = dt.AsEnumerable().Sum(row => row.Field<decimal?>("September") ?? 0);
                decimal October = dt.AsEnumerable().Sum(row => row.Field<decimal?>("October") ?? 0);
                decimal November = dt.AsEnumerable().Sum(row => row.Field<decimal?>("November") ?? 0);
                decimal December = dt.AsEnumerable().Sum(row => row.Field<decimal?>("December") ?? 0);

                decimal Total = dt.AsEnumerable().Sum(row => row.Field<decimal?>("Total") ?? 0);
                foreach (GridViewRow row in grdReport.Rows)
                {

                    Label lblTotalJanuary = (Label)grdReport.FooterRow.FindControl("lblTotalJanuary");
                    Label lblTotalFebraury = (Label)grdReport.FooterRow.FindControl("lblTotalFebraury");
                    Label lblTotalMarch = (Label)grdReport.FooterRow.FindControl("lblTotalMarch");
                    Label lblTotalApril = (Label)grdReport.FooterRow.FindControl("lblTotalApril");
                    Label lblTotalMay = (Label)grdReport.FooterRow.FindControl("lblTotalMay");
                    Label lblTotalJune = (Label)grdReport.FooterRow.FindControl("lblTotalJune");               
                    Label lblTotalJuly = (Label)grdReport.FooterRow.FindControl("lblTotalJuly");
                    Label lblTotalAugust = (Label)grdReport.FooterRow.FindControl("lblTotalAugust");
                    Label lblTotalSeptember = (Label)grdReport.FooterRow.FindControl("lblTotalSeptember");
                    Label lblTotalOctober = (Label)grdReport.FooterRow.FindControl("lblTotalOctober");
                    Label lblTotalNovember = (Label)grdReport.FooterRow.FindControl("lblTotalNovember");
                    Label lblTotalDecember = (Label)grdReport.FooterRow.FindControl("lblTotalDecember");

                    Label lblTotal = (Label)grdReport.FooterRow.FindControl("lblTotal");

                    lblTotalJanuary.Text = January.ToString();
                    lblTotalFebraury.Text = February.ToString();
                    lblTotalMarch.Text = March.ToString();
                    lblTotalApril.Text = April.ToString();
                    lblTotalMay.Text = May.ToString();
                    lblTotalJune.Text = June.ToString();
                    lblTotalJuly.Text = July.ToString();
                    lblTotalAugust.Text = August.ToString();
                    lblTotalSeptember.Text = September.ToString();
                    lblTotalOctober.Text = October.ToString();
                    lblTotalNovember.Text = November.ToString();
                    lblTotalDecember.Text = December.ToString();
                    lblTotal.Text = Total.ToString();
                    
                }

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
                    Response.AddHeader("content-disposition", "attachment;filename=NetSalaryAndWage.pdf");
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
                string filname = "NetSalaryAndWages" + DateTime.Now.ToString("ddMMyyyy");
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