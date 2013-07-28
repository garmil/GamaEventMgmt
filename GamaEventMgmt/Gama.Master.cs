using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GamaEventMgmt
{
    public partial class Gama : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["loggedIn"] != null && Session["loggedIn"].ToString() == "true")
            {
                hypLogin.Visible = false;
            }
            else
            {
                //ContentPlaceHolder cphNav = (ContentPlaceHolder)Master.FindControl("menu");
                //cphNav.Visible = false;
                menu.Visible = false;
                
            }
            

        }

        protected void lbtLogout_Click(object sender, EventArgs e)
        {
            Session.Remove("loggedIn");
            Session.Remove("usr_id");
            Session.Remove("ust_id");
            Session.Abandon();
        }
    }
}