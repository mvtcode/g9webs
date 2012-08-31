using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using App_Code.Caching;
using G9.Entity;
using System.Text;
using G9.Core;
using G9.Web.Utility;
using RelaxFunx.Core.Utility;

/// <summary>
/// Summary description for News
/// </summary>
namespace Website.App_Code.Controls.News
{
    public class News
    {
        public static string BuildContentItem(NewsInfo oItem)
        {
            //#if !DEBUG
            //    var oData = CacheController.GetNews(oItem.pk_Id);
            //    if (oData != null) return oData.ToString();
            //#endif

            StringBuilder sb = new StringBuilder();
            sb = new StringBuilder();
            sb.AppendFormat("<h3 class=\"colorxah\" style=\"padding:5px 0 0 7px;\">{0}</h3>", oItem.fk_CategoryName);
            sb.Append("<hr />");
            sb.AppendFormat("<p style=\"font-weight: bold;font-size:14pt;line-height: 20px; padding-left:5px; padding-bottom: 10px; padding-Right: 10px; text-align:justify \" >{0}</p>", oItem.s_Title);
            if (oItem.s_Image.Trim() != "")
            {
                //sb.AppendFormat("<script>DrawImgSize('{0}');</script>",UntilityFunction.GetPathImg(oItem.s_Image));
                //sb.AppendFormat("<img style=\"width:400px; display:block; margin:10px auto;\" src=\"{0}\" />", UntilityFunction.GetPathImg(oItem.s_Image));
                sb.AppendFormat("<div style=\"float:left\"><img alt=\"{1}\" style=\"display:block;width:105px; padding:0px 10px 0px 10px;\" src=\"{0}\" /></div>", UntilityFunction.GetPathImgThumb(oItem.s_Image), oItem.s_Title);
            }
            sb.AppendFormat("<p style=\"font-weight:bold; line-height: 15px; padding-left: 10px; padding-Right: 10px; text-align:justify\">{0}</p>", oItem.s_Description);
            sb.AppendFormat("<div style=\"clear:both\"></div>");
            sb.AppendFormat("<div style=\"padding: 10px; width: 680px;\"><div id=\"DivContent\">{0}</div></div>", oItem.s_Content);
            string s = sb.ToString();

            //#if !DEBUG
            //    CacheController.GetNews(oItem.pk_Id,s);
            //#endif

            return s;
        }

        public static string BuildContentListNews(List<NewsInfo> oList)
        {
            var sb = new StringBuilder();
            if (oList != null)
            {
                if (oList.Count > 0)
                {
                    foreach (NewsInfo o in oList)
                    {
                        sb.Append("<div class=\"tintucbinhthuongbox\">");
                        sb.AppendFormat("<a href=\"/News.aspx?ID={0}\">", o.pk_Id);
                        sb.AppendFormat("<img style=\"width:139px\" title=\"{0}\" src=\"{1}\">{2}</a>", o.s_Title, UntilityFunction.GetPathImgThumb(o.s_Image), o.s_Title);
                        sb.AppendFormat("<p>{0}</p></div>", o.s_Description);
                    }
                }
            }
            return sb.ToString();
        }

        public static string BuildContentOtherItem(List<NewsInfo> oList, int iCurent, string sType)
        {
            var sb = new StringBuilder();
            if (oList != null)
            {
                if (oList.Count > 1)
                {
                    sb.Append("<div class=\"cacbantinkhac\"><span>Các bản tin khác</span><ul>");
                    foreach (NewsInfo o in oList)
                    {
                        if (o.pk_Id != iCurent)
                        {
                            sb.AppendFormat("<li><a href=\"/{0}?ID={1}\">{2}</a></li>", sType, o.pk_Id,o.s_Title);
                        }
                    }
                    sb.Append("</ul></div>");
                }
            }
            return sb.ToString();
        }

        //List news
        public static string Build_TinNoibat(NewsInfo oItem)
        {
            var sb = new StringBuilder();
            if (oItem != null)
            {
                sb.AppendFormat("<a href=\"/tin-tuc/{0}/{1}.html\"><img width=\"400\" height=\"220\" src=\"{2}\" title=\"{3}\" /></a>", oItem.pk_Id,
                                UnicodeUtility.UrlRewriting(oItem.s_Title),
                                UntilityFunction.GetPathImg(oItem.s_Image), oItem.s_Title);
                sb.AppendFormat("<h2><a href=\"/tin-tuc/{0}/{1}.html\">{2}</a></h2>", oItem.pk_Id,
                                UnicodeUtility.UrlRewriting(oItem.s_Title), oItem.s_Title);
                sb.AppendFormat("<p>{0}</p>", ConvertUtility.SetShortTile(oItem.s_Description, 120));
            }
            return sb.ToString();
        }

        public static string Build_TinMoi(List<NewsInfo> oList)
        {
            var sb = new StringBuilder();
            if (oList != null)
            {
                foreach (NewsInfo newsInfo in oList)
                {
                    sb.AppendFormat(
                        "<div class=\"tinmoinhatbox\"><a href=\"/Tin-Tuc/{0}/{1}.html\"><img width=\"50\" height=\"50\" src=\"{2}\" title=\"{3}\" />{3}</a></div>",
                        newsInfo.pk_Id, UnicodeUtility.UrlRewriting(newsInfo.s_Title),
                        UntilityFunction.GetPathImgThumb(newsInfo.s_Image), newsInfo.s_Title);
                }
            }
            return sb.ToString();
        }

        public static string Build_TinDoc(List<NewsInfo> oList)
        {
            var sb = new StringBuilder();
            if (oList != null)
            {
                foreach (NewsInfo newsInfo in oList)
                {
                    sb.AppendFormat(
                        "<div class=\"tintucbinhthuongbox\"><a href=\"/Tin-Tuc/{0}/{1}.html\"><img width=\"139\" height=\"98\" src=\"{2}\" title=\"{3}\" />{3}</a>",
                        newsInfo.pk_Id, UnicodeUtility.UrlRewriting(newsInfo.s_Title),
                        UntilityFunction.GetPathImgThumb(newsInfo.s_Image), newsInfo.s_Title);
                    sb.AppendFormat("<p>{0}</p></div>", newsInfo.s_Description);
                }
            }
            return sb.ToString();
        }
    }
}