using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using App_Code.Caching;
using G9.Entity;
using System.Text;
using G9.Core;
using RelaxFunx.Core.Utility;

namespace Website.App_Code.Controls.SanPham
{
    public class Sanpham
    {
        public static string BuildContentListHomeItem(List<ProductsInfo> oList)
        {

            var sb = new StringBuilder();

            if (oList != null)
            {
                if (oList.Count > 0)
                {
                    foreach (ProductsInfo productsInfo in oList)
                    {
                        sb.Append("<div style=\"width: 325px; height: 210px; float: left; padding: 6px\"><div style=\"height:190px; overflow: hidden\">");
                        sb.AppendFormat("<div class=\"NewsTitleLeft\"><a href=\"/san-pham/Detail.aspx?ID={0}\">{1}</a></div>", productsInfo.pk_ID, productsInfo.s_Name);
                        sb.Append("<div style=\"margin: 10px 10px 4px 10px; float: left;clear: both; width: 120px; height: 153px;\">");
                        sb.AppendFormat("<a href=\"/san-pham/Detail.aspx?ID={0}\"><img style=\"width: 100%\" src=\"{1}\" alt=\"{2}\" style=\"max-height: 190px; width: 150px;\" /></a></div>", productsInfo.pk_ID, UntilityFunction.GetPathImgProduct(productsInfo.s_Image), productsInfo.s_Name);
                        sb.AppendFormat("<div style=\"text-align: justify;margin-top:10px\">{0}</div></div>", productsInfo.s_Description);
                        sb.Append("<div style=\"float: right; clear: both; padding-top: 6px\">");
                        sb.AppendFormat("<a href=\"/san-pham/Detail.aspx?ID={0}\"><h4 style=\"color: #333333;text-decoration: none;padding-left: 20px;\">Xem chi tiết</h4></a></div></div>", productsInfo.pk_ID);
                    }
                }
            }
            return sb.ToString();
        }

        public static string BuildContentListItem(List<ProductsInfo> oList)
        {
            var sb = new StringBuilder();

            if (oList != null)
            {
                if (oList.Count > 0)
                {
                    int i = 0;
                    foreach (ProductsInfo productsInfo in oList)
                    {
                        if (i == 0)
                        {
                            sb.AppendFormat("<div class=\"sanpham\" style=\"border-top:none\"><a href=\"/san-pham/Detail.aspx?ID={0}\"><img src=\"{1}\" />{2}</a>", productsInfo.pk_ID, UntilityFunction.GetPathImgProduct(productsInfo.s_Image), productsInfo.s_Name);
                        }
                        else
                        {
                            sb.AppendFormat("<div class=\"sanpham\"><a href=\"/san-pham/Detail.aspx?ID={0}\"><img src=\"{1}\" />{2}</a>", productsInfo.pk_ID, UntilityFunction.GetPathImgProduct(productsInfo.s_Image), productsInfo.s_Name);
                        }
                        sb.AppendFormat("<p>{0}</p></div>", productsInfo.s_Description);
                        i++;
                    }
                }
            }
            return sb.ToString();
        }

        public static string BuildContentTopDetail(ProductsInfo oItem)
        {
            var sb = new StringBuilder();

            if (oItem != null)
            {
                sb.AppendFormat("<div id=\"title-product\">{0}</div>", oItem.s_Name);
                sb.Append("<div style=\"clear: both\">");
                sb.AppendFormat("<div id=\"image-product\"><img width=\"160\" src=\"{0}\"/></div>", UntilityFunction.GetPathImgProduct(oItem.s_Image));
                sb.AppendFormat("<div id=\"description-product\">{0}</div>", oItem.s_Content);
                sb.Append("</div>");
            }
            return sb.ToString();
        }

        public static string BuildTab(List<ProductDetailInfo> oList)
        {
            var sbtitle = new StringBuilder();
            var sbcontent = new StringBuilder();
            if (oList != null)
            {
                if (oList.Count > 0)
                {
                    int i = 0;
                    sbtitle.AppendFormat("<div id=\"tabtitle\"><ul>");
                    sbcontent.AppendFormat("<div id=\"tabDetails\">");
                    foreach (ProductDetailInfo productDetailInfo in oList)
                    {
                        if (i == 0)
                        {
                            sbtitle.AppendFormat("<li><a class=\"active\" href=\"#{0}\">{1}</a></li>", UnicodeUtility.UrlRewriting(productDetailInfo.sTitle), productDetailInfo.sTitle);
                        }
                        else
                        {
                            sbtitle.AppendFormat("<li><a href=\"#{0}\">{1}</a></li>",UnicodeUtility.UrlRewriting(productDetailInfo.sTitle), productDetailInfo.sTitle);
                        }

                        sbcontent.AppendFormat("<div id=\"{0}\" class=\"tabContents\">{1}</div>",UnicodeUtility.UrlRewriting(productDetailInfo.sTitle), productDetailInfo.sContent);
                        i++;
                    }
                    sbtitle.AppendFormat("</div></ul>");
                    sbcontent.AppendFormat("</div>");
                }
            }
            return sbtitle.ToString() + sbcontent.ToString();
        }

        public static string BuildOtherList(List<ProductsInfo> oList,int iCurent)
        {
            var sb = new StringBuilder();
            if (oList != null)
            {
                if (oList.Count > 1)
                {
                    sb.Append("<div class=\"cacbantinkhac\"><span>Các bản tin khác</span><ul>");
                    foreach (ProductsInfo o in oList)
                    {
                        if (o.pk_ID != iCurent)
                        {
                            sb.AppendFormat("<li><a href=\"/san-pham/Detail.aspx?ID={0}\">{1}</a></li>", o.pk_ID,o.s_Name);
                        }
                    }
                    sb.Append("</ul></div>");
                }
            }
            return sb.ToString();
        }
    }
}