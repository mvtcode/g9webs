using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using G9.Core.Provider;
using G9.Web.Utility;

namespace App_Code.Caching
{
    public class CacheController
    {
        public static object GetListCus()
        {
            return CacheProvider.Get("GetListCus");
        }
        public static void GetListCus(string oData)
        {
            CacheProvider.AddWithTimeOut("GetListCus", oData, 600);
        }
        public static void GetListCus_Delete()
        {
            CacheProvider.Remove("GetListCus");
        }

        public static object GetListSupport()
        {
            return CacheProvider.Get("GetListSupport");
        }

        public static void GetListSupport(string oData)
        {
            CacheProvider.AddWithTimeOut("GetListSupport", oData, 600);
        }

        public static void GetListSupport_Delete()
        {
            CacheProvider.Remove("GetListSupport");
        }

        public static object GetNews(int id)
        {
            return CacheProvider.Get(string.Format("News-{0}", id));
        }
        public static void GetNews(int id, string oData)
        {
            CacheProvider.AddWithTimeOut(string.Format("News-{0}", id), oData, 600);
        }
        public static void GetNews_Delete(int id)
        {
            CacheProvider.Remove(string.Format("News-{0}", id));
        }

        public static object GetListNews(int oType)
        {
            return CacheProvider.Get(string.Format("ListNew-{0}", oType));
        }
        public static void GetListNews(int oType, string oData)
        {
            CacheProvider.AddWithTimeOut(string.Format("ListNew-{0}", oType), oData, 600);
        }
        public static void GetListNews_Delete1(int oType)
        {
            CacheProvider.Remove(string.Format("ListNew-{0}", oType));
        }

        public static object GetListNews(int oType, int iCurent)
        {
            return CacheProvider.Get(string.Format("ListNew-{0}-{1}", oType, iCurent));
        }
        public static void GetListNews(int oType, int iCurent, string oData)
        {
            CacheProvider.AddWithTimeOut(string.Format("ListNew-{0}-{1}", oType, iCurent), oData, 600);
        }
        public static void GetListNews_Delete2(int oType, int iCurent)
        {
            CacheProvider.Remove(string.Format("ListNew-{0}-{1}", oType, iCurent));
        }

        public static object GetListNewsColumn(int oType)
        {
            return CacheProvider.Get(string.Format("ListNewColumn1-{0}", oType));
        }
        public static void GetListNewsColumn(int oType, string oData)
        {
            CacheProvider.AddWithTimeOut(string.Format("ListNewColumn1-{0}", oType), oData, 600);
        }
        public static void GetListNewsColumn_Delete(int oType)
        {
            CacheProvider.Remove(string.Format("ListNewColumn1-{0}", oType));
        }

        public static object GetListNewsOtherColumn(int oType, int iCurent)
        {
            return CacheProvider.Get(string.Format("ListNewColumn2-{0}-{1}", oType, iCurent));
        }
        public static void GetListNewsOtherColumn(int oType, int iCurent, string oData)
        {
            CacheProvider.AddWithTimeOut(string.Format("ListNewColumn2-{0}-{1}", oType, iCurent), oData, 600);
        }
        public static void GetListNewsOtherColumn_Delete(int oType, int iCurent)
        {
            CacheProvider.Remove(string.Format("ListNewColumn2-{0}-{1}", oType, iCurent));
        }

        public static object GetListTronGoi(int oType)
        {
            return CacheProvider.Get(string.Format("ListTronGoi-{0}", oType));
        }
        public static void GetListTronGoi(int oType, string oData)
        {
            CacheProvider.AddWithTimeOut(string.Format("ListTronGoi-{0}", oType), oData, 600);
        }
        public static void GetListTronGoi_Delete(int oType)
        {
            CacheProvider.Remove(string.Format("ListTronGoi-{0}", oType));
        }

        public static object GetListProduct(int oType,int iPage)
        {
            return CacheProvider.Get(string.Format("Product-{0}-{1}", oType,iPage));
        }
        public static void GetListProduct(int oType,int iPage, string oData)
        {
            CacheProvider.AddWithTimeOut(string.Format("Product-{0}-{1}", oType, iPage), oData, 600);
        }
        public static void GetListProduct_Delete(int oType, int iPage)
        {
            CacheProvider.Remove(string.Format("Product-{0}-{1}", oType, iPage));
        }

        public static object GetListProductType()
        {
            return CacheProvider.Get(string.Format("ProductType"));
        }
        public static void GetListProductType(string oData)
        {
            CacheProvider.AddWithTimeOut(string.Format("ProductType"), oData, 600);
        }
        public static void GetListProductType_Delete()
        {
            CacheProvider.Remove(string.Format("ProductType"));
        }

        public static object GetListHoTro()
        {
            return CacheProvider.Get("GetListhoTro");
        }
        public static void GetListHoTro(string oData)
        {
            CacheProvider.AddWithTimeOut("GetListhoTro", oData, 600);
        }
        public static void GetListHoTro_Delete()
        {
            CacheProvider.Remove("GetListhoTro");
        }
    }
}
