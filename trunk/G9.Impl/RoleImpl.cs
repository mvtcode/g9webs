using System;
using System.Collections.Generic;
using G9.Entity;
using G9.Service;
using G9.Core;
using System.Data.SqlClient;

namespace G9.Impl
{
    public class RoleImpl : IRole
    {
        #region Insert

        public int Insert(RoleInfo role)
        {
            var param = new[]
                            {
                                new SqlParameter("@s_RoleName", role.s_RoleName)
                            };
            int result = DataHelper.ExecuteNonQuery(Config.ConnectionString, "usp_Role_INSERT", param);
            return result;
        }
        #endregion

        #region Delete
        public int Delete(int id)
        {
            var param = new[]
                            {
                                new SqlParameter("@pk_ID", id)
                            };
            int result = DataHelper.ExecuteNonQuery(Config.ConnectionString, "usp_Role_UDELETE", param);
            return result;
        }
        #endregion

        #region Update
        public int Update(RoleInfo role)
        {
            var param = new[]
                            {
                                new SqlParameter("@pk_ID", role.pk_Id),
                                new SqlParameter("@s_RoleName", role.s_RoleName)
                            };
            int rI = DataHelper.ExecuteNonQuery(Config.ConnectionString, "usp_Role_UPDATE", param);
            return rI;
        }
        #endregion Insert

        #region GetListRoles
        public List<RoleInfo> GetAll()
        {
            var list = new List<RoleInfo>();
            var r = DataHelper.ExecuteReader(Config.ConnectionString, "usp_Role_GetAll");
            while (r.Read())
            {
                list.Add(new RoleInfo
                             {
                               pk_Id  = Convert.ToInt32(r["pk_ID"]),
                               s_RoleName = r["s_RoleName"].ToString()
                             });
            }
            r.Close(); r.Dispose();
            return list;
        }
        #endregion

        #region GetRoleById
        public RoleInfo GetRoleById(int id)
        {
            RoleInfo role = null;
            var param = new[] {new SqlParameter("@pk_ID", id)};
            var r = DataHelper.ExecuteReader(Config.ConnectionString, "usp_Role_GetDetail", param);
            while (r.Read())
            {
                role = new RoleInfo
                           {
                               pk_Id = Convert.ToInt32(r["pk_ID"]),
                               s_RoleName = r["s_RoleName"].ToString()
                           };
            }
            r.Close(); r.Dispose();
            return role;
        }

        #endregion
    }
}
