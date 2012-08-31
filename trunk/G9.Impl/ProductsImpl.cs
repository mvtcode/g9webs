using System;
using System.Collections.Generic;
using System.Data;
using G9.Entity;
using G9.Service;
using G9.Core;
using System.Data.SqlClient;

namespace G9.Impl
{
    public class ProductsImpl : IProducts
    {
        #region Insert

        public int Insert(ProductsInfo products)
        {
            var param = new[]
                            {
                                new SqlParameter("@s_Name", products.s_Name),
                                new SqlParameter("@s_Description", products.s_Description),
                                new SqlParameter("@f_price", products.f_Price),
                                //new SqlParameter("@fk_ProductID", products.fk_ProductID),
                                //new SqlParameter("@s_ProductName", products.s_ProductName),
                                new SqlParameter("@s_Image", products.s_Image),
                                new SqlParameter("@s_Content", products.s_Content),
                                new SqlParameter("@SortField",products.SortField), 
                                //new SqlParameter("@path",products.sPath), 
                                new SqlParameter("@Active",products.Active?"Y":"N")
                            };
            int result = DataHelper.ExecuteNonQuery(Config.ConnectionString, "usp_Product_Insert", param);
            return result;
        }
        #endregion Insert

        #region Update
        public int Update(ProductsInfo products)
        {
            var param = new[]
                            { 
                                new SqlParameter("@pk_ID",products.pk_ID), 
                                new SqlParameter("@s_Name", products.s_Name),
                                new SqlParameter("@s_Description", products.s_Description),
                                new SqlParameter("@f_price", products.f_Price),
                                new SqlParameter("@s_Image", products.s_Image),
                                new SqlParameter("@s_Content", products.s_Content),
                                new SqlParameter("@SortField",products.SortField), 
                                //new SqlParameter("@path",products.sPath), 
                                new SqlParameter("@Active",products.Active?"Y":"N")
                            };
            int result = DataHelper.ExecuteNonQuery(Config.ConnectionString, "usp_Product_UPDATE", param);
            return result;
        }
        #endregion Update

        #region Delete
        public int Delete(int id)
        {
            var param = new[] { new SqlParameter("@pk_ID", id) };
            var result = DataHelper.ExecuteNonQuery(Config.ConnectionString, "usp_Product_DELETE", param);
            return result;
        }
        #endregion

        #region GetProductInfo
        public ProductsInfo GetProductInfo(int id)
        {
            ProductsInfo pr = null;
            var param = new[] { new SqlParameter("@pk_ID", id) };
            var r = DataHelper.ExecuteReader(Config.ConnectionString, "usp_Product_GetDetail", param);
            while (r.Read())
            {
                pr = new ProductsInfo
                         {
                             pk_ID = UntilityFunction.IntegerForNull((r["pk_ID"])),
                             s_Name = UntilityFunction.StringForNull(r["s_Name"]),
                             s_Description = UntilityFunction.StringForNull(r["s_Description"]),
                             f_Price = UntilityFunction.DoubleForNull(r["f_Price"]),
                             //fk_ProductID = UntilityFunction.IntegerForNull(r["fk_ProductID"]),
                             //s_ProductName = UntilityFunction.StringForNull(r["s_ProductName"]),
                             s_Image = UntilityFunction.StringForNull(r["s_Image"]),
                             s_Content = UntilityFunction.StringForNull(r["s_Content"]),
                             d_CreateDate = Convert.ToDateTime(r["d_CreateDate"].ToString()),
                             SortField = UntilityFunction.IntegerForNull(r["SortField"]),
                             //sPath = UntilityFunction.StringForNull(r["path"]),
                             Active = (UntilityFunction.StringForNull(r["Active"]) == "Y")
                         };
            }
            r.Close(); r.Dispose();
            return pr;
        }
        #endregion

        #region SelectNewProducts
        public List<ProductsInfo> SelectNewProducts(int numberTop)
        {
            var list = new List<ProductsInfo>();
            var param = new[]
                            {
                                //new SqlParameter("@fk_ProductID", fk_ProductID),
                                new SqlParameter("@numberTop", numberTop)
                            };
            var r = DataHelper.ExecuteReader(Config.ConnectionString, "usp_Product_GetNew", param);
            while (r.Read())
            {
                list.Add(new ProductsInfo
                             {
                                 pk_ID = UntilityFunction.IntegerForNull((r["pk_ID"])),
                                 s_Name = UntilityFunction.StringForNull(r["s_Name"]),
                                 s_Description = UntilityFunction.StringForNull(r["s_Description"]),
                                 f_Price = UntilityFunction.DoubleForNull(r["f_Price"]),
                                 //fk_ProductID = UntilityFunction.IntegerForNull(r["fk_ProductID"]),
                                 //s_ProductName = UntilityFunction.StringForNull(r["s_ProductName"]),
                                 s_Image = UntilityFunction.StringForNull(r["s_Image"]),
                                 s_Content = UntilityFunction.StringForNull(r["s_Content"]),
                                 d_CreateDate = Convert.ToDateTime(r["d_CreateDate"].ToString()),
                                 SortField = UntilityFunction.IntegerForNull(r["SortField"]),
                                 //sPath = UntilityFunction.StringForNull(r["path"]),
                                 Active = (UntilityFunction.StringForNull(r["Active"]) == "Y")
                             });
            }
            r.Close(); r.Dispose();
            return list;
        }
        #endregion SelectNewProducts

        #region SelectListProducts
        public List<ProductsInfo> SelectListProducts(int pageIndex, int pageSize, out int totalrow)
        {
            var list = new List<ProductsInfo>();
            var param = new[]
                            {
                                //new SqlParameter("@fk_ProductID",SqlDbType.Int){Value = fk_ProductID}, 
                                new SqlParameter("@PageIndex", SqlDbType.Int){Value = pageIndex},
                                new SqlParameter("@PageSize", SqlDbType.Int){Value = pageSize},
                                new SqlParameter("@totalrow",SqlDbType.Int){Direction = ParameterDirection.Output}
                            };
            SqlCommand cmd;
            var r = DataHelper.ExecuteReader(Config.ConnectionString, "usp_Product_GetList", param, out cmd);
            while (r.Read())
            {
                list.Add(new ProductsInfo
                {
                    pk_ID =UntilityFunction.IntegerForNull((r["pk_ID"])),
                    s_Name = UntilityFunction.StringForNull(r["s_Name"]),
                    s_Description = UntilityFunction.StringForNull(r["s_Description"]),
                    f_Price = UntilityFunction.DoubleForNull(r["f_Price"].ToString()),
                    //fk_ProductID = UntilityFunction.IntegerForNull(r["fk_ProductID"]),
                    //s_ProductName =UntilityFunction.StringForNull(r["s_ProductName"]),
                    s_Image = UntilityFunction.StringForNull(r["s_Image"]),
                    s_Content =UntilityFunction.StringForNull(r["s_Content"]),
                    d_CreateDate = Convert.ToDateTime(r["d_CreateDate"].ToString()),
                    SortField =UntilityFunction.IntegerForNull(r["SortField"]),
                    //sPath = UntilityFunction.StringForNull(r["path"]),
                    Active = (UntilityFunction.StringForNull(r["Active"]) == "Y")
                });
            }
            r.Close(); r.Dispose();
            totalrow = UntilityFunction.IntegerForNull(cmd.Parameters[2].Value);            
            return list;
        }
        #endregion SelectListProducts

        #region SelectNewstProducts
        public List<ProductsInfo> SelectNewstProducts(int fk_ProductID, int numberTop)
        {
            var list = new List<ProductsInfo>();
            var param = new[]
                            {
                                new SqlParameter("@fk_ProductID",SqlDbType.Int){Value = fk_ProductID}, 
                                new SqlParameter("@numberTop", SqlDbType.Int){Value = numberTop}
                            };
            var r = DataHelper.ExecuteReader(Config.ConnectionString, "usp_Product_GetNew", param);
            while (r.Read())
            {
                list.Add(new ProductsInfo
                {
                    pk_ID = UntilityFunction.IntegerForNull((r["pk_ID"])),
                    s_Name = UntilityFunction.StringForNull(r["s_Name"]),
                    s_Description = UntilityFunction.StringForNull(r["s_Description"]),
                    f_Price = UntilityFunction.DoubleForNull(r["f_Price"]),
                    //fk_ProductID = UntilityFunction.IntegerForNull(r["fk_ProductID"]),
                    //s_ProductName = UntilityFunction.StringForNull(r["s_ProductName"]),
                    s_Image = UntilityFunction.StringForNull(r["s_Image"]),
                    s_Content = UntilityFunction.StringForNull(r["s_Content"]),
                    d_CreateDate = Convert.ToDateTime(r["d_CreateDate"].ToString()),
                    SortField = UntilityFunction.IntegerForNull(r["SortField"]),
                    //sPath = UntilityFunction.StringForNull(r["path"]),
                    Active = (UntilityFunction.StringForNull(r["Active"]) == "Y")
                });
            }
            r.Close(); r.Dispose();
            return list;
        }
        #endregion SelectNewstProducts


        #region IProducts GetNew

        public List<ProductsInfo> GetNew(int pageIndex, int pageSize, out int totalrow)
        {
            var list = new List<ProductsInfo>();
            var param = new[]
                            {
                                new SqlParameter("@PageIndex",SqlDbType.Int){Value = pageIndex}, 
                                new SqlParameter("@PageSize",SqlDbType.Int){Value = pageSize}, 
                                new SqlParameter("@totalrow", SqlDbType.Int){Direction = ParameterDirection.Output}
                            };
            SqlCommand com;
            var r = DataHelper.ExecuteReader(Config.ConnectionString, "usp_Product_New", param, out com);
            while (r.Read())
            {
                list.Add(new ProductsInfo
                {
                    pk_ID = UntilityFunction.IntegerForNull((r["pk_ID"])),
                    s_Name = UntilityFunction.StringForNull(r["s_Name"]),
                    s_Description = UntilityFunction.StringForNull(r["s_Description"]),
                    f_Price = UntilityFunction.DoubleForNull(r["f_Price"]),
                    //fk_ProductID = UntilityFunction.IntegerForNull(r["fk_ProductID"]),
                    //s_ProductName = UntilityFunction.StringForNull(r["s_ProductName"]),
                    s_Image = UntilityFunction.StringForNull(r["s_Image"]),
                    s_Content = UntilityFunction.StringForNull(r["s_Content"]),
                    d_CreateDate = Convert.ToDateTime(r["d_CreateDate"].ToString()),
                    SortField = UntilityFunction.IntegerForNull(r["SortField"]),
                    //sPath = UntilityFunction.StringForNull(r["path"]),
                    Active = (UntilityFunction.StringForNull(r["Active"]) == "Y")
                });
            }
            r.Close(); r.Dispose();
            totalrow = UntilityFunction.IntegerForNull(com.Parameters[2].Value);
            return list;
        }

        #endregion

        public List<ProductsInfo> GetAll()
        {
            var list = new List<ProductsInfo>();
            var r = DataHelper.ExecuteReader(Config.ConnectionString, "usp_Product_GetAll");
            while (r.Read())
            {
                list.Add(new ProductsInfo
                {
                    pk_ID = UntilityFunction.IntegerForNull((r["pk_ID"])),
                    s_Name = UntilityFunction.StringForNull(r["s_Name"]),
                    s_Description = UntilityFunction.StringForNull(r["s_Description"]),
                    f_Price = UntilityFunction.DoubleForNull(r["f_Price"]),
                    //fk_ProductID = UntilityFunction.IntegerForNull(r["fk_ProductID"]),
                    //s_ProductName = UntilityFunction.StringForNull(r["s_ProductName"]),
                    s_Image = UntilityFunction.StringForNull(r["s_Image"]),
                    s_Content = UntilityFunction.StringForNull(r["s_Content"]),
                    d_CreateDate = Convert.ToDateTime(r["d_CreateDate"].ToString()),
                    SortField = UntilityFunction.IntegerForNull(r["SortField"]),
                    //sPath = UntilityFunction.StringForNull(r["path"]),
                    Active = (UntilityFunction.StringForNull(r["Active"]) == "Y")
                });
            }
            r.Close(); r.Dispose();
            return list;
        }

        public List<ProductsInfo> GetAllByType(int fk_ProductID)
        {
            var list = new List<ProductsInfo>();
            var param = new[]
                            {
                                new SqlParameter("@fk_ProductID",SqlDbType.Int){Value = fk_ProductID}
                            };
            var r = DataHelper.ExecuteReader(Config.ConnectionString, "usp_Product_GetAllByType", param);
            while (r.Read())
            {
                list.Add(new ProductsInfo
                {
                    pk_ID = UntilityFunction.IntegerForNull((r["pk_ID"])),
                    s_Name = UntilityFunction.StringForNull(r["s_Name"]),
                    s_Description = UntilityFunction.StringForNull(r["s_Description"]),
                    f_Price = UntilityFunction.DoubleForNull(r["f_Price"]),
                    //fk_ProductID = UntilityFunction.IntegerForNull(r["fk_ProductID"]),
                    //s_ProductName = UntilityFunction.StringForNull(r["s_ProductName"]),
                    s_Image = UntilityFunction.StringForNull(r["s_Image"]),
                    s_Content = UntilityFunction.StringForNull(r["s_Content"]),
                    d_CreateDate = Convert.ToDateTime(r["d_CreateDate"].ToString()),
                    SortField = UntilityFunction.IntegerForNull(r["SortField"]),
                    //sPath = UntilityFunction.StringForNull(r["path"]),
                    Active = (UntilityFunction.StringForNull(r["Active"]) == "Y")
                });
            }
            r.Close(); r.Dispose();
            return list;
        }
    }
}
