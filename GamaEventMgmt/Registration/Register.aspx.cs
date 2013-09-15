using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
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
        TabFormMgmt objTabs = new TabFormMgmt();
        AirportAirline objAirport = new AirportAirline();
        
        string eventGUID = string.Empty;
        string atnGUID = string.Empty;
        int atn_id = 0;
        int evt_id = 0;
        int attendeeStatus = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            //tbcRegistration.Tabs[0].Visible = false;
            //if (!Page.IsPostBack)
            //{
            //    fillGrids();
            //}

            if (Session["loggedIn"] != null && Session["loggedIn"].ToString() == "true")
            {
                HyperLink hypLogin = (HyperLink)Master.FindControl("hypLogin");
                hypLogin.Visible = false;
            }

            if (Request.QueryString["evt"] != null)
            {
                eventGUID = Request.QueryString["evt"].ToString();
                evt_id = objEvent.GetEventId(eventGUID);
                Session["eventGUID"] = eventGUID;

                string header = objEvent.GenerateEventHeader(Request.QueryString["evt"]);

                ltrHTML.Text = objEvent.GenerateEventHtml(Request.QueryString["evt"], true);
                ltrBusInfo.Text = header;
                ltrAddTrav.Text = header;
                ltrTravDetails.Text = header;
                ltrPrefs.Text = header;
                ltrVisaInfo.Text = header;
                ltrShirtSize.Text = header;

                if (!Page.IsPostBack)
                {
                    hideTabs();
                    
                }

                
                
                //processTabRules(evt_id);
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
                    //btnUpdateAddBusInfo.Visible = true;
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
                    btnRegisterForEvent.Visible = false;
                }
            }
            //else if (Session["atn_id"] != null)
            //{
            //    populateAttendeeData(Convert.ToInt32(Session["atn_id"].ToString()));
            //}

            //if (!IsPostBack)
            //{
            //    fillGrids();
            //}
            
        }

        private void hideTabs()
        {
            for (int i = 1; i < tbcRegistration.Tabs.Count; i++)
            {
                tbcRegistration.Tabs[i].Visible = false;
            }

            
        }

        private void showTabs()
        {
            for (int i = 1; i < tbcRegistration.Tabs.Count; i++)
            {
                tbcRegistration.Tabs[i].Visible = true;
            }

            fillGrids();
        }

        private void fillGrids()
        {
            FillAttendeeCityAirportGrid();
            FillAttendeeCityEventGrid();
            FillAdditionalAttendeeMemberGrid();
            FillPreferredAttendeeAirlineGrid();
            FillAirlineMembershipGrid();
        }


        private void processTabRules(int evt_id)
        {
            
            DataTable dtTabs = objTabs.getViewableEventTabs(evt_id.ToString());

            foreach (DataRow row in dtTabs.Rows)
            {
                if (Convert.ToInt32(row["etb_Visible"]) == 0)
                {
                    tbcRegistration.Tabs[Convert.ToInt32(row["tbn_Index"])].Visible = false;
                }
                else
                {
                    tbcRegistration.Tabs[Convert.ToInt32(row["tbn_Index"])].Visible = true;
                }
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
                hdfCountryId.Value = row["cnt_id"].ToString();
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
                //tbxPlaceofBirth.Text = row["atn_PlaceOfBirth"].ToString();
                tbxPlaceofIssue.Text = row["atn_PlaceOfIssue"].ToString();
                tbxStreetAddress1.Text = row["ata_AddressLine1"].ToString();
                tbxStreetAddress2.Text = row["ata_AddressLine2"].ToString();
                tbxStreetAddress3.Text = row["ata_AddressLine3"].ToString();
                tbxCity.Text = row["ata_City"].ToString();
                tbxStateProvince.Text = row["ata_State_Province"].ToString();
                //ddlCountry.SelectedValue = row["cnt_id"].ToString();
                //hdfCountryId.Value = row["cnt_id"].ToString();
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

        private void FillAirlineMembershipGrid()
        {
            int attendeeID = 0;
            if (Session["atn_id"] != null)
            {
                attendeeID = Convert.ToInt32(Session["atn_id"].ToString());
            }

            DataTable dtAirlineMembership = objAttendee.getAttendeeAirlineMembership(attendeeID);

            if (dtAirlineMembership.Rows.Count > 0)
            {
                gvwAirlineMembership.DataSource = dtAirlineMembership;
                gvwAirlineMembership.DataBind();
            }
            else
            {
                dtAirlineMembership.Rows.Add(dtAirlineMembership.NewRow());
                gvwAirlineMembership.DataSource = dtAirlineMembership;
                gvwAirlineMembership.DataBind();

                int TotalColumns = gvwAirlineMembership.Rows[0].Cells.Count;
                gvwAirlineMembership.Rows[0].Cells.Clear();
                gvwAirlineMembership.Rows[0].Cells.Add(new TableCell());
                gvwAirlineMembership.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                gvwAirlineMembership.Rows[0].Cells[0].Text = "No Record Found";
            }
        }


        private void FillAttendeeCityEventGrid()
        {
            int attendeeID = 0;
            if (Session["atn_id"] != null)
            {
                attendeeID = Convert.ToInt32(Session["atn_id"].ToString());
            }

            DataTable dtAttendeeCity = objAttendee.getAttendeeEventCityAirport(attendeeID, evt_id);

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

        private void FillPreferredAttendeeAirlineGrid()
        {
            int attendeeID = 0;
            if (Session["atn_id"] != null)
            {
                attendeeID = Convert.ToInt32(Session["atn_id"].ToString());
            }

            DataTable dtPrefAirline = objAirport.getAttendeePreferredAirline(attendeeID.ToString());

            if (dtPrefAirline.Rows.Count > 0)
            {

                gvwPreferredAirline.DataSource = dtPrefAirline;
                gvwPreferredAirline.DataBind();
            }
            else
            {
                dtPrefAirline.Rows.Add(dtPrefAirline.NewRow());
                gvwPreferredAirline.DataSource = dtPrefAirline;
                gvwPreferredAirline.DataBind();

                int TotalColumns = gvwPreferredAirline.Rows[0].Cells.Count;
                gvwPreferredAirline.Rows[0].Cells.Clear();
                gvwPreferredAirline.Rows[0].Cells.Add(new TableCell());
                gvwPreferredAirline.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                gvwPreferredAirline.Rows[0].Cells[0].Text = "No Records";
            }
        }

        private void FillAttendeeCityAirportGrid()
        {
            int attendeeID = 0;
            if (Session["atn_id"] != null)
            {
                attendeeID = Convert.ToInt32(Session["atn_id"].ToString());
            }

            DataTable dtAttendeeCity = objAttendee.getAttendeeEventCityAirport(attendeeID, evt_id);

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
            if (objAttendee.checkEventRegistrationByEmailAddress(tbxBusEmailAddress.Text, eventGUID) > 0 && tbxBusEmailAddress.Text != "garethmill@gmail.com"  )
            {
                dvWarningMessages.Visible = true;
                lblWarningMessages.Text = "The email address entered has already been registered for this event.";
            }
            else
            {

                dvWarningMessages.Visible = false;
                lblWarningMessages.Text = "";

                Session["atn_id"] = objAttendee.insertAttendee(ddlTitle.SelectedValue.ToString(), tbxFirstName.Text,
                                                               tbxMiddleName.Text, tbxLastName.Text,
                                                               tbxBusEmailAddress.Text, tbxLegalName.Text,
                                                               tbxDateOfBirth.Text, tbxPassportIdNum.Text, "",
                                                               tbxPlaceofIssue.Text, "1900/01/01", "1900/01/01");
                atn_id = Convert.ToInt32(Session["atn_id"]);

                if (tbxStreetAddress1.Text != "")
                {

                    if (objAttendee.checkAddressExists(atn_id,
                                                       Convert.ToInt32(ConfigurationManager.AppSettings["adtHome"])))
                    {
                        objAttendee.upAttendeeAddress(Convert.ToInt32(ConfigurationManager.AppSettings["adtHome"]),
                                                      atn_id,
                                                      tbxStreetAddress1.Text, tbxStreetAddress2.Text,
                                                      tbxStreetAddress3.Text,
                                                      tbxCity.Text, tbxStateProvince.Text,
                                                      Convert.ToInt32(ddlCountry.SelectedValue), tbxZip.Text,
                                                      tbxBusPhone.Text, tbxBusFax.Text);
                    }
                    else
                    {
                        objAttendee.insertAttendeeAddress(Convert.ToInt32(ConfigurationManager.AppSettings["adtHome"]),
                                                          atn_id,
                                                          tbxStreetAddress1.Text, tbxStreetAddress2.Text,
                                                          tbxStreetAddress3.Text,
                                                          tbxCity.Text, tbxStateProvince.Text,
                                                          Convert.ToInt32(ddlCountry.SelectedValue), tbxZip.Text,
                                                          tbxBusPhone.Text, tbxBusFax.Text);
                    }
                }
                objEvent.InsertEventAttendeeStatus(Convert.ToInt32(Session["atn_id"]),
                                                   ConfigurationManager.AppSettings["statusUnregistered"].ToString(),
                                                   evt_id);

                lblDisplayMessages.Text = "Business Info Saved";
                dvSystemMessages.Visible = true;
                CollapsiblePanelExtender2.Collapsed = true;
                CollapsiblePanelExtender2.ClientState = "true";
                CollapsiblePanelExtender3.Collapsed = false;
                CollapsiblePanelExtender3.ClientState = "false";

                btnRegistrationComplete.Visible = true;

            }

            fillGrids();


        }
        
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            objAttendee.updateAttendee(atn_id.ToString(), ddlTitle.SelectedValue.ToString(), tbxFirstName.Text, tbxMiddleName.Text, tbxLastName.Text, tbxBusEmailAddress.Text, tbxLegalName.Text, tbxDateOfBirth.Text, tbxPassportIdNum.Text, "", tbxPlaceofIssue.Text, "1900/01/01", "1900/01/01");
            objAttendee.upAttendeeAddress(Convert.ToInt32(ConfigurationManager.AppSettings["adtHome"]), atn_id, tbxStreetAddress1.Text, tbxStreetAddress2.Text, tbxStreetAddress3.Text, tbxCity.Text, tbxStateProvince.Text, Convert.ToInt32(ddlCountry.SelectedValue.ToString()), tbxZip.Text, tbxBusPhone.Text, tbxBusFax.Text);

            if (objEvent.getAttendeeEvent(Convert.ToInt32(Session["atn_id"]), evt_id) == 0)
            {
                objEvent.InsertEventAttendeeStatus(Convert.ToInt32(Session["atn_id"]), ConfigurationManager.AppSettings["statusUnregistered"].ToString(), evt_id);
            }
            
            lblDisplayMessages.Text = "Business Info Updated";
            dvSystemMessages.Visible = true;
            CollapsiblePanelExtender2.Collapsed = true;
            CollapsiblePanelExtender2.ClientState = "true";
            CollapsiblePanelExtender3.Collapsed = false;
            CollapsiblePanelExtender3.ClientState = "false";
        }

        protected void btnSaveNextAddBusInfo_Click(object sender, EventArgs e)
        {
            objAttendee.insertAttendeeAddress(Convert.ToInt32(ConfigurationManager.AppSettings["adtHome"].ToString()), Convert.ToInt32(Session["atn_id"].ToString()), tbxStreetAddress1.Text, tbxStreetAddress2.Text, tbxStreetAddress3.Text, tbxCity.Text, tbxStateProvince.Text, Convert.ToInt32(ddlCountry.SelectedValue.ToString()), tbxZip.Text, tbxBusPhone.Text, tbxBusFax.Text);
            atn_id = Convert.ToInt32(Session["atn_id"].ToString());
            skipToNextTab();
            //tbcRegistration.ActiveTabIndex += 1;
        }

        protected void btnUpdateAddBusInfo_Click(object sender, EventArgs e)
        {
            objAttendee.upAttendeeAddress(Convert.ToInt32(ConfigurationManager.AppSettings["adtHome"].ToString()), atn_id, tbxStreetAddress1.Text, tbxStreetAddress2.Text, tbxStreetAddress3.Text, tbxCity.Text, tbxStateProvince.Text, Convert.ToInt32(ddlCountry.SelectedValue.ToString()), tbxZip.Text, tbxBusPhone.Text, tbxBusFax.Text);
            skipToNextTab();
            //tbcRegistration.ActiveTabIndex += 1;
        }

        protected void btnSaveContinuePersInfo_Click(object sender, EventArgs e)
        {

            objAttendee.updatePersonalInfo(atn_id, tbxHomePhoneNumber.Text, tbxCellPhone.Text, tbxAltEmailAddress.Text, tbxEmergContactName.Text, tbxEmergContPhoneNum.Text);

            if (objEvent.getAttendeeEvent(Convert.ToInt32(Session["atn_id"]), evt_id) == 0)
            {
                objEvent.InsertEventAttendeeStatus(Convert.ToInt32(Session["atn_id"]), ConfigurationManager.AppSettings["statusUnregistered"].ToString(), evt_id);
            }

            lblDisplayMessages.Text = "Personal Info Saved";
            dvSystemMessages.Visible = true;

            skipToNextTab();
            //tbcRegistration.ActiveTabIndex += 1;
            fillGrids();
        }

        private void skipToNextTab()
        {
            bool nextTabVisibleTab = false;
            int nextTabIndex;
            nextTabIndex = tbcRegistration.ActiveTabIndex + 1;
            do
            {
                if (tbcRegistration.Tabs[nextTabIndex].Visible == true)
                {
                    //tbcRegistration.ActiveTabIndex = nextTabIndex;
                    tbcRegistration.ActiveTab = tbcRegistration.Tabs[nextTabIndex];
                    nextTabVisibleTab = true;
                }
                nextTabIndex++;

            } while (nextTabVisibleTab == false);
        }

        protected void btnSaveContinueGenReqs_Click(object sender, EventArgs e)
        {
            objAttendee.updateGeneralInfo(atn_id, ddlClassOfService.SelectedValue.ToString(), cblSeatingPref.SelectedValue.ToString(), tbxDisabilityComment.Text);
            skipToNextTab();
            //tbcRegistration.ActiveTabIndex += 1;
            fillGrids();
            lblDisplayMessages.Text = "General requirements saved";
            dvSystemMessages.Visible = true;
        }

        protected void btnSaveContinueAirportCity_Click(object sender, EventArgs e)
        {
            skipToNextTab();
            //tbcRegistration.ActiveTabIndex += 1;
            fillGrids();
        }

        protected void btnPrefFlight_Click(object sender, EventArgs e)
        {
            skipToNextTab();
            //tbcRegistration.ActiveTabIndex += 1;
        }

        protected void btnPrefAirline_Click(object sender, EventArgs e)
        {
            skipToNextTab();
            //tbcRegistration.ActiveTabIndex += 1;
        }

        protected void btnSaveContinueMealInfo_Click(object sender, EventArgs e)
        {
            skipToNextTab();
            //tbcRegistration.ActiveTabIndex += 1;
        }

        protected void btnSaveContinueVisaCheck_Click(object sender, EventArgs e)
        {
            skipToNextTab();
            //tbcRegistration.ActiveTabIndex += 1;
        }

        protected void btnAdditionalTrav_Click(object sender, EventArgs e)
        {
            dvSystemMessages.Visible = false;
            skipToNextTab();
            //tbcRegistration.ActiveTabIndex += 1;
            fillGrids();
        }

        protected void btnSaveContinueVisaInfo_Click(object sender, EventArgs e)
        {

        }

        //protected void btnSaveContinueAirlineMem_Click(object sender, EventArgs e)
        //{
        //    objAttendee.insertAttendeeAirlineMembership(Convert.ToInt32(Session["atn_id"].ToString()), tbxAirlineNameOrCode.Text, tbxAirlineMemNumber.Text);
        //    gvwAirlineMemNumber.DataBind();
        //    tbcRegistration.ActiveTabIndex += 1;
        //}

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
            int departAirportID = 0;
            TextBox tbxEditDepartCity = (TextBox)gvwCityAirport.Rows[e.RowIndex].FindControl("tbxEditDepartCity");
            TextBox tbxEditDepartAirport = (TextBox)gvwCityAirport.Rows[e.RowIndex].FindControl("tbxEditDepartAirport");
            TextBox tbxEditDepartDate = (TextBox)gvwCityAirport.Rows[e.RowIndex].FindControl("tbxEditDepartDate");
            DropDownList ddlEditDeptTime = (DropDownList)gvwCityAirport.Rows[e.RowIndex].FindControl("ddlEditDeptTime");
            TextBox tbxEditArrDate = (TextBox)gvwCityAirport.Rows[e.RowIndex].FindControl("tbxEditArrDate");
            DropDownList ddlEditArrTime = (DropDownList)gvwCityAirport.Rows[e.RowIndex].FindControl("ddlEditArrTime");
            //TextBox tbxEditPrefAirline = (TextBox)gvwCityAirport.Rows[e.RowIndex].FindControl("tbxEditPrefAirline");
            //TextBox tbxEditPrefFlightNum = (TextBox)gvwCityAirport.Rows[e.RowIndex].FindControl("tbxEditPrefFlightNum");

            departAirportID = objAirport.getDepartCityID(tbxEditDepartAirport.Text);

            objAttendee.updateAttendeeEventCityAirport(Convert.ToInt32(gvwCityAirport.DataKeys[e.RowIndex].Values[0].ToString()), tbxEditDepartCity.Text, departAirportID.ToString(), tbxEditArrDate.Text, ddlEditArrTime.SelectedValue, tbxEditDepartDate.Text, ddlEditDeptTime.SelectedValue);
            gvwCityAirport.EditIndex = -1;
            FillAttendeeCityEventGrid();
            lblDisplayMessages.Text = "Airport / City updated";
            dvSystemMessages.Visible = true;
        }

        protected void gvwCityAirport_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AddNew"))
            {
                int departAirportID = 0;
                TextBox tbxNewDepartCity = (TextBox)gvwCityAirport.FooterRow.FindControl("tbxNewDepartCity");
                
                TextBox tbxNewDepartAirport = (TextBox)gvwCityAirport.FooterRow.FindControl("tbxNewDepartAirport");
                departAirportID = objAirport.getDepartCityID(tbxNewDepartAirport.Text);
                TextBox tbxNewArrDate = (TextBox)gvwCityAirport.FooterRow.FindControl("tbxNewArrDate");
                DropDownList ddlNewArrTime = (DropDownList)gvwCityAirport.FooterRow.FindControl("ddlNewArrTime");
                TextBox tbxNewDepartDate = (TextBox)gvwCityAirport.FooterRow.FindControl("tbxNewDepartDate");
                DropDownList ddlNewDeptTime = (DropDownList)gvwCityAirport.FooterRow.FindControl("ddlNewDeptTime");
                //TextBox tbxNewPrefAirline = (TextBox)gvwCityAirport.FooterRow.FindControl("tbxNewPrefAirline");
                //TextBox tbxNewPrefFlightNum = (TextBox)gvwCityAirport.FooterRow.FindControl("tbxNewPrefFlightNum");

                objAttendee.insertAttendeeEventCityAirport(Convert.ToInt32(Session["atn_id"].ToString()), evt_id, tbxNewDepartCity.Text, departAirportID.ToString(), tbxNewArrDate.Text, ddlNewArrTime.SelectedValue, tbxNewDepartDate.Text, ddlNewDeptTime.SelectedValue);
                FillAttendeeCityEventGrid();
                lblDisplayMessages.Text = "Airport / City saved";
                dvSystemMessages.Visible = true;
            }
        }

        protected void gvwCityAirport_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            objAttendee.deleteAttendeeEventCityAirport(Convert.ToInt32(gvwCityAirport.DataKeys[e.RowIndex].Values[0].ToString()));
            FillAttendeeCityEventGrid();
            lblDisplayMessages.Text = "Airport / City deleted";
            dvSystemMessages.Visible = true;
        }

        protected void gvwCityAirport_Init(object sender, EventArgs e)
        {

        }

        protected void gvwAirlineMemNumber_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //protected void btnSaveAirline_Click(object sender, EventArgs e)
        //{
        //    objAttendee.insertAttendeeAirlineMembership(Convert.ToInt32(Session["atn_id"].ToString()), tbxAirlineNameOrCode.Text, tbxAirlineMemNumber.Text);
        //    gvwAirlineMemNumber.DataBind();
        //}

       

        protected void gvwAirlineMemNumber_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName.Equals("SelectRecord"))
            //{
            //    int row = Int32.Parse(e.CommandArgument.ToString());
                
            //    Label lblAirlineMemberNum = (Label)gvwAirlineMemNumber.Rows[row].FindControl("lblAirlineMemberNum");
            //    Label lblAirlineName = (Label)gvwAirlineMemNumber.Rows[row].FindControl("lblAirlineName");

            //    tbxAirlineNameOrCode.Text = lblAirlineName.Text;
            //    tbxAirlineMemNumber.Text = lblAirlineMemberNum.Text;
            //    hdf_alm_id.Value = gvwAirlineMemNumber.DataKeys[row].Values[0].ToString();

            //    btnSaveAirline.Visible = false;
            //    btnUpdateAirline.Visible = true;
            //}

        }

        //protected void btnUpdateAirline_Click(object sender, EventArgs e)
        //{
        //    objAttendee.updateAttendeeAirlineMembership(Convert.ToInt32(hdf_alm_id.Value), tbxAirlineNameOrCode.Text, tbxAirlineMemNumber.Text);
        //    btnUpdateAirline.Visible = false;
        //    btnSaveAirline.Visible = true;
        //    tbxAirlineNameOrCode.Text = "";
        //    tbxAirlineMemNumber.Text = "";

            
        //    gvwAirlineMemNumber.DataBind();

        //}

        protected void btnSaveMealReq_Click(object sender, EventArgs e)
        {
            objAttendee.deleteMealRequirements(atn_id);

            ArrayList arlMealReqs = new ArrayList();

            foreach (ListItem item in this.cblMealReqs.Items)
            {
                if (item.Selected)
                {
                    arlMealReqs.Add(item.Value);
                }
            }

            objAttendee.insertAttendeeMealRequirement(Convert.ToInt32(Session["atn_id"].ToString()), arlMealReqs, tbxAllergies.Text);
            
            fillGrids();
            lblDisplayMessages.Text = "Meal requirements saved";
            dvSystemMessages.Visible = true;
        }

        protected void btnSaveCitizenship_Click(object sender, EventArgs e)
        {
            if (Session["atn_id"] != null)
            {
                objAttendee.insertCitizenship(Convert.ToInt32(Session["atn_id"].ToString()),
                                              cmbCitizenship.SelectedItem.Text);
                gvwCitizenship.DataBind();
                lblDisplayMessages.Text = "Citizenship saved";
                dvSystemMessages.Visible = true;
            }
            else
            {
                lblWarningMessages.Text = "Registrant session not initiated";
                dvWarningMessages.Visible = true;
            }

        }

        protected void btnSaveVisaReqd_Click(object sender, EventArgs e)
        {
            objAttendee.insertCountryVisaReqd(Convert.ToInt32(Session["atn_id"].ToString()), cmbCitizenship.SelectedItem.Text);
            skipToNextTab();
            //tbcRegistration.ActiveTabIndex += 1;
            fillGrids();
        }

        protected void gvwCitizenship_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("SelectRecord"))
            {
                int row = Int32.Parse(e.CommandArgument.ToString());

                Label lblCitizenship = (Label)gvwCitizenship.Rows[row].FindControl("lblCitizenship");
                //tbxCitizenship.Text = lblCitizenship.Text;

                hdf_avr_id.Value = gvwCitizenship.DataKeys[row].Values[0].ToString();

                
                btnSaveCitizenship.Visible = false;
                btnUpdateZitizenship.Visible = true;
            }
        }

        protected void btnUpdateZitizenship_Click(object sender, EventArgs e)
        {
            lblDisplayMessages.Text = "Citizenship updated";
            dvSystemMessages.Visible = true;
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
                lblDisplayMessages.Text = tbxNewName.Text + " " + tbxNewSurname.Text + " saved";
                dvSystemMessages.Visible = true;
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
            lblDisplayMessages.Text = tbxEditName.Text + " " + tbxEditSurname.Text + " updated";
            dvSystemMessages.Visible = true;
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
            
            if (objEvent.getAttendeeEvent(Convert.ToInt32(Session["atn_id"]), evt_id) == 0)
            {
                objEvent.InsertEventAttendeeStatus(Convert.ToInt32(Session["atn_id"]), ConfigurationManager.AppSettings["statusUnregistered"].ToString(), evt_id);
            }

            objEvent.UpdateEventAttendeeStatus(Convert.ToInt32(Session["atn_id"]), ConfigurationManager.AppSettings["statusRegistered"].ToString(), evt_id);

            lblDisplayMessages.Text = "Attendee registered. An email has been sent to the relevant agent(s)";
            dvSystemMessages.Visible = true;
            string agentEmail = objEvent.GetEventAgent(evt_id);
            atn_id = Convert.ToInt32(Session["atn_id"]);
            string registrantEmail = objAttendee.getAttendeeEmail(atn_id);
            string eventName = string.Empty;
            string eventFormID = string.Empty;
            string attendeeName = string.Empty;
            DataTable dtEventData = new DataTable();
            
            DataTable dtAttendee = objAttendee.getAttendeeData(atn_id, evt_id);
            DataTable dtCityAirport = objAttendee.getAttendeeEventCityAirport(atn_id, evt_id);
            DataTable dtPrefFlight = objAirport.getAttendeePreferredAirline(atn_id.ToString());
            DataTable dtPreferences = objAttendee.getAttendeePreferences(atn_id.ToString());
            DataTable dtVisaCitizenship = objAttendee.getCitizenship(atn_id.ToString());
            string shirtSize = objAttendee.getShirtSize(atn_id.ToString());

            if (registrantEmail != "")
            {
                _CommonMethods.sendGeneralEmail(registrantEmail, dtAttendee, dtCityAirport, dtPrefFlight, dtPreferences, dtVisaCitizenship, shirtSize, "Event Attendee Registration");
                //_CommonMethods.sendAttendeeDataEmail(registrantEmail, dtAttendee, dtCityAirport, dtPrefFlight, "Event Attendee Registration");
            }

            //string attendantGUID = objAttendee.getAttendeeGUIDfromATN_Id(Convert.ToInt32(Session["atn_id"]));
            //string eventGUID = objEvent.GetEventGuid(evt_id.ToString());

            dtEventData = objEvent.GetEventData(evt_id.ToString());

            if (dtAttendee.Rows.Count > 0)
            {
                 for(int i=0; i < 1; i++)
                 {
                     attendeeName = dtAttendee.Rows[i]["atn_Surname"] + "/" + dtAttendee.Rows[i]["atn_Name"];
                 }
            }

            if (dtEventData.Rows.Count > 0)
            {
                for (int i = 0; i < 1; i++)
                {
                    eventName = dtEventData.Rows[i]["evt_Name"].ToString();
                    eventFormID = dtEventData.Rows[i]["evt_Form_ID"].ToString();
                }
            }


            if (agentEmail != "")
            {
                string[] emails = agentEmail.Split(';');
                string subject = string.Empty;
                foreach (string email in emails)
                {

                    if(email != "")
                    {
                        subject = "New registration form for group:" + eventName + ". Form ID:"+eventFormID+" for Passenger:" + attendeeName + " Status:Registered";

                        //_CommonMethods.sendGeneralEmail(email, dtAttendee, "Event Attendee Registration");
                        _CommonMethods.sendAttendeeDataEmail(email, dtAttendee, dtCityAirport, dtPrefFlight, subject);
                    }
                }
            }
            dvSystemMessages.Visible = true;

            tbcRegistration.Enabled = false;

            Response.Redirect("registrationCompleted.aspx", true);

        }

        protected void cblMealReqs_DataBound(object sender, EventArgs e)
        {
            populateMealInfo(atn_id);
        }

        protected void chkMultiReg_CheckedChanged(object sender, EventArgs e)
        {
            
            //if (chkMultiReg.Checked)
            //{
            //    if (Session["loggedIn"] == null)
            //    {
            //        Response.Redirect("registerSuperRegistrant.aspx", true);
            //    }
            //}
        }

        protected void btnRegisterForEvent_Click(object sender, EventArgs e)
        {
            //showTabs();
            processTabRules(evt_id);
            tbcRegistration.ActiveTabIndex += 1;
            
        }

        protected void btnSaveShirtSize_Click(object sender, EventArgs e)
        {
            objAttendee.updateAttendeeShirt(atn_id, ddlShirtSize.SelectedValue);
            
            //tbcRegistration.ActiveTabIndex += 1;
            fillGrids();
            lblDisplayMessages.Text = "Shirt size saved";
            dvSystemMessages.Visible = true;
        }

        protected void gvwPreferredAirline_DataBound(object sender, EventArgs e)
        {

        }

        protected void gvwPreferredAirline_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ComboBox cboEditAirline = (ComboBox)e.Row.FindControl("cboEditAirline");

                if (cboEditAirline != null)
                {
                    //cboEditAirline.DataSource = objAirport.GetAllAirlines();
                    //cboEditAirline.DataBind();
                    //cboEditAirline.SelectedValue = gvwPreferredAirline.DataKeys[e.Row.RowIndex].Values[1].ToString();
                }
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                //ComboBox cboNewAirline = (ComboBox)e.Row.FindControl("cboNewAirline");
                //cboNewAirline.DataSource = objAirport.GetAllAirlines();
                //cboNewAirline.DataBind();
            } 
        }

        protected void gvwPreferredAirline_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AddNew"))
            {
                int airlineID = 0;
                
                //ComboBox cboNewAirline = (ComboBox)gvwPreferredAirline.FooterRow.FindControl("cboNewAirline");
                TextBox tbxNewFlightNum = (TextBox) gvwPreferredAirline.FooterRow.FindControl("tbxNewFlightNum");
                TextBox tbxNewAirline = (TextBox) gvwPreferredAirline.FooterRow.FindControl("tbxNewAirline");

                airlineID = objAirport.getAirlineID(tbxNewAirline.Text);

                objAirport.insertAttendeePreferredAirline(Session["atn_id"].ToString(), airlineID.ToString(), tbxNewFlightNum.Text);
                FillPreferredAttendeeAirlineGrid();
                lblDisplayMessages.Text = "Preferred airline saved";
                dvSystemMessages.Visible = true;
            } 
        }

        protected void gvwPreferredAirline_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvwPreferredAirline.EditIndex = e.NewEditIndex;
            FillPreferredAttendeeAirlineGrid();
        }

        protected void gvwPreferredAirline_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvwPreferredAirline.EditIndex = -1;
            FillPreferredAttendeeAirlineGrid();
        }

        protected void gvwPreferredAirline_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int airlineID = 0;
            //ComboBox cboEditAirline = (ComboBox)gvwPreferredAirline.Rows[e.RowIndex].FindControl("cboEditAirline");
            TextBox tbxEditAirline = (TextBox) gvwPreferredAirline.Rows[e.RowIndex].FindControl("tbxEditAirline");
            TextBox tbxEditFlightNum = (TextBox) gvwPreferredAirline.Rows[e.RowIndex].FindControl("tbxEditFlightNum");
            airlineID = objAirport.getAirlineID(tbxEditAirline.Text);
            //Get the airline ID from the textbox above

            objAirport.updateAttendeePreferredAirline(gvwPreferredAirline.DataKeys[e.RowIndex].Values[0].ToString(),airlineID.ToString(), tbxEditFlightNum.Text);
            gvwPreferredAirline.EditIndex = -1;
            FillPreferredAttendeeAirlineGrid(); 
            lblDisplayMessages.Text = "Preferred airline updated";
        }

        protected void gvwPreferredAirline_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            objAirport.deleteAttendeePrefferedAirline(gvwPreferredAirline.DataKeys[e.RowIndex].Values[0].ToString());
            FillPreferredAttendeeAirlineGrid();
            lblDisplayMessages.Text = "Preferred airline deleted";
            dvSystemMessages.Visible = true;
        }

        protected void ddlCountry_DataBound(object sender, EventArgs e)
        {
            if(hdfCountryId.Value != "")
            {
                ddlCountry.SelectedValue = hdfCountryId.Value;
            }
        }

        
        
        #region Airline Membership

        protected void gvwAirlineMembership_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AddNew"))
            {
                TextBox tbxNewMemberAirline = (TextBox)gvwAirlineMembership.FooterRow.FindControl("tbxNewMemberAirline");
                TextBox tbxNewAirlineMem = (TextBox)gvwAirlineMembership.FooterRow.FindControl("tbxNewAirlineMem");

                objAttendee.insertAttendeeAirlineMembership(Convert.ToInt32(Session["atn_id"]), tbxNewMemberAirline.Text, tbxNewAirlineMem.Text);
                FillAirlineMembershipGrid();
                lblDisplayMessages.Text = "Airline membership saved";
                dvSystemMessages.Visible = true;
            }
        }

        protected void gvwAirlineMembership_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvwAirlineMembership.EditIndex = e.NewEditIndex;
            FillAirlineMembershipGrid();
        }

        protected void gvwAirlineMembership_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvwAirlineMembership.EditIndex = -1;
            FillAirlineMembershipGrid();
        }

        protected void gvwAirlineMembership_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TextBox tbxEditMemberAirline = (TextBox)gvwAirlineMembership.Rows[e.RowIndex].FindControl("tbxEditMemberAirline");
            TextBox tbxEditAirlineMem = (TextBox)gvwAirlineMembership.Rows[e.RowIndex].FindControl("tbxEditAirlineMem");

            objAttendee.updateAttendeeAirlineMembership(Convert.ToInt32(gvwAirlineMembership.DataKeys[e.RowIndex].Values[0].ToString()), tbxEditMemberAirline.Text, tbxEditAirlineMem.Text);
            gvwAirlineMembership.EditIndex = -1;
            FillAirlineMembershipGrid();
            lblDisplayMessages.Text = "Airline membership updated";
            dvSystemMessages.Visible = true;
        }

        protected void gvwAirlineMembership_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            objAttendee.deleteAttendeeAirlineMembership(Convert.ToInt32(gvwAirlineMembership.DataKeys[e.RowIndex].Values[0].ToString()));
            FillAirlineMembershipGrid();
            lblDisplayMessages.Text = "Airline membership deleted";
            dvSystemMessages.Visible = true;
        }
        #endregion


        private void ShowNoResultFound(DataTable source, GridView gv)
        {
            source.Rows.Add(source.NewRow()); // create a new blank row to the DataTable
            // Bind the DataTable which contain a blank row to the GridView
            gv.DataSource = source;
            gv.DataBind();
            // Get the total number of columns in the GridView to know what the Column Span should be
            int columnsCount = gv.Columns.Count;
            gv.Rows[0].Cells.Clear();// clear all the cells in the row
            gv.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
            gv.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell

            //You can set the styles here
            gv.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            gv.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
            gv.Rows[0].Cells[0].Font.Bold = true;
            //set No Results found to the new added cell
            gv.Rows[0].Cells[0].Text = "NO RESULT FOUND!";
        }

        protected void gvwCityAirport_PreRender(object sender, EventArgs e)
        {
            fillGrids();
        }

        protected void btnPreferencesContinue_Click(object sender, EventArgs e)
        {
            skipToNextTab();
        }
        

        
    }
}