using Gama;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GamaEventMgmt
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string currentPageFileName = new FileInfo(this.Request.Url.LocalPath).Name;
            
            HyperLink hypLogin = (HyperLink)Master.FindControl("hypLogin");
            hypLogin.Visible = false;

            if (Request.QueryString["superReg"] != null)
            {
                dvErrorMEssages.Visible = false;
                if (Request.QueryString["superReg"].ToString() == "true")
                {
                    dvSystemMessages.Visible = true;
                    lblDisplayMessages.Text = "Please check your email for the verification email. Clicking the link will verify your email address and activate your login.";
                }
            }

            if (Request.QueryString["ver"] != null)
            {
                if (Request.QueryString["ver"].ToString() == "true")
                {
                    dvSystemMessages.Visible = true;
                    lblDisplayMessages.Text = "You have succesfully registered. Please login below";
                }
            }

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Security objSecurity = new Security();
            DataTable dtLoginDetails = new DataTable();


            if (objSecurity.loginValid(tbxEmailAddress.Text, tbxPassword.Text))
            {
                Session["loggedIn"] = "true";

                dtLoginDetails = objSecurity.getLoginDetails(tbxEmailAddress.Text, tbxPassword.Text);
                Session["usr_id"] = dtLoginDetails.Rows[0]["usr_id"].ToString();
                Session["ust_id"] = dtLoginDetails.Rows[0]["ust_id"].ToString();
                Response.Redirect("Default.aspx", true);
            }
            else
            {
                dvSystemMessages.Visible = false;

                lblLoginStatus.Text = "Login Failed";
                dvErrorMEssages.Visible = true;
            }
        }
    }
}