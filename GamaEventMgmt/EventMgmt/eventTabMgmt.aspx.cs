using Gama;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GamaEventMgmt.EventMgmt
{
    public partial class eventTabMgmt : System.Web.UI.Page
    {
        TabFormMgmt objTab = new TabFormMgmt();

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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ArrayList arlTabSQL = new ArrayList();
            string sql = string.Empty;
            int visible = 0;

            foreach (ListItem item in cblTabs.Items)
            {
                if (item.Selected)
                {
                    visible = 1;
                }
                else
                {
                    visible = 0;
                }

                arlTabSQL.Add("INSERT INTO t_eventtabs_etb (evt_id, tbn_id, etb_Visible) VALUES (" + ddlEvents.SelectedValue.ToString() + "," + item.Value.ToString() + "," + visible + ");");
            }

            objTab.deleteUpdateEventTabs(ddlEvents.SelectedValue.ToString(), arlTabSQL);

            dvSystemMessages.Visible = true;
            lblDisplayMessages.Text = "Tabs saved";
        }

        protected void cblTabs_DataBound(object sender, EventArgs e)
        {

            DataTable dtSelectedTab = objTab.getEventViewableTabs(ddlEvents.SelectedValue.ToString());
            foreach (DataRow row in dtSelectedTab.Rows)
            {
                if (Convert.ToBoolean(row["etb_Visible"]) == true)
                {
                    cblTabs.Items[Convert.ToInt32(row["tbn_Index"])].Selected = true;
                }                
            }            
        }

        protected void ddlEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            cblTabs.DataBind();
        }
    }
}