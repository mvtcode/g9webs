using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using G9.Core;
using G9.Entity;
using G9.Service;
using System.Data;

namespace G9.Impl
{
    public class ProductTypeImpl : IProductType
    {
        public int Insert(ProductTypeInfo info)
        {
            var param = new[]
                            {
                                new SqlParameter("@s_Product", info.s_ProductName),
                                new SqlParameter("@path", info.Path)
                            };
            var result = DataHelper.ExecuteNonQuery(Config.ConnectionString, "usp_ProductType_INSERT", param);
            return result;
        }

        public int Update(ProductTypeInfo info)
        {
            var param = new[]
                            {
                                new SqlParameter("@pk_ID", info.pk_ID),
                                new SqlParameter("@s_Product", info.s_ProductName)
                            };
            var result = DataHelper.ExecuteNonQuery(Config.ConnectionString, "usp_ProductType_UPDATE", param);
            return result;
        }

        public int Delete(int id)
        {
            var param = new[] {new SqlParameter("@pk_ID", id)};
            var result = DataHelper.ExecuteNonQuery(Config.ConnectionString, "usp_ProductType_DELETE", param);
            return result;
        }

        public ProductTypeInfo GetInfo(int id)
        {
            ProductTypeInfo products = null;
            var param = new[] { new SqlParameter("@pk_ID", id) };
            var r = DataHelper.ExecuteReader(Config.ConnectionString, "usp_ProductType_GetDetail", param);
            while (r.Read())
            {
                products = new ProductTypeInfo
                               {
                                   pk_ID = Convert.ToInt32( r["pk_ID"]),
                                   s_ProductName = r["s_Product"].ToString(),
                                   Path = r["Path"].ToString()
                               };
            }
            r.Close();
            r.Dispose();
            return products;
        }

        public List<ProductTypeInfo> GetAllProduct()
        {
            var list = new List<ProductTypeInfo>();
            var r = DataHelper.ExecuteReader(Config.ConnectionString, "usp_ProductType_GetAll");
            while (r.Read())
            {
                list.Add(new ProductTypeInfo
                {
                    pk_ID = Convert.ToInt32( r["pk_ID"]),
                    s_ProductName = r["s_Product"].ToString(),
                    Path = r["Path"].ToString()
                });
            } r.Close();
            r.Dispose();
            return list;
        }

        public List<ProductTypeInfo> GetProductList(int pageIndex, int pageSize, out int totalrow)
        {
            var list = new List<ProductTypeInfo>();
            var param = new[]
                            {
                                new SqlParameter("@pageIndex", pageIndex),
                                new SqlParameter("@Pagesize", pageSize),
                                new SqlParameter("@totalrow", SqlDbType.Int){Direction = ParameterDirection.Output}
                            };
            SqlCommand cmd;
            var r = DataHelper.ExecuteReader(Config.ConnectionString, "usp_ProductType_GetList", param, out cmd);
            while (r.Read())
            {
                list.Add(new ProductTypeInfo
                             {
                                 pk_ID = (int)r["pk_ID"],
                                 s_ProductName = r["s_Product"].ToString(),
                                 Path = r["Path"].ToString()
                             });
            }
            r.Close(); r.Dispose();
            totalrow = Convert.ToInt32(cmd.Parameters[2].Value);
            return list;
        }
    }
}
