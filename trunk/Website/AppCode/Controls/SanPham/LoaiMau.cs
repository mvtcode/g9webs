using System.Collections.Generic;
using System.Text;
using App_Code.Caching;
using G9.Entity;
using RelaxFunx.Core.Utility;

namespace App_Code.Controls.ThietKeWeb
{
    public class LoaiMau
    {
        public static string BuildContentListItem(List<ProductTypeInfo> oList,int iType, int numColum)
        {
            #if !DEBUG
                var oData = CacheController.GetListProductType();
                if (oData != null) return oData.ToString();    
            #endif

            var sb = new StringBuilder[numColum];
            int i = 0;
            for (i = 0; i < sb.Length; i++)
            {
                sb[i] = new StringBuilder();
            }

            foreach (ProductTypeInfo o in oList)
            {
                sb[i % numColum].AppendFormat("<li><a href=\"/San-Pham/{0}/{1}.html#ChiTietSanPham\">{2}</a></li>", o.pk_ID, UnicodeUtility.UrlRewriting(o.s_ProductName), o.s_ProductName);
                i++;
            }

            string s = "";
            for (i = 0; i < numColum; i++)
            {
                if (i == numColum - 1)
                {
                    s += "<ul style=\"background-image:none\">" + sb[i] + "</ul>";
                }
                else
                {
                    s += "<ul>" + sb[i] + "</ul>";
                }
            }
            #if !DEBUG
                CacheController.GetListProductType(s);
            #endif
            return s;
        }
    }
}