using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using App_Code.Caching;
using G9.Entity;
using System.Text;
using RelaxFunx.Core.Utility;

/// <summary>
/// Summary description for TuyenDung
/// </summary>
namespace App_Code.Controls.TuyenDung
{
    public class TuyenDung
    {
        public static string BuildContentItem(NewsInfo oItem)
        {
            var oData = CacheController.GetNews(oItem.pk_Id);
            if (oData != null) return oData.ToString();

            StringBuilder sb = new StringBuilder();
            sb = new StringBuilder();            
            sb.AppendFormat("<p style=\"font-size: 14pt; color:#666; margin-bottom:10px;\">{0}</p>", oItem.s_Title);
            sb.Append("<br>");
            sb.AppendFormat("<p style=\"text-align:justify\">{0}</p>", oItem.s_Content);
            string s=sb.ToString();
            CacheController.GetNews(oItem.pk_Id, s);
            return s;
        }

        public static string BuildContentOtherItem(List<NewsInfo> oList, int numColum,int iCurent)
        {
            //var oData = CacheController.GetListNewsOtherColumn(oList[0].fk_CategoryId, numColum, iCurent);
            var oData = CacheController.GetListNewsOtherColumn(oList[0].fk_CategoryId, iCurent);
            if (oData != null) return oData.ToString();

            StringBuilder[] sb = new StringBuilder[numColum];
            int i = 0;
            for (i = 0; i < sb.Length; i++)
            {
                sb[i] = new StringBuilder();
            }

            foreach (NewsInfo o in oList)
            {
                if (o.pk_Id != iCurent)
                {
                    sb[i % numColum].AppendFormat("<li><a href=\"/Tuyen-Dung/{0}/{1}.html\">{2}</a></li>", o.pk_Id,UnicodeUtility.UrlRewriting(o.s_Title), o.s_Title);
                    i++;
                }
            }
            string s = "";
            for (i = 0; i < numColum; i++)
            {
                if (i == numColum - 1)
                {
                    s += "<ul class=\"tinkhac_phai\">" + sb[i].ToString() + "</ul>";
                }
                else
                {
                    s += "<ul class=\"tinkhac_trai\">" + sb[i].ToString() + "</ul>";
                }
            }
            s="<h2>Các bản tin khác:</h2>" + s ;
            //CacheController.GetListNewsOtherColumn(oList[0].fk_CategoryId, numColum, iCurent, s);
            CacheController.GetListNewsOtherColumn(oList[0].fk_CategoryId, iCurent, s);
            return s;
        }
    }
}

