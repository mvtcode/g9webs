using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using G9.Service;
using G9.Entity;
using G9.Core;
using System.Data;
using System.Data.SqlClient;
using G9.Web.Utility;

namespace G9.Impl
{
    public class CategoryTypeImpl:ICategoryType
    {

        #region ICategoryType Members

        public int Insert(CategoryTypeInfo info)
        {
            SqlParameter[] sqlParameter = {   
                                            new SqlParameter("@s_CategoryName",info.s_CategoryName),
                                            new SqlParameter("@ParentID",info.ParentID),
                                            new SqlParameter("@IsContent",info.IsContent)
                                          };
            int result = DataHelper.ExecuteNonQuery(Config.ConnectionString, "usp_CategoryType_Insert", sqlParameter);
            return result;
        }

        public int Update(CategoryTypeInfo info)
        {
            SqlParameter[] sqlParameter = {   
                                            new SqlParameter("@pk_ID",info.pk_ID), 
                                            new SqlParameter("@s_CategoryName", info.s_CategoryName),
                                            new SqlParameter("@ParentID",info.ParentID),
                                            new SqlParameter("@IsContent",info.IsContent)
                                          };
            int result = DataHelper.ExecuteNonQuery(Config.ConnectionString, "usp_CategoryType_UPDATE", sqlParameter);
            return result;
        }

        public int Delete(int id)
        {
            SqlParameter[] sqlParameter = {   
                                              new SqlParameter("@pk_ID",SqlDbType.Int){Value = id}
                                          };
            int result = DataHelper.ExecuteNonQuery(Config.ConnectionString, "usp_CategoryType_DELETE", sqlParameter);
            return result;
        }

        public CategoryTypeInfo GetInfo(int id)
        {
            CategoryTypeInfo oCategoryType = null;
            var param = new[]
                            {
                                new SqlParameter("@pk_ID", SqlDbType.Int){Value = id}
                            };
            var r = DataHelper.ExecuteReader(Config.ConnectionString, "usp_CategoryType_GetDetail", param);
            while (r.Read())
            {
                oCategoryType = new CategoryTypeInfo
                {
                    pk_ID = Convert.ToInt32(r["pk_ID"]),
                    s_CategoryName = r["s_CategoryName"].ToString(),
                    ParentID = ConvertUtility.ToInt32(r["ParentID"]),
                    IsContent = (r["IsContent"].ToString().ToLower() == "true")
                };
            }
            r.Close();
            r.Dispose();
            return oCategoryType;
        }

        public List<CategoryTypeInfo> GetAllCategory()
        {
            var list = new List<CategoryTypeInfo>();
            var r = DataHelper.ExecuteReader(Config.ConnectionString, "usp_CategoryType_GetAll");
            while (r.Read())
            {
                list.Add(new CategoryTypeInfo
                {
                    pk_ID = Convert.ToInt32(r["pk_ID"]),
                    s_CategoryName = r["s_CategoryName"].ToString(),
                    ParentID = ConvertUtility.ToInt32(r["ParentID"]),
                    IsContent = (r["IsContent"].ToString().ToLower()=="true")
                });
            }
            r.Close(); 
            r.Dispose();
            return list;
        }

        public List<CategoryTypeInfo> GetListCategory(int pageIndex, int pageSize, out int totalrow)
        {
            var list = new List<CategoryTypeInfo>();
            SqlParameter[] param = {
                                       new SqlParameter("@PageIndex",SqlDbType.Int){Value = pageIndex},  
                                       new SqlParameter("@PageSize", SqlDbType.Int){Value = pageSize}, 
                                       new SqlParameter("@totalrow",SqlDbType.Int){Direction = ParameterDirection.Output} 
                                   };
            SqlCommand com;
            var r = DataHelper.ExecuteReader(Config.ConnectionString, "usp_News_GetByCategoryId", param, out com);
            while (r.Read())
            {
                list.Add(new CategoryTypeInfo
                {
                    pk_ID = Convert.ToInt32(r["pk_ID"]),
                    s_CategoryName = r["s_CategoryName"].ToString(),
                    ParentID = ConvertUtility.ToInt32(r["ParentID"]),
                    IsContent = (r["IsContent"].ToString().ToLower() == "true")
                });
            }
            r.Close(); r.Dispose();
            totalrow = int.Parse(com.Parameters[3].Value.ToString());
            return list;
        }

        #endregion

        #region ICategoryType Members


        public List<CategoryTypeInfo> GetAll_ByParent(int iParentID)
        {
            var list = new List<CategoryTypeInfo>();
            SqlParameter[] param = {
                                       new SqlParameter("@parentID",SqlDbType.Int){Value = iParentID} 
                                   };
            var r = DataHelper.ExecuteReader(Config.ConnectionString, "usp_CategoryType_GetAllListByParent", param);
            while (r.Read())
            {
                list.Add(new CategoryTypeInfo
                {
                    pk_ID = Convert.ToInt32(r["pk_ID"]),
                    s_CategoryName = r["s_CategoryName"].ToString(),
                    ParentID = ConvertUtility.ToInt32(r["ParentID"]),
                    IsContent = (r["IsContent"].ToString().ToLower() == "true")
                });
            }
            r.Close(); r.Dispose();
            return list;
        }

        #endregion
    }
}

