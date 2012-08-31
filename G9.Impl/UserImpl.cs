using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using G9.Core;
using G9.Entity;
using G9.Service;
using G9.Web.Utility;

namespace G9.Impl
{
    public class UserImpl : IUser
    {
        public int Insert(UserInfo info)
        {
            var param = new[]
                            {
                                new SqlParameter("@sUsername", info.sUsername),
                                new SqlParameter("@sPassword", UntilityFunction.EncodePassword(info.sPassword)),
                                new SqlParameter("@sFullName",info.sFullName),
                                new SqlParameter("@sEmail", info.sEmail),
                                new SqlParameter("@sMobile", info.sMobile),
                                new SqlParameter("@sAddress", info.sAddress),
                                new SqlParameter("@sCompany", info.sCompany),
                                new SqlParameter("@sHomepage", info.sHomepage)
                            };
            var result = DataHelper.ExecuteNonQuery(Config.ConnectionString, "usp_User_INSERT", param);
            return result;
        }

        public int Update(UserInfo info)
        {
            var param = new[]
                            {
                                new SqlParameter("@id", info.id),
                                new SqlParameter("@sFullName",info.sFullName),
                                new SqlParameter("@sEmail", info.sEmail),
                                new SqlParameter("@sMobile", info.sMobile),
                                new SqlParameter("@sAddress", info.sAddress),
                                new SqlParameter("@sCompany", info.sCompany),
                                new SqlParameter("@sHomepage", info.sHomepage)
                            };
            var result = DataHelper.ExecuteNonQuery(Config.ConnectionString, "usp_User_UPDATE", param);
            return result;
        }

        public int Delete(int id)
        {
            var param = new[] {new SqlParameter("@id", id)};
            var result = DataHelper.ExecuteNonQuery(Config.ConnectionString, "usp_User_DELETE", param);
            return result;
        }

        public UserInfo GetUser(string sUsername)
        {
            UserInfo userInfo = null;
            var param = new[] { new SqlParameter("@sUsername", sUsername) };
            var r = DataHelper.ExecuteReader(Config.ConnectionString, "usp_User_GetDetail_Username", param);
            while (r.Read())
            {
                userInfo = new UserInfo
                {
                    id = (int)r["id"],
                    sUsername = r["sUsername"].ToString(),
                    sFullName = r["sFullName"].ToString(),
                    sEmail = r["sEmail"].ToString(),
                    sAddress = r["sAddress"].ToString(),
                    sMobile = r["sMobile"].ToString(),
                    sCompany = r["sCompany"].ToString(),
                    sHomepage = r["sHomepage"].ToString(),
                    CreateDate = System.Convert.ToDateTime(r["CreateDate"]),
                    active = ConvertUtility.ToBoolean(r["active"])
                };
            }
            r.Close(); r.Dispose();
            return userInfo;
        }

        public UserInfo GetUser(int id)
        {
            UserInfo userInfo = null;
            var param = new[] { new SqlParameter("@id", id) };
            var r = DataHelper.ExecuteReader(Config.ConnectionString, "usp_User_GetDetail", param);
            while (r.Read())
            {
                userInfo = new UserInfo
               {
                   id = (int)r["id"],
                   sUsername = ConvertUtility.ToString(r["sUsername"]),
                   sFullName = r["sFullName"].ToString(),
                   sEmail = r["sEmail"].ToString(),
                   sAddress = r["sAddress"].ToString(),
                   sMobile = r["sMobile"].ToString(),
                   sCompany = r["sCompany"].ToString(),
                   sHomepage = r["sHomepage"].ToString(),
                   CreateDate = System.Convert.ToDateTime(r["CreateDate"]),
                   active = ConvertUtility.ToBoolean(r["active"])
               };
            }
            r.Close();r.Dispose();
            return userInfo;
        }

        public UserInfo CheckLogin(string s_Username, string s_Password)
        {
            var param = new[]
                            {
                                new SqlParameter("@sUsername", s_Username),
                                new SqlParameter("@sPassword", UntilityFunction.EncodePassword(s_Password))
                            };
            var r = DataHelper.ExecuteReader(Config.ConnectionString, "usp_User_CheckLogin", param);
            UserInfo userInfo = null;
            while (r.Read())
            {
                userInfo = new UserInfo
                {
                    id = (int)r["id"],
                    sUsername = ConvertUtility.ToString(r["sUsername"]),
                    sFullName = r["sFullName"].ToString(),
                    sEmail = r["sEmail"].ToString(),
                    sAddress = r["sAddress"].ToString(),
                    sMobile = r["sMobile"].ToString(),
                    sCompany = r["sCompany"].ToString(),
                    sHomepage = r["sHomepage"].ToString(),
                    CreateDate = System.Convert.ToDateTime(r["CreateDate"]),
                    active = ConvertUtility.ToBoolean(r["active"])
                };
            }
            r.Close(); r.Dispose();
            return userInfo;
        }

        public int CheckExist(string s_Username)
        {
            var param = new[]
                            {
                                new SqlParameter("@sUserName",s_Username),
                                new SqlParameter("@iExists",SqlDbType.Int){Direction = ParameterDirection.Output}
                            };
            SqlCommand cmd;
            DataHelper.ExecuteReader(Config.ConnectionString, "usp_User_CheckExists", param, out cmd);
            return System.Convert.ToInt32(cmd.Parameters[1].Value);
        }

        public List<UserInfo> GetListUser(int pageIndex, int pageSize, out int totalrow)
        {
            List<UserInfo> list = null;
            var param = new[]
                            {
                                new SqlParameter("@pageIndex", pageIndex),
                                new SqlParameter("@pageSize", pageSize),
                                new SqlParameter("@totalrow",SqlDbType.Int){Direction = ParameterDirection.Output}
                            };
            SqlCommand cmd;
            var r = DataHelper.ExecuteReader(Config.ConnectionString, "usp_User_GetList", param, out cmd);
            list=new List<UserInfo>();
            while (r.Read())
            {
                list.Add(new UserInfo
                             {
                                 id = (int)r["id"],
                                 sUsername = ConvertUtility.ToString(r["sUsername"]),
                                 sFullName = r["sFullName"].ToString(),
                                 sEmail = r["sEmail"].ToString(),
                                 sAddress = r["sAddress"].ToString(),
                                 sMobile = r["sMobile"].ToString(),
                                 sCompany = r["sCompany"].ToString(),
                                 sHomepage = r["sHomepage"].ToString(),
                                 CreateDate = System.Convert.ToDateTime(r["CreateDate"]),
                                 active = ConvertUtility.ToBoolean(r["active"])
                             });
            }
            r.Close(); r.Dispose();
            totalrow = (int) cmd.Parameters[2].Value;
            return list;
        }



        public List<UserInfo> GetListUser()
        {
            List<UserInfo> list = null;
            SqlCommand cmd;
            var r = DataHelper.ExecuteReader(Config.ConnectionString, "Select * from tbl_User");
            list = new List<UserInfo>();
            while (r.Read())
            {
                list.Add(new UserInfo
                {
                    id = (int)r["id"],
                    sUsername = ConvertUtility.ToString(r["sUsername"]),
                    sFullName = r["sFullName"].ToString(),
                    sEmail = r["sEmail"].ToString(),
                    sAddress = r["sAddress"].ToString(),
                    sMobile = r["sMobile"].ToString(),
                    sCompany = r["sCompany"].ToString(),
                    sHomepage = r["sHomepage"].ToString(),
                    CreateDate = System.Convert.ToDateTime(r["CreateDate"]),
                    active = ConvertUtility.ToBoolean(r["active"])
                });
            }
            r.Close(); 
            r.Dispose();
            return list;
        }

        public UserInfo GetUserByEmail(string sEmail)
        {
            var param = new[]
                            {
                                new SqlParameter("@sEmail", sEmail)
                            };
            var r = DataHelper.ExecuteReader(Config.ConnectionString, "usp_User_GetByEmail", param);
            UserInfo userInfo = null;
            while (r.Read())
            {
                userInfo = new UserInfo
                {
                    id = (int)r["id"],
                    sUsername = ConvertUtility.ToString(r["sUsername"]),
                    sFullName = r["sFullName"].ToString(),
                    sEmail = r["sEmail"].ToString(),
                    sAddress = r["sAddress"].ToString(),
                    sMobile = r["sMobile"].ToString(),
                    sCompany = r["sCompany"].ToString(),
                    sHomepage = r["sHomepage"].ToString(),
                    CreateDate = System.Convert.ToDateTime(r["CreateDate"]),
                    active = ConvertUtility.ToBoolean(r["active"])
                };
            }
            r.Close(); r.Dispose();
            return userInfo;
        }

        public int ChangePass(int id, string sNewPass)
        {
            var param = new[]
                            {
                                new SqlParameter("@id", id),
                                new SqlParameter("@sPassword", UntilityFunction.EncodePassword(sNewPass))
                            };
            var result = DataHelper.ExecuteNonQuery(Config.ConnectionString, "usp_User_ChangePass", param);
            return result;
        }

        public List<UserInfo> GetNew(int iTop)
        {
            List<UserInfo> list = null;
            var param = new[]
                            {
                                new SqlParameter("@top", iTop)
                            };
            var r = DataHelper.ExecuteReader(Config.ConnectionString, "usp_User_GetNewUser",param);
            list = new List<UserInfo>();
            while (r.Read())
            {
                list.Add(new UserInfo
                {
                    id = (int)r["id"],
                    sUsername = ConvertUtility.ToString(r["sUsername"]),
                    sFullName = r["sFullName"].ToString(),
                    sEmail = r["sEmail"].ToString(),
                    sAddress = r["sAddress"].ToString(),
                    sMobile = r["sMobile"].ToString(),
                    sCompany = r["sCompany"].ToString(),
                    sHomepage = r["sHomepage"].ToString(),
                    CreateDate = System.Convert.ToDateTime(r["CreateDate"]),
                    active = ConvertUtility.ToBoolean(r["active"])
                });
            }
            r.Close();
            r.Dispose();
            return list;
        }

        public int CountUser()
        {
            int n = 0;
            var r = DataHelper.ExecuteReader(Config.ConnectionString, "usp_User_Count");
            while (r.Read())
            {
                n= (int)r["iRow"];
            }
            r.Close();
            r.Dispose();
            return n;
        }

        public bool CheckPass(int id, string sPassword)
        {
            int n = 0;
            var param = new[]
                            {
                                new SqlParameter("@id", id),
                                new SqlParameter("@sPassword", UntilityFunction.EncodePassword(sPassword))
                            };
            var r = DataHelper.ExecuteReader(Config.ConnectionString, "usp_User_CheckPass", param);
            while (r.Read())
            {
                n = (int)r["iRow"];
            }
            r.Close();
            r.Dispose();
            return (n>0);
        }
    }
}
