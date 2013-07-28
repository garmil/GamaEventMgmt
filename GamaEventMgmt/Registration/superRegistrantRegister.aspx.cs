using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Gama;
using System.Configuration;
using Gama.CommonMethods;
using System.Text;

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
            string randomString = Users.RandomString();
            StringBuilder mailBody = new StringBuilder();
            mailBody.Append("Hello<br><br> Please click on the link below to verify your email address:<br><br>" + ConfigurationManager.AppSettings["siteURL"].ToString() + "GamaAdmin//verifyUser.aspx?verNum="+randomString+"&email="+tbxSuperRegEmail.Text);

            _CommonMethods.sendGeneralEmail(tbxSuperRegEmail.Text, mailBody.ToString(), "Super USer Registration");
            objUser.insertUser(tbxSuperRegName.Text, tbxSuperRegSurName.Text, tbxPassword.Text, tbxSuperRegEmail.Text, ConfigurationManager.AppSettings["superRegUserType"].ToString(), randomString);
            
            Response.Redirect("~/login.aspx?superReg=true&email="+tbxSuperRegEmail.Text, true);
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

        protected void btnRegister_Click1(object sender, EventArgs e)
        {

        }
    }
}