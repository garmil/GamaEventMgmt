using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using OpenPop.Mime;
using OpenPop.Mime.Header;
using OpenPop.Pop3;

namespace Gama.CommonMethods
{
    public class _CommonMethods
    {
        _DataAccessLayer objDal = new _DataAccessLayer();

        public static string replaceApos(string stringApos)
        {
            stringApos = stringApos.Replace("'", "''");
            return stringApos;
        }

        public static string generateSixDigitRandom(int seed, int count)
        {
            Random random = new Random(seed);
            string randomNumber = random.Next(0, 1000000).ToString();
            return randomNumber;
            //Random random = new Random(seed);

            //StringBuilder sb = new StringBuilder(count);
            //for (int i = 0; i < count; ++i)
            //{
            //    sb.Append((char)('0' + random.Next(999999)));
            //}
            //return sb.ToString();
        }


        public static string generateShortGUID()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, 8)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result;
        }
        
        public static string sendGeneralEmail(string mailAddress, string mailBody, string subject)
        {
            

            string mailSubject = subject;
            string statusMsg = string.Empty;
            int retVal = 0;
            
            if (1 == 1) //this.isEmail(mailAddress)
            {

                
                
                // create mail message object
                System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
                message.To.Add(mailAddress);
                
                message.Subject = mailSubject;
                message.IsBodyHtml = true;
                message.From = new System.Net.Mail.MailAddress(ConfigurationManager.AppSettings["mailFrom"].ToString());
                message.Body = mailBody;
                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient(ConfigurationManager.AppSettings["SMTP"].ToString());
                //smtp.EnableSsl = true;
                try
                {
                    smtp.Send(message);        // and then send the mail
                }

                catch (Exception e)
                {
                    //throw new Exception(e.Message);
                    statusMsg = "Error sending mail. " + e.Message.ToString();
                }

                finally
                {
                    retVal = -1;
                }
                
                
            }
            else
            {
                statusMsg = "Not a valid email address";
            }
             
            return statusMsg;
         
        }


        public static string sendAttendeeDataEmail(string mailAddress, DataTable dtAttendee, DataTable dtCityAirport, DataTable dtPrefFlight, string subject)
        {
            string mailSubject = subject;
            string statusMsg = string.Empty;
            int retVal = 0;

            Attendee objAttendee = new Attendee();
            Event objEvent = new Event(); 
            
            StringBuilder sbMailBody = new StringBuilder();

            sbMailBody.AppendLine("Hi.<br><br> The following data has been captured.  " +
                                  
                                  "<br><br>Attendee Information:<br>");
            int rowcount = 0;

            foreach (DataRow row in dtAttendee.Rows)
            {
                /*
                aec.aec_DepartureCity, DATE_FORMAT(aec.aec_ArrivalDate, '%Y/%m/%d') aec_ArrivalDate, aec.aec_ArrivalTime, 
                DATE_FORMAT(aec.aec_DepartureDate, '%Y/%m/%d') aec_DepartureDate, aec.aec_DepartureTime, 
                aec.aec_FlightNumber
                */
                if (rowcount == 0)
                {
                    sbMailBody.AppendLine("Event: " + row["evt_Name"].ToString() + "<br>");

                    sbMailBody.AppendLine("Title: " + row["atn_Title"].ToString() + "<br>");
                    sbMailBody.AppendLine("Last Name: " + row["atn_Surname"].ToString() + "<br>");
                    sbMailBody.AppendLine("First Name: " + row["atn_Name"].ToString() + "<br>");
                    sbMailBody.AppendLine("Middle Name: " + row["atn_MiddleName"].ToString() + "<br>");
                    sbMailBody.AppendLine("Email: " + row["atn_Email"].ToString() + "<br>");
                    sbMailBody.AppendLine("Legal Name: " + row["atn_LegalName"].ToString() + "<br>");
                    sbMailBody.AppendLine("Date of Birth: " + row["atn_DateofBirth"].ToString() + "<br>");
                    sbMailBody.AppendLine("Passport/Id Num: " + row["atn_Passport_IdNum"].ToString() + "<br>");
                    
                    sbMailBody.AppendLine("Place of Issue: " + row["atn_PlaceOfIssue"].ToString() + "<br>");
                    
                    sbMailBody.AppendLine("Address 1: " + row["ata_AddressLine1"].ToString() + "<br>");
                    sbMailBody.AppendLine("Address 2: " + row["ata_AddressLine2"].ToString() + "<br>");
                    sbMailBody.AppendLine("Address 3: " + row["ata_AddressLine3"].ToString() + "<br>");
                    sbMailBody.AppendLine("City: " + row["ata_City"].ToString() + "<br>");
                    sbMailBody.AppendLine("Province / State: " + row["ata_State_Province"].ToString() + "<br>");
                    sbMailBody.AppendLine("Country: " + row["cnt_Name"].ToString() + "<br>");
                    sbMailBody.AppendLine("Province / State: " + row["ata_State_Province"].ToString() + "<br>");
                    sbMailBody.AppendLine("Bus Phone: " + row["ata_BusinessPhone"].ToString() + "<br>");
                    sbMailBody.AppendLine("Bus Fax: " + row["ata_BusinessFax"].ToString() + "<br>");
                    sbMailBody.AppendLine("Phone Num: " + row["atn_HomePhoneNum"].ToString() + "<br>");
                    sbMailBody.AppendLine("Cell Num: " + row["atn_CellNum"].ToString() + "<br>");
                    sbMailBody.AppendLine("Alternate Email: " + row["atn_AlternateEmailAddress"].ToString() + "<br>");
                    sbMailBody.AppendLine("Emergency Contact: " + row["atn_EmergencyContactName"].ToString() + "<br>");
                    sbMailBody.AppendLine("Emergency Contact Number: " + row["atn_EmergencyContactNum"].ToString() + "<br>");
                }
                rowcount++;
            }

            sbMailBody.AppendLine("<br>Departure / Arrivals:" + "<br>" );
            sbMailBody.AppendLine("<table>");
            foreach (DataRow row in dtCityAirport.Rows)
            {
                sbMailBody.AppendLine("<tr><td>Departure Airport</td><td>"+ row["aec_DepartureAirport"].ToString() +"</td></tr>");
                sbMailBody.AppendLine("<tr><td>Departure Date</td><td>" + row["aec_DepartureDate"].ToString() + "</td></tr>");
                sbMailBody.AppendLine("<tr><td>Departure Time</td><td>" + row["aec_DepartureTime"].ToString() + "</td></tr>");

                sbMailBody.AppendLine("<tr><td>Arrival Date</td><td>" + row["aec_ArrivalDate"].ToString() + "</td></tr>");
                sbMailBody.AppendLine("<tr><td>Arrival Time</td><td>" + row["aec_ArrivalTime"].ToString() + "</td></tr>");
           }

            sbMailBody.AppendLine("</table>");

            sbMailBody.AppendLine("<br>Preferred Flights:");
            sbMailBody.AppendLine("<table>");
            foreach (DataRow row in dtPrefFlight.Rows)
            {
                sbMailBody.AppendLine("<tr><td>Airline</td><td>" + row["aln_Airline"].ToString() + "</td></tr>");
                sbMailBody.AppendLine("<tr><td>Flight Number</td><td>" + row["apa_FlightNum"].ToString() + "</td></tr>");
            }

            sbMailBody.AppendLine("</table>");

            if (1 == 1) //this.isEmail(mailAddress)
            {



                // create mail message object
                System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
                message.To.Add(mailAddress);

                message.Subject = mailSubject;
                message.IsBodyHtml = true;
                message.From = new System.Net.Mail.MailAddress(ConfigurationManager.AppSettings["mailFrom"].ToString());
                message.Body = sbMailBody.ToString();
                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient(ConfigurationManager.AppSettings["SMTP"].ToString());
                //smtp.EnableSsl = true;
                try
                {
                    smtp.Send(message);        // and then send the mail
                }

                catch (Exception e)
                {
                    //throw new Exception(e.Message);
                    statusMsg = "Error sending mail. " + e.Message.ToString();
                }

                finally
                {
                    retVal = -1;
                }


            }
            else
            {
                statusMsg = "Not a valid email address";
            }

            return statusMsg;

        }

        public static string sendGeneralEmail(string mailAddress, DataTable dtAttendee, DataTable dtAirport, DataTable dtFlight, DataTable dtPreferences, DataTable dtVisaCitizenship, string shirtSize, string subject)
        {
            string mailSubject = subject;
            string statusMsg = string.Empty;
            int retVal = 0;

            
            StringBuilder sbMailBody = new StringBuilder();

            sbMailBody.AppendLine("Hi.<br><br> The following data has been captured. <br><br>Attendee Information:");


            foreach (DataRow row in dtAttendee.Rows)
            {
                /*
                aec.aec_DepartureCity, DATE_FORMAT(aec.aec_ArrivalDate, '%Y/%m/%d') aec_ArrivalDate, aec.aec_ArrivalTime, 
                DATE_FORMAT(aec.aec_DepartureDate, '%Y/%m/%d') aec_DepartureDate, aec.aec_DepartureTime, 
                aec.aec_FlightNumber
                */

                sbMailBody.AppendLine("Event: " + row["evt_Name"].ToString()+"<br>");

                sbMailBody.AppendLine("Title: " + row["atn_Title"].ToString() + "<br>");
                sbMailBody.AppendLine("Last Name: " + row["atn_Surname"].ToString() + "<br>");
                sbMailBody.AppendLine("First Name: " + row["atn_Name"].ToString() + "<br>");
                sbMailBody.AppendLine("Middle Name: " + row["atn_MiddleName"].ToString() + "<br>");
                sbMailBody.AppendLine("Email: " + row["atn_Email"].ToString() + "<br>");
                sbMailBody.AppendLine("Legal Name: " + row["atn_LegalName"].ToString() + "<br>");
                sbMailBody.AppendLine("Date of Birth: " + row["atn_DateofBirth"].ToString() + "<br>");
                sbMailBody.AppendLine("Passport/Id Num: " + row["atn_Passport_IdNum"].ToString() + "<br>");
                sbMailBody.AppendLine("Place of Issue: " + row["atn_PlaceOfIssue"].ToString() + "<br>");
                
                sbMailBody.AppendLine("Address 1: " + row["ata_AddressLine1"].ToString() + "<br>");
                sbMailBody.AppendLine("Address 2: " + row["ata_AddressLine2"].ToString() + "<br>");
                sbMailBody.AppendLine("Address 3: " + row["ata_AddressLine3"].ToString() + "<br>");
                sbMailBody.AppendLine("City: " + row["ata_City"].ToString() + "<br>");
                sbMailBody.AppendLine("Province / State: " + row["ata_State_Province"].ToString() + "<br>");
                sbMailBody.AppendLine("Country: " + row["cnt_Name"].ToString() + "<br>");
                sbMailBody.AppendLine("Province / State: " + row["ata_State_Province"].ToString() + "<br>");
                sbMailBody.AppendLine("Bus Phone: " + row["ata_BusinessPhone"].ToString() + "<br>");
                sbMailBody.AppendLine("Bus Fax: " + row["ata_BusinessFax"].ToString() + "<br>");
                sbMailBody.AppendLine("Phone Num: " + row["atn_HomePhoneNum"].ToString() + "<br>");
                sbMailBody.AppendLine("Cell Num: " + row["atn_CellNum"].ToString() + "<br>");
                sbMailBody.AppendLine("Alternate Email: " + row["atn_AlternateEmailAddress"].ToString() + "<br>");
                sbMailBody.AppendLine("Emergency Contact: " + row["atn_EmergencyContactName"].ToString() + "<br>");
                sbMailBody.AppendLine("Emergency Contact Number: " + row["atn_EmergencyContactNum"].ToString() + "<br>");

            }

            if (dtFlight.Rows.Count > 0)
            {
                sbMailBody.AppendLine("Flight Preferences: " + "<br>");
            }

            foreach (DataRow row in dtFlight.Rows)
            {
                sbMailBody.AppendLine("Preferred Airline:" + row["aln_Airline"] + "<br>");
                sbMailBody.AppendLine("Preferred Flight Num: " + row["apa_FlightNum"].ToString() + "<br>");
                
            }

            if (dtAirport.Rows.Count > 0)
            {
                sbMailBody.AppendLine("Airport / City Info: " + "<br>");
            }

            foreach (DataRow row in dtAirport.Rows)
            {

                sbMailBody.AppendLine("Departure City: " + row["aec_DepartureCity"].ToString() + "<br>");
                sbMailBody.AppendLine("Departure Airport: " + row["aec_DepartureAirport"].ToString() + "<br>");
                sbMailBody.AppendLine("Arrival Date: " + row["aec_ArrivalDate"].ToString() + "<br>");
                sbMailBody.AppendLine("Arrival Time: " + row["aec_ArrivalTime"].ToString() + "<br>");
                sbMailBody.AppendLine("Departure Date: " + row["aec_DepartureDate"].ToString() + "<br>");
                sbMailBody.AppendLine("Departure Time: " + row["aec_DepartureTime"].ToString() + "<br>");

            }

            if (dtPreferences.Rows.Count > 0)
            {
                sbMailBody.AppendLine("Preferences: " + "<br>");
            }

            foreach (DataRow row in dtPreferences.Rows)
            {

                sbMailBody.AppendLine("Seating Preference: " + row["atn_SeatingPref"].ToString() + "<br>");
                sbMailBody.AppendLine("Class of Service: " + row["atn_ClassOfService"].ToString() + "<br>");
                sbMailBody.AppendLine("Disability Requirement: " + row["atn_DisabilityRequirements"].ToString() + "<br>");
                
            }

            if (dtVisaCitizenship.Rows.Count > 0)
            {
                sbMailBody.AppendLine("Country Citizenship: " + "<br>");
            }

            foreach (DataRow row in dtVisaCitizenship.Rows)
            {

                sbMailBody.AppendLine("Country: " + row["avr_Citizenship"].ToString() + "<br>");
            }

            if (shirtSize != "")
            {
                sbMailBody.AppendLine("Shirt Size: " + shirtSize);
            }



            if (1 == 1) //this.isEmail(mailAddress)
            {

                

                // create mail message object
                System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
                message.To.Add(mailAddress);
                message.Bcc.Add(ConfigurationManager.AppSettings["inviteBCC"]);

                message.Subject = mailSubject;
                message.IsBodyHtml = true;
                message.From = new System.Net.Mail.MailAddress(ConfigurationManager.AppSettings["mailFrom"].ToString());
                message.Body = sbMailBody.ToString();
                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient(ConfigurationManager.AppSettings["SMTP"].ToString());
                //smtp.EnableSsl = true;
                try
                {
                    smtp.Send(message);        // and then send the mail
                }

                catch (Exception e)
                {
                    //throw new Exception(e.Message);
                    statusMsg = "Error sending mail. " + e.Message.ToString();
                }

                finally
                {
                    retVal = -1;
                }
                
                
            }
            else
            {
                statusMsg = "Not a valid email address";
            }
            
            return statusMsg;

        }

        #region EmailPop

        public static List<Message> FetchUnseenMessages(string hostname, int port, bool useSsl, string username, string password, List<string> seenUids)
        {
            // The client disconnects from the server when being disposed
            using (Pop3Client client = new Pop3Client())
            {
                // Connect to the server
                client.Connect(hostname, port, useSsl);

                // Authenticate ourselves towards the server
                client.Authenticate(username, password);

                // Fetch all the current uids seen
                List<string> uids = client.GetMessageUids();

                // Create a list we can return with all new messages
                List<Message> newMessages = new List<Message>();

                // All the new messages not seen by the POP3 client
                for (int i = 0; i < uids.Count; i++)
                {
                    string currentUidOnServer = uids[i];
                    if (!seenUids.Contains(currentUidOnServer))
                    {
                        // We have not seen this message before.
                        // Download it and add this new uid to seen uids

                        // the uids list is in messageNumber order - meaning that the first
                        // uid in the list has messageNumber of 1, and the second has 
                        // messageNumber 2. Therefore we can fetch the message using
                        // i + 1 since messageNumber should be in range [1, messageCount]
                        Message unseenMessage = client.GetMessage(i + 1);

                        // Add the message to the new messages
                        newMessages.Add(unseenMessage);

                        // Add the uid to the seen uids, as it has now been seen
                        seenUids.Add(currentUidOnServer);
                    }
                }

                // Return our new found messages
                return newMessages;
            }
        }

        public static List<Message> FetchAllMessages(string hostname, int port, bool useSsl, string username, string password)
        {
            // The client disconnects from the server when being disposed
            using (Pop3Client client = new Pop3Client())
            {
                // Connect to the server
                client.Connect(hostname, port, useSsl);

                // Authenticate ourselves towards the server
                client.Authenticate(username, password);

                // Get the number of messages in the inbox
                int messageCount = client.GetMessageCount();

                // We want to download all messages
                List<Message> allMessages = new List<Message>(messageCount);

                // Messages are numbered in the interval: [1, messageCount]
                // Ergo: message numbers are 1-based.
                // Most servers give the latest message the highest number
                for (int i = messageCount; i > 0; i--)
                {
                    allMessages.Add(client.GetMessage(i));
                }

                // Now return the fetched messages
                return allMessages;
            }
        }

        public static string  HeadersFromAndSubject(string hostname, int port, bool useSsl, string username, string password, int messageNumber)
        {
            // The client disconnects from the server when being disposed
            string subject = string.Empty;

            using (Pop3Client client = new Pop3Client())
            {
                // Connect to the server
                client.Connect(hostname, port, useSsl);

                // Authenticate ourselves towards the server
                client.Authenticate(username, password);

                // We want to check the headers of the message before we download
                // the full message
                MessageHeader headers = client.GetMessageHeaders(messageNumber);
                
                RfcMailAddress from = headers.From;
                subject = headers.Subject;

                // Only want to download message if:
                //  - is from test@xample.com
                //  - has subject "Some subject"
                if (from.HasValidMailAddress) //&& "Some subject".Equals(subject)
                {
                    // Download the full message
                    Message message = client.GetMessage(messageNumber);

                    
                }
            }

            return subject;
        }

        public static string getMessage(string hostname, int port, bool useSsl, string username, string password, int messageNumber)
        {
            string messageBody = "";
            using (Pop3Client client = new Pop3Client())
            {
                // Connect to the server
                client.Connect(hostname, port, useSsl);

                // Authenticate ourselves towards the server
                client.Authenticate(username, password);

                Message message = client.GetMessage(messageNumber);

                MessagePart htmlVersion = message.FindFirstHtmlVersion();
                if (htmlVersion != null)
                {
                    messageBody = htmlVersion.GetBodyAsText();
                    // Save it somehow
                }
                else 
                {
                    MessagePart plainText = message.FindFirstPlainTextVersion();

                    if (plainText != null)
                    {
                        messageBody = plainText.ToString();
                    }
                }
                
            }

            return messageBody;
        }

        public static string HeadersFrom(string hostname, int port, bool useSsl, string username, string password, int messageNumber)
        {
            // The client disconnects from the server when being disposed
            string fromEmailAddress = string.Empty;

            using (Pop3Client client = new Pop3Client())
            {
                // Connect to the server
                client.Connect(hostname, port, useSsl);

                // Authenticate ourselves towards the server
                client.Authenticate(username, password);

                // We want to check the headers of the message before we download
                // the full message
                MessageHeader headers = client.GetMessageHeaders(messageNumber);

                RfcMailAddress from = headers.From;
                fromEmailAddress = from.ToString();

                // Only want to download message if:
                //  - is from test@xample.com
                //  - has subject "Some subject"
                if (from.HasValidMailAddress) //&& "Some subject".Equals(subject)
                {
                    // Download the full message
                    Message message = client.GetMessage(messageNumber);


                }
            }

            return fromEmailAddress;
        }


        internal static string HeadersTo(string hostname, int port, bool useSsl, string username, string password, int messageNumber)
        {
            // The client disconnects from the server when being disposed
            string toEmailAddress = string.Empty;

            using (Pop3Client client = new Pop3Client())
            {
                // Connect to the server
                client.Connect(hostname, port, useSsl);

                // Authenticate ourselves towards the server
                client.Authenticate(username, password);

                // We want to check the headers of the message before we download
                // the full message
                MessageHeader headers = client.GetMessageHeaders(messageNumber);
                List<RfcMailAddress> toList = headers.To;

                for (int i = 0; i < toList.Count; i++)
                {
                    toEmailAddress = toList[0].ToString();
                }
            }

            return toEmailAddress;
        }

        public static void DeleteMessageOnServer(string hostname, int port, bool useSsl, string username, string password, int messageNumber)
        {
            // The client disconnects from the server when being disposed
            using (Pop3Client client = new Pop3Client())
            {
                // Connect to the server
                client.Connect(hostname, port, useSsl);

                // Authenticate ourselves towards the server
                client.Authenticate(username, password);

                // Mark the message as deleted
                // Notice that it is only MARKED as deleted
                // POP3 requires you to "commit" the changes
                // which is done by sending a QUIT command to the server
                // You can also reset all marked messages, by sending a RSET command.
                client.DeleteMessage(messageNumber);

                // When a QUIT command is sent to the server, the connection between them are closed.
                // When the client is disposed, the QUIT command will be sent to the server
                // just as if you had called the Disconnect method yourself.
                
            }
        }

        public bool DeleteMessageByMessageId(Pop3Client client, string messageId)
        {
            // Get the number of messages on the POP3 server
            int messageCount = client.GetMessageCount();

            // Run trough each of these messages and download the headers
            for (int messageItem = messageCount; messageItem > 0; messageItem--)
            {
                // If the Message ID of the current message is the same as the parameter given, delete that message
                if (client.GetMessageHeaders(messageItem).MessageId == messageId)
                {
                    // Delete
                    client.DeleteMessage(messageItem);
                    return true;
                }
            }

            // We did not find any message with the given messageId, report this back
            return false;
        }

        public void insertPoppedEmailLog(string mailFrom, string mailTo, string poppedDate, string subject,string mailBody)
        {
            string sql =
                "INSERT INTO t_poppedemail_pde (pde_From, pde_To, pde_poppedDate, pde_Subject, pde_Body, pde_RetrievedOn) VALUES ('" +
                _CommonMethods.replaceApos(mailFrom) + "','" + _CommonMethods.replaceApos(mailTo) + "','" + poppedDate + "','" + _CommonMethods.replaceApos(subject) + "','" + _CommonMethods.replaceApos(mailBody) + "','" + DateTime.Now.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture) + "')";

            objDal.insertData(sql);

        }

        #endregion

        #region csvExporter

        public static void CreateCSVHelper(DataTable sourceTable, string filename)
        {
            //locals
            StringBuilder outputBuilder = new StringBuilder();

            //write column names        
            for (int i = 0; i < sourceTable.Columns.Count; i++)
            {
                if (i > 0)
                    outputBuilder.Append(",");
                outputBuilder.Append(sourceTable.Columns[i].ColumnName);
            }
            outputBuilder.Append(Environment.NewLine);

            //Put in data
            foreach (DataRow row in sourceTable.Rows)
            {
                for (int i = 0; i < sourceTable.Columns.Count; i++)
                {
                    if (i > 0)
                        outputBuilder.Append(",");
                    outputBuilder.Append(string.Format("\"{0}\"", row[i].ToString()));
                }

                outputBuilder.Append(Environment.NewLine);
            }

            try
            {
                //Attempt to write file
                StreamWriter sw = new StreamWriter(filename);
                sw.Write(outputBuilder.ToString());
                sw.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex);
            }
        }

        #endregion

    }
}