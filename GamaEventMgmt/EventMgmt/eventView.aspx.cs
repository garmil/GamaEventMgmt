using System.Configuration;
using System.Web.UI.WebControls;
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
                ltrHTML.Text = objEvent.GenerateEventHtml(Request.QueryString["evt"], true);

                string atn_id = string.Empty;
                if (objEvent.eventActive(Request.QueryString["evt"]))
                {
                    
                    if (Request.QueryString["atn"] != null)
                    {
                        atn_id = "&atn=" + Request.QueryString["atn"];
                    }
                    hypRegisterFromEvtView.Visible = true;
                    hypRegisterFromEvtView.NavigateUrl = ConfigurationManager.AppSettings["siteURL"] +
                                                         "Registration/Register.aspx?evt="+Request.QueryString["evt"]+ atn_id;
                }
            }

            LinkButton lbtLogout = (LinkButton)Master.FindControl("lbtLogout");
            lbtLogout.Visible = false;
            
        }
    }
}