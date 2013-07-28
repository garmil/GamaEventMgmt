using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Gama
{
    public class TabFormMgmt
    {
        _DataAccessLayer objDAL = new _DataAccessLayer();

        #region TabMgmt

        public DataTable getViewableEventTabs(string evt_id)
        {
            string sql = "SELECT * FROM  t_eventtabs_etb ETB INNER JOIN m_tabnames_tbn TBN ON tbn.tbn_id = ETB.tbn_id " +
                         "WHERE etb.evt_id = "+evt_id;

            return objDAL.returnDataTable(sql);
        }

        public DataTable getAllTabNames()
        {
            string sql = "SELECT * FROM m_tabnames_tbn ORDER BY tbn_Index";

            return objDAL.returnDataTable(sql);
        }

        public DataTable getEventViewableTabs(string evt_id)
        {
            string sql = "SELECT etb.tbn_id, etb_Visible, tbn_Index FROM t_eventtabs_etb etb "+
                         "INNER JOIN m_tabnames_tbn tbn ON tbn.tbn_id = etb.tbn_id "+
                         "WHERE etb.evt_id = " + evt_id;

            return objDAL.returnDataTable(sql);
        }

        public void deleteUpdateEventTabs(string evt_id, ArrayList arlEventTabSQL)
        {
           

            ArrayList arlTransactions = new ArrayList();

            string sqlStringTrx1 = "DELETE FROM t_eventtabs_etb WHERE evt_id = " + evt_id;
            string sqlStringTrx2 = string.Empty;

            for (int i = 0; i < arlEventTabSQL.Count; i++)
            {
                sqlStringTrx2 += arlEventTabSQL[i].ToString();
            }

            arlTransactions.Add(sqlStringTrx1);
            arlTransactions.Add(sqlStringTrx2);

            objDAL.performTransaction(arlTransactions);

        }

        #endregion

        
    }
}