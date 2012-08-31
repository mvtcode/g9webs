using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using App_Code.Caching;
using G9.Entity;
using System.Text;
using G9.Core;

/// <summary>
/// Summary description for ChiTiet
/// </summary>
namespace App_Code.Controls.ThietKeWeb
{
    public class ChiTiet
    {
        public static string BuildContentListItem(List<ProductsInfo> oList, int iType, int numColum, int iPage)
        {
            //var oData = CacheController.GetListProduct(iType, numColum);
            var oData = CacheController.GetListProduct(iType, iPage);
            if (oData != null) return oData.ToString();

            StringBuilder sb = new StringBuilder();
            int i = 0;
            sb = new StringBuilder();
            foreach (ProductsInfo o in oList)
            {
                if ((i % numColum) == (numColum - 1))
                {
                    sb.AppendFormat("<div class=\"box_sanpham cuoi\">");
                }
                else
                {
                    sb.AppendFormat("<div class=\"box_sanpham\">");
                }
                sb.Append("<div class=\"childContent\">");
                sb.AppendFormat("<a class=\"group1\" href=\"{0}\" border:\"0\" title=\"{1}\"><img alt=\"\" src=\"{2}\"/></a>", GetPathImage(o), o.s_Description, GetPathThumb(o));
                sb.Append("</div>");
                sb.AppendFormat("<p>{0}</p>", o.s_Name);
                sb.Append("</div>");
                i++;
            }
            string s = sb.ToString();
            //CacheController.GetListProduct(iType, numColum,s);
            CacheController.GetListProduct(iType, iPage, s);
            return s;
        }
        private static string GetPathThumb(ProductsInfo o)
        {
            if (o.s_Image.Trim().Length > 0)
            {
                #if !DEBUG
                    return Config.PathProductShow + "/" + o.s_Image;
                #else
                    return Config.PathProductShow + "/" + o.s_Image;
                #endif
            }
            else
            {
                return "";
            }
        }

        private static string GetPathImage(ProductsInfo o)
        {
            if (o.s_Image.Trim().Length > 0)
            {
                #if !DEBUG
                    return Config.PathProductShow + "/" + o.s_Image;
                #else
                    return Config.PathProductShow + "/" + o.s_Image;
                #endif
            }
            else
            {
                return "";
            }
        }
    }
}

