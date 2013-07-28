using Gama;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GamaEventMgmt.EventFunctions
{
    public partial class evtLimitedOffers : System.Web.UI.Page
    {
        Event objEvent = new Event();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            objEvent.InsertEventFunction(ddlEvent.SelectedValue.ToString(), Convert.ToInt32(tbxNumSeats.Text), tbxEvtLimitedOffer.Text, tbxEvtLimOfferDesc.Text);
            lblSystemMessage.Text = "Limited offer saved";
        }
    }
}