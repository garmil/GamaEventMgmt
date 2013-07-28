using System;
using System.Globalization;
using System.Web.UI.WebControls;
using Gama;
using System.Data;

namespace GamaEventMgmt.EventMgmt
{
    public partial class EventSetup : System.Web.UI.Page
    {
        readonly Event _objEvent = new Event();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loggedIn"] != null && Session["loggedIn"].ToString() == "true")
            {
                var hypLogin = (HyperLink)Master.FindControl("hypLogin");
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

        protected void BtnSaveClick(object sender, EventArgs e)
        {
            _objEvent.InsertEvent(tbxEventTitle.Text, Convert.ToInt32(Session["usr_id"].ToString()), tbxEvent2.Content, tbxAgentEmail.Text);
            
        }

        protected void BtnUpdateClick(object sender, EventArgs e)
        {
            _objEvent.UpdateEvent(ddlEvents.SelectedValue.ToString(CultureInfo.InvariantCulture), tbxEventTitle.Text, tbxEvent2.Content, tbxAgentEmail.Text);
            ddlEvents.SelectedValue = "0";
            btnSave.Visible = true;
            btnUpdate.Visible = true;
        }

        protected void BtnGenerateHtmlClick(object sender, EventArgs e)
        {
            
        }



        protected void DdlEventsSelectedIndexChanged(object sender, EventArgs e)
        {
            btnSave.Visible = false;
            btnUpdate.Visible=true;

            var dtEvent = _objEvent.GetEventData(ddlEvents.SelectedValue);

            foreach (DataRow row in dtEvent.Rows)
            {
                
                tbxEvent2.Content= row["evt_HTML"].ToString();
                tbxEventTitle.Text = row["evt_Name"].ToString();
                tbxAgentEmail.Text = row["evt_Agent"].ToString();
            }
        }

        protected void BtnDeleteClick(object sender, EventArgs e)
        {
            _objEvent.DeleteEvent(int.Parse(ddlEvents.SelectedValue));


        }
    }
}