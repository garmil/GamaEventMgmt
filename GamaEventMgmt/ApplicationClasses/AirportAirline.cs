using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Gama;
using MySql.Data.MySqlClient;

namespace Gama
{
    public class AirportAirline
    {
        readonly _DataAccessLayer _objDal = new _DataAccessLayer();

        public DataTable GetAllDepartureCities()
        {
            const string sql = "SELECT * FROM m_airportcitites_apc ORDER BY apc_AirportCity";

            var dtEvents = _objDal.returnDataTable(sql);
            return dtEvents;
        }

        public DataTable GetAllDepartureCities(string searchText)
        {
            string sql = "SELECT * FROM m_airportcitites_apc WHERE apc_AirportCity LIKE '%"+searchText+"%' ORDER BY apc_AirportCity";

            var dtEvents = _objDal.returnDataTable(sql);
            return dtEvents;
        }

        public int getDepartCityID(string departCity)
        {
            string sql = "SELECT apc_id FROM m_airportcitites_apc WHERE apc_AirportCity = '" + departCity + "'";
            return _objDal.returnInt(sql);
        }

        public DataTable GetAllAirlines()
        {
            const string sql = "SELECT aln_id, aln_Code, aln_Airline, CONCAT(aln_Airline ,' (' , aln_Code , ')') as airlineAndCode FROM m_airlines_aln ORDER BY aln_Airline;";

            var dtEvents = _objDal.returnDataTable(sql);
            return dtEvents;
        }

        public DataTable getAttendeePreferredAirline(string atn_id)
        {
            string sql = "SELECT apa_id, aln.aln_id, apa_FlightNum, CONCAT(atn.atn_Name, ' ', atn.atn_Surname) as AttName, CONCAT(aln.aln_Airline,  ' (',aln.aln_Code,')') as  aln_Airline " +
                         "FROM t_attendeepreferredairline_apa APA INNER JOIN m_attendees_atn atn ON atn.atn_id = apa.atn_id " +
                         "INNER JOIN m_airlines_aln aln ON aln.aln_id = apa.aln_id WHERE apa.atn_id = " + atn_id + " ORDER BY aln.aln_Airline";

            return _objDal.returnDataTable(sql);
        }

        public void insertAttendeePreferredAirline(string atn_id, string aln_id, string flightNum)
        {
            string sql = "INSERT INTO t_attendeepreferredairline_apa(atn_id, aln_id, apa_FlightNum) VALUES (" + atn_id + "," + aln_id + ",'" +flightNum +"')";
            _objDal.insertData(sql);
        }

        public void updateAttendeePreferredAirline(string apa_id, string aln_id, string flightNum)
        {
            string sql = "UPDATE t_attendeepreferredairline_apa SET aln_id = " + aln_id + ", apa_FlightNum = '" + flightNum +"'  WHERE apa_id = " + apa_id;

            _objDal.updateTable(sql);
        }

        public void deleteAttendeePrefferedAirline(string apa_id)
        {
            string sql = "DELETE FROM t_attendeepreferredairline_apa WHERE apa_id =" + apa_id;
            _objDal.deleteData(sql);

        }

        //internal List<string> GetAllAirlinesForAutoComplete(string searchText)
        //{
            
        //    List<string> result = new List<string>(); 
        //    string sql = "SELECT aln_id, aln_Airline, CONCAT(aln_Airline ,' (' , aln_Code , ')') as airlineAndCode FROM m_airlines_aln "+
        //                       "WHERE CONCAT(aln_Airline ,' (' , aln_Code , ')') LIKE '%'"+searchText +"'%' ORDER BY CONCAT(aln_Airline ,' (' , aln_Code , ')');";
        //    result = _objDal.returnList(sql);
        //    return result;
        //}

        internal DataTable GetAllAirlinesForAutoComplete(string searchText)
        {

            
            string sql = "SELECT aln_id, aln_Code, aln_Airline, CONCAT(aln_Airline ,' (' , aln_Code , ')') as airlineAndCode FROM m_airlines_aln "+
                         "WHERE CONCAT(aln_Airline ,' (' , aln_Code , ')') LIKE '%"+searchText+"%' "+
                         "ORDER BY CONCAT(aln_Airline ,' (' , aln_Code , ')');";
            DataTable dtAirLineAirports = _objDal.returnDataTable(sql);
            return dtAirLineAirports;
        }

        public int getAirlineID(string airline)
        {
            string sql = "SELECT aln_id FROM m_airlines_aln WHERE CONCAT(aln_Airline ,' (' , aln_Code , ')') = '"+airline+"'";
            return _objDal.returnInt(sql);
        }
    }
}