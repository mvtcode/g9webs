using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using G9.Entity;

namespace G9.Service
{
    public interface IProductDetail
    {
        int Insert(ProductDetailInfo productDetail);
        int Update(ProductDetailInfo productDetail);
        //int Delete(int id);
        ProductDetailInfo GetProductDetailInfo(int id);
        List<ProductDetailInfo> GetAllByProduct(int id);
    }
}
