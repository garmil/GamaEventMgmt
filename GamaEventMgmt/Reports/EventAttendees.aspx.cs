using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExcelHelper;

namespace GamaEventMgmt.Reports
{
    public partial class EventAttendees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void odsEventAttendees_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            
        }

        protected void odsEventAttendees_Selected(object sender, ObjectDataSourceStatusEventArgs e)
        {
            if (ddlEvents.SelectedItem.Text != "-New Event-")
            {
                gvwAttendees.EmptyDataText = "No data found for " + ddlEvents.SelectedItem.Text;
            }
            else
            {
                gvwAttendees.EmptyDataText = "Select an event from the dropdownlist";
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //
        }

        protected void btnExportCsv_Click(object sender, EventArgs e)
        {
            string dateTime = DateTime.Now.ToString().Replace(":", "_").Replace("/","_");
            string fileName = "EventAttendees_" + dateTime + ".xls";
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=" + fileName);
            Response.Charset = "";


            // If you want the option to open the Excel file without saving then
            // comment out the line below
            // Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.xls";
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gvwAttendees.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();

        }
    }
}