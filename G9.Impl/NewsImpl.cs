using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using G9.Core;
using G9.Entity;
using G9.Service;

namespace G9.Impl
{
    public class NewsImpl : INews
    {
        #region Update

        public int Update(NewsInfo news)
        {
            var cnObj = new SqlConnection(Config.ConnectionString);
            int result;
            using (cnObj)
            {
                SqlParameter[] sqlParameters = {
                                                   new SqlParameter("@pk_ID", news.pk_Id),
                                                   new SqlParameter("@s_Title", news.s_Title),
                                                   new SqlParameter("@s_Description", news.s_Description),
                                                   new SqlParameter("@s_Image",news.s_Image), 
                                                   new SqlParameter("@s_Content", news.s_Content),
                                                   new SqlParameter("@SortField", news.SortField),
                                                   new SqlParameter("@Active", news.Active?"Y":"N")

                                               };
                var cmd = new SqlCommand
                {
                    Connection = cnObj,
                    CommandText = "usp_News_UPDATE",
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddRange(sqlParameters);
                try
                {
                    cnObj.Open();
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    result = 0;
                }
            }
            return result;
        }

        #endregion

        #region Delete

        public int Delete(int id)
        {
            var cnObj = new SqlConnection(Config.ConnectionString);
            int result;
            using (cnObj)
            {
                var cmd = new SqlCommand
                {
                    CommandText = "usp_News_DELETE",
                    CommandType = CommandType.StoredProcedure,
                    Connection = cnObj
                };
                cmd.Parameters.AddWithValue("@pk_ID", id);
                try
                {
                    cnObj.Open();
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    result = 0;
                }
            }
            return result;
        }

        #endregion

        #region Insert

        public int Insert(NewsInfo news)
        {
            var cnObj = new SqlConnection(Config.ConnectionString);
            int result;
            using (cnObj)
            {
                SqlParameter[] sqlParameters = {
                                                   new SqlParameter("@s_Title", news.s_Title),
                                                   new SqlParameter("@s_Description", news.s_Description),
                                                   new SqlParameter("@s_Image",news.s_Image),
                                                   new SqlParameter("@s_Content", news.s_Content),
                                                   new SqlParameter("@fk_User", news.fk_UserId),
                                                   new SqlParameter("@s_FullName", news.s_FullName),
                                                   new SqlParameter("fk_CategoryID", news.fk_CategoryId),
                                                   new SqlParameter("@s_CategoryName", news.fk_CategoryName),
                                                   new SqlParameter("@SortField",news.SortField),
                                                   new SqlParameter("@Active",news.Active?"Y":"N")
                                               };
                var cmd = new SqlCommand
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "usp_News_Insert",
                    Connection = cnObj
                };
                cmd.Parameters.AddRange(sqlParameters);
                try
                {
                    cnObj.Open();
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    result = 0;
                }
            }
            return result;
        }

        #endregion

        #region GetInfo

        public NewsInfo GetInfo(int id)
        {
            NewsInfo news = null;
            var param = new[]
                            {
                                new SqlParameter("@pk_ID", SqlDbType.Int) {Value = id}
                            };
            var r = DataHelper.ExecuteReader(Config.ConnectionString, "usp_News_GETDetail", param);
            while (r.Read())
            {
                news = new NewsInfo
                {
                    pk_Id = UntilityFunction.IntegerForNull(r["pk_ID"]),
                    s_Title = UntilityFunction.StringForNull(r["s_Title"]),
                    s_Description = UntilityFunction.StringForNull(r["s_Description"]),
                    s_Image = UntilityFunction.StringForNull(r["s_Image"]),
                    s_Content = UntilityFunction.StringForNull(r["s_Content"]),
                    d_DateCreated = Convert.ToDateTime(r["d_DateCreated"]),
                    fk_UserId = UntilityFunction.IntegerForNull(r["fk_User"]),
                    s_FullName = UntilityFunction.StringForNull(r["s_FullName"]),
                    fk_CategoryId = UntilityFunction.IntegerForNull(r["fk_CategoryID"]),
                    fk_CategoryName = UntilityFunction.StringForNull(r["s_CategoryName"]),
                    SortField = UntilityFunction.IntegerForNull(r["SortField"]),
                    Active = (r["Active"].ToString() == "Y")
                };
            }
            r.Close();
            r.Dispose();
            return news;
        }

        #endregion

        #region SelectTopNews
        public List<NewsInfo> SelectTopNews(int category, int nTop)
        {
            List<NewsInfo> list = null;
            SqlParameter[] param = {
                                       new SqlParameter("@fk_CategoryID", category),
                                       new SqlParameter("@numberTop", nTop)
                                   };
            var r = DataHelper.ExecuteReader(Config.ConnectionString, "usp_News_Top", param);
            list = new List<NewsInfo>();
            while (r.Read())
            {
                list.Add(new NewsInfo
                {
                    pk_Id = Convert.ToInt32(r["pk_ID"].ToString()),
                    s_Title = r["s_Title"].ToString(),
                    s_Description = r["s_Description"].ToString(),
                    s_Content = r["s_Content"].ToString(),
                    s_Image = r["s_Image"].ToString(),
                    d_DateCreated = Convert.ToDateTime(r["d_DateCreated"]),
                    fk_UserId = Convert.ToInt32(r["fk_User"]),
                    s_FullName = r["s_FullName"].ToString(),
                    fk_CategoryId = Convert.ToInt32(r["fk_CategoryID"]),
                    fk_CategoryName = r["s_CategoryName"].ToString(),
                    SortField = Convert.ToInt32(r["SortField"].ToString()),
                    Active = (r["Active"].ToString() == "Y")
                });
            }
            r.Close();
            r.Dispose();
            return list;
        }
        #endregion

        #region ListRandomNews
        public List<NewsInfo> ListRandomNews(int categoryId, int numberTop)
        {
            List<NewsInfo> list = null;
            SqlParameter[] param = {
                                               new SqlParameter("@fk_CategoryID", SqlDbType.Int) {Value = categoryId},
                                               new SqlParameter("@numberTop", SqlDbType.Int) {Value = numberTop}
                                           };
            var r = DataHelper.ExecuteReader(Config.ConnectionString, "usp_News_NewRandom", param);
            list = new List<NewsInfo>();
            while (r.Read())
            {
                list.Add(new NewsInfo
                {
                    pk_Id = Convert.ToInt32(r["pk_ID"].ToString()),
                    s_Title = r["s_Title"].ToString(),
                    s_Description = r["s_Description"].ToString(),
                    s_Content = r["s_Content"].ToString(),
                    s_Image = r["s_Image"].ToString(),
                    d_DateCreated = Convert.ToDateTime(r["d_DateCreated"]),
                    fk_UserId = Convert.ToInt32(r["fk_User"]),
                    s_FullName = r["s_FullName"].ToString(),
                    fk_CategoryId = Convert.ToInt32(r["fk_CategoryID"]),
                    fk_CategoryName = r["s_CategoryName"].ToString(),
                    SortField = Convert.ToInt32(r["SortField"].ToString()),
                    Active = (r["Active"].ToString() == "Y")
                });
            }
            r.Close();
            r.Dispose();
            return list;
        }
        #endregion getByCategoryNews

        #region GetList
        public List<NewsInfo> GetList(int categoryId, int pageIndex, int pageSize, out int totalRow)
        {
            List<NewsInfo> list = null;
            var param = new SqlParameter[]
                            {
                                new SqlParameter("@fk_CategoryID", SqlDbType.Int) {Value = categoryId},
                                new SqlParameter("@pageIndex", SqlDbType.Int) {Value = pageIndex},
                                new SqlParameter("@pageSize", SqlDbType.Int) {Value = pageSize},
                                new SqlParameter("@totalrow", SqlDbType.Int) {Direction = ParameterDirection.Output},
                            };
            SqlCommand com;
            var r = DataHelper.ExecuteReader(Config.ConnectionString, "usp_News_List", param, out com);
            list = new List<NewsInfo>();
            while (r.Read())
            {
                list.Add(new NewsInfo
                {
                    pk_Id = Convert.ToInt32(r["pk_ID"].ToString()),
                    s_Title = r["s_Title"].ToString(),
                    s_Description = r["s_Description"].ToString(),
                    s_Content = r["s_Content"].ToString(),
                    s_Image = r["s_Image"].ToString(),
                    d_DateCreated = Convert.ToDateTime(r["d_DateCreated"]),
                    fk_UserId = Convert.ToInt32(r["fk_User"]),
                    s_FullName = r["s_FullName"].ToString(),
                    fk_CategoryId = Convert.ToInt32(r["fk_CategoryID"]),
                    fk_CategoryName = r["s_CategoryName"].ToString(),
                    SortField = Convert.ToInt32(r["SortField"].ToString()),
                    Active = (r["Active"].ToString() == "Y")
                });
            }
            r.Close(); r.Dispose();
            totalRow = UntilityFunction.IntegerForNull(com.Parameters[3].Value);
            return list;
        }

        public List<NewsInfo> GetList(int pageIndex, int pageSize, out int totalRow)
        {

            List<NewsInfo> list = null;
            var param = new[]
                            {
                                new SqlParameter("@pageIndex", SqlDbType.Int) {Value = pageIndex},
                                new SqlParameter("@pageSize", SqlDbType.Int) {Value = pageSize},
                                new SqlParameter("@totalrow", SqlDbType.Int) {Direction = ParameterDirection.Output},
                            };
            SqlCommand com;
            var r = DataHelper.ExecuteReader(Config.ConnectionString, "usp_News_ListNew", param, out com);
            list = new List<NewsInfo>();
            while (r.Read())
            {
                list.Add(new NewsInfo
                {
                    pk_Id = Convert.ToInt32(r["pk_ID"].ToString()),
                    s_Title = r["s_Title"].ToString(),
                    s_Description = r["s_Description"].ToString(),
                    s_Content = r["s_Content"].ToString(),
                    s_Image = r["s_Image"].ToString(),
                    d_DateCreated = Convert.ToDateTime(r["d_DateCreated"]),
                    fk_UserId = Convert.ToInt32(r["fk_User"]),
                    s_FullName = r["s_FullName"].ToString(),
                    fk_CategoryId = Convert.ToInt32(r["fk_CategoryID"]),
                    fk_CategoryName = r["s_CategoryName"].ToString(),
                    SortField = Convert.ToInt32(r["SortField"].ToString()),
                    Active = (r["Active"].ToString() == "Y")
                });
            }
            r.Close(); r.Dispose();
            totalRow = UntilityFunction.IntegerForNull(com.Parameters[3].Value);
            return list;
        }

        #endregion getByCategoryNews

        #region GetList_New

        public List<NewsInfo> GetList_New(int fk_CategoryID, int numberTop)
        {

            var list = new List<NewsInfo>();

            SqlParameter[] param = {
                                       new SqlParameter("@fk_CategoryID", SqlDbType.Int) {Value = fk_CategoryID},
                                       new SqlParameter("@numberTop", SqlDbType.Int) {Value = numberTop}
                                   };
            var r = DataHelper.ExecuteReader(Config.ConnectionString, "usp_News_TopNew", param);
            while (r.Read())
            {
                list.Add(new NewsInfo
                {
                    pk_Id = Convert.ToInt32(r["pk_ID"].ToString()),
                    s_Title = r["s_Title"].ToString(),
                    s_Description = r["s_Description"].ToString(),
                    s_Content = r["s_Content"].ToString(),
                    s_Image = r["s_Image"].ToString(),
                    d_DateCreated = Convert.ToDateTime(r["d_DateCreated"]),
                    fk_UserId = Convert.ToInt32(r["fk_User"]),
                    s_FullName = r["s_FullName"].ToString(),
                    fk_CategoryId = Convert.ToInt32(r["fk_CategoryID"]),
                    fk_CategoryName = r["s_CategoryName"].ToString(),
                    SortField = Convert.ToInt32(r["SortField"].ToString()),
                    Active = (r["Active"].ToString() == "Y")
                });
            }
            r.Close(); r.Dispose();
            return list;
        }

        public List<NewsInfo> GetList_New(int top)
        {
            List<NewsInfo> list = null;
            var r = DataHelper.ExecuteReader(Config.ConnectionString, "select top ("+top+") *  from tbl_News ");
            list = new List<NewsInfo>();
            while (r.Read())
            {
                list.Add(new NewsInfo
                {
                    pk_Id = Convert.ToInt32(r["pk_ID"].ToString()),
                    s_Title = r["s_Title"].ToString(),
                    s_Description = r["s_Description"].ToString(),
                    s_Content = r["s_Content"].ToString(),
                    s_Image = r["s_Image"].ToString(),
                    d_DateCreated = Convert.ToDateTime(r["d_DateCreated"]),
                    fk_UserId = Convert.ToInt32(r["fk_User"]),
                    s_FullName = r["s_FullName"].ToString(),
                    fk_CategoryId = Convert.ToInt32(r["fk_CategoryID"]),
                    fk_CategoryName = r["s_CategoryName"].ToString(),
                    SortField = Convert.ToInt32(r["SortField"].ToString()),
                    Active = (r["Active"].ToString() == "Y")
                });
            }
            r.Close(); r.Dispose();
            return list;
        }

        #endregion

        public List<NewsInfo> GetRelateNewsInfo(int cate, int top)
        {
            List<NewsInfo> list = null;
            var r = DataHelper.ExecuteReader(Config.ConnectionString, "select top (" + top + ") *  from tbl_News where fk_CategoryId="+cate);
            list = new List<NewsInfo>();
            while (r.Read())
            {
                list.Add(new NewsInfo
                {
                    pk_Id = Convert.ToInt32(r["pk_ID"].ToString()),
                    s_Title = r["s_Title"].ToString(),
                    s_Description = r["s_Description"].ToString(),
                    s_Content = r["s_Content"].ToString(),
                    s_Image = r["s_Image"].ToString(),
                    d_DateCreated = Convert.ToDateTime(r["d_DateCreated"]),
                    fk_UserId = Convert.ToInt32(r["fk_User"]),
                    s_FullName = r["s_FullName"].ToString(),
                    fk_CategoryId = Convert.ToInt32(r["fk_CategoryID"]),
                    fk_CategoryName = r["s_CategoryName"].ToString(),
                    SortField = Convert.ToInt32(r["SortField"].ToString()),
                    Active = (r["Active"].ToString() == "Y")
                });
            }
            r.Close(); r.Dispose();
            return list;
        }

        public DataTable SearchByCategoryAndTitle(int categoryId, string text)
        {
            DataTable dt;
            var param = new[]
                            {
                                new SqlParameter("@fk_CategoryID", SqlDbType.Int){Value = categoryId},
                                new SqlParameter("fk_User", SqlDbType.Int){Value = 0},
                                new SqlParameter("s_Title", SqlDbType.NVarChar){Value = text}
                            };
            return DataHelper.ExecuteQueryToDataSet("sp_New_Search", param, CommandType.StoredProcedure).Tables[0];
            
        }

        public List<NewsInfo> GetAllNewsByType(int cate)
        {
            List<NewsInfo> list = null;
            var r = DataHelper.ExecuteReader(Config.ConnectionString, "select *  from tbl_News where fk_CategoryId=" + cate + " Order by d_DateCreated DESC");
            list = new List<NewsInfo>();
            while (r.Read())
            {
                list.Add(new NewsInfo
                {
                    pk_Id = Convert.ToInt32(r["pk_ID"].ToString()),
                    s_Title = r["s_Title"].ToString(),
                    s_Description = r["s_Description"].ToString(),
                    s_Content = r["s_Content"].ToString(),
                    s_Image = r["s_Image"].ToString(),
                    d_DateCreated = Convert.ToDateTime(r["d_DateCreated"]),
                    fk_UserId = Convert.ToInt32(r["fk_User"]),
                    s_FullName = r["s_FullName"].ToString(),
                    fk_CategoryId = Convert.ToInt32(r["fk_CategoryID"]),
                    fk_CategoryName = r["s_CategoryName"].ToString(),
                    SortField = Convert.ToInt32(r["SortField"].ToString()),
                    Active = (r["Active"].ToString() == "Y")
                });
            }
            r.Close(); 
            r.Dispose();
            return list;
        }

        public List<NewsInfo> GetListStartRow(int categoryId, int pageIndex, int pageSize, int iStart, out int totalRow)
        {
            List<NewsInfo> list = null;
            SqlParameter[] param = {
                                       new SqlParameter("@fk_CategoryID", categoryId),
                                       new SqlParameter("@PageIndex", pageIndex),
                                       new SqlParameter("@pageSize", pageSize),
                                       new SqlParameter("@StartRow", iStart),
                                       new SqlParameter("@totalrow", SqlDbType.Int) {Direction = ParameterDirection.Output}
                                   };
            SqlCommand com;
            IDataReader r = DataHelper.ExecuteReader(Config.ConnectionString, "usp_News_List_StartRow", param, out com);
            list = new List<NewsInfo>();
            while (r.Read())
            {
                list.Add(new NewsInfo
                {
                    pk_Id = Convert.ToInt32(r["pk_ID"].ToString()),
                    s_Title = r["s_Title"].ToString(),
                    s_Description = r["s_Description"].ToString(),
                    s_Content = r["s_Content"].ToString(),
                    s_Image = r["s_Image"].ToString(),
                    d_DateCreated = Convert.ToDateTime(r["d_DateCreated"]),
                    fk_UserId = Convert.ToInt32(r["fk_User"]),
                    s_FullName = r["s_FullName"].ToString(),
                    fk_CategoryId = Convert.ToInt32(r["fk_CategoryID"]),
                    fk_CategoryName = r["s_CategoryName"].ToString(),
                    SortField = Convert.ToInt32(r["SortField"].ToString()),
                    Active = (r["Active"].ToString() == "Y")
                });
            }
            r.Close();
            r.Dispose();
            totalRow = UntilityFunction.IntegerForNull(com.Parameters[4].Value);
            return list;
        }
    }
}
