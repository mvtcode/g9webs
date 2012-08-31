using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LicSystem.Core;
using LicSystem.Entity;
using LicSystem.Service;
using System.Data;
using System.Data.SqlClient; 

namespace LicSystem.Impl
{
   public class CommentImpl:IComment
    {
        public int Update(CommentInfo oComment)
        {
            var param = new[]
                            {
                                new SqlParameter("@pk_ID", oComment.pk_Id),
                                new SqlParameter("@s_CusName", oComment.s_CusName),
                                new SqlParameter("@s_Comment", oComment.s_Comment),
                                new SqlParameter("@d_Date", oComment.d_Date),
                                new SqlParameter("@SortField",oComment.sortField), 
                                new SqlParameter("@Active",oComment.Active?"Y":"N")
                            };
            int result = DataHelper.ExecuteNonQuery(Config.ConnectionString, "usp_Comment_UPDATE", param);
            return result;
        }

        public int Delete(int id)
        {
            var param = new[]
                            {
                                new SqlParameter("@pk_ID", id)
                            };
            int result = DataHelper.ExecuteNonQuery(Config.ConnectionString, "usp_Comment_DELETE", param);
            return result;
        }

        public int Insert(CommentInfo oComment)
        {
            var param = new[]
                            {
                                new SqlParameter("@s_CusName", oComment.s_CusName),
                                new SqlParameter("@s_Comment", oComment.s_Comment),
                                new SqlParameter("@d_Date", oComment.d_Date),
                                new SqlParameter("@SortField",oComment.sortField), 
                                new SqlParameter("@Active",oComment.Active?"Y":"N")
                            };
            int result = DataHelper.ExecuteNonQuery(Config.ConnectionString, "usp_Comment_INSERT", param);
            return result;
        }

        public CommentInfo GetInfo(int id)
        {
            CommentInfo info = null;
            var param = new[] { new SqlParameter("@pk_ID", id) };
            var r = DataHelper.ExecuteReader(Config.ConnectionString, "usp_Comment_LoadDetail", param);
            while (r.Read())
            {
                info = new CommentInfo
                {
                    pk_Id = UntilityFunction.IntegerForNull((r["pk_ID"])),
                    d_Date = Convert.ToDateTime(r["d_Date"].ToString()),
                    s_Comment = UntilityFunction.StringForNull(r["s_Comment"]),
                    s_CusName = UntilityFunction.StringForNull(r["s_CusName"].ToString()),
                    sortField = UntilityFunction.IntegerForNull((r["SortField"])),
                    Active = (UntilityFunction.StringForNull(r["Active"]) == "Y")
                };
            }
            r.Close(); 
            r.Dispose();
            return info;
        }

        public List<CommentInfo> getListTop(int numbetTop)
        {
            var list = new List<CommentInfo>();
            var param = new[]
                            {
                                new SqlParameter("@numberTop", numbetTop)
                            };
            var r = DataHelper.ExecuteReader(Config.ConnectionString, "usp_Comment_LoadTop", param);
            while (r.Read())
            {
                list.Add(new CommentInfo
                {
                    pk_Id = UntilityFunction.IntegerForNull((r["pk_ID"])),
                    d_Date = Convert.ToDateTime(r["d_Date"].ToString()),
                    s_Comment = UntilityFunction.StringForNull(r["s_Comment"]),
                    s_CusName = UntilityFunction.StringForNull(r["s_CusName"].ToString()),
                    sortField = UntilityFunction.IntegerForNull((r["SortField"])),
                    Active = (UntilityFunction.StringForNull(r["Active"]) == "Y")
                });
            }
            return list;
        }

        public List<CommentInfo> getList(int pageIndex, int pageSize,out int totalrow)
        {
            var list = new List<CommentInfo>();
            var param = new[]
                            {
                                new SqlParameter("@PageIndex", pageIndex),
                                new SqlParameter("@PageSize", pageSize),
                                new SqlParameter("@totalrow",SqlDbType.Int){Direction = ParameterDirection.Output}
                            };
            SqlCommand com;
            var r = DataHelper.ExecuteReader(Config.ConnectionString, "usp_Comment_LoadList", param,out com);
            while (r.Read())
            {
                list.Add(new CommentInfo
                {
                    pk_Id = UntilityFunction.IntegerForNull((r["pk_ID"])),
                    d_Date = Convert.ToDateTime(r["d_Date"].ToString()),
                    s_Comment = UntilityFunction.StringForNull(r["s_Comment"]),
                    s_CusName = UntilityFunction.StringForNull(r["s_CusName"].ToString()),
                    sortField = UntilityFunction.IntegerForNull((r["SortField"])),
                    Active = (UntilityFunction.StringForNull(r["Active"]) == "Y")
                });
            }
            totalrow = UntilityFunction.IntegerForNull(com.Parameters[2].Value);
            return list;
        }
    }
}
