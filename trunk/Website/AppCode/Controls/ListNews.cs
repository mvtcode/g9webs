using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using App_Code.Caching;
using G9.Entity;
using G9.Core;
using G9.Service;
using RelaxFunx.Core.Utility;

/// <summary>
/// Summary description for ListNews
/// </summary>
namespace App_Code.Controls
{
    public class ListNews
    {
        public static string BuildContentListItem(List<NewsInfo> oList)
        {
            var oData = CacheController.GetListNews(oList[0].fk_CategoryId);
            if (oData != null) return oData.ToString();

            var sb = new StringBuilder();
            foreach (NewsInfo o in oList)
            {
                sb.AppendFormat("<li><a href=\"/News/{0}/{1}.html\">{2}</a></li>", o.pk_Id,UnicodeUtility.UrlRewriting(o.s_Title), o.s_Title);
            }
            string s=sb.ToString();
            CacheController.GetListNews(oList[0].fk_CategoryId, s);
            return s;
        }
    }
}
