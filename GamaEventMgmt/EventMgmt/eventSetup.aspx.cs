using System;
using System.Configuration;
using System.Globalization;
using System.Web.UI.WebControls;
using Gama;
using System.Data;
using Gama.CommonMethods;

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
            int expectedNumRegistrants = 0;

            if (_objEvent.checkEventNameExists(tbxEventTitle.Text))
            {

                lblInfo.Text = "Event by that name already exists";
                dvErrorMEssages.Visible = true;
            }
            else
            {

               

                int newEventId = 0;
                string agentEmails = string.Empty;

                agentEmails = joinAgentEmails(tbxAgentEmail.Text);

                if (tbxNumRegistrants.Text != "")
                {
                    expectedNumRegistrants = Convert.ToInt32(tbxNumRegistrants.Text);
                }

                 newEventId = _objEvent.InsertEvent(tbxEventTitle.Text, Convert.ToInt32(Session["usr_id"].ToString()), tbxEventHeader.Content,
                                      tbxEvent2.Content, agentEmails, tbxEventDateFrom.Text, tbxDateEventTo.Text, expectedNumRegistrants);

                dvErrorMEssages.Visible = false;
                lblDisplayMessages.Text = "Event Saved";
                dvSystemMessages.Visible = true;

                btnSave.Visible = false;
                btnUpdate.Visible = true;

                ddlEvents.Items.Clear();
                ddlEvents.Items.Add(new ListItem("-New Event-", "0"));
                ddlEvents.DataBind();
                ddlEvents.SelectedValue = newEventId.ToString();

                var dtEvent = _objEvent.GetEventData(newEventId.ToString());

                foreach (DataRow row in dtEvent.Rows)
                {
                    hypViewEvent.NavigateUrl = ConfigurationManager.AppSettings["siteURL"] +
                                               "Registration/Register.aspx?evt=" + row["evt_GUID"];
                    
                }

                
            }
        }

        private string joinAgentEmails(string agentEmailAddresses)
        {
            string txt = agentEmailAddresses;
            string[] lst = txt.Split(new Char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            string agentEmails = string.Empty;
            foreach (string line in lst)
            {
                agentEmails += line + ";";
            }

            if (agentEmails != string.Empty)
            {
                agentEmails.Remove(agentEmails.Length - 1);
            }
            return agentEmails;
        }

        protected void BtnUpdateClick(object sender, EventArgs e)
        {
            int expectedNumRegistrants = 0;

            string agentEmails = string.Empty;
            string updatedEventID = ddlEvents.SelectedValue;

            agentEmails = joinAgentEmails(tbxAgentEmail.Text);

            if (tbxNumRegistrants.Text != "")
            {
                expectedNumRegistrants = Convert.ToInt32(tbxNumRegistrants.Text);
            }

            _objEvent.UpdateEvent(ddlEvents.SelectedValue.ToString(CultureInfo.InvariantCulture), tbxEventTitle.Text, tbxEventHeader.Content, tbxEvent2.Content, agentEmails, tbxEventDateFrom.Text, tbxDateEventTo.Text, expectedNumRegistrants);
            //ddlEvents.SelectedValue = "0";
            btnSave.Visible = false;
            btnUpdate.Visible = true;

            ddlEvents.Items.Clear();
            ddlEvents.Items.Add(new ListItem("-New Event-", "0"));
            ddlEvents.DataBind();
            ddlEvents.SelectedValue = updatedEventID;

            lblDisplayMessages.Text = "Event Updated";
            dvSystemMessages.Visible = true;
            dvErrorMEssages.Visible = false;
        }

        protected void BtnGenerateHtmlClick(object sender, EventArgs e)
        {
            
        }



        protected void DdlEventsSelectedIndexChanged(object sender, EventArgs e)
        {
            

            if (ddlEvents.SelectedValue == "0")
            {
                tbxAgentEmail.Text = "";
                tbxEventHeader.Content = "";
                tbxEvent2.Content = "";
                tbxEventDateFrom.Text = "";
                tbxDateEventTo.Text = "";
                tbxEventTitle.Text = "";
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                tbxNumRegistrants.Text = "";

            }
            else
            {
                btnSave.Visible = false;
                btnUpdate.Visible = true;
                tbxAgentEmail.Text = "";

                //lblNumRegistrants.Text = _objEvent.getNumRegistrants(ddlEvents.SelectedValue).ToString();
                var dtEvent = _objEvent.GetEventData(ddlEvents.SelectedValue);

                foreach (DataRow row in dtEvent.Rows)
                {

                    tbxEventHeader.Content = row["evt_HeaderHTML"].ToString();
                    tbxEvent2.Content = row["evt_HTML"].ToString();
                    tbxEventTitle.Text = row["evt_Name"].ToString();
                    tbxEventDateFrom.Text = row["evt_DateFrom"].ToString();
                    tbxDateEventTo.Text = row["evt_DateTo"].ToString();
                    tbxNumRegistrants.Text = row["evt_ExpectedNumRegistrants"].ToString();

                    string[] words = row["evt_Agent"].ToString().Split(';');

                    foreach (string word in words)
                    {
                        if (word != "")
                        {
                            tbxAgentEmail.Text += word + Environment.NewLine;
                        }
                    }

                    hypViewEvent.NavigateUrl = ConfigurationManager.AppSettings["siteURL"] +
                                               "Registration/Register.aspx?evt=" + row["evt_GUID"];
                }
            }
        }

        protected void BtnDeleteClick(object sender, EventArgs e)
        {
            _objEvent.DeleteEvent(int.Parse(ddlEvents.SelectedValue));
            lblDisplayMessages.Text = "Event deleted";
            dvSystemMessages.Visible = true;

        }
    }
}