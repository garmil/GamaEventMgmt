using System.Data;

// ReSharper disable CheckNamespace
namespace Gama
// ReSharper restore CheckNamespace
{
    public class Event
    {
        readonly _DataAccessLayer _objDal = new _DataAccessLayer();

        public void InsertEvent(string eventName, int userId, string eventHTML, string agentEmail)
        {
            string sql = "INSERT INTO m_event_evt(evt_Name, evt_GUID, usr_id, evt_HTML, evt_Agent) VALUES ('" + eventName + "', UUID_SHORT()," + userId + ",'" + eventHTML + "','" + agentEmail + "')";

            _objDal.insertData(sql);
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

        public int GetEventId(string eventGuid)
        {
            string sql = "SELECT evt_id FROM m_event_evt WHERE evt_GUID = '" + eventGuid + "'";
            return _objDal.returnInt(sql);
        }

        public string GenerateEventHtml(string evtGuid)
        {
            string sql = "SELECT evt_HTML FROM m_event_evt WHERE evt_GUID = '" + evtGuid +"'";
             
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
            var sql = "SELECT evt_id, evt_Name, evt_HTML, evt_Agent FROM m_event_evt WHERE evt_id = "+evtId+" ORDER BY evt_Name;";

            var dtEvents = _objDal.returnDataTable(sql);
            return dtEvents;
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

        public string GetEventAgent(int evtId)
        {
            string sql = "SELECT evt_Agent FROM m_event_evt WHERE evt_id = " + evtId;

            return _objDal.ReturnString(sql);
        }

        public void UpdateEvent(string evtId, string evtName, string eventHTML, string agentEmail)
        {
            string sql = "UPDATE m_event_evt SET " +
                        "evt_Name = '" + evtName + "'" +
                        ", evt_HTML = '" + eventHTML + "'" +
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
    }
}