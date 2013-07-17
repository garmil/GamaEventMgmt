using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Gama;
using AjaxControlToolkit;

namespace GamaEventMgmt.EventMgmt
{
    public partial class eventSetup : System.Web.UI.Page
    {
        Event objEvent = new Event();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            objEvent.insertEvent(tbxEventTitle.Text, Convert.ToInt32(Session["usr_id"].ToString()), tbxEvent.Text, tbxAgentEmail.Text);
            
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        protected void btnGenerateHTML_Click(object sender, EventArgs e)
        {
            
        }

        protected void htmeEvent_ImageUploadComplete(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)
        {
            htmeEvent.AjaxFileUpload.SaveAs(@"~\\eventImages\\" + e.FileName);
            e.PostedUrl = Page.ResolveUrl(@"~\\eventImages\\" + e.FileName);

            string fullpath = "~\\eventImages\\" + e.FileName;

            //htmeEvent.AjaxFileUpload.SaveAs(fullpath);

            //e.PostedUrl = Page.ResolveUrl("~\\eventImages\\" + e.FileName);

            //// Generate file path
            //string filePath = "~/eventImages/" + e.FileName;

            //// Save uploaded file to the file system
            //var ajaxFileUpload = (AjaxFileUpload)sender;
            //ajaxFileUpload.SaveAs(MapPath(filePath));

            //// Update client with saved image path
            //e.PostedUrl = Page.ResolveUrl(filePath);
        }
    }
}