using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;

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

        public void insertUser(string name, string surname, string password, string email, string userType, string verificationString)
        {
            string sqlInsert = "INSERT INTO m_users_usr (usr_Name, usr_Surname, usr_Email, ust_id, usr_Password, usr_Active, usr_VerificationString) " +
                               "VALUES ('" + name + "','" + surname + "','" + email + "'," + userType + ",MD5('" + password + "'), 0, '"+ verificationString+"')";

            objDAL.insertData(sqlInsert);
        }

        public static string RandomString()
        {
            Random random = new Random();

            StringBuilder builder = new StringBuilder();

            char ch;

            for (int i = 0; i < 4; i++)
            {

                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));// Upper case char

                builder.Append(ch);

                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 97)));// Lower case char

                builder.Append(ch);

            }

            return builder.ToString();

        } 

    }
}