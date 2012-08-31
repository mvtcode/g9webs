using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using G9.Core;
using G9.Entity;
using G9.Service;

namespace G9.Impl
{
    public class ProductDetailImpl : IProductDetail
    {
        public int Insert(ProductDetailInfo productDetail)
        {
            var param = new[]
                            {
                                new SqlParameter("@productID", productDetail.productId),
                                new SqlParameter("@ProductName", productDetail.productName),
                                new SqlParameter("@sTitle", productDetail.sTitle),
                                new SqlParameter("@sContent", productDetail.sContent),
                                new SqlParameter("@sFile", productDetail.sFile),
                                new SqlParameter("@Sort",productDetail.Sort), 
                                new SqlParameter("@Active",productDetail.Active)
                            };
            int result = DataHelper.ExecuteNonQuery(Config.ConnectionString, "sp_ProductDetail_Insert", param);
            return result;
        }

        public int Update(ProductDetailInfo productDetail)
        {
            var param = new[]
                            { 
                                new SqlParameter("@id", productDetail.id),
                                //new SqlParameter("@sTitle", productDetail.sTitle),
                                new SqlParameter("@sContent", productDetail.sContent),
                                new SqlParameter("@sFile", productDetail.sFile),
                                //new SqlParameter("@Sort",productDetail.Sort), 
                                //new SqlParameter("@Active",productDetail.Active)
                            };
            int result = DataHelper.ExecuteNonQuery(Config.ConnectionString, "sp_ProductDetail_Update", param);
            return result;
        }

        //public int Delete(int id)
        //{
        //    throw new NotImplementedException();
        //}

        public ProductDetailInfo GetProductDetailInfo(int id)
        {
            ProductDetailInfo item = null;
            var param = new[] { new SqlParameter("@id", id) };
            var r = DataHelper.ExecuteReader(Config.ConnectionString, "sp_ProductDetail_GetInfo", param);
            while (r.Read())
            {
                item = new ProductDetailInfo
                {
                    id = UntilityFunction.IntegerForNull((r["id"])),
                    sTitle = UntilityFunction.StringForNull(r["sTitle"]),
                    productId = UntilityFunction.IntegerForNull(r["productId"]),
                    productName = UntilityFunction.StringForNull(r["productName"]),
                    sContent = UntilityFunction.StringForNull(r["sContent"]),
                    sFile = UntilityFunction.StringForNull(r["sFile"]),
                    DateCreated = Convert.ToDateTime(r["DateCreated"].ToString()),
                    DateUpdate = Convert.ToDateTime(r["DateUpdate"].ToString()),
                    Active =Convert.ToBoolean((r["Active"])),
                    Sort = UntilityFunction.IntegerForNull(r["Sort"])
                };
            }
            r.Close(); r.Dispose();
            return item;
        }

        public List<ProductDetailInfo> GetAllByProduct(int id)
        {
            var list = new List<ProductDetailInfo>();
            var param = new[] { new SqlParameter("@productID", id) };
            var r = DataHelper.ExecuteReader(Config.ConnectionString, "sp_ProductDetail_GetList", param);
            while (r.Read())
            {
                list.Add(new ProductDetailInfo
                {
                    id = UntilityFunction.IntegerForNull((r["id"])),
                    sTitle = UntilityFunction.StringForNull(r["sTitle"]),
                    productId = UntilityFunction.IntegerForNull(r["productId"]),
                    productName = UntilityFunction.StringForNull(r["productName"]),
                    sContent = UntilityFunction.StringForNull(r["sContent"]),
                    sFile = UntilityFunction.StringForNull(r["sFile"]),
                    DateCreated = Convert.ToDateTime(r["DateCreated"].ToString()),
                    DateUpdate = Convert.ToDateTime(r["DateUpdate"].ToString()),
                    Active = Convert.ToBoolean((r["Active"])),
                    Sort = UntilityFunction.IntegerForNull(r["Sort"])
                });
            }
            r.Close(); r.Dispose();
            return list;
        }
    }
}
