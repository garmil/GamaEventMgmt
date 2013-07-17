using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Gama;
using System.Collections;
using System.Configuration;
using Gama.CommonMethods;

namespace GamaEventMgmt.Registration
{
      
    public partial class Register : System.Web.UI.Page
    {
        Attendee objAttendee = new Attendee();
        Event objEvent = new Event();
        string eventGUID = string.Empty;
        string atnGUID = string.Empty;
        int atn_id = 0;
        int evt_id = 0;
        int attendeeStatus = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (Request.QueryString["evt"] != null)
            {
                eventGUID = Request.QueryString["evt"].ToString();
                evt_id = objEvent.getEventId(eventGUID);
                Session["eventGUID"] = eventGUID;
            }

            if (Request.QueryString["atn"] != null)
            {
                atnGUID = Request.QueryString["atn"].ToString();
                atn_id = objAttendee.getAttendeeID(atnGUID);
                attendeeStatus = objAttendee.getAttendeeStatus(atn_id, evt_id);

                Session["atn_id"] = atn_id;

                if (attendeeStatus != Convert.ToInt32(ConfigurationManager.AppSettings["statusRegistered"].ToString()))
                {
                    dvWarningMessages.Visible = false;
                    if (!IsPostBack)
                    {
                        populateAttendeeData(atn_id);
                        populateAddressData(atn_id);
                        populateGeneralInfo(atn_id);


                    }
                    btnUpdate.Visible = true;
                    btnUpdateAddBusInfo.Visible = true;
                    btnSaveContinuePersInfo.Text = "Update and Continue";
                    btnSaveContinueGenReqs.Text = "Update and Continue";

                    btnSaveNextBusInfo.Visible = false;
                    btnSaveNextAddBusInfo.Visible = false;
                }
                else
                {
                    tbcRegistration.Enabled = false;
                    lblWarningMessages.Text = "Attendee already registered for this event";
                    dvWarningMessages.Visible = true;
                }
            }
            //else if (Session["atn_id"] != null)
            //{
            //    populateAttendeeData(Convert.ToInt32(Session["atn_id"].ToString()));
            //}

            if (!IsPostBack)
            {
                FillAttendeeCityEventGrid();
                FillAdditionalAttendeeMemberGrid();
            }
            
        }

        private void populateMealInfo(int atn_id)
        {
            Hashtable hs = new Hashtable();

            DataTable dtMealInfo = objAttendee.getAttendeeMealInfo(atn_id);
            foreach (DataRow row in dtMealInfo.Rows)
            {
                hs.Add(row["mrq_id"].ToString(), row["mrq_Meal"].ToString()); 
            }
            
            for (int i = 0; i < cblMealReqs.Items.Count; i++)
            {

                if (hs.ContainsKey(cblMealReqs.Items[i].Value))
                {
                    cblMealReqs.Items.FindByValue(cblMealReqs.Items[i].Value).Selected = true;
                }
            }
        }

        private void populateGeneralInfo(int atn_id)
        {
            DataTable dtAttendeeAddress = objAttendee.getGeneralInfo(atn_id);
            foreach (DataRow row in dtAttendeeAddress.Rows)
            {
                cblSeatingPref.SelectedValue = row["atn_SeatingPref"].ToString();
                tbxDisabilityComment.Text = row["atn_DisabilityRequirements"].ToString();
                ddlClassOfService.SelectedValue = row["atn_ClassOfService"].ToString();
            }
        }

        private void populateAddressData(int atn_id)
        {
            DataTable dtAttendeeAddress = objAttendee.getAttendeeAddress(atn_id);
            foreach (DataRow row in dtAttendeeAddress.Rows)
            {
                tbxStreetAddress1.Text = row["ata_AddressLine1"].ToString();
                tbxStreetAddress2.Text = row["ata_AddressLine2"].ToString();
                tbxStreetAddress3.Text = row["ata_AddressLine3"].ToString();
                tbxCity.Text = row["ata_City"].ToString();
                tbxStateProvince.Text = row["ata_State_Province"].ToString();
                ddlCountry.SelectedValue = row["cnt_id"].ToString();
                tbxZip.Text = row["ata_Zip"].ToString();
                tbxBusPhone.Text = row["ata_BusinessPhone"].ToString();
                tbxBusFax.Text = row["ata_BusinessFax"].ToString();
            }
        }

        private void populateAttendeeData(int atn_id)
        {
            DataTable dtAttendee = objAttendee.getAttendeeData(atn_id);
            foreach (DataRow row in dtAttendee.Rows)
            {
                ddlTitle.SelectedValue = row["atn_Title"].ToString();
                tbxLastName.Text = row["atn_Surname"].ToString();
                tbxFirstName.Text = row["atn_Name"].ToString();
                tbxMiddleName.Text = row["atn_MiddleName"].ToString();
                tbxBusEmailAddress.Text = row["atn_Email"].ToString();
                tbxConfBusEmailAddress.Text = row["atn_Email"].ToString();
                tbxLegalName.Text = row["atn_LegalName"].ToString();
                tbxDateOfBirth.Text = row["atn_DateofBirth"].ToString();
                tbxPassportIdNum.Text = row["atn_Passport_IdNum"].ToString();
                tbxPlaceofBirth.Text = row["atn_PlaceOfBirth"].ToString();
                tbxPlaceofIssue.Text = row["atn_PlaceOfIssue"].ToString();
                tbxDateofIssue.Text = row["atn_PassportDateOfIssue"].ToString();
                tbxExpirationDate.Text = row["atn_PassportExpDate"].ToString();
                tbxStreetAddress1.Text = row["ata_AddressLine1"].ToString();
                tbxStreetAddress2.Text = row["ata_AddressLine2"].ToString();
                tbxStreetAddress3.Text = row["ata_AddressLine3"].ToString();
                tbxCity.Text = row["ata_City"].ToString();
                tbxStateProvince.Text = row["ata_State_Province"].ToString();
                ddlCountry.SelectedValue = row["cnt_id"].ToString();
                //tbxZip.Text = row[""].ToString();
                tbxBusPhone.Text = row["ata_BusinessPhone"].ToString();
                tbxBusFax.Text = row["ata_BusinessFax"].ToString();
                tbxHomePhoneNumber.Text = row["atn_HomePhoneNum"].ToString();
                tbxCellPhone.Text = row["atn_CellNum"].ToString();
                tbxAltEmailAddress.Text = row["atn_AlternateEmailAddress"].ToString();
                tbxConfAltEmailAddress.Text = row["atn_AlternateEmailAddress"].ToString();
                tbxEmergContactName.Text = row["atn_EmergencyContactName"].ToString();
                tbxEmergContPhoneNum.Text = row["atn_EmergencyContactNum"].ToString();

            }

        }

        private void FillAttendeeCityEventGrid()
        {
            DataTable dtAttendeeCity = objAttendee.getAttendeeEventCityAirport(atn_id, evt_id);

            if (dtAttendeeCity.Rows.Count > 0)
            {
                gvwCityAirport.DataSource = dtAttendeeCity;
                gvwCityAirport.DataBind();
            }
            else
            {
                dtAttendeeCity.Rows.Add(dtAttendeeCity.NewRow());
                gvwCityAirport.DataSource = dtAttendeeCity;
                gvwCityAirport.DataBind();

                int TotalColumns = gvwCityAirport.Rows[0].Cells.Count;
                gvwCityAirport.Rows[0].Cells.Clear();
                gvwCityAirport.Rows[0].Cells.Add(new TableCell());
                gvwCityAirport.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                gvwCityAirport.Rows[0].Cells[0].Text = "No Records";
            }
        }

        private void FillAdditionalAttendeeMemberGrid()
        {
            int attendeeID = 0;
            if (Session["atn_id"] != null)
            {
                attendeeID = Convert.ToInt32(Session["atn_id"].ToString());
            }

            DataTable dtAdditionalMember = objAttendee.getAllAdditionalAttendees(attendeeID);

            if (dtAdditionalMember.Rows.Count > 0)
            {
                gvwAddTravellers.DataSource = dtAdditionalMember;
                gvwAddTravellers.DataBind();
            }
            else
            {
                dtAdditionalMember.Rows.Add(dtAdditionalMember.NewRow());
                gvwAddTravellers.DataSource = dtAdditionalMember;
                gvwAddTravellers.DataBind();

                int TotalColumns = gvwAddTravellers.Rows[0].Cells.Count;
                gvwAddTravellers.Rows[0].Cells.Clear();
                gvwAddTravellers.Rows[0].Cells.Add(new TableCell());
                gvwAddTravellers.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                gvwAddTravellers.Rows[0].Cells[0].Text = "No Records";
            }
        }


        protected void btnSaveNextBusInfo_Click(object sender, EventArgs e)
        {
            Session["atn_id"] = objAttendee.insertAttendee(ddlTitle.SelectedValue.ToString(), tbxFirstName.Text, tbxMiddleName.Text, tbxLastName.Text, tbxBusEmailAddress.Text, tbxLegalName.Text, tbxDateOfBirth.Text, tbxPassportIdNum.Text, tbxPlaceofBirth.Text, tbxPlaceofIssue.Text, tbxDateofIssue.Text, tbxExpirationDate.Text);
            
            

            tbcRegistration.ActiveTabIndex +=1;
        }
        
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            objAttendee.updateAttendee(atn_id.ToString(), ddlTitle.SelectedValue.ToString(), tbxFirstName.Text, tbxMiddleName.Text, tbxLastName.Text, tbxBusEmailAddress.Text, tbxLegalName.Text, tbxDateOfBirth.Text, tbxPassportIdNum.Text, tbxPlaceofBirth.Text, tbxPlaceofIssue.Text, tbxDateofIssue.Text, tbxExpirationDate.Text);
        }

        protected void btnSaveNextAddBusInfo_Click(object sender, EventArgs e)
        {
            objAttendee.insertAttendeeAddress(1, Convert.ToInt32(Session["atn_id"].ToString()), tbxStreetAddress1.Text, tbxStreetAddress2.Text, tbxStreetAddress3.Text, tbxCity.Text, tbxStateProvince.Text, Convert.ToInt32(ddlCountry.SelectedValue.ToString()), tbxZip.Text, tbxBusPhone.Text, tbxBusFax.Text);


            tbcRegistration.ActiveTabIndex += 1;
        }

        protected void btnUpdateAddBusInfo_Click(object sender, EventArgs e)
        {
            objAttendee.upAttendeeAddress(1, atn_id, tbxStreetAddress1.Text, tbxStreetAddress2.Text, tbxStreetAddress3.Text, tbxCity.Text, tbxStateProvince.Text, Convert.ToInt32(ddlCountry.SelectedValue.ToString()), tbxZip.Text, tbxBusPhone.Text, tbxBusFax.Text);
            tbcRegistration.ActiveTabIndex += 1;
        }

        protected void btnSaveContinuePersInfo_Click(object sender, EventArgs e)
        {
            objAttendee.updatePersonalInfo(atn_id, tbxHomePhoneNumber.Text, tbxCellPhone.Text, tbxAltEmailAddress.Text, tbxEmergContactName.Text, tbxEmergContPhoneNum.Text);
            tbcRegistration.ActiveTabIndex += 1;
        }

        protected void btnSaveContinueGenReqs_Click(object sender, EventArgs e)
        {
            objAttendee.updateGeneralInfo(atn_id, ddlClassOfService.SelectedValue.ToString(), cblSeatingPref.SelectedValue.ToString(), tbxDisabilityComment.Text);
            tbcRegistration.ActiveTabIndex += 1;
        }

        protected void btnSaveContinueAirportCity_Click(object sender, EventArgs e)
        {
            tbcRegistration.ActiveTabIndex += 1;
        }

        protected void btnPrefFlight_Click(object sender, EventArgs e)
        {
            tbcRegistration.ActiveTabIndex += 1;
        }

        protected void btnPrefAirline_Click(object sender, EventArgs e)
        {
            tbcRegistration.ActiveTabIndex += 1;
        }

        protected void btnSaveContinueMealInfo_Click(object sender, EventArgs e)
        {
            tbcRegistration.ActiveTabIndex += 1;
        }

        protected void btnSaveContinueVisaCheck_Click(object sender, EventArgs e)
        {
            tbcRegistration.ActiveTabIndex += 1;
        }

        protected void btnAdditionalTrav_Click(object sender, EventArgs e)
        {
            tbcRegistration.ActiveTabIndex += 1;
        }

        protected void btnSaveContinueVisaInfo_Click(object sender, EventArgs e)
        {

        }

        protected void btnSaveContinueAirlineMem_Click(object sender, EventArgs e)
        {
            objAttendee.insertAttendeeAirlineMembership(Convert.ToInt32(Session["atn_id"].ToString()), tbxAirlineNameOrCode.Text, tbxAirlineMemNumber.Text);
            gvwAirlineMemNumber.DataBind();
            tbcRegistration.ActiveTabIndex += 1;
        }

        protected void gvwCityAirport_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvwCityAirport.EditIndex = -1;
            FillAttendeeCityEventGrid();
        }

        protected void gvwCityAirport_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gvwCityAirport_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvwCityAirport.EditIndex = e.NewEditIndex;
            FillAttendeeCityEventGrid();
        }

        protected void gvwCityAirport_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            TextBox tbxEditDepartCity = (TextBox)gvwCityAirport.Rows[e.RowIndex].FindControl("tbxEditDepartCity");
            TextBox tbxEditDepartAirport = (TextBox)gvwCityAirport.Rows[e.RowIndex].FindControl("tbxEditDepartAirport");
            TextBox tbxEditDepartDate = (TextBox)gvwCityAirport.Rows[e.RowIndex].FindControl("tbxEditDepartDate");
            TextBox tbxEditDepartTime = (TextBox)gvwCityAirport.Rows[e.RowIndex].FindControl("tbxEditDepartTime");
            TextBox tbxEditArrDate = (TextBox)gvwCityAirport.Rows[e.RowIndex].FindControl("tbxEditArrDate");
            TextBox tbxEditArrTime = (TextBox)gvwCityAirport.Rows[e.RowIndex].FindControl("tbxEditArrTime");
            TextBox tbxEditPrefAirline = (TextBox)gvwCityAirport.Rows[e.RowIndex].FindControl("tbxEditPrefAirline");
            TextBox tbxEditPrefFlightNum = (TextBox)gvwCityAirport.Rows[e.RowIndex].FindControl("tbxEditPrefFlightNum");

            objAttendee.updateAttendeeEventCityAirport(Convert.ToInt32(gvwCityAirport.DataKeys[e.RowIndex].Values[0].ToString()), tbxEditDepartCity.Text, tbxEditDepartAirport.Text, tbxEditArrDate.Text, tbxEditArrTime.Text, tbxEditDepartDate.Text, tbxEditDepartTime.Text, tbxEditPrefAirline.Text, tbxEditPrefFlightNum.Text);
            gvwCityAirport.EditIndex = -1;
            FillAttendeeCityEventGrid();
        }

        protected void gvwCityAirport_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AddNew"))
            {
                TextBox tbxNewDepartCity = (TextBox)gvwCityAirport.FooterRow.FindControl("tbxNewDepartCity");
                TextBox tbxNewDepartAirport = (TextBox)gvwCityAirport.FooterRow.FindControl("tbxNewDepartAirport");
                TextBox tbxNewArrDate = (TextBox)gvwCityAirport.FooterRow.FindControl("tbxNewArrDate");
                TextBox tbxNewArrTime = (TextBox)gvwCityAirport.FooterRow.FindControl("tbxNewArrTime");
                TextBox tbxNewDepartDate = (TextBox)gvwCityAirport.FooterRow.FindControl("tbxNewDepartDate");
                TextBox tbxNewDepartTime = (TextBox)gvwCityAirport.FooterRow.FindControl("tbxNewDepartTime");
                TextBox tbxNewPrefAirline = (TextBox)gvwCityAirport.FooterRow.FindControl("tbxNewPrefAirline");
                TextBox tbxNewPrefFlightNum = (TextBox)gvwCityAirport.FooterRow.FindControl("tbxNewPrefFlightNum");

                objAttendee.insertAttendeeEventCityAirport(Convert.ToInt32(Session["atn_id"].ToString()), evt_id, tbxNewDepartCity.Text, tbxNewDepartAirport.Text, tbxNewArrDate.Text, tbxNewArrTime.Text, tbxNewDepartDate.Text, tbxNewDepartTime.Text, tbxNewPrefAirline.Text, tbxNewPrefFlightNum.Text);
                FillAttendeeCityEventGrid();
            }
        }

        protected void gvwCityAirport_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            objAttendee.deleteAttendeeEventCityAirport(Convert.ToInt32(gvwCityAirport.DataKeys[e.RowIndex].Values[0].ToString()));
            FillAttendeeCityEventGrid();
        }

        protected void gvwCityAirport_Init(object sender, EventArgs e)
        {

        }

        protected void gvwAirlineMemNumber_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnSaveAirline_Click(object sender, EventArgs e)
        {
            objAttendee.insertAttendeeAirlineMembership(Convert.ToInt32(Session["atn_id"].ToString()), tbxAirlineNameOrCode.Text, tbxAirlineMemNumber.Text);
            gvwAirlineMemNumber.DataBind();
        }

       

        protected void gvwAirlineMemNumber_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("SelectRecord"))
            {
                int row = Int32.Parse(e.CommandArgument.ToString());
                
                Label lblAirlineMemberNum = (Label)gvwAirlineMemNumber.Rows[row].FindControl("lblAirlineMemberNum");
                Label lblAirlineName = (Label)gvwAirlineMemNumber.Rows[row].FindControl("lblAirlineName");

                tbxAirlineNameOrCode.Text = lblAirlineName.Text;
                tbxAirlineMemNumber.Text = lblAirlineMemberNum.Text;
                hdf_alm_id.Value = gvwAirlineMemNumber.DataKeys[row].Values[0].ToString();

                btnSaveAirline.Visible = false;
                btnUpdateAirline.Visible = true;
            }

        }

        protected void btnUpdateAirline_Click(object sender, EventArgs e)
        {
            objAttendee.updateAttendeeAirlineMembership(Convert.ToInt32(hdf_alm_id.Value), tbxAirlineNameOrCode.Text, tbxAirlineMemNumber.Text);
            btnUpdateAirline.Visible = false;
            btnSaveAirline.Visible = true;
            tbxAirlineNameOrCode.Text = "";
            tbxAirlineMemNumber.Text = "";

            
            gvwAirlineMemNumber.DataBind();

        }

        protected void btnSaveMealReq_Click(object sender, EventArgs e)
        {
            objAttendee.deleteMealRequirements(1);

            ArrayList arlMealReqs = new ArrayList();

            foreach (ListItem item in this.cblMealReqs.Items)
            {
                if (item.Selected)
                {
                    arlMealReqs.Add(item.Value);
                }
            }

            objAttendee.insertAttendeeMealRequirement(Convert.ToInt32(Session["atn_id"].ToString()), arlMealReqs, tbxAllergies.Text);
        }

        protected void btnSaveCitizenship_Click(object sender, EventArgs e)
        {
            objAttendee.insertCitizenship(Convert.ToInt32(Session["atn_id"].ToString()), tbxCitizenship.Text);
            gvwCitizenship.DataBind();

        }

        protected void gvwCitizenship_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("SelectRecord"))
            {
                int row = Int32.Parse(e.CommandArgument.ToString());

                Label lblCitizenship = (Label)gvwCitizenship.Rows[row].FindControl("lblCitizenship");
                tbxCitizenship.Text = lblCitizenship.Text;

                hdf_avr_id.Value = gvwCitizenship.DataKeys[row].Values[0].ToString();

                
                btnSaveCitizenship.Visible = false;
                btnUpdateZitizenship.Visible = true;
            }
        }

        protected void btnUpdateZitizenship_Click(object sender, EventArgs e)
        {

        }
        
        #region attendeeAdditionalMember
        protected void gvwAddTravellers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AddNew"))
            {
                TextBox tbxNewName = (TextBox)gvwAddTravellers.FooterRow.FindControl("tbxNewName");
                TextBox tbxNewSurname = (TextBox)gvwAddTravellers.FooterRow.FindControl("tbxNewSurname");
                TextBox tbxNewEmail = (TextBox)gvwAddTravellers.FooterRow.FindControl("tbxNewEmail");

                objAttendee.insertAdditionalAttendees(Convert.ToInt32(Session["atn_id"].ToString()), tbxNewName.Text, tbxNewSurname.Text, tbxNewEmail.Text);
                FillAdditionalAttendeeMemberGrid();
            }
        }

        protected void gvwAddTravellers_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvwAddTravellers.EditIndex = -1;
            FillAdditionalAttendeeMemberGrid();
        }

        protected void gvwAddTravellers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvwAddTravellers.EditIndex = e.NewEditIndex;
            FillAdditionalAttendeeMemberGrid();
        }

        protected void gvwAddTravellers_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            TextBox tbxEditName = (TextBox)gvwAddTravellers.Rows[e.RowIndex].FindControl("tbxEditName");
            TextBox tbxEditSurname = (TextBox)gvwAddTravellers.Rows[e.RowIndex].FindControl("tbxEditSurname");
            TextBox tbxEditEmail = (TextBox)gvwAddTravellers.Rows[e.RowIndex].FindControl("tbxEditEmail");
            int aam_id = Convert.ToInt32(gvwAddTravellers.DataKeys[e.RowIndex].Values[0].ToString());
            objAttendee.updateAdditionalAttendees(aam_id, tbxEditName.Text, tbxEditSurname.Text, tbxEditEmail.Text);
            gvwAddTravellers.EditIndex = -1;
            FillAdditionalAttendeeMemberGrid();
        }

        protected void gvwAddTravellers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int aam_id = Convert.ToInt32(gvwAddTravellers.DataKeys[e.RowIndex].Values[0].ToString());
            objAttendee.deleteAdditionalAttendees(aam_id);
            FillAdditionalAttendeeMemberGrid();
        }

        #endregion

        protected void btnRegistrationComplete_Click(object sender, EventArgs e)
        {
            objEvent.insertEventAttendeeStatus(atn_id, ConfigurationManager.AppSettings["statusRegistered"].ToString(), evt_id);

            lblDisplayMessages.Text = "Attendee registered. An email has been sent to the relevant agent";
            string agentEmail = objEvent.getEventAgent(evt_id);

            DataTable dtAttendee = objAttendee.getAttendeeData(atn_id);
            

            if (agentEmail != "")
            {
                _CommonMethods.sendGeneralEmail(agentEmail, dtAttendee, "Event Attendee Registration");
            }
            dvSystemMessages.Visible = true;

            tbcRegistration.Enabled = false;

        }

        protected void cblMealReqs_DataBound(object sender, EventArgs e)
        {
            populateMealInfo(atn_id);
        }

        

        

        
        
        #region AttendeeAddress

        #endregion
    }
}