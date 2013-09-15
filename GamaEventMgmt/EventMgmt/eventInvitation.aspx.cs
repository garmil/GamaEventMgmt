using System.Data;
using Gama.CommonMethods;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Gama;

namespace GamaEventMgmt.EventMgmt
{
    public partial class eventInvitation : System.Web.UI.Page
    {
        string fileName = string.Empty;
        Event objEvent = new Event();
        Attendee objAttendee = new Attendee();
        //DataTable dtMailRecipients = new DataTable();
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

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (this.fupRecipients.HasFile)
            {
                this.fupRecipients.SaveAs(ConfigurationManager.AppSettings["gamaUploads"] + this.fupRecipients.FileName);
                hdfFileName.Value = ConfigurationManager.AppSettings["gamaUploads"] + this.fupRecipients.FileName;

                
                //dtMailRecipients.Columns.Add("Recipient");

                foreach (string line in File.ReadLines(hdfFileName.Value))
                {
                    tbxRecipients.Text += line + Environment.NewLine;

                    //DataRow dr = dtMailRecipients.NewRow();
                    //dr["Recipient"] = line;
                    //dtMailRecipients.Rows.Add(dr);
                }

                //gvwRecepients.DataSource = dtMailRecipients;
                //gvwRecepients.DataBind();

            }

            

            lblDisplayMessages.Text = "File upload complete";
            dvSystemMessages.Visible = true;
        }

        protected void btnSendMail_Click(object sender, EventArgs e)
        {
            fileName = hdfFileName.Value;
            string email = string.Empty;
            string htmlBody = tbxEmailBody.Text;
            string eventGuid = objEvent.GetEventGuid(ddlEvent.SelectedValue.ToString());
            const string subject = "Event invitation";
            string atn_guid = string.Empty;
            string emailStatus = string.Empty;
            string link = string.Empty;
            
            htmlBody += "<br>Please click this link to view the event: ";

            if (tbxRecipients.Text != "")
            {

                string txt = tbxRecipients.Text;
                string[] lst = txt.Split(new Char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string line in lst)
                {
                    email = line;
                    atn_guid = objAttendee.getAttendeeGUIDfromEmail(email);
                    if (atn_guid != "")
                    {
                        link = "<a href='" + ConfigurationManager.AppSettings["siteURL"] + "EventMgmt/eventView.aspx?evt=" + eventGuid + "&amp;atn=" + atn_guid + "'>View Event</a>";
                        emailStatus = _CommonMethods.sendGeneralEmail(email, htmlBody + link, subject);
                    }
                    else
                    {
                        link = "<a href='" + ConfigurationManager.AppSettings["siteURL"] + "EventMgmt/eventView.aspx?evt=" + eventGuid + "'>View Event</a>";
                        emailStatus = _CommonMethods.sendGeneralEmail(email, htmlBody + link, subject);
                    }
                }

                if (emailStatus != string.Empty)
                {
                    lblError.Text = emailStatus;
                    dvErrorMEssages.Visible = true;
                }
                else
                {
                    lblDisplayMessages.Text = "Invitations sent";
                    dvSystemMessages.Visible = true;
                }
                
            }
            else
            {


                foreach (string line in File.ReadLines(fileName))
                {
                    email = line;
                    atn_guid = objAttendee.getAttendeeGUIDfromEmail(email);
                    if (atn_guid != "")
                    {
                        emailStatus = _CommonMethods.sendGeneralEmail(email, htmlBody + "&atn=" + atn_guid, subject);
                    }
                    else
                    {
                        emailStatus = _CommonMethods.sendGeneralEmail(email, htmlBody, subject);
                    }
                }

                if (emailStatus != string.Empty)
                {
                    lblError.Text = emailStatus;
                    dvErrorMEssages.Visible = true;
                }
                else
                {
                    lblDisplayMessages.Text = "Invitations sent";
                    dvSystemMessages.Visible = true;
                }
            }
        }

        protected void gvwRecepients_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            
        }
    }
}