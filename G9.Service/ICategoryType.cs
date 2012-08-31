using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using G9.Entity;

namespace G9.Service
{
    public interface ICategoryType
    {
        int Insert(CategoryTypeInfo info);
        int Update(CategoryTypeInfo info);
        int Delete(int id);
        CategoryTypeInfo GetInfo(int id);
        List<CategoryTypeInfo> GetAllCategory();
        List<CategoryTypeInfo> GetListCategory(int pageIndex, int pageSize, out int totalrow);
        List<CategoryTypeInfo> GetAll_ByParent(int iParentID);
    }
}
