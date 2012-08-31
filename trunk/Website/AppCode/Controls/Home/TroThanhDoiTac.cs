using System.Collections.Generic;
using System.Text;
using App_Code.Caching;
using G9.Entity;
using RelaxFunx.Core.Utility;

/// <summary>
/// Summary description for TroThanhDoiTac
/// </summary>
namespace App_Code.Controls.Home
{
    public class TroThanhDoiTac
    {
        public static string BuildContentListItem(List<NewsInfo> oList, int numColum)
        {
            //var oData = CacheController.GetListNewsColumn(oList[0].fk_CategoryId, numColum);
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
                //sb[i % numColum].AppendFormat("<li><a style=\"text-align:justify;padding-right:10px\" href=\"/News/{0}/{1}.html\">{2}</a></li>", o.pk_Id, UnicodeUtility.UrlRewriting(o.s_Title), o.s_Title);
                sb[i % numColum].AppendFormat("<li><p style=\"text-align:justify;padding-right:10px\">{0}</p></li>",o.s_Title);
                i++;
            }

            string s = "";
            for (i = 0; i < sb.Length; i++)
            {
                if (i == numColum - 1)
                {
                    //no backgroup
                    s += "<div class=\"segment linec\"><ul>" + sb[i].ToString() + "</ul></div>";
                }
                else
                {
                    s += "<div class=\"segment\"><ul>" + sb[i].ToString() + "</ul></div>";
                }
            }

            //CacheController.GetListNewsColumn(oList[0].fk_CategoryId, numColum, s);
            CacheController.GetListNewsColumn(oList[0].fk_CategoryId, s);
            return s;
        }
    }
}
