using Gama.CommonMethods;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GamaEventMgmt.EventMgmt
{
    public partial class eventInvitation : System.Web.UI.Page
    {
        string fileName = string.Empty;
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
            }
        }

        protected void btnSendMail_Click(object sender, EventArgs e)
        {
            fileName = hdfFileName.Value;
            string email = string.Empty;
            string htmlBody = tbxEmailBody.Text;
            string subject = "Event invitation";

            foreach (string line in File.ReadLines(fileName))
            {
                email = line;

                _CommonMethods.sendGeneralEmail(email, htmlBody, subject);
            }
        }
    }
}