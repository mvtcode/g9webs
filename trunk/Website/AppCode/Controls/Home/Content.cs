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
/// Summary description for Content
/// </summary>
namespace App_Code.Controls.Home
{
    public class ContentList
    {
        public static string BuildContentListItem(List<NewsInfo> oList)
        {
            var oData = CacheController.GetListNews(oList[0].fk_CategoryId);
            if (oData != null) return oData.ToString();

            var sb = new StringBuilder();
            foreach (NewsInfo o in oList)
            {
                sb.AppendFormat("<div class=\"top_content clearfix\">");
                    sb.AppendFormat("<div class=\"thumbnail floatLeft\">");
                    //sb.AppendFormat("<a href=\"/News.aspx?ID={0}\"><img width=\"105\" alt=\"\" src=\"{1}\"></a>", o.pk_Id, UntilityFunction.GetPathImgThumb(o.s_Image));
                    sb.AppendFormat("<a href=\"/News/{0}/{1}.html\"><img width=\"105\" alt=\"{3}\" src=\"{2}\"></a>", o.pk_Id, UnicodeUtility.UrlRewriting(o.s_Title), UntilityFunction.GetPathImgThumb(o.s_Image), o.s_Title);
                    sb.AppendFormat("</div>");
                    sb.AppendFormat("<div class=\"title floatLeft\" style=\"margin-top: 5px;\">");
                    //sb.AppendFormat("<a href=\"/News.aspx?ID={0}\"><h4>{1}</h4></a>", o.pk_Id, o.s_Title);
                    sb.AppendFormat("<a href=\"/News/{0}/{1}.html\"><h4>{2}</h4></a>", o.pk_Id,UnicodeUtility.UrlRewriting(o.s_Title), o.s_Title);

                    sb.AppendFormat("</div>");
                    sb.AppendFormat("<div class=\"introtext floatLeft\">");
                        sb.AppendFormat("<p>{0}</p>",o.s_Description);
                    sb.AppendFormat("</div>");
                    sb.AppendFormat("<div style=\"float:right\"><a class=\"readmore clearfix floatRight\" style=\"padding-right:10px\" href=\"/News/{0}/{1}.html\">Chi tiết &gt;&gt;</a></div>", o.pk_Id, UnicodeUtility.UrlRewriting(o.s_Title));
                sb.AppendFormat("</div>");
            }
            string s=sb.ToString();
            CacheController.GetListNews(oList[0].fk_CategoryId, s);
            return s;
        } 
    }
}