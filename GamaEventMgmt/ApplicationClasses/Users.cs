using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace Gama
{
    public class Users
    {
        _DataAccessLayer objDAL = new _DataAccessLayer();

        public void insertUser(string name, string surname, string password, string email, string userType)
        {
            string sqlInsert = "INSERT INTO m_users_usr (usr_Name, usr_Surname, usr_Email, ust_id, usr_Password, usr_Active) " +
                               "VALUES ('" + name + "','" + surname + "','" + email + "'," + userType + ",MD5('"+password+"'), 1)";

            objDAL.insertData(sqlInsert);
        }

    }
}