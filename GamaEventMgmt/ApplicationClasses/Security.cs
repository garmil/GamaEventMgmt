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
            string sqlCmd = "SELECT count(usr_id) FROM m_users_usr WHERE usr_Email = @email AND usr_Password = MD5(@password) AND usr_Active = 1 AND usr_Verified = 1";

            validLogin = objDAL.returnBoolean(sqlCmd, email, password);
            
            return validLogin;
            //return true;
        }

        public DataTable getLoginDetails(string email, string password)
        {
            //Add this once the emails are working
            //AND usr_Verified = 1
            string sqlCmd = "SELECT USR.usr_id, USR.usr_Name, USR.usr_Surname, USR.usr_Email, USR.ust_id " +
                            "FROM m_users_usr USR "+
                            "INNER JOIN m_usertypes_ust UST ON USR.ust_id = UST.ust_id "+
                            "WHERE USR.usr_Email = '" + email + "' AND usr_Password = MD5('" + password + "') AND usr_Active = 1 "; 
            return objDAL.returnDataTable(sqlCmd);
        }

        public string verifyEmail(string verificationNum, string email)
        {
            string  verifiedEmail = "";
            //string sql1 = "SELECT usr_Email FROM m_users_usr WHERE usr_Email = '" + email + "' AND usr_VerificationString = '" + verificationNum + "'";
            string sql = "SELECT usr_Email, usr_id, usr_VerificationString FROM m_users_usr WHERE usr_Email = '" + email + "' AND usr_VerificationString = '" + verificationNum + "'";
            DataTable dtSuperReg = objDAL.returnDataTable(sql);

            if (dtSuperReg.Rows.Count > 0)
            {
                verifiedEmail = dtSuperReg.Rows[0]["usr_Email"].ToString();
                this.activateSuperReg(dtSuperReg.Rows[0]["usr_id"].ToString());
            }
            
            return verifiedEmail;
        }

        private void activateSuperReg(string usr_id)
        {
            string sql = "UPDATE m_users_usr SET usr_Verified = 1, usr_Active = 1 WHERE usr_id = " + usr_id;
            objDAL.updateTable(sql);
        }
    }
}