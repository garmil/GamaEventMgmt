using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Gama;
using System.Configuration;
using System.Text;
using Gama.CommonMethods;

namespace GamaEventMgmt.Registration
{
    public partial class registerSuperRegistrant : System.Web.UI.Page
    {
        Users objUser = new Users();        

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string randomString = Users.RandomString();
            StringBuilder mailBody = new StringBuilder();
            mailBody.Append("Hello<br><br> Please click on the link below to verify your email address:<br><br>" + ConfigurationManager.AppSettings["siteURL"].ToString() + "GamaAdmin//verifyUser.aspx?verNum=" + randomString + "&email=" + tbxSuperRegEmail.Text);

            _CommonMethods.sendGeneralEmail(tbxSuperRegEmail.Text, mailBody.ToString(), "Super User Registration");
            objUser.insertUser(tbxSuperRegName.Text, tbxSuperRegSurName.Text, tbxPassword.Text, tbxSuperRegEmail.Text, ConfigurationManager.AppSettings["superRegUserType"].ToString(), randomString);
            Response.Redirect("~/login.aspx?superReg=true&email=" + tbxSuperRegEmail.Text, true);

        }
    }
}