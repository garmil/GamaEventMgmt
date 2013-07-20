using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace Gama
{
    public class Event
    {
        _DataAccessLayer objDAL = new _DataAccessLayer();

        public void insertEvent(string eventName, int userId, string eventHTML, string agentEmail)
        {
            string sql = "INSERT INTO m_event_evt(evt_Name, evt_GUID, usr_id, evt_HTML, evt_Agent) VALUES ('" + eventName + "', UUID_SHORT()," + userId + ",'" + eventHTML + "','" + agentEmail + "')";

            objDAL.insertData(sql);
        }

        public string generateEventHTML(int evt_id)
        {
            string sql = "SELECT evt_HTML FROM m_event_evt WHERE evt_id = " + evt_id;
            

            return objDAL.returnString(sql);
        }

        public int getEventId(string eventGUID)
        {
            string sql = "SELECT evt_id FROM m_event_evt WHERE evt_GUID = '" + eventGUID + "'";
            return objDAL.returnInt(sql);
        }

        public string generateEventHTML(string evtGUID)
        {
            string sql = "SELECT evt_HTML FROM m_event_evt WHERE evt_GUID = '" + evtGUID +"'";
             
            return objDAL.returnString(sql);
        }

        public DataTable getAllEvents()
        {
            DataTable dtEvents = new DataTable();
            string sql = "SELECT evt_id, evt_Name FROM m_event_evt ORDER BY evt_Name;";

            dtEvents = objDAL.returnDataTable(sql);
            return dtEvents;
        }

        public DataTable getEventData(string evt_id)
        {
            DataTable dtEvents = new DataTable();
            string sql = "SELECT evt_id, evt_Name, evt_HTML, evt_Agent FROM m_event_evt WHERE evt_id = "+evt_id+" ORDER BY evt_Name;";

            dtEvents = objDAL.returnDataTable(sql);
            return dtEvents;
        }

        #region eventFunctions

        public void insertEventFunction(string evt_id, int evfSeats, string evfOfferName, string evf_desc )
        {
            string sqlInsert = "INSERT INTO t_eventfunctions_evf (evt_id, evf_AvailableSeats, evf_OfferName, evf_Desc) " +
                               "VALUES(" + evt_id + "," + evfSeats + ",'" + evfOfferName + "','" + evf_desc + "')";

            objDAL.insertData(sqlInsert);
        }

        #endregion

        internal void insertEventAttendeeStatus(int atn_id, string sts_id, int evt_id)
        {
            string sql = "INSERT INTO t_eventattendees_ead(atn_id, sts_id, evt_id) VALUES(" + atn_id + "," + sts_id + "," + evt_id + ")";

            objDAL.insertData(sql);
        }

        public string getEventAgent(int evt_id)
        {
            string sql = "SELECT evt_Agent FROM m_event_evt WHERE evt_id = " + evt_id;

            return objDAL.returnString(sql);
        }

        public void updateEvent(string evt_id, string evt_Name, string eventHTML, string agentEmail)
        {
            string sql = "UPDATE m_event_evt SET " +
                        "evt_Name = '" + evt_Name + "'" +
                        ", evt_HTML = '" + eventHTML + "'" +
                        ",evt_Agent = '" + agentEmail + "' WHERE evt_id = " + evt_id;
            objDAL.updateTable(sql);

        }

        public string getEventGUID(string eventID)
        {
            string guid = string.Empty;
            string sql = "SELECT evt_GUID FROM m_event_evt WHERE evt_id =" + eventID;

            guid = objDAL.returnString(sql);

            return guid;
        }

        #region EventFunction

        //public void insertEventFunction(string evt_id, int availableSeats, string evtOfferName, string evtDesc)
        //{
        //    string sql = "INSERT INTO t_eventfunctions_evf(evt_id, evf_AvailableSeats, evf_OfferName, evf_Desc) VALUES (" + evt_id + "," + availableSeats + ",'" + evtOfferName + "', '" + evtDesc + "')";
        //    objDAL.insertData(sql);

        //}

        public void updateEventFunction(string evf_id, string evt_id, int availableSeats, string evfOffername, string evfDesc)
        {
            string sql = "UPDATE t_eventfunctions_evf SET evt_id = " + evt_id + ", evf_AvailableSeats = " + availableSeats + ", evf_OfferName = '" + evfOffername + "', evf_Desc =  '" + evfDesc + "' WHERE evf_id = " + evf_id;
            objDAL.updateTable(sql);
        }


        public DataTable getEventFunctions(string evt_id)
        {

            string sql = "SELECT evf_id, evt_id, evt_Name, evf_OfferName, evf_Desc, evf_AvailableSeats " +
                         "FROM t_eventfunctions_evf EVF "+
                         "INNER JOIN m_event_evt EVT ON evt.evt_id = evf.evt_id WHERE EVF.evt_id = " + evt_id;
            return objDAL.returnDataTable(sql);
        }

        public void updateSeatsAvailable(string evf_id, int availableSeats)
        {
            string sql = "UPDATE t_eventfunctions_evf SET evf_AvailableSeats = " + availableSeats + " WHERE evf_id = " + evf_id;
            objDAL.updateTable(sql);
        }


        public void deleteEventFunction(string evf_id)
        {
            string sql = "DELETE FROM t_eventfunctions_evf WHERE evf_id = " + evf_id;
            objDAL.deleteData(sql);

        }
        #endregion
    }
}