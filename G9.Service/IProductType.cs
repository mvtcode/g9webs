using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using G9.Entity;
namespace G9.Service
{
    public  interface IProductType
    {
        int Insert(ProductTypeInfo info);
        int Update(ProductTypeInfo info);
        int Delete(int id);
        ProductTypeInfo GetInfo(int id);
        List<ProductTypeInfo> GetAllProduct();
        List<ProductTypeInfo> GetProductList(int pageIndex, int pageSize, out int totalrow);
    }
}
