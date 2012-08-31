using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using App_Code.Caching;
using G9.Entity;
using System.Text;
using System.Collections.Generic;
using G9.Core;
using RelaxFunx.Core.Utility;

/// <summary>
/// Summary description for TinTuc
/// </summary>
namespace App_Code.Controls.TinTuc
{
    public class TinTuc
    {
        public static string BuildNewNoiBat(NewsInfo entity)
        {
            #if !DEBUG
                var oData = CacheController.GetNews(entity.pk_Id);
                if (oData != null) return oData.ToString();
            #endif
            var sb = new StringBuilder();
            sb.AppendFormat("<img class=\"anhnoibat\" width=\"320\" src=\"{0}\" alt=\"\" title=\"{1}\"/>", UntilityFunction.GetPathImg(entity.s_Image),entity.s_Title);
            sb.AppendFormat("<a href=\"/Tin-Tuc/{0}/{1}.html\">{2}</a>", entity.pk_Id, UnicodeUtility.UrlRewriting(entity.s_Title), entity.s_Title);
            sb.AppendFormat("<strong>{0}</strong>", entity.s_Description);

            //sb.AppendFormat("<td><a href=\"{0}\"><img border=\"0\" src=\"{1}\"></a></td>", o.s_Homepage, o.s_Logo);
            string s = sb.ToString();
            #if !DEBUG
                CacheController.GetNews(entity.pk_Id, s);
            #endif
            return s;
        }

        public static string BuildNewTop(List<NewsInfo> list)
        {
            #if !DEBUG
                var oData = CacheController.GetListNews(list[0].pk_Id);
            if (oData != null) return oData.ToString();
            #endif
            var oData = CacheController.GetListNews(list[0].pk_Id);
            if (oData != null) return oData.ToString();

            var sb = new StringBuilder();
            sb.AppendFormat("<img class=\"anhnoibat\" src=\"{0}\" width=\"95\" alt=\"{1}\" title=\"\"/>", UntilityFunction.GetPathImgThumb(list[0].s_Image),list[0].s_Title);
            sb.AppendFormat("<a class=\"tieude\" href=\"/Tin-Tuc/{0}/{1}.html\">{2}</a>", list[0].pk_Id, UnicodeUtility.UrlRewriting(list[0].s_Title), list[0].s_Title);
            sb.AppendFormat("<p>{0}</p>", list[0].s_Description);

            sb.Append("<div class=\"clear\"></div><ul>");
            for (int i = 1; i < list.Count; i++)
            {
                NewsInfo entity = list[i];
                sb.AppendFormat("<li><a href=\"/Tin-Tuc/{0}/{1}.html\">{2}</a></li>", entity.pk_Id, UnicodeUtility.UrlRewriting(entity.s_Title), entity.s_Title);
            }
            sb.Append("</ul>");
            //sb.AppendFormat("<td><a href=\"{0}\"><img border=\"0\" src=\"{1}\"></a></td>", o.s_Homepage, o.s_Logo);
            string s = sb.ToString();
            #if !DEBUG
                CacheController.GetListNews(list[0].pk_Id, s);
            #endif
            return s;
        }


        public static string BuildNewQuangCao(List<NewsInfo> list)
        {
            #if !DEBUG
                var oData = CacheController.GetListNews(list[0].pk_Id);
                if (oData != null) return oData.ToString();
            #endif
            var sb = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                NewsInfo entity = list[i];
                sb.Append("<div class=\"box_tingannhat\">");
                sb.AppendFormat("<img src=\"{0}\" width=\"68\" alt=\"{1}\" title=\"\"/>", UntilityFunction.GetPathImgThumb(entity.s_Image), entity.s_Title);
                sb.AppendFormat("<a href=\"/Tin-Tuc/{0}/{1}.html\">{2}</a>", entity.pk_Id, UnicodeUtility.UrlRewriting(entity.s_Title), entity.s_Title);
                sb.Append("</div>");
            }
            string s = sb.ToString();
            #if !DEBUG
                CacheController.GetListNews(list[0].pk_Id, s);
            #endif
            return s;
        }

        public static string BuildNewCuHon(List<NewsInfo> list)
        {
            #if !DEBUG
                var oData = CacheController.GetListNews(list[0].pk_Id);
                if (oData != null) return oData.ToString();
            #endif
            var sb = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                NewsInfo entity = list[i];
                sb.Append("<div class=\"box_tincuhon\">");
                sb.AppendFormat("<img src=\"{0}\" width=\"120\" alt=\"{1}\" title=\"\"/>", UntilityFunction.GetPathImgThumb(entity.s_Image),entity.s_Title);
                sb.AppendFormat("<a href=\"/Tin-Tuc/{0}/{1}.html\">{2}</a>", entity.pk_Id, UnicodeUtility.UrlRewriting(entity.s_Title), entity.s_Title);
                sb.AppendFormat("<span>{0} | {1}</span>", entity.d_DateCreated.ToString("hh:mm"), entity.d_DateCreated.ToString("dd/MM/yyyy"));
                sb.AppendFormat("<div style=\"text-align:justify\">{0}</div>", entity.s_Description);
                sb.Append("</div>");
                sb.Append("<div class=\"clear\"></div>");
            }
            string s = sb.ToString();
            #if !DEBUG
                CacheController.GetListNews(list[0].pk_Id, s);
            #endif
            return s;
        }

        public static string BuildNewCuHonTrai(List<NewsInfo> list)
        {
            #if !DEBUG
                var oData = CacheController.GetListNews(list[0].pk_Id);
                if (oData != null) return oData.ToString();
            #endif
            var sb = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                NewsInfo entity = list[i];
                if (i % 2 == 0)
                {
                    sb.AppendFormat("<li><a href=\"/Tin-Tuc/{0}/{1}.html\">{2}</a></li>", entity.pk_Id, UnicodeUtility.UrlRewriting(entity.s_Title), entity.s_Title);
                }
            }
            string s = sb.ToString();
            #if !DEBUG
                CacheController.GetListNews(list[0].pk_Id, s);
            #endif
            return s;
        }

        public static string BuildNewCuHonPhai(List<NewsInfo> list)
        {
            #if !DEBUG
                var oData = CacheController.GetListNews(list[0].pk_Id);
                if (oData != null) return oData.ToString();
            #endif
            var sb = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                NewsInfo entity = list[i];
                if (i % 2 != 0)
                {
                    sb.AppendFormat("<li><a href=\"/Tin-Tuc/{0}/{1}.html\">{2}</a></li>", entity.pk_Id, UnicodeUtility.UrlRewriting(entity.s_Title), entity.s_Title);
                }
            }
            string s = sb.ToString();
            #if !DEBUG
                CacheController.GetListNews(list[0].pk_Id, s);
            #endif
            return s;
        }

        /////Detail
        public static string BuildContentItem(NewsInfo oItem)
        {
            #if !DEBUG
                var oData = CacheController.GetNews(oItem.pk_Id);
                if (oData != null) return oData.ToString();
            #endif

            StringBuilder sb = new StringBuilder();
            sb = new StringBuilder();
            sb.AppendFormat("<h3 class=\"colorxah\" style=\"padding:5px 0 0 7px;\">{0}</h3>", oItem.fk_CategoryName);
            sb.Append("<hr />");
            sb.AppendFormat("<p style=\"font-weight: bold;font-size:14pt;line-height: 20px; padding-left:5px; padding-bottom: 10px; padding-Right: 10px; text-align:justify\" >{0}</p>", oItem.s_Title);
            if (oItem.s_Image.Trim() != "")
            {
                //sb.AppendFormat("<script>DrawImgSize('{0}');</script>",UntilityFunction.GetPathImg(oItem.s_Image));
                //sb.AppendFormat("<img style=\"width:400px; display:block; margin:10px auto;\" src=\"{0}\" />", UntilityFunction.GetPathImg(oItem.s_Image));
                sb.AppendFormat("<div style=\"float:left\"><img alt=\"\" style=\"display:block;width:105px; padding:0px 10px 0px 10px;\" src=\"{0}\" /></div>", UntilityFunction.GetPathImgThumb(oItem.s_Image));
            }
            sb.AppendFormat("<p style=\"font-weight:bold; line-height: 15px; padding-left: 10px; padding-Right: 10px; text-align:justify\">{0}</p>", oItem.s_Description);
            sb.AppendFormat("<div style=\"clear:both\"></div>");
            sb.AppendFormat("<div style=\"padding: 10px; width: 680px;\"><div id=\"DivContent\">{0}</div></div>", oItem.s_Content);
            string s = sb.ToString();

            #if !DEBUG
                CacheController.GetNews(oItem.pk_Id,s);
            #endif

            return s;
        }

        public static string BuildContentOtherItem(List<NewsInfo> oList, int numColum, int iCurent)
        {
            //var oData = CacheController.GetListNewsOtherColumn(oList[0].fk_CategoryId, numColum, iCurent);
            #if !DEBUG
                var oData = CacheController.GetListNewsOtherColumn(oList[0].fk_CategoryId, iCurent);
                if (oData != null) return oData.ToString();
            #endif
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
                    sb[i % numColum].AppendFormat("<li><a href=\"/Tin-Tuc/{0}/{1}.html\">{2}</a></li>", o.pk_Id, UnicodeUtility.UrlRewriting(o.s_Title), o.s_Title);
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
            s = "<h2>Các bản tin khác:</h2>" + s;
            //CacheController.GetListNewsOtherColumn(oList[0].fk_CategoryId, numColum, iCurent, s);
            #if !DEBUG
                CacheController.GetListNewsOtherColumn(oList[0].fk_CategoryId, iCurent, s);
            #endif
            return s;
        }

    }
}