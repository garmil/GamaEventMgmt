using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Gama;
using Gama.CommonMethods;
using OpenPop.Mime;
using OpenPop.Mime.Header;

namespace GamaEventMgmt.GamaAdmin
{
    public partial class checkAgentEmailResponse : System.Web.UI.Page
    {
        _CommonMethods objCommMethod = new _CommonMethods();
        Attendee objAttendee = new Attendee();
        private Event objEvent = new Event();

        protected void Page_Load(object sender, EventArgs e)
        {
            

            List<string> lstSeenUids = new List<string>();
            string subject = string.Empty;
            string fromAddress = string.Empty;
            string toAddress = string.Empty;
            string poppedMailBody = string.Empty;
            
            string pop = ConfigurationManager.AppSettings["pop"];
            int port = Convert.ToInt32(ConfigurationManager.AppSettings["port"]);
            string user = ConfigurationManager.AppSettings["popUser"];
            string password = ConfigurationManager.AppSettings["popPassword"];
            string status = string.Empty;

            var messages = _CommonMethods.FetchAllMessages(pop, port, false, user,password);

            for (int i =1; i <= messages.Count; i++) // Loop through List with for
            {
                int atn_id = 0;
                int evt_id = 0;
                subject = _CommonMethods.HeadersFromAndSubject(pop, port, false, user,password, i);
                fromAddress = _CommonMethods.HeadersFrom(pop, port, false, user, password, i);
                toAddress = _CommonMethods.HeadersTo(pop, port, false, user, password, i);
                poppedMailBody = _CommonMethods.getMessage(pop, port, false, user, password, i);
                string firstName, lastname, eventName;

                string[] lstDirtyEventNameArray = subject.Split(new Char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                string[] lstCleantEventNameArray = lstDirtyEventNameArray[1].Split(new Char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
                eventName = lstCleantEventNameArray[0].ToString();


                string[] subjArray = subject.Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                
                if (subjArray.Length > 0)
                {
                    objCommMethod.insertPoppedEmailLog(fromAddress, toAddress, DateTime.Now.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture), subject, poppedMailBody);

                    string[] lstRegistrant = subjArray[8].Split(new Char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                    string[] lstCleanRegNameSurname = lstRegistrant[1].Split(new Char[] {'/'}, StringSplitOptions.RemoveEmptyEntries);
                    string[] lstEvent = subjArray[4].Split(new Char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                    string[] lstFormId = subjArray[6].Split(new Char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                    string[] lstStatus = subjArray[9].Split(new Char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

                    if (lstEvent.Length > 0)
                    {
                        evt_id = objEvent.GetEventIdByName(eventName);
                    }

                    if (lstCleanRegNameSurname.Length > 0)
                    {

                        firstName = lstCleanRegNameSurname[1].ToString();
                        lastname = lstCleanRegNameSurname[0].ToString();
                        //atn_id = objAttendee.getAttendeeID(lstRegistrant[1].Trim());
                        atn_id = objAttendee.getAtnIdByLastNameFirstNameEvent(lastname, firstName, evt_id);
                    }

                    if (evt_id == 0)
                    {
                        string invalidForm = "Hi<br> The form ID# you entered does not match our database - please submit again with an existing form ID. <br> "+
                                             "Q - Quote sent <br>" +
                                                  "R - Response received <br>" +
                                                  "C - Confirmed <br>" +
                                                  "X - Cancelled <br>" +
                                                  "I - Ticket issued";

                        _CommonMethods.sendGeneralEmail(fromAddress, invalidForm, subject);
                    }

                    if (atn_id == 0)
                    {
                        string invalidForm = "Hi<br> The registrant you entered does not match our database - please submit again with a valid registrant. <br> ";
                                             

                        _CommonMethods.sendGeneralEmail(fromAddress, invalidForm, subject);
                    }

                    if (lstStatus.Length > 0)
                    {
                        status = lstStatus[1].ToLower();

                        switch (status)
                        {
                            case "booked":
                                objEvent.UpdateEventAttendeeStatus(atn_id, ConfigurationManager.AppSettings["statusBooked"], evt_id);
                                break;

                            case "at agent":
                                objEvent.UpdateEventAttendeeStatus(atn_id, ConfigurationManager.AppSettings["statusAtAgent"], evt_id);
                                break;
                            case "registered":
                                objEvent.UpdateEventAttendeeStatus(atn_id, ConfigurationManager.AppSettings["statusRegistered"], evt_id);
                                break;
                            case "q":
                                objEvent.UpdateEventAttendeeStatus(atn_id, ConfigurationManager.AppSettings["quoteSent"], evt_id);
                                break;
                            case "r":
                                objEvent.UpdateEventAttendeeStatus(atn_id, ConfigurationManager.AppSettings["responseReceived"], evt_id);
                                break;
                            case "c":
                                objEvent.UpdateEventAttendeeStatus(atn_id, ConfigurationManager.AppSettings["Confirmed"], evt_id);
                                break;
                            case "x":
                                objEvent.UpdateEventAttendeeStatus(atn_id, ConfigurationManager.AppSettings["Cancelled"], evt_id);
                                break;
                            case "i":
                                objEvent.UpdateEventAttendeeStatus(atn_id, ConfigurationManager.AppSettings["Ticketissued"], evt_id);
                                break;
                            default:
                                string mailBody = "Hi<br> The status code you entered is incorrect, please use - <br> "+
                                                  "Q - Quote sent <br>"+
                                                  "R - Response received <br>" +
                                                  "C - Confirmed <br>" + 
                                                  "X - Cancelled <br>" +
                                                  "I - Ticket issued";
                                _CommonMethods.sendGeneralEmail(fromAddress, mailBody, subject);

                                break;
                        }

                        /*
                        if (status.ToLower() == "booked")
                        {
                            objEvent.UpdateEventAttendeeStatus(atn_id, ConfigurationManager.AppSettings["statusBooked"], evt_id);
                        }

                        if (status.ToLower() == "at agent")
                        {
                            objEvent.UpdateEventAttendeeStatus(atn_id, ConfigurationManager.AppSettings["statusAtAgent"], evt_id);
                        }

                        if (status.ToLower() == "registered")
                        {
                            objEvent.UpdateEventAttendeeStatus(atn_id, ConfigurationManager.AppSettings["statusRegistered"], evt_id);
                        }

                        if (status.ToLower() == "q")
                        {
                            objEvent.UpdateEventAttendeeStatus(atn_id, ConfigurationManager.AppSettings["quoteSent"], evt_id);
                        }

                        if (status.ToLower() == "r")
                        {
                            objEvent.UpdateEventAttendeeStatus(atn_id, ConfigurationManager.AppSettings["responseReceived"], evt_id);
                        }

                        if (status.ToLower() == "c")
                        {
                            objEvent.UpdateEventAttendeeStatus(atn_id, ConfigurationManager.AppSettings["Confirmed"], evt_id);
                        }

                        if (status.ToLower() == "x")
                        {
                            objEvent.UpdateEventAttendeeStatus(atn_id, ConfigurationManager.AppSettings["Cancelled"], evt_id);
                        }

                        if (status.ToLower() == "i")
                        {
                            objEvent.UpdateEventAttendeeStatus(atn_id, ConfigurationManager.AppSettings["Ticketissued"], evt_id);
                        }
                        */
                    }
                }
                else
                {
                    lblError.Text =
                        "Subject line not in correct format. Should be as follows: 'New registration form for group: Event Name. Form ID:123456 and Passenger:Surname/Name Status:r'";
                }
            }

            //Delete messages
            for (int i = 1; i <= messages.Count; i++) // Loop through List with for
            {
                _CommonMethods.DeleteMessageOnServer(pop, port, false, user, password, 1);
            }
        }
    }
}