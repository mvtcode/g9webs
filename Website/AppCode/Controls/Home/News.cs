using System.Text;
using G9.Core;
using G9.Entity;
using RelaxFunx.Core.Utility;

namespace Website.App_Code.Controls.Home
{
    public class News
    {
        public static string BuildNews(NewsInfo oItem,string sType,string sDetail)//preview news in home page
        {
            //var oData = CacheController.GetListNewsColumn(oList[0].fk_CategoryId);
            //if (oData != null) return oData.ToString();
            if (oItem == null) return "";
            var sb = new StringBuilder();
            if(sType=="tuyen-dung")
            {
                sb.AppendFormat("<div class=\"NewsTitleLeft\"><a href=\"/tuyen-dung/Default.aspx\">{0}</a></div>", oItem.fk_CategoryName);    
            }
            else
            {
                if (sType == "tin-tuc")
                {
                    sb.AppendFormat("<div class=\"NewsTitleLeft\"><a href=\"/tin-tuc/\">{0}</a></div>",oItem.fk_CategoryName);    
                }
                else
                {
                    sb.AppendFormat("<div class=\"NewsTitleLeft\"><a href=\"/{2}?ID={0}\">{1}</a></div>", oItem.fk_CategoryId, oItem.fk_CategoryName, sType);        
                }
            }

            sb.Append("<div class=\"NewsTechnology\"><div style=\"MARGIN-TOP: 6px; TEXT-ALIGN: left;\">");
            sb.AppendFormat("<a href=\"/{2}?ID={0}\"><h4 style=\"color: #333333;text-decoration: none\">{1}</h4></a></div>", oItem.pk_Id, oItem.s_Title, sDetail);
            sb.AppendFormat("<div style=\"MARGIN: 10px 10px 10px 0px; FLOAT: left\"><a href=\"/{1}?ID={0}\">", oItem.pk_Id, sDetail);
            sb.AppendFormat("<img style=\"WIDTH: 105px; max-height: 120px;\" src=\"{0}\" alt=\"{1}\" /></a></div>", UntilityFunction.GetPathImgThumb(oItem.s_Image), oItem.s_Title);
            sb.AppendFormat("<div style=\"TEXT-ALIGN: justify;\">{0}</div></div>", oItem.s_Description);
            sb.AppendFormat("<div style=\"FLOAT: right;clear: both;padding-top: 6px\"><a href=\"/{1}?ID={0}\" style=\"PADDING-RIGHT: 10px; COLOR: #1683D2; TEXT-DECORATION: none; TEXT-TRANSFORM: none;\">Chi tiết &gt;&gt;</a></div>", oItem.pk_Id, sDetail);
            string s = sb.ToString();
            //CacheController.GetListNewsColumn(oList[0].fk_CategoryId, s);
            return s;
        }
    }
}