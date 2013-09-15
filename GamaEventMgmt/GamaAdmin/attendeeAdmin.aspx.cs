using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Gama;

namespace GamaEventMgmt.GamaAdmin
{
    public partial class attendeeAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            odsRegistrants.DataBind();
        }

        protected void ddlRegistrants_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObjectDataSourceEvents.DataBind();
           

        }

        protected void gvwAttendeeEvents_OnDataBound(object sender, EventArgs e)
        {
            
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow  row in gvwAttendeeEvents.Rows)
            {
                var attendee = new Attendee();
                if(((CheckBox) row.Cells[2].FindControl("chkYourCheckBoxField")).Checked)
                {
                    var key = gvwAttendeeEvents.DataKeys[row.RowIndex];
                    attendee.RemovefromEvent(key.Value.ToString());
                }
            }
            gvwAttendeeEvents.DataBind();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        { var attendee = new Attendee();
            foreach (GridViewRow row in gvwAttendeeEvents.Rows)
            {


                var key = gvwAttendeeEvents.DataKeys[row.RowIndex];
                    attendee.RemovefromEvent(key.Value.ToString());
           
            }

            attendee.RemoveAtendee(ddlRegistrants.SelectedItem.Value);
            gvwAttendeeEvents.DataBind();
        }

       
    }
}