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
            return statusMsg;
        }


        public static void sendGeneralEmail(string mailAddress, DataTable dtAttendee, string subject)
        {
            StringBuilder sbMailBody = new StringBuilder();

            sbMailBody.Append("Attendee Information:")

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

            string mailSubject = subject;
            string statusMsg = "";
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
            return statusMsg;
        }
    }
}