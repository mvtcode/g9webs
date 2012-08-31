using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using G9.Entity;
using G9.Service;
using G9.Core;

namespace G9.Impl
{
    public class CustomerImpl: ICustomer
    {
        #region Insert
        public int Insert(CustomerInfo info)
        {
            
            SqlParameter[] sqlParameter = {
                                              new SqlParameter("@s_FullName",info.s_CustomerName),
                                              new SqlParameter("@s_Logo",info.s_Logo),
                                              new SqlParameter("@s_Address", info.s_Address),
                                              new SqlParameter("@s_Mobile",info.s_Mobile),
                                              new SqlParameter("@s_Email",info.s_Email),
                                              new SqlParameter("@s_Homepage",info.s_Homepage)
                                          };
            int result = DataHelper.ExecuteNonQuery(Config.ConnectionString, "usp_Customer_INSERT", sqlParameter);
            return result;
        }
        #endregion Insert

        #region Update
        public int Update(CustomerInfo info)
        {
            SqlParameter[] sqlParameter = {   new SqlParameter("@pk_ID",info.pk_Id), 
                                              new SqlParameter("@s_FullName",info.s_CustomerName),
                                              new SqlParameter("@s_Logo",info.s_Logo),
                                              new SqlParameter("@s_Address", info.s_Address),
                                              new SqlParameter("@s_Mobile",info.s_Mobile),
                                              new SqlParameter("@s_Email",info.s_Email),
                                              new SqlParameter("@s_Homepage",info.s_Homepage)
                                          };
            int result = DataHelper.ExecuteNonQuery(Config.ConnectionString, "usp_Customer_Update", sqlParameter);
            return result;
        }
        #endregion Update

        #region Delete
        public int Delete(int id)
        {
            var sqlParameter = new[]
                                   {
                                       new SqlParameter("@pk_ID", id)
                                   };
            int result = DataHelper.ExecuteNonQuery(Config.ConnectionString, "usp_Customer_DELETE", sqlParameter);
            return result;
        }
        #endregion Delete

        #region GetInfo
        public CustomerInfo GetInfo(int id)
        {
            CustomerInfo customer = null;
            var param = new[]
                            {
                                new SqlParameter("@pk_ID", id)
                            };
            var r = DataHelper.ExecuteReader(Config.ConnectionString, "usp_Customer_GetDetail", param);
            while (r.Read())
            {
                customer = new CustomerInfo
                               {
                                   pk_Id = Convert.ToInt32(r["pk_ID"]),
                                   s_CustomerName = r["s_FullName"].ToString(),
                                   s_Logo = r["s_Logo"].ToString(),
                                   s_Address = r["s_Address"].ToString(),
                                   s_Mobile = r["s_Mobile"].ToString(),
                                   s_Email = r["s_Email"].ToString(),
                                   s_Homepage = r["s_Homepage"].ToString(),
                                   d_CreateDate = Convert.ToDateTime(r["d_CreateDate"].ToString())
                               };
            }
            r.Close();
            r.Dispose();
            return customer;
        }
        #endregion GetInfo

        #region SelectTopCustomerNew
        public List<CustomerInfo> SelectTopCustomerNew(int numberTop)
        {
            var list = new List<CustomerInfo>();
            var param = new[]
                            {
                                new SqlParameter("@numberTop", numberTop)
                            };
            var r = DataHelper.ExecuteReader(Config.ConnectionString, "usp_Customer_TopNew", param);
            while (r.Read())
            {
                list.Add(new CustomerInfo
                {
                    pk_Id = Convert.ToInt32(r["pk_ID"]),
                    s_CustomerName = r["s_FullName"].ToString(),
                    s_Logo = r["s_Logo"].ToString(),
                    s_Address = r["s_Address"].ToString(),
                    s_Mobile = r["s_Mobile"].ToString(),
                    s_Email = r["s_Email"].ToString(),
                    s_Homepage = r["s_Homepage"].ToString(),
                    d_CreateDate = Convert.ToDateTime(r["d_CreatedDate"])
                });
            }
            r.Close(); r.Dispose();
            return list;
        }
        #endregion SelectTopCustomerNew

        #region SelectTopCustomer
        public List<CustomerInfo> SelectTopCustomer(int numberTop)
        {
            var list = new List<CustomerInfo>();
            var param = new[]
                            {
                                new SqlParameter("@numberTop", numberTop)
                            };
            var r = DataHelper.ExecuteReader(Config.ConnectionString, "usp_Customer_Top", param);
            while (r.Read())
            {
                list.Add(new CustomerInfo
                             {
                                 pk_Id = Convert.ToInt32(r["pk_ID"]),
                                 s_CustomerName = r["s_FullName"].ToString(),
                                 s_Logo = r["s_Logo"].ToString(),
                                 s_Address = r["s_Address"].ToString(),
                                 s_Mobile = r["s_Mobile"].ToString(),
                                 s_Email = r["s_Email"].ToString(),
                                 s_Homepage = r["s_Homepage"].ToString(),
                                 d_CreateDate = Convert.ToDateTime(r["d_CreateDate"])
                             });
            }
            r.Close();r.Dispose();
            return list;
        }
        #endregion SelectTopCustomer

        public List<CustomerInfo> GetListCustomer(int pageIndex, int pageSize, out int totalrow)
        {
            var list = new List<CustomerInfo>();
            var param = new[]
                            {
                               new SqlParameter("@pageIndex", SqlDbType.Int){Value = pageIndex}, 
                               new SqlParameter("@pageSize",SqlDbType.Int){Value = pageSize}, 
                               new SqlParameter("@totalrow",SqlDbType.Int){Direction = ParameterDirection.Output},
                            };
            SqlCommand com;
            var r = DataHelper.ExecuteReader(Config.ConnectionString, "usp_Customer_GetList", param, out com);
            while (r.Read())
            {
                list.Add(new CustomerInfo
                {
                    pk_Id = Convert.ToInt32(r["pk_ID"]),
                    s_CustomerName = r["s_FullName"].ToString(),
                    s_Logo = r["s_Logo"].ToString(),
                    s_Address = r["s_Address"].ToString(),
                    s_Mobile = r["s_Mobile"].ToString(),
                    s_Email = r["s_Email"].ToString(),
                    s_Homepage = r["s_Homepage"].ToString(),
                    d_CreateDate = Convert.ToDateTime(r["d_CreatedDate"])
                });
            }

            r.Close(); r.Dispose();
            totalrow = int.Parse(com.Parameters[2].Value.ToString());
            return list;
        }

        public List<CustomerInfo> GetListCustomer()
        {
            var list = new List<CustomerInfo>();
            var r = DataHelper.ExecuteReader(Config.ConnectionString, "select * from tbl_Customer");
            while (r.Read())
            {
                list.Add(new CustomerInfo
                {
                    pk_Id = Convert.ToInt32(r["pk_ID"]),
                    s_CustomerName = r["s_FullName"].ToString(),
                    s_Logo = r["s_Logo"].ToString(),
                    s_Address = r["s_Address"].ToString(),
                    s_Mobile = r["s_Mobile"].ToString(),
                    s_Email = r["s_Email"].ToString(),
                    s_Homepage = r["s_Homepage"].ToString(),
                    d_CreateDate = Convert.ToDateTime(r["d_CreateDate"])
                });
            }

            r.Close(); r.Dispose();
            return list;
        }
    }
}
