using Gama;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GamaEventMgmt.EventMgmt
{
    public partial class eventView : System.Web.UI.Page
    {
        Event objEvent = new Event();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["evt"] != null)
            {
                ltrHTML.Text = objEvent.generateEventHTML(Request.QueryString["evt"].ToString());
            }
        }
    }
}