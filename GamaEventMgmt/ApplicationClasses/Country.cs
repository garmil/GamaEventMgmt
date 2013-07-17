using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Gama
{
    public class Country
    {
        _DataAccessLayer objDAL = new _DataAccessLayer();

        public DataTable getAllCountriesAndRegions()
        {
            string sql = "SELECT * FROM m_countries_cnt order by cnt_Name";

            return objDAL.returnDataTable(sql);
        }
    }
}