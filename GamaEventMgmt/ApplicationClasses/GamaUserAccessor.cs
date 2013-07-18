using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Gama;

namespace GamaEventMgmt.ApplicationClasses
{
    public class GamaUserAccessor
    {
        readonly _DataAccessLayer _objDal = new _DataAccessLayer();
        public void InsertGamaUser(string userName, string userSurname, string userEmail, bool isActive, int userType)
        {
            var sql =
                string.Format(
                "insert into m_users_usr (usr_Name,usr_Surname, usr_Email, ust_id, usr_Active) values ('{0}','{1}','{2}',{3},{4})", userName, userSurname, userEmail, userType, isActive ? 1 : 0);
            _objDal.insertData(sql);
        }


        public void UpdateGamaUser(int usertypeId, string name, string surname, string email, bool isActive, int id)
        {
            var sql =
                string.Format(
                "update m_users_usr set usr_Name = '{0}',usr_Surname = '{1}', usr_Email = '{2}', usr_Active = {3},  ust_id =  {4}  where usr_id  =  {5}", name, surname, email, isActive ? 1 : 0, usertypeId, id);
            _objDal.updateTable(sql);
        }


        public IList<GamaUserType> GetAllUserTypes()
        {
            const string sql = "select *  from m_usertypes_ust;";
            var result = _objDal.returnDataTable(sql);
            return (from DataRow row in result.Rows
                    select new GamaUserType
                               {
                                   GamaTypeName = row["ust_UserType"].ToString(),
                                   Id = int.Parse(row["ust_id"].ToString())
                               }).ToList();
        }


        public IList<GamaUser> GetAllUsers()
        {
            const string sql = "select *  from m_users_usr;";
            var result = _objDal.returnDataTable(sql);
            return (from DataRow row in result.Rows
                    select new GamaUser
                    {
                        Name = row["usr_Name"].ToString(),
                        Surname = row["usr_Surname"].ToString(),
                        Email = row["usr_Email"].ToString(),
                        IsActive = Convert.ToBoolean(row["usr_Active"].ToString()),
                        UsertypeId = Convert.ToInt32(row["ust_id"].ToString()),
                        Id = Convert.ToInt32(row["usr_id"].ToString()),
                    }).ToList();
        }

    }

    public class GamaUser
    {
        public int UsertypeId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }

        public int Id { get; set; }
    }

    public class GamaUserType
    {
        public int Id { get; set; }
        public string GamaTypeName { get; set; }
    }
}