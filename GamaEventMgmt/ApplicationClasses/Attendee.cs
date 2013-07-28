using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using Gama;
using Gama.CommonMethods;
using System.Data;
using System.Collections;

namespace Gama
{
    public class Attendee
    {
        _DataAccessLayer objDAL = new _DataAccessLayer();

        #region Attendee Event City Airport

        public DataTable getAttendeeEventCityAirport(int atn_id, int evt_id)
        {
            string sql = "SELECT AEC.aec_id, AEC.atn_id, AEC.evt_id, aec_DepartureCity, aec_DepartureAirport, DATE_FORMAT(aec_ArrivalDate, '%Y-%m-%d') as aec_ArrivalDate, " +
                         "aec_ArrivalTime, DATE_FORMAT(aec_DepartureDate, '%Y-%m-%d') as aec_DepartureDate, aec_DepartureTime, aec_PreferredAirlineName_Code, " +
                         "aec_FlightNumber, atn.atn_name, atn.atn_surname, atn.atn_GUID, EVT.evt_name, evt.evt_GUID " +
                         "FROM t_atendeeeventcityairport_aec AEC " +
                         "INNER JOIN m_attendees_atn ATN ON ATN.atn_id = AEC.atn_id " +
                         "INNER JOIN m_event_evt EVT ON EVT.evt_id = AEC.evt_id " +
                         "WHERE aec.atn_id = "+atn_id+" AND aec.evt_id = "+evt_id+" AND ATN.atn_Active = 1;";

            return objDAL.returnDataTable(sql);
        }

        public void insertAttendeeEventCityAirport(int atn_id, int evt_id, string departCity, string departAirport, string arrivalDate, string arrivalTime, string departDate, string departTime, string prefAirline, string prefFlightNum)
        {
            string sql = "INSERT INTO t_atendeeeventcityairport_aec (atn_id, evt_id, aec_DepartureCity, aec_DepartureAirport, aec_ArrivalDate, aec_ArrivalTime, aec_DepartureDate, aec_DepartureTime, aec_PreferredAirlineName_Code,aec_FlightNumber ) " +
                         "VALUES (" + atn_id + ", " + evt_id + ", '" + _CommonMethods.replaceApos(departCity) + "', '" + _CommonMethods.replaceApos(departAirport) + "',  '" + arrivalDate + "', '" + arrivalTime + "', '" + departDate + "', '" + departTime + "', '" + _CommonMethods.replaceApos(prefAirline) + "','"+_CommonMethods.replaceApos(prefFlightNum)+"')";

            objDAL.insertData(sql);
            
        }

        public void updateAttendeeEventCityAirport(int aec_id, string departCity, string departAirport, string arrivalDate, string arrivalTime, string departDate, string departTime, string prefAirline, string prefFlighNum)
        {
            string sql = "UPDATE t_atendeeeventcityairport_aec SET aec_DepartureCity = '" + departCity + "', aec_DepartureAirport = '" + departAirport + "', aec_ArrivalDate = '"+arrivalDate+"', aec_ArrivalTime = '"+arrivalTime+"', aec_DepartureDate = '"+departDate +"', aec_DepartureTime ='"+departTime+"', aec_PreferredAirlineName_Code = '"+prefAirline+"', aec_FlightNumber = '"+ prefFlighNum+"' " + 
                         "WHERE aec_id = " + aec_id;

            objDAL.updateTable(sql);
        }

        public void deleteAttendeeEventCityAirport(int aec_id)
        {
            string sql = "DELETE FROM t_atendeeeventcityairport_aec WHERE aec_id = " + aec_id;
            objDAL.deleteData(sql);
        }

        #endregion

        #region Attendee Airline Membership

        public DataTable getAttendeeAirlineMembership(int atn_id)
        {
            string sql = "SELECT * FROM t_attendeeairlinemembership_alm "+
                         "WHERE atn_id = "+atn_id+";";

            return objDAL.returnDataTable(sql);
        }

        public void insertAttendeeAirlineMembership(int atn_id, string airlineNameCode, string airlineMemNum)
        {
            string sql = "INSERT INTO t_attendeeairlinemembership_alm (atn_id, aam_AirlineName_Code, aam_MembershipNumber) " +
                         "VALUES (" + atn_id + ", '" + _CommonMethods.replaceApos(airlineNameCode) + "', '" + _CommonMethods.replaceApos(airlineMemNum) + "')";

            objDAL.insertData(sql);

        }

        public void updateAttendeeAirlineMembership(int alm_id, string airlineNameCode, string airlineMemNum)
        {
            string sql = "UPDATE t_attendeeairlinemembership_alm SET aam_AirlineName_Code = '" + airlineNameCode + "', aam_MembershipNumber = '" + airlineMemNum+ "' WHERE alm_id = " + alm_id;

            objDAL.updateTable(sql);
        }

        public void deleteAttendeeAirlineMembership(int alm_id)
        {
            string sql = "DELETE FROM t_attendeeairlinemembership_alm WHERE alm_id = " + alm_id;
            objDAL.deleteData(sql);
        }
    
        #endregion

        #region AttendeeMealRequirement
        public DataTable getAllMealRequirements()
        {
            string sql = "SELECT * FROM m_mealrequest_mrq ORDER BY mrq_Meal";

            return objDAL.returnDataTable(sql);
        }

        public void insertAttendeeMealRequirement(int atn_id, ArrayList arlMrq_id, string allergy)
        {
            string sql = string.Empty;

            for (int i = 0; i < arlMrq_id.Count; i++)
            {
                sql += "INSERT INTO t_attendeemealreq_amr (atn_id, mrq_id) VALUES (" + atn_id + "," + Convert.ToInt32(arlMrq_id[i].ToString()) + ");";

            }

            if (allergy != "")
            {
                sql += "INSERT INTO t_attendeemealreq_amr (atn_id, amr_Allergy) VALUES (" + atn_id + ",'" + allergy + "');";
            }

            objDAL.insertData(sql);
        }

        public void deleteMealRequirements(int atn_id)
        {
            string sqlDelete = "DELETE FROM t_attendeemealreq_amr WHERE atn_id = " + atn_id;

            objDAL.deleteData(sqlDelete);
        }
        #endregion

        #region AtendeeCitizenship

        public void insertCitizenship(int atn_id, string citizenship)
        {
            string sql = "INSERT INTO t_atendeevisareqs_avr(atn_id, avr_Citizenship) VALUES (" + atn_id + ",'" + citizenship + "')";

            objDAL.insertData(sql);

        }

        public DataTable getAttendeeCitizenship(int atn_id)
        {
            string sql = "SELECT * FROM t_atendeevisareqs_avr WHERE atn_id = " + atn_id;
            return objDAL.returnDataTable(sql);
        }

        #endregion

        #region additionalAttendees
        public DataTable getAllAdditionalAttendees(int atn_id)
        {
            string sql = "SELECT * FROM t_attendeeadditionalmembers_aam WHERE atn_id = " + atn_id;

            return objDAL.returnDataTable(sql);
        }

        public void insertAdditionalAttendees(int atn_id, string name, string surname, string email)
        {
            string sql = "INSERT INTO t_attendeeadditionalmembers_aam (atn_id, aam_Name, aam_Surname, aam_Email) "+
                         "VALUES(" + atn_id + ",'"+ name+"','"+surname +"','"+email+"')";
            
            objDAL.insertData(sql);

        }

        public void updateAdditionalAttendees(int aam_id, string name, string surname, string email)
        {
            string sql = "UPDATE t_attendeeadditionalmembers_aam SET aam_Name = '" + name + "', aam_Surname = '" + surname + "', aam_Email = '" + email + "' WHERE aam_id = " + aam_id;

            objDAL.updateTable(sql);
        }

        public void deleteAdditionalAttendees(int aam_id)
        {
            string sql = "DELETE FROM t_attendeeadditionalmembers_aam WHERE aam_id = " + aam_id;

            objDAL.deleteData(sql);

        }
        #endregion

        #region AttendeeAddress
        public void insertAttendeeAddress(int adt_id, int atn_id, string addressLine1, string addressLine2, string addressLine3, string city, string stateProvince, int cnt_id, string zip, string busPhone, string busFax)
        {
            string sql = "INSERT INTO t_atendeeaddresses_ata (atn_id, adt_id, ata_AddressLine1, ata_AddressLine2, ata_AddressLine3, ata_City, ata_State_Province, cnt_id, ata_BusinessPhone, ata_BusinessFax, ata_Zip)" +
                        " VALUES (" + atn_id + "," + adt_id + ",'" + _CommonMethods.replaceApos(addressLine1) + "','" + _CommonMethods.replaceApos(addressLine2) + "','" + _CommonMethods.replaceApos(addressLine3) + "','" + _CommonMethods.replaceApos(city) + "','" + _CommonMethods.replaceApos(stateProvince) + "'," + cnt_id + ",'" + _CommonMethods.replaceApos(busPhone) + "','" + _CommonMethods.replaceApos(busFax) +"','" +_CommonMethods.replaceApos(zip) + "')";

            objDAL.insertData(sql);
        }

        public void upAttendeeAddress(int adt_id, int atn_id, string addressLine1, string addressLine2, string addressLine3, string city, string stateProvince, int cnt_id, string zip, string busPhone, string busFax)
        {
            string sql = "UPDATE t_atendeeaddresses_ata SET adt_id = " + adt_id +
                        ", ata_AddressLine1 = '" + _CommonMethods.replaceApos(addressLine1) +"'" +
                        ", ata_AddressLine2 = '" + _CommonMethods.replaceApos(addressLine2) +"'" +
                        ", ata_AddressLine3 = '" + _CommonMethods.replaceApos(addressLine3) +"'" +
                        ", ata_City = '" + _CommonMethods.replaceApos(city) +"'" +
                        ", ata_State_Province = '" + _CommonMethods.replaceApos(stateProvince) +"'" +
                        ", cnt_id = " + cnt_id + 
                        ", ata_BusinessPhone = '" + _CommonMethods.replaceApos(busPhone) + "'"+
                        ", ata_BusinessFax = '" + _CommonMethods.replaceApos(busFax) + "'" +
                        ", ata_Zip = '" + _CommonMethods.replaceApos(zip) + "'" +
                        " WHERE adt_id = " + adt_id + " AND atn_id = " + atn_id;
        }

        public DataTable getAttendeeAddress(int atn_id)
        {
            string sql = "SELECT atn_id, adt_id, ata_AddressLine1, ata_AddressLine2, ata_AddressLine3, ata_City, ata_State_Province, cnt_id, ata_BusinessPhone, ata_BusinessFax, ata_Zip FROM t_atendeeaddresses_ata WHERE atn_id = " + atn_id;

            DataTable dtAddress = objDAL.returnDataTable(sql);
            return dtAddress;
        }

        #endregion

        #region PersonalInfo
        public void updatePersonalInfo(int atn_id, string homePhoneNum, string cellNum, string altEmailAddress, string emergenyContactName, string emergencyContactNumber)
        {
            string sql = "UPDATE m_attendees_atn SET atn_HomePhoneNum = '" + _CommonMethods.replaceApos(homePhoneNum) + "', atn_CellNum = '" + _CommonMethods.replaceApos(cellNum) + "', atn_AlternateEmailAddress = '" + _CommonMethods.replaceApos(altEmailAddress) + "', atn_EmergencyContactName = '" + _CommonMethods.replaceApos(emergenyContactName) + "', atn_EmergencyContactNum = '" + _CommonMethods.replaceApos(emergencyContactNumber) + "' WHERE atn_id = " + atn_id ;
            objDAL.updateTable(sql);
        }

        #endregion

        #region GeneralInfo

        public void updateGeneralInfo(int atn_id, string classOfService, string seatingPref, string  disabilityReq)
        {
            string sql = "UPDATE m_attendees_atn SET atn_SeatingPref = '" + _CommonMethods.replaceApos(seatingPref) + "', atn_ClassOfService = '" + _CommonMethods.replaceApos(classOfService) + "', atn_DisabilityRequirements = '" + _CommonMethods.replaceApos(disabilityReq) + "' WHERE atn_id = " + atn_id;
            objDAL.updateTable(sql);
        }

        #endregion

        public int getAttendeeID(string atnGUID)
        {
            string sql = "SELECT atn_id FROM m_attendees_atn WHERE atn_GUID = '" + atnGUID + "'";
            return objDAL.returnInt(sql);
            
        }

        public string getAttendeeGUIDfromEmail(string email)
        {
            string sql = "SELECT atn_GUID FROM m_attendees_atn WHERE atn_Email = '" + email + "'";
            string atnGuid = objDAL.ReturnString(sql);
            return atnGuid;
        }

        public DataTable getAttendeeData(int atn_id)
        {
            string sql = "SELECT atn.atn_id, atn.atn_Title, atn.atn_Name, atn.atn_MiddleName, atn.atn_Surname, atn.atn_Email, atn.atn_AlternateEmailAddress, atn.atn_GUID, atn.atn_LegalName, DATE_FORMAT(atn.atn_DateofBirth, '%Y/%m/%d') as atn_DateofBirth, "+
                         "atn.atn_Passport_IdNum, atn.atn_PlaceOfBirth, atn.atn_PlaceOfIssue, DATE_FORMAT(atn.atn_PassportDateOfIssue, '%Y/%m/%d') as atn_PassportDateOfIssue, DATE_FORMAT(atn.atn_PassportExpDate, '%Y/%m/%d') as atn_PassportExpDate, atn.atn_HomePhoneNum, atn.atn_CellNum, atn.atn_EmergencyContactName, " +
                         "atn.atn_EmergencyContactNum, atn.atn_DisabilityRequirements, atn.atn_ClassOfService, atn.atn_SeatingPref, atn.atn_Active, cnt.cnt_Name, ATA.* FROM m_attendees_atn ATN "+ 
                         "LEFT JOIN t_atendeeaddresses_ata ATA ON ata.atn_id = ATN.atn_id "+
                         "LEFT JOIN m_countries_cnt CNT ON cnt.cnt_id = ata.cnt_id " +
                         "WHERE ATN.atn_id = "+atn_id+" AND atn_Active = 1";

            return objDAL.returnDataTable(sql);
        }
        
        public int insertAttendee(string title, string firstName, string middleName, string lastName, string busEmailAddress, string legalName, string dateOfBirth, string idNum, string placeOfBirth, string placeOfIssue, string dateOfIssue, string expDate)
        {
            //atn_HomePhoneNum, atn_CellNum, atn_EmergencyContactName, atn_EmergencyContactNum, atn_DisabilityRequirements,
            int atn_id;
            string sql = "INSERT INTO m_attendees_atn (atn_Title,               atn_Name,                                           atn_MiddleName,                                         atn_Surname,                                atn_Email,                               atn_GUID,          atn_LegalName,                              atn_DateofBirth,                atn_PlaceOfBirth,                               atn_PlaceOfIssue,                   atn_Passport_IdNum, atn_PassportDateOfIssue, atn_PassportExpDate,  atn_Active) VALUES( " +
                                                       "'" + title + "','" + _CommonMethods.replaceApos(firstName) + "','" + _CommonMethods.replaceApos(middleName) + "','" + _CommonMethods.replaceApos(lastName) + "','" + _CommonMethods.replaceApos(busEmailAddress) + "', UUID_SHORT() ,'" + _CommonMethods.replaceApos(legalName) + "','" + dateOfBirth + "','" + _CommonMethods.replaceApos(placeOfBirth) + "','" + _CommonMethods.replaceApos(placeOfIssue) +"','" + idNum + "','" + dateOfIssue + "','" + expDate + "', 1)"
                        + "; SELECT LAST_INSERT_ID(); ";
            atn_id = objDAL.insertDataReturnNewID(sql);
            return atn_id;
        }

        public void updateAttendee(string atn_id, string title, string firstName, string middleName, string lastName, string busEmailAddress, string legalName, string dateOfBirth, string idNum, string placeOfBirth, string placeOfIssue, string dateOfIssue, string expDate)
        {
            string sqlUpdate = "UPDATE m_attendees_atn SET atn_Title = '" + _CommonMethods.replaceApos(title) + "'" +
                                ", atn_Name = '" + _CommonMethods.replaceApos(firstName) +"'"+
                                ", atn_MiddleName = '" + _CommonMethods.replaceApos(middleName) + "'" +
                                ", atn_Surname = '" + lastName + "'" +
                                ", atn_Email = '" + busEmailAddress + "'" +
                                ", atn_LegalName = '" + legalName + "'" +
                                ", atn_DateofBirth = '" + dateOfBirth + "'" +
                                ", atn_Passport_IdNum = '" + idNum + "'" +
                                ", atn_PlaceOfBirth = '" + placeOfBirth + "'" +
                                ", atn_PlaceOfIssue = '" + placeOfIssue + "'" +
                                ", atn_PassportDateOfIssue = '" + dateOfIssue + "'" +
                                ", atn_PassportExpDate = '" + expDate +"'" +
                                " WHERE atn_id = " + atn_id;

            objDAL.updateTable(sqlUpdate);
                
        }



        public DataTable getGeneralInfo(int atn_id)
        {
            string sql = "SELECT atn_DisabilityRequirements, atn_SeatingPref, atn_ClassOfService FROM m_attendees_atn WHERE atn_id =  " + atn_id;
            return objDAL.returnDataTable(sql);
        }

        public DataTable getAttendeeMealInfo(int atn_id)
        {
            string sql = "SELECT amr_Allergy, mrq_Meal, amr.mrq_id FROM t_attendeemealreq_amr AMR INNER JOIN m_mealrequest_mrq MRQ ON mrq.mrq_id = AMR.mrq_id WHERE atn_id = " + atn_id;

            return objDAL.returnDataTable(sql);
        }

        public int getAttendeeStatus(int atn_id, int evt_id)
        {
            int status = 0;
            string sql = "SELECT sts_id FROM t_eventattendees_ead WHERE atn_id = " + atn_id + " AND evt_id = " + evt_id;

            status = objDAL.returnInt(sql);
            return status;
            
        }
    }
}