using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Gama;

namespace GamaEventMgmt.GamaAdmin
{
    public partial class dbChanges : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loggedIn"] != null && Session["loggedIn"].ToString() == "true")
            {
               
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            _DataAccessLayer objDal = new _DataAccessLayer();

            string sql = tbxScriptChanges.Text;
            objDal.applyDBchange(sql);
        }
    }
}