using Gama;
using System;

namespace GamaEventMgmt.EventMgmt
{
    public partial class eventView : System.Web.UI.Page
    {
        Event objEvent = new Event();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["evt"] != null)
            {
                ltrHTML.Text = objEvent.GenerateEventHtml(Request.QueryString["evt"].ToString());
            }
        }
    }
}