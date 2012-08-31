using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using App_Code.Caching;
using G9.Entity;
using RelaxFunx.Core.Utility;

namespace App_Code.Controls.Home
{
    public class trongoi
    {
        public static string BuildContentListItem(List<NewsInfo> oList, int numColum)
        {
            //var oData = CacheController.GetListNewsColumn(oList[0].fk_CategoryId, numColum);
            var oData = CacheController.GetListNewsColumn(oList[0].fk_CategoryId);
            if (oData != null) return oData.ToString();

            var sb = new StringBuilder[numColum];
            int i = 0;
            for (i = 0; i < sb.Length; i++)
            {
                sb[i % numColum] = new StringBuilder();
            }

            foreach (NewsInfo o in oList)
            {
                sb[i % numColum].AppendFormat("<li><a href=\"/News/{0}/{1}.html\">{2}</a></li>", o.pk_Id, UnicodeUtility.UrlRewriting(o.s_Title), o.s_Title);
                i++;
            }

            string s = "";
            for (i = 0; i < sb.Length; i++)
            {
                if (i == numColum - 1)
                {
                    s += "<div class=\"ndtg1\" style=\"float:left;height:100%;\"><ul>" + sb[i] + "</ul></div>";
                }
                else
                {
                    s += "<div class=\"ndtg1\" style=\"float:left;height:100%;\"><ul>" + sb[i] + "</ul></div>";
                }
            }
            //CacheController.GetListNewsColumn(oList[0].fk_CategoryId, numColum, s);
            CacheController.GetListNewsColumn(oList[0].fk_CategoryId, s);
            return s;
        }
    }
}
