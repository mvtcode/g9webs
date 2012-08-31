using System.Collections.Generic;
using G9.Entity;
using System.Text;
using G9.Core;
using RelaxFunx.Core.Utility;
using App_Code.Caching;

namespace App_Code.Controls.GioiThieu
{
    public class GioiThieu
    {
        public static string BuildContentListItem(List<NewsInfo> oList,int index)
        {
            var oData = CacheController.GetListNews(oList[0].fk_CategoryId,index);
            if (oData == null)
            {
                string[] aA = new string[2];
                int n = oList.Count;
                int i;
                int iCurent = oList[0].pk_Id;
                for (i = 1; i < n; i++)
                {
                    if (oList[i].pk_Id == index)
                    {
                        iCurent = oList[i].pk_Id;
                    }
                }
                StringBuilder sb = new StringBuilder();
                StringBuilder[] osb = new StringBuilder[n - 1];

                if (n <= 1)
                {
                    osb[0] = new StringBuilder();
                }
                else
                {
                    for (i = 0; i < n - 1; i++)
                    {
                        osb[i] = new StringBuilder();
                    }
                }

                i = 0;
                foreach (NewsInfo o in oList)
                {
                    if (o.pk_Id == iCurent) 
                    {
                        sb.AppendFormat("<div><h2>{0}</h2>", o.s_Title);
                        sb.AppendFormat("<p style=\"padding-left: 10px;text-align:justify\">{0}</p>", o.s_Description);
                        sb.AppendFormat("<img style=\"padding-top: 5px; padding-bottom: 5px;\" alt=\"\" src=\"/images/line1dau.jpg\"></div>");
                        sb.AppendFormat("<div><div style=\"padding: 0px\"><div style=\"margin:0px 10px 10px 0px; float: left\">");
                        //sb.AppendFormat("<script>DrawImgSize('{0}')</script></div>",
                        sb.AppendFormat("<img alt=\"ảnh bài viết\" class=\"block\" style=\"width:180px; display:block; margin:5px auto;\" src=\"{0}\" /></div>",UntilityFunction.GetPathImg(o.s_Image));
                        sb.AppendFormat("<p style=\"text-align:justify\">{0}</p></div>", o.s_Content);
                        sb.Append("<div style=\"clear:both\"></div></div>");
                    }
                    else
                    {
                        osb[i].AppendFormat("<div id=\"sumenh{0}\">", i + 1);
                        osb[i].AppendFormat("<a href=\"/Gioi-Thieu/{0}/{1}.html\" class=\"tieudesumenh\">{2}</a>",
                                            o.pk_Id, UnicodeUtility.UrlRewriting(o.s_Title), o.s_Title);
                        osb[i].AppendFormat("<p style=\"padding-top: 0px;text-align:justify\">{0}</p>", o.s_Description);
                        osb[i].AppendFormat(
                            "<a class=\"chitiet\" href=\"/Gioi-Thieu/{0}/{1}.html\"><span class=\"chitietsm{2}\"></span><em>chi tiết</em><span class=\"chitietsm{2}\"></span></a>",
                            o.pk_Id, UnicodeUtility.UrlRewriting(o.s_Title), i + 1);
                        osb[i].AppendFormat("</div>");
                        i++;
                    }

                }
                string s = sb.ToString() + "<div id=\"gioithieu3\" class=\"block\">";
                foreach (var oS in osb)
                {
                    s += oS.ToString();
                }
                s+= "<div style=\"clear:both\"></div></div>";
                CacheController.GetListNews(oList[0].fk_CategoryId, index, s);
                return s;
            }
            else
            {
                string s = oData.ToString();
                return s;
            }
        }

        public static string Build_RightMenu(List<NewsInfo> oList)
        {
            StringBuilder sb = new StringBuilder();
            if(oList!=null)
            {
                if (oList.Count <= 0) return "";

                var oType = ServiceFactory.GetInstanceCategoryType().GetInfo(oList[0].fk_CategoryId);
                sb.AppendFormat("<h2 class=\"tieude\"><a href=\"javascrpt:void(0)\">{0}</a></h2>",oType.s_CategoryName);
                sb.Append("<div><ul class=\"list-ul\">");
                foreach (var newsInfo in oList)
                {
                    sb.AppendFormat("<li><a href=\"javascript:void(0)\" onclick=\"javascript:chitiet({0})\">{1}</a></li>", newsInfo.pk_Id, newsInfo.s_Title);
                }
                sb.Append("</ul></div>");
            }

            return sb.ToString();

        }

        public static string Build_ThongTinDauTu(List<CategoryTypeInfo> oList)
        {
            StringBuilder sb = new StringBuilder();
            if (oList != null)
            {
                if (oList.Count <= 0) return "";

                var oType = ServiceFactory.GetInstanceCategoryType().GetInfo(oList[0].ParentID);
                sb.AppendFormat("<h2 class=\"tieude\"><a href=\"javascrpt:void(0)\">{0}</a></h2>", oType.s_CategoryName);
                sb.Append("<div><ul class=\"list-ul\">");
                foreach (var oItem in oList)
                {
                    sb.AppendFormat("<li><a href=\"javascript:void(0)\" onclick=\"javascript:SelectList({0})\">{1}</a></li>", oItem.pk_ID, oItem.s_CategoryName);
                }
                sb.Append("</ul></div>");
            }

            return sb.ToString();

        }
    }
}