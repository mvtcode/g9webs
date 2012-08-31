using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using G9.Core;
using G9.Entity;
using G9.Service;

namespace G9.Impl
{
    public class SupportImpl : ISupport
    {
        #region getListSupportInfo
        public List<SupportInfo> getListSupportInfo(int topNum)
        {
            var list = new List<SupportInfo>();
            var param = new[]
                            {
                                new SqlParameter("@numberTop",topNum)
                            };
            var r = DataHelper.ExecuteReader(Config.ConnectionString, "usp_Support_GetList", param);
            while (r.Read())
            {
                list.Add(new SupportInfo
                             {
                                 pk_Id = (int)r["pk_ID"],
                                 s_Name = r["s_Name"].ToString(),
                                 s_Email = r["s_Email"].ToString(),
                                 s_Mobile = r["s_Mobile"].ToString(),
                                 s_Skype = r["s_Skype"].ToString(),
                                 s_Yahoo = r["s_Yahoo"].ToString()
                             });
            }
            r.Close();
            r.Dispose();
            return list;
        }
        #endregion getListSupportInfo

        #region Update
        public int Update(SupportInfo support)
        {
            var param = new[]
                            {
                                new SqlParameter("@pk_ID",support.pk_Id), 
                                new SqlParameter("@s_Name", support.s_Name),
                                new SqlParameter("@s_Email", support.s_Email),   
                                new SqlParameter("@s_Mobile", support.s_Mobile),
                                new SqlParameter("@s_Yahoo", support.s_Yahoo),
                                new SqlParameter("@s_Skype", support.s_Skype)
                            };
            var result = DataHelper.ExecuteNonQuery(Config.ConnectionString, "usp_Support_UPDATE", param);
            return result;
        }
        #endregion Update

        #region Delete
        public int Delete(int id)
        {
            var param = new[]
                            {   new SqlParameter("@pk_ID",id), 
                                
                            };
            var result = DataHelper.ExecuteNonQuery(Config.ConnectionString, "usp_Support_DELETE", param);
            return result;
        }
        #endregion Delete

        #region Insert
        public int Insert(SupportInfo support)
        {
            var param = new[]
                            {
                                new SqlParameter("@s_Name", support.s_Name),
                                new SqlParameter("@s_Email", support.s_Email),
                                new SqlParameter("@s_Mobile", support.s_Mobile),
                                new SqlParameter("@s_Yahoo", support.s_Yahoo),
                                new SqlParameter("@s_Skype", support.s_Skype)
                            };
            var result = DataHelper.ExecuteNonQuery(Config.ConnectionString, "usp_Support_INSERT", param);
            return result;
        }
        #endregion Insert

        #region GetInfo
        public SupportInfo GetInfo(int pk_ID)
        {
            var param = new[] { new SqlParameter("@pk_ID", pk_ID) };
            SupportInfo support = null;
            var r = DataHelper.ExecuteReader(Config.ConnectionString, "usp_Support_GetDetail", param);
            while (r.Read())
            {
                support = new SupportInfo
                              {
                                  pk_Id = (int)r["pk_ID"],
                                  s_Mobile = r["s_Mobile"].ToString(),
                                  s_Email = r["s_Email"].ToString(),
                                  s_Skype = r["s_Skype"].ToString(),
                                  s_Name = r["s_Name"].ToString(),
                                  s_Yahoo = r["s_Yahoo"].ToString()
                              };
            }
            r.Close(); r.Dispose();
            return support;
        }

        public List<SupportInfo> getListTop(int topNum)
        {
            var list = new List<SupportInfo>();
            var param = new[]
                            {
                                new SqlParameter("@numberTop",topNum)
                            };
            var r = DataHelper.ExecuteReader(Config.ConnectionString, "usp_Support_GetTop", param);
            while (r.Read())
            {
                list.Add(new SupportInfo
                {
                    pk_Id = (int)r["pk_ID"],
                    s_Name = r["s_Name"].ToString(),
                    s_Email = r["s_Email"].ToString(),
                    s_Mobile = r["s_Mobile"].ToString(),
                    s_Skype = r["s_Skype"].ToString(),
                    s_Yahoo = r["s_Yahoo"].ToString()
                });
            }
            r.Close();
            r.Dispose();
            return list;
        }

        #endregion GetInfo


        List<SupportInfo> ISupport.getListSupportInfo()
        {
            var list = new List<SupportInfo>();
            var r = DataHelper.ExecuteReader(Config.ConnectionString,"Select * from tbl_support");
            while (r.Read())
            {
                list.Add(new SupportInfo
                {
                    pk_Id = (int)r["pk_ID"],
                    s_Name = r["s_Name"].ToString(),
                    s_Email = r["s_Email"].ToString(),
                    s_Mobile = r["s_Mobile"].ToString(),
                    s_Skype = r["s_Skype"].ToString(),
                    s_Yahoo = r["s_Yahoo"].ToString()
                });
            }
            r.Close();
            r.Dispose();
            return list;
        }

   
    }
}
