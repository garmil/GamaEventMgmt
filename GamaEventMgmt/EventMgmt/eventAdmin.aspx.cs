using System;
using System.Configuration;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using Gama;

namespace GamaEventMgmt.EventMgmt
{
    public partial class eventAdmin : System.Web.UI.Page
    {
        Event objEvent = new Event();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void odsEvents_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters[0] = tbxDateFrom.Text;
            e.InputParameters[1] = tbxDateTo.Text;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            gvwEvents.DataBind();
        }

        
        protected void gvwEvents_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("SelectRecord"))
            {
                int row = Int32.Parse(e.CommandArgument.ToString());
                string evtGuid = gvwEvents.DataKeys[row].Values[0].ToString();

                Response.Redirect(ConfigurationManager.AppSettings["siteURL"] +
                                               "EventMgmt/eventView.aspx?evt=" + evtGuid);
            }

            if (e.CommandName.Equals("viewStats"))
            {
                
                int row = Int32.Parse(e.CommandArgument.ToString());
                string evtGuid = gvwEvents.DataKeys[row].Values[0].ToString();
                int evtId = objEvent.GetEventId(evtGuid);
                Response.Redirect(ConfigurationManager.AppSettings["siteURL"] +
                                               "EventMgmt/eventStats.aspx?evtId=" + evtId);
            }

            if (e.CommandName.Equals("viewAttendants"))
            {
                
                int row = Int32.Parse(e.CommandArgument.ToString());
                string evtGuid = gvwEvents.DataKeys[row].Values[0].ToString();
                int evtId = objEvent.GetEventId(evtGuid);
                Response.Redirect(ConfigurationManager.AppSettings["siteURL"] +
                                               "EventMgmt/eventAttendants.aspx?evtId=" + evtId);
            }
            
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
           
            string dateTime = DateTime.Now.ToString().Replace(":", "_").Replace("/", "_");
            string fileName = "EventAdmin_" + dateTime + ".xls";
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
            gvwEvents.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
        }
    }
}