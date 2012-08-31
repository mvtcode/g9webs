using System.Collections.Generic;
using G9.Entity;

namespace G9.Service
{
    public interface INews
    {
        int Update(NewsInfo news);
        int Delete(int id);
        int Insert(NewsInfo news);
        NewsInfo GetInfo(int id);
        List<NewsInfo> SelectTopNews(int categoryId, int nTop);
        List<NewsInfo> ListRandomNews(int categoryId, int numberTop);
        List<NewsInfo> GetList(int categoryId, int pageIndex, int pageSize, out int totalRow);
        List<NewsInfo> GetList(int pageIndex, int pageSize, out int totalRow);
        List<NewsInfo> GetList_New(int fk_CategoryID, int numberTop);
        List<NewsInfo> GetList_New(int top);
        List<NewsInfo> GetRelateNewsInfo(int cate, int top);
        List<NewsInfo> GetAllNewsByType(int cate);
        List<NewsInfo> GetListStartRow(int categoryId, int pageIndex, int pageSize, int iStart, out int totalRow);
    }
}
