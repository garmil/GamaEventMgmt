using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Gama
{
    public class Security
    {
        
         _DataAccessLayer objDAL = new _DataAccessLayer();

        private string _connectionString;
        
        public Security()
        {
            Initialize();
        }

        public void Initialize()
        {
            // Initialize data source. 

            if (ConfigurationManager.ConnectionStrings["GCS"] == null ||
                ConfigurationManager.ConnectionStrings["GCS"].ConnectionString.Trim() == "")
            {
                throw new Exception("A connection string named 'GCS' with a valid connection string " +
                                    "must exist in the <connectionStrings> configuration section for the application.");
            }

            _connectionString = ConfigurationManager.ConnectionStrings["GCS"].ConnectionString;
           
        }

        public bool loginValid(string email, string password)
        {
            bool validLogin = false;
            string sqlCmd = "SELECT count(usr_id) FROM m_users_usr WHERE usr_Email = @email AND usr_Password = MD5(@password)";

            validLogin = objDAL.returnBoolean(sqlCmd, email, password);
            
            return validLogin;
            //return true;
        }

        public DataTable getLoginDetails(string email, string password)
        {
            string sqlCmd = "SELECT USR.usr_id, USR.usr_Name, USR.usr_Surname, USR.usr_Email, USR.ust_id " +
                            "FROM m_users_usr USR "+
                            "INNER JOIN m_usertypes_ust UST ON USR.ust_id = UST.ust_id "+
                            "WHERE USR.usr_Email = '" + email + "' AND usr_Password = MD5('" + password + "')";
            return objDAL.returnDataTable(sqlCmd);
        }
    }
}