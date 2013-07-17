using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Gama;
using System.Configuration;

namespace GamaEventMgmt.Registration
{
    public partial class superRegistrantRegister : System.Web.UI.Page
    {
        Users objUser = new Users();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            objUser.insertUser(tbxSuperRegName.Text, tbxSuperRegSurName.Text, tbxPassword.Text, tbxSuperRegEmail.Text, ConfigurationManager.AppSettings["superRegUserType"].ToString());
        }

        protected void btnOkay_Click(object sender, EventArgs e)
        {
            try
            {
                // code will go here
                
                ClientScript.RegisterStartupScript(this.GetType(),
                "onload", "onSuccess();", true);
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(),
                "onload", "onError();", true);
                
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/login.aspx", true);

        }
    }
}