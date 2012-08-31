using System.Collections.Generic;
using G9.Entity;

namespace G9.Service
{
    public interface IProducts
    {
        int Insert(ProductsInfo products);
        int Update(ProductsInfo products);
        int Delete(int id);
        ProductsInfo GetProductInfo(int id);
        List<ProductsInfo> SelectNewProducts(int numberTop);
        List<ProductsInfo> SelectListProducts(int pageIndex, int pageSize, out int totalrow);
        List<ProductsInfo> GetNew(int pageIndex, int pageSize, out int totalrow);
        List<ProductsInfo> GetAll();
        List<ProductsInfo> GetAllByType(int fk_ProductID);
    }
}
