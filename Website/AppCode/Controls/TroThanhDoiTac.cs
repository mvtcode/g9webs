using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using G9.Entity;
using RelaxFunx.Core.Utility;

namespace App_Code.Controls
{
    public class TroThanhDoiTac
    {
        public static string BuildContentListItem(List<NewsInfo> oList, int numColum)
        {
            StringBuilder[] sb = new StringBuilder[numColum];
            int i = 0;
            for (i = 0; i < sb.Length; i++)
            {
                sb[i % numColum] = new StringBuilder();
            }

            foreach (NewsInfo o in oList)
            {
                sb[i % numColum].AppendFormat("<a href=\"/News/{0}/{1}.html\">{2}</a><br>", o.pk_Id,UnicodeUtility.UrlRewriting(o.s_Title), o.s_Title);
                i++;
            }

            string s = "";
            for (i = 0; i < sb.Length; i++)
            {
                s += "<div id=\"gt41\"><ul>" + sb[i].ToString() + "</div>";
            }
            return s;
        }
    }
}