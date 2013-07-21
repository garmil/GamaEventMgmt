using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Gama;

namespace GamaEventMgmt.EventMgmt
{
    public partial class eventFunctions : System.Web.UI.Page
    {
        Event objEvtFuncs = new Event();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loggedIn"] != null && Session["loggedIn"].ToString() == "true")
            {
                HyperLink hypLogin = (HyperLink)Master.FindControl("hypLogin");
                hypLogin.Visible = false;

                if (Session["usr_id"] != null && Convert.ToInt32(Session["ust_id"]) > 2)
                {
                    Response.Redirect("~/accessDenied.aspx");
                }

            }
            else
            {

                Response.Redirect("~/accessDenied.aspx");

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            objEvtFuncs.insertEventFunction(ddlEvents.SelectedValue.ToString(), Convert.ToInt32(tbxNumSeats.Text), tbxOfferName.Text, tbxOfferDesc.Text);
            lblDisplayMessages.Text = "Event function saved";
            dvSystemMessages.Visible = true;
        }
    }
}