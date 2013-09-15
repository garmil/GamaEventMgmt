using System.Data;
using Gama.CommonMethods;

// ReSharper disable CheckNamespace
namespace Gama
// ReSharper restore CheckNamespace
{
    public class Event
    {
        readonly _DataAccessLayer _objDal = new _DataAccessLayer();

        public int InsertEvent(string eventName, int userId, string eventHeader, string eventHTML, string agentEmail, string dateFrom, string dateTo, int expectedNumRegistrants)
        {
            string sql = "INSERT INTO m_event_evt(evt_Name, evt_GUID, usr_id, evt_HeaderHTML, evt_HTML, evt_Agent, evt_DateFrom, evt_DateTo, evt_ExpectedNumRegistrants, evt_Form_ID) VALUES ('" + _CommonMethods.replaceApos(eventName) + "', UUID_SHORT()," + userId + ",'" + _CommonMethods.replaceApos(eventHeader) + "','" + _CommonMethods.replaceApos(eventHTML) + "','" + agentEmail + "','" + dateFrom + "','" + dateTo + "', " + expectedNumRegistrants + ", floor(0+ RAND() * 1000000)); " + 
                "SELECT LAST_INSERT_ID();";

            return _objDal.insertDataReturnNewID(sql);
        }


        public void DeleteEvent(int eventId)
        {
            var sql = string.Format("Delete from m_event_evt where evt_id = {0}",eventId);
            _objDal.deleteData(sql);
        }

        public string GenerateEventHtml(int evtId)
        {
            string sql = "SELECT evt_HTML FROM m_event_evt WHERE evt_id = " + evtId;
            

            return _objDal.ReturnString(sql);
        }

        public bool checkEventNameExists(string eventName)
        {
            string sql = "SELECT COUNT(evt_id) FROM m_event_evt WHERE evt_Name = '" + eventName + "'";

            return (_objDal.returnBoolean(sql));

        }

        public int GetEventId(string eventGuid)
        {
            string sql = "SELECT evt_id FROM m_event_evt WHERE evt_GUID = '" + eventGuid + "'";
            return _objDal.returnInt(sql);
        }

        public string GenerateEventHeader(string evtGuid)
        {
            string sql = "SELECT evt_HeaderHTML FROM m_event_evt WHERE evt_GUID = '" + evtGuid + "'";

            return _objDal.ReturnString(sql);
        }

        public string GenerateEventHtml(string evtGuid)
        {
            string sql = "SELECT evt_HTML FROM m_event_evt WHERE evt_GUID = '" + evtGuid +"'";
             
            return _objDal.ReturnString(sql);
        }

        public string GenerateEventHtml(string evtGuid, bool showHeader)
        {
            string sql = "SELECT Concat(IFNULL(evt_HeaderHTML,''), evt_HTML) as evt_HTML FROM m_event_evt WHERE evt_GUID = '" + evtGuid + "'";

            return _objDal.ReturnString(sql);
        }

        public DataTable GetAllEvents()
        {
            const string sql = "SELECT evt_id, evt_Name FROM m_event_evt ORDER BY evt_Name;";

            var dtEvents = _objDal.returnDataTable(sql);
            return dtEvents;
        }

        public DataTable GetEventData(string evtId)
        {
            var sql = "SELECT evt_id, evt_Name, evt_HTML, evt_HeaderHTML, evt_Agent, evt_GUID, DATE_FORMAT(evt_DateFrom, '%Y/%m/%d') as evt_DateFrom, DATE_FORMAT(evt_DateTo, '%Y/%m/%d') as evt_DateTo, IFNULL(evt_ExpectedNumRegistrants,0) as evt_ExpectedNumRegistrants, evt_Form_ID  FROM m_event_evt WHERE evt_id = " + evtId + " ORDER BY evt_Name;";

            var dtEvents = _objDal.returnDataTable(sql);
            return dtEvents;
        }

        public DataTable getEventsByDateRange(string dateFrom, string dateTo)
        {
            string sql = "SELECT evt_id, evt_GUID, evt_Name as `Event Name`, DATE_FORMAT(evt_DateFrom, '%Y/%m/%d') as `Event Start`, DATE_FORMAT(evt_DateTo, '%Y/%m/%d') as `Event End`,  " +
                         "FROM m_event_evt " +
                         "WHERE evt_DateFrom >= '" + dateFrom + "' AND evt_DateTo <= '" + dateTo + "' ORDER BY evt_DateFrom DESC";

            return _objDal.returnDataTable(sql);
        }

        public DataTable getEventAttendantStats(string evtId)
        {
            string sql = "SELECT 'Unregistered' as Status, COUNT(atn_id) as NumberAttendees " +
                         "FROM t_eventattendees_ead " +
                         "WHERE evt_id = " + evtId + " AND sts_id = 1 " +
                         "UNION ALL " +
                         "SELECT 'Registered' as Status, COUNT(atn_id) as NumberAttendees " +
                         "FROM t_eventattendees_ead " +
                         "WHERE evt_id = " + evtId + " AND sts_id = 2 " +
                         "UNION ALL " +
                         "SELECT 'At Agent', COUNT(atn_id) as NumberAttendees " +
                         "FROM t_eventattendees_ead " +
                         "WHERE evt_id = " + evtId + " AND sts_id = 3 " +
                         "UNION ALL " +
                         "SELECT 'Booking Completed', COUNT(atn_id) as NumberAttendees " +
                         "FROM t_eventattendees_ead " +
                         "WHERE evt_id = " + evtId + " AND sts_id = 4;";

            return _objDal.returnDataTable(sql);
        }

        public DataTable getEventAttendeeStatsData(string evtId)
        {
            string sql ="SELECT evt_Name as `Event`, atn.atn_Name `Registrant Name`, atn.atn_Surname `Registrant Last Name`, " +
                "atn.atn_Email `Email`, atn.atn_CellNum `Cell Num`, atn.atn_HomePhoneNum `Home Phone` " +
                "FROM t_eventattendees_ead EAD " +
                "INNER JOIN m_attendees_atn ATN ON ATN.atn_id = EAD.atn_id " +
                "INNER JOIN m_status_sts STS ON sts.sts_id = EAD.sts_id " +
                "INNER JOIN m_event_evt EVT ON evt.evt_id = EAD.evt_id " +
                "WHERE ead.evt_id =" + evtId;

            return _objDal.returnDataTable(sql);
        }

        #region eventFunctions

        public void InsertEventFunction(string evtId, int evfSeats, string evfOfferName, string evfDesc )
        {
            string sqlInsert = "INSERT INTO t_eventfunctions_evf (evt_id, evf_AvailableSeats, evf_OfferName, evf_Desc) " +
                               "VALUES(" + evtId + "," + evfSeats + ",'" + evfOfferName + "','" + evfDesc + "')";

            _objDal.insertData(sqlInsert);
        }

        #endregion

        internal void InsertEventAttendeeStatus(int atnId, string stsId, int evtId)
        {
            string sql = "INSERT INTO t_eventattendees_ead(atn_id, sts_id, evt_id) VALUES(" + atnId + "," + stsId + "," + evtId + ")";

            _objDal.insertData(sql);
        }

        internal void UpdateEventAttendeeStatus(int atnId, string stsId, int evtId)
        {
            string sql = "UPDATE t_eventattendees_ead SET sts_id = "+stsId+ " WHERE atn_id =" + atnId + " AND evt_id = " + evtId;

            _objDal.insertData(sql);
        }

        public string GetEventAgent(int evtId)
        {
            string sql = "SELECT evt_Agent FROM m_event_evt WHERE evt_id = " + evtId;

            return _objDal.ReturnString(sql);
        }

        public void UpdateEvent(string evtId, string evtName, string eventHeader, string eventHTML, string agentEmail, string dateFrom, string dateTo, int expectedNumRegistrants)
        {
            string sql = "UPDATE m_event_evt SET " +
                        "evt_Name = '" + _CommonMethods.replaceApos(evtName) + "'" +
                        ",evt_HeaderHTML = '" + _CommonMethods.replaceApos(eventHeader) + "'" +
                        ", evt_HTML = '" + _CommonMethods.replaceApos(eventHTML) + "'" +
                        ", evt_DateFrom ='" +dateFrom +"'" +
                        ", evt_DateTo ='" +dateTo +"'"+
                        ", evt_ExpectedNumRegistrants = " + expectedNumRegistrants +
                        ",evt_Agent = '" + agentEmail + "' WHERE evt_id = " + evtId;
            _objDal.updateTable(sql);

        }

        public string GetEventGuid(string eventId)
        {
            string sql = "SELECT evt_GUID FROM m_event_evt WHERE evt_id =" + eventId;

            string guid = _objDal.ReturnString(sql);

            return guid;
        }

        #region EventFunction

        //public void insertEventFunction(string evt_id, int availableSeats, string evtOfferName, string evtDesc)
        //{
        //    string sql = "INSERT INTO t_eventfunctions_evf(evt_id, evf_AvailableSeats, evf_OfferName, evf_Desc) VALUES (" + evt_id + "," + availableSeats + ",'" + evtOfferName + "', '" + evtDesc + "')";
        //    objDAL.insertData(sql);

        //}

        public void UpdateEventFunction(string evfId, string evtId, int availableSeats, string evfOffername, string evfDesc)
        {
            string sql = "UPDATE t_eventfunctions_evf SET evt_id = " + evtId + ", evf_AvailableSeats = " + availableSeats + ", evf_OfferName = '" + evfOffername + "', evf_Desc =  '" + evfDesc + "' WHERE evf_id = " + evfId;
            _objDal.updateTable(sql);
        }


        public DataTable GetEventFunctions(string evtId)
        {

            string sql = "SELECT evf_id, evt_id, evt_Name, evf_OfferName, evf_Desc, evf_AvailableSeats " +
                         "FROM t_eventfunctions_evf EVF "+
                         "INNER JOIN m_event_evt EVT ON evt.evt_id = evf.evt_id WHERE EVF.evt_id = " + evtId;
            return _objDal.returnDataTable(sql);
        }

        public void UpdateSeatsAvailable(string evfId, int availableSeats)
        {
            string sql = "UPDATE t_eventfunctions_evf SET evf_AvailableSeats = " + availableSeats + " WHERE evf_id = " + evfId;
            _objDal.updateTable(sql);
        }


        public void DeleteEventFunction(string evfId)
        {
            string sql = "DELETE FROM t_eventfunctions_evf WHERE evf_id = " + evfId;
            _objDal.deleteData(sql);

        }
        #endregion

        internal bool eventActive(string evtGUID)
        {
            bool evtActive = false;
            string sql = "SELECT evt_Active FROM m_event_evt WHERE evt_GUID = '" + evtGUID + "'";

            if (_objDal.returnInt(sql) == 1)
            {
                evtActive = true;
            }
            else
            {
                evtActive = false;
            }

            return evtActive;
        }

        public int getNumRegistrants(string evt_id)
        {
            
            string sql = "SELECT COUNT(atn_id) as NumberAttendees FROM t_eventattendees_ead WHERE evt_id = " + evt_id +
                         " AND sts_id = 1 ";

            return _objDal.returnInt(sql);
        }

        public int getAttendeeEvent(int atn_id, int evt_id)
        {
            string sql = "SELECT COUNT(ead_id) as eads FROM t_eventattendees_ead WHERE atn_id = " + atn_id +
                         " AND evt_id = " + evt_id;

            return _objDal.returnInt(sql);
        }

        public string getEventNameById(int evt_id)
        {
            string sql = "SELECT evt_Name from m_Event_evt WHERE evt_id = " + evt_id;

            return _objDal.ReturnString(sql);
        }

        internal int GetEventIdByName(string eventName)
        {
            string sql = "SELECT evt_id FROM m_event_evt WHERE evt_Name='" + eventName + "'";

            return _objDal.returnInt(sql);
        }
    }
}