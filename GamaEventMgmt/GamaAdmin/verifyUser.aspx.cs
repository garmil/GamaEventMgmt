using Gama;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GamaEventMgmt.GamaAdmin
{
    public partial class verifyUser : System.Web.UI.Page
    {
        Users objUser = new Users();
        Security objSec = new Security();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["verNum"] != null)
            {
                if (objSec.verifyEmail(Request.QueryString["verNum"].ToString(), Request.QueryString["email"]) != "")
                {
                    Response.Redirect("../login.aspx?ver=true");
                }
                else
                {
                    Response.Redirect("../login.aspx?ver=false");
                }
            }
        }
    }
}