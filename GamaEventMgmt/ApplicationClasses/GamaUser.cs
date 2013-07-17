using System.Collections.Generic;
using System.Data;
using System.Linq;
using Gama;

namespace GamaEventMgmt.ApplicationClasses
{
    public class GamaUser
    {
        readonly _DataAccessLayer _objDal = new _DataAccessLayer();
        public void InsertGamaUser(string userName, string userSurname, string userEmail, bool isActive, int userType)
        {
            var sql =
                string.Format(
                "insert into m_users_usr (usr_Name,usr_Surname, usr_Email, ust_id, usr_Active) values ('{0}','{1}','{2}',{3},{4})", userName, userSurname, userEmail, userType, isActive ? 1 : 0);
            _objDal.insertData(sql);
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
    }

    public class GamaUserType
    {
        public int Id { get; set; }
        public string GamaTypeName { get; set; }
    }
}