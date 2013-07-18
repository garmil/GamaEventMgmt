using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace Gama.CommonMethods
{
    public class _CommonMethods
    {
        public static string replaceApos(string stringApos)
        {
            stringApos = stringApos.Replace("'", "''");
            return stringApos;
        }
        
        public static string sendGeneralEmail(string mailAddress, string mailBody, string subject)
        {
            

            string mailSubject = subject;
            string statusMsg = "";
            int retVal = 0;
            /*
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
                smtp.EnableSsl = true;
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
                statusMsg = "Mail sent";

            }
            else
            {
                statusMsg = "Not a valid email address";
            }
             */
            return statusMsg;
         
        }


        public static string sendGeneralEmail(string mailAddress, DataTable dtAttendee, string subject)
        {
            string mailSubject = subject;
            string statusMsg = "";
            int retVal = 0;

            /*
            StringBuilder sbMailBody = new StringBuilder();

            sbMailBody.AppendLine("Attendee Information:");


            foreach (DataRow row in dtAttendee.Rows)
            {
                sbMailBody.AppendLine("Title: " + row["atn_Title"].ToString());
                sbMailBody.AppendLine("Surname: "  +row["atn_Surname"].ToString());
                sbMailBody.AppendLine("Name: " + row["atn_Name"].ToString());
                sbMailBody.AppendLine("Middle Name: "  + row["atn_MiddleName"].ToString());
                sbMailBody.AppendLine("Email: "  + row["atn_Email"].ToString());
                sbMailBody.AppendLine("Legal Name: " + row["atn_LegalName"].ToString());
                sbMailBody.AppendLine("Date of Birth: "  +row["atn_DateofBirth"].ToString());
                sbMailBody.AppendLine("Passport/Id Num: " + row["atn_Passport_IdNum"].ToString());
                sbMailBody.AppendLine("Place of Birth: " + row["atn_PlaceOfBirth"].ToString());
                sbMailBody.AppendLine("Place of Issue: "  + row["atn_PlaceOfIssue"].ToString());
                sbMailBody.AppendLine("Date of Issue: "  + row["atn_PassportDateOfIssue"].ToString());
                sbMailBody.AppendLine("Expiration Date: "  + row["atn_PassportExpDate"].ToString());
                sbMailBody.AppendLine("Address 1: "  + row["ata_AddressLine1"].ToString());
                sbMailBody.AppendLine("Address 2: "  + row["ata_AddressLine2"].ToString());
                sbMailBody.AppendLine("Address 3: "  + row["ata_AddressLine3"].ToString());
                sbMailBody.AppendLine("City: " + row["ata_City"].ToString());
                sbMailBody.AppendLine("Province / State: "  + row["ata_State_Province"].ToString());
                sbMailBody.AppendLine("Country: "  + row["cnt_Name"].ToString());
                sbMailBody.AppendLine("Province / State: " +row[""].ToString());
                sbMailBody.AppendLine("Bus Phone: " + row["ata_BusinessPhone"].ToString());
                sbMailBody.AppendLine("Bus Fax: " + row["ata_BusinessFax"].ToString());
                sbMailBody.AppendLine("Phone Num: " + row["atn_HomePhoneNum"].ToString());
                sbMailBody.AppendLine("Cell Num: " + row["atn_CellNum"].ToString());
                sbMailBody.AppendLine("Alternate Email: " + row["atn_AlternateEmailAddress"].ToString());
                sbMailBody.AppendLine("Emergency Contact: " + row["atn_EmergencyContactName"].ToString());
                sbMailBody.AppendLine("Emergency Contact Number: " + row["atn_EmergencyContactNum"].ToString());

            }

            

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
                smtp.EnableSsl = true;
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
                statusMsg = "Mail sent";

            }
            else
            {
                statusMsg = "Not a valid email address";
            }
            */
            return statusMsg;
           
        }
    }
}