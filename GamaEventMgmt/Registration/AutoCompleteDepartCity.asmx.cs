using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using Gama;

namespace GamaEventMgmt.Registration
{
    /// <summary>
    /// Summary description for AutoCompleteDepartCity
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class AutoCompleteDepartCity : System.Web.Services.WebService
    {

        AirportAirline objAirLines = new AirportAirline();

        [WebMethod]
       
        public string[] GetCompletionList(string prefixText, int count)
        {
            DataTable dt = objAirLines.GetAllDepartureCities(prefixText);

            //Then return List of string(txtItems) as result
            List<string> txtItems = new List<string>();
            String dbValues;

            foreach (DataRow row in dt.Rows)
            {
                //String From DataBase(dbValues)
                dbValues = row["apc_AirportCity"].ToString();
                dbValues = dbValues.ToLower();
                txtItems.Add(dbValues);
            }

            return txtItems.ToArray();
        }
    }
}
