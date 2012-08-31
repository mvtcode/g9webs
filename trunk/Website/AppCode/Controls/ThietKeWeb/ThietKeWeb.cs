using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using App_Code.Caching;
using G9.Entity;
using System.Text;
using RelaxFunx.Core.Utility;

/// <summary>
/// Summary description for ThietKeWebTheoChucNang
/// </summary>
namespace App_Code.Controls.ThietKeWeb
{
    public class ThietKeWeb
    {
        public static string BuildKhuyenMai(List<NewsInfo> oList, int numColum)
        {
            //var oData = CacheController.GetListNewsColumn(oList[0].fk_CategoryId,numColum);
            var oData = CacheController.GetListNewsColumn(oList[0].fk_CategoryId);
            if (oData != null) return oData.ToString();

            StringBuilder[] sb = new StringBuilder[numColum];
            int i = 0;
            for (i = 0; i < sb.Length; i++)
            {
                sb[i % numColum] = new StringBuilder();
            }

            foreach (NewsInfo o in oList)
            {
                sb[i % numColum].AppendFormat("<li><a href=\"/News/{0}/{1}.html\">{2}</a></li>", o.pk_Id,UnicodeUtility.UrlRewriting(o.s_Title), o.s_Title);
                i++;
            }

            string s = "";
            for (i = 0; i < sb.Length; i++)
            {
                if (i == numColum - 1)
                {
                    s += "<div class=\"ndtg1\"><ul style=\"background:none;\">" + sb[i].ToString() + "</ul></div>";
                }
                else
                {
                    s += "<div class=\"ndtg1\"><ul>" + sb[i].ToString() + "</ul></div>";
                }
            }
            //CacheController.GetListNewsColumn(oList[0].fk_CategoryId, numColum, s);
            CacheController.GetListNewsColumn(oList[0].fk_CategoryId, s);
            return s;
        }

        public static string BuildContent(List<NewsInfo> oList)
        {
            #if !DEBUG
                var oData = CacheController.GetListTronGoi(oList[0].fk_CategoryId);
                if (oData != null) return oData.ToString();
            #endif

            int numColum = 2;
            int iRow = (oList.Count % numColum != 0) ? ((int)oList.Count / numColum) : (oList.Count / numColum)-1;
            StringBuilder[] sb = new StringBuilder[iRow+1];
            int i = 0;
            for (i = 0; i < iRow+1; i++)
            {
                sb[i] = new StringBuilder();
            }

            i=1;
            foreach (NewsInfo o in oList)
            {
                int Row = (i % numColum != 0) ? ((int)i / numColum) : (i / numColum)-1;
                sb[Row].Append("<td width=\"50%\" class=\"td\" valign=\"top\">");
                sb[Row].AppendFormat("<div class=\"idtitle\" style=\"color:#09F;\">{0}</div>", o.s_Title);
                sb[Row].AppendFormat("<p>{0}</p>", o.s_Content);
                i++;
            }

            string s = "";
            for (i = 0; i < iRow+1; i++)
            {
                s += "<tr>" + sb[i].ToString() + "</tr>";
            }
            #if !DEBUG
                CacheController.GetListTronGoi(oList[0].fk_CategoryId, s);
            #endif
            return s;
        }       
    }
}
